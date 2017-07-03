using System;
using System.Threading;

namespace RestWCFServiceLibrary
{
    public class StudentService : IStudentService
    {
        private Timer timer;
        private int tickCount = 0;

        public StudentService()
        {
            startTimer();
        }

        protected void startTimer()
        {
            if (timer == null)
            {
                Console.WriteLine("Starting timer in student service");

                //due time = time to wait before first execution of the method
                //period = time to wait between subsequent executions
                timer = new Timer(new TimerCallback(TimerTick), null, 3000, 1000);
            }
        }

        protected void stopTimer()
        {
            if (timer != null)
            {
                Console.WriteLine("Stopping timer in student service");
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;
            }
        }

        protected void TimerTick(object state)
        {
            ++tickCount;
            Console.WriteLine("Timer ticked in student service: " + tickCount);

            if (tickCount >= 5)
            {
                stopTimer();
            }
        }

        public string XMLData(string id)
        {
            return Data(id);
        }
        public string JSONData(string id)
        {
            return Data(id);
        }

        private string Data(string id)
        {
            // logic
            return "Data: " + id;
        }
    }
}