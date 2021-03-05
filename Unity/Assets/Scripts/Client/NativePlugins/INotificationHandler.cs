using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyInfo
{
    public string Title;
    public string Body;
    public DateTime DeliveryTime;

    public NotifyInfo(string title, string body)
    {
        Title = title;
        Body = body;
    }
}

public interface INotificationHandler
{
    void ScheduleNotification(NotifyInfo info);
}
