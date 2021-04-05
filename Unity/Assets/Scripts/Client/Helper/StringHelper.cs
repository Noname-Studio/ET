using RestaurantPreview.Config;

namespace Client.Helper
{
    public static class StringHelper
    {
        public static string CheckNameIsVaild(this string name, int maxLength)
        {
            if (string.IsNullOrEmpty(name))
            {
                return LocalizationProperty.Read("PleaseInputSomething");
            }

            if (name.Length > 16)
            {
                return string.Format(LocalizationProperty.Read("InputNameMoreThanNum"), maxLength);
            }

            return "";
        }
    }
}