using Cassiano.EShopOnContainers.Core.Application.In.Commands.AddEntity;
using Cassiano.EShopOnContainers.Core.Domain.EventSourcing;
using Cassiano.EShopOnContainers.Core.Domain.Helpers.Exceptions;
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

namespace Cassiano.EShopOnContainers.Core.Application.In.Commands.UpdateEntity
{
    public abstract class UpdateEntityCommandHandler<TEntity, TRepository, TUpdateCommand> : BaseRequestHandler<TUpdateCommand>
        where TEntity : IEntityWithDomainValidations<TEntity>
        where TRepository : IWriterRepository<TEntity>, IReaderRepository<TEntity>
        where TUpdateCommand : IEntityDTO, IAppMessage

    {
        protected readonly TRepository Repository;
        protected readonly DomainNotificationService DomainNotificationService;
        protected readonly ValidationStrategyService<TEntity> ValidationStrategyService;

        protected UpdateEntityCommandHandler(IMediator mediator, TRepository repository, DomainNotificationService domainNotificationService) : base(mediator)
        {
            Repository = repository;
            ValidationStrategyService = new ValidationStrategyService<TEntity>();
            DomainNotificationService = domainNotificationService;
        }

        protected override EventType GetEventType() => EventType.Update;

        public override async Task<CommandResult> ExecuteAsync(TUpdateCommand request, CancellationToken cancellationToken)
        {
            TEntity entity = (await Repository.GetByIdAsync(request.Id, cancellationToken) ?? throw new Exception($"Entity {typeof(TEntity).Name} with id {request.Id} not found to update")) ?? throw new ApplicationCoreException($"Entity {typeof(TEntity).Name} with id {request.Id} not found on UpdateEntityCommandHandler");
            try
            {
                SetUpdateDataInEntity(entity, request);
            }
            catch (Exception ex)
            {
                throw GetTemplateMethodException(request.Id, "SetUpdateDataInEntity", ex);
            }

            await BeforeValidate(entity, request, cancellationToken);
            var validationResult = await Validate(entity);
            if (!validationResult.Valid) return CommandResult.CommandFinished();

            await BeforeUpdateEntity(entity, request, cancellationToken);
            await Repository.UpdateAsync(entity, cancellationToken);
            await AfterUpdateEntity(entity, request, cancellationToken);

            return CommandResult.CommandFinished();
        }
        private async Task<ValidationStrategyResult> Validate(TEntity entity)
        {
            ValidationStrategyService.AddValidationStrategyPolicies(entity.GetValidationStrategyPolicies());
            ValidationStrategyService.AddValidationStrategyPolicies(GetAditionalsValidations());

            var validationResult = await ValidationStrategyService.ValidateAsync(entity);

            if (!validationResult.Valid)
                foreach (var policyResult in validationResult.PoliciesResult)
                    foreach (var error in policyResult.Errors)
                        DomainNotificationService.Add(policyResult.ErrorGroup, error);

            return validationResult;
        }
        protected abstract void SetUpdateDataInEntity(TEntity entity,TUpdateCommand request);
        
        private Task BeforeValidate(TEntity entity, TUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return BeforeValidateTemplateMethod(entity, request, cancellationToken);
            }
            catch (Exception ex)
            {
                throw GetTemplateMethodException(entity.Id, "BeforeValidateTemplateMethod", ex);
            }
        }
        protected virtual Task BeforeValidateTemplateMethod(TEntity entity, TUpdateCommand request, CancellationToken cancellationToken) => Task.CompletedTask;
        
        private IEnumerable<IValidationStrategyPolicy<TEntity>> GetAditionalsValidations()
        {
            try
            {
                return GetAditionalsValidationsTemplateMethod();
            }
            catch (Exception ex)
            {
                throw GetTemplateMethodException(null, "GetAditionalsValidationsTemplateMethod", ex);
            }
        }
        protected virtual IEnumerable<IValidationStrategyPolicy<TEntity>> GetAditionalsValidationsTemplateMethod() => new List<IValidationStrategyPolicy<TEntity>>();
       
        private Task BeforeUpdateEntity(TEntity entity, TUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return BeforeUpdateEntityTemplateMethod(entity, request, cancellationToken);
            }
            catch (Exception ex)
            {
                throw GetTemplateMethodException(request.Id, "BeforeUpdateEntityTemplateMethod", ex);
            }
        }
        protected virtual Task BeforeUpdateEntityTemplateMethod(TEntity entity, TUpdateCommand request, CancellationToken cancellationToken) => Task.CompletedTask;

        private Task AfterUpdateEntity(TEntity entity, TUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return AfterUpdateEntityTemplateMethod(entity, request, cancellationToken);

            }
            catch (Exception ex)
            {
                throw GetTemplateMethodException(request.Id, "AfterUpdateEntityTemplateMethod", ex);
            }
        }

        protected virtual Task AfterUpdateEntityTemplateMethod(TEntity entity, TUpdateCommand request, CancellationToken cancellationToken) => Task.CompletedTask;
        private static TemplateMathodException GetTemplateMethodException(Guid? entityId, string templateMathodName, Exception ex)
        {
            return TemplateMathodException.Create(typeof(TEntity), typeof(UpdateEntityCommandHandler<TEntity, TRepository, TUpdateCommand>), entityId, templateMathodName, ex);
        }
    }
}
