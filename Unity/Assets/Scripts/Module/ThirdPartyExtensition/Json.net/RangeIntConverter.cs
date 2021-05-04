using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class RangeIntConverter : JsonConverter<RangeInt>
{
    public override void WriteJson(JsonWriter writer, RangeInt value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName(nameof(value.Min));
        writer.WriteValue(value.Min);
        writer.WritePropertyName(nameof(value.Max));
        writer.WriteValue(value.Max);
        writer.WriteEndObject();
    }

    public override RangeInt ReadJson(JsonReader reader, Type objectType, RangeInt existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var range = new RangeInt();
        var array = JArray.Load(reader);
        range.Min = array[0].ToObject<int>();
        range.Max = array[1].ToObject<int>();
        return range;
    }
}
