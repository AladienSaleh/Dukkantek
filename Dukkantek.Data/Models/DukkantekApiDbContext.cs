using Dukkantek.Data.Models.Configuration;
using Dukkantek.Data.Models.Products;
using Dukkantek.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Dukkantek.Data.Models
{
    public class DukkantekApiDbContext : DbContext
    {
        #region Constructor
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DukkantekApiDbContext>
        {
            public DukkantekApiDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
                var connectionString = configuration.GetConnectionString(DbContextNames.AuthenticationContext);
                return new DukkantekApiDbContext(GetOptions(connectionString));
            }
        }

        public DukkantekApiDbContext(DbContextOptions<DukkantekApiDbContext> options) : base(options)
        { }

        public static DbContextOptions<DukkantekApiDbContext> GetOptions(string connectionString)
        {
            DbContextOptionsBuilder<DukkantekApiDbContext> MsSQL(DbContextOptionsBuilder<DukkantekApiDbContext> builder) =>
                   builder.UseSqlServer(connectionString, sqlServerOptions =>
                   {
                       sqlServerOptions.CommandTimeout(300);
                       sqlServerOptions.MinBatchSize(1).MaxBatchSize(1000);
                   });

            return MsSQL(new DbContextOptionsBuilder<DukkantekApiDbContext>()).Options;
        }
        #endregion

        #region Public Members
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Category> Categories { get; set; }
        #endregion

        #region Private members 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasKey(PC => new { PC.ProductId, PC.CategoryId });


            ModelBuilderExtensions.SeedData(modelBuilder);
        }
        #endregion

    }
}
