using Cassiano.EShopOnContainers.Core.Domain.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Helpers.Constants;
using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using System.Linq.Expressions;

namespace Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers
{
    public abstract class DomainValidationStrategyPolicy<TEntity> : IValidationStrategyPolicy<TEntity>
    {
        public readonly FluentValidationDecorator<TEntity> FluentValidationDecorator;
        private readonly ValidationErrorMessageService _validationErrorMessageService;

        protected DomainValidationStrategyPolicy(TEntity entity)
        {
            _validationErrorMessageService = new ValidationErrorMessageService();
            FluentValidationDecorator = new FluentValidationDecorator<TEntity>(entity, _validationErrorMessageService);
        }
        public void SetPrefixToErrorMessages(string prefix, bool useCollectionIndex = true)
        {
            _validationErrorMessageService.SetPrefix(prefix, useCollectionIndex);
        }
        public ValidationStrategyType WhatDoWhenInvalidStateType => ValidationStrategyType.InGroupValidationResult;

        public Task<ValidationStrategyPolicyResult> ValidateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            SetValidationRules();
            return Task.FromResult(FluentValidationDecorator.RunValidation(entity));
        }

        public abstract void SetValidationRules();

        public void IsRequired<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionProperty, string propertyName = "", Func<TEntity, bool>? whenCondition = null)
        {
            FluentValidationDecorator.Required(expressionProperty, propertyName, whenCondition);
        }
        public void MinLength(Expression<Func<TEntity, string>> expressionProperty, string propertyName = "", int length = CoreConstants.MIN_LEN)
        {
            FluentValidationDecorator.MinLength(expressionProperty, propertyName, length);
        }
        public void MaxLength(Expression<Func<TEntity, string>> expressionProperty, string propertyName = "", int length = CoreConstants.MAX_LEN)
        {
            FluentValidationDecorator.MaxLength(expressionProperty, propertyName, length);
        }

        /// <summary>
        /// Validate field to be required, max and min length
        /// </summary>
        /// <param name="expressionProperty">the property</param>
        /// <param name="propertyName">the custom property name</param>
        /// <param name="required">required</param>
        /// <param name="maxLength">max length</param>
        /// <param name="minLength">min length</param>
        public void BasicValidationsToTextField(Expression<Func<TEntity, string>> expressionProperty, string propertyName = "", bool required = true, int maxLength = CoreConstants.MAX_LEN, int minLength = CoreConstants.MIN_LEN)
        {
            FluentValidationDecorator.BasicValidationsToTextField(expressionProperty, propertyName, required, maxLength, minLength);
        }

        public void MustBeNull<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionProperty, string propertyName = "")
        {
            FluentValidationDecorator.MustBeNull(expressionProperty, propertyName);
        }
        public void MustBeEmpty<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionProperty, string propertyName = "")
        {
            FluentValidationDecorator.MustBeEmpty(expressionProperty, propertyName);
        }

        public void RangeNumberInt(Expression<Func<TEntity, int>> expressionProperty, int max, int min = 0, string propertyName = "")
        {
            FluentValidationDecorator.RangeNumberInt(expressionProperty, max, min, propertyName);
        }
        public void RangeNumberDouble(Expression<Func<TEntity, double>> expressionProperty, double max, double min = 0, string propertyName = "")
        {
            FluentValidationDecorator.RangeNumberDouble(expressionProperty, max, min, propertyName);
        }
        public void MinDate(Expression<Func<TEntity, DateTime>> expressionProperty, DateTime limit, string propertyName = "")
        {
            FluentValidationDecorator.MinDate(expressionProperty, limit, propertyName);
        }
        public void MaxDate(Expression<Func<TEntity, DateTime>> expressionProperty, DateTime limit, string propertyName = "")
        {
            FluentValidationDecorator.MaxDate(expressionProperty, limit, propertyName);
        }

        public void DateNotBeGreaterThenCurrentDate(Expression<Func<TEntity, DateTime>> expressionProperty, string propertyName = "")
        {
            FluentValidationDecorator.DateNotBeGreaterThenCurrentDate(expressionProperty, propertyName);
        }
        public void DateNotBeLessThenCurrentDate(Expression<Func<TEntity, DateTime>> expressionProperty, string propertyName = "")
        {
            FluentValidationDecorator.DateNotBeLessThenCurrentDate(expressionProperty, propertyName);
        }
        public void ValidRangeDate(Expression<Func<TEntity, DateTime>> expressionProperty, DateTime minDate, DateTime maxDate, string propertyName = "")
        {
            FluentValidationDecorator.ValidRangeDate(expressionProperty, minDate, maxDate, propertyName);
        }
        /// <summary>
        /// Valid if date is between 1900 and maxBirthDate (where default is current date)
        /// </summary>
        /// <param name="expressionProperty">date to validate</param>
        /// <param name="maxBirthDate">default is current date</param>
        /// <param name="propertyName">property name to display</param>
        public void ValidBirthDate(Expression<Func<TEntity, DateTime>> expressionProperty, DateTime? maxBirthDate = null, string propertyName = "")
        {
            FluentValidationDecorator.ValidBirthDate(expressionProperty, maxBirthDate, propertyName);
        }

        public void Email(Expression<Func<TEntity, string>> expressionProperty, string propertyName = "")
        {
            FluentValidationDecorator.Email(expressionProperty, propertyName);
        }
        public void AddValidationsFromDependentListProperty<TClassWithValidations>(Expression<Func<TEntity, IEnumerable<TClassWithValidations>>> expressionListProperty
               , string propertyName = ""
               , bool required = true) where TClassWithValidations : IClassWithDomainValidations<TClassWithValidations>
        {
            FluentValidationDecorator.AddValidationsFromDependentListProperty(expressionListProperty, propertyName, required);
        }
        public void AddValidationsFromDependentProperty<TClassWithValidations>(Expression<Func<TEntity, TClassWithValidations>> expressionListProperty
              , string propertyName = ""
              , bool required = true) where TClassWithValidations : IClassWithDomainValidations<TClassWithValidations>
        {
            FluentValidationDecorator.AddValidationsFromDependentProperty(expressionListProperty, propertyName, required);
        }
        public void DontRepeatDependentListItemProperty(Expression<Func<TEntity, IEnumerable<string>>> expressionListSelectedUnicKeys
             , string propertyName
             )
        {
            FluentValidationDecorator.DontRepeatDependentListItemProperty(expressionListSelectedUnicKeys, propertyName);
        }
        public void DontRepeatDependentListItemProperty(Expression<Func<TEntity, IEnumerable<Guid>>> expressionListSelectedEntityIds
                , string propertyName
                )
        {
            FluentValidationDecorator.DontRepeatDependentListItemProperty(expressionListSelectedEntityIds, propertyName);
        }

        public void AddCustomValidation<TFuncReturn>(Expression<Func<TEntity, TFuncReturn>> expressionProperty, Func<TFuncReturn, bool> validationMethod, string customValidationMessage)
        {
            FluentValidationDecorator.AddCustomValidation(expressionProperty, validationMethod, customValidationMessage);
        }
    }
}
