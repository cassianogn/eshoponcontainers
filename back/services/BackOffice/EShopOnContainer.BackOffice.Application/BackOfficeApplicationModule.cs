using Cassiano.EShopOnContainers.Core.Application;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ShopOnContainers.BackOffice.Domain.Products;
using System.Reflection;

namespace EShopOnContainer.BackOffice.Application
{
    public static class BackOfficeApplicationModule
    {
        public static void AddBackOfficeApplicationBase<TInfrastructureBusService>(IServiceCollection services)
            where TInfrastructureBusService : class, IInfrastructureBusService

        {
            services.AddCoreApplication<TInfrastructureBusService>(new List<Assembly>() { typeof(BackOfficeApplicationModule).Assembly });
        }
        public static void AddApplicationRepositories<TProductRepository>(IServiceCollection services)
            where TProductRepository : class, IProductRepository

        {
            services.AddScoped<IProductRepository, TProductRepository>();
        }
    }
}
