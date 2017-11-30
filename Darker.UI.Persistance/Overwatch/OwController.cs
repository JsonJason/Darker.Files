using System.Linq;
using Darker.OWAPI;

namespace Darker.UI.Persistance.Overwatch
{
    public class OwController : BaseController
    {
        private readonly OverwatchApi.OverwatchApi _overwatch;
        private readonly OwApi _owapi;

        public OwController(OverwatchApi.OverwatchApi overwatch,OwApi owapi)
        {
            _overwatch = overwatch;
            _owapi = owapi;
        }

        public void LoadBlob() => Try(() =>
        {
            _view.Heroes = _overwatch.GetHeroes().ToList();
            LoadUser();
        });


        public override void Initialize()
        {
            LoadBlob();
          
        }

        private void LoadUser()
        {
           var result =  _owapi.GetUserBlob(_view.BattleTag);
            int i = 0;
        }

        

        private OWView _view;
        public void SetView(OWView view)
        {
            _view = view;
            base.View = _view;
        }
    }
}