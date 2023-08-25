using DTI.Core.Application.Tests.Integration.Domain.FakieEntities;
using DTI.Core.Domain.Services.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DTI.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeCreateEntity
{
    internal class MinhaCustomValidation : IValidationStrategyPolicy<FakeEntity>
    {
        private readonly IFakeEntityRepository _repository;

        public MinhaCustomValidation(IFakeEntityRepository repository)
        {
            _repository = repository;
        }

        public ValidationStrategyType WhatDoWhenInvalidStateType => ValidationStrategyType.InGroupValidationResult;

        public async Task<ValidationStrategyPolicyResult> ValidateAsync(FakeEntity entity, CancellationToken cancellationToken = default)
        {
            await  _repository.GetByIdAsync(entity.Id);

            // TODO: TODA VALIDA~]AO

            return ValidationStrategyPolicyResult.Valid();
        }
    }
}
