namespace Iadeptmain.Mainforms
{
    partial class frmDiagnosticRPM
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
            this.lblRPM = new DevExpress.XtraEditors.LabelControl();
            this.lbl = new DevExpress.XtraEditors.LabelControl();
            this.txtStdRPM = new DevExpress.XtraEditors.TextEdit();
            this.txtVariation = new DevExpress.XtraEditors.TextEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gbMachine = new DevExpress.XtraEditors.GroupControl();
            this.cmbMachineType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtStdRPM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVariation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbMachine)).BeginInit();
            this.gbMachine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMachineType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRPM
            // 
            this.lblRPM.Location = new System.Drawing.Point(25, 43);
            this.lblRPM.Name = "lblRPM";
            this.lblRPM.Size = new System.Drawing.Size(71, 13);
            this.lblRPM.TabIndex = 0;
            this.lblRPM.Text = "Standard RPM ";
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(25, 76);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(79, 13);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "Variation In RPM";
            // 
            // txtStdRPM
            // 
            this.txtStdRPM.Location = new System.Drawing.Point(123, 40);
            this.txtStdRPM.Name = "txtStdRPM";
            this.txtStdRPM.Size = new System.Drawing.Size(127, 20);
            this.txtStdRPM.TabIndex = 2;
            this.txtStdRPM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStdRPM_KeyPress);
            // 
            // txtVariation
            // 
            this.txtVariation.Location = new System.Drawing.Point(123, 73);
            this.txtVariation.Name = "txtVariation";
            this.txtVariation.Size = new System.Drawing.Size(127, 20);
            this.txtVariation.TabIndex = 3;
            this.txtVariation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStdRPM_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(123, 106);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.gbMachine);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(277, 138);
            this.groupControl1.TabIndex = 5;
            // 
            // gbMachine
            // 
            this.gbMachine.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gbMachine.Controls.Add(this.cmbMachineType);
            this.gbMachine.Controls.Add(this.labelControl1);
            this.gbMachine.Controls.Add(this.lbl);
            this.gbMachine.Controls.Add(this.lblRPM);
            this.gbMachine.Controls.Add(this.txtStdRPM);
            this.gbMachine.Controls.Add(this.btnOK);
            this.gbMachine.Controls.Add(this.txtVariation);
            this.gbMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMachine.Location = new System.Drawing.Point(0, 0);
            this.gbMachine.Name = "gbMachine";
            this.gbMachine.Size = new System.Drawing.Size(277, 138);
            this.gbMachine.TabIndex = 5;
            this.gbMachine.Text = "Machine Detail";
            // 
            // cmbMachineType
            // 
            this.cmbMachineType.EditValue = "Select Machine Type";
            this.cmbMachineType.Location = new System.Drawing.Point(123, 24);
            this.cmbMachineType.Name = "cmbMachineType";
            this.cmbMachineType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMachineType.Properties.Items.AddRange(new object[] {
            "Select Machine Type",
            "Class1",
            "Class2",
            "Class3",
            "Class4"});
            this.cmbMachineType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbMachineType.Size = new System.Drawing.Size(127, 20);
            this.cmbMachineType.TabIndex = 1;
            this.cmbMachineType.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Machine Type";
            this.labelControl1.Visible = false;
            // 
            // frmDiagnosticRPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 138);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDiagnosticRPM";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Machine Information";
            ((System.ComponentModel.ISupportInitialize)(this.txtStdRPM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVariation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbMachine)).EndInit();
            this.gbMachine.ResumeLayout(false);
            this.gbMachine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMachineType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblRPM;
        private DevExpress.XtraEditors.LabelControl lbl;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.TextEdit txtStdRPM;
        public DevExpress.XtraEditors.TextEdit txtVariation;
        private DevExpress.XtraEditors.GroupControl gbMachine;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMachineType;
    }
}