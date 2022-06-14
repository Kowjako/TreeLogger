using System;
using System.Drawing;
using Threading = System.Threading;
using System.Windows.Forms;
using TreeLogger.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace TreeLogger
{
    public partial class TreeLoggerView : Form, ILoggerView
    {
        private Point lastPoint;
        private ILoggerViewModel viewModel;
        private CancellationTokenSource cts;
        private Threading.Timer timer;

        public TreeLoggerView()
        {
            InitializeComponent();
            timer = new Threading.Timer((e) => viewModel.HandleTimerTick(), null, 1000, Timeout.Infinite);
            cts = new CancellationTokenSource();
        }

        public TimeSpan ElapsedTime
        {
            set
            {
                timeLabel.Text = string.Format("{0:00}:{1:00}:{2:00}", value.Hours, value.Minutes, value.Seconds);
            }
        }

        public CancellationToken CancellationToken => cts.Token;

        public TreeNodeCollection Nodes => mainTreeView.Nodes;

        public TreeView SubView => mainTreeView;

        public void SetViewModel(ILoggerViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        #region Common behaviuor

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

        private void bDisturb_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            viewModel.HandleCloseOperation();
        }

        private void TreeLoggerView_Load(object sender, EventArgs e)
        {
            viewModel.HandleDoOperation();
        }

    }
}
