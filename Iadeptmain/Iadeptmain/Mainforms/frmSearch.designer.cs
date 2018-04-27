namespace Iadeptmain.Mainforms
{
    partial class frmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox10 = new DevExpress.XtraEditors.GroupControl();
            this.rbtnDescription = new System.Windows.Forms.RadioButton();
            this.rbtnID = new System.Windows.Forms.RadioButton();
            this.lblField = new DevExpress.XtraEditors.LabelControl();
            this.cmbField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox9 = new DevExpress.XtraEditors.GroupControl();
            this.lblFind = new DevExpress.XtraEditors.LabelControl();
            this.txtFind = new DevExpress.XtraEditors.TextEdit();
            this.chkfind = new DevExpress.XtraEditors.CheckEdit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox10)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox9)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkfind.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnClose);
            this.pnlSearch.Controls.Add(this.groupBox10);
            this.pnlSearch.Controls.Add(this.btnFind);
            this.pnlSearch.Controls.Add(this.groupBox9);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(214, 158);
            this.pnlSearch.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(125, 126);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.rbtnDescription);
            this.groupBox10.Controls.Add(this.rbtnID);
            this.groupBox10.Controls.Add(this.lblField);
            this.groupBox10.Controls.Add(this.cmbField);
            this.groupBox10.Location = new System.Drawing.Point(3, -3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(196, 61);
            this.groupBox10.TabIndex = 87;
            // 
            // rbtnDescription
            // 
            this.rbtnDescription.AutoSize = true;
            this.rbtnDescription.Location = new System.Drawing.Point(106, 38);
            this.rbtnDescription.Name = "rbtnDescription";
            this.rbtnDescription.Size = new System.Drawing.Size(78, 17);
            this.rbtnDescription.TabIndex = 62;
            this.rbtnDescription.TabStop = true;
            this.rbtnDescription.Text = "Description";
            this.rbtnDescription.UseVisualStyleBackColor = true;
            this.rbtnDescription.Visible = false;
            // 
            // rbtnID
            // 
            this.rbtnID.AutoSize = true;
            this.rbtnID.Location = new System.Drawing.Point(22, 38);
            this.rbtnID.Name = "rbtnID";
            this.rbtnID.Size = new System.Drawing.Size(36, 17);
            this.rbtnID.TabIndex = 61;
            this.rbtnID.TabStop = true;
            this.rbtnID.Text = "ID";
            this.rbtnID.UseVisualStyleBackColor = true;
            this.rbtnID.Visible = false;
            // 
            // lblField
            // 
            this.lblField.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblField.Location = new System.Drawing.Point(4, 29);
            this.lblField.Name = "lblField";
            this.lblField.Size = new System.Drawing.Size(24, 13);
            this.lblField.TabIndex = 45;
            this.lblField.Text = "Type";
            // 
            // cmbField
            // 
            this.cmbField.Location = new System.Drawing.Point(64, 23);
            this.cmbField.Name = "cmbField";
            this.cmbField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbField.Properties.Items.AddRange(new object[] {
            "Factory",
            "Area",
            "Train",
            "Machine",
            "Point"});
            this.cmbField.Size = new System.Drawing.Size(127, 20);
            this.cmbField.TabIndex = 1;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(44, 126);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Search";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lblFind);
            this.groupBox9.Controls.Add(this.txtFind);
            this.groupBox9.Controls.Add(this.chkfind);
            this.groupBox9.Location = new System.Drawing.Point(3, 59);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(196, 61);
            this.groupBox9.TabIndex = 88;
            // 
            // lblFind
            // 
            this.lblFind.Location = new System.Drawing.Point(2, 26);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(33, 13);
            this.lblFind.TabIndex = 49;
            this.lblFind.Text = "Search";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(62, 23);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(127, 20);
            this.txtFind.TabIndex = 2;
            // 
            // chkfind
            // 
            this.chkfind.Location = new System.Drawing.Point(139, 38);
            this.chkfind.Name = "chkfind";
            this.chkfind.Properties.Caption = "Case";
            this.chkfind.Size = new System.Drawing.Size(50, 19);
            this.chkfind.TabIndex = 48;
            this.chkfind.Visible = false;
            // 
            // frmSearch
            // 
            this.AcceptButton = this.btnFind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(214, 158);
            this.Controls.Add(this.pnlSearch);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFind_FormClosing);
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox10)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox9)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkfind.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.GroupControl groupBox10;
        private System.Windows.Forms.RadioButton rbtnDescription;
        private System.Windows.Forms.RadioButton rbtnID;
        private DevExpress.XtraEditors.LabelControl lblField;
        private DevExpress.XtraEditors.ComboBoxEdit cmbField;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraEditors.GroupControl groupBox9;
        private DevExpress.XtraEditors.LabelControl lblFind;
        private DevExpress.XtraEditors.TextEdit txtFind;
        private DevExpress.XtraEditors.CheckEdit chkfind;
    }
}