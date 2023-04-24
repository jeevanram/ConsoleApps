using DataAccess.Api.OData;
using DataAccess.Database.DBContext;
using DataAccess.Database.Repository.Implementation;
using DataAccess.Database.Repository.Interface;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
    .AddOData(options => options.Select().Filter().OrderBy().Expand().SetMaxTop(null)
    .AddRouteComponents("odata", TestDBEdmBuilder.GetEdmModel(), services => services.AddSingleton<ODataResourceSerializer, OmitNullResourceSerializer>()).EnableQueryFeatures());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddDbContextCheck<TestDbContext>();

builder.Services.AddDbContext<TestDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDBSqlConnection"),
     sqlServerOptionsAction: sqlOptions =>
     {
         sqlOptions.EnableRetryOnFailure(
             maxRetryCount: 3,
             maxRetryDelay: TimeSpan.FromSeconds(5),
         errorNumbersToAdd: null);
     });
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITestDBRepositoryWrapper, TestDBRepositoryWrapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");

app.UseAuthorization();

app.MapControllers();

app.Run();
