using Cassiano.EShopOnContainers.Core.Domain.Interfaces.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Results;

namespace Cassiano.EShopOnContainers.Core.Domain.Services.Validations
{
    public class ValidationStrategyService<TEntity> where TEntity : IEntity
    {
        private readonly List<IValidationStrategyPolicy<TEntity>> _validationsPolicies;

        public ValidationStrategyService()
        {
            _validationsPolicies = new List<IValidationStrategyPolicy<TEntity>>();
        }

        public void AddValidationStrategyPolicy(IValidationStrategyPolicy<TEntity> validationStrategyPolicy) => _validationsPolicies.Add(validationStrategyPolicy);
        public void AddValidationStrategyPolicies(IEnumerable<IValidationStrategyPolicy<TEntity>> validationStrategyPolicy) => _validationsPolicies.AddRange(validationStrategyPolicy);

        public async Task<ValidationStrategyResult> ValidateAsync(TEntity entity)
        {
            var validationResults = new ValidationStrategyResult();
            
            var validationsGroupPolicies = _validationsPolicies.Where(x => x.WhatDoWhenInvalidStateType == ValidationStrategyType.InGroupValidationResult);
            var validationsBreakerPolicies = _validationsPolicies.Where(x => x.WhatDoWhenInvalidStateType == ValidationStrategyType.IndividualValidationResult);
            
            await RunInGroupValidationResult(entity, validationResults, validationsGroupPolicies);

            if (!validationResults.Valid)
                return validationResults;

            await RunIndividualValidations(entity, validationResults, validationsBreakerPolicies);

            return validationResults;
        }

        private static async Task RunInGroupValidationResult(TEntity entity, ValidationStrategyResult validationResults, IEnumerable<IValidationStrategyPolicy<TEntity>> validationsGroupPolicies, CancellationToken cancellationToken = default)
        {
            foreach (var validationPolocy in validationsGroupPolicies)
            {
                var validationResult = await validationPolocy.ValidateAsync(entity, cancellationToken);

                if (!validationResult.IsValid)
                    validationResults.Add(validationResult);
            }
        }

        private static async Task RunIndividualValidations(TEntity entity, ValidationStrategyResult validationResults, IEnumerable<IValidationStrategyPolicy<TEntity>> validationsBreakerPolicies, CancellationToken cancellationToken = default)
        {
            foreach (var validationPolocy in validationsBreakerPolicies)
            {
                var validationResult = await validationPolocy.ValidateAsync(entity, cancellationToken);

                if (!validationResult.IsValid)
                {
                    validationResults.Add(validationResult);
                    break;
                }
            }
        }

    
    }
}
