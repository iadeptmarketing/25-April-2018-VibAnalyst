namespace Iadeptmain.BaseUserControl
{
    partial class frmgraphcontrol
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmgraphcontrol));
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Displacement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Velocity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGraphData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Bearing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCheckBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.scGraphContainer = new System.Windows.Forms.SplitContainer();
            this.btnGraphClicking = new DevExpress.XtraEditors.SimpleButton();
            this.lblDIValues = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.lblPointName = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tscbGraphTypes = new System.Windows.Forms.ToolStripComboBox();
            this.tsbtnSetLineColor = new System.Windows.Forms.ToolStripButton();
            this.btnSetBackColor = new System.Windows.Forms.ToolStripButton();
            this.btnToolTipBackColor = new System.Windows.Forms.ToolStripButton();
            this.btnToolTipForeColor = new System.Windows.Forms.ToolStripButton();
            this.cmbMarkerTypes = new System.Windows.Forms.ToolStripComboBox();
            this.btnZoom = new System.Windows.Forms.ToolStripButton();
            this.btnCursor = new System.Windows.Forms.ToolStripButton();
            this.btnUnZoom = new System.Windows.Forms.ToolStripButton();
            this.btnSideBandCursor = new System.Windows.Forms.ToolStripButton();
            this.tsbWaterFall = new System.Windows.Forms.ToolStripButton();
            this.tsbNewOne = new System.Windows.Forms.ToolStripButton();
            this.btn2DControl = new System.Windows.Forms.ToolStripButton();
            this.tsbValuesWindow = new System.Windows.Forms.ToolStripButton();
            this.btnValuetoClipBoard = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGraphData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scGraphContainer)).BeginInit();
            this.scGraphContainer.Panel1.SuspendLayout();
            this.scGraphContainer.Panel2.SuspendLayout();
            this.scGraphContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Test";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Displacement
            // 
            this.Displacement.HeaderText = "Displacement";
            this.Displacement.Name = "Displacement";
            // 
            // Velocity
            // 
            this.Velocity.HeaderText = "Velocity";
            this.Velocity.Name = "Velocity";
            // 
            // YValue
            // 
            this.YValue.HeaderText = "Acceleration";
            this.YValue.Name = "YValue";
            // 
            // Direction
            // 
            this.Direction.HeaderText = "Direction";
            this.Direction.Name = "Direction";
            // 
            // dgvGraphData
            // 
            this.dgvGraphData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGraphData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Direction,
            this.YValue,
            this.Velocity,
            this.Displacement,
            this.Bearing});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGraphData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGraphData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvGraphData.Location = new System.Drawing.Point(0, 0);
            this.dgvGraphData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvGraphData.Name = "dgvGraphData";
            this.dgvGraphData.Size = new System.Drawing.Size(50, 27);
            this.dgvGraphData.TabIndex = 0;
            this.dgvGraphData.Visible = false;
            // 
            // Bearing
            // 
            this.Bearing.HeaderText = "Bearing";
            this.Bearing.Name = "Bearing";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Test";
            this.Column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColColor
            // 
            this.ColColor.HeaderText = "Color";
            this.ColColor.Name = "ColColor";
            this.ColColor.ReadOnly = true;
            this.ColColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColColor.Visible = false;
            // 
            // ColCheckBox
            // 
            this.ColCheckBox.HeaderText = "";
            this.ColCheckBox.Name = "ColCheckBox";
            this.ColCheckBox.ReadOnly = true;
            this.ColCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColCheckBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCheckBox.Width = 20;
            // 
            // colDateTime
            // 
            this.colDateTime.HeaderText = "Date & Time";
            this.colDateTime.Name = "colDateTime";
            this.colDateTime.ReadOnly = true;
            this.colDateTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateTime,
            this.ColCheckBox,
            this.ColColor,
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(309, 81);
            this.dataGridView1.TabIndex = 1;
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Axial",
            "Vertical",
            "Horizontal"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(75, 28);
            // 
            // scGraphContainer
            // 
            this.scGraphContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scGraphContainer.Location = new System.Drawing.Point(0, 0);
            this.scGraphContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scGraphContainer.Name = "scGraphContainer";
            this.scGraphContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scGraphContainer.Panel1
            // 
            this.scGraphContainer.Panel1.Controls.Add(this.btnGraphClicking);
            this.scGraphContainer.Panel1.Controls.Add(this.lblDIValues);
            this.scGraphContainer.Panel1.Controls.Add(this.lblDate);
            this.scGraphContainer.Panel1.Controls.Add(this.lblPointName);
            this.scGraphContainer.Panel1.Controls.Add(this.toolStrip1);
            // 
            // scGraphContainer.Panel2
            // 
            this.scGraphContainer.Panel2.Controls.Add(this.dataGridView1);
            this.scGraphContainer.Panel2.Controls.Add(this.dgvGraphData);
            this.scGraphContainer.Size = new System.Drawing.Size(737, 513);
            this.scGraphContainer.SplitterDistance = 426;
            this.scGraphContainer.SplitterWidth = 5;
            this.scGraphContainer.TabIndex = 1;
            // 
            // btnGraphClicking
            // 
            this.btnGraphClicking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraphClicking.Location = new System.Drawing.Point(700, 59);
            this.btnGraphClicking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGraphClicking.Name = "btnGraphClicking";
            this.btnGraphClicking.Size = new System.Drawing.Size(37, 28);
            this.btnGraphClicking.TabIndex = 6;
            this.btnGraphClicking.Text = "--";
            // 
            // lblDIValues
            // 
            this.lblDIValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDIValues.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblDIValues.Location = new System.Drawing.Point(569, 383);
            this.lblDIValues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDIValues.Name = "lblDIValues";
            this.lblDIValues.Size = new System.Drawing.Size(0, 16);
            this.lblDIValues.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Location = new System.Drawing.Point(614, 25);
            this.lblDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(123, 20);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date and Time";
            // 
            // lblPointName
            // 
            this.lblPointName.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblPointName.Location = new System.Drawing.Point(0, 30);
            this.lblPointName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblPointName.Name = "lblPointName";
            this.lblPointName.Size = new System.Drawing.Size(0, 16);
            this.lblPointName.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(737, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tscbGraphTypes
            // 
            this.tscbGraphTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbGraphTypes.Items.AddRange(new object[] {
            "AreaPlot ",
            "LinePlot"});
            this.tscbGraphTypes.Name = "tscbGraphTypes";
            this.tscbGraphTypes.Size = new System.Drawing.Size(75, 28);
            // 
            // tsbtnSetLineColor
            // 
            this.tsbtnSetLineColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSetLineColor.Enabled = false;
            this.tsbtnSetLineColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSetLineColor.Image")));
            this.tsbtnSetLineColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSetLineColor.Name = "tsbtnSetLineColor";
            this.tsbtnSetLineColor.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSetLineColor.Text = "Click to change Line Color";
            this.tsbtnSetLineColor.Visible = false;
            // 
            // btnSetBackColor
            // 
            this.btnSetBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetBackColor.Image = ((System.Drawing.Image)(resources.GetObject("btnSetBackColor.Image")));
            this.btnSetBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetBackColor.Name = "btnSetBackColor";
            this.btnSetBackColor.Size = new System.Drawing.Size(23, 22);
            this.btnSetBackColor.Text = "Click to change Graph Back Color";
            // 
            // btnToolTipBackColor
            // 
            this.btnToolTipBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolTipBackColor.Enabled = false;
            this.btnToolTipBackColor.Image = ((System.Drawing.Image)(resources.GetObject("btnToolTipBackColor.Image")));
            this.btnToolTipBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToolTipBackColor.Name = "btnToolTipBackColor";
            this.btnToolTipBackColor.Size = new System.Drawing.Size(23, 22);
            this.btnToolTipBackColor.Text = "Click to change tooltip back color";
            this.btnToolTipBackColor.Visible = false;
            // 
            // btnToolTipForeColor
            // 
            this.btnToolTipForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToolTipForeColor.Enabled = false;
            this.btnToolTipForeColor.Image = ((System.Drawing.Image)(resources.GetObject("btnToolTipForeColor.Image")));
            this.btnToolTipForeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToolTipForeColor.Name = "btnToolTipForeColor";
            this.btnToolTipForeColor.Size = new System.Drawing.Size(23, 22);
            this.btnToolTipForeColor.Text = "Click to change tooltip fore color";
            this.btnToolTipForeColor.Visible = false;
            // 
            // cmbMarkerTypes
            // 
            this.cmbMarkerTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarkerTypes.DropDownWidth = 121;
            this.cmbMarkerTypes.Enabled = false;
            this.cmbMarkerTypes.Items.AddRange(new object[] {
            "VLine",
            "HLine",
            "Cross",
            "Box"});
            this.cmbMarkerTypes.Name = "cmbMarkerTypes";
            this.cmbMarkerTypes.Size = new System.Drawing.Size(75, 28);
            // 
            // btnZoom
            // 
            this.btnZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoom.Image = ((System.Drawing.Image)(resources.GetObject("btnZoom.Image")));
            this.btnZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(23, 22);
            this.btnZoom.Text = "Zoom Graph";
            // 
            // btnCursor
            // 
            this.btnCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCursor.Image = ((System.Drawing.Image)(resources.GetObject("btnCursor.Image")));
            this.btnCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCursor.Name = "btnCursor";
            this.btnCursor.Size = new System.Drawing.Size(23, 22);
            this.btnCursor.Text = "toolStripButton1";
            // 
            // btnUnZoom
            // 
            this.btnUnZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnZoom.Image = ((System.Drawing.Image)(resources.GetObject("btnUnZoom.Image")));
            this.btnUnZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnZoom.Name = "btnUnZoom";
            this.btnUnZoom.Size = new System.Drawing.Size(23, 22);
            this.btnUnZoom.Text = "toolStripButton1";
            // 
            // btnSideBandCursor
            // 
            this.btnSideBandCursor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSideBandCursor.Enabled = false;
            this.btnSideBandCursor.Image = ((System.Drawing.Image)(resources.GetObject("btnSideBandCursor.Image")));
            this.btnSideBandCursor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSideBandCursor.Name = "btnSideBandCursor";
            this.btnSideBandCursor.Size = new System.Drawing.Size(23, 22);
            this.btnSideBandCursor.Text = "toolStripButton1";
            this.btnSideBandCursor.Visible = false;
            // 
            // tsbWaterFall
            // 
            this.tsbWaterFall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbWaterFall.Enabled = false;
            this.tsbWaterFall.Image = ((System.Drawing.Image)(resources.GetObject("tsbWaterFall.Image")));
            this.tsbWaterFall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWaterFall.Name = "tsbWaterFall";
            this.tsbWaterFall.Size = new System.Drawing.Size(23, 22);
            this.tsbWaterFall.Text = "toolStripButton1";
            this.tsbWaterFall.Visible = false;
            // 
            // tsbNewOne
            // 
            this.tsbNewOne.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewOne.Enabled = false;
            this.tsbNewOne.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewOne.Image")));
            this.tsbNewOne.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewOne.Name = "tsbNewOne";
            this.tsbNewOne.Size = new System.Drawing.Size(23, 22);
            this.tsbNewOne.Text = "WaterFall";
            this.tsbNewOne.ToolTipText = "View WaterFall";
            // 
            // btn2DControl
            // 
            this.btn2DControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn2DControl.Image = ((System.Drawing.Image)(resources.GetObject("btn2DControl.Image")));
            this.btn2DControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn2DControl.Name = "btn2DControl";
            this.btn2DControl.Size = new System.Drawing.Size(23, 22);
            this.btn2DControl.Text = "toolStripButton1";
            this.btn2DControl.ToolTipText = "View 2D Graph";
            // 
            // tsbValuesWindow
            // 
            this.tsbValuesWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbValuesWindow.Enabled = false;
            this.tsbValuesWindow.Image = ((System.Drawing.Image)(resources.GetObject("tsbValuesWindow.Image")));
            this.tsbValuesWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbValuesWindow.Name = "tsbValuesWindow";
            this.tsbValuesWindow.Size = new System.Drawing.Size(23, 22);
            this.tsbValuesWindow.Text = "toolStripButton1";
            // 
            // btnValuetoClipBoard
            // 
            this.btnValuetoClipBoard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnValuetoClipBoard.Image = ((System.Drawing.Image)(resources.GetObject("btnValuetoClipBoard.Image")));
            this.btnValuetoClipBoard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValuetoClipBoard.Name = "btnValuetoClipBoard";
            this.btnValuetoClipBoard.Size = new System.Drawing.Size(23, 22);
            this.btnValuetoClipBoard.Text = "Copy Values of Graph to ClipBoard";
            // 
            // frmgraphcontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 513);
            this.Controls.Add(this.scGraphContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmgraphcontrol";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGraphData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.scGraphContainer.Panel1.ResumeLayout(false);
            this.scGraphContainer.Panel1.PerformLayout();
            this.scGraphContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scGraphContainer)).EndInit();
            this.scGraphContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Displacement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Velocity;
        private System.Windows.Forms.DataGridViewTextBoxColumn YValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvGraphData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bearing;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridView1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton btnValuetoClipBoard;
        private System.Windows.Forms.ToolStripButton tsbValuesWindow;
        private System.Windows.Forms.ToolStripButton btn2DControl;
        private System.Windows.Forms.ToolStripButton tsbNewOne;
        private System.Windows.Forms.ToolStripButton tsbWaterFall;
        private System.Windows.Forms.SplitContainer scGraphContainer;
        private DevExpress.XtraEditors.SimpleButton btnGraphClicking;
        private DevExpress.XtraEditors.LabelControl lblDIValues;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private DevExpress.XtraEditors.LabelControl lblPointName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox tscbGraphTypes;
        private System.Windows.Forms.ToolStripButton tsbtnSetLineColor;
        private System.Windows.Forms.ToolStripButton btnSetBackColor;
        private System.Windows.Forms.ToolStripButton btnToolTipBackColor;
        private System.Windows.Forms.ToolStripButton btnToolTipForeColor;
        private System.Windows.Forms.ToolStripComboBox cmbMarkerTypes;
        private System.Windows.Forms.ToolStripButton btnZoom;
        private System.Windows.Forms.ToolStripButton btnCursor;
        private System.Windows.Forms.ToolStripButton btnUnZoom;
        private System.Windows.Forms.ToolStripButton btnSideBandCursor;
    }
}