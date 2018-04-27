namespace Iadeptmain.Mainforms
{
    partial class frmDeleteDatabase
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
            this.lblDataBase = new DevExpress.XtraEditors.LabelControl();
            this.cmbExtDatabase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbExtDatabase.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDataBase
            // 
            this.lblDataBase.Location = new System.Drawing.Point(12, 28);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(91, 13);
            this.lblDataBase.TabIndex = 6;
            this.lblDataBase.Text = "Existing Databases";
            // 
            // cmbExtDatabase
            // 
            this.cmbExtDatabase.Location = new System.Drawing.Point(140, 25);
            this.cmbExtDatabase.Name = "cmbExtDatabase";
            this.cmbExtDatabase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbExtDatabase.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbExtDatabase.Size = new System.Drawing.Size(148, 20);
            this.cmbExtDatabase.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(222, 57);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmDeleteDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 87);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cmbExtDatabase);
            this.Controls.Add(this.lblDataBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeleteDatabase";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Database";
            ((System.ComponentModel.ISupportInitialize)(this.cmbExtDatabase.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblDataBase;
        private DevExpress.XtraEditors.ComboBoxEdit cmbExtDatabase;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}