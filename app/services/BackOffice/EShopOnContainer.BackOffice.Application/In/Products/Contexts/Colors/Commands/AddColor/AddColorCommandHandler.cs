using DTI.Core.Application.In.Commands.AddEntity;
using DTI.Core.Domain.Services.DomainNotifications;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.AddColor
{
    internal class AddColorCommandHandler : AddEntityCommandHandler<Color, IColorRepository, AddColorCommand>
    {
        public AddColorCommandHandler(IMediator mediator, IColorRepository repository, DomainNotificationService domainNotificationService) : base(mediator, repository, domainNotificationService)
        {
        }

        protected override Color ParseCommandToEntity(AddColorCommand request)
        {
            return new Color(request.Id, request.Name);
        }
    }
}
