using System.Net.Http;
using Darker.Files.Windows;
using Darker.Restful;
using Darker.Serializing.Json;
using Darker.TextFilePersistance;
using Darker.Tv;
using Darker.TvDb;
using Darker.UI.Persistance.shows;

namespace Darker.UI.Persistance
{
    public class ShowAppFactory : AppFactory
    {
        public App Create()
        {
            ShowApp app = new ShowApp(new ShowSearchView(), ctrl: new ShowAppController(CreateShowService(), CreateStorage()));
            return app;
        }

        TextFileStorage CreateStorage()
        {
            return new TextFileStorage(new WindowsFileSystem(), new JsonSerializer(true), "");
        }

        TvShowService CreateShowService()
        {
            return new TvDbApi(

                new HttpRestService(),

                new JsonSerializer(true), APIKEY);
        }
        private string APIKEY = "49F9D3C3C70D1CEB";
    }
}