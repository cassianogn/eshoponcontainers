using Cassiano.EShopOnContainers.Core.Application.In.Queries.GetEntityById;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeGetEntityById
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
