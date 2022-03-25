using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeLogger.Interfaces;
using TreeLogger.ViewModel;

namespace TreeLogger
{
    public partial class TreeLoggerView : Form
    {
        private Point lastPoint;
        private ILoggerViewModel ViewModel;
        private static DateTime LoggerStartTime;
        public TreeLoggerView()
        {
            InitializeComponent();
            mainTreeView.Nodes.Clear();
            ViewModel = new LoggerViewModel();
            OnViewModelSet();
        }

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void bMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CreateMainRootNode(string caption, MessageSeverity e)
        {
            ViewModel.CreateMainRootNode(caption, e);
        }

        public void CreateChildNode(string caption, MessageSeverity e)
        {
            ViewModel.CreateChildNode(caption, e);
        }
        public void CreateChildNode(string caption, MessageSeverity e, TreeNode parentNode)
        {
            ViewModel.CreateChildNode(caption, e, parentNode);
        }

        private void RefreshTree()
        {
            if(mainTreeView.InvokeRequired)
            {
                mainTreeView.BeginInvoke(new MethodInvoker(() =>
                {
                    /* Using Clone to prevent Concurrency issue with reference-types */
                    if (mainTreeView.Nodes.Count == 0)
                    {
                        mainTreeView.Nodes.Add(ViewModel.RootNodes.First().Clone() as TreeNode);
                    }
                    else
                    {
                        foreach(TreeNode tn in ViewModel.RootNodes.First().Nodes)
                        {
                            if (!mainTreeView.Nodes[0].Nodes.Contains(tn))
                                mainTreeView.Nodes[0].Nodes.Add(tn);
                        }
                        mainTreeView.Nodes[0].Nodes[mainTreeView.Nodes[0].Nodes.Count - 1].EnsureVisible();
                    }
                    mainTreeView.ExpandAll();
                }));
            }
        }

        private void RefreshLoggerTime()
        {
            if(timeLabel.InvokeRequired)
            {
                timeLabel.BeginInvoke(new MethodInvoker(() =>
                {
                    timeLabel.Text = string.Format("{0:00} : {1:00}", (DateTime.Now - LoggerStartTime).Minutes,
                                                                      (DateTime.Now - LoggerStartTime).Seconds);
                }));
            }
        }

        private void OnViewModelSet()
        {
            ViewModel.RefreshTree += RefreshTree;
            ViewModel.RefreshLoggerTime += RefreshLoggerTime;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            LoggerStartTime = DateTime.Now;
            Task.Factory.StartNew(() => ViewModel.ShowExample());
        }

        private void bDisturb_Click(object sender, EventArgs e)
        {
            ViewModel.HandleCancellationToken();
        }
    }
}
