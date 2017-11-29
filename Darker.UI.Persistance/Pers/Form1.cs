using System;
using System.Windows.Forms;

namespace Darker.UI.Persistance
{
    public partial class Form1 : Form
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

        public void StatusReport(string status) => label_status.Text = status;

        public void Error(Exception exception) =>
            MessageBox.Show(this, exception.Message, typeof(Exception).Name);

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
                OnControllerReady();
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