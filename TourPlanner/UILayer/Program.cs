using BusinessLayer.Mapping;
using DataAccessLayer.Entity.Context;
using DataAccessLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Service.Interface;
using BusinessLayer.Service;
using DataAccessLayer.Repository;
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

            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Register ITourRepository and ITourService
            builder.Services.AddScoped<ITourRepository, TourRepository>();
            builder.Services.AddScoped<ITourService, TourService>();

            // Register ITourLogRepository and ITourLogService
            builder.Services.AddScoped<ITourLogRepository, TourLogRepository>();
            builder.Services.AddScoped<ITourLogService, TourLogService>();

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
