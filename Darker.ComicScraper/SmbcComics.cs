using System.Collections.Generic;
using System.Linq;
using Darker.WebComics;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace Darker.ComicScraper
{
    public class SmbcComics : ComicProvider
    {
        private readonly string url = "http://smbc-comics.com/";
        private HtmlWeb web;


        public SmbcComics()
        {
            web = new HtmlWeb();
        }


        public SmbcComic GetLatest() => Grab(url);

        public SmbcComic Grab(string url,string name = "")
        {
            return CreateComic(web.Load(url),name);
        }

     


        private HtmlNode GetAfterComicNode(HtmlDocument doc)=>
            doc.DocumentNode.CssSelect("#aftercomic").FirstOrDefault().CssSelect("img").FirstOrDefault();
        


        private HtmlNode GetMainComicNode(HtmlDocument doc)=>
            doc.DocumentNode.CssSelect("#cc-comic").FirstOrDefault();
        

        public SmbcComic GrabByName(string comicname)
        {
            return Grab(url + @"/" + comicname);
        }


        public SmbcComic CreateComic(HtmlDocument doc,string name)
        {
            
            var main = GetMainComicNode(doc);
            var after = GetAfterComicNode(doc);

            var mainimg = main.Attributes["src"].Value;
            var afterimg = after.Attributes["src"].Value;

            return new SmbcComic
            {
                SeriesName = "Smbc Comics",
                Author = "Sam Weinersmith",
                Image = url + mainimg,
                Name = name,
                HiddenComicImage = "http:"+afterimg
            };
        }

        public Comic Get() => GetLatest();
    }

    public class SmbcComic : Comic
    {
        public string HiddenComicImage { get; set; }
    }

    public class XkcdComic : Comic
    {
        public string DescriptionText { get; set; }
    }


    public class ComicCollection
    {
        private List<ComicProvider> _providers;
        private List<ComicProvider> Providers => _providers ?? (_providers = new List<ComicProvider>());

        public void Add(ComicProvider provider)
        {
            Providers.Add(provider);
        }

        public IEnumerable<Comic> GetComics()
        {
            return Providers.Select(x => x.Get());
        }

    }




}