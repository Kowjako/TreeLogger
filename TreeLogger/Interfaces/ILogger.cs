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
        /// <summary>
        /// Methods to log messages
        /// </summary>
        /// <param name="message"></param>
        void LogMessage(string message);
        void LogMessage(string message, MessageSeverity severity);

        /// <summary>
        /// Make current node as start node for subprocess
        /// </summary>
        void InitSubLogging();

        /// <summary>
        /// End subprocess and return main node to parent
        /// </summary>
        void EndSubLogging();

        /// <summary>
        /// Set next node as root node
        /// </summary>
        void ResetSubLogging();
    }
}
