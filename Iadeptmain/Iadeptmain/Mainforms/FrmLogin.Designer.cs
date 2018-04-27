namespace Iadeptmain.Mainforms
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.grpLogin = new DevExpress.XtraEditors.GroupControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btncancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmbdata = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpLogin)).BeginInit();
            this.grpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdata.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
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
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.label1);
            this.grpLogin.Controls.Add(this.btncancel);
            this.grpLogin.Controls.Add(this.cmbdata);
            this.grpLogin.Controls.Add(this.labelControl3);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.txtID);
            this.grpLogin.Controls.Add(this.labelControl2);
            this.grpLogin.Controls.Add(this.labelControl1);
            this.grpLogin.Location = new System.Drawing.Point(0, 0);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(355, 176);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.Text = "Login Details";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(137, 145);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "OK";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Enter Valid Login ID and Password";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(217, 144);
            this.btncancel.LookAndFeel.SkinName = "Blue";
            this.btncancel.Margin = new System.Windows.Forms.Padding(2);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(71, 24);
            this.btncancel.TabIndex = 5;
            this.btncancel.Text = "Cancel";
            this.btncancel.Click += new System.EventHandler(this.simpleButton1_Click);
            this.btncancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            // 
            // cmbdata
            // 
            this.cmbdata.AllowDrop = true;
            this.cmbdata.EditValue = "My SQL";
            this.cmbdata.Enabled = false;
            this.cmbdata.Location = new System.Drawing.Point(140, 111);
            this.cmbdata.Name = "cmbdata";
            this.cmbdata.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbdata.Properties.Appearance.Options.UseBackColor = true;
            this.cmbdata.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cmbdata.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbdata.Properties.Items.AddRange(new object[] {
            "--Select--",
            "Sql Server",
            "My SQL"});
            this.cmbdata.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbdata.Size = new System.Drawing.Size(148, 22);
            this.cmbdata.TabIndex = 3;
            this.cmbdata.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl3.Location = new System.Drawing.Point(33, 114);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Database";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(140, 85);
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
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(148, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Location = new System.Drawing.Point(140, 58);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtID.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtID.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            this.txtID.Properties.Appearance.Options.UseBackColor = true;
            this.txtID.Properties.Appearance.Options.UseBorderColor = true;
            this.txtID.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Transparent;
            this.txtID.Properties.AppearanceFocused.BackColor2 = System.Drawing.Color.Red;
            this.txtID.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.txtID.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtID.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtID.Properties.LookAndFeel.SkinName = "Blue";
            this.txtID.Size = new System.Drawing.Size(148, 20);
            this.txtID.TabIndex = 1;
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl2.Location = new System.Drawing.Point(33, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Password";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Location = new System.Drawing.Point(33, 60);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Login ID";
            // 
            // FrmLogin
            // 
            this.Appearance.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Appearance.BackColor2 = System.Drawing.Color.Aqua;
            this.Appearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 176);
            this.ControlBox = false;
            this.Controls.Add(this.grpLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Glass Oceans";
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Form";
            this.TransparencyKey = System.Drawing.Color.SpringGreen;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grpLogin)).EndInit();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdata.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpLogin;
        private DevExpress.XtraEditors.ComboBoxEdit cmbdata;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btncancel;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
    }
}