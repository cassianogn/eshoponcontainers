using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.In.Commands.Bases
{
    public abstract class BaseHandler<TRequest, TResponse>
        where TRequest : IRequest<CommandResult<TResponse>>
    {

        public abstract Task<CommandResult<TResponse>> Execute(TRequest request, CancellationToken cancellationToken);

    }
}
