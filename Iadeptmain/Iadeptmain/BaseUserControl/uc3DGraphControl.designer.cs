namespace Iadeptmain.BaseUserControl
{
    partial class uc3DGraphControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNewValues = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lblNewValues
            // 
            this.lblNewValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNewValues.Location = new System.Drawing.Point(0, 0);
            this.lblNewValues.Name = "lblNewValues";
            this.lblNewValues.Size = new System.Drawing.Size(22, 13);
            this.lblNewValues.TabIndex = 0;
            this.lblNewValues.Text = "label";
            this.lblNewValues.Click += new System.EventHandler(this.lblNewValues_Click);
            // 
            // uc3DGraphControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNewValues);
            this.Name = "uc3DGraphControl";
            this.PreferredSize = new System.Drawing.Size(424, 272);
            this.Size = new System.Drawing.Size(402, 272);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblNewValues;
    }
}
