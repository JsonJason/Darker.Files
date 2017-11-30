using System;
using Darker.Tv;
using Newtonsoft.Json.Linq;

namespace Darker.TvDb
{
    public class ModelFactory
    {
        public static TvShowSummary ConvertToSummary(dynamic d)
        {

            if (d == null) return null;
            var dynamicdate = d?.data?.firstAired;
            DateTime? date = dynamicdate != null ? DateTime.Parse(dynamicdate) : null; 
            return new TvShowSummary
            {
                Name = (string)d.seriesName,
                Banner = "https://www.thetvdb.com/banners/" + d.banner,
                Description = (string)d.overview,
                FirstAired = date,
                Id = d.id,
                Status = d.status,
                Network = d.network,
                Aliases = ((JArray)d.aliases).ToObject<string[]>()

            };
        }

        public static TvShowDetails ConvertToDetails(dynamic d)
        {
            if (d == null) return null;
            var dynamicdate = d?.data?.firstAired;
            DateTime? date = dynamicdate != null ? DateTime.Parse(dynamicdate) : null;
            return new TvShowDetails
            {
                Name = (string)d.seriesName,
                Banner = "https://www.thetvdb.com/banners/" + d.banner,
                Description = (string)d.overview,
                FirstAired = date,
                Id = d.id,
                Status = d.status,
                Network = d.network,
                Aliases = ((JArray)d.aliases).ToObject<string[]>()
            };
        }
    }
}