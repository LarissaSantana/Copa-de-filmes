using System.Collections.Generic;
using System.Linq;

namespace CopaDeFilmes.Domain.Core.Notifications
{
    public class NotificationContext : INotificationContext
    {
        private List<Notification> _notifications;
        public bool HasNotifications => _notifications.Any();

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(string key, string message)
        {
            _notifications.Add(new Notification(key, message));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Dispose()
        {
            _notifications = new List<Notification>();
        }
    }
}
