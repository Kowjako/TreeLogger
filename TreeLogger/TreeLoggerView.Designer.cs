
namespace TreeLogger
{
    partial class TreeLoggerView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeLoggerView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bExit = new System.Windows.Forms.Button();
            this.bDisturb = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainTreeView = new System.Windows.Forms.TreeView();
            this.loggerImagesList = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.timeLabel = new System.Windows.Forms.Label();
            this.lblOperation = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.bClose = new System.Windows.Forms.PictureBox();
            this.bMinimize = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.bExit);
            this.panel1.Controls.Add(this.bDisturb);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.headerPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 450);
            this.panel1.TabIndex = 0;
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(324, 412);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(290, 32);
            this.bExit.TabIndex = 4;
            this.bExit.TabStop = false;
            this.bExit.Text = "Zamknij";
            this.bExit.UseVisualStyleBackColor = true;
            // 
            // bDisturb
            // 
            this.bDisturb.Location = new System.Drawing.Point(10, 412);
            this.bDisturb.Name = "bDisturb";
            this.bDisturb.Size = new System.Drawing.Size(290, 32);
            this.bDisturb.TabIndex = 3;
            this.bDisturb.TabStop = false;
            this.bDisturb.Text = "Przerwij";
            this.bDisturb.UseVisualStyleBackColor = true;
            this.bDisturb.Click += new System.EventHandler(this.bDisturb_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mainTreeView);
            this.panel2.Location = new System.Drawing.Point(10, 75);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(604, 331);
            this.panel2.TabIndex = 2;
            // 
            // mainTreeView
            // 
            this.mainTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mainTreeView.ImageIndex = 0;
            this.mainTreeView.ImageList = this.loggerImagesList;
            this.mainTreeView.Location = new System.Drawing.Point(0, 0);
            this.mainTreeView.Name = "mainTreeView";
            this.mainTreeView.SelectedImageIndex = 0;
            this.mainTreeView.Size = new System.Drawing.Size(604, 331);
            this.mainTreeView.TabIndex = 0;
            // 
            // loggerImagesList
            // 
            this.loggerImagesList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("loggerImagesList.ImageStream")));
            this.loggerImagesList.TransparentColor = System.Drawing.Color.Transparent;
            this.loggerImagesList.Images.SetKeyName(0, "warning.png");
            this.loggerImagesList.Images.SetKeyName(1, "info.png");
            this.loggerImagesList.Images.SetKeyName(2, "error.png");
            this.loggerImagesList.Images.SetKeyName(3, "success.png");
            this.loggerImagesList.Images.SetKeyName(4, "process.png");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.Controls.Add(this.timeLabel);
            this.panel3.Controls.Add(this.lblOperation);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(626, 40);
            this.panel3.TabIndex = 1;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeLabel.Location = new System.Drawing.Point(100, 12);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(44, 15);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "00 : 00";
            // 
            // lblOperation
            // 
            this.lblOperation.AutoSize = true;
            this.lblOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOperation.Location = new System.Drawing.Point(9, 12);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(93, 16);
            this.lblOperation.TabIndex = 0;
            this.lblOperation.Text = "Czas operacji:";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Pink;
            this.headerPanel.Controls.Add(this.bClose);
            this.headerPanel.Controls.Add(this.bMinimize);
            this.headerPanel.Controls.Add(this.label1);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(626, 29);
            this.headerPanel.TabIndex = 0;
            this.headerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseDown);
            this.headerPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseMove);
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Transparent;
            this.bClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bClose.Image = ((System.Drawing.Image)(resources.GetObject("bClose.Image")));
            this.bClose.Location = new System.Drawing.Point(596, 2);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(31, 25);
            this.bClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bClose.TabIndex = 3;
            this.bClose.TabStop = false;
            // 
            // bMinimize
            // 
            this.bMinimize.BackColor = System.Drawing.Color.Transparent;
            this.bMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bMinimize.Image = ((System.Drawing.Image)(resources.GetObject("bMinimize.Image")));
            this.bMinimize.Location = new System.Drawing.Point(568, 2);
            this.bMinimize.Name = "bMinimize";
            this.bMinimize.Size = new System.Drawing.Size(31, 25);
            this.bMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bMinimize.TabIndex = 2;
            this.bMinimize.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Logger by maybedot";
            // 
            // TreeLoggerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TreeLoggerView";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMinimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox bClose;
        private System.Windows.Forms.PictureBox bMinimize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bDisturb;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView mainTreeView;
        private System.Windows.Forms.ImageList loggerImagesList;
    }
}

