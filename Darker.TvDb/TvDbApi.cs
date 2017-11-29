using System.Collections.Generic;
using Darker.Restful;
using Darker.Tv;
namespace Darker.TvDb
{
    public class TvDbApi : TvShowService
    {
        private readonly RestService _http;
        private readonly RestSerializer _serializer;
        private readonly string _apiKey;

        public TvDbApi(RestService http,RestSerializer serializer,string apiKey)
        {
            _http = http;
            _serializer = serializer;
            _apiKey = apiKey;
            _http.SetBaseUrl("https://api.thetvdb.com");
        }

        public IEnumerable<TvShowSummary> Search(string search)
        {
            if(!IsAuthenticated) Authenticate();

            var response = _http.Get("/search/series?name=" + search);
            if (!response.Succeeded) yield break;

            var responseObject = _serializer.DeSerialize(response);

            foreach (var show in responseObject.data)
            {
                yield return ModelFactory.ConvertToSummary(show);
            }
        }

        public TvShowDetails GetDetails(string id)
        {
            if (!IsAuthenticated) Authenticate();

            var response = _http.Get("/series/" + id);

            if (!response.Succeeded) return null;

            var responseObject = _serializer.DeSerialize(response);
            return ModelFactory.ConvertToDetails(responseObject.data);
        }


        void Authenticate()
        {
            string datastring = _serializer.Serialize(new {apikey = _apiKey});
            var response = _http.Post("/login", datastring);
            if (response.Succeeded)
            {
                var responseObject = _serializer.DeSerialize(response);
                _http.AddBearerAuthentication((string)responseObject.token);
                IsAuthenticated = true;
            }

        }

        private bool IsAuthenticated { get; set; }
    }
}
