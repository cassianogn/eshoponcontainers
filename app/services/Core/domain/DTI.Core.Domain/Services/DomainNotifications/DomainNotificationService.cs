using DTI.Core.Domain.Services.DomainNotifications.Models;

namespace DTI.Core.Domain.Services.DomainNotifications
{
    public class DomainNotificationService
    {   
        private readonly IList<Notification> _notifications = new List<Notification>();

        public void Add(string code, string message)
        {
            _notifications.Add(new Notification(code, message));
        }

        public IReadOnlyCollection<Notification> GetAll() => _notifications.ToList();

        public bool HasNotification() => _notifications.Any();
    }
}
