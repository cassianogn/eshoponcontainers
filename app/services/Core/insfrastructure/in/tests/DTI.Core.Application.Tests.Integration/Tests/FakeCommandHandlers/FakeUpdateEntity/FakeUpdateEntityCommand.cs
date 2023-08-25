using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Services.Bus.Interfaces;

namespace DTI.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeUpdateEntity
{
    internal class FakeUpdateEntityCommand : NamedEntityDTO, IAppMessage
    {
        public string Description { get; set; }
    }
}
