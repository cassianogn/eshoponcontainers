using Cassiano.EShopOnContainers.Core.Application.In.Queries.GetEntityById;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Unit.FakeCommandHandlers.FakeGetEntityById
{
    internal class FakeGetEntityByIdQueryHandler : GetEntityByIdQueryHandler<FakeEntity, IFakeEntityRepository, FakeGetEntityByIdQuery, FakeGetEntityByIdViewModel>
    {
        public FakeGetEntityByIdQueryHandler(IMediator mediator, IFakeEntityRepository repository) : base(mediator, repository)
        {
        }

        protected override FakeGetEntityByIdViewModel MapEntityToViewModel(FakeEntity entity)
        {
            return new FakeGetEntityByIdViewModel()
            {
                Description = entity.Description,
                Id = entity.Id, 
                Name = entity.Name.Value
            };
        }
    }
}
