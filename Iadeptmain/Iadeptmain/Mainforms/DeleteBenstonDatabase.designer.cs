namespace Iadeptmain.Mainforms
{
    partial class DeleteBenstonDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteBenstonDatabase));
            this.lbPrsntDataBss = new System.Windows.Forms.ListBox();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lbPrsntDataBss
            // 
            this.lbPrsntDataBss.FormattingEnabled = true;
            this.lbPrsntDataBss.Location = new System.Drawing.Point(12, 12);
            this.lbPrsntDataBss.Name = "lbPrsntDataBss";
            this.lbPrsntDataBss.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbPrsntDataBss.Size = new System.Drawing.Size(211, 186);
            this.lbPrsntDataBss.TabIndex = 0;
            this.lbPrsntDataBss.SelectedIndexChanged += new System.EventHandler(this.lbPrsntDataBss_SelectedIndexChanged_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(167, 211);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(51, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // DeleteBenstonDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 246);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lbPrsntDataBss);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteBenstonDatabase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Route In Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeleteBenstonDatabase_FormClosing);
            this.Load += new System.EventHandler(this.DeleteBenstonDatabase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDelete;
        public System.Windows.Forms.ListBox lbPrsntDataBss;
    }
}