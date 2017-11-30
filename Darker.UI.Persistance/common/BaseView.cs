using System;
using System.Windows.Forms;

namespace Darker.UI.Persistance
{
    public class BaseView : Form,View
    {
        public virtual void Error(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().Name);
        }

        public virtual void StatusUpdate(string status)
        {
            MessageBox.Show(status);
        }

        public virtual void LoadingStart()
        {
        }

        public virtual void LoadingEnd()
        {
           
        }
    }
}
