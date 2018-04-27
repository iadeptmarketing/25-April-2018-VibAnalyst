namespace Iadeptmain.Mainforms
{
    partial class SideBandValue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SideBandValue));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.tbBandValue = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbpole = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtActspeed = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBandValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbpole.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActspeed.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Percentage";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 77);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(108, 77);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbBandValue
            // 
            this.tbBandValue.Location = new System.Drawing.Point(83, 31);
            this.tbBandValue.Name = "tbBandValue";
            this.tbBandValue.Properties.MaxLength = 5;
            this.tbBandValue.Size = new System.Drawing.Size(77, 20);
            this.tbBandValue.TabIndex = 4;
            this.tbBandValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbBandValue_KeyUp);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(166, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "%";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(20, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Pole";
            this.labelControl2.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 45);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Actual Speed";
            this.labelControl3.Visible = false;
            // 
            // cmbpole
            // 
            this.cmbpole.Location = new System.Drawing.Point(83, 10);
            this.cmbpole.Name = "cmbpole";
            this.cmbpole.Properties.AllowFocused = false;
            this.cmbpole.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbpole.Properties.Appearance.Options.UseBackColor = true;
            this.cmbpole.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbpole.Properties.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8"});
            this.cmbpole.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbpole.Size = new System.Drawing.Size(72, 20);
            this.cmbpole.TabIndex = 8;
            this.cmbpole.Visible = false;
            // 
            // txtActspeed
            // 
            this.txtActspeed.Location = new System.Drawing.Point(83, 42);
            this.txtActspeed.Name = "txtActspeed";
            this.txtActspeed.Properties.MaxLength = 5;
            this.txtActspeed.Size = new System.Drawing.Size(72, 20);
            this.txtActspeed.TabIndex = 9;
            this.txtActspeed.Visible = false;
            // 
            // SideBandValue
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(185, 102);
            this.ControlBox = false;
            this.Controls.Add(this.txtActspeed);
            this.Controls.Add(this.cmbpole);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBandValue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SideBandValue";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SideBandValue";
            this.Shown += new System.EventHandler(this.SideBandValue_Shown_1);
            ((System.ComponentModel.ISupportInitialize)(this.tbBandValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbpole.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtActspeed.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit tbBandValue;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbpole;
        private DevExpress.XtraEditors.TextEdit txtActspeed;
    }
}