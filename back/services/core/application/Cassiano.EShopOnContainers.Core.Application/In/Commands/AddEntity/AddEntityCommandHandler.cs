using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Repositories;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Bases;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Models;
using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Results;
using MediatR;

namespace Cassiano.EShopOnContainers.Core.Application.In.Commands.AddEntity
{
    public abstract class AddEntityCommandHandler<TEntity, TRepository, TAddCommand> : BaseRequesHandler<TAddCommand, Guid?>
        where TEntity : IEntityWithDomainValidations<TEntity>
        where TRepository : IWriterRepository<TEntity>
        where TAddCommand : IEntityDTO, IAppMessage<Guid?>

    {
        protected readonly TRepository Repository;
        protected readonly DomainNotificationService DomainNotificationService;
        protected readonly ValidationStrategyService<TEntity> ValidationStrategyService;

        protected AddEntityCommandHandler(IMediator mediator, TRepository repository, DomainNotificationService domainNotificationService) : base(mediator)
        {
            Repository = repository;
            ValidationStrategyService = new ValidationStrategyService<TEntity>();
            DomainNotificationService = domainNotificationService;
        }

        protected override EventType GetEventType() => EventType.Create;

        public override async Task<CommandResult<Guid?>> ExecuteAsync(TAddCommand request, CancellationToken cancellationToken)
        {
            TEntity entity = ParseCommandToEntity(request);

            await BeforeValidateTemplateMethod(entity, request, cancellationToken);
            var validationResult = await Validate(entity);
            if (!validationResult.Valid) return CommandResult<Guid?>.GetSuccess(null);

            await BeforeRegisterEntityTemplateMethod(entity, request, cancellationToken);
            await Repository.AddAsync(entity, cancellationToken);
            await AfterRegisterEntityTemplateMethod(entity, request, cancellationToken);

            return CommandResult<Guid?>.GetSuccess(entity.Id);
        }
        private async Task<ValidationStrategyResult> Validate(TEntity entity)
        {
            ValidationStrategyService.AddValidationStrategyPolicies(entity.GetValidationStrategyPolicies());
            ValidationStrategyService.AddValidationStrategyPolicies(GetAditionalsValidationsTemplateMethod());

            var validationResult = await ValidationStrategyService.ValidateAsync(entity);

            if (!validationResult.Valid)
                foreach (var policyResult in validationResult.PoliciesResult)
                    foreach (var error in policyResult.Errors)
                        DomainNotificationService.Add(policyResult.ErrorGroup, error);

            return validationResult;
        }
        protected abstract TEntity ParseCommandToEntity(TAddCommand request);
        protected virtual Task BeforeValidateTemplateMethod(TEntity entity, TAddCommand request, CancellationToken cancellationToken) => Task.CompletedTask;
        protected virtual IEnumerable<IValidationStrategyPolicy<TEntity>> GetAditionalsValidationsTemplateMethod() => new List<IValidationStrategyPolicy<TEntity>>();
        protected virtual Task BeforeRegisterEntityTemplateMethod(TEntity entity, TAddCommand request, CancellationToken cancellationToken) => Task.CompletedTask;
        protected virtual Task AfterRegisterEntityTemplateMethod(TEntity entity, TAddCommand request, CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
