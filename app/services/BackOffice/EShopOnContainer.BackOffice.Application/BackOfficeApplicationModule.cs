using DTI.Core.Application;
using DTI.Core.Domain.Services.Bus.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ShopOnContainers.BackOffice.Domain.Products;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Categories;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors;
using System.Reflection;

namespace EShopOnContainer.BackOffice.Application
{
    public static class BackOfficeApplicationModule
    {
        public static void AddBackOfficeApplicationBase<TInfrastructureBusService>(this IServiceCollection services, Func<IServiceProvider, TInfrastructureBusService> instanceOfInfrastructureBusDelegate)
            where TInfrastructureBusService : class, IInfrastructureBusService

        {
            services.AddCoreApplication(new List<Assembly>() { typeof(BackOfficeApplicationModule).Assembly }, instanceOfInfrastructureBusDelegate);
        }
        public static void AddBackOfficeApplicationRepositories<TProductRepository, TColorRepository, TCategoryRepository>(this IServiceCollection services)
            where TProductRepository : class, IProductRepository
            where TColorRepository : class, IColorRepository
            where TCategoryRepository : class, ICategoryRepository

        {
            services.AddScoped<IProductRepository, TProductRepository>();
            services.AddScoped<IColorRepository, TColorRepository>();
            services.AddScoped<ICategoryRepository, TCategoryRepository>();
        }
    }
}
