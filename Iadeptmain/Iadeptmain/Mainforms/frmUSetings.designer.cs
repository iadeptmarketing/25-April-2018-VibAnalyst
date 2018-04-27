namespace Iadeptmain.Mainforms
{
    partial class frmUSetings
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
            this.backstageRoute = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtUName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.backstageUSettings = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.chkRoute = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.backstageViewClientControl2 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.chklAlarms = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.backstageViewClientControl4 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.chklSensors = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.backstageViewClientControl5 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.chklReports = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.backstageViewClientControl3 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.chklPType = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.backstageRoutes1 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageAlarms = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageSensors = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageReports = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstagePType = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.backstageUSettings.SuspendLayout();
            this.backstageViewClientControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkRoute)).BeginInit();
            this.backstageViewClientControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklAlarms)).BeginInit();
            this.backstageViewClientControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklSensors)).BeginInit();
            this.backstageViewClientControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklReports)).BeginInit();
            this.backstageViewClientControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklPType)).BeginInit();
            this.SuspendLayout();
            // 
            // backstageRoute
            // 
            this.backstageRoute.Caption = "Route";
            this.backstageRoute.CaptionHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center;
            this.backstageRoute.ContentControl = null;
            this.backstageRoute.Name = "backstageRoute";
            this.backstageRoute.Selected = false;
            // 
            // panelControl1
            // 
            this.panelControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Separator;
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.IndianRed;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.txtUName);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(434, 49);
            this.panelControl1.TabIndex = 0;
            // 
            // txtUName
            // 
            this.txtUName.Location = new System.Drawing.Point(134, 14);
            this.txtUName.Name = "txtUName";
            this.txtUName.Properties.AllowFocused = false;
            this.txtUName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtUName.Properties.Appearance.Options.UseFont = true;
            this.txtUName.Properties.ReadOnly = true;
            this.txtUName.Size = new System.Drawing.Size(222, 22);
            this.txtUName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Location = new System.Drawing.Point(22, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "User Name";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.backstageUSettings);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 49);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(434, 394);
            this.panelControl2.TabIndex = 1;
            // 
            // backstageUSettings
            // 
            this.backstageUSettings.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageUSettings.Controls.Add(this.backstageViewClientControl1);
            this.backstageUSettings.Controls.Add(this.backstageViewClientControl2);
            this.backstageUSettings.Controls.Add(this.backstageViewClientControl4);
            this.backstageUSettings.Controls.Add(this.backstageViewClientControl5);
            this.backstageUSettings.Controls.Add(this.backstageViewClientControl3);
            this.backstageUSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backstageUSettings.Items.Add(this.backstageRoutes1);
            this.backstageUSettings.Items.Add(this.backstageAlarms);
            this.backstageUSettings.Items.Add(this.backstageSensors);
            this.backstageUSettings.Items.Add(this.backstageReports);
            this.backstageUSettings.Items.Add(this.backstagePType);
            this.backstageUSettings.Location = new System.Drawing.Point(0, 0);
            this.backstageUSettings.Name = "backstageUSettings";
            this.backstageUSettings.SelectedTab = this.backstageReports;
            this.backstageUSettings.SelectedTabIndex = 3;
            this.backstageUSettings.Size = new System.Drawing.Size(434, 394);
            this.backstageUSettings.TabIndex = 0;
            this.backstageUSettings.Text = "backstageViewControl1";
            this.backstageUSettings.SelectedTabChanged += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.backstageViewControl1_SelectedTabChanged);
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Controls.Add(this.chkRoute);
            this.backstageViewClientControl1.Location = new System.Drawing.Point(132, 0);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(302, 394);
            this.backstageViewClientControl1.TabIndex = 0;
            // 
            // chkRoute
            // 
            this.chkRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRoute.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.chkRoute.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Addition"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Deletion"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Modification"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Upload/Download"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "View"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "None")});
            this.chkRoute.Location = new System.Drawing.Point(0, 0);
            this.chkRoute.Margin = new System.Windows.Forms.Padding(5);
            this.chkRoute.Name = "chkRoute";
            this.chkRoute.Size = new System.Drawing.Size(302, 394);
            this.chkRoute.TabIndex = 1;
            this.chkRoute.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkRoute_ItemCheck);
            this.chkRoute.MouseLeave += new System.EventHandler(this.chkrt_MouseLeave);
            // 
            // backstageViewClientControl2
            // 
            this.backstageViewClientControl2.Controls.Add(this.chklAlarms);
            this.backstageViewClientControl2.Location = new System.Drawing.Point(132, 0);
            this.backstageViewClientControl2.Name = "backstageViewClientControl2";
            this.backstageViewClientControl2.Size = new System.Drawing.Size(302, 394);
            this.backstageViewClientControl2.TabIndex = 1;
            // 
            // chklAlarms
            // 
            this.chklAlarms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklAlarms.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.chklAlarms.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Addition"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Deletion"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Modification"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Upload/Download"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "View"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "None")});
            this.chklAlarms.Location = new System.Drawing.Point(0, 0);
            this.chklAlarms.Name = "chklAlarms";
            this.chklAlarms.Size = new System.Drawing.Size(302, 394);
            this.chklAlarms.TabIndex = 0;
            this.chklAlarms.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chklAlarms_ItemCheck);
            this.chklAlarms.MouseLeave += new System.EventHandler(this.chklAlarms_MouseLeave);
            // 
            // backstageViewClientControl4
            // 
            this.backstageViewClientControl4.Controls.Add(this.chklSensors);
            this.backstageViewClientControl4.Location = new System.Drawing.Point(132, 0);
            this.backstageViewClientControl4.Name = "backstageViewClientControl4";
            this.backstageViewClientControl4.Size = new System.Drawing.Size(302, 394);
            this.backstageViewClientControl4.TabIndex = 3;
            // 
            // chklSensors
            // 
            this.chklSensors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklSensors.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.chklSensors.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Addition"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Deletion"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Modification"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Upload/Download"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "View"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "None")});
            this.chklSensors.Location = new System.Drawing.Point(0, 0);
            this.chklSensors.Name = "chklSensors";
            this.chklSensors.Size = new System.Drawing.Size(302, 394);
            this.chklSensors.TabIndex = 1;
            this.chklSensors.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chklSensors_ItemCheck);
            this.chklSensors.MouseLeave += new System.EventHandler(this.chklSensors_MouseLeave);
            // 
            // backstageViewClientControl5
            // 
            this.backstageViewClientControl5.Controls.Add(this.chklReports);
            this.backstageViewClientControl5.Location = new System.Drawing.Point(132, 0);
            this.backstageViewClientControl5.Name = "backstageViewClientControl5";
            this.backstageViewClientControl5.Size = new System.Drawing.Size(302, 394);
            this.backstageViewClientControl5.TabIndex = 4;
            // 
            // chklReports
            // 
            this.chklReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklReports.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.chklReports.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Addition"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Deletion"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Modification"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Upload/Download"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "View"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "None")});
            this.chklReports.Location = new System.Drawing.Point(0, 0);
            this.chklReports.Name = "chklReports";
            this.chklReports.Size = new System.Drawing.Size(302, 394);
            this.chklReports.TabIndex = 1;
            this.chklReports.MouseLeave += new System.EventHandler(this.chklReports_MouseLeave);
            // 
            // backstageViewClientControl3
            // 
            this.backstageViewClientControl3.Controls.Add(this.chklPType);
            this.backstageViewClientControl3.Location = new System.Drawing.Point(132, 0);
            this.backstageViewClientControl3.Name = "backstageViewClientControl3";
            this.backstageViewClientControl3.Size = new System.Drawing.Size(302, 394);
            this.backstageViewClientControl3.TabIndex = 2;
            // 
            // chklPType
            // 
            this.chklPType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklPType.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.chklPType.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Addition"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Deletion"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Modification"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Upload/Download"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "View"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "None")});
            this.chklPType.Location = new System.Drawing.Point(0, 0);
            this.chklPType.Name = "chklPType";
            this.chklPType.Size = new System.Drawing.Size(302, 394);
            this.chklPType.TabIndex = 1;
            this.chklPType.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chklPType_ItemCheck);
            this.chklPType.MouseLeave += new System.EventHandler(this.chklPType_MouseLeave);
            // 
            // backstageRoutes1
            // 
            this.backstageRoutes1.Appearance.BorderColor = System.Drawing.Color.White;
            this.backstageRoutes1.Appearance.Options.UseBorderColor = true;
            this.backstageRoutes1.AppearanceHover.BackColor = System.Drawing.Color.Gray;
            this.backstageRoutes1.AppearanceHover.BackColor2 = System.Drawing.Color.Transparent;
            this.backstageRoutes1.AppearanceHover.Options.UseBackColor = true;
            this.backstageRoutes1.AppearanceSelected.BackColor = System.Drawing.Color.Transparent;
            this.backstageRoutes1.AppearanceSelected.BackColor2 = System.Drawing.Color.Transparent;
            this.backstageRoutes1.AppearanceSelected.Options.UseBackColor = true;
            this.backstageRoutes1.Caption = "Route";
            this.backstageRoutes1.CaptionHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center;
            this.backstageRoutes1.ContentControl = this.backstageViewClientControl1;
            this.backstageRoutes1.Name = "backstageRoutes1";
            this.backstageRoutes1.Selected = false;
            // 
            // backstageAlarms
            // 
            this.backstageAlarms.AppearanceHover.BackColor = System.Drawing.Color.Transparent;
            this.backstageAlarms.AppearanceHover.BackColor2 = System.Drawing.Color.Transparent;
            this.backstageAlarms.AppearanceHover.Options.UseBackColor = true;
            this.backstageAlarms.AppearanceSelected.BackColor = System.Drawing.Color.Transparent;
            this.backstageAlarms.AppearanceSelected.BackColor2 = System.Drawing.Color.Transparent;
            this.backstageAlarms.AppearanceSelected.Options.UseBackColor = true;
            this.backstageAlarms.Caption = "Alarms";
            this.backstageAlarms.CaptionHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center;
            this.backstageAlarms.ContentControl = this.backstageViewClientControl2;
            this.backstageAlarms.Name = "backstageAlarms";
            this.backstageAlarms.Selected = false;
            // 
            // backstageSensors
            // 
            this.backstageSensors.Caption = "Sensors";
            this.backstageSensors.CaptionHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center;
            this.backstageSensors.ContentControl = this.backstageViewClientControl4;
            this.backstageSensors.Name = "backstageSensors";
            this.backstageSensors.Selected = false;
            // 
            // backstageReports
            // 
            this.backstageReports.Caption = "Reports";
            this.backstageReports.CaptionHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center;
            this.backstageReports.ContentControl = this.backstageViewClientControl5;
            this.backstageReports.Name = "backstageReports";
            this.backstageReports.Selected = true;
            // 
            // backstagePType
            // 
            this.backstagePType.Caption = "Point Type";
            this.backstagePType.CaptionHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center;
            this.backstagePType.ContentControl = this.backstageViewClientControl3;
            this.backstagePType.Name = "backstagePType";
            this.backstagePType.Selected = false;
            // 
            // frmUSetings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 443);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUSetings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Settings";
            this.Load += new System.EventHandler(this.frmUSetings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.backstageUSettings.ResumeLayout(false);
            this.backstageViewClientControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkRoute)).EndInit();
            this.backstageViewClientControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chklAlarms)).EndInit();
            this.backstageViewClientControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chklSensors)).EndInit();
            this.backstageViewClientControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chklReports)).EndInit();
            this.backstageViewClientControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chklPType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageRoute;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageUSettings;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl2;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl3;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl4;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl5;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageRoutes1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageAlarms;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstagePType;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageSensors;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageReports;
        private DevExpress.XtraEditors.TextEdit txtUName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl chkRoute;
        private DevExpress.XtraEditors.CheckedListBoxControl chklAlarms;
        private DevExpress.XtraEditors.CheckedListBoxControl chklSensors;
        private DevExpress.XtraEditors.CheckedListBoxControl chklReports;
        private DevExpress.XtraEditors.CheckedListBoxControl chklPType;
    }
}