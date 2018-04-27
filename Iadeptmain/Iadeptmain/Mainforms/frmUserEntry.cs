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
using Iadeptmain.Mainforms;
using Iadeptmain.GlobalClasess;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Mainforms
{
    public partial class frmUserEntry : DevExpress.XtraEditors.XtraForm
    {


        string ADD_Edit = "";

        frmSDAlarm objSD = null;
        public frmUserEntry(string ss)
        {
            InitializeComponent();
            ADD_Edit = ss;
        }

        public void fillEntry()
        {
            txtUsrName.Text = PublicClass.uName;
            txtPassword.Text = PublicClass.uPassword; 
            cmbDataBase.Text = PublicClass.uDataBase;
            
        }


        private void frmUserEntry_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        string sUName = null;
        string suPassword = null;
        bool checkPassword = false;
        int LoginStatus;

        private void btnOk_Click(object sender, EventArgs e)
        {
          

            objSD = new frmSDAlarm();
            try
            {
                bool sLogin = false;
                sUName = txtUsrName.Text.Trim().ToString();
                suPassword = txtPassword.Text.Trim().ToString();

                 string uID="";

                checkPassword = PublicClass.CheckForSpecialCharacter(suPassword);

                if (sUName == "" || suPassword == "")
                {

                    MessageBox.Show("User Name & Password can not be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    
                }
                else if(checkPassword == false)
                {
                    MessageBox.Show("Special character is mondetory");
                    return ;
                }
                    else if (suPassword.Length < 6)
                {
                    MessageBox.Show("Password must be of minimum 6 character");
                    return;
                }

                else
                {
                    if (sLogin == true)
                    {
                        LoginStatus = 1;
                    }
                    else
                    {
                        LoginStatus = 0;
                    }

                    DataTable dtu = new DataTable();
                    dtu = DbClass.getdata(CommandType.Text, "Select distinct  ID, UserName,Password,Password,Login from userdetail where UserName= '" + sUName + "'  ");
                    foreach (DataRow dr in dtu.Rows)
                    {
                         uID = Convert.ToString(dr["ID"]);
                       
                    }

                    if (ADD_Edit == "Insert")
                    {
                        if (Convert.ToString(uID).Trim() != "")
                        {
                            MessageBox.Show(this, "This name is already exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {

                            DbClass.executequery(CommandType.Text, "insert into userdetail(UserName,Password,Login,LastloginDate,DatabaseName) values('" + sUName.Trim() + "' , '" + suPassword.Trim() + "' ,  " + LoginStatus + ", '" + PublicClass.GetDatetime() + "' , '" + PublicClass.databasename + "')");
                            DbClass.executequery(CommandType.Text, "Insert into login_data(User_ID,uPassword,Upload,Download) values('" + sUName.Trim() + "' , '" + suPassword.Trim() + "' ," + 0 + ", " + 0 + " )");

                        }
                    }
                    else if (ADD_Edit == "Edit")
                    {

                        if (PublicClass.uName.Trim() != sUName || PublicClass.uPassword.Trim() != suPassword)
                        {
                            DbClass.executequery(CommandType.Text, "Update userdetail set UserName = '" + sUName + "' , Password = '" + suPassword + "' , Login = '" + LoginStatus + "'  where ID = '" + PublicClass.uID.Trim() + "'  ");
                            DbClass.executequery(CommandType.Text, "Update usersettings set UserName = '" + sUName + "' where UserDetailID = '" + PublicClass.uID.Trim() + "' ");
                            DbClass.executequery(CommandType.Text, "Update login_data set User_ID = '" + sUName + "' , uPassword = '" + suPassword + "' where User_ID = '" + PublicClass.uName.Trim() + "' and uPassword = '" + PublicClass.uPassword.Trim() + "'");
                            MessageBox.Show("Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    this.Close();
                }

              
                
               
            }
            catch
            {

            }

        }
    }
}