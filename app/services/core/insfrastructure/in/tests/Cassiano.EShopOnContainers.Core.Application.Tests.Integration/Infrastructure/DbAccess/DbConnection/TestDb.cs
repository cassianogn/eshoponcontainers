using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.FakeEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.DbConnection
{
    public class TestDb : DbContext
    {
        public TestDb() 
        {
        }

        public DbSet<FakeEntity> FakeEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FakeEntityFA());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var connectionString = configuration
                        .GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

    }
}
