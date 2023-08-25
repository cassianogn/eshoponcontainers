using DTI.Core.Application.In.Queries.SearchNamedEntity;
using DTI.Core.Domain.DTOs.Entities;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Queries.SearchColor
{
    internal class SearchColorQueryHandler : SearchNamedEntityQueryHandler<Color, IColorRepository, SearchColorQuery, NamedEntityDTO>
    {
        public SearchColorQueryHandler(IMediator mediator, IColorRepository repository) : base(mediator, repository)
        {
        }
    }
}
