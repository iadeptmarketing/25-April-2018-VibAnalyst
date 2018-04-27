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
    public partial class frmSDAlarm : DevExpress.XtraEditors.XtraForm
    {
        public frmSDAlarm()
        {
            InitializeComponent();
        }

        private void btnSDNewCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        float fPercentValue = 0;
        public float SDPercentValue
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

        public string SDPercentName
        {
            get
            {
                return txtSDName.Text;
            }
            set
            {
                txtSDName.Text = value;
            }
        }

        public bool CheckForSpecialCharacter(string Name)
        {
            bool bC = false;
            try
            {
                if (Name.Contains("~"))
                {
                    bC = true;
                }
                else if (Name.Contains("`"))
                {
                    bC = true;
                }
                else if (Name.Contains("!"))
                {
                    bC = true;
                }
                else if (Name.Contains("@"))
                {
                    bC = true;
                }
                else if (Name.Contains("#"))
                {
                    bC = true;
                }
                else if (Name.Contains("$"))
                {
                    bC = true;
                }
                else if (Name.Contains("%"))
                {
                    bC = true;
                }
                else if (Name.Contains("^"))
                {
                    bC = true;
                }
                else if (Name.Contains("&"))
                {
                    bC = true;
                }
                else if (Name.Contains("*"))
                {
                    bC = true;
                }
                else if (Name.Contains("+"))
                {
                    bC = true;
                }
                else if (Name.Contains("="))
                {
                    bC = true;
                }
                else if (Name.Contains("|"))
                {
                    bC = true;
                }
                else if (Name.Contains("/"))
                {
                    bC = true;
                }
                else if (Name.Contains("<"))
                {
                    bC = true;
                }
                else if (Name.Contains(">"))
                {
                    bC = true;
                }
                else if (Name.Contains(","))
                {
                    bC = true;
                }
                return bC;

            }
            catch (Exception ex)
            {
                return bC;
            }
        }

        private void btnSDNewOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtSDName.Text).Trim() == "")
                {
                    MessageBox.Show("Name can not be Blank..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string sFsdAl = txtSDName.Text.ToString().TrimEnd(' ');
                sFsdAl = sFsdAl.TrimStart(' ');
                if (!string.IsNullOrEmpty(sFsdAl))
                {
                    if (Convert.ToInt32(txtSDValue.Text) > 100)
                    {
                        MessageBox.Show("Percentage alarm should be less than 100", "Name error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtSDValue.Text = "";
                        return;
                    }

                    bool IsSpecial = CheckForSpecialCharacter(sFsdAl);
                    if (!IsSpecial)
                    {
                        if (sFsdAl.Length > 8)
                        {
                            MessageBox.Show("Max limit for alarm name is 8 characters", "Name error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            this.SDPercentName = sFsdAl;
                            if ((float)Convert.ToDouble(txtSDValue.Text) >= 0)
                            {
                                this.SDPercentValue = (float)Convert.ToDouble(txtSDValue.Text);
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
            catch
            {
            }
        }

        private void frmSDAlarm_Load(object sender, EventArgs e)
        {

        }

        private void txtSDValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            PublicClass.only_numeric(e);
        }
    }
}