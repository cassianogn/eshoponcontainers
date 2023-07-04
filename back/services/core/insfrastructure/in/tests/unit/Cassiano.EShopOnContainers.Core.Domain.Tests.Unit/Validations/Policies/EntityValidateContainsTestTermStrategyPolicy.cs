using Cassiano.EShopOnContainers.Core.Domain.Services.Validations;
using System.Threading;
using System.Threading.Tasks;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.Policies
{
    internal class EntityValidateContainsTestTermStrategyPolicy : IValidationStrategyPolicy<EntityToValidationTest>
    {
        public ValidationStrategyType WhatDoWhenInvalidStateType => ValidationStrategyType.InGroupValidationResult;

        public Task<ValidationStrategyPolicyResult> ValidateAsync(EntityToValidationTest entity, CancellationToken cancellationToken = default)
        {
            if (entity.CustomValue.Contains("test"))
                return Task.FromResult(ValidationStrategyPolicyResult.Invalid("custom validation", "the custom value contains a test term"));

            return Task.FromResult(ValidationStrategyPolicyResult.Valid());
        }
    }
}
