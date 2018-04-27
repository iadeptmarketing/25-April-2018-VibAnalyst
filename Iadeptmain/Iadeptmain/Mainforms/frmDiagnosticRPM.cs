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
    public partial class frmDiagnosticRPM : DevExpress.XtraEditors.XtraForm
    {
        public frmDiagnosticRPM()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string MType = cmbMachineType.SelectedItem.ToString();
                if(txtStdRPM.Text=="" || txtStdRPM.Text == null|| txtVariation.Text == "" || txtVariation.Text == null)
                {
                    MessageBox.Show(this,"Standard RPM  and variation can not be blank","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                this.Close();
            }
            catch
            {

            }
        }


        public string[] GetRPMallValues(int rpm, int variation)
        {
            int Rpm = 1;
            bool rpmFlag = false;
            string[] RPMValues = new string[4];            
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "Select ordertrace_rpm , Point_Type from point_data where Data_ID in(select max(Data_ID) as Data_ID from point_data where Point_ID = '" + PublicClass.SPointID + "')");

                if (dt.Rows.Count > 0)
                {
                    Rpm = Convert.ToInt32(dt.Rows[0]["ordertrace_rpm"]);
                    rpmFlag = true;

                }
                else
                {
                    Rpm = rpm;
                }
                if (Rpm == 0)
                {
                    Rpm = rpm;
                    rpmFlag = false;
                }
                RPMValues[0] = Convert.ToString(Rpm);
                RPMValues[2] = Convert.ToString(cmbMachineType.SelectedItem);
                RPMValues[1] = Convert.ToString(variation);
                RPMValues[3] = Convert.ToString(rpmFlag);                
            }
            catch
            {
            }
            return RPMValues;
        }
        private void txtStdRPM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}