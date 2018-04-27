using DevExpress.XtraSplashScreen;
using Iadeptmain.Classes;
using Iadeptmain.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Iadeptmain.Mainforms
{
    public partial class GeneratingfromSdf : DevExpress.XtraEditors.XtraForm
    {
        public GeneratingfromSdf()
        {
            InitializeComponent();           
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    if (rbfolder.Checked == true)
                    {
                        FolderBrowserDialog fbd = new FolderBrowserDialog();
                        DialogResult result = fbd.ShowDialog();
                        if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            spath = fbd.SelectedPath.ToString();
                            if (!string.IsNullOrEmpty(spath))
                            {
                                textBox2.Text = spath;
                                btnok.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        OpenFileDialog saveFileDialog = new OpenFileDialog();
                        saveFileDialog.InitialDirectory = "c:\\";
                        saveFileDialog.Filter = "FFT File (.fft)|*.fft";
                        saveFileDialog.FilterIndex = 1;
                        saveFileDialog.DefaultExt = ".fft";
                        saveFileDialog.RestoreDirectory = true;
                        saveFileDialog.ShowDialog();
                        spath = saveFileDialog.FileName.ToString();
                        if (!string.IsNullOrEmpty(spath))
                        {
                            textBox2.Text = spath;
                            btnok.Enabled = true;
                        }
                    }
                }
                else
                {
                    OpenFileDialog saveFileDialog = new OpenFileDialog();
                    saveFileDialog.InitialDirectory = "c:\\";
                    saveFileDialog.Filter = "SqlCE File (.sdf)|*.sdf";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.DefaultExt = ".sdf";
                    saveFileDialog.RestoreDirectory = true;

                    saveFileDialog.ShowDialog();
                    spath = saveFileDialog.FileName.ToString();
                    if (!string.IsNullOrEmpty(spath))
                    {
                        textBox2.Text = spath;
                        btnok.Enabled = true;
                    }
                }
            }
            catch 
            {
            }
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
        public bool st = false;
        private void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.a = 0;
                bCancel = false;
                if (!string.IsNullOrEmpty(textBox2.Text.ToString()))
                {
                    if (!string.IsNullOrEmpty(txtdb.Text.ToString()))
                    {
                        sPathtosave = textBox2.Text.ToString();
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
                            if (PublicClass.currentInstrument == "Kohtect-C911")
                            {
                                try
                                {
                                    clsC911 clsdb = new clsC911(); clsdb.PCPath = textBox2.Text;
                                    string routefile = null; string areaname = null; string trainname = null; string machinename = null; string pointname = null;
                                    if (rbfolder.Checked == true)
                                    {
                                        string name = "DefaultPlant";
                                        clsdb.InsertItemsInDataBase("Plant", null, name + "|" + "Plant");
                                        string[] dirs = Directory.GetDirectories(sPathtosave);
                                        for (int i = 0; i < dirs.Length;i++ )
                                        {
                                            string area = dirs[i];
                                            if (area != null)
                                            {
                                                string[] split = area.Split(new char[] { '\\' });
                                                areaname = split[7];
                                                DataTable dt = DbClass.getdata(CommandType.Text, "select * from area_info");
                                                if(dt.Rows.Count>0)
                                                { 
                                                    clsdb.facid = Convert.ToString(dt.Rows[0]["Area_ID"]); 
                                                }
                                                clsdb.InsertItemsInDataBase("Area", clsdb.facid, areaname + "|" + "Area");
                                            }
                                            string[] dirs1 = Directory.GetDirectories(area);
                                            for (int a = 0; a < dirs1.Length; a++)
                                            {
                                                string train = dirs1[a];
                                                if (train != null)
                                                {
                                                    string[] split = train.Split(new char[] { '\\' });
                                                    trainname = split[8];
                                                    clsdb.InsertItemsInDataBase("Train", clsdb.facid, trainname + "|" + "Train");
                                                }
                                                string[] dirs2 = Directory.GetDirectories(train);
                                                for (int t = 0; t < dirs2.Length; t++)
                                                {
                                                    string Mach = dirs2[t];
                                                    if (Mach != null)
                                                    {
                                                        string[] split = Mach.Split(new char[] { '\\' });
                                                        machinename = split[9];
                                                        clsdb.InsertItemsInDataBase("Machine", clsdb.facid, machinename + "|" + "Machine");                                                        
                                                    }
                                                    //string[] dirs3 = Directory.GetDirectories(Mach);

                                                    //t++;
                                                    //--------creating hirerchy-------//
                                                   
                                                    
                                                   // clsdb.datatransfer(sDB, areaname, trainname, machinename, routefile);
                                                }
                                                //a++;
                                            }
                                          //  i++;
                                        }
                                      
                                    }
                                    else
                                    {                                       
                                        clsdb.datatransfer(sDB, textBox2.Text);
                                    }
                                }
                                catch { }
                            }
                            else
                            {
                                ClsSdftodb clsdb = new ClsSdftodb();
                                clsdb.PCPath = sPathtosave;
                                clsdb.alltransfer(sDB);
                            }
                            SplashScreenManager.CloseForm();
                            this.Close();
                        }
                        else
                        {
                            txtdb.Text = string.Empty;
                            SplashScreenManager.CloseForm();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Please Fill Database Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Select any .SDF file", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bCancel = true; this.Close();
        }

        private void txtdb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PublicClass.chkTxtboxKey(e))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
