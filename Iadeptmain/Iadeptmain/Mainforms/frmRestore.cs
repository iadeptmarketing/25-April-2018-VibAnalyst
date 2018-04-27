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
using Iadeptmain.GlobalClasses;
using MySql.Data.MySqlClient;

namespace Iadeptmain.Mainforms
{
    public partial class frmRestore : DevExpress.XtraEditors.XtraForm
    {
        public frmRestore()
        {
            InitializeComponent();
           
        }

        private void btnDBRestore_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtNewDBName.Text).Trim() == "")
                {
                    MessageBox.Show(this, "DataBase Name can't be Blank", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '" + txtNewDBName.Text.Trim() + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(this, "This DataBase is Already Exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (PublicClass.ValidateDatabase(Convert.ToString(txtNewDBName.Text).Trim()))
                    {


                        PublicClass.statusbar(dbRestoreProgbar);
                        DbClass.executequery(CommandType.Text, "CREATE database  " + Convert.ToString(txtNewDBName.Text).Trim() + " ");
                        PublicClass.statusbar(dbRestoreProgbar);
                        string constring = "SERVER=localhost ; DATABASE=" + Convert.ToString(txtNewDBName.Text).Trim() + "; UID=root; PASSWORD=1234 ;Convert Zero Datetime=true; Allow Zero Datetime=true";
                        PublicClass.statusbar(dbRestoreProgbar);
                        using (MySqlConnection conn = new MySqlConnection(constring))
                        {
                            PublicClass.statusbar(dbRestoreProgbar);
                            using (MySqlCommand cmd = new MySqlCommand())
                            {
                                PublicClass.statusbar(dbRestoreProgbar);
                                using (MySqlBackup mb = new MySqlBackup(cmd))
                                {
                                    PublicClass.statusbar(dbRestoreProgbar);
                                    cmd.Connection = conn;
                                    PublicClass.statusbar(dbRestoreProgbar);
                                    conn.Open();
                                    PublicClass.statusbar(dbRestoreProgbar);
                                    try
                                    {
                                        mb.ImportFromFile(spath);
                                    }

                                    catch { }
                                    PublicClass.statusbar(dbRestoreProgbar);
                                    conn.Close();
                                    PublicClass.statusbar(dbRestoreProgbar);
                                    PublicClass.statusbar(dbRestoreProgbar);
                                    PublicClass.statusbar(dbRestoreProgbar);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Only alphanumeric characters may be used in Database Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNewDBName.Text = "";
                        return;
                    }
                    PublicClass.CreateConnection("route");
                    PublicClass.statusbar(dbRestoreProgbar);
                    DbClass.executequery(CommandType.Text, "Insert into databasename(Database_Name,InstrumentName)values('" + Convert.ToString(txtNewDBName.Text).Trim() + "','" + PublicClass.currentInstrument + "')");
                    PublicClass.statusbar(dbRestoreProgbar);
                    DbClass.executequery(CommandType.Text, "Update lastdatabase set DBName= '" + Convert.ToString(txtNewDBName.Text).Trim() + "' where UserName = '" + PublicClass.cUserName + "' ");
                    PublicClass.statusbar(dbRestoreProgbar);
                    PublicClass.statusbar(dbRestoreProgbar);
                    PublicClass.CreateConnection(Convert.ToString(txtNewDBName.Text).Trim());
                    PublicClass.statusbar(dbRestoreProgbar);
                    dbRestoreProgbar.Value = 100;
                    PublicClass.flagAlarm = true;
                    this.Close();
                }
            }
            catch
            {

            }
        }

        public bool stscancel = false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            stscancel = true;
        }

        string dbName = null;
        string spath = null;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog saveFileDialog1 = new OpenFileDialog();
                saveFileDialog1.Filter = "SQL Files|*.sql";
                saveFileDialog1.ShowDialog();
                spath = saveFileDialog1.FileName.ToString();
                string[] sfilepath = spath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
                dbName = sfilepath[sfilepath.Length - 1];
                string[] sfilepath1 = dbName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                dbName = sfilepath1[sfilepath1.Length - 1];
                if (dbName == "sql")
                {
                    if (!string.IsNullOrEmpty(spath))
                    {

                        txtDBName.Text = sfilepath1[0]+".sql";
                    }
                }
                else
                {
                    MessageBox.Show(this, "Please Select only .Sql File", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
            }
        }

        private void txtNewDBName_KeyPress(object sender, KeyPressEventArgs e)
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