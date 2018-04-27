namespace Iadeptmain.Mainforms
{
    partial class frmRestore
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
            this.btnDBRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblNewDB = new DevExpress.XtraEditors.LabelControl();
            this.txtNewDBName = new DevExpress.XtraEditors.TextEdit();
            this.txtDBName = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.dbRestoreProgbar = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewDBName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBName.Properties)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDBRestore
            // 
            this.btnDBRestore.Location = new System.Drawing.Point(73, 101);
            this.btnDBRestore.Name = "btnDBRestore";
            this.btnDBRestore.Size = new System.Drawing.Size(69, 25);
            this.btnDBRestore.TabIndex = 11;
            this.btnDBRestore.Text = "Restore";
            this.btnDBRestore.Click += new System.EventHandler(this.btnDBRestore_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(161, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 25);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblNewDB
            // 
            this.lblNewDB.Location = new System.Drawing.Point(184, 75);
            this.lblNewDB.Name = "lblNewDB";
            this.lblNewDB.Size = new System.Drawing.Size(105, 13);
            this.lblNewDB.TabIndex = 13;
            this.lblNewDB.Text = "Enter DataBase Name";
            // 
            // txtNewDBName
            // 
            this.txtNewDBName.Location = new System.Drawing.Point(30, 68);
            this.txtNewDBName.Name = "txtNewDBName";
            this.txtNewDBName.Size = new System.Drawing.Size(144, 20);
            this.txtNewDBName.TabIndex = 14;
            this.txtNewDBName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewDBName_KeyPress);
            // 
            // txtDBName
            // 
            this.txtDBName.Enabled = false;
            this.txtDBName.Location = new System.Drawing.Point(30, 35);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(144, 20);
            this.txtDBName.TabIndex = 15;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(184, 32);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(37, 25);
            this.simpleButton1.TabIndex = 16;
            this.simpleButton1.Text = "........";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusBar,
            this.dbRestoreProgbar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 136);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(309, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(164, 17);
            this.lblStatusBar.Text = "Database Creation In Progress";
            // 
            // dbRestoreProgbar
            // 
            this.dbRestoreProgbar.Name = "dbRestoreProgbar";
            this.dbRestoreProgbar.Size = new System.Drawing.Size(100, 16);
            // 
            // frmRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 158);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.txtNewDBName);
            this.Controls.Add(this.lblNewDB);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDBRestore);
            this.Name = "frmRestore";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataBase Restore";
            ((System.ComponentModel.ISupportInitialize)(this.txtNewDBName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBName.Properties)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDBRestore;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblNewDB;
        private DevExpress.XtraEditors.TextEdit txtNewDBName;
        private DevExpress.XtraEditors.TextEdit txtDBName;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
        private System.Windows.Forms.ToolStripProgressBar dbRestoreProgbar;
    }
}