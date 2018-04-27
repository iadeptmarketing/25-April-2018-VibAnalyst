namespace Iadeptmain.Mainforms
{
    partial class frmMachineComparision
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
            this.trlMachineRoute = new DevExpress.XtraTreeList.TreeList();
            this.pnlAllSpectrums = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMachine5 = new System.Windows.Forms.Panel();
            this.pnlMachine4 = new System.Windows.Forms.Panel();
            this.pnlMachine3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlMachine2 = new System.Windows.Forms.Panel();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPoint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFrequency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmplitude = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlMachine1 = new System.Windows.Forms.Panel();
            this.gcRouteMachine = new DevExpress.XtraEditors.GroupControl();
            this.trlMachine = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.trlMachineRoute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAllSpectrums)).BeginInit();
            this.pnlAllSpectrums.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRouteMachine)).BeginInit();
            this.gcRouteMachine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlMachine)).BeginInit();
            this.SuspendLayout();
            // 
            // trlMachineRoute
            // 
            this.trlMachineRoute.Location = new System.Drawing.Point(8, 8);
            this.trlMachineRoute.Name = "trlMachineRoute";
            this.trlMachineRoute.Size = new System.Drawing.Size(329, 687);
            this.trlMachineRoute.TabIndex = 1;
            // 
            // pnlAllSpectrums
            // 
            this.pnlAllSpectrums.Controls.Add(this.tableLayoutPanel1);
            this.pnlAllSpectrums.Controls.Add(this.gcRouteMachine);
            this.pnlAllSpectrums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAllSpectrums.Location = new System.Drawing.Point(0, 0);
            this.pnlAllSpectrums.Name = "pnlAllSpectrums";
            this.pnlAllSpectrums.Size = new System.Drawing.Size(1208, 714);
            this.pnlAllSpectrums.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Controls.Add(this.pnlMachine5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlMachine4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlMachine3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.grdData, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlMachine1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(262, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(944, 710);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // pnlMachine5
            // 
            this.pnlMachine5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMachine5.Location = new System.Drawing.Point(314, 358);
            this.pnlMachine5.Name = "pnlMachine5";
            this.pnlMachine5.Size = new System.Drawing.Size(305, 349);
            this.pnlMachine5.TabIndex = 20;
            // 
            // pnlMachine4
            // 
            this.pnlMachine4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMachine4.Location = new System.Drawing.Point(3, 358);
            this.pnlMachine4.Name = "pnlMachine4";
            this.pnlMachine4.Size = new System.Drawing.Size(305, 349);
            this.pnlMachine4.TabIndex = 19;
            // 
            // pnlMachine3
            // 
            this.pnlMachine3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMachine3.Location = new System.Drawing.Point(625, 3);
            this.pnlMachine3.Name = "pnlMachine3";
            this.pnlMachine3.Size = new System.Drawing.Size(316, 349);
            this.pnlMachine3.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlMachine2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(314, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 349);
            this.panel1.TabIndex = 17;
            // 
            // pnlMachine2
            // 
            this.pnlMachine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMachine2.Location = new System.Drawing.Point(0, 0);
            this.pnlMachine2.Name = "pnlMachine2";
            this.pnlMachine2.Size = new System.Drawing.Size(305, 349);
            this.pnlMachine2.TabIndex = 17;
            // 
            // grdData
            // 
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(625, 358);
            this.grdData.MainView = this.gridView1;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(316, 349);
            this.grdData.TabIndex = 15;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMachineName,
            this.colPoint,
            this.colFrequency,
            this.colAmplitude});
            this.gridView1.GridControl = this.grdData;
            this.gridView1.Name = "gridView1";
            // 
            // colMachineName
            // 
            this.colMachineName.Caption = "Machine Name";
            this.colMachineName.Name = "colMachineName";
            this.colMachineName.Visible = true;
            this.colMachineName.VisibleIndex = 0;
            // 
            // colPoint
            // 
            this.colPoint.Caption = "Point Name";
            this.colPoint.Name = "colPoint";
            this.colPoint.Visible = true;
            this.colPoint.VisibleIndex = 1;
            // 
            // colFrequency
            // 
            this.colFrequency.Caption = "Frequency(Hz)";
            this.colFrequency.Name = "colFrequency";
            this.colFrequency.Visible = true;
            this.colFrequency.VisibleIndex = 2;
            // 
            // colAmplitude
            // 
            this.colAmplitude.Caption = "Amplitude";
            this.colAmplitude.Name = "colAmplitude";
            this.colAmplitude.Visible = true;
            this.colAmplitude.VisibleIndex = 3;
            // 
            // pnlMachine1
            // 
            this.pnlMachine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMachine1.Location = new System.Drawing.Point(3, 3);
            this.pnlMachine1.Name = "pnlMachine1";
            this.pnlMachine1.Size = new System.Drawing.Size(305, 349);
            this.pnlMachine1.TabIndex = 16;
            // 
            // gcRouteMachine
            // 
            this.gcRouteMachine.Controls.Add(this.trlMachine);
            this.gcRouteMachine.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcRouteMachine.Location = new System.Drawing.Point(2, 2);
            this.gcRouteMachine.Name = "gcRouteMachine";
            this.gcRouteMachine.Size = new System.Drawing.Size(260, 710);
            this.gcRouteMachine.TabIndex = 0;
            this.gcRouteMachine.Text = "Machine List";
            // 
            // trlMachine
            // 
            this.trlMachine.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.trlMachine.Appearance.EvenRow.Options.UseBackColor = true;
            this.trlMachine.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.trlMachine.Appearance.FocusedCell.Options.UseBackColor = true;
            this.trlMachine.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.trlMachine.Appearance.SelectedRow.Options.UseBackColor = true;
            this.trlMachine.BestFitVisibleOnly = true;
            this.trlMachine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trlMachine.Location = new System.Drawing.Point(2, 24);
            this.trlMachine.Name = "trlMachine";
            this.trlMachine.OptionsBehavior.AutoNodeHeight = false;
            this.trlMachine.OptionsBehavior.Editable = false;
            this.trlMachine.OptionsView.EnableAppearanceEvenRow = true;
            this.trlMachine.Size = new System.Drawing.Size(256, 684);
            this.trlMachine.TabIndex = 0;
            this.trlMachine.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.trlMachine_BeforeCheckNode);
            this.trlMachine.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.trlMachine_AfterCheckNode);
            this.trlMachine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trlMachine_MouseClick);
            // 
            // frmMachineComparision
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 714);
            this.ControlBox = false;
            this.Controls.Add(this.pnlAllSpectrums);
            this.Controls.Add(this.trlMachineRoute);
            this.MinimizeBox = false;
            this.Name = "frmMachineComparision";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.trlMachineRoute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAllSpectrums)).EndInit();
            this.pnlAllSpectrums.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRouteMachine)).EndInit();
            this.gcRouteMachine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlMachine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList trlMachineRoute;
        private DevExpress.XtraEditors.PanelControl pnlAllSpectrums;
        private DevExpress.XtraEditors.GroupControl gcRouteMachine;
        private DevExpress.XtraTreeList.TreeList trlMachine;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMachineName;
        private DevExpress.XtraGrid.Columns.GridColumn colPoint;
        private DevExpress.XtraGrid.Columns.GridColumn colFrequency;
        private DevExpress.XtraGrid.Columns.GridColumn colAmplitude;
        private System.Windows.Forms.Panel pnlMachine5;
        private System.Windows.Forms.Panel pnlMachine4;
        private System.Windows.Forms.Panel pnlMachine3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlMachine2;
        private System.Windows.Forms.Panel pnlMachine1;
    }
}