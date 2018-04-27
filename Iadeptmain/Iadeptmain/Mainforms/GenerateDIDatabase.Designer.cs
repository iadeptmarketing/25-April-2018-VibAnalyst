namespace Iadeptmain.Mainforms
{
    partial class GenerateDIDatabase
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
            this.Sstrip = new System.Windows.Forms.StatusStrip();
            this.sStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtdb = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtdbpath = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.listDB = new DevExpress.XtraEditors.ListBoxControl();
            this.rbExternal = new System.Windows.Forms.RadioButton();
            this.rbPhysicalDimensions = new System.Windows.Forms.RadioButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnok = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.Sstrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdbpath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDB)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.Sstrip);
            this.panelControl1.Controls.Add(this.txtdb);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtdbpath);
            this.panelControl1.Controls.Add(this.btnBrowse);
            this.panelControl1.Controls.Add(this.btnConnect);
            this.panelControl1.Controls.Add(this.listDB);
            this.panelControl1.Controls.Add(this.rbExternal);
            this.panelControl1.Controls.Add(this.rbPhysicalDimensions);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnok);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(394, 432);
            this.panelControl1.TabIndex = 0;
            // 
            // Sstrip
            // 
            this.Sstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sStatus,
            this.Status});
            this.Sstrip.Location = new System.Drawing.Point(2, 408);
            this.Sstrip.Name = "Sstrip";
            this.Sstrip.Size = new System.Drawing.Size(390, 22);
            this.Sstrip.TabIndex = 24;
            this.Sstrip.Text = "statusStrip1";
            // 
            // sStatus
            // 
            this.sStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sStatus.Name = "sStatus";
            this.sStatus.Size = new System.Drawing.Size(45, 17);
            this.sStatus.Text = "Status :";
            // 
            // Status
            // 
            this.Status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(39, 17);
            this.Status.Text = "Ready";
            // 
            // txtdb
            // 
            this.txtdb.Location = new System.Drawing.Point(31, 348);
            this.txtdb.Name = "txtdb";
            this.txtdb.Size = new System.Drawing.Size(225, 20);
            this.txtdb.TabIndex = 23;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 325);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Enter Database Name";
            // 
            // txtdbpath
            // 
            this.txtdbpath.Location = new System.Drawing.Point(31, 288);
            this.txtdbpath.Name = "txtdbpath";
            this.txtdbpath.Properties.ReadOnly = true;
            this.txtdbpath.Size = new System.Drawing.Size(225, 20);
            this.txtdbpath.TabIndex = 21;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(293, 286);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(71, 23);
            this.btnBrowse.TabIndex = 20;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(293, 236);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(71, 23);
            this.btnConnect.TabIndex = 19;
            this.btnConnect.Text = "Connect...";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // listDB
            // 
            this.listDB.Location = new System.Drawing.Point(45, 34);
            this.listDB.Name = "listDB";
            this.listDB.Size = new System.Drawing.Size(226, 225);
            this.listDB.TabIndex = 18;
            // 
            // rbExternal
            // 
            this.rbExternal.AutoSize = true;
            this.rbExternal.Location = new System.Drawing.Point(12, 265);
            this.rbExternal.Name = "rbExternal";
            this.rbExternal.Size = new System.Drawing.Size(84, 17);
            this.rbExternal.TabIndex = 17;
            this.rbExternal.TabStop = true;
            this.rbExternal.Text = "External File";
            this.rbExternal.UseVisualStyleBackColor = true;
            this.rbExternal.CheckedChanged += new System.EventHandler(this.rbPhysicalDimensions_CheckedChanged);
            // 
            // rbPhysicalDimensions
            // 
            this.rbPhysicalDimensions.AutoSize = true;
            this.rbPhysicalDimensions.Location = new System.Drawing.Point(12, 11);
            this.rbPhysicalDimensions.Name = "rbPhysicalDimensions";
            this.rbPhysicalDimensions.Size = new System.Drawing.Size(110, 17);
            this.rbPhysicalDimensions.TabIndex = 16;
            this.rbPhysicalDimensions.TabStop = true;
            this.rbPhysicalDimensions.Text = "Instrument Route";
            this.rbPhysicalDimensions.UseVisualStyleBackColor = true;
            this.rbPhysicalDimensions.CheckedChanged += new System.EventHandler(this.rbPhysicalDimensions_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(314, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(224, 380);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(71, 23);
            this.btnok.TabIndex = 4;
            this.btnok.Text = "OK";
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // GenerateDIDatabase
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 432);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Name = "GenerateDIDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate Database";
            this.Load += new System.EventHandler(this.GenerateDIDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.Sstrip.ResumeLayout(false);
            this.Sstrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtdb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdbpath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnok;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.ListBoxControl listDB;
        private System.Windows.Forms.RadioButton rbExternal;
        private System.Windows.Forms.RadioButton rbPhysicalDimensions;
        private DevExpress.XtraEditors.TextEdit txtdb;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtdbpath;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private System.Windows.Forms.ToolStripStatusLabel sStatus;
        public System.Windows.Forms.ToolStripStatusLabel Status;
        public System.Windows.Forms.StatusStrip Sstrip;
    }
}