namespace DTI.Core.Domain.Helpers.Extensions
{
    public static class ListExtensions
    {
        public static IEnumerable<T> NotNullList<T>(this IEnumerable<T> list)
        {
            if (list == null)
                return Enumerable.Empty<T>();
            return list;
        }
    }
}
