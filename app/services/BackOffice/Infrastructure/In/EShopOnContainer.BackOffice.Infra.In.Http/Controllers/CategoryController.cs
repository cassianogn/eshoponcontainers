using Cassiano.EShopOnContainers.Core.Domain.Auth;
using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Cassiano.EShopOnContainers.Core.Infrastructure.In.Http.Controllers;
using Cassiano.EShopOnContainers.Core.Infrastructure.In.Http.Services;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Commands.AddCategory;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Commands.DeleteCategory;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Commands.UpdateCategory;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Queries.GetCategoryById;

namespace EShopOnContainer.BackOffice.Infra.In.Http.Controllers
{
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
