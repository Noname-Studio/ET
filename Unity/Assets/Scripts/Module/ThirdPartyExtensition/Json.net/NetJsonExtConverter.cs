using Newtonsoft.Json;

public class NetJsonExtConverter
{
    public static void RegisterAll()
    {
        var settings = JsonConvert.DefaultSettings();
        settings.Converters.Add(new RangeIntConverter());
        settings.Converters.Add(new RangeFloatConverter());
        settings.Converters.Add(new RestaurantKeyConverter());
    }
}
