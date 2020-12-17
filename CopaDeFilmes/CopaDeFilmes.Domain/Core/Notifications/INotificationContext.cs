using System.Collections.Generic;

namespace CopaDeFilmes.Domain.Core.Notifications
{
    public interface INotificationContext
    {
        void AddNotification(string key, string message);
        void AddNotification(Notification notification);
        List<Notification> GetNotifications();
    }
}
