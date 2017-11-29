using System;
using Darker.Tv;

namespace Darker.TvDb
{
    public class ModelFactory
    {
        public static TvShowSummary ConvertToSummary(dynamic obj)
        {

            if (obj == null) return null;
            var dynamicdate = obj?.data?.firstAired;
            DateTime? date = dynamicdate != null ? DateTime.Parse(dynamicdate) : null; 
            return new TvShowSummary
            {
                Name = (string)obj.seriesName,
                Banner = "https://www.thetvdb.com/banners/" + obj.banner,
                Description = (string)obj.overview,
                FirstAired = date
            };
        }

        public static TvShowDetails ConvertToDetails(dynamic d)
        {
            if (d == null) return null;
            var dynamicdate = d?.data?.firstAired;
            DateTime? date = dynamicdate != null ? DateTime.Parse(dynamicdate) : null;
            return new TvShowDetails
            {
                Name = (string)d.data.seriesName,
                Banner = "https://www.thetvdb.com/banners/" + d.data.banner,
                Description = (string)d.data.overview,
                FirstAired = date
            };
        }
    }
}