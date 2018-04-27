namespace Iadeptmain.Mainforms
{
    partial class frmsplash1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsplash1));
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = global::Iadeptmain.XRDesignRibbonControllerResources.Movglobe;
            this.pictureEdit2.Location = new System.Drawing.Point(1, -1);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.AllowFocused = false;
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowMenu = false;
            this.pictureEdit2.Size = new System.Drawing.Size(189, 193);
            this.pictureEdit2.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl4.Location = new System.Drawing.Point(441, 83);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 13);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "Version 5.0.0.0";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Comic Sans MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.SeaGreen;
            this.labelControl3.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(276, 24);
            this.labelControl3.LookAndFeel.SkinName = "Money Twins";
            this.labelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.labelControl3.LookAndFeel.UseWindowsXPTheme = true;
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(241, 67);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "VibAnalyst";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(12, 298);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(295, 14);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "© 2016 VibAnalyst Condition Monitering Technologies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(9, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "This program is protected by Copyright Law and International Treaties.";
            // 
            // marqueeProgressBarControl1
            // 
            this.marqueeProgressBarControl1.EditValue = "Initializing....";
            this.marqueeProgressBarControl1.Location = new System.Drawing.Point(115, 236);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marqueeProgressBarControl1.Properties.Appearance.ForeColor = System.Drawing.Color.Green;
            this.marqueeProgressBarControl1.Properties.ShowTitle = true;
            this.marqueeProgressBarControl1.Size = new System.Drawing.Size(402, 22);
            this.marqueeProgressBarControl1.TabIndex = 20;
            // 
            // frmsplash1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(619, 348);
            this.ControlBox = false;
            this.Controls.Add(this.marqueeProgressBarControl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.pictureEdit2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmsplash1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VibAnalyst";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;     
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
    }
}