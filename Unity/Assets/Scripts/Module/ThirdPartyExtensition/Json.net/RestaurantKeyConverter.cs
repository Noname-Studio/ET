using System;
using Newtonsoft.Json;

public class RestaurantKeyConverter : JsonConverter<RestaurantKey>
{
    public override void WriteJson(JsonWriter writer, RestaurantKey value, JsonSerializer serializer)
    {
        writer.WriteValue(value.Key);
    }

    public override RestaurantKey ReadJson(JsonReader reader, Type objectType, RestaurantKey existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var s = reader.Value as string;
        return RestaurantKey.Wrap(s);
    }
}