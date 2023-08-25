using DTI.Core.Application.In.Queries.SearchNamedEntity;
using DTI.Core.Domain.DTOs.Entities;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Categories;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Queries.SearchCategory
{
    internal class SearchCategoryQueryHandler : SearchNamedEntityQueryHandler<Category, ICategoryRepository, SearchCategoryQuery, NamedEntityDTO>
    {
        public SearchCategoryQueryHandler(IMediator mediator, ICategoryRepository repository) : base(mediator, repository)
        {
        }
    }
}