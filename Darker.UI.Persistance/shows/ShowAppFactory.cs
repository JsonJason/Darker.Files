using Darker.Restful;
using Darker.Tv;
using Darker.TvDb;
using Darker.UI.Persistance.shows;

namespace Darker.UI.Persistance
{
    public class ShowAppFactory
    {
        public ShowApp Create()
        {
            ShowApp app = new ShowApp(new ShowSearchView(), ctrl: new ShowAppController(CreateShowService()));
            return app;
        }

        TvShowService CreateShowService()
        {
            return new TvDbApi(new HttpRestService(),new JsonNetRestSerializer(), APIKEY);
        }
        private string APIKEY = "49F9D3C3C70D1CEB";
    }
}