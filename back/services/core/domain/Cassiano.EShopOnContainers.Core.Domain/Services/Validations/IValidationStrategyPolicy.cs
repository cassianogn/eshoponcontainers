using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Results;

namespace Cassiano.EShopOnContainers.Core.Domain.Services.Validations
{
    public interface IValidationStrategyPolicy<TEntity>
    {
        ValidationStrategyType WhatDoWhenInvalidStateType { get; }
        Task<ValidationStrategyPolicyResult> ValidateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
