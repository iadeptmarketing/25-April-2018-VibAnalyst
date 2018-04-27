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
using Iadeptmain.Mainforms;
namespace Iadeptmain.Mainforms
{
    public partial class frmPAlarm : DevExpress.XtraEditors.XtraForm
    {

        bool bGenerated = false;
        bool bAlarmEntry = true;
        


        public frmPAlarm()
        {
            InitializeComponent();
        }

        float fPercentValue = 0;
        public float PPercentValue
        {
            get
            {
                return fPercentValue;
            }
            set
            {
                fPercentValue = value;
            }
        }

        public string PPercentName
        {
            get
            {
                return txtPName.Text;
            }
            set
            {
                txtPName.Text = value;
            }
        }

        private void btnPNewOK_Click(object sender, EventArgs e)
        {
            frmSDAlarm sda = new frmSDAlarm();
            try
            {
                if (Convert.ToString(txtPName.Text).Trim() == "")
                {
                    MessageBox.Show("Name can not be Blank..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string sFsdAl = txtPName.Text.ToString().TrimEnd(' ');
                sFsdAl = sFsdAl.TrimStart(' ');

                if (!string.IsNullOrEmpty(sFsdAl))
                {
                    if (Convert.ToInt32(txtPValue.Text) > 100)
                    {
                        MessageBox.Show("Percentage alarm should be less than 100", "Name error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPValue.Text = "";
                        return;
                    }
                    bool IsSpecial = sda.CheckForSpecialCharacter(sFsdAl);
                    if (!IsSpecial)
                    {
                        if (sFsdAl.Length > 8)
                        {
                            MessageBox.Show("Max limit for alarm name is 8 characters", "Name error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            this.PPercentName = sFsdAl;

                            if ((float)Convert.ToDouble(txtPValue.Text) >= 0)
                            {
                                this.PPercentValue = (float)Convert.ToDouble(txtPValue.Text);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Negative values not accepted");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Name Field Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Accepted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void txtPValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            PublicClass.only_numeric(e);
        }

        private void btnPNewCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}