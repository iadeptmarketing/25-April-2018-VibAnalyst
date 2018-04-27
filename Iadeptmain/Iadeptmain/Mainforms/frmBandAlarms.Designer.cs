namespace Iadeptmain.Mainforms
{
    partial class frmBandAlarms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.xSCBandAlarm = new DevExpress.XtraEditors.XtraScrollableControl();
            this.groupBox6 = new DevExpress.XtraEditors.GroupControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkDelete = new System.Windows.Forms.LinkLabel();
            this.TxtGroupName = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBandGroup = new DevExpress.XtraEditors.ComboBoxEdit();
            this.xtcBADemo = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTPDemo = new DevExpress.XtraTab.XtraTabPage();
            this.dgvBADA = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colBANameDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrqDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvXDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvYDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCounterDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_Axis_Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.xtcBAPower = new DevExpress.XtraTab.XtraTabControl();
            this.xtpPower = new DevExpress.XtraTab.XtraTabPage();
            this.dgvBAPH = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colBANamePWR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrqPwr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colxAxisPwr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYaxisPwr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCounterPWR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B_Axis_Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.xSCBandAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox6)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBandGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcBADemo)).BeginInit();
            this.xtcBADemo.SuspendLayout();
            this.xtraTPDemo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBADA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcBAPower)).BeginInit();
            this.xtcBAPower.SuspendLayout();
            this.xtpPower.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBAPH)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(87, 28);
            this.xtraScrollableControl1.TabIndex = 0;
            // 
            // xSCBandAlarm
            // 
            this.xSCBandAlarm.Controls.Add(this.groupBox6);
            this.xSCBandAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xSCBandAlarm.Location = new System.Drawing.Point(0, 0);
            this.xSCBandAlarm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xSCBandAlarm.Name = "xSCBandAlarm";
            this.xSCBandAlarm.Size = new System.Drawing.Size(707, 535);
            this.xSCBandAlarm.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panel1);
            this.groupBox6.Controls.Add(this.xtcBADemo);
            this.groupBox6.Controls.Add(this.btnExit);
            this.groupBox6.Controls.Add(this.xtcBAPower);
            this.groupBox6.Location = new System.Drawing.Point(6, 4);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(689, 517);
            this.groupBox6.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lnkDelete);
            this.panel1.Controls.Add(this.TxtGroupName);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.cmbBandGroup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 54);
            this.panel1.TabIndex = 31;
            // 
            // lnkDelete
            // 
            this.lnkDelete.AutoSize = true;
            this.lnkDelete.Location = new System.Drawing.Point(496, 37);
            this.lnkDelete.Name = "lnkDelete";
            this.lnkDelete.Size = new System.Drawing.Size(174, 17);
            this.lnkDelete.TabIndex = 35;
            this.lnkDelete.TabStop = true;
            this.lnkDelete.Text = "Delete Existing Band Group";
            this.lnkDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDelete_LinkClicked);
            // 
            // TxtGroupName
            // 
            this.TxtGroupName.Location = new System.Drawing.Point(367, 14);
            this.TxtGroupName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtGroupName.Name = "TxtGroupName";
            this.TxtGroupName.Size = new System.Drawing.Size(117, 23);
            this.TxtGroupName.TabIndex = 34;
            this.TxtGroupName.Visible = false;
            this.TxtGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtGroupName_KeyPress);
            this.TxtGroupName.Leave += new System.EventHandler(this.TxtGroupName_Leave);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(497, 17);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(139, 17);
            this.linkLabel1.TabIndex = 33;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Add New Band Group";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(251, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(103, 16);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Band Group Name";
            // 
            // cmbBandGroup
            // 
            this.cmbBandGroup.Location = new System.Drawing.Point(367, 14);
            this.cmbBandGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBandGroup.Name = "cmbBandGroup";
            this.cmbBandGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBandGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBandGroup.Size = new System.Drawing.Size(117, 22);
            this.cmbBandGroup.TabIndex = 31;
            this.cmbBandGroup.SelectedIndexChanged += new System.EventHandler(this.cmbBandGroup_SelectedIndexChanged);
            // 
            // xtcBADemo
            // 
            this.xtcBADemo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xtcBADemo.Location = new System.Drawing.Point(2, 276);
            this.xtcBADemo.LookAndFeel.SkinName = "iMaginary";
            this.xtcBADemo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtcBADemo.Name = "xtcBADemo";
            this.xtcBADemo.SelectedTabPage = this.xtraTPDemo;
            this.xtcBADemo.Size = new System.Drawing.Size(685, 239);
            this.xtcBADemo.TabIndex = 2;
            this.xtcBADemo.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTPDemo});
            // 
            // xtraTPDemo
            // 
            this.xtraTPDemo.Controls.Add(this.dgvBADA);
            this.xtraTPDemo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTPDemo.Name = "xtraTPDemo";
            this.xtraTPDemo.Size = new System.Drawing.Size(679, 208);
            this.xtraTPDemo.Text = "Demodulate";
            // 
            // dgvBADA
            // 
            this.dgvBADA.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.dgvBADA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBADA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBANameDemo,
            this.colFrqDemo,
            this.dgvXDemo,
            this.dgvYDemo,
            this.colCounterDemo,
            this.idDemo,
            this.D_Axis_Type});
            this.dgvBADA.Cursor = System.Windows.Forms.Cursors.IBeam;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBADA.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBADA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBADA.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvBADA.Location = new System.Drawing.Point(0, 0);
            this.dgvBADA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvBADA.MultiSelect = false;
            this.dgvBADA.Name = "dgvBADA";
            this.dgvBADA.Size = new System.Drawing.Size(679, 208);
            this.dgvBADA.TabIndex = 3;
            this.dgvBADA.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBADA_CellEndEdit);
            this.dgvBADA.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvBADA_CurrentCellDirtyStateChanged);
            this.dgvBADA.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvBADA_EditingControlShowing);
            this.dgvBADA.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvBADA_RowsAdded);
            this.dgvBADA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBADA_KeyDown);
            this.dgvBADA.Leave += new System.EventHandler(this.dgvBADA_Leave);
            // 
            // colBANameDemo
            // 
            this.colBANameDemo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBANameDemo.HeaderText = "Demodulate Name";
            this.colBANameDemo.Name = "colBANameDemo";
            // 
            // colFrqDemo
            // 
            this.colFrqDemo.HeaderText = "Frequency";
            this.colFrqDemo.Name = "colFrqDemo";
            // 
            // dgvXDemo
            // 
            this.dgvXDemo.HeaderText = "High";
            this.dgvXDemo.Name = "dgvXDemo";
            this.dgvXDemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvYDemo
            // 
            this.dgvYDemo.HeaderText = "Low";
            this.dgvYDemo.Name = "dgvYDemo";
            this.dgvYDemo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCounterDemo
            // 
            this.colCounterDemo.HeaderText = "Counter";
            this.colCounterDemo.Name = "colCounterDemo";
            this.colCounterDemo.Visible = false;
            // 
            // idDemo
            // 
            this.idDemo.HeaderText = "ID";
            this.idDemo.Name = "idDemo";
            this.idDemo.ReadOnly = true;
            this.idDemo.Visible = false;
            // 
            // D_Axis_Type
            // 
            this.D_Axis_Type.HeaderText = "Axis Type";
            this.D_Axis_Type.Name = "D_Axis_Type";
            this.D_Axis_Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.D_Axis_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.D_Axis_Type.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnExit.Appearance.Options.UseBackColor = true;
            this.btnExit.Appearance.Options.UseBorderColor = true;
            this.btnExit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnExit.Location = new System.Drawing.Point(631, -1);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(57, 28);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // xtcBAPower
            // 
            this.xtcBAPower.Location = new System.Drawing.Point(5, 82);
            this.xtcBAPower.LookAndFeel.SkinName = "iMaginary";
            this.xtcBAPower.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtcBAPower.Name = "xtcBAPower";
            this.xtcBAPower.SelectedTabPage = this.xtpPower;
            this.xtcBAPower.Size = new System.Drawing.Size(685, 192);
            this.xtcBAPower.TabIndex = 0;
            this.xtcBAPower.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpPower});
            // 
            // xtpPower
            // 
            this.xtpPower.Controls.Add(this.dgvBAPH);
            this.xtpPower.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtpPower.Name = "xtpPower";
            this.xtpPower.Size = new System.Drawing.Size(679, 161);
            this.xtpPower.Text = "Band";
            // 
            // dgvBAPH
            // 
            this.dgvBAPH.AllowUserToDeleteRows = false;
            this.dgvBAPH.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(247)))));
            this.dgvBAPH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBAPH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBANamePWR,
            this.colFrqPwr,
            this.colxAxisPwr,
            this.colYaxisPwr,
            this.colCounterPWR,
            this.ID,
            this.B_Axis_Type});
            this.dgvBAPH.Cursor = System.Windows.Forms.Cursors.IBeam;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBAPH.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBAPH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBAPH.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvBAPH.Location = new System.Drawing.Point(0, 0);
            this.dgvBAPH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvBAPH.MultiSelect = false;
            this.dgvBAPH.Name = "dgvBAPH";
            this.dgvBAPH.Size = new System.Drawing.Size(679, 161);
            this.dgvBAPH.TabIndex = 1;
            this.dgvBAPH.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBAPH_CellEndEdit);
            this.dgvBAPH.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvBAPH_CurrentCellDirtyStateChanged);
            this.dgvBAPH.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvBAPH_DataError);
            this.dgvBAPH.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvBAPH_EditingControlShowing);
            this.dgvBAPH.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvBAPH_RowsAdded);
            this.dgvBAPH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBAPH_KeyDown);
            this.dgvBAPH.Leave += new System.EventHandler(this.dgvBAPH_Leave);
            // 
            // colBANamePWR
            // 
            this.colBANamePWR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colBANamePWR.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBANamePWR.HeaderText = "Band Name";
            this.colBANamePWR.Name = "colBANamePWR";
            // 
            // colFrqPwr
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colFrqPwr.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFrqPwr.HeaderText = "Frequency";
            this.colFrqPwr.Name = "colFrqPwr";
            // 
            // colxAxisPwr
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.NullValue = null;
            this.colxAxisPwr.DefaultCellStyle = dataGridViewCellStyle4;
            this.colxAxisPwr.HeaderText = "High";
            this.colxAxisPwr.Name = "colxAxisPwr";
            this.colxAxisPwr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colYaxisPwr
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.NullValue = null;
            this.colYaxisPwr.DefaultCellStyle = dataGridViewCellStyle5;
            this.colYaxisPwr.HeaderText = "Low";
            this.colYaxisPwr.Name = "colYaxisPwr";
            this.colYaxisPwr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCounterPWR
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.NullValue = null;
            this.colCounterPWR.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCounterPWR.HeaderText = "Counter";
            this.colCounterPWR.Name = "colCounterPWR";
            this.colCounterPWR.ReadOnly = true;
            this.colCounterPWR.Visible = false;
            // 
            // ID
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.NullValue = null;
            this.ID.DefaultCellStyle = dataGridViewCellStyle7;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // B_Axis_Type
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.NullValue = null;
            this.B_Axis_Type.DefaultCellStyle = dataGridViewCellStyle8;
            this.B_Axis_Type.HeaderText = "Axis Type";
            this.B_Axis_Type.Name = "B_Axis_Type";
            this.B_Axis_Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.B_Axis_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.B_Axis_Type.Visible = false;
            // 
            // frmBandAlarms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 535);
            this.ControlBox = false;
            this.Controls.Add(this.xSCBandAlarm);
            this.Controls.Add(this.xtraScrollableControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBandAlarms";
            this.ShowIcon = false;
            this.Text = "Band Alarms";
            this.Load += new System.EventHandler(this.frmBandAlarms_Load);
            this.xSCBandAlarm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox6)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBandGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcBADemo)).EndInit();
            this.xtcBADemo.ResumeLayout(false);
            this.xtraTPDemo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBADA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcBAPower)).EndInit();
            this.xtcBAPower.ResumeLayout(false);
            this.xtpPower.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBAPH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.XtraScrollableControl xSCBandAlarm;
        private DevExpress.XtraEditors.GroupControl groupBox6;
        private DevExpress.XtraTab.XtraTabControl xtcBADemo;
        private DevExpress.XtraTab.XtraTabPage xtraTPDemo;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvBADA;
        private DevExpress.XtraTab.XtraTabControl xtcBAPower;
        private DevExpress.XtraTab.XtraTabPage xtpPower;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvBAPH;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBandGroup;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox TxtGroupName;
        private System.Windows.Forms.LinkLabel lnkDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBANameDemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrqDemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvXDemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvYDemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCounterDemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDemo;
        private System.Windows.Forms.DataGridViewComboBoxColumn D_Axis_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBANamePWR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrqPwr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colxAxisPwr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYaxisPwr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCounterPWR;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn B_Axis_Type;
    }
}