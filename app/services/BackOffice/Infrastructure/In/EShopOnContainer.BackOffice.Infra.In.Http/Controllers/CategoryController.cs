using DTI.Core.Domain.Auth;
using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Services.Bus;
using DTI.Core.Domain.Services.DomainNotifications;
using DTI.Core.Infra.In.Http.Controllers;
using DTI.Core.Infra.In.Http.Services;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Commands.AddCategory;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Commands.DeleteCategory;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Commands.UpdateCategory;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Queries.GetCategoryById;
using Microsoft.AspNetCore.Mvc;

namespace EShopOnContainer.BackOffice.Infra.In.Http.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : EntityController<GetCategoryByIdQuery, NamedEntityDTO, AddCategoryCommand, UpdateCategoryCommand, DeleteCategoryCommand>
    {
        public CategoryController(DomainNotificationService domainNotificationService, UserHttpRequest usuarioHttpRequest, BusService busService) : base(domainNotificationService, usuarioHttpRequest, busService)
        {
        }

        protected override HttpAuthParameters GetAuthParameters()
        {
            return HttpAuthParameters.GetAnonymousAuth();
        }

        
    }
}
