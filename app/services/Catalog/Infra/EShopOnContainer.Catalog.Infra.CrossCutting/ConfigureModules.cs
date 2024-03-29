﻿using DTI.Core.Infra.Out.Observability.ELK;
using EShopOnContainer.Catalog.Application;
using EShopOnContainer.Catalog.Infra.Out.AccessData;
using EShopOnContainer.Catalog.Infra.Out.Bus.Kafka;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EShopOnContainer.Catalog.Infra.CrossCutting
{
    public static class ConfigureModules
    {
        public static IServiceCollection AddApplicationWithDependencies(this IServiceCollection services, string connectionStringBus, string elasticCloudId, string elasticCloudKey)
        {
            services.AddCatalogApplicationApplicationBase(services => new CatalogKafkaBusService(connectionStringBus, "back-office-group"));
            services.AddCatalogAccessData(elasticCloudId, elasticCloudKey);
            return services;
        }

        public static Action<WebApplication> AddObservability(this WebApplicationBuilder builder)
        {
            return builder.AddObservabilityELK("catalog");
        }
    }
}
