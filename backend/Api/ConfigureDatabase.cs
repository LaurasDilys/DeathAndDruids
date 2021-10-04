using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class ConfigureDatabase
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(builder => builder.UseSqlServer(connectionString));
        }
    }
}
