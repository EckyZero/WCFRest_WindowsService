using System.ServiceProcess;
using System.ServiceModel;

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
            oStudentServiceHost = new ServiceHost(typeof(RestWCFServiceLibrary.StudentService));
            oStudentServiceHost.Open();

            oTeacherServiceHost = new ServiceHost(typeof(RestWCFServiceLibrary.TeacherService));
            oTeacherServiceHost.Open();
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