using DTI.Core.Domain.EventSourcing;
using DTI.Core.Domain.Services.Bus.Bases;
using DTI.Core.Domain.Services.Bus.Models;
using EShopOnContainer.Catalog.Application.Products.Entities;
using EShopOnContainer.Catalog.Application.Products.Interfaces;
using MediatR;

namespace EShopOnContainer.Catalog.Application.Products.UseCases.Commands.AddProduct
{
    internal class AddProductCommandHandler : BaseRequestHandler<AddProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public AddProductCommandHandler(IMediator mediator, IProductRepository productRepository) : base(mediator)
        {
            _productRepository = productRepository;
        }

        public override async Task<CommandResult> ExecuteAsync(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductModel(request.Id, request.Name, request.Description, request.Price); 
            await _productRepository.Add(product);
            return CommandResult.CommandFinished();
        }

        protected override EventType GetEventType() => EventType.Create;
    }
}
