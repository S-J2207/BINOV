﻿using MicroServiceCRUD.Repositories;
using MicroServiceCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceCRUD
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration _configuration)
        {
            string connectionString = "";
            connectionString = _configuration["ConnectionStrings:SQLConnectionStrings"];

            services.AddDbContext<DatabaseService>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IADSORepository, ADSORepository>();


            return services;
        }
    }
}
