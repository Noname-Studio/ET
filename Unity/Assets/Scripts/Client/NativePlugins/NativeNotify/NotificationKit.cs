public class NotificationKit
{
    public static INotificationHandler Inst { get; private set; }

    public static void Initialize(INotificationHandler handler)
    {
        Inst = handler;
    }
}
