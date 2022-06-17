using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeLogger.Global;

namespace TreeLoggerTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeLoggerRunner.RunTreeLogger("Ksiegowanie dokumentu handlowego", (logger, token) =>
            {
                logger.LogMessage("Ksiegowanie naglowka");
                logger.InitSubLogging();
                for(int i = 0;i <10;i++)
                {
                    if (token.IsCancellationRequested) return;
                    logger.LogMessage($"Aktualna wartosc : {i}", TreeLogger.Enums.MessageSeverity.Information);
                    Thread.Sleep(500);
                }
                logger.EndSubLogging();
                logger.LogMessage("Ksiegowanie stopki");
            });
        }
    }
}
