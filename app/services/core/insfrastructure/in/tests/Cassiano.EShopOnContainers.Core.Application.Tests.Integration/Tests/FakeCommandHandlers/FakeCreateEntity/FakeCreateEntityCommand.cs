using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using System;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeCreateEntity
{
    internal class FakeCreateEntityCommand : NamedEntityDTO, IAppMessage<Guid?>
    {
        public FakeCreateEntityCommand()
        {
        }

        public string Description { get; set; }
    }
}
