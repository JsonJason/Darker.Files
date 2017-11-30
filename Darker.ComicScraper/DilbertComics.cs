using System;
using System.Linq;
using Darker.WebComics;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace Darker.ComicScraper
{
    public class DilbertComics : ComicProvider
    {
        private readonly string baseUrl = "http://dilbert.com/";
        //img-comic-container

        private readonly HtmlWeb web;
        public DilbertComics()
        {
            web = new HtmlWeb();
        }
        public Comic GetLatest()=> Get(baseUrl);

        public Comic GetByDate(DateTime date)
        {
            string dateString = $"{date.Year}-{date.Month}-{date.Day}";
            return Get(baseUrl + "/strip/" + dateString);
        }

        Comic Get(string url)
        {
            var doc = web.Load(url);
            var node = GetMainComicNode(doc);

            return CreateComic(node,url);
        }

        Comic CreateComic(HtmlNode node,string url)
        {
            var name = node.Attributes["alt"].Value.Split('-')[0].Trim();
            var imgurl = node.Attributes["src"].Value;
            return new Comic
            {
                Name = name,
                SeriesName = "Dilbert",
                Author = "Scott Adams",
                Image = imgurl,
                Url = url
            };
        }


        private HtmlNode GetMainComicNode(HtmlDocument doc) =>
            doc.DocumentNode.CssSelect(".img-comic").FirstOrDefault();


        public Comic Get() => GetLatest();
    }
}