using System;
using System.Net;

namespace Darker.Restful
{
    public class WebClientService : RestService
    {
        private readonly WebClient _client;
        private string _url;
        public WebClientService()
        {
            _client = new WebClient();
        }
        public void SetBaseUrl(string url)
        {
            _url = url;
        }

        public void AddBearerAuthentication(string token)
        {
            _client.Headers.Add("Authentication", "Bearer "+token);
        }

        public Response Get(string route)
        {
            try
            {
                var url = _url + route;
                var data = _client.DownloadString(url);
                return new RestResponse
                {
                    Succeeded = true,
                    HttpCode = "200",
                    ResponseData = data
                };
            }
            catch (Exception ex)
            {
                return new RestResponse
                {
                    Succeeded = false,
                    Exception = ex
                };
            }
        }

        public Response Post(string route, string data)
        {
            try
            {
                var url = _url + route;
                var result = _client.UploadString(url, data);

                return new RestResponse
                {
                    Succeeded = true,
                    HttpCode = "200",
                    ResponseData = result
                };
            }
            catch (Exception ex)
            {
                return new RestResponse
                {
                    Succeeded = false,
                    Exception = ex
                };
            }
        }
    }
}
