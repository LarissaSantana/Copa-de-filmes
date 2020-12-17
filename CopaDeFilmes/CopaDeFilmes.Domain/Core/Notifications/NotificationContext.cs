using System.Collections.Generic;
using System.Linq;

namespace CopaDeFilmes.Domain.Core.Notifications
{
    public class NotificationContext : INotificationContext<Notification>
    {
        private List<Notification> _notifications;

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }
        
        public bool HasNotifications()
        {
            return _notifications.Any();               
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

        public void AddNotification(string message)
        {
            _notifications.Add(new Notification(null, message));
        }

        public void Dispose()
        {
            _notifications = new List<Notification>();
        }
    }
}
