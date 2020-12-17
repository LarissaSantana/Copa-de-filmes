using System.Collections.Generic;

namespace CopaDeFilmes.Domain.Core.Notifications
{
    public interface INotificationContext<T> where T : Notification
    {
        void AddNotification(string key, string message);
        void AddNotification(Notification notification);
        void AddNotification(string message);
        List<Notification> GetNotifications();
        bool HasNotifications();
    }
}
