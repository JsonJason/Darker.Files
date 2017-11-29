using System;
using Newtonsoft.Json;

namespace Darker.Serializing.Json
{
    public class JsonSerializer : TextSerializer
    {
        private readonly Formatting _formatting;
        private readonly JsonSerializerSettings _settings;

        public JsonSerializer(bool readableFormatting =false) : this(new JsonSerializerSettings(),readableFormatting)
        {
        }

        public JsonSerializer(JsonSerializerSettings settings, bool readableFormatting = false)
        {
            _settings = settings;
            _formatting = readableFormatting ? Formatting.Indented : Formatting.None;
        }

        public T Deserialize<T>(string text) => JsonConvert.DeserializeObject<T>(text, _settings);

        public string Serialize<T>(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            return JsonConvert.SerializeObject(item, _formatting);
        }
    }
}