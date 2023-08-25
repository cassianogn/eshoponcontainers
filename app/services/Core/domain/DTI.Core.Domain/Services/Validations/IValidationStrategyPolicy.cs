namespace DTI.Core.Domain.Services.Validations
{
    public interface IValidationStrategyPolicy<TEntity>
    {
        ValidationStrategyType WhatDoWhenInvalidStateType { get; }
        Task<ValidationStrategyPolicyResult> ValidateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
