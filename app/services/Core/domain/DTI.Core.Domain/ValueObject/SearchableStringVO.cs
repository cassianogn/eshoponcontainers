using DTI.Core.Domain.Helpers.Extensions;

namespace DTI.Core.Domain.ValueObject
{
    public class SearchableStringVO
    {
        public SearchableStringVO(string value)
        {
            Value = value;
            SearchableValue = value.ToSerachable();
        }

        
        public string Value { get; private set; }
        public string SearchableValue { get; private set; }
    }
}
