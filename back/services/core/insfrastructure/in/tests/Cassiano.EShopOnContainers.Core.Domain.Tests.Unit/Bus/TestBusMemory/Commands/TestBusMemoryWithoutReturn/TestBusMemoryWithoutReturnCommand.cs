using Cassiano.EShopOnContainers.Core.Domain.Interfaces.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using System;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Bus.TestBusMemory.Commands.TestBusMemoryWithoutReturn
{
    internal class TestBusMemoryWithoutReturnCommand : IAppMessage, IEntityDTO
    {
        public Guid Id { get; set; }
        public bool ThrowError { get;  set; }
    }
}
