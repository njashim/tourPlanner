using AutoMapper;
using BusinessLayer.Mapping;
using DataAccessLayer.Entity.Context;
using Microsoft.EntityFrameworkCore;
using UILayer.Components;

namespace UILayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var configuration = builder.Configuration;

            // Configure logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Register the DbContext with the connection string
            builder.Services.AddDbContext<TourPlannerContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("TourPlannerDBConnection")),
                ServiceLifetime.Scoped);

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TourPlannerContext>();
                try
                {
                    db.Database.Migrate();
                }
                catch (Npgsql.NpgsqlException ex)
                {
                    app.Logger.LogError(ex, "An error occurred while migrating the database.");
                    throw;
                }
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}