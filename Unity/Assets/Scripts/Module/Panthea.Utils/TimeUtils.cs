﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;

public static class TimeUtils
{
    private static DateTime _utcDateTime;
    private static long _utcTimeStamp;
    private static long _baseSystemUpTime;
    private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    static TimeUtils()
    {
        if (_utcTimeStamp == 0)
        {
            _utcDateTime = DateTime.UtcNow;
            _utcTimeStamp = (long) _utcDateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        _baseSystemUpTime = (long) Time.realtimeSinceStartup;
    }

    public static async void FetchUtcTime()
    {
        var request = (HttpWebRequest) WebRequest.Create("http://www.microsoft.com");
        var response = await Task.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null);
        string todaysDates = response.Headers["date"];
        _utcDateTime = DateTime.ParseExact(todaysDates,
            "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
            CultureInfo.InvariantCulture.DateTimeFormat,
            DateTimeStyles.AssumeUniversal);
        _utcDateTime = _utcDateTime.ToUniversalTime();
        _utcTimeStamp = ConvertDateTimeToStamp(_utcDateTime);
        response.Dispose();
        Log.Print("当前UTC时间为:" + _utcDateTime);
    }

    /// <summary>
    /// 返回当前UTC时间(全球)
    /// </summary>
    /// <returns></returns>
    public static long GetUtcTimeStamp()
    {
        return _utcTimeStamp + (long) Time.realtimeSinceStartup - _baseSystemUpTime;
    }

    /// <summary>
    /// 将DateTime转换为UTC时间(全球)
    /// </summary>
    /// <returns></returns>
    public static long GetUtcTimeStamp(DateTime dt)
    {
        return ConvertDateTimeToStamp(dt) + (long) Time.realtimeSinceStartup - _baseSystemUpTime;
    }

    /// <summary>
    /// 返回当前UTC时间(全球)
    /// </summary>
    /// <returns></returns>
    public static DateTime GetUtcDateTime()
    {
        return DateTimeOffset.FromUnixTimeSeconds(GetUtcTimeStamp()).DateTime;
    }

    /// <summary>
    /// 返回当前UTC时间(全球)
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DateTime GetUtcDateTime(DateTime dt)
    {
        return DateTimeOffset.FromUnixTimeSeconds(GetUtcTimeStamp(dt)).DateTime;
    }

    /// <summary>
    /// 返回当前UTC时间(本地)
    /// </summary>
    /// <returns></returns>
    public static long GetLocalTimeStamp()
    {
        long utcTime = GetUtcTimeStamp();
        return ConvertDateTimeToStamp(DateTimeOffset.FromUnixTimeSeconds(utcTime).LocalDateTime);
    }

    /// <summary>
    /// 返回当前UTC时间(本地)
    /// </summary>
    /// <returns></returns>
    public static DateTime GetLocalDateTime()
    {
        long utcTime = GetUtcTimeStamp();
        return DateTimeOffset.FromUnixTimeSeconds(utcTime).LocalDateTime;
    }

    /// <summary>
    /// 将DateTime转换为UTC时间
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static long ConvertDateTimeToStamp(DateTime time)
    {
        TimeSpan elapsedTime = time - Epoch;
        return (long) elapsedTime.TotalSeconds;
    }

    /// <summary>
    /// 设置DateTime为一天的开始时间 0小时 0 分 0 秒
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DateTime TodayAtZero(this DateTime dt)
    {
        return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
    }

    /// <summary>
    /// 获取两个UTC时间之间的差值
    /// </summary>
    /// <param name="fromUtcTime"></param>
    /// <param name="toUtcTime"></param>
    /// <returns></returns>
    public static TimeSpan BetweenTime(long fromUtcTime, long toUtcTime)
    {
        return DateTimeOffset.FromUnixTimeSeconds(toUtcTime) - DateTimeOffset.FromUnixTimeSeconds(fromUtcTime);
    }

    /// <summary>
    /// 给定一个数字和一个转换格式如mm:ss
    /// 比如 ConvertNumberToTimeString(90,@"mm\:ss");
    /// 则返回结果 01:30
    /// </summary>
    /// <param name="seconds"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public static string ConvertNumberToTimeString(double seconds, string format)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);
        string text = time.ToString(format);
        return text;
    }
}