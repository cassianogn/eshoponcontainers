using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;
using System;
using System.Linq;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.FluentValidationDecorator.Entities.Policies
{
    internal class EntityFluentValidationDecoratorPolicy : DomainValidationStrategyPolicy<EntityFluentValidationDecorator>
    {
        public EntityFluentValidationDecoratorPolicy(EntityFluentValidationDecorator entity) : base(entity)
        {
        }

        public override void SetValidationRules()
        {
            BasicValidationsToTextField((entityValidate) => entityValidate.Required);
            BasicValidationsToTextField((entityValidate) => entityValidate.MinLength);
            BasicValidationsToTextField((entityValidate) => entityValidate.MaxLength);

            RangeNumberDouble((entity) => entity.OverflowDouble, 1000, 10);
            RangeNumberDouble((entity) => entity.MimRangeDouble, 9.99, 0);
            RangeNumberInt((entity) => entity.OverflowInt, 1000, 10);
            RangeNumberInt((entity) => entity.MimRangeInt, 9, 0);
            
            Email((entity) => entity.Email);

            ValidBirthDate((entity) => entity.BirthDateAfeterToDay);
            ValidBirthDate((entity) => entity.BirthDateMustOld);
            DateNotBeLessThenCurrentDate((entity) => entity.NotBeLessThenCurrentDate);
            DateNotBeGreaterThenCurrentDate((entity) => entity.DateNotBeGreaterThenCurrentDate);
            ValidRangeDate((entity) => entity.OverflowDate, DateTime.UtcNow, DateTime.UtcNow.AddDays(10));
            ValidRangeDate((entity) => entity.MinRangeDate, DateTime.UtcNow.AddDays(-10), DateTime.UtcNow.AddMinutes(5));

            AddValidationsFromDependentListProperty((entity) => entity.EntitiesDependentInvalidRules);
            AddValidationsFromDependentProperty((entity) => entity.EntityDependent);
            DontRepeatDependentListItemProperty((entity) => entity.EntitiesDependentDuplicatesById.Select(dependent => dependent.Id), "Dependent - Id");
            DontRepeatDependentListItemProperty((entity) => entity.EntitiesDependentDuplicatesByUnicKey.Select(dependent => dependent.Name + dependent.Organization), "Dependent - Keys");
        }
    }
}
