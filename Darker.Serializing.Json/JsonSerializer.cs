using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Darker.Serializing.Json
{
    public class JsonSerializer : TextSerializer
    {
        private readonly Formatting _formatting;
        private readonly JsonSerializerSettings _settings;

        public JsonSerializer(bool readableFormatting = false)
        {
            _formatting = readableFormatting ? Formatting.Indented : Formatting.None;
            _settings = new JsonSerializerSettings();
        }

        public T Deserialize<T>(string text) => JsonConvert.DeserializeObject<T>(text, _settings);

        public string Serialize<T>(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            return JsonConvert.SerializeObject(item, _formatting);
        }

        public dynamic DynamicDeserialize(string text)
        {
            return JObject.Parse(text);
        }
    }
}