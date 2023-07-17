using Microsoft.Extensions.DependencyInjection;
using EShopOnContainer.BackOffice.Application;
using EShopOnContainer.BackOffice.Infra.Out.AccessData.Contexts.Products;
using Microsoft.EntityFrameworkCore;

namespace EShopOnContainer.BackOffice.Infra.Out.AccessData
{
    public static class BackOfficeAccessDataModule
    {
        public static IServiceCollection AddBackOfficeAccessData(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BackOfficeDb>(options => options.UseSqlServer(connectionString));
            services.AddBackOfficeApplicationRepositories<ProductRepository>();

            return services;
        }
    }
}
