namespace Iadeptmain.Mainforms
{
    partial class frmFailure
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
            this.cmbVibrationUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtLevel = new DevExpress.XtraEditors.TextEdit();
            this.cmbPattern = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbMachineClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblPattern = new DevExpress.XtraEditors.LabelControl();
            this.llLevel = new DevExpress.XtraEditors.LabelControl();
            this.lblMachineClass = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVibrationUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPattern.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMachineClass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbVibrationUnit
            // 
            this.cmbVibrationUnit.EditValue = "--Select Unit--";
            this.cmbVibrationUnit.Location = new System.Drawing.Point(368, 110);
            this.cmbVibrationUnit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbVibrationUnit.Name = "cmbVibrationUnit";
            this.cmbVibrationUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbVibrationUnit.Properties.Items.AddRange(new object[] {
            "Gs",
            "m/sec2",
            "inch/sec",
            "mm/sec",
            "mil",
            "um"});
            this.cmbVibrationUnit.Size = new System.Drawing.Size(124, 22);
            this.cmbVibrationUnit.TabIndex = 3;
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(273, 110);
            this.txtLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(71, 22);
            this.txtLevel.TabIndex = 2;
            // 
            // cmbPattern
            // 
            this.cmbPattern.EditValue = "--Select Pattern--";
            this.cmbPattern.Location = new System.Drawing.Point(274, 26);
            this.cmbPattern.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPattern.Name = "cmbPattern";
            this.cmbPattern.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPattern.Properties.Items.AddRange(new object[] {
            "ISO Pattern",
            "Customized Pattern"});
            this.cmbPattern.Size = new System.Drawing.Size(218, 22);
            this.cmbPattern.TabIndex = 0;
            // 
            // cmbMachineClass
            // 
            this.cmbMachineClass.EditValue = "--Select Class--";
            this.cmbMachineClass.Location = new System.Drawing.Point(273, 68);
            this.cmbMachineClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMachineClass.Name = "cmbMachineClass";
            this.cmbMachineClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMachineClass.Properties.Items.AddRange(new object[] {
            "Class 1",
            "Class 2",
            "Class 3",
            "Class 4"});
            this.cmbMachineClass.Size = new System.Drawing.Size(218, 22);
            this.cmbMachineClass.TabIndex = 1;
            this.cmbMachineClass.EditValueChanged += new System.EventHandler(this.cmbMachineClass_EditValueChanged);
            // 
            // lblPattern
            // 
            this.lblPattern.Appearance.Font = new System.Drawing.Font("Cambria", 11F);
            this.lblPattern.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPattern.Location = new System.Drawing.Point(41, 26);
            this.lblPattern.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(197, 21);
            this.lblPattern.TabIndex = 1;
            this.lblPattern.Text = "Choose Base Line Pattern";
            // 
            // llLevel
            // 
            this.llLevel.Appearance.Font = new System.Drawing.Font("Cambria", 11F);
            this.llLevel.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.llLevel.Location = new System.Drawing.Point(41, 110);
            this.llLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.llLevel.Name = "llLevel";
            this.llLevel.Size = new System.Drawing.Size(119, 21);
            this.llLevel.TabIndex = 2;
            this.llLevel.Text = "Vibration Level";
            // 
            // lblMachineClass
            // 
            this.lblMachineClass.Appearance.Font = new System.Drawing.Font("Cambria", 11F);
            this.lblMachineClass.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMachineClass.Location = new System.Drawing.Point(41, 68);
            this.lblMachineClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblMachineClass.Name = "lblMachineClass";
            this.lblMachineClass.Size = new System.Drawing.Size(110, 21);
            this.lblMachineClass.TabIndex = 0;
            this.lblMachineClass.Text = "Machine Class";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(273, 164);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 36);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.Appearance.Options.UseFont = true;
            this.btnSubmit.Location = new System.Drawing.Point(92, 164);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(132, 36);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Calculate";
            // 
            // frmFailure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(527, 219);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cmbVibrationUnit);
            this.Controls.Add(this.lblMachineClass);
            this.Controls.Add(this.lblPattern);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.cmbMachineClass);
            this.Controls.Add(this.llLevel);
            this.Controls.Add(this.cmbPattern);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmFailure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Failure TIme Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.cmbVibrationUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPattern.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMachineClass.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cmbVibrationUnit;
        private DevExpress.XtraEditors.TextEdit txtLevel;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPattern;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMachineClass;
        private DevExpress.XtraEditors.LabelControl lblPattern;
        private DevExpress.XtraEditors.LabelControl llLevel;
        private DevExpress.XtraEditors.LabelControl lblMachineClass;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;
    }
}