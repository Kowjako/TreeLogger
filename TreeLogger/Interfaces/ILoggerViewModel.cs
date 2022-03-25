using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeLogger.ViewModel;

namespace TreeLogger.Interfaces
{
    public interface ILoggerViewModel
    {
        CancellationTokenSource CancelTokenSource { get; set; }
        event Action<TreeNode> OnNodeAdded;
        event Action RefreshTree;
        event Action RefreshLoggerTime;
        ICollection<TreeNode> RootNodes { get; }
        TreeNode MainRootNode { get; set; }
        void CreateMainRootNode(string caption, MessageSeverity e);
        void CreateChildNode(string caption, MessageSeverity e);
        void CreateChildNode(string caption, MessageSeverity e, TreeNode parentNode);
        void ShowExample();
        void HandleCancellationToken();

    }
}
