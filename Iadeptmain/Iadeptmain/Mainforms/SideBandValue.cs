using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using Iadeptmain.Mainforms;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Mainforms
{
    public partial class SideBandValue : DevExpress.XtraEditors.XtraForm
    {
        public SideBandValue()
        {
            InitializeComponent();
           
        }

        public bool check = false;

        frmIAdeptMain objMainForm = null;
        public frmIAdeptMain MainForm
        {
            get
            {
                return objMainForm;
            }
            set
            {
                objMainForm = value;
            }
        }

      
        int ival = 10;
        public int _Value
        {
            get
            {
                return ival;
            }
        }

        public string checkpole;
        public string _checkpole
        {
            get
            {
                return checkpole;
            }
            set
            {
                checkpole = value;
            }
        }

        public int Actualspeed;
        public int _Actualspeed
        {
            get
            {
                return Actualspeed;
            }
            set
            {
                Actualspeed = value;
            }
        }

        private int FillValue()
        {
            int Value = 10;
            try
            {
                DataTable dt = DbClass.getdata(CommandType.Text, "select * from SideBandVal");

                foreach (DataRow dr in dt.Rows)
                {
                    Value = Convert.ToInt32(dr["Value"]);
                } 
            }


            catch (Exception ex)
            {

            }
            return Value;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void SaveValuesInDataBase(int value)
        {

            try
            {
                DbClass.executequery(CommandType.Text, "truncate table SideBandVal");


                DbClass.executequery(CommandType.Text, "insert into SideBandVal(Value) values('" + value + "')");
            }
            catch (Exception ex1)
            {
                DbClass.executequery(CommandType.Text, "create table" + Convert.ToString(PublicClass.User_DataBase).Trim() + " .` SideBandVal`(Value int(100))");
                DbClass.executequery(CommandType.Text, "insert into SideBandVal(Value) values('" + value + "')");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                try
                {
                    checkpole = cmbpole.Text;
                    Actualspeed = Convert.ToInt32(txtActspeed.Text.ToString());
                }
                catch { }
            }
            else
            {
                try
                {
                    int ValChk = (Convert.ToInt32(tbBandValue.Text.ToString()));
                    if (ValChk <= 100)
                    {
                        SaveValuesInDataBase(Convert.ToInt32(tbBandValue.Text.ToString()));
                        ival = ValChk;                        
                    }
                    else
                    {
                        MessageBox.Show("You can enter upto 100 % only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Enter Only Numerical values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }

        private void tbBandValue_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void SideBandValue_Shown_1(object sender, EventArgs e)
        {
            try
            {
                if (check == true)
                {
                    labelControl1.Visible = false;
                    tbBandValue.Visible = false;
                    label1.Visible = false;
                    labelControl2.Visible = true;
                    labelControl3.Visible = true;
                    txtActspeed.Visible = true;
                    cmbpole.Visible = true;                        
                }
                else
                {
                    tbBandValue.Text = Convert.ToString(FillValue());
                }
            }
            catch
            {
            }
        }
    }
}
