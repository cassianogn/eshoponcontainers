using Cassiano.EShopOnContainers.BackOffice.Domain.Products;
using Cassiano.EShopOnContainers.Core.Infrastructure.Out.DbAccess.FluentApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShopOnContainer.BackOffice.Infra.Out.AccessData.Contexts.Products.FluentApi
{
    internal class ProductFA : NamedEntityFA<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(MAX_LENGTH_DEFAULT);
            builder.Property(p => p.Description).IsRequired();
            builder.OwnsOne(p => p.Price, price =>
            {
                price.Property(pp => pp.Sale).IsRequired();
                price.Property(pp => pp.Cost).IsRequired();
            });
            base.Configure(builder);
        }
    }
}
