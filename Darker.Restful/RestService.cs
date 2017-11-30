using System.Web;

namespace Darker.Restful
{
    public interface RestService
    {
        void SetBaseUrl(string url);
        void AddBearerAuthentication(string token);
        Response Get(string route);
        Response Post(string route, string data);

    }
}
