using Cassiano.EShopOnContainers.Core.Domain.Services.Validations;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;
using Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations
{
    public class ValidationStrategyTests
    {
        private ValidationStrategyService<EntityToValidationTest> _validationStrategyService;
        public ValidationStrategyTests()
        {
           
        }
        // testes para ValidationStrategyService
        [Trait("Categoria", "ValidationStrategy")]
        [Fact(DisplayName = "1 - Validate Service Orquestrator in group")]
        public async Task ValidateDomainValidationStrategyInGroup()
        {
            //arrange 
            var entity = new EntityToValidationTest(Guid.NewGuid(), "", "forbbiden term in text test");
            var validations = entity.GetValidationStrategyPolicies().ToList();
            _validationStrategyService = new ValidationStrategyService<EntityToValidationTest>();
            _validationStrategyService.AddValidationStrategyPolicies(validations);
            _validationStrategyService.AddValidationStrategyPolicy(new EntityValidateContainsTestTermStrategyPolicy());
            _validationStrategyService.AddValidationStrategyPolicy(new EntityValidateIndividualTestStrategyPolicy());

            //action
            var result = await _validationStrategyService.ValidateAsync(entity);

            // assert
            Assert.False(result.Valid);

            var domainErrors = result.PoliciesResult.SingleOrDefault(policyResult => policyResult.ErrorGroup == ValidationErrorMessage.DomainRuleErrorGroup());
            Assert.NotNull(domainErrors);
            Assert.Contains(domainErrors!.Errors, error => error == ValidationErrorMessage.Required(nameof(EntityToValidationTest.Description)));

            var customError = result.PoliciesResult.SingleOrDefault(policyResult => policyResult.ErrorGroup == "custom validation");
            Assert.NotNull(customError);
            Assert.Contains(customError!.Errors, error => error == "the custom value contains a forbbiden term");
            Assert.Contains(customError!.Errors, error => error == "the custom value contains a test term");

            var individualExecution = result.PoliciesResult.SingleOrDefault(policyResult => policyResult.ErrorGroup == "individual execution");
            Assert.Null(individualExecution);

        }

        // testes para ValidationStrategyService
        [Trait("Categoria", "ValidationStrategy")]
        [Fact(DisplayName = "2 - Validate Service Orquestrator in individual")]
        public async Task ValidateDomainValidationStrategyInIndividual()
        {
            //arrange 
            var entity = new EntityToValidationTest(Guid.NewGuid(), "value", "value");
            _validationStrategyService = new ValidationStrategyService<EntityToValidationTest>();
            _validationStrategyService.AddValidationStrategyPolicy(new EntityValidateIndividualTestStrategyPolicy());
            _validationStrategyService.AddValidationStrategyPolicy(new EntityValidateSecundIndividualTestStrategyPolicy());

            //action
            var result = await _validationStrategyService.ValidateAsync(entity);

            // assert
            Assert.False(result.Valid);
           
            var customError = result.PoliciesResult.SingleOrDefault(policyResult => policyResult.ErrorGroup == "individual execution");
            Assert.NotNull(customError);
            Assert.DoesNotContain(customError!.Errors, error => error == "this is a individual validation error 2");
            Assert.Contains(customError!.Errors, error => error == "this is a individual validation error 1");
        }
    }
}
