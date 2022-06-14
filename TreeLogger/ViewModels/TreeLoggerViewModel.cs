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
    /// <summary>
    /// Class to incapsulate logged message
    /// </summary>
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

    /// <summary>
    /// ViewModel of our logger
    /// </summary>
    internal class TreeLoggerViewModel : ILogger, ILoggerViewModel
    {
        private readonly ILoggerView _view;
        private readonly TreeView _viewTreeView;

        protected Action CoreOperation { get; set; }
        protected Action<ILogger> DefaultOperation { get; set; }
        protected Action<ILogger, CancellationToken> CancellableOperation { get; set; }

        private TreeNode _currentRootNode;
        private TreeNode _actualNode;

        public string OperationName { get; private set; }

        private DateTime _startTime;

        public TreeLoggerViewModel(ILoggerView view)
        {
            _view = view;
            _viewTreeView = _view.SubView;
            _view.SetViewModel(this);
        }

        #region Run methods

        internal void Run(string operation, Action<ILogger> action)
        {
            RunMain(operation, () => DefaultOperation = action, () =>
            {
                action(this);
            });
        }

        internal void Run(string operation, Action<ILogger, CancellationToken> action)
        {
            RunMain(operation, () => CancellableOperation = action, () =>
            {
                action(this, _view.CancellationToken);
            });
        }

        internal void RunMain(string operationName, Action assignOperation, Action operation)
        {
            OperationName = operationName;
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
                    _actualNode = new OperationTreeNode(contract);
                    _currentRootNode.Nodes.Add(_actualNode);                   
                    _currentRootNode.ExpandAll();
                    _viewTreeView.SelectedNode = _actualNode;
                }));
            }
        }

        public void HandleDoOperation()
        {
            Task.Run(() =>
            {
                HandleBeforeOperation();
                CoreOperation();
                if (!_view.CancellationToken.IsCancellationRequested)
                {
                    HandleSuccess();
                }
            }, _view.CancellationToken);
        }

        public void HandleBeforeOperation()
        {
            _startTime = DateTime.Now;
            _viewTreeView.Invoke(new MethodInvoker(() =>
            {
                _currentRootNode = new OperationRootNode(OperationName);
                _viewTreeView.Nodes.Add(_currentRootNode);
            }));
        }

        public void HandleSuccess()
        {
            LogMessage("Operacja została ukończona", MessageSeverity.Success);
        }

        public void HandleCloseOperation()
        {
            LogMessage("Operacja została przerwana przez użytkownika", MessageSeverity.Warning);
        }

        public void HandleTimerTick()
        {
            _view.ElapsedTime = DateTime.Now - _startTime;
        }

        #endregion

    }
}
