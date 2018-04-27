using Iadeptmain.GlobalClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iadeptmain.Mainforms
{
    public partial class frmFailure : Form
    {
        public frmFailure()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMachineClass_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedClass = cmbMachineClass.SelectedItem.ToString();
                string selectedType = cmbPattern.SelectedItem.ToString();
                if (selectedType == "ISO Pattern")
                {
                    DataTable dtData = DbClass.getdata(CommandType.Text, "SELECT * FROM route.tblmachinevibrationlevel where MachineClass = '" + selectedClass + "'");
                    txtLevel.Text = Convert.ToString(dtData.Rows[0]["VibrationLevel"]);
                    txtLevel.Enabled = false;
                    cmbVibrationUnit.SelectedItem = Convert.ToString(dtData.Rows[0]["VibrationUnit"]);
                    cmbVibrationUnit.Enabled = false;
                }
                else
                {
                    txtLevel.Enabled = true;
                    cmbVibrationUnit.Enabled = true;
                }

            }
            catch (Exception ex) { throw ex; }


        }
    }
}
