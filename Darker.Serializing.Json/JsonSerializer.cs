using System;
using Newtonsoft.Json;

namespace Darker.Serializing.Json
{
    public class JsonSerializer : TextSerializer
    {
        private readonly Formatting _formatting;
        private readonly JsonSerializerSettings _settings;

        public JsonSerializer() : this(new JsonSerializerSettings(), Formatting.None)
        {
        }

        public JsonSerializer(JsonSerializerSettings settings, Formatting formatting)
        {
            _settings = settings;
            _formatting = formatting;
        }

        public T Deserialize<T>(string text) => JsonConvert.DeserializeObject<T>(text, _settings);

        public string Serialize<T>(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            return JsonConvert.SerializeObject(item, _formatting);
        }
    }
}