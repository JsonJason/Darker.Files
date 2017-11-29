using System.Collections.Generic;
namespace Darker.Tv
{
    public interface TvShowService
    {
        IEnumerable<TvShowSummary> Search(string search);

        TvShowDetails GetDetails(string id);
    }
}
