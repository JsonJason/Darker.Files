using System.Collections.Generic;
using Darker.Restful;
using Darker.Serializing;

namespace Darker.OverwatchApi
{
    public class OverwatchApi
    {
        private readonly RestService _http;
        private readonly TextSerializer _serializer;

        public OverwatchApi(RestService http, TextSerializer serializer)
        {
            _http = http;
            _http.SetBaseUrl("https://overwatch-api.net/api/v1");
            _serializer = serializer;
        }

   

        public IEnumerable<HeroSummary> GetHeroes()
        {
            var response = _http.Get("/hero");
            if (response.Succeeded)
            {
                var dynamicResponse = _serializer.DynamicDeserialize(response.ResponseData);
                foreach (var item in dynamicResponse.data)
                {
                    yield return ModelFactory.CreateHeroSummary(item);
                }


            }
        }

    }
}
