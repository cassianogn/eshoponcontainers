using DTI.Core.Application.In.Queries.GetEntityById;
using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.Interfaces.Repositories;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Categories;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : GetEntityByIdQueryHandler<Category, ICategoryRepository, GetCategoryByIdQuery, NamedEntityDTO>
    {
        public GetCategoryByIdQueryHandler(IMediator mediator, ICategoryRepository repository) : base(mediator, repository)
        {
        }

        protected override NamedEntityDTO MapEntityToViewModel(Category entity)
        {
            return new NamedEntityDTO
            {
                Id = entity.Id,
                Name = entity.Name.Value
            };
        }
    }
}
