namespace Iadeptmain.Mainforms
{
    partial class frmUpload
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
            this.grpupload = new DevExpress.XtraEditors.GroupControl();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.textBox2 = new DevExpress.XtraEditors.TextEdit();
            this.textBox1 = new DevExpress.XtraEditors.TextEdit();
            this.rbPC = new System.Windows.Forms.RadioButton();
            this.rbInst = new System.Windows.Forms.RadioButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpupload)).BeginInit();
            this.grpupload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpupload
            // 
            this.grpupload.Controls.Add(this.btnBrowse);
            this.grpupload.Controls.Add(this.textBox2);
            this.grpupload.Controls.Add(this.textBox1);
            this.grpupload.Controls.Add(this.rbPC);
            this.grpupload.Controls.Add(this.rbInst);
            this.grpupload.Controls.Add(this.btnOK);
            this.grpupload.Controls.Add(this.btnCancel);
            this.grpupload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpupload.Location = new System.Drawing.Point(0, 0);
            this.grpupload.Name = "grpupload";
            this.grpupload.Size = new System.Drawing.Size(427, 178);
            this.grpupload.TabIndex = 0;
            this.grpupload.Text = "Upload";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(361, 114);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(57, 21);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // textBox2
            // 
            this.textBox2.EditValue = "c:\\database.sdf";
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(10, 114);
            this.textBox2.Name = "textBox2";
            this.textBox2.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Properties.Appearance.Options.UseBackColor = true;
            this.textBox2.Size = new System.Drawing.Size(340, 20);
            this.textBox2.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.EditValue = "\\Storage Card\\[Instrument Name]\\DataCollector\\Data\\[RouteName].sdf";
            this.textBox1.Location = new System.Drawing.Point(10, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Properties.Appearance.Options.UseBackColor = true;
            this.textBox1.Properties.Appearance.Options.UseFont = true;
            this.textBox1.Properties.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(340, 20);
            this.textBox1.TabIndex = 9;
            // 
            // rbPC
            // 
            this.rbPC.AutoSize = true;
            this.rbPC.Location = new System.Drawing.Point(10, 91);
            this.rbPC.Name = "rbPC";
            this.rbPC.Size = new System.Drawing.Size(38, 17);
            this.rbPC.TabIndex = 6;
            this.rbPC.Text = "PC";
            this.rbPC.UseVisualStyleBackColor = true;
            // 
            // rbInst
            // 
            this.rbInst.AutoSize = true;
            this.rbInst.Checked = true;
            this.rbInst.Location = new System.Drawing.Point(10, 29);
            this.rbInst.Name = "rbInst";
            this.rbInst.Size = new System.Drawing.Size(78, 17);
            this.rbInst.TabIndex = 7;
            this.rbInst.TabStop = true;
            this.rbInst.Text = "Instrument";
            this.rbInst.UseVisualStyleBackColor = true;
            this.rbInst.CheckedChanged += new System.EventHandler(this.rbInst_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(231, 150);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(57, 21);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(307, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 21);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 178);
            this.ControlBox = false;
            this.Controls.Add(this.grpupload);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpload";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmUpload_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpupload)).EndInit();
            this.grpupload.ResumeLayout(false);
            this.grpupload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpupload;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.TextEdit textBox2;
        private System.Windows.Forms.RadioButton rbPC;
        private System.Windows.Forms.RadioButton rbInst;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        public DevExpress.XtraEditors.TextEdit textBox1;

    }
}