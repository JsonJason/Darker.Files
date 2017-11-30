using System.Collections.Generic;
using Darker.OverwatchApi;

namespace Darker.UI.Persistance.Overwatch
{
    public partial class OWView : BaseView
    {
        private OwController _controller;
        private List<HeroSummary> _heroes;

        public OWView()
        {
            InitializeComponent();
        }

        public OwController Controller
        {
            get => _controller;
            set
            {
                _controller = value;
                _controller.Initialize();
            }
        }

        public string BattleTag => textBox1.Text;

        public List<HeroSummary> Heroes
        {
            get { return _heroes; }
            set
            {
                _heroes = value;
                OnHeroesLoaded();
            }
        }

        private void OnHeroesLoaded()
        {
            richTextBox1.Text = "";

            foreach (var heroSummary in Heroes)
            {
                richTextBox1.Text +=
                    heroSummary.Id + "\n" +
                    heroSummary.Name + "\n" +
                    heroSummary.Description + "\n" +
                    heroSummary.Health + "\n" +
                    heroSummary.Armour + "\n" +
                    heroSummary.Shield + "\n" +
                    heroSummary.RealName + "\n" +
                    heroSummary.Age + "\n" +
                    heroSummary.Height + "\n" +
                    heroSummary.Affiliation + "\n" +
                    heroSummary.Location + "\n" +
                    heroSummary.DIfficulty + "\n";
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Controller.LoadBlob();
        }
    }
}
