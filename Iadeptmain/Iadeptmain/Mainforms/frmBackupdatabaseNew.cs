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
using System.IO;
using Iadeptmain.GlobalClasses;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace Iadeptmain.Mainforms
{
    public partial class frmBackupdatabaseNew : DevExpress.XtraEditors.XtraForm
    {

        public frmBackupdatabaseNew()
        {
            InitializeComponent();
        }
        string constring1 = "server= localhost; User=root; Database= " + PublicClass.User_DataBase.Trim() + "";
        string constring = "DRIVER= {MySQL ODBC 3.51 Driver}; server= localhost; Database= " + PublicClass.User_DataBase.Trim() + "; User=root";
        private void frmBackupdatabaseNew_Load(object sender, EventArgs e)
        {

        }
        public bool frmBackupClose = false;
        public bool BackupClose
        {
            get
            {
                return frmBackupClose;
            }
        }

        public string strDataName
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }
        string strName = null;
        string SystemPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        bool selcetDataBase = false;

       public void btnOK_Click(object sender, EventArgs e)
        {
            try
            {                
                string strNewName = txtDataName.Text.ToLower();
                {
                    if (selcetDataBase == true)                    {
                        MessageBox.Show("This DataBase Already Exist");
                        txtDataName.Text = "";                  
                        selcetDataBase = false;
                        txtDataName.Focus();
                    }
                    else
                    {
                        
                        string[] Directories = null;
                        string[] Drct = null;
                        bool BkpExist = false;
                        try
                        {
                            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\data"))
                            {
                                Directories = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "\\data");
                                if (Directories.Length >= 1)
                                {
                                    for (int i = 0; i < Directories.Length; i++)
                                    {
                                        int CountIndex = Directories[i].LastIndexOf('.');
                                        string strSub = Directories[i].Substring(0, CountIndex);
                                        Drct = strSub.Split(new string[] { AppDomain.CurrentDomain.BaseDirectory + "\\data\\" }, StringSplitOptions.RemoveEmptyEntries);
                                        if (strNewName == Drct[0].ToString())
                                        {
                                            BkpExist = true;
                                        }
                                    }
                                }
                            }
                        }
                        catch { }
                        if (BkpExist == true)
                        {
                            MessageBox.Show("This Name is already Exist");
                            BkpExist = false;
                            txtDataName.Text = "";
                            txtDataName.Focus();
                        }
                        else
                        {
                           // PublicClass.a = 0;
                           // PublicClass.statusbar(bkpNewProBar);

                            char space = ' ';
                            string name = strDataName;
                            string DataBaseName = strNewName;
                            DataBaseName = DataBaseName.TrimEnd(new char[] { space });
                            DataBaseName = DataBaseName.TrimStart(new char[] { space });
                            char[] ChkNameValues = DataBaseName.ToCharArray();
                            if (ChkNameValues[0] < 48 || ChkNameValues[0] > 57)
                            {
                                if (DataBaseName != "")
                                {
                                    PublicClass.a = 0;
                                    PublicClass.statusbar(bkpNewProBar);
                                    if (DataBaseName.Length < 64)
                                    {
                                        PublicClass.statusbar(bkpNewProBar);
                                        if (DataBaseName.Contains(" "))
                                        {
                                            MessageBox.Show("Please avoid space in DataBase Name");//////\
                                            txtDataName.Text = "";
                                            txtDataName.Focus();
                                        }
                                            
                                        else
                                        {
                                            try
                                            {

                                                PublicClass.statusbar(bkpNewProBar);
                                                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                                string constring = "SERVER=localhost ; DATABASE=" + PublicClass.sBkpDBName + "; UID=root; PASSWORD=1234 ;Convert Zero Datetime=true; Allow Zero Datetime=true";
                                                PublicClass.statusbar(bkpNewProBar);
                                                string file = path +"\\"+ strNewName + ".sql";
                                                PublicClass.statusbar(bkpNewProBar);
                                                using (MySqlConnection conn = new MySqlConnection(constring))
                                                {
                                                    PublicClass.statusbar(bkpNewProBar);
                                                    using (MySqlCommand cmd = new MySqlCommand())
                                                    {
                                                        PublicClass.statusbar(bkpNewProBar);
                                                        using (MySqlBackup mb = new MySqlBackup(cmd))
                                                        {
                                                            PublicClass.statusbar(bkpNewProBar);
                                                            cmd.Connection = conn;
                                                            conn.Open();
                                                            PublicClass.statusbar(bkpNewProBar);
                                                            mb.ExportToFile(file);
                                                            PublicClass.statusbar(bkpNewProBar);
                                                            conn.Close();

                                                        }
                                                    }
                                                }
                                            }
                                            catch
                                            {

                                            }
                                            bkpNewProBar.Value = 100;
                                            PublicClass.statusbar(bkpNewProBar);
                                            this.Close();
                                            txtDataName.Text = "";
                                        }
                                    }
                                    else if (DataBaseName == "")
                                    {
                                        MessageBox.Show("You Have To Enter New Database Name First", "Database Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtDataName.Text = "";
                                        txtDataName.Focus();
                                    }
                                }

                            }
                            else
                            {
                                MessageBox.Show("Name Can not be Started with numeric character .");
                                txtDataName.Text = "";
                                txtDataName.Focus();
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter Valid DataBaseName");
                txtDataName.Text = "";
                txtDataName.Focus();
                
            }
        }
       public bool Cancel = false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel = true;
            this.Close();
        }

        private void txtDataName_KeyPress(object sender, KeyPressEventArgs e)
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