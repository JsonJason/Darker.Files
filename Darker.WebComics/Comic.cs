using System.Collections.Generic;
namespace Darker.WebComics
{
    public class Comic
    {
        public string SeriesName { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
       public string Image { get; set; }
        public string Author { get; set; }
    }

    public interface WebComics
    {
        IEnumerable<Comic> Comics { get; }
    }


  


}