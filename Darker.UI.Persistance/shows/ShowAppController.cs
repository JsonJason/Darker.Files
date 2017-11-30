using System.Diagnostics;
using System.Linq;
using Darker.TextFilePersistance;
using Darker.Tv;

namespace Darker.UI.Persistance.shows
{
    public class ShowAppController : BaseController
    {
        private readonly TvShowService _showService;
        private readonly TextFileStorage _fileStorage;

        public ShowAppController(TvShowService showService,TextFileStorage fileStorage)
        {
            _showService = showService;
            _fileStorage = fileStorage;
        }

        public new ShowSearchView View => base.View as ShowSearchView;

        public void LoadShows() => Try(() =>
        {
            View.Shows = _showService.Search(View.SearchTerm);
        });

        public void SaveToFile() => Try(() =>
        {
            _fileStorage.FilePath = View.FilePath;
            _fileStorage.Save(View.Shows.ToList());
            View.StatusUpdate("Saved!");
            Process.Start(_fileStorage.FilePath);
        });

        public void SetView(ShowSearchView view)
        {
            base.View = view;
        }
    }
}