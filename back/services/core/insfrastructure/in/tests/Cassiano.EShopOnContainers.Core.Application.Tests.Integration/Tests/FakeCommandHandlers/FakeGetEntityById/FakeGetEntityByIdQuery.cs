using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeGetEntityById
{
    internal class FakeGetEntityByIdQuery : EntityDTO, IAppMessage<FakeGetEntityByIdViewModel>
    {
    }
}
