using Cassiano.EShopOnContainers.BackOffice.Domain.Products;
using Cassiano.EShopOnContainers.Core.Infrastructure.Out.DbAccess.FluentApi.Entities;
using EShopOnContainer.BackOffice.Infra.Out.AccessData.Contexts.Products.FluentApi;
using Microsoft.EntityFrameworkCore;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Categories;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors;

namespace EShopOnContainer.BackOffice.Infra.Out.AccessData
{
    internal class BackOfficeDb : DbContext
    {
        public BackOfficeDb(DbContextOptions<BackOfficeDb> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductFA());
            modelBuilder.ApplyConfiguration(new ProductCategoryFA());
            modelBuilder.ApplyConfiguration(new ProductColorFA());
            modelBuilder.ApplyConfiguration(new NamedEntityFA<Color>());
            modelBuilder.ApplyConfiguration(new NamedEntityFA<Category>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
