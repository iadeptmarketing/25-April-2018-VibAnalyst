namespace Iadeptmain.Mainforms
{
    partial class Sensor_Manufacture
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
            this.btnSen_New = new DevExpress.XtraEditors.SimpleButton();
            this.btnSen_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btnSen_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.cmbSensorManuName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSen_New
            // 
            this.btnSen_New.Location = new System.Drawing.Point(20, 113);
            this.btnSen_New.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnSen_New.Name = "btnSen_New";
            this.btnSen_New.Size = new System.Drawing.Size(74, 23);
            this.btnSen_New.TabIndex = 32;
            this.btnSen_New.Text = "New";
            this.btnSen_New.Click += new System.EventHandler(this.btnSen_New_Click);
            // 
            // btnSen_Save
            // 
            this.btnSen_Save.Location = new System.Drawing.Point(120, 113);
            this.btnSen_Save.Name = "btnSen_Save";
            this.btnSen_Save.Size = new System.Drawing.Size(87, 23);
            this.btnSen_Save.TabIndex = 33;
            this.btnSen_Save.Text = "Save";
            this.btnSen_Save.Click += new System.EventHandler(this.btnSen_Save_Click);
            // 
            // btnSen_Cancel
            // 
            this.btnSen_Cancel.Location = new System.Drawing.Point(234, 113);
            this.btnSen_Cancel.Name = "btnSen_Cancel";
            this.btnSen_Cancel.Size = new System.Drawing.Size(87, 23);
            this.btnSen_Cancel.TabIndex = 34;
            this.btnSen_Cancel.Text = "Cancel";
            this.btnSen_Cancel.Click += new System.EventHandler(this.btnSen_Cancel_Click);
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(120, 63);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(165, 21);
            this.txtaddress.TabIndex = 35;
            this.txtaddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaddress_KeyPress);
            // 
            // cmbSensorManuName
            // 
            this.cmbSensorManuName.FormattingEnabled = true;
            this.cmbSensorManuName.Location = new System.Drawing.Point(120, 26);
            this.cmbSensorManuName.Name = "cmbSensorManuName";
            this.cmbSensorManuName.Size = new System.Drawing.Size(165, 21);
            this.cmbSensorManuName.TabIndex = 36;
            this.cmbSensorManuName.SelectedIndexChanged += new System.EventHandler(this.cmbSensorManuName_SelectedIndexChanged);
            this.cmbSensorManuName.SelectedValueChanged += new System.EventHandler(this.cmbSensorManuName_SelectedValueChanged);
            this.cmbSensorManuName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSensorManuName_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSen_Cancel);
            this.groupBox1.Controls.Add(this.txtaddress);
            this.groupBox1.Controls.Add(this.btnSen_Save);
            this.groupBox1.Controls.Add(this.cmbSensorManuName);
            this.groupBox1.Controls.Add(this.btnSen_New);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 155);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensor Manufacturer";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Address";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Name";
            // 
            // Sensor_Manufacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 165);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sensor_Manufacture";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sensor Manufacturer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSen_New;
        private DevExpress.XtraEditors.SimpleButton btnSen_Save;
        private DevExpress.XtraEditors.SimpleButton btnSen_Cancel;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.ComboBox cmbSensorManuName;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label1;
    }
}