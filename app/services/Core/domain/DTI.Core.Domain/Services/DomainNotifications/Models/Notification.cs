namespace DTI.Core.Domain.Services.DomainNotifications.Models
{
    public class Notification
    {
        public Notification(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; private set; }
        public string Message { get; private set; }
    }
}
