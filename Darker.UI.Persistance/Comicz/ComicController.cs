using System.Linq;
using Darker.ComicScraper;

namespace Darker.UI.Persistance.Comicz
{
    public class ComicController : BaseController
    {
        private readonly ComicCollection _comics;

        public ComicController(ComicCollection comics)
        {
            _comics = comics;
        }

        public override void Initialize()
        {
            (View as ComicView).Comics = _comics.GetComics().ToList();
        }
    }
}
