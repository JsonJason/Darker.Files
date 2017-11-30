using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Darker.Tv;
using Darker.UI.Persistance.shows;

namespace Darker.UI.Persistance
{
    public partial class ShowSearchView :BaseView
    {
        private ShowAppController _controller;
        private IEnumerable<TvShowSummary> _shows;

        public ShowSearchView()
        {
            InitializeComponent();
        }

        public string SearchTerm => textBox1.Text;

        public IEnumerable<TvShowSummary> Shows
        {
            set
            {
                _shows = value;
                OnShowsRefreshed();
            }
            get => _shows;
        }

        public ShowAppController Controller
        {
            get => _controller;
            set
            {
                _controller = value;
                OnControllerInitialized();
            }
        }

        public string FilePath { get; set; }

        private void OnShowsRefreshed()
        {
            flowLayoutPanel1.Controls.Clear();
           
            foreach (var summary in Shows)
                flowLayoutPanel1.Controls.Add(CreateBanner(summary));
                    
                   
        }

        private Control CreateBanner(TvShowSummary summary)
        {
            var image = new PictureBox();
            image.Width = 400;
            image.Height = 100;
            image.LoadAsync(summary.Banner);
            return image;

        }

        private void OnControllerInitialized()
        {
            Controller.Initialize();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            Controller.LoadShows();
        }

  
        private void button_savetofile_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;
            FilePath = Path.Combine(folderBrowserDialog1.SelectedPath,"shows.json");
            Controller.SaveToFile();
        }
    }
}