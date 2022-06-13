using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TreeLogger.Global
{
    public static class TreeLoggerRunner
    {
        /// <summary>
        /// Standard method to invoke logger execution
        /// </summary>
        /// <param name="caption">Logger start operation caption</param>
        /// <param name="action">Method which should be logged</param>
        public static void RunTreeLogger(string caption, Action<ILogger> action)
        {

        }

        /// <summary>
        /// Standard method to invoke logger execution supports async cancellation
        /// </summary>
        /// <param name="caption">Logger start operation caption</param>
        /// <param name="action">Method which should be logged</param>
        public static void RunTreeLogger(string caption, Action<ILogger, CancellationToken> action)
        {

        }
    }
}
