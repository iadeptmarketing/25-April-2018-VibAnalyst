namespace Iadeptmain.Mainforms
{
    partial class frmRpmCount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRpmCount));
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBox1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.button1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmboverall = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnoverall = new DevExpress.XtraEditors.SimpleButton();
            this.btnvalue = new System.Windows.Forms.Button();
            this.txtvalue = new System.Windows.Forms.TextBox();
            this.lblvalue = new System.Windows.Forms.Label();
            this.lbluff = new DevExpress.XtraEditors.LabelControl();
            this.txtuff = new DevExpress.XtraEditors.TextEdit();
            this.btnuff = new DevExpress.XtraEditors.SimpleButton();
            this.btnok = new DevExpress.XtraEditors.SimpleButton();
            this.lblharmonic = new DevExpress.XtraEditors.LabelControl();
            this.cmbharmonic = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboverall.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtuff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbharmonic.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "RPM Up to";
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(91, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBox1.Properties.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64",
            "65",
            "66",
            "67",
            "68",
            "69",
            "70",
            "71",
            "72",
            "73",
            "74",
            "75",
            "76",
            "77",
            "78",
            "79",
            "80",
            "81",
            "82",
            "83",
            "84",
            "85",
            "86",
            "87",
            "88",
            "89",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99"});
            this.comboBox1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBox1.Size = new System.Drawing.Size(62, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(161, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(6, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "X";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(198, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Select OverAll";
            this.labelControl1.Visible = false;
            // 
            // cmboverall
            // 
            this.cmboverall.EditValue = "Acceleration";
            this.cmboverall.Location = new System.Drawing.Point(88, 10);
            this.cmboverall.Name = "cmboverall";
            this.cmboverall.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmboverall.Properties.Items.AddRange(new object[] {
            "Acceleration",
            "Velocity",
            "Displacement",
            "CrestFactor",
            "Bearing"});
            this.cmboverall.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmboverall.Size = new System.Drawing.Size(94, 20);
            this.cmboverall.TabIndex = 5;
            this.cmboverall.Visible = false;
            // 
            // btnoverall
            // 
            this.btnoverall.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnoverall.Location = new System.Drawing.Point(196, 8);
            this.btnoverall.Name = "btnoverall";
            this.btnoverall.Size = new System.Drawing.Size(33, 23);
            this.btnoverall.TabIndex = 6;
            this.btnoverall.Text = "OK";
            this.btnoverall.Visible = false;
            this.btnoverall.Click += new System.EventHandler(this.btnoverall_Click);
            // 
            // btnvalue
            // 
            this.btnvalue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnvalue.Location = new System.Drawing.Point(196, 16);
            this.btnvalue.Name = "btnvalue";
            this.btnvalue.Size = new System.Drawing.Size(33, 21);
            this.btnvalue.TabIndex = 9;
            this.btnvalue.Text = "Ok";
            this.btnvalue.UseVisualStyleBackColor = true;
            this.btnvalue.Visible = false;
            this.btnvalue.Click += new System.EventHandler(this.btnvalue_Click);
            // 
            // txtvalue
            // 
            this.txtvalue.Location = new System.Drawing.Point(84, 11);
            this.txtvalue.Name = "txtvalue";
            this.txtvalue.Size = new System.Drawing.Size(100, 21);
            this.txtvalue.TabIndex = 8;
            this.txtvalue.Visible = false;
            this.txtvalue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtvalue_KeyPress);
            // 
            // lblvalue
            // 
            this.lblvalue.AutoSize = true;
            this.lblvalue.Location = new System.Drawing.Point(34, 14);
            this.lblvalue.Name = "lblvalue";
            this.lblvalue.Size = new System.Drawing.Size(33, 13);
            this.lblvalue.TabIndex = 7;
            this.lblvalue.Text = "Value";
            this.lblvalue.Visible = false;
            // 
            // lbluff
            // 
            this.lbluff.Location = new System.Drawing.Point(7, 10);
            this.lbluff.Name = "lbluff";
            this.lbluff.Size = new System.Drawing.Size(63, 13);
            this.lbluff.TabIndex = 10;
            this.lbluff.Text = "UFF OR WAV";
            this.lbluff.Visible = false;
            // 
            // txtuff
            // 
            this.txtuff.Enabled = false;
            this.txtuff.Location = new System.Drawing.Point(71, 8);
            this.txtuff.Name = "txtuff";
            this.txtuff.Size = new System.Drawing.Size(118, 20);
            this.txtuff.TabIndex = 11;
            this.txtuff.Visible = false;
            // 
            // btnuff
            // 
            this.btnuff.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnuff.Location = new System.Drawing.Point(195, 7);
            this.btnuff.Name = "btnuff";
            this.btnuff.Size = new System.Drawing.Size(38, 23);
            this.btnuff.TabIndex = 12;
            this.btnuff.Text = "...";
            this.btnuff.Click += new System.EventHandler(this.btnuff_Click);
            // 
            // btnok
            // 
            this.btnok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnok.Location = new System.Drawing.Point(144, 32);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(38, 23);
            this.btnok.TabIndex = 13;
            this.btnok.Text = "Ok";
            this.btnok.Visible = false;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // lblharmonic
            // 
            this.lblharmonic.Location = new System.Drawing.Point(34, 37);
            this.lblharmonic.Name = "lblharmonic";
            this.lblharmonic.Size = new System.Drawing.Size(44, 13);
            this.lblharmonic.TabIndex = 14;
            this.lblharmonic.Text = "Harmonic";
            this.lblharmonic.Visible = false;
            // 
            // cmbharmonic
            // 
            this.cmbharmonic.Location = new System.Drawing.Point(84, 36);
            this.cmbharmonic.Name = "cmbharmonic";
            this.cmbharmonic.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbharmonic.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbharmonic.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbharmonic.Size = new System.Drawing.Size(100, 20);
            this.cmbharmonic.TabIndex = 15;
            // 
            // frmRpmCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 61);
            this.Controls.Add(this.cmbharmonic);
            this.Controls.Add(this.lblharmonic);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.btnuff);
            this.Controls.Add(this.txtuff);
            this.Controls.Add(this.lbluff);
            this.Controls.Add(this.btnvalue);
            this.Controls.Add(this.txtvalue);
            this.Controls.Add(this.lblvalue);
            this.Controls.Add(this.btnoverall);
            this.Controls.Add(this.cmboverall);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRpmCount";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rpm Count";
            this.Load += new System.EventHandler(this.frmRpmCount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboverall.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtuff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbharmonic.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBox1;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.SimpleButton button1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmboverall;
        private DevExpress.XtraEditors.SimpleButton btnoverall;
        private System.Windows.Forms.Button btnvalue;
        private System.Windows.Forms.TextBox txtvalue;
        private System.Windows.Forms.Label lblvalue;
        private DevExpress.XtraEditors.LabelControl lbluff;
        private DevExpress.XtraEditors.TextEdit txtuff;
        private DevExpress.XtraEditors.SimpleButton btnuff;
        private DevExpress.XtraEditors.SimpleButton btnok;
        private DevExpress.XtraEditors.LabelControl lblharmonic;
        private DevExpress.XtraEditors.ComboBoxEdit cmbharmonic;
    }
}