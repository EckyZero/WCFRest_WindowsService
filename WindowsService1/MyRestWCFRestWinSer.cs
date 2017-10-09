using System.ServiceProcess;
using System.ServiceModel;
using RestWCFServiceLibrary.Use_Cases.HighScores;
using RestWCFServiceLibrary.Use_Cases.Teachers;
using System;
using WindowsService1;

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
            AppDomain currentDomain = AppDomain.CurrentDomain;

            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleUnhandledExceptions);

            oStudentServiceHost = new ServiceHost(typeof(HighScoresController));

            oStudentServiceHost.Open();

            oTeacherServiceHost = new ServiceHost(typeof(TeachersController));
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

        private void HandleUnhandledExceptions(object sender, UnhandledExceptionEventArgs args)
        {
            var e = (Exception)args.ExceptionObject;
            var message = DateTime.UtcNow + " - " + e.Message + " - " + e.StackTrace;
            var logger = new Logger();

            logger.LogEntry(message, LogLevel.Error);
        }
    }
}