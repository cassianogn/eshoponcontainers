using Cassiano.EShopOnContainers.Core.Domain.Services.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Validations.Policies
{
    internal class EntityValidateContainsForbbidenDescriptionStrategyPolicy : IValidationStrategyPolicy<EntityToValidationTest>
    {
        private readonly List<string> _forbbidenTerms = new() { "forbbiden term" };
        public ValidationStrategyType WhatDoWhenInvalidStateType => ValidationStrategyType.InGroupValidationResult;

        public Task<ValidationStrategyPolicyResult> ValidateAsync(EntityToValidationTest entity, CancellationToken cancellationToken = default)
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
