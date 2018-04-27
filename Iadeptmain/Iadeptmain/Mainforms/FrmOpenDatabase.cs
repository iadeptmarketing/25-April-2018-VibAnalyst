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
using System.Data.Odbc;
namespace Iadeptmain.Mainforms
{
    public partial class FrmOpenDatabase : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        public FrmOpenDatabase()
        {
            InitializeComponent();
            Fill_InstruemntName();
            cmbInstName.Enabled = false;
            Fill_DatabaseName();
        }
            
        private void Fill_InstruemntName()
        {
            try
            {
                dt = DbClass.getdata(CommandType.StoredProcedure, "CALL InstrumentName('" + PublicClass.currentInstrument + "')");
                foreach (DataRow dr in dt.Rows)
                {
                    cmbInstName.Properties.Items.Add(dr["instrumentname"]);
                }
                cmbInstName.SelectedIndex = 0;
            }
            catch { }
        }

        private void Fill_DatabaseName()
        {
            try
            {
                dt1 = DbClass.getdata(CommandType.StoredProcedure, "CALL DatabaseName('"+PublicClass.currentInstrument+"')");
                foreach (DataRow dr in dt1.Rows)
                {
                    cmbMySqlFilll.Properties.Items.Add(dr["SCHEMA_NAME"]);
                }
                cmbMySqlFilll.SelectedIndex = -1;
            }
            catch { }
        }

        public bool check1 = false;
        private void btnopen_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbMySqlFilll.Text) == "")
                {
                    MessageBox.Show(this, "DataBase Name can't be Blank", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    PublicClass.CreateConnection("route");
                    DbClass.executequery(CommandType.Text, "Update lastdatabase set DBName= '" + Convert.ToString(cmbMySqlFilll.Text) + "' where UserName = '" + PublicClass.cUserName + "' and InstrumentName='" + PublicClass.currentInstrument + "' ");
                    PublicClass.CreateConnection(Convert.ToString(cmbMySqlFilll.Text));
                    PublicClass.flagAlarm = true;
                    check1 = true;
                    this.Close();
                }
            }
            catch { }
        }

        private void FrmOpenDatabase_Load(object sender, EventArgs e)
        {
            btnopen.Select();
        }
    }
}