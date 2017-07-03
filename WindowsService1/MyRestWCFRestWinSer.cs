using System.ServiceProcess;
using System.ServiceModel;
using System.Threading;
using System;

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
            Console.WriteLine("Windows service started");

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