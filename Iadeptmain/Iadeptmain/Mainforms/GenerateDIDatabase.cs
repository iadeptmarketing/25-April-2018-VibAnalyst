using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.IO.Ports;
using DevExpress.XtraSplashScreen;
using Iadeptmain.Classes;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Mainforms
{
    public partial class GenerateDIDatabase : DevExpress.XtraEditors.XtraForm
    {
        public GenerateDIDatabase()
        {
            InitializeComponent();
        }
        bool bCancel = true;
        public bool IsCancelClicked
        {
            get
            {
                return bCancel;
            }
            set
            {
                bCancel = value;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {           
            if (PublicClass.currentInstrument == "SKF/DI")
            {
                if (_objgenDi.m_objSerialPort.IsOpen == true)
                {
                    _objgenDi.m_objSerialPort.Write("\x06");
                    _objgenDi.m_objSerialPort.Write("\x04");
                    _objgenDi.m_objSerialPort.Close();
                }
            }
            bCancel = true; this.Close();
        }

        #region Constants
        string RouteNumbers = null;
       
        #endregion
        ClsSdftodb _objgenDi = new ClsSdftodb();
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_objgenDi.m_objSerialPort.IsOpen == true)
                {
                    _objgenDi.m_objSerialPort.Write("\x06");
                    _objgenDi.m_objSerialPort.Write("\x04");
                    _objgenDi.m_objSerialPort.Close();
                }
                if (_objgenDi.m_objSerialPort.IsOpen == false)
                {
                    _objgenDi.ConnectwithINST();
                    listDB.Items.Clear();
                    if (_objgenDi.DiStatus == true)
                    {
                        RouteNumbers = _objgenDi.sblRtNumbers.ToString();
                        for (int a = 0; a < _objgenDi.Routename.Length - 1; a++)
                        {
                            string[] Routename1 = Convert.ToString(_objgenDi.Routename[a]).Split('|');
                            listDB.Items.Add(Routename1[0]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Device Not Connected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch { }
        }

        private void rbPhysicalDimensions_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbPhysicalDimensions.Checked)
                {
                    listDB.Enabled = true;
                    btnConnect.Enabled = true;
                    btnBrowse.Enabled = false;
                    txtdbpath.Text = "";
                    txtdbpath.Enabled = false;
                }
                else
                {
                    listDB.Enabled = false;
                    btnConnect.Enabled = false;
                    btnBrowse.Enabled = true;
                    txtdbpath.Text = "";
                    txtdbpath.Enabled = true;
                }
            }
            catch { }
        }

         string spath = null;
        string sPathtosave = null;
        public string PCPath
        {
            get
            {
                return sPathtosave;
            }
            set
            {
                sPathtosave = value;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog saveFileDialog = new OpenFileDialog();
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "IMXA Data File (.dat)|*.dat";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.DefaultExt = ".dat";
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.ShowDialog();
                spath = saveFileDialog.FileName.ToString();
                if (!string.IsNullOrEmpty(spath))
                {
                    txtdbpath.Text = spath;
                    btnok.Enabled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        string sDB = null;
        public string PCDB
        {
            get
            {
                return sDB;
            }
            set
            {
                sDB = value;
            }
        }

        string sInst = null;
        public string Instrument
        {
            get
            {
                return sInst;
            }
            set
            {
                sInst = value;
            }
        }
        public bool st = false;
        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                bCancel = false;
                if (PublicClass.currentInstrument == "SKF/DI")
                {
                    if (rbPhysicalDimensions.Checked == true)
                    {
                        if (!string.IsNullOrEmpty(listDB.Text.ToString()))
                        {
                            if (!string.IsNullOrEmpty(txtdb.Text.ToString()))
                            {
                                sPathtosave = listDB.Text.ToString();
                                sDB = txtdb.Text.ToString();

                                frmNewDataBaseCreation objDBCreate = new frmNewDataBaseCreation();
                                if (PublicClass.ValidateDatabase(sDB))
                                {
                                    SplashScreenManager.ShowForm(typeof(WaitForm2));
                                    st = objDBCreate.CreateDataBase(Convert.ToString(sDB).Trim(), st);
                                }
                                else
                                {
                                    MessageBox.Show(this, "Only alphanumeric characters used for Database Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtdb.Text = "";
                                    return;
                                }
                                if (st)
                                {
                                    try
                                    {
                                        _objgenDi.PCPath = sPathtosave;
                                        _objgenDi.Directdownload(sDB, listDB.SelectedIndex);
                                        if (_objgenDi.checkbool == "false")
                                        {
                                            DbClass.executequery(CommandType.Text, "Select Database_name as SCHEMA_NAME from route.databasename where InstrumentName='" + PublicClass.currentInstrument + "' && Database_name!='" + sDB + "'");
                                            Status.Text = "Connection Error..";
                                            MessageBox.Show(this, "Connection Error..Connect Device Properly", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            _objgenDi.m_objSerialPort.Write("\x06");
                                            _objgenDi.m_objSerialPort.Write("\x04");
                                            _objgenDi.m_objSerialPort.Close();
                                            SplashScreenManager.CloseForm();
                                            return;
                                        }
                                        else
                                        {
                                            if (_objgenDi.m_objSerialPort.IsOpen == true)
                                            {
                                                _objgenDi.m_objSerialPort.Write("\x06");
                                                _objgenDi.m_objSerialPort.Write("\x04");
                                                _objgenDi.m_objSerialPort.Close();
                                                SplashScreenManager.CloseForm();
                                            }
                                            this.Close();
                                        }
                                    }
                                    catch { }
                                }
                                else
                                {
                                    txtdb.Text = string.Empty;
                                    SplashScreenManager.CloseForm();
                                }
                            }
                            else
                            {
                                Status.Text = "Please Fill Database Name";
                                MessageBox.Show(this, "Please Fill Database Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            Status.Text = "Select any Database Route Name";
                            MessageBox.Show(this, "Select any Database Route Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(txtdbpath.Text.ToString()))
                        {
                            if (!string.IsNullOrEmpty(txtdb.Text.ToString()))
                            {
                                sDB = txtdb.Text.ToString();
                                frmNewDataBaseCreation objDBCreate = new frmNewDataBaseCreation();
                                if (PublicClass.ValidateDatabase(sDB))
                                {
                                    SplashScreenManager.ShowForm(typeof(WaitForm2));
                                    st = objDBCreate.CreateDataBase(Convert.ToString(sDB).Trim(), st);
                                }
                                else
                                {
                                    MessageBox.Show(this, "Only alphanumeric characters may be used in Database Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtdb.Text = "";
                                    return;
                                }
                                if (st)
                                {                                   
                                    _objgenDi.GenerateNewRouteFromFile(spath);
                                    bCancel = false;
                                    this.Close();
                                }
                            }
                            else
                            {
                                Status.Text = "Fill Database Name";
                                MessageBox.Show(this, "Please Fill Database Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            Status.Text = "Select any .DAT file";
                            MessageBox.Show(this, "Select any .DAT file", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch { }
        }

        private void GenerateDIDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                listDB.Enabled = false;
                btnConnect.Enabled = false;
                btnBrowse.Enabled = false;
                txtdbpath.Text = "";
                txtdbpath.Enabled = false;
            }
            catch { }
        }

    }
}