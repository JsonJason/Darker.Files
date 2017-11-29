using System.Windows.Forms;

namespace Darker.UI.Persistance
{
    public class PersistanceFormApp : App
    {
        private readonly Form1 _view;
        private PersistanceFormController _ctrl;
        public PersistanceFormApp(PersistanceFormController ctrl,Form1 view)
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
}
