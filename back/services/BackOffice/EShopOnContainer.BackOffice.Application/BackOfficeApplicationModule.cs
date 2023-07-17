using Cassiano.EShopOnContainers.Core.Application;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ShopOnContainers.BackOffice.Domain.Products;
using System.Reflection;

namespace EShopOnContainer.BackOffice.Application
{
    public static class BackOfficeApplicationModule
    {
        public static void AddBackOfficeApplicationBase<TInfrastructureBusService>(this IServiceCollection services)
            where TInfrastructureBusService : class, IInfrastructureBusService

        {
            services.AddCoreApplication<TInfrastructureBusService>(new List<Assembly>() { typeof(BackOfficeApplicationModule).Assembly });
        }
        public static void AddBackOfficeApplicationRepositories<TProductRepository>(this IServiceCollection services)
            where TProductRepository : class, IProductRepository

        {
            services.AddScoped<IProductRepository, TProductRepository>();
        }
    }
}
