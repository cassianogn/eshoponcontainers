using System;
using System.Collections.Generic;

namespace DTI.Core.Domain.Tests.Unit.Validations.FluentValidationDecorator.Entities
{
    public class EntityFluentValidationDecorator
    {
        public string Required { get; set; }
        public string MinLength { get; set; }
        public string MaxLength { get; set; }
        public double OverflowDouble { get; set; }
        public double MimRangeDouble { get; set; }
        public int OverflowInt { get; set; }
        public int MimRangeInt { get; set; }
        public string Email { get; set; }
        public IEnumerable<EntityDependentFluentValidationDecorator> EntitiesDependentDuplicatesByUnicKey { get; set; }
        public IEnumerable<EntityDependentFluentValidationDecorator> EntitiesDependentDuplicatesById { get; set; }
        public IEnumerable<EntityDependentFluentValidationDecorator> EntitiesDependentInvalidRules { get; set; }
        public EntityDependentFluentValidationDecorator EntityDependent { get; set; }
        public DateTime BirthDateAfeterToDay { get; set; }
        public DateTime BirthDateMustOld { get; set; }
        public DateTime NotBeLessThenCurrentDate { get; set; }
        public DateTime DateNotBeGreaterThenCurrentDate { get; set; }
        public DateTime OverflowDate { get; set; }
        public DateTime MinRangeDate { get; set; }

    }
}
