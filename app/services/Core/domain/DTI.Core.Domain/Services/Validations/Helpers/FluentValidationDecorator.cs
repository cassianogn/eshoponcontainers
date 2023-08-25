using DTI.Core.Domain.Helpers.Constants;
using DTI.Core.Domain.Interfaces.Entities;
using DTI.Core.Domain.Services.Validations.Helpers.CustomValidations;
using FluentValidation;
using FluentValidation.Results;
using System.Linq.Expressions;

namespace DTI.Core.Domain.Services.Validations.Helpers
{
    public class FluentValidationDecorator<TEntity> : AbstractValidator<TEntity>
    {
        protected ValidationResult _validationResult = new();
        protected readonly TEntity _entity;
        private readonly ValidationErrorMessageService _validationErrorMessageService;

        public FluentValidationDecorator(TEntity entity, ValidationErrorMessageService validationErrorMessageService)
        {
            _entity = entity;
            _validationErrorMessageService = validationErrorMessageService;
        }

        public ValidationStrategyPolicyResult RunValidation(TEntity entity)
        {
            _validationResult = Validate(entity);

            if (_validationResult.IsValid)
                return ValidationStrategyPolicyResult.Valid();

            var errorGrouop = _validationErrorMessageService.DomainRuleErrorGroup();
            var errorMessages = _validationResult.Errors.Select(error => ValidationErrorMessageService.FormatingErrorResult(error.ErrorMessage)).Distinct().ToList();

            return ValidationStrategyPolicyResult.Invalid(errorGrouop, errorMessages);
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

        public virtual void Required<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionProperty, string propertyName = "", Func<TEntity, bool>? whenCondition = null)
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);

            var emptyRole= RuleFor(expressionProperty)
                .NotEmpty()
                .WithMessage(_validationErrorMessageService.Required(propertyName));
        
            if (whenCondition != null)
                emptyRole.When(whenCondition);

