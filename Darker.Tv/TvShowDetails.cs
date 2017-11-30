using System;

namespace Darker.Tv
{
    public class TvShowDetails
    {
        public string Status { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Banner { get; set; }
        public DateTime? FirstAired { get; set; }
        public string[] Aliases { get; set; }
        public string Network { get; set; }
    }
}