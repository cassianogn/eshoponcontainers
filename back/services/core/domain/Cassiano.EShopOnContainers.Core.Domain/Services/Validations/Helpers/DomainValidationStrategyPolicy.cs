using Cassiano.EShopOnContainers.Core.Domain.Helpers.Constants;
using System.Linq.Expressions;

namespace Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers
{
    public abstract class DomainValidationStrategyPolicy<TEntity> : IValidationStrategyPolicy<TEntity>
    {   
        public readonly FluentValidationDecorator<TEntity> _validationRule;
        
        protected DomainValidationStrategyPolicy(TEntity entity)
        {
            _validationRule = new FluentValidationDecorator<TEntity>(entity);
        }

        public ValidationStrategyType WhatDoWhenInvalidStateType => ValidationStrategyType.InGroupValidationResult;

        public Task<ValidationStrategyPolicyResult> ValidateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            SetValidationRules();
            return Task.FromResult(_validationRule.RunValidation(entity));
        }

        protected abstract void SetValidationRules();

        protected void IsRequired<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionProperty, string propertyName = "")
        {
            _validationRule.Required(expressionProperty, propertyName);
        }
        protected void MinLength(Expression<Func<TEntity, string>> expressionProperty, string propertyName = "", int length = CoreConstants.MIN_LEN)
        {
            _validationRule.MinLength(expressionProperty, propertyName, length);
        }
        protected void MaxLength(Expression<Func<TEntity, string>> expressionProperty, string propertyName = "", int length = CoreConstants.MAX_LEN)
        {
            _validationRule.MaxLength(expressionProperty, propertyName, length);
        }
    }
}
