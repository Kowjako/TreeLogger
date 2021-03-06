using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLogger.Interfaces
{
    public interface ILoggerViewModel
    {
        void HandleBeforeOperation();
        void HandleDoOperation();
        void HandleCloseOperation();
        void HandleTimerTick();
    }
}
