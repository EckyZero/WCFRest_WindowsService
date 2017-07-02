using System.ServiceProcess;
using System.ServiceModel;
using System.Data.SQLite;

namespace RestWCFWinService
{
    public partial class MyRestWCFRestWinSer : ServiceBase
    {
        ServiceHost oServiceHost = null;
        public MyRestWCFRestWinSer()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            oServiceHost = new ServiceHost(typeof(RestWCFServiceLibrary.RestWCFServiceLibrary));
            oServiceHost.Open();

            RestWCFServiceLibrary.Application.Startup();
        }

        protected override void OnStop()
        {
            if (oServiceHost != null)
            {
                oServiceHost.Close();
                oServiceHost = null;
            }
        }
    }
}