using System.Linq;
using System.Net;
using Darker.WebComics;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace Darker.ComicScraper
{
    public class XkcdComics : ComicProvider
    {
        private string baseUrl = "http://www.xkcd.com/";//comic
        private HtmlWeb web;
        public XkcdComics()
        {
            web = new HtmlWeb();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public Comic Get() => Grab(baseUrl);


        public XkcdComic Grab(string url)
        {
            return CreateComic(web.Load(url),url);
        }

        public XkcdComic CreateComic(HtmlDocument doc,string url)
        {
            var main = GetMainComicNode(doc);
            var name = main.CssSelect("#ctitle").FirstOrDefault().InnerText;
            var cm = main.CssSelect("#comic > img").FirstOrDefault();
            var mainimg = cm.Attributes["src"].Value;
            var description = cm.Attributes["title"].Value;
            return new XkcdComic
            {
                Author = "Randall Munroe",
                DescriptionText = description,
                Image = "http:"+mainimg,
                Name = name,
                SeriesName = "XKCD",
                Url = url
            };
        }

        private HtmlNode GetMainComicNode(HtmlDocument doc) =>
            doc.DocumentNode.CssSelect("#middleContainer").FirstOrDefault();

    }
}