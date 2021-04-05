using NotificationSamples;

namespace Panthea.NativePlugins.Notify
{
    public class NativeNotify: INotificationHandler
    {
        private GameNotificationsManager mNotifications;

        public NativeNotify(GameNotificationsManager notifications)
        {
            mNotifications = notifications;
        }

        public void ScheduleNotification(NotifyInfo info)
        {
            IGameNotification notification = mNotifications.CreateNotification();
            notification.Body = info.Body;
            notification.Title = info.Title;
            notification.DeliveryTime = info.DeliveryTime;
            var msg = mNotifications.ScheduleNotification(notification);
            msg.Reschedule = true;
        }
    }
}