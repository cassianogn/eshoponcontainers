namespace Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers
{
    public static class ValidationErrorMessage
    {
        public static string Required(string field) => $"{field} is required";
        public static string DomainRuleErrorGroup() => "The basic validation rule failed";
        public static string MinLength(string propertyName, int length) => $"{propertyName} must be at least {length} characters long";
        public static string MaxLength(string propertyName, int length) => $"{propertyName} must be at most {length} characters long";
    }
}
