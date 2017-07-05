using RestWCFServiceLibrary.Use_Cases.Teachers.Interfaces;
using System;
using System.Diagnostics;
using System.Threading;

namespace RestWCFServiceLibrary.Use_Cases.Teachers
{
    public class TeachersController : ITeachersController
    {
        private Timer timer;
        private int tickCount = 0;

        public TeachersController()
        {
            startTimer();

            // Create the source for the events to be logged, if it does not already exist
            if (!EventLog.SourceExists("MyDemoSource"))
            {
                EventLog.CreateEventSource("MyDemoSource", "MyDemoLog");
                Console.WriteLine("Created Event Source");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");
                // The source is created.  Exit the application to allow it to be registered (doesn't happen automatically).
                return;
            }

            // Create an EventLog instance and assign its source
            EventLog log = new EventLog();
            log.Source = "MyDemoSource";

            // Write an information and error entry to the event log  
            log.WriteEntry("Writing sample information message to event log.", EventLogEntryType.Information);
            log.WriteEntry("Writing sample error message to event log.", EventLogEntryType.Error);
        }

        private void startTimer()
        {
            if (timer == null)
            {
                Console.WriteLine("Starting timer in teacher service");

                //due time = time to wait before first execution of the method
                //period = time to wait between subsequent executions
                timer = new Timer(new TimerCallback(TimerTick), null, 3000, 1000);
            }
        }

        private void stopTimer()
        {
            if (timer != null)
            {
                Console.WriteLine("Stopping timer in teacher service");
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;
            }
        }

        private void TimerTick(object state)
        {
            ++tickCount;
            Console.WriteLine("Timer ticked in teacher service: " + tickCount);

            if (tickCount >= 5)
            {
                stopTimer();
            }
        }

        public string Get (string id)
        {
            return "You entered id: " + id;
        }
    }
}
