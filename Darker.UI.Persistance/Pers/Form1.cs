using System;
using System.Windows.Forms;

namespace Darker.UI.Persistance
{
    public partial class Form1 : BaseView
    {


        private void OnControllerReady()
        {

            Controller.LoadMessage();
        }


        private PersistanceFormController _controller;

        public Form1()
        {
            InitializeComponent();
         
        }

    
        public string Message
        {
            get => box_message.Text;
            set => box_message.Text = value;
        }

        public PersistanceFormController Controller
        {
            get => _controller;
            set
            {
                _controller = value;
                Controller.Initialize();
            }
        }


        private void btn_load_Click(object sender, System.EventArgs e)
        {
            Controller.LoadMessage();
        }

        private void btn_save_Click(object sender, System.EventArgs e)
        {
            Controller.SaveMessage();
        }

        

        public void Initialize()
        {
            Controller.LoadMessage();
        }

    }
}