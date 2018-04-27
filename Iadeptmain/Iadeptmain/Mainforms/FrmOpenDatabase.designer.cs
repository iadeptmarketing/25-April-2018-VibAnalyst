namespace Iadeptmain.Mainforms
{
    partial class FrmOpenDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpenDatabase));
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbInstName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbMySqlFilll = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnopen = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMySqlFilll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select Instrument";
            // 
            // cmbInstName
            // 
            this.cmbInstName.Location = new System.Drawing.Point(109, 15);
            this.cmbInstName.Name = "cmbInstName";
            this.cmbInstName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInstName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbInstName.Size = new System.Drawing.Size(148, 20);
            this.cmbInstName.TabIndex = 8;
            // 
            // cmbMySqlFilll
            // 
            this.cmbMySqlFilll.Location = new System.Drawing.Point(109, 50);
            this.cmbMySqlFilll.Name = "cmbMySqlFilll";
            this.cmbMySqlFilll.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMySqlFilll.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbMySqlFilll.Size = new System.Drawing.Size(148, 20);
            this.cmbMySqlFilll.TabIndex = 7;
            // 
            // btnopen
            // 
            this.btnopen.Location = new System.Drawing.Point(262, 49);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(43, 23);
            this.btnopen.TabIndex = 6;
            this.btnopen.Text = "Open";
            this.btnopen.Click += new System.EventHandler(this.btnopen_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Existing Databases";
            // 
            // FrmOpenDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 87);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbInstName);
            this.Controls.Add(this.cmbMySqlFilll);
            this.Controls.Add(this.btnopen);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOpenDatabase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open Database";
            this.Load += new System.EventHandler(this.FrmOpenDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbInstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMySqlFilll.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbInstName;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMySqlFilll;
        private DevExpress.XtraEditors.SimpleButton btnopen;
        private DevExpress.XtraEditors.LabelControl label1;
    }
}