using Darker.Restful;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Darker.TvDb
{
    public class JsonNetRestSerializer : RestSerializer
    {
        public dynamic DeSerialize(Response resp)
        {
            return JObject.Parse(resp.ResponseData);
        }

        public string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}