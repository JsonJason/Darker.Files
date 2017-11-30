using Darker.ComicScraper;
using Darker.UI.Persistance.Comicz;

namespace Darker.UI.Persistance
{
    internal class ComicsAppFactory : AppFactory
    {
        public App Create()
        {
            return new ComicApp(new ComicView(), new ComicController(CreateComicCollection()));
        }

        ComicCollection CreateComicCollection()
        {
            var comics = new ComicCollection();
            comics.Add(new DilbertComics());
            comics.Add(new SmbcComics());
            comics.Add(new XkcdComics());
            return comics;
        }

    }
}