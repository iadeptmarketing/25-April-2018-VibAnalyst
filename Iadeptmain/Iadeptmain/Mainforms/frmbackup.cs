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
using System.IO;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace Iadeptmain.Mainforms
{
    public partial class frmbackup : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt1 = new DataTable();
        public frmbackup()
        {
            InitializeComponent();
            Fill_DatabaseName();
        }

        BackgroundWorker objWorker = null;

        private void Fill_DatabaseName()
        {
            try
            {
                dt1 = DbClass.getdata(CommandType.StoredProcedure, "CALL DatabaseName('" + PublicClass.currentInstrument + "')");
                foreach (DataRow dr in dt1.Rows)
                {
                    cmbdata.Properties.Items.Add(dr["SCHEMA_NAME"]);
                }
                cmbdata.SelectedIndex = -1;
            }
            catch { }
        }

        private void cmbdata_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtdate.Text = "";
                string dbName = Convert.ToString(cmbdata.SelectedItem);
                DataTable dt = DbClass.getdata(CommandType.Text, "Select DataBaseName , max(BackupDateTime) as BackupDateTime from " + dbName + ".database_backup where DataBaseName = '" + dbName + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToString(dr["BackupDateTime"]) == "" || Convert.ToString(dr["BackupDateTime"]) == null)
                    {
                        txtdate.Text = "Still BackUp not taken";
                        txtdate.Enabled = false;
                    }
                    else
                    {
                        txtdate.Text = Convert.ToString(dr["BackupDateTime"]);
                        txtdate.Enabled = false;
                    }
                }

            }
            catch { }
        }

        private void UpdateDbNamnes(string DbName)
        {
            try
            {
                PublicClass.statusbar(bkpProBar);
                DbClass.executequery(CommandType.Text, "Update " + DbName + ".database_backup set BackupDateTime = '" + PublicClass.GetDatetime() + "' where DataBaseName = '" + DbName + "'");
                PublicClass.statusbar(bkpProBar);
            }

            catch (Exception ex)
            {
            }
        }

         private void InsertDbNamnes(string DbName)
        {
             try
             {
                 PublicClass.statusbar(bkpProBar);
                 DbClass.executequery(CommandType.Text, "insert into "+DbName+".database_backup(DataBaseName,BackupDateTime) values ('" + DbName + "','" + PublicClass.GetDatetime() + "')");
                 PublicClass.statusbar(bkpProBar);
             }
           
            catch (Exception ex)
            {
            }
        }

        string strInsert = null;
        bool selcetDataBase = false;
        bool bkpcancel = false;

        public void bacupDataBase()
        {
            try
            {
                PublicClass.statusbar(bkpProBar);
                string server = "localhost";
                string uid = "root";
                string password = "1234";
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                PublicClass.statusbar(bkpProBar);
                string constring = "SERVER=localhost ; DATABASE=" + strInsert + "; UID=root; PASSWORD=1234 ;Convert Zero Datetime=true; Allow Zero Datetime=true";
                PublicClass.statusbar(bkpProBar);
                string file = path +"\\" + strInsert + ".sql";
                PublicClass.statusbar(bkpProBar);
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    PublicClass.statusbar(bkpProBar);
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        PublicClass.statusbar(bkpProBar);
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            PublicClass.statusbar(bkpProBar);
                            cmd.Connection = conn;
                            PublicClass.statusbar(bkpProBar);
                            conn.Open();
                            PublicClass.statusbar(bkpProBar);
                            mb.ExportToFile(file);
                            PublicClass.statusbar(bkpProBar);                            
                            conn.Close();
                            
                        }
                    }
                }
            }
            catch
            {

            }
        }

        string can = null;
        private void btnbackup_Click(object sender, EventArgs e)
        {
            try
            {
                bkpcancel = false;
                strInsert = Convert.ToString(cmbdata.SelectedItem);
                if (strInsert != "")
                {
                    this.Enabled = false;
                    frmBackupdatabaseNew objBackup = new frmBackupdatabaseNew();
                    dt1 = DbClass.getdata(CommandType.StoredProcedure, "CALL DatabaseName('"+PublicClass.currentInstrument+"')");
                    string strOldName = null;
                    foreach (DataRow dr in dt1.Rows)
                    {
                        strOldName = (string)dr["SCHEMA_NAME"];
                        if (strOldName == strInsert)
                        {
                            selcetDataBase = true;
                            break;
                        }
                    }
                    if (selcetDataBase == true)
                    {
                        string str = "'";
                        DialogResult DrSelect = MessageBox.Show("Press Yes to create Backup of " + str + strInsert + str + " with another name." + "\n" + "Press No to create Backup of " + str + strInsert + str + " with same name.", "Database BackUp Process", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                  
                        if (DrSelect == DialogResult.Yes)
                        {
                            PublicClass.sBkpDBName = Convert.ToString(cmbdata.SelectedItem);
                            objBackup.strDataName = strInsert;
                            objBackup.ShowDialog();
                            if (objBackup.BackupClose == false)
                            {
                                PublicClass.statusbar(bkpProBar);
                                DataTable dt2 = DbClass.getdata(CommandType.Text, "Select * from " + strInsert + ".database_backup");
                                if (dt2.Rows.Count > 0)
                                {
                                    UpdateDbNamnes(strInsert);
                                }
                                else
                                {
                                    InsertDbNamnes(strInsert);
                                }
                                this.Enabled = true;
                                txtdate.Text = "";
                                PublicClass.statusbar(bkpProBar);
                                cmbdata.SelectedItem = "--Select--";
                                PublicClass.statusbar(bkpProBar);
                            }
                            else if (objBackup.frmBackupClose == true)
                            {
                                this.Enabled = true;
                                PublicClass.statusbar(bkpProBar);
                            }
                        }
                        else if (DrSelect == DialogResult.No)
                        {
                            PublicClass.a = 0;
                            PublicClass.statusbar(bkpProBar);
                            try
                            {
                                PublicClass.statusbar(bkpProBar);
                                bacupDataBase();
                                DataTable dt2 = DbClass.getdata(CommandType.Text, "Select * from " + strInsert + ".database_backup");
                                if(dt2.Rows.Count> 0)
                                {
                                    UpdateDbNamnes(strInsert);
                                }
                                else
                                {
                                    InsertDbNamnes(strInsert);
                                }
                                PublicClass.statusbar(bkpProBar);
                                this.Enabled = true;
                                txtdate.Text = "";
                                cmbdata.SelectedItem = "--Select--";
                                PublicClass.statusbar(bkpProBar);
                            }
                            catch
                            {

                            }
                            
                        }
                        else if (DrSelect == DialogResult.Cancel)
                        {
                            can = "Cancel";
                            bkpcancel = true;
                            this.Enabled = true;
                            cmbdata.SelectedItem = "--Select--";                        
                            this.Close();
                        }
                        else { }
                    }
                    if (objBackup.Cancel)
                    {
                       bkpProBar.Value = 100;
                       PublicClass.statusbar(bkpProBar);
                       this.Close();
                    }
                    else
                    {
                        if (can!=null)
                        {
                        }
                        else
                        {
                            PublicClass.statusbar(bkpProBar);
                            if (objBackup.BackupClose == false)
                            {
                                bkpProBar.Value = 100;
                                PublicClass.statusbar(bkpProBar);
                                MessageBox.Show("BackUp Process Completed");
                                this.Close();
                            }
                            else { }
                        }
                        
                        }                      
                    }

                else
                {
                    MessageBox.Show("Please Select any database First");
                    return;
                }
            }

            catch
            {

            }


        }

    }
}