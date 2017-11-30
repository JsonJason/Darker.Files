using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Darker.Restful
{
    public class ClientRestService : RestService
    {
        private readonly HttpClient _client;

        public ClientRestService(HttpClient client)
        {
            _client = client;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string _url;
        public void SetBaseUrl(string url)
        {
            _url = url;
            _client.BaseAddress = new Uri(url);

        }

        public void AddBearerAuthentication(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
        }


        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            var url = _url + path;
            HttpResponseMessage response = await _client.GetAsync(url);
            return response;
        }

        public async Task<HttpResponseMessage> PostAsync(string path,HttpContent content)
        {
            var url = _url + path;
            HttpResponseMessage response = await _client.PostAsync(url, content);
            return response;
        }

        public Response Get(string route)
        {
            try
            {
                var message =  GetAsync(route);
                return ToSuccessResponse("application/json", "200", message.Result.Content.ReadAsStringAsync().ConfigureAwait(false).ToString());
            }
            catch (Exception ex) { return ToFailResponse("application/json", "500", ex); }
        }

        public Response Post(string route, string data)
        {
            try
            {
                HttpContent content = new StringContent(data);
          
                var message = PostAsync(route,content);
                return ToSuccessResponse("application/json", "200", message.Result.Content.ReadAsStringAsync().ConfigureAwait(false).ToString());
            }
            catch (Exception ex) { return ToFailResponse("application/json", "500", ex); }
        }


        Response ToSuccessResponse(string type, string httpcode, string data)
        {
            return new RestResponse
            {
                Succeeded = true,
                ResponseType =type,
                ResponseData = data,
                HttpCode = httpcode
            };
        }

   
        Response ToFailResponse(string type,string httpcode, Exception ex)
        {
            return new RestResponse
            {
                Succeeded = false,
                Exception = ex,
                ResponseType =type,
                HttpCode = httpcode
            };
        }
    }
}