            var type = typeof(TPropertyReturn);
            var isGuid = type.FullName!.Contains("System.Guid") && (type.FullName.Contains("System.Nullable") || type.Name == "Guid");
            if (isGuid)
            {
                var guidToValidate = expressionProperty.Compile().Invoke(_entity) as Guid?;
                Expression<Func<TEntity, Guid?>> expressionGuid = entity => guidToValidate;
                var guidEmptyRole = RuleFor(expressionGuid).SetValidator(new GuidEmptyCustomValidation(propertyName, _validationErrorMessageService));
                if (whenCondition != null)
                    guidEmptyRole.When(whenCondition);
            }
        }
        public void MinLength(Expression<Func<TEntity, string>> expressionProperty, string propertyName = "", int length = CoreConstants.MIN_LEN)
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);
            RuleFor(expressionProperty)
                .MinimumLength(length)
                .WithMessage(_validationErrorMessageService.MinLength(propertyName, length));
        }

        public void MaxLength(Expression<Func<TEntity, string>> expressionProperty, string propertyName = "", int length = CoreConstants.MAX_LEN)
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);
            RuleFor(expressionProperty)
                .MaximumLength(length)
                .WithMessage(_validationErrorMessageService.MaxLength(propertyName, length));
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
            propertyName = GetPropertyName(expressionProperty, propertyName);
            if (required)
                Required(expressionProperty, propertyName);

            MinLength(expressionProperty, propertyName, minLength);
            MaxLength(expressionProperty, propertyName, maxLength);
        }

        public void MustBeNull<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionProperty, string propertyName = "")
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);
            RuleFor(expressionProperty)
                .Null()
                .WithMessage(_validationErrorMessageService.MustBeNull(propertyName));

        }
        public void MustBeEmpty<TPropertyReturn>(Expression<Func<TEntity, TPropertyReturn>> expressionProperty, string propertyName = "")
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);
            RuleFor(expressionProperty)
                .Empty()
                .WithMessage(_validationErrorMessageService.MustBeNull(propertyName));
        }

        public void RangeNumberInt(Expression<Func<TEntity, int>> expressionProperty, int max, int min = 0, string propertyName = "")
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);
            RuleFor(expressionProperty)
                .GreaterThanOrEqualTo(min)
                .WithMessage(_validationErrorMessageService.NumberMinInt(propertyName, min))
                .LessThanOrEqualTo(max)
                .WithMessage(_validationErrorMessageService.NumberMaxInt(propertyName, max));
        }
        public void RangeNumberDouble(Expression<Func<TEntity, double>> expressionProperty, double max, double min = 0, string propertyName = "")
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);
            RuleFor(expressionProperty)
                .GreaterThanOrEqualTo(min)
                .WithMessage(_validationErrorMessageService.NumberMinDouble(propertyName, min))
                .LessThanOrEqualTo(max)
                .WithMessage(_validationErrorMessageService.NumberMaxDouble(propertyName, max));
        }


        public void MinDate(Expression<Func<TEntity, DateTime>> expressionProperty, DateTime limit, string propertyName = "")
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);
            RuleFor(expressionProperty)
                .GreaterThanOrEqualTo(limit)
                .WithMessage(_validationErrorMessageService.DateGreaterThan(propertyName, limit));
        }
        public void MaxDate(Expression<Func<TEntity, DateTime>> expressionProperty, DateTime limit, string propertyName = "")
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);
            RuleFor(expressionProperty)
                .LessThanOrEqualTo(limit)
                .WithMessage(_validationErrorMessageService.DataLessThen(propertyName, limit));
        }

        public void DateNotBeGreaterThenCurrentDate(Expression<Func<TEntity, DateTime>> expressionProperty, string propertyName = "")
        {
            MaxDate(expressionProperty, CoreConstants.CURRENT_DATE, propertyName);
        }
        public void DateNotBeLessThenCurrentDate(Expression<Func<TEntity, DateTime>> expressionProperty, string propertyName = "")
        {
            MinDate(expressionProperty, CoreConstants.CURRENT_DATE, propertyName);
        }


        public void ValidRangeDate(Expression<Func<TEntity, DateTime>> expressionProperty, DateTime minDate, DateTime maxDate, string propertyName = "")
        {
            MaxDate(expressionProperty, maxDate, propertyName);
            MinDate(expressionProperty, minDate, propertyName);
        }
        /// <summary>
        /// Valid if date is between 1900 and maxBirthDate (where default is current date)
        /// </summary>
        /// <param name="expressionProperty">date to validate</param>
        /// <param name="maxBirthDate">default is current date</param>
        /// <param name="propertyName">property name to display</param>
        public void ValidBirthDate(Expression<Func<TEntity, DateTime>> expressionProperty, DateTime? maxBirthDate = null, string propertyName = "")
        {
            maxBirthDate ??= CoreConstants.CURRENT_DATE;
            ValidRangeDate(expressionProperty, CoreConstants.MIN_BIRTH_DATE, maxBirthDate.Value, propertyName);
        }

        public void Email(Expression<Func<TEntity, string>> expressionProperty, string propertyName = "")
        {
            propertyName = GetPropertyName(expressionProperty, propertyName);
            RuleFor(expressionProperty)
                .EmailAddress()
                .WithMessage(_validationErrorMessageService.Email(propertyName));
        }

        public void AddValidationsFromDependentListProperty<TClassWithValidations>(Expression<Func<TEntity, IEnumerable<TClassWithValidations>>> expressionListProperty
               , string propertyName = ""
               , bool required = true) where TClassWithValidations : IClassWithDomainValidations<TClassWithValidations>
        {
            propertyName = GetPropertyName(expressionListProperty, propertyName);

            if (required)
                Required(expressionListProperty, propertyName);

            var dependecies = expressionListProperty.Compile().Invoke(_entity);
            if (dependecies == null)
                return;

            foreach (var dependecy in dependecies)
                foreach (var validationPolicy in dependecy.GetValidationStrategyPolicies())
                {
                    validationPolicy.SetPrefixToErrorMessages(propertyName);
                    validationPolicy.SetValidationRules();
                    RuleForEach(expressionListProperty).SetValidator(validationPolicy.FluentValidationDecorator);
                }
        }

        public void AddValidationsFromDependentProperty<TClassWithValidations>(Expression<Func<TEntity, TClassWithValidations>> expressionListProperty
              , string propertyName = ""
              , bool required = true) where TClassWithValidations : IClassWithDomainValidations<TClassWithValidations>
        {
            propertyName = GetPropertyName(expressionListProperty, propertyName);

            if (required)
                Required(expressionListProperty, propertyName);

            var dependecy = expressionListProperty.Compile().Invoke(_entity);
            if (dependecy == null)
                return;

            foreach (var validationPolicy in dependecy.GetValidationStrategyPolicies())
            {
                validationPolicy.SetPrefixToErrorMessages(propertyName, false);
                validationPolicy.SetValidationRules();
                RuleFor(expressionListProperty).SetValidator(validationPolicy.FluentValidationDecorator);
            }
        }

        public void DontRepeatDependentListItemProperty(Expression<Func<TEntity, IEnumerable<string>>> expressionListSelectedUnicKeys
             , string propertyName
             )
        {
            RuleFor(expressionListSelectedUnicKeys)
                .Must(unicKeys => !unicKeys
                    .Any(unicKeysCurrentItem => unicKeys.Count(unicKeysListItem => unicKeysCurrentItem == unicKeysListItem) > 1))
                .WithMessage(_validationErrorMessageService.DontRepeatItemOnList(propertyName));
        }
        public void DontRepeatDependentListItemProperty(Expression<Func<TEntity, IEnumerable<Guid>>> expressionListSelectedEntityIds
                , string propertyName
                )
        {

            RuleFor(expressionListSelectedEntityIds)
                .Must(unicKeys => !unicKeys
                    .Any(unicKeysCurrentItem => unicKeys.Count(unicKeysListItem => unicKeysCurrentItem == unicKeysListItem) > 1))
                .WithMessage(_validationErrorMessageService.DontRepeatItemOnList(propertyName));
        }

        public void AddCustomValidation<TFuncReturn>(Expression<Func<TEntity, TFuncReturn>> expressionProperty, Func<TFuncReturn, bool> validationMethod, string customValidationMessage)
        {
            RuleFor(expressionProperty).Must(validationMethod).WithMessage(customValidationMessage);
        }
    }
}
