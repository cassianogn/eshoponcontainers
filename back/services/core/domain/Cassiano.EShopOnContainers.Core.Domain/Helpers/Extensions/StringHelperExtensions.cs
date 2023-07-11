using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Cassiano.EShopOnContainers.Core.Domain.Helpers.Extensions
{
    public static class StringHelperExtensions
    {
        public static string ToSerachable(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            var formatValue = value.ToLower().RemoveAccent().Trim().RemoveUnnecessarySpace();

            return formatValue;
        }

        public static string RemoveUnnecessarySpace(this string value)
        {
            var formatValue = value.Replace("  ", " ");
            return formatValue;
        }
        public static string RemoveAccent(this string value)
        {
            var normalizedString = value.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);

        }
    }
}
