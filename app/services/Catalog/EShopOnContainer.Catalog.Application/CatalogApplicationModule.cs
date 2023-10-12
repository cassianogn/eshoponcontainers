using DTI.Core.Application;
using DTI.Core.Domain.Services.Bus.Interfaces;
using EShopOnContainer.Catalog.Application.Products.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EShopOnContainer.Catalog.Application
{
    public static class CatalogApplicationModule
    {
        public static IServiceCollection AddCatalogApplicationApplicationBase<TInfrastructureBusService>(this IServiceCollection services, Func<IServiceProvider, TInfrastructureBusService> instanceOfInfrastructureBusDelegate)
            where TInfrastructureBusService : class, IInfrastructureBusService

        {
            services.AddCoreApplication(new List<Assembly>() { typeof(CatalogApplicationModule).Assembly }, instanceOfInfrastructureBusDelegate);
            return services;
        }

        public static IServiceCollection AddCatalogApplicationRepositories<TProductRepository>(this IServiceCollection services)
           where TProductRepository : class, IProductRepository
        {
            services.AddScoped<IProductRepository, TProductRepository>();
            return services;
        }
    }
}
