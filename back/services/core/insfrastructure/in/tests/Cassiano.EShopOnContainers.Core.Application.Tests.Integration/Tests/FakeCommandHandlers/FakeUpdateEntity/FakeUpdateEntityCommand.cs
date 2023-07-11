using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeUpdateEntity
{
    internal class FakeUpdateEntityCommand : NamedEntityDTO, IAppMessage
    {
        public string Description { get; set; }
    }
}
