using DTI.Core.Domain.Services.Validations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DTI.Core.Domain.Tests.Unit.Validations.Service.Policies
{
    internal class EntityValidateContainsForbbidenDescriptionStrategyPolicy : IValidationStrategyPolicy<EntityToServiceValidationTest>
    {
        private readonly List<string> _forbbidenTerms = new() { "forbbiden term" };
        public ValidationStrategyType WhatDoWhenInvalidStateType => ValidationStrategyType.InGroupValidationResult;

        public Task<ValidationStrategyPolicyResult> ValidateAsync(EntityToServiceValidationTest entity, CancellationToken cancellationToken = default)
        {
            foreach (var forbbidenDescription in _forbbidenTerms)
            {
                if (entity.CustomValue.Contains(forbbidenDescription))
                    return Task.FromResult(ValidationStrategyPolicyResult.Invalid("custom validation", "the custom value contains a forbbiden term"));
            }

            return Task.FromResult(ValidationStrategyPolicyResult.Valid());
        }
    }
}
