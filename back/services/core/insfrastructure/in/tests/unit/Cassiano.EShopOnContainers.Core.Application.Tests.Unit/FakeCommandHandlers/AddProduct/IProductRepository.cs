using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.AddProduct
{
    internal interface IProductRepository : IWriterRepository<Product>
    {
    }
}
