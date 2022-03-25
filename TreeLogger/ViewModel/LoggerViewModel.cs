using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeLogger.Interfaces;

namespace TreeLogger.ViewModel
{
    public enum MessageSeverity
    {
        Process = 4,
        Information = 1,
        Warning = 0,
        Error = 2,
        OK = 3
    }
    class LoggerViewModel : ILoggerViewModel
    {
        private List<TreeNode> AllNodes;

        public event Action<TreeNode> OnNodeAdded;
        public event Action RefreshTree;
        public event Action RefreshLoggerTime;

        public TreeNode MainRootNode { get; set; }
        public ICollection<TreeNode> RootNodes => AllNodes;

        public CancellationTokenSource CancelTokenSource { get; set; }
        private CancellationToken Token;


        public LoggerViewModel()
        {
            AllNodes = new List<TreeNode>();
            CancelTokenSource = new CancellationTokenSource();
            Token = CancelTokenSource.Token;
            OnNodeAdded += (node) =>
            {
                AllNodes.Add(node);
                RefreshLoggerTime?.Invoke();
                RefreshTree?.Invoke();
            };
        }
        public void CreateMainRootNode(string caption, MessageSeverity e)
        {
            if (MainRootNode != null) throw new LoggerExcpetion("Main Root Node was already created");
            MainRootNode = new TreeNode(caption, (int)e, (int)e);
            OnNodeAdded(MainRootNode);
        }

        public void CreateChildNode(string caption, MessageSeverity e)
        {
            var newNode = new TreeNode(caption, (int)e, (int)e);
            MainRootNode.Nodes.Add(newNode);
            OnNodeAdded(newNode);
        }
        public void CreateChildNode(string caption, MessageSeverity e, TreeNode parentNode)
        {
            if (Token.IsCancellationRequested) return;
            if (parentNode == null) throw new LoggerExcpetion("Parent node cannot be found");
            else
            {
                Thread.Sleep(500);
                var newNode = new TreeNode(caption, (int)e, (int)e);
                parentNode.Nodes.Add(newNode);
                RefreshTree?.Invoke();
                RefreshLoggerTime?.Invoke();
            }
        }

        public void ShowExample()
        {
            CreateMainRootNode("Tworzenie głównej bazy danych", MessageSeverity.Process);

            CreateChildNode("Tworzenie tabeli Clinics", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Drugs", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Employees", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Tools", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Registrations", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Users", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Orders", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli OrderTools", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Patients", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Costs", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Producents", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Operations", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Localizations", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie tabeli Data", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie widoku ClinicRow", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie widoku DrugRow", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie widoku EmployeeRow", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie widoku ToolRow", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie widoku OrderRow", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie widoku OpinionRow", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie widoku CostRow", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie widoku ProducentRow", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie widoku PatientRow", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Wypełnianie danych tabel", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Aktualizacja triggerów", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Tworzenie użytkowników", MessageSeverity.Information, MainRootNode);
            CreateChildNode("Zakończono sukcesem", MessageSeverity.OK, MainRootNode);
        }

        public void HandleCancellationToken()
        {
            CancelTokenSource.Cancel();
        }
    }
}
