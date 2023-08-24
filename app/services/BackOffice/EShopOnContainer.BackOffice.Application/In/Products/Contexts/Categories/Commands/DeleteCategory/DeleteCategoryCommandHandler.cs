using Cassiano.EShopOnContainers.Core.Application.In.Commands.DeleteEntity;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Categories;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Commands.DeleteCategory
{
    internal class DeleteCategoryCommandHandler : DeleteEntityCommandHandler<Category, ICategoryRepository, DeleteCategoryCommand>
    {
        public DeleteCategoryCommandHandler(IMediator mediator, ICategoryRepository repository) : base(mediator, repository)
        {
        }
    }
}
