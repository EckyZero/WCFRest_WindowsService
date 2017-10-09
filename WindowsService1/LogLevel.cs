using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public enum LogLevel
    {
        Error,
        FailureAudit,
        Information,
        SuccessAudit,
        Warning
    }

    public interface ILogger
    {
        void LogEntry(string message, LogLevel logLevel);

        void ClearLog();
    }
}
