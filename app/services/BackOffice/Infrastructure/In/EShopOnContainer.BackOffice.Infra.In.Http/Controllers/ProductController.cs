using DTI.Core.Domain.Auth;
using DTI.Core.Domain.Services.Bus;
using DTI.Core.Domain.Services.DomainNotifications;
using DTI.Core.Infrastructure.In.Http.Controllers;
using DTI.Core.Infrastructure.In.Http.Services;
using EShopOnContainer.BackOffice.Application.In.Products.Commands.AddProduct;
using EShopOnContainer.BackOffice.Application.In.Products.Commands.DeleteProduct;
using EShopOnContainer.BackOffice.Application.In.Products.Commands.UpdateProduct;
using EShopOnContainer.BackOffice.Application.In.Products.Queries.GetProductById;
using Microsoft.AspNetCore.Mvc;

namespace EShopOnContainer.BackOffice.Infra.In.Http.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : EntityController<GetProductByIdQuery, GetProductByIdViewModel, AddProductCommand, UpdateProductCommand, DeleteProductCommand>
    {
        public ProductController(DomainNotificationService domainNotificationService, UserHttpRequest usuarioHttpRequest, BusService busService) : base(domainNotificationService, usuarioHttpRequest, busService)
        {
        }

        protected override HttpAuthParameters GetAuthParameters()
        {
            return HttpAuthParameters.GetAnonymousAuth();
        }
    }
}
