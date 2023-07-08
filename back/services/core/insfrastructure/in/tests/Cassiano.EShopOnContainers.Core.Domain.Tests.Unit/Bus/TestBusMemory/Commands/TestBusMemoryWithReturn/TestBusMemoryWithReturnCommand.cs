using Cassiano.EShopOnContainers.Core.Domain.Interfaces.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using System;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestBusMemory.Commands.TestBusMemoryWithReturn
{
    public class TestBusMemoryWithReturnCommand : IAppMessage<Guid>, IEntityDTO
    {
        public Guid Id { get; set; }
    }
}
