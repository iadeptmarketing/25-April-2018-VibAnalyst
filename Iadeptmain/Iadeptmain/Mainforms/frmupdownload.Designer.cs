namespace Iadeptmain.Mainforms
{
    partial class frmupdownload
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
            this.grpupdown = new DevExpress.XtraEditors.GroupControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsSerial = new System.Windows.Forms.ToolStripStatusLabel();
            this.btndownload = new DevExpress.XtraEditors.SimpleButton();
            this.btnupload = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grpupdown)).BeginInit();
            this.grpupdown.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpupdown
            // 
            this.grpupdown.Appearance.BackColor = System.Drawing.Color.White;
            this.grpupdown.Appearance.Options.UseBackColor = true;
            this.grpupdown.Controls.Add(this.statusStrip1);
            this.grpupdown.Controls.Add(this.btndownload);
            this.grpupdown.Controls.Add(this.btnupload);
            this.grpupdown.Controls.Add(this.pictureBox2);
            this.grpupdown.Controls.Add(this.pictureBox1);
            this.grpupdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpupdown.Location = new System.Drawing.Point(0, 0);
            this.grpupdown.Name = "grpupdown";
            this.grpupdown.Size = new System.Drawing.Size(503, 172);
            this.grpupdown.TabIndex = 0;
            this.grpupdown.Text = "Upload/Download";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsSerial});
            this.statusStrip1.Location = new System.Drawing.Point(2, 148);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(499, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsSerial
            // 
            this.tsSerial.BackColor = System.Drawing.Color.Transparent;
            this.tsSerial.Image = global::Iadeptmain.Properties.Resources.status;
            this.tsSerial.Name = "tsSerial";
            this.tsSerial.Size = new System.Drawing.Size(16, 17);
            // 
            // btndownload
            // 
            this.btndownload.Image = global::Iadeptmain.XRDesignRibbonControllerResources.downloadn11;
            this.btndownload.Location = new System.Drawing.Point(182, 96);
            this.btndownload.Name = "btndownload";
            this.btndownload.Size = new System.Drawing.Size(132, 26);
            this.btndownload.TabIndex = 3;
            this.btndownload.Click += new System.EventHandler(this.btndownload_Click);
            // 
            // btnupload
            // 
            this.btnupload.Image = global::Iadeptmain.XRDesignRibbonControllerResources.upload11;
            this.btnupload.Location = new System.Drawing.Point(182, 48);
            this.btnupload.Name = "btnupload";
            this.btnupload.Size = new System.Drawing.Size(132, 26);
            this.btnupload.TabIndex = 2;
            this.btnupload.Click += new System.EventHandler(this.btnupload_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Iadeptmain.XRDesignRibbonControllerResources.computer1;
            this.pictureBox2.Location = new System.Drawing.Point(358, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(116, 97);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Iadeptmain.XRDesignRibbonControllerResources.computer;
            this.pictureBox1.Location = new System.Drawing.Point(31, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmupdownload
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 172);
            this.Controls.Add(this.grpupdown);
            this.LookAndFeel.SkinName = "Seven Classic";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmupdownload";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Silver;
            ((System.ComponentModel.ISupportInitialize)(this.grpupdown)).EndInit();
            this.grpupdown.ResumeLayout(false);
            this.grpupdown.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpupdown;
        private DevExpress.XtraEditors.SimpleButton btndownload;
        private DevExpress.XtraEditors.SimpleButton btnupload;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel tsSerial;
    }
}