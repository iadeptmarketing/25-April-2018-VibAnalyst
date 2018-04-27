namespace Iadeptmain.Mainforms
{
    partial class FrmPointType
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
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("Amplitude & Phase");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("Cepstrum");
            this.xtraTbPointType = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTPPType = new DevExpress.XtraTab.XtraTabPage();
            this.gpPType = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtPointtypename = new DevExpress.XtraEditors.TextEdit();
            this.cmbPointTpname = new System.Windows.Forms.ComboBox();
            this.lblPTypeName = new DevExpress.XtraEditors.LabelControl();
            this.cmbPTypeInst = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbPType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblPType = new DevExpress.XtraEditors.LabelControl();
            this.lblPTypeInst = new DevExpress.XtraEditors.LabelControl();
            this.xtraTPB0 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraSCB0 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.lstmeasure = new System.Windows.Forms.ListView();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTPB1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.xtraScB1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.groupBox5 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.cmbBandGroup = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbAlarmlist = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox3 = new DevExpress.XtraEditors.GroupControl();
            this.cmbSDAlarmList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupBox2 = new DevExpress.XtraEditors.GroupControl();
            this.cmbPAlarmList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gbUniaxial = new DevExpress.XtraEditors.GroupControl();
            this.cbICPPower = new DevExpress.XtraEditors.CheckEdit();
            this.chkCH1 = new DevExpress.XtraEditors.CheckEdit();
            this.chkAxial = new DevExpress.XtraEditors.CheckEdit();
            this.chkHorizontal = new DevExpress.XtraEditors.CheckEdit();
            this.chkVertical = new DevExpress.XtraEditors.CheckEdit();
            this.cmbtempname = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.CmbSensorName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gbOverAll = new DevExpress.XtraEditors.GroupControl();
            this.cmbaccHPFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblCrestFilter = new DevExpress.XtraEditors.LabelControl();
            this.cbCrestFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBearingFilter = new DevExpress.XtraEditors.LabelControl();
            this.cbBearingFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDisplacementFilter = new DevExpress.XtraEditors.LabelControl();
            this.cbDispFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblVelocityFilter = new DevExpress.XtraEditors.LabelControl();
            this.cbVelocityFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbAccelerationFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblAccFilter = new DevExpress.XtraEditors.LabelControl();
            this.gbTime = new DevExpress.XtraEditors.GroupControl();
            this.cbOverlap = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblOverlap = new DevExpress.XtraEditors.LabelControl();
            this.lblLines = new DevExpress.XtraEditors.LabelControl();
            this.cbLines = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbTimeBand = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBand = new DevExpress.XtraEditors.LabelControl();
            this.xtraTPB2 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.xtraSCB2 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.gboctave = new DevExpress.XtraEditors.GroupControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.lblN = new DevExpress.XtraEditors.LabelControl();
            this.cmbBarstyle = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblBarstyle = new DevExpress.XtraEditors.LabelControl();
            this.cmbOctave = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblOctave = new DevExpress.XtraEditors.LabelControl();
            this.gbOrdertrace = new DevExpress.XtraEditors.GroupControl();
            this.cbOTSlope = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.cbOTLines = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.txtOTOrder = new DevExpress.XtraEditors.TextEdit();
            this.cbOTAvg = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.hbPowerSpectrum = new DevExpress.XtraEditors.GroupControl();
            this.label128 = new System.Windows.Forms.Label();
            this.chkbxG3P1 = new System.Windows.Forms.CheckBox();
            this.chkbxG3P2 = new DevExpress.XtraEditors.CheckEdit();
            this.lblG3P2Line = new DevExpress.XtraEditors.LabelControl();
            this.cbG3PSLines1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbG3PSBand1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblG3P2Band = new DevExpress.XtraEditors.LabelControl();
            this.lblG3P1Line = new DevExpress.XtraEditors.LabelControl();
            this.cbG3PSLines = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbG3PSBand = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblG3P1Band = new DevExpress.XtraEditors.LabelControl();
            this.label127 = new System.Windows.Forms.Label();
            this.chkbxG2P1 = new System.Windows.Forms.CheckBox();
            this.chkbxG2P2 = new DevExpress.XtraEditors.CheckEdit();
            this.lblG2P2Line = new DevExpress.XtraEditors.LabelControl();
            this.cbG2PSLines1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbG2PSBand1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblG2P2Band = new DevExpress.XtraEditors.LabelControl();
            this.lblG2P1Line = new DevExpress.XtraEditors.LabelControl();
            this.cbG2PSLines = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbG2PSBand = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblG2P1Band = new DevExpress.XtraEditors.LabelControl();
            this.label126 = new System.Windows.Forms.Label();
            this.chkbxG1P1 = new System.Windows.Forms.CheckBox();
            this.cbMultipleBand = new DevExpress.XtraEditors.CheckEdit();
            this.lblPowerLine1 = new DevExpress.XtraEditors.LabelControl();
            this.cbPSLines1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbPSBand1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblPowerBand1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPSZoom = new DevExpress.XtraEditors.TextEdit();
            this.cbZoom = new DevExpress.XtraEditors.CheckEdit();
            this.cbPSOverlap = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblPSOverlap = new DevExpress.XtraEditors.LabelControl();
            this.cbAvgTimes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblAverageTimes = new DevExpress.XtraEditors.LabelControl();
            this.cbPSWindow = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblWindow = new DevExpress.XtraEditors.LabelControl();
            this.label87 = new DevExpress.XtraEditors.LabelControl();
            this.cbPSLines = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbPSBand = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label88 = new DevExpress.XtraEditors.LabelControl();
            this.gbDemodulate = new DevExpress.XtraEditors.GroupControl();
            this.cbFilter = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblFilter = new DevExpress.XtraEditors.LabelControl();
            this.cmbdmAvgTimes = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label81 = new DevExpress.XtraEditors.LabelControl();
            this.cmbdmWindow = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label84 = new DevExpress.XtraEditors.LabelControl();
            this.label85 = new DevExpress.XtraEditors.LabelControl();
            this.cmbdmLines = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbDMBand = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label86 = new DevExpress.XtraEditors.LabelControl();
            this.gbCepstrum = new DevExpress.XtraEditors.GroupControl();
            this.txtCepZoom = new DevExpress.XtraEditors.TextEdit();
            this.chkCepZoom = new DevExpress.XtraEditors.CheckEdit();
            this.cbCepOverlap = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.cbCepAvgTime = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.cbCepWind = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.cbCepLine = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbCepBand = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTPB3 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.xtraScB3 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.gbMeasure = new DevExpress.XtraEditors.GroupControl();
            this.lblCepstrum = new DevExpress.XtraEditors.LabelControl();
            this.cbCepstrum = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblOrderTrace = new DevExpress.XtraEditors.LabelControl();
            this.cbOrderTrace = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDemodulate = new DevExpress.XtraEditors.LabelControl();
            this.cbDemodulate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblSpectrum = new DevExpress.XtraEditors.LabelControl();
            this.cbSpectrum = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbTime = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblTime = new DevExpress.XtraEditors.LabelControl();
            this.gbUnitDetection = new DevExpress.XtraEditors.GroupControl();
            this.cbCurrentUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblCurrent = new DevExpress.XtraEditors.LabelControl();
            this.cbCurrent = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbPressureUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblPressure = new DevExpress.XtraEditors.LabelControl();
            this.cbPressure = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbDispUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbVelUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbAccUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtProcess = new DevExpress.XtraEditors.TextEdit();
            this.lblProcess = new DevExpress.XtraEditors.LabelControl();
            this.cbTemp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblTemprature = new DevExpress.XtraEditors.LabelControl();
            this.lblDisp = new DevExpress.XtraEditors.LabelControl();
            this.cbDisp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblVel = new DevExpress.XtraEditors.LabelControl();
            this.cbVel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbAcc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblAcc = new DevExpress.XtraEditors.LabelControl();
            this.xtraTPIMXA = new DevExpress.XtraTab.XtraTabPage();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.xtraSCIMAX = new DevExpress.XtraEditors.XtraScrollableControl();
            this.grbAlarms = new DevExpress.XtraEditors.GroupControl();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.cmbAlarmImxa = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.cmbbandimxa = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbUnitsMain = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gbDI2 = new DevExpress.XtraEditors.GroupControl();
            this.label54 = new DevExpress.XtraEditors.LabelControl();
            this.label53 = new DevExpress.XtraEditors.LabelControl();
            this.tbSpecAver = new DevExpress.XtraEditors.TextEdit();
            this.tbTimeAveg = new DevExpress.XtraEditors.TextEdit();
            this.label64 = new DevExpress.XtraEditors.LabelControl();
            this.label77 = new DevExpress.XtraEditors.LabelControl();
            this.cmbDirection = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbChannelType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label65 = new DevExpress.XtraEditors.LabelControl();
            this.label76 = new DevExpress.XtraEditors.LabelControl();
            this.cmbCollectionType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbTriggerRange = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbMeasureType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label75 = new DevExpress.XtraEditors.LabelControl();
            this.label66 = new DevExpress.XtraEditors.LabelControl();
            this.tbLevel = new DevExpress.XtraEditors.TextEdit();
            this.cmbResolution = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label74 = new DevExpress.XtraEditors.LabelControl();
            this.label69 = new DevExpress.XtraEditors.LabelControl();
            this.cmbSlope1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbFrequency = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label73 = new DevExpress.XtraEditors.LabelControl();
            this.label70 = new DevExpress.XtraEditors.LabelControl();
            this.cmbTriggerType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbOrders = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label72 = new DevExpress.XtraEditors.LabelControl();
            this.label71 = new DevExpress.XtraEditors.LabelControl();
            this.tbOverlap = new DevExpress.XtraEditors.TextEdit();
            this.gbDI1 = new DevExpress.XtraEditors.GroupControl();
            this.label83 = new DevExpress.XtraEditors.LabelControl();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.cmbCouple = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbFullScale = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label57 = new DevExpress.XtraEditors.LabelControl();
            this.label82 = new DevExpress.XtraEditors.LabelControl();
            this.tbSensitivity = new DevExpress.XtraEditors.TextEdit();
            this.label67 = new DevExpress.XtraEditors.LabelControl();
            this.cmbDetectionType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbFilterValue = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label58 = new DevExpress.XtraEditors.LabelControl();
            this.label63 = new DevExpress.XtraEditors.LabelControl();
            this.cmbWindowType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbFilterType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label62 = new DevExpress.XtraEditors.LabelControl();
            this.xtraC911 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraSCC911 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            this.cmbalarmC911 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
            this.cmbBandC911 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gcC911 = new DevExpress.XtraEditors.GroupControl();
            this.gbamplifier = new System.Windows.Forms.GroupBox();
            this.rbampenv = new System.Windows.Forms.RadioButton();
            this.rbampint1 = new System.Windows.Forms.RadioButton();
            this.rbampint2 = new System.Windows.Forms.RadioButton();
            this.rbamplinA = new System.Windows.Forms.RadioButton();
            this.txtcomment = new DevExpress.XtraEditors.TextEdit();
            this.txtN = new DevExpress.XtraEditors.TextEdit();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.cmbAvermode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbtrigger = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbfmax = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbFmin = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbspectral = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbwindow = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbchannel2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbenv = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gbC911 = new System.Windows.Forms.GroupBox();
            this.rbrnv = new System.Windows.Forms.RadioButton();
            this.rbintv = new System.Windows.Forms.RadioButton();
            this.rbint = new System.Windows.Forms.RadioButton();
            this.rblinA = new System.Windows.Forms.RadioButton();
            this.cmbchannel1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.pttPanel = new DevExpress.XtraEditors.PanelControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTbPointType)).BeginInit();
            this.xtraTbPointType.SuspendLayout();
            this.xtraTPPType.SuspendLayout();
            this.gpPType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPointtypename.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPTypeInst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPType.Properties)).BeginInit();
            this.xtraTPB0.SuspendLayout();
            this.xtraSCB0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.xtraTPB1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.xtraScB1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox5)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBandGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAlarmlist.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSDAlarmList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPAlarmList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbUniaxial)).BeginInit();
            this.gbUniaxial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbICPPower.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCH1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAxial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHorizontal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVertical.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtempname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbSensorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbOverAll)).BeginInit();
            this.gbOverAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbaccHPFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCrestFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBearingFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDispFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVelocityFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAccelerationFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbTime)).BeginInit();
            this.gbTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOverlap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLines.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTimeBand.Properties)).BeginInit();
            this.xtraTPB2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.xtraSCB2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gboctave)).BeginInit();
            this.gboctave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBarstyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOctave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbOrdertrace)).BeginInit();
            this.gbOrdertrace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOTSlope.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOTLines.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOTOrder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOTAvg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbPowerSpectrum)).BeginInit();
            this.hbPowerSpectrum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkbxG3P2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG3PSLines1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG3PSBand1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG3PSLines.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG3PSBand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkbxG2P2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG2PSLines1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG2PSBand1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG2PSLines.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG2PSBand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMultipleBand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSLines1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSBand1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPSZoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSOverlap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAvgTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSLines.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSBand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDemodulate)).BeginInit();
            this.gbDemodulate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdmAvgTimes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdmWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdmLines.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDMBand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbCepstrum)).BeginInit();
            this.gbCepstrum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCepZoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCepZoom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepOverlap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepAvgTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepWind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepBand.Properties)).BeginInit();
            this.xtraTPB3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.xtraScB3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbMeasure)).BeginInit();
            this.gbMeasure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepstrum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOrderTrace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDemodulate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSpectrum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbUnitDetection)).BeginInit();
            this.gbUnitDetection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCurrentUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCurrent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPressureUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPressure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDispUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVelUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAccUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTemp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDisp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAcc.Properties)).BeginInit();
            this.xtraTPIMXA.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            this.xtraSCIMAX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbAlarms)).BeginInit();
            this.grbAlarms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAlarmImxa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbbandimxa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnitsMain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDI2)).BeginInit();
            this.gbDI2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpecAver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeAveg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDirection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChannelType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCollectionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTriggerRange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMeasureType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbResolution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSlope1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrequency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTriggerType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrders.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOverlap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDI1)).BeginInit();
            this.gbDI1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCouple.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFullScale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSensitivity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDetectionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilterValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWindowType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilterType.Properties)).BeginInit();
            this.xtraC911.SuspendLayout();
            this.xtraSCC911.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbalarmC911.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBandC911.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcC911)).BeginInit();
            this.gcC911.SuspendLayout();
            this.gbamplifier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcomment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAvermode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtrigger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbfmax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFmin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbspectral.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbwindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbchannel2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbenv.Properties)).BeginInit();
            this.gbC911.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbchannel1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pttPanel)).BeginInit();
            this.pttPanel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTbPointType
            // 
            this.xtraTbPointType.Appearance.BackColor = System.Drawing.Color.Silver;
            this.xtraTbPointType.Appearance.BackColor2 = System.Drawing.Color.Silver;
            this.xtraTbPointType.Appearance.BorderColor = System.Drawing.Color.Gray;
            this.xtraTbPointType.Appearance.Options.UseBackColor = true;
            this.xtraTbPointType.Appearance.Options.UseBorderColor = true;
            this.xtraTbPointType.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTbPointType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTbPointType.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.xtraTbPointType.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Vertical;
            this.xtraTbPointType.Location = new System.Drawing.Point(2, 2);
            this.xtraTbPointType.Name = "xtraTbPointType";
            this.xtraTbPointType.PageImagePosition = DevExpress.XtraTab.TabPageImagePosition.Center;
            this.xtraTbPointType.SelectedTabPage = this.xtraTPPType;
            this.xtraTbPointType.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTbPointType.Size = new System.Drawing.Size(930, 504);
            this.xtraTbPointType.TabIndex = 1;
            this.xtraTbPointType.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTPPType,
            this.xtraTPB0,
            this.xtraTPB1,
            this.xtraTPB2,
            this.xtraTPB3,
            this.xtraTPIMXA,
            this.xtraC911});
            this.xtraTbPointType.Click += new System.EventHandler(this.xtraTbPointType_Click);
            // 
            // xtraTPPType
            // 
            this.xtraTPPType.Controls.Add(this.gpPType);
            this.xtraTPPType.FireScrollEventOnMouseWheel = true;
            this.xtraTPPType.Name = "xtraTPPType";
            this.xtraTPPType.Size = new System.Drawing.Size(901, 498);
            this.xtraTPPType.Text = "Point Type";
            this.xtraTPPType.Leave += new System.EventHandler(this.xtraTPPType_Leave);
            // 
            // gpPType
            // 
            this.gpPType.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpPType.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpPType.Controls.Add(this.txtPointtypename);
            this.gpPType.Controls.Add(this.cmbPointTpname);
            this.gpPType.Controls.Add(this.lblPTypeName);
            this.gpPType.Controls.Add(this.cmbPTypeInst);
            this.gpPType.Controls.Add(this.cmbPType);
            this.gpPType.Controls.Add(this.lblPType);
            this.gpPType.Controls.Add(this.lblPTypeInst);
            this.gpPType.Location = new System.Drawing.Point(17, 11);
            this.gpPType.Name = "gpPType";
            this.gpPType.Size = new System.Drawing.Size(372, 206);
            // 
            // 
            // 
            this.gpPType.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpPType.Style.BackColorGradientAngle = 90;
            this.gpPType.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpPType.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpPType.Style.BorderBottomWidth = 1;
            this.gpPType.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpPType.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpPType.Style.BorderLeftWidth = 1;
            this.gpPType.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpPType.Style.BorderRightWidth = 1;
            this.gpPType.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpPType.Style.BorderTopWidth = 1;
            this.gpPType.Style.CornerDiameter = 4;
            this.gpPType.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpPType.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gpPType.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpPType.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.gpPType.TabIndex = 8;
            this.gpPType.Text = "Point Type";
            // 
            // txtPointtypename
            // 
            this.txtPointtypename.Location = new System.Drawing.Point(113, 41);
            this.txtPointtypename.Name = "txtPointtypename";
            this.txtPointtypename.Size = new System.Drawing.Size(243, 20);
            this.txtPointtypename.TabIndex = 7;
            this.txtPointtypename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPointtypename_KeyPress);
            this.txtPointtypename.Leave += new System.EventHandler(this.txtPointtypename_Leave);
            // 
            // cmbPointTpname
            // 
            this.cmbPointTpname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPointTpname.FormattingEnabled = true;
            this.cmbPointTpname.Location = new System.Drawing.Point(113, 40);
            this.cmbPointTpname.Name = "cmbPointTpname";
            this.cmbPointTpname.Size = new System.Drawing.Size(243, 21);
            this.cmbPointTpname.TabIndex = 1;
            this.cmbPointTpname.SelectedValueChanged += new System.EventHandler(this.cmbPointTpname_SelectedValueChanged);
            // 
            // lblPTypeName
            // 
            this.lblPTypeName.Location = new System.Drawing.Point(13, 41);
            this.lblPTypeName.Name = "lblPTypeName";
            this.lblPTypeName.Size = new System.Drawing.Size(81, 13);
            this.lblPTypeName.TabIndex = 3;
            this.lblPTypeName.Text = "Point Type Name";
            // 
            // cmbPTypeInst
            // 
            this.cmbPTypeInst.EditValue = "";
            this.cmbPTypeInst.Location = new System.Drawing.Point(113, 110);
            this.cmbPTypeInst.Name = "cmbPTypeInst";
            this.cmbPTypeInst.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cmbPTypeInst.Properties.Appearance.Options.UseBackColor = true;
            this.cmbPTypeInst.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPTypeInst.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPTypeInst.Size = new System.Drawing.Size(243, 20);
            this.cmbPTypeInst.TabIndex = 3;
            this.cmbPTypeInst.SelectedValueChanged += new System.EventHandler(this.cmbPTypeInst_SelectedValueChanged);
            // 
            // cmbPType
            // 
            this.cmbPType.EditValue = "--Select--";
            this.cmbPType.Location = new System.Drawing.Point(113, 74);
            this.cmbPType.Name = "cmbPType";
            this.cmbPType.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.cmbPType.Properties.Appearance.Options.UseBackColor = true;
            this.cmbPType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPType.Properties.Items.AddRange(new object[] {
            "--Select--",
            "Vibration",
            "Current",
            "Pressure",
            "Manual Entry",
            "Sound"});
            this.cmbPType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPType.Size = new System.Drawing.Size(243, 20);
            this.cmbPType.TabIndex = 2;
            this.cmbPType.SelectedIndexChanged += new System.EventHandler(this.cmbPType_SelectedIndexChanged);
            // 
            // lblPType
            // 
            this.lblPType.Location = new System.Drawing.Point(13, 77);
            this.lblPType.Name = "lblPType";
            this.lblPType.Size = new System.Drawing.Size(54, 13);
            this.lblPType.TabIndex = 4;
            this.lblPType.Text = "Point Type ";
            // 
            // lblPTypeInst
            // 
            this.lblPTypeInst.Location = new System.Drawing.Point(13, 113);
            this.lblPTypeInst.Name = "lblPTypeInst";
            this.lblPTypeInst.Size = new System.Drawing.Size(53, 13);
            this.lblPTypeInst.TabIndex = 5;
            this.lblPTypeInst.Text = "Instrument";
            // 
            // xtraTPB0
            // 
            this.xtraTPB0.Controls.Add(this.xtraSCB0);
            this.xtraTPB0.Name = "xtraTPB0";
            this.xtraTPB0.Size = new System.Drawing.Size(901, 499);
            this.xtraTPB0.Text = "Measurement";
            // 
            // xtraSCB0
            // 
            this.xtraSCB0.Controls.Add(this.groupControl4);
            this.xtraSCB0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraSCB0.Location = new System.Drawing.Point(0, 0);
            this.xtraSCB0.Name = "xtraSCB0";
            this.xtraSCB0.Size = new System.Drawing.Size(901, 499);
            this.xtraSCB0.TabIndex = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl4.Appearance.Options.UseBackColor = true;
            this.groupControl4.AppearanceCaption.BorderColor = System.Drawing.Color.Transparent;
            this.groupControl4.AppearanceCaption.Options.UseBorderColor = true;
            this.groupControl4.AutoSize = true;
            this.groupControl4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl4.Controls.Add(this.lstmeasure);
            this.groupControl4.Controls.Add(this.labelControl6);
            this.groupControl4.Controls.Add(this.labelControl7);
            this.groupControl4.FireScrollEventOnMouseWheel = true;
            this.groupControl4.Location = new System.Drawing.Point(25, 22);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.ShowCaption = false;
            this.groupControl4.Size = new System.Drawing.Size(299, 166);
            this.groupControl4.TabIndex = 48;
            // 
            // lstmeasure
            // 
            this.lstmeasure.BackColor = System.Drawing.Color.White;
            this.lstmeasure.CheckBoxes = true;
            this.lstmeasure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
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
            listViewItem11.ToolTipText = "Amplitude & Phase";
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
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(5, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(65, 13);
            this.labelControl6.TabIndex = 35;
            this.labelControl6.Text = "Measurement";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(5, 150);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(92, 13);
            this.labelControl7.TabIndex = 25;
            this.labelControl7.Text = "Last Analyzed:   ---\r\n";
            // 
            // xtraTPB1
            // 
            this.xtraTPB1.Controls.Add(this.panelControl4);
            this.xtraTPB1.Name = "xtraTPB1";
            this.xtraTPB1.Size = new System.Drawing.Size(901, 498);
            this.xtraTPB1.Text = "Overall/Alarms";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.xtraScB1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(901, 498);
            this.panelControl4.TabIndex = 1;
            // 
            // xtraScB1
            // 
            this.xtraScB1.Controls.Add(this.groupBox5);
            this.xtraScB1.Controls.Add(this.groupControl1);
            this.xtraScB1.Controls.Add(this.gbOverAll);
            this.xtraScB1.Controls.Add(this.gbTime);
            this.xtraScB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScB1.FireScrollEventOnMouseWheel = true;
            this.xtraScB1.Location = new System.Drawing.Point(2, 2);
            this.xtraScB1.Name = "xtraScB1";
            this.xtraScB1.Size = new System.Drawing.Size(897, 494);
            this.xtraScB1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupControl3);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.btnOK);
            this.groupBox5.Location = new System.Drawing.Point(452, 10);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(447, 347);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.Text = "Alarm Options";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.cmbBandGroup);
            this.groupControl3.Location = new System.Drawing.Point(2, 246);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(443, 86);
            this.groupControl3.TabIndex = 9;
            this.groupControl3.Text = "Band Alarm";
            // 
            // cmbBandGroup
            // 
            this.cmbBandGroup.Location = new System.Drawing.Point(6, 37);
            this.cmbBandGroup.Name = "cmbBandGroup";
            this.cmbBandGroup.Properties.AllowFocused = false;
            this.cmbBandGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbBandGroup.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBandGroup.Properties.Appearance.Options.UseBackColor = true;
            this.cmbBandGroup.Properties.Appearance.Options.UseFont = true;
            this.cmbBandGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBandGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBandGroup.Size = new System.Drawing.Size(273, 20);
            this.cmbBandGroup.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbAlarmlist);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(2, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 62);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.Text = "General Alarm";
            // 
            // cmbAlarmlist
            // 
            this.cmbAlarmlist.Location = new System.Drawing.Point(6, 30);
            this.cmbAlarmlist.Name = "cmbAlarmlist";
            this.cmbAlarmlist.Properties.AllowFocused = false;
            this.cmbAlarmlist.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbAlarmlist.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAlarmlist.Properties.Appearance.Options.UseBackColor = true;
            this.cmbAlarmlist.Properties.Appearance.Options.UseFont = true;
            this.cmbAlarmlist.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAlarmlist.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbAlarmlist.Size = new System.Drawing.Size(273, 20);
            this.cmbAlarmlist.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbSDAlarmList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(2, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(443, 75);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.Text = "Deviation Alarm";
            // 
            // cmbSDAlarmList
            // 
            this.cmbSDAlarmList.Location = new System.Drawing.Point(6, 30);
            this.cmbSDAlarmList.Name = "cmbSDAlarmList";
            this.cmbSDAlarmList.Properties.AllowFocused = false;
            this.cmbSDAlarmList.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbSDAlarmList.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSDAlarmList.Properties.Appearance.Options.UseBackColor = true;
            this.cmbSDAlarmList.Properties.Appearance.Options.UseFont = true;
            this.cmbSDAlarmList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSDAlarmList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbSDAlarmList.Size = new System.Drawing.Size(273, 20);
            this.cmbSDAlarmList.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbPAlarmList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(2, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 82);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.Text = "Percentage Alarm";
            // 
            // cmbPAlarmList
            // 
            this.cmbPAlarmList.Location = new System.Drawing.Point(6, 30);
            this.cmbPAlarmList.Name = "cmbPAlarmList";
            this.cmbPAlarmList.Properties.AllowFocused = false;
            this.cmbPAlarmList.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbPAlarmList.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPAlarmList.Properties.Appearance.Options.UseBackColor = true;
            this.cmbPAlarmList.Properties.Appearance.Options.UseFont = true;
            this.cmbPAlarmList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPAlarmList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPAlarmList.Size = new System.Drawing.Size(273, 20);
            this.cmbPAlarmList.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(6, 111);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(17, 10);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gbUniaxial);
            this.groupControl1.Controls.Add(this.cmbtempname);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.CmbSensorName);
            this.groupControl1.Location = new System.Drawing.Point(14, 178);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(432, 179);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "Sensor";
            // 
            // gbUniaxial
            // 
            this.gbUniaxial.Controls.Add(this.cbICPPower);
            this.gbUniaxial.Controls.Add(this.chkCH1);
            this.gbUniaxial.Controls.Add(this.chkAxial);
            this.gbUniaxial.Controls.Add(this.chkHorizontal);
            this.gbUniaxial.Controls.Add(this.chkVertical);
            this.gbUniaxial.Location = new System.Drawing.Point(7, 58);
            this.gbUniaxial.Name = "gbUniaxial";
            this.gbUniaxial.Size = new System.Drawing.Size(414, 109);
            this.gbUniaxial.TabIndex = 18;
            this.gbUniaxial.Text = "Direction Option for Uniaxial";
            // 
            // cbICPPower
            // 
            this.cbICPPower.Enabled = false;
            this.cbICPPower.Location = new System.Drawing.Point(100, 71);
            this.cbICPPower.Name = "cbICPPower";
            this.cbICPPower.Properties.AllowFocused = false;
            this.cbICPPower.Properties.Caption = "ICP Power";
            this.cbICPPower.Size = new System.Drawing.Size(76, 19);
            this.cbICPPower.TabIndex = 21;
            // 
            // chkCH1
            // 
            this.chkCH1.Enabled = false;
            this.chkCH1.Location = new System.Drawing.Point(16, 71);
            this.chkCH1.Name = "chkCH1";
            this.chkCH1.Properties.AllowFocused = false;
            this.chkCH1.Properties.Caption = "CH1";
            this.chkCH1.Size = new System.Drawing.Size(84, 19);
            this.chkCH1.TabIndex = 20;
            // 
            // chkAxial
            // 
            this.chkAxial.EditValue = true;
            this.chkAxial.Location = new System.Drawing.Point(16, 35);
            this.chkAxial.Name = "chkAxial";
            this.chkAxial.Properties.AllowFocused = false;
            this.chkAxial.Properties.Caption = "Axial";
            this.chkAxial.Size = new System.Drawing.Size(84, 19);
            this.chkAxial.TabIndex = 14;
            this.chkAxial.CheckedChanged += new System.EventHandler(this.chkVertical_CheckedChanged);
            // 
            // chkHorizontal
            // 
            this.chkHorizontal.Location = new System.Drawing.Point(100, 35);
            this.chkHorizontal.Name = "chkHorizontal";
            this.chkHorizontal.Properties.AllowFocused = false;
            this.chkHorizontal.Properties.Caption = "Horizontal";
            this.chkHorizontal.Size = new System.Drawing.Size(84, 19);
            this.chkHorizontal.TabIndex = 14;
            this.chkHorizontal.CheckedChanged += new System.EventHandler(this.chkVertical_CheckedChanged);
            // 
            // chkVertical
            // 
            this.chkVertical.Location = new System.Drawing.Point(184, 35);
            this.chkVertical.Name = "chkVertical";
            this.chkVertical.Properties.AllowFocused = false;
            this.chkVertical.Properties.Caption = "Vertical";
            this.chkVertical.Size = new System.Drawing.Size(84, 19);
            this.chkVertical.TabIndex = 14;
            this.chkVertical.CheckedChanged += new System.EventHandler(this.chkVertical_CheckedChanged);
            // 
            // cmbtempname
            // 
            this.cmbtempname.Location = new System.Drawing.Point(297, 29);
            this.cmbtempname.Name = "cmbtempname";
            this.cmbtempname.Properties.AllowFocused = false;
            this.cmbtempname.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbtempname.Properties.Appearance.Options.UseBackColor = true;
            this.cmbtempname.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbtempname.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbtempname.Size = new System.Drawing.Size(100, 20);
            this.cmbtempname.TabIndex = 14;
            this.cmbtempname.SelectedIndexChanged += new System.EventHandler(this.cmbtempname_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(193, 31);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(98, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Temperature Sensor";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Sensor";
            // 
            // CmbSensorName
            // 
            this.CmbSensorName.Location = new System.Drawing.Point(55, 29);
            this.CmbSensorName.Name = "CmbSensorName";
            this.CmbSensorName.Properties.AllowFocused = false;
            this.CmbSensorName.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.CmbSensorName.Properties.Appearance.Options.UseBackColor = true;
            this.CmbSensorName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CmbSensorName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CmbSensorName.Size = new System.Drawing.Size(100, 20);
            this.CmbSensorName.TabIndex = 0;
            this.CmbSensorName.SelectedIndexChanged += new System.EventHandler(this.CmbSensorName_SelectedIndexChanged);
            // 
            // gbOverAll
            // 
            this.gbOverAll.Controls.Add(this.cmbaccHPFilter);
            this.gbOverAll.Controls.Add(this.labelControl5);
            this.gbOverAll.Controls.Add(this.lblCrestFilter);
            this.gbOverAll.Controls.Add(this.cbCrestFilter);
            this.gbOverAll.Controls.Add(this.lblBearingFilter);
            this.gbOverAll.Controls.Add(this.cbBearingFilter);
            this.gbOverAll.Controls.Add(this.lblDisplacementFilter);
            this.gbOverAll.Controls.Add(this.cbDispFilter);
            this.gbOverAll.Controls.Add(this.lblVelocityFilter);
            this.gbOverAll.Controls.Add(this.cbVelocityFilter);
            this.gbOverAll.Controls.Add(this.cbAccelerationFilter);
            this.gbOverAll.Controls.Add(this.lblAccFilter);
            this.gbOverAll.Location = new System.Drawing.Point(14, 11);
            this.gbOverAll.Name = "gbOverAll";
            this.gbOverAll.Size = new System.Drawing.Size(432, 102);
            this.gbOverAll.TabIndex = 10;
            this.gbOverAll.Text = "OverAll";
            // 
            // cmbaccHPFilter
            // 
            this.cmbaccHPFilter.EditValue = "500Hz";
            this.cmbaccHPFilter.Location = new System.Drawing.Point(316, 76);
            this.cmbaccHPFilter.Name = "cmbaccHPFilter";
            this.cmbaccHPFilter.Properties.AllowFocused = false;
            this.cmbaccHPFilter.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbaccHPFilter.Properties.Appearance.Options.UseBackColor = true;
            this.cmbaccHPFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbaccHPFilter.Properties.Items.AddRange(new object[] {
            "500Hz",
            "1kHz",
            "2kHz",
            "5kHz",
            "10kHz",
            "20kHz"});
            this.cmbaccHPFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbaccHPFilter.Size = new System.Drawing.Size(105, 20);
            this.cmbaccHPFilter.TabIndex = 14;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(205, 79);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(102, 13);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Acceleration HP Filter";
            // 
            // lblCrestFilter
            // 
            this.lblCrestFilter.Location = new System.Drawing.Point(7, 79);
            this.lblCrestFilter.Name = "lblCrestFilter";
            this.lblCrestFilter.Size = new System.Drawing.Size(87, 13);
            this.lblCrestFilter.TabIndex = 12;
            this.lblCrestFilter.Text = "Crest Factor Filter";
            // 
            // cbCrestFilter
            // 
            this.cbCrestFilter.EditValue = "None";
            this.cbCrestFilter.Location = new System.Drawing.Point(102, 76);
            this.cbCrestFilter.Name = "cbCrestFilter";
            this.cbCrestFilter.Properties.AllowFocused = false;
            this.cbCrestFilter.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbCrestFilter.Properties.Appearance.Options.UseBackColor = true;
            this.cbCrestFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCrestFilter.Properties.Items.AddRange(new object[] {
            "None",
            "2Hz - 1KHz",
            "5Hz - 1KHz",
            "10Hz - 1KHz",
            "2Hz HP",
            "5Hz HP",
            "10Hz HP"});
            this.cbCrestFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbCrestFilter.Size = new System.Drawing.Size(81, 20);
            this.cbCrestFilter.TabIndex = 11;
            // 
            // lblBearingFilter
            // 
            this.lblBearingFilter.Location = new System.Drawing.Point(205, 53);
            this.lblBearingFilter.Name = "lblBearingFilter";
            this.lblBearingFilter.Size = new System.Drawing.Size(63, 13);
            this.lblBearingFilter.TabIndex = 10;
            this.lblBearingFilter.Text = "Bearing Filter";
            // 
            // cbBearingFilter
            // 
            this.cbBearingFilter.EditValue = "Acceleration HP";
            this.cbBearingFilter.Location = new System.Drawing.Point(316, 50);
            this.cbBearingFilter.Name = "cbBearingFilter";
            this.cbBearingFilter.Properties.AllowFocused = false;
            this.cbBearingFilter.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbBearingFilter.Properties.Appearance.Options.UseBackColor = true;
            this.cbBearingFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBearingFilter.Properties.Items.AddRange(new object[] {
            "Acceleration HP",
            "Envelop Acceleration"});
            this.cbBearingFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbBearingFilter.Size = new System.Drawing.Size(105, 20);
            this.cbBearingFilter.TabIndex = 7;
            // 
            // lblDisplacementFilter
            // 
            this.lblDisplacementFilter.Location = new System.Drawing.Point(7, 53);
            this.lblDisplacementFilter.Name = "lblDisplacementFilter";
            this.lblDisplacementFilter.Size = new System.Drawing.Size(90, 13);
            this.lblDisplacementFilter.TabIndex = 5;
            this.lblDisplacementFilter.Text = "Displacement Filter";
            // 
            // cbDispFilter
            // 
            this.cbDispFilter.EditValue = "None";
            this.cbDispFilter.Location = new System.Drawing.Point(102, 50);
            this.cbDispFilter.Name = "cbDispFilter";
            this.cbDispFilter.Properties.AllowFocused = false;
            this.cbDispFilter.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbDispFilter.Properties.Appearance.Options.UseBackColor = true;
            this.cbDispFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDispFilter.Properties.Items.AddRange(new object[] {
            "None",
            "2Hz - 1KHz",
            "5Hz - 1KHz",
            "10Hz - 1KHz",
            "2Hz HP",
            "5Hz HP",
            "10Hz HP"});
            this.cbDispFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbDispFilter.Size = new System.Drawing.Size(81, 20);
            this.cbDispFilter.TabIndex = 4;
            // 
            // lblVelocityFilter
            // 
            this.lblVelocityFilter.Location = new System.Drawing.Point(205, 26);
            this.lblVelocityFilter.Name = "lblVelocityFilter";
            this.lblVelocityFilter.Size = new System.Drawing.Size(64, 13);
            this.lblVelocityFilter.TabIndex = 3;
            this.lblVelocityFilter.Text = "Velocity Filter";
            // 
            // cbVelocityFilter
            // 
            this.cbVelocityFilter.EditValue = "None";
            this.cbVelocityFilter.Location = new System.Drawing.Point(316, 24);
            this.cbVelocityFilter.Name = "cbVelocityFilter";
            this.cbVelocityFilter.Properties.AllowFocused = false;
            this.cbVelocityFilter.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbVelocityFilter.Properties.Appearance.Options.UseBackColor = true;
            this.cbVelocityFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbVelocityFilter.Properties.Items.AddRange(new object[] {
            "None",
            "2Hz - 1KHz",
            "5Hz - 1KHz",
            "10Hz - 1KHz",
            "2Hz HP",
            "5Hz HP",
            "10Hz HP"});
            this.cbVelocityFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbVelocityFilter.Size = new System.Drawing.Size(105, 20);
            this.cbVelocityFilter.TabIndex = 2;
            // 
            // cbAccelerationFilter
            // 
            this.cbAccelerationFilter.EditValue = "None";
            this.cbAccelerationFilter.Location = new System.Drawing.Point(102, 23);
            this.cbAccelerationFilter.Name = "cbAccelerationFilter";
            this.cbAccelerationFilter.Properties.AllowFocused = false;
            this.cbAccelerationFilter.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbAccelerationFilter.Properties.Appearance.Options.UseBackColor = true;
            this.cbAccelerationFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAccelerationFilter.Properties.Items.AddRange(new object[] {
            "None",
            "2Hz - 1KHz",
            "5Hz - 1KHz",
            "10Hz - 1KHz",
            "2Hz HP",
            "5Hz HP",
            "10Hz HP"});
            this.cbAccelerationFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAccelerationFilter.Size = new System.Drawing.Size(81, 20);
            this.cbAccelerationFilter.TabIndex = 1;
            // 
            // lblAccFilter
            // 
            this.lblAccFilter.Location = new System.Drawing.Point(7, 26);
            this.lblAccFilter.Name = "lblAccFilter";
            this.lblAccFilter.Size = new System.Drawing.Size(86, 13);
            this.lblAccFilter.TabIndex = 0;
            this.lblAccFilter.Text = "Acceleration Filter";
            // 
            // gbTime
            // 
            this.gbTime.Controls.Add(this.cbOverlap);
            this.gbTime.Controls.Add(this.lblOverlap);
            this.gbTime.Controls.Add(this.lblLines);
            this.gbTime.Controls.Add(this.cbLines);
            this.gbTime.Controls.Add(this.cbTimeBand);
            this.gbTime.Controls.Add(this.lblBand);
            this.gbTime.Location = new System.Drawing.Point(14, 115);
            this.gbTime.Name = "gbTime";
            this.gbTime.Size = new System.Drawing.Size(432, 60);
            this.gbTime.TabIndex = 11;
            this.gbTime.Text = "Time";
            // 
            // cbOverlap
            // 
            this.cbOverlap.EditValue = "0%";
            this.cbOverlap.Location = new System.Drawing.Point(301, 23);
            this.cbOverlap.Name = "cbOverlap";
            this.cbOverlap.Properties.AllowFocused = false;
            this.cbOverlap.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbOverlap.Properties.Appearance.Options.UseBackColor = true;
            this.cbOverlap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbOverlap.Properties.Items.AddRange(new object[] {
            "0%",
            "25%",
            "50%",
            "75%",
            "Max"});
            this.cbOverlap.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbOverlap.Size = new System.Drawing.Size(105, 20);
            this.cbOverlap.TabIndex = 12;
            // 
            // lblOverlap
            // 
            this.lblOverlap.Location = new System.Drawing.Point(253, 26);
            this.lblOverlap.Name = "lblOverlap";
            this.lblOverlap.Size = new System.Drawing.Size(38, 13);
            this.lblOverlap.TabIndex = 11;
            this.lblOverlap.Text = "Overlap";
            // 
            // lblLines
            // 
            this.lblLines.Location = new System.Drawing.Point(123, 26);
            this.lblLines.Name = "lblLines";
            this.lblLines.Size = new System.Drawing.Size(50, 13);
            this.lblLines.TabIndex = 3;
            this.lblLines.Text = "Resolution";
            // 
            // cbLines
            // 
            this.cbLines.EditValue = "2048";
            this.cbLines.Location = new System.Drawing.Point(179, 23);
            this.cbLines.Name = "cbLines";
            this.cbLines.Properties.AllowFocused = false;
            this.cbLines.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbLines.Properties.Appearance.Options.UseBackColor = true;
            this.cbLines.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLines.Properties.Items.AddRange(new object[] {
            "256",
            "512",
            "1024",
            "2048",
            "4096",
            "8190",
            "16384",
            "32768"});
            this.cbLines.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbLines.Size = new System.Drawing.Size(57, 20);
            this.cbLines.TabIndex = 2;
            // 
            // cbTimeBand
            // 
            this.cbTimeBand.EditValue = "1 KHz";
            this.cbTimeBand.Location = new System.Drawing.Point(47, 23);
            this.cbTimeBand.Name = "cbTimeBand";
            this.cbTimeBand.Properties.AllowFocused = false;
            this.cbTimeBand.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbTimeBand.Properties.Appearance.Options.UseBackColor = true;
            this.cbTimeBand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTimeBand.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbTimeBand.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbTimeBand.Size = new System.Drawing.Size(57, 20);
            this.cbTimeBand.TabIndex = 1;
            // 
            // lblBand
            // 
            this.lblBand.Location = new System.Drawing.Point(9, 26);
            this.lblBand.Name = "lblBand";
            this.lblBand.Size = new System.Drawing.Size(24, 13);
            this.lblBand.TabIndex = 0;
            this.lblBand.Text = "Band";
            // 
            // xtraTPB2
            // 
            this.xtraTPB2.Controls.Add(this.panelControl3);
            this.xtraTPB2.Name = "xtraTPB2";
            this.xtraTPB2.Size = new System.Drawing.Size(901, 498);
            this.xtraTPB2.Text = "Power";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.xtraSCB2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(901, 498);
            this.panelControl3.TabIndex = 1;
            // 
            // xtraSCB2
            // 
            this.xtraSCB2.Controls.Add(this.gboctave);
            this.xtraSCB2.Controls.Add(this.gbOrdertrace);
            this.xtraSCB2.Controls.Add(this.hbPowerSpectrum);
            this.xtraSCB2.Controls.Add(this.gbDemodulate);
            this.xtraSCB2.Controls.Add(this.gbCepstrum);
            this.xtraSCB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraSCB2.FireScrollEventOnMouseWheel = true;
            this.xtraSCB2.Location = new System.Drawing.Point(2, 2);
            this.xtraSCB2.Name = "xtraSCB2";
            this.xtraSCB2.Size = new System.Drawing.Size(897, 494);
            this.xtraSCB2.TabIndex = 0;
            // 
            // gboctave
            // 
            this.gboctave.Controls.Add(this.textEdit1);
            this.gboctave.Controls.Add(this.lblN);
            this.gboctave.Controls.Add(this.cmbBarstyle);
            this.gboctave.Controls.Add(this.lblBarstyle);
            this.gboctave.Controls.Add(this.cmbOctave);
            this.gboctave.Controls.Add(this.lblOctave);
            this.gboctave.Location = new System.Drawing.Point(16, 306);
            this.gboctave.Name = "gboctave";
            this.gboctave.Size = new System.Drawing.Size(399, 80);
            this.gboctave.TabIndex = 49;
            this.gboctave.Text = "Octave";
            this.gboctave.Visible = false;
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "2";
            this.textEdit1.Location = new System.Drawing.Point(67, 55);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(40, 20);
            this.textEdit1.TabIndex = 5;
            this.textEdit1.Visible = false;
            // 
            // lblN
            // 
            this.lblN.Location = new System.Drawing.Point(42, 58);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(17, 13);
            this.lblN.TabIndex = 4;
            this.lblN.Text = "n =";
            this.lblN.Visible = false;
            // 
            // cmbBarstyle
            // 
            this.cmbBarstyle.EditValue = "Bars with Border";
            this.cmbBarstyle.Location = new System.Drawing.Point(225, 28);
            this.cmbBarstyle.Name = "cmbBarstyle";
            this.cmbBarstyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBarstyle.Properties.Items.AddRange(new object[] {
            "Bars with Border",
            "Empty Bars",
            "Filled bars",
            "Thick Lines",
            "Thin Lines"});
            this.cmbBarstyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBarstyle.Size = new System.Drawing.Size(124, 20);
            this.cmbBarstyle.TabIndex = 3;
            // 
            // lblBarstyle
            // 
            this.lblBarstyle.Location = new System.Drawing.Point(172, 31);
            this.lblBarstyle.Name = "lblBarstyle";
            this.lblBarstyle.Size = new System.Drawing.Size(43, 13);
            this.lblBarstyle.TabIndex = 2;
            this.lblBarstyle.Text = "Bar Style";
            // 
            // cmbOctave
            // 
            this.cmbOctave.EditValue = "1";
            this.cmbOctave.Location = new System.Drawing.Point(101, 28);
            this.cmbOctave.Name = "cmbOctave";
            this.cmbOctave.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOctave.Properties.Items.AddRange(new object[] {
            "1",
            "3",
            "12"});
            this.cmbOctave.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbOctave.Size = new System.Drawing.Size(51, 20);
            this.cmbOctave.TabIndex = 1;
            // 
            // lblOctave
            // 
            this.lblOctave.Location = new System.Drawing.Point(15, 31);
            this.lblOctave.Name = "lblOctave";
            this.lblOctave.Size = new System.Drawing.Size(80, 13);
            this.lblOctave.TabIndex = 0;
            this.lblOctave.Text = "Octaves          1/";
            // 
            // gbOrdertrace
            // 
            this.gbOrdertrace.Controls.Add(this.cbOTSlope);
            this.gbOrdertrace.Controls.Add(this.labelControl22);
            this.gbOrdertrace.Controls.Add(this.labelControl21);
            this.gbOrdertrace.Controls.Add(this.cbOTLines);
            this.gbOrdertrace.Controls.Add(this.labelControl19);
            this.gbOrdertrace.Controls.Add(this.txtOTOrder);
            this.gbOrdertrace.Controls.Add(this.cbOTAvg);
            this.gbOrdertrace.Controls.Add(this.labelControl20);
            this.gbOrdertrace.Location = new System.Drawing.Point(421, 204);
            this.gbOrdertrace.Name = "gbOrdertrace";
            this.gbOrdertrace.Size = new System.Drawing.Size(391, 93);
            this.gbOrdertrace.TabIndex = 47;
            this.gbOrdertrace.Text = "Order Trace";
            // 
            // cbOTSlope
            // 
            this.cbOTSlope.EditValue = "Positive";
            this.cbOTSlope.Location = new System.Drawing.Point(235, 53);
            this.cbOTSlope.Name = "cbOTSlope";
            this.cbOTSlope.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbOTSlope.Properties.Appearance.Options.UseBackColor = true;
            this.cbOTSlope.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbOTSlope.Properties.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.cbOTSlope.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbOTSlope.Size = new System.Drawing.Size(86, 20);
            this.cbOTSlope.TabIndex = 27;
            // 
            // labelControl22
            // 
            this.labelControl22.Location = new System.Drawing.Point(166, 56);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(63, 13);
            this.labelControl22.TabIndex = 26;
            this.labelControl22.Text = "Trigger Slope";
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(10, 56);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(28, 13);
            this.labelControl21.TabIndex = 25;
            this.labelControl21.Text = "Order";
            // 
            // cbOTLines
            // 
            this.cbOTLines.EditValue = "0.25";
            this.cbOTLines.Location = new System.Drawing.Point(222, 27);
            this.cbOTLines.Name = "cbOTLines";
            this.cbOTLines.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbOTLines.Properties.Appearance.Options.UseBackColor = true;
            this.cbOTLines.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbOTLines.Properties.Items.AddRange(new object[] {
            "0.5",
            "0.25",
            "0.125",
            "0.0625"});
            this.cbOTLines.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbOTLines.Size = new System.Drawing.Size(67, 20);
            this.cbOTLines.TabIndex = 24;
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(166, 30);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(50, 13);
            this.labelControl19.TabIndex = 23;
            this.labelControl19.Text = "Resolution";
            // 
            // txtOTOrder
            // 
            this.txtOTOrder.EditValue = "1";
            this.txtOTOrder.Location = new System.Drawing.Point(44, 53);
            this.txtOTOrder.Name = "txtOTOrder";
            this.txtOTOrder.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtOTOrder.Properties.Appearance.Options.UseBackColor = true;
            this.txtOTOrder.Properties.MaxLength = 8;
            this.txtOTOrder.Size = new System.Drawing.Size(96, 20);
            this.txtOTOrder.TabIndex = 22;
            // 
            // cbOTAvg
            // 
            this.cbOTAvg.EditValue = "10";
            this.cbOTAvg.Location = new System.Drawing.Point(87, 27);
            this.cbOTAvg.Name = "cbOTAvg";
            this.cbOTAvg.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbOTAvg.Properties.Appearance.Options.UseBackColor = true;
            this.cbOTAvg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbOTAvg.Properties.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
            this.cbOTAvg.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbOTAvg.Size = new System.Drawing.Size(67, 20);
            this.cbOTAvg.TabIndex = 14;
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(9, 30);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(61, 13);
            this.labelControl20.TabIndex = 13;
            this.labelControl20.Text = "Average No.";
            // 
            // hbPowerSpectrum
            // 
            this.hbPowerSpectrum.Controls.Add(this.label128);
            this.hbPowerSpectrum.Controls.Add(this.chkbxG3P1);
            this.hbPowerSpectrum.Controls.Add(this.chkbxG3P2);
            this.hbPowerSpectrum.Controls.Add(this.lblG3P2Line);
            this.hbPowerSpectrum.Controls.Add(this.cbG3PSLines1);
            this.hbPowerSpectrum.Controls.Add(this.cbG3PSBand1);
            this.hbPowerSpectrum.Controls.Add(this.lblG3P2Band);
            this.hbPowerSpectrum.Controls.Add(this.lblG3P1Line);
            this.hbPowerSpectrum.Controls.Add(this.cbG3PSLines);
            this.hbPowerSpectrum.Controls.Add(this.cbG3PSBand);
            this.hbPowerSpectrum.Controls.Add(this.lblG3P1Band);
            this.hbPowerSpectrum.Controls.Add(this.label127);
            this.hbPowerSpectrum.Controls.Add(this.chkbxG2P1);
            this.hbPowerSpectrum.Controls.Add(this.chkbxG2P2);
            this.hbPowerSpectrum.Controls.Add(this.lblG2P2Line);
            this.hbPowerSpectrum.Controls.Add(this.cbG2PSLines1);
            this.hbPowerSpectrum.Controls.Add(this.cbG2PSBand1);
            this.hbPowerSpectrum.Controls.Add(this.lblG2P2Band);
            this.hbPowerSpectrum.Controls.Add(this.lblG2P1Line);
            this.hbPowerSpectrum.Controls.Add(this.cbG2PSLines);
            this.hbPowerSpectrum.Controls.Add(this.cbG2PSBand);
            this.hbPowerSpectrum.Controls.Add(this.lblG2P1Band);
            this.hbPowerSpectrum.Controls.Add(this.label126);
            this.hbPowerSpectrum.Controls.Add(this.chkbxG1P1);
            this.hbPowerSpectrum.Controls.Add(this.cbMultipleBand);
            this.hbPowerSpectrum.Controls.Add(this.lblPowerLine1);
            this.hbPowerSpectrum.Controls.Add(this.cbPSLines1);
            this.hbPowerSpectrum.Controls.Add(this.cbPSBand1);
            this.hbPowerSpectrum.Controls.Add(this.lblPowerBand1);
            this.hbPowerSpectrum.Controls.Add(this.txtPSZoom);
            this.hbPowerSpectrum.Controls.Add(this.cbZoom);
            this.hbPowerSpectrum.Controls.Add(this.cbPSOverlap);
            this.hbPowerSpectrum.Controls.Add(this.lblPSOverlap);
            this.hbPowerSpectrum.Controls.Add(this.cbAvgTimes);
            this.hbPowerSpectrum.Controls.Add(this.lblAverageTimes);
            this.hbPowerSpectrum.Controls.Add(this.cbPSWindow);
            this.hbPowerSpectrum.Controls.Add(this.lblWindow);
            this.hbPowerSpectrum.Controls.Add(this.label87);
            this.hbPowerSpectrum.Controls.Add(this.cbPSLines);
            this.hbPowerSpectrum.Controls.Add(this.cbPSBand);
            this.hbPowerSpectrum.Controls.Add(this.label88);
            this.hbPowerSpectrum.Location = new System.Drawing.Point(16, 2);
            this.hbPowerSpectrum.Name = "hbPowerSpectrum";
            this.hbPowerSpectrum.Size = new System.Drawing.Size(399, 295);
            this.hbPowerSpectrum.TabIndex = 46;
            this.hbPowerSpectrum.Text = "PowerSpectrum";
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label128.Location = new System.Drawing.Point(284, 25);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(52, 13);
            this.label128.TabIndex = 47;
            this.label128.Text = "Group 3";
            // 
            // chkbxG3P1
            // 
            this.chkbxG3P1.AutoSize = true;
            this.chkbxG3P1.Enabled = false;
            this.chkbxG3P1.Location = new System.Drawing.Point(276, 48);
            this.chkbxG3P1.Name = "chkbxG3P1";
            this.chkbxG3P1.Size = new System.Drawing.Size(65, 17);
            this.chkbxG3P1.TabIndex = 46;
            this.chkbxG3P1.Text = "Power 1";
            this.chkbxG3P1.UseVisualStyleBackColor = true;
            this.chkbxG3P1.CheckedChanged += new System.EventHandler(this.chkbxG3P1_CheckedChanged);
            // 
            // chkbxG3P2
            // 
            this.chkbxG3P2.Enabled = false;
            this.chkbxG3P2.Location = new System.Drawing.Point(274, 129);
            this.chkbxG3P2.Name = "chkbxG3P2";
            this.chkbxG3P2.Properties.Caption = "Power 2";
            this.chkbxG3P2.Size = new System.Drawing.Size(87, 19);
            this.chkbxG3P2.TabIndex = 45;
            this.chkbxG3P2.CheckedChanged += new System.EventHandler(this.chkbxG3P2_CheckedChanged);
            // 
            // lblG3P2Line
            // 
            this.lblG3P2Line.Enabled = false;
            this.lblG3P2Line.Location = new System.Drawing.Point(276, 182);
            this.lblG3P2Line.Name = "lblG3P2Line";
            this.lblG3P2Line.Size = new System.Drawing.Size(50, 13);
            this.lblG3P2Line.TabIndex = 44;
            this.lblG3P2Line.Text = "Resolution";
            // 
            // cbG3PSLines1
            // 
            this.cbG3PSLines1.EditValue = "800";
            this.cbG3PSLines1.Enabled = false;
            this.cbG3PSLines1.Location = new System.Drawing.Point(332, 179);
            this.cbG3PSLines1.Name = "cbG3PSLines1";
            this.cbG3PSLines1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbG3PSLines1.Properties.Appearance.Options.UseBackColor = true;
            this.cbG3PSLines1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbG3PSLines1.Properties.Items.AddRange(new object[] {
            "100",
            "200",
            "400",
            "800",
            "1600",
            "3200",
            "6400",
            "12800"});
            this.cbG3PSLines1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbG3PSLines1.Size = new System.Drawing.Size(57, 20);
            this.cbG3PSLines1.TabIndex = 43;
            // 
            // cbG3PSBand1
            // 
            this.cbG3PSBand1.EditValue = "1 KHz";
            this.cbG3PSBand1.Enabled = false;
            this.cbG3PSBand1.Location = new System.Drawing.Point(332, 153);
            this.cbG3PSBand1.Name = "cbG3PSBand1";
            this.cbG3PSBand1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbG3PSBand1.Properties.Appearance.Options.UseBackColor = true;
            this.cbG3PSBand1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbG3PSBand1.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbG3PSBand1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbG3PSBand1.Size = new System.Drawing.Size(57, 20);
            this.cbG3PSBand1.TabIndex = 42;
            // 
            // lblG3P2Band
            // 
            this.lblG3P2Band.Enabled = false;
            this.lblG3P2Band.Location = new System.Drawing.Point(276, 156);
            this.lblG3P2Band.Name = "lblG3P2Band";
            this.lblG3P2Band.Size = new System.Drawing.Size(24, 13);
            this.lblG3P2Band.TabIndex = 41;
            this.lblG3P2Band.Text = "Band";
            // 
            // lblG3P1Line
            // 
            this.lblG3P1Line.Enabled = false;
            this.lblG3P1Line.Location = new System.Drawing.Point(276, 101);
            this.lblG3P1Line.Name = "lblG3P1Line";
            this.lblG3P1Line.Size = new System.Drawing.Size(50, 13);
            this.lblG3P1Line.TabIndex = 40;
            this.lblG3P1Line.Text = "Resolution";
            // 
            // cbG3PSLines
            // 
            this.cbG3PSLines.EditValue = "800";
            this.cbG3PSLines.Enabled = false;
            this.cbG3PSLines.Location = new System.Drawing.Point(332, 99);
            this.cbG3PSLines.Name = "cbG3PSLines";
            this.cbG3PSLines.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbG3PSLines.Properties.Appearance.Options.UseBackColor = true;
            this.cbG3PSLines.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbG3PSLines.Properties.Items.AddRange(new object[] {
            "100",
            "200",
            "400",
            "800",
            "1600",
            "3200",
            "6400",
            "12800"});
            this.cbG3PSLines.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbG3PSLines.Size = new System.Drawing.Size(57, 20);
            this.cbG3PSLines.TabIndex = 39;
            // 
            // cbG3PSBand
            // 
            this.cbG3PSBand.EditValue = "1 KHz";
            this.cbG3PSBand.Enabled = false;
            this.cbG3PSBand.Location = new System.Drawing.Point(332, 73);
            this.cbG3PSBand.Name = "cbG3PSBand";
            this.cbG3PSBand.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbG3PSBand.Properties.Appearance.Options.UseBackColor = true;
            this.cbG3PSBand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbG3PSBand.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbG3PSBand.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbG3PSBand.Size = new System.Drawing.Size(57, 20);
            this.cbG3PSBand.TabIndex = 38;
            // 
            // lblG3P1Band
            // 
            this.lblG3P1Band.Enabled = false;
            this.lblG3P1Band.Location = new System.Drawing.Point(276, 75);
            this.lblG3P1Band.Name = "lblG3P1Band";
            this.lblG3P1Band.Size = new System.Drawing.Size(24, 13);
            this.lblG3P1Band.TabIndex = 37;
            this.lblG3P1Band.Text = "Band";
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label127.Location = new System.Drawing.Point(129, 25);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(52, 13);
            this.label127.TabIndex = 36;
            this.label127.Text = "Group 2";
            // 
            // chkbxG2P1
            // 
            this.chkbxG2P1.AutoSize = true;
            this.chkbxG2P1.Location = new System.Drawing.Point(132, 49);
            this.chkbxG2P1.Name = "chkbxG2P1";
            this.chkbxG2P1.Size = new System.Drawing.Size(65, 17);
            this.chkbxG2P1.TabIndex = 35;
            this.chkbxG2P1.Text = "Power 1";
            this.chkbxG2P1.UseVisualStyleBackColor = true;
            this.chkbxG2P1.CheckedChanged += new System.EventHandler(this.chkbxG2P1_CheckedChanged);
            // 
            // chkbxG2P2
            // 
            this.chkbxG2P2.Enabled = false;
            this.chkbxG2P2.Location = new System.Drawing.Point(130, 130);
            this.chkbxG2P2.Name = "chkbxG2P2";
            this.chkbxG2P2.Properties.Caption = "Power 2";
            this.chkbxG2P2.Size = new System.Drawing.Size(87, 19);
            this.chkbxG2P2.TabIndex = 34;
            this.chkbxG2P2.CheckedChanged += new System.EventHandler(this.chkbxG2P2_CheckedChanged);
            // 
            // lblG2P2Line
            // 
            this.lblG2P2Line.Enabled = false;
            this.lblG2P2Line.Location = new System.Drawing.Point(131, 182);
            this.lblG2P2Line.Name = "lblG2P2Line";
            this.lblG2P2Line.Size = new System.Drawing.Size(50, 13);
            this.lblG2P2Line.TabIndex = 33;
            this.lblG2P2Line.Text = "Resolution";
            // 
            // cbG2PSLines1
            // 
            this.cbG2PSLines1.EditValue = "800";
            this.cbG2PSLines1.Enabled = false;
            this.cbG2PSLines1.Location = new System.Drawing.Point(188, 179);
            this.cbG2PSLines1.Name = "cbG2PSLines1";
            this.cbG2PSLines1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbG2PSLines1.Properties.Appearance.Options.UseBackColor = true;
            this.cbG2PSLines1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbG2PSLines1.Properties.Items.AddRange(new object[] {
            "100",
            "200",
            "400",
            "800",
            "1600",
            "3200",
            "6400",
            "12800"});
            this.cbG2PSLines1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbG2PSLines1.Size = new System.Drawing.Size(57, 20);
            this.cbG2PSLines1.TabIndex = 32;
            // 
            // cbG2PSBand1
            // 
            this.cbG2PSBand1.EditValue = "1 KHz";
            this.cbG2PSBand1.Enabled = false;
            this.cbG2PSBand1.Location = new System.Drawing.Point(188, 153);
            this.cbG2PSBand1.Name = "cbG2PSBand1";
            this.cbG2PSBand1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbG2PSBand1.Properties.Appearance.Options.UseBackColor = true;
            this.cbG2PSBand1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbG2PSBand1.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbG2PSBand1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbG2PSBand1.Size = new System.Drawing.Size(57, 20);
            this.cbG2PSBand1.TabIndex = 31;
            // 
            // lblG2P2Band
            // 
            this.lblG2P2Band.Enabled = false;
            this.lblG2P2Band.Location = new System.Drawing.Point(136, 156);
            this.lblG2P2Band.Name = "lblG2P2Band";
            this.lblG2P2Band.Size = new System.Drawing.Size(24, 13);
            this.lblG2P2Band.TabIndex = 30;
            this.lblG2P2Band.Text = "Band";
            // 
            // lblG2P1Line
            // 
            this.lblG2P1Line.Enabled = false;
            this.lblG2P1Line.Location = new System.Drawing.Point(138, 102);
            this.lblG2P1Line.Name = "lblG2P1Line";
            this.lblG2P1Line.Size = new System.Drawing.Size(50, 13);
            this.lblG2P1Line.TabIndex = 29;
            this.lblG2P1Line.Text = "Resolution";
            // 
            // cbG2PSLines
            // 
            this.cbG2PSLines.EditValue = "800";
            this.cbG2PSLines.Enabled = false;
            this.cbG2PSLines.Location = new System.Drawing.Point(188, 99);
            this.cbG2PSLines.Name = "cbG2PSLines";
            this.cbG2PSLines.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbG2PSLines.Properties.Appearance.Options.UseBackColor = true;
            this.cbG2PSLines.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbG2PSLines.Properties.Items.AddRange(new object[] {
            "100",
            "200",
            "400",
            "800",
            "1600",
            "3200",
            "6400",
            "12800"});
            this.cbG2PSLines.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbG2PSLines.Size = new System.Drawing.Size(57, 20);
            this.cbG2PSLines.TabIndex = 28;
            // 
            // cbG2PSBand
            // 
            this.cbG2PSBand.EditValue = "1 KHz";
            this.cbG2PSBand.Enabled = false;
            this.cbG2PSBand.Location = new System.Drawing.Point(188, 73);
            this.cbG2PSBand.Name = "cbG2PSBand";
            this.cbG2PSBand.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbG2PSBand.Properties.Appearance.Options.UseBackColor = true;
            this.cbG2PSBand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbG2PSBand.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbG2PSBand.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbG2PSBand.Size = new System.Drawing.Size(57, 20);
            this.cbG2PSBand.TabIndex = 27;
            // 
            // lblG2P1Band
            // 
            this.lblG2P1Band.Enabled = false;
            this.lblG2P1Band.Location = new System.Drawing.Point(138, 76);
            this.lblG2P1Band.Name = "lblG2P1Band";
            this.lblG2P1Band.Size = new System.Drawing.Size(24, 13);
            this.lblG2P1Band.TabIndex = 26;
            this.lblG2P1Band.Text = "Band";
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label126.Location = new System.Drawing.Point(7, 24);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(52, 13);
            this.label126.TabIndex = 25;
            this.label126.Text = "Group 1";
            // 
            // chkbxG1P1
            // 
            this.chkbxG1P1.AutoSize = true;
            this.chkbxG1P1.Checked = true;
            this.chkbxG1P1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbxG1P1.Enabled = false;
            this.chkbxG1P1.Location = new System.Drawing.Point(10, 48);
            this.chkbxG1P1.Name = "chkbxG1P1";
            this.chkbxG1P1.Size = new System.Drawing.Size(65, 17);
            this.chkbxG1P1.TabIndex = 24;
            this.chkbxG1P1.Text = "Power 1";
            this.chkbxG1P1.UseVisualStyleBackColor = true;
            // 
            // cbMultipleBand
            // 
            this.cbMultipleBand.Location = new System.Drawing.Point(8, 127);
            this.cbMultipleBand.Name = "cbMultipleBand";
            this.cbMultipleBand.Properties.Caption = "Power 2";
            this.cbMultipleBand.Size = new System.Drawing.Size(87, 19);
            this.cbMultipleBand.TabIndex = 23;
            this.cbMultipleBand.CheckedChanged += new System.EventHandler(this.cbMultipleBand_CheckedChanged);
            // 
            // lblPowerLine1
            // 
            this.lblPowerLine1.Enabled = false;
            this.lblPowerLine1.Location = new System.Drawing.Point(10, 181);
            this.lblPowerLine1.Name = "lblPowerLine1";
            this.lblPowerLine1.Size = new System.Drawing.Size(50, 13);
            this.lblPowerLine1.TabIndex = 22;
            this.lblPowerLine1.Text = "Resolution";
            // 
            // cbPSLines1
            // 
            this.cbPSLines1.EditValue = "800";
            this.cbPSLines1.Enabled = false;
            this.cbPSLines1.Location = new System.Drawing.Point(65, 178);
            this.cbPSLines1.Name = "cbPSLines1";
            this.cbPSLines1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbPSLines1.Properties.Appearance.Options.UseBackColor = true;
            this.cbPSLines1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPSLines1.Properties.Items.AddRange(new object[] {
            "100",
            "200",
            "400",
            "800",
            "1600",
            "3200",
            "6400",
            "12800"});
            this.cbPSLines1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPSLines1.Size = new System.Drawing.Size(57, 20);
            this.cbPSLines1.TabIndex = 21;
            // 
            // cbPSBand1
            // 
            this.cbPSBand1.EditValue = "1 KHz";
            this.cbPSBand1.Enabled = false;
            this.cbPSBand1.Location = new System.Drawing.Point(65, 152);
            this.cbPSBand1.Name = "cbPSBand1";
            this.cbPSBand1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbPSBand1.Properties.Appearance.Options.UseBackColor = true;
            this.cbPSBand1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPSBand1.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbPSBand1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPSBand1.Size = new System.Drawing.Size(57, 20);
            this.cbPSBand1.TabIndex = 20;
            // 
            // lblPowerBand1
            // 
            this.lblPowerBand1.Enabled = false;
            this.lblPowerBand1.Location = new System.Drawing.Point(10, 155);
            this.lblPowerBand1.Name = "lblPowerBand1";
            this.lblPowerBand1.Size = new System.Drawing.Size(24, 13);
            this.lblPowerBand1.TabIndex = 19;
            this.lblPowerBand1.Text = "Band";
            // 
            // txtPSZoom
            // 
            this.txtPSZoom.Location = new System.Drawing.Point(231, 250);
            this.txtPSZoom.Name = "txtPSZoom";
            this.txtPSZoom.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtPSZoom.Properties.Appearance.Options.UseBackColor = true;
            this.txtPSZoom.Properties.MaxLength = 8;
            this.txtPSZoom.Size = new System.Drawing.Size(39, 20);
            this.txtPSZoom.TabIndex = 18;
            // 
            // cbZoom
            // 
            this.cbZoom.Location = new System.Drawing.Point(177, 250);
            this.cbZoom.Name = "cbZoom";
            this.cbZoom.Properties.Caption = "Zoom";
            this.cbZoom.Size = new System.Drawing.Size(53, 19);
            this.cbZoom.TabIndex = 17;
            this.cbZoom.CheckedChanged += new System.EventHandler(this.cbZoom_CheckedChanged);
            // 
            // cbPSOverlap
            // 
            this.cbPSOverlap.EditValue = "0%";
            this.cbPSOverlap.Location = new System.Drawing.Point(225, 224);
            this.cbPSOverlap.Name = "cbPSOverlap";
            this.cbPSOverlap.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbPSOverlap.Properties.Appearance.Options.UseBackColor = true;
            this.cbPSOverlap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPSOverlap.Properties.Items.AddRange(new object[] {
            "0%",
            "25%",
            "50%",
            "75%",
            "Max"});
            this.cbPSOverlap.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPSOverlap.Size = new System.Drawing.Size(90, 20);
            this.cbPSOverlap.TabIndex = 16;
            // 
            // lblPSOverlap
            // 
            this.lblPSOverlap.Location = new System.Drawing.Point(177, 227);
            this.lblPSOverlap.Name = "lblPSOverlap";
            this.lblPSOverlap.Size = new System.Drawing.Size(38, 13);
            this.lblPSOverlap.TabIndex = 15;
            this.lblPSOverlap.Text = "Overlap";
            // 
            // cbAvgTimes
            // 
            this.cbAvgTimes.EditValue = "3";
            this.cbAvgTimes.Location = new System.Drawing.Point(87, 250);
            this.cbAvgTimes.Name = "cbAvgTimes";
            this.cbAvgTimes.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbAvgTimes.Properties.Appearance.Options.UseBackColor = true;
            this.cbAvgTimes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAvgTimes.Properties.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "10",
            "20",
            "30",
            "50",
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "5000"});
            this.cbAvgTimes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAvgTimes.Size = new System.Drawing.Size(65, 20);
            this.cbAvgTimes.TabIndex = 14;
            // 
            // lblAverageTimes
            // 
            this.lblAverageTimes.Location = new System.Drawing.Point(9, 253);
            this.lblAverageTimes.Name = "lblAverageTimes";
            this.lblAverageTimes.Size = new System.Drawing.Size(61, 13);
            this.lblAverageTimes.TabIndex = 13;
            this.lblAverageTimes.Text = "Average No.";
            // 
            // cbPSWindow
            // 
            this.cbPSWindow.EditValue = "Hanning";
            this.cbPSWindow.Location = new System.Drawing.Point(49, 224);
            this.cbPSWindow.Name = "cbPSWindow";
            this.cbPSWindow.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbPSWindow.Properties.Appearance.Options.UseBackColor = true;
            this.cbPSWindow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPSWindow.Properties.Items.AddRange(new object[] {
            "Rectangular",
            "Hanning",
            "Flattop"});
            this.cbPSWindow.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPSWindow.Size = new System.Drawing.Size(105, 20);
            this.cbPSWindow.TabIndex = 12;
            // 
            // lblWindow
            // 
            this.lblWindow.Location = new System.Drawing.Point(5, 227);
            this.lblWindow.Name = "lblWindow";
            this.lblWindow.Size = new System.Drawing.Size(38, 13);
            this.lblWindow.TabIndex = 11;
            this.lblWindow.Text = "Window";
            // 
            // label87
            // 
            this.label87.Location = new System.Drawing.Point(10, 102);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(50, 13);
            this.label87.TabIndex = 3;
            this.label87.Text = "Resolution";
            // 
            // cbPSLines
            // 
            this.cbPSLines.EditValue = "800";
            this.cbPSLines.Location = new System.Drawing.Point(65, 98);
            this.cbPSLines.Name = "cbPSLines";
            this.cbPSLines.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbPSLines.Properties.Appearance.Options.UseBackColor = true;
            this.cbPSLines.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPSLines.Properties.Items.AddRange(new object[] {
            "100",
            "200",
            "400",
            "800",
            "1600",
            "3200",
            "6400",
            "12800"});
            this.cbPSLines.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPSLines.Size = new System.Drawing.Size(57, 20);
            this.cbPSLines.TabIndex = 2;
            // 
            // cbPSBand
            // 
            this.cbPSBand.EditValue = "1 KHz";
            this.cbPSBand.Location = new System.Drawing.Point(65, 72);
            this.cbPSBand.Name = "cbPSBand";
            this.cbPSBand.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbPSBand.Properties.Appearance.Options.UseBackColor = true;
            this.cbPSBand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPSBand.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbPSBand.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPSBand.Size = new System.Drawing.Size(57, 20);
            this.cbPSBand.TabIndex = 1;
            // 
            // label88
            // 
            this.label88.Location = new System.Drawing.Point(10, 76);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(24, 13);
            this.label88.TabIndex = 0;
            this.label88.Text = "Band";
            // 
            // gbDemodulate
            // 
            this.gbDemodulate.Controls.Add(this.cbFilter);
            this.gbDemodulate.Controls.Add(this.lblFilter);
            this.gbDemodulate.Controls.Add(this.cmbdmAvgTimes);
            this.gbDemodulate.Controls.Add(this.label81);
            this.gbDemodulate.Controls.Add(this.cmbdmWindow);
            this.gbDemodulate.Controls.Add(this.label84);
            this.gbDemodulate.Controls.Add(this.label85);
            this.gbDemodulate.Controls.Add(this.cmbdmLines);
            this.gbDemodulate.Controls.Add(this.cbDMBand);
            this.gbDemodulate.Controls.Add(this.label86);
            this.gbDemodulate.Location = new System.Drawing.Point(421, 105);
            this.gbDemodulate.Name = "gbDemodulate";
            this.gbDemodulate.Size = new System.Drawing.Size(390, 93);
            this.gbDemodulate.TabIndex = 21;
            this.gbDemodulate.Text = "Demodulate";
            // 
            // cbFilter
            // 
            this.cbFilter.EditValue = "500 Hz ~ 2K Hz";
            this.cbFilter.Location = new System.Drawing.Point(279, 55);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.Properties.Appearance.Options.UseBackColor = true;
            this.cbFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbFilter.Properties.Items.AddRange(new object[] {
            "500 Hz ~ 2K Hz",
            "1k Hz ~ 2.5K Hz",
            "2K Hz ~ 5K Hz",
            "5K Hz ~ 10K Hz",
            "10K Hz HP"});
            this.cbFilter.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbFilter.Size = new System.Drawing.Size(105, 20);
            this.cbFilter.TabIndex = 16;
            // 
            // lblFilter
            // 
            this.lblFilter.Location = new System.Drawing.Point(231, 58);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(24, 13);
            this.lblFilter.TabIndex = 15;
            this.lblFilter.Text = "Filter";
            // 
            // cmbdmAvgTimes
            // 
            this.cmbdmAvgTimes.EditValue = "3";
            this.cmbdmAvgTimes.Location = new System.Drawing.Point(87, 55);
            this.cmbdmAvgTimes.Name = "cmbdmAvgTimes";
            this.cmbdmAvgTimes.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbdmAvgTimes.Properties.Appearance.Options.UseBackColor = true;
            this.cmbdmAvgTimes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbdmAvgTimes.Properties.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "10",
            "20",
            "30",
            "50",
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "5000"});
            this.cmbdmAvgTimes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbdmAvgTimes.Size = new System.Drawing.Size(72, 20);
            this.cmbdmAvgTimes.TabIndex = 14;
            // 
            // label81
            // 
            this.label81.Location = new System.Drawing.Point(9, 58);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(61, 13);
            this.label81.TabIndex = 13;
            this.label81.Text = "Average No.";
            // 
            // cmbdmWindow
            // 
            this.cmbdmWindow.EditValue = "Rectangular";
            this.cmbdmWindow.Location = new System.Drawing.Point(279, 23);
            this.cmbdmWindow.Name = "cmbdmWindow";
            this.cmbdmWindow.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbdmWindow.Properties.Appearance.Options.UseBackColor = true;
            this.cmbdmWindow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbdmWindow.Properties.Items.AddRange(new object[] {
            "Rectangular",
            "Hanning",
            "FlatTop"});
            this.cmbdmWindow.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbdmWindow.Size = new System.Drawing.Size(105, 20);
            this.cmbdmWindow.TabIndex = 12;
            // 
            // label84
            // 
            this.label84.Location = new System.Drawing.Point(229, 26);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(38, 13);
            this.label84.TabIndex = 11;
            this.label84.Text = "Window";
            // 
            // label85
            // 
            this.label85.Location = new System.Drawing.Point(108, 26);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(50, 13);
            this.label85.TabIndex = 3;
            this.label85.Text = "Resolution";
            // 
            // cmbdmLines
            // 
            this.cmbdmLines.EditValue = "800";
            this.cmbdmLines.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmbdmLines.Location = new System.Drawing.Point(164, 23);
            this.cmbdmLines.Name = "cmbdmLines";
            this.cmbdmLines.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbdmLines.Properties.Appearance.Options.UseBackColor = true;
            this.cmbdmLines.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbdmLines.Properties.Items.AddRange(new object[] {
            "100",
            "200",
            "400",
            "800",
            "1600",
            "3200",
            "6400",
            "12800"});
            this.cmbdmLines.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbdmLines.Size = new System.Drawing.Size(57, 20);
            this.cmbdmLines.TabIndex = 2;
            // 
            // cbDMBand
            // 
            this.cbDMBand.EditValue = "1K Hz";
            this.cbDMBand.Location = new System.Drawing.Point(43, 23);
            this.cbDMBand.Name = "cbDMBand";
            this.cbDMBand.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbDMBand.Properties.Appearance.Options.UseBackColor = true;
            this.cbDMBand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDMBand.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1K Hz",
            "2K Hz",
            "5K Hz",
            "10K Hz",
            "20K Hz",
            "40K Hz"});
            this.cbDMBand.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbDMBand.Size = new System.Drawing.Size(57, 20);
            this.cbDMBand.TabIndex = 1;
            // 
            // label86
            // 
            this.label86.Location = new System.Drawing.Point(9, 26);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(24, 13);
            this.label86.TabIndex = 0;
            this.label86.Text = "Band";
            // 
            // gbCepstrum
            // 
            this.gbCepstrum.Controls.Add(this.txtCepZoom);
            this.gbCepstrum.Controls.Add(this.chkCepZoom);
            this.gbCepstrum.Controls.Add(this.cbCepOverlap);
            this.gbCepstrum.Controls.Add(this.labelControl14);
            this.gbCepstrum.Controls.Add(this.cbCepAvgTime);
            this.gbCepstrum.Controls.Add(this.labelControl15);
            this.gbCepstrum.Controls.Add(this.cbCepWind);
            this.gbCepstrum.Controls.Add(this.labelControl16);
            this.gbCepstrum.Controls.Add(this.labelControl17);
            this.gbCepstrum.Controls.Add(this.cbCepLine);
            this.gbCepstrum.Controls.Add(this.cbCepBand);
            this.gbCepstrum.Controls.Add(this.labelControl18);
            this.gbCepstrum.Location = new System.Drawing.Point(421, 3);
            this.gbCepstrum.Name = "gbCepstrum";
            this.gbCepstrum.Size = new System.Drawing.Size(390, 96);
            this.gbCepstrum.TabIndex = 20;
            this.gbCepstrum.Text = "Cepstrum";
            // 
            // txtCepZoom
            // 
            this.txtCepZoom.Location = new System.Drawing.Point(345, 53);
            this.txtCepZoom.Name = "txtCepZoom";
            this.txtCepZoom.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtCepZoom.Properties.Appearance.Options.UseBackColor = true;
            this.txtCepZoom.Properties.MaxLength = 8;
            this.txtCepZoom.Size = new System.Drawing.Size(39, 20);
            this.txtCepZoom.TabIndex = 22;
            // 
            // chkCepZoom
            // 
            this.chkCepZoom.Location = new System.Drawing.Point(291, 53);
            this.chkCepZoom.Name = "chkCepZoom";
            this.chkCepZoom.Properties.Caption = "Zoom";
            this.chkCepZoom.Size = new System.Drawing.Size(53, 19);
            this.chkCepZoom.TabIndex = 21;
            this.chkCepZoom.CheckedChanged += new System.EventHandler(this.chkCepZoom_CheckedChanged);
            // 
            // cbCepOverlap
            // 
            this.cbCepOverlap.EditValue = "0%";
            this.cbCepOverlap.Location = new System.Drawing.Point(215, 55);
            this.cbCepOverlap.Name = "cbCepOverlap";
            this.cbCepOverlap.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbCepOverlap.Properties.Appearance.Options.UseBackColor = true;
            this.cbCepOverlap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCepOverlap.Properties.Items.AddRange(new object[] {
            "0%",
            "25%",
            "50%",
            "75%",
            "Max"});
            this.cbCepOverlap.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbCepOverlap.Size = new System.Drawing.Size(66, 20);
            this.cbCepOverlap.TabIndex = 20;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(165, 58);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(38, 13);
            this.labelControl14.TabIndex = 19;
            this.labelControl14.Text = "Overlap";
            // 
            // cbCepAvgTime
            // 
            this.cbCepAvgTime.EditValue = "3";
            this.cbCepAvgTime.Location = new System.Drawing.Point(87, 55);
            this.cbCepAvgTime.Name = "cbCepAvgTime";
            this.cbCepAvgTime.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbCepAvgTime.Properties.Appearance.Options.UseBackColor = true;
            this.cbCepAvgTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCepAvgTime.Properties.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "10",
            "20",
            "30",
            "50",
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "5000"});
            this.cbCepAvgTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbCepAvgTime.Size = new System.Drawing.Size(67, 20);
            this.cbCepAvgTime.TabIndex = 14;
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(9, 58);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(61, 13);
            this.labelControl15.TabIndex = 13;
            this.labelControl15.Text = "Average No.";
            // 
            // cbCepWind
            // 
            this.cbCepWind.EditValue = "Rectangular";
            this.cbCepWind.Location = new System.Drawing.Point(279, 23);
            this.cbCepWind.Name = "cbCepWind";
            this.cbCepWind.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbCepWind.Properties.Appearance.Options.UseBackColor = true;
            this.cbCepWind.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCepWind.Properties.Items.AddRange(new object[] {
            "Rectangular",
            "Hanning",
            "FlatTop"});
            this.cbCepWind.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbCepWind.Size = new System.Drawing.Size(105, 20);
            this.cbCepWind.TabIndex = 12;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(229, 26);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(38, 13);
            this.labelControl16.TabIndex = 11;
            this.labelControl16.Text = "Window";
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(108, 26);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(50, 13);
            this.labelControl17.TabIndex = 3;
            this.labelControl17.Text = "Resolution";
            // 
            // cbCepLine
            // 
            this.cbCepLine.EditValue = "2048";
            this.cbCepLine.Location = new System.Drawing.Point(162, 23);
            this.cbCepLine.Name = "cbCepLine";
            this.cbCepLine.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbCepLine.Properties.Appearance.Options.UseBackColor = true;
            this.cbCepLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCepLine.Properties.Items.AddRange(new object[] {
            "256",
            "512",
            "1024",
            "2048",
            "4096",
            "8192",
            "16384",
            "32768"});
            this.cbCepLine.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbCepLine.Size = new System.Drawing.Size(57, 20);
            this.cbCepLine.TabIndex = 2;
            // 
            // cbCepBand
            // 
            this.cbCepBand.EditValue = "1 KHz";
            this.cbCepBand.Location = new System.Drawing.Point(43, 23);
            this.cbCepBand.Name = "cbCepBand";
            this.cbCepBand.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbCepBand.Properties.Appearance.Options.UseBackColor = true;
            this.cbCepBand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCepBand.Properties.Items.AddRange(new object[] {
            "50 Hz",
            "100 Hz",
            "200 Hz",
            "500 Hz",
            "1 KHz",
            "2 KHz",
            "5 KHz",
            "10 KHz",
            "20 KHz",
            "40 KHz"});
            this.cbCepBand.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbCepBand.Size = new System.Drawing.Size(57, 20);
            this.cbCepBand.TabIndex = 1;
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(9, 26);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(24, 13);
            this.labelControl18.TabIndex = 0;
            this.labelControl18.Text = "Band";
            // 
            // xtraTPB3
            // 
            this.xtraTPB3.Controls.Add(this.panelControl2);
            this.xtraTPB3.Name = "xtraTPB3";
            this.xtraTPB3.Size = new System.Drawing.Size(901, 499);
            this.xtraTPB3.Text = "Units";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.xtraScB3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(901, 499);
            this.panelControl2.TabIndex = 1;
            // 
            // xtraScB3
            // 
            this.xtraScB3.Controls.Add(this.gbMeasure);
            this.xtraScB3.Controls.Add(this.gbUnitDetection);
            this.xtraScB3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScB3.Location = new System.Drawing.Point(2, 2);
            this.xtraScB3.Name = "xtraScB3";
            this.xtraScB3.Size = new System.Drawing.Size(897, 495);
            this.xtraScB3.TabIndex = 0;
            // 
            // gbMeasure
            // 
            this.gbMeasure.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.gbMeasure.Appearance.ForeColor = System.Drawing.Color.Black;
            this.gbMeasure.Appearance.Options.UseBackColor = true;
            this.gbMeasure.Appearance.Options.UseForeColor = true;
            this.gbMeasure.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gbMeasure.Controls.Add(this.lblCepstrum);
            this.gbMeasure.Controls.Add(this.cbCepstrum);
            this.gbMeasure.Controls.Add(this.lblOrderTrace);
            this.gbMeasure.Controls.Add(this.cbOrderTrace);
            this.gbMeasure.Controls.Add(this.lblDemodulate);
            this.gbMeasure.Controls.Add(this.cbDemodulate);
            this.gbMeasure.Controls.Add(this.lblSpectrum);
            this.gbMeasure.Controls.Add(this.cbSpectrum);
            this.gbMeasure.Controls.Add(this.cbTime);
            this.gbMeasure.Controls.Add(this.lblTime);
            this.gbMeasure.Location = new System.Drawing.Point(9, 274);
            this.gbMeasure.Name = "gbMeasure";
            this.gbMeasure.Size = new System.Drawing.Size(402, 157);
            this.gbMeasure.TabIndex = 11;
            this.gbMeasure.Text = "Measure";
            // 
            // lblCepstrum
            // 
            this.lblCepstrum.Location = new System.Drawing.Point(9, 135);
            this.lblCepstrum.Name = "lblCepstrum";
            this.lblCepstrum.Size = new System.Drawing.Size(46, 13);
            this.lblCepstrum.TabIndex = 9;
            this.lblCepstrum.Text = "Cepstrum";
            // 
            // cbCepstrum
            // 
            this.cbCepstrum.EditValue = "Acceleration";
            this.cbCepstrum.Location = new System.Drawing.Point(132, 132);
            this.cbCepstrum.Name = "cbCepstrum";
            this.cbCepstrum.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbCepstrum.Properties.Appearance.Options.UseBackColor = true;
            this.cbCepstrum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCepstrum.Properties.Items.AddRange(new object[] {
            "Acceleration",
            "Velocity",
            "Displacement",
            "Pressure",
            "Current"});
            this.cbCepstrum.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbCepstrum.Size = new System.Drawing.Size(135, 20);
            this.cbCepstrum.TabIndex = 8;
            // 
            // lblOrderTrace
            // 
            this.lblOrderTrace.Location = new System.Drawing.Point(9, 109);
            this.lblOrderTrace.Name = "lblOrderTrace";
            this.lblOrderTrace.Size = new System.Drawing.Size(82, 13);
            this.lblOrderTrace.TabIndex = 7;
            this.lblOrderTrace.Text = "Amplitude & Phase";
            // 
            // cbOrderTrace
            // 
            this.cbOrderTrace.EditValue = "Acceleration";
            this.cbOrderTrace.Location = new System.Drawing.Point(132, 106);
            this.cbOrderTrace.Name = "cbOrderTrace";
            this.cbOrderTrace.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbOrderTrace.Properties.Appearance.Options.UseBackColor = true;
            this.cbOrderTrace.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbOrderTrace.Properties.Items.AddRange(new object[] {
            "Acceleration",
            "Velocity",
            "Displacement",
            "Pressure",
            "Current"});
            this.cbOrderTrace.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbOrderTrace.Size = new System.Drawing.Size(135, 20);
            this.cbOrderTrace.TabIndex = 6;
            // 
            // lblDemodulate
            // 
            this.lblDemodulate.Location = new System.Drawing.Point(9, 83);
            this.lblDemodulate.Name = "lblDemodulate";
            this.lblDemodulate.Size = new System.Drawing.Size(105, 13);
            this.lblDemodulate.TabIndex = 5;
            this.lblDemodulate.Text = "Demodulate Spectrum";
            // 
            // cbDemodulate
            // 
            this.cbDemodulate.EditValue = "Acceleration";
            this.cbDemodulate.Location = new System.Drawing.Point(132, 80);
            this.cbDemodulate.Name = "cbDemodulate";
            this.cbDemodulate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbDemodulate.Properties.Appearance.Options.UseBackColor = true;
            this.cbDemodulate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDemodulate.Properties.Items.AddRange(new object[] {
            "Acceleration",
            "Velocity",
            "Displacement",
            "Pressure",
            "Current"});
            this.cbDemodulate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbDemodulate.Size = new System.Drawing.Size(135, 20);
            this.cbDemodulate.TabIndex = 4;
            // 
            // lblSpectrum
            // 
            this.lblSpectrum.Location = new System.Drawing.Point(9, 56);
            this.lblSpectrum.Name = "lblSpectrum";
            this.lblSpectrum.Size = new System.Drawing.Size(78, 13);
            this.lblSpectrum.TabIndex = 3;
            this.lblSpectrum.Text = "Power Spectrum";
            // 
            // cbSpectrum
            // 
            this.cbSpectrum.EditValue = "Acceleration";
            this.cbSpectrum.Location = new System.Drawing.Point(132, 53);
            this.cbSpectrum.Name = "cbSpectrum";
            this.cbSpectrum.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbSpectrum.Properties.Appearance.Options.UseBackColor = true;
            this.cbSpectrum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSpectrum.Properties.Items.AddRange(new object[] {
            "Acceleration",
            "Velocity",
            "Displacement",
            "Pressure",
            "Current"});
            this.cbSpectrum.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbSpectrum.Size = new System.Drawing.Size(135, 20);
            this.cbSpectrum.TabIndex = 2;
            // 
            // cbTime
            // 
            this.cbTime.EditValue = "Acceleration";
            this.cbTime.Location = new System.Drawing.Point(132, 26);
            this.cbTime.Name = "cbTime";
            this.cbTime.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbTime.Properties.Appearance.Options.UseBackColor = true;
            this.cbTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTime.Properties.Items.AddRange(new object[] {
            "Acceleration",
            "Velocity",
            "Displacement",
            "Pressure",
            "Current"});
            this.cbTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbTime.Size = new System.Drawing.Size(135, 20);
            this.cbTime.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(9, 29);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(75, 13);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Time Waveform";
            // 
            // gbUnitDetection
            // 
            this.gbUnitDetection.Controls.Add(this.cbCurrentUnit);
            this.gbUnitDetection.Controls.Add(this.lblCurrent);
            this.gbUnitDetection.Controls.Add(this.cbCurrent);
            this.gbUnitDetection.Controls.Add(this.cbPressureUnit);
            this.gbUnitDetection.Controls.Add(this.lblPressure);
            this.gbUnitDetection.Controls.Add(this.cbPressure);
            this.gbUnitDetection.Controls.Add(this.cbDispUnit);
            this.gbUnitDetection.Controls.Add(this.cbVelUnit);
            this.gbUnitDetection.Controls.Add(this.cbAccUnit);
            this.gbUnitDetection.Controls.Add(this.txtProcess);
            this.gbUnitDetection.Controls.Add(this.lblProcess);
            this.gbUnitDetection.Controls.Add(this.cbTemp);
            this.gbUnitDetection.Controls.Add(this.lblTemprature);
            this.gbUnitDetection.Controls.Add(this.lblDisp);
            this.gbUnitDetection.Controls.Add(this.cbDisp);
            this.gbUnitDetection.Controls.Add(this.lblVel);
            this.gbUnitDetection.Controls.Add(this.cbVel);
            this.gbUnitDetection.Controls.Add(this.cbAcc);
            this.gbUnitDetection.Controls.Add(this.lblAcc);
            this.gbUnitDetection.Location = new System.Drawing.Point(9, 5);
            this.gbUnitDetection.Name = "gbUnitDetection";
            this.gbUnitDetection.Size = new System.Drawing.Size(402, 263);
            this.gbUnitDetection.TabIndex = 10;
            this.gbUnitDetection.Text = "Unit/Detection";
            // 
            // cbCurrentUnit
            // 
            this.cbCurrentUnit.EditValue = "Peak";
            this.cbCurrentUnit.Location = new System.Drawing.Point(192, 190);
            this.cbCurrentUnit.Name = "cbCurrentUnit";
            this.cbCurrentUnit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbCurrentUnit.Properties.Appearance.Options.UseBackColor = true;
            this.cbCurrentUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCurrentUnit.Properties.Items.AddRange(new object[] {
            "RMS",
            "Peak",
            "P-P",
            "True-PK"});
            this.cbCurrentUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbCurrentUnit.Size = new System.Drawing.Size(87, 20);
            this.cbCurrentUnit.TabIndex = 18;
            // 
            // lblCurrent
            // 
            this.lblCurrent.Location = new System.Drawing.Point(6, 193);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(37, 13);
            this.lblCurrent.TabIndex = 17;
            this.lblCurrent.Text = "Current";
            // 
            // cbCurrent
            // 
            this.cbCurrent.EditValue = "mA";
            this.cbCurrent.Location = new System.Drawing.Point(81, 190);
            this.cbCurrent.Name = "cbCurrent";
            this.cbCurrent.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbCurrent.Properties.Appearance.Options.UseBackColor = true;
            this.cbCurrent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCurrent.Properties.Items.AddRange(new object[] {
            "mA"});
            this.cbCurrent.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbCurrent.Size = new System.Drawing.Size(87, 20);
            this.cbCurrent.TabIndex = 16;
            // 
            // cbPressureUnit
            // 
            this.cbPressureUnit.EditValue = "Peak";
            this.cbPressureUnit.Location = new System.Drawing.Point(192, 164);
            this.cbPressureUnit.Name = "cbPressureUnit";
            this.cbPressureUnit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbPressureUnit.Properties.Appearance.Options.UseBackColor = true;
            this.cbPressureUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPressureUnit.Properties.Items.AddRange(new object[] {
            "RMS",
            "Peak",
            "P-P",
            "True-PK"});
            this.cbPressureUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPressureUnit.Size = new System.Drawing.Size(87, 20);
            this.cbPressureUnit.TabIndex = 15;
            // 
            // lblPressure
            // 
            this.lblPressure.Location = new System.Drawing.Point(6, 167);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(42, 13);
            this.lblPressure.TabIndex = 14;
            this.lblPressure.Text = "Pressure";
            // 
            // cbPressure
            // 
            this.cbPressure.EditValue = "Pa";
            this.cbPressure.Location = new System.Drawing.Point(81, 164);
            this.cbPressure.Name = "cbPressure";
            this.cbPressure.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbPressure.Properties.Appearance.Options.UseBackColor = true;
            this.cbPressure.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPressure.Properties.Items.AddRange(new object[] {
            "Pa",
            "bar"});
            this.cbPressure.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPressure.Size = new System.Drawing.Size(87, 20);
            this.cbPressure.TabIndex = 13;
            // 
            // cbDispUnit
            // 
            this.cbDispUnit.EditValue = "P-P";
            this.cbDispUnit.Location = new System.Drawing.Point(192, 84);
            this.cbDispUnit.Name = "cbDispUnit";
            this.cbDispUnit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbDispUnit.Properties.Appearance.Options.UseBackColor = true;
            this.cbDispUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDispUnit.Properties.Items.AddRange(new object[] {
            "RMS",
            "Peak",
            "P-P",
            "True-PK"});
            this.cbDispUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbDispUnit.Size = new System.Drawing.Size(87, 20);
            this.cbDispUnit.TabIndex = 12;
            // 
            // cbVelUnit
            // 
            this.cbVelUnit.EditValue = "RMS";
            this.cbVelUnit.Location = new System.Drawing.Point(192, 57);
            this.cbVelUnit.Name = "cbVelUnit";
            this.cbVelUnit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbVelUnit.Properties.Appearance.Options.UseBackColor = true;
            this.cbVelUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbVelUnit.Properties.Items.AddRange(new object[] {
            "RMS",
            "Peak",
            "P-P",
            "True-PK"});
            this.cbVelUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbVelUnit.Size = new System.Drawing.Size(87, 20);
            this.cbVelUnit.TabIndex = 11;
            // 
            // cbAccUnit
            // 
            this.cbAccUnit.EditValue = "Peak";
            this.cbAccUnit.Location = new System.Drawing.Point(192, 30);
            this.cbAccUnit.Name = "cbAccUnit";
            this.cbAccUnit.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbAccUnit.Properties.Appearance.Options.UseBackColor = true;
            this.cbAccUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAccUnit.Properties.Items.AddRange(new object[] {
            "RMS",
            "Peak",
            "P-P",
            "True-PK"});
            this.cbAccUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAccUnit.Size = new System.Drawing.Size(87, 20);
            this.cbAccUnit.TabIndex = 10;
            // 
            // txtProcess
            // 
            this.txtProcess.EditValue = "";
            this.txtProcess.Location = new System.Drawing.Point(81, 138);
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtProcess.Properties.Appearance.Options.UseBackColor = true;
            this.txtProcess.Properties.MaxLength = 31;
            this.txtProcess.Size = new System.Drawing.Size(87, 20);
            this.txtProcess.TabIndex = 9;
            // 
            // lblProcess
            // 
            this.lblProcess.Location = new System.Drawing.Point(6, 141);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(37, 13);
            this.lblProcess.TabIndex = 8;
            this.lblProcess.Text = "Process";
            // 
            // cbTemp
            // 
            this.cbTemp.EditValue = "*C";
            this.cbTemp.Location = new System.Drawing.Point(81, 111);
            this.cbTemp.Name = "cbTemp";
            this.cbTemp.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbTemp.Properties.Appearance.Options.UseBackColor = true;
            this.cbTemp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTemp.Properties.Items.AddRange(new object[] {
            "*C",
            "*F"});
            this.cbTemp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbTemp.Size = new System.Drawing.Size(87, 20);
            this.cbTemp.TabIndex = 7;
            // 
            // lblTemprature
            // 
            this.lblTemprature.Location = new System.Drawing.Point(6, 114);
            this.lblTemprature.Name = "lblTemprature";
            this.lblTemprature.Size = new System.Drawing.Size(62, 13);
            this.lblTemprature.TabIndex = 6;
            this.lblTemprature.Text = "Temperature";
            // 
            // lblDisp
            // 
            this.lblDisp.Location = new System.Drawing.Point(6, 87);
            this.lblDisp.Name = "lblDisp";
            this.lblDisp.Size = new System.Drawing.Size(63, 13);
            this.lblDisp.TabIndex = 5;
            this.lblDisp.Text = "Displacement";
            // 
            // cbDisp
            // 
            this.cbDisp.EditValue = "um";
            this.cbDisp.Location = new System.Drawing.Point(81, 84);
            this.cbDisp.Name = "cbDisp";
            this.cbDisp.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbDisp.Properties.Appearance.Options.UseBackColor = true;
            this.cbDisp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDisp.Properties.Items.AddRange(new object[] {
            "mil",
            "um"});
            this.cbDisp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbDisp.Size = new System.Drawing.Size(87, 20);
            this.cbDisp.TabIndex = 4;
            // 
            // lblVel
            // 
            this.lblVel.Location = new System.Drawing.Point(6, 60);
            this.lblVel.Name = "lblVel";
            this.lblVel.Size = new System.Drawing.Size(37, 13);
            this.lblVel.TabIndex = 3;
            this.lblVel.Text = "Velocity";
            // 
            // cbVel
            // 
            this.cbVel.EditValue = "mm/s";
            this.cbVel.Location = new System.Drawing.Point(81, 57);
            this.cbVel.Name = "cbVel";
            this.cbVel.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbVel.Properties.Appearance.Options.UseBackColor = true;
            this.cbVel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbVel.Properties.Items.AddRange(new object[] {
            "mm/s",
            "in/s",
            "cm/s"});
            this.cbVel.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbVel.Size = new System.Drawing.Size(87, 20);
            this.cbVel.TabIndex = 2;
            // 
            // cbAcc
            // 
            this.cbAcc.EditValue = "Gs";
            this.cbAcc.Location = new System.Drawing.Point(81, 30);
            this.cbAcc.Name = "cbAcc";
            this.cbAcc.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cbAcc.Properties.Appearance.Options.UseBackColor = true;
            this.cbAcc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAcc.Properties.Items.AddRange(new object[] {
            "Gs",
            "gal",
            "m/s2"});
            this.cbAcc.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAcc.Size = new System.Drawing.Size(87, 20);
            this.cbAcc.TabIndex = 1;
            // 
            // lblAcc
            // 
            this.lblAcc.Location = new System.Drawing.Point(6, 33);
            this.lblAcc.Name = "lblAcc";
            this.lblAcc.Size = new System.Drawing.Size(59, 13);
            this.lblAcc.TabIndex = 0;
            this.lblAcc.Text = "Acceleration";
            // 
            // xtraTPIMXA
            // 
            this.xtraTPIMXA.Controls.Add(this.xtraScrollableControl1);
            this.xtraTPIMXA.Name = "xtraTPIMXA";
            this.xtraTPIMXA.Size = new System.Drawing.Size(901, 499);
            this.xtraTPIMXA.Text = "IMXA460/SKF";
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.panelControl5);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(901, 499);
            this.xtraScrollableControl1.TabIndex = 2;
            // 
            // panelControl5
            // 
            this.panelControl5.Controls.Add(this.xtraSCIMAX);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl5.Location = new System.Drawing.Point(0, 0);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(901, 499);
            this.panelControl5.TabIndex = 1;
            // 
            // xtraSCIMAX
            // 
            this.xtraSCIMAX.Controls.Add(this.grbAlarms);
            this.xtraSCIMAX.Controls.Add(this.cmbUnitsMain);
            this.xtraSCIMAX.Controls.Add(this.gbDI2);
            this.xtraSCIMAX.Controls.Add(this.gbDI1);
            this.xtraSCIMAX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraSCIMAX.FireScrollEventOnMouseWheel = true;
            this.xtraSCIMAX.Location = new System.Drawing.Point(2, 2);
            this.xtraSCIMAX.Name = "xtraSCIMAX";
            this.xtraSCIMAX.Size = new System.Drawing.Size(897, 495);
            this.xtraSCIMAX.TabIndex = 0;
            // 
            // grbAlarms
            // 
            this.grbAlarms.Controls.Add(this.labelControl30);
            this.grbAlarms.Controls.Add(this.cmbAlarmImxa);
            this.grbAlarms.Controls.Add(this.labelControl27);
            this.grbAlarms.Controls.Add(this.cmbbandimxa);
            this.grbAlarms.Location = new System.Drawing.Point(494, 3);
            this.grbAlarms.Name = "grbAlarms";
            this.grbAlarms.Size = new System.Drawing.Size(371, 199);
            this.grbAlarms.TabIndex = 115;
            this.grbAlarms.Text = "General\\Band Alarms";
            // 
            // labelControl30
            // 
            this.labelControl30.Location = new System.Drawing.Point(14, 40);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(72, 13);
            this.labelControl30.TabIndex = 33;
            this.labelControl30.Text = "General Alarms";
            // 
            // cmbAlarmImxa
            // 
            this.cmbAlarmImxa.Location = new System.Drawing.Point(115, 37);
            this.cmbAlarmImxa.Name = "cmbAlarmImxa";
            this.cmbAlarmImxa.Properties.AllowFocused = false;
            this.cmbAlarmImxa.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbAlarmImxa.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAlarmImxa.Properties.Appearance.Options.UseBackColor = true;
            this.cmbAlarmImxa.Properties.Appearance.Options.UseFont = true;
            this.cmbAlarmImxa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAlarmImxa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbAlarmImxa.Size = new System.Drawing.Size(176, 20);
            this.cmbAlarmImxa.TabIndex = 32;
            // 
            // labelControl27
            // 
            this.labelControl27.Location = new System.Drawing.Point(16, 73);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(59, 13);
            this.labelControl27.TabIndex = 17;
            this.labelControl27.Text = "Band Alarms";
            // 
            // cmbbandimxa
            // 
            this.cmbbandimxa.Location = new System.Drawing.Point(115, 70);
            this.cmbbandimxa.Name = "cmbbandimxa";
            this.cmbbandimxa.Properties.AllowFocused = false;
            this.cmbbandimxa.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbbandimxa.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbbandimxa.Properties.Appearance.Options.UseBackColor = true;
            this.cmbbandimxa.Properties.Appearance.Options.UseFont = true;
            this.cmbbandimxa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbbandimxa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbbandimxa.Size = new System.Drawing.Size(176, 20);
            this.cmbbandimxa.TabIndex = 4;
            // 
            // cmbUnitsMain
            // 
            this.cmbUnitsMain.Location = new System.Drawing.Point(95, 11);
            this.cmbUnitsMain.Name = "cmbUnitsMain";
            this.cmbUnitsMain.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbUnitsMain.Properties.Appearance.Options.UseBackColor = true;
            this.cmbUnitsMain.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUnitsMain.Properties.Items.AddRange(new object[] {
            "Accel (G)",
            "Accel to Velocity (IPS)",
            "Accel to Velocity (mm/s)",
            "Accel to Displacement (Mils)",
            "Accel to Displacement (um)",
            "Velocity (IPS)",
            "Velocity (mm/s)",
            "Velocity to Displacement (Mils)",
            "Velocity to Displacement (um)",
            "Displacement(Mils)",
            "Displacement(um)",
            "ESP (G)",
            "Volts (V)",
            "RPM",
            "Temperature [s]",
            "Pressure [s]",
            "Flow [s]",
            "Rotating Speed [s]",
            "Linear Displacement [s]",
            "Count [s]",
            "Count Rate [s]",
            "Voltage [s]",
            "Current [s]",
            "Acceleration (G) [s]",
            "Velocity (IPS) [s]",
            "Velocity (mm/s) [s]",
            "Displacement (Mils) [s]",
            "Displacement (um) [s]"});
            this.cmbUnitsMain.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbUnitsMain.Size = new System.Drawing.Size(385, 20);
            this.cmbUnitsMain.TabIndex = 114;
            this.cmbUnitsMain.SelectedIndexChanged += new System.EventHandler(this.cmbUnitsMain_SelectedIndexChanged);
            // 
            // gbDI2
            // 
            this.gbDI2.Controls.Add(this.label54);
            this.gbDI2.Controls.Add(this.label53);
            this.gbDI2.Controls.Add(this.tbSpecAver);
            this.gbDI2.Controls.Add(this.tbTimeAveg);
            this.gbDI2.Controls.Add(this.label64);
            this.gbDI2.Controls.Add(this.label77);
            this.gbDI2.Controls.Add(this.cmbDirection);
            this.gbDI2.Controls.Add(this.cmbChannelType);
            this.gbDI2.Controls.Add(this.label65);
            this.gbDI2.Controls.Add(this.label76);
            this.gbDI2.Controls.Add(this.cmbCollectionType);
            this.gbDI2.Controls.Add(this.cmbTriggerRange);
            this.gbDI2.Controls.Add(this.cmbMeasureType);
            this.gbDI2.Controls.Add(this.label75);
            this.gbDI2.Controls.Add(this.label66);
            this.gbDI2.Controls.Add(this.tbLevel);
            this.gbDI2.Controls.Add(this.cmbResolution);
            this.gbDI2.Controls.Add(this.label74);
            this.gbDI2.Controls.Add(this.label69);
            this.gbDI2.Controls.Add(this.cmbSlope1);
            this.gbDI2.Controls.Add(this.cmbFrequency);
            this.gbDI2.Controls.Add(this.label73);
            this.gbDI2.Controls.Add(this.label70);
            this.gbDI2.Controls.Add(this.cmbTriggerType);
            this.gbDI2.Controls.Add(this.cmbOrders);
            this.gbDI2.Controls.Add(this.label72);
            this.gbDI2.Controls.Add(this.label71);
            this.gbDI2.Controls.Add(this.tbOverlap);
            this.gbDI2.Location = new System.Drawing.Point(3, 204);
            this.gbDI2.Name = "gbDI2";
            this.gbDI2.ShowCaption = false;
            this.gbDI2.Size = new System.Drawing.Size(485, 330);
            this.gbDI2.TabIndex = 24;
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(21, 165);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(48, 13);
            this.label54.TabIndex = 51;
            this.label54.Text = "Time Avg.";
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(21, 142);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(71, 13);
            this.label53.TabIndex = 50;
            this.label53.Text = "Spectrum Avg.";
            // 
            // tbSpecAver
            // 
            this.tbSpecAver.EditValue = "4";
            this.tbSpecAver.Location = new System.Drawing.Point(109, 140);
            this.tbSpecAver.Name = "tbSpecAver";
            this.tbSpecAver.Properties.MaxLength = 4;
            this.tbSpecAver.Size = new System.Drawing.Size(261, 20);
            this.tbSpecAver.TabIndex = 26;
            this.tbSpecAver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txthigh_KeyPress);
            // 
            // tbTimeAveg
            // 
            this.tbTimeAveg.EditValue = "1";
            this.tbTimeAveg.Location = new System.Drawing.Point(109, 163);
            this.tbTimeAveg.Name = "tbTimeAveg";
            this.tbTimeAveg.Properties.MaxLength = 3;
            this.tbTimeAveg.Size = new System.Drawing.Size(261, 20);
            this.tbTimeAveg.TabIndex = 25;
            this.tbTimeAveg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txthigh_KeyPress);
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(21, 7);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(42, 13);
            this.label64.TabIndex = 27;
            this.label64.Text = "Direction";
            // 
            // label77
            // 
            this.label77.Location = new System.Drawing.Point(21, 304);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(66, 13);
            this.label77.TabIndex = 49;
            this.label77.Text = "Channel Type";
            // 
            // cmbDirection
            // 
            this.cmbDirection.Location = new System.Drawing.Point(109, 5);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDirection.Properties.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical",
            "Other Radial",
            "Axial"});
            this.cmbDirection.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDirection.Size = new System.Drawing.Size(261, 20);
            this.cmbDirection.TabIndex = 26;
            // 
            // cmbChannelType
            // 
            this.cmbChannelType.Location = new System.Drawing.Point(109, 301);
            this.cmbChannelType.Name = "cmbChannelType";
            this.cmbChannelType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbChannelType.Properties.Items.AddRange(new object[] {
            "X - Plane",
            "Y - Plane",
            "Z - Plane",
            "XY - Plane",
            "XZ - Plane",
            "AC",
            "DC"});
            this.cmbChannelType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbChannelType.Size = new System.Drawing.Size(261, 20);
            this.cmbChannelType.TabIndex = 48;
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(21, 30);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(73, 13);
            this.label65.TabIndex = 28;
            this.label65.Text = "Collection Type";
            // 
            // label76
            // 
            this.label76.Location = new System.Drawing.Point(21, 280);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(68, 13);
            this.label76.TabIndex = 47;
            this.label76.Text = "Trigger Range";
            // 
            // cmbCollectionType
            // 
            this.cmbCollectionType.Location = new System.Drawing.Point(109, 27);
            this.cmbCollectionType.Name = "cmbCollectionType";
            this.cmbCollectionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCollectionType.Properties.Items.AddRange(new object[] {
            "Overall Only",
            "Signature and Overall",
            "Signature on alarm",
            "Signature By User",
            "Signature Only"});
            this.cmbCollectionType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbCollectionType.Size = new System.Drawing.Size(261, 20);
            this.cmbCollectionType.TabIndex = 29;
            // 
            // cmbTriggerRange
            // 
            this.cmbTriggerRange.Location = new System.Drawing.Point(109, 277);
            this.cmbTriggerRange.Name = "cmbTriggerRange";
            this.cmbTriggerRange.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTriggerRange.Properties.Items.AddRange(new object[] {
            "10 V",
            "25 V"});
            this.cmbTriggerRange.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTriggerRange.Size = new System.Drawing.Size(261, 20);
            this.cmbTriggerRange.TabIndex = 46;
            // 
            // cmbMeasureType
            // 
            this.cmbMeasureType.Location = new System.Drawing.Point(109, 49);
            this.cmbMeasureType.Name = "cmbMeasureType";
            this.cmbMeasureType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMeasureType.Properties.Items.AddRange(new object[] {
            "Frequency",
            "Frequency and Phase",
            "Time ",
            "Orbit"});
            this.cmbMeasureType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbMeasureType.Size = new System.Drawing.Size(261, 20);
            this.cmbMeasureType.TabIndex = 30;
            this.cmbMeasureType.SelectedIndexChanged += new System.EventHandler(this.cmbMeasureType_SelectedIndexChanged);
            // 
            // label75
            // 
            this.label75.Location = new System.Drawing.Point(21, 256);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(25, 13);
            this.label75.TabIndex = 45;
            this.label75.Text = "Level";
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(21, 53);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(68, 13);
            this.label66.TabIndex = 31;
            this.label66.Text = "Measure Type";
            // 
            // tbLevel
            // 
            this.tbLevel.EditValue = "10";
            this.tbLevel.Location = new System.Drawing.Point(109, 253);
            this.tbLevel.Name = "tbLevel";
            this.tbLevel.Size = new System.Drawing.Size(261, 20);
            this.tbLevel.TabIndex = 44;
            this.tbLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txthigh_KeyPress);
            // 
            // cmbResolution
            // 
            this.cmbResolution.Location = new System.Drawing.Point(109, 72);
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbResolution.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbResolution.Size = new System.Drawing.Size(261, 20);
            this.cmbResolution.TabIndex = 32;
            // 
            // label74
            // 
            this.label74.Location = new System.Drawing.Point(21, 233);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(26, 13);
            this.label74.TabIndex = 43;
            this.label74.Text = "Slope";
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(21, 75);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(50, 13);
            this.label69.TabIndex = 33;
            this.label69.Text = "Resolution";
            // 
            // cmbSlope1
            // 
            this.cmbSlope1.Location = new System.Drawing.Point(109, 230);
            this.cmbSlope1.Name = "cmbSlope1";
            this.cmbSlope1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSlope1.Properties.Items.AddRange(new object[] {
            "Positive",
            "Negative"});
            this.cmbSlope1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbSlope1.Size = new System.Drawing.Size(261, 20);
            this.cmbSlope1.TabIndex = 42;
            // 
            // cmbFrequency
            // 
            this.cmbFrequency.Location = new System.Drawing.Point(109, 94);
            this.cmbFrequency.Name = "cmbFrequency";
            this.cmbFrequency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFrequency.Properties.Items.AddRange(new object[] {
            "100 Hz (6 KCPM)",
            "200 Hz (12 KCPM)",
            "500 Hz (30 KCPM)",
            "1 KHz (60 KCPM)",
            "2 KHz (120 KCPM)",
            "5 KHz (300 KCPM)",
            "10 KHz (600 KCPM)",
            "20 KHz (1200 KCPM)",
            "40 KHz (2400 KCPM)",
            "25 Hz (1.5 KCPM)"});
            this.cmbFrequency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbFrequency.Size = new System.Drawing.Size(261, 20);
            this.cmbFrequency.TabIndex = 34;
            // 
            // label73
            // 
            this.label73.Location = new System.Drawing.Point(21, 210);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(61, 13);
            this.label73.TabIndex = 41;
            this.label73.Text = "Trigger Type";
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(21, 96);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(51, 13);
            this.label70.TabIndex = 35;
            this.label70.Text = "Frequency";
            // 
            // cmbTriggerType
            // 
            this.cmbTriggerType.Location = new System.Drawing.Point(109, 208);
            this.cmbTriggerType.Name = "cmbTriggerType";
            this.cmbTriggerType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTriggerType.Properties.Items.AddRange(new object[] {
            "Free Run",
            "Ext",
            "Ext-TTL"});
            this.cmbTriggerType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTriggerType.Size = new System.Drawing.Size(261, 20);
            this.cmbTriggerType.TabIndex = 40;
            // 
            // cmbOrders
            // 
            this.cmbOrders.Location = new System.Drawing.Point(109, 117);
            this.cmbOrders.Name = "cmbOrders";
            this.cmbOrders.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOrders.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cmbOrders.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbOrders.Size = new System.Drawing.Size(261, 20);
            this.cmbOrders.TabIndex = 36;
            // 
            // label72
            // 
            this.label72.Location = new System.Drawing.Point(21, 188);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(57, 13);
            this.label72.TabIndex = 39;
            this.label72.Text = "Overlap(%)";
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(21, 120);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(33, 13);
            this.label71.TabIndex = 37;
            this.label71.Text = "Orders";
            // 
            // tbOverlap
            // 
            this.tbOverlap.EditValue = "50";
            this.tbOverlap.Location = new System.Drawing.Point(109, 186);
            this.tbOverlap.Name = "tbOverlap";
            this.tbOverlap.Size = new System.Drawing.Size(261, 20);
            this.tbOverlap.TabIndex = 38;
            this.tbOverlap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txthigh_KeyPress);
            // 
            // gbDI1
            // 
            this.gbDI1.Controls.Add(this.label83);
            this.gbDI1.Controls.Add(this.lblType);
            this.gbDI1.Controls.Add(this.cmbCouple);
            this.gbDI1.Controls.Add(this.cmbFullScale);
            this.gbDI1.Controls.Add(this.label57);
            this.gbDI1.Controls.Add(this.label82);
            this.gbDI1.Controls.Add(this.tbSensitivity);
            this.gbDI1.Controls.Add(this.label67);
            this.gbDI1.Controls.Add(this.cmbDetectionType);
            this.gbDI1.Controls.Add(this.cmbFilterValue);
            this.gbDI1.Controls.Add(this.label58);
            this.gbDI1.Controls.Add(this.label63);
            this.gbDI1.Controls.Add(this.cmbWindowType);
            this.gbDI1.Controls.Add(this.cmbFilterType);
            this.gbDI1.Controls.Add(this.label62);
            this.gbDI1.Location = new System.Drawing.Point(3, 3);
            this.gbDI1.Name = "gbDI1";
            this.gbDI1.ShowCaption = false;
            this.gbDI1.Size = new System.Drawing.Size(485, 199);
            this.gbDI1.TabIndex = 23;
            // 
            // label83
            // 
            this.label83.Location = new System.Drawing.Point(11, 40);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(44, 13);
            this.label83.TabIndex = 27;
            this.label83.Text = "Full Scale";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(11, 14);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(24, 13);
            this.lblType.TabIndex = 113;
            this.lblType.Text = "Type";
            // 
            // cmbCouple
            // 
            this.cmbCouple.Location = new System.Drawing.Point(92, 80);
            this.cmbCouple.Name = "cmbCouple";
            this.cmbCouple.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCouple.Properties.Items.AddRange(new object[] {
            "Accelerometer",
            "AC Couple",
            "DC Couple"});
            this.cmbCouple.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbCouple.Size = new System.Drawing.Size(261, 20);
            this.cmbCouple.TabIndex = 14;
            // 
            // cmbFullScale
            // 
            this.cmbFullScale.Location = new System.Drawing.Point(92, 33);
            this.cmbFullScale.Name = "cmbFullScale";
            this.cmbFullScale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFullScale.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbFullScale.Size = new System.Drawing.Size(261, 20);
            this.cmbFullScale.TabIndex = 26;
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(11, 84);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(33, 13);
            this.label57.TabIndex = 15;
            this.label57.Text = "Couple";
            // 
            // label82
            // 
            this.label82.Location = new System.Drawing.Point(11, 61);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(49, 13);
            this.label82.TabIndex = 25;
            this.label82.Text = "Sensitivity";
            // 
            // tbSensitivity
            // 
            this.tbSensitivity.EditValue = "100";
            this.tbSensitivity.Location = new System.Drawing.Point(92, 58);
            this.tbSensitivity.Name = "tbSensitivity";
            this.tbSensitivity.Size = new System.Drawing.Size(261, 20);
            this.tbSensitivity.TabIndex = 16;
            this.tbSensitivity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txthigh_KeyPress);
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(11, 175);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(53, 13);
            this.label67.TabIndex = 24;
            this.label67.Text = "Filter Value";
            // 
            // cmbDetectionType
            // 
            this.cmbDetectionType.Location = new System.Drawing.Point(92, 103);
            this.cmbDetectionType.Name = "cmbDetectionType";
            this.cmbDetectionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDetectionType.Properties.Items.AddRange(new object[] {
            "RMS",
            "Peak",
            "Peak to Peak",
            "True Peak",
            "True Peak to Peak"});
            this.cmbDetectionType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDetectionType.Size = new System.Drawing.Size(261, 20);
            this.cmbDetectionType.TabIndex = 17;
            // 
            // cmbFilterValue
            // 
            this.cmbFilterValue.Location = new System.Drawing.Point(92, 172);
            this.cmbFilterValue.Name = "cmbFilterValue";
            this.cmbFilterValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFilterValue.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbFilterValue.Size = new System.Drawing.Size(261, 20);
            this.cmbFilterValue.TabIndex = 23;
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(11, 105);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(73, 13);
            this.label58.TabIndex = 18;
            this.label58.Text = "Detection Type";
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(11, 152);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(51, 13);
            this.label63.TabIndex = 22;
            this.label63.Text = "Filter Type";
            // 
            // cmbWindowType
            // 
            this.cmbWindowType.Location = new System.Drawing.Point(92, 126);
            this.cmbWindowType.Name = "cmbWindowType";
            this.cmbWindowType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbWindowType.Properties.Items.AddRange(new object[] {
            "Hanning",
            "Rectangular",
            "Flattop",
            "Hamming"});
            this.cmbWindowType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbWindowType.Size = new System.Drawing.Size(261, 20);
            this.cmbWindowType.TabIndex = 19;
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.Location = new System.Drawing.Point(92, 149);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFilterType.Properties.Items.AddRange(new object[] {
            "None",
            "Band pass Filter(enveloper)",
            "High pass Filter",
            "Band pass Filter(no enveloper)"});
            this.cmbFilterType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbFilterType.Size = new System.Drawing.Size(261, 20);
            this.cmbFilterType.TabIndex = 21;
            this.cmbFilterType.SelectedIndexChanged += new System.EventHandler(this.cmbFilterType_SelectedIndexChanged);
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(11, 128);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(65, 13);
            this.label62.TabIndex = 20;
            this.label62.Text = "Window Type";
            // 
            // xtraC911
            // 
            this.xtraC911.Controls.Add(this.xtraSCC911);
            this.xtraC911.Name = "xtraC911";
            this.xtraC911.Size = new System.Drawing.Size(901, 499);
            this.xtraC911.Text = "Measurement-C911";
            // 
            // xtraSCC911
            // 
            this.xtraSCC911.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xtraSCC911.Appearance.Options.UseBackColor = true;
            this.xtraSCC911.Controls.Add(this.groupControl2);
            this.xtraSCC911.Controls.Add(this.gcC911);
            this.xtraSCC911.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraSCC911.Location = new System.Drawing.Point(0, 0);
            this.xtraSCC911.Name = "xtraSCC911";
            this.xtraSCC911.Size = new System.Drawing.Size(901, 499);
            this.xtraSCC911.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl26);
            this.groupControl2.Controls.Add(this.cmbalarmC911);
            this.groupControl2.Controls.Add(this.labelControl28);
            this.groupControl2.Controls.Add(this.cmbBandC911);
            this.groupControl2.Location = new System.Drawing.Point(444, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(371, 151);
            this.groupControl2.TabIndex = 116;
            this.groupControl2.Text = "General\\Band Alarms";
            // 
            // labelControl26
            // 
            this.labelControl26.Location = new System.Drawing.Point(14, 40);
            this.labelControl26.Name = "labelControl26";
            this.labelControl26.Size = new System.Drawing.Size(67, 13);
            this.labelControl26.TabIndex = 33;
            this.labelControl26.Text = "General Alarm";
            // 
            // cmbalarmC911
            // 
            this.cmbalarmC911.Location = new System.Drawing.Point(115, 37);
            this.cmbalarmC911.Name = "cmbalarmC911";
            this.cmbalarmC911.Properties.AllowFocused = false;
            this.cmbalarmC911.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbalarmC911.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbalarmC911.Properties.Appearance.Options.UseBackColor = true;
            this.cmbalarmC911.Properties.Appearance.Options.UseFont = true;
            this.cmbalarmC911.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbalarmC911.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbalarmC911.Size = new System.Drawing.Size(176, 20);
            this.cmbalarmC911.TabIndex = 32;
            // 
            // labelControl28
            // 
            this.labelControl28.Location = new System.Drawing.Point(16, 80);
            this.labelControl28.Name = "labelControl28";
            this.labelControl28.Size = new System.Drawing.Size(54, 13);
            this.labelControl28.TabIndex = 17;
            this.labelControl28.Text = "Band Alarm";
            // 
            // cmbBandC911
            // 
            this.cmbBandC911.Location = new System.Drawing.Point(115, 77);
            this.cmbBandC911.Name = "cmbBandC911";
            this.cmbBandC911.Properties.AllowFocused = false;
            this.cmbBandC911.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbBandC911.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBandC911.Properties.Appearance.Options.UseBackColor = true;
            this.cmbBandC911.Properties.Appearance.Options.UseFont = true;
            this.cmbBandC911.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBandC911.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBandC911.Size = new System.Drawing.Size(176, 20);
            this.cmbBandC911.TabIndex = 4;
            // 
            // gcC911
            // 
            this.gcC911.Controls.Add(this.gbamplifier);
            this.gcC911.Controls.Add(this.txtcomment);
            this.gcC911.Controls.Add(this.txtN);
            this.gcC911.Controls.Add(this.labelControl25);
            this.gcC911.Controls.Add(this.labelControl24);
            this.gcC911.Controls.Add(this.cmbAvermode);
            this.gcC911.Controls.Add(this.cmbtrigger);
            this.gcC911.Controls.Add(this.cmbfmax);
            this.gcC911.Controls.Add(this.cmbFmin);
            this.gcC911.Controls.Add(this.cmbspectral);
            this.gcC911.Controls.Add(this.cmbwindow);
            this.gcC911.Controls.Add(this.cmbchannel2);
            this.gcC911.Controls.Add(this.cmbenv);
            this.gcC911.Controls.Add(this.gbC911);
            this.gcC911.Controls.Add(this.cmbchannel1);
            this.gcC911.Controls.Add(this.labelControl23);
            this.gcC911.Controls.Add(this.labelControl13);
            this.gcC911.Controls.Add(this.labelControl12);
            this.gcC911.Controls.Add(this.labelControl11);
            this.gcC911.Controls.Add(this.labelControl10);
            this.gcC911.Controls.Add(this.labelControl9);
            this.gcC911.Controls.Add(this.labelControl8);
            this.gcC911.Controls.Add(this.labelControl4);
            this.gcC911.Controls.Add(this.labelControl2);
            this.gcC911.Location = new System.Drawing.Point(8, 3);
            this.gcC911.Name = "gcC911";
            this.gcC911.Size = new System.Drawing.Size(430, 476);
            this.gcC911.TabIndex = 0;
            this.gcC911.Text = "Analyser";
            // 
            // gbamplifier
            // 
            this.gbamplifier.Controls.Add(this.rbampenv);
            this.gbamplifier.Controls.Add(this.rbampint1);
            this.gbamplifier.Controls.Add(this.rbampint2);
            this.gbamplifier.Controls.Add(this.rbamplinA);
            this.gbamplifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbamplifier.Location = new System.Drawing.Point(219, 131);
            this.gbamplifier.Name = "gbamplifier";
            this.gbamplifier.Size = new System.Drawing.Size(150, 69);
            this.gbamplifier.TabIndex = 25;
            this.gbamplifier.TabStop = false;
            this.gbamplifier.Text = "Amplifier Mode";
            // 
            // rbampenv
            // 
            this.rbampenv.AutoSize = true;
            this.rbampenv.Location = new System.Drawing.Point(90, 48);
            this.rbampenv.Name = "rbampenv";
            this.rbampenv.Size = new System.Drawing.Size(43, 17);
            this.rbampenv.TabIndex = 3;
            this.rbampenv.Text = "Env";
            this.rbampenv.UseVisualStyleBackColor = true;
            // 
            // rbampint1
            // 
            this.rbampint1.AutoSize = true;
            this.rbampint1.Location = new System.Drawing.Point(16, 48);
            this.rbampint1.Name = "rbampint1";
            this.rbampint1.Size = new System.Drawing.Size(54, 17);
            this.rbampint1.TabIndex = 2;
            this.rbampint1.Text = "Int1 V";
            this.rbampint1.UseVisualStyleBackColor = true;
            // 
            // rbampint2
            // 
            this.rbampint2.AutoSize = true;
            this.rbampint2.Location = new System.Drawing.Point(90, 20);
            this.rbampint2.Name = "rbampint2";
            this.rbampint2.Size = new System.Drawing.Size(54, 17);
            this.rbampint2.TabIndex = 1;
            this.rbampint2.Text = "Int2 S";
            this.rbampint2.UseVisualStyleBackColor = true;
            // 
            // rbamplinA
            // 
            this.rbamplinA.AutoSize = true;
            this.rbamplinA.Checked = true;
            this.rbamplinA.Location = new System.Drawing.Point(16, 20);
            this.rbamplinA.Name = "rbamplinA";
            this.rbamplinA.Size = new System.Drawing.Size(48, 17);
            this.rbamplinA.TabIndex = 0;
            this.rbamplinA.TabStop = true;
            this.rbamplinA.Text = "Lin A";
            this.rbamplinA.UseVisualStyleBackColor = true;
            // 
            // txtcomment
            // 
            this.txtcomment.EditValue = "";
            this.txtcomment.Location = new System.Drawing.Point(150, 424);
            this.txtcomment.Name = "txtcomment";
            this.txtcomment.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtcomment.Properties.Appearance.Options.UseBackColor = true;
            this.txtcomment.Properties.MaxLength = 31;
            this.txtcomment.Size = new System.Drawing.Size(238, 20);
            this.txtcomment.TabIndex = 24;
            // 
            // txtN
            // 
            this.txtN.EditValue = "2";
            this.txtN.Enabled = false;
            this.txtN.Location = new System.Drawing.Point(301, 389);
            this.txtN.Name = "txtN";
            this.txtN.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtN.Properties.Appearance.Options.UseBackColor = true;
            this.txtN.Properties.MaxLength = 31;
            this.txtN.Size = new System.Drawing.Size(87, 20);
            this.txtN.TabIndex = 23;
            // 
            // labelControl25
            // 
            this.labelControl25.Location = new System.Drawing.Point(6, 427);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(50, 13);
            this.labelControl25.TabIndex = 22;
            this.labelControl25.Text = "Comments";
            // 
            // labelControl24
            // 
            this.labelControl24.Location = new System.Drawing.Point(273, 392);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(7, 13);
            this.labelControl24.TabIndex = 21;
            this.labelControl24.Text = "N";
            // 
            // cmbAvermode
            // 
            this.cmbAvermode.EditValue = "OFF";
            this.cmbAvermode.Location = new System.Drawing.Point(150, 389);
            this.cmbAvermode.Name = "cmbAvermode";
            this.cmbAvermode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbAvermode.Properties.Appearance.Options.UseBackColor = true;
            this.cmbAvermode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAvermode.Properties.Items.AddRange(new object[] {
            "OFF",
            "Linear frequency domain",
            "Exponantial frequency domain",
            "Linear time domain",
            "Exponantial time domain"});
            this.cmbAvermode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbAvermode.Size = new System.Drawing.Size(87, 20);
            this.cmbAvermode.TabIndex = 20;
            // 
            // cmbtrigger
            // 
            this.cmbtrigger.EditValue = "free run";
            this.cmbtrigger.Location = new System.Drawing.Point(150, 357);
            this.cmbtrigger.Name = "cmbtrigger";
            this.cmbtrigger.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbtrigger.Properties.Appearance.Options.UseBackColor = true;
            this.cmbtrigger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbtrigger.Properties.Items.AddRange(new object[] {
            "free run",
            "Internal",
            "External"});
            this.cmbtrigger.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbtrigger.Size = new System.Drawing.Size(87, 20);
            this.cmbtrigger.TabIndex = 19;
            // 
            // cmbfmax
            // 
            this.cmbfmax.EditValue = "125";
            this.cmbfmax.Location = new System.Drawing.Point(150, 322);
            this.cmbfmax.Name = "cmbfmax";
            this.cmbfmax.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbfmax.Properties.Appearance.Options.UseBackColor = true;
            this.cmbfmax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbfmax.Properties.Items.AddRange(new object[] {
            "125",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000",
            "2000"});
            this.cmbfmax.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbfmax.Size = new System.Drawing.Size(87, 20);
            this.cmbfmax.TabIndex = 18;
            // 
            // cmbFmin
            // 
            this.cmbFmin.EditValue = "2";
            this.cmbFmin.Location = new System.Drawing.Point(150, 287);
            this.cmbFmin.Name = "cmbFmin";
            this.cmbFmin.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbFmin.Properties.Appearance.Options.UseBackColor = true;
            this.cmbFmin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFmin.Properties.Items.AddRange(new object[] {
            "2",
            "10"});
            this.cmbFmin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbFmin.Size = new System.Drawing.Size(87, 20);
            this.cmbFmin.TabIndex = 17;
            // 
            // cmbspectral
            // 
            this.cmbspectral.EditValue = "";
            this.cmbspectral.Location = new System.Drawing.Point(150, 252);
            this.cmbspectral.Name = "cmbspectral";
            this.cmbspectral.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbspectral.Properties.Appearance.Options.UseBackColor = true;
            this.cmbspectral.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbspectral.Properties.Items.AddRange(new object[] {
            "100",
            "200",
            "400",
            "800",
            "1600",
            "3200"});
            this.cmbspectral.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbspectral.Size = new System.Drawing.Size(148, 20);
            this.cmbspectral.TabIndex = 16;
            // 
            // cmbwindow
            // 
            this.cmbwindow.EditValue = "Rectangular";
            this.cmbwindow.Location = new System.Drawing.Point(150, 214);
            this.cmbwindow.Name = "cmbwindow";
            this.cmbwindow.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbwindow.Properties.Appearance.Options.UseBackColor = true;
            this.cmbwindow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbwindow.Properties.Items.AddRange(new object[] {
            "Rectangular",
            "Hanning"});
            this.cmbwindow.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbwindow.Size = new System.Drawing.Size(148, 20);
            this.cmbwindow.TabIndex = 15;
            // 
            // cmbchannel2
            // 
            this.cmbchannel2.EditValue = "in 1";
            this.cmbchannel2.Location = new System.Drawing.Point(90, 132);
            this.cmbchannel2.Name = "cmbchannel2";
            this.cmbchannel2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbchannel2.Properties.Appearance.Options.UseBackColor = true;
            this.cmbchannel2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbchannel2.Properties.Items.AddRange(new object[] {
            "in 1",
            "in 2",
            "in 3",
            "off"});
            this.cmbchannel2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbchannel2.Size = new System.Drawing.Size(87, 20);
            this.cmbchannel2.TabIndex = 13;
            // 
            // cmbenv
            // 
            this.cmbenv.EditValue = "2";
            this.cmbenv.Location = new System.Drawing.Point(165, 101);
            this.cmbenv.Name = "cmbenv";
            this.cmbenv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbenv.Properties.Appearance.Options.UseBackColor = true;
            this.cmbenv.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbenv.Properties.Items.AddRange(new object[] {
            "2",
            "4",
            "8",
            "16",
            "32"});
            this.cmbenv.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbenv.Size = new System.Drawing.Size(90, 20);
            this.cmbenv.TabIndex = 12;
            // 
            // gbC911
            // 
            this.gbC911.Controls.Add(this.rbrnv);
            this.gbC911.Controls.Add(this.rbintv);
            this.gbC911.Controls.Add(this.rbint);
            this.gbC911.Controls.Add(this.rblinA);
            this.gbC911.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbC911.Location = new System.Drawing.Point(219, 23);
            this.gbC911.Name = "gbC911";
            this.gbC911.Size = new System.Drawing.Size(150, 69);
            this.gbC911.TabIndex = 11;
            this.gbC911.TabStop = false;
            this.gbC911.Text = "Amplifier Mode";
            // 
            // rbrnv
            // 
            this.rbrnv.AutoSize = true;
            this.rbrnv.Location = new System.Drawing.Point(90, 48);
            this.rbrnv.Name = "rbrnv";
            this.rbrnv.Size = new System.Drawing.Size(43, 17);
            this.rbrnv.TabIndex = 3;
            this.rbrnv.Text = "Env";
            this.rbrnv.UseVisualStyleBackColor = true;
            // 
            // rbintv
            // 
            this.rbintv.AutoSize = true;
            this.rbintv.Location = new System.Drawing.Point(16, 48);
            this.rbintv.Name = "rbintv";
            this.rbintv.Size = new System.Drawing.Size(54, 17);
            this.rbintv.TabIndex = 2;
            this.rbintv.Text = "Int1 V";
            this.rbintv.UseVisualStyleBackColor = true;
            // 
            // rbint
            // 
            this.rbint.AutoSize = true;
            this.rbint.Location = new System.Drawing.Point(90, 20);
            this.rbint.Name = "rbint";
            this.rbint.Size = new System.Drawing.Size(54, 17);
            this.rbint.TabIndex = 1;
            this.rbint.Text = "Int2 S";
            this.rbint.UseVisualStyleBackColor = true;
            // 
            // rblinA
            // 
            this.rblinA.AutoSize = true;
            this.rblinA.Checked = true;
            this.rblinA.Location = new System.Drawing.Point(16, 20);
            this.rblinA.Name = "rblinA";
            this.rblinA.Size = new System.Drawing.Size(48, 17);
            this.rblinA.TabIndex = 0;
            this.rblinA.TabStop = true;
            this.rblinA.Text = "Lin A";
            this.rblinA.UseVisualStyleBackColor = true;
            // 
            // cmbchannel1
            // 
            this.cmbchannel1.EditValue = "in 1";
            this.cmbchannel1.Location = new System.Drawing.Point(90, 40);
            this.cmbchannel1.Name = "cmbchannel1";
            this.cmbchannel1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.cmbchannel1.Properties.Appearance.Options.UseBackColor = true;
            this.cmbchannel1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbchannel1.Properties.Items.AddRange(new object[] {
            "in 1",
            "in 2",
            "in 3",
            "off"});
            this.cmbchannel1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbchannel1.Size = new System.Drawing.Size(87, 20);
            this.cmbchannel1.TabIndex = 10;
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(6, 392);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(78, 13);
            this.labelControl23.TabIndex = 9;
            this.labelControl23.Text = "Averaging Mode";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(6, 360);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(63, 13);
            this.labelControl13.TabIndex = 8;
            this.labelControl13.Text = "Trigger Mode";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(6, 329);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(54, 13);
            this.labelControl12.TabIndex = 7;
            this.labelControl12.Text = "Fmax (LPF)";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(6, 290);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(52, 13);
            this.labelControl11.TabIndex = 6;
            this.labelControl11.Text = "Fmin (HPF)";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(6, 255);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(106, 13);
            this.labelControl10.TabIndex = 5;
            this.labelControl10.Text = "Spectral Lines Number";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(6, 217);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(65, 13);
            this.labelControl9.TabIndex = 4;
            this.labelControl9.Text = "Window Type";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(5, 135);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(45, 13);
            this.labelControl8.TabIndex = 3;
            this.labelControl8.Text = "Channel2";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 103);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(142, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Enveloping Carrier Frequency";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Channel1";
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(903, 491);
            // 
            // pttPanel
            // 
            this.pttPanel.Controls.Add(this.groupBox4);
            this.pttPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pttPanel.Location = new System.Drawing.Point(0, 0);
            this.pttPanel.Name = "pttPanel";
            this.pttPanel.Size = new System.Drawing.Size(938, 551);
            this.pttPanel.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox4.Controls.Add(this.panelControl1);
            this.groupBox4.Controls.Add(this.toolStrip1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox4.Size = new System.Drawing.Size(934, 547);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.xtraTbPointType);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 14);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(934, 508);
            this.panelControl1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSave,
            this.tsbtnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 522);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(934, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.Image = global::Iadeptmain.XRDesignRibbonControllerResources.RibbonUserDesigner_SaveFile;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(51, 22);
            this.tsbtnSave.Text = "Save";
            this.tsbtnSave.Click += new System.EventHandler(this.tsbtnSave_Click);
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.Image = global::Iadeptmain.XRDesignRibbonControllerResources.delete_icon;
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(60, 22);
            this.tsbtnDelete.Text = "Delete";
            this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
            // 
            // FrmPointType
            // 
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(938, 551);
            this.ControlBox = false;
            this.Controls.Add(this.pttPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPointType";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point Type";
            this.Load += new System.EventHandler(this.PType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTbPointType)).EndInit();
            this.xtraTbPointType.ResumeLayout(false);
            this.xtraTPPType.ResumeLayout(false);
            this.gpPType.ResumeLayout(false);
            this.gpPType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPointtypename.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPTypeInst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPType.Properties)).EndInit();
            this.xtraTPB0.ResumeLayout(false);
            this.xtraSCB0.ResumeLayout(false);
            this.xtraSCB0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            this.xtraTPB1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.xtraScB1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBox5)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbBandGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbAlarmlist.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSDAlarmList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPAlarmList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbUniaxial)).EndInit();
            this.gbUniaxial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbICPPower.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCH1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAxial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHorizontal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVertical.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtempname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CmbSensorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbOverAll)).EndInit();
            this.gbOverAll.ResumeLayout(false);
            this.gbOverAll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbaccHPFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCrestFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBearingFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDispFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVelocityFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAccelerationFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbTime)).EndInit();
            this.gbTime.ResumeLayout(false);
            this.gbTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOverlap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLines.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTimeBand.Properties)).EndInit();
            this.xtraTPB2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.xtraSCB2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gboctave)).EndInit();
            this.gboctave.ResumeLayout(false);
            this.gboctave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBarstyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOctave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbOrdertrace)).EndInit();
            this.gbOrdertrace.ResumeLayout(false);
            this.gbOrdertrace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbOTSlope.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOTLines.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOTOrder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOTAvg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hbPowerSpectrum)).EndInit();
            this.hbPowerSpectrum.ResumeLayout(false);
            this.hbPowerSpectrum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkbxG3P2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG3PSLines1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG3PSBand1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG3PSLines.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG3PSBand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkbxG2P2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG2PSLines1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG2PSBand1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG2PSLines.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbG2PSBand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMultipleBand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSLines1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSBand1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPSZoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbZoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSOverlap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAvgTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSLines.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPSBand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDemodulate)).EndInit();
            this.gbDemodulate.ResumeLayout(false);
            this.gbDemodulate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdmAvgTimes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdmWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdmLines.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDMBand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbCepstrum)).EndInit();
            this.gbCepstrum.ResumeLayout(false);
            this.gbCepstrum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCepZoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCepZoom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepOverlap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepAvgTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepWind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepBand.Properties)).EndInit();
            this.xtraTPB3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.xtraScB3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbMeasure)).EndInit();
            this.gbMeasure.ResumeLayout(false);
            this.gbMeasure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCepstrum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbOrderTrace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDemodulate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSpectrum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbUnitDetection)).EndInit();
            this.gbUnitDetection.ResumeLayout(false);
            this.gbUnitDetection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCurrentUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCurrent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPressureUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPressure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDispUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVelUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAccUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTemp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDisp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAcc.Properties)).EndInit();
            this.xtraTPIMXA.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.xtraSCIMAX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbAlarms)).EndInit();
            this.grbAlarms.ResumeLayout(false);
            this.grbAlarms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAlarmImxa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbbandimxa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUnitsMain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDI2)).EndInit();
            this.gbDI2.ResumeLayout(false);
            this.gbDI2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpecAver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTimeAveg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDirection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChannelType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCollectionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTriggerRange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMeasureType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbResolution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSlope1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrequency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTriggerType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrders.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbOverlap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbDI1)).EndInit();
            this.gbDI1.ResumeLayout(false);
            this.gbDI1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCouple.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFullScale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSensitivity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDetectionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilterValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWindowType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilterType.Properties)).EndInit();
            this.xtraC911.ResumeLayout(false);
            this.xtraSCC911.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbalarmC911.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBandC911.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcC911)).EndInit();
            this.gcC911.ResumeLayout(false);
            this.gcC911.PerformLayout();
            this.gbamplifier.ResumeLayout(false);
            this.gbamplifier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtcomment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAvermode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbtrigger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbfmax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFmin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbspectral.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbwindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbchannel2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbenv.Properties)).EndInit();
            this.gbC911.ResumeLayout(false);
            this.gbC911.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbchannel1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pttPanel)).EndInit();
            this.pttPanel.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabPage xtraTPPType;
        private DevComponents.DotNetBar.Controls.GroupPanel gpPType;
        private DevExpress.XtraEditors.LabelControl lblPTypeName;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPTypeInst;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPType;
        private DevExpress.XtraEditors.LabelControl lblPType;
        private DevExpress.XtraEditors.LabelControl lblPTypeInst;
        private DevExpress.XtraTab.XtraTabPage xtraTPB0;
        private DevExpress.XtraEditors.XtraScrollableControl xtraSCB0;
        private DevExpress.XtraTab.XtraTabPage xtraTPB1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScB1;
        private DevExpress.XtraTab.XtraTabPage xtraTPB2;
        private DevExpress.XtraEditors.XtraScrollableControl xtraSCB2;
        private DevExpress.XtraTab.XtraTabPage xtraTPB3;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScB3;
        private DevExpress.XtraTab.XtraTabPage xtraTPIMXA;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraSCIMAX;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl gbOverAll;
        private DevExpress.XtraEditors.LabelControl lblCrestFilter;
        private DevExpress.XtraEditors.ComboBoxEdit cbCrestFilter;
        private DevExpress.XtraEditors.LabelControl lblBearingFilter;
        private DevExpress.XtraEditors.ComboBoxEdit cbBearingFilter;
        private DevExpress.XtraEditors.LabelControl lblDisplacementFilter;
        private DevExpress.XtraEditors.ComboBoxEdit cbDispFilter;
        private DevExpress.XtraEditors.LabelControl lblVelocityFilter;
        private DevExpress.XtraEditors.ComboBoxEdit cbVelocityFilter;
        private DevExpress.XtraEditors.ComboBoxEdit cbAccelerationFilter;
        private DevExpress.XtraEditors.LabelControl lblAccFilter;
        private DevExpress.XtraEditors.GroupControl gbTime;
        private DevExpress.XtraEditors.ComboBoxEdit cbOverlap;
        private DevExpress.XtraEditors.LabelControl lblOverlap;
        private DevExpress.XtraEditors.LabelControl lblLines;
        private DevExpress.XtraEditors.ComboBoxEdit cbLines;
        private DevExpress.XtraEditors.ComboBoxEdit cbTimeBand;
        private DevExpress.XtraEditors.LabelControl lblBand;
        private DevExpress.XtraEditors.GroupControl groupBox5;
        private DevExpress.XtraEditors.GroupControl groupBox1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAlarmlist;
        private DevExpress.XtraEditors.GroupControl groupBox3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSDAlarmList;
        private DevExpress.XtraEditors.GroupControl groupBox2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPAlarmList;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.GroupControl gbCepstrum;
        private DevExpress.XtraEditors.TextEdit txtCepZoom;
        private DevExpress.XtraEditors.CheckEdit chkCepZoom;
        private DevExpress.XtraEditors.ComboBoxEdit cbCepOverlap;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.ComboBoxEdit cbCepAvgTime;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.ComboBoxEdit cbCepWind;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.ComboBoxEdit cbCepLine;
        private DevExpress.XtraEditors.ComboBoxEdit cbCepBand;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.GroupControl gbDemodulate;
        private DevExpress.XtraEditors.ComboBoxEdit cbFilter;
        private DevExpress.XtraEditors.LabelControl lblFilter;
        private DevExpress.XtraEditors.ComboBoxEdit cmbdmAvgTimes;
        private DevExpress.XtraEditors.LabelControl label81;
        private DevExpress.XtraEditors.ComboBoxEdit cmbdmWindow;
        private DevExpress.XtraEditors.LabelControl label84;
        private DevExpress.XtraEditors.LabelControl label85;
        private DevExpress.XtraEditors.ComboBoxEdit cmbdmLines;
        private DevExpress.XtraEditors.ComboBoxEdit cbDMBand;
        private DevExpress.XtraEditors.LabelControl label86;
        private DevExpress.XtraEditors.GroupControl gbDI2;
        private DevExpress.XtraEditors.LabelControl label54;
        private DevExpress.XtraEditors.LabelControl label53;
        private DevExpress.XtraEditors.TextEdit tbSpecAver;
        private DevExpress.XtraEditors.TextEdit tbTimeAveg;
        private DevExpress.XtraEditors.LabelControl label64;
        private DevExpress.XtraEditors.LabelControl label77;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDirection;
        private DevExpress.XtraEditors.ComboBoxEdit cmbChannelType;
        private DevExpress.XtraEditors.LabelControl label65;
        private DevExpress.XtraEditors.LabelControl label76;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCollectionType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTriggerRange;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMeasureType;
        private DevExpress.XtraEditors.LabelControl label75;
        private DevExpress.XtraEditors.LabelControl label66;
        private DevExpress.XtraEditors.TextEdit tbLevel;
        private DevExpress.XtraEditors.ComboBoxEdit cmbResolution;
        private DevExpress.XtraEditors.LabelControl label74;
        private DevExpress.XtraEditors.LabelControl label69;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSlope1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFrequency;
        private DevExpress.XtraEditors.LabelControl label73;
        private DevExpress.XtraEditors.LabelControl label70;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTriggerType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbOrders;
        private DevExpress.XtraEditors.LabelControl label72;
        private DevExpress.XtraEditors.LabelControl label71;
        private DevExpress.XtraEditors.TextEdit tbOverlap;
        private DevExpress.XtraEditors.GroupControl gbDI1;
        private DevExpress.XtraEditors.LabelControl label83;
        private DevExpress.XtraEditors.ComboBoxEdit cmbCouple;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFullScale;
        private DevExpress.XtraEditors.LabelControl label57;
        private DevExpress.XtraEditors.LabelControl label82;
        private DevExpress.XtraEditors.TextEdit tbSensitivity;
        private DevExpress.XtraEditors.LabelControl label67;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDetectionType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFilterValue;
        private DevExpress.XtraEditors.LabelControl label58;
        private DevExpress.XtraEditors.LabelControl label63;
        private DevExpress.XtraEditors.ComboBoxEdit cmbWindowType;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFilterType;
        private DevExpress.XtraEditors.LabelControl label62;
        private DevExpress.XtraEditors.GroupControl gbUnitDetection;
        private DevExpress.XtraEditors.ComboBoxEdit cbCurrentUnit;
        private DevExpress.XtraEditors.LabelControl lblCurrent;
        private DevExpress.XtraEditors.ComboBoxEdit cbCurrent;
        private DevExpress.XtraEditors.ComboBoxEdit cbPressureUnit;
        private DevExpress.XtraEditors.LabelControl lblPressure;
        private DevExpress.XtraEditors.ComboBoxEdit cbPressure;
        private DevExpress.XtraEditors.ComboBoxEdit cbDispUnit;
        private DevExpress.XtraEditors.ComboBoxEdit cbVelUnit;
        private DevExpress.XtraEditors.ComboBoxEdit cbAccUnit;
        private DevExpress.XtraEditors.TextEdit txtProcess;
        private DevExpress.XtraEditors.LabelControl lblProcess;
        private DevExpress.XtraEditors.ComboBoxEdit cbTemp;
        private DevExpress.XtraEditors.LabelControl lblTemprature;
        private DevExpress.XtraEditors.LabelControl lblDisp;
        private DevExpress.XtraEditors.ComboBoxEdit cbDisp;
        private DevExpress.XtraEditors.LabelControl lblVel;
        private DevExpress.XtraEditors.ComboBoxEdit cbVel;
        private DevExpress.XtraEditors.ComboBoxEdit cbAcc;
        private DevExpress.XtraEditors.LabelControl lblAcc;
        private DevExpress.XtraEditors.GroupControl gbMeasure;
        private DevExpress.XtraEditors.LabelControl lblCepstrum;
        private DevExpress.XtraEditors.ComboBoxEdit cbCepstrum;
        private DevExpress.XtraEditors.LabelControl lblOrderTrace;
        private DevExpress.XtraEditors.ComboBoxEdit cbOrderTrace;
        private DevExpress.XtraEditors.LabelControl lblDemodulate;
        private DevExpress.XtraEditors.ComboBoxEdit cbDemodulate;
        private DevExpress.XtraEditors.LabelControl lblSpectrum;
        private DevExpress.XtraEditors.ComboBoxEdit cbSpectrum;
        private DevExpress.XtraEditors.ComboBoxEdit cbTime;
        private DevExpress.XtraEditors.LabelControl lblTime;
        private DevExpress.XtraEditors.GroupControl hbPowerSpectrum;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.CheckBox chkbxG3P1;
        private DevExpress.XtraEditors.CheckEdit chkbxG3P2;
        private DevExpress.XtraEditors.LabelControl lblG3P2Line;
        private DevExpress.XtraEditors.ComboBoxEdit cbG3PSLines1;
        private DevExpress.XtraEditors.ComboBoxEdit cbG3PSBand1;
        private DevExpress.XtraEditors.LabelControl lblG3P2Band;
        private DevExpress.XtraEditors.LabelControl lblG3P1Line;
        private DevExpress.XtraEditors.ComboBoxEdit cbG3PSLines;
        private DevExpress.XtraEditors.ComboBoxEdit cbG3PSBand;
        private DevExpress.XtraEditors.LabelControl lblG3P1Band;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.CheckBox chkbxG2P1;
        private DevExpress.XtraEditors.CheckEdit chkbxG2P2;
        private DevExpress.XtraEditors.LabelControl lblG2P2Line;
        private DevExpress.XtraEditors.ComboBoxEdit cbG2PSLines1;
        private DevExpress.XtraEditors.ComboBoxEdit cbG2PSBand1;
        private DevExpress.XtraEditors.LabelControl lblG2P2Band;
        private DevExpress.XtraEditors.LabelControl lblG2P1Line;
        private DevExpress.XtraEditors.ComboBoxEdit cbG2PSLines;
        private DevExpress.XtraEditors.ComboBoxEdit cbG2PSBand;
        private DevExpress.XtraEditors.LabelControl lblG2P1Band;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.CheckBox chkbxG1P1;
        private DevExpress.XtraEditors.CheckEdit cbMultipleBand;
        private DevExpress.XtraEditors.LabelControl lblPowerLine1;
        private DevExpress.XtraEditors.ComboBoxEdit cbPSLines1;
        private DevExpress.XtraEditors.ComboBoxEdit cbPSBand1;
        private DevExpress.XtraEditors.LabelControl lblPowerBand1;
        private DevExpress.XtraEditors.TextEdit txtPSZoom;
        private DevExpress.XtraEditors.CheckEdit cbZoom;
        private DevExpress.XtraEditors.ComboBoxEdit cbPSOverlap;
        private DevExpress.XtraEditors.LabelControl lblPSOverlap;
        private DevExpress.XtraEditors.ComboBoxEdit cbAvgTimes;
        private DevExpress.XtraEditors.LabelControl lblAverageTimes;
        private DevExpress.XtraEditors.ComboBoxEdit cbPSWindow;
        private DevExpress.XtraEditors.LabelControl lblWindow;
        private DevExpress.XtraEditors.LabelControl label87;
        private DevExpress.XtraEditors.ComboBoxEdit cbPSLines;
        private DevExpress.XtraEditors.ComboBoxEdit cbPSBand;
        private DevExpress.XtraEditors.LabelControl label88;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit CmbSensorName;
        private DevExpress.XtraEditors.GroupControl gbOrdertrace;
        private DevExpress.XtraEditors.ComboBoxEdit cbOTSlope;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.ComboBoxEdit cbOTLines;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.TextEdit txtOTOrder;
        private DevExpress.XtraEditors.ComboBoxEdit cbOTAvg;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private System.Windows.Forms.ComboBox cmbPointTpname;
        private DevExpress.XtraEditors.ComboBoxEdit cmbUnitsMain;
        private DevExpress.XtraEditors.LabelControl lblType;
        private DevExpress.XtraEditors.TextEdit txtPointtypename;
        private DevExpress.XtraEditors.ComboBoxEdit cmbtempname;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl gbUniaxial;
        private DevExpress.XtraEditors.CheckEdit chkAxial;
        private DevExpress.XtraEditors.CheckEdit chkHorizontal;
        private DevExpress.XtraEditors.CheckEdit chkVertical;
        private DevExpress.XtraEditors.CheckEdit cbICPPower;
        private DevExpress.XtraEditors.CheckEdit chkCH1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBandGroup;
        private DevExpress.XtraEditors.ComboBoxEdit cmbaccHPFilter;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.PanelControl pttPanel;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.ListView lstmeasure;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;
        public DevExpress.XtraTab.XtraTabControl xtraTbPointType;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl5;
        private DevExpress.XtraTab.XtraTabPage xtraC911;
        private DevExpress.XtraEditors.XtraScrollableControl xtraSCC911;
        private DevExpress.XtraEditors.GroupControl gcC911;
        private DevExpress.XtraEditors.ComboBoxEdit cmbchannel2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbenv;
        private System.Windows.Forms.GroupBox gbC911;
        private System.Windows.Forms.RadioButton rbrnv;
        private System.Windows.Forms.RadioButton rbintv;
        private System.Windows.Forms.RadioButton rbint;
        private System.Windows.Forms.RadioButton rblinA;
        private DevExpress.XtraEditors.ComboBoxEdit cmbchannel1;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAvermode;
        private DevExpress.XtraEditors.ComboBoxEdit cmbtrigger;
        private DevExpress.XtraEditors.ComboBoxEdit cmbfmax;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFmin;
        private DevExpress.XtraEditors.ComboBoxEdit cmbspectral;
        private DevExpress.XtraEditors.ComboBoxEdit cmbwindow;
        private DevExpress.XtraEditors.TextEdit txtcomment;
        private DevExpress.XtraEditors.TextEdit txtN;
        private System.Windows.Forms.GroupBox gbamplifier;
        private System.Windows.Forms.RadioButton rbampenv;
        private System.Windows.Forms.RadioButton rbampint1;
        private System.Windows.Forms.RadioButton rbampint2;
        private System.Windows.Forms.RadioButton rbamplinA;
        private DevExpress.XtraEditors.GroupControl grbAlarms;
        private DevExpress.XtraEditors.ComboBoxEdit cmbbandimxa;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAlarmImxa;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private DevExpress.XtraEditors.ComboBoxEdit cmbalarmC911;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBandC911;
        private DevExpress.XtraEditors.GroupControl gboctave;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl lblN;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBarstyle;
        private DevExpress.XtraEditors.LabelControl lblBarstyle;
        private DevExpress.XtraEditors.ComboBoxEdit cmbOctave;
        private DevExpress.XtraEditors.LabelControl lblOctave;
    }
}