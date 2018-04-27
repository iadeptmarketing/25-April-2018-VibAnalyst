namespace Iadeptmain.Mainforms
{
    partial class frmHasp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHasp));
            this.btnTryAgain = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.lblPlz = new DevExpress.XtraEditors.LabelControl();
            this.pbDngImg = new System.Windows.Forms.PictureBox();
            this.lblExit = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.btnInstallDrivers = new DevExpress.XtraEditors.SimpleButton();
            this.lblInstallDrivers = new DevExpress.XtraEditors.LabelControl();
            this.btnDemo = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pbDngImg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTryAgain
            // 
            this.btnTryAgain.Location = new System.Drawing.Point(345, 39);
            this.btnTryAgain.Name = "btnTryAgain";
            this.btnTryAgain.Size = new System.Drawing.Size(56, 23);
            this.btnTryAgain.TabIndex = 0;
            this.btnTryAgain.Text = "Try";
            this.btnTryAgain.Click += new System.EventHandler(this.btnTryAgain_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(345, 89);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(56, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblPlz
            // 
            this.lblPlz.Location = new System.Drawing.Point(134, 22);
            this.lblPlz.Name = "lblPlz";
            this.lblPlz.Size = new System.Drawing.Size(118, 13);
            this.lblPlz.TabIndex = 2;
            this.lblPlz.Text = "Insert key and press Try";
            // 
            // pbDngImg
            // 
            this.pbDngImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbDngImg.Image = ((System.Drawing.Image)(resources.GetObject("pbDngImg.Image")));
            this.pbDngImg.Location = new System.Drawing.Point(0, 0);
            this.pbDngImg.Name = "pbDngImg";
            this.pbDngImg.Size = new System.Drawing.Size(128, 152);
            this.pbDngImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDngImg.TabIndex = 3;
            this.pbDngImg.TabStop = false;
            // 
            // lblExit
            // 
            this.lblExit.Location = new System.Drawing.Point(134, 67);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(111, 13);
            this.lblExit.TabIndex = 4;
            this.lblExit.Text = "Click Exit Button to Exit";
            this.lblExit.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(129, 136);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status:";
            // 
            // btnInstallDrivers
            // 
            this.btnInstallDrivers.Location = new System.Drawing.Point(345, 12);
            this.btnInstallDrivers.Name = "btnInstallDrivers";
            this.btnInstallDrivers.Size = new System.Drawing.Size(56, 23);
            this.btnInstallDrivers.TabIndex = 6;
            this.btnInstallDrivers.Text = "Drivers";
            this.btnInstallDrivers.Visible = false;
            // 
            // lblInstallDrivers
            // 
            this.lblInstallDrivers.Location = new System.Drawing.Point(134, 51);
            this.lblInstallDrivers.Name = "lblInstallDrivers";
            this.lblInstallDrivers.Size = new System.Drawing.Size(188, 13);
            this.lblInstallDrivers.TabIndex = 7;
            this.lblInstallDrivers.Text = "Click on Drivers Button to install Drivers";
            this.lblInstallDrivers.Visible = false;
            // 
            // btnDemo
            // 
            this.btnDemo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDemo.Location = new System.Drawing.Point(345, 122);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(56, 23);
            this.btnDemo.TabIndex = 8;
            this.btnDemo.Text = "Demo";
            this.btnDemo.Visible = false;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(134, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Click on Demo";
            this.label1.Visible = false;
            // 
            // frmHasp
            // 
            this.AcceptButton = this.btnTryAgain;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(413, 152);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDemo);
            this.Controls.Add(this.lblInstallDrivers);
            this.Controls.Add(this.btnInstallDrivers);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.pbDngImg);
            this.Controls.Add(this.lblPlz);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTryAgain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHasp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dongle Detection";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHasp_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbDngImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnTryAgain;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.LabelControl lblPlz;
        private System.Windows.Forms.PictureBox pbDngImg;
        private DevExpress.XtraEditors.LabelControl lblExit;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.SimpleButton btnInstallDrivers;
        private DevExpress.XtraEditors.LabelControl lblInstallDrivers;
        private DevExpress.XtraEditors.SimpleButton btnDemo;
        private DevExpress.XtraEditors.LabelControl label1;
    }
}