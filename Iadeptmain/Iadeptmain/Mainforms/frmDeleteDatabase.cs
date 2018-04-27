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

namespace Iadeptmain.Mainforms
{
    public partial class frmDeleteDatabase : DevExpress.XtraEditors.XtraForm
    {
        public frmDeleteDatabase()
        {
            InitializeComponent();
            Fill_Database();
        }


        private void Fill_Database()
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = DbClass.getdata(CommandType.Text, "Select Database_name as SCHEMA_NAME from route.databasename where InstrumentName='" + PublicClass.currentInstrument + "' && Database_name!='" + PublicClass.User_DataBase + "'");
                foreach (DataRow dr in dt1.Rows)
                {
                    cmbExtDatabase.Properties.Items.Add(dr["SCHEMA_NAME"]);
                }
                cmbExtDatabase.SelectedIndex = -1;
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string cDatabase = Convert.ToString(cmbExtDatabase.SelectedItem);
                if (cDatabase != "")
                {
                    if (cDatabase == (PublicClass.User_DataBase))
                    {
                        MessageBox.Show(this, "Database is in Use", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "Drop database " + cDatabase + "");
                        DbClass.executequery(CommandType.Text, "delete from route.databasename where database_name='" + cDatabase + "'");
                        MessageBox.Show(this, "DataBase Deleted Successfully", "Delete Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                { MessageBox.Show(this, "Please Select Any Database", "Delete Database", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            }
            catch
            { }
        }
    }
    
}