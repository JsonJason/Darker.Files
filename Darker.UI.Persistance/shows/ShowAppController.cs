using System;
using Darker.Tv;

namespace Darker.UI.Persistance.shows
{
    public class ShowAppController
    {
        private readonly TvShowService _showService;

        public ShowAppController(TvShowService showService)
        {
            _showService = showService;
        }

        public ShowSearchView View { get; set; }

        public void LoadShows()
        {
            try
            {
                View.Shows = _showService.Search(View.SearchTerm);
            }
            catch (Exception ex)
            {
                View.Error(ex);
            }
        }
    }
}