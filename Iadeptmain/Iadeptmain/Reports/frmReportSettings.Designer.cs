namespace Iadeptmain.Reports
{
    partial class frmReportSettings
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
            this.cmsReport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.vScrollBar2 = new DevExpress.XtraEditors.VScrollBar();
            this.gcDaily = new DevExpress.XtraEditors.GroupControl();
            this.lbDaily = new DevExpress.XtraEditors.ListBoxControl();
            this.btnauto = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lstautoreport = new DevExpress.XtraEditors.ListBoxControl();
            this.gcSReport = new DevExpress.XtraEditors.GroupControl();
            this.lbSelectReport = new DevExpress.XtraEditors.ListBoxControl();
            this.btnDaily = new DevExpress.XtraEditors.SimpleButton();
            this.btnForword = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lbAllReport = new DevExpress.XtraEditors.ListBoxControl();
            this.cmsReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDaily)).BeginInit();
            this.gcDaily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbDaily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstautoreport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSReport)).BeginInit();
            this.gcSReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbSelectReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbAllReport)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsReport
            // 
            this.cmsReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDelete});
            this.cmsReport.Name = "cmsReport";
            this.cmsReport.Size = new System.Drawing.Size(108, 26);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(107, 22);
            this.tsmDelete.Text = "Delete";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.AllowTouchScroll = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.vScrollBar2);
            this.panelControl1.Controls.Add(this.gcDaily);
            this.panelControl1.Controls.Add(this.btnauto);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.gcSReport);
            this.panelControl1.Controls.Add(this.btnDaily);
            this.panelControl1.Controls.Add(this.btnForword);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.FireScrollEventOnMouseWheel = true;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelControl1.ScrollBarSmallChange = 25;
            this.panelControl1.Size = new System.Drawing.Size(1010, 494);
            this.panelControl1.TabIndex = 31;
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.vScrollBar2.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar2.Location = new System.Drawing.Point(993, 0);
            this.vScrollBar2.Maximum = 10;
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.ScrollBarAutoSize = true;
            this.vScrollBar2.Size = new System.Drawing.Size(17, 494);
            this.vScrollBar2.TabIndex = 28;
            // 
            // gcDaily
            // 
            this.gcDaily.Controls.Add(this.lbDaily);
            this.gcDaily.Location = new System.Drawing.Point(557, 392);
            this.gcDaily.Name = "gcDaily";
            this.gcDaily.Size = new System.Drawing.Size(271, 72);
            this.gcDaily.TabIndex = 25;
            this.gcDaily.Text = "Daily Reports";
            // 
            // lbDaily
            // 
            this.lbDaily.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lbDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDaily.Location = new System.Drawing.Point(2, 21);
            this.lbDaily.Name = "lbDaily";
            this.lbDaily.Size = new System.Drawing.Size(267, 49);
            this.lbDaily.TabIndex = 4;
            this.lbDaily.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbDaily_MouseClick);
            this.lbDaily.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbDaily_MouseDown);
            // 
            // btnauto
            // 
            this.btnauto.Location = new System.Drawing.Point(364, 312);
            this.btnauto.Name = "btnauto";
            this.btnauto.Size = new System.Drawing.Size(158, 23);
            this.btnauto.TabIndex = 26;
            this.btnauto.Text = "Add";
            this.btnauto.Click += new System.EventHandler(this.btnauto_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lstautoreport);
            this.groupControl1.Location = new System.Drawing.Point(555, 291);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(271, 72);
            this.groupControl1.TabIndex = 24;
            this.groupControl1.Text = "Automatic Reports";
            // 
            // lstautoreport
            // 
            this.lstautoreport.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lstautoreport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstautoreport.Location = new System.Drawing.Point(2, 21);
            this.lstautoreport.Name = "lstautoreport";
            this.lstautoreport.Size = new System.Drawing.Size(267, 49);
            this.lstautoreport.TabIndex = 4;
            this.lstautoreport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstautoreport_MouseClick);
            this.lstautoreport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbDaily_MouseDown);
            // 
            // gcSReport
            // 
            this.gcSReport.Controls.Add(this.lbSelectReport);
            this.gcSReport.Location = new System.Drawing.Point(553, 33);
            this.gcSReport.Name = "gcSReport";
            this.gcSReport.Size = new System.Drawing.Size(271, 230);
            this.gcSReport.TabIndex = 23;
            this.gcSReport.Text = "Selected Reports";
            // 
            // lbSelectReport
            // 
            this.lbSelectReport.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.lbSelectReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSelectReport.Location = new System.Drawing.Point(2, 21);
            this.lbSelectReport.Name = "lbSelectReport";
            this.lbSelectReport.Size = new System.Drawing.Size(267, 207);
            this.lbSelectReport.TabIndex = 4;
            this.lbSelectReport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbSelectReport_MouseClick);
            this.lbSelectReport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbDaily_MouseDown);
            // 
            // btnDaily
            // 
            this.btnDaily.Location = new System.Drawing.Point(364, 413);
            this.btnDaily.Name = "btnDaily";
            this.btnDaily.Size = new System.Drawing.Size(158, 23);
            this.btnDaily.TabIndex = 22;
            this.btnDaily.Text = "Add";
            this.btnDaily.Click += new System.EventHandler(this.btnDaily_Click);
            // 
            // btnForword
            // 
            this.btnForword.Location = new System.Drawing.Point(364, 167);
            this.btnForword.Name = "btnForword";
            this.btnForword.Size = new System.Drawing.Size(158, 23);
            this.btnForword.TabIndex = 21;
            this.btnForword.Text = "Add";
            this.btnForword.Click += new System.EventHandler(this.btnForword_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lbAllReport);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(237, 494);
            this.panelControl2.TabIndex = 32;
            // 
            // lbAllReport
            // 
            this.lbAllReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAllReport.Items.AddRange(new object[] {
            "OverAll Values",
            "OverAll Values with Difference and Graphical Analysis",
            "Points with Alarms",
            "User Selected Points",
            "Velocity Axial with Time Graph",
            "Velocity Axial with Power Graph",
            "Velocity Axial with Demodulate Graph",
            "Velocity Horizontal with Time Graph",
            "Velocity Horizontal with Power Graph",
            "Velocity Horizontal with Demodulate Graph",
            "Velocity Vertical with Time Graph",
            "Velocity Vertical with Power Graph",
            "Velocity Vertical with Demodulate Graph",
            "Acceleration Axial with Time Graph",
            "Acceleration Axial with Power Graph",
            "Acceleration Axial with Demodulate Graph",
            "Acceleration Horizontal with Time Graph",
            "Acceleration Horizontal with Power Graph",
            "Acceleration Horizontal with Demodulate Graph",
            "Acceleration Vertical with Time Graph",
            "Acceleration Vertical with Power Graph",
            "Acceleration Vertical with Demodulate Graph",
            "Displacement Axial with Time Graph",
            "Displacement Axial with Power Graph",
            "Displacement Axial with Demodulate Graph",
            "Displacement Horizontal with Time Graph",
            "Displacement Horizontal with Power Graph",
            "Displacement Horizontal with Demodulate Graph",
            "Displacement Vertical with Time Graph",
            "Displacement Vertical with Power Graph",
            "Displacement Vertical with Demodulate Graph",
            "Bearing Axial with Time Graph",
            "Bearing Axial with Power Graph",
            "Bearing Axial with Demodulate Graph",
            "Bearing Horizontal with Time Graph",
            "Bearing Horizontal with Power Graph",
            "Bearing Horizontal with Demodulate Graph",
            "Bearing Vertical with Time Graph",
            "Bearing Vertical with Power Graph",
            "Bearing Vertical with Demodulate Graph",
            "1 Overall and 1 Graph",
            "Multi Overall and Multi Graph",
            "All Route DownLoad Report",
            "Route Time Based Report",
            "OverDue Points",
            "Last Monitored Exception",
            "Band Alarm Exception",
            "Fault Frequency Exception",
            "Machine RPM Exception"});
            this.lbAllReport.Location = new System.Drawing.Point(2, 2);
            this.lbAllReport.Name = "lbAllReport";
            this.lbAllReport.Size = new System.Drawing.Size(233, 490);
            this.lbAllReport.TabIndex = 3;
            // 
            // frmReportSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1010, 494);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReportSettings_FormClosed);
            this.Load += new System.EventHandler(this.frmReportSettings_Load);
            this.cmsReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDaily)).EndInit();
            this.gcDaily.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbDaily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstautoreport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSReport)).EndInit();
            this.gcSReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbSelectReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbAllReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsReport;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.VScrollBar vScrollBar2;
        private DevExpress.XtraEditors.GroupControl gcDaily;
        private DevExpress.XtraEditors.ListBoxControl lbDaily;
        private DevExpress.XtraEditors.SimpleButton btnauto;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ListBoxControl lstautoreport;
        private DevExpress.XtraEditors.GroupControl gcSReport;
        private DevExpress.XtraEditors.ListBoxControl lbSelectReport;
        private DevExpress.XtraEditors.SimpleButton btnDaily;
        private DevExpress.XtraEditors.SimpleButton btnForword;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ListBoxControl lbAllReport;

    }
}