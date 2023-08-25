using DTI.Core.Domain.Services.Validations;
using System.Threading;
using System.Threading.Tasks;

namespace DTI.Core.Domain.Tests.Unit.Validations.Service.Policies
{
    internal class EntityValidateContainsTestTermStrategyPolicy : IValidationStrategyPolicy<EntityToServiceValidationTest>
    {
        public ValidationStrategyType WhatDoWhenInvalidStateType => ValidationStrategyType.InGroupValidationResult;

        public Task<ValidationStrategyPolicyResult> ValidateAsync(EntityToServiceValidationTest entity, CancellationToken cancellationToken = default)
        {
            if (entity.CustomValue.Contains("test"))
                return Task.FromResult(ValidationStrategyPolicyResult.Invalid("custom validation", "the custom value contains a test term"));

            return Task.FromResult(ValidationStrategyPolicyResult.Valid());
        }
    }
}
