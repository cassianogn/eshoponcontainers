using DTI.Core.Application.In.Queries.GetEntityById;
using DTI.Core.Domain.DTOs.Entities;
using MediatR;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors;

namespace EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Queries.GetColorById
{
    internal class GetColorByIdQueryHandler : GetEntityByIdQueryHandler<Color, IColorRepository, GetColorByIdQuery, NamedEntityDTO>
    {
        public GetColorByIdQueryHandler(IMediator mediator, IColorRepository repository) : base(mediator, repository)
        {
        }

        protected override NamedEntityDTO MapEntityToViewModel(Color entity)
        {
            return new NamedEntityDTO
            {
                Id = entity.Id,
                Name = entity.Name.Value
            };
        }
    }
}
