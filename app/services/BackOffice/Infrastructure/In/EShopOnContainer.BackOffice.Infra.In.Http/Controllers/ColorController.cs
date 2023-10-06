using DTI.Core.Domain.Auth;
using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Services.Bus;
using DTI.Core.Domain.Services.DomainNotifications;
using DTI.Core.Infrastructure.In.Http.Controllers;
using DTI.Core.Infrastructure.In.Http.Services;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.AddColor;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.DeleteColor;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.UpdateColor;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Queries.GetColorById;
using Microsoft.AspNetCore.Mvc;

namespace EShopOnContainer.BackOffice.Infra.In.Http.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
