using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeLogger.Interfaces
{
    /// <summary>
    /// Interface which describe TreeLogger view implementations
    /// </summary>
    public interface ILoggerView : IDisposable
    {
        /// <summary>
        /// Used to attach view model to view of logger
        /// </summary>
        /// <param name="viewModel"></param>
        void SetViewModel(ILoggerViewModel viewModel);

        /// <summary>
        /// Property to get execution time
        /// </summary>
        TimeSpan ElapsedTime { get; }

        /// <summary>
        /// Method to show logger window
        /// </summary>
        /// <returns></returns>
        DialogResult ShowDialog();

        /// <summary>
        /// Token which used to async logger cancellation
        /// </summary>
        CancellationToken CancellationToken { get; }
    }
}
