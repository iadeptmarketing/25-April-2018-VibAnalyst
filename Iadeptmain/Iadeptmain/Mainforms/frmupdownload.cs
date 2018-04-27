using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Iadeptmain.GlobalClasess;
using Iadeptmain.GlobalClasses;
using Iadeptmain.Classes;
using System.IO;
using System.Data.Odbc;
using Iadeptmain.Images;
using trial6;
using DevExpress.XtraSplashScreen;
using System.Management;
using System.IO.Ports;


namespace Iadeptmain.Mainforms
{
    public partial class frmupdownload : DevExpress.XtraEditors.XtraForm
    {        
        public delegate void ShowStatusMessageHandler();
        frmupdownload objupdown = null;
        frmUpload upload = null;
        frmdownload download = null;
        frmIAdeptMain _objMain;
        ShowStatusMessageHandler m_objToShowString = null;
        private string m_sMessage = null;
        string SerialKeyForImpaq = null;
        private SerialPort m_objSerialPort = null;
        public string check = null;
        public frmupdownload()
        {
            InitializeComponent();
            if (m_objRAPI.DevicePresent)
            {
                m_objRAPI.Connect();
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    GetSrialKeyForImpaq();
                    if (SerialKeyForImpaq != null)
                    {
                        PublicClass.InstrumentSerial = SerialKeyForImpaq;
                        check = "true";
                        if (PublicClass.currentInstrument == "Impaq-Benstone")
                        {
                            pictureBox2.Image = ImageResources.elite2;
                        }
                        else
                        { pictureBox2.Image = ImageResources.fieldpaqnew; }
                    }
                    else
                    { check = "false"; }
                }
            }
            else
            {
                if (PublicClass.currentInstrument == "SKF/DI")
                {
                    ConnectwithINST();
                    if(DiStatus==true)
                    {
                        check = "true";
                        pictureBox2.Image = ImageResources.fieldpac;
                    }
                    else { check = "true"; }
                }
                else if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    check = "true";
                    pictureBox2.Image = ImageResources.kohtect;
                }
                //else
                //{ check = "true"; }
            }
        }

        bool DiStatus = false;
        private void ConnectwithINST()
        {
            DiStatus = false;
            byte[] arrFiveByte = { 0x05 };
            int BaudRR = 115200;
            try
            {
                string sComPortName = null;
                string[] sComPortName1 = SerialPort.GetPortNames();
                if (sComPortName1.Length > 1)
                {
                    sComPortName = sComPortName1[sComPortName1.Length - 1];
                }
                else
                {
                    sComPortName = sComPortName1[0];
                }
                if (!string.IsNullOrEmpty(sComPortName))
                {
                    m_objSerialPort = new SerialPort(sComPortName, BaudRR, Parity.None, 8, StopBits.One);
                    m_objSerialPort.Open();
                    m_objSerialPort.DtrEnable = true;
                    m_objSerialPort.RtsEnable = true;
                    m_objSerialPort.Write(arrFiveByte, 0, arrFiveByte.Length);
                    m_objSerialPort.Close();
                    DiStatus = true;
                }
            }
            catch
            { DiStatus = false; }            
        }

     
        bool bInstSelected = true;
        public bool IsInstrument
        {
            get
            {
                return bInstSelected;
            }
            set
            {
                bInstSelected = value;
            }
        }
        string sPathtoCopy = null;
        public string PathToUpLoad
        {
            get
            {
                return sPathtoCopy;
            }
            set
            {
                sPathtoCopy = value;
            }
        }

        public frmIAdeptMain MainForm
        {
            get
            {
                return _objMain;
            }

            set
            {
                _objMain = value;

            }
        }

        private string getSerialNo()
        {
            try
            {
                byte[] objbyte = new byte[32];
                byte[] objbytein = new byte[0];             
                if (m_objRAPI.DevicePresent)
                {
                    m_objRAPI.Connect();
                    try
                    {
                        if (m_objRAPI.DeviceFileExists(@"\Windows\DI460RapiDLL.dll"))
                        {
                            m_objRAPI.DeleteDeviceFile(@"\Windows\DI460RapiDLL.dll");
                        }
                        m_objRAPI.CopyFileToDevice(AppDomain.CurrentDomain.BaseDirectory + "DI460RapiDLL.dll", @"\Windows\DI460RapiDLL.dll");
                    }
                    catch { }
                    m_objRAPI.Invoke(@"\Windows\DI460RapiDLL.dll", "DIGetSerialNumber", objbytein, out objbyte);
                    SerialKeyForImpaq = Encoding.ASCII.GetString(objbyte);
                    SerialKeyForImpaq = SerialKeyForImpaq.Trim('\0');
                }
            }
            catch { }
            return SerialKeyForImpaq;
        }

        private string GetSrialKeyForImpaq()
        {          
            try
            {
                string serialKey = null; string pathh = null;
                if (PublicClass.currentInstrument == "FieldPaq2")
                {
                    pathh = "\\Storage Card\\FieldpaqII\\App\\FieldpaqIIApp.ini";
                }
                else
                {
                    pathh = "\\Storage Card\\impaqElite\\App\\ImpaqEliteApp.ini";
                }
                string txtxfilepath = Path.GetTempPath() + @"serial.txt";
                try
                {
                    if (File.Exists(txtxfilepath))
                    {
                        File.WriteAllText(txtxfilepath, String.Empty);
                    }
                    else { }
                }
                catch { }
                m_objRAPI.CopyFileFromDevice(txtxfilepath, pathh, true);
                string[] lines = File.ReadAllLines(txtxfilepath);
                serialKey = lines[1];
                string[] serialKeyNew = serialKey.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                SerialKeyForImpaq = serialKeyNew[1];
                SerialKeyForImpaq = SerialKeyForImpaq.Trim();
            }
            catch { }
            return SerialKeyForImpaq;
        }


        internal void ShowMessage(string sMessage)
        {
            try
            {               
               m_sMessage = sMessage;
               // this.Invoke(m_objToShowString);
            }
            catch (Exception ex)
            {               
            }
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            _objMain.lblStatus.Caption = "Status: Uploading Route";
            objupdown = new frmupdownload();
            upload = new frmUpload();
            string text1 = null;
            string CurrentInstName = PublicClass.currentInstrument;
            try
            {
                if (PublicClass.routename != null)
                {
                    upload.SelectedRouteName = PublicClass.routename;
                    upload.ShowDialog();
                    SplashScreenManager.ShowForm(typeof(WaitForm3));
                    IsInstrument = upload.IsInstrumentSelected;
                    if (CurrentInstName == "Kohtect-C911")
                    {
                        try
                        {
                            if (IsInstrument == false)
                            {
                                PathToUpLoad = upload.PCPath;
                                PublicClass.Path = PathToUpLoad;
                            }
                            else
                            {
                                PathToUpLoad = upload.textBox1.Text;
                                PublicClass.Path = PathToUpLoad;
                            }
                            if (upload.IsCancelClicked == false)
                            {
                                clsdb.Main = _objMain;
                                clsdb.C911uploaddata(PublicClass.routename, PublicClass.Path);
                                if (clsdb.check == "true")
                                {
                                    _objMain.lblStatus.Caption = "Status: Uploading Route Successfully In Instrument";
                                    MessageBox.Show("Route Create Sucessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _objMain.ribbonControl1.Enabled = true;
                                    this.Enabled = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("No point In Route", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    _objMain.ribbonControl1.Enabled = true;
                                    this.Enabled = true;
                                    this.Close();
                                }
                                SplashScreenManager.CloseForm();
                            }                            
                        }
                        catch { }
                    }
                    else if (CurrentInstName == "SKF/DI")
                    {
                        try
                        {                           
                            if (IsInstrument == false)
                            {
                                PathToUpLoad = upload.PCPath;
                                PublicClass.Path = PathToUpLoad;
                            }        
                            else
                            {
                                string path = Path.GetTempPath();
                                text1 = upload.textBox1.Text;
                                PathToUpLoad = path + PublicClass.routename + ".dat";
                            }
                            if (upload.IsCancelClicked == false)
                            {                               
                                clsdb.Main = _objMain;                                
                                _objMain.ribbonControl1.Enabled = false;
                                this.Enabled = false;
                                if (text1 == null)
                                {
                                    clsdb.UsbSelected = true;
                                    clsdb.DIuploaddata(PublicClass.routename);
                                    if (clsdb.check == "true")
                                    {
                                        _objMain.lblStatus.Caption = "Status: Uploading Route Successfully In Instrument";
                                        MessageBox.Show("Route Create Sucessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        SplashScreenManager.CloseForm();
                                        _objMain.ribbonControl1.Enabled = true;
                                        this.Enabled = true;
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("No point In Route", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        SplashScreenManager.CloseForm();
                                        _objMain.ribbonControl1.Enabled = true;
                                        this.Enabled = true;
                                        this.Close();
                                    }
                                }
                                else
                                {  
                                    clsdb.DIuploaddata(PublicClass.routename);
                                    if (clsdb.check == "true")
                                    {
                                        _objMain.lblStatus.Caption = "Status: Uploading Route Successfully In Instrument";
                                        MessageBox.Show("Route Create Sucessfully In Instrument", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        //SplashScreenManager.CloseForm();
                                        _objMain.ribbonControl1.Enabled = true;
                                        this.Enabled = true;
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("No point In Route", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        //SplashScreenManager.CloseForm();
                                        _objMain.ribbonControl1.Enabled = true;
                                        this.Enabled = true;
                                        this.Close();
                                    }
                                }
                            }
                            else
                            {
                                _objMain.lblStatus.Caption = "Status: Error";
                                MessageBox.Show("Route not Created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Enabled = true;
                                _objMain.ribbonControl1.Enabled = true;
                                this.Close();
                            }
                            SplashScreenManager.CloseForm(); 
                        }
                        catch { SplashScreenManager.CloseForm(); }
                    }
                    else
                    {                       
                        if (IsInstrument == false)
                        {
                            PathToUpLoad = upload.PCPath;
                        }
                        else
                        {
                            if (m_objRAPI.DevicePresent)
                            {
                                m_objRAPI.Connect();
                                string path = Path.GetTempPath();
                                text1 = upload.textBox1.Text;
                                PathToUpLoad = path + PublicClass.routename + ".sdf";
                            }
                            else
                            {
                                SplashScreenManager.CloseForm();
                                MessageBox.Show(this, "Device Not Connected....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        if (upload.IsCancelClicked == false)
                        {
                            _objMain.ribbonControl1.Enabled = false;
                            this.Enabled = false;
                            bool sStatus = CheckDemoSdf();
                            if (sStatus == true)
                            {
                                if (text1 != null)
                                {
                                    getRouteInformation(PublicClass.routename);
                                    UploadData _objupload = new UploadData();
                                    _objupload.Main = _objMain;
                                    _objupload.UploadValuesToBenstone();
                                    _objMain.lblStatus.Caption = "Status: Uploading Route";
                                    StartTheThread();
                                    _objMain.lblStatus.Caption = "Status: Uploading Route Successfully In Instrument";
                                    MessageBox.Show("Route Create Sucessfully In Instrument", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _objMain.ribbonControl1.Enabled = true;
                                    this.Enabled = true;
                                }
                                else
                                {
                                    getRouteInformation(PublicClass.routename);
                                    UploadData _objupload = new UploadData();
                                    _objupload.Main = _objMain;
                                    _objupload.UploadValuesToBenstone();
                                    _objMain.lblStatus.Caption = "Status: Uploading Route Successfully";
                                    MessageBox.Show("Route Create Sucessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    _objMain.ribbonControl1.Enabled = true;
                                    this.Enabled = true;
                                }
                            }
                            else
                            {
                                _objMain.lblStatus.Caption = "Status: Error";
                                MessageBox.Show("Route not Created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Enabled = true;
                                _objMain.ribbonControl1.Enabled = true;
                                this.Close();
                            }
                        }
                        if (PublicClass.routename != null)
                        {
                            this.Close();
                        }
                        SplashScreenManager.CloseForm();
                    }
                }
            }
            catch { SplashScreenManager.CloseForm(); }
        }


        RAPI m_objRAPI = new RAPI();
        private void StartTheThread()
        {
            try
            {
                try
                {
                    m_objRAPI.Connect();
                    if (m_objRAPI.DevicePresent)
                    {
                        if (PublicClass.currentInstrument == "Impaq-Benstone")
                        {
                            m_objRAPI.CopyFileToDevice(PathToUpLoad, @"\Storage Card\ImpaqElite" + CValues.SCONSTDCD + PublicClass.routename + CValues.SCONSTDBF, true);
                        }
                        else
                        { m_objRAPI.CopyFileToDevice(PathToUpLoad, @"\Storage Card\FieldpaqII" + CValues.SCONSTDCD + PublicClass.routename + CValues.SCONSTDBF, true); }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {               
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        OdbcCommand objCommand = null;
        OdbcDataReader objdataReader = null;
        private void getRouteInformation(string sRouteName)
        {
            string Uptime = null;
            string DnTime = null;
            string UpDn = null;
            OdbcDataReader objReader = null;
            try
            {
               _objMain.lblStatus.Caption="Generating Route Information";
               DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select rdd.ID,rdd.Route_Name,rdd.Route_Level,rdd.DatabaseName,rdd.Date,rd1.Type_ID from route.route_data rdd inner join route.route_data1 rd1 on rdd.ID=rd1.ID where rdd.Route_Name='" + PublicClass.routename + "' order by ID asc");

                foreach (DataRow dr in dt.Rows)
                {
                    string id = Convert.ToString(dr["id"]);
                    string routename = Convert.ToString(dr["Route_Name"]);
                    string routelevel = Convert.ToString(dr["Route_Level"]);
                    string routelevelid = Convert.ToString(dr["Type_Id"]);
                    string databasename = Convert.ToString(dr["DatabaseName"]);
                    string date = Convert.ToString(dr["date"]);
                }

                string currdatabase = "use "+ PublicClass.databasename;
             
            }
            catch (Exception ex)
            {               
            }
        }

        string versionoption = "Elite";
        bool status = false;
        public bool CheckDemoSdf()
        {
            string[] sfilepath = PathToUpLoad.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < sfilepath.Length - 1; i++)
            {
                sb.Append(Convert.ToString(sfilepath[i] + "\\"));
            }
            string filepath = Convert.ToString(sb);
            PublicClass.finalpath = Convert.ToString(PathToUpLoad).Trim();
            try
            {
                CreateSdfFile objsdfCrt = new CreateSdfFile();
                if (Directory.Exists(filepath))
                {
                    if (File.Exists(PathToUpLoad))
                    {
                        File.Delete(PathToUpLoad);
                    }
                    objsdfCrt.MainForm = _objMain;
                    objsdfCrt.CreateDatabaseInSdfFormat(versionoption);

                    status = true;
                }
                else
                {
                    Directory.CreateDirectory(filepath);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;                

            }
            return status;
        }

        ClsSdftodb clsdb = new ClsSdftodb();
        private void btndownload_Click(object sender, EventArgs e)
        {
            _objMain.lblStatus.Caption = "Status: Start to Download Data From Instrument";
            download = new frmdownload();
            string CurrentInstName = PublicClass.currentInstrument;
            try
            {
                if (CurrentInstName == "SKF/DI")
                {
                    clsdb.Main = _objMain;
                    clsdb.callconnection();                    
                    this.Close();
                }
                else if (CurrentInstName == "Kohtect-C911")
                {
                    clsdb.Main = _objMain;
                    clsdb.C911callconnection();
                    this.Close();
                }
                else
                {
                    UploadData down = new UploadData();
                    down.Main = _objMain;
                    down.CallCheckConnections();
                    this.Close();
                }
            }
            catch 
            {
                MessageBox.Show(this, "Error in Download", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}