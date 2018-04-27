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
    public partial class frmUserDetail : DevExpress.XtraEditors.XtraForm
    {


        frmIAdeptMain _objMain;
        frmUserEntry uEntry = null;
        public frmUserDetail()
        {
            InitializeComponent();
            ShowUserDetail();           
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

        public void ShowUserDetail()
        {
            dgvUserDetail.Rows.Clear();
            try
            {

                
                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.Text, " SELECT * FROM userdetail");
                int b = 0;
                foreach (DataRow dr in dtt.Rows)
                {                   
                    dgvUserDetail.Rows.Add();
                    dgvUserDetail.Rows[b].Cells["colUserName"].Value = Convert.ToString(dr["UserName"]);
                    dgvUserDetail.Rows[b].Cells["colPassword"].Value = Convert.ToString(dr["Password"]);
                    dgvUserDetail.Rows[b].Cells["colLogin"].Value = Convert.ToString(dr["Login"]);
                    dgvUserDetail.Rows[b].Cells["colLoginDate"].Value = Convert.ToString(dr["LastloginDate"]);
                    dgvUserDetail.Rows[b].Cells["colID"].Value = Convert.ToString(dr["ID"]);
                    dgvUserDetail.Rows[b].Cells["colDatabase"].Value = Convert.ToString(dr["DatabaseName"]);
                    dgvUserDetail.Rows[b].Cells["colSr"].Value = b + 1;
                    b = b + 1;
                }
            }
            catch
            { }
 
        }

    
        

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                 uEntry = new frmUserEntry("Edit");
                 uEntry.fillEntry();
                uEntry.ShowDialog();
                ShowUserDetail();
            }
            catch 
            {
            }
           
        }

        private void dgvUserDetail_MouseClick(object sender, MouseEventArgs e)
        {
            PublicClass. uName = Convert.ToString(dgvUserDetail.CurrentRow.Cells[1].Value);
            PublicClass. uPassword = Convert.ToString(dgvUserDetail.CurrentRow.Cells[2].Value);
            PublicClass .uDataBase = Convert.ToString(dgvUserDetail.CurrentRow.Cells[6].Value);
            PublicClass.uID = Convert.ToString(dgvUserDetail.CurrentRow.Cells[5].Value);
            

        }
        
        private void tsbtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                uEntry = new frmUserEntry("Insert");
                uEntry.cmbDataBase.Visible = false;
                uEntry.lblDataBase.Visible = false;
                uEntry.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                uEntry.ShowDialog();
                ShowUserDetail();
            }
            catch
            {
                        
            }
           
        }

        frmUSetings obj = null;
        private void dgvUserDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cName = Convert.ToString(dgvUserDetail.CurrentCell.Value);
            string cUserName = Convert.ToString(dgvUserDetail.CurrentRow.Cells[1].Value);
            string cPassword = Convert.ToString(dgvUserDetail.CurrentRow.Cells[5].Value);
            
            int rIndex = dgvUserDetail.CurrentRow.Index;
            if (cName == "Change Settings")
            {
                obj = new frmUSetings();
                obj.ShowDialog();
            }
            if (cName == "Delete")
            {
                DbClass.executequery(CommandType.Text, "Delete from userdetail where ID =  '" + Convert.ToString(dgvUserDetail.CurrentRow.Cells["colID"].Value) + "'");
                DbClass.executequery(CommandType.Text, "Delete from usersettings where UserDetailID =  '" + Convert.ToString(dgvUserDetail.CurrentRow.Cells["colID"].Value) + "'");
                DbClass.executequery(CommandType.Text, "Delete from login_data where User_ID = '" + PublicClass.uName.Trim() + "' and uPassword = '" + PublicClass.uPassword.Trim() + "'");
                dgvUserDetail.Rows.RemoveAt(rIndex);
            }
        }

        private void frmUserDetail_Load(object sender, EventArgs e)
        {
            try
           {
               if (Convert.ToString(PublicClass.cUserName).Trim() == Convert.ToString(dgvUserDetail.Rows[0].Cells[1].Value).Trim() && Convert.ToString(PublicClass.cPassword).Trim() == Convert.ToString(dgvUserDetail.Rows[0].Cells[2].Value).Trim())
               {
                   dgvUserDetail.CurrentRow.Cells[7].ReadOnly = true;
                   dgvUserDetail.CurrentRow.Cells[8].ReadOnly = true;
               }
               else
               {
                   dgvUserDetail.CurrentRow.Cells[7].ReadOnly = false;
                   dgvUserDetail.CurrentRow.Cells[8].ReadOnly = false;
               }

           }
           catch
           {

           }

        }

        
    }
}