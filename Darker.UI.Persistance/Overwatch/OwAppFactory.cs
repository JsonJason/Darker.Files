using Darker.OWAPI;
using Darker.Restful;
using Darker.Serializing.Json;
namespace Darker.UI.Persistance.Overwatch
{
    public class OwAppFactory : AppFactory
    {
        public App Create()
        {
            return new OWApp(new OWView(), new OwController(CreateOverwatchApi(),CreateOWApi()));
        }

        OwApi CreateOWApi()
        {
            return new OwApi(new WebClientService(), new JsonSerializer(true));
        }

        OverwatchApi.OverwatchApi CreateOverwatchApi()
        {
            return new OverwatchApi.OverwatchApi(
                //   new HttpRestService(), 
                new WebClientService(),
                new JsonSerializer(true));
        }

    }
}
