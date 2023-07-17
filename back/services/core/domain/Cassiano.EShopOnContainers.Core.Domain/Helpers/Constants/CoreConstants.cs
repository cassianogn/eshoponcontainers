using System.Globalization;

namespace Cassiano.EShopOnContainers.Core.Domain.Helpers.Constants
{
    public static  class CoreConstants
    {
        public const int MIN_LEN = 2;
        public const int MAX_LEN = 150;
        public readonly static DateTime CURRENT_DATE = DateTime.UtcNow;
        public readonly static DateTime MIN_BIRTH_DATE = new DateTime(1900,01,01);
    }
}
