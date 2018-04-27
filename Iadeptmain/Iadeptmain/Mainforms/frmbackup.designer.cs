namespace Iadeptmain.Mainforms
{
    partial class frmbackup
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnbackup = new DevExpress.XtraEditors.SimpleButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.bkpProBar = new System.Windows.Forms.ToolStripProgressBar();
            this.txtdate = new DevExpress.XtraEditors.TextEdit();
            this.cmbdata = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdata.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnbackup);
            this.panelControl1.Controls.Add(this.statusStrip1);
            this.panelControl1.Controls.Add(this.txtdate);
            this.panelControl1.Controls.Add(this.cmbdata);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(370, 104);
            this.panelControl1.TabIndex = 0;
            // 
            // btnbackup
            // 
            this.btnbackup.Location = new System.Drawing.Point(296, 47);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(69, 25);
            this.btnbackup.TabIndex = 10;
            this.btnbackup.Text = "Back Up";
            this.btnbackup.Click += new System.EventHandler(this.btnbackup_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusBar,
            this.bkpProBar});
            this.statusStrip1.Location = new System.Drawing.Point(2, 80);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(366, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(85, 17);
            this.lblStatusBar.Text = "Backup Pocess";
            // 
            // bkpProBar
            // 
            this.bkpProBar.Name = "bkpProBar";
            this.bkpProBar.Size = new System.Drawing.Size(175, 16);
            // 
            // txtdate
            // 
            this.txtdate.Location = new System.Drawing.Point(134, 52);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(143, 20);
            this.txtdate.TabIndex = 3;
            // 
            // cmbdata
            // 
            this.cmbdata.Location = new System.Drawing.Point(133, 22);
            this.cmbdata.Name = "cmbdata";
            this.cmbdata.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbdata.Size = new System.Drawing.Size(144, 20);
            this.cmbdata.TabIndex = 2;
            this.cmbdata.SelectedIndexChanged += new System.EventHandler(this.cmbdata_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(104, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Previous Backup Date";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Exising Database";
            // 
            // frmbackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 104);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmbackup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataBase Backup";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdata.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtdate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnbackup;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
        private System.Windows.Forms.ToolStripProgressBar bkpProBar;
        public DevExpress.XtraEditors.ComboBoxEdit cmbdata;
    }
}