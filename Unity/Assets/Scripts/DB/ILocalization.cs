using System;
using RestaurantPreview.Config;

namespace DB
{
    public interface ILocalization
    {
        string Chinese { get; set; }
        string Chinese_tw { get; set; }

        string English { get; set; }
        /*string Spanish { get; set; }
        string German { get; set; }
        string French { get; set; }
        string Indonesian { get; set; }
        string Portugese { get; set; }
        string Thai { get; set; }
        string Italian { get; set; }*/
    }

    public static class LocalizationReader
    {
        public static string ToLoc(this ILocalization localization, Language? language)
        {
            if (!language.HasValue)
            {
                language = Language.CurrentLanguage;
            }

            if (language.Equals(Language.Chinese))
            {
                return localization.Chinese;
            }
            else if (language.Equals(Language.Chinese_tw))
            {
                return localization.Chinese_tw;
            }
            else if (language.Equals(Language.English))
            {
                return localization.English;
            }

            /*else if (language.Equals(Language.Spanish))
                return localization.Spanish;
            else if (language.Equals(Language.German))
                return localization.German;
            else if (language.Equals(Language.French))
                return localization.French;
            else if (language.Equals(Language.Indonesian))
                return localization.Indonesian;
            else if (language.Equals(Language.Portugese))
                return localization.Portugese;
            else if (language.Equals(Language.Thai))
                return localization.Thai;
            else if (language.Equals(Language.Italian))
                return localization.Italian;*/
            return localization.English;
        }
    }

    public static class LocalizationHelper
    {
        public static string GetTimeString(long timeStamp)
        {
            var lastLogin = DateTimeOffset.FromUnixTimeSeconds(timeStamp);
            var now = DateTimeOffset.UtcNow;
            var span = now - lastLogin;
            if (span.TotalHours < 24)
            {
                return string.Format(LocalizationProperty.Read("X hours ago"), span.Hours);
            }
            if (span.TotalDays < 7)
            {
                return string.Format(LocalizationProperty.Read("X days ago"), span.Days);
            }
            else if (span.TotalDays < 30)
            {
                return LocalizationProperty.Read("A week ago");
            }
            else if (span.TotalDays < 180)
            {
                return LocalizationProperty.Read("A month ago");
            }
            else if (span.TotalDays < 365)
            {
                return LocalizationProperty.Read("Half a year ago");
            }
            else
            {
                return LocalizationProperty.Read("A year ago");
            }
        }
    }
}