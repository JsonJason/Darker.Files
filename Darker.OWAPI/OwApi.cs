using System.Threading.Tasks;
using Darker.Restful;
using Darker.Serializing;

namespace Darker.OWAPI
{
    public class OwApi
    {
        private readonly RestService _http;
        private readonly TextSerializer _serializer;

        public OwApi(RestService http,TextSerializer serializer)
        {
            _http = http;
            _http.SetBaseUrl("http://owapi.net/api/v3");
            _serializer = serializer;
        }

        public string GetUserBlob(string battletag)
        {
            var route = "/u/" + battletag.Replace('#', '-') + "/blob";
            var response = _http.Get(route);
            if (response.Succeeded)
            {
                return _serializer.DynamicDeserialize(response.ResponseData);
            }
            return string.Empty;
        }

      


    }
}
