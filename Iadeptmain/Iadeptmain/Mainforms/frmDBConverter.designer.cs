namespace Iadeptmain.Mainforms
{
    partial class frmDBConverter
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
            this.lblInstrument = new DevExpress.XtraEditors.LabelControl();
            this.lblOldDB = new DevExpress.XtraEditors.LabelControl();
            this.lblNewDB = new DevExpress.XtraEditors.LabelControl();
            this.cmnInstrument = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbOldDB = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtNewDB = new DevExpress.XtraEditors.TextEdit();
            this.btnConvert = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.dbConverProgbar = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.cmnInstrument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOldDB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewDB.Properties)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInstrument
            // 
            this.lblInstrument.Location = new System.Drawing.Point(24, 28);
            this.lblInstrument.Name = "lblInstrument";
            this.lblInstrument.Size = new System.Drawing.Size(83, 13);
            this.lblInstrument.TabIndex = 0;
            this.lblInstrument.Text = "Instrument Name";
            // 
            // lblOldDB
            // 
            this.lblOldDB.Location = new System.Drawing.Point(24, 58);
            this.lblOldDB.Name = "lblOldDB";
            this.lblOldDB.Size = new System.Drawing.Size(97, 13);
            this.lblOldDB.TabIndex = 1;
            this.lblOldDB.Text = "Select Old DataBase";
            // 
            // lblNewDB
            // 
            this.lblNewDB.Location = new System.Drawing.Point(24, 88);
            this.lblNewDB.Name = "lblNewDB";
            this.lblNewDB.Size = new System.Drawing.Size(100, 13);
            this.lblNewDB.TabIndex = 2;
            this.lblNewDB.Text = "New DataBase Name";
            // 
            // cmnInstrument
            // 
            this.cmnInstrument.Enabled = false;
            this.cmnInstrument.Location = new System.Drawing.Point(135, 25);
            this.cmnInstrument.Name = "cmnInstrument";
            this.cmnInstrument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmnInstrument.Size = new System.Drawing.Size(135, 20);
            this.cmnInstrument.TabIndex = 3;
            this.cmnInstrument.SelectedIndexChanged += new System.EventHandler(this.cmnInstrument_SelectedIndexChanged);
            // 
            // cmbOldDB
            // 
            this.cmbOldDB.Location = new System.Drawing.Point(135, 55);
            this.cmbOldDB.Name = "cmbOldDB";
            this.cmbOldDB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOldDB.Size = new System.Drawing.Size(135, 20);
            this.cmbOldDB.TabIndex = 4;
            // 
            // txtNewDB
            // 
            this.txtNewDB.Location = new System.Drawing.Point(135, 85);
            this.txtNewDB.Name = "txtNewDB";
            this.txtNewDB.Size = new System.Drawing.Size(135, 20);
            this.txtNewDB.TabIndex = 5;
            this.txtNewDB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNewDB_KeyPress);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(54, 112);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(85, 25);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Convert";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(161, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusBar,
            this.dbConverProgbar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 139);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(307, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(179, 17);
            this.lblStatusBar.Text = "Database Conversion In Progress";
            this.lblStatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dbConverProgbar
            // 
            this.dbConverProgbar.Name = "dbConverProgbar";
            this.dbConverProgbar.Size = new System.Drawing.Size(100, 16);
            // 
            // frmDBConverter
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 161);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtNewDB);
            this.Controls.Add(this.cmbOldDB);
            this.Controls.Add(this.cmnInstrument);
            this.Controls.Add(this.lblNewDB);
            this.Controls.Add(this.lblOldDB);
            this.Controls.Add(this.lblInstrument);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDBConverter";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataBase Conversion";
            ((System.ComponentModel.ISupportInitialize)(this.cmnInstrument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOldDB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewDB.Properties)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblInstrument;
        private DevExpress.XtraEditors.LabelControl lblOldDB;
        private DevExpress.XtraEditors.LabelControl lblNewDB;
        private DevExpress.XtraEditors.ComboBoxEdit cmnInstrument;
        private DevExpress.XtraEditors.ComboBoxEdit cmbOldDB;
        private DevExpress.XtraEditors.TextEdit txtNewDB;
        private DevExpress.XtraEditors.SimpleButton btnConvert;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
        private System.Windows.Forms.ToolStripProgressBar dbConverProgbar;
    }
}