using MediatR;

namespace Cassiano.EShopOnContainers.Core.Domain.Helpers.Exceptions
{
    public class TemplateMathodException : Exception
    {
        private TemplateMathodException( string message, Exception innerException) : base(message, innerException)
        {
        }

        public static TemplateMathodException Create(Type referenceEnityClass, Type referenceHandlerClass, Guid? entityId, string templateMethodName, Exception innerException)
        {
            var entityIdValue = entityId.HasValue ? entityId.ToString() : "null";
            var message = $"Entity {referenceEnityClass.Name} with id {entityIdValue} on {referenceHandlerClass.Name}. Not is possible make template method: {templateMethodName}.";
            return new TemplateMathodException(message, innerException);
        }

        
    }
}
