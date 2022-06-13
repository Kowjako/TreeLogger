using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeLogger.Enums;

namespace TreeLogger.Interfaces
{
    public interface ILogger
    {
        void LogMessage(string message);

        void LogMessage(string message, MessageSeverity severity);
    }
}
