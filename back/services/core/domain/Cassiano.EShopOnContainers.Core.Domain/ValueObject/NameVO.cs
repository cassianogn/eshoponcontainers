using Cassiano.EShopOnContainers.Core.Domain.Helpers.Extensions;

namespace Cassiano.EShopOnContainers.Core.Domain.ValueObject
{
    public class NameVO
    {
        public NameVO(string value)
        {
            DisplayName = FormatName(value);
            Search = value.ToSerachable();
        }

        private string FormatName(string value)
        {
            value = value.RemoveUnnecessarySpace();
            var splitedName = value.Split(' ');

            var finalName = "";
            foreach (var partialName in splitedName)
            {
                var firstCharacter = partialName.Substring(0, 1);
                var remainName = partialName.Substring(1, partialName.Length -1);
                var formatPartialName = firstCharacter.ToUpper() + remainName;
                finalName += $"{formatPartialName} ";
            }

            return finalName.Trim();
        }

        public string DisplayName { get; private set; }
        public string Search { get; private set; }
    }
}
