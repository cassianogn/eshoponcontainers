﻿using DTI.Core.Domain.Services.Validations;
using System.Threading;
using System.Threading.Tasks;

namespace DTI.Core.Domain.Tests.Unit.Validations.Service.Policies
{
    internal class EntityValidateIndividualTestStrategyPolicy : IValidationStrategyPolicy<EntityToServiceValidationTest>
    {
        public ValidationStrategyType WhatDoWhenInvalidStateType => ValidationStrategyType.IndividualValidationResult;

        public Task<ValidationStrategyPolicyResult> ValidateAsync(EntityToServiceValidationTest entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(ValidationStrategyPolicyResult.Invalid("individual execution", "this is a individual validation error 1"));
        }
    }
}
