namespace Iadeptmain.Mainforms
{
    partial class frmPAlarm
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
            this.btnPNewCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnPNewOK = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPValue = new DevExpress.XtraEditors.TextEdit();
            this.txtPName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPNewCancel
            // 
            this.btnPNewCancel.Location = new System.Drawing.Point(234, 73);
            this.btnPNewCancel.Name = "btnPNewCancel";
            this.btnPNewCancel.Size = new System.Drawing.Size(48, 22);
            this.btnPNewCancel.TabIndex = 29;
            this.btnPNewCancel.Text = "Cancel";
            this.btnPNewCancel.Click += new System.EventHandler(this.btnPNewCancel_Click);
            // 
            // btnPNewOK
            // 
            this.btnPNewOK.Location = new System.Drawing.Point(180, 73);
            this.btnPNewOK.Name = "btnPNewOK";
            this.btnPNewOK.Size = new System.Drawing.Size(48, 22);
            this.btnPNewOK.TabIndex = 30;
            this.btnPNewOK.Text = "OK";
            this.btnPNewOK.Click += new System.EventHandler(this.btnPNewOK_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Enter the Name of Alarm";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(255, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "%";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Enter the % increase in Percentage";
            // 
            // txtPValue
            // 
            this.txtPValue.Location = new System.Drawing.Point(195, 9);
            this.txtPValue.Name = "txtPValue";
            this.txtPValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPValue.Properties.MaxLength = 3;
            this.txtPValue.Size = new System.Drawing.Size(53, 20);
            this.txtPValue.TabIndex = 31;
            this.txtPValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPValue_KeyPress);
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(148, 50);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(134, 20);
            this.txtPName.TabIndex = 32;
            // 
            // frmPAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 104);
            this.ControlBox = false;
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.txtPValue);
            this.Controls.Add(this.btnPNewCancel);
            this.Controls.Add(this.btnPNewOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPAlarm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Percentage Alarm";
            ((System.ComponentModel.ISupportInitialize)(this.txtPValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPNewCancel;
        private DevExpress.XtraEditors.SimpleButton btnPNewOK;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label1;
        public DevExpress.XtraEditors.TextEdit txtPName;
        public DevExpress.XtraEditors.TextEdit txtPValue;

    }
}