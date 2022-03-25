using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLogger
{
    class LoggerExcpetion : Exception
    {
        public LoggerExcpetion(string message) : base(message)
        {

        }
    }
}
