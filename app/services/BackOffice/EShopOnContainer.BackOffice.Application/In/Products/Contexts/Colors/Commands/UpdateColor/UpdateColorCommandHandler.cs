using DTI.Core.Application.In.Commands.UpdateEntity;
using DTI.Core.Domain.Services.DomainNotifications;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.UpdateColor
{
    internal class UpdateColorCommandHandler : UpdateEntityCommandHandler<Color, IColorRepository, UpdateColorCommand>
    {
        public UpdateColorCommandHandler(IMediator mediator, IColorRepository repository, DomainNotificationService domainNotificationService) : base(mediator, repository, domainNotificationService)
        {
        }

        protected override void SetUpdateDataInEntity(Color entity, UpdateColorCommand request)
        {
            entity.SetName(request.Name);
        }
    }
}
