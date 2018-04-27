namespace Iadeptmain.Mainforms
{
    partial class Sensor_Type
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
            DevExpress.XtraEditors.SimpleButton btnSensortypeSave;
            this.btnSensortypeCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSensortypeNew = new DevExpress.XtraEditors.SimpleButton();
            this.cmbSensorType = new System.Windows.Forms.ComboBox();
            this.Cmbunit = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSensorUnit = new DevExpress.XtraEditors.LabelControl();
            this.lblSensorType = new DevExpress.XtraEditors.LabelControl();
            btnSensortypeSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSensortypeSave
            // 
            btnSensortypeSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnSensortypeSave.Appearance.Options.UseFont = true;
            btnSensortypeSave.Location = new System.Drawing.Point(139, 109);
            btnSensortypeSave.Name = "btnSensortypeSave";
            btnSensortypeSave.Size = new System.Drawing.Size(93, 23);
            btnSensortypeSave.TabIndex = 5;
            btnSensortypeSave.Text = "Save";
            btnSensortypeSave.Click += new System.EventHandler(this.btnSensortypeSave_Click);
            // 
            // btnSensortypeCancel
            // 
            this.btnSensortypeCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSensortypeCancel.Appearance.Options.UseFont = true;
            this.btnSensortypeCancel.Location = new System.Drawing.Point(247, 109);
            this.btnSensortypeCancel.Name = "btnSensortypeCancel";
            this.btnSensortypeCancel.Size = new System.Drawing.Size(93, 23);
            this.btnSensortypeCancel.TabIndex = 4;
            this.btnSensortypeCancel.Text = "Cancel";
            this.btnSensortypeCancel.Click += new System.EventHandler(this.btnSensortypeCancel_Click);
            // 
            // btnSensortypeNew
            // 
            this.btnSensortypeNew.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSensortypeNew.Appearance.Options.UseFont = true;
            this.btnSensortypeNew.Location = new System.Drawing.Point(32, 109);
            this.btnSensortypeNew.Name = "btnSensortypeNew";
            this.btnSensortypeNew.Size = new System.Drawing.Size(93, 23);
            this.btnSensortypeNew.TabIndex = 6;
            this.btnSensortypeNew.Text = "New";
            this.btnSensortypeNew.Click += new System.EventHandler(this.btnSensortypeNew_Click);
            // 
            // cmbSensorType
            // 
            this.cmbSensorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSensorType.FormattingEnabled = true;
            this.cmbSensorType.Location = new System.Drawing.Point(117, 28);
            this.cmbSensorType.MaxLength = 32;
            this.cmbSensorType.Name = "cmbSensorType";
            this.cmbSensorType.Size = new System.Drawing.Size(175, 21);
            this.cmbSensorType.TabIndex = 9;
            this.cmbSensorType.SelectedIndexChanged += new System.EventHandler(this.cmbSensorType_SelectedIndexChanged_1);
            this.cmbSensorType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSensorType_KeyPress);
            // 
            // Cmbunit
            // 
            this.Cmbunit.FormattingEnabled = true;
            this.Cmbunit.Location = new System.Drawing.Point(117, 63);
            this.Cmbunit.Name = "Cmbunit";
            this.Cmbunit.Size = new System.Drawing.Size(175, 21);
            this.Cmbunit.TabIndex = 10;
            this.Cmbunit.SelectedIndexChanged += new System.EventHandler(this.Cmbunit_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSensorUnit);
            this.groupBox1.Controls.Add(this.lblSensorType);
            this.groupBox1.Controls.Add(this.btnSensortypeCancel);
            this.groupBox1.Controls.Add(btnSensortypeSave);
            this.groupBox1.Controls.Add(this.btnSensortypeNew);
            this.groupBox1.Controls.Add(this.Cmbunit);
            this.groupBox1.Controls.Add(this.cmbSensorType);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 152);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensor Type";
            // 
            // lblSensorUnit
            // 
            this.lblSensorUnit.Location = new System.Drawing.Point(32, 66);
            this.lblSensorUnit.Name = "lblSensorUnit";
            this.lblSensorUnit.Size = new System.Drawing.Size(19, 13);
            this.lblSensorUnit.TabIndex = 12;
            this.lblSensorUnit.Text = "Unit";
            // 
            // lblSensorType
            // 
            this.lblSensorType.Location = new System.Drawing.Point(32, 28);
            this.lblSensorType.Name = "lblSensorType";
            this.lblSensorType.Size = new System.Drawing.Size(24, 13);
            this.lblSensorType.TabIndex = 11;
            this.lblSensorType.Text = "Type";
            // 
            // Sensor_Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 181);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sensor_Type";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sensor Type";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSensortypeCancel;
        private DevExpress.XtraEditors.SimpleButton btnSensortypeNew;
        private System.Windows.Forms.ComboBox cmbSensorType;
        private System.Windows.Forms.ComboBox Cmbunit;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl lblSensorUnit;
        private DevExpress.XtraEditors.LabelControl lblSensorType;
    }
}