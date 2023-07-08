using Cassiano.EShopOnContainers.Core.Domain.Services.Validations;
using System.Threading;
using System.Threading.Tasks;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.Policies
{
    internal class EntityValidateIndividualTestStrategyPolicy : IValidationStrategyPolicy<EntityToValidationTest>
    {
        public ValidationStrategyType WhatDoWhenInvalidStateType => ValidationStrategyType.IndividualValidationResult;

        public Task<ValidationStrategyPolicyResult> ValidateAsync(EntityToValidationTest entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(ValidationStrategyPolicyResult.Invalid("individual execution", "this is a individual validation error 1"));
        }
    }
}
