namespace Iadeptmain.Mainforms
{
    partial class frmmultiplegraph
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtLAxial = new System.Windows.Forms.TextBox();
            this.txtLHorizontal = new System.Windows.Forms.TextBox();
            this.txtLVertical = new System.Windows.Forms.TextBox();
            this.txtLCh1 = new System.Windows.Forms.TextBox();
            this.btnok = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtHAxial = new System.Windows.Forms.TextBox();
            this.txtHHorizontal = new System.Windows.Forms.TextBox();
            this.txtHVertical = new System.Windows.Forms.TextBox();
            this.txtHCh1 = new System.Windows.Forms.TextBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(145, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Low Freq";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 51);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(23, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Axial";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(6, 85);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Horizontal";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(6, 114);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(35, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Vertical";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(6, 148);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(45, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Channel1";
            // 
            // txtLAxial
            // 
            this.txtLAxial.Enabled = false;
            this.txtLAxial.Location = new System.Drawing.Point(140, 43);
            this.txtLAxial.MaxLength = 5;
            this.txtLAxial.Name = "txtLAxial";
            this.txtLAxial.Size = new System.Drawing.Size(64, 21);
            this.txtLAxial.TabIndex = 2;
            this.txtLAxial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHAxial_KeyPress);
            // 
            // txtLHorizontal
            // 
            this.txtLHorizontal.Enabled = false;
            this.txtLHorizontal.Location = new System.Drawing.Point(140, 78);
            this.txtLHorizontal.MaxLength = 5;
            this.txtLHorizontal.Name = "txtLHorizontal";
            this.txtLHorizontal.Size = new System.Drawing.Size(64, 21);
            this.txtLHorizontal.TabIndex = 4;
            this.txtLHorizontal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHAxial_KeyPress);
            // 
            // txtLVertical
            // 
            this.txtLVertical.Enabled = false;
            this.txtLVertical.Location = new System.Drawing.Point(140, 107);
            this.txtLVertical.MaxLength = 5;
            this.txtLVertical.Name = "txtLVertical";
            this.txtLVertical.Size = new System.Drawing.Size(64, 21);
            this.txtLVertical.TabIndex = 6;
            this.txtLVertical.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHAxial_KeyPress);
            // 
            // txtLCh1
            // 
            this.txtLCh1.Enabled = false;
            this.txtLCh1.Location = new System.Drawing.Point(140, 141);
            this.txtLCh1.MaxLength = 5;
            this.txtLCh1.Name = "txtLCh1";
            this.txtLCh1.Size = new System.Drawing.Size(64, 21);
            this.txtLCh1.TabIndex = 8;
            this.txtLCh1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHAxial_KeyPress);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(67, 174);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(56, 23);
            this.btnok.TabIndex = 9;
            this.btnok.Text = "OK";
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(67, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "High Freq.";
            // 
            // txtHAxial
            // 
            this.txtHAxial.Enabled = false;
            this.txtHAxial.Location = new System.Drawing.Point(61, 43);
            this.txtHAxial.MaxLength = 5;
            this.txtHAxial.Name = "txtHAxial";
            this.txtHAxial.Size = new System.Drawing.Size(64, 21);
            this.txtHAxial.TabIndex = 1;
            this.txtHAxial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHAxial_KeyPress);
            // 
            // txtHHorizontal
            // 
            this.txtHHorizontal.Enabled = false;
            this.txtHHorizontal.Location = new System.Drawing.Point(61, 77);
            this.txtHHorizontal.MaxLength = 5;
            this.txtHHorizontal.Name = "txtHHorizontal";
            this.txtHHorizontal.Size = new System.Drawing.Size(64, 21);
            this.txtHHorizontal.TabIndex = 3;
            this.txtHHorizontal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHAxial_KeyPress);
            // 
            // txtHVertical
            // 
            this.txtHVertical.Enabled = false;
            this.txtHVertical.Location = new System.Drawing.Point(61, 106);
            this.txtHVertical.MaxLength = 5;
            this.txtHVertical.Name = "txtHVertical";
            this.txtHVertical.Size = new System.Drawing.Size(64, 21);
            this.txtHVertical.TabIndex = 5;
            this.txtHVertical.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHAxial_KeyPress);
            // 
            // txtHCh1
            // 
            this.txtHCh1.Enabled = false;
            this.txtHCh1.Location = new System.Drawing.Point(61, 140);
            this.txtHCh1.MaxLength = 5;
            this.txtHCh1.Name = "txtHCh1";
            this.txtHCh1.Size = new System.Drawing.Size(64, 21);
            this.txtHCh1.TabIndex = 7;
            this.txtHCh1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHAxial_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(140, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(58, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmmultiplegraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 207);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.txtLCh1);
            this.Controls.Add(this.txtHCh1);
            this.Controls.Add(this.txtLVertical);
            this.Controls.Add(this.txtHVertical);
            this.Controls.Add(this.txtLHorizontal);
            this.Controls.Add(this.txtHHorizontal);
            this.Controls.Add(this.txtLAxial);
            this.Controls.Add(this.txtHAxial);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmmultiplegraph";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Multiple Graph";
            this.Load += new System.EventHandler(this.frmmultiplegraph_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.TextBox txtLAxial;
        private System.Windows.Forms.TextBox txtLHorizontal;
        private System.Windows.Forms.TextBox txtLVertical;
        private System.Windows.Forms.TextBox txtLCh1;
        private DevExpress.XtraEditors.SimpleButton btnok;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txtHAxial;
        private System.Windows.Forms.TextBox txtHHorizontal;
        private System.Windows.Forms.TextBox txtHVertical;
        private System.Windows.Forms.TextBox txtHCh1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}