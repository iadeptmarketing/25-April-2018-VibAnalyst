using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using DevExpress.XtraEditors.Controls;
using System.Threading;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using Iadeptmain;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Management;
using System.Drawing.Imaging;
using System.Data.Odbc;
using System.IO.Ports;
using DevExpress.Skins;
using System.Management.Instrumentation;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.LookAndFeel;
using DevExpress.XtraTabbedMdi;
using Iadeptmain.Mainforms;
using Iadeptmain.BaseUserControl;
using Iadeptmain.GlobalClasess;
using System.Threading;
using Iadeptmain.Classes;
using Iadeptmain.GlobalClasses;
using Iadeptmain.Images;
using com.iAM.chart2dnet;
using Iadeptmain.Reports;
using Aladdin.HASP;
using DevExpress.XtraGauges.Win;
using DevExpress.XtraGauges.Win.Gauges.Circular;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Win.Base;
using DevExpress.XtraGauges.Core.Drawing;
using DevExpress.XtraCharts;
using DevExpress.XtraSplashScreen;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Iadeptmain.Mainforms
{
    public partial class frmIAdeptMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        IadeptUserControl _objUserControl = null;
        private frmgraphcontrol m_objGraphControl = null;
        private frmGControls objGcontrol = null;
        ImpaqHandler objIHand = new ImpaqHandler();
        string sErrorLogPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
        bool IsSaveEnabled = false;
        string ConnectionStr = null;
        bool bFindClosed = true;
        bool bFRClosed = true;
        string sARGB = null;
        GraphView m_objGraphView = null;
        FrmPointType aa = null;
        FileStream aa1 = null;
        public string sSelectedpage = null;
        frmUserDetail user = null;
        CSysPro m_objCSysPro = null;
        rproute rproute = null;
        string ChartFooter = null;
        string ChartHeader = null;
        Thread m_objHaspCheck = null;
        PointGeneral1 m_PointGeneral1 = null;
        _3DGraphControl _3DGraph = new _3DGraphControl();
        BarChart _BarGraph = new BarChart();
        _PolarPlot _OrbitGraph = new _PolarPlot();
        Class_extractdata ExtractData = new Class_extractdata();
        public LineGraphControl _LineGraph1 = new LineGraphControl();
        public LineGraphControl _LineGraph2 = new LineGraphControl();
        public LineGraphControl _LineGraph3 = new LineGraphControl();
        public LineGraphControl _LineGraph4 = new LineGraphControl();
        public LineGraphControl _LineGraph5 = new LineGraphControl();
        public LineGraphControl _LineGraph6 = new LineGraphControl();
        public LineGraphControl _LineGraph_Dual = null;
        public LineGraphControl _LineGraph = new LineGraphControl();
        public LineGraphControl _LineGraph_cut1 = null;
        public LineGraphControl _LineGraph_cut2 = null;
        public LineGraphControl _LineGraph_cut3 = null;
        public LineGraphControl _LineGraph_cut4 = null;
        public LineGraphControl _LineGraph_cut5 = null;
        public LineGraphControl _LineGraph_cut6 = null;
        public LineGraphControl _LineGraph_cut7 = null;
        public LineGraphControl _LineGraph_cut8 = null;
        public LineGraphControl _LineGraph_cut9 = null;
        public LineGraphControl _LineGraph_cut10 = null;
        frmDiagnostic objDiagnostic = null;
        frmMachineComparision objMachineCompare = null;
        frmBandAlarms fBAlarm = null;
        bool IsOctave = false;
        frmIAdeptMain MainForm = null;
        public string CurrentXLabel = null;
        public string CurrentYLabel = null;
        Color MainCursor = Color.Black;
        Color GraphBG1 = Color.White;
        Color GraphBG2 = Color.White;
        Color ChartBG1 = Color.White;
        Color ChartBG2 = Color.White;
        Color AxisColor = Color.Black;
        int GraphBGDir = 0;
        int ChartBGDir = 0;
        bool _AreaPlot = false;
        string XUnit = "X Unit";
        string YUnit = "Y Unit";
        bool clicktw = false;
        public double[] xarrayNw = new double[0];
        public double[] xarrayNew = new double[0];
        public double[] yarrayNew = new double[0];
        bool bAck = false; bool NotNow = false;
        bool bNever = false; bool bOnce = false;
        private bool m_bDemoButtonClicked = false;
        private ThreadStart m_objThreadStartForDSSS = null;
        private ThreadStart m_objThreadStartForESS = null;
        public delegate void SetFacTabPageTextHandler(string sName);
        SetFacTabPageTextHandler _objSetFacText = null;
        ManagementEventWatcher w = null; bool bAcknowledge = false;
        CImageCreation m_objImageCreation = null;
        bool bUnCheckAck = false;
        bool bCheckAck = false;
        bool KeyAttached = false;
        public bool exitsts = false;
        public frmIAdeptMain()
        {
            InitializeComponent();

            ShowSplashExample();

            ////////..........Code for without dongle............./////////////

            // PublicClass.currentInstrument = "Kohtect-C911";
            // PublicClass.currentInstrument = "SKF/DI";
            // PublicClass.currentInstrument = "FieldPaq2";
            PublicClass.currentInstrument = "Impaq-Benstone";
            FunctionForLogin();

            ////////..........Code for with dongle............./////////////         

            //haspcontroller();
            //m_objHaspCheck.Start();
            //if (!m_bDemoButtonClicked)
            //{
            //    FunctionForLogin();
            //}
            //else
            //{
            //    //SettingsForDemo();
            //}



            if (PublicClass.LoginStatus == true)
            {
                IntializeAllObjects();
                this.nticon.BalloonTipText = "Welcome to VibAnalyst";
                this.nticon.BalloonTipTitle = "VibAnalyst";
                this.nticon.BalloonTipIcon = ToolTipIcon.Info;

                //button active//
                InsertFactoryButton = true;
                InsertResourceButton = true;
                InsertElementButton = false;
                InsertSubElementButton = false;
                InsertPointButton = false;
                for (int i = 0; i <= 100; i++)
                {
                    SplashScreenManager.Default.SetWaitFormDescription(i.ToString() + "%");
                    Thread.Sleep(50);
                }
                SplashScreenManager.CloseForm();
                this.nticon.Visible = true;
                this.nticon.ShowBalloonTip(3);
            }
        }

        public static bool AnotherInstanceExists()
        {
            Process currentRunningProcess = Process.GetCurrentProcess();
            Process[] listOfProcs = Process.GetProcessesByName(currentRunningProcess.ProcessName);

            foreach (Process proc in listOfProcs)
            {
                if ((proc.MainModule.FileName == currentRunningProcess.MainModule.FileName) && (proc.Id != currentRunningProcess.Id))
                    return true;
            }
            return false;
        }

        string checklastdb = null;
        private void FunctionForLogin()
        {
            try
            {
                Iadeptmain.GlobalClasses.PublicClass.LoginStatus = false;
                defaultcolor();
                Iadeptmain.Mainforms.FrmLogin login = new Iadeptmain.Mainforms.FrmLogin();
                login.ShowDialog();
                if (PublicClass.LoginStatus == false)
                {
                    this.Dispose();
                    return;
                }
                else
                {
                    if (clicktw == false)
                    {
                        SplashScreenManager.ShowForm(typeof(WaitForm1));
                        clicktw = true;
                    }
                }
                color();
                Iadeptmain.GlobalClasses.PublicClass.User_IP = Iadeptmain.GlobalClasses.PublicClass.GetIP();
                ribbonPageCategory1.Text = "Selected DataBase: " + Iadeptmain.GlobalClasses.PublicClass.User_DataBase;
                try
                {
                    if (Iadeptmain.GlobalClasses.PublicClass.LoginStatus == false)
                    {
                        this.Dispose();
                    }
                    else
                    {
                        if (checklastdb == null)
                        {
                            checklastdb = PublicClass.currentInstrument;
                        }
                        SetUserTabpages();
                        if (PublicClass.currentInstrument == "SKF/DI" || PublicClass.currentInstrument == "Kohtect-C911")
                        { rpSensor.Visible = false; ribbonPageGroup3.Visible = false; rpdashboard.Visible = false; }
                        ssStatus.Text = "User Name= " + Iadeptmain.GlobalClasses.PublicClass.User_Name.Trim() + " and IPAddress= " + Iadeptmain.GlobalClasses.PublicClass.User_IP.Trim() + "  ";
                        lblRealName.Caption = "Real Name= " + Iadeptmain.GlobalClasses.PublicClass.User_Name.Trim() + "";
                        lblUId.Caption = "Admin Name= " + Iadeptmain.GlobalClasses.PublicClass.User_Name.Trim() + "";
                        if (checklastdb != PublicClass.currentInstrument)
                        {
                            SplashScreenManager.ShowForm(typeof(WaitForm1));
                            _objUserControl.filltreelist();
                            checklastdb = PublicClass.currentInstrument;
                            SplashScreenManager.CloseForm();
                        }
                    }
                }
                catch { }
            }
            catch { }
        }

        private void SSEN()
        {
            try
            {
                if (ssStatus != null)
                    ssStatus.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void SSDis()
        {
            try
            {
                if (ssStatus != null)
                    ssStatus.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }
        public void haspcontroller()
        {
            try
            {
                UsbController();
                m_objImageCreation = new CImageCreation();
                m_objCSysPro = new CSysPro();
                if (m_objCSysPro != null)
                {
                    m_objCSysPro.ExitButtonClicked += new CSysPro.ExitButtonClickHandler(m_objCSysPro_ExitButtonClicked);
                    m_objCSysPro.TryButtonClicked += new CSysPro.ExitButtonClickHandler(m_objCSysPro_TryButtonClicked);
                    m_objCSysPro.DemoButtonClick += new CSysPro.ExitButtonClickHandler(m_objCSysPro_DemoButtonClick);
                }
                m_objHaspCheck = new Thread(new ThreadStart(CheckHasp));
                m_objThreadStartForDSSS = new ThreadStart(SSDis);
                m_objThreadStartForESS = new ThreadStart(SSEN);
                m_objHaspCheck.Name = CValues.SCONSTCHBG;

                bAcknowledge = m_objCSysPro.Test();
                if (m_objCSysPro.featureStatus == "FeatureNotFound")
                {
                    MessageBox.Show("You can not use other key! Please contact the Vendor", "Wrong Key Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Environment.Exit(1);
                }
                if (PublicClass.currentInstrument != "Impaq-Benstone" && PublicClass.currentInstrument != "SKF/DI" && PublicClass.currentInstrument != "FieldPaq2" && PublicClass.currentInstrument != "Kohtect-C911")
                {
                    if (PublicClass.currentInstrument == "")
                    { }
                    else
                    {
                        MessageBox.Show("You can not use other key! Please contact the Vendor", "Wrong Key Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Environment.Exit(1);
                    }
                }
                else if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    //if (PublicClass.InstrumentSerial != "07000150" || PublicClass.InstrumentSerial != "07000037"|| PublicClass.InstrumentSerial != "07240177" || PublicClass.InstrumentSerial != "07240178" || PublicClass.InstrumentSerial != "07240179" || PublicClass.InstrumentSerial != "07240180" || PublicClass.InstrumentSerial != "07240181" || PublicClass.InstrumentSerial != "07240182" || PublicClass.InstrumentSerial != "07240183" || PublicClass.InstrumentSerial != "07240184" || PublicClass.InstrumentSerial != "07240185" || PublicClass.InstrumentSerial != "07240186" || PublicClass.InstrumentSerial != "07240187" || PublicClass.InstrumentSerial != "07240188" || PublicClass.InstrumentSerial != "07240189" || PublicClass.InstrumentSerial != "07240190" || PublicClass.InstrumentSerial != "07240191" || PublicClass.InstrumentSerial != "07240192" || PublicClass.InstrumentSerial != "07240193" || PublicClass.InstrumentSerial != "07240194" || PublicClass.InstrumentSerial != "07240195" || PublicClass.InstrumentSerial != "07240196" || PublicClass.InstrumentSerial != "07240197" || PublicClass.InstrumentSerial != "07240198" || PublicClass.InstrumentSerial != "07240199" || PublicClass.InstrumentSerial != "07240200" || PublicClass.InstrumentSerial != "07240201" || PublicClass.InstrumentSerial != "07240202" || PublicClass.InstrumentSerial != "07240203" || PublicClass.InstrumentSerial != "07240204" || PublicClass.InstrumentSerial != "07240205" || PublicClass.InstrumentSerial != "07240206" || PublicClass.InstrumentSerial != "07240207" || PublicClass.InstrumentSerial != "07240208" || PublicClass.InstrumentSerial != "07240209" || PublicClass.InstrumentSerial != "07240210" || PublicClass.InstrumentSerial != "07240211")
                    if (PublicClass.InstrumentSerial != "07241084" && PublicClass.InstrumentSerial != "05240179" && PublicClass.InstrumentSerial != "07000150" && PublicClass.InstrumentSerial != "07000037" && PublicClass.InstrumentSerial != "07240151" && PublicClass.InstrumentSerial != "07240177" && PublicClass.InstrumentSerial != "07240178" && PublicClass.InstrumentSerial != "07240179" && PublicClass.InstrumentSerial != "07240180" && PublicClass.InstrumentSerial != "07240181" && PublicClass.InstrumentSerial != "07240182" && PublicClass.InstrumentSerial != "07240183" && PublicClass.InstrumentSerial != "07240184" && PublicClass.InstrumentSerial != "07240185" && PublicClass.InstrumentSerial != "07240186" && PublicClass.InstrumentSerial != "07240187" && PublicClass.InstrumentSerial != "07240188" && PublicClass.InstrumentSerial != "07240189" && PublicClass.InstrumentSerial != "07240190" && PublicClass.InstrumentSerial != "07240191" && PublicClass.InstrumentSerial != "07240192" && PublicClass.InstrumentSerial != "07240193" && PublicClass.InstrumentSerial != "07240194" && PublicClass.InstrumentSerial != "07240195" && PublicClass.InstrumentSerial != "07240196" && PublicClass.InstrumentSerial != "07240197" && PublicClass.InstrumentSerial != "07240198" && PublicClass.InstrumentSerial != "07240199" && PublicClass.InstrumentSerial != "07240200" && PublicClass.InstrumentSerial != "07240201" && PublicClass.InstrumentSerial != "07240202" && PublicClass.InstrumentSerial != "07240203" && PublicClass.InstrumentSerial != "07240204" && PublicClass.InstrumentSerial != "07240205" && PublicClass.InstrumentSerial != "07240206" && PublicClass.InstrumentSerial != "07240207" && PublicClass.InstrumentSerial != "07240208" && PublicClass.InstrumentSerial != "07240209" && PublicClass.InstrumentSerial != "07240210" && PublicClass.InstrumentSerial != "07240211")
                    {
                        MessageBox.Show("You can not use other key! Please contact the Vendor", "Wrong Key Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Environment.Exit(1);
                    }
                }

                if (!bAcknowledge)
                {
                    m_objCSysPro.OpenFrm();
                }
                if (!bAcknowledge)
                {
                    KeyAttached = false;
                }
                else
                {
                    KeyAttached = true;
                }
            }
            catch { }
        }
        private bool m_bTryButtonClick = false;
        void m_objCSysPro_ExitButtonClicked()
        {
            try
            {
                m_bTryButtonClick = false;
                m_bDemoButtonClicked = false;
                Application.Exit();
            }
            catch (Exception ex)
            {
                Application.Exit();

            }
        }
        internal void EF()
        {
            EnableForm();
        }


        private void EnableForm()
        {
            try
            {
                this.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }

        void m_objCSysPro_DemoButtonClick()
        {
            try
            {
                m_bDemoButtonClicked = true;
                m_bTryButtonClick = false;

                //NewEnabled = false;
                //SDFGenerationEnabled = false;
                //OpenEnabled = false;

                //BackupEnabled = false;

                //ReportSettingEnabled = false;

                if (_objUserControl != null)
                {
                    //m_objMainControl.DemoButtonClicked = true;
                    //m_objMainControl.TryAndAck = false;
                    //m_objBaseFormWorker.DemoButtonClicked = true;
                    //m_objBaseFormWorker.TryAndAck = false;

                    if (m_bDemoButtonClicked && !m_bTryButtonClick)
                    {
                        //m_objMainControl.DisableCopyPaste();
                        //CheckConnectionStrings();
                        //if (m_objBaseFormWorker != null && MysqlFlag)
                        //{
                        //    m_objBaseFormWorker.OpenCurrentDataBase();
                        //}
                    }
                }

                //NewEnabled = false;
                //OpenEnabled = false;

                //BackupEnabled = false;

                //ReportSettingEnabled = false;

            }
            catch (Exception ex)
            {

            }
        }

        void m_objCSysPro_TryButtonClicked()
        {
            bool bTest = false;
            try
            {
                m_bDemoButtonClicked = false;
                m_bTryButtonClick = true;

                if (m_objCSysPro != null)
                    bTest = m_objCSysPro.Test();



                if (_objUserControl != null && bTest)
                {
                    if (CImageCreation.Vcode == null)
                    {
                        CImageCreation.Vcode = CSysPro.VCode;
                    }
                    try
                    {
                        this.Invoke(new ThreadStart(SetupToolMenu));
                    }
                    catch
                    {
                        SetupToolMenu();
                    }

                    // _objUserControl.TryAndAck = bTest;
                    // _objUserControl.DemoButtonClicked = false;

                    //m_objBaseFormWorker.DemoButtonClicked = false;
                    //m_objBaseFormWorker.TryAndAck = true;
                    //m_objMainControl.EnableCopyPaste();

                    //CheckConnectionStrings();
                    //if (m_objBaseFormWorker != null && MysqlFlag)
                    //{
                    //    m_objBaseFormWorker.OpenCurrentDataBase();
                    //}
                }
                if (bTest)
                {
                    try
                    {
                        this.Invoke(new ThreadStart(EnableForm));
                    }
                    catch
                    {
                        EnableForm();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SetupToolMenu()
        {
            string strinsName = PublicClass.currentInstrument;
            if (strinsName == null)
            {
                strinsName = " ";
            }
            string[] insName = strinsName.Split(new string[] { "|" }, StringSplitOptions.None);
            bool CheckIns = false;
            if (insName[0] == "Impaq-Benstone" || insName[0].Trim() == "SKF/DI" || insName[0].Trim() == "FieldPaq2" || insName[0].Trim() == "Kohtect-C911")
            {
                CheckIns = true;
            }
            if (CheckIns == false)
            {
                MessageBox.Show("You can not use other key! Please contact the Vendor", "Wrong Key Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(1);
            }
        }

        private void UsbController()
        {
            try
            {
                WqlEventQuery q;
                ManagementOperationObserver observer = new ManagementOperationObserver();
                ManagementScope scope = new ManagementScope("root\\CIMV2");
                scope.Options.EnablePrivileges = true;
                try
                {
                    q = new WqlEventQuery();
                    q.EventClassName = "__InstanceOperationEvent";
                    q.WithinInterval = new TimeSpan(0, 0, 3);
                    q.Condition = @"TargetInstance ISA 'Win32_USBControllerdevice' ";
                    w = new ManagementEventWatcher(scope, q);

                    w.EventArrived += new EventArrivedEventHandler(UsbEventArrived);
                    w.Start();
                }
                catch (Exception ex)
                {
                }
                finally
                {
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void UsbEventArrived(object sender, EventArrivedEventArgs e)
        {
            try
            {
                if (m_objHaspCheck.ThreadState == System.Threading.ThreadState.Stopped)
                {
                    m_objHaspCheck = new Thread(new ThreadStart(CheckHasp));
                    m_objHaspCheck.Start();
                }
            }
            catch
            {
            }
        }

        private delegate void ToOpenAdmin();
        private void CheckHasp()
        {
            try
            {
                frmHasp objNOhasp = new frmHasp();
                for (int i = 0; i < 1; i++)
                {
                    if (m_objCSysPro != null)
                    {
                        bAck = m_objCSysPro.Test();

                        if (bAck == true)
                        {
                            bOnce = true;
                            if (bNever || m_bDemoButtonClicked)
                            {
                                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "Kohtect-C911" || PublicClass.currentInstrument == "SKF/DI" || PublicClass.currentInstrument == "FieldPaq2")
                                {
                                    if (PublicClass.InstrumentSerial != "")
                                    {
                                        NotNow = false;
                                        this.Invoke(new ToOpenAdmin(FunctionForLogin));
                                        m_objCSysPro_TryButtonClicked();
                                        bNever = false;
                                    }
                                    else
                                    {
                                        if (PublicClass.currentInstrument == "SKF/DI" || PublicClass.currentInstrument == "Kohtect-C911")
                                        {
                                            NotNow = false;
                                            this.Invoke(new ToOpenAdmin(FunctionForLogin));
                                            m_objCSysPro_TryButtonClicked();
                                            bNever = false;
                                        }
                                        else
                                        {
                                            bNever = false;
                                            MessageBox.Show("You can not use other key! Please contact the Vendor", "Wrong Key Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                NotNow = true;
                            }
                            if (m_bDemoButtonClicked)
                            {

                            }
                        }
                        if (bAck == false)
                        {
                            bNever = true;
                            if (!m_bDemoButtonClicked)
                            {
                                this.Invoke(new ThreadStart(CallToTest));
                            }

                            m_objCSysPro.FromOtherThread = CValues.SCONSTFRMOTHTH;
                            if (!m_bDemoButtonClicked && bOnce)
                            {
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }


        public void SetButtons(string sGraphNametodraw, string sInstrumentname)
        {
            try
            {
                switch (sInstrumentname)
                {
                    case "DI-460":
                        {
                            break;
                        }
                    case "FieldPaq2":
                    case "Kohtect-C911":
                    case "Impaq-Benstone":
                        {
                            bboveralltype.Visibility = BarItemVisibility.Never;
                            bcmDirection.Visibility = BarItemVisibility.Always;
                            switch (sGraphNametodraw)
                            {
                                case "Time":
                                    {
                                        bbGraphBack.Enabled = true;
                                        bbGraphNext.Enabled = true;
                                        bbWaterfall.Enabled = false;
                                        bbArea.Enabled = true;
                                        bbTrend.Enabled = true;
                                        bbBand.Enabled = false;
                                        bbFaultFreq.Enabled = false;
                                        bbRPM.Enabled = false;
                                        bbBFF.Enabled = false;
                                        bbOctave.Enabled = false;
                                        bbdiagonostic.Enabled = false;
                                        btnFailureTime.Enabled = false;
                                        if (PublicClass.sensordirtype == "XYZ" || PublicClass.sensordirtype == "XY" || PublicClass.sensordirtype == "XZ")
                                        {
                                            bbOrbit.Enabled = true;
                                        }
                                        else
                                        {
                                            bbOrbit.Enabled = false;
                                        }
                                        bbSBRatio.Enabled = false;
                                        bbSBTrend.Enabled = false;
                                        bbSBValue.Enabled = false;
                                        bbDualGraph.Enabled = false;
                                        bbMultiGraph.Enabled = false;
                                        bcmDirection.Enabled = true;
                                        bbCepstrum.Enabled = true;
                                        bbChangeXUnit.Enabled = true;
                                        bbChangeYUnit.Enabled = true;
                                        IsOverallTrend = false;
                                        bbZoom.Enabled = true;
                                        bbUnzoom.Enabled = true;
                                        break;
                                    }
                                case "Power":
                                    {
                                        bbTrend.Enabled = true;
                                        bbArea.Enabled = true;
                                        bbWaterfall.Enabled = true;
                                        bbOrbit.Enabled = false;
                                        bbGraphBack.Enabled = true;
                                        bbGraphNext.Enabled = true;
                                        bbBand.Enabled = true;
                                        bbFaultFreq.Enabled = true;
                                        bbRPM.Enabled = true;
                                        bbBFF.Enabled = true;
                                        bbOctave.Enabled = false;
                                        bbSBRatio.Enabled = true;
                                        bbSBTrend.Enabled = true;
                                        bbSBValue.Enabled = true; ;
                                        bcmDirection.Enabled = true;
                                        bbChangeXUnit.Enabled = true;
                                        bbChangeYUnit.Enabled = true;
                                        bbdiagonostic.Enabled = false;
                                        btnFailureTime.Enabled = false;
                                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                                        {
                                            bbCepstrum.Enabled = true;
                                            bbDualGraph.Enabled = true;
                                        }
                                        else if (PublicClass.currentInstrument == "Kohtect-C911")
                                        {
                                            bboveralltype.Visibility = BarItemVisibility.Always;
                                        }
                                        else
                                        {
                                            bbDualGraph.Visibility = BarItemVisibility.Never;
                                            bbCepstrum.Visibility = BarItemVisibility.Never;
                                        }
                                        bbMultiGraph.Enabled = true;
                                        IsOverallTrend = false;
                                        bbZoom.Enabled = true;
                                        bbUnzoom.Enabled = true;
                                        break;
                                    }
                                case "Demodulate":
                                    {
                                        bbTrend.Enabled = true;
                                        bbDualGraph.Enabled = false;
                                        bbMultiGraph.Enabled = false;
                                        bbArea.Enabled = true;
                                        bbWaterfall.Enabled = true;
                                        bbOrbit.Enabled = false;
                                        bbGraphBack.Enabled = true;
                                        bbGraphNext.Enabled = true;
                                        bbBand.Enabled = true;
                                        bbFaultFreq.Enabled = true;
                                        bbRPM.Enabled = true;
                                        bbBFF.Enabled = true;
                                        bbOctave.Enabled = false;
                                        bbSBRatio.Enabled = true;
                                        bbSBTrend.Enabled = true;
                                        bbSBValue.Enabled = true;
                                        bcmDirection.Enabled = true;
                                        bbCepstrum.Enabled = true;
                                        bbChangeXUnit.Enabled = true;
                                        bbChangeYUnit.Enabled = true;
                                        IsOverallTrend = false;
                                        bbZoom.Enabled = true;
                                        bbUnzoom.Enabled = true;
                                        bbdiagonostic.Enabled = false;
                                        btnFailureTime.Enabled = false;
                                        break;
                                    }
                                case "Trend":
                                    {
                                        bbDualGraph.Enabled = false;
                                        bbMultiGraph.Enabled = false;
                                        bbTrend.Enabled = false;
                                        bbArea.Enabled = true;
                                        bbWaterfall.Enabled = false;
                                        bbOrbit.Enabled = false;
                                        bbGraphBack.Enabled = false;
                                        bbGraphNext.Enabled = false;
                                        bbBand.Enabled = false;
                                        bbFaultFreq.Enabled = false;
                                        bbRPM.Enabled = false;
                                        bbBFF.Enabled = false;
                                        bbOctave.Enabled = false;
                                        bbSBRatio.Enabled = false;
                                        bbSBTrend.Enabled = false;
                                        bbSBValue.Enabled = false;
                                        bcmDirection.Enabled = false;
                                        bbCepstrum.Enabled = false;
                                        bbChangeXUnit.Enabled = false;
                                        bbChangeYUnit.Enabled = false;
                                        IsOverallTrend = true;
                                        bbZoom.Enabled = false;
                                        bbUnzoom.Enabled = false;
                                        bbdiagonostic.Enabled = false;
                                        btnFailureTime.Enabled = true;
                                        break;
                                    }
                                case "Cepstrum":
                                    {
                                        bbTrend.Enabled = true;
                                        bbArea.Enabled = true;
                                        bbWaterfall.Enabled = true;
                                        bbOrbit.Enabled = false;
                                        bbGraphBack.Enabled = true;
                                        bbGraphNext.Enabled = true;
                                        bbBand.Enabled = true;
                                        bbFaultFreq.Enabled = true;
                                        bbRPM.Enabled = true;
                                        bbBFF.Enabled = true;
                                        bbOctave.Enabled = false;
                                        bbSBRatio.Enabled = true;
                                        bbSBTrend.Enabled = true;
                                        bbSBValue.Enabled = true;
                                        bcmDirection.Enabled = true;
                                        bbCepstrum.Enabled = true;
                                        bbChangeXUnit.Enabled = true;
                                        bbChangeYUnit.Enabled = true;
                                        bbDualGraph.Enabled = false;
                                        bbMultiGraph.Enabled = false;
                                        IsOverallTrend = false;
                                        bbZoom.Enabled = true;
                                        bbUnzoom.Enabled = true;
                                        bbdiagonostic.Enabled = false;
                                        btnFailureTime.Enabled = false;
                                        break;
                                    }
                                default:
                                    {
                                        bbTrend.Enabled = true;
                                        bbArea.Enabled = true;
                                        bbWaterfall.Enabled = true;
                                        bbOrbit.Enabled = false;
                                        bbGraphBack.Enabled = true;
                                        bbGraphNext.Enabled = true;
                                        bbBand.Enabled = true;
                                        bbFaultFreq.Enabled = true;
                                        bbRPM.Enabled = true;
                                        bbDualGraph.Enabled = true;
                                        bbMultiGraph.Enabled = true;
                                        bbBFF.Enabled = true;
                                        bbOctave.Enabled = false;
                                        bbSBRatio.Enabled = true;
                                        bbSBTrend.Enabled = true;
                                        bbSBValue.Enabled = true;
                                        bcmDirection.Enabled = true;
                                        bbCepstrum.Enabled = true;
                                        bbChangeXUnit.Enabled = true;
                                        bbChangeYUnit.Enabled = true;
                                        IsOverallTrend = false;
                                        bbZoom.Enabled = true;
                                        bbUnzoom.Enabled = true;
                                        bbdiagonostic.Enabled = false;
                                        btnFailureTime.Enabled = false;
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public string DirectionValue
        {
            get
            {
                return bcmDirection.EditValue.ToString();
            }
            set
            {
                bcmDirection.EditValue = value;
            }
        }

        string _EdittextDirection = null;
        public string EdittextDirection
        {
            get
            {
                return (string)bcmDirection.EditValue;
            }
            set
            {
                _EdittextDirection = value;
            }
        }
        public void SetUserTabpages()
        {
            try
            {
                if (PublicClass.cUserName == "admin" && PublicClass.cPassword == "admin")
                {
                    rpadmin.Visible = true;
                }
                else
                {
                    rpadmin.Visible = false;
                }

                DbClass.executequery(CommandType.Text, "Update userdetail set Login = '1' where ID = " + PublicClass.cUID + "");

                DataTable dt1 = new DataTable();
                dt1 = DbClass.getdata(CommandType.Text, "select TabName,Addition,Deletion,Modification,ReportView,UpDown,Other from usersettings where UserDetailID = '" + PublicClass.cUID + "' ");

                foreach (DataRow dr in dt1.Rows)
                {
                    string tName = Convert.ToString(dr["TabName"]);
                    int add = Convert.ToInt32(dr["Addition"]);
                    int del = Convert.ToInt32(dr["Deletion"]);
                    int mod = Convert.ToInt32(dr["Modification"]);
                    int rView = Convert.ToInt32(dr["ReportView"]);
                    int UD = Convert.ToInt32(dr["UpDown"]);
                    int None = Convert.ToInt32(dr["Other"]);

                    switch (tName)
                    {
                        case "Route":
                            {
                                if (None == 1)
                                {
                                    rpRoute.Visible = false;
                                }
                                else
                                {
                                    rpRoute.Visible = true;
                                }
                                break;
                            }

                        case "Reports":
                            {

                                if (rView == 1)
                                {
                                    rpgReports.Enabled = true;
                                }
                                else
                                {
                                    rpgReports.Enabled = false;
                                }
                                break;
                            }

                        //case "Alarms":
                        //    {
                        //        if (None == 1)
                        //        {
                        //            rpgAlarm.Enabled = false;
                        //        }
                        //        else
                        //        {
                        //            rpgAlarm.Enabled = true;
                        //        }

                        //        break;
                        //    }
                        case "Sensors":
                            {
                                if (None == 1)
                                {
                                    rpSensor.Visible = false;
                                }
                                else
                                {
                                    rpSensor.Visible = true;
                                }

                                break;
                            }
                        case "Point Type":
                            {
                                if (None == 1)
                                {
                                    rppointtype.Visible = false;
                                }
                                else
                                {
                                    rppointtype.Visible = true;
                                }

                                break;
                            }
                    }
                }
            }
            catch
            {
            }
        }

        string TrendType = null;
        public void ClearCmbCursor()
        {
            try
            {
                cmbCurSors.Items.Clear();
                repositoryItemComboBox2.Items.Clear();
            }
            catch (Exception ex)
            {
            }
        }
        double[] ExactBearingFF = null;
        public double[] _ExactBearingFF
        {
            get
            {
                return ExactBearingFF;
            }
            set
            {
                ExactBearingFF = value;
            }
        }

        public int SelectedRowIndex = 0;
        public int _SelectedRowIndex
        {
            get
            {
                return SelectedRowIndex;
            }
            set
            {
                SelectedRowIndex = value;
            }
        }
        bool bShowCursorVal = true;
        public bool _ShowCursorVal
        {
            get
            {
                return bShowCursorVal;
            }
            set
            {
                bShowCursorVal = value;
            }
        }
        bool IsOverallTrend = false;
        public bool _IsOverallTrend
        {
            get
            {
                return IsOverallTrend;
            }
            set
            {
                IsOverallTrend = value;
            }
        }

        int iBearingHarmonics = 1;
        BearingFF_Interface _BFFInterface = new BearingFF_Control();
        public ArrayList GetBearingFaultFrequencies(string spointid)
        {
            string BDIR = "1";
            string BDOR = "10";
            string BCA = "1";
            string BDRE = "1";
            string BNRE = "1";
            string Manufacture = "0";
            string BearingNumber = "0";
            string _BPFO = null;
            string _BPFI = null;
            string _BSF = null;
            string _FTF = null;
            string Sstatus = null;
            ArrayList BearingFaultFrequencies = new ArrayList();
            try
            {
                DataTable dt = DbClass.getdata(CommandType.Text, "select * from point_bearing where Point_ID='" + spointid + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    _BPFO = dr["BPFO"].ToString();
                    _BPFI = dr["BPFI"].ToString();
                    _BSF = dr["BSF"].ToString();
                    _FTF = dr["FTF"].ToString();
                    Sstatus = dr["Status"].ToString();
                }
                double NumberOfBalls = Convert.ToDouble(BNRE.ToString());
                double BearingPitchDiameter = Convert.ToDouble(((Convert.ToDouble(BDIR.ToString()) + Convert.ToDouble(BDOR.ToString())) / 2));
                double RollingElementDiameter = Convert.ToDouble(BDRE.ToString());
                double ContactAngle = Convert.ToDouble(BCA.ToString());
                double ShaftSpeed = 0;

                if (chkBFFOverride.Checked)
                {
                    ShaftSpeed = Convert.ToDouble(_LineGraph._BearingFFOverridenRPM);
                    if (CurrentXLabel == "Hz")
                    {
                        ShaftSpeed = ShaftSpeed * 60;
                    }
                }
                else
                {
                    string[] RPMValues = _objUserControl.GetRPMValues(PublicClass.SMachineID);
                    int iRPM = Convert.ToInt32(RPMValues[0]);
                    int iPulse = Convert.ToInt32(RPMValues[1]);
                    ShaftSpeed = (double)((double)iRPM / (double)(iPulse));
                }

                if (Sstatus == "true")
                {
                    BearingFaultFrequencies = _BFFInterface.CalculateBearingFaultFrequencies(ShaftSpeed, NumberOfBalls, BearingPitchDiameter, RollingElementDiameter, ContactAngle);
                }
                else
                {
                    BearingFaultFrequencies.Add("BPFO = " + Convert.ToString(Convert.ToDouble(Convert.ToDouble(_BPFO.ToString()) * ShaftSpeed) / 60));
                    BearingFaultFrequencies.Add("BPFI = " + Convert.ToString(Convert.ToDouble(Convert.ToDouble(_BPFI.ToString()) * ShaftSpeed) / 60));
                    BearingFaultFrequencies.Add("BSF = " + Convert.ToString(Convert.ToDouble(Convert.ToDouble(_BSF.ToString()) * ShaftSpeed) / 60));
                    BearingFaultFrequencies.Add("FTF = " + Convert.ToString(Convert.ToDouble(Convert.ToDouble(_FTF.ToString()) * ShaftSpeed) / 60));
                }

                for (int i = 0; i < 4; i++)
                {
                    string[] ExtractFreqSingle = BearingFaultFrequencies[i].ToString().Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    double Comparator = Convert.ToDouble(ExtractFreqSingle[1]);
                    double dcomp = Comparator;

                    for (int j = 0; j < iBearingHarmonics - 1; j++)
                    {
                        Comparator = dcomp * (j + 2);
                        BearingFaultFrequencies.Add(ExtractFreqSingle[0].ToString() + Convert.ToString(j + 2) + "x =" + Comparator.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return BearingFaultFrequencies;
        }
        public string TrendRatio
        {
            get
            {
                return tbSideBandRatio.Text.ToString();
            }
            set
            {
                tbSideBandRatio.Text = value;
                bbSBRatio.SuperTip.Items.Clear();
                bbSBRatio.SuperTip.Items.AddTitle((string)tbSideBandRatio.Text);
            }

        }

        public string SBValue
        {
            get
            {
                return tbSideBandPercentage.Text.ToString();
            }
            set
            {
                tbSideBandPercentage.Text = value;
                bbSBValue.SuperTip.Items.Clear();
                bbSBValue.SuperTip.Items.AddTitle((string)tbSideBandPercentage.Text);
            }
        }

        bool _BearingFaultFrequency = false;
        public bool BearingFaultFrequency
        {
            get
            {
                return _BearingFaultFrequency;
            }
            set
            {
                _BearingFaultFrequency = value;
                if (_BearingFaultFrequency)
                {
                    chkBFFOverride.Visibility = BarItemVisibility.Always;
                    barEditBearingHarmonics.Visibility = BarItemVisibility.Always;
                    chkBFFOverride.Checked = false;
                }
                else
                {
                    chkBFFOverride.Visibility = BarItemVisibility.Never;
                    barEditBearingHarmonics.Visibility = BarItemVisibility.Never;
                }
            }
        }

        public void setgraphCombo()
        {
            try
            {
                repositoryItemComboBox15.Items.Clear();
                ArrayList CursorItems = new ArrayList();
                if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    CursorItems.Add("Power Spectrum Channel1");
                    CursorItems.Add("Power Spectrum Channel2");
                }
                else
                {
                    CursorItems.Add("Time Channel1");
                    CursorItems.Add("Time Channel2");
                    //CursorItems.Add("TWF To FFT Channel1");
                    //CursorItems.Add("TWF To FFT Channel2");
                    CursorItems.Add("Power Spectrum Channel1");
                    CursorItems.Add("Power Spectrum Channel2");
                }
                for (int i = 0; i < CursorItems.Count; i++)
                {
                    repositoryItemComboBox15.Items.Add((object)CursorItems[i].ToString());
                }
            }
            catch { }
        }

        public void setCursorCombo(string sCG)
        {
            try
            {
                if (PublicClass.chkcurrent != null)
                {
                    sCG = "Current";
                }
                TrendType = sCG;
                ClearCmbCursor();
                if (sCG == "Time" || sCG == "Trend")
                {
                    ArrayList CursorItems = new ArrayList();
                    CursorItems.Add("Select Cursor");
                    CursorItems.Add("Single");
                    CursorItems.Add("Single With Square");
                    CursorItems.Add("Cross Hair");
                    CursorItems.Add("Delta Cursors");
                    AddToCmbCursor(CursorItems);
                }
                else if (sCG == "Trending")
                {
                    ArrayList CursorItems = new ArrayList();
                    CursorItems.Add("Select Cursor");
                    CursorItems.Add("Single");
                    CursorItems.Add("Single With Square");
                    CursorItems.Add("Cross Hair");
                    AddToCmbCursor(CursorItems);
                }
                else if (sCG == "Current")
                {
                    ArrayList CursorItems = new ArrayList();
                    CursorItems.Add("Select Cursor");
                    CursorItems.Add("Single");
                    CursorItems.Add("Single With Square");
                    CursorItems.Add("Line");
                    CursorItems.Add("Line With SideBand");
                    AddToCmbCursor(CursorItems);
                    bbSBTrend.Enabled = false;
                    bbSBRatio.Enabled = false;
                    bbSBValue.Enabled = false;
                }
                else
                {
                    ArrayList CursorItems = new ArrayList();
                    CursorItems.Add("Select Cursor");
                    CursorItems.Add("Single");
                    CursorItems.Add("Harmonic");
                    CursorItems.Add("Single With Square");
                    CursorItems.Add("Cross Hair");
                    CursorItems.Add("Sideband");
                    CursorItems.Add("SidebandRatio");
                    CursorItems.Add("SideBandTrend");
                    CursorItems.Add("PeekCursor");
                    CursorItems.Add("Delta Cursors");
                    CursorItems.Add("Kill Cursor");
                    CursorItems.Add("Highest 10 Peeks");
                    CursorItems.Add("Refrence Cursor");
                    AddToCmbCursor(CursorItems);
                }
                string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                CmbCursorSelectedItem(SelectedCursorItem);
            }
            catch (Exception ex)
            {

            }
        }

        public void CmbCursorSelectedItem(string SelectedEditValue)
        {
            try
            {
                cmbCurSors.SelectedItem = SelectedEditValue;
                bcmCursors.EditValue = SelectedEditValue;
            }
            catch (Exception ex)
            {
            }
        }

        public void AddToCmbCursor(ArrayList CursorItems)
        {
            try
            {
                for (int i = 0; i < CursorItems.Count; i++)
                {
                    cmbCurSors.Items.Add((object)CursorItems[i].ToString());
                    repositoryItemComboBox2.Items.Add((object)CursorItems[i].ToString());
                }
            }
            catch (Exception ex)
            {
            }
        }

        public IadeptUserControl usercontrol
        {
            get
            {
                return _objUserControl;
            }
            set
            {
                _objUserControl = value;
            }
        }

        private void IntializeAllObjects()
        {
            try
            {
                _objUserControl = new IadeptUserControl();
                _objUserControl.MainForm = this;

                m_PointGeneral1 = new PointGeneral1();
                m_PointGeneral1.MainForm1 = this;
                _objUserControl.pg = m_PointGeneral1;

                objGcontrol = new frmGControls();
                objGcontrol.MainForm = this;
                _objUserControl.graphcontrol1 = objGcontrol;
                _objUserControl.activateobjects();
                _LineGraph.LineChartView = new ChartView();
            }
            catch
            {
            }
        }

        public bool IsFindClosed
        {
            get
            {
                return bFindClosed;
            }
            set
            {
                bFindClosed = value;
            }
        }

        public bool IsFindReplaceClosed
        {
            get
            {
                return bFRClosed;
            }
            set
            {
                bFRClosed = value;
            }
        }
        private void CallToTest()
        {
            try
            {
                this.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }

        private void bbNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Open New Database Creation Form";
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select UserName , Password from userdetail where ID = '1' ");
                string Name = dt.Rows[0]["UserName"].ToString();
                string Passwd = dt.Rows[0]["Password"].ToString();
                if (PublicClass.cUserName != Name.Trim() && PublicClass.cPassword != Passwd.Trim())
                {
                    MessageBox.Show(this, "You are not allowed to create database", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                Iadeptmain.Mainforms.frmNewDataBaseCreation aa = new Iadeptmain.Mainforms.frmNewDataBaseCreation();
                aa.ShowDialog();
                color();
                ribbonPageCategory1.Text = "Selected DataBase: " + Iadeptmain.GlobalClasses.PublicClass.User_DataBase;
                try
                {
                    if (Iadeptmain.GlobalClasses.PublicClass.LoginStatus == false)
                    {
                        this.Dispose();
                    }
                    else
                    {
                        SetUserTabpages();
                        if (PublicClass.currentInstrument == "SKF/DI" || PublicClass.currentInstrument == "Kohtect-C911")
                        { rpSensor.Visible = false; ribbonPageGroup3.Visible = false; rpdashboard.Visible = false; }
                        ssStatus.Text = "User Name= " + Iadeptmain.GlobalClasses.PublicClass.User_Name.Trim() + " and IPAddress= " + Iadeptmain.GlobalClasses.PublicClass.User_IP.Trim() + "  ";
                    }
                    if (aa.check == true && aa.checkstatus == true)
                    {
                        fillform();
                        lblStatus.Caption = "Status: Database Created Successfully";
                    }
                }
                catch { }

            }
            catch (Exception ex) { Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name); }

        }
        private void ShowSplashExample()
        {
            try
            {
                frmsplash1 frmsplash = new frmsplash1();
                frmsplash.ShowDialog();
            }
            catch { }
        }

        public void fillform()
        {
            try
            {
                lblStatus.Caption = "Ready";
                panelControl2.Visible = true;
                pnl3.Visible = false;
                _objUserControl.MdiParent = this;
                _objUserControl.MainForm = this;
                panelControl2.Controls.Clear();
                panelControl2.Controls.Add(_objUserControl);
                panelControl2.Dock = DockStyle.Fill;
                _objUserControl.Dock = DockStyle.Fill;
                if (_objUserControl.IsDisposed)
                {
                    _objUserControl = new IadeptUserControl();
                    panelControl2.Visible = true;
                    pnl3.Visible = false;
                    _objUserControl.MdiParent = this;
                    _objUserControl.MainForm = this;
                    panelControl2.Controls.Clear();
                    panelControl2.Controls.Add(_objUserControl);
                    panelControl2.Dock = DockStyle.Fill;
                    _objUserControl.Dock = DockStyle.Fill;
                    _objUserControl.Show();
                    if (PublicClass.flagAlarm)
                    {
                        _objUserControl.filltreelist();
                        // _objUserControl.filltreelistDownload(PublicClass.pointIDs);
                        DataTable dtFact = DbClass.getdata(CommandType.Text, "Select Name , Description from factory_info where Factory_ID in(Select min(Factory_ID) from factory_info)");
                        try
                        {
                            if (dtFact.Rows.Count > 0)
                            {
                                _objUserControl.txtfactoryname.Text = Convert.ToString(dtFact.Rows[0]["Name"]);
                                _objUserControl.TxtDetail.Text = Convert.ToString(dtFact.Rows[0]["Description"]);
                            }
                            else
                            {
                                _objUserControl.txtfactoryname.Text = "Plant";
                                _objUserControl.TxtDetail.Text = "";
                            }
                        }
                        catch
                        { }
                        _objUserControl.CtrTab.SelectedTabPageIndex = 0;
                        PublicClass.flagAlarm = false;
                    }
                    _objUserControl.sNodeType = null;
                    if (_objUserControl.sNodeType == "Plant")
                    {
                        _objUserControl.visbilty(_objUserControl.sNodeType);
                        _objUserControl.trlPlantManger.FocusedNode = _objUserControl.trlPlantManger.Nodes[0];
                    }
                    else
                    {
                        _objUserControl.sNodeType = "Plant";
                        _objUserControl.visbilty(_objUserControl.sNodeType);
                        _objUserControl.trlPlantManger.FocusedNode = _objUserControl.trlPlantManger.Nodes[0];
                    }
                }
                else
                {
                    _objUserControl.Show();
                    if (PublicClass.flagAlarm)
                    {
                        _objUserControl.filltreelist();
                        // _objUserControl.filltreelistDownload(PublicClass.pointIDs);
                        DataTable dtFact = DbClass.getdata(CommandType.Text, "Select Name , Description from factory_info where Factory_ID in(Select min(Factory_ID) from factory_info)");
                        try
                        {
                            if (dtFact.Rows.Count > 0)
                            {
                                _objUserControl.txtfactoryname.Text = Convert.ToString(dtFact.Rows[0]["Name"]);
                                _objUserControl.TxtDetail.Text = Convert.ToString(dtFact.Rows[0]["Description"]);
                            }
                            else
                            {
                                _objUserControl.txtfactoryname.Text = "Plant";
                                _objUserControl.TxtDetail.Text = "";
                            }
                        }
                        catch
                        { }
                        _objUserControl.CtrTab.SelectedTabPageIndex = 0;
                        PublicClass.flagAlarm = false;
                    }

                    //_objUserControl.sNodeType = null;
                    if (_objUserControl.sNodeType == "Plant" || _objUserControl.sNodeType == "Area" || _objUserControl.sNodeType == "Train" || _objUserControl.sNodeType == "Machine" || _objUserControl.sNodeType == "Point")
                    {
                        // _objUserControl.trlPlantManger.FocusedNode = 
                        _objUserControl.visbilty(_objUserControl.sNodeType);
                        _objUserControl.trlPlantManger.FocusedNode = _objUserControl.trlPlantManger.Nodes[0];
                    }
                    else
                    {
                        _objUserControl.sNodeType = "Plant";
                        _objUserControl.visbilty(_objUserControl.sNodeType);
                        _objUserControl.trlPlantManger.FocusedNode = _objUserControl.trlPlantManger.Nodes[0];

                    }
                }
            }
            catch
            {
            }
        }

        public void ChangeFontStyle(string FontStyleName)
        {
            float s = 10;
            try
            {
                switch (FontStyleName)
                {
                    case "Arial":
                        {
                            var f = DevExpress.Utils.AppearanceObject.DefaultFont;
                            DevExpress.Utils.AppearanceObject.DefaultFont = new Font(FontStyleName, s);
                            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
                            break;
                        }
                    case "Times New Roman":
                        {
                            var f = DevExpress.Utils.AppearanceObject.DefaultFont;
                            DevExpress.Utils.AppearanceObject.DefaultFont = new Font(FontStyleName, s);
                            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
                            break;
                        }
                    case "Buxton sketch":
                        {
                            var f = DevExpress.Utils.AppearanceObject.DefaultFont;
                            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font(FontStyleName, s);
                            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
                            break;
                        }
                    case "Georgia":
                        {
                            var f = DevExpress.Utils.AppearanceObject.DefaultFont;
                            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font(FontStyleName, s);
                            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
                            break;
                        }
                    case "Segoe Script":
                        {
                            var f = DevExpress.Utils.AppearanceObject.DefaultFont;
                            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font(FontStyleName, s);
                            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
                            break;
                        }
                }
            }
            catch { }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ToolStripComboBox comboBox = sender as ToolStripComboBox;
                string skinName = comboBox.Text;
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skinName;
            }
            catch (Exception ex)
            {
            }
        }

        internal void DisSave()
        {
            savebutton = false;
        }

        public bool savebutton
        {
            get
            {
                return IsSaveEnabled;
            }
            set
            {
                saveToolStripMenuItem.Enabled = value;
                saveToolStripButton.Enabled = value;
            }
        }

        public void checkform()
        {

            try
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (Convert.ToString(f.Name).Trim() != "frmIAdeptMain" && Convert.ToString(f.Name).Trim() != "frmIAdeptMain")
                    {
                        f.Close();
                    }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void barEditItem11_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                PublicClass.fontStyle = barEditItem11.EditValue.ToString();
                ChangeFontStyle(PublicClass.fontStyle);
            }
            catch { }
        }

        public void color()
        {
            try
            {
                DataTable dtDesign = DbClass.getdata(CommandType.Text, "select * from proj_design where UserName = '" + PublicClass.cUserName + "' and Password = '" + PublicClass.cPassword + "'");
                if (dtDesign.Rows.Count > 0)
                {
                    PublicClass.designStyle = Convert.ToString(dtDesign.Rows[0]["pDesign"]);
                    if (PublicClass.designStyle == "")
                    {
                        defaultcolor();
                    }
                    else
                    { changestyle(PublicClass.designStyle); }
                    PublicClass.ColorStyle = Convert.ToString(dtDesign.Rows[0]["pColor"]);
                    PublicClass.fontStyle = Convert.ToString(dtDesign.Rows[0]["pFont"]);
                    barcolor(PublicClass.ColorStyle);
                    ChangeFontStyle(PublicClass.fontStyle);
                }
                else
                {
                    defaultcolor();
                }
            }
            catch { }
        }

        public Process objStartProcess { get; set; }

        private void bbOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Opening Existing Database Form";
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select UserName , Password from userdetail where ID = '1' ");
                string Name = dt.Rows[0]["UserName"].ToString();
                string Passwd = dt.Rows[0]["Password"].ToString();
                if (PublicClass.cUserName != Name.Trim() && PublicClass.cPassword != Passwd.Trim())
                {
                    MessageBox.Show(this, "You are not allowed to change database", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Iadeptmain.Mainforms.FrmOpenDatabase aa = new Iadeptmain.Mainforms.FrmOpenDatabase();
                aa.ShowDialog();
                color();
                ribbonPageCategory1.Text = "Selected DataBase: " + Iadeptmain.GlobalClasses.PublicClass.User_DataBase;
                try
                {
                    if (Iadeptmain.GlobalClasses.PublicClass.LoginStatus == false)
                    {
                        this.Dispose();
                    }
                    else
                    {
                        SetUserTabpages();
                        if (PublicClass.currentInstrument == "SKF/DI" || PublicClass.currentInstrument == "Kohtect-C911")
                        { rpSensor.Visible = false; ribbonPageGroup3.Visible = false; rpdashboard.Visible = false; }
                        ssStatus.Text = "User Name= " + Iadeptmain.GlobalClasses.PublicClass.User_Name.Trim() + " and IPAddress= " + Iadeptmain.GlobalClasses.PublicClass.User_IP.Trim() + "  ";
                    }
                    if (aa.check1 == true)
                    {
                        SplashScreenManager.ShowForm(typeof(WaitForm2));
                        fillform();
                        SplashScreenManager.CloseForm();
                        lblStatus.Caption = "Status: Database Selecting Successfully";
                    }
                }
                catch { SplashScreenManager.CloseForm(); }

            }
            catch { }
        }

        private void bbLast_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                LastRdToolStripButton_Click(sender, e);
            }
            catch (Exception ex)
            {
            }
        }

        private void LastRdToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                _objUserControl.MoveLast();
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        public void changestyle(string style)
        {
            try
            {
                _objUserControl = new IadeptUserControl();
                string skinName = style;

                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skinName;
                DevExpress.Skins.SkinManager.EnableFormSkins();
                _objUserControl.ChangeStyle(skinName);
                ribbonPageCategory1.Color = Color.FromKnownColor(KnownColor.Transparent);
            }
            catch (Exception ex)
            {
                //Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
            }

        }

        private void barStyle_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BarEditItem comboBox = sender as BarEditItem;
                PublicClass.designStyle = comboBox.EditValue.ToString();
                changestyle(PublicClass.designStyle);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        public void defaultcolor()
        {
            try
            {
                string skinName = "Glass Oceans";
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skinName;
                DevExpress.Skins.SkinManager.EnableFormSkins();
            }
            catch { }
        }


        public string ARGBValues
        {
            get
            {
                return sARGB;
            }
            set
            {
                sARGB = value;
            }


        }

        public void barcolor(string color)
        {
            try
            {
                string colortext = color;
                sARGB = colortext;
                string[] RGBValue = colortext.Split(new string[] { ",", "[", "]", "A=", "R=", "G=", "B=", "=", " " }, StringSplitOptions.RemoveEmptyEntries);
                if (RGBValue.Length > 4)
                {
                    int A = Convert.ToInt32(RGBValue[1].ToString());
                    int R = Convert.ToInt32(RGBValue[2].ToString());
                    int G = Convert.ToInt32(RGBValue[3].ToString());
                    int B = Convert.ToInt32(RGBValue[4].ToString());

                    _objUserControl.ChangeColorStyle(A, R, G, B);

                    ribbonPageCategory1.Color = Color.FromArgb(A, R, G, B);
                    panelControl2.BackColor = Color.FromArgb(A, R, G, B);
                    pnl3.BackColor = Color.FromArgb(A, R, G, B);

                }
                else if (RGBValue.Length > 1)
                {
                    string Name = RGBValue[1].ToString();
                    _objUserControl.ChangeColorStyle(Name);
                    ribbonPageCategory1.Color = Color.FromName(Name);

                    panelControl2.BackColor = Color.FromName(Name);
                    pnl3.BackColor = Color.FromName(Name);
                }
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void barColor_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                BarEditItem comboBox = sender as BarEditItem;
                PublicClass.ColorStyle = comboBox.EditValue.ToString();
                barcolor(PublicClass.ColorStyle);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void barSensor_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Opening Sensor Form";
                Sensor sen = new Sensor();
                sen.ShowDialog();
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void barSensorType_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Opening Sensor Type";
                Sensor_Type st = new Sensor_Type();
                st.ShowDialog();
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void barSensorManufacture_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Opening Sensor Manufacture";
                Sensor_Manufacture sm = new Sensor_Manufacture();
                sm.ShowDialog();
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void bbCrtFactory_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Create New Factory";
                _objUserControl.LevelModify = false;
                tsbtnInsert_Click(sender, e);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        public string ConnecStr
        {
            get
            {
                return ConnectionStr;
            }
            set
            {
                ConnectionStr = value;
            }
        }

        public bool InsertFactory
        {
            get
            {
                return factoryTSMI.Enabled;
            }
            set
            {
                factoryTSMI.Enabled = value;
                bbCrtFactory.Enabled = value;
            }
        }

        public bool InsertResource
        {
            get
            {
                return resourceTSMI.Enabled;
            }
            set
            {
                resourceTSMI.Enabled = value; bbCrtResource.Enabled = value;
                selectedToolStripMenuItem.Enabled = value;
            }
        }
        public bool InsertElement
        {
            get
            {
                return elementTSMI.Enabled;
            }
            set
            {
                elementTSMI.Enabled = value;
                DelResource.Enabled = value;
                bbCrtElement.Enabled = value;
            }
        }
        public bool InsertSubElement
        {
            get
            {
                return subElementTSMI.Enabled;
            }
            set
            {
                subElementTSMI.Enabled = value;
                DelElement.Enabled = value;
                bbCrtSubElement.Enabled = value;
            }
        }
        public bool InsertPoint
        {
            get
            {
                return pointTSMI.Enabled;
            }
            set
            {
                pointTSMI.Enabled = value;
                bbCrtPoint.Enabled = value;
            }
        }

        public bool InsertFactoryButton
        {
            get
            {
                return tsbtnInsert.Enabled;
            }
            set
            {
                tsbtnInsert.Enabled = value;
                bbCrtFactory.Enabled = value;
            }
        }

        public bool InsertResourceButton
        {
            get
            {
                return btnInstRes.Enabled;
            }
            set
            {
                btnInstRes.Enabled = value;
                bbCrtResource.Enabled = value;
            }
        }
        public bool InsertElementButton
        {
            get
            {
                return btnInstElmnt.Enabled;
            }
            set
            {
                btnInstElmnt.Enabled = value;
                bbCrtElement.Enabled = value;
            }

        }
        public bool InsertSubElementButton
        {
            get
            {
                return btnInstSbElmnt.Enabled;
            }
            set
            {
                btnInstSbElmnt.Enabled = value;
                bbCrtSubElement.Enabled = value;
            }
        }
        public bool DeleteElement
        {
            set
            {
                DelElement.Enabled = value;
            }
        }

        public bool DeleteResource
        {
            set
            {
                DelResource.Enabled = value;
            }
        }
        public bool InsertPointButton
        {
            get
            {
                return btnInstPoint.Enabled;
            }
            set
            {
                btnInstPoint.Enabled = value;
                bbCrtPoint.Enabled = value;
            }
        }

        private string names = null;

        public string RibbonPageCategoryText
        {
            get
            {
                return ribbonPageCategory1.Text;
            }
            set
            {
                ribbonPageCategory1.Text = "Selected DataBase: " + value;
            }
        }

        public bool DeleteFactory
        {
            set
            {
                selectedToolStripMenuItem.Enabled = value;
            }
        }
        public bool DeleteSubEl
        {
            set
            {
                DelSubElement.Enabled = value;
            }
        }
        public string _XUnit
        {
            get
            {
                return XUnit;
            }
            set
            {
                XUnit = value;
            }
        }
        public string _YUnit
        {
            get
            {
                return YUnit;
            }
            set
            {
                YUnit = value;
            }
        }
        public frmIAdeptMain _MainForm
        {
            get
            {
                return MainForm;
            }
            set
            {
                MainForm = value;
            }
        }
        public Color _GraphBG1
        {
            get
            {
                return GraphBG1;
            }
            set
            {
                GraphBG1 = value;
            }
        }
        public Color _GraphBG2
        {
            get
            {
                return GraphBG2;
            }
            set
            {
                GraphBG2 = value;
            }
        }
        public int _GraphBGDir
        {
            get
            {
                return GraphBGDir;
            }
            set
            {
                GraphBGDir = value;
            }
        }
        public Color _ChartBG1
        {
            get
            {
                return ChartBG1;
            }
            set
            {
                ChartBG1 = value;
            }
        }
        public Color _ChartBG2
        {
            get
            {
                return ChartBG2;
            }
            set
            {
                ChartBG2 = value;
            }
        }
        public int _ChartBGDir
        {
            get
            {
                return ChartBGDir;
            }
            set
            {
                ChartBGDir = value;
            }
        }

        private void RemovePreviousGraphControl()
        {
            try
            {
                int iControlCount = objGcontrol.panel1.Controls.Count;
                int[] graphcontrolIndex = new int[0];
                for (int i = 0; i < iControlCount; i++)
                {
                    if (objGcontrol.panel1.Controls[i].Name.Contains("Graph"))
                    {
                        objGcontrol.panel1.Controls.Remove(objGcontrol.panel1.Controls[i]);
                        i--;
                        iControlCount--;
                    }
                }
                _LineGraph = null;
                _OrbitGraph = null;

                _BarGraph = null;
                _3DGraph = null;

            }
            catch (Exception ex)
            {
            }
        }

        public ChartView _ChartViewDI = new ChartView();
        public void DrawLineGraphsforDi(double[] xData, double[] yData, string XLabel, string YLabel)
        {
            try
            {
                if (_LineGraph == null)
                {
                    _LineGraph = new LineGraphControl();
                    _LineGraph.Name = "LineGraph 1";
                }
                _LineGraph._MainForm = this;
                _LineGraph._XLabel = XLabel;
                _LineGraph._YLabel = YLabel;
                _LineGraph.Dock = DockStyle.Fill;
                if (PublicClass.checkgraph == true)
                {
                    ribbonControl1.SelectedPage = rpGraph;
                    _LineGraph.DrawLineGraph(xData, yData);
                    objGcontrol.panel1.Controls.Add(_LineGraph);

                }
                else
                {
                    _LineGraph.DrawLineGraph(xData, yData);
                    _ChartViewDI = _LineGraph.LineChartView;
                }
            }
            catch { }
        }

        public void DrawLineGraphs(double[] xData, double[] yData, string XLabel, string YLabel)
        {
            try
            {
                RemovePreviousGraphControl();
                if (_LineGraph == null)
                {
                    _LineGraph = new LineGraphControl();
                    _LineGraph.Name = "LineGraph 1";
                }
                _LineGraph._MainForm = this;
                _LineGraph._XLabel = XLabel;
                _LineGraph._YLabel = YLabel;
                if (wavnode == null)
                {
                    DataTable dt = new DataTable();
                    dt = DbClass.getdata(CommandType.Text, "select fac.Name,ar.Name,tra.Name,mac.Name,pp.PointName from point pp inner join machine_info mac on mac.Machine_ID=pp.Machine_ID left join train_info tra on tra.Train_ID=mac.TrainID left join area_info ar on ar.Area_ID=tra.Area_ID left join factory_info fac on fac.Factory_ID=ar.FactoryID where Point_ID='" + PublicClass.SPointID + "'");
                    foreach (DataRow rd in dt.Rows)
                    {
                        fac = Convert.ToString(rd["Name"]);
                        are = Convert.ToString(rd["Name1"]);
                        tra = Convert.ToString(rd["Name2"]);
                        mac = Convert.ToString(rd["Name3"]);
                        pp = Convert.ToString(rd["PointName"]);
                    }
                    string showhierchy = fac + " --> " + are + " --> " + tra + " --> " + mac + " --> " + pp;
                    string demOverall = GetImpaqOverall();
                    PublicClass.footername = showhierchy + "\n" + "Overall : " + demOverall;
                    PublicClass.Chart_Footer = showhierchy + "\n" + "Overall : " + demOverall;
                }
                _LineGraph._ChartFooter = ChartFooter;
                _LineGraph._GraphBG1 = _GraphBG1;
                _LineGraph._GraphBG2 = _GraphBG2;
                _LineGraph._GraphBGDir = _GraphBGDir;
                _LineGraph._ChartBG1 = _ChartBG1;
                _LineGraph._ChartBG2 = _ChartBG2;
                _LineGraph._ChartBGDir = _ChartBGDir;
                _LineGraph._AxisColor = _AxisColor;
                _LineGraph._MainCursorColor = _MainCursorColor;
                _LineGraph.Dock = DockStyle.Fill;
                _LineGraph.DrawLineGraph(xData, yData);
                objGcontrol.panel1.Controls.Add(_LineGraph);

            }
            catch (Exception ex)
            {
            }
        }

        //void PerformShowLabelsAction()
        //{
        //    Series.LabelsVisibility = cbShowLabels.Checked ? DefaultBoolean.True : DefaultBoolean.False;
        //    WebChartControl1.ToolTipEnabled = cbShowLabels.Checked ? DefaultBoolean.False : DefaultBoolean.True;
        //}

        int someInt;
        public void test(double[] Phasevalue)
        {
            ChartControl RadarPointChart = new ChartControl();

            // Add a radar series to it.
            Series series1 = new Series("Series 1", ViewType.PolarArea);

            // Populate the series with points.

            for (int i = 0; i < Phasevalue.Length; i++)
            {
                if (Phasevalue[i] >= 0 && Phasevalue[i] < 90)
                {
                    someInt = 0;
                    someInt = Convert.ToInt32(Phasevalue[i]);
                    series1.Points.Add(new SeriesPoint(someInt, Phasevalue[i]));
                }
                if (Phasevalue[i] >= 90 && Phasevalue[i] < 180)
                {
                    someInt = 0;
                    someInt = Convert.ToInt32(Phasevalue[i]);
                    series1.Points.Add(new SeriesPoint(someInt, Phasevalue[i]));
                }
                if (Phasevalue[i] >= 180 && Phasevalue[i] < 270)
                {
                    someInt = 0;
                    someInt = Convert.ToInt32(Phasevalue[i]);
                    series1.Points.Add(new SeriesPoint(someInt, Phasevalue[i]));
                }
                if (Phasevalue[i] >= 270 && Phasevalue[i] < 360)
                {
                    someInt = 0;
                    someInt = Convert.ToInt32(Phasevalue[i]);
                    series1.Points.Add(new SeriesPoint(someInt, Phasevalue[i]));
                }
            }
            // Add the series to the chart.
            if (PublicClass.checkphase == "true")
            {
                RadarPointChart.Series.Add(series1);
                // Flip the diagram (if necessary).
                ((RadarDiagram)RadarPointChart.Diagram).DrawingStyle = RadarDiagramDrawingStyle.Circle;
                ((PolarDiagram)RadarPointChart.Diagram).StartAngleInDegrees = 0;
                ((PolarDiagram)RadarPointChart.Diagram).RotationDirection =
                    RadarDiagramRotationDirection.Counterclockwise;

                //foreach (Series series in WebChartControl1.Series)
                //    series.LabelsVisibility = cbShowLabels.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                //WebChartControl1.ToolTipEnabled = cbShowLabels.Checked ? DefaultBoolean.False : DefaultBoolean.True;
            }
            else
            {
                RadarPointChart.Series.Add(series1);
                // Flip the diagram (if necessary).
                ((RadarDiagram)RadarPointChart.Diagram).DrawingStyle = RadarDiagramDrawingStyle.Circle;
                ((PolarDiagram)RadarPointChart.Diagram).StartAngleInDegrees = 270;
                ((PolarDiagram)RadarPointChart.Diagram).RotationDirection =
                    RadarDiagramRotationDirection.Counterclockwise;
            }

            // Add a title to the chart and hide the legend.
            RadarPointChart.Legend.Visible = false;

            // Add the chart to the form.
            RadarPointChart.Dock = DockStyle.Fill;

            objGcontrol.panel1.Controls.Clear();
            objGcontrol.panel1.Controls.Add(RadarPointChart);
            ribbonControl1.SelectedPage = rpGraph;

        }

        public void test(double[] Phasevalue, List<double> magnitude)
        {
            ChartControl RadarPointChart = new ChartControl();

            // Add a radar series to it.
            Series series1 = new Series("Series 1", ViewType.PolarArea);

            // Populate the series with points.
            if (PublicClass.currentInstrument == "Impaq-Benstone")
            {
                for (int i = 0; i < Phasevalue.Length; i++)
                {
                    if (Phasevalue[i] >= 0 && Phasevalue[i] < 90)
                    {
                        someInt = 0;
                        someInt = Convert.ToInt32(Phasevalue[i]);
                        series1.Points.Add(new SeriesPoint(someInt, Phasevalue[i]));
                    }
                    if (Phasevalue[i] >= 90 && Phasevalue[i] < 180)
                    {
                        someInt = 0;
                        someInt = Convert.ToInt32(Phasevalue[i]);
                        series1.Points.Add(new SeriesPoint(someInt, Phasevalue[i]));
                    }
                    if (Phasevalue[i] >= 180 && Phasevalue[i] < 270)
                    {
                        someInt = 0;
                        someInt = Convert.ToInt32(Phasevalue[i]);
                        series1.Points.Add(new SeriesPoint(someInt, Phasevalue[i]));
                    }
                    if (Phasevalue[i] >= 270 && Phasevalue[i] < 360)
                    {
                        someInt = 0;
                        someInt = Convert.ToInt32(Phasevalue[i]);
                        series1.Points.Add(new SeriesPoint(someInt, Phasevalue[i]));
                    }
                }
            }
            else
            {
                for (int i = 0; i < magnitude.Count; i++)
                {
                    if (Phasevalue[i] >= 0 && Phasevalue[i] < 90)
                    {
                        someInt = 0;
                        someInt = Convert.ToInt32(Phasevalue[i]);
                        series1.Points.Add(new SeriesPoint(someInt, magnitude[i]));
                    }
                    if (Phasevalue[i] >= 90 && Phasevalue[i] < 180)
                    {
                        someInt = 0;
                        someInt = Convert.ToInt32(Phasevalue[i]);
                        series1.Points.Add(new SeriesPoint(someInt, magnitude[i]));
                    }
                    if (Phasevalue[i] >= 180 && Phasevalue[i] < 270)
                    {
                        someInt = 0;
                        someInt = Convert.ToInt32(Phasevalue[i]);
                        series1.Points.Add(new SeriesPoint(someInt, magnitude[i]));
                    }
                    if (Phasevalue[i] >= 270 && Phasevalue[i] < 360)
                    {
                        someInt = 0;
                        someInt = Convert.ToInt32(Phasevalue[i]);
                        series1.Points.Add(new SeriesPoint(someInt, magnitude[i]));
                    }
                }
            }
            // Add the series to the chart.
            if (PublicClass.checkphase == "true")
            {
                RadarPointChart.Series.Add(series1);
                // Flip the diagram (if necessary).
                ((RadarDiagram)RadarPointChart.Diagram).DrawingStyle = RadarDiagramDrawingStyle.Circle;
                ((PolarDiagram)RadarPointChart.Diagram).StartAngleInDegrees = 0;
                ((PolarDiagram)RadarPointChart.Diagram).RotationDirection =
                    RadarDiagramRotationDirection.Counterclockwise;

                //foreach (Series series in WebChartControl1.Series)
                //    series.LabelsVisibility = cbShowLabels.Checked ? DefaultBoolean.True : DefaultBoolean.False;
                //WebChartControl1.ToolTipEnabled = cbShowLabels.Checked ? DefaultBoolean.False : DefaultBoolean.True;
            }
            else
            {
                RadarPointChart.Series.Add(series1);
                // Flip the diagram (if necessary).
                ((RadarDiagram)RadarPointChart.Diagram).DrawingStyle = RadarDiagramDrawingStyle.Circle;
                ((PolarDiagram)RadarPointChart.Diagram).StartAngleInDegrees = 270;
                ((PolarDiagram)RadarPointChart.Diagram).RotationDirection =
                    RadarDiagramRotationDirection.Counterclockwise;
            }

            // Add a title to the chart and hide the legend.
            RadarPointChart.Legend.Visible = false;

            // Add the chart to the form.
            RadarPointChart.Dock = DockStyle.Fill;

            objGcontrol.panel1.Controls.Clear();
            objGcontrol.panel1.Controls.Add(RadarPointChart);
            ribbonControl1.SelectedPage = rpGraph;

        }

        int ixctr = 4;
        string[] XDataLabels = null; ArrayList XYTrendData = null; ArrayList arrXTrenddataLabels = null;
        public void DrawOverallTrendGraph(ArrayList XYData, ArrayList arrXdataLabels)
        {
            RemovePreviousGraphControl();
            int GraphCount = XYData.Count / 2;
            xarrayNew = new double[0];
            yarrayNew = new double[0];
            XDataLabels = new string[arrXdataLabels.Count];
            XYTrendData = XYData;
            arrXTrenddataLabels = arrXdataLabels;
            try
            {
                for (int i = 0; i < arrXdataLabels.Count; i++)
                {
                    XDataLabels[i] = arrXdataLabels[i].ToString();
                }
                for (int i = 0; i < GraphCount; i++)
                {
                    double[] xData = (double[])XYData[2 * i];
                    double[] yData = (double[])XYData[(2 * i) + 1];

                    if (_LineGraph == null)
                    {
                        _LineGraph = new LineGraphControl();
                        _LineGraph.Name = "LineGraph" + i.ToString();

                        _LineGraph._ChartFooter = "";
                        _LineGraph._MainForm = this;
                        _LineGraph._XLabel = PublicClass.x_Unit;
                        CurrentXLabel = _LineGraph._XLabel;
                        _LineGraph._YLabel = PublicClass.y_Unit;
                        CurrentYLabel = _LineGraph._YLabel;

                        _LineGraph._GraphBG1 = _GraphBG1;
                        _LineGraph._GraphBG2 = _GraphBG2;
                        _LineGraph._GraphBGDir = _GraphBGDir;
                        _LineGraph._ChartBG1 = _ChartBG1;

                        _LineGraph._ChartBG2 = _ChartBG2;
                        _LineGraph._ChartBGDir = _ChartBGDir;
                        _LineGraph._AxisColor = _AxisColor;
                        _LineGraph._MainCursorColor = _MainCursorColor;
                        _LineGraph._AreaFill = _AreaPlot;

                        _LineGraph.Dock = DockStyle.Fill;
                        _LineGraph.DrawLineGraph(xData, yData, XDataLabels);
                        objGcontrol.panel1.Controls.Add(_LineGraph);
                        ribbonControl1.SelectedPage = rpGraph;
                        xarrayNew = xData;
                        yarrayNew = yData;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void DrawLineGraphs(ArrayList XYData, string zoom, string pwrzoom)
        {
            RemovePreviousGraphControl();
            int GraphCount = XYData.Count / 2;
            xarrayNew = new double[0];
            yarrayNew = new double[0];
            try
            {
                for (int i = 0; i < GraphCount; i++)
                {
                    double[] xData = (double[])XYData[2 * i];
                    double[] yData = (double[])XYData[(2 * i) + 1];

                    if (_LineGraph == null)
                    {
                        _LineGraph = new LineGraphControl();
                        _LineGraph._MainForm = this;
                        _LineGraph.Name = "LineGraph" + i.ToString();
                        _LineGraph._ChartFooter = PublicClass.Chart_Footer;
                        _LineGraph._XLabel = PublicClass.x_Unit;
                        CurrentXLabel = _LineGraph._XLabel;
                        _LineGraph._YLabel = PublicClass.y_Unit;
                        CurrentYLabel = _LineGraph._YLabel;
                        _LineGraph._ChartHeader = ChartHeader;
                        _LineGraph._GraphBG1 = _GraphBG1;
                        _LineGraph._GraphBG2 = _GraphBG2;
                        _LineGraph._GraphBGDir = _GraphBGDir;
                        _LineGraph._ChartBG1 = _ChartBG1;
                        _LineGraph._ChartBG2 = _ChartBG2;
                        _LineGraph._ChartBGDir = _ChartBGDir;
                        _LineGraph._AxisColor = _AxisColor;
                        _LineGraph._MainCursorColor = _MainCursorColor;
                        _LineGraph._AreaFill = _AreaPlot;

                        _LineGraph.Dock = DockStyle.Fill;
                        if (zoom != "0" && pwrzoom != "0")
                        {
                            _LineGraph.DrawLineGraphzoom(xData, yData, _LineGraph._ColorTag, false);
                        }
                        else
                        {
                            _LineGraph.DrawLineGraph(xData, yData);
                        }

                        objGcontrol.panel1.Controls.Clear();
                        objGcontrol.panel1.Controls.Add(_LineGraph);
                        if (PublicClass.GraphClicked != "Power" && PublicClass.GraphClicked != "Power1" && PublicClass.GraphClicked != "Power2" && PublicClass.GraphClicked != "Power21" && PublicClass.GraphClicked != "Power3" && PublicClass.GraphClicked != "Power31")
                        {
                            bbdiagonostic.Enabled = false;
                        }
                        else
                        {
                            bbdiagonostic.Enabled = true;
                        }

                        ribbonControl1.SelectedPage = rpGraph;

                        xarrayNew = xData;
                        yarrayNew = yData;
                        xarrayNw = xData;

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void DrawLineGraphsDia(ArrayList XYData)
        {
            RemovePreviousGraphControl();
            int GraphCount = XYData.Count / 2;
            xarrayNew = new double[0];
            yarrayNew = new double[0];
            try
            {
                for (int i = 0; i < GraphCount; i++)
                {
                    double[] xData = (double[])XYData[2 * i];
                    double[] yData = (double[])XYData[(2 * i) + 1];

                    if (_LineGraph == null)
                    {
                        _LineGraph = new LineGraphControl();
                        _LineGraph._MainForm = this;
                        _LineGraph.Name = "LineGraph" + i.ToString();
                        _LineGraph._ChartFooter = PublicClass.Chart_Footer;
                        _LineGraph._XLabel = PublicClass.x_Unit;
                        CurrentXLabel = _LineGraph._XLabel;
                        _LineGraph._YLabel = PublicClass.y_Unit;
                        CurrentYLabel = _LineGraph._YLabel;

                        _LineGraph._ChartHeader = ChartHeader;

                        _LineGraph._GraphBG1 = _GraphBG1;
                        _LineGraph._GraphBG2 = _GraphBG2;
                        _LineGraph._GraphBGDir = _GraphBGDir;
                        _LineGraph._ChartBG1 = _ChartBG1;
                        _LineGraph._ChartBG2 = _ChartBG2;
                        _LineGraph._ChartBGDir = _ChartBGDir;
                        _LineGraph._AxisColor = _AxisColor;
                        _LineGraph._MainCursorColor = _MainCursorColor;
                        _LineGraph._AreaFill = _AreaPlot;
                        _LineGraph.Dock = DockStyle.Fill;
                        _LineGraph.DrawLineGraph(xData, yData);
                        objDiagnostic.panel1.Controls.Clear();
                        objDiagnostic.panel1.Controls.Add(_LineGraph);
                        xarrayNew = xData;
                        yarrayNew = yData;

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public Color _AxisColor
        {
            get
            {
                return AxisColor;
            }
            set
            {
                AxisColor = value;
            }
        }
        public Color _MainCursorColor
        {
            get
            {
                return MainCursor;
            }
            set
            {
                MainCursor = value;
            }
        }


        private void tsbtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                _objUserControl.InsertNextLevelFB("Plant");

            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void bbCrtResource_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Creating New Area";
                _objUserControl.LevelModify = false;
                btnInstRes_Click(sender, e);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void btnInstRes_Click(object sender, EventArgs e)
        {
            try
            {
                _objUserControl.InsertNextLevelFB("Area");
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void bbCrtElement_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Creating New Train";
                _objUserControl.LevelModify = false;
                btnInstElmnt_Click(sender, e);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
                //System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }


        private void btnInstElmnt_Click(object sender, EventArgs e)
        {
            try
            {
                _objUserControl.InsertNextLevelFB("Train");
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
                //System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }

        }

        private void btnInstSbElmnt_Click(object sender, EventArgs e)
        {
            try
            {
                _objUserControl.InsertNextLevelFB("Machine");
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
                //System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        private void btnInstPoint_Click(object sender, EventArgs e)
        {
            try
            {
                _objUserControl.InsertNextLevelFB("Point");
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
                //System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void bbCrtSubElement_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Creating New Machine";
                _objUserControl.LevelModify = false;
                btnInstSbElmnt_Click(sender, e);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void bbCrtPoint_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Creating New Point";
                _objUserControl.LevelModify = false;
                btnInstPoint_Click(sender, e);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void frmIAdeptMain_Load(object sender, EventArgs e)
        {
            try
            {
                fillform();
            }
            catch (Exception ex) { Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name); }
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You want to Close your Application", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    DataTable dt = DbClass.getdata(CommandType.Text, "select * from factory_info");
                    if (dt.Rows.Count > 0)
                    {
                        DbClass.executequery(CommandType.Text, "Update userdetail set Login = '0' , LastloginDate = '" + PublicClass.GetDatetime() + "'where ID = '" + PublicClass.cUID + "'");
                        exitsts = true;
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Please Create a Hierarchy", "VibAnalyst", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void bbFirst_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                FirstRdToolStripButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void FirstRdToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                _objUserControl.MoveFirst();

            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);

            }
        }

        private void bbPrevious_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                PreviousRdToolStripButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        public void PreviousRdToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                _objUserControl.MovePrevious();
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
                //System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        private void bbNext_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                NextRdToolStripButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        public void NextRdToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                _objUserControl.MoveNext();

            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
                //System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void bbGLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                btnlogsend_Click(null, null);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
                //System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void btnlogsend_Click(object sender, EventArgs e)
        {
            try
            {
                string sDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filepath = sDesktop + "\\ErrorLogFile.txt";
                FileStream fs = null;
                if (!File.Exists(filepath))
                {
                    using (fs = File.Create(filepath))
                    {
                        MessageBox.Show("Log File Shown on Desktop");
                        lblStatus.Caption = "Status: Generating Log File Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, e.ToString(), ex.LineNumber(), this.FindForm().Name);
                //System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void bbDelLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                btclrlog_Click(null, null);
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void btclrlog_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to Delete the log File", "Log file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string filepath = sDesktop + "\\ErrorLogFile.txt";
                    if (File.Exists(filepath))
                    {
                        File.Delete(filepath);
                        MessageBox.Show("Log File Deleted");
                        lblStatus.Caption = "Status: Deleting Log File Data Successfully";
                    }
                    else
                    { MessageBox.Show("NO File"); }
                }

            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void bbGeneralAlarms_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Opening Alarms";
                Alarms aa = new Alarms();
                panelControl2.Visible = false;
                pnl3.Controls.Clear();
                pnl3.Visible = true;
                aa.MdiParent = this;
                aa.MainForm = this;
                // checkform();
                pnl3.Controls.Add(aa);
                aa.Dock = DockStyle.Fill;
                aa.Show();
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        public void ribbonControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                RibbonControl _RC = sender as RibbonControl;

                rpdiagonostic.Visible = false;

                if (sSelectedpage == null || sSelectedpage == "")
                {
                    sSelectedpage = Convert.ToString(ribbonControl1.SelectedPage.Name);
                }
                else
                {
                }
                if (_RC.SelectedPage.Name == "rppointtype")
                {
                    lblStatus.Caption = "Status: Opening Point Type Module";
                    aa = new FrmPointType();
                    panelControl2.Visible = false;
                    List<Control> controlList2 = pnl3.Controls.OfType<Control>().ToList();
                    for (int i = 0; i < controlList2.Count; i++)
                    {
                        try
                        {
                            controlList2[i].Dispose();
                        }
                        catch { }
                    }
                    pnl3.Visible = true;
                    aa.MdiParent = this;
                    aa.MainForm = this;
                    checkform();
                    pnl3.Controls.Add(aa);
                    aa.Dock = DockStyle.Fill;
                    aa.Show();
                    aa.xtraTbPointType.SelectedTabPageIndex = 0;
                    rpGraph.Visible = false;
                    rpdiagonostic.Visible = false;
                }
                //case "Factory Manager":
                else if (_RC.SelectedPage.Name == "rpFactory")
                {
                    lblStatus.Caption = "Ready";
                    fillform();
                    rpGraph.Visible = false;
                    rpdiagonostic.Visible = false;
                }
                //case "Sensors":
                else if (ribbonControl1.SelectedPage.Name == "rpSensor")
                {
                    try
                    {
                        lblStatus.Caption = "Status: Opening Sensor Module";
                        panelControl2.Visible = true;
                        panelControl2.Controls.Clear();
                        pnl3.Visible = false;
                        panelControl2.Dock = DockStyle.Fill;
                        rpGraph.Visible = false;
                        rpdiagonostic.Visible = false;
                    }
                    catch
                    {
                    }
                }
                //case "Route Manager":
                else if (_RC.SelectedPage.Name == "rpRoute")
                {
                    lblStatus.Caption = "Status: Opening Route Manager Module";
                    rproute = new rproute();
                    pnl3.Visible = false;
                    panelControl2.Controls.Clear();
                    panelControl2.Visible = true;
                    panelControl2.Dock = DockStyle.Fill;
                    rproute.MdiParent = this;
                    rproute.MainForm = this;
                    panelControl2.Controls.Add(rproute);
                    rproute.Dock = DockStyle.Fill;
                    rproute.Show();
                    rpGraph.Visible = false;
                    rpdiagonostic.Visible = false;
                }
                //case "Admin":
                else if (_RC.SelectedPage.Name == "rpadmin")
                {
                    lblStatus.Caption = "Status: Opening Administration Module";
                    user = new frmUserDetail();
                    panelControl2.Controls.Clear();
                    pnl3.Visible = false;
                    panelControl2.Visible = true;
                    panelControl2.Dock = DockStyle.Fill;
                    user.MdiParent = this;
                    user.MainForm = this;
                    panelControl2.Controls.Add(user);
                    user.Dock = DockStyle.Fill;
                    user.Show();
                    rpGraph.Visible = false;
                    rpdiagonostic.Visible = false;
                }
                //case "Graph Analysis":
                else if (_RC.SelectedPage.Name == "rpGraph")
                {
                    rpGraph.Visible = true;
                    pnl3.Visible = false;
                    panelControl2.Controls.Clear();
                    panelControl2.Visible = true;
                    panelControl2.Dock = DockStyle.Fill;
                    objGcontrol.MdiParent = this;
                    if (PublicClass.GraphClicked == "Trend" && PublicClass.trendbool == false) { }
                    else if (PublicClass.GraphClicked == "TWFToFFT") { }
                    else { m_PointGeneral1.allGraph(PublicClass.GraphClicked, "Power"); }
                    panelControl2.Controls.Add(objGcontrol);
                    objGcontrol.Dock = DockStyle.Fill;
                    if (objGcontrol.IsDisposed)
                    {
                        objGcontrol = new frmGControls();
                        rpGraph.Visible = true;
                        pnl3.Visible = false;
                        panelControl2.Controls.Clear();
                        panelControl2.Visible = true;
                        panelControl2.Dock = DockStyle.Fill;
                        objGcontrol.MdiParent = this;
                        if (PublicClass.GraphClicked == "Trend" && PublicClass.trendbool == false)
                        {
                        }
                        else
                        {
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, "Power");
                        }
                        panelControl2.Controls.Add(objGcontrol);
                        objGcontrol.Dock = DockStyle.Fill;
                        objGcontrol.Show();
                    }
                    else { objGcontrol.Show(); }
                    rpdiagonostic.Visible = false;
                    if (PublicClass.GraphClicked == "Trend" && PublicClass.trendbool == false)
                    { //PublicClass.SPointID = PublicClass.SPointID;
                    }
                }
                else if (_RC.SelectedPage.Name == "rpMachineCompare")
                {
                    objMachineCompare = new frmMachineComparision();
                    pnl3.Visible = false;
                    panelControl2.Visible = true;
                    panelControl2.Controls.Clear();
                    panelControl2.Dock = DockStyle.Fill;
                    objMachineCompare.MdiParent = this;
                    panelControl2.Controls.Add(objMachineCompare);
                    objMachineCompare.Dock = DockStyle.Fill;
                    objMachineCompare.ptMain = m_PointGeneral1;
                    objMachineCompare.Main = this;
                    objMachineCompare.usercontrol = _objUserControl;
                    objMachineCompare.Show();
                }
                else if (_RC.SelectedPage.Name == "rpdiagonostic")
                {
                    objDiagnostic = new frmDiagnostic();
                    rpdiagonostic.Visible = true;
                    pnl3.Visible = false;
                    panelControl2.Visible = true;
                    panelControl2.Controls.Clear();
                    panelControl2.Dock = DockStyle.Fill;
                    objDiagnostic.MdiParent = this;
                    panelControl2.Controls.Add(objDiagnostic);
                    objDiagnostic.Dock = DockStyle.Fill;
                    objDiagnostic.ptMain = m_PointGeneral1;
                    objDiagnostic.Main = this;
                    objDiagnostic.usercontrol = _objUserControl;
                    objDiagnostic.Show();
                }

            }
            catch (Exception ex)
            {
                //Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void bbtnSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmSearch objFind = new frmSearch();
                objFind.MainControl = _objUserControl;
                objFind.Iadept = this;
                objFind.ShowDialog();
                bFindClosed = false;
                bFRClosed = false;
            }
            catch (Exception ex)
            {
                Errorlogfile.LogFile(ex, ex.ToString(), ex.LineNumber(), this.FindForm().Name);
            }
        }

        private void bbNewNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Opening Notes";
                frmNotes fnote = new frmNotes();
                panelControl2.Visible = true;
                pnl3.Controls.Clear();
                pnl3.Visible = true;
                panelControl2.Controls.Clear();
                fnote.MdiParent = this;
                fnote.MainForm = this;
                checkform();
                pnl3.Controls.Add(fnote);
                fnote.Dock = DockStyle.Fill;
                fnote.Show();
            }
            catch
            {
            }
        }

        private void barbtnband_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Opening Band Alarms";
                fBAlarm = new frmBandAlarms();
                panelControl2.Visible = false;
                pnl3.Controls.Clear();
                pnl3.Visible = true;
                fBAlarm.MdiParent = this;
                fBAlarm.MainForm = this;
                checkform();
                pnl3.Controls.Add(fBAlarm);
                fBAlarm.Dock = DockStyle.Fill;
                fBAlarm.Show();
            }
            catch
            { }
        }

        private void bbDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                _objUserControl.deleteselected();
            }
            catch { }
        }

        private bool bSetTime = false;
        public bool SetTypeForTime
        {
            get
            {
                return bSetTime;
            }
            set
            {
                bSetTime = value;
            }
        }
        Color Color_Panel1BackColor = Color.White;
        public Color P1BackColor
        {
            get
            {
                return Color_Panel1BackColor;
            }
            set
            {
                Color_Panel1BackColor = value;
            }
        }
        private void bbGraphColor1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ColorDialog _ColorDialog = new ColorDialog();
                _ColorDialog.ShowDialog();
                Color SelectedColor = _ColorDialog.Color;
                objGcontrol.panel1.BackColor = SelectedColor;
                Color_Panel1BackColor = SelectedColor;
            }
            catch { }
        }

        private void bbGraphBG1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ColorDialog _Color = new ColorDialog();
                _Color.ShowDialog();
                byte ColorA = _Color.Color.A;
                byte ColorR = _Color.Color.R;
                byte ColorG = _Color.Color.G;
                byte ColorB = _Color.Color.B;
                _GraphBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                if (_LineGraph != null)
                {
                    _LineGraph._GraphBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                else if (_LineGraph4 != null || _LineGraph3 != null || _LineGraph2 != null || _LineGraph1 != null)
                {
                    _LineGraph4._GraphBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph3._GraphBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph2._GraphBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph1._GraphBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                if (_BarGraph != null)
                {
                    _BarGraph._GraphBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                if (_3DGraph != null)
                {
                    _3DGraph._GraphBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
            }
            catch
            {
            }
        }

        private void BackGroundChanges()
        {
            try
            {
                if (_LineGraph != null)
                {
                    _LineGraph.BackGroundChanges();
                }
                else if (_LineGraph4 != null || _LineGraph3 != null || _LineGraph2 != null || _LineGraph1 != null)
                {
                    _LineGraph4.BackGroundChanges();
                    _LineGraph3.BackGroundChanges();
                    _LineGraph2.BackGroundChanges();
                    _LineGraph1.BackGroundChanges();
                }
                if (_BarGraph != null)
                {
                    _BarGraph.BackGroundChanges();
                }
                if (_3DGraph != null)
                {
                    _3DGraph.BackGroundChanges();
                }
                this.Refresh();
            }
            catch
            {
            }
        }

        private void bbGraphBG2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ColorDialog _Color = new ColorDialog();
                _Color.ShowDialog();
                byte ColorA = _Color.Color.A;
                byte ColorR = _Color.Color.R;
                byte ColorG = _Color.Color.G;
                byte ColorB = _Color.Color.B;
                _GraphBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                if (_LineGraph != null)
                {
                    _LineGraph._GraphBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                else if (_LineGraph4 != null || _LineGraph3 != null || _LineGraph2 != null || _LineGraph1 != null)
                {
                    _LineGraph4._GraphBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph3._GraphBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph2._GraphBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph1._GraphBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
            }
            catch { }
        }

        private void bbGraphDirHor_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                _GraphBGDir = 0;
                if (_LineGraph != null)
                {
                    _LineGraph._GraphBGDir = 0;
                    BackGroundChanges();
                }
                if (_BarGraph != null)
                {
                    _BarGraph._GraphBGDir = 0;
                    BackGroundChanges();
                }
                if (_3DGraph != null)
                {
                    _3DGraph._GraphBGDir = 0;
                    BackGroundChanges();
                }
            }
            catch
            {
            }
        }

        private void bbChartDirVer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                _ChartBGDir = 1;
                if (_LineGraph != null)
                {
                    _LineGraph._ChartBGDir = 1;
                    BackGroundChanges();
                }
                if (_BarGraph != null)
                {
                    _BarGraph._ChartBGDir = 1;
                    BackGroundChanges();
                }
                if (_3DGraph != null)
                {
                    _3DGraph._ChartBGDir = 1;
                    BackGroundChanges();
                }
            }
            catch
            {
            }
        }

        private void bbChartBG1_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ColorDialog _Color = new ColorDialog();
                _Color.ShowDialog();
                byte ColorA = _Color.Color.A;
                byte ColorR = _Color.Color.R;
                byte ColorG = _Color.Color.G;
                byte ColorB = _Color.Color.B;
                _ChartBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                if (_LineGraph != null)
                {
                    _LineGraph._ChartBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                else if (_LineGraph4 != null || _LineGraph3 != null || _LineGraph2 != null || _LineGraph1 != null)
                {
                    _LineGraph4._ChartBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph3._ChartBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph2._ChartBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph1._ChartBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                if (_BarGraph != null)
                {
                    _BarGraph._ChartBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                if (_3DGraph != null)
                {
                    _3DGraph._ChartBG1 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
            }
            catch
            {
            }
        }

        private void bbChartBG2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ColorDialog _Color = new ColorDialog();
                _Color.ShowDialog();
                byte ColorA = _Color.Color.A;
                byte ColorR = _Color.Color.R;
                byte ColorG = _Color.Color.G;
                byte ColorB = _Color.Color.B;
                _ChartBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                if (_LineGraph != null)
                {
                    _LineGraph._ChartBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                else if (_LineGraph4 != null || _LineGraph3 != null || _LineGraph2 != null || _LineGraph1 != null)
                {
                    _LineGraph4._ChartBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph3._ChartBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph2._ChartBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    _LineGraph1._ChartBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                if (_BarGraph != null)
                {
                    _BarGraph._ChartBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                if (_3DGraph != null)
                {
                    _3DGraph._ChartBG2 = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
            }
            catch
            {
            }
        }

        private void bbChartDirHor_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                _ChartBGDir = 0;
                if (_LineGraph != null)
                {
                    _LineGraph._ChartBGDir = 0;
                    BackGroundChanges();
                }
                if (_BarGraph != null)
                {
                    _BarGraph._ChartBGDir = 0;
                    BackGroundChanges();
                }
                if (_3DGraph != null)
                {
                    _3DGraph._ChartBGDir = 0;
                    BackGroundChanges();
                }
            }
            catch
            {
            }
        }

        private void bbGraphDirVer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                _GraphBGDir = 1;
                if (_LineGraph != null)
                {
                    _LineGraph._GraphBGDir = 1;
                    BackGroundChanges();
                }
                if (_BarGraph != null)
                {
                    _BarGraph._GraphBGDir = 1;
                    BackGroundChanges();
                }
                if (_3DGraph != null)
                {
                    _3DGraph._GraphBGDir = 1;
                    BackGroundChanges();
                }
            }
            catch
            {
            }
        }

        private void bbAxisColor_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ColorDialog _Color = new ColorDialog();
                _Color.ShowDialog();
                byte ColorA = _Color.Color.A;
                byte ColorR = _Color.Color.R;
                byte ColorG = _Color.Color.G;
                byte ColorB = _Color.Color.B;
                _AxisColor = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                if (_LineGraph != null)
                {
                    _LineGraph._AxisColor = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                if (_BarGraph != null)
                {
                    _BarGraph._AxisColor = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
                if (_3DGraph != null)
                {
                    _3DGraph._AxisColor = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                    BackGroundChanges();
                }
            }
            catch
            {
            }
        }

        private void bbmainCursor_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ColorDialog _Color = new ColorDialog();
                _Color.ShowDialog();

                byte ColorA = _Color.Color.A;
                byte ColorR = _Color.Color.R;
                byte ColorG = _Color.Color.G;
                byte ColorB = _Color.Color.B;
                _MainCursorColor = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                if (_LineGraph != null)
                {
                    _LineGraph._MainCursorColor = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                }
                if (_BarGraph != null)
                {
                    _BarGraph._MainCursorColor = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                }
                if (_3DGraph != null)
                {
                    _3DGraph._MainCursorColor = Color.FromArgb((int)ColorA, (int)ColorR, (int)ColorG, (int)ColorB);
                }
            }
            catch
            {
            }
        }
        private bool Zoom = false;
        private void bbZoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (_LineGraph != null)
                {
                    Zoom = true;
                    _LineGraph.StartZoom();
                }
                if (_OrbitGraph != null)
                {
                    _OrbitGraph.StartZoom();
                }
                string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                CmbCursorSelectedItem(SelectedCursorItem);
            }
            catch
            {
            }
        }

        private void bbUnzoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (_LineGraph != null)
                {
                    Zoom = false;
                    _LineGraph.Unzoom();
                }
                if (_OrbitGraph != null)
                {
                    _OrbitGraph.Unzoom();
                }
                string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                CmbCursorSelectedItem(SelectedCursorItem);
                if (PublicClass.zoom == true)
                {
                    m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                }
            }
            catch
            {
            }
        }
        public bool IsAreaPlot
        {
            get
            {
                return _AreaPlot;
            }
            set
            {
                _AreaPlot = value;
                if (_LineGraph != null)
                {
                    _LineGraph._AreaFill = value;
                }
            }
        }

        private void bbArea_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (IsAreaPlot == false)
                {
                    IsAreaPlot = true;
                    _LineGraph._AreaFill = true;
                }
                else
                {
                    IsAreaPlot = false;
                    _LineGraph._AreaFill = false;
                }
                bool bReturned = _LineGraph.AreaGraph();
                if (!bReturned)
                {
                    IsAreaPlot = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
        ArrayList arlstSColors = new ArrayList();
        public ArrayList SelectedColors
        {
            get
            {
                return arlstSColors;
            }
            set
            {
                arlstSColors = value;
            }
        }

        bool IsTrend = false;
        int selectGraphNumber = 0;
        public bool SetIsTrend
        {
            get
            {
                return IsTrend;
            }
            set
            {
                IsTrend = value;
                if (IsTrend)
                {
                    bbTrend.Caption = "Untrend";
                }
                else
                {
                    bbTrend.Caption = "Trend";
                }
                TrendingButtons(IsTrend);
            }
        }

        bool enableorbit = false;
        private void TrendingButtons(bool ON)
        {
            try
            {
                string _CurrentInstrument = PublicClass.currentInstrument;
                bbCepstrum.Enabled = !ON;
                bbArea.Enabled = !ON;
                bbShaftCenterLine.Enabled = !ON;
                bbChangeXUnit.Enabled = !ON;
                bbChangeYUnit.Enabled = !ON;
                bbCrestFactorTrend.Enabled = !ON;
                if (PublicClass.GraphClicked != "Time")
                {
                    // bbOctave.Enabled = !ON;
                    bbWaterfall.Enabled = !ON;
                    bbBand.Enabled = !ON;
                    bbOriginal.Enabled = !ON;
                }
                else
                {
                    if (_CurrentInstrument == "DI-460")
                    {
                        if (enableorbit)
                        {
                            bbOrbit.Enabled = !ON;
                        }
                        else
                        {
                            bbOrbit.Enabled = false;
                        }
                    }
                    else if (_CurrentInstrument == "Impaq-Benstone" || _CurrentInstrument == "FieldPaq2")
                    {
                        if (PublicClass.sensordirtype == "XYZ")
                        {
                            bbOrbit.Enabled = !ON;
                        }
                        else
                        {
                            bbOrbit.Enabled = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }
        private void bbTrend_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (EdittextDirection != "Overlap")
                {
                    arlstSColors = new ArrayList();
                    string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                    CmbCursorSelectedItem(SelectedCursorItem);
                    SetIsTrend = !SetIsTrend;
                    if (SetIsTrend)
                    {
                        selectGraphNumber = 0;
                        setCursorCombo("Trending");
                        StartTrending();
                    }
                    else
                    {
                        Set_iClick(Function.Clear);
                        setCursorCombo("Power");
                        StopTrending();
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        ArrayList arlSelectedDataGridValue = null;
        ArrayList arlstSelectedTime = new ArrayList();
        ArrayList newxyval = new ArrayList();
        ArrayList arrXYVals = null;
        ArrayList arrXYVals1 = null;
        ArrayList arrXYVals2 = null;
        ArrayList arrXYVals3 = null;

        private void StartTrending()
        {
            string[] colors = null;
            ArrayList Time = new ArrayList();
            ArrayList fullTime = new ArrayList();
            ImageList objlistimg = new ImageList();
            string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };

            int color = 0;
            try
            {
                RemovePreviousGraphControl();
                iclick = 0;
                objlistimg.Images.Add(ImageResources.DarkRed);
                objlistimg.Images.Add(ImageResources.DarkGreen);
                objlistimg.Images.Add(ImageResources.DarkGoldenRod);
                objlistimg.Images.Add(ImageResources.DarkseaGreen31);
                objlistimg.Images.Add(ImageResources.DarkBlue);
                objlistimg.Images.Add(ImageResources.DimGrey);
                objlistimg.Images.Add(ImageResources.Chocolate);
                objlistimg.Images.Add(ImageResources.DarkKhaki);
                objlistimg.Images.Add(ImageResources.Black);
                objlistimg.Images.Add(ImageResources.Orange);
                objlistimg.Images.Add(ImageResources.Cyan);
                objlistimg.Images.Add(ImageResources.AquaMarine);
                objlistimg.Images.Add(ImageResources.Bisque);
                objlistimg.Images.Add(ImageResources.Blue);
                objlistimg.Images.Add(ImageResources.BlueViolet);
                objlistimg.Images.Add(ImageResources.Coral);
                objlistimg.Images.Add(ImageResources.Darkmagenta);
                objlistimg.Images.Add(ImageResources.DarkSlateBlue31);
                objlistimg.Images.Add(ImageResources.DarkVoilet31);
                objlistimg.Images.Add(ImageResources.Deeppink31);
                objlistimg.Images.Add(ImageResources.DodgerBlue);
                objlistimg.Images.Add(ImageResources.FireBrick);
                objlistimg.Images.Add(ImageResources.ForestGreen);
                objlistimg.Images.Add(ImageResources.GreenYellow);
                objlistimg.Images.Add(ImageResources.HotPink);
                objlistimg.Images.Add(ImageResources.IndianRed);
                objlistimg.Images.Add(ImageResources.Darkorange);
                objlistimg.Images.Add(ImageResources.Darkorchid);
                objlistimg.Images.Add(ImageResources.DeepSkyBlue31);
                objlistimg.Images.Add(ImageResources.SandyBrown);
                arlSelectedDataGridValue = new ArrayList();
                if (_objUserControl != null)
                {
                    string sInstrumentName = PublicClass.currentInstrument;
                    if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "SKF/DI" || sInstrumentName == "FieldPaq2" || sInstrumentName == "Kohtect-C911")
                    {
                        fullTime = objIHand.ReturnAllDates(PublicClass.SPointID, PublicClass.GraphClicked, null, EdittextDirection);

                        arlstSColors = new ArrayList();
                        objGcontrol.CallClearDataGridMain();
                        colors = new string[fullTime.Count];
                        if (fullTime.Count > 0)
                        {
                            objGcontrol.dataGridView2.Rows.Add(fullTime.Count);
                        }
                        int icc = 0;
                        for (int i = 0; i < fullTime.Count; i++)
                        {
                            objGcontrol.dataGridView2.Rows[i].Cells[0].Value = fullTime[i].ToString();
                            {
                                objGcontrol.dataGridView2.Rows[i].Cells[1].Value = "√";
                                Time.Add(fullTime[i].ToString());
                                Set_iClick(Function.Add);
                                arlstSColors.Add(ColorCode[i]);
                                colors[i] = ColorCode[i].ToString();
                            }
                            objGcontrol.dataGridView2.Rows[i].Cells[3].Value = objlistimg.Images[icc];
                            objGcontrol.dataGridView2.Rows[i].Cells[3].Tag = ColorCode[icc].ToString();
                            arlSelectedDataGridValue.Add(i);
                            color++;
                            icc++;
                            if (icc >= 30)
                            {
                                icc = 0;
                            }
                        }
                        objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 1].Cells[3].Value = ImageResources.White;
                        arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, Time, PublicClass.GraphClicked, EdittextDirection);
                        DrawLineGraphs(arrXYVals, colors);
                        arlstSelectedTime = new ArrayList();
                        arlstSelectedTime = Time;
                    }
                }
                NavigateGraphs(selectGraphNumber);
            }
            catch
            {
            }
        }

        ArrayList DataSelected = new ArrayList(); string sDatagridCaption = null;
        private void NavigateGraphs(int selectGraphNumber)
        {
            try
            {
                int colorvalue = Convert.ToInt32(arlstSColors[selectGraphNumber]);
                if (_3DGraph != null)
                {
                    DataSelected = _3DGraph.SelectNextPlot(colorvalue);
                }
                if (_LineGraph != null)
                {
                    DataSelected = _LineGraph.SelectNextPlot(colorvalue);

                    _LineGraph._FooterColor = Color.FromArgb(-Convert.ToInt32(colorvalue));
                }
                try
                {
                    sDatagridCaption = arlstSelectedTime[selectGraphNumber].ToString();
                    string splitedgrid = arlSelectedDataGridValue[selectGraphNumber].ToString();

                    {
                        int RowValue = Convert.ToInt32(splitedgrid);
                        DataGridViewSelectedRowCollection dvsrc = objGcontrol.dataGridView2.SelectedRows;
                        for (int i = 0; i < dvsrc.Count; i++)
                        {
                            dvsrc[i].Selected = false;
                        }
                        objGcontrol.dataGridView2.Rows[RowValue].Selected = true;
                        sDatagridCaption = objGcontrol.dataGridView2.Rows[RowValue].Cells[0].Value.ToString();
                    }
                }
                catch (Exception exx)
                {
                }
                _LineGraph._ChartFooter = "Selected Graph Caption: " + sDatagridCaption;
            }
            catch (Exception ex)
            {
            }
            BackGroundChanges();
        }

        public void DrawLineGraphs(ArrayList XYData, string[] ColorTag)
        {
            try
            {
                if (_LineGraph == null)
                {
                    _LineGraph = new LineGraphControl();
                    _LineGraph.Dock = DockStyle.Fill;
                    CurrentYLabel = _YUnit;
                    _LineGraph._YLabel = PublicClass.y_Unit;
                    CurrentXLabel = _XUnit;
                    _LineGraph._XLabel = PublicClass.x_Unit;
                    objGcontrol.panel1.Controls.Add(_LineGraph);
                    _LineGraph._MainForm = this;
                }
                _LineGraph._ChartFooter = ChartFooter;
                _LineGraph._GraphBG1 = _GraphBG1;
                _LineGraph._GraphBG2 = _GraphBG2;
                _LineGraph._GraphBGDir = _GraphBGDir;
                _LineGraph._ChartBG1 = _ChartBG1;
                _LineGraph._ChartBG2 = _ChartBG2;
                _LineGraph._ChartBGDir = _ChartBGDir;
                _LineGraph._AxisColor = _AxisColor;
                _LineGraph._MainCursorColor = _MainCursorColor;

                ribbonControl1.SelectedPage = rpGraph;
                _LineGraph.DrawLineGraph(XYData, ColorTag);
            }
            catch (Exception ex)
            {
            }
        }

        public enum Function
        {
            Add, Subtract, Clear
        };
        int iclick = 0;

        public void Set_iClick(Function function)
        {
            try
            {
                switch (function)
                {
                    case Function.Add:
                        {
                            iclick++;
                            break;
                        }
                    case Function.Subtract:
                        {
                            iclick--;
                            break;
                        }
                    case Function.Clear:
                        {
                            iclick = 1;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
            }
        }
        bool IsWaterfall = false;
        private void bbWaterfall_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (EdittextDirection != "Overlap")
                {
                    IsWaterfall = !IsWaterfall;
                    string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                    CmbCursorSelectedItem(SelectedCursorItem);
                    if (IsWaterfall)
                    {
                        if (wavnode != null)
                        {

                        }
                        else
                        {
                            setCursorCombo("Trending");
                            StartWaterfall();
                        }
                    }
                    else
                    {
                        setCursorCombo("Power");
                        Set_iClick(Function.Clear);
                        StopTrending();
                    }
                }
                WaterFallButtons(IsWaterfall);
            }
            catch (Exception ex)
            {
            }
        }

        public void DrawWaterfallGraphs(ArrayList XYData, string[] ColorTag)
        {
            try
            {
                if (_3DGraph == null)
                {
                    _3DGraph = new _3DGraphControl();
                    _3DGraph.Dock = DockStyle.Fill;
                    CurrentYLabel = _YUnit;
                    _3DGraph._YLabel = PublicClass.y_Unit;
                    CurrentXLabel = _XUnit;
                    _3DGraph._XLabel = PublicClass.x_Unit;
                    objGcontrol.panel1.Controls.Add(_3DGraph);
                    _3DGraph._MainForm = this;
                }

                _3DGraph._GraphBG1 = _GraphBG1;
                _3DGraph._GraphBG2 = _GraphBG2;
                _3DGraph._GraphBGDir = _GraphBGDir;
                _3DGraph._ChartBG1 = _ChartBG1;
                _3DGraph._ChartBG2 = _ChartBG2;
                _3DGraph._ChartBGDir = _ChartBGDir;
                _3DGraph._AxisColor = _AxisColor;
                _3DGraph._MainCursorColor = _MainCursorColor;

                ArrayList arXD = new ArrayList();
                ArrayList arYD = new ArrayList();
                for (int i = 0; i < XYData.Count; i++)
                {
                    arXD.Add(XYData[i]);
                    i += 1;
                    arYD.Add(XYData[i]);
                }
                _3DGraph.DrawWaterfallGraph(arXD, arYD, ColorTag);
            }
            catch (Exception ex)
            {
            }
        }

        private void StartWaterfall()
        {
            ArrayList Time = new ArrayList();
            ImageList objlistimg = new ImageList();
            string[] starColor = { "Red", "Green", "Orange" };
            string[] colors = null;
            string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };
            int color = 0;
            arlSelectedDataGridValue = new ArrayList();
            try
            {
                RemovePreviousGraphControl();
                iclick = 0;
                objlistimg.Images.Add(ImageResources.DarkRed);
                objlistimg.Images.Add(ImageResources.DarkGreen);
                objlistimg.Images.Add(ImageResources.DarkGoldenRod);
                objlistimg.Images.Add(ImageResources.DarkseaGreen31);
                objlistimg.Images.Add(ImageResources.DarkBlue);
                objlistimg.Images.Add(ImageResources.DimGrey);
                objlistimg.Images.Add(ImageResources.Chocolate);
                objlistimg.Images.Add(ImageResources.DarkKhaki);
                objlistimg.Images.Add(ImageResources.Black);
                objlistimg.Images.Add(ImageResources.Orange);
                objlistimg.Images.Add(ImageResources.Cyan);
                objlistimg.Images.Add(ImageResources.AquaMarine);
                objlistimg.Images.Add(ImageResources.Bisque);
                objlistimg.Images.Add(ImageResources.Blue);
                objlistimg.Images.Add(ImageResources.BlueViolet);
                objlistimg.Images.Add(ImageResources.Coral);
                objlistimg.Images.Add(ImageResources.Darkmagenta);
                objlistimg.Images.Add(ImageResources.DarkSlateBlue31);
                objlistimg.Images.Add(ImageResources.DarkVoilet31);
                objlistimg.Images.Add(ImageResources.Deeppink31);
                objlistimg.Images.Add(ImageResources.DodgerBlue);
                objlistimg.Images.Add(ImageResources.FireBrick);
                objlistimg.Images.Add(ImageResources.ForestGreen);
                objlistimg.Images.Add(ImageResources.GreenYellow);
                objlistimg.Images.Add(ImageResources.HotPink);
                objlistimg.Images.Add(ImageResources.IndianRed);
                objlistimg.Images.Add(ImageResources.Darkorange);
                objlistimg.Images.Add(ImageResources.Darkorchid);
                objlistimg.Images.Add(ImageResources.DeepSkyBlue31);
                objlistimg.Images.Add(ImageResources.SandyBrown);
                string InstName = PublicClass.currentInstrument;
                if (InstName == "Impaq-Benstone" || InstName == "SKF/DI" || InstName == "FieldPaq2" || InstName == "Kohtect-C911")
                {
                    Time = objIHand.ReturnAllDates(PublicClass.SPointID, PublicClass.GraphClicked, null, EdittextDirection);
                    arlstSColors = new ArrayList();
                    objGcontrol.CallClearDataGridMain();
                    colors = new string[Time.Count];
                    if (Time.Count > 0)
                    {
                        objGcontrol.dataGridView2.Rows.Add(Time.Count);
                    }
                    int icc = 0;
                    for (int i = 0; i < Time.Count; i++)
                    {
                        objGcontrol.dataGridView2.Rows[i].Cells[0].Value = Time[i].ToString();
                        {
                            objGcontrol.dataGridView2.Rows[i].Cells[1].Value = "√";
                            Set_iClick(Function.Add);
                            arlstSColors.Add(ColorCode[i]);
                            colors[i] = ColorCode[i].ToString();
                            arlSelectedDataGridValue.Add(i);
                        }
                        objGcontrol.dataGridView2.Rows[i].Cells[3].Value = objlistimg.Images[icc];
                        objGcontrol.dataGridView2.Rows[i].Cells[3].Tag = ColorCode[icc].ToString();
                        color++;
                        icc++;
                        if (icc >= 30)
                        {
                            icc = 0;
                        }
                    }
                    objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 1].Cells[3].Value = ImageResources.White;
                    arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, Time, PublicClass.GraphClicked, EdittextDirection);
                    DrawWaterfallGraphs(arrXYVals, colors);
                    arlstSelectedTime = new ArrayList();
                    arlstSelectedTime = Time;
                }

            }
            catch { }
        }

        public string GetCurrentDateTime(string Graph)
        {
            string DateTime = null; string sCommandText = null;
            string currentInstName = PublicClass.currentInstrument;
            try
            {
                if (currentInstName == "DI-460")
                {
                }
                else if (currentInstName == "Card Vibro Neo")
                {
                    MessageBox.Show("Not Implemented");
                }
                else if (currentInstName == "Impaq-Benstone" || currentInstName == "SKF/DI" || currentInstName == "FieldPaq2")
                {
                    if (Graph == "Time")
                    {
                        sCommandText = "select Measure_Time from Point_data where Point_ID='" + PublicClass.SPointID + "' order by data_id asc";
                    }
                    else if (Graph == "Power" || Graph == "Power1" || Graph == "Power2" || Graph == "Power21" || Graph == "Power3" || Graph == "Power31")
                    {
                        sCommandText = "select Measure_Time from Point_data where Point_ID='" + PublicClass.SPointID + "' order by data_id asc";
                    }
                    else if (Graph == "Demodulate")
                    {
                        sCommandText = "select Measure_Time from Point_data where Point_ID='" + PublicClass.SPointID + "' order by data_id asc";
                    }
                    else if (Graph == "Cepstrum")
                    {
                        sCommandText = "select Measure_Time from Point_data where Point_ID='" + PublicClass.SPointID + "' order by data_id asc";
                    }
                    DataTable dt = DbClass.getdata(CommandType.Text, sCommandText);
                    foreach (DataRow dr in dt.Rows)
                    {
                        DateTime = Convert.ToDateTime(dr["Measure_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return DateTime;
        }

        private void StopTrending()
        {
            string sInstrumentName = PublicClass.currentInstrument;
            ArrayList _Time = new ArrayList();
            try
            {
                objGcontrol.dataGridView2.Rows.Clear();
                ShowCurrentDate();
                m_PointGeneral1.ExtractUnits();
                if (PublicClass.SPointID != null)
                {
                    if (PublicClass.checkgraphtime == "true")
                    {
                        _Time.Add(PublicClass.tym);
                    }
                    else
                    {
                        _Time.Add(GetCurrentDateTime(PublicClass.GraphClicked));
                    }

                    if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "SKF/DI" || sInstrumentName == "FieldPaq2")
                    {
                        arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, PublicClass.GraphClicked, EdittextDirection);
                    }
                    else if (sInstrumentName == "DI-460")
                    {
                        //arrXYVals = objIHand.GetAllPlotValuesDI(m_objMainControl._PointID, _Time, GenDiGraph);
                    }
                }
                if (arrXYVals.Count > 0)
                {
                    RemovePreviousGraphControl();
                    DrawLineGraphs(arrXYVals, "0", "0");
                }
                else
                {
                    MessageBox.Show("Current Selection Have No Data", "No Data");
                    PublicClass.AHVCH1 = lastDirection;
                    bcmDirection.EditValue = lastDirection;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void WaterFallButtons(bool ON)
        {
            try
            {
                bbTrend.Enabled = !ON;
                // bbOctave.Enabled = !ON;
                bbCepstrum.Enabled = !ON;
                bbArea.Enabled = !ON;
                bbChangeXUnit.Enabled = !ON;
                bbChangeYUnit.Enabled = !ON;
                bbBand.Enabled = !ON;
                bbShaftCenterLine.Enabled = !ON;
                bbFaultFreq.Enabled = !ON;
                bbBFF.Enabled = !ON;
                bbRPM.Enabled = !ON;
                bbOriginal.Enabled = !ON;
                bbCrestFactorTrend.Enabled = !ON;
                if (ON)
                {
                    cmbCurSors.Items.Add((object)"Line");
                    repositoryItemComboBox2.Items.Add((object)"Line");
                }
                else
                {
                    cmbCurSors.Items.Remove((object)"Line");
                    repositoryItemComboBox2.Items.Remove((object)"Line");
                }
            }
            catch (Exception ex)
            {
            }
        }
        bool IsOrbitPlot = false;
        private void bbOrbit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                IsOrbitPlot = !IsOrbitPlot;
                string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                CmbCursorSelectedItem(SelectedCursorItem);
                if (IsOrbitPlot)
                {
                    ExtractTestDataForOrbit();
                }
                else
                {
                    Set_iClick(Function.Clear);
                    StopTrending();
                }
                OrbitButtons(IsOrbitPlot);
            }
            catch (Exception ex)
            {
            }
        }
        int initialorbitctr = 1;
        private void ExtractTestDataForOrbit()
        {
            initialorbitctr = 1;
            ArrayList Time_Mag = new ArrayList();
            ArrayList Time_Ang = new ArrayList();
            ArrayList Time_selected = new ArrayList();
            ImageList objlistimg = new ImageList();
            arrXYVals = null;
            arrXYVals1 = null;
            string[] colors = null;
            string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };
            int color = 0;
            iclick = 0;
            objlistimg.Images.Add(ImageResources.DarkRed);
            objlistimg.Images.Add(ImageResources.DarkGreen);
            objlistimg.Images.Add(ImageResources.DarkGoldenRod);
            objlistimg.Images.Add(ImageResources.DarkseaGreen31);
            objlistimg.Images.Add(ImageResources.DarkBlue);
            objlistimg.Images.Add(ImageResources.DimGrey);
            objlistimg.Images.Add(ImageResources.Chocolate);
            objlistimg.Images.Add(ImageResources.DarkKhaki);
            objlistimg.Images.Add(ImageResources.Black);
            objlistimg.Images.Add(ImageResources.Orange);
            objlistimg.Images.Add(ImageResources.Cyan);
            objlistimg.Images.Add(ImageResources.AquaMarine);
            objlistimg.Images.Add(ImageResources.Bisque);
            objlistimg.Images.Add(ImageResources.Blue);
            objlistimg.Images.Add(ImageResources.BlueViolet);
            objlistimg.Images.Add(ImageResources.Coral);
            objlistimg.Images.Add(ImageResources.Darkmagenta);
            objlistimg.Images.Add(ImageResources.DarkSlateBlue31);
            objlistimg.Images.Add(ImageResources.DarkVoilet31);
            objlistimg.Images.Add(ImageResources.Deeppink31);
            objlistimg.Images.Add(ImageResources.DodgerBlue);
            objlistimg.Images.Add(ImageResources.FireBrick);
            objlistimg.Images.Add(ImageResources.ForestGreen);
            objlistimg.Images.Add(ImageResources.GreenYellow);
            objlistimg.Images.Add(ImageResources.HotPink);
            objlistimg.Images.Add(ImageResources.IndianRed);
            objlistimg.Images.Add(ImageResources.Darkorange);
            objlistimg.Images.Add(ImageResources.Darkorchid);
            objlistimg.Images.Add(ImageResources.DeepSkyBlue31);
            objlistimg.Images.Add(ImageResources.SandyBrown);
            string sInstrumentName = PublicClass.currentInstrument;
            if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "SKF/DI" || sInstrumentName == "FieldPaq2")
            {
                try
                {
                    ImpaqHandler objIHand = new ImpaqHandler(); //(m_objMainControl);
                    Time_Mag = objIHand.ReturnAllDates(PublicClass.SPointID, "Time", null, "Vertical");
                    if (_objUserControl != null)
                    {
                        arlstSColors = new ArrayList();
                        objGcontrol.CallClearDataGridMain();
                        colors = new string[1];
                        if (Time_Mag.Count > 0)
                        {
                            objGcontrol.dataGridView2.Rows.Add(Time_Mag.Count);
                        }
                        int icc = 0;
                        for (int i = 0; i < Time_Mag.Count; i++)
                        {
                            objGcontrol.dataGridView2.Rows[i].Cells[1].Value = "X";
                            objGcontrol.dataGridView2.Rows[i].Cells[0].Value = Time_Mag[i].ToString();
                            objGcontrol.dataGridView2.Rows[i].Cells[3].Value = objlistimg.Images[icc];
                            objGcontrol.dataGridView2.Rows[i].Cells[3].Tag = ColorCode[icc].ToString();
                            color++;
                            icc++;
                            if (icc >= 30)
                            {
                                icc = 0;
                            }
                        }
                    }
                    objGcontrol.dataGridView2.Rows[0].Cells[1].Value = "√";
                    Time_selected.Add(Time_Mag[0].ToString());
                    arlstSColors.Add(ColorCode[0]);
                    colors[0] = ColorCode[0].ToString();
                    objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 1].Cells[3].Value = ImageResources.White;
                    if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "FieldPaq2")
                    {
                        arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, Time_selected, "Time", "Vertical");
                        arrXYVals1 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, Time_selected, "Time", "Horizontal");
                    }
                    else
                    {
                        arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, Time_selected, "Time", PublicClass.AHVCH1);
                        arrXYVals1 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, Time_selected, "Time", "Channel1");
                    }
                    if (arrXYVals.Count > 1 && arrXYVals1.Count > 1)
                    {
                        ArrayList arlOrbitData = new ArrayList();
                        arlOrbitData.Add((double[])arrXYVals1[1]);
                        arlOrbitData.Add((double[])arrXYVals[1]);
                        DrawLineOrbitGraphs(arlOrbitData, colors);
                    }
                }
                catch { }
            }
        }

        public void DrawLineOrbitGraphs(ArrayList XYData, string[] ColorTag)
        {
            try
            {
                RemovePreviousGraphControl();
                if (_LineGraph == null)
                {
                    _LineGraph = new LineGraphControl();
                    _LineGraph.Dock = DockStyle.Fill;

                    _LineGraph._YLabel = m_PointGeneral1._DisplacementUnit;

                    _LineGraph._XLabel = m_PointGeneral1._DisplacementUnit;
                    objGcontrol.panel1.Controls.Add(_LineGraph);
                    _LineGraph._MainForm = this;
                }
                _LineGraph._ChartFooter = ChartFooter;
                _LineGraph._GraphBG1 = _GraphBG1;
                _LineGraph._GraphBG2 = _GraphBG2;
                _LineGraph._GraphBGDir = _GraphBGDir;
                _LineGraph._ChartBG1 = _ChartBG1;
                _LineGraph._ChartBG2 = _ChartBG2;
                _LineGraph._ChartBGDir = _ChartBGDir;
                _LineGraph._AxisColor = _AxisColor;
                _LineGraph._MainCursorColor = _MainCursorColor;
                _LineGraph._AreaFill = false;
                _LineGraph.DrawLineOrbitGraph(XYData, ColorTag);
            }
            catch (Exception ex)
            {
            }
        }

        private void OrbitButtons(bool ON)
        {
            try
            {
                bbArea.Enabled = !ON;
                bbTrend.Enabled = !ON;
                bbCepstrum.Enabled = !ON;
                bbChangeXUnit.Enabled = !ON;
                bbChangeYUnit.Enabled = !ON;
                bbGraphBack.Enabled = !ON;
                bbGraphNext.Enabled = !ON;
                bcmDirection.Enabled = !ON;
                bbShaftCenterLine.Enabled = !ON;
                bbOriginal.Enabled = !ON;
                bbCrestFactorTrend.Enabled = !ON;
            }
            catch (Exception ex)
            {
            }
        }
        bool bSCL = false; private string ChoosenType = null;
        public string GraphType
        {
            get
            {
                return ChoosenType;
            }
            set
            {
                ChoosenType = value;
            }
        }
        private void bbShaftCenterLine_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                bSCL = !bSCL;

                bbArea.Enabled = !bSCL;
                bbTrend.Enabled = !bSCL;
                bbCepstrum.Enabled = !bSCL;
                bbChangeXUnit.Enabled = !bSCL;
                bbChangeYUnit.Enabled = !bSCL;
                bbGraphBack.Enabled = !bSCL;
                bbGraphNext.Enabled = !bSCL;
                bcmDirection.Enabled = !bSCL;
                if (PublicClass.GraphClicked != "Time")
                {
                    bbOriginal.Enabled = !bSCL;
                }
                if (bSCL)
                {
                    RemovePreviousGraphControl();
                    //lblOverall.Visible = false;
                    objGcontrol.panel1.Refresh();
                    ExtractDataForShaftCenterLine();
                    objGcontrol.panel1.Refresh();
                    objGcontrol.redrawSCL();
                }
                else
                {
                    GraphType = "FFT";
                    StopTrending();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ExtractDataForShaftCenterLine()
        {
            string sInstrumentName = PublicClass.currentInstrument;
            {
                try
                {
                    ArrayList arrXYVals = new ArrayList();
                    if (sInstrumentName == "DI-460")
                    {
                        //arrXYVals = objIHand.OverallValuesDI(m_objMainControl._PointID);
                    }
                    else if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "FieldPaq2")
                    {
                        arrXYVals = objIHand.GetDualOverallValuesImpaq(PublicClass.SPointID);
                    }
                    double[] arrDX = new double[arrXYVals.Count / 2];
                    double[] arrDY = new double[arrXYVals.Count / 2];
                    for (int i = 0; i < (arrXYVals.Count / 2); i++)
                    {
                        arrDX[i] = Convert.ToDouble(arrXYVals[2 * i]);
                        arrDY[i] = Convert.ToDouble(arrXYVals[(2 * i) + 1]);
                    }
                    double[] arrACTDX = new double[arrDX.Length];
                    double[] arrACTDY = new double[arrDX.Length];
                    for (int i = 0; i < arrDX.Length; i++)
                    {
                        double diff = arrDX[i] - arrDX[0];

                        arrACTDX[i] = diff;

                        diff = arrDY[i] - arrDY[0];

                        arrACTDY[i] = Math.Abs(diff);

                    }
                    GraphType = "SCL";
                    objGcontrol.GenerateShaftCenterChange(arrACTDX, arrACTDY);

                }
                catch (Exception ex)
                {

                }
            }
        }
        private void OctaveButtons(bool ON)
        {
            try
            {
                bbArea.Enabled = !ON;
                bbTrend.Enabled = !ON;
                bbWaterfall.Enabled = !ON;
                bbCepstrum.Enabled = !ON;
                bbChangeXUnit.Enabled = !ON;
                bbChangeYUnit.Enabled = !ON;
                bcmDirection.Enabled = !ON;
                bbShaftCenterLine.Enabled = !ON;
                bbOriginal.Enabled = !ON;
                bbCrestFactorTrend.Enabled = !ON;
                if (IsBandAreaPlot)
                {
                    bbCepstrum.Enabled = false;
                    bbFaultFreq.Enabled = false;
                    bbRPM.Enabled = false;
                    bbBFF.Enabled = false;
                    bbTrend.Enabled = false;
                    bbWaterfall.Enabled = false;
                    bbChangeXUnit.Enabled = false;
                    bbChangeYUnit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        string Octavesetting = null; string Octavebar = null;
        private void bbOctave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //if (!CheckForTimeData(yarrayNew) && !cepstrum)
                //{
                IsOctave = !IsOctave;
                OctaveButtons(IsOctave);
                if (IsOctave)
                {
                    NullCursorBools();
                    _LineGraph.DGVTrendNodes = objGcontrol.dataGridView2;
                    _BarGraph = new BarChart();
                    _BarGraph._XLabel = "Hz";
                    _BarGraph._YLabel = CurrentYLabel;
                    _BarGraph.Dock = DockStyle.Fill;
                    _BarGraph.AllowDrop = true;
                    if (CurrentYLabel == "db")
                    {
                        octavecheck = false;
                        ExtractDataForOctaveNewControl();
                    }
                    else
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select mea.octavesetting,mea.octavebar from measure mea inner join type_point tp on tp.ID=mea.Type_ID left join point pp on pp.pointtype_id=tp.ID where pp.Point_ID='" + PublicClass.SPointID + "'");
                        if (dt.Rows.Count > 0)
                        {
                            Octavesetting = Convert.ToString(dt.Rows[0]["octavesetting"]);
                            Octavebar = Convert.ToString(dt.Rows[0]["octavebar"]);
                            conversionforOctave(CurrentYLabel);
                            octavecheck = true;
                            ExtractDataForOctaveNewControl();
                        }
                    }
                }
                else
                {
                    objGcontrol.panel1.Controls.Remove(_BarGraph);
                    objGcontrol.panel1.Controls.Add(_LineGraph);
                    _BarGraph = null;
                    _LineGraph.Dock = DockStyle.Fill;
                    m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                    bbOctave.Enabled = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        string sUnitNew = null;
        private void conversionforOctave(string RawUnit)
        {
            try
            {
                frmUnit_IMXA _Unit_IMXA = new frmUnit_IMXA();
                sUnitNew = "db";
                string[] splUnit = RawUnit.Split(new string[] { "Y Unit", "X Unit", ":", " ", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                if (sUnitNew.ToString() == "db")
                {
                    double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), "IPS", (float)1);
                    double[] TempY = new double[yarrayNew.Length];
                    for (int i = 0; i < TempY.Length; i++)
                    {
                        TempY[i] = (double)yarrayNew[i] * ConversionFactor;

                        if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                        {
                            if (xarrayNew[i] != 0)
                            {
                                if (CurrentXLabel.Contains("CPM"))
                                {
                                    TempY[i] = TempY[i] * xarrayNew[i];
                                }
                                else if (CurrentXLabel.Contains("Hz"))
                                {
                                    TempY[i] = TempY[i] * (xarrayNew[i] * 60);
                                }
                            }
                        }
                        else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                        {
                            if (xarrayNew[i] != 0)
                            {
                                if (CurrentXLabel.Contains("CPM"))
                                {
                                    TempY[i] = TempY[i] / (xarrayNew[i]);
                                }
                                else if (CurrentXLabel.Contains("Hz"))
                                {
                                    TempY[i] = TempY[i] / (xarrayNew[i] * 60);
                                }
                            }
                        }
                    }
                    yarrayNew = TempY;
                    CurrentYLabel = sUnitNew.ToString();
                    ConversionFactor = _Unit_IMXA.UnitConverter("IPS", "mm/s");
                    TempY = new double[yarrayNew.Length];
                    for (int i = 0; i < TempY.Length; i++)
                    {
                        if (yarrayNew[i] > 0)
                        {
                            TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                            TempY[i] = 20 * Math.Log10(TempY[i] / Math.Pow(10, (-5)));
                        }
                        else
                        {
                            TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                        }
                    }

                    for (int i = 0; i < TempY.Length; i++)
                    {
                        if (TempY[i] != 0)
                        {
                            if (xarrayNew[i] != 0)
                            {
                                //vdb
                                if (splUnit[0].ToString() == "IPS" || splUnit[0].ToString() == "in/s" || splUnit[0].ToString() == "mm/s" || splUnit[0].ToString() == "cm/s" || splUnit[0].ToString() == "m/s" || splUnit[0].ToString() == "ft/s")
                                {

                                }
                                //  adb
                                else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                                {
                                    TempY[i] = TempY[i] + (20 * Math.Log10(xarrayNew[i])) - 44;
                                }
                                //ddb
                                else if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                {
                                    TempY[i] = TempY[i] - (20 * Math.Log10(xarrayNew[i])) - 24;
                                }
                            }
                        }
                    }
                    yarrayNew = TempY;
                }
            }
            catch { }
        }


        private void cmbGraphs_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                objGcontrol.dataGridView3.Rows.Clear();
                string selectedString = Convert.ToString(cmbGraphs.EditValue);
                m_PointGeneral1.MainForm1 = this;

                switch (selectedString)
                {
                    case "Time Waveform":
                        {
                            PublicClass.GraphClicked = "Time";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            break;
                        }
                    case "Demodulate Spectrum":
                        {
                            PublicClass.GraphClicked = "Demodulate";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            break;
                        }
                    case "Cepstrum":
                        {
                            PublicClass.GraphClicked = "Cepstrum";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            break;
                        }
                    case "Power Spectrum Group1 Power1":
                        {
                            PublicClass.GraphClicked = "Power";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            break;
                        }
                    case "Power Spectrum Group1 Power2":
                        {
                            PublicClass.GraphClicked = "Power1";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            break;
                        }
                    case "Power Spectrum Group2 Power1":
                        {
                            PublicClass.GraphClicked = "Power2";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            break;
                        }
                    case "Power Spectrum Group2 Power2":
                        {
                            PublicClass.GraphClicked = "Power21";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            break;
                        }
                    case "Power Spectrum Group3 Power1":
                        {
                            PublicClass.GraphClicked = "Power3";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            break;
                        }
                    case "Power Spectrum Group3 Power2":
                        {
                            PublicClass.GraphClicked = "Power31";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            break;
                        }
                    case "Time Channel1":
                        {
                            PublicClass.GraphClicked = "Time";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            bcmDirection.Enabled = false;
                            break;
                        }
                    case "Time Channel2":
                        {
                            PublicClass.GraphClicked = "Time";
                            string firstdir = PublicClass.AHVCH1;
                            PublicClass.AHVCH1 = "Channel1";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            PublicClass.AHVCH1 = firstdir;
                            bcmDirection.EditValue = firstdir;
                            bcmDirection.Enabled = false;
                            break;
                        }
                    case "TWF To FFT Channel1":
                        {
                            double[] xarrayNew = new double[0];
                            double[] yarrayNew = new double[0];
                            ArrayList Time = new ArrayList();
                            Time.Add(PublicClass.tym);
                            arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, Time, PublicClass.GraphClicked, EdittextDirection);
                            if (arrXYVals != null)
                            {
                                xarrayNew = (double[])arrXYVals[0]; yarrayNew = (double[])arrXYVals[1];
                                PublicClass.GraphClicked = "TWFToFFT";
                                PublicClass.checkgraph = true;
                                SetButtons("Time", PublicClass.currentInstrument);
                                setCursorCombo("Time");
                                DrawLineGraphsforDi(xarrayNew, yarrayNew, "Sec", CurrentYLabel);
                                bcmDirection.Enabled = false;
                            }
                            else
                            {
                                MessageBox.Show(this, "Data Not Available on TWF To FFT Channel1", "TWF To FFT Channel1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            break;
                        }
                    case "TWF To FFT Channel2":
                        {
                            string firstdir = PublicClass.AHVCH1;

                            PublicClass.AHVCH1 = firstdir;
                            EdittextDirection = firstdir;
                            bcmDirection.Enabled = false;
                            break;
                        }
                    case "Power Spectrum Channel1":
                        {
                            PublicClass.GraphClicked = "Power";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            bcmDirection.Enabled = false;
                            break;
                        }
                    case "Power Spectrum Channel2":
                        {
                            PublicClass.GraphClicked = "Power";
                            string firstdir = PublicClass.AHVCH1;
                            PublicClass.AHVCH1 = "Channel1";
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            PublicClass.AHVCH1 = firstdir;
                            bcmDirection.EditValue = firstdir;
                            bcmDirection.Enabled = false;
                            break;
                        }
                }
            }
            catch { }
        }

        string fac = null;
        string are = null;
        string tra = null;
        string mac = null;
        string pp = null; string lastDirection = null;
        private void bcmDirection_EditValueChanged(object sender, EventArgs e)
        {
            if (PublicClass.GraphClicked == null)
            {
                modify = true;
                objGcontrol.dataGridView3.Rows.Clear();
                objGcontrol.DataGridSettingForPhase(true);
                bboriginal();
                return;
            }
            else
            {
                try
                {
                    string lastDir = null;
                    DataTable dt = new DataTable();
                    dt = DbClass.getdata(CommandType.Text, "select fac.Name,ar.Name,tra.Name,mac.Name,pp.PointName from point pp inner join machine_info mac on mac.Machine_ID=pp.Machine_ID left join train_info tra on tra.Train_ID=mac.TrainID left join area_info ar on ar.Area_ID=tra.Area_ID left join factory_info fac on fac.Factory_ID=ar.FactoryID where Point_ID='" + PublicClass.SPointID + "'");
                    foreach (DataRow rd in dt.Rows)
                    {
                        fac = Convert.ToString(rd["Name"]);
                        are = Convert.ToString(rd["Name1"]);
                        tra = Convert.ToString(rd["Name2"]);
                        mac = Convert.ToString(rd["Name3"]);
                        pp = Convert.ToString(rd["PointName"]);
                    }
                    string showhierchy = fac + " --> " + are + " --> " + tra + " --> " + mac + " --> " + pp;
                    string demOverall = m_PointGeneral1.GetImpaqOverall();
                    PublicClass.footername = showhierchy + "\n" + "Overall : " + demOverall;
                    PublicClass.Chart_Footer = showhierchy + "\n" + "Overall : " + demOverall;
                    BarEditItem comboBox = sender as BarEditItem;
                    lastDirection = PublicClass.AHVCH1;
                    EdittextDirection = comboBox.EditValue.ToString();
                    PublicClass.AHVCH1 = EdittextDirection;
                    if (EdittextDirection != "Overlap")
                    {
                        if (EdittextDirection != "All Direction")
                        {
                            if (SetIsTrend)
                            {
                                StartTrending();
                            }
                            else if (IsWaterfall)
                            {
                                StartWaterfall();
                            }
                            else if (!SetIsTrend && !IsWaterfall)
                            {
                                if (PublicClass.GraphClicked == "Trend")
                                { }
                                else
                                {
                                    bbChangeXUnit.Enabled = true;
                                    bbChangeYUnit.Enabled = true;
                                    StopTrending();
                                }
                            }
                            setCursorCombo(PublicClass.GraphClicked);
                        }
                        else
                        {
                            AllDirectionGraphs();
                            ClearCmbCursor();
                            ArrayList CursorItems = new ArrayList();
                            CursorItems.Add("Select Cursor");
                            CursorItems.Add("Single");
                            CursorItems.Add("Line");
                            AddToCmbCursor(CursorItems);
                        }
                    }
                    else
                    {
                        setCursorCombo(PublicClass.GraphClicked);
                        bbChangeXUnit.Enabled = false;
                        bbChangeYUnit.Enabled = false;
                        SetIsTrend = true;
                        DrawOverlapGraph();
                    }

                }
                catch (Exception ex)
                {
                }
            }
        }


        private void bbAllpowergraph_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string scg = "Time";
                setCursorCombo(scg);
                AllpowerGraphs();
                scg = null;
            }
            catch
            { }
        }

        string overallcol = null;
        public string GetImpaqOverall()
        {
            return GetOverall(PublicClass.GraphClicked, overallcol);
        }

        private string GetOverall(string sGraphnametodraw, string column)
        {
            string overallcolumn = null;
            string overalltoshow = null;
            switch (sGraphnametodraw)
            {
                case "Time":
                    {
                        switch (column)
                        {
                            case "accel_":
                                {
                                    overallcolumn = "accel_";
                                    break;
                                }
                            case "vel_":
                                {
                                    overallcolumn = "vel_";
                                    break;
                                }
                            case "displ_":
                                {
                                    overallcolumn = "displ_";
                                    break;
                                }
                        }
                        break;
                    }
                case "Power":
                    {
                        switch (column)
                        {
                            case "accel_":
                                {
                                    overallcolumn = "accel_";
                                    break;
                                }
                            case "vel_":
                                {
                                    overallcolumn = "vel_";
                                    break;
                                }
                            case "displ_":
                                {
                                    overallcolumn = "displ_";
                                    break;
                                }
                        }
                        break;
                    }
                case "Demodulate":
                    {
                        switch (column)
                        {
                            case "accel_":
                                {
                                    overallcolumn = "accel_";
                                    break;
                                }
                            case "vel_":
                                {
                                    overallcolumn = "vel_";
                                    break;
                                }
                            case "displ_":
                                {
                                    overallcolumn = "displ_";
                                    break;
                                }
                        }
                        break;
                    }
                case "Cepstrum":
                    {
                        switch (column)
                        {
                            case "accel_":
                                {
                                    overallcolumn = "accel_";
                                    break;
                                }
                            case "vel_":
                                {
                                    overallcolumn = "vel_";
                                    break;
                                }
                            case "displ_":
                                {
                                    overallcolumn = "displ_";
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        switch (column)
                        {
                            case "accel_":
                                {
                                    overallcolumn = "accel_";
                                    break;
                                }
                            case "vel_":
                                {
                                    overallcolumn = "vel_";
                                    break;
                                }
                            case "displ_":
                                {
                                    overallcolumn = "displ_";
                                    break;
                                }
                        }
                        break;
                    }
            }
            switch (EdittextDirection)
            {
                case "Axial":
                    {
                        overallcolumn += "a";
                        break;
                    }
                case "Horizontal":
                    {
                        overallcolumn += "h";
                        break;
                    }
                case "Vertical":
                    {
                        overallcolumn += "v";
                        break;
                    }
                case "Channel1":
                    {
                        overallcolumn += "ch1";
                        break;
                    }
            }

            string sPointID = PublicClass.SPointID;
            DataTable dt = new DataTable();
            dt = DbClass.getdata(CommandType.Text, "Select " + overallcolumn + " from point_data where Point_ID='" + sPointID + "' and measure_time='" + PublicClass.tym + "' ");

            foreach (DataRow dr in dt.Rows)
            {
                overalltoshow = Convert.ToString(dr[overallcolumn]);
                break;
            }
            return overalltoshow;
        }

        private void AllDirectionGraphs()
        {
            ArrayList _Time = new ArrayList();
            string[] saxis = { "Axial", "Horizontal", "Vertical", "Channel1" };
            ArrayList arrdataA = new ArrayList();
            ArrayList arrdataH = new ArrayList();
            ArrayList arrdataV = new ArrayList();
            ArrayList arrdataCH1 = new ArrayList();
            int cnt = 0;
            try
            {
                objGcontrol.dataGridView2.Rows.Clear();
                ShowCurrentDate();
                if (PublicClass.SPointID != null)
                {
                    string sInstrumentName = PublicClass.currentInstrument;
                    if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "FieldPaq2")
                    {
                        m_PointGeneral1.ExtractUnits();
                    }
                    else
                    { m_PointGeneral1.getExtractCurrentUnit(); }

                    _Time.Add(PublicClass.tym);
                    arrXYVals = new ArrayList();

                    if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "SKF/DI" || sInstrumentName == "FieldPaq2")
                    {
                        arrdataA = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, PublicClass.GraphClicked, "Axial");
                        if (arrdataA.Count > 0)
                            cnt++;
                        arrdataH = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, PublicClass.GraphClicked, "Horizontal");
                        if (arrdataH.Count > 0)
                            cnt++;
                        arrdataV = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, PublicClass.GraphClicked, "Vertical");
                        if (arrdataV.Count > 0)
                            cnt++;
                        arrdataCH1 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, PublicClass.GraphClicked, "Channel1");
                        if (arrdataCH1.Count > 0)
                            cnt++;

                    }
                }
                RemovePreviousGraphControl();
                Draw3LineGraphs(arrdataA, arrdataH, arrdataV, arrdataCH1, cnt);

            }
            catch (Exception ex)
            {
            }
        }

        //For all power graphs
        private void AllpowerGraphs()
        {
            ArrayList _Time = new ArrayList();

            string[] saxis = { "Power", "Power1", "Power2", "Power21", "Power3", "Power31" };
            ArrayList arrdataP = new ArrayList();
            ArrayList arrdataP1 = new ArrayList();
            ArrayList arrdataP2 = new ArrayList();
            ArrayList arrdataP21 = new ArrayList();
            ArrayList arrdataP3 = new ArrayList();
            ArrayList arrdataP31 = new ArrayList();
            int cnt = 0;
            try
            {
                objGcontrol.dataGridView2.Rows.Clear();
                ShowCurrentDate();
                m_PointGeneral1.ExtractUnits();
                if (PublicClass.SPointID != null)
                {
                    string sInstrumentName = PublicClass.currentInstrument;
                    _Time.Add(PublicClass.tym);
                    arrXYVals = new ArrayList();
                    if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "SKF/DI" || sInstrumentName == "FieldPaq2")
                    {
                        arrdataP = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power", EdittextDirection);
                        if (arrdataP.Count > 0)
                            cnt++;
                        arrdataP1 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power1", EdittextDirection);
                        if (arrdataP1.Count > 0)
                            cnt++;
                        arrdataP2 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power2", EdittextDirection);
                        if (arrdataP2.Count > 0)
                            cnt++;
                        arrdataP21 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power21", EdittextDirection);
                        if (arrdataP21.Count > 0)
                            cnt++;
                        arrdataP3 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power3", EdittextDirection);
                        if (arrdataP3.Count > 0)
                            cnt++;
                        arrdataP31 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power31", EdittextDirection);
                        if (arrdataP31.Count > 0)
                            cnt++;

                    }
                }
                RemovePreviousGraphControl();
                Draw3LineAllpowerGraphs(arrdataP, arrdataP1, arrdataP2, arrdataP21, arrdataP3, arrdataP31, cnt);

            }
            catch (Exception ex)
            {
            }
        }

        private void Draw3LineGraphs(ArrayList arrdataA, ArrayList arrdataH, ArrayList arrdataV, ArrayList arrdataCH1, int cnt)
        {
            try
            {
                if (arrdataV.Count > 0)
                {
                    double[] tempX = (double[])arrdataV[0];
                    double[] tempY = (double[])arrdataV[1];
                    _LineGraph3.Name = "LineGraph Vertical";

                    PublicClass.Chart_Footer = "Vertical";
                    _LineGraph3._MainForm = this;
                    _LineGraph3._XLabel = _XUnit;
                    _LineGraph3._YLabel = _YUnit;
                    _LineGraph3._GraphBG1 = _GraphBG1;
                    _LineGraph3._GraphBG2 = _GraphBG2;
                    _LineGraph3._GraphBGDir = _GraphBGDir;
                    _LineGraph3._ChartBG1 = _ChartBG1;
                    _LineGraph3._ChartBG2 = _ChartBG2;
                    _LineGraph3._ChartBGDir = _ChartBGDir;
                    _LineGraph3._AxisColor = _AxisColor;
                    _LineGraph3._MainCursorColor = _MainCursorColor;
                    _LineGraph3._AreaFill = _AreaPlot;

                    _LineGraph3.Dock = DockStyle.Top;
                    _LineGraph3.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph3.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph3);
                }
                if (arrdataH.Count > 0)
                {
                    double[] tempX = (double[])arrdataH[0];
                    double[] tempY = (double[])arrdataH[1];


                    _LineGraph2.Name = "LineGraph Horizontal";
                    PublicClass.Chart_Footer = "Horizontal";
                    _LineGraph2._MainForm = this;
                    _LineGraph2._XLabel = _XUnit;
                    _LineGraph2._YLabel = _YUnit;
                    _LineGraph2._GraphBG1 = _GraphBG1;
                    _LineGraph2._GraphBG2 = _GraphBG2;
                    _LineGraph2._GraphBGDir = _GraphBGDir;
                    _LineGraph2._ChartBG1 = _ChartBG1;
                    _LineGraph2._ChartBG2 = _ChartBG2;
                    _LineGraph2._ChartBGDir = _ChartBGDir;
                    _LineGraph2._AxisColor = _AxisColor;
                    _LineGraph2._MainCursorColor = _MainCursorColor;
                    _LineGraph2._AreaFill = _AreaPlot;

                    _LineGraph2.Dock = DockStyle.Top;
                    _LineGraph2.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph2.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph2);
                }
                if (arrdataA.Count > 0)
                {
                    double[] tempX = (double[])arrdataA[0];
                    double[] tempY = (double[])arrdataA[1];


                    _LineGraph1.Name = "LineGraph Axial";

                    PublicClass.Chart_Footer = "Axial";
                    _LineGraph1._MainForm = this;
                    _LineGraph1._XLabel = _XUnit;
                    _LineGraph1._YLabel = _YUnit;
                    _LineGraph1._GraphBG1 = _GraphBG1;
                    _LineGraph1._GraphBG2 = _GraphBG2;
                    _LineGraph1._GraphBGDir = _GraphBGDir;
                    _LineGraph1._ChartBG1 = _ChartBG1;
                    _LineGraph1._ChartBG2 = _ChartBG2;
                    _LineGraph1._ChartBGDir = _ChartBGDir;
                    _LineGraph1._AxisColor = _AxisColor;
                    _LineGraph1._MainCursorColor = _MainCursorColor;
                    _LineGraph1._AreaFill = _AreaPlot;

                    _LineGraph1.Dock = DockStyle.Top;
                    _LineGraph1.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph1.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph1);
                }
                if (arrdataCH1.Count > 0)
                {
                    double[] tempX = (double[])arrdataCH1[0];
                    double[] tempY = (double[])arrdataCH1[1];


                    _LineGraph4.Name = "LineGraph Channel1";

                    PublicClass.Chart_Footer = "Channel1";
                    _LineGraph4._MainForm = this;
                    _LineGraph4._XLabel = _XUnit;
                    _LineGraph4._YLabel = _YUnit;
                    _LineGraph4._GraphBG1 = _GraphBG1;
                    _LineGraph4._GraphBG2 = _GraphBG2;
                    _LineGraph4._GraphBGDir = _GraphBGDir;
                    _LineGraph4._ChartBG1 = _ChartBG1;
                    _LineGraph4._ChartBG2 = _ChartBG2;
                    _LineGraph4._ChartBGDir = _ChartBGDir;
                    _LineGraph4._AxisColor = _AxisColor;
                    _LineGraph4._MainCursorColor = _MainCursorColor;
                    _LineGraph4._AreaFill = _AreaPlot;

                    _LineGraph4.Dock = DockStyle.Top;
                    _LineGraph4.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph4.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph4);
                }

            }
            catch (Exception ex)
            {
            }
        }

        //for all power graph
        private void Draw3LineAllpowerGraphs(ArrayList arrdataP, ArrayList arrdataP1, ArrayList arrdataP2, ArrayList arrdataP21, ArrayList arrdataP3, ArrayList arrdataP31, int cnt)
        {
            try
            {
                if (arrdataP.Count > 0)
                {
                    double[] tempX = (double[])arrdataP[0];
                    double[] tempY = (double[])arrdataP[1];
                    _LineGraph3.Name = "LineGraph Power Graph";

                    PublicClass.Chart_Footer = "Power Spectrum";
                    _LineGraph3._MainForm = this;
                    _LineGraph3._XLabel = PublicClass.x_Unit;
                    _LineGraph3._YLabel = PublicClass.y_Unit;
                    _LineGraph3._GraphBG1 = _GraphBG1;
                    _LineGraph3._GraphBG2 = _GraphBG2;
                    _LineGraph3._GraphBGDir = _GraphBGDir;
                    _LineGraph3._ChartBG1 = _ChartBG1;
                    _LineGraph3._ChartBG2 = _ChartBG2;
                    _LineGraph3._ChartBGDir = _ChartBGDir;
                    _LineGraph3._AxisColor = _AxisColor;
                    _LineGraph3._MainCursorColor = _MainCursorColor;
                    _LineGraph3._AreaFill = _AreaPlot;

                    _LineGraph3.Dock = DockStyle.Top;
                    _LineGraph3.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph3.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph3);
                }
                if (arrdataP1.Count > 0)
                {
                    double[] tempX = (double[])arrdataP1[0];
                    double[] tempY = (double[])arrdataP1[1];


                    _LineGraph2.Name = "LineGraph Power Graph1";
                    PublicClass.Chart_Footer = "Power Spectrum1";
                    _LineGraph2._MainForm = this;
                    _LineGraph2._XLabel = PublicClass.x_Unit;
                    _LineGraph2._YLabel = PublicClass.y_Unit;
                    _LineGraph2._GraphBG1 = _GraphBG1;
                    _LineGraph2._GraphBG2 = _GraphBG2;
                    _LineGraph2._GraphBGDir = _GraphBGDir;
                    _LineGraph2._ChartBG1 = _ChartBG1;
                    _LineGraph2._ChartBG2 = _ChartBG2;
                    _LineGraph2._ChartBGDir = _ChartBGDir;
                    _LineGraph2._AxisColor = _AxisColor;
                    _LineGraph2._MainCursorColor = _MainCursorColor;
                    _LineGraph2._AreaFill = _AreaPlot;

                    _LineGraph2.Dock = DockStyle.Top;
                    _LineGraph2.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph2.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph2);
                }
                if (arrdataP2.Count > 0)
                {
                    double[] tempX = (double[])arrdataP2[0];
                    double[] tempY = (double[])arrdataP2[1];


                    _LineGraph1.Name = "LineGraph Power2 Graph";

                    PublicClass.Chart_Footer = "Power2 Spectrum";
                    _LineGraph1._MainForm = this;
                    _LineGraph1._XLabel = PublicClass.x_Unit;
                    _LineGraph1._YLabel = PublicClass.y_Unit;
                    _LineGraph1._GraphBG1 = _GraphBG1;
                    _LineGraph1._GraphBG2 = _GraphBG2;
                    _LineGraph1._GraphBGDir = _GraphBGDir;
                    _LineGraph1._ChartBG1 = _ChartBG1;
                    _LineGraph1._ChartBG2 = _ChartBG2;
                    _LineGraph1._ChartBGDir = _ChartBGDir;
                    _LineGraph1._AxisColor = _AxisColor;
                    _LineGraph1._MainCursorColor = _MainCursorColor;
                    _LineGraph1._AreaFill = _AreaPlot;

                    _LineGraph1.Dock = DockStyle.Top;
                    _LineGraph1.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph1.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph1);
                }
                if (arrdataP21.Count > 0)
                {
                    double[] tempX = (double[])arrdataP21[0];
                    double[] tempY = (double[])arrdataP21[1];

                    _LineGraph4.Name = "LineGraph Power2 Graph1";

                    PublicClass.Chart_Footer = "Power2 Spectrum1";
                    _LineGraph4._MainForm = this;
                    _LineGraph4._XLabel = PublicClass.x_Unit;
                    _LineGraph4._YLabel = PublicClass.y_Unit;
                    _LineGraph4._GraphBG1 = _GraphBG1;
                    _LineGraph4._GraphBG2 = _GraphBG2;
                    _LineGraph4._GraphBGDir = _GraphBGDir;
                    _LineGraph4._ChartBG1 = _ChartBG1;
                    _LineGraph4._ChartBG2 = _ChartBG2;
                    _LineGraph4._ChartBGDir = _ChartBGDir;
                    _LineGraph4._AxisColor = _AxisColor;
                    _LineGraph4._MainCursorColor = _MainCursorColor;
                    _LineGraph4._AreaFill = _AreaPlot;

                    _LineGraph4.Dock = DockStyle.Top;
                    _LineGraph4.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph4.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph4);
                }
                if (arrdataP3.Count > 0)
                {
                    double[] tempX = (double[])arrdataP3[0];
                    double[] tempY = (double[])arrdataP3[1];


                    _LineGraph5.Name = "LineGraph Power3 Graph";

                    PublicClass.Chart_Footer = "Power3 Spectrum";
                    _LineGraph5._MainForm = this;
                    _LineGraph5._XLabel = PublicClass.x_Unit;
                    _LineGraph5._YLabel = PublicClass.y_Unit;
                    _LineGraph5._GraphBG1 = _GraphBG1;
                    _LineGraph5._GraphBG2 = _GraphBG2;
                    _LineGraph5._GraphBGDir = _GraphBGDir;
                    _LineGraph5._ChartBG1 = _ChartBG1;
                    _LineGraph5._ChartBG2 = _ChartBG2;
                    _LineGraph5._ChartBGDir = _ChartBGDir;
                    _LineGraph5._AxisColor = _AxisColor;
                    _LineGraph5._MainCursorColor = _MainCursorColor;
                    _LineGraph5._AreaFill = _AreaPlot;

                    _LineGraph5.Dock = DockStyle.Top;
                    _LineGraph5.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph5.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph5);
                }
                if (arrdataP31.Count > 0)
                {
                    double[] tempX = (double[])arrdataP31[0];
                    double[] tempY = (double[])arrdataP31[1];

                    _LineGraph6.Name = "LineGraph Power3 Graph1";

                    PublicClass.Chart_Footer = "Power3 Spectrum1";
                    _LineGraph6._MainForm = this;
                    _LineGraph6._XLabel = PublicClass.x_Unit;
                    _LineGraph6._YLabel = PublicClass.y_Unit;
                    _LineGraph6._GraphBG1 = _GraphBG1;
                    _LineGraph6._GraphBG2 = _GraphBG2;
                    _LineGraph6._GraphBGDir = _GraphBGDir;
                    _LineGraph6._ChartBG1 = _ChartBG1;
                    _LineGraph6._ChartBG2 = _ChartBG2;
                    _LineGraph6._ChartBGDir = _ChartBGDir;
                    _LineGraph6._AxisColor = _AxisColor;
                    _LineGraph6._MainCursorColor = _MainCursorColor;
                    _LineGraph6._AreaFill = _AreaPlot;

                    _LineGraph6.Dock = DockStyle.Top;
                    _LineGraph6.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph6.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph6);
                }

            }
            catch (Exception ex)
            {
            }
        }

        public bool ButtonOrbitEnabled
        {
            get
            {
                return btnOrbit.Enabled;
            }
            set
            {
                btnOrbit.Enabled = value;
                bbOrbit.Enabled = value;
            }
        }

        private void DrawOverlapGraph()
        {
            string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };
            ArrayList ArlXYData = null;
            ArrayList arltime = new ArrayList();
            arlstSColors = new ArrayList();
            try
            {
                iclick = 4;
                string currenttime = PublicClass.tym;
                arltime.Add(currenttime);
                ImpaqHandler objNewIHandler = new ImpaqHandler();
                ArlXYData = objNewIHandler.GetAllPlotValues(PublicClass.SPointID, null, arltime, PublicClass.GraphClicked, EdittextDirection);
                string[] colors = new string[4];
                for (int i = 0; i < 4; i++)
                {
                    arlstSColors.Add(ColorCode[i]);
                    colors[i] = ColorCode[i];
                }

                {
                    if (ButtonOrbitEnabled)
                        ButtonOrbitEnabled = false;
                }
                ImageList objlistimg = new ImageList();
                objGcontrol.dataGridView2.Rows.Clear();
                objlistimg.Images.Add(ImageResources.DarkRed);
                objlistimg.Images.Add(ImageResources.DarkGreen);
                objlistimg.Images.Add(ImageResources.DarkGoldenRod);
                objlistimg.Images.Add(ImageResources.AquaMarine);
                objGcontrol.dataGridView2.Rows.Add(3);

                if (((double[])ArlXYData[1]).Length > 5)
                {
                    objGcontrol.dataGridView2.Rows[0].Cells[0].Value = currenttime + " Axial";
                    arlstSelectedTtimeoverlap.Add(currenttime);
                    objGcontrol.dataGridView2.Rows[0].Cells[1].Value = "√";
                    objGcontrol.dataGridView2.Rows[0].Cells[3].Value = objlistimg.Images[0];
                    objGcontrol.dataGridView2.Rows[0].Cells[3].Tag = ColorCode[0].ToString();
                    // Set_iClick(Function.Add);
                }
                else
                {

                    objGcontrol.dataGridView2.Rows[0].Cells[0].Value = currenttime + " Axial";
                    arlstSelectedTtimeoverlap.Add(currenttime);
                    objGcontrol.dataGridView2.Rows[0].Cells[1].Value = "X";
                    objGcontrol.dataGridView2.Rows[0].Cells[3].Value = objlistimg.Images[0];
                    objGcontrol.dataGridView2.Rows[0].Cells[3].Tag = ColorCode[0].ToString();

                }

                if (((double[])ArlXYData[3]).Length > 5)
                {
                    objGcontrol.dataGridView2.Rows[1].Cells[0].Value = currenttime + " Horizontal";
                    arlstSelectedTtimeoverlap.Add(currenttime);
                    objGcontrol.dataGridView2.Rows[1].Cells[1].Value = "√";
                    objGcontrol.dataGridView2.Rows[1].Cells[3].Value = objlistimg.Images[1];
                    objGcontrol.dataGridView2.Rows[1].Cells[3].Tag = ColorCode[1].ToString();
                    // Set_iClick(Function.Add);
                }
                else
                {
                    objGcontrol.dataGridView2.Rows[1].Cells[0].Value = currenttime + " Horizontal";
                    arlstSelectedTtimeoverlap.Add(currenttime);
                    objGcontrol.dataGridView2.Rows[1].Cells[1].Value = "X";
                    objGcontrol.dataGridView2.Rows[1].Cells[3].Value = objlistimg.Images[1];
                    objGcontrol.dataGridView2.Rows[1].Cells[3].Tag = ColorCode[1].ToString();
                }

                if (((double[])ArlXYData[5]).Length > 5)
                {
                    objGcontrol.dataGridView2.Rows[2].Cells[0].Value = currenttime + " Vertical";
                    arlstSelectedTtimeoverlap.Add(currenttime);
                    objGcontrol.dataGridView2.Rows[2].Cells[1].Value = "√";
                    objGcontrol.dataGridView2.Rows[2].Cells[3].Value = objlistimg.Images[2];
                    objGcontrol.dataGridView2.Rows[2].Cells[3].Tag = ColorCode[2].ToString();
                    //Set_iClick(Function.Add);
                }
                else
                {
                    objGcontrol.dataGridView2.Rows[2].Cells[0].Value = currenttime + " Vertical";
                    arlstSelectedTtimeoverlap.Add(currenttime);
                    objGcontrol.dataGridView2.Rows[2].Cells[1].Value = "X";
                    objGcontrol.dataGridView2.Rows[2].Cells[3].Value = objlistimg.Images[2];
                    objGcontrol.dataGridView2.Rows[2].Cells[3].Tag = ColorCode[2].ToString();
                }
                if (((double[])ArlXYData[7]).Length > 5)
                {
                    objGcontrol.dataGridView2.Rows[3].Cells[0].Value = currenttime + " Channel1";
                    arlstSelectedTtimeoverlap.Add(currenttime);
                    objGcontrol.dataGridView2.Rows[3].Cells[1].Value = "√";
                    objGcontrol.dataGridView2.Rows[3].Cells[3].Value = objlistimg.Images[3];
                    objGcontrol.dataGridView2.Rows[3].Cells[3].Tag = ColorCode[3].ToString();
                    // Set_iClick(Function.Add);
                }
                else
                {
                    objGcontrol.dataGridView2.Rows[3].Cells[0].Value = currenttime + " Channel1";
                    arlstSelectedTtimeoverlap.Add(currenttime);
                    objGcontrol.dataGridView2.Rows[3].Cells[1].Value = "X";
                    objGcontrol.dataGridView2.Rows[3].Cells[3].Value = objlistimg.Images[3];
                    objGcontrol.dataGridView2.Rows[3].Cells[3].Tag = ColorCode[3].ToString();
                }
                RemovePreviousGraphControl();
                DrawLineGraphs(ArlXYData, colors);
            }
            catch (Exception ex)
            {
            }
        }

        double[] xx = null;
        int[] yy = null;
        int[] ff = null;
        double[] dXVals = null;
        double[] dYVals = null;
        double[] Xdata12 = new double[5];
        double[] Ydata12 = new double[5];

        public void DrawLineGraphsDia(ArrayList XYData, string[] RPMValues)
        {
            ImageList objlistimg = new ImageList();
            int icc = 0; int color = 0; iclick = 0;
            string[] colors = null;
            RemovePreviousGraphControl();
            string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };
            objlistimg.Images.Add(ImageResources.DarkRed);
            objlistimg.Images.Add(ImageResources.DarkGreen);
            objlistimg.Images.Add(ImageResources.DarkGoldenRod);
            objlistimg.Images.Add(ImageResources.DarkseaGreen31);
            objlistimg.Images.Add(ImageResources.DarkBlue);
            objlistimg.Images.Add(ImageResources.DimGrey);
            objlistimg.Images.Add(ImageResources.Chocolate);
            objlistimg.Images.Add(ImageResources.DarkKhaki);
            objlistimg.Images.Add(ImageResources.Black);
            objlistimg.Images.Add(ImageResources.Orange);
            objlistimg.Images.Add(ImageResources.Cyan);
            objlistimg.Images.Add(ImageResources.AquaMarine);
            objlistimg.Images.Add(ImageResources.Bisque);
            objlistimg.Images.Add(ImageResources.Blue);
            objlistimg.Images.Add(ImageResources.BlueViolet);
            objlistimg.Images.Add(ImageResources.Coral);
            objlistimg.Images.Add(ImageResources.Darkmagenta);
            objlistimg.Images.Add(ImageResources.DarkSlateBlue31);
            objlistimg.Images.Add(ImageResources.DarkVoilet31);
            objlistimg.Images.Add(ImageResources.Deeppink31);
            objlistimg.Images.Add(ImageResources.DodgerBlue);
            objlistimg.Images.Add(ImageResources.FireBrick);
            objlistimg.Images.Add(ImageResources.ForestGreen);
            objlistimg.Images.Add(ImageResources.GreenYellow);
            objlistimg.Images.Add(ImageResources.HotPink);
            objlistimg.Images.Add(ImageResources.IndianRed);
            objlistimg.Images.Add(ImageResources.Darkorange);
            objlistimg.Images.Add(ImageResources.Darkorchid);
            objlistimg.Images.Add(ImageResources.DeepSkyBlue31);
            objlistimg.Images.Add(ImageResources.SandyBrown);
            int GraphCount = XYData.Count / 2;
            xarrayNew = new double[0];
            yarrayNew = new double[0];
            try
            {
                for (int i = 0; i < GraphCount; i++)
                {
                    double[] xData = (double[])XYData[2 * i];
                    double[] yData = (double[])XYData[(2 * i) + 1];

                    if (_LineGraph == null)
                    {
                        _LineGraph = new LineGraphControl();
                        _LineGraph._MainForm = this;
                        _LineGraph.Name = "LineGraph" + i.ToString();
                        _LineGraph._ChartFooter = PublicClass.Chart_Footer;
                        _LineGraph._XLabel = PublicClass.x_Unit;
                        CurrentXLabel = _LineGraph._XLabel;
                        _LineGraph._YLabel = PublicClass.y_Unit;
                        CurrentYLabel = _LineGraph._YLabel;
                        _LineGraph._ChartHeader = ChartHeader;
                        _LineGraph._GraphBG1 = _GraphBG1;
                        _LineGraph._GraphBG2 = _GraphBG2;
                        _LineGraph._GraphBGDir = _GraphBGDir;
                        _LineGraph._ChartBG1 = _ChartBG1;
                        _LineGraph._ChartBG2 = _ChartBG2;
                        _LineGraph._ChartBGDir = _ChartBGDir;
                        _LineGraph._AxisColor = _AxisColor;
                        _LineGraph._MainCursorColor = _MainCursorColor;
                        _LineGraph._AreaFill = _AreaPlot;

                        _LineGraph.Dock = DockStyle.Fill;
                        ArrayList FaultNameWithValue1 = null;
                        FaultNameWithValue1 = drawPeak(XYData, RPMValues, false);
                        string[] FaultName = (string[])FaultNameWithValue[1];

                        _LineGraph.DrawLineGraphDiag(XYData, ColorCode, PublicClass.x_Unit, PublicClass.y_Unit, PublicClass.SPointID, FaultNameWithValue1);
                        objDiagnostic.panel1.Controls.Clear();
                        objDiagnostic.panel1.Controls.Add(_LineGraph);
                        objDiagnostic.dgvRPM.Rows.Clear();
                        objDiagnostic.dgvFaultName.Rows.Clear();
                        int FaultLength = 0;
                        for (int jk = 0; jk < FaultName.Length; jk++)
                        {
                            if (FaultName[jk] != null)
                            {
                                FaultLength++;
                            }
                        }

                        for (int ij = 0; ij < FaultLength; ij++)
                        {
                            try
                            {
                                string[] actFault = new string[2];
                                actFault = FaultName[ij].Split('/');
                                objDiagnostic.dgvFaultName.Rows.Add();
                                objDiagnostic.dgvFaultName.Rows[ij].Cells[0].Value = actFault[0];
                                objDiagnostic.dgvFaultName.Rows[ij].Cells[1].Value = actFault[1];
                                objDiagnostic.txtDescription.Text = PublicClass.Description;
                                Set_iClick(Function.Add);
                                arlstSColors.Add(ColorCode[ij]);
                                objDiagnostic.dgvFaultName.Rows[ij].Cells[3].Value = objlistimg.Images[icc];
                                objDiagnostic.dgvFaultName.Rows[ij].Cells[3].Tag = ColorCode[icc].ToString();
                                color++;
                                icc++;
                            }
                            catch
                            { }
                        }

                        for (int j = 0; j < Convert.ToInt32(allPeak); j++)
                        {
                            try
                            {
                                if (yData[yy[j]] != 0)
                                {
                                    objDiagnostic.dgvRPM.Rows.Add();
                                    objDiagnostic.dgvRPM.Rows[objDiagnostic.dgvRPM.Rows.Count - 2].Cells[0].Value = Convert.ToString(j + 1) + " Highest Peak";
                                    objDiagnostic.dgvRPM.Rows[objDiagnostic.dgvRPM.Rows.Count - 2].Cells[1].Value = Convert.ToString(Math.Round(Convert.ToDouble(xData[yy[j]]), 2));
                                    objDiagnostic.dgvRPM.Rows[objDiagnostic.dgvRPM.Rows.Count - 2].Cells[2].Value = Convert.ToString(Math.Round(Convert.ToDouble(yData[yy[j]]), 2));
                                    objDiagnostic.dgvRPM.Rows[objDiagnostic.dgvRPM.Rows.Count - 2].Cells[3].Value = Convert.ToString(Math.Round(Convert.ToDouble(xData[yy[j]]) * 60, 0));
                                }
                            }
                            catch { }
                        }
                        xarrayNew = xData;
                        yarrayNew = yData;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void bcmCursors_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                BarEditItem comboBox = sender as BarEditItem;
                string Edittext = comboBox.EditValue.ToString();
                cmbCurSors.SelectedItem = Edittext.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        public ArrayList FaultNameWithValue = new ArrayList(); string allPeak = null;

        bool[] finalstatus = new bool[1];
        public ArrayList drawPeak(ArrayList XYData1, string[] RPMValues, bool fstatus)
        {
            try
            {
                int Deviation = Convert.ToInt32(RPMValues[1]);
                dXVals = (double[])XYData1[0];
                dYVals = (double[])XYData1[1];
                finalstatus[0] = fstatus;
                double Fst = 0;
                double Scnd = 0;
                double Thrd = 0;

                try
                {
                    for (int i = 2; i < dYVals.Length; i++)
                    {
                        Fst = dYVals[i - 2];
                        Scnd = dYVals[i - 1];
                        Thrd = dYVals[i];

                        if (Fst < Scnd && Scnd > Thrd)
                        {
                            Array.Resize(ref Peeks, Peeks.Length + 1);
                            Peeks[Peeks.Length - 1] = i - 1;
                            Array.Resize(ref Peeks1, Peeks1.Length + 1);
                            Peeks1[Peeks1.Length - 1] = dYVals[i - 1];
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                xx = new double[Peeks.Length];
                yy = new int[Peeks1.Length];
                int pos = 0;
                for (int ictrx = 0; ictrx < Peeks.Length; ictrx++)
                {
                    for (int jctrx = ictrx; jctrx < Peeks1.Length; jctrx++)
                    {
                        if (xx[ictrx] < Peeks1[jctrx])
                        {
                            xx[ictrx] = Peeks1[jctrx];
                            yy[ictrx] = Peeks[jctrx];
                            pos = jctrx;
                        }
                    }
                    Peeks1[pos] = 0;
                    Peeks[pos] = 0;
                }
                int peak1 = Convert.ToInt32(dXVals[yy[0]] * 60);
                double peak21 = Convert.ToDouble(dYVals[yy[0]]);
                int rpm = 0, rpm1, rpm2;
                if (RPMValues[3] == "true")
                {
                    rpm = Convert.ToInt32(RPMValues[0]);
                    if (Math.Abs(rpm - peak1) < Convert.ToInt32(RPMValues[1]))
                    {
                        rpm = peak1;
                    }
                }
                else
                {
                    rpm1 = (Convert.ToInt32(RPMValues[0]) - Convert.ToInt32(RPMValues[1]));
                    rpm2 = (Convert.ToInt32(RPMValues[0]) + Convert.ToInt32(RPMValues[1]));
                    if (Enumerable.Range(rpm1, rpm2).Contains(peak1))
                    {
                        rpm = peak1;
                    }
                    else
                    {
                        rpm = Convert.ToInt32(RPMValues[0]);
                    }
                }

                double[] AllSignificantPeak = null;
                double[] AllSignificantPeakFreq = null;
                double rangeValue = (peak21 * 20) / 100;
                Array.Resize(ref AllSignificantPeak, 1);
                Array.Resize(ref AllSignificantPeakFreq, 1);
                AllSignificantPeakFreq[0] = Convert.ToDouble(dXVals[yy[0]]);
                AllSignificantPeak[0] = Convert.ToDouble(dYVals[yy[0]]);

                for (int i = 1; i < Peeks.Length; i++)
                {
                    double sigPeak = Convert.ToDouble(dYVals[yy[i]]);
                    if ((Convert.ToDouble(dYVals[yy[i]]) < peak21) && (Convert.ToDouble(dYVals[yy[i]]) > rangeValue))
                    {
                        Array.Resize(ref AllSignificantPeak, i + 1);
                        Array.Resize(ref AllSignificantPeakFreq, i + 1);
                        AllSignificantPeak[i] = Convert.ToDouble(dYVals[yy[i]]);
                        AllSignificantPeakFreq[i] = Convert.ToDouble(dXVals[yy[i]]);
                    }
                }

                double[] AllPeakOrder = null;
                string[] FaultName = null;

                for (int i = 0; i < AllSignificantPeakFreq.Length; i++)
                {
                    Array.Resize(ref AllPeakOrder, i + 1);
                    AllPeakOrder[i] = Math.Round(Convert.ToDouble((AllSignificantPeakFreq[i] * 60) / rpm), 2);
                }
                allPeak = Convert.ToString(AllPeakOrder.Length);
                Array.Resize(ref ff, AllPeakOrder.Length);
                Array.Resize(ref FaultName, AllPeakOrder.Length);

                double margin = Math.Round(((Convert.ToDouble(RPMValues[0]) * 5) / 100) / (Convert.ToDouble(RPMValues[0])), 3);

                PublicClass.Description = null;
                if (AllPeakOrder[0] <= (1.0 + margin) && AllPeakOrder[0] >= (1.0 - margin))
                {
                    if (allPeak == "1")
                    {
                        //case 1 Unbalance and possible Losseness Structural
                        ff[0] = yy[0];
                        FaultName[0] = "Unbalance / Losseness Structural";
                        PublicClass.Description = "Description :" + System.Environment.NewLine + "There is only one significant peak on first order";
                        finalstatus[0] = true;
                    }
                    else if (allPeak == "2")
                    {
                        if (AllPeakOrder[1] <= (2.0 + margin) && AllPeakOrder[1] >= (2.0 - margin))
                        {
                            //case 2 Bent Shaft

                            ff[0] = yy[0];
                            ff[1] = yy[1];
                            FaultName[0] = "Bent Shaft / Unbalance";
                            PublicClass.Description = "Description :" + System.Environment.NewLine + "There are two significant peaks and also first is on first order and second is on second order ";
                            finalstatus[0] = true;
                        }
                        else
                        {
                            ff[0] = yy[0];
                            ff[1] = yy[1];
                            FaultName[0] = "Unbalance";
                            PublicClass.Description = "Description :" + System.Environment.NewLine + "There are two significant peaks and also first is on first order and second is on more than fifth order";
                            finalstatus[0] = true;
                        }
                    }
                    else if (allPeak == "3")
                    {
                        if ((AllPeakOrder[1] <= (2.0 + margin) && AllPeakOrder[1] >= (2.0 - margin)) && (AllPeakOrder[2] <= (3.0 + margin) && AllPeakOrder[2] >= (3.0 - margin)))
                        {
                            //case 3 Angular Missalignment
                            ff[0] = yy[0];
                            ff[1] = yy[1];
                            ff[2] = yy[2];
                            FaultName[0] = "Angular Missalignment / Unbalance";
                            PublicClass.Description = "Description :" + System.Environment.NewLine + "There are three significant peaks and also first is on first order and second is on second or third order ";
                            finalstatus[0] = true;
                        }
                        else if ((AllPeakOrder[1] <= (3.0 + margin) && AllPeakOrder[1] >= (3.0 - margin)) && (AllPeakOrder[2] <= (2.0 + margin) && AllPeakOrder[2] >= (2.0 - margin)))
                        {
                            //case 4 Angular Missalignment
                            ff[0] = yy[0];
                            ff[1] = yy[1];
                            ff[2] = yy[2];
                            FaultName[0] = "Angular Missalignment / Unbalance";
                            PublicClass.Description = "Description :" + System.Environment.NewLine + "There are three significant peaks and also first is on first order and second is on third order";
                            finalstatus[0] = true;
                        }
                    }
                    else if (Convert.ToInt32(allPeak) >= 4)
                    {
                        if (AllPeakOrder[0] <= (1.0 + margin) && AllPeakOrder[0] >= (1.0 - margin))
                        {
                            if (AllPeakOrder[1] <= (2.0 + margin) && AllPeakOrder[1] >= (2.0 - margin))
                            {
                                //case 10 Losseness Rotating and possible  Unbalance
                                ff[0] = yy[0];
                                ff[1] = yy[1];
                                ff[2] = yy[2];
                                ff[3] = yy[3];
                                FaultName[0] = " Losseness Rotating / Unbalance";
                                PublicClass.Description = "Description :" + System.Environment.NewLine + "There are multiple significant peaks and also peaks are on first , second and so on up to tenth order.  ";
                                finalstatus[0] = true;
                            }
                            else if (AllPeakOrder[1] <= (3.0 + margin) && AllPeakOrder[1] >= (3.0 - margin))
                            {
                                //case 10 Losseness Rotating and possible  Unbalance
                                ff[0] = yy[0];
                                ff[1] = yy[1];
                                ff[2] = yy[2];
                                ff[3] = yy[3];
                                FaultName[0] = " Losseness Rotating / Unbalance";
                                PublicClass.Description = "Description :" + System.Environment.NewLine + "There are multiple significant peaks and also peaks are on first , second and so on up to tenth order. ";
                                finalstatus[0] = true;
                            }
                            else if (AllPeakOrder[1] <= (4.0 + margin) && AllPeakOrder[1] >= (4.0 - margin))
                            {
                                //case 10 Losseness Rotating and possible  Unbalance
                                ff[0] = yy[0];
                                ff[1] = yy[1];
                                ff[2] = yy[2];
                                ff[3] = yy[3];
                                FaultName[0] = " Losseness Rotating / Unbalance";
                                PublicClass.Description = "Description :" + System.Environment.NewLine + "There are multiple significant peaks and also peaks are on first , second and so on up to tenth order. ";
                                finalstatus[0] = true;
                            }
                            else if (AllPeakOrder[1] <= (5.0 + margin) && AllPeakOrder[1] >= (5.0 - margin))
                            {
                                //case 10 Losseness Rotating and possible  Unbalance
                                ff[0] = yy[0];
                                ff[1] = yy[1];
                                ff[2] = yy[2];
                                ff[3] = yy[3];
                                FaultName[0] = " Losseness Rotating / Unbalance";
                                PublicClass.Description = "Description :" + System.Environment.NewLine + "There are multiple significant peaks and also peaks are on first , second and so on up to tenth order. ";
                                finalstatus[0] = true;
                            }
                            else
                            {
                                ff[0] = yy[0];
                                FaultName[0] = "Unbalance / Losseness Structural";
                                PublicClass.Description = "Description :" + System.Environment.NewLine + "There are more than one significant peak but highest peak is on first order as per our basic fault detection system....";
                                finalstatus[0] = true;
                            }


                        }
                        else if (AllPeakOrder[0] <= (2.0 + margin) && AllPeakOrder[0] >= (2.0 - margin))
                        {
                            if (AllPeakOrder[1] <= (1.0 + margin) && AllPeakOrder[1] >= (1.0 - margin))
                            {
                                //case 11 Severe misalignment and possible Looseness
                                for (int i = 0; i > Convert.ToInt32(allPeak); i++)
                                {
                                    ff[i] = yy[i];
                                }
                                FaultName[0] = " Severe misalignment / Losseness Rotating";
                                PublicClass.Description = "Description :" + System.Environment.NewLine + "There are multiple significant peaks and also peaks are on first , second and so on up to tenth order. but first peak is on second order ";
                                finalstatus[0] = true;
                            }
                        }
                    }
                }
                else if (AllPeakOrder[0] <= (2.0 + margin) && AllPeakOrder[0] >= (2.0 - margin))
                {
                    if (allPeak == "3")
                    {
                        if ((AllPeakOrder[1] <= (1.0 + margin) && AllPeakOrder[1] >= (1.0 - margin)) && (AllPeakOrder[2] <= (3.0 + margin) && AllPeakOrder[2] >= (3.0 - margin)))
                        {
                            //case 5 Cocked bearing
                            ff[0] = yy[0];
                            ff[1] = yy[1];
                            ff[2] = yy[2];
                            FaultName[0] = "Cocked bearing / Parallel Misallignment";
                            PublicClass.Description = "Description :" + System.Environment.NewLine + "There are three significant peaks and also first is on second or first order and second is on first or second order and third is on third order  ";
                            finalstatus[0] = true;
                        }
                        else if ((AllPeakOrder[1] <= (1.0 + margin) && AllPeakOrder[1] >= (1.0 - margin)) && (AllPeakOrder[2] <= (3.0 + margin) && AllPeakOrder[2] >= (3.0 - margin)))
                        {
                            //case 6 Parallel Misallignment
                            ff[0] = yy[0];
                            ff[1] = yy[1];
                            ff[2] = yy[2];
                            FaultName[0] = " Parallel Misallignment / Cocked bearing";
                            PublicClass.Description = "Description :" + System.Environment.NewLine + "There are three significant peaks and also first is on second order and second is on first order and third is on third order ";
                            finalstatus[0] = true;
                        }
                        else if ((AllPeakOrder[1] <= (3.0 + margin) && AllPeakOrder[1] >= (3.0 - margin)) && (AllPeakOrder[2] <= (1.0 + margin) && AllPeakOrder[2] >= (1.0 - margin)))
                        {
                            //case 7 Parallel Misallignment
                            ff[0] = yy[0];
                            ff[1] = yy[1];
                            ff[2] = yy[2];
                            FaultName[0] = " Parallel Misallignment / Cocked bearing";
                            PublicClass.Description = "Description :" + System.Environment.NewLine + "There are three significant peaks and also first is on second order and second is on third order and third is on first order  ";
                            finalstatus[0] = true;
                        }
                    }
                    else if (allPeak == "4")
                    {
                        if (((AllPeakOrder[1] <= (1.0 + margin) && AllPeakOrder[1] >= (1.0 - margin)) && (AllPeakOrder[2] <= (3.0 + margin) && AllPeakOrder[2] >= (3.0 - margin))) && (AllPeakOrder[3] >= (1.0 - margin)))
                        {
                            //case 8 Losseness Pillow block
                            ff[0] = yy[0];
                            ff[1] = yy[1];
                            ff[2] = yy[2];
                            ff[3] = yy[3];
                            FaultName[0] = "Losseness Pillow block / Misallignment";
                            PublicClass.Description = "Description :" + System.Environment.NewLine + "There are four significant peaks and also first is on second order and second is on first order and third is on third order  ";
                            finalstatus[0] = true;
                        }
                        else if (((AllPeakOrder[1] <= (3.0 + margin) && AllPeakOrder[1] >= (3.0 - margin)) && (AllPeakOrder[2] <= (1.0 + margin) && AllPeakOrder[2] >= (1.0 - margin)) && (AllPeakOrder[3] >= (1.0 - margin))))
                        {
                            //case 9 Losseness Pillow block
                            ff[0] = yy[0];
                            ff[1] = yy[1];
                            ff[2] = yy[2];
                            ff[3] = yy[3];
                            FaultName[0] = "Losseness Pillow block / Misallignment";
                            PublicClass.Description = "Description :" + System.Environment.NewLine + "There are four significant peaks and also first is on second order and second is on third order and third is on first order  ";
                            finalstatus[0] = true;
                        }
                    }
                }
                else
                {
                    int firstOrder = Convert.ToInt32(AllPeakOrder[0]);

                    if (Convert.ToInt32(allPeak) >= 5)
                    {
                        if (AllPeakOrder[0] <= (1.0 + margin) && AllPeakOrder[0] >= (1.0 - margin))
                        {
                            if (AllPeakOrder[1] <= (2.0 + margin) && AllPeakOrder[1] >= (2.0 - margin))
                            {
                                //case 10 Losseness Rotating and possible  Unbalance
                                ff[0] = yy[0];
                                ff[1] = yy[1];
                                ff[2] = yy[2];
                                ff[3] = yy[3];
                                FaultName[0] = " Losseness Rotating / Unbalance";
                                PublicClass.Description = "Description :" + System.Environment.NewLine + "There are multiple significant peaks and also peaks are on first , second and so on up to tenth order. ";
                                finalstatus[0] = true;
                            }
                            else if (AllPeakOrder[1] <= (3.0 + margin) && AllPeakOrder[1] >= (3.0 - margin))
                            {
                                ff[0] = yy[0];
                                ff[1] = yy[1];
                                ff[2] = yy[2];
                                ff[3] = yy[3];
                                FaultName[0] = " Losseness Rotating / Unbalance";
                                PublicClass.Description = "Description :" + System.Environment.NewLine + "There are multiple significant peaks and also peaks are on first , second and so on up to tenth order. ";
                                finalstatus[0] = true;
                            }
                            else if (AllPeakOrder[1] <= (4.0 + margin) && AllPeakOrder[1] >= (4.0 - margin))
                            {
                                //case 10 Losseness Rotating and possible  Unbalance
                                ff[0] = yy[0];
                                ff[1] = yy[1];
                                ff[2] = yy[2];
                                ff[3] = yy[3];
                                FaultName[0] = " Losseness Rotating / Unbalance";
                                PublicClass.Description = "Description :" + System.Environment.NewLine + "There are multiple significant peaks and also peaks are on first , second and so on up to tenth order. ";
                                finalstatus[0] = true;
                            }
                            else if (AllPeakOrder[1] <= (5.0 + margin) && AllPeakOrder[1] >= (5.0 - margin))
                            {
                                //case 10 Losseness Rotating and possible  Unbalance
                                ff[0] = yy[0];
                                ff[1] = yy[1];
                                ff[2] = yy[2];
                                ff[3] = yy[3];
                                FaultName[0] = " Losseness Rotating / Unbalance";
                                PublicClass.Description = "Description :" + System.Environment.NewLine + "There are multiple significant peaks and also peaks are on first , second and so on up to tenth order. ";
                                finalstatus[0] = true;
                            }

                        }
                        else if (AllPeakOrder[0] <= (2.0 + margin) && AllPeakOrder[0] >= (2.0 - margin))
                        {
                            if (AllPeakOrder[1] <= (1.0 + margin) && AllPeakOrder[1] >= (1.0 - margin))
                            {
                                //case 11 Severe misalignment and possible Looseness
                                for (int i = 0; i > Convert.ToInt32(allPeak); i++)
                                {
                                    ff[i] = yy[i];
                                }
                                FaultName[0] = " Severe misalignment / Losseness Rotating";
                                PublicClass.Description = "Description :" + System.Environment.NewLine + "There are multiple significant peaks and also peaks are on first , second and so on up to tenth order. but first peak is on second order ";
                                finalstatus[0] = true;
                            }
                        }
                    }
                }
                for (int i = 0; i < _LineGraph.xx1.Length; i++)
                {
                    if (_LineGraph.xx1[i] == 0)
                        break;
                    Xdata12[i] = _LineGraph.xx1[i];
                    Ydata12[i] = _LineGraph.yy1[i];
                }
                FaultNameWithValue.Clear();
                FaultNameWithValue.Add(ff);
                FaultNameWithValue.Add(FaultName);
                FaultNameWithValue.Add(finalstatus);
            }
            catch
            { }
            return FaultNameWithValue;
        }

        private double CalculateMean(double[] Values)
        {
            double Mean = 0;
            double Sum = 0;
            try
            {
                for (int i = 0; i < Values.Length; i++)
                {
                    Sum += Values[i];
                }
                Mean = Sum / Values.Length;
            }
            catch (Exception ex)
            { }
            return Mean;
        }
        private double CalculateSigma(double[] XVal)
        {
            double s1 = 0;
            double s2 = 0;
            double sum1 = 0;
            double sum2 = 0;
            try
            {
                double mean = CalculateMean(XVal);
                for (int i = 0; i < XVal.Length; i++)
                {
                    s1 = XVal[i] - mean;
                    s1 *= s1;
                    sum1 += s1;
                }
                s2 = sum1 / XVal.Length;
                sum2 = Math.Sqrt(s2);
            }
            catch (Exception ex)
            {
            }
            return sum2;
        }

        float PrvsValX = 0;
        private bool KillCrs = false;
        Double RPM = 0;
        private bool SingleCrs = false;
        private bool HarmncCrs = false;
        private bool SideBndCsr = false;
        private bool SideBndCsrRatio = false;
        private bool SideBandTrndDrw = false;
        private bool PeekCursor = false;
        private bool SqureCrs = false;
        private bool LineCursor = false;
        private bool TwDSingleSqrCrs = false;
        private bool TwoDCrossHairCursor = false;
        private bool ThrdSqr = false;
        private bool ThrdLn = false;
        private bool MultipleCrsr = false;
        bool SelectBandTrend = false;
        public bool ShowRpmRatio = false;
        bool FaultFreq = false;
        string Yunits = null;
        string Xunits = null; string lastcursor = null;
        public string boolharmonic; public int counthar = 0; public double countharval = 0;
        string checkpole = null; int actualspeed;
        private void cmbCurSors_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrvsValX = 0;
            LineGraphControl _lineGraph = new LineGraphControl();
            ChartView _ChartView = new ChartView();
            boolharmonic = null;
            try
            {
                if (_LineGraph != null)
                {
                    _LineGraph._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph3 != null)
                {
                    _LineGraph3._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph2 != null)
                {
                    _LineGraph2._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph1 != null)
                {
                    _LineGraph1._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph4 != null)
                {
                    _LineGraph4._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph5 != null)
                {
                    _LineGraph5._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph6 != null)
                {
                    _LineGraph6._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph_Dual != null)
                {
                    _LineGraph_Dual._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph_cut1 != null)
                {
                    _LineGraph_cut1._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph_cut2 != null)
                {
                    _LineGraph_cut2._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph_cut3 != null)
                {
                    _LineGraph_cut3._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph_cut4 != null)
                {
                    _LineGraph_cut4._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph_cut5 != null)
                {
                    _LineGraph_cut5._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph_cut6 != null)
                {
                    _LineGraph_cut6._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph_cut7 != null)
                {
                    _LineGraph_cut7._DataGridView = objGcontrol.dataGridView1;
                }
                if (_LineGraph_cut8 != null)
                {
                    _LineGraph_cut8._DataGridView = objGcontrol.dataGridView1;
                }
                if (_3DGraph != null)
                {
                    _3DGraph._DataGridView = objGcontrol.dataGridView1;
                }
                if (_BarGraph != null)
                {
                    _BarGraph._DataGridView = objGcontrol.dataGridView1;
                }
                try
                {
                    if (bcmDirection.EditValue.ToString() == "All Direction")
                    {
                        _LineGraph1._DataGridView = objGcontrol.dataGridView1;
                        _LineGraph2._DataGridView = objGcontrol.dataGridView1;
                        _LineGraph3._DataGridView = objGcontrol.dataGridView1;
                        _LineGraph4._DataGridView = objGcontrol.dataGridView1;
                    }
                }
                catch
                {
                }
                objGcontrol.dataGridView1.Rows.Clear();
                objGcontrol.dataGridView3.Rows.Clear();
                objGcontrol.DataGridSettingForDifferenceCursor(false);
                objGcontrol.DataGridSettingForPhase(false);
                string SlctedCursor = cmbCurSors.SelectedItem.ToString();
                if (lastcursor == "Highest 10 Peeks" || lastcursor == "Refrence Cursor")
                {
                    lastcursor = null;
                    m_PointGeneral1.allGraph(PublicClass.GraphClicked, "Power");
                }
                if (lastcursor == "Harmonic")
                {
                    _LineGraph.deletemarker();
                    //ShowRpmRatio = true;
                    //bbRPM.PerformClick();
                }

                switch (SlctedCursor)
                {
                    case "Single":
                        {
                            SingleCrs = true;
                            HarmncCrs = false;
                            SideBndCsr = false;
                            SideBndCsrRatio = false;
                            SideBandTrndDrw = false;
                            PeekCursor = false;
                            TwDSingleSqrCrs = false;
                            TwoDCrossHairCursor = false;
                            ThrdSqr = false;
                            ThrdLn = false;
                            KillCrs = false;
                            MultipleCrsr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Single");
                            }
                            if (_LineGraph3 != null)
                            {
                                _LineGraph3.SetCursorType("Single");
                            }
                            if (_LineGraph2 != null)
                            {
                                _LineGraph2.SetCursorType("Single");
                            }
                            if (_LineGraph1 != null)
                            {
                                _LineGraph1.SetCursorType("Single");
                            }
                            if (_LineGraph4 != null)
                            {
                                _LineGraph4.SetCursorType("Single");
                            }
                            if (_LineGraph5 != null)
                            {
                                _LineGraph5.SetCursorType("Single");
                            }
                            if (_LineGraph6 != null)
                            {
                                _LineGraph6.SetCursorType("Single");
                            }
                            if (_LineGraph_Dual != null)
                            {
                                _LineGraph_Dual.SetCursorType("Single");
                            }
                            if (_LineGraph_cut1 != null)
                            {
                                _LineGraph_cut1.SetCursorType("Single");
                            }
                            if (_LineGraph_cut2 != null)
                            {
                                _LineGraph_cut2.SetCursorType("Single");
                            }
                            if (_LineGraph_cut3 != null)
                            {
                                _LineGraph_cut3.SetCursorType("Single");
                            }
                            if (_LineGraph_cut4 != null)
                            {
                                _LineGraph_cut4.SetCursorType("Single");
                            }
                            if (_LineGraph_cut5 != null)
                            {
                                _LineGraph_cut5.SetCursorType("Single");
                            }
                            if (_LineGraph_cut6 != null)
                            {
                                _LineGraph_cut6.SetCursorType("Single");
                            }
                            if (_LineGraph_cut7 != null)
                            {
                                _LineGraph_cut7.SetCursorType("Single");
                            }
                            if (_LineGraph_cut8 != null)
                            {
                                _LineGraph_cut8.SetCursorType("Single");
                            }
                            if (_LineGraph_cut9 != null)
                            {
                                _LineGraph_cut9.SetCursorType("Single");
                            }
                            if (_LineGraph_cut10 != null)
                            {
                                _LineGraph_cut10.SetCursorType("Single");
                            }

                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("Single");
                            }
                            if (_3DGraph != null)
                            {
                                _3DGraph.SetCursorType("Single");
                            }
                            if (bcmDirection.EditValue.ToString() == "All Direction")
                            {
                                _LineGraph1.SetCursorType("Single");
                                _LineGraph2.SetCursorType("Single");
                                _LineGraph3.SetCursorType("Single");
                                _LineGraph4.SetCursorType("Single");
                            }
                            break;
                        }
                    case "Harmonic":
                        {
                            lastcursor = "Harmonic";
                            HarmncCrs = true;
                            SideBndCsr = false;
                            SideBndCsrRatio = false;
                            SideBandTrndDrw = false;
                            PeekCursor = false;
                            SingleCrs = false;
                            TwDSingleSqrCrs = false;
                            TwoDCrossHairCursor = false;
                            ThrdSqr = false;
                            ThrdLn = false;
                            KillCrs = false;
                            MultipleCrsr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Harmonic");
                            }
                            if (_LineGraph3 != null)
                            {
                                _LineGraph3.SetCursorType("Harmonic");
                            }
                            if (_LineGraph2 != null)
                            {
                                _LineGraph2.SetCursorType("Harmonic");
                            }
                            if (_LineGraph1 != null)
                            {
                                _LineGraph1.SetCursorType("Harmonic");
                            }
                            if (_LineGraph4 != null)
                            {
                                _LineGraph4.SetCursorType("Harmonic");
                            }
                            if (_LineGraph5 != null)
                            {
                                _LineGraph5.SetCursorType("Harmonic");
                            }
                            if (_LineGraph6 != null)
                            {
                                _LineGraph6.SetCursorType("Harmonic");
                            }
                            if (_LineGraph_Dual != null)
                            {
                                _LineGraph_Dual.SetCursorType("Harmonic");
                            }
                            if (_LineGraph_cut1 != null)
                            {
                                _LineGraph_cut1.SetCursorType("Harmonic");
                            }
                            if (_LineGraph_cut2 != null)
                            {
                                _LineGraph_cut2.SetCursorType("Harmonic");
                            }
                            if (_LineGraph_cut3 != null)
                            {
                                _LineGraph_cut3.SetCursorType("Harmonic");
                            }
                            if (_LineGraph_cut4 != null)
                            {
                                _LineGraph_cut4.SetCursorType("Harmonic");
                            }
                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("Select Cursor");
                            }
                            if (_3DGraph != null)
                            {
                                _3DGraph.SetCursorType("Select Cursor");
                            }
                            DialogResult Drslt = MessageBox.Show("Press Yes to set values with Refrence Value" + "\n" + "Press NO to set Harmonic with techo data" + "\n" + "Press Cancel to Close", "Harmonic", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                            if (Drslt == DialogResult.Yes)
                            {
                                try
                                {
                                    frmRpmCount objhRpm = new frmRpmCount();
                                    PublicClass.checkname = "Harmonic";
                                    objhRpm.Text = "Harmonic value";
                                    PublicClass.flag = true;
                                    objhRpm.ShowDialog();
                                    //ShowRpmRatio = true;
                                    //bbRPM.PerformClick();
                                    counthar = objhRpm._refcount;
                                    countharval = objhRpm._refValue;
                                    double aa = Convert.ToDouble(objhRpm._refValue);
                                    double bb = Convert.ToDouble(PublicClass.chartscale);
                                    if (aa < bb)
                                    {
                                        if (aa != 0.0)
                                        {
                                            if (counthar == 0)
                                            {
                                                return;
                                            }
                                            else
                                            { boolharmonic = "true"; }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Value Can Not be Greater Than Chart Band", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                catch { }
                            }
                            if (Drslt == DialogResult.No)
                            {
                                boolharmonic = "false";
                                rpmCheck = true;
                                ShowRpmRatio = false;
                                bbRPM.PerformClick();
                                return;
                            }

                            break;
                        }
                    case "Line":
                        {
                            SingleCrs = false;
                            SideBndCsr = false;
                            SideBndCsrRatio = false;
                            SideBandTrndDrw = false;
                            TwDSingleSqrCrs = false;
                            ThrdSqr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Line");
                            }

                            double[] xx = new double[1];
                            int[] yy = new int[1]; ArrayList newxyval1 = new ArrayList();
                            double[] Xdata12 = new double[1];
                            double[] Ydata12 = new double[1];
                            arrselectedDate.Add(PublicClass.tym);
                            arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, EdittextDirection);
                            if (arrXYVals.Count > 0)
                            {
                                dXVals = (double[])arrXYVals[0];
                                dYVals = (double[])arrXYVals[1];
                            }
                            double[][] darrValues = { dXVals, dYVals };
                            newxyval.Add(darrValues);
                            newxyval1.Add(dXVals); newxyval1.Add(dYVals);
                            if (dXVals.Length > 1 && dYVals.Length > 1)
                            {
                                Yunits = m_PointGeneral1.getUnitValuesforgraph(PublicClass.GraphClicked);
                                Xunits = null;
                                switch (PublicClass.GraphClicked)
                                {
                                    case "Time":
                                    case "Cepstrum":
                                        {
                                            Xunits = "Sec";
                                            break;
                                        }
                                    case "Power":
                                    case "Power1":
                                    case "Power2":
                                    case "Power21":
                                    case "Power3":
                                    case "Power31":
                                    case "Demodulate":
                                        {
                                            Xunits = "Hz";
                                            break;
                                        }
                                    case "Trend":
                                        {
                                            Xunits = "Date and Time";
                                            break;
                                        }
                                }
                            }
                            double[] ff = new double[1];
                            double Fst = 0;
                            double Scnd = 0;
                            double Thrd = 0;
                            try
                            {
                                for (int i = 2; i < dYVals.Length; i++)
                                {
                                    Fst = dYVals[i - 2];
                                    Scnd = dYVals[i - 1];
                                    Thrd = dYVals[i];
                                    if (Fst < Scnd && Scnd > Thrd)
                                    {
                                        Array.Resize(ref Peeks, Peeks.Length + 1);
                                        Peeks[Peeks.Length - 1] = i - 1;
                                        Array.Resize(ref Peeks1, Peeks1.Length + 1);
                                        Peeks1[Peeks1.Length - 1] = dYVals[i - 1];
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            xx[0] = 0;
                            int pos = 0;
                            for (int ictrx = 0; ictrx < 1; ictrx++)
                            {
                                for (int jctrx = ictrx; jctrx < Peeks1.Length; jctrx++)
                                {
                                    if (xx[ictrx] < Peeks1[jctrx])
                                    {
                                        xx[ictrx] = Peeks1[jctrx];
                                        yy[ictrx] = Peeks[jctrx];
                                        pos = jctrx;
                                    }
                                }
                                Peeks1[pos] = 0;
                                Peeks[pos] = 0;
                            }

                            PublicClass.Xline = Convert.ToDouble(dXVals[yy[0]]);
                            PublicClass.Yline = Convert.ToDouble(xx[0]);
                            break;
                        }
                    case "Line With SideBand":
                        {
                            SingleCrs = false;
                            SideBndCsr = false;
                            SideBndCsrRatio = false;
                            SideBandTrndDrw = false;
                            TwDSingleSqrCrs = false;
                            ThrdSqr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Line With SideBand");
                            }

                            try
                            {
                                SideBandValue objSideBand = new SideBandValue();
                                objSideBand.check = true;
                                objSideBand.ShowDialog();
                                PublicClass.checkpole = objSideBand.checkpole;
                                PublicClass.actualspeed = objSideBand.Actualspeed;
                            }
                            catch { }


                            double[] xx = new double[1];
                            int[] yy = new int[1]; ArrayList newxyval1 = new ArrayList();
                            double[] Xdata12 = new double[1];
                            double[] Ydata12 = new double[1];
                            arrselectedDate.Add(PublicClass.tym);
                            arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, EdittextDirection);
                            if (arrXYVals.Count > 0)
                            {
                                dXVals = (double[])arrXYVals[0];
                                dYVals = (double[])arrXYVals[1];
                            }
                            double[][] darrValues = { dXVals, dYVals };
                            newxyval.Add(darrValues);
                            newxyval1.Add(dXVals); newxyval1.Add(dYVals);
                            if (dXVals.Length > 1 && dYVals.Length > 1)
                            {
                                Yunits = m_PointGeneral1.getUnitValuesforgraph(PublicClass.GraphClicked);
                                Xunits = null;
                                switch (PublicClass.GraphClicked)
                                {
                                    case "Time":
                                    case "Cepstrum":
                                        {
                                            Xunits = "Sec";
                                            break;
                                        }
                                    case "Power":
                                    case "Power1":
                                    case "Power2":
                                    case "Power21":
                                    case "Power3":
                                    case "Power31":
                                    case "Demodulate":
                                        {
                                            Xunits = "Hz";
                                            break;
                                        }
                                    case "Trend":
                                        {
                                            Xunits = "Date and Time";
                                            break;
                                        }
                                }
                            }
                            double[] ff = new double[1];
                            double Fst = 0;
                            double Scnd = 0;
                            double Thrd = 0;
                            try
                            {
                                for (int i = 2; i < dYVals.Length; i++)
                                {
                                    Fst = dYVals[i - 2];
                                    Scnd = dYVals[i - 1];
                                    Thrd = dYVals[i];
                                    if (Fst < Scnd && Scnd > Thrd)
                                    {
                                        Array.Resize(ref Peeks, Peeks.Length + 1);
                                        Peeks[Peeks.Length - 1] = i - 1;
                                        Array.Resize(ref Peeks1, Peeks1.Length + 1);
                                        Peeks1[Peeks1.Length - 1] = dYVals[i - 1];
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            xx[0] = 0;
                            int pos = 0;
                            for (int ictrx = 0; ictrx < 1; ictrx++)
                            {
                                for (int jctrx = ictrx; jctrx < Peeks1.Length; jctrx++)
                                {
                                    if (xx[ictrx] < Peeks1[jctrx])
                                    {
                                        xx[ictrx] = Peeks1[jctrx];
                                        yy[ictrx] = Peeks[jctrx];
                                        pos = jctrx;
                                    }
                                }
                                Peeks1[pos] = 0;
                                Peeks[pos] = 0;
                            }

                            PublicClass.Xline = Convert.ToDouble(dXVals[yy[0]]);
                            PublicClass.Yline = Convert.ToDouble(xx[0]);

                            break;
                        }
                    case "Highest 10 Peeks":
                        {
                            KillCrs = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Highest 10 Peeks");
                            }
                            //lastcursor = "Highest 10 Peeks";
                            double[] xx = new double[10];
                            int[] yy = new int[10]; ArrayList newxyval1 = new ArrayList();
                            double[] Xdata12 = new double[10];
                            double[] Ydata12 = new double[10];
                            arrselectedDate.Add(PublicClass.tym);
                            arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, EdittextDirection);
                            if (arrXYVals.Count > 0)
                            {
                                if (Zoom == true)
                                {
                                    PublicClass.zoom = true;
                                    double Value = 0.0; int Xminindex = 0; int Xmaxindex = 0; double[] dXVals1 = null;
                                    double[] dYVals1 = null;
                                    int Xmin = Convert.ToInt32(PublicClass.XMin); int Xmax = Convert.ToInt32(PublicClass.XMax);
                                    int Subtract = Xmax - Xmin;
                                    dXVals1 = (double[])arrXYVals[0];
                                    dYVals1 = (double[])arrXYVals[1];
                                    try
                                    {
                                        for (int i = 0; i < dXVals1.Length; i++)
                                        {
                                            Value = dXVals1[i];
                                            if (Value > Xmin)
                                            {
                                                Xminindex = i;
                                                break;
                                            }
                                        }
                                        for (int i = 0 + Xminindex; i < dXVals1.Length; i++)
                                        {
                                            Value = dXVals1[i];
                                            if (Value > Xmax)
                                            {
                                                Xmaxindex = i;
                                                break;
                                            }
                                        }
                                        int checkdouble = Xmaxindex - Xminindex;
                                        dXVals = new double[checkdouble];
                                        dYVals = new double[checkdouble];
                                        for (int i = 0; i < checkdouble; i++)
                                        {
                                            dXVals[i] = Convert.ToDouble(dXVals1[Xminindex]);
                                            dYVals[i] = Convert.ToDouble(dYVals1[Xminindex]);
                                            Xminindex++;
                                        }
                                    }
                                    catch { }
                                }
                                else
                                {
                                    dXVals = (double[])arrXYVals[0];
                                    dYVals = (double[])arrXYVals[1];
                                }
                                double[][] darrValues = { dXVals, dYVals };
                                newxyval.Add(darrValues);
                                newxyval1.Add(dXVals); newxyval1.Add(dYVals);
                                if (dXVals.Length > 1 && dYVals.Length > 1)
                                {
                                    if (PublicClass.currentInstrument == "Kohtect-C911")
                                    {
                                        string XY = m_PointGeneral1.getUnitValuesC911();
                                        string[] graph = XY.Split(new char[] { ',' });
                                        Xunits = graph[0];
                                        Yunits = graph[1];
                                    }
                                    else
                                    {
                                        Yunits = m_PointGeneral1.getUnitValuesforgraph(PublicClass.GraphClicked);
                                        Xunits = null;
                                        switch (PublicClass.GraphClicked)
                                        {
                                            case "Time":
                                            case "Cepstrum":
                                                {
                                                    Xunits = "Sec";
                                                    break;
                                                }
                                            case "Power":
                                            case "Power1":
                                            case "Power2":
                                            case "Power21":
                                            case "Power3":
                                            case "Power31":
                                            case "Demodulate":
                                                {
                                                    Xunits = "Hz";
                                                    break;
                                                }
                                            case "Trend":
                                                {
                                                    Xunits = "Date and Time";
                                                    break;
                                                }
                                        }
                                    }
                                }
                            }

                            double[] ff = new double[10];
                            double Fst = 0;
                            double Scnd = 0;
                            double Thrd = 0;
                            try
                            {
                                for (int i = 2; i < dYVals.Length; i++)
                                {
                                    Fst = dYVals[i - 2];
                                    Scnd = dYVals[i - 1];
                                    Thrd = dYVals[i];
                                    if (Fst < Scnd && Scnd > Thrd)
                                    {
                                        Array.Resize(ref Peeks, Peeks.Length + 1);
                                        Peeks[Peeks.Length - 1] = i - 1;
                                        Array.Resize(ref Peeks1, Peeks1.Length + 1);
                                        Peeks1[Peeks1.Length - 1] = dYVals[i - 1];
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                            }
                            xx[0] = 0;
                            xx[1] = 0;
                            xx[2] = 0;
                            xx[3] = 0;
                            xx[4] = 0;
                            xx[5] = 0;
                            xx[6] = 0;
                            xx[7] = 0;
                            xx[8] = 0;
                            xx[9] = 0;
                            int pos = 0;
                            for (int ictrx = 0; ictrx < 10; ictrx++)
                            {
                                for (int jctrx = ictrx; jctrx < Peeks1.Length; jctrx++)
                                {
                                    if (xx[ictrx] < Peeks1[jctrx])
                                    {
                                        xx[ictrx] = Peeks1[jctrx];
                                        yy[ictrx] = Peeks[jctrx];
                                        pos = jctrx;
                                    }
                                }
                                Peeks1[pos] = 0;
                                Peeks[pos] = 0;
                            }
                            DataTable dtrpm = DbClass.getdata(CommandType.Text, "select ordertrace_rpm from Point_Data where Point_id = '" + PublicClass.SPointID + "' and measure_time = '" + PublicClass.tym + "'");
                            foreach (DataRow dr1 in dtrpm.Rows)
                            {
                                RPM = Convert.ToDouble(dr1["ordertrace_rpm"].ToString());
                            }
                            if (RPM == 0)
                            {
                                DataTable dtmid = DbClass.getdata(CommandType.Text, "select RPM_Driven from machine_info where machine_id in (Select Machine_ID from point where Point_ID = '" + PublicClass.SPointID + "') ");

                                foreach (DataRow dr2 in dtmid.Rows)
                                {
                                    RPM = Convert.ToDouble(dr2["RPM_Driven"].ToString());
                                }
                            }
                            RemovePreviousGraphControl();
                            int GraphCount = arrXYVals.Count / 2;
                            xarrayNew = new double[0];
                            yarrayNew = new double[0];
                            for (int i = 0; i < GraphCount; i++)
                            {
                                if (Zoom == true)
                                {
                                    double[] xData = (double[])newxyval1[2 * i];
                                    double[] yData = (double[])newxyval1[(2 * i) + 1];
                                    xarrayNew = xData;
                                    yarrayNew = yData;
                                }
                                else
                                {
                                    double[] xData = (double[])arrXYVals[2 * i];
                                    double[] yData = (double[])arrXYVals[(2 * i) + 1];
                                    xarrayNew = xData;
                                    yarrayNew = yData;
                                }
                                if (_LineGraph == null)
                                {
                                    _LineGraph = new LineGraphControl();
                                    _LineGraph._MainForm = this;
                                    _LineGraph.Name = "LineGraph" + i.ToString();
                                    _LineGraph._ChartFooter = PublicClass.Chart_Footer;
                                    _LineGraph._XLabel = PublicClass.x_Unit;
                                    CurrentXLabel = _LineGraph._XLabel;
                                    _LineGraph._YLabel = PublicClass.y_Unit;
                                    CurrentYLabel = _LineGraph._YLabel;
                                    _LineGraph._ChartHeader = ChartHeader;
                                    _LineGraph._GraphBG1 = _GraphBG1;
                                    _LineGraph._GraphBG2 = _GraphBG2;
                                    _LineGraph._GraphBGDir = _GraphBGDir;
                                    _LineGraph._ChartBG1 = _ChartBG1;
                                    _LineGraph._ChartBG2 = _ChartBG2;
                                    _LineGraph._ChartBGDir = _ChartBGDir;
                                    _LineGraph._AxisColor = _AxisColor;
                                    _LineGraph._MainCursorColor = _MainCursorColor;
                                    _LineGraph._AreaFill = _AreaPlot;
                                    if (Zoom == true)
                                    {
                                        _LineGraph.DrawReportGraph2(newxyval1, ColorCode, Xunits, Yunits, RPM, this, PublicClass.ReportName, PublicClass.SPointID, yy);
                                    }
                                    else
                                    {
                                        _LineGraph.DrawReportGraph2(arrXYVals, ColorCode, Xunits, Yunits, RPM, this, PublicClass.ReportName, PublicClass.SPointID, yy);
                                    }
                                    for (int a = 0; a < _lineGraph.xx1.Length; a++)
                                    {
                                        if (_lineGraph.xx1[a] == 0)
                                            break;
                                        Xdata12[a] = _lineGraph.xx1[a];
                                        Ydata12[a] = _lineGraph.yy1[a];
                                    }
                                    objGcontrol.panel1.Controls.Clear();
                                    _LineGraph.Dock = DockStyle.Fill;
                                    objGcontrol.panel1.Controls.Add(_LineGraph);

                                    for (int j = 0; j < 10; j++)
                                    {
                                        objGcontrol.dataGridView3.Rows.Add();
                                        objGcontrol.dataGridView3.Rows[objGcontrol.dataGridView3.Rows.Count - 2].Cells[0].Value = Convert.ToString(j + 1) + " Highest Peak";
                                        objGcontrol.dataGridView3.Rows[objGcontrol.dataGridView3.Rows.Count - 2].Cells[1].Value = Convert.ToString(Math.Round(Convert.ToDouble(dXVals[yy[j]]), 2));
                                        objGcontrol.dataGridView3.Rows[objGcontrol.dataGridView3.Rows.Count - 2].Cells[2].Value = Convert.ToString(Math.Round(Convert.ToDouble(xx[j]), 2));
                                    }
                                }
                            }
                            break;
                        }
                    case "Refrence Cursor":
                        {
                            try
                            {
                                KillCrs = false;
                                if (_LineGraph != null)
                                {
                                    _LineGraph.SetCursorType("Refrence Cursor");
                                }
                                frmRpmCount rpmcount = new frmRpmCount();
                                rpmcount.Text = "Refrence Value";
                                PublicClass.checkname = SlctedCursor;
                                PublicClass.flag = true;
                                rpmcount.ShowDialog();
                                string value = rpmcount._overall;
                                if (value != "0")
                                {
                                    if (value != "")
                                    {
                                        string[] overall = new string[] { value };
                                        FaultFreq = true;
                                        bool bReturned = _LineGraph.DrawFaultFrequencies(FaultFreq, overall, objGcontrol.dataGridView3);
                                        if (!bReturned)
                                        {
                                            FaultFreq = false;
                                            objGcontrol.Datagrid3visible = false;
                                        }
                                        else
                                        {
                                            objGcontrol.Datagrid3visible = true;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show(this, "Value Can Not be Greater Than Chart Band", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                                        CmbCursorSelectedItem(SelectedCursorItem);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Please Enter Any Value", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                                    CmbCursorSelectedItem(SelectedCursorItem);
                                    return;
                                }
                            }
                            catch
                            { }
                            break;
                        }
                    case "Single With Square":
                        {
                            TwDSingleSqrCrs = true;
                            SideBndCsr = false;
                            PeekCursor = false;
                            SideBndCsrRatio = false;
                            SideBandTrndDrw = false;
                            HarmncCrs = false;
                            SingleCrs = false;
                            TwoDCrossHairCursor = false;
                            ThrdSqr = false;
                            ThrdLn = false;
                            KillCrs = false;
                            MultipleCrsr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Single With Square");
                            }
                            if (_LineGraph3 != null)
                            {
                                _LineGraph3.SetCursorType("Single With Square");
                            }
                            if (_LineGraph2 != null)
                            {
                                _LineGraph2.SetCursorType("Single With Square");
                            }
                            if (_LineGraph1 != null)
                            {
                                _LineGraph1.SetCursorType("Single With Square");
                            }
                            if (_LineGraph4 != null)
                            {
                                _LineGraph4.SetCursorType("Single With Square");
                            }
                            if (_LineGraph5 != null)
                            {
                                _LineGraph5.SetCursorType("Single With Square");
                            }
                            if (_LineGraph6 != null)
                            {
                                _LineGraph6.SetCursorType("Single With Square");
                            }

                            if (_LineGraph_Dual != null)
                            {
                                _LineGraph_Dual.SetCursorType("Single With Square");
                            }

                            if (_LineGraph_cut1 != null)
                            {
                                _LineGraph_cut1.SetCursorType("Single With Square");
                            }
                            if (_LineGraph_cut2 != null)
                            {
                                _LineGraph_cut2.SetCursorType("Single With Square");
                            }
                            if (_LineGraph_cut3 != null)
                            {
                                _LineGraph_cut3.SetCursorType("Single With Square");
                            }
                            if (_LineGraph_cut4 != null)
                            {
                                _LineGraph_cut4.SetCursorType("Single With Square");
                            }
                            if (_LineGraph_cut5 != null)
                            {
                                _LineGraph_cut5.SetCursorType("Single With Square");
                            }
                            if (_LineGraph_cut6 != null)
                            {
                                _LineGraph_cut6.SetCursorType("Single With Square");
                            }
                            if (_LineGraph_cut7 != null)
                            {
                                _LineGraph_cut7.SetCursorType("Single With Square");
                            }
                            if (_LineGraph_cut8 != null)
                            {
                                _LineGraph_cut8.SetCursorType("Single With Square");
                            }
                            if (_LineGraph_cut9 != null)
                            {
                                _LineGraph_cut9.SetCursorType("Single With Square");
                            }
                            if (_LineGraph_cut10 != null)
                            {
                                _LineGraph_cut10.SetCursorType("Single With Square");
                            }


                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("Single With Square");
                            }
                            if (_3DGraph != null)
                            {
                                _3DGraph.SetCursorType("Single With Square");
                            }
                            if (bcmDirection.EditValue.ToString() == "All Direction")
                            {
                                _LineGraph1.SetCursorType("Single With Square");
                                _LineGraph2.SetCursorType("Single With Square");
                                _LineGraph3.SetCursorType("Single With Square");
                                _LineGraph4.SetCursorType("Single With Square");
                            }
                            break;
                        }
                    case "Cross Hair":
                        {
                            TwoDCrossHairCursor = true;
                            SideBndCsr = false;
                            PeekCursor = false;
                            SideBndCsrRatio = false;
                            SideBandTrndDrw = false;
                            TwDSingleSqrCrs = false;
                            HarmncCrs = false;
                            SingleCrs = false;
                            ThrdSqr = false;
                            ThrdLn = false;
                            KillCrs = false;
                            MultipleCrsr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph3 != null)
                            {
                                _LineGraph3.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph2 != null)
                            {
                                _LineGraph2.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph1 != null)
                            {
                                _LineGraph1.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph4 != null)
                            {
                                _LineGraph4.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph5 != null)
                            {
                                _LineGraph5.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph6 != null)
                            {
                                _LineGraph6.SetCursorType("Cross Hair");
                            }

                            if (_LineGraph_Dual != null)
                            {
                                _LineGraph_Dual.SetCursorType("Cross Hair");
                            }

                            if (_LineGraph_cut1 != null)
                            {
                                _LineGraph_cut1.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph_cut2 != null)
                            {
                                _LineGraph_cut2.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph_cut3 != null)
                            {
                                _LineGraph_cut3.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph_cut4 != null)
                            {
                                _LineGraph_cut4.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph_cut5 != null)
                            {
                                _LineGraph_cut5.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph_cut6 != null)
                            {
                                _LineGraph_cut6.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph_cut7 != null)
                            {
                                _LineGraph_cut7.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph_cut8 != null)
                            {
                                _LineGraph_cut8.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph_cut9 != null)
                            {
                                _LineGraph_cut9.SetCursorType("Cross Hair");
                            }
                            if (_LineGraph_cut10 != null)
                            {
                                _LineGraph_cut10.SetCursorType("Cross Hair");
                            }

                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("Cross Hair");
                            }
                            if (_3DGraph != null)
                            {
                                _3DGraph.SetCursorType("Cross Hair");
                            }
                            if (bcmDirection.EditValue.ToString() == "All Direction")
                            {
                                _LineGraph1.SetCursorType("Cross Hair");
                                _LineGraph2.SetCursorType("Cross Hair");
                                _LineGraph3.SetCursorType("Cross Hair");
                                _LineGraph4.SetCursorType("Cross Hair");
                            }
                            break;
                        }
                    case "Sideband":
                        {
                            SideBndCsr = true;
                            SideBndCsrRatio = false;
                            PeekCursor = false;
                            SideBandTrndDrw = false;
                            TwoDCrossHairCursor = false;
                            TwDSingleSqrCrs = false;
                            HarmncCrs = false;
                            SingleCrs = false;
                            ThrdSqr = false;
                            ThrdLn = false;
                            KillCrs = false;
                            MultipleCrsr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Sideband");
                            }
                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("Select Cursor");
                            }
                            if (_3DGraph != null)
                            {
                                _3DGraph.SetCursorType("Select Cursor");
                            }
                            break;
                        }

                    case "SidebandRatio":
                        {
                            SideBndCsr = false;
                            SideBndCsrRatio = true;
                            SideBandTrndDrw = false;
                            PeekCursor = false;
                            TwoDCrossHairCursor = false;
                            TwDSingleSqrCrs = false;
                            HarmncCrs = false;
                            SingleCrs = false;
                            ThrdSqr = false;
                            ThrdLn = false;
                            KillCrs = false;
                            MultipleCrsr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("SidebandRatio");
                            }
                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("Select Cursor");
                            }
                            if (_3DGraph != null)
                            {
                                _3DGraph.SetCursorType("Select Cursor");
                            }
                            break;
                        }
                    case "SideBandTrend":
                        {
                            KillCrs = false;
                            SideBandTrndDrw = true;
                            SideBndCsr = false;
                            PeekCursor = false;
                            SideBndCsrRatio = false;
                            TwoDCrossHairCursor = false;
                            TwDSingleSqrCrs = false;
                            HarmncCrs = false;
                            SingleCrs = false;
                            ThrdSqr = false;
                            ThrdLn = false;
                            SelectBandTrend = false;
                            MultipleCrsr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("SideBandTrend");
                            }
                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("SideBandTrend");
                            }
                            if (_3DGraph != null)
                            {
                                _3DGraph.SetCursorType("Select Cursor");
                            }
                            break;
                        }
                    case "PeekCursor":
                        {
                            SideBandTrndDrw = false;
                            SideBndCsr = false;
                            PeekCursor = true;
                            SideBndCsrRatio = false;
                            TwoDCrossHairCursor = false;
                            TwDSingleSqrCrs = false;
                            HarmncCrs = false;
                            SingleCrs = false;
                            ThrdSqr = false;
                            ThrdLn = false;
                            FindAllPeaks();
                            KillCrs = false;
                            MultipleCrsr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("PeekCursor");
                            }
                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("PeekCursor");
                            }
                            if (_3DGraph != null)
                            {
                                _3DGraph.SetCursorType("Select Cursor");
                            }
                            break;
                        }
                    case "Delta Cursors":
                        {
                            BearingFaultFrequency = false;
                            FaultFreq = false;
                            ShowRpmRatio = false;

                            objGcontrol.DataGridSettingForDifferenceCursor(true);
                            SelectedRowIndex = 0;

                            KillCrs = false;
                            MultipleCrsr = true;

                            SideBandTrndDrw = false;
                            SideBndCsr = false;
                            PeekCursor = false;
                            SideBndCsrRatio = false;
                            TwoDCrossHairCursor = false;
                            TwDSingleSqrCrs = false;
                            HarmncCrs = false;
                            SingleCrs = false;
                            ThrdSqr = false;
                            ThrdLn = false;

                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph3 != null)
                            {
                                _LineGraph3.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph2 != null)
                            {
                                _LineGraph2.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph1 != null)
                            {
                                _LineGraph1.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph4 != null)
                            {
                                _LineGraph4.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph5 != null)
                            {
                                _LineGraph5.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph6 != null)
                            {
                                _LineGraph6.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph_cut1 != null)
                            {
                                _LineGraph_cut1.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph_cut2 != null)
                            {
                                _LineGraph_cut2.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph_cut3 != null)
                            {
                                _LineGraph_cut3.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph_cut4 != null)
                            {
                                _LineGraph_cut4.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph_cut5 != null)
                            {
                                _LineGraph_cut5.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph_cut6 != null)
                            {
                                _LineGraph_cut6.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph_cut7 != null)
                            {
                                _LineGraph_cut7.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph_cut8 != null)
                            {
                                _LineGraph_cut8.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph_cut9 != null)
                            {
                                _LineGraph_cut9.SetCursorType("Delta Cursors");
                            }
                            if (_LineGraph_cut10 != null)
                            {
                                _LineGraph_cut10.SetCursorType("Delta Cursors");
                            }

                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("Delta Cursors");
                            }
                            if (_3DGraph != null)
                            {
                                _3DGraph.SetCursorType("Select Cursor");
                            }
                            frmRpmCount _CursorCount = new frmRpmCount();
                            _CursorCount._HeaderText = "No. of Cursors";
                            _CursorCount._LabelText = "Cursor Count";
                            _CursorCount.ShowDialog();
                            int Cursorcount = _CursorCount._RPMCount;
                            objGcontrol.DrawMultipleCursors(Cursorcount);
                            break;
                        }
                    case "Square":
                        {
                            objGcontrol.ClearDatagrid();
                            objGcontrol.dataGridView1.Rows.Add(1);
                            SqureWaterFallCursorClicked();
                            ThrdSqr = true;
                            ThrdLn = false;
                            KillCrs = false;
                            MultipleCrsr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Square");
                            }
                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("Square");
                            }
                            break;
                        }

                    case "Multiple":
                        {
                            MultipleCrsr = true;
                            KillCrs = false;
                            SideBandTrndDrw = false;
                            SideBndCsr = false;
                            PeekCursor = false;
                            SideBndCsrRatio = false;
                            TwoDCrossHairCursor = false;
                            TwDSingleSqrCrs = false;
                            HarmncCrs = false;
                            SingleCrs = false;
                            ThrdSqr = false;
                            ThrdLn = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Multiple");
                            }
                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("Multiple");
                            }
                            break;
                        }
                    case "Kill Cursor":
                        {
                            SingleCrs = false;
                            HarmncCrs = false;
                            SideBndCsr = false;
                            SideBndCsrRatio = false;
                            SideBandTrndDrw = false;
                            PeekCursor = false;
                            TwDSingleSqrCrs = false;
                            TwoDCrossHairCursor = false;
                            ThrdSqr = false;
                            ThrdLn = false;
                            KillCrs = true;
                            MultipleCrsr = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Single");
                            }
                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("Single");
                            }
                            if (_3DGraph != null)
                            {
                                _3DGraph.SetCursorType("Single");
                            }
                            break;
                        }
                    default:
                        {
                            MultipleCrsr = false;
                            SideBandTrndDrw = false;
                            SideBndCsr = false;
                            PeekCursor = false;
                            SideBndCsrRatio = false;
                            TwoDCrossHairCursor = false;
                            TwDSingleSqrCrs = false;
                            HarmncCrs = false;
                            SingleCrs = false;
                            ThrdSqr = false;
                            ThrdLn = false;
                            KillCrs = false;
                            if (_LineGraph != null)
                            {
                                _LineGraph.SetCursorType("Select Cursor");
                            }
                            if (_BarGraph != null)
                            {
                                _BarGraph.SetCursorType("Select Cursor");
                            }
                            if (_3DGraph != null)
                            {
                                _3DGraph.SetCursorType("Select Cursor");
                            }
                            break;
                        }
                }
                if (KillCrs)
                {
                    bbKillCursor.Visibility = BarItemVisibility.Always;
                }
                else
                {
                    bbKillCursor.Visibility = BarItemVisibility.Never;
                }
            }
            catch { }
        }

        private void SqureWaterFallCursorClicked()
        {
            SqureCrs = true;
            LineCursor = false;
        }

        private void LineCursorWaterFallClicked()
        {
            objGcontrol.ThreeDeeRedraw();
            LineCursor = true;
            SqureCrs = false;
        }

        private PointF[] Pts = null;
        double[] Peeks1 = new double[0];
        int[] Peeks = new int[0];
        double[] x = new double[0];
        double[] y = new double[0];
        public int[] FindAllPeaks()
        {
            Peeks = new int[0];
            Peeks1 = new double[0];
            double Fst = 0;
            double Scnd = 0;
            double Thrd = 0;
            try
            {
                for (int i = 2; i < y.Length; i++)
                {
                    Fst = y[i - 2];
                    Scnd = y[i - 1];
                    Thrd = y[i];

                    if (Fst < Scnd && Scnd > Thrd)
                    {
                        Array.Resize(ref Peeks, Peeks.Length + 1);
                        Peeks[Peeks.Length - 1] = i - 1;
                        Array.Resize(ref Peeks1, Peeks1.Length + 1);
                        Peeks1[Peeks1.Length - 1] = Pts[i - 1].X;
                        i++;
                    }
                }
            }
            catch (Exception ex)
            { }
            return Peeks;
        }

        bool cepstrum = false;
        private void CepstrumButtons(bool ON)
        {
            try
            {
                bbTrend.Enabled = !ON;
                bcmDirection.Enabled = !ON;
                bbShaftCenterLine.Enabled = !ON;
                bbCrestFactorTrend.Enabled = !ON;
                string _CurrentInstrument = PublicClass.currentInstrument;
                if (PublicClass.GraphClicked != "Time")
                {
                    bbWaterfall.Enabled = !ON;
                    //  bbOctave.Enabled = !ON;
                    bbOriginal.Enabled = !ON;
                }
                else
                {
                    if (_CurrentInstrument == "DI-460")
                    {
                        if (enableorbit)
                        {
                            bbOrbit.Enabled = !ON;
                        }
                        else
                        {
                            bbOrbit.Enabled = false;
                        }
                    }
                    else if (_CurrentInstrument == "Impaq-Benstone" || _CurrentInstrument == "FieldPaq2")
                    {
                        if (PublicClass.sensordirtype == "XYZ")
                        {
                            bbOrbit.Enabled = !ON;
                        }
                        else
                        {
                            bbOrbit.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        double[] PreviousxarrayNewCep = null;
        double[] PreviousyarrayNewCep = null;
        string PreviousXLabelCep = null;
        string PreviousYLabelCep = null;
        bool Time = false;
        public bool CheckForTimeData(double[] Target)
        {
            Time = false;
            try
            {
                for (int i = 0; i < Target.Length; i++)
                {
                    if (Target[i] < 0)
                    {
                        Time = true;
                    }
                    else if (Target[i] >= 0)
                        Time = false;
                    if (Time == true)
                        break;
                }
            }
            catch (Exception ex)
            {
            }
            return Time;
        }

        private void bbCepstrum_ItemClick(object sender, ItemClickEventArgs e)
        {
            double[] Cepstrumdata = null;
            try
            {
                if (EdittextDirection != "Overlap")
                {
                    cepstrum = !cepstrum;
                    CepstrumButtons(cepstrum);
                    if (cepstrum)
                    {
                        PreviousxarrayNewCep = xarrayNew;
                        PreviousXLabelCep = CurrentXLabel;
                        PreviousyarrayNewCep = yarrayNew;
                        PreviousYLabelCep = CurrentYLabel;
                        if (yarrayNew.Length > 0)
                        {
                            bool IsTimeData = CheckForTimeData(yarrayNew);
                            double[] data = null;
                            double[] tempX = null;
                            if (yarrayNew.Length % 2 != 0)
                            {
                                data = new double[yarrayNew.Length - 1];
                                tempX = new double[yarrayNew.Length - 1];
                                for (int i = 0; i < yarrayNew.Length - 1; i++)
                                {
                                    data[i] = yarrayNew[i];
                                    tempX[i] = xarrayNew[i];
                                }
                            }
                            else
                            {
                                data = yarrayNew;
                                tempX = xarrayNew;
                            }

                            int tempxlength = tempX.Length;
                            if (IsTimeData)
                            {
                                Cepstrumdata = objGcontrol.CalculateCepstrumfromTime(data, xarrayNew);
                            }
                            else
                            {
                                double finalSec = 1 / xarrayNew[1];
                                double secdiff = (1 / xarrayNew[tempxlength - 1]) / 2;
                                tempX = new double[tempxlength * 2];
                                for (int i = 1; i < tempxlength * 2; i++)
                                {
                                    tempX[i] = tempX[i - 1] + secdiff;
                                }
                                Cepstrumdata = objGcontrol.CalculateCepstrumfromFFT(data, xarrayNew);
                            }

                            if (Cepstrumdata != null)
                            {
                                xarrayNew = tempX;
                                yarrayNew = Cepstrumdata;
                                CurrentXLabel = "Sec";
                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                        }
                        try
                        {
                            this.Cursor = Cursors.Default;
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        xarrayNew = PreviousxarrayNewCep;
                        yarrayNew = PreviousyarrayNewCep;
                        CurrentXLabel = PreviousXLabelCep;
                        DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    this.Cursor = Cursors.Default;
                }
                catch
                { }
            }
        }

        public void bboriginal()
        {
            try
            {
                if (modify == true)
                {
                    string[] allPhaseValue = null; double[] PhaseValueActual = null;
                    List<double> Magnitude = new List<double>();
                    string PhaseValue = null; int n = 0; int n1 = 17;
                    DataTable dt = new DataTable();
                    if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                    {
                        if (EdittextDirection == "Axial")
                        {
                            dt = DbClass.getdata(CommandType.Text, "select  distinct a.data_id,a.Point_ID,Measure_time , ordertrace_a_real, ordertrace_a_image from point_data a  where a.Point_ID= '" + PublicClass.SPointID + "' ");
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    double otam = Convert.ToDouble(dr["ordertrace_a_image"]);
                                    double otar = Convert.ToDouble(dr["ordertrace_a_real"]);
                                    allPhaseValue = _objUserControl.CalculatePhaseValue(otam, otar, 0, 0, 0, 0, 0, 0);
                                    PhaseValue += allPhaseValue[0] + "/";
                                }
                            }
                        }
                        else if (EdittextDirection == "Horizontal")
                        {
                            dt = DbClass.getdata(CommandType.Text, "select  distinct  a.data_id,a.Point_ID,Measure_time , ordertrace_h_real, ordertrace_h_image from point_data a  where a.Point_ID= '" + PublicClass.SPointID + "' ");
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    double othm = Convert.ToDouble(dr["ordertrace_h_image"]);
                                    double othr = Convert.ToDouble(dr["ordertrace_h_real"]);
                                    allPhaseValue = _objUserControl.CalculatePhaseValue(0, 0, othm, othr, 0, 0, 0, 0);
                                    PhaseValue += allPhaseValue[1] + "/";
                                }
                            }
                        }
                        else if (EdittextDirection == "Vertical")
                        {
                            dt = DbClass.getdata(CommandType.Text, "select  distinct  a.data_id,a.Point_ID,Measure_time , ordertrace_v_real, ordertrace_v_image from point_data a  where a.Point_ID= '" + PublicClass.SPointID + "' ");
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    double otvm = Convert.ToDouble(dr["ordertrace_v_image"]);
                                    double otvr = Convert.ToDouble(dr["ordertrace_v_real"]);
                                    allPhaseValue = _objUserControl.CalculatePhaseValue(0, 0, 0, 0, otvm, otvr, 0, 0);
                                    PhaseValue += allPhaseValue[2] + "/";
                                }
                            }
                        }
                        else if (EdittextDirection == "Channel1")
                        {
                            dt = DbClass.getdata(CommandType.Text, "select  distinct  a.data_id,a.Point_ID,Measure_time , ordertrace_ch1_real, ordertrace_ch1_image from point_data a  where a.Point_ID= '" + PublicClass.SPointID + "' ");
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Rows)
                                {
                                    double otch1m = Convert.ToDouble(dr["ordertrace_ch1_image"]);
                                    double otch1r = Convert.ToDouble(dr["ordertrace_ch1_real"]);
                                    allPhaseValue = _objUserControl.CalculatePhaseValue(0, 0, 0, 0, 0, 0, otch1m, otch1r);
                                    PhaseValue += allPhaseValue[3] + "/";
                                }
                            }
                        }

                        string[] PValue = PhaseValue.Split(new Char[] { '/' });
                        PhaseValueActual = new double[PValue.Length - 1];
                        for (int i = 0; i < PValue.Length - 1; i++)
                        {
                            if (PValue[i] == "NA")
                            {
                                PhaseValueActual[i] = 0.0;
                            }
                            else { PhaseValueActual[i] = Convert.ToDouble(PValue[i]); }

                            objGcontrol.dataGridView1.Rows.Add();
                            objGcontrol.dataGridView1.Rows[objGcontrol.dataGridView1.Rows.Count - 2].Cells[0].Value = Convert.ToString(i + 1);
                            objGcontrol.dataGridView1.Rows[objGcontrol.dataGridView1.Rows.Count - 2].Cells[1].Value = Convert.ToString(Math.Round(Convert.ToDouble(PhaseValueActual[i]), 2)) + "°";
                        }
                    }
                    else
                    {
                        dt = DbClass.getdata(CommandType.Text, "select  distinct a.data_id,a.Point_ID,Measure_time ,a.manual from point_data a  where a.Point_ID= '" + PublicClass.SPointID + "' ");
                        if (dt.Rows.Count > 0)
                        {
                            string Manual = Convert.ToString(dt.Rows[0]["manual"]);
                            try
                            {
                                string[] manual1 = Manual.Split(new char[] { '|', ',', '?' });
                                if (PublicClass.checkphase != "true")
                                {
                                    DialogResult Drslt = MessageBox.Show("Press Yes to Show Channel X Data" + "\n" + "Press NO to Show Channel Y Data" + "\n" + "Press Cancel to Close", "Order Tracking", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                                    if (Drslt == DialogResult.Yes)
                                    {
                                        PhaseValueActual = new double[manual1.Length - 9];
                                        PhaseValueActual[0] = Convert.ToDouble(manual1[1]);
                                        PhaseValueActual[1] = Convert.ToDouble(manual1[3]);
                                        PhaseValueActual[2] = Convert.ToDouble(manual1[5]);
                                        PhaseValueActual[3] = Convert.ToDouble(manual1[7]);
                                        PhaseValueActual[4] = Convert.ToDouble(manual1[9]);
                                        PhaseValueActual[5] = Convert.ToDouble(manual1[11]);
                                        PhaseValueActual[6] = Convert.ToDouble(manual1[13]);
                                        PhaseValueActual[7] = Convert.ToDouble(manual1[15]);
                                    }
                                    if (Drslt == DialogResult.No)
                                    {
                                        PhaseValueActual = new double[manual1.Length - 26];
                                        PhaseValueActual[0] = Convert.ToDouble(manual1[18]);
                                        PhaseValueActual[1] = Convert.ToDouble(manual1[20]);
                                        PhaseValueActual[2] = Convert.ToDouble(manual1[22]);
                                        PhaseValueActual[3] = Convert.ToDouble(manual1[24]);
                                        PhaseValueActual[4] = Convert.ToDouble(manual1[26]);
                                        PhaseValueActual[5] = Convert.ToDouble(manual1[28]);
                                        PhaseValueActual[6] = Convert.ToDouble(manual1[30]);
                                        PhaseValueActual[7] = Convert.ToDouble(manual1[32]);
                                    }
                                    if (Drslt == DialogResult.Cancel)
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    PhaseValueActual = new double[8];
                                    PhaseValueActual[0] = Math.Abs(Convert.ToDouble(manual1[1]) - Convert.ToDouble(manual1[18]));
                                    PhaseValueActual[1] = Math.Abs(Convert.ToDouble(manual1[3]) - Convert.ToDouble(manual1[20]));
                                    PhaseValueActual[2] = Math.Abs(Convert.ToDouble(manual1[5]) - Convert.ToDouble(manual1[22]));
                                    PhaseValueActual[3] = Math.Abs(Convert.ToDouble(manual1[7]) - Convert.ToDouble(manual1[24]));
                                    PhaseValueActual[4] = Math.Abs(Convert.ToDouble(manual1[9]) - Convert.ToDouble(manual1[26]));
                                    PhaseValueActual[5] = Math.Abs(Convert.ToDouble(manual1[11]) - Convert.ToDouble(manual1[28]));
                                    PhaseValueActual[6] = Math.Abs(Convert.ToDouble(manual1[13]) - Convert.ToDouble(manual1[30]));
                                    PhaseValueActual[7] = Math.Abs(Convert.ToDouble(manual1[15]) - Convert.ToDouble(manual1[32]));
                                }
                                for (int i = 0; i < PhaseValueActual.Length - 1; i++)
                                {
                                    if (PublicClass.checkphase == "true")
                                    {
                                        try
                                        {
                                            if (PhaseValueActual[i] != 0.0)
                                            {
                                                objGcontrol.dataGridView1.Rows.Add();
                                                objGcontrol.dataGridView1.Rows[objGcontrol.dataGridView1.Rows.Count - 2].Cells[0].Value = Convert.ToString(i + 1);
                                                objGcontrol.dataGridView1.Rows[objGcontrol.dataGridView1.Rows.Count - 2].Cells[1].Value = Convert.ToString(Math.Round(Convert.ToDouble(manual1[n]), 4)) + "/" + Convert.ToString(Math.Round(Convert.ToDouble(manual1[n + 1]), 2)) + "°";
                                                objGcontrol.dataGridView1.Rows[objGcontrol.dataGridView1.Rows.Count - 2].Cells[2].Value = Convert.ToString(Math.Round(Convert.ToDouble(manual1[n1]), 4)) + "/" + Convert.ToString(Math.Round(Convert.ToDouble(manual1[n1 + 1]), 2)) + "°";
                                                objGcontrol.dataGridView1.Rows[objGcontrol.dataGridView1.Rows.Count - 2].Cells[3].Value = (Math.Abs(Convert.ToDouble(manual1[n]) - Convert.ToDouble(manual1[n1]))) + "/" + Convert.ToString(Math.Round(Convert.ToDouble(PhaseValueActual[i]), 2)) + "°";
                                                Magnitude.Add(Math.Abs(Convert.ToDouble(manual1[n]) - Convert.ToDouble(manual1[n1])));
                                                n += 2; n1 += 2;
                                            }
                                        }
                                        catch { }
                                    }
                                    else
                                    {
                                        if (PhaseValueActual[i] != 0.0)
                                        {
                                            objGcontrol.dataGridView1.Rows.Add();
                                            objGcontrol.dataGridView1.Rows[objGcontrol.dataGridView1.Rows.Count - 2].Cells[0].Value = Convert.ToString(i + 1);
                                            objGcontrol.dataGridView1.Rows[objGcontrol.dataGridView1.Rows.Count - 2].Cells[1].Value = Convert.ToString(Math.Round(Convert.ToDouble(PhaseValueActual[i]), 2)) + "°";
                                        }
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                    lastg = PublicClass.GraphClicked;
                    PublicClass.GraphClicked = null;
                    //test(PhaseValueActual);                   
                    test(PhaseValueActual, Magnitude);
                    modify = false;
                }
                else
                {
                    PublicClass.GraphClicked = lastg;
                    m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                    modify = true;
                    PublicClass.checkphase = "false";
                }
            }
            catch
            {
                modify = false;
            }
        }

        bool bOrderTracking = false; string lastg = null;
        private void bbOriginal_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                objGcontrol.dataGridView3.Rows.Clear();
                objGcontrol.DataGridSettingForPhase(true);
                bboriginal();
            }
            catch { }

        }

        public double FindNearest(double[] TargetArray, double ValueToBeFound)
        {
            double Value = 0.0;
            try
            {
                for (int i = 0; i < TargetArray.Length; i++)
                {
                    Value = TargetArray[i];
                    if (Value > ValueToBeFound)
                    {
                        if ((double)(Value - ValueToBeFound) > Math.Abs((double)(ValueToBeFound - (double)TargetArray[i - 1])))
                        {
                            Value = TargetArray[i - 1];
                        }
                        else
                        {
                            Value = TargetArray[i];
                        }
                        break;
                    }
                }
                return Value;
            }
            catch (Exception ex)
            {
                return Value;
            }
        }

        string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };
        bool IsCrestTrend = false; bool bFarzi = false;
        private void bbCrestFactorTrend_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string[] colors = null;
                ArrayList Time = new ArrayList();
                ArrayList fullTime = new ArrayList();
                ImageList objlistimg = new ImageList();
                int color = 0;
                iclick = 0;
                objlistimg.Images.Add(ImageResources.DarkRed);
                objlistimg.Images.Add(ImageResources.DarkGreen);
                objlistimg.Images.Add(ImageResources.DarkGoldenRod);
                objlistimg.Images.Add(ImageResources.DarkseaGreen31);
                objlistimg.Images.Add(ImageResources.DarkBlue);
                objlistimg.Images.Add(ImageResources.DimGrey);
                objlistimg.Images.Add(ImageResources.Chocolate);
                objlistimg.Images.Add(ImageResources.DarkKhaki);
                objlistimg.Images.Add(ImageResources.Black);
                objlistimg.Images.Add(ImageResources.Orange);
                objlistimg.Images.Add(ImageResources.Cyan);
                objlistimg.Images.Add(ImageResources.AquaMarine);
                objlistimg.Images.Add(ImageResources.Bisque);
                objlistimg.Images.Add(ImageResources.Blue);
                objlistimg.Images.Add(ImageResources.BlueViolet);
                objlistimg.Images.Add(ImageResources.Coral);
                objlistimg.Images.Add(ImageResources.Darkmagenta);
                objlistimg.Images.Add(ImageResources.DarkSlateBlue31);
                objlistimg.Images.Add(ImageResources.DarkVoilet31);
                objlistimg.Images.Add(ImageResources.Deeppink31);
                objlistimg.Images.Add(ImageResources.DodgerBlue);
                objlistimg.Images.Add(ImageResources.FireBrick);
                objlistimg.Images.Add(ImageResources.ForestGreen);
                objlistimg.Images.Add(ImageResources.GreenYellow);
                objlistimg.Images.Add(ImageResources.HotPink);
                objlistimg.Images.Add(ImageResources.IndianRed);
                objlistimg.Images.Add(ImageResources.Darkorange);
                objlistimg.Images.Add(ImageResources.Darkorchid);
                objlistimg.Images.Add(ImageResources.DeepSkyBlue31);
                objlistimg.Images.Add(ImageResources.SandyBrown);
                arlSelectedDataGridValue = new ArrayList();
                if (_objUserControl != null)
                {
                    string sInstrumentName = PublicClass.currentInstrument;
                    arlstSColors = new ArrayList();
                    objGcontrol.CallClearDataGridMain();
                    fullTime = objIHand.ReturnAllDates(PublicClass.SPointID, PublicClass.GraphClicked, null, EdittextDirection);
                    colors = new string[fullTime.Count];
                    if (fullTime.Count > 0)
                    {
                        objGcontrol.dataGridView2.Rows.Add(fullTime.Count);
                    }
                    int icc = 0;
                    for (int i = 0; i < fullTime.Count; i++)
                    {
                        objGcontrol.dataGridView2.Rows[i].Cells[0].Value = fullTime[i].ToString();
                        {
                            objGcontrol.dataGridView2.Rows[i].Cells[1].Value = "√";
                            Time.Add(fullTime[i].ToString());
                            Set_iClick(Function.Add);
                            arlstSColors.Add(ColorCode[i]);
                            colors[i] = ColorCode[i].ToString();
                        }
                        objGcontrol.dataGridView2.Rows[i].Cells[3].Value = objlistimg.Images[icc];
                        objGcontrol.dataGridView2.Rows[i].Cells[3].Tag = ColorCode[icc].ToString();
                        arlSelectedDataGridValue.Add(i);
                        color++;
                        icc++;
                        if (icc >= 30)
                        {
                            icc = 0;
                        }
                    }
                    objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 1].Cells[3].Value = ImageResources.White;
                    arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, Time, PublicClass.GraphClicked, EdittextDirection);
                    int j = 0;
                    double[] CrestFactor = new double[arrXYVals.Count / 2];
                    if (CrestFactor.Length > 1)
                    {
                        for (int i = 1; i < arrXYVals.Count; i++)
                        {
                            CrestFactor[j] = objGcontrol.CalculateCrestFactor((double[])arrXYVals[i]);
                            j++;
                            i++;
                        }
                        IsCrestTrend = !IsCrestTrend;
                        bbWaterfall.Enabled = !IsCrestTrend;
                        bbTrend.Enabled = !IsCrestTrend;
                        bbCepstrum.Enabled = !IsCrestTrend;
                        bbTrend.Enabled = !IsCrestTrend;
                        bbShaftCenterLine.Enabled = !IsCrestTrend;
                        // bbOctave.Enabled = !IsCrestTrend;
                        bbOriginal.Enabled = !IsCrestTrend;

                        if (IsCrestTrend)
                        {
                            NullCursorBools();

                            _LineGraph.DGVTrendNodes = objGcontrol.dataGridView2;
                            _BarGraph = new BarChart();
                            _BarGraph._XLabel = "Hz";
                            _BarGraph.Dock = DockStyle.Top;
                            _BarGraph.AllowDrop = true;
                            DrawBarGraphs(CrestFactor, fullTime);
                            bFarzi = true;
                            DrawLineGraphs(arrXYVals, colors);
                        }
                        else
                        {
                            bbTrend.Enabled = true;

                            objGcontrol.panel1.Controls.Remove(_BarGraph);
                            _BarGraph = null;
                            _LineGraph.Dock = DockStyle.Fill;
                            StopTrending();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must have more than one graph for the Trend of Crest Factor");
                    }
                    arlstSelectedTime = new ArrayList();
                    arlstSelectedTime = Time;
                }
            }
            catch { }
        }

        private void DrawBarGraphs(double[] CrestFactor, ArrayList arlstSelectedTime)
        {
            string[] sxData = new string[arlstSelectedTime.Count];
            double[] dyData = new double[arlstSelectedTime.Count];
            try
            {
                for (int i = 0; i < arlstSelectedTime.Count; i++)
                {
                    sxData[i] = (string)arlstSelectedTime[i];
                    dyData[i] = CrestFactor[i];
                }
                _BarGraph.Name = "BarGraph 1";
                _BarGraph.AllowDrop = false;
                _BarGraph._MainForm = this;
                _BarGraph._XLabel = " ";
                _BarGraph._YLabel = " ";
                _BarGraph._DataGridView = objGcontrol.dataGridView1;
                _BarGraph._GraphBG1 = _GraphBG1;
                _BarGraph._GraphBG2 = _GraphBG2;
                _BarGraph._GraphBGDir = _GraphBGDir;
                _BarGraph._ChartBG1 = _ChartBG1;
                _BarGraph._ChartBG2 = _ChartBG2;
                _BarGraph._ChartBGDir = _ChartBGDir;
                _BarGraph._AxisColor = _AxisColor;
                _BarGraph._MainCursorColor = _MainCursorColor;
                _BarGraph.Height = objGcontrol.panel1.Height / 2;
                _BarGraph.Dock = DockStyle.Top;
                _BarGraph._AreaFill = true;
                _BarGraph._BarWidth = .8;
                _BarGraph.DrawBarGraph(sxData, dyData, "7667712", true);
                objGcontrol.panel1.Controls.Add(_BarGraph);
            }
            catch (Exception ex)
            {
            }
        }
        private void NullCursorBools()
        {
            try
            {
                SingleCrs = false;
                HarmncCrs = false;
                SideBndCsr = false;
                SideBndCsrRatio = false;
                PeekCursor = false;
                SideBandTrndDrw = false;
                LineCursor = false;
                SqureCrs = false;
                HarmncCrs = false;
                SingleCrs = false;
                TwDSingleSqrCrs = false;
                TwoDCrossHairCursor = false;
                string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                CmbCursorSelectedItem(SelectedCursorItem);
            }
            catch (Exception ex)
            {
            }
        }

        private void bbCopyGraph_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (_LineGraph != null)
                {
                    if (_LineGraph.Size == objGcontrol.panel1.Size)
                    {
                        _LineGraph.CopyGraph();
                    }

                    else
                    {
                        if (_BarGraph != null)
                        {
                            if (_BarGraph.Size == _LineGraph.Size)
                            {
                                _BarGraph.CopyGraph();
                            }
                        }
                        if (_3DGraph != null)
                        {
                            if (_3DGraph.Size == _LineGraph.Size)
                            {
                                _3DGraph.CopyGraph();
                            }
                        }
                    }
                }
                else if (_BarGraph != null)
                {
                    _BarGraph.CopyGraph();
                }
                else if (_3DGraph != null)
                {
                    _3DGraph.CopyGraph();
                }
                if (_OrbitGraph != null)
                {
                    _OrbitGraph.CopyGraph();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void bbCopyData_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ArrayList DataSelected1 = new ArrayList();
                double[] XValsToCopy = null;
                double[] YValsToCopy = null;
                if (DataSelected1.Count <= 0)
                {
                    DataSelected1 = _LineGraph.GetAllPlotDataSet();
                }
                for (int i = 0; i < DataSelected1.Count; i++)
                {
                    XValsToCopy = (double[])DataSelected1[i];
                    i += 1;
                    YValsToCopy = (double[])DataSelected1[i];
                }
                CopyValuestoClipBoard(XValsToCopy, YValsToCopy, PublicClass.SPointID);
            }
            catch (Exception ex)
            {

            }
        }
        string OverallTrendUnit = "AccTrend";
        public string _OverallTrendUnit
        {
            get
            {
                return OverallTrendUnit;
            }
            set
            {
                OverallTrendUnit = value;
            }
        }

        private void CopyValuestoClipBoard(double[] XValsToCopy, double[] YValsToCopy, string pointID)
        {
            StringBuilder ydata = new StringBuilder();
            string sFactoryName = null;
            string sAreaName = null;
            string sTrainName = null;
            string sMachineName = null;
            string sPointName = null;
            try
            {
                string sInstName = PublicClass.currentInstrument;
                if (sInstName == "Impaq-Benstone" || sInstName == "SKF/DI" || sInstName == "FieldPaq2" || sInstName == "Kohtect-C911")
                {

                    DataTable dt = DbClass.getdata(CommandType.Text, "select fac.Name,ar.Name,tra.Name,mac.Name,pp.PointName from point pp inner join machine_info mac on mac.Machine_ID=pp.Machine_ID left join train_info tra on tra.Train_ID=mac.TrainID left join area_info ar on ar.Area_ID=tra.Area_ID left join factory_info fac on fac.Factory_ID=ar.FactoryID where Point_ID='" + PublicClass.SPointID + "'");
                    foreach (DataRow rd in dt.Rows)
                    {
                        sFactoryName = Convert.ToString(rd["Name"]);
                        sAreaName = Convert.ToString(rd["Name1"]);
                        sTrainName = Convert.ToString(rd["Name2"]);
                        sMachineName = Convert.ToString(rd["Name3"]);
                        sPointName = Convert.ToString(rd["PointName"]);
                    }

                    ydata.Append(sFactoryName + "->" + sAreaName + "->" + sTrainName + "->" + sMachineName + "->" + sPointName + "\n");



                    if (!IsOverallTrend)
                    {
                        if (IsOrbitPlot)
                        {
                            ydata.Append("Orbit Data" + "\n");
                            try
                            {
                                ydata.Append(objGcontrol.dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "\n");
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            ydata.Append("Direction -> " + EdittextDirection + "\n");
                            try
                            {
                                ydata.Append(objGcontrol.dataGridView2.SelectedRows[0].Cells[0].Value.ToString() + "\n");
                            }
                            catch
                            {
                            }
                        }
                    }
                    else
                    {
                        ydata.Append("Overall Trend " + _OverallTrendUnit + "\n");
                    }
                    ydata.Append("X Values (" + _LineGraph._XLabel.ToString() + ")" + "\t\t");
                    ydata.Append("Y Values (" + _LineGraph._YLabel.ToString() + ")" + "\n");

                    string[] arrXValues = new string[XValsToCopy.Length];
                    string[] arrYValues = new string[YValsToCopy.Length];
                    for (int iCounter = 0; iCounter < XValsToCopy.Length; iCounter++)
                    {
                        arrXValues[iCounter] = XValsToCopy[iCounter].ToString();
                        arrYValues[iCounter] = YValsToCopy[iCounter].ToString();

                        if (IsOverallTrend)
                        {
                            if (m_PointGeneral1.sarrTime != null)
                            {
                                try
                                {
                                    arrXValues[iCounter] = m_PointGeneral1.sarrTime[Convert.ToInt32(XValsToCopy[iCounter]) - 1].ToString();
                                }
                                catch (Exception ex)
                                {
                                }
                            }
                        }
                        ydata.Append(arrXValues[iCounter].ToString() + "\t" + "\t" + arrYValues[iCounter].ToString() + "\n");
                    }

                    Clipboard.SetText(ydata.ToString());
                    MessageBox.Show("Copied to ClipBoard." + "\n" + "Click Paste in word/excel/notepad etc.");
                }

            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void bbReportSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmReportSettings objReport = new frmReportSettings();
                panelControl2.Visible = false;
                pnl3.Visible = true;
                panelControl2.Controls.Clear();
                pnl3.Controls.Clear();
                objReport.MdiParent = this;
                objReport.MainForm = this;
                checkform();
                pnl3.Controls.Add(objReport);
                pnl3.Dock = DockStyle.Fill;
                objReport.Dock = DockStyle.Fill;
                objReport.Show();

            }
            catch { }
        }

        public double[] fftMag(double[] x)
        {

            // assume n is a power of 2
            if (x.Length % 2 == 0)
            {
                n = x.Length;
            }
            else
            {
                n = x.Length - 1;
            }
            nu = (int)(Math.Log(n) / Math.Log(2));
            int n2 = n / 2;
            int nu1 = nu - 1;
            double[] xre = new double[n];
            double[] xim = new double[n];
            double[] mag = new double[n2];
            double tr, ti, p, arg, c, s;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    xre[i] = x[i];
                    xim[i] = 0.0f;
                }
                int k = 0;

                for (int l = 1; l <= nu; l++)
                {
                    while (k < n)
                    {
                        for (int i = 1; i <= n2; i++)
                        {
                            if ((k + n2) < n)
                            {
                                try
                                {
                                    p = bitrev(k >> nu1);
                                    arg = 2 * (double)Math.PI * p / n;
                                    c = (double)Math.Cos(arg);
                                    s = (double)Math.Sin(arg);
                                    tr = xre[k + n2] * c + xim[k + n2] * s;
                                    ti = xim[k + n2] * c - xre[k + n2] * s;
                                    xre[k + n2] = xre[k] - tr;
                                    xim[k + n2] = xim[k] - ti;
                                    xre[k] += tr;
                                    xim[k] += ti;
                                    k++;
                                }
                                catch
                                {
                                }
                            }
                        }
                        k += n2;
                    }
                    k = 0;
                    nu1--;
                    n2 = n2 / 2;
                }
                k = 0;
                int r;
                while (k < n)
                {
                    r = bitrev(k);
                    if (r > k)
                    {
                        tr = xre[k];
                        ti = xim[k];
                        xre[k] = xre[r];
                        xim[k] = xim[r];
                        xre[r] = tr;
                        xim[r] = ti;
                    }
                    k++;
                }

                mag[0] = 0;// (double)(Math.Sqrt(xre[0] * xre[0] + xim[0] * xim[0])) / n;
                for (int i = 1; i < n / 2; i++)
                {
                    //double temp_mag = (double)(Math.Sqrt(xre[i] * xre[i] + xim[i] * xim[i])) / 1000;
                    //double temp_2Per_mag = (2 * temp_mag) / 100;

                    //mag[i] = (float)(Math.Sqrt(xre[i] * xre[i] + xim[i] * xim[i])) / 1000;
                    //mag[i] = temp_mag - temp_2Per_mag;
                    mag[i] = (float)((2 * (float)(Math.Sqrt(xre[i] * xre[i] + xim[i] * xim[i]))) / n);
                }
            }
            catch { }
            return mag;
        }

        private void bbTWFtoFFT_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ConvertToFFT.TWFtoFFT _Convert = new ConvertToFFT.TWFtoFFT();
                ArrayList NewValues = _Convert.ConvertTWFtoFFT(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                if (NewValues != null)
                {
                    xarrayNew = (double[])NewValues[0];
                    yarrayNew = (double[])NewValues[1];
                    CurrentXLabel = (string)NewValues[2];
                    CurrentYLabel = (string)NewValues[3];
                    DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                }
            }
            catch { }
        }

        private void barEditBearingHarmonics_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                iBearingHarmonics = Convert.ToInt32(barEditBearingHarmonics.EditValue.ToString());
                if (BearingFaultFrequency)
                {

                    callBFF();
                }
            }
            catch (Exception ex)
            {
            }
        }
        int iConstSBValue = 10;
        int iConstSBRatio = 10;
        private void bbSBValue_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                CmbCursorSelectedItem(SelectedCursorItem);
                SideBandValue objSideBand = new SideBandValue();
                objSideBand.ShowDialog();
                iConstSBValue = objSideBand._Value;
                SBValue = Convert.ToString(iConstSBValue);
                SelectedCursorItem = "Sideband";
                CmbCursorSelectedItem(SelectedCursorItem);

            }
            catch (Exception ex)
            {
            }
        }

        private void bbSBRatio_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                CmbCursorSelectedItem(SelectedCursorItem);
                SideBandRatio objRatio = new SideBandRatio();
                objRatio.ShowDialog();
                iConstSBRatio = objRatio._Value;
                TrendRatio = "1/" + Convert.ToString(iConstSBRatio);
                SelectedCursorItem = "SidebandRatio";
                CmbCursorSelectedItem(SelectedCursorItem);
            }
            catch (Exception ex)
            {

            }
        }

        private void bbSBTrend_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                CmbCursorSelectedItem(SelectedCursorItem);
                SideBandTrendFunction();

            }
            catch (Exception ex)
            {

            }
        }
        private void SideBandTrendFunction()
        {
            try
            {
                SingleCrs = false;
                HarmncCrs = false;
                SideBndCsr = false;
                SideBndCsrRatio = false;
                SideBandTrndDrw = false;
                TwDSingleSqrCrs = false;
                TwoDCrossHairCursor = false;
                ThrdSqr = false;
                ThrdLn = false;
                SelectBandTrend = true;
                _LineGraph.SideBandTrendClicked();
                string SelectedCursorItem = "SideBandTrend";
                CmbCursorSelectedItem(SelectedCursorItem);
            }
            catch (Exception ex)
            {
            }
        }
        public string TrendValue
        {
            get
            {
                return tsSideBandTrendValue.Text.ToString();
            }
            set
            {
                tsSideBandTrendValue.Text = value;
                bbSBTrend.SuperTip.Items.Clear();
                bbSBTrend.SuperTip.Items.AddTitle((string)tsSideBandTrendValue.Text);
            }

        }

        private void bbMainReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Open Generating Reports";
                this.WindowState = FormWindowState.Minimized;
                frmReport objmainReport = new frmReport();
                objmainReport.MainForm = this;
                objmainReport.usercontrol = _objUserControl;
                objmainReport.ShowDialog();
            }
            catch
            {
            }
        }

        public bool IsBandAreaPlot = false;
        private void bbBand_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (CurrentXLabel == "Sec" || CurrentXLabel == "s")
                {
                }
                else
                {
                    IsBandAreaPlot = !IsBandAreaPlot;
                    FaultFreq = false;
                    ShowRpmRatio = false;
                    BearingFaultFrequency = false;
                    string[] BandData = null;
                    string instname = PublicClass.currentInstrument;
                    if (instname == "DI-460")
                    {// BandData = GetBandAlarmForDI();
                    }
                    else if (instname == "Card Vibro Neo")
                    {
                        MessageBox.Show("Not Implemented");
                    }
                    else if (instname == "Impaq-Benstone" || instname == "FieldPaq2")
                    {
                        BandData = GetBandAlarmForSpecifiedDirection(bcmDirection.EditValue.ToString(), PublicClass.GraphClicked);
                    }

                    bool bReturned = _LineGraph.DrawBandRegion(BandData, objGcontrol.dataGridView1, IsBandAreaPlot);
                    if (!bReturned)
                    {
                        IsBandAreaPlot = false;
                    }
                    objGcontrol.DataGridSettingForBandAlarm(IsBandAreaPlot);
                    BandAlarmButtons(IsBandAreaPlot);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BandAlarmButtons(bool ON)
        {
            try
            {
                bbFaultFreq.Enabled = !ON;
                bbRPM.Enabled = !ON;
                bbBFF.Enabled = !ON;

                if (!IsCrestTrend)
                {
                    bbCepstrum.Enabled = !ON;
                    bbTrend.Enabled = !ON;
                    bbWaterfall.Enabled = !ON;
                    bbChangeXUnit.Enabled = !ON;
                    bbChangeYUnit.Enabled = !ON;
                    bbShaftCenterLine.Enabled = !ON;
                    if (IsOctave)
                    {
                        bbArea.Enabled = false;
                        bbTrend.Enabled = false;
                        bbWaterfall.Enabled = false;
                        bbCepstrum.Enabled = false;
                        bbChangeXUnit.Enabled = false;
                        bbChangeYUnit.Enabled = false;

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private string[] GetBandAlarmForSpecifiedDirection(string Direction, string Type)
        {
            try
            {
                objGcontrol.ExtractBandAlarms();
                if (Direction == "Axial" || Direction == "Select Axis")
                {
                    if (Type == "Power")
                    {
                        objGcontrol.GetBandAlarmData(objGcontrol.BandAlarmsPowerAxial);
                        return objGcontrol.BandAlarmsPowerAxial;
                    }
                    else if (Type == "Demodulate")
                    {
                        objGcontrol.GetBandAlarmData(objGcontrol.BandAlarmsDemodulateAxial);
                        return objGcontrol.BandAlarmsDemodulateAxial;
                    }
                }
                else if (Direction == "Horizontal")
                {
                    if (Type == "Power")
                    {
                        objGcontrol.GetBandAlarmData(objGcontrol.BandAlarmsPowerHorizontal);
                        return objGcontrol.BandAlarmsPowerHorizontal;
                    }
                    else if (Type == "Demodulate")
                    {
                        objGcontrol.GetBandAlarmData(objGcontrol.BandAlarmsDemodulateHorizontal);
                        return objGcontrol.BandAlarmsDemodulateHorizontal;
                    }
                }
                else if (Direction == "Vertical")
                {
                    if (Type == "Power")
                    {
                        objGcontrol.GetBandAlarmData(objGcontrol.BandAlarmsPowerVerticle);
                        return objGcontrol.BandAlarmsPowerVerticle;
                    }
                    else if (Type == "Demodulate")
                    {
                        objGcontrol.GetBandAlarmData(objGcontrol.BandAlarmsDemodulateVerticle);
                        return objGcontrol.BandAlarmsDemodulateVerticle;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return null;
        }

        private void bbFaultFreq_ItemClick(object sender, ItemClickEventArgs e)
        {
            string[] Frequencies = new string[0];
            try
            {
                FaultFreq = !FaultFreq;

                ShowRpmRatio = false;
                BearingFaultFrequency = false;
                if (CurrentXLabel == "Sec" || CurrentXLabel == "S" || CurrentXLabel == "s" || CurrentXLabel == "Order")

                    FaultFreq = false;

                if (FaultFreq)
                {
                    Frequencies = _LineGraph.ExtractFaultFrequencies(PublicClass.SPointID);

                }

                bool bReturned = _LineGraph.DrawFaultFrequencies(FaultFreq, Frequencies, objGcontrol.dataGridView3);
                if (!bReturned)
                {
                    FaultFreq = false;
                    objGcontrol.Datagrid3visible = false;
                }
                else
                {
                    objGcontrol.Datagrid3visible = true;

                }
            }
            catch (Exception ex)
            {
                FaultFreq = false;

            }
        }
        int RPMCount = 10;
        public int _RPMCount
        {
            get
            {
                return RPMCount;
            }
            set
            {
                RPMCount = value;
            }
        }
        string OctaveStyle = null; double OctaveOrder = 0;
        double[] octaveCenterData = null;
        double[] octaveLowerData = null;
        double[] octaveUpperData = null;
        double[] dActXData = null; bool octavecheck = false;
        private void ExtractDataForOctaveNewControl()
        {
            try
            {
                octaveSettings _octaveSettings = new octaveSettings();
                if (octavecheck == false)
                {
                    _octaveSettings.ShowDialog();
                    OctaveStyle = _octaveSettings.Bars;
                    OctaveOrder = Convert.ToDouble(_octaveSettings.Octave);
                }
                else
                {
                    if (Octavesetting == "0")
                    {
                        _octaveSettings.Octave = "1";
                        OctaveOrder = Convert.ToDouble(_octaveSettings.Octave);
                    }
                    else if (Octavesetting == "1")
                    {
                        _octaveSettings.Octave = "3";
                        OctaveOrder = Convert.ToDouble(_octaveSettings.Octave);
                    }
                    else if (Octavesetting == "2")
                    {
                        _octaveSettings.Octave = "12";
                        OctaveOrder = Convert.ToDouble(_octaveSettings.Octave);
                    }
                    if (Octavebar == "0")
                    { OctaveStyle = "Bars with Border"; }
                    else if (Octavebar == "1")
                    { OctaveStyle = "Empty Bars"; }
                    else if (Octavebar == "2")
                    { OctaveStyle = "Filled bars"; }
                    else if (Octavebar == "3")
                    { OctaveStyle = "Thick Lines"; }
                    else if (Octavebar == "4")
                    { OctaveStyle = "Thin Lines"; }
                }

                double[] XData = new double[xarrayNew.Length];
                double[] YData = new double[xarrayNew.Length];
                YData = yarrayNew;
                double count = 0;
                double power = 0;

                octaveCenterData = new double[0];
                octaveLowerData = new double[0];
                octaveUpperData = new double[0];

                if (CurrentXLabel == "CPM")
                {
                    for (int i = 0; i < XData.Length; i++)
                    {
                        XData[i] = (double)xarrayNew[i] / 60;
                    }
                }
                else
                {
                    XData = xarrayNew;
                }

                do
                {
                    count = Math.Pow(10, power);
                    if (count >= 1000)
                    {
                        count = count / 1000;
                        count = Math.Round(count);
                        count = count * 1000;
                    }
                    else if (count >= 130)
                    {
                        count = count / 10;
                        count = Math.Round(count);
                        count = count * 10;
                    }
                    else if (count >= 50)
                    {
                        count = Math.Truncate(count);
                    }
                    else
                    {
                        if (OctaveOrder == 1)
                        {
                            count = Math.Round(count);
                        }
                        else
                        {
                            if (count >= 15)
                            {
                                count = Math.Round(count);
                            }
                            else
                            {
                                count = Math.Round(count, 3);
                            }
                        }
                    }
                    Array.Resize(ref octaveCenterData, octaveCenterData.Length + 1);
                    octaveCenterData[octaveCenterData.Length - 1] = count;
                    double count1 = Math.Pow(10, power - (.15 / OctaveOrder));
                    if (count1 >= 1000)
                    {
                        count1 = count1 / 10;
                        count1 = Math.Round(count1);
                        count1 = count1 * 10;
                    }
                    else if (count1 >= 130)
                    {
                        count1 = Math.Round(count1);
                    }
                    else if (count1 >= 50)
                    {
                        count1 = Math.Truncate(count1);
                    }
                    else
                    {
                        count1 = Math.Round(count1, 3);
                    }
                    Array.Resize(ref octaveLowerData, octaveLowerData.Length + 1);
                    octaveLowerData[octaveLowerData.Length - 1] = count1;
                    count1 = Math.Pow(10, power + (.15 / OctaveOrder));
                    if (count1 >= 1000)
                    {
                        count1 = count1 / 10;
                        count1 = Math.Round(count1);
                        count1 = count1 * 10;
                    }
                    else if (count1 >= 130)
                    {
                        count1 = Math.Round(count1);
                    }
                    else if (count1 >= 50)
                    {
                        count1 = Math.Truncate(count1);
                    }
                    else
                    {
                        count1 = Math.Round(count1, 3);
                    }
                    Array.Resize(ref octaveUpperData, octaveUpperData.Length + 1);
                    octaveUpperData[octaveUpperData.Length - 1] = count1;
                    power += Math.Round((double)(.3 / OctaveOrder), 3);
                    power = Math.Round(power, 3);
                }
                while (count < XData[XData.Length - 1]);

                dActXData = new double[0];
                double temp = 0;
                int ii = 0;

                try
                {
                    for (int j = 0; j < octaveCenterData.Length; j++)
                    {
                        temp = 0;
                        for (int i = 0; (XData[i] <= octaveUpperData[j]) && (i < XData.Length - 2); i++)
                        {
                            try
                            {
                                if ((XData[i] <= octaveUpperData[j]) && (XData[i] >= octaveLowerData[j]))
                                {
                                    if (temp < YData[i])
                                    {
                                        temp = YData[i];
                                    }
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }
                        Array.Resize(ref dActXData, dActXData.Length + 1);
                        dActXData[dActXData.Length - 1] = temp;
                        temp = 0;
                    }
                }
                catch (Exception ex)
                {

                }
                XSelected = octaveCenterData;
                YSelected = dActXData;
                DrawBarGraphs(XSelected, YSelected);
            }
            catch (Exception ex)
            {
                // ErrorLog_Class.ErrorLogEntry(ex);
            }
        }

        public void DrawBarGraphs(double[] xData, double[] yData)
        {
            try
            {
                _BarGraph = new BarChart();
                _BarGraph.Name = "BarGraph 1";
                _BarGraph.AllowDrop = true;
                _BarGraph._MainForm = this;
                if (CurrentYLabel == "db")
                {
                    _BarGraph._XLabel = "Frequency.Log[Hz]";
                }
                else
                {
                    _BarGraph._XLabel = CurrentXLabel;
                }
                _BarGraph._YLabel = CurrentYLabel;
                _BarGraph._DataGridView = objGcontrol.dataGridView1;
                _BarGraph._GraphBG1 = _GraphBG1;
                _BarGraph._GraphBG2 = _GraphBG2;
                _BarGraph._GraphBGDir = _GraphBGDir;
                _BarGraph._ChartBG1 = _ChartBG1;
                _BarGraph._ChartBG2 = _ChartBG2;
                _BarGraph._ChartBGDir = _ChartBGDir;
                _BarGraph._AxisColor = _AxisColor;

                _BarGraph._MainCursorColor = _MainCursorColor;
                //_LineGraph.Dock = DockStyle.Top;
                //_LineGraph.Height = objGcontrol.panel1.Height ;
                //_BarGraph.Height = objGcontrol.panel1.Height ;
                //_LineGraph.Height = objGcontrol.panel1.Height / 2;
                //_BarGraph.Height = objGcontrol.panel1.Height / 2;
                _BarGraph.Dock = DockStyle.Fill;
                if (OctaveStyle == "Empty Bars")
                {
                    _BarGraph._AreaFill = false;
                }
                else
                {
                    _BarGraph._AreaFill = true;
                }
                if (OctaveStyle == "Filled bars")
                {
                    _BarGraph._BarWidth = 1;
                }
                else if (OctaveStyle == "Thick Lines")
                {
                    _BarGraph._BarWidth = .5;
                }
                else if (OctaveStyle == "Thin Lines")
                {
                    _BarGraph._BarWidth = .15;
                }
                else
                {
                    _BarGraph._BarWidth = .8;
                }
                _BarGraph.DrawBarGraph(xData, yData);
                objGcontrol.panel1.Controls.Clear();
                objGcontrol.panel1.Controls.Add(_BarGraph);
            }
            catch (Exception ex)
            {
            }
        }
        double[] XSelected = new double[0];
        double[] YSelected = new double[0]; public bool rpmCheck = false;
        private void bbRPM_ItemClick(object sender, ItemClickEventArgs e)
        {
            string[] Frequencies = new string[0];
            try
            {
                ShowRpmRatio = !ShowRpmRatio;
                FaultFreq = false;
                BearingFaultFrequency = false;
                double FinalFreq = 0;
                if (CurrentXLabel == "Sec" || CurrentXLabel == "S" || CurrentXLabel == "s" || CurrentXLabel == "Order")
                {
                    ShowRpmRatio = false;
                }

                if (ShowRpmRatio)
                {
                    frmRpmCount objCount = new frmRpmCount();
                    if (rpmCheck)
                    {
                        _RPMCount = objCount._RPMCount;
                        rpmCheck = false;
                        objCount._ShouldDraw = true;
                    }
                    else
                    {
                        objCount.ShowDialog();
                        _RPMCount = objCount._RPMCount;
                    }
                    if (objCount._ShouldDraw == false)
                    { return; }
                    else
                    {
                        string[] RPMValues = _objUserControl.GetRPMValues(PublicClass.SPointID);
                        int iRPM = Convert.ToInt32(RPMValues[0]);
                        int iPulse = Convert.ToInt32(RPMValues[1]);
                        FinalFreq = (double)((double)iRPM / (double)(iPulse * 60));
                    }

                    bool bReturned = _LineGraph.DrawRPMmarkers(ShowRpmRatio, FinalFreq, objGcontrol.dataGridView3, _RPMCount);
                    if (!bReturned)
                    {
                        ShowRpmRatio = false;
                        objGcontrol.Datagrid3visible = false;
                    }
                    else
                    {
                        objGcontrol.Datagrid3visible = true;
                    }
                    objGcontrol.panel1.Refresh();
                }
                else
                {
                    m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                }
            }
            catch (Exception ex)
            {
            }
        }
        double[] Top5points = new double[5];
        double[] Top5pointsX = new double[5];
        private void Top5Values()
        {
            Top5points = new double[5];
            Top5pointsX = new double[5];

            double temp = 0;
            string sTemp = null;
            try
            {
                double[] Xval = XSelected;
                double[] Yval = YSelected;

                for (int i = 0; i < Xval.Length; i++)
                {
                    if ((double)Yval[i] > (double)Top5points[0])
                    {
                        temp = (double)Top5points[0];
                        Top5points[0] = (double)Yval[i];
                        Top5points[4] = (double)Top5points[3];
                        Top5points[3] = (double)Top5points[2];
                        Top5points[2] = (double)Top5points[1];
                        Top5points[1] = temp;


                        temp = (double)Top5pointsX[0];
                        Top5pointsX[0] = (double)Xval[i];
                        Top5pointsX[4] = (double)Top5pointsX[3];
                        Top5pointsX[3] = (double)Top5pointsX[2];
                        Top5pointsX[2] = (double)Top5pointsX[1];
                        Top5pointsX[1] = temp;
                    }
                    else if ((double)Yval[i] > (double)Top5points[1])
                    {
                        temp = (double)Top5points[1];
                        Top5points[1] = (double)Yval[i];
                        Top5points[4] = (double)Top5points[3];
                        Top5points[3] = (double)Top5points[2];
                        Top5points[2] = temp;


                        temp = (double)Top5pointsX[1];
                        Top5pointsX[1] = (double)Xval[i];
                        Top5pointsX[4] = (double)Top5pointsX[3];
                        Top5pointsX[3] = (double)Top5pointsX[2];
                        Top5pointsX[2] = temp;
                    }
                    else if ((double)Yval[i] > (double)Top5points[2])
                    {
                        temp = (double)Top5points[2];
                        Top5points[2] = (double)Yval[i];
                        Top5points[4] = (double)Top5points[3];
                        Top5points[3] = temp;


                        temp = (double)Top5pointsX[2];
                        Top5pointsX[2] = (double)Xval[i];
                        Top5pointsX[4] = (double)Top5pointsX[3];
                        Top5pointsX[3] = temp;

                    }
                    else if ((double)Yval[i] > (double)Top5points[3])
                    {
                        temp = (double)Top5points[3];
                        Top5points[3] = (double)Yval[i];
                        Top5points[4] = temp;


                        temp = (double)Top5pointsX[3];
                        Top5pointsX[3] = (double)Xval[i];
                        Top5pointsX[4] = temp;

                    }
                    else if ((double)Yval[i] > (double)Top5points[4])
                    {
                        Top5points[4] = (double)Yval[i];
                        Top5pointsX[4] = (double)Xval[i];
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void bbBFF_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                BearingFaultFrequency = !BearingFaultFrequency;
                chkBFFOverride.Checked = false;
                FaultFreq = false;
                ShowRpmRatio = false;
                if (CurrentXLabel == "Sec" || CurrentXLabel == "S" || CurrentXLabel == "s")
                {
                    BearingFaultFrequency = false;
                }
                ExactBearingFF = new double[4];

                ArrayList BearingFF = GetBearingFaultFrequencies(PublicClass.SPointID);
                string[] Frequencies = new string[BearingFF.Count];
                for (int i = 0; i < BearingFF.Count; i++)
                {
                    Frequencies[i] = BearingFF[i].ToString();
                }
                bool bReturned = _LineGraph.DrawFaultFrequencies(BearingFaultFrequency, Frequencies, objGcontrol.dataGridView3);
                if (!bReturned)
                {
                    BearingFaultFrequency = false;
                    objGcontrol.Datagrid3visible = false;
                }
                else
                {
                    objGcontrol.Datagrid3visible = true;

                    Top5Values();
                    bool BearingFault = false;
                    string sBearingFault = null;
                    for (int i = 0; i < 5; i++)
                    {
                        if ((double)ExactBearingFF[0] == (double)Top5pointsX[i])
                        {
                            BearingFault = true;
                            sBearingFault += "\n" + " Ball Passing Frequency Defect";
                        }
                        if ((double)ExactBearingFF[1] == (double)Top5pointsX[i])
                        {
                            BearingFault = true;
                            sBearingFault += "\n" + " Ball Passing Inner Race Defect";
                        }
                        if ((double)ExactBearingFF[2] == (double)Top5pointsX[i])
                        {
                            BearingFault = true;
                            sBearingFault += "\n" + " Ball Spin Frequency Defect";
                        }
                        if ((double)ExactBearingFF[3] == (double)Top5pointsX[i])
                        {
                            BearingFault = true;
                            sBearingFault += "\n" + " Fundamental Train Frequency Defect";
                        }
                    }
                    if (BearingFault)
                    {
                        MessageBox.Show("Current Graph shows following fault(s) in the Bearing " + sBearingFault, "Bearing Fault", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void chkBFFOverride_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (BearingFaultFrequency)
                {
                    _LineGraph._IsBearingFF = chkBFFOverride.Checked;
                    string SelectedCursorItem = cmbCurSors.Items[1].ToString();
                    CmbCursorSelectedItem(SelectedCursorItem);
                    if (chkBFFOverride.Checked == false)
                    {

                        callBFF();
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        public void callBFF()
        {
            ArrayList BearingFF = GetBearingFaultFrequencies(PublicClass.SPointID);
            string[] Frequencies = new string[BearingFF.Count];
            for (int i = 0; i < BearingFF.Count; i++)
            {
                Frequencies[i] = BearingFF[i].ToString();
            }
            bool bReturned = _LineGraph.DrawFaultFrequencies(BearingFaultFrequency, Frequencies, objGcontrol.dataGridView3);
        }

        ArrayList arrselectedDate = new ArrayList();
        ArrayList _Time = new ArrayList();
        string graphname = null; string graphfooter = null; string graphname1 = null; string graphfooter1 = null;
        private void bbDualGraph_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (PublicClass.GraphClicked == "Time" || PublicClass.GraphClicked == "Demodulate" || PublicClass.GraphClicked == "Cepstrum")
            {
                return;
            }
            else
            {
                try
                {
                    frmValues valuecount = new frmValues();
                    valuecount.ShowDialog();
                    if (valuecount._ShouldDraw)
                    {
                        int cnt = 0;
                        int value = valuecount._value;
                        ArrayList arrdataP = new ArrayList();
                        ArrayList arrdataP1 = new ArrayList();
                        objGcontrol.dataGridView2.Rows.Clear();
                        ShowCurrentDate();
                        m_PointGeneral1.ExtractUnits();
                        if (PublicClass.SPointID != null)
                        {
                            string sInstrumentName = PublicClass.currentInstrument;
                            _Time.Add(PublicClass.tym);
                            arrXYVals = new ArrayList();
                            if (value != 0)
                            {
                                if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "FieldPaq2")
                                {
                                    if (value == 1)
                                    {
                                        arrdataP = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power", EdittextDirection);
                                        if (arrdataP.Count > 0)
                                            cnt++;
                                        graphname = "LineGraph Power Spectrum"; graphfooter = "Power Spectrum";
                                        arrdataP1 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power1", EdittextDirection);
                                        if (arrdataP1.Count > 0)
                                            cnt++;
                                        graphname1 = "LineGraph Power1 Spectrum"; graphfooter1 = "Power1 Spectrum";
                                    }
                                    if (value == 2)
                                    {
                                        arrdataP = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power2", EdittextDirection);
                                        if (arrdataP.Count > 0)
                                            cnt++;
                                        graphname = "LineGraph Power2 Spectrum"; graphfooter = "Power2 Spectrum";
                                        arrdataP1 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power21", EdittextDirection);
                                        if (arrdataP1.Count > 0)
                                            cnt++;
                                        graphname1 = "LineGraph Power21 Spectrum"; graphfooter1 = "Power21 Spectrum";
                                    }
                                    if (value == 3)
                                    {
                                        arrdataP = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power3", EdittextDirection);
                                        if (arrdataP.Count > 0)
                                            cnt++;
                                        graphname = "LineGraph Power3 Spectrum"; graphfooter = "Power3 Spectrum";
                                        arrdataP1 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, "Power31", EdittextDirection);
                                        if (arrdataP1.Count > 0)
                                            cnt++;
                                        graphname1 = "LineGraph Power31 Spectrum"; graphfooter1 = "Power31 Spectrum";
                                    }

                                }

                                if (arrdataP.Count != 0)
                                {
                                    RemovePreviousGraphControl();
                                    DrawDualWindowGraph(arrdataP, arrdataP1, cnt);
                                }
                                else
                                {
                                    MessageBox.Show(this, "Data Not Avaiable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Please Select Any CheckBox", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    else
                    {
                        m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                    }
                }
                catch
                {
                }
            }
        }

        private void DrawDualWindowGraph(ArrayList arrdataP, ArrayList arrdataP1, int cnt)
        {
            try
            {
                if (arrdataP.Count > 0)
                {
                    double[] tempX = (double[])arrdataP[0];
                    double[] tempY = (double[])arrdataP[1];
                    _LineGraph3.Name = graphname;

                    PublicClass.Chart_Footer = graphfooter;
                    _LineGraph3._MainForm = this;
                    _LineGraph3._XLabel = PublicClass.x_Unit;
                    _LineGraph3._YLabel = PublicClass.y_Unit;
                    _LineGraph3._GraphBG1 = _GraphBG1;
                    _LineGraph3._GraphBG2 = _GraphBG2;
                    _LineGraph3._GraphBGDir = _GraphBGDir;
                    _LineGraph3._ChartBG1 = _ChartBG1;
                    _LineGraph3._ChartBG2 = _ChartBG2;
                    _LineGraph3._ChartBGDir = _ChartBGDir;
                    _LineGraph3._AxisColor = _AxisColor;
                    _LineGraph3._MainCursorColor = _MainCursorColor;
                    _LineGraph3._AreaFill = _AreaPlot;

                    _LineGraph3.Dock = DockStyle.Top;
                    _LineGraph3.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph3.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph3);
                }
                if (arrdataP1.Count > 0)
                {
                    double[] tempX = (double[])arrdataP1[0];
                    double[] tempY = (double[])arrdataP1[1];


                    _LineGraph2.Name = graphname1;
                    PublicClass.Chart_Footer = graphfooter1;
                    _LineGraph2._MainForm = this;
                    _LineGraph2._XLabel = PublicClass.x_Unit;
                    _LineGraph2._YLabel = PublicClass.y_Unit;
                    _LineGraph2._GraphBG1 = _GraphBG1;
                    _LineGraph2._GraphBG2 = _GraphBG2;
                    _LineGraph2._GraphBGDir = _GraphBGDir;
                    _LineGraph2._ChartBG1 = _ChartBG1;
                    _LineGraph2._ChartBG2 = _ChartBG2;
                    _LineGraph2._ChartBGDir = _ChartBGDir;
                    _LineGraph2._AxisColor = _AxisColor;
                    _LineGraph2._MainCursorColor = _MainCursorColor;
                    _LineGraph2._AreaFill = _AreaPlot;

                    _LineGraph2.Dock = DockStyle.Top;
                    _LineGraph2.Height = objGcontrol.panel1.Height / cnt;
                    _LineGraph2.DrawLineGraph(tempX, tempY);
                    objGcontrol.panel1.Controls.Add(_LineGraph2);
                }
            }
            catch { }
        }


        ResizeArray_Interface _ResizeArray = new ResizeArray_Control();
        private void DrawMultiGraph(ArrayList arrXYVals, int NumberofGraphs, int Band1, int Band2, int Band3, int Band4)
        {
            try
            {
                int[] band = new int[4];
                band[0] = Band1;
                band[1] = Band2;
                band[2] = Band3;
                band[3] = Band4;
                double[] xData = (double[])arrXYVals[0];
                double[] yData = (double[])arrXYVals[1];

                ArrayList CutarrxVals = new ArrayList();
                ArrayList CutarryVals = new ArrayList();
                PublicClass.Chart_Footer = null;
                for (int i = 0; i < NumberofGraphs; i++)
                {
                    double[] CutxData = new double[0];
                    double[] CutyData = new double[0];

                    for (int j = 0; j < xData.Length; j++)
                    {
                        if (xData[j] <= (double)band[i])
                        {
                            _ResizeArray.IncreaseArrayDouble(ref CutxData, 1);
                            CutxData[CutxData.Length - 1] = xData[j];

                            _ResizeArray.IncreaseArrayDouble(ref CutyData, 1);
                            CutyData[CutyData.Length - 1] = yData[j];
                        }
                        else
                        {
                            break;
                        }
                    }
                    CutarrxVals.Add(CutxData);
                    CutarryVals.Add(CutyData);
                }
                switch (NumberofGraphs)
                {
                    case 1:
                        {
                            DrawCutLineGraph1(CutarrxVals, CutarryVals);
                            break;
                        }
                    case 2:
                        {
                            DrawCutLineGraph1(CutarrxVals, CutarryVals);
                            DrawCutLineGraph2(CutarrxVals, CutarryVals);
                            break;
                        }
                    case 3:
                        {
                            DrawCutLineGraph1(CutarrxVals, CutarryVals);
                            DrawCutLineGraph2(CutarrxVals, CutarryVals);
                            DrawCutLineGraph3(CutarrxVals, CutarryVals);
                            break;
                        }

                    case 4:
                        {
                            DrawCutLineGraph1(CutarrxVals, CutarryVals);
                            DrawCutLineGraph2(CutarrxVals, CutarryVals);
                            DrawCutLineGraph3(CutarrxVals, CutarryVals);
                            DrawCutLineGraph4(CutarrxVals, CutarryVals);
                            break;
                        }
                }
            }
            catch
            { }
        }

        private void DrawCutLineGraph1(ArrayList CutarrxVals, ArrayList CutarryVals)
        {
            try
            {
                _LineGraph_cut1 = new LineGraphControl();
                _LineGraph_cut1.Name = "3DGraph 1";
                _LineGraph_cut1.AllowDrop = false;
                _LineGraph_cut1._MainForm = this;
                _LineGraph_cut1._XLabel = PublicClass.x_Unit;
                _LineGraph_cut1._YLabel = PublicClass.y_Unit;
                _LineGraph_cut1._DataGridView = objGcontrol.dataGridView1;
                _LineGraph_cut1._GraphBG1 = _GraphBG1;
                _LineGraph_cut1._GraphBG2 = _GraphBG2;
                _LineGraph_cut1._GraphBGDir = _GraphBGDir;
                _LineGraph_cut1._ChartBG1 = _ChartBG1;
                _LineGraph_cut1._ChartBG2 = _ChartBG2;
                _LineGraph_cut1._ChartBGDir = _ChartBGDir;
                _LineGraph_cut1._AxisColor = _AxisColor;
                _LineGraph_cut1._MainCursorColor = _MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                _LineGraph_cut1.Height = objGcontrol.panel1.Height / 2;
                _LineGraph_cut1.Dock = DockStyle.Top;

                _LineGraph_cut1.DrawLineGraph((double[])CutarrxVals[0], (double[])CutarryVals[0]);
                objGcontrol.panel1.Controls.Add(_LineGraph_cut1);
                objGcontrol.panel1.AutoScroll = true;
            }
            catch
            {
            }
        }
        private void DrawCutLineGraph2(ArrayList CutarrxVals, ArrayList CutarryVals)
        {
            try
            {
                _LineGraph_cut2 = new LineGraphControl();
                _LineGraph_cut2.Name = "3DGraph 1";
                _LineGraph_cut2.AllowDrop = false;
                _LineGraph_cut2._MainForm = this;
                _LineGraph_cut2._XLabel = PublicClass.x_Unit;
                _LineGraph_cut2._YLabel = PublicClass.y_Unit;
                _LineGraph_cut2._DataGridView = objGcontrol.dataGridView1;
                _LineGraph_cut2._GraphBG1 = _GraphBG1;
                _LineGraph_cut2._GraphBG2 = _GraphBG2;
                _LineGraph_cut2._GraphBGDir = _GraphBGDir;
                _LineGraph_cut2._ChartBG1 = _ChartBG1;
                _LineGraph_cut2._ChartBG2 = _ChartBG2;
                _LineGraph_cut2._ChartBGDir = _ChartBGDir;
                _LineGraph_cut2._AxisColor = _AxisColor;
                _LineGraph_cut2._MainCursorColor = _MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                _LineGraph_cut2.Height = objGcontrol.panel1.Height / 2;
                _LineGraph_cut2.Dock = DockStyle.Top;

                _LineGraph_cut2.DrawLineGraph((double[])CutarrxVals[1], (double[])CutarryVals[1]);

                objGcontrol.panel1.Controls.Add(_LineGraph_cut2);
            }
            catch
            {
            }
        }

        private void DrawCutLineGraph4(ArrayList CutarrxVals, ArrayList CutarryVals)
        {
            try
            {
                _LineGraph_cut4 = new LineGraphControl();
                _LineGraph_cut4.Name = "3DGraph 1";
                _LineGraph_cut4.AllowDrop = false;
                _LineGraph_cut4._MainForm = this;
                _LineGraph_cut4._XLabel = PublicClass.x_Unit;
                _LineGraph_cut4._YLabel = PublicClass.y_Unit;
                _LineGraph_cut4._DataGridView = objGcontrol.dataGridView1;
                _LineGraph_cut4._GraphBG1 = _GraphBG1;
                _LineGraph_cut4._GraphBG2 = _GraphBG2;
                _LineGraph_cut4._GraphBGDir = _GraphBGDir;
                _LineGraph_cut4._ChartBG1 = _ChartBG1;
                _LineGraph_cut4._ChartBG2 = _ChartBG2;
                _LineGraph_cut4._ChartBGDir = _ChartBGDir;
                _LineGraph_cut4._AxisColor = _AxisColor;
                _LineGraph_cut4._MainCursorColor = _MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                _LineGraph_cut4.Height = objGcontrol.panel1.Height / 2;
                _LineGraph_cut4.Dock = DockStyle.Top;

                _LineGraph_cut4.DrawLineGraph((double[])CutarrxVals[3], (double[])CutarryVals[3]);

                objGcontrol.panel1.Controls.Add(_LineGraph_cut4);
            }

            catch
            {
            }
        }
        private void DrawCutLineGraph3(ArrayList CutarrxVals, ArrayList CutarryVals)
        {
            try
            {
                _LineGraph_cut3 = new LineGraphControl();
                _LineGraph_cut3.Name = "3DGraph 1";
                _LineGraph_cut3.AllowDrop = false;
                _LineGraph_cut3._MainForm = this;
                _LineGraph_cut3._XLabel = PublicClass.x_Unit;
                _LineGraph_cut3._YLabel = PublicClass.y_Unit;
                _LineGraph_cut3._DataGridView = objGcontrol.dataGridView1;
                _LineGraph_cut3._GraphBG1 = _GraphBG1;
                _LineGraph_cut3._GraphBG2 = _GraphBG2;
                _LineGraph_cut3._GraphBGDir = _GraphBGDir;
                _LineGraph_cut3._ChartBG1 = _ChartBG1;
                _LineGraph_cut3._ChartBG2 = _ChartBG2;
                _LineGraph_cut3._ChartBGDir = _ChartBGDir;
                _LineGraph_cut3._AxisColor = _AxisColor;
                _LineGraph_cut3._MainCursorColor = _MainCursorColor;

                _LineGraph.Dock = DockStyle.Top;
                _LineGraph.Height = objGcontrol.panel1.Height / 2;
                _LineGraph_cut3.Height = objGcontrol.panel1.Height / 2;
                _LineGraph_cut3.Dock = DockStyle.Top;
                _LineGraph_cut3.DrawLineGraph((double[])CutarrxVals[2], (double[])CutarryVals[2]);

                objGcontrol.panel1.Controls.Add(_LineGraph_cut3);
            }
            catch
            {
            }
        }

        string highname = null; string lowname = null;
        private void bbMultiGraph_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (PublicClass.GraphClicked == "Time" || PublicClass.GraphClicked == "Demodulate" || PublicClass.GraphClicked == "Cepstrum")
                {
                    return;
                }
                else
                {
                    if (modify == true)
                    {
                        DialogResult Drslt = MessageBox.Show("Press Yes to Create Single Axis Spectrum With Multiple Band" + "\n" + "Press NO to Create Multple Axis Spectrum With Manually High and low Freq." + "\n" + "Press Cancel to Close", "Multiple Graphs", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (Drslt == DialogResult.Yes)
                        {
                            MultigraphSelection _multigraph = new MultigraphSelection();
                            _multigraph.ShowDialog();
                            if (_multigraph._ShouldDraw)
                            {
                                RemovePreviousGraphControl();
                                setCursorCombo("Time");
                                int NumberofGraphs = _multigraph._NumberofGraphs;
                                int Band1 = _multigraph._Band1;
                                int Band2 = _multigraph._Band2;
                                int Band3 = _multigraph._Band3;
                                int Band4 = _multigraph._Band4;
                                ArrayList arrselectedDate = new ArrayList();
                                arrselectedDate.Add(PublicClass.tym);
                                arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, EdittextDirection);
                                _LineGraph = new LineGraphControl();
                                DrawMultiGraph(arrXYVals, NumberofGraphs, Band1, Band2, Band3, Band4);
                                modify = false;
                            }
                        }
                        else if (Drslt == DialogResult.No)
                        {
                            frmmultiplegraph _multigraph = new frmmultiplegraph();
                            _multigraph.ShowDialog();
                            if (_multigraph._ShouldDraw)
                            {
                                RemovePreviousGraphControl();
                                setCursorCombo("Time");
                                ClsCommon clscommon = new ClsCommon();
                                int NumberofGraphs = _multigraph._NumberofGraphs;
                                int Band1 = _multigraph._Band1;
                                int Band2 = _multigraph._Band2;
                                int Band3 = _multigraph._Band3;
                                int Band4 = _multigraph._Band4;
                                int Band5 = _multigraph._Band5;
                                int Band6 = _multigraph._Band6;
                                int Band7 = _multigraph._Band7;
                                int Band8 = _multigraph._Band8;
                                ArrayList arrselectedDate = new ArrayList();
                                arrselectedDate.Add(PublicClass.tym);
                                _LineGraph = new LineGraphControl();
                                arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, "Axial");
                                if (arrXYVals.Count > 0)
                                {
                                    highname = "Axial High Value";
                                    lowname = "Axial Low Value";
                                    if (Band1 != 0)
                                    {
                                        _LineGraph_cut1 = new LineGraphControl();
                                        _LineGraph_cut2 = new LineGraphControl();
                                        clscommon._MainForm = this; clscommon._Maincontrol = objGcontrol;
                                        clscommon.DrawMultiGraph(arrXYVals, NumberofGraphs, Band1, Band2, highname, lowname, "Axial");
                                    }
                                }

                                arrXYVals1 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, "Horizontal");
                                if (arrXYVals1.Count > 0)
                                {
                                    highname = "Horizontal High Value";
                                    lowname = "Horizontal Low Value";
                                    if (Band3 != 0)
                                    {
                                        _LineGraph_cut3 = new LineGraphControl();
                                        _LineGraph_cut4 = new LineGraphControl();
                                        clscommon._MainForm = this; clscommon._Maincontrol = objGcontrol;
                                        clscommon.DrawMultiGraph(arrXYVals1, NumberofGraphs, Band3, Band4, highname, lowname, "Horizontal");
                                    }
                                }

                                arrXYVals2 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, "Vertical");
                                if (arrXYVals2.Count > 0)
                                {
                                    highname = "Verticle High Value";
                                    lowname = "verticle Low Value";
                                    if (Band5 != 0)
                                    {
                                        _LineGraph_cut5 = new LineGraphControl();
                                        _LineGraph_cut6 = new LineGraphControl();
                                        clscommon._MainForm = this; clscommon._Maincontrol = objGcontrol;
                                        clscommon.DrawMultiGraph(arrXYVals2, NumberofGraphs, Band5, Band6, highname, lowname, "Vertical");
                                    }
                                }
                                arrXYVals3 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, "Channel1");
                                if (arrXYVals3.Count > 0)
                                {
                                    highname = "Channel1 High Value";
                                    lowname = "Channel1 Low Value";
                                    if (Band7 != 0)
                                    {
                                        _LineGraph_cut7 = new LineGraphControl();
                                        _LineGraph_cut8 = new LineGraphControl();
                                        clscommon._MainForm = this; clscommon._Maincontrol = objGcontrol;
                                        clscommon.DrawMultiGraph(arrXYVals3, NumberofGraphs, Band7, Band8, highname, lowname, "Channel1");
                                    }
                                }
                            }
                            modify = false;
                        }
                    }
                    else
                    {
                        try
                        {
                            m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                            modify = true;
                        }
                        catch { }
                    }
                }
            }
            catch
            {
            }
        }

        private void bbDeleteDatabase_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmDeleteDatabase objdelete = new frmDeleteDatabase();
                objdelete.ShowDialog();
            }
            catch
            { }
        }

        private void bbDeleteFrmInstrument_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DeleteBenstonDatabase frmDbDel = new DeleteBenstonDatabase();
                frmDbDel.ShowDialog();
            }
            catch
            { }
        }

        private void bbCreateBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmbackup bckup = new frmbackup();
                bckup.ShowDialog();
            }
            catch { }
        }

        private void bbBackupSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmBackupdatabaseNew bckdata = new frmBackupdatabaseNew();
                bckdata.ShowDialog();
            }
            catch { }
        }

        private void bbChangeXUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ChangeDataUnitforIMXANew(CurrentXLabel, "X");
            }
            catch (Exception ex)
            { }
        }

        private void ChangeDataUnitforIMXANew(string RawUnit, string Axis)
        {
            string sUnitNew = null;
            string sUnitBlank = "Blank";
            try
            {
                string[] splUnit = RawUnit.Split(new string[] { "Y Unit", "X Unit", ":", " ", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                frmUnit_IMXA _Unit_IMXA = new frmUnit_IMXA();
                _Unit_IMXA.usrcontrol = _objUserControl;
                _Unit_IMXA.SetHeader(Axis);
                byte[] _charUnit = Encoding.ASCII.GetBytes(splUnit[0].ToString());
                if (_charUnit.Length == 4)
                {
                    if (_charUnit[0].ToString() == "109" && _charUnit[1].ToString() == "47" && _charUnit[2].ToString() == "115" && _charUnit[3].ToString() == "63")
                    {
                        splUnit[0] = "m/s2";
                    }
                }
                _Unit_IMXA.GetOldUnit = splUnit[0].ToString();
                _Unit_IMXA.ShowDialog();

                if (_Unit_IMXA.IsOkClicked)
                {
                    if (_Unit_IMXA.UnitSelected)
                    {
                        sUnitNew = _Unit_IMXA.RetNewUnit.ToString();
                        if (Axis == "X")
                        {
                            CurrentXLabel = sUnitNew.ToString();
                            double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew);
                            double[] TempX = new double[xarrayNew.Length];
                            if (sUnitNew == "Order")
                            {
                                int MainIndex = Array.FindIndex(xarrayNew, delegate(double item) { return item == ConversionFactor; });
                                double tempCF = ConversionFactor;

                                if (MainIndex == -1)
                                {
                                    if (ConversionFactor <= xarrayNew[xarrayNew.Length - 1])
                                    {
                                        tempCF = FindNearest(xarrayNew, ConversionFactor);
                                        MainIndex = Array.FindIndex(xarrayNew, delegate(double item) { return item == tempCF; });
                                    }
                                }

                                double FreqToCalc = 0;
                                int ictr = 1;

                                for (int i = 0; i < TempX.Length; i++)
                                {
                                    FreqToCalc = (double)xarrayNew[i] / ConversionFactor;
                                    if (i == MainIndex)
                                    {
                                        ictr++;
                                        double temporx = ConversionFactor * ictr;

                                        MainIndex = Array.FindIndex(xarrayNew, delegate(double item) { return item == temporx; });

                                        if (MainIndex == -1)
                                        {
                                            if (temporx <= xarrayNew[xarrayNew.Length - 1])
                                            {
                                                temporx = FindNearest(xarrayNew, temporx);
                                                MainIndex = Array.FindIndex(xarrayNew, delegate(double item) { return item == temporx; });
                                            }
                                        }
                                        FreqToCalc = ictr - 1;
                                    }
                                    TempX[i] = FreqToCalc;
                                }
                            }
                            else
                            {
                                for (int i = 0; i < TempX.Length; i++)
                                {
                                    TempX[i] = (double)xarrayNew[i] * ConversionFactor;
                                }
                            }
                            if (sUnitNew == "Hz")
                            {
                                xarrayNew = xarrayNw;
                            }
                            else
                            {
                                xarrayNew = TempX;
                            }
                            DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                        }
                        if (Axis == "Y")
                        {
                            if (sUnitNew.ToString() == "db")
                            {
                                bbOctave.Enabled = true;
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), "IPS", (float)1);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;

                                    if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                    {
                                        if (xarrayNew[i] != 0)
                                        {
                                            if (CurrentXLabel.Contains("CPM"))
                                            {
                                                TempY[i] = TempY[i] * xarrayNew[i];
                                            }
                                            else if (CurrentXLabel.Contains("Hz"))
                                            {
                                                TempY[i] = TempY[i] * (xarrayNew[i] * 60);
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                                    {
                                        if (xarrayNew[i] != 0)
                                        {
                                            if (CurrentXLabel.Contains("CPM"))
                                            {
                                                TempY[i] = TempY[i] / (xarrayNew[i]);
                                            }
                                            else if (CurrentXLabel.Contains("Hz"))
                                            {
                                                TempY[i] = TempY[i] / (xarrayNew[i] * 60);
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;
                                CurrentYLabel = sUnitNew.ToString();
                                ConversionFactor = _Unit_IMXA.UnitConverter("IPS", "mm/s");
                                TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    if (yarrayNew[i] > 0)
                                    {
                                        TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                        TempY[i] = 20 * Math.Log10(TempY[i] / Math.Pow(10, (-5)));
                                    }
                                    else
                                    {
                                        TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                    }
                                }

                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    if (TempY[i] != 0)
                                    {
                                        if (xarrayNew[i] != 0)
                                        {

                                            //vdb
                                            if (splUnit[0].ToString() == "IPS" || splUnit[0].ToString() == "in/s" || splUnit[0].ToString() == "mm/s" || splUnit[0].ToString() == "cm/s" || splUnit[0].ToString() == "m/s" || splUnit[0].ToString() == "ft/s")
                                            {

                                            }
                                            //  adb
                                            else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                                            {
                                                TempY[i] = TempY[i] + (20 * Math.Log10(xarrayNew[i])) - 44;
                                            }
                                            //ddb
                                            else if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                            {
                                                TempY[i] = TempY[i] - (20 * Math.Log10(xarrayNew[i])) - 24;
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;
                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else
                            {
                                CurrentYLabel = sUnitNew.ToString();
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                }


                                yarrayNew = TempY;
                            }

                            DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                        }
                    }
                    else if (_Unit_IMXA.ConversionSelected)
                    {
                        bool bchkTime = CheckForTimeData(yarrayNew);
                        {
                            float fCPM = 1;
                            sUnitNew = _Unit_IMXA.RetNewUnit.ToString();
                            if (sUnitNew == "Displacement (Mils)")
                            {
                                sUnitNew = "Mils";
                                CurrentYLabel = sUnitNew.ToString();
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                    if (splUnit[0].ToString() == "IPS" || splUnit[0].ToString() == "in/s" || splUnit[0].ToString() == "mm/s" || splUnit[0].ToString() == "cm/s" || splUnit[0].ToString() == "m/s" || splUnit[0].ToString() == "ft/s")
                                    {
                                        if (bchkTime)
                                        {
                                            TempY[i] = TempY[i] * xarrayNew[i];
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM") || bchkTime)
                                                {
                                                    TempY[i] = TempY[i] / xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                                    {
                                        if (bchkTime)
                                        {
                                            TempY[i] = TempY[i] * Math.Pow(xarrayNew[i], 2);
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM") || bchkTime)
                                                {
                                                    TempY[i] = TempY[i] / Math.Pow(xarrayNew[i], 2);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] / (Math.Pow((xarrayNew[i] * 60), 2));
                                                }
                                            }
                                        }
                                    }

                                }
                                yarrayNew = TempY;
                                overallcol = "displ_";
                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else if (sUnitNew == "Displacement (mm)")
                            {
                                sUnitNew = "Mils";
                                overallcol = "displ_";
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                    if (splUnit[0].ToString() == "IPS" || splUnit[0].ToString() == "in/s" || splUnit[0].ToString() == "mm/s" || splUnit[0].ToString() == "cm/s" || splUnit[0].ToString() == "m/s" || splUnit[0].ToString() == "ft/s")
                                    {
                                        if (bchkTime)
                                        {
                                            TempY[i] = TempY[i] * xarrayNew[i];
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM") || bchkTime)
                                                {
                                                    TempY[i] = TempY[i] / xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                                    {
                                        if (bchkTime)
                                        {
                                            TempY[i] = TempY[i] * Math.Pow(xarrayNew[i], 2);
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM") || bchkTime)
                                                {
                                                    TempY[i] = TempY[i] / Math.Pow(xarrayNew[i], 2);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] / (Math.Pow((xarrayNew[i] * 60), 2));
                                                }
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;


                                sUnitNew = "mm";
                                CurrentYLabel = sUnitNew.ToString();
                                ConversionFactor = _Unit_IMXA.UnitConverter("Mils", sUnitNew);
                                TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                }
                                yarrayNew = TempY;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else if (sUnitNew == "Displacement (um)")
                            {
                                sUnitNew = "Mils";
                                overallcol = "displ_";
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                    if (splUnit[0].ToString() == "IPS" || splUnit[0].ToString() == "in/s" || splUnit[0].ToString() == "mm/s" || splUnit[0].ToString() == "cm/s" || splUnit[0].ToString() == "m/s" || splUnit[0].ToString() == "ft/s")
                                    {
                                        if (bchkTime)
                                        {
                                            TempY[i] = TempY[i] * xarrayNew[i];
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM") || bchkTime)
                                                {
                                                    TempY[i] = TempY[i] / xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                                    {
                                        if (bchkTime)
                                        {
                                            TempY[i] = TempY[i] * Math.Pow(xarrayNew[i], 2);
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] / Math.Pow(xarrayNew[i], 2);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] / (Math.Pow((xarrayNew[i] * 60), 2));
                                                }
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;


                                sUnitNew = "um";
                                CurrentYLabel = sUnitNew.ToString();
                                ConversionFactor = _Unit_IMXA.UnitConverter("Mils", sUnitNew);
                                TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                }
                                yarrayNew = TempY;
                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else if (sUnitNew == "Acceleration (g)")
                            {
                                sUnitNew = "g";
                                overallcol = "accel_";
                                CurrentYLabel = sUnitNew.ToString();
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;

                                    if (splUnit[0].ToString() == "IPS" || splUnit[0].ToString() == "in/s" || splUnit[0].ToString() == "mm/s" || splUnit[0].ToString() == "cm/s" || splUnit[0].ToString() == "m/s" || splUnit[0].ToString() == "ft/s")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / xarrayNew[i];
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / Math.Pow(xarrayNew[i], 2);
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * Math.Pow(xarrayNew[i], 2);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (Math.Pow((xarrayNew[i] * 60), 2));
                                                }
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;
                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else if (sUnitNew == "Acceleration (mm/s2)")
                            {
                                sUnitNew = "g";
                                overallcol = "accel_";
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;


                                    if (splUnit[0].ToString() == "IPS" || splUnit[0].ToString() == "in/s" || splUnit[0].ToString() == "mm/s" || splUnit[0].ToString() == "cm/s" || splUnit[0].ToString() == "m/s" || splUnit[0].ToString() == "ft/s")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / xarrayNew[i];
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / Math.Pow(xarrayNew[i], 2);
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * Math.Pow(xarrayNew[i], 2);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (Math.Pow((xarrayNew[i] * 60), 2));
                                                }
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;

                                sUnitNew = "mm/s2";
                                CurrentYLabel = sUnitNew.ToString();
                                ConversionFactor = _Unit_IMXA.UnitConverter("g", sUnitNew);
                                TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                }
                                yarrayNew = TempY;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else if (sUnitNew == "Acceleration (cm/s2)")
                            {
                                sUnitNew = "g";
                                overallcol = "accel_";
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;


                                    if (splUnit[0].ToString() == "IPS" || splUnit[0].ToString() == "in/s" || splUnit[0].ToString() == "mm/s" || splUnit[0].ToString() == "cm/s" || splUnit[0].ToString() == "m/s" || splUnit[0].ToString() == "ft/s")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / xarrayNew[i];
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / Math.Pow(xarrayNew[i], 2);
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * Math.Pow(xarrayNew[i], 2);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (Math.Pow((xarrayNew[i] * 60), 2));
                                                }
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;

                                sUnitNew = "cm/s2";
                                CurrentYLabel = sUnitNew.ToString();
                                ConversionFactor = _Unit_IMXA.UnitConverter("g", sUnitNew);
                                TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                }
                                yarrayNew = TempY;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else if (sUnitNew == "Acceleration (m/s2)")
                            {
                                sUnitNew = "g"; overallcol = "accel_";
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;


                                    if (splUnit[0].ToString() == "IPS" || splUnit[0].ToString() == "in/s" || splUnit[0].ToString() == "mm/s" || splUnit[0].ToString() == "cm/s" || splUnit[0].ToString() == "m/s" || splUnit[0].ToString() == "ft/s")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / xarrayNew[i];
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / Math.Pow(xarrayNew[i], 2);
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * Math.Pow(xarrayNew[i], 2);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (Math.Pow((xarrayNew[i] * 60), 2));
                                                }
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;

                                sUnitNew = "m/s2";
                                CurrentYLabel = sUnitNew.ToString();
                                ConversionFactor = _Unit_IMXA.UnitConverter("g", sUnitNew);
                                TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                }
                                yarrayNew = TempY;
                                YSelected = y;
                                objGcontrol.panel1.Refresh();
                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else if (sUnitNew == "Velocity (IPS)")
                            {
                                sUnitNew = "IPS"; overallcol = "vel_";
                                CurrentYLabel = sUnitNew.ToString();
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;


                                    if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / (xarrayNew[i]);
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                                    {
                                        if (bchkTime)
                                        {
                                            TempY[i] = TempY[i] * (xarrayNew[i]);
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i]);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else if (sUnitNew == "Velocity (mm/s)")
                            {
                                sUnitNew = "IPS";
                                overallcol = "vel_";
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;


                                    if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / (xarrayNew[i]);
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                                    {
                                        if (bchkTime)
                                        {
                                            TempY[i] = TempY[i] * (xarrayNew[i]);
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i]);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i] * 60);
                                                }

                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;

                                sUnitNew = "mm/s";
                                CurrentYLabel = sUnitNew.ToString();
                                ConversionFactor = _Unit_IMXA.UnitConverter("IPS", sUnitNew);
                                TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                }

                                yarrayNew = TempY;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else if (sUnitNew == "Velocity (cm/s)")
                            {
                                sUnitNew = "IPS"; overallcol = "vel_";
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;


                                    if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / (xarrayNew[i]);
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                                    {
                                        if (bchkTime)
                                        {
                                            TempY[i] = TempY[i] * (xarrayNew[i]);
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i]);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;

                                sUnitNew = "cm/s";
                                CurrentYLabel = sUnitNew.ToString();
                                ConversionFactor = _Unit_IMXA.UnitConverter("IPS", sUnitNew);
                                TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                }

                                yarrayNew = TempY;
                                YSelected = y;
                                objGcontrol.panel1.Refresh();
                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else if (sUnitNew == "Velocity (m/s)")
                            {
                                sUnitNew = "IPS"; overallcol = "vel_";
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;


                                    if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / (xarrayNew[i]);
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                                    {
                                        if (bchkTime)
                                        {
                                            TempY[i] = TempY[i] * (xarrayNew[i]);
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i]);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;

                                sUnitNew = "m/s";
                                CurrentYLabel = sUnitNew.ToString();
                                ConversionFactor = _Unit_IMXA.UnitConverter("IPS", sUnitNew);
                                TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                }

                                yarrayNew = TempY;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            else if (sUnitNew == "Velocity (ft/s)")
                            {
                                sUnitNew = "IPS"; overallcol = "vel_";
                                double ConversionFactor = _Unit_IMXA.UnitConverter(splUnit[0].ToString(), sUnitNew, fCPM);
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;


                                    if (splUnit[0].ToString() == "mm" || splUnit[0].ToString() == "um" || splUnit[0].ToString() == "mil" || splUnit[0].ToString() == "Mils")
                                    {
                                        if (bchkTime)
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                TempY[i] = TempY[i] / (xarrayNew[i]);
                                            }
                                            else
                                            {
                                                TempY[i] = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] * xarrayNew[i];
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] * (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                    else if (splUnit[0].ToString() == "Gs" || splUnit[0].ToString() == "G" || splUnit[0].ToString() == "g" || splUnit[0].ToString() == "mm/s2" || splUnit[0].ToString() == "cm/s2" || splUnit[0].ToString() == "m/s2" || splUnit[0].ToString() == "gal")
                                    {
                                        if (bchkTime)
                                        {
                                            TempY[i] = TempY[i] * (xarrayNew[i]);
                                        }
                                        else
                                        {
                                            if (xarrayNew[i] != 0)
                                            {
                                                if (CurrentXLabel.Contains("CPM"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i]);
                                                }
                                                else if (CurrentXLabel.Contains("Hz"))
                                                {
                                                    TempY[i] = TempY[i] / (xarrayNew[i] * 60);
                                                }
                                            }
                                        }
                                    }
                                }
                                yarrayNew = TempY;

                                sUnitNew = "ft/s";
                                CurrentYLabel = sUnitNew.ToString();
                                ConversionFactor = _Unit_IMXA.UnitConverter("IPS", sUnitNew);
                                TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                }

                                yarrayNew = TempY;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                        }

                    }
                    #region Commented

                    #endregion
                    else
                    {
                        string Formula = _Unit_IMXA._Formula.ToString();
                        string FormulaUnit = _Unit_IMXA._FormulaUnit.ToString();
                        if (Axis == "X")
                        {
                            CurrentXLabel = FormulaUnit.ToString();
                        }
                        if (Axis == "Y")
                        {
                            CurrentYLabel = FormulaUnit;
                        }
                        string[] arrFormula = Formula.Split(new string[] { "+", "-", "/", "*" }, StringSplitOptions.RemoveEmptyEntries);
                        double ConversionFactor = Convert.ToDouble(arrFormula[0].ToString());
                        if (Formula.Contains("/"))
                        {
                            if (Axis == "X")
                            {
                                double[] TempX = new double[xarrayNew.Length];
                                for (int i = 0; i < TempX.Length; i++)
                                {
                                    TempX[i] = (double)xarrayNew[i] / ConversionFactor;
                                }
                                xarrayNew = TempX;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            if (Axis == "Y")
                            {
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] / ConversionFactor;
                                }
                                yarrayNew = TempY;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                        }
                        else if (Formula.Contains("*"))
                        {
                            if (Axis == "X")
                            {
                                double[] TempX = new double[xarrayNew.Length];
                                for (int i = 0; i < TempX.Length; i++)
                                {
                                    TempX[i] = (double)xarrayNew[i] * ConversionFactor;
                                }
                                xarrayNew = TempX;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            if (Axis == "Y")
                            {
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] * ConversionFactor;
                                }
                                yarrayNew = TempY;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                        }
                        else if (Formula.Contains("+"))
                        {
                            if (Axis == "X")
                            {
                                double[] TempX = new double[xarrayNew.Length];
                                for (int i = 0; i < TempX.Length; i++)
                                {
                                    TempX[i] = (double)xarrayNew[i] + ConversionFactor;
                                }
                                xarrayNew = TempX;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            if (Axis == "Y")
                            {
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] + ConversionFactor;
                                }
                                yarrayNew = TempY;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                        }
                        else if (Formula.Contains("-"))
                        {
                            if (Axis == "X")
                            {
                                double[] TempX = new double[xarrayNew.Length];
                                for (int i = 0; i < TempX.Length; i++)
                                {
                                    TempX[i] = (double)xarrayNew[i] - ConversionFactor;
                                }
                                xarrayNew = TempX;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                            if (Axis == "Y")
                            {
                                double[] TempY = new double[yarrayNew.Length];
                                for (int i = 0; i < TempY.Length; i++)
                                {
                                    TempY[i] = (double)yarrayNew[i] - ConversionFactor;
                                }
                                yarrayNew = TempY;

                                DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                            }
                        }
                    }
                    GphCtr = 0;

                }

                string SelectedCursorItem = cmbCurSors.Items[0].ToString();
                CmbCursorSelectedItem(SelectedCursorItem);
                objGcontrol.dataGridView1.Rows.Clear();
                while (objGcontrol.dataGridView1.Rows.Count > 1)
                {
                    objGcontrol.dataGridView1.Rows.RemoveAt(0);
                }

            }
            catch (Exception ex)
            {
            }
        }

        private int GphCtr = 0;
        private void bbChangeYUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ChangeDataUnitforIMXANew(CurrentYLabel, "Y");
            }
            catch
            {
            }
        }

        private void chkShowCursorVal_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            _ShowCursorVal = chkShowCursorVal.Checked;
        }

        ArrayList arlstDates = null;
        string sTime = null; string data_id = null;
        ArrayList arlstData_id = new ArrayList();
        string previoustym = null; DataTable dt = null;
        string currenttym = PublicClass.tym; string checktime = null;
        public void checkPrevnextGraph()
        {
            try
            {
                arlstDates = new ArrayList(); arlstSelectedTime = new ArrayList();
                dt = DbClass.getdata(CommandType.Text, "select data_id,Measure_time from point_data where point_id='" + PublicClass.SPointID + "'");
                foreach (DataRow dr3 in dt.Rows)
                {
                    data_id = Convert.ToString(dr3["data_id"]);
                    sTime = Convert.ToDateTime(dr3["Measure_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                    arlstData_id.Add(data_id);
                    arlstDates.Add(sTime);
                }
                for (int i = 0; i < arlstDates.Count; i++)
                {
                    checktime = Convert.ToString(arlstDates[i]);
                    if (PublicClass.tym == checktime)
                    {
                        PublicClass.tym = Convert.ToString(arlstDates[i - 1]);
                        arlstSelectedTime.Add(PublicClass.tym);
                        previoustym = PublicClass.tym;
                        break;
                    }
                }
                string[] AddValue = { "Axial", "Horizontal", "Vertical", "Channel1" };
                for (int aa = 0; aa < AddValue.Length; aa++)
                {
                    arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arlstSelectedTime, PublicClass.GraphClicked, AddValue[aa]);
                    if (arrXYVals.Count > 0)
                    {
                        PublicClass.checkgraphtime = "true";
                        PublicClass.AHVCH1 = AddValue[aa];
                        break;
                    }
                }

                m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                lblStatus.Caption = "Data Collected Date: " + PublicClass.tym + "";
            }
            catch
            {
            }
        }

        private void bbGraphBack_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                checkPrevnextGraph();
            }
            catch { }
        }

        string text = null;
        private void bbGraphNext_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                arlstSelectedTime = new ArrayList();
                for (int i = 0; i < arlstDates.Count; i++)
                {
                    checktime = Convert.ToString(arlstDates[i]);
                    if (PublicClass.tym == checktime)
                    {
                        PublicClass.tym = Convert.ToString(arlstDates[i + 1]);
                        arlstSelectedTime.Add(PublicClass.tym);
                        previoustym = PublicClass.tym;
                        break;
                    }
                }
                string[] AddValue = { "Axial", "Horizontal", "Vertical", "Channel1" };

                for (int aa = 0; aa < AddValue.Length; aa++)
                {
                    arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arlstSelectedTime, PublicClass.GraphClicked, AddValue[aa]);
                    if (arrXYVals.Count > 0)
                    {
                        PublicClass.checkgraphtime = "true";
                        PublicClass.AHVCH1 = AddValue[aa];
                        break;
                    }
                }
                m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                lblStatus.Caption = "Data Collected Date: " + PublicClass.tym + "";
            }
            catch { }
        }

        private void bbGenSDF_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Start Importing Sdf File";
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2" || PublicClass.currentInstrument == "Kohtect-C911")
                {
                    GeneratingfromSdf objFrmSdf = new GeneratingfromSdf();
                    objFrmSdf.Instrument = PublicClass.currentInstrument;
                    if (PublicClass.currentInstrument == "Kohtect-C911")
                    {
                        objFrmSdf.rbfolder.Visible = true;
                        objFrmSdf.rbfile.Visible = true;
                        objFrmSdf.ShowDialog();
                    }
                    else
                    {
                        objFrmSdf.ShowDialog();
                    }
                    if (!objFrmSdf.IsCancelClicked)
                    {
                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "SKF/DI" || PublicClass.currentInstrument == "Kohtect-C911" || PublicClass.currentInstrument == "FieldPaq2")
                        {
                            if (objFrmSdf.PCDB != "")
                            {
                                if (objFrmSdf.st = true)
                                {
                                    /////------///////////
                                    PublicClass.flagAlarm = true;
                                    PublicClass.CreateConnection(objFrmSdf.PCDB);
                                    defaultcolor();
                                    ///--------//
                                    ribbonPageCategory1.Text = "Selected DataBase: " + Iadeptmain.GlobalClasses.PublicClass.User_DataBase;
                                    try
                                    {
                                        if (Iadeptmain.GlobalClasses.PublicClass.LoginStatus == false)
                                        {
                                            this.Dispose();
                                        }
                                        else
                                        {
                                            SetUserTabpages();
                                            if (PublicClass.currentInstrument == "SKF/DI" || PublicClass.currentInstrument == "Kohtect-C911")
                                            { rpSensor.Visible = false; ribbonPageGroup3.Visible = false; rpdashboard.Visible = false; }
                                            ssStatus.Text = "User Name= " + Iadeptmain.GlobalClasses.PublicClass.User_Name.Trim() + " and IPAddress= " + Iadeptmain.GlobalClasses.PublicClass.User_IP.Trim() + "  ";
                                        }
                                        fillform();
                                        lblStatus.Caption = "Status: Database Created Successfully";
                                    }
                                    catch { }
                                }
                                else
                                { }
                            }
                            else
                            {
                                MessageBox.Show(this, "Fill Database Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                else
                {
                    GenerateDIDatabase objFrmSdf = new GenerateDIDatabase();
                    objFrmSdf.Instrument = PublicClass.currentInstrument;
                    objFrmSdf.ShowDialog();
                    if (!objFrmSdf.IsCancelClicked)
                    {
                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "SKF/DI" || PublicClass.currentInstrument == "FieldPaq2")
                        {
                            if (objFrmSdf.PCDB != "")
                            {
                                if (objFrmSdf.st = true)
                                {
                                    /////------///////////
                                    PublicClass.flagAlarm = true;
                                    PublicClass.CreateConnection(objFrmSdf.PCDB);
                                    defaultcolor();
                                    ///--------//
                                    ribbonPageCategory1.Text = "Selected DataBase: " + Iadeptmain.GlobalClasses.PublicClass.User_DataBase;
                                    try
                                    {
                                        if (Iadeptmain.GlobalClasses.PublicClass.LoginStatus == false)
                                        {
                                            this.Dispose();
                                        }
                                        else
                                        {
                                            SetUserTabpages();
                                            if (PublicClass.currentInstrument == "SKF/DI")
                                            { rpSensor.Visible = false; ribbonPageGroup3.Visible = false; rpdashboard.Visible = false; }
                                            ssStatus.Text = "User Name= " + Iadeptmain.GlobalClasses.PublicClass.User_Name.Trim() + " and IPAddress= " + Iadeptmain.GlobalClasses.PublicClass.User_IP.Trim() + "  ";
                                        }
                                        fillform();
                                        lblStatus.Caption = "Status: Database Created Successfully";
                                    }
                                    catch { }
                                }
                                else
                                { }
                            }
                            else
                            {
                                MessageBox.Show(this, "Fill Database Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }

            }
            catch
            { }
        }

        private void bbftod_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        ArrayList arlstSelectedTtimeoverlap = new ArrayList();
        public void datagridcontent(int aa)
        {
            ArrayList arlNewTime = new ArrayList();
            ArrayList arlColorTag = new ArrayList();
            string[] starColor = { "Red", "Green", "Orange" };
            int color = 0;
            bool bDoNotCreate = false;
            bool setColor = true;
            int ColorValue = 0;
            string DatagridCaption = null;
            arlSelectedDataGridValue = new ArrayList();
            string sInstrumentName = PublicClass.currentInstrument;
            try
            {
                if (SetIsTrend)
                {
                    if (aa <= objGcontrol.dataGridView2.RowCount - 1)
                    {
                        if (objGcontrol.dataGridView2.Rows[aa].Cells[1].Value.ToString() == "√")
                        {
                            if (iclick > 1)
                            {
                                objGcontrol.dataGridView2.Rows[aa].Cells[1].Value = "X";
                                Set_iClick(Function.Subtract);
                            }
                            else
                            {
                                bDoNotCreate = true;
                            }
                        }
                        else
                        {
                            objGcontrol.dataGridView2.Rows[aa].Cells[1].Value = "√";
                            ColorValue = Convert.ToInt32(objGcontrol.dataGridView2.Rows[aa].Cells[3].Tag.ToString());
                            DatagridCaption = aa.ToString();
                            Set_iClick(Function.Add);
                            setColor = false;
                        }
                        for (int i = 0; i < objGcontrol.dataGridView2.Rows.Count - 1; i++)
                        {
                            if (objGcontrol.dataGridView2.Rows[i].Cells[1].Value.ToString() == "√")
                            {
                                arlNewTime.Add(objGcontrol.dataGridView2.Rows[i].Cells[0].Value.ToString());
                                arlColorTag.Add(objGcontrol.dataGridView2.Rows[i].Cells[3].Tag.ToString());
                                arlSelectedDataGridValue.Add(i);
                                if (setColor)
                                {
                                    ColorValue = Convert.ToInt32(objGcontrol.dataGridView2.Rows[i].Cells[3].Tag.ToString());
                                    DatagridCaption = i.ToString();
                                }
                                color++;
                            }
                        }
                        arlstSColors = new ArrayList();
                        arlstSColors = arlColorTag;
                        if (!bDoNotCreate)
                        {
                            if (EdittextDirection == "Overlap")
                            {
                                for (int i = 0; i < arlNewTime.Count; i++)
                                {
                                    string stime = (string)arlNewTime[i];
                                    string[] time = stime.Split();
                                    string newTime = (string)time[2];
                                    if (newTime == "Axial")
                                    {
                                        PublicClass.Axialoverlap = true;
                                    }
                                    else if (newTime == "Horizontal")
                                    {
                                        PublicClass.horoverlap = true;
                                    }
                                    else if (newTime == "Vertical")
                                    {
                                        PublicClass.veroverlap = true;
                                    }
                                    else if (newTime == "Channel1")
                                    {
                                        PublicClass.chanoverlap = true;
                                    }
                                }

                                //arlstSelectedTime.Clear();
                                arlstSelectedTime.Add(PublicClass.tym);
                                if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "FieldPaq2")
                                {
                                    PublicClass.overlaybool = true;
                                    arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arlstSelectedTime, PublicClass.GraphClicked, EdittextDirection);
                                    PublicClass.overlaybool = false;
                                    PublicClass.Axialoverlap = false;
                                    PublicClass.horoverlap = false;
                                    PublicClass.veroverlap = false;
                                    PublicClass.chanoverlap = false;
                                }
                                else if (sInstrumentName == "DI-460")
                                {
                                    //arrXYVals = objIHand.GetAllPlotValuesDI(m_objMainControl._PointID, arlstSelectedTime, GenDiGraph);
                                }
                            }
                            else
                            {
                                arlstSelectedTime = arlNewTime;
                                if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "FieldPaq2")
                                {
                                    arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arlstSelectedTime, PublicClass.GraphClicked, EdittextDirection);
                                }
                                else if (sInstrumentName == "DI-460")
                                {
                                    //arrXYVals = objIHand.GetAllPlotValuesDI(m_objMainControl._PointID, arlstSelectedTime, GenDiGraph);
                                }
                            }
                            arlstSelectedTime = arlNewTime;
                            string[] colors = new string[arlstSelectedTime.Count];
                            for (int i = 0; i < colors.Length; i++)
                            {
                                colors[i] = arlstSColors[i].ToString();
                            }
                            RemovePreviousGraphControl();
                            DrawLineGraphs(arrXYVals, colors);
                            NavigateGraphs(ColorValue, DatagridCaption);
                        }
                    }
                }
                else if (IsOrbitPlot)
                {
                    if (aa < objGcontrol.dataGridView2.RowCount - 1)
                    {
                        if (objGcontrol.dataGridView2.Rows[aa].Cells[1].Value.ToString() == "√")
                        {
                            bDoNotCreate = true;
                        }
                        else
                        {
                            for (int i = 0; i < objGcontrol.dataGridView2.Rows.Count - 1; i++)
                            {
                                if (objGcontrol.dataGridView2.Rows[i].Cells[1].Value.ToString() == "√")
                                {
                                    objGcontrol.dataGridView2.Rows[i].Cells[1].Value = "X";
                                    break;
                                }
                            }
                            objGcontrol.dataGridView2.Rows[aa].Cells[1].Value = "√";
                        }
                        for (int i = 0; i < objGcontrol.dataGridView2.Rows.Count - 1; i++)
                        {
                            if (objGcontrol.dataGridView2.Rows[i].Cells[1].Value.ToString() == "√")
                            {
                                arlNewTime.Add(objGcontrol.dataGridView2.Rows[i].Cells[0].Value.ToString());
                                arlColorTag.Add(objGcontrol.dataGridView2.Rows[i].Cells[3].Tag.ToString());
                                arlSelectedDataGridValue.Add(i);
                                ColorValue = Convert.ToInt32(objGcontrol.dataGridView2.Rows[i].Cells[3].Tag.ToString());
                                DatagridCaption = i.ToString();
                                color++;
                                break;
                            }
                        }
                        arlstSColors = new ArrayList();
                        arlstSColors = arlColorTag;

                        if (!bDoNotCreate)
                        {
                            arlstSelectedTime = new ArrayList();
                            arlstSelectedTime = arlNewTime;

                            arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arlstSelectedTime, "Time", "Vertical");
                            arrXYVals1 = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arlstSelectedTime, "Time", "Horizontal");

                            string[] colors = new string[1];
                            {
                                colors[0] = arlstSColors[0].ToString();
                            }
                            if (arrXYVals.Count > 1 && arrXYVals1.Count > 1)
                            {
                                ArrayList arlOrbitData = new ArrayList();
                                arlOrbitData.Add((double[])arrXYVals1[1]);
                                arlOrbitData.Add((double[])arrXYVals[1]);
                                DrawLineOrbitGraphs(arlOrbitData, colors);
                                NavigateGraphs(ColorValue, DatagridCaption);
                            }
                        }
                    }
                }
                else if (IsWaterfall)
                {
                    if (aa < objGcontrol.dataGridView2.RowCount - 1)
                    {
                        if (objGcontrol.dataGridView2.Rows[aa].Cells[1].Value.ToString() == "√")
                        {
                            if (iclick > 1)
                            {
                                objGcontrol.dataGridView2.Rows[aa].Cells[1].Value = "X";
                                Set_iClick(Function.Subtract);
                            }
                            else
                            {
                                bDoNotCreate = true;
                            }
                        }
                        else
                        {
                            objGcontrol.dataGridView2.Rows[aa].Cells[1].Value = "√";
                            Set_iClick(Function.Add);
                        }
                        for (int i = 0; i < objGcontrol.dataGridView2.Rows.Count - 1; i++)
                        {
                            if (objGcontrol.dataGridView2.Rows[i].Cells[1].Value.ToString() == "√")
                            {
                                arlNewTime.Add(objGcontrol.dataGridView2.Rows[i].Cells[0].Value.ToString());
                                arlColorTag.Add(objGcontrol.dataGridView2.Rows[i].Cells[3].Tag.ToString());
                                arlSelectedDataGridValue.Add(i);
                                color++;
                            }
                        }
                        arlstSColors = new ArrayList();
                        arlstSColors = arlColorTag;

                        if (!bDoNotCreate)
                        {
                            //arlstSelectedTime = new ArrayList();
                            arlstSelectedTime = arlNewTime;

                            if (sInstrumentName == "Impaq-Benstone" || sInstrumentName == "SKF/DI" || sInstrumentName == "FieldPaq2" || sInstrumentName == "Kohtect-C911")
                            {
                                arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, arlstSelectedTime, PublicClass.GraphClicked, EdittextDirection);
                            }
                            else if (sInstrumentName == "DI-460")
                            {
                                //arrXYVals = objIHand.GetAllPlotValuesDI(m_objMainControl._PointID, arlstSelectedTime, GenDiGraph);
                            }

                            string[] colors = new string[arlstSelectedTime.Count];
                            for (int i = 0; i < colors.Length; i++)
                            {
                                colors[i] = arlstSColors[i].ToString();
                            }
                            RemovePreviousGraphControl();
                            DrawWaterfallGraphs(arrXYVals, colors);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        bool bConvertToFFT = false; ArrayList _arlstPath = new ArrayList();
        ArrayList _arlstPath1 = new ArrayList(); ArrayList PhasetoDisplay;
        public void wavdatagridcontent(int aa)
        {
            ArrayList arlNewTime = new ArrayList();
            ArrayList arlColorTag = new ArrayList();
            arlSelectedDataGridValue = new ArrayList();
            string[] starColor = { "Red", "Green", "Orange" };
            int color = 0;
            bool bDoNotCreate = false;
            int ColorValue = 0;
            string DatagridCaption = null;
            //BtnOk = 1;
            ArrayList arlSelectedDataGridNumber = new ArrayList();
            ArrayList CursorItems = new ArrayList();
            NullCursorBools();
            try
            {
                SplashScreenManager.ShowForm(typeof(WaitForm2));
                if (Zoom)
                {
                    bbUnzoom_ItemClick(null, null);
                }

                if (bConvertToFFT)
                {
                    // bbConvertToFFT_ItemClick(null, null);
                }
                if (aa < objGcontrol.dataGridView2.RowCount - 1)
                {
                    if (!bFarzi)
                    {
                        if (objGcontrol.dataGridView2.Rows[aa].Cells[1].Value.ToString() == "√")
                        {


                            if (wavnode == "CSVFile" || wavnode == "DATFile")
                            {
                                if (iclick > 2)
                                {
                                    objGcontrol.dataGridView2.Rows[aa].Cells[1].Value = "X";
                                    Set_iClick(Function.Subtract);
                                }
                                else
                                {
                                    bDoNotCreate = true;
                                }
                            }
                            else
                            {
                                if (iclick > 1)
                                {
                                    objGcontrol.dataGridView2.Rows[aa].Cells[1].Value = "X";
                                    Set_iClick(Function.Subtract);
                                }
                                else
                                {
                                    bDoNotCreate = true;
                                }
                            }
                        }
                        else
                        {
                            objGcontrol.dataGridView2.Rows[aa].Cells[1].Value = "√";
                            Set_iClick(Function.Add);
                        }
                    }
                    try
                    {
                        for (int i = 0; i < objGcontrol.dataGridView2.Rows.Count - 1; i++)
                        {
                            if (objGcontrol.dataGridView2.Rows[i].Cells[1].Value.ToString() == "√")
                            {
                                arlNewTime.Add(objGcontrol.dataGridView2.Rows[i].Cells[2].Value.ToString());
                                if (objGcontrol.dataGridView2.Rows[i].Cells[3].Tag != null)
                                {
                                    arlColorTag.Add(objGcontrol.dataGridView2.Rows[i].Cells[3].Tag.ToString());
                                    arlSelectedDataGridValue.Add("ch1 " + i);
                                    arlSelectedDataGridNumber.Add(i);
                                    DatagridCaption = "ch1 " + i;
                                    ColorValue = Convert.ToInt32(objGcontrol.dataGridView2.Rows[i].Cells[3].Tag.ToString());
                                }
                                else
                                {
                                    DatagridCaption = "ch1 " + i;
                                    ColorValue = Convert.ToInt32("7667712");
                                    arlColorTag.Add("7667712");
                                }
                                color++;
                            }
                            else
                            {
                                try
                                {
                                    _arlstPath[2 * i] = new double[5];
                                    _arlstPath[(2 * i) + 1] = new double[5];
                                }
                                catch
                                {
                                }

                            }
                        }
                        for (int i = 0; i < objGcontrol.dataGridView2.Rows.Count - 1; i++)
                        {
                            if (objGcontrol.dataGridView2.Rows[i].Cells[1].Value.ToString() == "√")
                            {
                                arlNewTime.Add(objGcontrol.dataGridView2.Rows[i].Cells[0].Value.ToString());
                                if (objGcontrol.dataGridView2.Rows[i].Cells[3].Tag != null)
                                {
                                    arlColorTag.Add(objGcontrol.dataGridView2.Rows[i].Cells[3].Tag.ToString());
                                    arlSelectedDataGridValue.Add("ch2 " + i);
                                }
                                else
                                {
                                    arlColorTag.Add("7667712");
                                }
                                color++;
                            }
                        }
                    }
                    catch
                    {
                    }
                    arlstSColors = new ArrayList();
                    arlstSColors = arlColorTag;
                    setCursorCombo("Time");
                    if (!bDoNotCreate)
                    {
                        arlstSelectedTime = new ArrayList();
                        Thread.Sleep(20);
                        if (arlNewTime.Count > 0)
                        {
                            ArrayList arrXYVals = GetAllPlotValuesNewGraph(arlNewTime);
                            arrWAVReportXYVals = arrXYVals;
                            try
                            {
                                if (wavnode == "WAVFile" && (Name_Ch2 == "Tacho" || label_Ch2.Contains("Tacho")))
                                {
                                    PhasetoDisplay = new ArrayList();
                                    for (int i = 0; i < arrXYVals.Count; i++)
                                    {
                                        i++;
                                        FindAllWaves((double[])arrXYVals[i]);
                                        CalculatingPhase((double[])arrXYVals[i - 1], (i - 1) / 2);
                                    }
                                }
                                else
                                {
                                    PhasetoDisplay = null;
                                }
                            }
                            catch
                            {
                            }
                            // bbConvertToFFT.Enabled = true;
                            if (arlNewTime.Count == 1)
                            {
                                bbCepstrum.Enabled = true;
                            }
                            else
                            {
                                bbCepstrum.Enabled = false;
                            }

                            arlstSelectedTime = arrSelTime;
                            arlSelectedColorTag = arlColorTag;
                            string[] sarrColorTag = new string[arlSelectedColorTag.Count];
                            ArrayList xdta = new ArrayList();
                            ArrayList ydta = new ArrayList();
                            for (int i = 0; i < arrXYVals.Count / 2; i++)
                            {
                                xdta.Add((double[])arrXYVals[2 * i]);
                                ydta.Add((double[])arrXYVals[(2 * i) + 1]);
                                sarrColorTag[i] = arlSelectedColorTag[i].ToString();
                                try
                                {
                                    _arlstPath[2 * (int)arlSelectedDataGridNumber[i]] = (double[])arrXYVals[2 * i];
                                    _arlstPath[(2 * (int)arlSelectedDataGridNumber[i]) + 1] = (double[])arrXYVals[(2 * i) + 1];
                                }
                                catch
                                {
                                }
                            }
                            DrawLineGraphs(arrXYVals, sarrColorTag);
                            NavigateGraphs(ColorValue, DatagridCaption);


                            if (IsCrestTrend)
                            {
                                //bbConvertToFFT.Enabled = false;
                                bbCepstrum.Enabled = false;
                                if (arrXYVals.Count > 2)
                                {
                                    int j = 0;
                                    double[] CrestFactor = new double[arrXYVals.Count / 2];
                                    for (int i = 1; i < arrXYVals.Count; i++)
                                    {
                                        // CrestFactor[j] = CalculateCrestFactor((double[])arrXYVals[i]);
                                        j++;
                                        i++;
                                    }

                                    bFarzi = false;

                                    // panel1.Controls.Remove(_BarGraph);
                                    _BarGraph = null;
                                    _LineGraph.Dock = DockStyle.Fill;
                                    _BarGraph = new BarChart();
                                    _BarGraph._XLabel = "Hz";
                                    //_BarGraph._YLabel = lblDisplayunit.Text.ToString();
                                    _BarGraph.Dock = DockStyle.Top;
                                    _BarGraph.AllowDrop = true;
                                    DrawBarGraphs(CrestFactor, arlstSelectedTime);

                                }
                                else
                                {
                                    //MessageBoxEx.Show("Please ensure atleast 2 data sets for cepstrum trend");
                                    //panel1.Controls.Remove(_BarGraph);
                                    _BarGraph = null;
                                    _LineGraph.Dock = DockStyle.Fill;
                                }
                            }
                        }
                        else
                        {
                            // bbConvertToFFT.Enabled = false;
                            bbCepstrum.Enabled = false;
                            if (wavnode == "WAVFile" && jclick < 2)
                            {
                                DrawWavInitial(wavnode, true);
                            }
                        }

                        objGcontrol.panel1.Refresh();
                    }
                }
                SplashScreenManager.CloseForm();

            }
            catch
            { SplashScreenManager.CloseForm(); }
        }

        private void CalculatingPhase(double[] x_data, int counter)
        {
            try
            {
                ArrayList FinalTachoPositions = new ArrayList();
                ArrayList arlSelectedDataGridNumber = new ArrayList();
                double PhaseSum = 0;
                double PhaseAVG = 0;
                double PhaseCount = 0;
                int[] tachopositionforselected = (int[])FinalTachoPositions[(int)arlSelectedDataGridNumber[counter]];
                for (int i = 0; i < lowerPeak.Count - 1; i++)
                {
                    int start_index = (int)lowerPeak[i];
                    int end_index = (int)lowerPeak[i + 1];
                    double timeofwave = x_data[end_index] - x_data[start_index];
                    int tachopeekfortheselectedwave = 0;
                    for (int j = 0; j < tachopositionforselected.Length; j++)
                    {
                        if ((int)tachopositionforselected[j] >= start_index && (int)tachopositionforselected[j] <= end_index)
                        {
                            tachopeekfortheselectedwave = (int)tachopositionforselected[j];
                            break;
                        }
                    }
                    if (tachopeekfortheselectedwave != 0)
                    {
                        double timeofTachopeek = x_data[tachopeekfortheselectedwave] - x_data[start_index];
                        double phaseangle = (double)(360 * timeofTachopeek) / timeofwave;
                        while (phaseangle > 360)
                        {
                            phaseangle = phaseangle - 360;
                        }
                        PhaseCount++;
                        PhaseSum += phaseangle;
                    }
                }
                PhaseAVG = PhaseSum / PhaseCount;
                PhaseAVG = Math.Round(PhaseAVG);
                PhasetoDisplay.Add(PhaseAVG);
            }
            catch { }
        }

        ArrayList lowerPeak = new ArrayList();
        ArrayList UpperPeak = new ArrayList();
        private void FindAllWaves(double[] tachoY)
        {
            bool increasing = false;
            bool decreasing = false;
            try
            {
                for (int i = 0; i < tachoY.Length - 3; i++)
                {
                    if (tachoY[i] < 0)
                    {
                        if (tachoY[i + 1] < 0)
                        {
                            if (increasing == true)
                            {
                                UpperPeak.Add(i);
                            }
                            decreasing = true;
                            increasing = false;
                        }
                    }
                    else if (tachoY[i] >= 0)
                    {
                        if (tachoY[i + 1] >= 0)
                        {
                            if (decreasing == true)
                            {
                                lowerPeak.Add(i);
                            }
                            increasing = true;
                            decreasing = false;
                        }
                    }
                }
            }
            catch { }
        }

        private ArrayList GetAllPlotValuesNewGraph(ArrayList arlNewTime)
        {
            ArrayList arrXYValues = new ArrayList();
            ArrayList arrSelTime = new ArrayList();
            try
            {
                for (int i = 0; i < arlNewTime.Count; i++)
                {
                    string[] sarrFileName = arlNewTime[i].ToString().Split(new string[] { "<>" }, StringSplitOptions.RemoveEmptyEntries);
                    if (sarrFileName.Length > 1)
                    {
                        if (wavnode == "WAVFile")
                        {
                            string filepath = (AppDomain.CurrentDomain.BaseDirectory + sarrFileName[1].ToString() + ".TXT");
                            ReadTXTfileNew(filepath, true);
                            arrSelTime.Add(arlNewTime[i].ToString());
                        }
                        arrXYValues.Add(xarrayNew);
                        arrXYValues.Add(yarrayNew);
                    }
                    else
                    {
                        if (wavnode == "WAVFile" || wavnode == "DATFile")
                        {

                            string filepath = ("c:\\vvtemp\\" + sarrFileName[0] + ".txt");
                            ReadTXTfileNew(filepath, true);
                            arrSelTime.Add(arlNewTime[i].ToString());
                            arrXYValues.Add(xarrayNew);
                            arrXYValues.Add(yarrayNew);
                        }
                    }
                }
            }
            catch { }
            return arrXYValues;
        }

        int jclick = 1; ArrayList arlSelectedColorTag = null; ArrayList arrSelTime = null;
        private void NavigateGraphs(int colorvalue, string DatagridCaption)
        {
            try
            {
                DataSelected = _LineGraph.SelectNextPlot(colorvalue);
                try
                {
                    string splitedgrid = DatagridCaption.ToString();

                    int RowValue = Convert.ToInt32(splitedgrid.ToString());
                    DataGridViewSelectedRowCollection dvsrc = objGcontrol.dataGridView2.SelectedRows;
                    for (int i = 0; i < dvsrc.Count; i++)
                    {
                        dvsrc[i].Selected = false;
                    }
                    objGcontrol.dataGridView2.Rows[RowValue].Selected = true;
                    sDatagridCaption = objGcontrol.dataGridView2.Rows[RowValue].Cells[0].Value.ToString();

                }
                catch (Exception exx)
                {
                    DataGridViewSelectedRowCollection dvsrc = objGcontrol.dataGridView2.SelectedRows;
                    for (int i = 0; i < dvsrc.Count; i++)
                    {
                        dvsrc[i].Selected = false;
                    }
                    objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.RowCount - 2].Selected = true;
                    sDatagridCaption = objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.RowCount - 2].Cells[0].Value.ToString();
                }
                _LineGraph._FooterColor = Color.FromArgb(-Convert.ToInt32(colorvalue));
                _LineGraph._ChartFooter = "Selected Graph Caption: " + sDatagridCaption;
                BackGroundChanges();
            }
            catch (Exception ex)
            {

            }
        }

        private void barbtnRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                try
                {
                    lblStatus.Caption = "Status: Restoring Existing Database Form";
                    DataTable dt = new DataTable();
                    dt = DbClass.getdata(CommandType.Text, "select UserName , Password from userdetail where ID = '1' ");
                    string Name = dt.Rows[0]["UserName"].ToString();
                    string Passwd = dt.Rows[0]["Password"].ToString();
                    if (PublicClass.cUserName != Name.Trim() && PublicClass.cPassword != Passwd.Trim())
                    {
                        MessageBox.Show(this, "You are not allowed to change database", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    frmRestore restore = new frmRestore();
                    restore.ShowDialog();
                    if (!restore.stscancel)
                    {
                        ribbonPageCategory1.Text = "Selected DataBase: " + Iadeptmain.GlobalClasses.PublicClass.User_DataBase;
                        try
                        {
                            if (Iadeptmain.GlobalClasses.PublicClass.LoginStatus == false)
                            {
                                this.Dispose();
                            }
                            else
                            {
                                SetUserTabpages();
                                ssStatus.Text = "User Name= " + Iadeptmain.GlobalClasses.PublicClass.User_Name.Trim() + " and IPAddress= " + Iadeptmain.GlobalClasses.PublicClass.User_IP.Trim() + "  ";
                            }

                            fillform();
                            lblStatus.Caption = "Status: Database Selecting Successfully";
                        }
                        catch { }
                    }

                }
                catch { }
            }
            catch
            {
            }
        }

        private void bbtncompanyinfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblStatus.Caption = "Status: Filling Company Data";
                ReportSetting rptcomp_info = new ReportSetting();
                rptcomp_info.ShowDialog();
            }
            catch { }
        }

        private void bbKillCursor_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                _LineGraph.KillPoint(true);
            }
            catch { }

        }

        private void bbDBConversion_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmDBConverter objdbconverter = new frmDBConverter();
                objdbconverter.ShowDialog();
                if (!objdbconverter.tscancel)
                {
                    Iadeptmain.GlobalClasses.PublicClass.User_IP = Iadeptmain.GlobalClasses.PublicClass.GetIP();
                    ribbonPageCategory1.Text = "Selected DataBase: " + Iadeptmain.GlobalClasses.PublicClass.User_DataBase;
                    try
                    {
                        if (Iadeptmain.GlobalClasses.PublicClass.LoginStatus == false)
                        {
                            this.Dispose();
                        }
                        else
                        {
                            SetUserTabpages();
                            ssStatus.Text = "User Name= " + Iadeptmain.GlobalClasses.PublicClass.User_Name.Trim() + " and IPAddress= " + Iadeptmain.GlobalClasses.PublicClass.User_IP.Trim() + "  ";

                        }
                    }
                    catch { }
                    fillform();
                }
            }
            catch { }
        }

        public bool checkStatus(ArrayList xyData2, string[] allvalue)
        {
            bool chk = false;
            try
            {
                dXVals = (double[])xyData2[0];
                dYVals = (double[])xyData2[1];
                double Fst = 0;
                double Scnd = 0;
                double Thrd = 0;
                try
                {
                    for (int i = 2; i < dYVals.Length; i++)
                    {
                        Fst = dYVals[i - 2];
                        Scnd = dYVals[i - 1];
                        Thrd = dYVals[i];

                        if (Fst < Scnd && Scnd > Thrd)
                        {
                            Array.Resize(ref Peeks, Peeks.Length + 1);
                            Peeks[Peeks.Length - 1] = i - 1;
                            Array.Resize(ref Peeks1, Peeks1.Length + 1);
                            Peeks1[Peeks1.Length - 1] = dYVals[i - 1];
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                xx = new double[Peeks.Length];
                yy = new int[Peeks1.Length];
                ff = new int[Peeks.Length];
                int pos = 0;
                for (int ictrx = 0; ictrx < Peeks.Length; ictrx++)
                {
                    for (int jctrx = ictrx; jctrx < Peeks1.Length; jctrx++)
                    {
                        if (xx[ictrx] < Peeks1[jctrx])
                        {
                            xx[ictrx] = Peeks1[jctrx];
                            yy[ictrx] = Peeks[jctrx];
                            pos = jctrx;
                        }
                    }
                    Peeks1[pos] = 0;
                    Peeks[pos] = 0;
                }

                string[] xyUnit = m_PointGeneral1.ExtractUnits();
                string[] Unit1 = xyUnit[1].Split('(');
                string Unit11 = Unit1[0];
                string[] Unit12 = Unit1[1].Split(')');
                string mUnit = null;

                DataTable dt = DbClass.getdata(CommandType.Text, "Select pd.Point_ID , pd.Point_Type , u.power_unit_type  from Point_data pd inner join Units u on pd.Point_Type = u.Type_ID where Point_ID='" + PublicClass.SPointID + "'");

                foreach (DataRow dr in dt.Rows)
                {
                    string PointID = Convert.ToString(dr["Point_ID"]);
                    mUnit = Convert.ToString(dr["power_unit_type"]);
                }
                double xxValue = 0.0;
                double val = Convert.ToDouble(xx[0]);
                double freq = (Convert.ToDouble(allvalue[0]) / 60);
                double cpm = Convert.ToDouble(allvalue[0]);

                switch (mUnit)
                {
                    //---------------Acceleration--------------------------------

                    case "0":
                        {
                            switch (Unit12[0])
                            {
                                case "RMS":
                                    {

                                        switch (Unit11)
                                        {
                                            case "m/s2":
                                                {
                                                    val = val * 9.807;  //Convert m/s^2 into Gs 
                                                    val = val * 1.414;  //Convert RMS into Peak
                                                    xxValue = ((val * 93580) / cpm);  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                            case "Gs":
                                                {
                                                    val = Convert.ToDouble(val * 1.414);  //Convert RMS into Peak
                                                    xxValue = (val * 93580) / (cpm);  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                        }

                                        break;
                                    }
                                case "P-P":
                                    {
                                        switch (Unit11)
                                        {
                                            case "m/s2":
                                                {
                                                    val = Convert.ToDouble(val * 9.807);  //Convert m/s^2 into Gs 
                                                    val = Convert.ToDouble(val * 0.5);  //Convert P-P into Peak
                                                    xxValue = (val * 93580) / (cpm);  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                            case "Gs":
                                                {
                                                    val = Convert.ToDouble(val * 0.5);  //Convert P-P into Peak
                                                    xxValue = (val * 93580) / (cpm);   //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case "Peak":
                                    {
                                        switch (Unit11)
                                        {
                                            case "m/s2":
                                                {
                                                    val = Convert.ToDouble(val * 9.807);  //Convert m/s^2 into Gs 
                                                    xxValue = (val * 93580) / (cpm);  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                            case "Gs":
                                                {
                                                    xxValue = (val * 93580) / (cpm);  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                            }
                            break;
                        }

                    //---------------Velocity--------------------------------

                    case "1":
                        {

                            switch (Unit12[0])
                            {
                                case "RMS":
                                    {
                                        switch (Unit11)
                                        {
                                            case "mm/s":
                                                {
                                                    xxValue = Convert.ToDouble(val);  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                            case "cm/s":
                                                {
                                                    xx[0] = Convert.ToDouble(val * 10);  // Convert cm/s into mm/s
                                                    xxValue = Convert.ToDouble(val);  //Calculate velocity into mm/s(RMS)

                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case "Peak":
                                    {
                                        switch (Unit11)
                                        {
                                            case "mm/s":
                                                {
                                                    val = Convert.ToDouble(val * 0.707);  //Convert Peak into RMS
                                                    xxValue = Convert.ToDouble(val);  //Calculate velocity into mm/s(RMS)

                                                    break;
                                                }
                                            case "cm/s":
                                                {
                                                    val = Convert.ToDouble(val * 10);  // Convert cm/s into mm/s
                                                    val = Convert.ToDouble(val * 0.707);  //Convert Peak into RMS
                                                    xxValue = Convert.ToDouble(val);  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case "P-P":
                                    {
                                        switch (Unit11)
                                        {
                                            case "mm/s":
                                                {
                                                    val = Convert.ToDouble(val * 0.354);  //Convert P-P into RMS 
                                                    xxValue = Convert.ToDouble(val);  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                            case "cm/s":
                                                {
                                                    val = Convert.ToDouble(val * 10);  // Convert cm/s into mm/s
                                                    val = Convert.ToDouble(val * 0.354);  //Convert P-P into RMS 
                                                    xxValue = Convert.ToDouble(val);  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                            }
                            break;
                        }

                    //---------------Displacement--------------------------------

                    case "2":
                        {

                            switch (Unit12[0])
                            {
                                case "RMS":
                                    {
                                        switch (Unit11)
                                        {
                                            case "um":
                                                {
                                                    val = Convert.ToDouble(val / 0.000039370079); // Convert into inch
                                                    val = Convert.ToDouble(val * 1.414);// Convert into Peak
                                                    xxValue = (6.28 * freq);  //Calculate velocity into inch/s(PEAK)
                                                    xxValue = xxValue / 1.414; // Convert into RMS
                                                    xxValue = xxValue / 25.4;  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                            case "mil":
                                                {
                                                    val = Convert.ToDouble(val / 0.001); // Convert into inch.
                                                    val = Convert.ToDouble(val * 1.414);// Convert into Peak
                                                    xxValue = (6.28 * freq);  //Calculate velocity into inch/s(PEAK)
                                                    xxValue = xxValue / 1.414; // Convert into RMS
                                                    xxValue = xxValue / 25.4;  //Calculate velocity into mm/s(RMS)
                                                    val = Convert.ToDouble(val * 1.414);
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case "Peak":
                                    {
                                        switch (Unit11)
                                        {
                                            case "um":
                                                {
                                                    val = Convert.ToDouble(val / 0.000039370079); // Convert into inch
                                                    xxValue = (6.28 * freq);  //Calculate velocity into inch/s(PEAK)
                                                    xxValue = xxValue / 1.414; // Convert into RMS
                                                    xxValue = xxValue / 25.4;  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                            case "mil":
                                                {
                                                    val = Convert.ToDouble(val / 0.001); // Convert into inch.
                                                    xxValue = (6.28 * freq);  //Calculate velocity into inch/s(PEAK)
                                                    xxValue = xxValue / 1.414; // Convert into RMS
                                                    xxValue = xxValue / 25.4;  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                        }
                                        break;
                                    }

                                case "P-P":
                                    {
                                        switch (Unit11)
                                        {
                                            case "um":
                                                {
                                                    val = Convert.ToDouble(val / 0.000039370079); // Convert into inch
                                                    val = Convert.ToDouble(val * 0.5);// Convert into Peak
                                                    xxValue = (6.28 * freq);  //Calculate velocity into inch/s(PEAK)
                                                    xxValue = xxValue / 1.414; // Convert into RMS
                                                    xxValue = xxValue / 25.4;  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                            case "mil":
                                                {
                                                    val = Convert.ToDouble(val / 0.001); // Convert into inch.
                                                    val = Convert.ToDouble(val * 0.5);// Convert into Peak
                                                    xxValue = (6.28 * freq);  //Calculate velocity into inch/s(PEAK)
                                                    xxValue = xxValue / 1.414; // Convert into RMS
                                                    xxValue = xxValue / 25.4;  //Calculate velocity into mm/s(RMS)
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                }
                if (xxValue == 2.0 || xxValue > 2.0)
                {
                    chk = true;
                }
                else
                {
                    chk = false;
                }
                string MachineType = Convert.ToString(allvalue[2]);
            }
            catch { }
            return chk;
        }

        public string[] allvalue = null;
        private void bbdiagonostic_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                bool status = false;
                ArrayList _Time = new ArrayList();
                _Time.Add(PublicClass.tym);
                allvalue = new string[4];
                frmDiagnosticRPM objdiaRPM = new frmDiagnosticRPM();

                // DataTable dtRpm = DbClass.getdata(CommandType.Text, "Select ordertrace_rpm , Point_Type from point_data where Data_ID in(select max(Data_ID) as Data_ID from point_data where Point_ID = '" + PublicClass.SPointID + "')");
                DataTable dtRpm = DbClass.getdata(CommandType.Text, "Select RPM_Driven from machine_info where Machine_ID in(select machine_id from point where Point_ID = '" + PublicClass.SPointID + "')");
                if (dtRpm.Rows.Count > 0 && Convert.ToInt32(dtRpm.Rows[0]["RPM_Driven"]) != 0)
                {
                    int Rpm = Convert.ToInt32(dtRpm.Rows[0]["RPM_Driven"]);
                    allvalue[0] = Convert.ToString(Rpm);
                    allvalue[2] = "Default";
                    allvalue[1] = "50";
                    allvalue[3] = "true";
                }
                else
                {
                    objdiaRPM.ShowDialog();
                    allvalue = objdiaRPM.GetRPMallValues(Convert.ToInt32(objdiaRPM.txtStdRPM.Text), Convert.ToInt32(objdiaRPM.txtVariation.Text));
                }
                arrXYVals = objIHand.GetAllPlotValues(PublicClass.SPointID, null, _Time, PublicClass.GraphClicked, EdittextDirection);
                status = checkStatus(arrXYVals, allvalue);
                if (status)
                {
                    ArrayList fData = drawPeak(arrXYVals, allvalue, false);
                    bool[] sts = new bool[1];
                    sts = (bool[])fData[2];
                    if (sts[0])
                    {
                        ribbonControl1.SelectedPage = rpdiagonostic;
                    }
                    else
                    {
                        MessageBox.Show(this, "Please verify your input data OR refer to expert to detect the fault...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Your Machine is in Good Condition..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch { }
        }

        private void btnAutoReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DataTable dtReport = DbClass.getdata(CommandType.Text, "Select ReportName from allreport where ReportStatus = 'Auto'");
                if (dtReport.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "You have not add any Report for Automatic Report", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    lblStatus.Caption = "Status: Open Automatic Reports";
                    this.WindowState = FormWindowState.Minimized;
                    frmReport objmainReport = new frmReport();
                    objmainReport.MainForm = this;
                    objmainReport.autosts = true;
                    objmainReport.usercontrol = _objUserControl;
                    objmainReport.ShowDialog();
                }
            }
            catch
            { }
        }

        private void btnDailyReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DataTable dtReport = DbClass.getdata(CommandType.Text, "Select ReportName from allreport where ReportStatus = 'Daily'");
                if (dtReport.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "You have not add any Report for Daily Report", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    lblStatus.Caption = "Status: Open Daily Reports";
                    this.WindowState = FormWindowState.Minimized;
                    frmReport objmainReport = new frmReport();
                    objmainReport.MainForm = this;
                    objmainReport.dailysts = true;
                    objmainReport.usercontrol = _objUserControl;
                    objmainReport.ShowDialog();
                }
            }
            catch
            {
            }
        }

        private void bbSigma_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                double Sigma = CalculateSigma(yarrayNew);
                MessageBox.Show(Sigma.ToString());
            }
            catch (Exception ex)
            {
            }
        }

        public void ShowCurrentDate()
        {
            bbTrend.Caption = "Trend";
            objGcontrol.dataGridView2.Rows.Clear();
            ImageList objlistimg = new ImageList();
            try
            {
                objlistimg.Images.Add(ImageResources.DarkRed);
                objGcontrol.dataGridView2.Rows[0].Cells[0].Value = PublicClass.tym;
                objGcontrol.dataGridView2.Rows[0].Cells[1].Value = "√";
                objGcontrol.dataGridView2.Rows[0].Cells[3].Value = objlistimg.Images[0];
            }
            catch (Exception ex)
            { }
        }

        public void ShowRedColor(string Type)
        {
            ImageList objlistimg = new ImageList();
            try
            {
                objlistimg.Images.Add(ImageResources.DarkRed);
                objGcontrol.dataGridView2.Rows[0].Cells[0].Value = Type;
                objGcontrol.dataGridView2.Rows[0].Cells[1].Value = "√";
                objGcontrol.dataGridView2.Rows[0].Cells[3].Value = objlistimg.Images[0];
            }
            catch
            {
            }
        }

        public bool modify = true;
        private void bbgauge_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int acc = 0; int hor = 0; int ver = 0; int channel = 0; string unit = ""; string unname = null; int max_val = 0;
                string gaugeunit = null;
                DataTable dt = new DataTable();
                if (modify == true)
                {
                    frmRpmCount rpmcount = new frmRpmCount();
                    rpmcount.Text = "OverAll";
                    PublicClass.flag = true;
                    PublicClass.checkname = "Gauge";
                    rpmcount.ShowDialog();
                    string overall = rpmcount._overall;
                    if (rpmcount._ShouldDraw == false)
                    {
                        return;
                    }
                    else
                    {
                        if (overall == "Acceleration")
                        {
                            try
                            {
                                dt = DbClass.getdata(CommandType.Text, "select un.accel_unit,accel_a,accel_h,accel_v,accel_ch1 from point_data pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where pd.point_id='" + PublicClass.SPointID + "' and pd.measure_time='" + PublicClass.tym + "'");
                                foreach (DataRow dr in dt.Rows)
                                {
                                    acc = Convert.ToInt32(dr["accel_a"]);
                                    hor = Convert.ToInt32(dr["accel_h"]);
                                    ver = Convert.ToInt32(dr["accel_v"]);
                                    channel = Convert.ToInt32(dr["accel_ch1"]);
                                    unit = Convert.ToString(dr["accel_unit"]);
                                    if (unit == "0")
                                    {
                                        unname = "Gs";
                                    }
                                    else if (unit == "1")
                                    {
                                        unname = "gal";
                                    }
                                    else if (unit == "2")
                                    {
                                        unname = "m/s2";
                                    }
                                    max_val = 200;
                                }
                            }
                            catch
                            { }
                        }
                        else if (overall == "Velocity")
                        {
                            try
                            {
                                dt = DbClass.getdata(CommandType.Text, "select un.vel_unit,vel_a,vel_h,vel_v,vel_ch1 from point_data  pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where point_id='" + PublicClass.SPointID + "' and measure_time='" + PublicClass.tym + "'");
                                foreach (DataRow dr in dt.Rows)
                                {
                                    acc = Convert.ToInt32(dr["vel_a"]);
                                    hor = Convert.ToInt32(dr["vel_h"]);
                                    ver = Convert.ToInt32(dr["vel_v"]);
                                    channel = Convert.ToInt32(dr["vel_ch1"]);
                                    unit = Convert.ToString(dr["vel_unit"]);
                                    if (unit == "0")
                                    {
                                        unname = "mm/s";
                                    }
                                    else if (unit == "1")
                                    {
                                        unname = "in/s";
                                    }
                                    else if (unit == "2")
                                    {
                                        unname = "cm/s";
                                    }
                                    max_val = 200;
                                }
                            }
                            catch
                            { }
                        }
                        else if (overall == "Displacement")
                        {
                            try
                            {
                                dt = DbClass.getdata(CommandType.Text, "select un.displ_unit,displ_a,displ_h,displ_v,displ_ch1 from point_data  pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where point_id='" + PublicClass.SPointID + "' and measure_time='" + PublicClass.tym + "'");
                                foreach (DataRow dr in dt.Rows)
                                {
                                    acc = Convert.ToInt32(dr["displ_a"]);
                                    hor = Convert.ToInt32(dr["displ_h"]);
                                    ver = Convert.ToInt32(dr["displ_v"]);
                                    channel = Convert.ToInt32(dr["displ_ch1"]);
                                    unit = Convert.ToString(dr["displ_unit"]);
                                    if (unit == "0")
                                    {
                                        unname = "mil";
                                    }
                                    else if (unit == "1")
                                    {
                                        unname = "um";
                                    }
                                    max_val = 2000;
                                }
                            }
                            catch
                            { }
                        }
                        else if (overall == "CrestFactor")
                        {
                            try
                            {
                                dt = DbClass.getdata(CommandType.Text, "select crest_factor_a,crest_factor_h,crest_factor_v,crest_factor_ch1 from point_data  pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where point_id='" + PublicClass.SPointID + "' and measure_time='" + PublicClass.tym + "'");
                                foreach (DataRow dr in dt.Rows)
                                {
                                    acc = Convert.ToInt32(dr["crest_factor_a"]);
                                    hor = Convert.ToInt32(dr["crest_factor_h"]);
                                    ver = Convert.ToInt32(dr["crest_factor_v"]);
                                    channel = Convert.ToInt32(dr["crest_factor_ch1"]);
                                    max_val = 1000;
                                }
                            }
                            catch
                            { }
                        }
                        else if (overall == "Bearing")
                        {
                            try
                            {
                                dt = DbClass.getdata(CommandType.Text, "select un.accel_unit,bearing_a,bearing_h,bearing_v,bearing_ch1 from point_data  pd inner join type_point tp on tp.id=pd.Point_Type left join units un on un.Type_ID=tp.ID where point_id='" + PublicClass.SPointID + "' and measure_time='" + PublicClass.tym + "'");
                                foreach (DataRow dr in dt.Rows)
                                {
                                    acc = Convert.ToInt32(dr["bearing_a"]);
                                    hor = Convert.ToInt32(dr["bearing_h"]);
                                    ver = Convert.ToInt32(dr["bearing_v"]);
                                    channel = Convert.ToInt32(dr["bearing_ch1"]);
                                    unit = Convert.ToString(dr["accel_unit"]);
                                    if (unit == "0")
                                    {
                                        unname = "Gs";
                                    }
                                    else if (unit == "1")
                                    {
                                        unname = "gal";
                                    }
                                    else if (unit == "2")
                                    {
                                        unname = "m/s2";
                                    }
                                    max_val = 5000;
                                }
                            }
                            catch
                            { }
                        }
                        CreateCircularGauge(PublicClass.GraphClicked, acc, hor, ver, channel, max_val, unname);
                        modify = false;
                    }
                }
                else
                {
                    m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                    modify = true;
                }
            }
            catch { }
        }

        private void CreateCircularGauge(string graph, int acc, int horr, int vert, int chanel, int max, string unitname)
        {
            try
            {
                //gauge1 axial
                GaugeControl gc = new GaugeControl();
                CircularGauge circularGauge = gc.AddCircularGauge();
                circularGauge.AddDefaultElements();
                ArcScaleBackgroundLayer background = circularGauge.BackgroundLayers[0];
                background.ShapeType = BackgroundLayerShapeType.CircularThreeFourth_Style17;
                ArcScaleComponent scale = circularGauge.Scales[0];
                scale.MinValue = 0;
                scale.MaxValue = max;
                scale.Value = acc;
                scale.MajorTickCount = 6;
                scale.MajorTickmark.FormatString = "{0:F0}";
                scale.MajorTickmark.ShapeType = TickmarkShapeType.Circular_Style17_1;
                scale.MajorTickmark.ShapeOffset = -9;
                scale.MajorTickmark.AllowTickOverlap = true;
                scale.MinorTickCount = 3;
                scale.MinorTickmark.ShapeType = TickmarkShapeType.Circular_Style17_2;

                ArcScaleSpindleCap cap = circularGauge.AddSpindleCap();
                cap.ShapeType = SpindleCapShapeType.CircularFull_Style2;
                ArcScaleNeedleComponent needle = circularGauge.Needles[0];
                needle.ShapeType = NeedleShapeType.CircularFull_Style3;
                gc.Size = new Size(475, 265);

                circularGauge.BeginUpdate();
                LabelComponent label = new LabelComponent("myLabel");
                label.AppearanceText.TextBrush = new SolidBrushObject(Color.Black);
                label.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(250, 210);
                label.ZOrder = -10000;
                label.AllowHTMLString = true;
                label.Text = "<color=BLUE><b>Axial</b></color>";
                circularGauge.Labels.Add(label);
                circularGauge.EndUpdate();

                circularGauge.BeginUpdate();
                LabelComponent label5 = new LabelComponent("myLabel1");
                label5.AppearanceText.TextBrush = new SolidBrushObject(Color.Black);
                label5.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125, 240);
                label5.ZOrder = -10000;
                label5.AllowHTMLString = true;
                label5.Text = "<color=BLUE><b>" + unitname + "</b></color>";
                circularGauge.Labels.Add(label5);
                circularGauge.EndUpdate();


                objGcontrol.panel1.Controls.Clear();
                objGcontrol.panel1.Controls.Add(gc);


                // gauge2 horizontal
                GaugeControl gc1 = new GaugeControl();
                CircularGauge circularGauge1 = gc1.AddCircularGauge();
                circularGauge1.AddDefaultElements();
                ArcScaleBackgroundLayer background1 = circularGauge1.BackgroundLayers[0];
                background1.ShapeType = BackgroundLayerShapeType.CircularThreeFourth_Style17;
                ArcScaleComponent scale1 = circularGauge1.Scales[0];
                scale1.MinValue = 0;
                scale1.MaxValue = max;
                scale1.Value = horr;
                scale1.MajorTickCount = 6;
                scale1.MajorTickmark.FormatString = "{0:F0}";
                scale1.MajorTickmark.ShapeType = TickmarkShapeType.Circular_Style17_1;
                scale1.MajorTickmark.ShapeOffset = -9;
                scale1.MajorTickmark.AllowTickOverlap = true;
                scale1.MinorTickCount = 3;
                scale1.MinorTickmark.ShapeType = TickmarkShapeType.Circular_Style17_2;
                ArcScaleSpindleCap cap1 = circularGauge1.AddSpindleCap();
                cap1.ShapeType = SpindleCapShapeType.CircularFull_Style2;
                ArcScaleNeedleComponent needle1 = circularGauge1.Needles[0];
                needle1.ShapeType = NeedleShapeType.CircularFull_Style3;
                gc1.Location = new System.Drawing.Point(0, 265);

                circularGauge1.BeginUpdate();
                LabelComponent label1 = new LabelComponent("myLabel");
                label1.AppearanceText.TextBrush = new SolidBrushObject(Color.Black);
                label1.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125, 240);
                label1.ZOrder = -10000;
                label1.AllowHTMLString = true;
                label1.Text = "<color=BLUE><b>" + unitname + "</b></color>";
                circularGauge1.Labels.Add(label1);
                circularGauge1.EndUpdate();

                circularGauge1.BeginUpdate();
                LabelComponent label6 = new LabelComponent("myLabel1");
                label6.AppearanceText.TextBrush = new SolidBrushObject(Color.Black);
                label6.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(250, 210);
                label6.ZOrder = -10000;
                label6.AllowHTMLString = true;
                label6.Text = "<color=BLUE><b>             Horizontal</b></color>";
                circularGauge1.Labels.Add(label6);
                circularGauge1.EndUpdate();


                gc1.Size = new Size(475, 265);
                objGcontrol.panel1.Controls.Add(gc1);

                // gauge3 vertical
                GaugeControl gc2 = new GaugeControl();
                CircularGauge circularGauge2 = gc2.AddCircularGauge();
                circularGauge2.AddDefaultElements();
                ArcScaleBackgroundLayer background2 = circularGauge2.BackgroundLayers[0];
                background2.ShapeType = BackgroundLayerShapeType.CircularThreeFourth_Style17;
                ArcScaleComponent scale2 = circularGauge2.Scales[0];
                scale2.MinValue = 0;
                scale2.MaxValue = max;
                scale2.Value = vert;
                scale2.MajorTickCount = 6;
                scale2.MajorTickmark.FormatString = "{0:F0}";
                scale2.MajorTickmark.ShapeType = TickmarkShapeType.Circular_Style17_1;
                scale2.MajorTickmark.ShapeOffset = -9;
                scale2.MajorTickmark.AllowTickOverlap = true;
                scale2.MinorTickCount = 3;
                scale2.MinorTickmark.ShapeType = TickmarkShapeType.Circular_Style17_2;
                ArcScaleSpindleCap cap2 = circularGauge2.AddSpindleCap();
                cap2.ShapeType = SpindleCapShapeType.CircularFull_Style2;
                ArcScaleNeedleComponent needle2 = circularGauge2.Needles[0];
                needle2.ShapeType = NeedleShapeType.CircularFull_Style3;
                gc2.Location = new System.Drawing.Point(475, 0);

                circularGauge2.BeginUpdate();
                LabelComponent label2 = new LabelComponent("myLabel");
                label2.AppearanceText.TextBrush = new SolidBrushObject(Color.Black);
                label2.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125, 240);
                label2.ZOrder = -10000;
                label2.AllowHTMLString = true;
                label2.Text = "<color=BLUE><b>" + unitname + "</b></color>";
                circularGauge2.Labels.Add(label2);
                circularGauge2.EndUpdate();

                circularGauge2.BeginUpdate();
                LabelComponent label7 = new LabelComponent("myLabel1");
                label7.AppearanceText.TextBrush = new SolidBrushObject(Color.Black);
                label7.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(250, 210);
                label7.ZOrder = -10000;
                label7.AllowHTMLString = true;
                label7.Text = "<color=BLUE><b>       Vertical</b></color>";
                circularGauge2.Labels.Add(label7);
                circularGauge2.EndUpdate();

                gc2.Size = new Size(475, 265);
                objGcontrol.panel1.Controls.Add(gc2);

                // gauge3 channel1
                GaugeControl gc3 = new GaugeControl();
                CircularGauge circularGauge3 = gc3.AddCircularGauge();
                circularGauge3.AddDefaultElements();
                ArcScaleBackgroundLayer background3 = circularGauge3.BackgroundLayers[0];
                background3.ShapeType = BackgroundLayerShapeType.CircularThreeFourth_Style17;
                ArcScaleComponent scale3 = circularGauge3.Scales[0];
                scale3.MinValue = 0;
                scale3.MaxValue = max;
                scale3.Value = chanel;
                scale3.MajorTickCount = 6;
                scale3.MajorTickmark.FormatString = "{0:F0}";
                scale3.MajorTickmark.ShapeType = TickmarkShapeType.Circular_Style17_1;
                scale3.MajorTickmark.ShapeOffset = -9;
                scale3.MajorTickmark.AllowTickOverlap = true;
                scale3.MinorTickCount = 3;
                scale3.MinorTickmark.ShapeType = TickmarkShapeType.Circular_Style17_2;
                ArcScaleSpindleCap cap3 = circularGauge3.AddSpindleCap();
                cap3.ShapeType = SpindleCapShapeType.CircularFull_Style2;

                ArcScaleNeedleComponent needle3 = circularGauge3.Needles[0];
                needle3.ShapeType = NeedleShapeType.CircularFull_Style3;
                gc3.Location = new System.Drawing.Point(475, 265);

                circularGauge3.BeginUpdate();
                LabelComponent label3 = new LabelComponent("myLabel");
                label3.AppearanceText.TextBrush = new SolidBrushObject(Color.Black);
                label3.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125, 240);
                label3.ZOrder = -10000;
                label3.AllowHTMLString = true;
                label3.Text = "<color=BLUE><b>" + unitname + "</b></color>";
                circularGauge3.Labels.Add(label3);
                circularGauge3.EndUpdate();

                circularGauge3.BeginUpdate();
                LabelComponent label8 = new LabelComponent("myLabel1");
                label8.AppearanceText.TextBrush = new SolidBrushObject(Color.Black);
                label8.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(250, 210);
                label8.ZOrder = -10000;
                label8.AllowHTMLString = true;
                label8.Text = "<color=BLUE><b>            Channel1</b></color>";
                circularGauge3.Labels.Add(label8);
                circularGauge3.EndUpdate();
                gc3.Size = new Size(475, 265);
                objGcontrol.panel1.Controls.Add(gc3);
            }
            catch { }
        }

        private string getdatetimeoffile(string SelectedWavPath)
        {
            string timeoffile = null;
            try
            {
                timeoffile = File.GetLastWriteTime(SelectedWavPath).ToString();
            }
            catch (Exception ex)
            {
            }
            return timeoffile;
        }

        bool bShowOrbit = false;
        ArrayList arrWAVReportXYVals = null; string dateofwav = null;
        private void bbUffwav_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (modify == true)
                {
                    frmRpmCount rpmcount = new frmRpmCount();
                    rpmcount.Text = "UFF & WAV";
                    PublicClass.flag = true;
                    PublicClass.checkname = "UFF OR WAV";
                    rpmcount.ShowDialog();
                    if (rpmcount.spath != null)
                    {
                        if (rpmcount.spath != "")
                        {
                            SplashScreenManager.ShowForm(typeof(WaitForm2));
                            //----------//                           

                            bbTrend.Enabled = false;
                            bbBand.Enabled = false;
                            bbFaultFreq.Enabled = false;
                            bbRPM.Enabled = false;
                            bbBFF.Enabled = false;
                            bbOctave.Enabled = false;
                            bbOrbit.Enabled = false;
                            bbSBRatio.Enabled = false;
                            bbSBTrend.Enabled = false;
                            bbSBValue.Enabled = false;
                            bcmDirection.Enabled = false;
                            bbCepstrum.Enabled = false;
                            bbChangeXUnit.Enabled = false;
                            bbChangeYUnit.Enabled = false;
                            IsOverallTrend = false;
                            bbCepstrum.Enabled = false;
                            bbCrestFactorTrend.Enabled = false;
                            bbOriginal.Enabled = false;
                            bbDualGraph.Enabled = false;
                            bbMultiGraph.Enabled = false;
                            bbdiagonostic.Enabled = false;
                            bbgauge.Enabled = false;
                            bbWaterfall.Enabled = false;
                            bbAllpowergraph.Enabled = false;
                            bbTWFtoFFT.Enabled = false;
                            //--------//

                            wavnode = rpmcount.wavuff;
                            RemovePreviousGraphControl();
                            objGcontrol.dataGridView2.Rows.Clear();
                            arrWAVReportXYVals = new ArrayList();
                            if (wavnode == "WAVFile")
                            {
                                dateofwav = getdatetimeoffile(rpmcount.spath);
                                CreateFinalWave(rpmcount.spath);
                                setCursorCombo("Time");
                                DrawWavInitial(wavnode, true);
                            }
                            else if (wavnode == "UFFFile")
                            {
                                ExtractData.getUFF58Data(rpmcount.spath);
                                setCursorCombo("Time");
                                ArrayList arlXData = ExtractData.Arraylist_X;
                                ArrayList arlYData = ExtractData.Arraylist_Y;
                                DrawlineGraphs(ExtractData.Arraylist_X, ExtractData.Arraylist_Y, ExtractData.arrXUnits, ExtractData.arrYUnits);
                            }
                            else if (wavnode == "BA2File")
                            {
                                //  ReadBA2File(rpmcount.spath);
                            }
                            else
                            {
                                C911_class _C911 = new C911_class();
                                _C911._objgcontrol = objGcontrol;
                                _C911._Form1 = this;
                                // _C911._dataGridView2 = this._Datagridview2;
                                _C911.ReadFFTFile(rpmcount.spath);
                                setCursorCombo("Time");
                            }
                            modify = false;
                            SplashScreenManager.CloseForm();
                        }
                    }
                }
                else
                {
                    m_PointGeneral1.allGraph(PublicClass.GraphClicked, PublicClass.AHVCH1);
                    wavnode = null;
                    modify = true;
                }
            }
            catch
            { }
        }




        string specdata = null;
        public double[] Specch1_x = null; public double[] Specch1_y = null;
        public double[] Specch2_x = null; public double[] Specch2_y = null;
        public double[] Specch3_x = null; public double[] Specch3_y = null;
        public double[] Specch4_x = null; public double[] Specch4_y = null;
        public double[] timech1_x = null; public double[] timech1_y = null;
        public double[] timech2_x = null; public double[] timech2_y = null;
        public double[] timech3_x = null; public double[] timech3_y = null;
        public double[] timech4_x = null; public double[] timech4_y = null;
        public void DrawlineGraphs(ArrayList arlstXdata, ArrayList arlstYdata, string[] Xunit, string[] Yunit)
        {
            ClsCommon clscommon = new ClsCommon();
            int total = arlstYdata.Count;
            objGcontrol.dataGridView2.Rows.Clear();
            ImageList objlistimg = new ImageList();
            objlistimg.Images.Add(ImageResources.DarkRed);
            objlistimg.Images.Add(ImageResources.DarkGreen);
            objlistimg.Images.Add(ImageResources.DarkGoldenRod);
            objlistimg.Images.Add(ImageResources.DarkseaGreen31);
            objlistimg.Images.Add(ImageResources.DarkBlue);
            objlistimg.Images.Add(ImageResources.DimGrey);
            objlistimg.Images.Add(ImageResources.Chocolate);
            objlistimg.Images.Add(ImageResources.DarkKhaki);
            objlistimg.Images.Add(ImageResources.Black);
            objlistimg.Images.Add(ImageResources.Orange);
            objlistimg.Images.Add(ImageResources.Cyan);
            objlistimg.Images.Add(ImageResources.AquaMarine);
            objlistimg.Images.Add(ImageResources.Bisque);
            objlistimg.Images.Add(ImageResources.Blue);
            objlistimg.Images.Add(ImageResources.BlueViolet);
            objlistimg.Images.Add(ImageResources.Coral);
            objlistimg.Images.Add(ImageResources.Darkmagenta);
            objlistimg.Images.Add(ImageResources.DarkSlateBlue31);
            objlistimg.Images.Add(ImageResources.DarkVoilet31);
            objlistimg.Images.Add(ImageResources.Deeppink31);
            objlistimg.Images.Add(ImageResources.DodgerBlue);
            objlistimg.Images.Add(ImageResources.FireBrick);
            objlistimg.Images.Add(ImageResources.ForestGreen);
            objlistimg.Images.Add(ImageResources.GreenYellow);
            objlistimg.Images.Add(ImageResources.HotPink);
            objlistimg.Images.Add(ImageResources.IndianRed);
            objlistimg.Images.Add(ImageResources.Darkorange);
            objlistimg.Images.Add(ImageResources.Darkorchid);
            objlistimg.Images.Add(ImageResources.DeepSkyBlue31);
            objlistimg.Images.Add(ImageResources.SandyBrown);
            try
            {
                for (int icount = 0; icount < arlstXdata.Count; icount++)
                {
                    double[] XDATA = (double[])arlstXdata[icount];
                    double[] YDATA = (double[])arlstYdata[icount];
                    XUnit = (string)Xunit[icount];
                    YUnit = (string)Yunit[icount];
                    try
                    {
                        objGcontrol.dataGridView2.Rows.Add();
                        objGcontrol.dataGridView2.Rows[icount].Cells[0].Value = ExtractData.arldata[icount].ToString();
                        specdata = objGcontrol.dataGridView2.Rows[icount].Cells[0].Value.ToString();
                        string[] insName = specdata.Split(new string[] { "(" }, StringSplitOptions.RemoveEmptyEntries);
                        if (insName[0] == "Spectrum" && insName[1].Trim() == "CH1)")
                        {
                            Specch1_x = (double[])arlstXdata[icount];
                            Specch1_y = (double[])arlstYdata[icount];
                        }
                        if (insName[0] == "Spectrum" && insName[1].Trim() == "CH2)")
                        {
                            Specch2_x = (double[])arlstXdata[icount];
                            Specch2_y = (double[])arlstYdata[icount];
                        }
                        if (insName[0] == "Spectrum" && insName[1].Trim() == "CH3)")
                        {
                            Specch3_x = (double[])arlstXdata[icount];
                            Specch3_y = (double[])arlstYdata[icount];
                        }
                        if (insName[0] == "Spectrum" && insName[1].Trim() == "CH4)")
                        {
                            Specch4_x = (double[])arlstXdata[icount];
                            Specch4_y = (double[])arlstYdata[icount];
                        }
                        if (insName[0] == "Time" && insName[1].Trim() == "CH1)")
                        {
                            timech1_x = (double[])arlstXdata[icount];
                            timech1_y = (double[])arlstYdata[icount];
                        }
                        if (insName[0] == "Time" && insName[1].Trim() == "CH2)")
                        {
                            timech2_x = (double[])arlstXdata[icount];
                            timech2_y = (double[])arlstYdata[icount];
                        }
                        if (insName[0] == "Time" && insName[1].Trim() == "CH3)")
                        {
                            timech3_x = (double[])arlstXdata[icount];
                            timech3_y = (double[])arlstYdata[icount];
                        }
                        if (insName[0] == "Time" && insName[1].Trim() == "CH4)")
                        {
                            timech4_x = (double[])arlstXdata[icount];
                            timech4_y = (double[])arlstYdata[icount];
                        }
                        objGcontrol.dataGridView2.Rows[icount].Cells[1].Value = "√";
                        objGcontrol.dataGridView2.Rows[icount].Cells[3].Value = objlistimg.Images[icount];
                        objGcontrol.dataGridView2.Rows[icount].Cells[3].Tag = ColorCode[icount].ToString();
                    }
                    catch { }
                    clscommon._MainForm = this; clscommon._Maincontrol = objGcontrol;
                    PublicClass.Chart_Footer = ExtractData.arldata[icount].ToString();
                    if (icount == 0)
                    { _LineGraph = new LineGraphControl(); clscommon.DrawlineGraphsuff(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 1)
                    { _LineGraph1 = new LineGraphControl(); clscommon.DrawlineGraphsuff1(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 2)
                    { _LineGraph2 = new LineGraphControl(); clscommon.DrawlineGraphsuff2(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 3)
                    { _LineGraph3 = new LineGraphControl(); clscommon.DrawlineGraphsuff3(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 4)
                    { _LineGraph4 = new LineGraphControl(); clscommon.DrawlineGraphsuff4(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 5)
                    { _LineGraph5 = new LineGraphControl(); clscommon.DrawlineGraphsuff5(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 6)
                    { _LineGraph6 = new LineGraphControl(); clscommon.DrawlineGraphsuff6(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 7)
                    { _LineGraph_Dual = new LineGraphControl(); clscommon.DrawlineGraphsuff7(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 8)
                    { _LineGraph_cut1 = new LineGraphControl(); clscommon.DrawlineGraphsuff8(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 9)
                    { _LineGraph_cut2 = new LineGraphControl(); clscommon.DrawlineGraphsuff9(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 10)
                    { _LineGraph_cut3 = new LineGraphControl(); clscommon.DrawlineGraphsuff10(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 11)
                    { _LineGraph_cut4 = new LineGraphControl(); clscommon.DrawlineGraphsuff11(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 12)
                    { _LineGraph_cut5 = new LineGraphControl(); clscommon.DrawlineGraphsuff12(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 13)
                    { _LineGraph_cut6 = new LineGraphControl(); clscommon.DrawlineGraphsuff13(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 14)
                    { _LineGraph_cut7 = new LineGraphControl(); clscommon.DrawlineGraphsuff14(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 15)
                    { _LineGraph_cut8 = new LineGraphControl(); clscommon.DrawlineGraphsuff15(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 16)
                    { _LineGraph_cut9 = new LineGraphControl(); clscommon.DrawlineGraphsuff16(XDATA, YDATA, total, ColorCode[icount]); }
                    if (icount == 17)
                    { _LineGraph_cut10 = new LineGraphControl(); clscommon.DrawlineGraphsuff17(XDATA, YDATA, total, ColorCode[icount]); }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void DrawlineGraphs(double[] dxData, double[] dyData, int ictr, string ChartTitle)
        {
            try
            {
                _LineGraph = new LineGraphControl();
                _LineGraph.Name = "LineGraph 1";
                _LineGraph._MainForm = _MainForm;
                _LineGraph._XLabel = XUnit;
                _LineGraph._YLabel = YUnit;
                _LineGraph._GraphBG1 = _GraphBG1;
                _LineGraph._GraphBG2 = _GraphBG2;
                _LineGraph._GraphBGDir = _GraphBGDir;
                _LineGraph._ChartBG1 = _ChartBG1;
                _LineGraph._ChartBG2 = _ChartBG2;
                _LineGraph._ChartBGDir = _ChartBGDir;
                _LineGraph._AxisColor = _AxisColor;
                _LineGraph._MainCursorColor = _MainCursorColor;
                _LineGraph.Height = objGcontrol.panel1.Height / (ictr);
                _LineGraph.Dock = System.Windows.Forms.DockStyle.Top;
                _LineGraph._AreaFill = false;
                _LineGraph.DrawLineGraph(dxData, dyData, ChartTitle);
                objGcontrol.panel1.Controls.Add(_LineGraph);
            }
            catch (Exception ex)
            {
            }
        }


        ArrayList arlTachoData = null; int AvgBytesPerSec = 0;
        int SF = 0;
        int iLastFrequency = 0;
        int iLOR = 0;
        int LineOfResolution = 0; int iFinalFrequency = 0;
        double ExectTime = 0;
        int ExectDataByteSample = 0;
        int TotalDataBytes = 0;
        double TimeVal = 0;
        int TotalTime = 0; int channel = 1;
        int RUCDvariable = 5; int SamplePerSec = 0; double[] xarray = new double[0];
        double[] yarray = new double[0]; double divider_CH1 = 1;
        double divider_CH2 = 1;
        double sensitivity_CH1 = 0;
        double sensitivity_CH2 = 0;
        string label_Ch1 = null;
        string label_Ch2 = null;
        string Name_Ch1 = null;
        string Name_Ch2 = null; ArrayList arlYData = null;
        double[] Fulldata_CH1 = null;
        double[] Fulldata_CH2 = null;
        double[] FullTime_CH1 = null;
        double[] FullTime_CH2 = null;

        private void CreateFinalWave(string spath)
        {
            ImageList objlistimg = new ImageList();
            objlistimg.Images.Add(ImageResources.DarkRed);
            objlistimg.Images.Add(ImageResources.DarkGreen);
            objlistimg.Images.Add(ImageResources.DarkGoldenRod);
            objlistimg.Images.Add(ImageResources.DarkseaGreen31);
            objlistimg.Images.Add(ImageResources.DarkBlue);
            objlistimg.Images.Add(ImageResources.DimGrey);
            objlistimg.Images.Add(ImageResources.Chocolate);
            objlistimg.Images.Add(ImageResources.DarkKhaki);
            objlistimg.Images.Add(ImageResources.Black);
            objlistimg.Images.Add(ImageResources.Orange);
            objlistimg.Images.Add(ImageResources.Cyan);
            objlistimg.Images.Add(ImageResources.AquaMarine);
            objlistimg.Images.Add(ImageResources.Bisque);
            objlistimg.Images.Add(ImageResources.Blue);
            objlistimg.Images.Add(ImageResources.BlueViolet);
            objlistimg.Images.Add(ImageResources.Coral);
            objlistimg.Images.Add(ImageResources.Darkmagenta);
            objlistimg.Images.Add(ImageResources.DarkSlateBlue31);
            objlistimg.Images.Add(ImageResources.DarkVoilet31);
            objlistimg.Images.Add(ImageResources.Deeppink31);
            objlistimg.Images.Add(ImageResources.DodgerBlue);
            objlistimg.Images.Add(ImageResources.FireBrick);
            objlistimg.Images.Add(ImageResources.ForestGreen);
            objlistimg.Images.Add(ImageResources.GreenYellow);
            objlistimg.Images.Add(ImageResources.HotPink);
            objlistimg.Images.Add(ImageResources.IndianRed);
            objlistimg.Images.Add(ImageResources.Darkorange);
            objlistimg.Images.Add(ImageResources.Darkorchid);
            objlistimg.Images.Add(ImageResources.DeepSkyBlue31);
            objlistimg.Images.Add(ImageResources.SandyBrown);
            arlTachoData = new ArrayList();
            int[] LOR = { 100, 200, 400, 800, 1600, 3200, 6400, 12800, 25600, 51200, 102400, 204800 };
            int[] LOR1 = { 256, 512, 1024, 2048, 4096, 8192, 16384, 32738, 65536, 131072, 262144, 524288 };
            AvgBytesPerSec = 0;
            SF = 0;
            iLastFrequency = 0;
            iLOR = 0;
            LineOfResolution = 0;
            ExectTime = 0;
            ExectDataByteSample = 0;
            TotalDataBytes = 0;
            TimeVal = 0;
            TotalTime = 0;
            channel = 1;
            string RIFF = "RIFF";

            string OROS = "oros";
            string fmt = "fmt ";
            string data = "data";
            double[] xData = null;
            int iDataStart = 0;
            try
            {
                iclick = 1;
                if (Directory.Exists("c:\\vvtemp\\"))
                {
                    Directory.Delete("c:\\vvtemp\\", true);
                }
                using (FileStream wav = new FileStream(spath, FileMode.Open, FileAccess.Read))
                {
                    Byte[] Parameter = new byte[wav.Length];
                    wav.Read(Parameter, 0, Parameter.Length);
                    string SFH = null;
                    //Check Header ID
                    for (int i = 0; i < 4; i++)
                    {
                        int val = Convert.ToInt32(Parameter[i].ToString());
                        char c = (char)val;
                        SFH += c.ToString();
                    }
                    if (SFH == RIFF)
                    {
                        SFH = null;
                        for (int i = 12; i < 16; i++)
                        {
                            int val = Convert.ToInt32(Parameter[i].ToString());
                            char c = (char)val;
                            SFH += c.ToString();
                        }
                        if (SFH == fmt)
                        {
                            SFH = null;
                            for (int i = 23; i > 21; i--)
                            {
                                int val = Convert.ToInt32(Parameter[i].ToString());
                                string sval = Common.DeciamlToHexadeciaml1(val);
                                switch (sval)
                                {
                                    case "0":
                                        sval = "00";
                                        break;
                                    case "1":
                                        sval = "01";
                                        break;
                                    case "2":
                                        sval = "02";
                                        break;
                                    case "3":
                                        sval = "03";
                                        break;
                                    case "4":
                                        sval = "04";
                                        break;
                                    case "5":
                                        sval = "05";
                                        break;
                                    case "6":
                                        sval = "06";
                                        break;
                                    case "7":
                                        sval = "07";
                                        break;
                                    case "8":
                                        sval = "08";
                                        break;
                                    case "9":
                                        sval = "09";
                                        break;
                                }
                                SFH += sval;
                            }
                            channel = Common.HexadecimaltoDecimal(SFH);
                            string[] SFbyteD = new string[4];
                            SFH = null;
                            int ctr = 0;
                            for (int i = 27; i > 23; i--)
                            {
                                int val = Convert.ToInt32(Parameter[i].ToString());
                                string sval = Common.DeciamlToHexadeciaml1(val);
                                switch (sval)
                                {
                                    case "0":
                                        sval = "00";
                                        break;
                                    case "1":
                                        sval = "01";
                                        break;
                                    case "2":
                                        sval = "02";
                                        break;
                                    case "3":
                                        sval = "03";
                                        break;
                                    case "4":
                                        sval = "04";
                                        break;
                                    case "5":
                                        sval = "05";
                                        break;
                                    case "6":
                                        sval = "06";
                                        break;
                                    case "7":
                                        sval = "07";
                                        break;
                                    case "8":
                                        sval = "08";
                                        break;
                                    case "9":
                                        sval = "09";
                                        break;
                                }
                                SFH += sval;
                            }
                            SF = Common.HexadecimaltoDecimal(SFH);
                            SFH = null;
                            for (int i = 31; i > 27; i--)
                            {
                                int val = Convert.ToInt32(Parameter[i].ToString());
                                string sval = Common.DeciamlToHexadeciaml1(val);
                                switch (sval)
                                {
                                    case "0":
                                        sval = "00";
                                        break;
                                    case "1":
                                        sval = "01";
                                        break;
                                    case "2":
                                        sval = "02";
                                        break;
                                    case "3":
                                        sval = "03";
                                        break;
                                    case "4":
                                        sval = "04";
                                        break;
                                    case "5":
                                        sval = "05";
                                        break;
                                    case "6":
                                        sval = "06";
                                        break;
                                    case "7":
                                        sval = "07";
                                        break;
                                    case "8":
                                        sval = "08";
                                        break;
                                    case "9":
                                        sval = "09";
                                        break;
                                }
                                SFH += sval;
                            }
                            AvgBytesPerSec = Common.HexadecimaltoDecimal(SFH);

                            SFH = null;

                            for (int i = 27; i > 23; i--)
                            {
                                string sval = Parameter[i].ToString();
                                switch (sval)
                                {
                                    case "0":
                                        sval = "00";
                                        break;
                                    case "1":
                                        sval = "01";
                                        break;
                                    case "2":
                                        sval = "02";
                                        break;
                                    case "3":
                                        sval = "03";
                                        break;
                                    case "4":
                                        sval = "04";
                                        break;
                                    case "5":
                                        sval = "05";
                                        break;
                                    case "6":
                                        sval = "06";
                                        break;
                                    case "7":
                                        sval = "07";
                                        break;
                                    case "8":
                                        sval = "08";
                                        break;
                                    case "9":
                                        sval = "09";
                                        break;
                                }
                                SFH += sval;
                            }
                            iLastFrequency = Convert.ToInt32(SFH);
                            iFinalFrequency = iLastFrequency;
                            iLOR = 0;
                            for (int i = 0; i < LOR.Length; i++)
                            {
                                double temp = (double)LOR[i] / (double)iLastFrequency;
                                if (temp >= 0.666667)
                                {
                                    iLOR = i;
                                    break;
                                }
                            }
                            LineOfResolution = LOR1[iLOR];
                            RUCDvariable = (LOR[iLOR] / 100) * 2;
                            if (RUCDvariable < 5)
                            {
                                RUCDvariable = 5;
                            }
                            ExectTime = (double)LOR[iLOR] / (double)iLastFrequency;
                            ExectDataByteSample = Convert.ToInt32((double)SF * ExectTime);
                            SFH = null;

                            for (int i = 36; i < 40; i++)
                            {
                                int val = Convert.ToInt32(Parameter[i].ToString());
                                char c = (char)val;
                                SFH += c.ToString();
                            }
                            string tempDATA = null;
                            SFH = null;
                            int tempICTR = 36;
                            while (SFH != data)
                            {
                                for (int i = tempICTR; i < tempICTR + 4; i++)
                                {
                                    int val = Convert.ToInt32(Parameter[i].ToString());
                                    char c = (char)val;
                                    tempDATA += c.ToString();
                                }
                                tempICTR++;
                                SFH = tempDATA;
                                tempDATA = null;
                            }


                            if (SFH == data)
                            {
                                iDataStart = tempICTR + 7;
                                SFH = null;
                                for (int i = tempICTR + 6; i > (tempICTR + 2); i--)
                                {
                                    int val = Convert.ToInt32(Parameter[i].ToString());
                                    string sval = Common.DeciamlToHexadeciaml1(val);
                                    switch (sval)
                                    {
                                        case "0":
                                            sval = "00";
                                            break;
                                        case "1":
                                            sval = "01";
                                            break;
                                        case "2":
                                            sval = "02";
                                            break;
                                        case "3":
                                            sval = "03";
                                            break;
                                        case "4":
                                            sval = "04";
                                            break;
                                        case "5":
                                            sval = "05";
                                            break;
                                        case "6":
                                            sval = "06";
                                            break;
                                        case "7":
                                            sval = "07";
                                            break;
                                        case "8":
                                            sval = "08";
                                            break;
                                        case "9":
                                            sval = "09";
                                            break;
                                    }
                                    SFH += sval;
                                }
                                TotalDataBytes = Common.HexadecimaltoDecimal(SFH);
                                TimeVal = Convert.ToDouble(1 / Convert.ToDouble(SF));


                                xData = new double[ExectDataByteSample];

                                for (int i = 0; i < ExectDataByteSample; i++)
                                {
                                    xData[i] = i * TimeVal;
                                }
                                xarray = xData;
                                SamplePerSec = 0;
                                if (channel == 1)
                                {
                                    SamplePerSec = AvgBytesPerSec / SF;
                                }
                                else if (channel == 2)
                                {
                                    SamplePerSec = AvgBytesPerSec / SF;
                                    SamplePerSec = SamplePerSec / 2;
                                }
                                else
                                {
                                    SamplePerSec = AvgBytesPerSec / SF;
                                    SamplePerSec = SamplePerSec / channel;
                                }
                                TotalTime = TotalDataBytes / AvgBytesPerSec;
                                if (wav.Length > (TotalDataBytes + 44))
                                {
                                    try
                                    {
                                        SFH = null;
                                        for (int i = TotalDataBytes + 44 + 7; i > TotalDataBytes + 44 + 3; i--)
                                        {
                                            int val = Convert.ToInt32(Parameter[i].ToString());
                                            string sval = Common.DeciamlToHexadeciaml1(val);
                                            switch (sval)
                                            {
                                                case "0":
                                                    sval = "00";
                                                    break;
                                                case "1":
                                                    sval = "01";
                                                    break;
                                                case "2":
                                                    sval = "02";
                                                    break;
                                                case "3":
                                                    sval = "03";
                                                    break;
                                                case "4":
                                                    sval = "04";
                                                    break;
                                                case "5":
                                                    sval = "05";
                                                    break;
                                                case "6":
                                                    sval = "06";
                                                    break;
                                                case "7":
                                                    sval = "07";
                                                    break;
                                                case "8":
                                                    sval = "08";
                                                    break;
                                                case "9":
                                                    sval = "09";
                                                    break;
                                            }
                                            SFH += sval;
                                        }
                                        int TotalOROSDataBytes = Common.HexadecimaltoDecimal(SFH);

                                        Byte[] orosChunk = new byte[TotalOROSDataBytes];
                                        int orosctr = TotalDataBytes + 44 + 8;
                                        for (int i = 0; i < orosChunk.Length; i++)
                                        {
                                            orosChunk[i] = Parameter[orosctr];
                                            orosctr++;
                                        }

                                        sensitivity_CH1 = 0;
                                        sensitivity_CH2 = 0;
                                        label_Ch1 = null;
                                        label_Ch2 = null;
                                        Name_Ch1 = null;
                                        Name_Ch2 = null;
                                        sensitivity_CH1 = BitConverter.ToSingle(orosChunk, 8);
                                        divider_CH1 = (3.16 * 1.414 / 32768) / sensitivity_CH1;
                                        if (channel == 2)
                                        {
                                            sensitivity_CH2 = BitConverter.ToSingle(orosChunk, 100);
                                            divider_CH2 = (3.16 * 1.414 / 32768) / sensitivity_CH2;
                                        }
                                        byte[] NameExtracter = new byte[32];
                                        for (int i = 39, j = 0; j < 32; i++, j++)
                                        {
                                            NameExtracter[j] = orosChunk[i];
                                        }
                                        label_Ch1 = Encoding.ASCII.GetString(NameExtracter);
                                        label_Ch1 = label_Ch1.Trim(new char[] { '\0', ' ' });
                                        if (channel == 2)
                                        {
                                            NameExtracter = new byte[32];
                                            for (int i = 131, j = 0; j < 32; i++, j++)
                                            {
                                                NameExtracter[j] = orosChunk[i];
                                            }
                                            label_Ch2 = Encoding.ASCII.GetString(NameExtracter);
                                            label_Ch2 = label_Ch2.Trim(new char[] { '\0', ' ' });
                                        }

                                        NameExtracter = new byte[20];
                                        for (int i = 78, j = 0; j < 20; i++, j++)
                                        {
                                            NameExtracter[j] = orosChunk[i];
                                        }

                                        Name_Ch1 = Encoding.ASCII.GetString(NameExtracter);
                                        Name_Ch1 = Name_Ch1.Trim(new char[] { '\0', ' ' });
                                        if (channel == 2)
                                        {
                                            NameExtracter = new byte[20];
                                            for (int i = 170, j = 0; j < 20; i++, j++)
                                            {
                                                NameExtracter[j] = orosChunk[i];
                                            }

                                            Name_Ch2 = Encoding.ASCII.GetString(NameExtracter);
                                            Name_Ch2 = Name_Ch2.Trim(new char[] { '\0', ' ' });
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            else if (SFH == OROS)
                            {
                                SFH = null;
                                for (int i = 43; i > 39; i--)
                                {
                                    int val = Convert.ToInt32(Parameter[i].ToString());
                                    string sval = Common.DeciamlToHexadeciaml1(val);
                                    switch (sval)
                                    {
                                        case "0":
                                            sval = "00";
                                            break;
                                        case "1":
                                            sval = "01";
                                            break;
                                        case "2":
                                            sval = "02";
                                            break;
                                        case "3":
                                            sval = "03";
                                            break;
                                        case "4":
                                            sval = "04";
                                            break;
                                        case "5":
                                            sval = "05";
                                            break;
                                        case "6":
                                            sval = "06";
                                            break;
                                        case "7":
                                            sval = "07";
                                            break;
                                        case "8":
                                            sval = "08";
                                            break;
                                        case "9":
                                            sval = "09";
                                            break;
                                    }
                                    SFH += sval;
                                }
                                int TotalOROSDataBytes = Common.HexadecimaltoDecimal(SFH);

                                Byte[] orosChunk = new byte[TotalOROSDataBytes];
                                int orosctr = TotalDataBytes + 36 + 8;
                                for (int i = 0; i < orosChunk.Length; i++)
                                {
                                    orosChunk[i] = Parameter[orosctr];
                                    orosctr++;
                                }

                                sensitivity_CH1 = 0;
                                sensitivity_CH2 = 0;
                                label_Ch1 = null;
                                label_Ch2 = null;
                                Name_Ch1 = null;
                                Name_Ch2 = null;
                                sensitivity_CH1 = BitConverter.ToSingle(orosChunk, 8);
                                divider_CH1 = (3.16 * 1.414 / 32768) / sensitivity_CH1;
                                if (channel == 2)
                                {
                                    sensitivity_CH2 = BitConverter.ToSingle(orosChunk, 100);
                                    divider_CH2 = (3.16 * 1.414 / 32768) / sensitivity_CH2;
                                }
                                byte[] NameExtracter = new byte[32];
                                for (int i = 39, j = 0; j < 32; i++, j++)
                                {
                                    NameExtracter[j] = orosChunk[i];
                                }
                                label_Ch1 = Encoding.ASCII.GetString(NameExtracter);
                                label_Ch1 = label_Ch1.Trim(new char[] { '\0', ' ' });
                                if (channel == 2)
                                {
                                    NameExtracter = new byte[32];
                                    for (int i = 131, j = 0; j < 32; i++, j++)
                                    {
                                        NameExtracter[j] = orosChunk[i];
                                    }
                                    label_Ch2 = Encoding.ASCII.GetString(NameExtracter);
                                    label_Ch2 = label_Ch2.Trim(new char[] { '\0', ' ' });
                                }

                                NameExtracter = new byte[20];
                                for (int i = 78, j = 0; j < 20; i++, j++)
                                {
                                    NameExtracter[j] = orosChunk[i];
                                }

                                Name_Ch1 = Encoding.ASCII.GetString(NameExtracter);
                                Name_Ch1 = Name_Ch1.Trim(new char[] { '\0', ' ' });
                                if (channel == 2)
                                {
                                    NameExtracter = new byte[20];
                                    for (int i = 170, j = 0; j < 20; i++, j++)
                                    {
                                        NameExtracter[j] = orosChunk[i];
                                    }

                                    Name_Ch2 = Encoding.ASCII.GetString(NameExtracter);
                                    Name_Ch2 = Name_Ch2.Trim(new char[] { '\0', ' ' });
                                }

                                SFH = null;

                                for (int i = orosctr; i < orosctr + 4; i++)
                                {
                                    int val = Convert.ToInt32(Parameter[i].ToString());
                                    char c = (char)val;
                                    SFH += c.ToString();
                                }
                                if (SFH == data)
                                {
                                    SFH = null;
                                    int datastart = orosctr + 4 - 1;
                                    for (int i = datastart + 4; i > datastart; i--)
                                    {
                                        int val = Convert.ToInt32(Parameter[i].ToString());
                                        string sval = Common.DeciamlToHexadeciaml1(val);
                                        switch (sval)
                                        {
                                            case "0":
                                                sval = "00";
                                                break;
                                            case "1":
                                                sval = "01";
                                                break;
                                            case "2":
                                                sval = "02";
                                                break;
                                            case "3":
                                                sval = "03";
                                                break;
                                            case "4":
                                                sval = "04";
                                                break;
                                            case "5":
                                                sval = "05";
                                                break;
                                            case "6":
                                                sval = "06";
                                                break;
                                            case "7":
                                                sval = "07";
                                                break;
                                            case "8":
                                                sval = "08";
                                                break;
                                            case "9":
                                                sval = "09";
                                                break;
                                        }
                                        SFH += sval;
                                    }
                                    TotalDataBytes = Common.HexadecimaltoDecimal(SFH);
                                    TimeVal = Convert.ToDouble(1 / Convert.ToDouble(SF));

                                    iDataStart = datastart + 4 + 1;
                                    xData = new double[ExectDataByteSample];

                                    for (int i = 0; i < ExectDataByteSample; i++)
                                    {
                                        xData[i] = i * TimeVal;
                                    }
                                    xarray = xData;
                                    SamplePerSec = 0;
                                    if (channel == 1)
                                    {
                                        SamplePerSec = AvgBytesPerSec / SF;
                                    }
                                    else if (channel == 2)
                                    {
                                        SamplePerSec = AvgBytesPerSec / SF;
                                        SamplePerSec = SamplePerSec / 2;
                                    }
                                    else
                                    {
                                        SamplePerSec = AvgBytesPerSec / SF;
                                        SamplePerSec = SamplePerSec / channel;
                                    }
                                    TotalTime = TotalDataBytes / AvgBytesPerSec;
                                }
                            }
                            bShowOrbit = false;
                            if (TotalTime > 0)
                            {
                                short sample;
                                double[] narray = new double[0];
                                BinaryReader fr = new BinaryReader(wav);

                                double[] soundBytes = new double[xData.Length];
                                double[] soundBytes1 = new double[xData.Length];
                                arlYData = new ArrayList();
                                ctr = 0;
                                int abc = 0;

                                fr.BaseStream.Position = iDataStart;
                                if (channel == 1)
                                {
                                    objGcontrol.dataGridView1.Visible = false;
                                    int xx = 0;
                                    double[] abcd = new double[TotalDataBytes / 2];
                                    Fulldata_CH1 = new double[abcd.Length];
                                    while (fr.BaseStream.Position - iDataStart < TotalDataBytes)
                                    {

                                        sample = fr.ReadInt16();
                                        abcd[xx] = sample;

                                        soundBytes[ctr] = sample;
                                        double SampleVal = Convert.ToDouble(sample * divider_CH1);
                                        Fulldata_CH1[xx] = SampleVal;
                                        if (SampleVal < 100)
                                        {
                                            SampleVal = Math.Round(SampleVal, 9);
                                            soundBytes[ctr] = (SampleVal);
                                        }
                                        else
                                        {
                                            SampleVal = Math.Round(SampleVal);
                                            soundBytes[ctr] = (SampleVal);
                                        }
                                        ctr++;
                                        xx++;
                                        if (ctr == xData.Length)
                                        {
                                            double[] tempYdata = null;
                                            if (!bShowOrbit)
                                            {
                                                double[] Fmag = ConvertToFFT(soundBytes, xData, iLastFrequency);
                                                arlYData.Add(Fmag);
                                                tempYdata = soundBytes;
                                            }
                                            else
                                            {
                                                arlYData.Add(soundBytes);
                                                tempYdata = soundBytes;
                                            }
                                            ctr = 0;
                                            soundBytes = new double[xData.Length];
                                            {
                                                string sTag = wavnode;
                                                string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };
                                                try
                                                {
                                                    {
                                                        string s = null;
                                                        if (!bShowOrbit)
                                                        {
                                                            if (channel == 1)
                                                            {
                                                                s = trendValCtr.ToString();
                                                                s = (ExectTime * (double)trendValCtr).ToString();
                                                            }
                                                            else if (channel == 2 && trendValCtr % 2 == 0)
                                                            {
                                                                abc += 1;
                                                                s = abc.ToString() + " Ch-1";
                                                                s = (ExectTime * (double)trendValCtr).ToString() + " Ch-1";
                                                            }
                                                            else if (channel == 2 && trendValCtr % 2 != 0)
                                                            {
                                                                s = abc.ToString() + " Ch-2";
                                                                s = (ExectTime * (double)(trendValCtr - 1)).ToString() + " Ch-2";
                                                            }

                                                            if (!Directory.Exists("c:\\vvtemp\\"))
                                                            {
                                                                Directory.CreateDirectory("c:\\vvtemp\\");
                                                            }

                                                            aa1 = new FileStream("c:\\vvtemp\\" + s + ".txt", FileMode.Create, FileAccess.ReadWrite);

                                                            sw = new StreamWriter(aa1);
                                                            for (int i = 0; i < xData.Length; i++)
                                                            {
                                                                sw.Write(xData[i] + "/././" + tempYdata[i] + ".....");
                                                            }
                                                            sw.Close();

                                                            iCCtr = trendValCtr % 30;
                                                            objGcontrol.dataGridView2.Rows.Add(1);
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[0].Value = s;
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[2].Value = s;
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[1].Value = "X";
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[3].Value = objlistimg.Images[iCCtr];
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[3].Tag = ColorCode[iCCtr].ToString();

                                                            trendValCtr++;
                                                        }
                                                        else
                                                        {
                                                            if (channel == 2 && trendValCtr % 2 == 0)
                                                            {

                                                                s = abc.ToString();

                                                                iCCtr = trendValCtr % 30;
                                                                objGcontrol.dataGridView2.Rows.Add(1);
                                                                objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[0].Value = s;
                                                                objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[2].Value = s;
                                                                objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[1].Value = "X";
                                                                objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[3].Value = objlistimg.Images[iCCtr];
                                                                objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[3].Tag = ColorCode[iCCtr].ToString();

                                                            }
                                                            abc += 1;
                                                            trendValCtr++;
                                                        }
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    objGcontrol.dataGridView1.Visible = true;
                                    {
                                        objGcontrol.dataGridView1.Height = objGcontrol.panel1.Height / 3;
                                        objGcontrol.dataGridView2.Height = objGcontrol.panel1.Height / 3;
                                    }
                                    int xx = 0;
                                    int yy = 0;
                                    double[] abcd = new double[TotalDataBytes / (channel * SamplePerSec)];
                                    Fulldata_CH1 = new double[abcd.Length];
                                    double[] abcd1 = new double[TotalDataBytes / (channel * SamplePerSec)];
                                    Fulldata_CH2 = new double[abcd1.Length];
                                    int timectr = 0;
                                    while (fr.BaseStream.Position - iDataStart < TotalDataBytes)
                                    {
                                        sample = fr.ReadInt16();
                                        double SampleVal = 0;
                                        if (xx % channel == 0)
                                        {
                                            SampleVal = Convert.ToDouble(sample * divider_CH1);
                                            if (SampleVal < 100)
                                            {
                                                SampleVal = Math.Round(SampleVal, 9);
                                                soundBytes[ctr] = (SampleVal);
                                            }
                                            else
                                            {
                                                SampleVal = Math.Round(SampleVal);
                                                soundBytes[ctr] = (SampleVal);
                                            }
                                            abcd[yy] = sample;
                                            Fulldata_CH1[yy] = SampleVal;
                                            xx++;

                                        }
                                        else if (xx % channel == 1)
                                        {
                                            SampleVal = Convert.ToDouble(sample * divider_CH2);
                                            if (SampleVal < 100)
                                            {
                                                SampleVal = Math.Round(SampleVal, 9);
                                                soundBytes1[ctr] = (SampleVal);
                                            }
                                            else
                                            {
                                                SampleVal = Math.Round(SampleVal);
                                                soundBytes1[ctr] = (SampleVal);
                                            }
                                            abcd1[yy] = sample;
                                            Fulldata_CH2[yy] = SampleVal;
                                            ctr++;
                                            xx++;
                                            yy++;
                                        }
                                        else
                                        {
                                            xx++;
                                        }
                                        if (ctr == xData.Length)
                                        {
                                            double[] tempYdata = null;
                                            if (!bShowOrbit)
                                            {
                                                double[] Fmag = ConvertToFFT(soundBytes, xData, iLastFrequency);
                                                arlYData.Add(Fmag);
                                                tempYdata = soundBytes;
                                            }
                                            else
                                            {
                                                arlYData.Add(soundBytes);
                                                tempYdata = soundBytes;
                                            }

                                            ctr = 0;
                                            soundBytes = new double[xData.Length];
                                            {
                                                string sTag = wavnode;
                                                string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };
                                                try
                                                {
                                                    string s = null;
                                                    if (!bShowOrbit)
                                                    {
                                                        {
                                                            abc += 1;
                                                            s = abc.ToString() + " Ch-1";
                                                            s = (ExectTime * (double)timectr).ToString() + " Ch-1";

                                                            iCCtr = trendValCtr % 30;
                                                            objGcontrol.dataGridView2.Rows.Add(1);
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[0].Value = s;
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[2].Value = s;
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[1].Value = "X";
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[3].Value = objlistimg.Images[iCCtr];
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[3].Tag = ColorCode[iCCtr].ToString();

                                                            trendValCtr++;

                                                            if (!Directory.Exists("c:\\vvtemp\\"))
                                                            {
                                                                Directory.CreateDirectory("c:\\vvtemp\\");
                                                            }

                                                            aa1 = new FileStream("c:\\vvtemp\\" + s + ".txt", FileMode.Create, FileAccess.ReadWrite);

                                                            sw = new StreamWriter(aa1);
                                                            for (int i = 0; i < xData.Length; i++)
                                                            {
                                                                sw.Write(xData[i] + "/././" + tempYdata[i] + ".....");
                                                            }
                                                            sw.Close();
                                                        }
                                                        s = abc.ToString() + " Ch-2";
                                                        s = (ExectTime * (double)(timectr)).ToString() + " Ch-2";

                                                        iCCtr = trendValCtr % 30;
                                                        objGcontrol.dataGridView2.Rows.Add(1);
                                                        objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[0].Value = s;
                                                        objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[2].Value = s;
                                                        objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[1].Value = "X";
                                                        objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[3].Value = objlistimg.Images[iCCtr];
                                                        objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[3].Tag = ColorCode[iCCtr].ToString();

                                                        trendValCtr++;

                                                        aa1 = new FileStream("c:\\vvtemp\\" + s + ".txt", FileMode.Create, FileAccess.ReadWrite);

                                                        sw = new StreamWriter(aa1);
                                                        for (int i = 0; i < xData.Length; i++)
                                                        {
                                                            sw.Write(xData[i] + "/././" + soundBytes1[i] + ".....");
                                                        }
                                                        sw.Close();

                                                        soundBytes1 = new double[xData.Length];
                                                        timectr++;
                                                    }
                                                    else
                                                    {
                                                        if (channel == 2 && trendValCtr % 2 == 0)
                                                        {
                                                            s = abc.ToString();
                                                            iCCtr = trendValCtr % 30;
                                                            objGcontrol.dataGridView2.Rows.Add(1);
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[0].Value = s;
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[2].Value = s;
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[1].Value = "X";
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[3].Value = objlistimg.Images[iCCtr];
                                                            objGcontrol.dataGridView2.Rows[objGcontrol.dataGridView2.Rows.Count - 2].Cells[3].Tag = ColorCode[iCCtr].ToString();

                                                        }
                                                        abc += 1;
                                                        trendValCtr++;
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                    }
                                    double and = findHighestValue(abcd);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Not Enough Sample to Draw");
                                bWave = !bWave;
                            }
                        }
                    }
                }
            }
            catch
            { }
            finally
            {
                sr = null;
                sw = null;
            }
        }
        int iCCtr = 0;
        int trendValCtr = 0;

        private float findHighestValue(double[] Target)
        {
            double MaxVal = 0.0;
            double MinVal = 0.0;
            double FinalVal = 0.0;
            try
            {
                for (int i = 0; i < Target.Length; i++)
                {
                    if (Target[i] > MaxVal)
                        MaxVal = Target[i];
                    if (Target[i] < MinVal)
                        MinVal = Target[i];
                }
                MinVal = Math.Abs(MinVal);
                if (MaxVal >= MinVal)
                    FinalVal = MaxVal;
                else if (MinVal > MaxVal)
                    FinalVal = MinVal;
            }
            catch
            {
            }
            return (float)FinalVal;
        }

        private int n, nu; bool bWave = false; StreamWriter sw = null;
        StreamReader sr = null;
        //public double[] fftMag(double[] x)
        //{            
        //    if (x.Length % 2 == 0)
        //    {
        //        n = x.Length;
        //    }
        //    else
        //    {
        //        n = x.Length - 1;
        //    }
        //    nu = (int)(Math.Log(n) / Math.Log(2));
        //    int n2 = n / 2;
        //    int nu1 = nu - 1;
        //    double[] xre = new double[n];
        //    double[] xim = new double[n];
        //    double[] mag = new double[n2];
        //    double tr, ti, p, arg, c, s;
        //    try
        //    {
        //        for (int i = 0; i < n; i++)
        //        {
        //            xre[i] = x[i];
        //            xim[i] = 0.0f;
        //        }
        //        int k = 0;

        //        for (int l = 1; l <= nu; l++)
        //        {
        //            while (k < n)
        //            {
        //                for (int i = 1; i <= n2; i++)
        //                {
        //                    if ((k + n2) < n)
        //                    {
        //                        try
        //                        {
        //                            p = bitrev(k >> nu1);
        //                            arg = 2 * (double)Math.PI * p / n;
        //                            c = (double)Math.Cos(arg);
        //                            s = (double)Math.Sin(arg);
        //                            tr = xre[k + n2] * c + xim[k + n2] * s;
        //                            ti = xim[k + n2] * c - xre[k + n2] * s;
        //                            xre[k + n2] = xre[k] - tr;
        //                            xim[k + n2] = xim[k] - ti;
        //                            xre[k] += tr;
        //                            xim[k] += ti;
        //                            k++;
        //                        }
        //                        catch
        //                        {
        //                        }
        //                    }
        //                }
        //                k += n2;
        //            }
        //            k = 0;
        //            nu1--;
        //            n2 = n2 / 2;
        //        }
        //        k = 0;
        //        int r;
        //        while (k < n)
        //        {
        //            r = bitrev(k);
        //            if (r > k)
        //            {
        //                tr = xre[k];
        //                ti = xim[k];
        //                xre[k] = xre[r];
        //                xim[k] = xim[r];
        //                xre[r] = tr;
        //                xim[r] = ti;
        //            }
        //            k++;
        //        }
        //        mag[0] = 0;
        //        for (int i = 1; i < n / 2; i++)
        //        {
        //            mag[i] = (float)((2 * (float)(Math.Sqrt(xre[i] * xre[i] + xim[i] * xim[i]))) / n);
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    return mag;
        //}

        private int bitrev(int j)
        {
            int j2;
            int j1 = j;
            int k = 0;
            try
            {
                for (int i = 1; i <= nu; i++)
                {
                    j2 = j1 / 2;
                    k = 2 * k + j1 - 2 * j2;
                    j1 = j2;
                }
            }
            catch
            {
            }
            return k;
        }

        private double[] ConvertToFFT(double[] soundBytes, double[] xData, int ilastFreq)
        {
            double[] Fmag = new double[0];
            try
            {
                double[] mag = fftMag(soundBytes);
                double lastTimevalue = (double)(xData[xData.Length - 1]);
                lastTimevalue = Math.Round(lastTimevalue, 2);
                double HzRate = (double)(1 / lastTimevalue);
                double[] Hz = new double[mag.Length];
                for (int i = 0; i < mag.Length; i++)
                {
                    Hz[i] = HzRate * i;
                    if (Hz[i] >= ilastFreq)
                    {
                        break;
                    }
                }
                xarray = Hz;
                Fmag = new double[Hz.Length];
                for (int i = 0; i < Hz.Length; i++)
                {
                    Fmag[i] = mag[i];
                }
            }
            catch
            {
            }
            return Fmag;
        }

        bool Channel1GraphToDraw = true; public double[] Channel1WavX = null;
        public double[] Channel1WavY = null; public double[] Channel2WavX = null;
        public double[] Channel2WavY = null;
        public string wavnode = null; string source = null;
        string Dest = null;
        private void DrawWavInitial(string wavnode, bool New)
        {
            try
            {
                if (Channel1GraphToDraw)
                {
                    int xlength = (TotalDataBytes / SamplePerSec) / channel;
                    double[] xData = new double[xlength];
                    for (int i = 0; i < xlength; i++)
                    {
                        xData[i] = i * TimeVal;
                    }
                    xarray = xData;
                    FullTime_CH2 = xData;
                    string sTag = wavnode;
                    string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };

                    try
                    {
                        Channel1WavX = xData;
                        Channel1WavY = Fulldata_CH1;
                        if (channel == 2)
                        {
                            Channel2WavX = Channel1WavX;
                            Channel2WavY = Fulldata_CH2;
                        }
                        x = xData;
                        y = Fulldata_CH1;
                        NullCursorBools();
                        GphCtr = 0;
                        ArrayList _arlst = new ArrayList();
                        _arlst.Add(x);
                        _arlst.Add(y);
                        CurrentXLabel = "Sec";
                        CurrentYLabel = label_Ch1.ToString();
                        xarrayNew = x;
                        yarrayNew = y;
                        PublicClass.Chart_Footer = null;
                        DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    int xlength = (TotalDataBytes / SamplePerSec) / channel;
                    double[] xData = new double[xlength];
                    for (int i = 0; i < xlength; i++)
                    {
                        xData[i] = i * TimeVal;
                    }
                    xarray = xData;
                    FullTime_CH2 = xData;
                    Channel1WavX = xData;
                    Channel1WavY = Fulldata_CH1;
                    Channel2WavX = Channel1WavX;
                    Channel2WavY = Fulldata_CH2;

                    string sTag = wavnode;
                    string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };

                    try
                    {
                        x = xData;
                        y = Fulldata_CH2;
                        NullCursorBools();
                        GphCtr = 0;
                        CurrentXLabel = "Sec";
                        CurrentYLabel = label_Ch2.ToString();
                        xarrayNew = x;
                        yarrayNew = y;
                        DrawLineGraphs(xarrayNew, yarrayNew, CurrentXLabel, CurrentYLabel);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        string DestbeforeTrend = null;
        private void ReadTXTfileNew(string Dest, bool Exact)
        {
            xarrayNew = new double[0];
            yarrayNew = new double[0];
            string data = null;
            try
            {
                string[] sarrpath = null;
                if (!Exact)
                {
                    sarrpath = Dest.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                    aa1 = new FileStream("c:\\vvtemp\\" + sarrpath[sarrpath.Length - 1], FileMode.Open, FileAccess.Read);
                    DestbeforeTrend = "c:\\vvtemp\\" + sarrpath[sarrpath.Length - 1];
                }
                else
                {
                    aa1 = new FileStream(Dest, FileMode.Open, FileAccess.Read);
                    DestbeforeTrend = Dest;
                }
                sr = new StreamReader(aa1);
                data = sr.ReadToEnd();
                sr.Close();
                string[] splitedData = data.Split(new string[] { "....." }, StringSplitOptions.RemoveEmptyEntries);
                xarrayNew = new double[splitedData.Length];
                yarrayNew = new double[splitedData.Length];
                for (int i = 0; i < splitedData.Length; i++)
                {
                    string[] splittedXYData = splitedData[i].ToString().Split(new string[] { "/././" }, StringSplitOptions.RemoveEmptyEntries);
                    xarrayNew[i] = Convert.ToDouble(splittedXYData[0]);
                    yarrayNew[i] = Convert.ToDouble(splittedXYData[1]);
                }
            }
            catch
            {
            }
            finally
            {
                sr = null;
                sw = null;
            }
        }


        private void bbdashboard_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
                frmDashboardRibbon objDashboard = new frmDashboardRibbon();
                objDashboard.MainForm = this;
                objDashboard.UserControl = _objUserControl;
                objDashboard.ShowDialog();
                objDashboard.WindowState = FormWindowState.Maximized;
            }
            catch
            {
            }
        }

        private void helpbb_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Help.ShowHelp(this, Application.StartupPath + "\\" + "VibAnalyst.chm");
            }
            catch { }
        }

        private void aboutbb_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmabout about = new frmabout();
                about.ShowDialog();
            }
            catch
            { }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmtest test = new frmtest();
                test.ShowDialog();
            }
            catch { }
        }

        private void frmIAdeptMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (exitsts)
                {
                    Application.Exit();
                }
                else
                {
                    var res = MessageBox.Show(this, "You really want to quit?", "Exit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (res != DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select * from factory_info");
                        if (dt.Rows.Count > 0)
                        {
                            DbClass.executequery(CommandType.Text, "Update userdetail set Login = '0' , LastloginDate = '" + PublicClass.GetDatetime() + "' where ID = '" + PublicClass.cUID + "'");
                            DataTable dtDesign = DbClass.getdata(CommandType.Text, "Select * from proj_design where UserName = '" + PublicClass.cUserName + "' and Password ='" + PublicClass.cPassword + "'");
                            if (dtDesign.Rows.Count <= 0)
                            {
                                DbClass.executequery(CommandType.Text, "Insert into proj_design(UserName,Password,pDesign,pColor,pFont) values('" + PublicClass.cUserName + "' , '" + PublicClass.cPassword + "' ,'" + PublicClass.designStyle + "' , '" + PublicClass.ColorStyle + "','" + PublicClass.fontStyle + "' )");
                            }
                            else
                            {
                                DbClass.executequery(CommandType.Text, "Update proj_design set pDesign = '" + PublicClass.designStyle + "' , pColor = '" + PublicClass.ColorStyle + "', pFont = '" + PublicClass.fontStyle + "' where UserName = '" + PublicClass.cUserName + "' and Password = '" + PublicClass.cPassword + "'");
                            }
                        }
                        //else
                        //{
                        //    MessageBox.Show("Please Create a Hierarchy", "VibAnalyst", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    e.Cancel = true;
                        //    return;
                        //}
                    }
                }
            }
            catch { }

        }

        private void bbMachinediagram_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmmachine machine = new frmmachine();
                machine.ShowDialog();
                if (machine.chkclose == true)
                {
                    try
                    {
                        SplashScreenManager.ShowForm(typeof(WaitForm1));
                        ClsSdftodb machinediagram = new ClsSdftodb();
                        machinediagram.fillmachinediagram();
                        _objUserControl.filltreelist();
                        SplashScreenManager.CloseForm();
                    }
                    catch { SplashScreenManager.CloseForm(); }
                }
            }
            catch { SplashScreenManager.CloseForm(); }
        }

        [DllImport("user32.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string windowName);
        private void bbtnVibanalyser_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Process pNovian = new Process();
                pNovian.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "Novian";
                pNovian.Start();
                pNovian.WaitForInputIdle();
                IntPtr handle = pNovian.MainWindowHandle;
                SetWindowText(handle, "ANALYSER");
                this.WindowState = FormWindowState.Minimized;
                pNovian.WaitForExit();
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
            }
        }


        private void bbcrossphase_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                PublicClass.checkphase = "true";
                objGcontrol.dataGridView3.Rows.Clear();
                objGcontrol.DataGridSettingForPhase(true);
                bboriginal();
                PublicClass.checkphase = "false";
            }
            catch { }
        }

        private void bbcalc_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("Calc");
            }
            catch { }
        }

        string overallname = null;
        private void bboveralltype_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                objGcontrol.dataGridView3.Rows.Clear();
                string selectedString = Convert.ToString(bboveralltype.EditValue);
                m_PointGeneral1.MainForm1 = this;
                switch (selectedString)
                {
                    case "A":
                        {
                            overallname = "A";
                            CalculateAllData();
                            break;
                        }
                    case "V":
                        {
                            overallname = "V";
                            CalculateAllData();
                            break;
                        }
                    case "S":
                        {
                            overallname = "S";
                            CalculateAllData();
                            break;
                        }
                }

            }
            catch { }
        }

        double[] YData_A = null; double[] YData_V = null; double[] YData_S = null; double[] YData_common = null;
        double[] YData_A2 = null; double[] YData_V2 = null; double[] YData_S2 = null;
        private void CalculateAllData()
        {
            bool testcheck = false;
            try
            {
                if (PublicClass.checkparent == "Acc")
                {
                    if (overallname == "V")
                    {
                        testcheck = true; PublicClass.y_Unit = "m/s";
                        YData_V = Calculate_ModeV(PublicClass.darrYData, "Mode_A"); YData_common = YData_V;
                    }
                    else if (overallname == "S")
                    {
                        testcheck = true; PublicClass.y_Unit = "um";
                        YData_S = Calculate_ModeS(PublicClass.darrYData, "Mode_A"); YData_common = YData_S;
                    }
                    else { testcheck = true; PublicClass.y_Unit = "m/s2"; YData_common = PublicClass.darrYData; }
                }
                else if (PublicClass.checkparent == "Vel")
                {
                    if (overallname == "A")
                    {
                        testcheck = true; PublicClass.y_Unit = "m/s2";
                        YData_A = Calculate_ModeA(PublicClass.darrYData, "Mode_V"); YData_common = YData_A;
                    }
                    else if (overallname == "S")
                    {
                        testcheck = true; PublicClass.y_Unit = "um";
                        YData_S = Calculate_ModeS(PublicClass.darrYData, "Mode_V"); YData_common = YData_S;
                    }
                    else { testcheck = true; PublicClass.y_Unit = "m/s"; YData_common = PublicClass.darrYData; }
                }
                else if (PublicClass.checkparent == "Displ")
                {
                    if (overallname == "V")
                    {
                        testcheck = true; PublicClass.y_Unit = "m/s";
                        YData_V = Calculate_ModeV(PublicClass.darrYData, "Mode_S"); YData_common = YData_V;
                    }
                    else if (overallname == "A")
                    {
                        testcheck = true; PublicClass.y_Unit = "m/s2";
                        YData_A = Calculate_ModeA(PublicClass.darrYData, "Mode_S"); YData_common = YData_A;
                    }
                    else { testcheck = true; PublicClass.y_Unit = "um"; YData_common = PublicClass.darrYData; }
                }

                if (testcheck == true)
                {
                    ArrayList arrXYVals = new ArrayList();
                    arrXYVals.Add(PublicClass.darrXData);
                    arrXYVals.Add(YData_common);
                    DrawLineGraphs(arrXYVals, "0", "0");
                }
            }
            catch
            {
            }
        }

        private double[] Calculate_ModeA(double[] YData, string FromMode)
        {
            double[] returnArray = new double[YData.Length];
            try
            {
                switch (FromMode)
                {
                    case "Mode_S":
                        {
                            for (int i = 0; i < YData.Length; i++)
                            {
                                double tempdouble = Convert.ToDouble(YData[i] / 1000) * Convert.ToDouble(2 * 3.14 * PublicClass.darrXData[i]);
                                returnArray[i] = Convert.ToDouble(tempdouble / 1000) * Convert.ToDouble(2 * 3.14 * PublicClass.darrXData[i]);
                                if (returnArray[i].ToString() == "NaN")
                                {
                                    returnArray[i] = 0;
                                }
                            }


                            break;
                        }
                    case "Mode_V":
                        {

                            for (int i = 0; i < YData.Length; i++)
                            {
                                returnArray[i] = Convert.ToDouble(YData[i] / 1000) * Convert.ToDouble(2 * 3.14 * PublicClass.darrXData[i]);
                                if (returnArray[i].ToString() == "NaN")
                                {
                                    returnArray[i] = 0;
                                }
                            }
                            break;
                        }
                }
            }
            catch
            {
            }
            return returnArray;
        }

        private double[] Calculate_ModeS(double[] YData, string FromMode)
        {
            double[] returnArray = new double[YData.Length];
            try
            {
                switch (FromMode)
                {
                    case "Mode_A":
                        {
                            for (int i = 0; i < YData.Length; i++)
                            {
                                returnArray[i] = Convert.ToDouble(YData[i] * 1000000) / Convert.ToDouble(Math.Pow((2 * 3.14 * PublicClass.darrXData[i]), 2));
                                if (returnArray[i].ToString() == "NaN")
                                {
                                    returnArray[i] = 0;
                                }
                            }
                            break;
                        }
                    case "Mode_V":
                        {

                            for (int i = 0; i < YData.Length; i++)
                            {
                                double tempdouble = Convert.ToDouble(YData[i] / 1000) * Convert.ToDouble(2 * 3.14 * PublicClass.darrXData[i]);
                                returnArray[i] = Convert.ToDouble(tempdouble * 1000000) / Convert.ToDouble(Math.Pow((2 * 3.14 * PublicClass.darrXData[i]), 2));
                                if (returnArray[i].ToString() == "NaN")
                                {
                                    returnArray[i] = 0;
                                }
                            }
                            break;
                        }
                }
            }
            catch
            {
            }
            return returnArray;
        }

        private double[] Calculate_ModeV(double[] YData, string FromMode)
        {
            double[] returnArray = new double[YData.Length];
            try
            {
                switch (FromMode)
                {
                    case "Mode_A":
                        {
                            for (int i = 0; i < YData.Length; i++)
                            {
                                returnArray[i] = Convert.ToDouble(YData[i] * 1000) / Convert.ToDouble(2 * 3.14 * PublicClass.darrXData[i]);
                                if (returnArray[i].ToString() == "NaN")
                                {
                                    returnArray[i] = 0;
                                }
                            }
                            break;
                        }
                    case "Mode_S":
                        {
                            for (int i = 0; i < YData.Length; i++)
                            {
                                returnArray[i] = Convert.ToDouble(YData[i] / 1000) * Convert.ToDouble(2 * 3.14 * PublicClass.darrXData[i]);
                                if (returnArray[i].ToString() == "NaN")
                                {
                                    returnArray[i] = 0;
                                }
                            }
                            break;
                        }
                }
            }
            catch
            {
            }
            return returnArray;
        }

        public double[] fftMag2(double[] x)
        {
            // assume n is a power of 2
            if (x.Length % 2 == 0)
            {
                n = x.Length;
            }
            else
            {
                n = x.Length;
            }
            nu = (int)(Math.Log(n) * Math.Log(2));
            int n2 = n * 2;
            int nu1 = nu + 1;
            double[] xre = new double[n];
            double[] xim = new double[n];
            double[] mag = new double[n2];
            double tr, ti, p, arg, c, s;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    xre[i] = x[i];
                    xim[i] = 0.0f;
                }
                int k = 0;

                for (int l = 1; l <= nu; l++)
                {
                    while (k < n)
                    {
                        for (int i = 1; i <= n2; i++)
                        {
                            if ((k + n2) < n)
                            {
                                try
                                {
                                    p = bitrev(k >> nu1);
                                    arg = 2 * (double)Math.PI * p / n;
                                    c = (double)Math.Cos(arg);
                                    s = (double)Math.Sin(arg);
                                    tr = xre[k + n2] * c + xim[k + n2] * s;
                                    ti = xim[k + n2] * c - xre[k + n2] * s;
                                    xre[k + n2] = xre[k] - tr;
                                    xim[k + n2] = xim[k] - ti;
                                    xre[k] += tr;
                                    xim[k] += ti;
                                    k++;
                                }
                                catch
                                {
                                }
                            }
                        }
                        k += n2;
                    }
                    k = 0;
                    nu1--;
                    n2 = n2 / 2;
                }
                k = 0;
                int r;
                while (k < n)
                {
                    r = bitrev(k);
                    if (r > k)
                    {
                        tr = xre[k];
                        ti = xim[k];
                        xre[k] = xre[r];
                        xim[k] = xim[r];
                        xre[r] = tr;
                        xim[r] = ti;
                    }
                    k++;
                }

                mag[0] = 0;// (double)(Math.Sqrt(xre[0] * xre[0] + xim[0] * xim[0])) / n;
                for (int i = 1; i < n / 2; i++)
                {
                    //double temp_mag = (double)(Math.Sqrt(xre[i] * xre[i] + xim[i] * xim[i])) / 1000;
                    //double temp_2Per_mag = (2 * temp_mag) / 100;

                    //mag[i] = (float)(Math.Sqrt(xre[i] * xre[i] + xim[i] * xim[i])) / 1000;
                    //mag[i] = temp_mag - temp_2Per_mag;

                    mag[i] = (float)((2 * (float)(Math.Sqrt(xre[i] - xim[i]))) * n);

                    // mag[i] = (float)((2 * (float)(Math.Sqrt(xre[i] * xre[i] + xim[i] * xim[i]))) / n);


                }
            }
            catch { }
            return mag;
        }


        private void bbFFTtoTWF_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                double[] Hz = new double[0];
                double[] mag = new double[0];
                mag = fftMag2(PublicClass.darrYData);
                double lastTimevalue = (double)(PublicClass.darrXData[PublicClass.darrXData.Length - 1]);
                lastTimevalue = Math.Round(lastTimevalue, 2);
                double HzRate = (double)(1 / lastTimevalue);
                for (int i = 0; i < mag.Length; i++)
                {
                    //Array.Resize(ref Hz, Hz.Length + 1);
                    _ResizeArray.IncreaseArrayDouble(ref Hz, 1);
                    Hz[i] = HzRate / i;
                }
                xarrayNew = Hz;
                yarrayNew = mag;
                CurrentXLabel = "Hz";
                if (Hz.Length > 1)
                {
                    DrawLineGraphs(xarrayNew, yarrayNew, "Sec", CurrentYLabel);
                }
            }
            catch { }
        }


        private void barButtonItem9_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmtest test = new frmtest();
            test.ShowDialog();
        }

        private void btnFailureTime_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                frmFailure objFailure = new frmFailure();
                objFailure.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGenerateSpectrum_ItemClick(object sender, ItemClickEventArgs e)
        {
            objMachineCompare = new frmMachineComparision();
            try
            {
                objMachineCompare.GetAllCheckedNode();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}