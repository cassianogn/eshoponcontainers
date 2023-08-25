namespace DTI.Core.Domain.Services.Validations
{
    public class ValidationStrategyPolicyResult
    {
        private ValidationStrategyPolicyResult(string errorGroup, IEnumerable<string> errors)
        {
            ErrorGroup = errorGroup;
            Errors = errors.ToList();
        }

        public string ErrorGroup { get; private set; }
        public bool IsValid { get => !Errors.Any(); }
        public List<string> Errors { get; private set; }
        
        public void AddError(string error) => Errors.Add(error);
        public void AddErrors(IEnumerable<string> errors) => Errors.AddRange(errors);

        public static ValidationStrategyPolicyResult Valid() => new(string.Empty, new List<string>());
        public static ValidationStrategyPolicyResult Invalid(string errorGroup, IList<string> errors) => new(errorGroup, errors);
        public static ValidationStrategyPolicyResult Invalid(string errorGroup, string error) => new(errorGroup, new List<string>(1) { error});
    }
}
