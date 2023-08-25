using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Services.Bus.Interfaces;

namespace DTI.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeDeleteEntity
{
    internal class FakeDeleteEntityCommand : EntityDTO, IAppMessage
    {
    }
}
