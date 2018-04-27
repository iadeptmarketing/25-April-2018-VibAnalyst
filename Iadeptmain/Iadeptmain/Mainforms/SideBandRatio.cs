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
    public partial class SideBandRatio : DevExpress.XtraEditors.XtraForm
    {
        public SideBandRatio()
        {
            InitializeComponent();
           
        }
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


        private int FillValue()
        {

            int Value = 10;

            try
            {

                DataTable dt = DbClass.getdata(CommandType.Text, "select * from SideBandRatio");

                foreach (DataRow dr in dt.Rows)
                {
                    Value = Convert.ToInt32(dr["Value"]);
                }

            }
            catch (Exception ex1)
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
                DbClass.executequery(CommandType.Text, "truncate table SideBandRatio");

                DbClass.executequery(CommandType.Text, "insert into SideBandRatio(Value) values('" + value + "')");

            }
            catch (Exception ex1)
            {
                DbClass.executequery(CommandType.Text, "create table" + Convert.ToString(PublicClass.User_DataBase).Trim() + " .` SideBandRatio`(Value integer)");

                DbClass.executequery(CommandType.Text, "insert into SideBandRatio(Value) values('" + value + "')");
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int ValChk = (Convert.ToInt32(tbBandValue.Text.ToString()));
                if (ValChk <= 1000)
                {
                    SaveValuesInDataBase(Convert.ToInt32(tbBandValue.Text.ToString()));
                    //MainForm.SideBandRatio = true;
                    ival = ValChk;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You can enter upto 1000 % only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Enter Only Numerical values","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void tbBandValue_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void SideBandRatio_Shown(object sender, EventArgs e)
        {
            try
            {
                tbBandValue.Text = Convert.ToString(FillValue());
            }
            catch (Exception ex)
            {
            }
        }


    }
}
