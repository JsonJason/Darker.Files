using System;

namespace Darker.UI.Persistance
{
    public class BaseController : Controller
    {
        public virtual void Initialize()
        {
            
        }

        public virtual void Try(Action act)
        {
            try
            {
                act?.Invoke();
            }
            catch(Exception ex) { View?.Error(ex); }
        }

        public View View { get; set; }

    }
}
