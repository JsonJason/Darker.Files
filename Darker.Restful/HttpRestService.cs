using System;
using System.IO;
using System.Net;

namespace Darker.Restful
{
    public class HttpRestService : RestService
    {
        private string baseUrl;
        public void SetBaseUrl(string url)
        {
            baseUrl = url;
        }

        private string bearerString = "";
        public void AddBearerAuthentication(string token)
        {
            bearerString = "Bearer " + token;
        }

        public Response Get(string route)
        {
            HttpWebResponse resp = null;
            try
            {
                var url = baseUrl + route;
                var req = CreateGetWebRequest(url);
                resp = GetResponse(req);
                return ToSuccessResponse(resp);
            }
            catch (Exception ex)
            {
                return ToFailResponse(resp, ex);
            }
        }

        public Response Post(string route, string data)
        {
            HttpWebResponse resp = null;
            try
            {
                var req = CreatePostWebRequest(baseUrl + route, data);
                resp = GetResponse(req);
                return ToSuccessResponse(resp);
            }
            catch (Exception ex)
            {
                return ToFailResponse(resp, ex);
            }
        }

        HttpWebRequest CreatePostWebRequest(string url, string data)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            if(TokenAquired)
                request.Headers.Add("Authorization", bearerString);
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(data);
            requestWriter.Close();
            return request;
        }

        HttpWebRequest CreateGetWebRequest(string url)
        {
        
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            if(TokenAquired)
                request.Headers.Add("Authorization",bearerString);
            return request;
        }



        private bool TokenAquired => !String.IsNullOrWhiteSpace(bearerString);
        HttpWebResponse GetResponse(HttpWebRequest req)
        {
            return req.GetResponse() as HttpWebResponse;
        }

        string ReadResponse(WebResponse webResponse)
        {
            Stream webStream = webResponse.GetResponseStream();
            if (webStream != null)
            {
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                responseReader.Close();
                return response;
            }
            return String.Empty;
        }

        Response ToSuccessResponse(HttpWebResponse webresponse)
        {
            return new RestResponse
            {
                Succeeded = true,
                ResponseType = webresponse?.ContentType,
                ResponseData = ReadResponse(webresponse),
                HttpCode = webresponse?.StatusCode.ToString()
            };
        }

        Response ToFailResponse(HttpWebResponse webresponse,Exception ex)
        {
            return new RestResponse
            {
                Succeeded = false,
                Exception = ex,
                ResponseType = webresponse?.ContentType,
                HttpCode = webresponse?.StatusCode.ToString()
            };
        }


    }
}