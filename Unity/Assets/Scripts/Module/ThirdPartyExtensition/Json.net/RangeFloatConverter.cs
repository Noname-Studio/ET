using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class RangeFloatConverter : JsonConverter<RangeFloat>
{
    public override void WriteJson(JsonWriter writer, RangeFloat value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName(nameof(value.Min));
        writer.WriteValue(value.Min);
        writer.WritePropertyName(nameof(value.Max));
        writer.WriteValue(value.Max);
        writer.WriteEndObject();
    }

    public override RangeFloat ReadJson(JsonReader reader, Type objectType, RangeFloat existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var range = new RangeFloat();
        var array = JArray.Load(reader);
        range.Min = array[0].ToObject<float>();
        range.Max = array[1].ToObject<float>();
        return range;
    }
}
