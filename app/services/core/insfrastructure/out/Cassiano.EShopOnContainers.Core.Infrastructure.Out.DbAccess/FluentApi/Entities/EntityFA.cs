using Cassiano.EShopOnContainers.Core.Domain.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Helpers.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cassiano.EShopOnContainers.Core.Infrastructure.Out.DbAccess.FluentApi.Entities
{
    public class EntityFA<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity<TEntity>
    {
        protected readonly int MAX_LENGTH_DEFAULT = CoreConstants.MAX_LEN;
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            var tableName = typeof(TEntity).ToString().Split('.').Last();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreationDate).IsRequired();
            builder.Property(e => e.Deleted).IsRequired();

            builder.ToTable(tableName);
        }
    }
}
