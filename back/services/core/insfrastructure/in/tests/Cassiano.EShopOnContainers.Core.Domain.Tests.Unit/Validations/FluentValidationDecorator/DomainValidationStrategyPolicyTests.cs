using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;
using Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.FluentValidationDecorator.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.FluentValidationDecorator.Entities.Policies;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.FluentValidationDecorator
{
    public class DomainValidationStrategyPolicyTests
    {
        private readonly ValidationErrorMessageService _validationErrorMessageService = new();

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "Required Invalid")]
        public async Task EntityFluentValidationDecorator_Required_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);
            
            //result
            Assert.Single(result.Errors , _validationErrorMessageService.Required("Required"));
            Assert.False(result.IsValid);
        }
        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "Required Valid")]
        public async Task EntityFluentValidationDecorator_Required_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Empty(result.Errors.Where(error => error == _validationErrorMessageService.Required("Required")));
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "MinLength Invalid")]
        public async Task EntityFluentValidationDecorator_MinLength_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Single(result.Errors , _validationErrorMessageService.MinLength("MinLength", 2));
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "MinLength Valid")]
        public async Task EntityFluentValidationDecorator_MinLength_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Empty(result.Errors.Where(error => error == _validationErrorMessageService.MinLength("MinLength", 2)));
        }
        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "MaxLength Invalid")]
        public async Task EntityFluentValidationDecorator_MaxLength_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Single(result.Errors , _validationErrorMessageService.MaxLength("MaxLength", 150));
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "MaxLength Valid")]
        public async Task EntityFluentValidationDecorator_MaxLength_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Empty(result.Errors.Where(error => error == _validationErrorMessageService.MaxLength("MaxLength", 150)));
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "OverflowDouble Invalid")]
        public async Task EntityFluentValidationDecorator_OverflowDouble_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Single(result.Errors , _validationErrorMessageService.NumberMaxDouble("OverflowDouble", 1000));
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "OverflowDouble Valid")]
        public async Task EntityFluentValidationDecorator_OverflowDouble_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Empty(result.Errors.Where(error => error == _validationErrorMessageService.NumberMaxDouble("OverflowDouble", 1000)));
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "MimRangeDouble Invalid")]
        public async Task EntityFluentValidationDecorator_MimRangeDouble_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);
            
            //result
            Assert.Single(result.Errors , _validationErrorMessageService.NumberMinDouble("MimRangeDouble", 0));
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "MimRangeDouble Valid")]
        public async Task EntityFluentValidationDecorator_MimRangeDouble_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            
            //action
            var result = await entityValidation.ValidateAsync(entity);
            
            //result
            Assert.Empty(result.Errors.Where(error => error == _validationErrorMessageService.NumberMinDouble("MimRangeDouble", 0)));
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "OverflowInt Invalid")]
        public async Task EntityFluentValidationDecorator_OverflowInt_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            
            //action
            var result = await entityValidation.ValidateAsync(entity);
            
            //result
            Assert.Single(result.Errors , _validationErrorMessageService.NumberMaxInt("OverflowInt", 1000));
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "OverflowInt Valid")]
        public async Task EntityFluentValidationDecorator_OverflowInt_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            
            //action
            var result = await entityValidation.ValidateAsync(entity);
            
            //result
            Assert.Empty(result.Errors.Where(error => error == _validationErrorMessageService.NumberMaxInt("OverflowInt", 1000)));
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "MimRangeInt Invalid")]
        public async Task EntityFluentValidationDecorator_MimRangeInt_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Single(result.Errors , _validationErrorMessageService.NumberMinInt("MimRangeInt", 0));
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "MimRangeInt Valid")]
        public async Task EntityFluentValidationDecorator_MimRangeInt_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            
            //action
            var result = await entityValidation.ValidateAsync(entity);
            
            //result
            Assert.Empty(result.Errors.Where(error => error == _validationErrorMessageService.NumberMinInt("MimRangeInt", 0)));
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "Email Invalid")]
        public async Task EntityFluentValidationDecorator_Email_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            
            //action
            var result = await entityValidation.ValidateAsync(entity);
            
            //result
            Assert.Single(result.Errors , _validationErrorMessageService.Email("Email"));
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "Email Valid")]
        public async Task EntityFluentValidationDecorator_Email_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            
            //action
            var result = await entityValidation.ValidateAsync(entity);
            
            //result
            Assert.Empty(result.Errors.Where(error => error == _validationErrorMessageService.Email("Email")));
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "BirthDateAfeterToDay Invalid")]
        public async Task EntityFluentValidationDecorator_BirthDateAfeterToDay_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "BirthDateAfeterToDay must be less than";
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Single(errors);
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "BirthDateAfeterToDay Valid")]
        public async Task EntityFluentValidationDecorator_BirthDateAfeterToDay_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "BirthDateAfeterToDay must be less than";
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Empty(errors);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "BirthDateMustOld Invalid")]
        public async Task EntityFluentValidationDecorator_BirthDateMustOld_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "BirthDateMustOld must be greater than";
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Single(errors);
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "BirthDateMustOld Valid")]

        public async Task EntityFluentValidationDecorator_BirthDateMustOld_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "BirthDateMustOld must be greater than";
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Empty(errors);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "DateNotBeGreaterThenCurrentDate Invalid")]
        public async Task EntityFluentValidationDecorator_DateNotBeGreaterThenCurrentDate_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "DateNotBeGreaterThenCurrentDate must be less than";
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Single(errors);
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "DateNotBeGreaterThenCurrentDate Valid")]
        public async Task EntityFluentValidationDecorator_DateNotBeGreaterThenCurrentDate_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "DateNotBeGreaterThenCurrentDate must be less than";
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Empty(errors);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "NotBeLessThenCurrentDate Invalid")]
        public async Task EntityFluentValidationDecorator_NotBeLessThenCurrentDate_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "NotBeLessThenCurrentDate must be greater than";
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Single(errors);
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "NotBeLessThenCurrentDate Valid")]
        public async Task EntityFluentValidationDecorator_NotBeLessThenCurrentDate_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "NotBeLessThenCurrentDate must be greater than";
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Empty(errors);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "OverflowDate Invalid")]
        public async Task EntityFluentValidationDecorator_OverflowDate_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "OverflowDate must be less than";
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Single(errors);
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "OverflowDate Valid")]
        public async Task EntityFluentValidationDecorator_OverflowDate_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "OverflowDate must be less than";
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Empty(errors);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "MinRangeDate Invalid")]
        public async Task EntityFluentValidationDecorator_MinRangeDate_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "MinRangeDate must be greater than";
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Single(errors);
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "MinRangeDate Valid")]
        public async Task EntityFluentValidationDecorator_MinRangeDate_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            var partialMessageError = "MinRangeDate must be greater than";
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            var errors = result.Errors.Where(error => error.Contains(partialMessageError)).ToList();
            Assert.Empty(errors);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "EntitiesDependentInvalidRules Invalid")]
        public async Task EntityFluentValidationDecorator_EntitiesDependentInvalidRules_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Equal(4, result.Errors.Count(error => error.Contains("EntitiesDependentInvalidRules")));
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "EntitiesDependentInvalidRules Valid")]
        public async Task EntityFluentValidationDecorator_EntitiesDependentInvalidRules_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);
            
            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Empty(result.Errors.Where(error => error.Contains("EntitiesDependentInvalidRules")));
            Assert.True(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "EntityDependentInvalidRules Invalid")]
        public async Task EntityFluentValidationDecorator_EntityDependentInvalidRules_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Equal(2, result.Errors.Count(error => error.Contains("EntityDependent")));
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "EntityDependentInvalidRules Valid")]
        public async Task EntityFluentValidationDecorator_EntityDependentInvalidRules_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Empty(result.Errors.Where(error => error.Contains("EntityDependent")));
            Assert.True(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "EntitiesDependentDuplicatesById Invalid")]
        public async Task EntityFluentValidationDecorator_EntitiesDependentDuplicatesById_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Equal(1, result.Errors.Count(error => error.Contains("Dependent - Id")));
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "EntitiesDependentDuplicatesById Valid")]
        public async Task EntityFluentValidationDecorator_EntitiesDependentDuplicatesById_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Empty(result.Errors.Where(error => error.Contains("Dependent - Id")));
            Assert.True(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "EntitiesDependentDuplicatesByUnicKey Invalid")]
        public async Task EntityFluentValidationDecorator_EntitiesDependentDuplicatesByUnicKey_Invalid()
        {
            //arrange
            var entity = GetEntityInvalid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Equal(1, result.Errors.Count(error => error.Contains("Dependent - Keys")));
            Assert.False(result.IsValid);
        }

        [Trait("Category", "FluentValidationDecorator")]
        [Fact(DisplayName = "EntitiesDependentDuplicatesByUnicKey Valid")]
        public async Task EntityFluentValidationDecorator_EntitiesDependentDuplicatesByUnicKey_Valid()
        {
            //arrange
            var entity = GetEntityValid();
            var entityValidation = new EntityFluentValidationDecoratorPolicy(entity);

            //action
            var result = await entityValidation.ValidateAsync(entity);

            //result
            Assert.Empty(result.Errors.Where(error => error.Contains("Dependent - Keys")));
            Assert.True(result.IsValid);
        }

        private EntityFluentValidationDecorator GetEntityInvalid()
        {
            var unicId = Guid.NewGuid();
            var invalidEntity = new EntityFluentValidationDecorator
            {
                Required = "",
                MinLength = "s",
                MaxLength = "DescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescription",
                OverflowDouble = 2000,
                MimRangeDouble = -1,
                Email = "aaaaa",
                BirthDateAfeterToDay = DateTime.UtcNow.AddDays(1),
                BirthDateMustOld = DateTime.UtcNow.AddYears(-200),
                DateNotBeGreaterThenCurrentDate = DateTime.UtcNow.AddDays(1),
                NotBeLessThenCurrentDate = DateTime.UtcNow.AddDays(-1),
                OverflowDate = DateTime.UtcNow.AddDays(11),
                MinRangeDate = DateTime.UtcNow.AddDays(-11),
                OverflowInt = 2000,
                MimRangeInt = -1,
                EntitiesDependentDuplicatesByUnicKey = new List<EntityDependentFluentValidationDecorator>
                {
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "Name",
                        Organization = "Organization"
                    },
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "Name",
                        Organization = "Organization"
                    },
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "Namea",
                        Organization = "Organizatiosn"
                    }
                },
                EntitiesDependentDuplicatesById = new List<EntityDependentFluentValidationDecorator>
                {
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "Name asdasdas",
                        Organization = "Organizationad "
                    },
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = unicId,
                        Name = "Name asdasdasgg",
                        Organization = "Organization sdasdasd"
                    },
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = unicId,
                        Name = "Namea",
                        Organization = "Organizatiosn"
                    }
                },
                EntitiesDependentInvalidRules = new List<EntityDependentFluentValidationDecorator>()
                {
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "",
                        Organization = ""
                    },
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "",
                        Organization = ""
                    }
                },
                EntityDependent = new EntityDependentFluentValidationDecorator
                {
                    Id = Guid.NewGuid(),
                    Name = "",
                    Organization = ""
                }
            };
            return invalidEntity;
        }
        private EntityFluentValidationDecorator GetEntityValid()
        {
            var invalidEntity = new EntityFluentValidationDecorator
            {
                Required = "aslkdjlaskjdas",
                MinLength = "alskjdla",
                MaxLength = "asd",
                OverflowDouble = 999,
                MimRangeDouble = 0,
                Email = "aaa@a.com",
                BirthDateAfeterToDay = DateTime.UtcNow.AddDays(-1),
                BirthDateMustOld = DateTime.UtcNow.AddYears(-100),
                DateNotBeGreaterThenCurrentDate = DateTime.UtcNow.AddDays(-1),
                NotBeLessThenCurrentDate = DateTime.UtcNow.AddDays(1),
                OverflowDate = DateTime.UtcNow.AddDays(10),
                MinRangeDate = DateTime.UtcNow.AddDays(-9),
                OverflowInt = 1000,
                MimRangeInt = 0,
                EntitiesDependentDuplicatesByUnicKey = new List<EntityDependentFluentValidationDecorator>
                {
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "Nameazdas",
                        Organization = "Organization"
                    },
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "Namedsadsa",
                        Organization = "Organization"
                    },
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "Namea",
                        Organization = "Organizatiosn"
                    }
                },
                EntitiesDependentDuplicatesById = new List<EntityDependentFluentValidationDecorator>
                {
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "Name asdasdas",
                        Organization = "Organizationad "
                    },
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "Name asdasdasgg",
                        Organization = "Organization sdasdasd"
                    },
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "Namea",
                        Organization = "Organizatiosn"
                    }
                },
                EntitiesDependentInvalidRules = new List<EntityDependentFluentValidationDecorator>()
                {
                    new EntityDependentFluentValidationDecorator
                    {
                        Id = Guid.NewGuid(),
                        Name = "dasdasdas",
                        Organization = "dasdasdasda"
                    },
                },
                EntityDependent = new EntityDependentFluentValidationDecorator
                {
                    Id = Guid.NewGuid(),
                    Name = "asdasdas",
                    Organization = "aasdasdasdsa"
                }
            };
            return invalidEntity;
        }


    }
}
