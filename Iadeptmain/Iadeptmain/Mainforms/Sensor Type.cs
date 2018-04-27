using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Odbc;
using System.Data;
using Iadeptmain.GlobalClasses;
using System.Text.RegularExpressions;

namespace Iadeptmain.Mainforms
{
    public partial class Sensor_Type : DevExpress.XtraEditors.XtraForm
    {
        public Sensor_Type()
        {
            InitializeComponent();
            fillcombobox();
        }
        DataTable dt = new DataTable();
        bool add;
        int IDD;
        private void fillcombobox()
        {
            try
            {
                cmbSensorType.DataSource = DbClass.getdata(CommandType.Text, "select distinct sensortype from sensor_type");
                cmbSensorType.DisplayMember = "sensortype";
                cmbSensorType.ValueMember = "sensortype";
            }
            catch
            {
            }

        }
        private int chekdata(int useid)
        {
            try
            {
                DataTable dtname = new DataTable();
                dtname = DbClass.getdata(CommandType.Text, "select Unit from sensor_type where Unit = '" + Cmbunit.Text.Trim() + "' ");
                if (dtname.Rows.Count > 0)
                {
                    useid = 1;
                }
                else
                {
                    useid = 0;
                }
            }
            catch { }
            return useid;
        }

        private void Blank()
        {
            try
            {
                cmbSensorType.SelectedIndex = -1;
                Cmbunit.SelectedIndex = -1;
                add = false;
            }
            catch { }
        }
        private void btnSensortypeSave_Click(object sender, EventArgs e)
        {
            try
            {
                //vadivate();
                if (cmbSensorType.Text == "")
                { MessageBox.Show("Please Fill Sensor Type"); return; }
                if (add == true)
                {
                    int r = chekdata(Convert.ToInt32(cmbSensorType.SelectedValue));
                    if (r == 1)
                    {
                        MessageBox.Show(this, "This Name is already Exist", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (r == 0)
                    {
                        //return;
                    }
                    if (MessageBox.Show(this, "Do You want to Save", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            using (OdbcConnection objConnection = new OdbcConnection())
                            {
                                DbClass.executequery(CommandType.Text, "call insert_SensorType  ('" + cmbSensorType.Text + "','" + Cmbunit.Text + "') ");
                                MessageBox.Show(this, "Data saved successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                add = false;
                            }
                        }
                        catch { }
                    }
                }
                else if (add == false)
                {
                    if (MessageBox.Show(this, "Do You want to update", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            DbClass.executequery(CommandType.Text, " call  update_SensorType  ('" + IDD + "','" + cmbSensorType.Text.Trim() + "','" + Cmbunit.Text + "')");
                            MessageBox.Show(this, "Data saved successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                    }
                }
                fillcombobox();
                Blank();
            }
            catch { }
        }
        
        private void btnSensortypeCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSensortypeNew_Click(object sender, EventArgs e)
        {
            Blank();
            add = true;
        }

        private void cmbSensorType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {

                Cmbunit.DataSource = DbClass.getdata(CommandType.Text, "select distinct id,unit  from sensor_type where SensorType= '" + cmbSensorType.Text.Trim() + "'  ");
                Cmbunit.DisplayMember = "unit";
                Cmbunit.ValueMember = "id";
                IDD = Convert.ToInt16(Cmbunit.SelectedValue);
            }
            catch { }
        }

        private void Cmbunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { IDD = Convert.ToInt16(Cmbunit.SelectedValue); }
            catch { }
        }

        private void cmbSensorType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PublicClass.chkKeyEnter(e))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}