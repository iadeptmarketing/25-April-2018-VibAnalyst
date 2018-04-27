namespace Iadeptmain.BaseUserControl
{
    partial class GraphView
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
            this.lblValues = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lblValues
            // 
            this.lblValues.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblValues.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblValues.Location = new System.Drawing.Point(0, 230);
            this.lblValues.Margin = new System.Windows.Forms.Padding(4);
            this.lblValues.Name = "lblValues";
            this.lblValues.Size = new System.Drawing.Size(0, 16);
            this.lblValues.TabIndex = 0;
            // 
            // GraphView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValues);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GraphView";
            this.PreferredSize = new System.Drawing.Size(424, 272);
            this.Size = new System.Drawing.Size(267, 246);
            this.Load += new System.EventHandler(this.GraphView_Load);
            this.Click += new System.EventHandler(this.GraphView_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GraphView_KeyDown_1);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GraphView_KeyPress_1);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GraphView_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GraphView_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblValues;


    }
}
