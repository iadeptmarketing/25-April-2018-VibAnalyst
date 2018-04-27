namespace Iadeptmain.Mainforms
{
    partial class frmPointInfo
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Overall Acceleration");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Overall Velocity");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Overall Displacement");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Overall Bearing");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Time WaveForm");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Power Spectrum");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Demodulate Spectrum");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Temperature");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Process Parameter");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Crest Factor");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("OrderTrace");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Cepstrum");
            this.gbpTypeInfo = new System.Windows.Forms.GroupBox();
            this.txtPType = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.bsPTypeInfo = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControl2 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControl3 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControl4 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControl5 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewTabItem1 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator1 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItem2 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator2 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItem3 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator3 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItem4 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator4 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.backstageViewTabItem5 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator5 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lstmeasure = new System.Windows.Forms.ListView();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.gbpTypeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPType.Properties)).BeginInit();
            this.bsPTypeInfo.SuspendLayout();
            this.backstageViewClientControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbpTypeInfo
            // 
            this.gbpTypeInfo.Controls.Add(this.txtPType);
            this.gbpTypeInfo.Controls.Add(this.labelControl1);
            this.gbpTypeInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbpTypeInfo.Location = new System.Drawing.Point(0, 0);
            this.gbpTypeInfo.Name = "gbpTypeInfo";
            this.gbpTypeInfo.Size = new System.Drawing.Size(475, 37);
            this.gbpTypeInfo.TabIndex = 0;
            this.gbpTypeInfo.TabStop = false;
            // 
            // txtPType
            // 
            this.txtPType.Location = new System.Drawing.Point(173, 10);
            this.txtPType.Name = "txtPType";
            this.txtPType.Properties.ReadOnly = true;
            this.txtPType.Size = new System.Drawing.Size(188, 20);
            this.txtPType.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(38, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(95, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Selected Point Type";
            // 
            // bsPTypeInfo
            // 
            this.bsPTypeInfo.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.bsPTypeInfo.Controls.Add(this.backstageViewClientControl1);
            this.bsPTypeInfo.Controls.Add(this.backstageViewClientControl2);
            this.bsPTypeInfo.Controls.Add(this.backstageViewClientControl3);
            this.bsPTypeInfo.Controls.Add(this.backstageViewClientControl4);
            this.bsPTypeInfo.Controls.Add(this.backstageViewClientControl5);
            this.bsPTypeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bsPTypeInfo.Items.Add(this.backstageViewTabItem1);
            this.bsPTypeInfo.Items.Add(this.backstageViewItemSeparator1);
            this.bsPTypeInfo.Items.Add(this.backstageViewTabItem2);
            this.bsPTypeInfo.Items.Add(this.backstageViewItemSeparator2);
            this.bsPTypeInfo.Items.Add(this.backstageViewTabItem3);
            this.bsPTypeInfo.Items.Add(this.backstageViewItemSeparator3);
            this.bsPTypeInfo.Items.Add(this.backstageViewTabItem4);
            this.bsPTypeInfo.Items.Add(this.backstageViewItemSeparator4);
            this.bsPTypeInfo.Items.Add(this.backstageViewTabItem5);
            this.bsPTypeInfo.Items.Add(this.backstageViewItemSeparator5);
            this.bsPTypeInfo.Location = new System.Drawing.Point(0, 37);
            this.bsPTypeInfo.Name = "bsPTypeInfo";
            this.bsPTypeInfo.SelectedTab = this.backstageViewTabItem2;
            this.bsPTypeInfo.SelectedTabIndex = 2;
            this.bsPTypeInfo.Size = new System.Drawing.Size(475, 256);
            this.bsPTypeInfo.TabIndex = 1;
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Controls.Add(this.groupControl2);
            this.backstageViewClientControl1.Location = new System.Drawing.Point(144, 0);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(331, 256);
            this.backstageViewClientControl1.TabIndex = 1;
            // 
            // backstageViewClientControl2
            // 
            this.backstageViewClientControl2.Location = new System.Drawing.Point(144, 0);
            this.backstageViewClientControl2.Name = "backstageViewClientControl2";
            this.backstageViewClientControl2.Size = new System.Drawing.Size(331, 256);
            this.backstageViewClientControl2.TabIndex = 2;
            // 
            // backstageViewClientControl3
            // 
            this.backstageViewClientControl3.Location = new System.Drawing.Point(144, 0);
            this.backstageViewClientControl3.Name = "backstageViewClientControl3";
            this.backstageViewClientControl3.Size = new System.Drawing.Size(331, 256);
            this.backstageViewClientControl3.TabIndex = 3;
            // 
            // backstageViewClientControl4
            // 
            this.backstageViewClientControl4.Location = new System.Drawing.Point(144, 0);
            this.backstageViewClientControl4.Name = "backstageViewClientControl4";
            this.backstageViewClientControl4.Size = new System.Drawing.Size(331, 256);
            this.backstageViewClientControl4.TabIndex = 4;
            // 
            // backstageViewClientControl5
            // 
            this.backstageViewClientControl5.Location = new System.Drawing.Point(144, 0);
            this.backstageViewClientControl5.Name = "backstageViewClientControl5";
            this.backstageViewClientControl5.Size = new System.Drawing.Size(331, 256);
            this.backstageViewClientControl5.TabIndex = 5;
            // 
            // backstageViewTabItem1
            // 
            this.backstageViewTabItem1.Caption = "Measurement";
            this.backstageViewTabItem1.CaptionHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center;
            this.backstageViewTabItem1.ContentControl = this.backstageViewClientControl1;
            this.backstageViewTabItem1.Name = "backstageViewTabItem1";
            this.backstageViewTabItem1.Selected = false;
            // 
            // backstageViewItemSeparator1
            // 
            this.backstageViewItemSeparator1.Name = "backstageViewItemSeparator1";
            // 
            // backstageViewTabItem2
            // 
            this.backstageViewTabItem2.Caption = "OverAll";
            this.backstageViewTabItem2.CaptionHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center;
            this.backstageViewTabItem2.ContentControl = this.backstageViewClientControl2;
            this.backstageViewTabItem2.Name = "backstageViewTabItem2";
            this.backstageViewTabItem2.Selected = true;
            // 
            // backstageViewItemSeparator2
            // 
            this.backstageViewItemSeparator2.Name = "backstageViewItemSeparator2";
            // 
            // backstageViewTabItem3
            // 
            this.backstageViewTabItem3.Caption = "Alarms";
            this.backstageViewTabItem3.CaptionHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center;
            this.backstageViewTabItem3.ContentControl = this.backstageViewClientControl3;
            this.backstageViewTabItem3.Name = "backstageViewTabItem3";
            this.backstageViewTabItem3.Selected = false;
            // 
            // backstageViewItemSeparator3
            // 
            this.backstageViewItemSeparator3.Name = "backstageViewItemSeparator3";
            // 
            // backstageViewTabItem4
            // 
            this.backstageViewTabItem4.Caption = "Power Spectrum";
            this.backstageViewTabItem4.CaptionHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center;
            this.backstageViewTabItem4.ContentControl = this.backstageViewClientControl4;
            this.backstageViewTabItem4.Name = "backstageViewTabItem4";
            this.backstageViewTabItem4.Selected = false;
            // 
            // backstageViewItemSeparator4
            // 
            this.backstageViewItemSeparator4.Name = "backstageViewItemSeparator4";
            // 
            // backstageViewTabItem5
            // 
            this.backstageViewTabItem5.Caption = "Units";
            this.backstageViewTabItem5.CaptionHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center;
            this.backstageViewTabItem5.ContentControl = this.backstageViewClientControl5;
            this.backstageViewTabItem5.Name = "backstageViewTabItem5";
            this.backstageViewTabItem5.Selected = false;
            // 
            // backstageViewItemSeparator5
            // 
            this.backstageViewItemSeparator5.Name = "backstageViewItemSeparator5";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.AppearanceCaption.BorderColor = System.Drawing.Color.Transparent;
            this.groupControl2.AppearanceCaption.Options.UseBorderColor = true;
            this.groupControl2.AutoSize = true;
            this.groupControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl2.Controls.Add(this.lstmeasure);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.FireScrollEventOnMouseWheel = true;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(331, 256);
            this.groupControl2.TabIndex = 47;
            // 
            // lstmeasure
            // 
            this.lstmeasure.BackColor = System.Drawing.Color.White;
            this.lstmeasure.CheckBoxes = true;
            listViewItem1.Checked = true;
            listViewItem1.StateImageIndex = 1;
            listViewItem1.ToolTipText = "Overall Acceleration";
            listViewItem2.Checked = true;
            listViewItem2.IndentCount = 1;
            listViewItem2.StateImageIndex = 1;
            listViewItem2.ToolTipText = "Overall Velocity";
            listViewItem3.Checked = true;
            listViewItem3.StateImageIndex = 1;
            listViewItem3.ToolTipText = "Overall Displacement";
            listViewItem4.Checked = true;
            listViewItem4.IndentCount = 1;
            listViewItem4.StateImageIndex = 1;
            listViewItem4.ToolTipText = "Overall Bearing";
            listViewItem5.Checked = true;
            listViewItem5.StateImageIndex = 1;
            listViewItem5.ToolTipText = "Time WaveForm";
            listViewItem6.Checked = true;
            listViewItem6.IndentCount = 1;
            listViewItem6.StateImageIndex = 1;
            listViewItem6.ToolTipText = "Power Spectrum";
            listViewItem7.Checked = true;
            listViewItem7.StateImageIndex = 1;
            listViewItem7.ToolTipText = "Demodulate Spectrum";
            listViewItem8.IndentCount = 1;
            listViewItem8.StateImageIndex = 0;
            listViewItem8.ToolTipText = "Temperature";
            listViewItem9.StateImageIndex = 0;
            listViewItem9.ToolTipText = "Process Parameter";
            listViewItem10.Checked = true;
            listViewItem10.StateImageIndex = 1;
            listViewItem10.ToolTipText = "Crest Factor";
            listViewItem11.Checked = true;
            listViewItem11.StateImageIndex = 1;
            listViewItem11.ToolTipText = "Order Trace";
            listViewItem12.Checked = true;
            listViewItem12.StateImageIndex = 1;
            listViewItem12.ToolTipText = "Cepstrum";
            this.lstmeasure.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12});
            this.lstmeasure.Location = new System.Drawing.Point(9, 23);
            this.lstmeasure.Name = "lstmeasure";
            this.lstmeasure.Size = new System.Drawing.Size(287, 124);
            this.lstmeasure.TabIndex = 37;
            this.lstmeasure.UseCompatibleStateImageBehavior = false;
            this.lstmeasure.View = System.Windows.Forms.View.List;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 35;
            this.labelControl2.Text = "Measurement";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 150);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(92, 13);
            this.labelControl4.TabIndex = 25;
            this.labelControl4.Text = "Last Analyzed:   ---\r\n";
            // 
            // frmPointInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 293);
            this.Controls.Add(this.bsPTypeInfo);
            this.Controls.Add(this.gbpTypeInfo);
            this.Name = "frmPointInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point Information";
            this.gbpTypeInfo.ResumeLayout(false);
            this.gbpTypeInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPType.Properties)).EndInit();
            this.bsPTypeInfo.ResumeLayout(false);
            this.backstageViewClientControl1.ResumeLayout(false);
            this.backstageViewClientControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbpTypeInfo;
        private DevExpress.XtraEditors.TextEdit txtPType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl bsPTypeInfo;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl2;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl3;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl4;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl5;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem1;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem2;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator2;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem3;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator3;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem4;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator4;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem5;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator5;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.ListView lstmeasure;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}