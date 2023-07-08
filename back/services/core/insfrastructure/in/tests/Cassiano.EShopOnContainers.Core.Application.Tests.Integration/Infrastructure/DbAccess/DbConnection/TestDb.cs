using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.FakeEntities;
using Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers;
using Microsoft.EntityFrameworkCore;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.DbConnection
{
    public class TestDb : DbContext
    {
        public TestDb(DbContextOptions<TestDb> options) : base(options)
        {
        }

        public DbSet<FakeEntity> FakeEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FakeEntityFA());
            base.OnModelCreating(modelBuilder);
        }
    }
}
