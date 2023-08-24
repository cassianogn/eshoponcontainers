namespace Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Results
{

    public class ValidationStrategyResult
    {
        public ValidationStrategyResult()
        {
            PoliciesResult = new List<ValidationStrategyPolicyResult>();
        }

        public IList<ValidationStrategyPolicyResult> PoliciesResult { get; private set; }
        public bool Valid { get => !PoliciesResult.Any(x => !x.IsValid);}

        public void Add(ValidationStrategyPolicyResult policyResult)
        {
            var existentPolicyResult = PoliciesResult.FirstOrDefault(x => x.ErrorGroup == policyResult.ErrorGroup);
            var existPolicyResult = existentPolicyResult != null;
            
            if (existPolicyResult)
                existentPolicyResult!.AddErrors(policyResult.Errors);
            else
                PoliciesResult.Add(policyResult);
        }

    }
}
