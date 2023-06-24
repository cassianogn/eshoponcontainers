using System.Threading.Tasks;
namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeCreateEntity
{
    internal class FakeCreateEntityCommandHandler
    {

        public Task ExecuteAsync(FakeCreateEntityCommand command)
        {
            return Task.CompletedTask;
        }
    }
}
