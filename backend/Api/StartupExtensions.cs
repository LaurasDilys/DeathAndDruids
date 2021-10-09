using Application;
using Business.Services;
using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class StartupExtensions
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<CreationService>()
                    .AddScoped<CreationRepository>();

            services.AddScoped<MonstersService>()
                    .AddScoped<MonstersRepository>();

            services.AddTransient<MapperService>()
                    .AddTransient<ConverterService>();
        }

        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(builder => builder.UseSqlServer(connectionString));
        }

        public static void AddDatabaseMigrations(this IApplicationBuilder app)
        {
            // Database migrations added by default
            var context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<DataContext>();
            context.Database.Migrate();
        }
    }
}
