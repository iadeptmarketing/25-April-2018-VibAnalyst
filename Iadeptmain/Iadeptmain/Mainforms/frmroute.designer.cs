namespace Iadeptmain.Mainforms
{
    partial class rproute
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
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.TxtRouteID = new DevExpress.XtraEditors.TextEdit();
            this.TxtRouteName = new DevExpress.XtraEditors.TextEdit();
            this.BtnTransfer = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbLevel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.trlFactoriesPrsnt11 = new DevExpress.XtraTreeList.TreeList();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblRUpload = new DevExpress.XtraEditors.LabelControl();
            this.tbUpTime = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new DevExpress.XtraEditors.LabelControl();
            this.btnDownloadRoute = new DevExpress.XtraEditors.SimpleButton();
            this.tbDnTime = new DevExpress.XtraEditors.TextEdit();
            this.btnUploadRoute = new DevExpress.XtraEditors.SimpleButton();
            this.tbUnfinised = new DevExpress.XtraEditors.TextEdit();
            this.trlRoute11 = new DevExpress.XtraTreeList.TreeList();
            this.lblRdnload = new DevExpress.XtraEditors.LabelControl();
            this.label6 = new DevExpress.XtraEditors.LabelControl();
            this.label9 = new DevExpress.XtraEditors.LabelControl();
            this.tbRouteElementName11 = new DevExpress.XtraEditors.TextEdit();
            this.tbArchive = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new DevExpress.XtraEditors.LabelControl();
            this.tbTaken = new DevExpress.XtraEditors.TextEdit();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insertRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRouteID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRouteName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlFactoriesPrsnt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUpTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDnTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUnfinised.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlRoute11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRouteElementName11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbArchive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTaken.Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.TxtRouteID);
            this.panelControl1.Controls.Add(this.TxtRouteName);
            this.panelControl1.Controls.Add(this.BtnTransfer);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.CmbLevel);
            this.panelControl1.Controls.Add(this.splitContainerControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1035, 402);
            this.panelControl1.TabIndex = 0;
            // 
            // TxtRouteID
            // 
            this.TxtRouteID.Location = new System.Drawing.Point(920, 31);
            this.TxtRouteID.Name = "TxtRouteID";
            this.TxtRouteID.Size = new System.Drawing.Size(98, 20);
            this.TxtRouteID.TabIndex = 9;
            this.TxtRouteID.Visible = false;
            // 
            // TxtRouteName
            // 
            this.TxtRouteName.Location = new System.Drawing.Point(661, 37);
            this.TxtRouteName.Name = "TxtRouteName";
            this.TxtRouteName.Properties.ReadOnly = true;
            this.TxtRouteName.Size = new System.Drawing.Size(225, 20);
            this.TxtRouteName.TabIndex = 8;
            this.TxtRouteName.Leave += new System.EventHandler(this.TxtRouteName_Leave);
            // 
            // BtnTransfer
            // 
            this.BtnTransfer.Image = global::Iadeptmain.XRDesignRibbonControllerResources.data_transfer_icon;
            this.BtnTransfer.Location = new System.Drawing.Point(670, 70);
            this.BtnTransfer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnTransfer.Name = "BtnTransfer";
            this.BtnTransfer.Size = new System.Drawing.Size(191, 55);
            this.BtnTransfer.TabIndex = 7;
            this.BtnTransfer.Text = "Transfer";
            this.BtnTransfer.Click += new System.EventHandler(this.BtnTransfer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(577, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Route Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Level";
            // 
            // CmbLevel
            // 
            this.CmbLevel.EditValue = "--Select--";
            this.CmbLevel.Location = new System.Drawing.Point(661, 9);
            this.CmbLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CmbLevel.Name = "CmbLevel";
            this.CmbLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbLevel.Properties.Items.AddRange(new object[] {
            "--Select--",
            "Plant",
            "Area",
            "Train",
            "Machine",
            "Point"});
            this.CmbLevel.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CmbLevel.Size = new System.Drawing.Size(225, 20);
            this.CmbLevel.TabIndex = 3;
            this.CmbLevel.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainerControl2.Appearance.Options.UseBackColor = true;
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainerControl2.Location = new System.Drawing.Point(2, 2);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.trlFactoriesPrsnt11);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerControl2.Panel2.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.splitContainerControl2.Panel2.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.splitContainerControl2.Panel2.Appearance.Options.UseBackColor = true;
            this.splitContainerControl2.Panel2.Appearance.Options.UseBorderColor = true;
            this.splitContainerControl2.Panel2.Controls.Add(this.simpleButton1);
            this.splitContainerControl2.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainerControl2.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblRUpload);
            this.splitContainerControl2.Panel2.Controls.Add(this.tbUpTime);
            this.splitContainerControl2.Panel2.Controls.Add(this.label10);
            this.splitContainerControl2.Panel2.Controls.Add(this.btnDownloadRoute);
            this.splitContainerControl2.Panel2.Controls.Add(this.tbDnTime);
            this.splitContainerControl2.Panel2.Controls.Add(this.btnUploadRoute);
            this.splitContainerControl2.Panel2.Controls.Add(this.tbUnfinised);
            this.splitContainerControl2.Panel2.Controls.Add(this.trlRoute11);
            this.splitContainerControl2.Panel2.Controls.Add(this.lblRdnload);
            this.splitContainerControl2.Panel2.Controls.Add(this.label6);
            this.splitContainerControl2.Panel2.Controls.Add(this.label9);
            this.splitContainerControl2.Panel2.Controls.Add(this.tbRouteElementName11);
            this.splitContainerControl2.Panel2.Controls.Add(this.tbArchive);
            this.splitContainerControl2.Panel2.Controls.Add(this.label8);
            this.splitContainerControl2.Panel2.Controls.Add(this.tbTaken);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(569, 398);
            this.splitContainerControl2.SplitterPosition = 235;
            this.splitContainerControl2.TabIndex = 2;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // trlFactoriesPrsnt11
            // 
            this.trlFactoriesPrsnt11.AllowDrop = true;
            this.trlFactoriesPrsnt11.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.trlFactoriesPrsnt11.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.trlFactoriesPrsnt11.Appearance.Empty.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.trlFactoriesPrsnt11.Appearance.EvenRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.trlFactoriesPrsnt11.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.trlFactoriesPrsnt11.Appearance.EvenRow.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.EvenRow.Options.UseBorderColor = true;
            this.trlFactoriesPrsnt11.Appearance.EvenRow.Options.UseForeColor = true;
            this.trlFactoriesPrsnt11.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.trlFactoriesPrsnt11.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.trlFactoriesPrsnt11.Appearance.FocusedCell.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.FocusedCell.Options.UseForeColor = true;
            this.trlFactoriesPrsnt11.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(109)))), ((int)(((byte)(189)))));
            this.trlFactoriesPrsnt11.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(139)))), ((int)(((byte)(206)))));
            this.trlFactoriesPrsnt11.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.trlFactoriesPrsnt11.Appearance.FocusedRow.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.trlFactoriesPrsnt11.Appearance.FocusedRow.Options.UseForeColor = true;
            this.trlFactoriesPrsnt11.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlFactoriesPrsnt11.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlFactoriesPrsnt11.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.trlFactoriesPrsnt11.Appearance.FooterPanel.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.trlFactoriesPrsnt11.Appearance.FooterPanel.Options.UseForeColor = true;
            this.trlFactoriesPrsnt11.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlFactoriesPrsnt11.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlFactoriesPrsnt11.Appearance.GroupButton.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.GroupButton.Options.UseBorderColor = true;
            this.trlFactoriesPrsnt11.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.trlFactoriesPrsnt11.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(254)))));
            this.trlFactoriesPrsnt11.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.trlFactoriesPrsnt11.Appearance.GroupFooter.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.trlFactoriesPrsnt11.Appearance.GroupFooter.Options.UseForeColor = true;
            this.trlFactoriesPrsnt11.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.trlFactoriesPrsnt11.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(201)))), ((int)(((byte)(254)))));
            this.trlFactoriesPrsnt11.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.trlFactoriesPrsnt11.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.trlFactoriesPrsnt11.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.trlFactoriesPrsnt11.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            this.trlFactoriesPrsnt11.Appearance.HideSelectionRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.trlFactoriesPrsnt11.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.trlFactoriesPrsnt11.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.HideSelectionRow.Options.UseBorderColor = true;
            this.trlFactoriesPrsnt11.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.trlFactoriesPrsnt11.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlFactoriesPrsnt11.Appearance.HorzLine.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.trlFactoriesPrsnt11.Appearance.OddRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.trlFactoriesPrsnt11.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.trlFactoriesPrsnt11.Appearance.OddRow.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.OddRow.Options.UseBorderColor = true;
            this.trlFactoriesPrsnt11.Appearance.OddRow.Options.UseForeColor = true;
            this.trlFactoriesPrsnt11.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.trlFactoriesPrsnt11.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.trlFactoriesPrsnt11.Appearance.Preview.Options.UseFont = true;
            this.trlFactoriesPrsnt11.Appearance.Preview.Options.UseForeColor = true;
            this.trlFactoriesPrsnt11.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.trlFactoriesPrsnt11.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.trlFactoriesPrsnt11.Appearance.Row.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.Row.Options.UseForeColor = true;
            this.trlFactoriesPrsnt11.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(155)))), ((int)(((byte)(215)))));
            this.trlFactoriesPrsnt11.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.trlFactoriesPrsnt11.Appearance.SelectedRow.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.SelectedRow.Options.UseForeColor = true;
            this.trlFactoriesPrsnt11.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(133)))), ((int)(((byte)(195)))));
            this.trlFactoriesPrsnt11.Appearance.TreeLine.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.trlFactoriesPrsnt11.Appearance.VertLine.Options.UseBackColor = true;
            this.trlFactoriesPrsnt11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlFactoriesPrsnt11.Location = new System.Drawing.Point(0, 0);
            this.trlFactoriesPrsnt11.Name = "trlFactoriesPrsnt11";
            this.trlFactoriesPrsnt11.OptionsBehavior.DragNodes = true;
            this.trlFactoriesPrsnt11.OptionsBehavior.Editable = false;
            this.trlFactoriesPrsnt11.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.trlFactoriesPrsnt11.OptionsView.EnableAppearanceEvenRow = true;
            this.trlFactoriesPrsnt11.OptionsView.EnableAppearanceOddRow = true;
            this.trlFactoriesPrsnt11.Size = new System.Drawing.Size(235, 398);
            this.trlFactoriesPrsnt11.TabIndex = 0;
            this.trlFactoriesPrsnt11.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trlFactoriesPrsnt11_MouseMove);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Enabled = false;
            this.simpleButton1.Location = new System.Drawing.Point(756, 149);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(82, 21);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "Rename";
            // 
            // pictureBox2
            // 
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.Location = new System.Drawing.Point(697, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(129, 106);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(347, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 106);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblRUpload
            // 
            this.lblRUpload.Location = new System.Drawing.Point(463, 191);
            this.lblRUpload.Name = "lblRUpload";
            this.lblRUpload.Size = new System.Drawing.Size(68, 13);
            this.lblRUpload.TabIndex = 1;
            this.lblRUpload.Text = "Last Uploaded";
            // 
            // tbUpTime
            // 
            this.tbUpTime.Location = new System.Drawing.Point(466, 208);
            this.tbUpTime.Name = "tbUpTime";
            this.tbUpTime.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tbUpTime.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Italic);
            this.tbUpTime.Properties.Appearance.Options.UseBackColor = true;
            this.tbUpTime.Properties.Appearance.Options.UseFont = true;
            this.tbUpTime.Properties.ReadOnly = true;
            this.tbUpTime.Size = new System.Drawing.Size(237, 20);
            this.tbUpTime.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(463, 356);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Last Downloaded Unfinished";
            // 
            // btnDownloadRoute
            // 
            this.btnDownloadRoute.Location = new System.Drawing.Point(486, 72);
            this.btnDownloadRoute.Name = "btnDownloadRoute";
            this.btnDownloadRoute.Size = new System.Drawing.Size(203, 21);
            this.btnDownloadRoute.TabIndex = 2;
            this.btnDownloadRoute.ToolTip = "Download Selected Route to Computer";
            // 
            // tbDnTime
            // 
            this.tbDnTime.Location = new System.Drawing.Point(466, 251);
            this.tbDnTime.Name = "tbDnTime";
            this.tbDnTime.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tbDnTime.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Italic);
            this.tbDnTime.Properties.Appearance.Options.UseBackColor = true;
            this.tbDnTime.Properties.Appearance.Options.UseFont = true;
            this.tbDnTime.Properties.ReadOnly = true;
            this.tbDnTime.Size = new System.Drawing.Size(237, 20);
            this.tbDnTime.TabIndex = 0;
            // 
            // btnUploadRoute
            // 
            this.btnUploadRoute.Location = new System.Drawing.Point(486, 32);
            this.btnUploadRoute.Name = "btnUploadRoute";
            this.btnUploadRoute.Size = new System.Drawing.Size(203, 21);
            this.btnUploadRoute.TabIndex = 2;
            this.btnUploadRoute.ToolTip = "Upload Selected Route to instrument";
            // 
            // tbUnfinised
            // 
            this.tbUnfinised.Location = new System.Drawing.Point(466, 373);
            this.tbUnfinised.Name = "tbUnfinised";
            this.tbUnfinised.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tbUnfinised.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Italic);
            this.tbUnfinised.Properties.Appearance.Options.UseBackColor = true;
            this.tbUnfinised.Properties.Appearance.Options.UseFont = true;
            this.tbUnfinised.Properties.ReadOnly = true;
            this.tbUnfinised.Size = new System.Drawing.Size(237, 20);
            this.tbUnfinised.TabIndex = 5;
            // 
            // trlRoute11
            // 
            this.trlRoute11.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.trlRoute11.Appearance.Empty.BackColor2 = System.Drawing.Color.White;
            this.trlRoute11.Appearance.Empty.Options.UseBackColor = true;
            this.trlRoute11.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.trlRoute11.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.trlRoute11.Appearance.EvenRow.Options.UseBackColor = true;
            this.trlRoute11.Appearance.EvenRow.Options.UseForeColor = true;
            this.trlRoute11.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.trlRoute11.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.trlRoute11.Appearance.FocusedCell.Options.UseBackColor = true;
            this.trlRoute11.Appearance.FocusedCell.Options.UseForeColor = true;
            this.trlRoute11.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.trlRoute11.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.trlRoute11.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.trlRoute11.Appearance.FocusedRow.Options.UseBackColor = true;
            this.trlRoute11.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.trlRoute11.Appearance.FocusedRow.Options.UseForeColor = true;
            this.trlRoute11.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.trlRoute11.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.trlRoute11.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White;
            this.trlRoute11.Appearance.FooterPanel.Options.UseBackColor = true;
            this.trlRoute11.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.trlRoute11.Appearance.FooterPanel.Options.UseForeColor = true;
            this.trlRoute11.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.trlRoute11.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(139)))), ((int)(((byte)(48)))));
            this.trlRoute11.Appearance.GroupButton.ForeColor = System.Drawing.Color.White;
            this.trlRoute11.Appearance.GroupButton.Options.UseBackColor = true;
            this.trlRoute11.Appearance.GroupButton.Options.UseBorderColor = true;
            this.trlRoute11.Appearance.GroupButton.Options.UseForeColor = true;
            this.trlRoute11.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.trlRoute11.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(193)))), ((int)(((byte)(55)))));
            this.trlRoute11.Appearance.GroupFooter.Options.UseBackColor = true;
            this.trlRoute11.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.trlRoute11.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.trlRoute11.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(57)))));
            this.trlRoute11.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.trlRoute11.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.trlRoute11.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.trlRoute11.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.trlRoute11.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(158)))), ((int)(((byte)(64)))));
            this.trlRoute11.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(231)))), ((int)(((byte)(177)))));
            this.trlRoute11.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.trlRoute11.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.trlRoute11.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.trlRoute11.Appearance.HorzLine.Options.UseBackColor = true;
            this.trlRoute11.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(230)))));
            this.trlRoute11.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.trlRoute11.Appearance.OddRow.Options.UseBackColor = true;
            this.trlRoute11.Appearance.OddRow.Options.UseForeColor = true;
            this.trlRoute11.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(253)))), ((int)(((byte)(246)))));
            this.trlRoute11.Appearance.Preview.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.trlRoute11.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(114)))), ((int)(((byte)(50)))));
            this.trlRoute11.Appearance.Preview.Options.UseBackColor = true;
            this.trlRoute11.Appearance.Preview.Options.UseFont = true;
            this.trlRoute11.Appearance.Preview.Options.UseForeColor = true;
            this.trlRoute11.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(230)))));
            this.trlRoute11.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.trlRoute11.Appearance.Row.Options.UseBackColor = true;
            this.trlRoute11.Appearance.Row.Options.UseForeColor = true;
            this.trlRoute11.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(139)))), ((int)(((byte)(41)))));
            this.trlRoute11.Appearance.SelectedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(139)))), ((int)(((byte)(41)))));
            this.trlRoute11.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.trlRoute11.Appearance.SelectedRow.Options.UseBackColor = true;
            this.trlRoute11.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.trlRoute11.Appearance.SelectedRow.Options.UseForeColor = true;
            this.trlRoute11.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.trlRoute11.Appearance.TreeLine.Options.UseBackColor = true;
            this.trlRoute11.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(166)))), ((int)(((byte)(37)))));
            this.trlRoute11.Appearance.VertLine.Options.UseBackColor = true;
            this.trlRoute11.Dock = System.Windows.Forms.DockStyle.Left;
            this.trlRoute11.DragNodesMode = DevExpress.XtraTreeList.TreeListDragNodesMode.Advanced;
            this.trlRoute11.Location = new System.Drawing.Point(0, 0);
            this.trlRoute11.Name = "trlRoute11";
            this.trlRoute11.OptionsBehavior.Editable = false;
            this.trlRoute11.OptionsView.EnableAppearanceEvenRow = true;
            this.trlRoute11.OptionsView.EnableAppearanceOddRow = true;
            this.trlRoute11.Size = new System.Drawing.Size(329, 398);
            this.trlRoute11.TabIndex = 0;
            this.trlRoute11.DragLeave += new System.EventHandler(this.trlRoute11_DragLeave);
            this.trlRoute11.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trlRoute11_MouseClick);
            this.trlRoute11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trlRoute11_MouseDown);
            // 
            // lblRdnload
            // 
            this.lblRdnload.Location = new System.Drawing.Point(463, 234);
            this.lblRdnload.Name = "lblRdnload";
            this.lblRdnload.Size = new System.Drawing.Size(82, 13);
            this.lblRdnload.TabIndex = 1;
            this.lblRdnload.Text = "Last Downloaded";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(463, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Name";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(463, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Last Downloaded Skipped";
            // 
            // tbRouteElementName11
            // 
            this.tbRouteElementName11.Location = new System.Drawing.Point(466, 149);
            this.tbRouteElementName11.Name = "tbRouteElementName11";
            this.tbRouteElementName11.Size = new System.Drawing.Size(283, 20);
            this.tbRouteElementName11.TabIndex = 0;
            // 
            // tbArchive
            // 
            this.tbArchive.Location = new System.Drawing.Point(466, 292);
            this.tbArchive.Name = "tbArchive";
            this.tbArchive.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tbArchive.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Italic);
            this.tbArchive.Properties.Appearance.Options.UseBackColor = true;
            this.tbArchive.Properties.Appearance.Options.UseFont = true;
            this.tbArchive.Properties.ReadOnly = true;
            this.tbArchive.Size = new System.Drawing.Size(237, 20);
            this.tbArchive.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(463, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Last Downloaded Archive";
            // 
            // tbTaken
            // 
            this.tbTaken.Location = new System.Drawing.Point(466, 334);
            this.tbTaken.Name = "tbTaken";
            this.tbTaken.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.tbTaken.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Italic);
            this.tbTaken.Properties.Appearance.Options.UseBackColor = true;
            this.tbTaken.Properties.Appearance.Options.UseFont = true;
            this.tbTaken.Properties.ReadOnly = true;
            this.tbTaken.Size = new System.Drawing.Size(237, 20);
            this.tbTaken.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertRouteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // insertRouteToolStripMenuItem
            // 
            this.insertRouteToolStripMenuItem.Name = "insertRouteToolStripMenuItem";
            this.insertRouteToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.insertRouteToolStripMenuItem.Text = "Insert Route";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // rproute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 402);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rproute";
            this.ShowIcon = false;
            this.Text = "Route Manager";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRouteID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRouteName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlFactoriesPrsnt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUpTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDnTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbUnfinised.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlRoute11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRouteElementName11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbArchive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTaken.Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton BtnTransfer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit CmbLevel;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraTreeList.TreeList trlFactoriesPrsnt11;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl lblRUpload;
        private DevExpress.XtraEditors.TextEdit tbUpTime;
        private DevExpress.XtraEditors.LabelControl label10;
        private DevExpress.XtraEditors.SimpleButton btnDownloadRoute;
        private DevExpress.XtraEditors.TextEdit tbDnTime;
        private DevExpress.XtraEditors.SimpleButton btnUploadRoute;
        private DevExpress.XtraEditors.TextEdit tbUnfinised;
        private DevExpress.XtraTreeList.TreeList trlRoute11;
        private DevExpress.XtraEditors.LabelControl lblRdnload;
        private DevExpress.XtraEditors.LabelControl label6;
        private DevExpress.XtraEditors.LabelControl label9;
        private DevExpress.XtraEditors.TextEdit tbRouteElementName11;
        private DevExpress.XtraEditors.TextEdit tbArchive;
        private DevExpress.XtraEditors.LabelControl label8;
        private DevExpress.XtraEditors.TextEdit tbTaken;
        private DevExpress.XtraEditors.TextEdit TxtRouteName;
        private DevExpress.XtraEditors.TextEdit TxtRouteID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem insertRouteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}