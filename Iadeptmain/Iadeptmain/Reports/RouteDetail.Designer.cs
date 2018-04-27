namespace Iadeptmain.Reports
{
    partial class RouteDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteDetail));
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbRouteName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbDTime = new DevExpress.XtraEditors.ComboBoxEdit();
            this.button1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new DevExpress.XtraEditors.GroupControl();
            this.button2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRouteName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Route Name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Download time for the selected Route";
            this.label2.Visible = false;
            // 
            // cmbRouteName
            // 
            this.cmbRouteName.Location = new System.Drawing.Point(9, 33);
            this.cmbRouteName.Name = "cmbRouteName";
            this.cmbRouteName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRouteName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbRouteName.Size = new System.Drawing.Size(149, 20);
            this.cmbRouteName.TabIndex = 1;
            this.cmbRouteName.SelectedIndexChanged += new System.EventHandler(this.cmbRouteName_SelectedIndexChanged);
            // 
            // cmbDTime
            // 
            this.cmbDTime.Location = new System.Drawing.Point(9, 100);
            this.cmbDTime.Name = "cmbDTime";
            this.cmbDTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDTime.Size = new System.Drawing.Size(149, 20);
            this.cmbDTime.TabIndex = 1;
            this.cmbDTime.Visible = false;
            this.cmbDTime.SelectedIndexChanged += new System.EventHandler(this.cmbDTime_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(161, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbDTime);
            this.groupBox1.Controls.Add(this.cmbRouteName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 140);
            this.groupBox1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(80, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RouteDetail
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(248, 184);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RouteDetail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RouteDetail";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RouteDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbRouteName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbRouteName;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDTime;
        private DevExpress.XtraEditors.SimpleButton button1;
        private DevExpress.XtraEditors.GroupControl groupBox1;
        private DevExpress.XtraEditors.SimpleButton button2;
    }
}