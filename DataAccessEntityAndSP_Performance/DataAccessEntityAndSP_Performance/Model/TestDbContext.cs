using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessEntityAndSP_Performance.Model;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DBConnectionString"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserInfo");

            entity.Property(e => e.Address1).HasMaxLength(100);
            entity.Property(e => e.Address2).HasMaxLength(100);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("CITY");
            entity.Property(e => e.County)
                .HasMaxLength(50)
                .HasColumnName("COUNTY");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Postalcode)
                .HasMaxLength(5)
                .HasColumnName("POSTALCODE");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .HasColumnName("STATE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
