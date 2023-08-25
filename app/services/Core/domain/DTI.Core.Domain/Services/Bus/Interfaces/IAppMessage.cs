using DTI.Core.Domain.Services.Bus.Models;
using MediatR;

namespace DTI.Core.Domain.Services.Bus.Interfaces
{
    public interface IAppMessage : IRequest<CommandResult>
    {
    }

    public interface IAppMessage<TResponse> : IRequest<CommandResult<TResponse>>
    {
    }
}
