using Cassiano.EShopOnContainers.Core.Application.In.Commands.DeleteEntity;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.DeleteColor
{
    public class DeleteColorCommandHandler : DeleteEntityCommandHandler<Color, IColorRepository, DeleteColorCommand>
    {
        public DeleteColorCommandHandler(IMediator mediator, IColorRepository repository) : base(mediator, repository)
        {
        }
    }
}
