namespace Iadeptmain.Mainforms
{
    partial class MultigraphSelection
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBand1 = new System.Windows.Forms.Label();
            this.lblBand2 = new System.Windows.Forms.Label();
            this.lblBand4 = new System.Windows.Forms.Label();
            this.lblBand3 = new System.Windows.Forms.Label();
            this.cbBand1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbBand2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbBand3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbBand4 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cbBand1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBand2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBand3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBand4.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox1.Location = new System.Drawing.Point(121, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(62, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select no. of graphs";
            // 
            // lblBand1
            // 
            this.lblBand1.AutoSize = true;
            this.lblBand1.Location = new System.Drawing.Point(13, 46);
            this.lblBand1.Name = "lblBand1";
            this.lblBand1.Size = new System.Drawing.Size(38, 13);
            this.lblBand1.TabIndex = 2;
            this.lblBand1.Text = "Band1";
            // 
            // lblBand2
            // 
            this.lblBand2.AutoSize = true;
            this.lblBand2.Location = new System.Drawing.Point(13, 74);
            this.lblBand2.Name = "lblBand2";
            this.lblBand2.Size = new System.Drawing.Size(38, 13);
            this.lblBand2.TabIndex = 3;
            this.lblBand2.Text = "Band2";
            // 
            // lblBand4
            // 
            this.lblBand4.AutoSize = true;
            this.lblBand4.Location = new System.Drawing.Point(13, 130);
            this.lblBand4.Name = "lblBand4";
            this.lblBand4.Size = new System.Drawing.Size(38, 13);
            this.lblBand4.TabIndex = 5;
            this.lblBand4.Text = "Band4";
            // 
            // lblBand3
            // 
            this.lblBand3.AutoSize = true;
            this.lblBand3.Location = new System.Drawing.Point(13, 102);
            this.lblBand3.Name = "lblBand3";
            this.lblBand3.Size = new System.Drawing.Size(38, 13);
            this.lblBand3.TabIndex = 4;
            this.lblBand3.Text = "Band3";
            // 
            // cbBand1
            // 
            this.cbBand1.EditValue = "50 Hz";
            this.cbBand1.Location = new System.Drawing.Point(57, 43);
            this.cbBand1.Name = "cbBand1";
            this.cbBand1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbBand1.Properties.Appearance.Options.UseBackColor = true;
            this.cbBand1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBand1.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbBand1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbBand1.Size = new System.Drawing.Size(56, 20);
            this.cbBand1.TabIndex = 21;
            this.cbBand1.SelectedIndexChanged += new System.EventHandler(this.cbBand1_SelectedIndexChanged);
            // 
            // cbBand2
            // 
            this.cbBand2.EditValue = "50 Hz";
            this.cbBand2.Location = new System.Drawing.Point(57, 71);
            this.cbBand2.Name = "cbBand2";
            this.cbBand2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbBand2.Properties.Appearance.Options.UseBackColor = true;
            this.cbBand2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBand2.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbBand2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbBand2.Size = new System.Drawing.Size(56, 20);
            this.cbBand2.TabIndex = 22;
            this.cbBand2.SelectedIndexChanged += new System.EventHandler(this.cbBand2_SelectedIndexChanged);
            // 
            // cbBand3
            // 
            this.cbBand3.EditValue = "50 Hz";
            this.cbBand3.Location = new System.Drawing.Point(57, 99);
            this.cbBand3.Name = "cbBand3";
            this.cbBand3.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbBand3.Properties.Appearance.Options.UseBackColor = true;
            this.cbBand3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBand3.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbBand3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbBand3.Size = new System.Drawing.Size(56, 20);
            this.cbBand3.TabIndex = 23;
            this.cbBand3.SelectedIndexChanged += new System.EventHandler(this.cbBand3_SelectedIndexChanged);
            // 
            // cbBand4
            // 
            this.cbBand4.EditValue = "50 Hz";
            this.cbBand4.Location = new System.Drawing.Point(57, 127);
            this.cbBand4.Name = "cbBand4";
            this.cbBand4.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbBand4.Properties.Appearance.Options.UseBackColor = true;
            this.cbBand4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBand4.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbBand4.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbBand4.Size = new System.Drawing.Size(56, 20);
            this.cbBand4.TabIndex = 24;
            this.cbBand4.SelectedIndexChanged += new System.EventHandler(this.cbBand4_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(121, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 26);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(121, 61);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 26);
            this.btnOK.TabIndex = 26;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // MultigraphSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 155);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbBand4);
            this.Controls.Add(this.cbBand3);
            this.Controls.Add(this.cbBand2);
            this.Controls.Add(this.cbBand1);
            this.Controls.Add(this.lblBand4);
            this.Controls.Add(this.lblBand3);
            this.Controls.Add(this.lblBand2);
            this.Controls.Add(this.lblBand1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MultigraphSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Multiple Graph";
            ((System.ComponentModel.ISupportInitialize)(this.cbBand1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBand2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBand3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBand4.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBand1;
        private System.Windows.Forms.Label lblBand2;
        private System.Windows.Forms.Label lblBand4;
        private System.Windows.Forms.Label lblBand3;
        private DevExpress.XtraEditors.ComboBoxEdit cbBand1;
        private DevExpress.XtraEditors.ComboBoxEdit cbBand2;
        private DevExpress.XtraEditors.ComboBoxEdit cbBand3;
        private DevExpress.XtraEditors.ComboBoxEdit cbBand4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}