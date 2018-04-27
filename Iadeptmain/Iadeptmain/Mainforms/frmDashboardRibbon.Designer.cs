namespace Iadeptmain.Mainforms
{
    partial class frmDashboardRibbon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboardRibbon));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbPie = new DevExpress.XtraBars.BarButtonItem();
            this.bbcopy = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.bbstatus = new DevExpress.XtraBars.BarStaticItem();
            this.bbback = new DevExpress.XtraBars.BarButtonItem();
            this.rpgGraph = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xscDashboard = new DevExpress.XtraEditors.XtraScrollableControl();
            this.pnlDashboard = new DevExpress.XtraEditors.PanelControl();
            this.pnlLblDasboard = new DevExpress.XtraEditors.PanelControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.bbGraphBack = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.xscDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLblDasboard)).BeginInit();
            this.pnlLblDasboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Iadeptmain.XRDesignRibbonControllerResources.Movglobe;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbPie,
            this.bbcopy,
            this.barStaticItem2,
            this.bbstatus,
            this.bbback});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 12;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpgGraph});
            this.ribbon.Size = new System.Drawing.Size(1032, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // bbPie
            // 
            this.bbPie.Caption = "Pie Chart";
            this.bbPie.Id = 1;
            this.bbPie.LargeGlyph = global::Iadeptmain.XRDesignRibbonControllerResources.PieDashboard;
            this.bbPie.Name = "bbPie";
            this.bbPie.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPie_ItemClick);
            // 
            // bbcopy
            // 
            this.bbcopy.Caption = "Copy";
            this.bbcopy.Id = 5;
            this.bbcopy.LargeGlyph = global::Iadeptmain.XRDesignRibbonControllerResources.RibbonUserDesigner_CopyLarge;
            this.bbcopy.Name = "bbcopy";
            this.bbcopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbcopy_ItemClick);
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem2.Caption = "IADEPT MARKETING";
            this.barStaticItem2.Id = 9;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbstatus
            // 
            this.bbstatus.Caption = "Ready";
            this.bbstatus.Glyph = global::Iadeptmain.Properties.Resources.status;
            this.bbstatus.Id = 10;
            this.bbstatus.Name = "bbstatus";
            this.bbstatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbback
            // 
            this.bbback.Caption = "Back";
            this.bbback.Glyph = ((System.Drawing.Image)(resources.GetObject("bbback.Glyph")));
            this.bbback.Id = 11;
            this.bbback.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbback.LargeGlyph")));
            this.bbback.Name = "bbback";
            this.bbback.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbback_ItemClick);
            // 
            // rpgGraph
            // 
            this.rpgGraph.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup2,
            this.ribbonPageGroup1});
            this.rpgGraph.Name = "rpgGraph";
            this.rpgGraph.Text = "Graphical Representation";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bbback);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Navigation";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbPie, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbcopy);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Copy & Print";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem2);
            this.ribbonStatusBar.ItemLinks.Add(this.bbstatus);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 744);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1032, 31);
            // 
            // xscDashboard
            // 
            this.xscDashboard.Controls.Add(this.pnlDashboard);
            this.xscDashboard.Controls.Add(this.pnlLblDasboard);
            this.xscDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xscDashboard.Location = new System.Drawing.Point(0, 144);
            this.xscDashboard.Name = "xscDashboard";
            this.xscDashboard.Size = new System.Drawing.Size(1032, 600);
            this.xscDashboard.TabIndex = 2;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.AutoSize = true;
            this.pnlDashboard.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 30);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(1032, 570);
            this.pnlDashboard.TabIndex = 2;
            // 
            // pnlLblDasboard
            // 
            this.pnlLblDasboard.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLblDasboard.Controls.Add(this.btnBack);
            this.pnlLblDasboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLblDasboard.Location = new System.Drawing.Point(0, 0);
            this.pnlLblDasboard.Name = "pnlLblDasboard";
            this.pnlLblDasboard.Size = new System.Drawing.Size(1032, 30);
            this.pnlLblDasboard.TabIndex = 1;
            this.pnlLblDasboard.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Appearance.Options.UseBackColor = true;
            this.btnBack.Appearance.Options.UseForeColor = true;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnBack.Location = new System.Drawing.Point(921, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(81, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // bbGraphBack
            // 
            this.bbGraphBack.Caption = "Previous";
            this.bbGraphBack.Glyph = ((System.Drawing.Image)(resources.GetObject("bbGraphBack.Glyph")));
            this.bbGraphBack.Id = 143;
            this.bbGraphBack.Name = "bbGraphBack";
            // 
            // frmDashboardRibbon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 775);
            this.Controls.Add(this.xscDashboard);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmDashboardRibbon";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "VibAnalyst-Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDashboardRibbon_FormClosed);
            this.Load += new System.EventHandler(this.frmDashboardRibbon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.xscDashboard.ResumeLayout(false);
            this.xscDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLblDasboard)).EndInit();
            this.pnlLblDasboard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem bbPie;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpgGraph;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.XtraScrollableControl xscDashboard;
        private DevExpress.XtraEditors.PanelControl pnlLblDasboard;
        public DevExpress.XtraEditors.PanelControl pnlDashboard;
        public DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraBars.BarButtonItem bbcopy;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbGraphBack;
        public DevExpress.XtraBars.BarButtonItem bbback;
        public DevExpress.XtraBars.BarStaticItem bbstatus;
    }
}