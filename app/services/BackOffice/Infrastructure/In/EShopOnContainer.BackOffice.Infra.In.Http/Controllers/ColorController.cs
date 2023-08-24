using Cassiano.EShopOnContainers.Core.Domain.Auth;
using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Cassiano.EShopOnContainers.Core.Infrastructure.In.Http.Controllers;
using Cassiano.EShopOnContainers.Core.Infrastructure.In.Http.Services;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.AddColor;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.DeleteColor;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.UpdateColor;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Queries.GetColorById;

namespace EShopOnContainer.BackOffice.Infra.In.Http.Controllers
{
    public class ColorController : EntityController<GetColorByIdQuery, NamedEntityDTO, AddColorCommand, UpdateColorCommand, DeleteColorCommand>
    {
        public ColorController(DomainNotificationService domainNotificationService, UserHttpRequest usuarioHttpRequest, BusService busService) : base(domainNotificationService, usuarioHttpRequest, busService)
        {
        }

        protected override HttpAuthParameters GetAuthParameters()
        {
            return HttpAuthParameters.GetAnonymousAuth();
        }
    }
}
