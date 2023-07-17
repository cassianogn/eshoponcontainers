using Cassiano.EShopOnContainers.Core.Domain.Services.Validations;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers;
using Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.Service.Policies;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.Service
{
    public class ValidationStrategyTests
    {
        private ValidationStrategyService<EntityToServiceValidationTest> _validationStrategyService;
        private readonly ValidationErrorMessageService _validationErrorMessageService = new ();
        public ValidationStrategyTests()
        {

        }
        // testes para ValidationStrategyService
        [Trait("Categoria", "ValidationStrategy")]
        [Fact(DisplayName = "1 - Validate Service Orquestrator in group")]
        public async Task ValidateDomainValidationStrategyInGroup()
        {
            //arrange 
            var entity = new EntityToServiceValidationTest(Guid.NewGuid(), "", "forbbiden term in text test");
            var validations = entity.GetValidationStrategyPolicies().ToList();
            _validationStrategyService = new ValidationStrategyService<EntityToServiceValidationTest>();
            _validationStrategyService.AddValidationStrategyPolicies(validations);
            _validationStrategyService.AddValidationStrategyPolicy(new EntityValidateContainsTestTermStrategyPolicy());
            _validationStrategyService.AddValidationStrategyPolicy(new EntityValidateIndividualTestStrategyPolicy());
            _validationStrategyService.AddValidationStrategyPolicy(new EntityValidateContainsForbbidenDescriptionStrategyPolicy());

            //action
            var result = await _validationStrategyService.ValidateAsync(entity);

            // assert
            Assert.False(result.Valid);

            var domainErrors = result.PoliciesResult.SingleOrDefault(policyResult => policyResult.ErrorGroup == _validationErrorMessageService.DomainRuleErrorGroup());
            Assert.NotNull(domainErrors);
            Assert.Contains(domainErrors!.Errors, error => error == _validationErrorMessageService.Required(nameof(EntityToServiceValidationTest.Description)));

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
            var entity = new EntityToServiceValidationTest(Guid.NewGuid(), "value", "value");
            _validationStrategyService = new ValidationStrategyService<EntityToServiceValidationTest>();
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
