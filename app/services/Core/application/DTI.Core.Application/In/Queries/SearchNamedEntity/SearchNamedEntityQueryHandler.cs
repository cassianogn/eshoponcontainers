using DTI.Core.Domain.DTOs.Entities;
using DTI.Core.Domain.DTOs.Search;
using DTI.Core.Domain.EventSourcing;
using DTI.Core.Domain.Interfaces.Entities;
using DTI.Core.Domain.Interfaces.Repositories;
using DTI.Core.Domain.Services.Bus.Bases;
using DTI.Core.Domain.Services.Bus.Interfaces;
using DTI.Core.Domain.Services.Bus.Models;
using MediatR;
using System.Collections.Generic;

namespace DTI.Core.Application.In.Queries.SearchNamedEntity
{
    public class SearchNamedEntityQueryHandler<TEntity, TRepository, TQuery, TViewModel> : BaseRequestHandler<TQuery, IEnumerable<TViewModel>>
        where TEntity : IEntity
        where TRepository : IReaderRepository<TEntity>
        where TQuery : SearchQuery, IAppMessage<IEnumerable<TViewModel>>
        where TViewModel : NamedEntityDTO, new()
    {
        protected readonly TRepository Repository;
        public SearchNamedEntityQueryHandler(IMediator mediator, TRepository repository) : base(mediator)
        {
            Repository = repository;
        }

        public override async Task<CommandResult<IEnumerable<TViewModel>>> ExecuteAsync(TQuery request, CancellationToken cancellationToken)
        {
            var results = await Repository.SearchByKeywordAsync(request.QueryKey, cancellationToken);
            IEnumerable<TViewModel> resultsViewModel = ParseQueryResultToViewModel(results);
            return CommandResult<IEnumerable<TViewModel>>.CommandFinished(resultsViewModel);
        }

        protected virtual IEnumerable<TViewModel> ParseQueryResultToViewModel(IEnumerable<NamedEntityDTO> results)
        {
            return results.Select(result => new TViewModel() { Id = result.Id, Name = result.Name });
        }

        protected override EventType GetEventType() => EventType.Query;
    }
}
