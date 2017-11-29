using System.Windows.Forms;
using Darker.UI.Persistance.shows;

namespace Darker.UI.Persistance
{
    public class ShowApp : App
    {
        private readonly ShowSearchView _view;
        private readonly ShowAppController _ctrl;

        public ShowApp(ShowSearchView view,ShowAppController ctrl)
        {
            _view = view;
            _ctrl = ctrl;
            _ctrl.View = _view;
            _view.Controller = _ctrl;
        }

        public void Start()
        {
            Application.Run(_view);
        }
    }

    public interface App
    {
        void Start();
    }

}