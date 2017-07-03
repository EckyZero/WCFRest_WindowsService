using System.ServiceProcess;
using System.ServiceModel;
using System.Data.SQLite;

namespace RestWCFWinService
{
    public partial class MyRestWCFRestWinSer : ServiceBase
    {
        ServiceHost oStudentServiceHost = null;
        ServiceHost oTeacherServiceHost = null;

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
            oStudentServiceHost = new ServiceHost(typeof(RestWCFServiceLibrary.HighScoreController));
            oStudentServiceHost.Open();

            oTeacherServiceHost = new ServiceHost(typeof(RestWCFServiceLibrary.TeacherService));
            oTeacherServiceHost.Open();

            RestWCFServiceLibrary.Application.Startup();
        }

        protected override void OnStop()
        {
            if (oStudentServiceHost != null)
            {
                oStudentServiceHost.Close();
                oStudentServiceHost = null;
            }
            if (oTeacherServiceHost != null)
            {
                oTeacherServiceHost.Close();
                oTeacherServiceHost = null;
            }
        }
    }
}