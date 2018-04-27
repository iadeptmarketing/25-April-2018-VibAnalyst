namespace Iadeptmain.Mainforms
{
    partial class Form_MotorDes
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
            this.reflectionImageMotor = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX4 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX5 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.cmbSensors = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbSenType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.ciAcc = new DevComponents.Editors.ComboItem();
            this.ciVel = new DevComponents.Editors.ComboItem();
            this.ciDisp = new DevComponents.Editors.ComboItem();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.tbSenZ = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbSenY = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbSenX = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labeluniY = new DevComponents.DotNetBar.LabelX();
            this.labeluniZ = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.cmbSenDir = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.cbVert = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cmbSenUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.cbHori = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.cbAxial = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reflectionImageMotor
            // 
            this.reflectionImageMotor.BackColor = System.Drawing.Color.AliceBlue;
            this.reflectionImageMotor.Dock = System.Windows.Forms.DockStyle.Left;
            this.reflectionImageMotor.Location = new System.Drawing.Point(0, 0);
            this.reflectionImageMotor.Name = "reflectionImageMotor";
            this.reflectionImageMotor.Size = new System.Drawing.Size(274, 429);
            this.reflectionImageMotor.TabIndex = 0;
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(280, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(122, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Name";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Location = new System.Drawing.Point(408, 12);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(172, 20);
            this.textBoxX1.TabIndex = 2;
            this.textBoxX1.WatermarkText = "Machine Name";
            this.textBoxX1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPressSpaceCheck);
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Location = new System.Drawing.Point(408, 38);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(172, 20);
            this.textBoxX2.TabIndex = 4;
            this.textBoxX2.WatermarkText = "RPM Value of Machine";
            this.textBoxX2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxX2_KeyPress);
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(280, 35);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(122, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "RPM";
            // 
            // textBoxX4
            // 
            // 
            // 
            // 
            this.textBoxX4.Border.Class = "TextBoxBorder";
            this.textBoxX4.Location = new System.Drawing.Point(408, 64);
            this.textBoxX4.Name = "textBoxX4";
            this.textBoxX4.Size = new System.Drawing.Size(172, 20);
            this.textBoxX4.TabIndex = 8;
            this.textBoxX4.WatermarkText = "Serial Number of Machine";
            this.textBoxX4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxX4_KeyPress);
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(280, 61);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(122, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "Serial Number";
            // 
            // textBoxX5
            // 
            // 
            // 
            // 
            this.textBoxX5.Border.Class = "TextBoxBorder";
            this.textBoxX5.Location = new System.Drawing.Point(408, 90);
            this.textBoxX5.Name = "textBoxX5";
            this.textBoxX5.Size = new System.Drawing.Size(172, 20);
            this.textBoxX5.TabIndex = 10;
            this.textBoxX5.WatermarkText = "Make of Machine";
            // 
            // labelX5
            // 
            this.labelX5.Location = new System.Drawing.Point(280, 87);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(122, 23);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "Make";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(423, 394);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 11;
            this.buttonX1.Text = "OK";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonX2.Location = new System.Drawing.Point(504, 394);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 15;
            this.buttonX2.Text = "Cancel";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.labelX9);
            this.groupPanel1.Controls.Add(this.cmbSensors);
            this.groupPanel1.Controls.Add(this.cmbSenType);
            this.groupPanel1.Controls.Add(this.labelX8);
            this.groupPanel1.Controls.Add(this.tbSenZ);
            this.groupPanel1.Controls.Add(this.tbSenY);
            this.groupPanel1.Controls.Add(this.tbSenX);
            this.groupPanel1.Controls.Add(this.labeluniY);
            this.groupPanel1.Controls.Add(this.labeluniZ);
            this.groupPanel1.Controls.Add(this.labelX7);
            this.groupPanel1.Controls.Add(this.cmbSenDir);
            this.groupPanel1.Controls.Add(this.cbVert);
            this.groupPanel1.Controls.Add(this.cmbSenUnit);
            this.groupPanel1.Controls.Add(this.cbHori);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.cbAxial);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Location = new System.Drawing.Point(280, 116);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(292, 272);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.AliceBlue;
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.AliceBlue;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 16;
            this.groupPanel1.Text = "Sensor Settings";
            this.groupPanel1.Click += new System.EventHandler(this.groupPanel1_DoubleClick);
            this.groupPanel1.DoubleClick += new System.EventHandler(this.groupPanel1_DoubleClick);
            // 
            // labelX9
            // 
            this.labelX9.Location = new System.Drawing.Point(3, 3);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(75, 23);
            this.labelX9.TabIndex = 48;
            this.labelX9.Text = "Sensor Name";
            // 
            // cmbSensors
            // 
            this.cmbSensors.DisplayMember = "Text";
            this.cmbSensors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSensors.FormattingEnabled = true;
            this.cmbSensors.ItemHeight = 14;
            this.cmbSensors.Location = new System.Drawing.Point(92, 3);
            this.cmbSensors.Name = "cmbSensors";
            this.cmbSensors.Size = new System.Drawing.Size(140, 20);
            this.cmbSensors.TabIndex = 47;
            this.cmbSensors.SelectedIndexChanged += new System.EventHandler(this.cmbSensors_SelectedIndexChanged);
            // 
            // cmbSenType
            // 
            this.cmbSenType.DisplayMember = "Text";
            this.cmbSenType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSenType.Enabled = false;
            this.cmbSenType.FormattingEnabled = true;
            this.cmbSenType.ItemHeight = 15;
            this.cmbSenType.Items.AddRange(new object[] {
            this.ciAcc,
            this.ciVel,
            this.ciDisp});
            this.cmbSenType.Location = new System.Drawing.Point(92, 31);
            this.cmbSenType.Name = "cmbSenType";
            this.cmbSenType.Size = new System.Drawing.Size(140, 21);
            this.cmbSenType.TabIndex = 46;
            this.cmbSenType.SelectedIndexChanged += new System.EventHandler(this.cmbSenType_SelectedIndexChanged);
            // 
            // ciAcc
            // 
            this.ciAcc.Text = "Acceleration";
            // 
            // ciVel
            // 
            this.ciVel.Text = "Velocity";
            // 
            // ciDisp
            // 
            this.ciDisp.Text = "Displacement";
            // 
            // labelX8
            // 
            this.labelX8.Location = new System.Drawing.Point(3, 29);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 45;
            this.labelX8.Text = "Sensor Type";
            // 
            // tbSenZ
            // 
            // 
            // 
            // 
            this.tbSenZ.Border.Class = "TextBoxBorder";
            this.tbSenZ.Enabled = false;
            this.tbSenZ.Location = new System.Drawing.Point(92, 180);
            this.tbSenZ.Name = "tbSenZ";
            this.tbSenZ.Size = new System.Drawing.Size(140, 20);
            this.tbSenZ.TabIndex = 44;
            this.tbSenZ.WatermarkText = "Value in mV/G";
            this.tbSenZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxX2_KeyPress);
            // 
            // tbSenY
            // 
            // 
            // 
            // 
            this.tbSenY.Border.Class = "TextBoxBorder";
            this.tbSenY.Enabled = false;
            this.tbSenY.Location = new System.Drawing.Point(92, 150);
            this.tbSenY.Name = "tbSenY";
            this.tbSenY.Size = new System.Drawing.Size(140, 20);
            this.tbSenY.TabIndex = 43;
            this.tbSenY.WatermarkText = "Value in mV/G";
            this.tbSenY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxX2_KeyPress);
            // 
            // tbSenX
            // 
            // 
            // 
            // 
            this.tbSenX.Border.Class = "TextBoxBorder";
            this.tbSenX.Enabled = false;
            this.tbSenX.Location = new System.Drawing.Point(92, 120);
            this.tbSenX.Name = "tbSenX";
            this.tbSenX.Size = new System.Drawing.Size(140, 20);
            this.tbSenX.TabIndex = 42;
            this.tbSenX.WatermarkText = "Value in mV/G";
            this.tbSenX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxX2_KeyPress);
            // 
            // labeluniY
            // 
            this.labeluniY.Location = new System.Drawing.Point(3, 150);
            this.labeluniY.Name = "labeluniY";
            this.labeluniY.Size = new System.Drawing.Size(75, 23);
            this.labeluniY.TabIndex = 41;
            this.labeluniY.Text = "                      Y";
            // 
            // labeluniZ
            // 
            this.labeluniZ.Location = new System.Drawing.Point(3, 180);
            this.labeluniZ.Name = "labeluniZ";
            this.labeluniZ.Size = new System.Drawing.Size(75, 23);
            this.labeluniZ.TabIndex = 40;
            this.labeluniZ.Text = "                      Z";
            // 
            // labelX7
            // 
            this.labelX7.Location = new System.Drawing.Point(3, 120);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 39;
            this.labelX7.Text = "Sensitivity    X";
            // 
            // cmbSenDir
            // 
            this.cmbSenDir.DisplayMember = "Text";
            this.cmbSenDir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSenDir.Enabled = false;
            this.cmbSenDir.FormattingEnabled = true;
            this.cmbSenDir.ItemHeight = 15;
            this.cmbSenDir.Items.AddRange(new object[] {
            this.comboItem4,
            this.comboItem5});
            this.cmbSenDir.Location = new System.Drawing.Point(92, 90);
            this.cmbSenDir.Name = "cmbSenDir";
            this.cmbSenDir.Size = new System.Drawing.Size(140, 21);
            this.cmbSenDir.TabIndex = 35;
            this.cmbSenDir.SelectedIndexChanged += new System.EventHandler(this.cmbSenDir_SelectedIndexChanged);
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "Triaxial";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "Uniaxial";
            // 
            // cbVert
            // 
            this.cbVert.Location = new System.Drawing.Point(205, 215);
            this.cbVert.Name = "cbVert";
            this.cbVert.Size = new System.Drawing.Size(75, 23);
            this.cbVert.TabIndex = 38;
            this.cbVert.Text = "Vertical";
            // 
            // cmbSenUnit
            // 
            this.cmbSenUnit.DisplayMember = "Text";
            this.cmbSenUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSenUnit.Enabled = false;
            this.cmbSenUnit.FormattingEnabled = true;
            this.cmbSenUnit.ItemHeight = 15;
            this.cmbSenUnit.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cmbSenUnit.Location = new System.Drawing.Point(92, 60);
            this.cmbSenUnit.Name = "cmbSenUnit";
            this.cmbSenUnit.Size = new System.Drawing.Size(140, 21);
            this.cmbSenUnit.TabIndex = 34;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "Gs";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "gal";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "m/s-2";
            // 
            // cbHori
            // 
            this.cbHori.Location = new System.Drawing.Point(93, 215);
            this.cbHori.Name = "cbHori";
            this.cbHori.Size = new System.Drawing.Size(75, 23);
            this.cbHori.TabIndex = 37;
            this.cbHori.Text = "Horizontal";
            // 
            // labelX6
            // 
            this.labelX6.Location = new System.Drawing.Point(3, 90);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 33;
            this.labelX6.Text = "Direction";
            // 
            // cbAxial
            // 
            this.cbAxial.Location = new System.Drawing.Point(3, 215);
            this.cbAxial.Name = "cbAxial";
            this.cbAxial.Size = new System.Drawing.Size(75, 23);
            this.cbAxial.TabIndex = 36;
            this.cbAxial.Text = "Axial";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(3, 60);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 32;
            this.labelX3.Text = "Sensor Unit";
            // 
            // Form_MotorDes
            // 
            this.AcceptButton = this.buttonX1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CancelButton = this.buttonX2;
            this.ClientSize = new System.Drawing.Size(592, 429);
            this.ControlBox = false;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.textBoxX5);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.textBoxX4);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.reflectionImageMotor);
            this.Name = "Form_MotorDes";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Item";
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImageMotor;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX4;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX5;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSenZ;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSenY;
        private DevComponents.DotNetBar.Controls.TextBoxX tbSenX;
        private DevComponents.DotNetBar.LabelX labeluniY;
        private DevComponents.DotNetBar.LabelX labeluniZ;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSenDir;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbVert;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSenUnit;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbHori;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbAxial;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSenType;
        private DevComponents.Editors.ComboItem ciAcc;
        private DevComponents.Editors.ComboItem ciVel;
        private DevComponents.Editors.ComboItem ciDisp;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSensors;
    }
}