using DTI.Core.Domain.Interfaces.DTOs;
using DTI.Core.Domain.Services.Bus.Interfaces;
using System;

namespace DTI.Core.Domain.Tests.Unit.Bus.TestBusMemory.Commands.TestBusMemoryWithoutReturn
{
    internal class TestBusMemoryWithoutReturnCommand : IAppMessage, IEntityDTO
    {
        public Guid Id { get; set; }
        public bool ThrowError { get;  set; }
    }
}
