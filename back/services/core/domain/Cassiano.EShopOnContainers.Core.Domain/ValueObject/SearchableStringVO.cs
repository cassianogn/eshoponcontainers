using Cassiano.EShopOnContainers.Core.Domain.Helpers.Extensions;

namespace Cassiano.EShopOnContainers.Core.Domain.ValueObject
{
    public class SearchableStringVO
    {
        public SearchableStringVO(string value)
        {
            Value = FormatSearchableValue(value);
            SearchableValue = value.ToSerachable();
        }

        private string FormatSearchableValue(string value)
        {
            value = value.RemoveUnnecessarySpace();
            var splitedValue = value.Split(' ');

            var finalValue = "";
            foreach (var partialName in splitedValue)
            {
                var firstCharacter = partialName.Substring(0, 1);
                var remainValue = partialName.Substring(1, partialName.Length -1);
                var formatPartialValue = firstCharacter.ToUpper() + remainValue;
                finalValue += $"{formatPartialValue} ";
            }

            return finalValue.Trim();
        }

        public string Value { get; private set; }
        public string SearchableValue { get; private set; }
    }
}
