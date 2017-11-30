using System;
using System.Collections.Generic;
using System.Linq;
using Darker.ComicScraper;
using Darker.WebComics;
using NUnit.Framework;

namespace Darker.Scrapy.Tests
{
    [TestFixture]
    public class ScraperTests
    {

        [Test]
        public void TestScraping()
        {
           SmbcComics smbc = new SmbcComics();

            var comic = smbc.GetLatest();
            var i = 0;
        }
        [Test]
        public void GrabByName()
        {
            DilbertComics dilb = new DilbertComics();

            //var com = dilb.GetLatest();
            var date = new DateTime(2016,11,29);
            var com = dilb.GetByDate(date);
            int i = 0;
        }


        [Test]
        public void GetAll()
        {
            _comicFactory = new List<ComicProvider>
            {
                new DilbertComics(),
                new SmbcComics(),
                new XkcdComics()
            };


            var comics = _comicFactory.Select(x => x.Get()).ToList();


            int i = 0;

        }

        private IEnumerable<ComicProvider> _comicFactory;




















        [Test]
        public void ComicCollectionTests()
        {
            var comics = new ComicCollection();
            comics.Add(new DilbertComics());
            comics.Add(new SmbcComics());
            comics.Add(new XkcdComics());

            List<Comic> latest = comics.GetComics().ToList();

        }


    }






}
