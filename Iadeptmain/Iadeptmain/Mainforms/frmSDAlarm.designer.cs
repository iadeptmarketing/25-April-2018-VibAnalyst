namespace Iadeptmain.Mainforms
{
    partial class frmSDAlarm
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
            this.btnSDNewCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSDNewOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtSDName = new DevExpress.XtraEditors.TextEdit();
            this.txtSDValue = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDValue.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSDNewCancel
            // 
            this.btnSDNewCancel.Location = new System.Drawing.Point(234, 73);
            this.btnSDNewCancel.Name = "btnSDNewCancel";
            this.btnSDNewCancel.Size = new System.Drawing.Size(48, 22);
            this.btnSDNewCancel.TabIndex = 22;
            this.btnSDNewCancel.Text = "Cancel";
            this.btnSDNewCancel.Click += new System.EventHandler(this.btnSDNewCancel_Click);
            // 
            // btnSDNewOK
            // 
            this.btnSDNewOK.Location = new System.Drawing.Point(180, 73);
            this.btnSDNewOK.Name = "btnSDNewOK";
            this.btnSDNewOK.Size = new System.Drawing.Size(48, 22);
            this.btnSDNewOK.TabIndex = 23;
            this.btnSDNewOK.Text = "OK";
            this.btnSDNewOK.Click += new System.EventHandler(this.btnSDNewOK_Click);
            // 
            // txtSDName
            // 
            this.txtSDName.Location = new System.Drawing.Point(142, 47);
            this.txtSDName.Name = "txtSDName";
            this.txtSDName.Size = new System.Drawing.Size(140, 20);
            this.txtSDName.TabIndex = 21;
            // 
            // txtSDValue
            // 
            this.txtSDValue.Location = new System.Drawing.Point(178, 10);
            this.txtSDValue.Name = "txtSDValue";
            this.txtSDValue.Properties.MaxLength = 3;
            this.txtSDValue.Size = new System.Drawing.Size(57, 20);
            this.txtSDValue.TabIndex = 20;
            this.txtSDValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDValue_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Enter the Name of Alarm";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(241, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "%";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Enter the % increase in Deviation";
            // 
            // frmSDAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 104);
            this.ControlBox = false;
            this.Controls.Add(this.btnSDNewCancel);
            this.Controls.Add(this.btnSDNewOK);
            this.Controls.Add(this.txtSDName);
            this.Controls.Add(this.txtSDValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSDAlarm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Deviation Alarm";
            this.Load += new System.EventHandler(this.frmSDAlarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSDName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDValue.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSDNewCancel;
        private DevExpress.XtraEditors.SimpleButton btnSDNewOK;
        private DevExpress.XtraEditors.TextEdit txtSDName;
        private DevExpress.XtraEditors.TextEdit txtSDValue;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label1;
    }
}