namespace Iadeptmain.Mainforms
{
    partial class frmCompleteImage
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
            this.mPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mPicBox
            // 
            this.mPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPicBox.Location = new System.Drawing.Point(0, 0);
            this.mPicBox.Name = "mPicBox";
            this.mPicBox.Size = new System.Drawing.Size(555, 434);
            this.mPicBox.TabIndex = 0;
            this.mPicBox.TabStop = false;
            // 
            // frmCompleteImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 434);
            this.Controls.Add(this.mPicBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCompleteImage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.mPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mPicBox;



    }
}