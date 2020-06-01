using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Mediator.Notifications
{
    public class NotificationHandler
    {
        private List<string> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<string>();
        }

        public void PublishNotification(string notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }

        public List<string> GetNotifications()
        {
            return _notifications;
        }

        public void ClearNotifications()
        {
            _notifications.Clear();
        }
    }
}
