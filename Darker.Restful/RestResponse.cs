using System;

namespace Darker.Restful
{
    public class RestResponse : Response
    {
        public string ResponseType { get; set; }
        public string ResponseData { get; set; }
        public string HttpCode { get; set; }
        public bool Succeeded { get; set; }
        public Exception Exception { get; set; }
    }

    public interface Response
    {
        string ResponseType { get; }
        string ResponseData { get; }
        string HttpCode { get; }
        bool Succeeded { get; }
        Exception Exception { get; }
    }
}