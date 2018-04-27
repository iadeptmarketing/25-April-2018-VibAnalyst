namespace Iadeptmain.Mainforms
{
    partial class frmFailureTime
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
            this.lblMachineClass = new DevExpress.XtraEditors.LabelControl();
            this.lblPattern = new DevExpress.XtraEditors.LabelControl();
            this.llLevel = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbVibrationUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSubmit = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.txtLevel = new DevExpress.XtraEditors.TextEdit();
            this.cmbPattern = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbMachineClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVibrationUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPattern.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMachineClass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMachineClass
            // 
            this.lblMachineClass.Appearance.Font = new System.Drawing.Font("Cambria", 10F);
            this.lblMachineClass.Location = new System.Drawing.Point(29, 26);
            this.lblMachineClass.Name = "lblMachineClass";
            this.lblMachineClass.Size = new System.Drawing.Size(102, 20);
            this.lblMachineClass.TabIndex = 0;
            this.lblMachineClass.Text = "Machine Class";
            // 
            // lblPattern
            // 
            this.lblPattern.Appearance.Font = new System.Drawing.Font("Cambria", 10F);
            this.lblPattern.Location = new System.Drawing.Point(29, 59);
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(182, 20);
            this.lblPattern.TabIndex = 1;
            this.lblPattern.Text = "Choose Base Line Pattern";
            // 
            // llLevel
            // 
            this.llLevel.Appearance.Font = new System.Drawing.Font("Cambria", 10F);
            this.llLevel.Location = new System.Drawing.Point(29, 89);
            this.llLevel.Name = "llLevel";
            this.llLevel.Size = new System.Drawing.Size(111, 20);
            this.llLevel.TabIndex = 2;
            this.llLevel.Text = "Vibration Level";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cmbVibrationUnit);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.txtLevel);
            this.groupBox1.Controls.Add(this.cmbPattern);
            this.groupBox1.Controls.Add(this.cmbMachineClass);
            this.groupBox1.Controls.Add(this.lblPattern);
            this.groupBox1.Controls.Add(this.llLevel);
            this.groupBox1.Controls.Add(this.lblMachineClass);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 169);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // cmbVibrationUnit
            // 
            this.cmbVibrationUnit.EditValue = "--Select Unit--";
            this.cmbVibrationUnit.Location = new System.Drawing.Point(283, 89);
            this.cmbVibrationUnit.Name = "cmbVibrationUnit";
            this.cmbVibrationUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbVibrationUnit.Properties.Items.AddRange(new object[] {
            "ISO Pattern",
            "Customized Pattern"});
            this.cmbVibrationUnit.Size = new System.Drawing.Size(108, 22);
            this.cmbVibrationUnit.TabIndex = 11;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.Appearance.Options.UseFont = true;
            this.btnSubmit.Location = new System.Drawing.Point(87, 125);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(115, 33);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Calculate";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(216, 125);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 33);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(216, 89);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(62, 22);
            this.txtLevel.TabIndex = 10;
            // 
            // cmbPattern
            // 
            this.cmbPattern.EditValue = "--Select Pattern--";
            this.cmbPattern.Location = new System.Drawing.Point(216, 59);
            this.cmbPattern.Name = "cmbPattern";
            this.cmbPattern.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPattern.Properties.Items.AddRange(new object[] {
            "ISO Pattern",
            "Customized Pattern"});
            this.cmbPattern.Size = new System.Drawing.Size(175, 22);
            this.cmbPattern.TabIndex = 6;
            // 
            // cmbMachineClass
            // 
            this.cmbMachineClass.EditValue = "--Select Class--";
            this.cmbMachineClass.Location = new System.Drawing.Point(216, 26);
            this.cmbMachineClass.Name = "cmbMachineClass";
            this.cmbMachineClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMachineClass.Properties.Items.AddRange(new object[] {
            "Class 1",
            "Class 2",
            "Class 3",
            "Class 4"});
            this.cmbMachineClass.Size = new System.Drawing.Size(175, 22);
            this.cmbMachineClass.TabIndex = 5;
            // 
            // frmFailureTime
            // 
            this.Appearance.Font = new System.Drawing.Font("Cambria", 8F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 169);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFailureTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Failure Time Prediction";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVibrationUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPattern.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMachineClass.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblMachineClass;
        private DevExpress.XtraEditors.LabelControl lblPattern;
        private DevExpress.XtraEditors.LabelControl llLevel;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtLevel;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSubmit;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPattern;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMachineClass;
        private DevExpress.XtraEditors.ComboBoxEdit cmbVibrationUnit;
    }
}