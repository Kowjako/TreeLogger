using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeLogger.Enums;
using TreeLogger.Interfaces;
using TreeLogger.TreeNodes;

namespace TreeLogger.ViewModels
{
    internal class OperationContract
    {
        public string Message { get; private set; }
        public MessageSeverity MessageSeverity { get; private set; }
        public OperationContract(string message, MessageSeverity severity)
        {
            Message = message;
            MessageSeverity = severity;
        }
    }

    public class TreeLoggerViewModel : ILogger, ILoggerViewModel
    {
        private readonly ILoggerView _view;
        private readonly TreeView _viewTreeView;

        protected Action CoreOperation { get; set; }
        protected Action<ILogger> DefaultOperation { get; set; }
        protected Action<ILogger, CancellationToken> CancellableOperation { get; set; }

        private TreeNode _currentRootNode;

        private DateTime _startTime;

        public TreeLoggerViewModel(ILoggerView view)
        {
            _view = view;
            _viewTreeView = _view.SubView;
            _view.SetViewModel(this);
            Task.Run(() =>
            {
                HandleBeforeOperation();
                HandleDoOperation();
            }, _view.CancellationToken);
        }

        #region Run methods

        public void Run(string operation, Action<ILogger> action)
        {
            RunMain(operation, () => DefaultOperation = action, () =>
            {
                action(this);
            });
        }

        public void Run(string operation, Action<ILogger, CancellationToken> action)
        {
            RunMain(operation, () => CancellableOperation = action, () =>
            {
                action(this, _view.CancellationToken);
            });
        }

        internal void RunMain(string operationName, Action assignOperation, Action operation)
        {
            assignOperation();
            CoreOperation = operation;
            _view.ShowDialog();
        }

        #endregion

        #region MessageLogging

        public void LogMessage(string message)
        {
            LogMessageCore(new OperationContract(message, MessageSeverity.Information));
        }

        public void LogMessage(string message, MessageSeverity severity)
        {
            LogMessageCore(new OperationContract(message, severity));
        }

        internal void LogMessageCore(OperationContract contract)
        {
            if (_currentRootNode != null)
            {
                _viewTreeView.Invoke(new MethodInvoker(() =>
                {
                    _currentRootNode.Nodes.Add(new OperationTreeNode(contract));
                    _currentRootNode.ExpandAll();
                }));
            }
        }

        public void HandleDoOperation()
        {
            CoreOperation();
        }

        public void HandleBeforeOperation()
        {
            _startTime = DateTime.Now;
            _viewTreeView.Invoke(new MethodInvoker(() =>
            {
                _currentRootNode = new OperationRootNode("Operacja rozpoczęta");
                _viewTreeView.Nodes.Add(_currentRootNode);
            }));
        }

        public void HandleCloseOperation()
        {
            LogMessage("Operacja została przerwana przez użytkownika", MessageSeverity.Warning);
        }

        #endregion

    }
}
