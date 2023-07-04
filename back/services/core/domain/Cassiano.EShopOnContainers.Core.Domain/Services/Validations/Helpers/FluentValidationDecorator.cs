using Cassiano.EShopOnContainers.Core.Domain.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Helpers.Constants;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers.CustomValidations;
using FluentValidation;
using FluentValidation.Results;
using System.Linq.Expressions;

namespace Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers
{
    internal class FluentValidationDecorator<TEntity> : AbstractValidator<TEntity>
    {
        protected ValidationResult _validationResult = new();
        protected readonly TEntity _entity;

        public FluentValidationDecorator(TEntity entity)
        {
            _entity = entity;
        }

        public ValidationStrategyPolicyResult RunValidation(TEntity entity)
        {
            _validationResult = Validate(entity);

            if (_validationResult.IsValid)
                return ValidationStrategyPolicyResult.Valid();

            var errorGrouop = ValidationErrorMessage.DomainRuleErrorGroup();
            var errorMessages = _validationResult.Errors.Select(error => error.ErrorMessage).Distinct().ToList();

            return ValidationStrategyPolicyResult.Invalid(errorGrouop, errorMessages);
        }

        public virtual void Required<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionProperty, string propertyName = "")
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);

            RuleFor(expressionProperty)
                .NotEmpty()
                .WithMessage(ValidationErrorMessage.Required(propertyName));

            var type = typeof(TPropertyReturn);
            var isGuid = type.FullName!.Contains("System.Guid") && (type.FullName.Contains("System.Nullable") || type.Name == "Guid");
            if (isGuid)
            {
                var guidToValidate = expressionProperty.Compile().Invoke(_entity) as Guid?;
                Expression<Func<TEntity, Guid?>> expressionGuid = entity => guidToValidate;
                RuleFor(expressionGuid).SetValidator(new GuidEmptyCustomValidation(propertyName));
            }
        }
        protected string GetPropertyName<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionProperty, string property)
        {
            if (string.IsNullOrEmpty(property))
                return GetPropertyNameInExpression(expressionProperty);
            return property;
        }

        private string GetPropertyNameInExpression<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionProperty)
        {
            var expressionString = expressionProperty.ToString();
            var propertyName = expressionString.Split('.').Last();
            return propertyName;
        }

      

        public void MinLength(Expression<Func<TEntity, string>> expressionProperty, string propertyName = "", int length = CoreConstants.MIN_LEN)
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);
            RuleFor(expressionProperty)
                .MinimumLength(length)
                .WithMessage(ValidationErrorMessage.MinLength(propertyName, length));
        }

        public void MaxLength(Expression<Func<TEntity, string>> expressionProperty, string propertyName = "", int length = CoreConstants.MAX_LEN)
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);
            RuleFor(expressionProperty)
                .MaximumLength(length)
                .WithMessage(ValidationErrorMessage.MaxLength(propertyName, length));
        }

    }
}
