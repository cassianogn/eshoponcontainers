namespace DTI.Core.Domain.Services.Validations.Helpers
{
    public class ValidationErrorMessageService
    {
        public const string CollectionSeparator = "|||";
        public string Prefix { get; private set; }
        public bool UseCollectionIndex { get; private set; }

        public ValidationErrorMessageService()
        {
            Prefix = string.Empty;
            UseCollectionIndex = false;
        }
        public ValidationErrorMessageService SetPrefix(string prefix, bool useCollectionIndex = true)
        {
            Prefix = prefix;
            UseCollectionIndex = useCollectionIndex;
            return this;
        }
        public string DomainRuleErrorGroup() => "The basic validation rule failed";
        public string Required(string propertyName) => $"{GetPrefix()}{propertyName} is required";
        public string MinLength(string propertyName, int length) => $"{GetPrefix()}{propertyName} must be at least {length} characters long";
        public string MaxLength(string propertyName, int length) => $"{GetPrefix()}{propertyName} must be at most {length} characters long";
        public string MustBeNull(string propertyName) => $"{GetPrefix()}{propertyName} should be null";
        public string NumberMinInt(string propertyName, int min) => $"{GetPrefix()}{propertyName} must be at least {min}";
        public string NumberMaxInt(string propertyName, int max) => $"{GetPrefix()}{propertyName} must be at most {max}";
        public string NumberMinDouble(string propertyName, double min) => $"{GetPrefix()}{propertyName} must be at least {min}";
        public string NumberMaxDouble(string propertyName, double max) => $"{GetPrefix()}{propertyName} must be at most {max}";
        public string DateGreaterThan(string propertyName, DateTime date) => $"{GetPrefix()}{propertyName} must be greater than {date:dd/MM/yyyy HH:mm}";
        public string DataLessThen(string propertyName, DateTime date) => $"{GetPrefix()}{propertyName} must be less than {date:dd/MM/yyyy HH:mm}";
        public string Email(string propertyName) => $"{GetPrefix()}{propertyName} is not a valid email address";
        public string DontRepeatItemOnList(string propertyName) => $"{GetPrefix()}{propertyName} item is already on the list";

        private string GetPrefix()
        {
            if (Prefix == string.Empty) return "";

            var finalPrefix = $"{Prefix}";
            if (UseCollectionIndex)
                finalPrefix += CollectionSeparator + "{CollectionIndex}" + CollectionSeparator;
            finalPrefix += "- ";
            return finalPrefix;
        }

        public static string FormatingErrorResult(string message)
        {
            if (!message.Contains(CollectionSeparator)) return message;

            var splitedMessage = message.Split(CollectionSeparator);
            
            if (!int.TryParse(splitedMessage[1], out int messageIndex)) return message;
            
            messageIndex++;
            
            return $"{splitedMessage[0]} {messageIndex} {splitedMessage[2]}";
        }
    }
}
