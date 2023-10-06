using DTI.Core.Domain.Interfaces.Entities;
using DTI.Core.Domain.ValueObject;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DTI.Core.Infrastructure.Out.DbAccess.FluentApi.ValueObjects
{
    public class SearchableStringVOFA
    {
        public static Action<OwnedNavigationBuilder<TEntity, SearchableStringVO>> Map<TEntity>(bool requied, int maxLength) where TEntity : class
        {
            return searchableStringBuilder =>
            {
                if (requied)
                {
                    searchableStringBuilder.Property(stringPesquisavel => stringPesquisavel.Value).IsRequired();
                    searchableStringBuilder.Property(stringPesquisavel => stringPesquisavel.SearchableValue).IsRequired();
                }
                searchableStringBuilder.Property(stringPesquisavel => stringPesquisavel.Value).HasMaxLength(maxLength);
                searchableStringBuilder.Property(stringPesquisavel => stringPesquisavel.SearchableValue).HasMaxLength(maxLength);
            };
        }
    }
}
