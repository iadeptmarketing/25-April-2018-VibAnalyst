using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Mainforms
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.LoginStatus = false;
                this.Close();
            }
            catch { }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string lastdbName = null;
                PublicClass.CreateConnection("route");

                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.Text, "select * from route.lastdatabase where Instrumentname='" + PublicClass.currentInstrument + "'");

                foreach (DataRow dr in dtt.Rows)
                {
                    lastdbName = Convert.ToString(dr["DBName"]);
                }
                PublicClass.User_DataBase = lastdbName;

                if (PublicClass.conn.State == ConnectionState.Open)
                {
                    PublicClass.conn.Close();
                }
                PublicClass.CreateConnection(lastdbName);
                if (String.IsNullOrEmpty(txtID.Text))
                {
                    MessageBox.Show(this, "Please Enter The ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show(this, "Please Enter The Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cmbdata.SelectedIndex == 0)
                {
                    MessageBox.Show(this, "Please Select any Data Source.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PublicClass.cUserName = Convert.ToString(txtID.Text).Trim();
                PublicClass.cPassword = Convert.ToString(txtPassword.Text).Trim();
                DataTable dt1 = new DataTable();
                dt1 = DbClass.getdata(CommandType.Text, "Select ID from userdetail where UserName = '" + PublicClass.cUserName + "'  and Password = '" + PublicClass.cPassword + "'");
                foreach (DataRow dr in dt1.Rows)
                {
                    PublicClass.cUID = Convert.ToString(dr["ID"]);
                }
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "Select distinct  User_ID ,uPassword from login_data where  user_id= '" + Convert.ToString(txtID.Text).Trim() + "' and upassword = '" + Convert.ToString(txtPassword.Text).Trim() + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Please Enter the valid Id and Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = "";
                    txtPassword.Text = "";
                    return;
                }
                else
                {
                    int uchk = String.Compare(Convert.ToString(dt.Rows[0]["User_ID"]), PublicClass.cUserName);
                    int pchk = String.Compare(Convert.ToString(dt.Rows[0]["upassword"]), PublicClass.cPassword);

                    if (uchk == 0 && pchk == 0)
                    {
                        PublicClass.LoginStatus = true;
                        this.Close();
                        PublicClass.User_Name = Convert.ToString(txtID.Text).Trim();
                        DbClass.executequery(CommandType.Text, "Update userdetail set Login = '1' , LastloginDate = '" + PublicClass.GetDatetime() + "'where ID = '" + PublicClass.cUID + "'");
                    }
                    else
                    {
                        MessageBox.Show(this, "You have entered wrong user name or password...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtID.Text = "";
                        txtPassword.Text = "";
                    }
                }
            }
            catch { }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtID.Select();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {
                        btnLogin_Click(sender, e);
                    }
                    catch
                    {

                    }
                }
            }
            catch { }
        }

      
    }
}

