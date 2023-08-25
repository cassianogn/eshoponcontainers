using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Services.Bus.Interfaces;
using System;

namespace DTI.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeCreateEntity
{
    internal class FakeCreateEntityCommand : NamedEntityDTO, IAppMessage<Guid?>
    {
        public FakeCreateEntityCommand()
        {
        }

        public string Description { get; set; }
    }
}
