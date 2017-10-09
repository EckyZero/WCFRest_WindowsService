using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public class Logger
    {
        private EventLog log = null;
        private string sourceName = "WindowsService1";
        private string logName = "WindowsService1 Log";

        public Logger()
        {
            // Create the source for the events to be logged, if it does not already exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, logName);
            }

            //Create an instance of Windows Event Log and assign its source
            log = new EventLog();
            log.Source = sourceName;
        }

        public void LogEntry(string message, LogLevel logLevel)
        {
            //Log a given message based on its level and print to console
            switch (logLevel)
            {
                case LogLevel.Error:
                    log.WriteEntry(message, EventLogEntryType.Error);
                    Console.WriteLine("Error: " + message);
                    break;
                case LogLevel.FailureAudit:
                    log.WriteEntry(message, EventLogEntryType.FailureAudit);
                    Console.WriteLine("Failure Audit: " + message);
                    break;
                case LogLevel.Information:
                    log.WriteEntry(message, EventLogEntryType.Information);
                    Console.WriteLine("Information: " + message);
                    break;
                case LogLevel.SuccessAudit:
                    log.WriteEntry(message, EventLogEntryType.SuccessAudit);
                    Console.WriteLine("Success Audit: " + message);
                    break;
                case LogLevel.Warning:
                    log.WriteEntry(message, EventLogEntryType.Warning);
                    Console.WriteLine("Warning: " + message);
                    break;
            }
        }

        public void ClearLog()
        {
            log.Clear();
        }
    }
}