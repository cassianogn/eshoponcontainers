﻿using Cassiano.EShopOnContainers.CommandsCentral.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cassiano.EShopOnContainers.CommandsCentral.Infra.Out.AccessData
{
    public static class AddMongoAccessDataModule 
    {
        public static IServiceCollection AddCommandsCentralMongoAccessData(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDatabaseSettings>(configuration.GetSection("MongoDatabaseSettings"));
            services.AddCommandsCentralApplicationRepositories<EventStoredRepository>();
            return services;
        }
    }
}
