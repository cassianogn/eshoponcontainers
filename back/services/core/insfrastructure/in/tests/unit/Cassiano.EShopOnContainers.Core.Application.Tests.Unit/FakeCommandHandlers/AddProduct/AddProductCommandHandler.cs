using Cassiano.EShopOnContainers.Core.Application.In.Commands.AddEntity;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.AddProduct
{
    internal class AddProductCommandHandler : AddEntityCommandHandler<Product, IProductRepository, AddProductCommand>
    {
        public AddProductCommandHandler(IMediator mediator, IProductRepository repository, DomainNotificationService domainNotificationService) : base(mediator, repository, domainNotificationService)
        {
        }

        protected override Product ParseCommandToEntity(AddProductCommand request)
        {
            return new Product(request.Id, request.Name, request.Description);
        }

    }
}
