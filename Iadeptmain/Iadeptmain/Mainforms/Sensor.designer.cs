namespace Iadeptmain.Mainforms
{
    partial class Sensor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbSenDir = new System.Windows.Forms.ComboBox();
            this.lblSensDir = new System.Windows.Forms.Label();
            this.lblRange = new System.Windows.Forms.Label();
            this.cmbRange = new System.Windows.Forms.ComboBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.cmbManu = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.txtSenV = new System.Windows.Forms.TextBox();
            this.txtSenH = new System.Windows.Forms.TextBox();
            this.txtSenA = new System.Windows.Forms.TextBox();
            this.txtSenCH1 = new System.Windows.Forms.TextBox();
            this.lblSenV = new System.Windows.Forms.Label();
            this.lblSenH = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSensAcc = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSensOffset = new System.Windows.Forms.Label();
            this.txtSenOffset = new System.Windows.Forms.TextBox();
            this.chkBoxICP = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.08839F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(357, 510);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 499);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbSenDir);
            this.panel1.Controls.Add(this.lblSensDir);
            this.panel1.Controls.Add(this.lblRange);
            this.panel1.Controls.Add(this.cmbRange);
            this.panel1.Controls.Add(this.cmbUnit);
            this.panel1.Controls.Add(this.cmbManu);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.cmbName);
            this.panel1.Controls.Add(this.txtSenV);
            this.panel1.Controls.Add(this.txtSenH);
            this.panel1.Controls.Add(this.txtSenA);
            this.panel1.Controls.Add(this.txtSenCH1);
            this.panel1.Controls.Add(this.lblSenV);
            this.panel1.Controls.Add(this.lblSenH);
            this.panel1.Controls.Add(this.lblManufacturer);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.lblUnit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblSensAcc);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Location = new System.Drawing.Point(3, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 352);
            this.panel1.TabIndex = 0;
            // 
            // cmbSenDir
            // 
            this.cmbSenDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSenDir.FormattingEnabled = true;
            this.cmbSenDir.Items.AddRange(new object[] {
            "XYZ",
            "X",
            "XYZ+CH1"});
            this.cmbSenDir.Location = new System.Drawing.Point(138, 147);
            this.cmbSenDir.Name = "cmbSenDir";
            this.cmbSenDir.Size = new System.Drawing.Size(134, 21);
            this.cmbSenDir.TabIndex = 5;
            this.cmbSenDir.SelectedIndexChanged += new System.EventHandler(this.cmbSenDir_SelectedIndexChanged);
            // 
            // lblSensDir
            // 
            this.lblSensDir.AutoSize = true;
            this.lblSensDir.Location = new System.Drawing.Point(37, 150);
            this.lblSensDir.Name = "lblSensDir";
            this.lblSensDir.Size = new System.Drawing.Size(85, 13);
            this.lblSensDir.TabIndex = 20;
            this.lblSensDir.Text = "Sensor Direction";
            // 
            // lblRange
            // 
            this.lblRange.AutoSize = true;
            this.lblRange.Location = new System.Drawing.Point(37, 316);
            this.lblRange.Name = "lblRange";
            this.lblRange.Size = new System.Drawing.Size(67, 13);
            this.lblRange.TabIndex = 18;
            this.lblRange.Text = "Input Range";
            // 
            // cmbRange
            // 
            this.cmbRange.AllowDrop = true;
            this.cmbRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRange.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbRange.FormattingEnabled = true;
            this.cmbRange.Items.AddRange(new object[] {
            "5V",
            "20V"});
            this.cmbRange.Location = new System.Drawing.Point(138, 313);
            this.cmbRange.Name = "cmbRange";
            this.cmbRange.Size = new System.Drawing.Size(134, 21);
            this.cmbRange.TabIndex = 10;
            // 
            // cmbUnit
            // 
            this.cmbUnit.AllowDrop = true;
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(138, 115);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(134, 21);
            this.cmbUnit.TabIndex = 4;
            // 
            // cmbManu
            // 
            this.cmbManu.AllowDrop = true;
            this.cmbManu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManu.FormattingEnabled = true;
            this.cmbManu.Location = new System.Drawing.Point(138, 46);
            this.cmbManu.Name = "cmbManu";
            this.cmbManu.Size = new System.Drawing.Size(134, 21);
            this.cmbManu.TabIndex = 2;
            // 
            // cmbType
            // 
            this.cmbType.AllowDrop = true;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(138, 81);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(134, 21);
            this.cmbType.TabIndex = 3;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // cmbName
            // 
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(138, 12);
            this.cmbName.MaxLength = 32;
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(134, 21);
            this.cmbName.TabIndex = 1;
            this.cmbName.SelectedValueChanged += new System.EventHandler(this.cmbName_SelectedValueChanged);
            this.cmbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbName_KeyPress);
            this.cmbName.Leave += new System.EventHandler(this.cmbName_Leave);
            // 
            // txtSenV
            // 
            this.txtSenV.Location = new System.Drawing.Point(138, 280);
            this.txtSenV.MaxLength = 32;
            this.txtSenV.Name = "txtSenV";
            this.txtSenV.Size = new System.Drawing.Size(134, 21);
            this.txtSenV.TabIndex = 9;
            this.txtSenV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenV_KeyPress);
            // 
            // txtSenH
            // 
            this.txtSenH.Location = new System.Drawing.Point(138, 245);
            this.txtSenH.MaxLength = 32;
            this.txtSenH.Name = "txtSenH";
            this.txtSenH.Size = new System.Drawing.Size(134, 21);
            this.txtSenH.TabIndex = 8;
            this.txtSenH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenH_KeyPress);
            // 
            // txtSenA
            // 
            this.txtSenA.Location = new System.Drawing.Point(138, 212);
            this.txtSenA.MaxLength = 32;
            this.txtSenA.Name = "txtSenA";
            this.txtSenA.Size = new System.Drawing.Size(134, 21);
            this.txtSenA.TabIndex = 7;
            this.txtSenA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenA_KeyPress);
            // 
            // txtSenCH1
            // 
            this.txtSenCH1.Location = new System.Drawing.Point(138, 179);
            this.txtSenCH1.MaxLength = 32;
            this.txtSenCH1.Name = "txtSenCH1";
            this.txtSenCH1.Size = new System.Drawing.Size(134, 21);
            this.txtSenCH1.TabIndex = 6;
            this.txtSenCH1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenCH1_KeyPress);
            // 
            // lblSenV
            // 
            this.lblSenV.AutoSize = true;
            this.lblSenV.Location = new System.Drawing.Point(37, 283);
            this.lblSenV.Name = "lblSenV";
            this.lblSenV.Size = new System.Drawing.Size(98, 13);
            this.lblSenV.TabIndex = 7;
            this.lblSenV.Text = "Channel Sensitivity";
            // 
            // lblSenH
            // 
            this.lblSenH.AutoSize = true;
            this.lblSenH.Location = new System.Drawing.Point(37, 248);
            this.lblSenH.Name = "lblSenH";
            this.lblSenH.Size = new System.Drawing.Size(98, 13);
            this.lblSenH.TabIndex = 6;
            this.lblSenH.Text = "Channel Sensitivity";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(37, 49);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(72, 13);
            this.lblManufacturer.TabIndex = 5;
            this.lblManufacturer.Text = "Manufacturer";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(37, 84);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(37, 118);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(26, 13);
            this.lblUnit.TabIndex = 3;
            this.lblUnit.Text = "Unit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Channel Sensitivity";
            // 
            // lblSensAcc
            // 
            this.lblSensAcc.AutoSize = true;
            this.lblSensAcc.Location = new System.Drawing.Point(37, 215);
            this.lblSensAcc.Name = "lblSensAcc";
            this.lblSensAcc.Size = new System.Drawing.Size(98, 13);
            this.lblSensAcc.TabIndex = 1;
            this.lblSensAcc.Text = "Channel Sensitivity";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(37, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(34, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnNew);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Location = new System.Drawing.Point(3, 454);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(342, 45);
            this.panel3.TabIndex = 2;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(35, 5);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(235, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Delete";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(135, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblSensOffset);
            this.panel2.Controls.Add(this.txtSenOffset);
            this.panel2.Controls.Add(this.chkBoxICP);
            this.panel2.Location = new System.Drawing.Point(3, 378);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 70);
            this.panel2.TabIndex = 1;
            // 
            // lblSensOffset
            // 
            this.lblSensOffset.AutoSize = true;
            this.lblSensOffset.Location = new System.Drawing.Point(34, 8);
            this.lblSensOffset.Name = "lblSensOffset";
            this.lblSensOffset.Size = new System.Drawing.Size(59, 13);
            this.lblSensOffset.TabIndex = 16;
            this.lblSensOffset.Text = "Sen Offset";
            // 
            // txtSenOffset
            // 
            this.txtSenOffset.Location = new System.Drawing.Point(138, 8);
            this.txtSenOffset.MaxLength = 32;
            this.txtSenOffset.Name = "txtSenOffset";
            this.txtSenOffset.Size = new System.Drawing.Size(137, 21);
            this.txtSenOffset.TabIndex = 11;
            this.txtSenOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenOffset_KeyPress);
            // 
            // chkBoxICP
            // 
            this.chkBoxICP.AutoSize = true;
            this.chkBoxICP.Location = new System.Drawing.Point(34, 42);
            this.chkBoxICP.Name = "chkBoxICP";
            this.chkBoxICP.Size = new System.Drawing.Size(43, 17);
            this.chkBoxICP.TabIndex = 12;
            this.chkBoxICP.Text = "ICP";
            this.chkBoxICP.UseVisualStyleBackColor = true;
            // 
            // Sensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 510);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sensor";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sensor";
            this.Load += new System.EventHandler(this.Sensor_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRange;
        private System.Windows.Forms.ComboBox cmbRange;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.ComboBox cmbManu;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.TextBox txtSenV;
        private System.Windows.Forms.TextBox txtSenH;
        private System.Windows.Forms.TextBox txtSenA;
        private System.Windows.Forms.TextBox txtSenCH1;
        private System.Windows.Forms.Label lblSenV;
        private System.Windows.Forms.Label lblSenH;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSensAcc;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSensOffset;
        private System.Windows.Forms.TextBox txtSenOffset;
        private System.Windows.Forms.CheckBox chkBoxICP;
        private System.Windows.Forms.ComboBox cmbSenDir;
        private System.Windows.Forms.Label lblSensDir;

    }
}