namespace Iadeptmain.Mainforms
{
    partial class frmUserEntry
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
            this.grpLogin = new DevExpress.XtraEditors.GroupControl();
            this.cmbDataBase = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblDataBase = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUsrName = new DevExpress.XtraEditors.TextEdit();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblUName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpLogin)).BeginInit();
            this.grpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsrName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLogin
            // 
            this.grpLogin.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpLogin.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grpLogin.Appearance.Options.UseBackColor = true;
            this.grpLogin.AppearanceCaption.BackColor = System.Drawing.Color.Gray;
            this.grpLogin.AppearanceCaption.BackColor2 = System.Drawing.Color.Salmon;
            this.grpLogin.AppearanceCaption.Options.UseBackColor = true;
            this.grpLogin.Controls.Add(this.cmbDataBase);
            this.grpLogin.Controls.Add(this.btnOk);
            this.grpLogin.Controls.Add(this.label1);
            this.grpLogin.Controls.Add(this.btnCancel);
            this.grpLogin.Controls.Add(this.lblDataBase);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.txtUsrName);
            this.grpLogin.Controls.Add(this.lblPassword);
            this.grpLogin.Controls.Add(this.lblUName);
            this.grpLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLogin.Location = new System.Drawing.Point(0, 0);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(364, 185);
            this.grpLogin.TabIndex = 1;
            this.grpLogin.Text = "User Detail";
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.Enabled = false;
            this.cmbDataBase.Location = new System.Drawing.Point(144, 116);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDataBase.Size = new System.Drawing.Size(148, 20);
            this.cmbDataBase.TabIndex = 14;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(144, 143);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Please Enter the new user Detail";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(224, 142);
            this.btnCancel.LookAndFeel.SkinName = "Blue";
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDataBase
            // 
            this.lblDataBase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataBase.Location = new System.Drawing.Point(38, 119);
            this.lblDataBase.Name = "lblDataBase";
            this.lblDataBase.Size = new System.Drawing.Size(46, 13);
            this.lblDataBase.TabIndex = 12;
            this.lblDataBase.Text = "Database";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(144, 89);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            this.txtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txtPassword.Properties.Appearance.Options.UseBorderColor = true;
            this.txtPassword.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Red;
            this.txtPassword.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtPassword.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtPassword.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtPassword.Properties.LookAndFeel.SkinName = "Blue";
            this.txtPassword.Size = new System.Drawing.Size(148, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUsrName
            // 
            this.txtUsrName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsrName.Location = new System.Drawing.Point(144, 62);
            this.txtUsrName.Name = "txtUsrName";
            this.txtUsrName.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtUsrName.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtUsrName.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            this.txtUsrName.Properties.Appearance.Options.UseBackColor = true;
            this.txtUsrName.Properties.Appearance.Options.UseBorderColor = true;
            this.txtUsrName.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Transparent;
            this.txtUsrName.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Red;
            this.txtUsrName.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtUsrName.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtUsrName.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtUsrName.Properties.LookAndFeel.SkinName = "Blue";
            this.txtUsrName.Size = new System.Drawing.Size(148, 20);
            this.txtUsrName.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.Location = new System.Drawing.Point(38, 93);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(46, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password";
            // 
            // lblUName
            // 
            this.lblUName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUName.Location = new System.Drawing.Point(38, 65);
            this.lblUName.Name = "lblUName";
            this.lblUName.Size = new System.Drawing.Size(51, 13);
            this.lblUName.TabIndex = 6;
            this.lblUName.Text = "User name";
            // 
            // frmUserEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 185);
            this.Controls.Add(this.grpLogin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserEntry";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmUserEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpLogin)).EndInit();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsrName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOk;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsrName;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.LabelControl lblUName;
        public DevExpress.XtraEditors.LabelControl lblDataBase;
        public DevExpress.XtraEditors.ComboBoxEdit cmbDataBase;
        public DevExpress.XtraEditors.GroupControl grpLogin;
    }
}