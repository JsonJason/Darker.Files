using System.Windows.Forms;

namespace Darker.UI.Persistance.Overwatch
{
    public class OWApp : App
    {
        private readonly OwController _ctrl;
        private readonly OWView _view;

        public OWApp(OWView view, OwController ctrl)
        {
            _view = view;
            _ctrl = ctrl;

            _ctrl.SetView(_view);
            _view.Controller = _ctrl;
        }

        public void Start()
        {
            Application.Run(_view);
        }
    }
}