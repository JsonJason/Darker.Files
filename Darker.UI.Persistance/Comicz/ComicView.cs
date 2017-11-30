using System.Collections.Generic;
using System.Windows.Forms;
using Darker.ComicScraper;
using Darker.Tv;
using Darker.WebComics;

namespace Darker.UI.Persistance.Comicz
{
    public partial class ComicView : BaseView
    {
        private ComicController _ctrl;
        private List<Comic> _comics;

        public ComicView()
        {
            InitializeComponent();
        }

        public ComicController Ctrl
        {
            get => _ctrl;
            set
            {
                _ctrl = value; 
                _ctrl.Initialize();
            }
        }

        public List<Comic> Comics
        {
            get { return _comics; }
            set
            {
                _comics = value;
                OnComicsLoaded();
            }
        }

        private void OnComicsLoaded()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var summary in Comics)
            {
                if (summary != null)
                {
                    flowLayoutPanel1.Controls.Add(CreateComic(summary.Image));

                    SmbcComic smbc = summary as SmbcComic;
                    if (smbc != null)
                    {
                        flowLayoutPanel1.Controls.Add(CreateComic(smbc.HiddenComicImage));

                    }

                }

            }

        }


        private Control CreateComic(string path)
        {
            

            var image = new PictureBox();
            image.SizeMode = PictureBoxSizeMode.Zoom;
            image.Width = 1000;
            image.Height = 1000;
            image.SizeMode = PictureBoxSizeMode.Normal;
            image.LoadAsync(path);
            return image;

        }
        

    }
}