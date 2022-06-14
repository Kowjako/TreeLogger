using System;
using System.Drawing;
using Threading = System.Threading;
using System.Windows.Forms;
using TreeLogger.Interfaces;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;

namespace TreeLogger
{
    public partial class TreeLoggerView : Form, ILoggerView
    {
        private ILoggerViewModel viewModel;
        private readonly CancellationTokenSource cts;

        public System.Timers.Timer timer { get; private set; }

        public bool IsCloseEnabled
        {
            set => bDisturb.Enabled = false;
        }

        public bool LoggerFinished
        {
            set => timer.Stop();
        }

        public TreeLoggerView()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += (sender, e) => viewModel.HandleTimerTick();
            timer.Start();
            cts = new CancellationTokenSource();
        }

        public TimeSpan ElapsedTime
        {
            set
            {
                timeLabel.Invoke(new MethodInvoker(() => timeLabel.Text = string.Format("{0:00}:{1:00}:{2:00}", value.Hours, value.Minutes, value.Seconds)));
            }
        }

        public CancellationToken CancellationToken => cts.Token;

        public TreeNodeCollection Nodes => mainTreeView.Nodes;

        public TreeView SubView => mainTreeView;

        public void SetViewModel(ILoggerViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        private void bDisturb_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            viewModel.HandleCloseOperation();
        }

        private void TreeLoggerView_Load(object sender, EventArgs e)
        {
            viewModel.HandleDoOperation();
        }

        #region Common behaviuor

        private Point lastPoint;

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
