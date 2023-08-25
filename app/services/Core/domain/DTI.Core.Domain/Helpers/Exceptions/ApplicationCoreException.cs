using System.Runtime.Serialization;

namespace DTI.Core.Domain.Helpers.Exceptions
{
    public class ApplicationCoreException : Exception
    {
        public ApplicationCoreException(string? message) : base(message)
        {
        }

        public ApplicationCoreException(string? message, Exception? innerException) : base(message, innerException)
        {
        }


    }
}
