using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.DTOs.Search;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Bases;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.In.Queries.SearchNamedEntity
{
    public class SearchNamedEntityQueryHandler<TEntity,TRepository, TQuery, TViewModel> : BaseRequestHandler<TQuery, IEnumerable<TViewModel>>
        where TEntity : IEntity
        where TRepository : IReaderRepository<TEntity>
        where TQuery : SearchQuery, IAppMessage<IEnumerable<TViewModel>>
        where TViewModel : NamedEntityDTO
    {
        protected readonly TRepository Repository;
        public SearchNamedEntityQueryHandler(IMediator mediator, TRepository repository) : base(mediator)
        {
            Repository = repository;
        }

        public override async Task<CommandResult<IEnumerable<TViewModel>>> ExecuteAsync(TQuery request, CancellationToken cancellationToken)
        {
            var results = await Repository.SearchByKeywordAsync(request.QueryKey, cancellationToken);
            return CommandResult<IEnumerable<TViewModel>>.CommandFinished(results.Cast<TViewModel>());
        }

        protected override EventType GetEventType() => EventType.Query;
    }
}
