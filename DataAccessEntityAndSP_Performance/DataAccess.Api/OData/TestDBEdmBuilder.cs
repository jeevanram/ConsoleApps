using DataAccess.Database.Model;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace DataAccess.Api.OData
{
    public class TestDBEdmBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<UserInfo>("Users");
            return builder.GetEdmModel();
        }
    }
}
