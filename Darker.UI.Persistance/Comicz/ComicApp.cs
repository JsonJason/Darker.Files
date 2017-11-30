using System.Windows.Forms;

namespace Darker.UI.Persistance.Comicz
{
    public class ComicApp : App
    {
        private readonly ComicView _view;
        private readonly ComicController _ctrl;

        public ComicApp(ComicView view,ComicController ctrl)
        {
            _view = view;
            _ctrl = ctrl;

            _ctrl.View = _view;
            _view.Ctrl = _ctrl;

        }

        public void Start()
        {
            
            Application.Run(_view);
        }
    }
}