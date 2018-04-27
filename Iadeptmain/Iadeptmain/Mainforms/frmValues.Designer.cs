namespace Iadeptmain.Mainforms
{
    partial class frmValues
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
            this.lblValues = new DevExpress.XtraEditors.LabelControl();
            this.chkgrp1 = new DevExpress.XtraEditors.CheckEdit();
            this.chkgrp2 = new DevExpress.XtraEditors.CheckEdit();
            this.chkgrp3 = new DevExpress.XtraEditors.CheckEdit();
            this.btnok = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chkgrp1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkgrp2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkgrp3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblValues
            // 
            this.lblValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValues.Location = new System.Drawing.Point(0, 0);
            this.lblValues.Name = "lblValues";
            this.lblValues.Size = new System.Drawing.Size(22, 13);
            this.lblValues.TabIndex = 0;
            this.lblValues.Text = "label";
            this.lblValues.Visible = false;
            // 
            // chkgrp1
            // 
            this.chkgrp1.Location = new System.Drawing.Point(12, 19);
            this.chkgrp1.Name = "chkgrp1";
            this.chkgrp1.Properties.Caption = "Group1 Power Specrum";
            this.chkgrp1.Size = new System.Drawing.Size(156, 19);
            this.chkgrp1.TabIndex = 1;
            // 
            // chkgrp2
            // 
            this.chkgrp2.Location = new System.Drawing.Point(12, 44);
            this.chkgrp2.Name = "chkgrp2";
            this.chkgrp2.Properties.Caption = "Group2 Power Specrum";
            this.chkgrp2.Size = new System.Drawing.Size(156, 19);
            this.chkgrp2.TabIndex = 2;
            // 
            // chkgrp3
            // 
            this.chkgrp3.Location = new System.Drawing.Point(12, 69);
            this.chkgrp3.Name = "chkgrp3";
            this.chkgrp3.Properties.Caption = "Group3 Power Specrum";
            this.chkgrp3.Size = new System.Drawing.Size(156, 19);
            this.chkgrp3.TabIndex = 3;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(30, 97);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(60, 26);
            this.btnok.TabIndex = 4;
            this.btnok.Text = "OK";
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // frmValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 135);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.chkgrp3);
            this.Controls.Add(this.chkgrp2);
            this.Controls.Add(this.chkgrp1);
            this.Controls.Add(this.lblValues);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmValues";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Spectrum Groups";
            ((System.ComponentModel.ISupportInitialize)(this.chkgrp1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkgrp2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkgrp3.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblValues;
        private DevExpress.XtraEditors.CheckEdit chkgrp1;
        private DevExpress.XtraEditors.CheckEdit chkgrp2;
        private DevExpress.XtraEditors.CheckEdit chkgrp3;
        private DevExpress.XtraEditors.SimpleButton btnok;

    }
}