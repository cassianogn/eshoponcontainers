using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities;
using Cassiano.EShopOnContainers.Core.Infrastructure.Out.DbAccess.FluentApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.FakeEntities
{
    public class FakeEntityFA : NamedEntityFA<FakeEntity>
    {
        public override void Configure(EntityTypeBuilder<FakeEntity> builder)
        {
            builder.Property(entity => entity.Description).HasMaxLength(MAX_LENGTH_DEFAULT);
            builder.Property(entity => entity.Description).IsRequired();
            
            base.Configure(builder);
        }
    }
}
