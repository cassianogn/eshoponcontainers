using DTI.Core.Domain.Interfaces.DTOs;
using DTI.Core.Domain.Services.Bus.Interfaces;
using System;

namespace DTI.Core.Domain.Tests.Unit.Bus.TestBusMemory.Commands.TestBusMemoryWithReturn
{
    public class TestBusMemoryWithReturnCommand : IAppMessage<Guid>, IEntityDTO
    {
        public Guid Id { get; set; }
    }
}
