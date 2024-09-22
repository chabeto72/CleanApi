using Application.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection addPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddDbContext<DataBaseService>(options => options.UseSqlServer(configuration["SQLConnectionString"]));
            services.AddScoped<IDataBaseService, DataBaseService>();
            return services;
        }
    }
}
