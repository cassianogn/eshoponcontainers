using Cassiano.EShopOnContainers.Core.Application.In.Queries.GetEntityById;
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
using System;

namespace Cassiano.EShopOnContainers.Core.Application.In.Commands.AddEntity
{
    public abstract class AddEntityCommandHandler<TEntity, TRepository, TAddCommand> : BaseRequestHandler<TAddCommand, Guid?>
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
            request.Id = Guid.NewGuid();

            TEntity entity;
            try
            {
                entity = ParseCommandToEntity(request);
            }
            catch (Exception ex)
            {
                throw GetTemplateMethodException(request.Id, "ParseCommandToEntity", ex);
            }

            await BeforeValidate(entity, request, cancellationToken);
            var validationResult = await Validate(entity);
            if (!validationResult.Valid) return CommandResult<Guid?>.CommandFinished(null);

            await BeforeRegisterEntity(entity, request, cancellationToken);
            await Repository.AddAsync(entity, cancellationToken);
            await AfterRegisterEntity(entity, request, cancellationToken);

            return CommandResult<Guid?>.CommandFinished(entity.Id);
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
        
        protected abstract TEntity ParseCommandToEntity(TAddCommand request);
        private Task BeforeValidate(TEntity entity, TAddCommand request, CancellationToken cancellationToken)
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
        protected virtual Task BeforeValidateTemplateMethod(TEntity entity, TAddCommand request, CancellationToken cancellationToken) => Task.CompletedTask;
       
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
       
        private Task BeforeRegisterEntity(TEntity entity, TAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return BeforeRegisterEntityTemplateMethod(entity, request, cancellationToken);
            }
            catch (Exception ex)
            {
                throw GetTemplateMethodException(request.Id, "BeforeRegisterEntityTemplateMethod", ex);
            }
        }
        protected virtual Task BeforeRegisterEntityTemplateMethod(TEntity entity, TAddCommand request, CancellationToken cancellationToken) => Task.CompletedTask;
        
        private Task AfterRegisterEntity(TEntity entity, TAddCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return AfterRegisterEntityTemplateMethod(entity, request, cancellationToken);
                
            }
            catch (Exception ex)
            {
                throw GetTemplateMethodException(request.Id, "AfterRegisterEntityTemplateMethod", ex);
            }
        }
        protected virtual Task AfterRegisterEntityTemplateMethod(TEntity entity, TAddCommand request, CancellationToken cancellationToken) => Task.CompletedTask;
        private static TemplateMathodException GetTemplateMethodException(Guid? entityId, string templateMathodName, Exception ex)
        {
            return TemplateMathodException.Create(typeof(TEntity), typeof(AddEntityCommandHandler<TEntity, TRepository, TAddCommand>), entityId, templateMathodName, ex);
        }

    }
}
