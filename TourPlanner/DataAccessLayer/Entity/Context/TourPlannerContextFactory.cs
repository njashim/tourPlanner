using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccessLayer.Entity.Context
{
    public class TourPlannerContextFactory : IDesignTimeDbContextFactory<TourPlannerContext>
    {
        public TourPlannerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TourPlannerContext>();

            // Read the connection string from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("TourPlannerDBConnection");

            optionsBuilder.UseNpgsql(connectionString);

            return new TourPlannerContext(optionsBuilder.Options);
        }
    }
}