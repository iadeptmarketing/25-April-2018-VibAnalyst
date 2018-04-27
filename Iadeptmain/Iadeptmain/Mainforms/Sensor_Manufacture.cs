using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Data.Odbc;
using Iadeptmain.GlobalClasses;
using System.Text.RegularExpressions;
namespace Iadeptmain.Mainforms
{
    public partial class Sensor_Manufacture : DevExpress.XtraEditors.XtraForm
    {
        public Sensor_Manufacture()
        {
            InitializeComponent();
            fillcombobox();
        }
        DataTable dt=new DataTable ();
        bool add;
        int IDD;

        private void fillcombobox()
        {
            try
            {

                cmbSensorManuName.DataSource = DbClass.getdata(CommandType.Text, "select ManufactureName,id from manufacture");
                cmbSensorManuName.DisplayMember = "ManufactureName";
                cmbSensorManuName.ValueMember = "ID";

            }
            catch { }
        }
        
        private int chekdata(int useid)
        {
            try
            {
                DataTable dtname = new DataTable();
                dtname = DbClass.getdata(CommandType.Text, "select ManufactureName  from manufacture   where ManufactureName = '" + cmbSensorManuName.Text.Trim() + "' ");

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
      
   
        private void btnSen_New_Click(object sender, EventArgs e)
        {
            Blank();
            add = true;
        }

        private void btnSen_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vadivate()
        {
            if (cmbSensorManuName.Text == "")
            { MessageBox.Show("Please Fill Type"); }
          
        }


        private void btnSen_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (add == true)
                {
                    vadivate();
                    int r = chekdata(Convert.ToInt32(cmbSensorManuName.SelectedValue));
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
                            //DbClass.executequery(CommandType.Text, "insert manufacture (ManufactureName,ManufactureAddress) values ('" + cmbSensorManuName.Text + "','" + txtaddress.Text + "') ");
                            DbClass.executequery(CommandType.StoredProcedure, " call  Insert_manufacture ('" + cmbSensorManuName.Text + "','" + txtaddress.Text + "')");
                            MessageBox.Show(this, "Data saved successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            add = false;
                        }
                        catch { }
                    }
                }
                else if (add == false)
                {
                    vadivate();
                    if (MessageBox.Show(this, "Do You want to update", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            //DbClass .executequery (CommandType.Text,  "update manufacturer set ManufactureAddress = '" + txtaddress.Text + "' ,ManufactureName = '" + cmbSensorManuName .Text .Trim ()+ "'  where id = '" + IDD + "'  ");
                            DbClass.executequery(CommandType.StoredProcedure, "call  Update_manufacture ('" + IDD + "' ,'" + cmbSensorManuName.Text.Trim() + "','" + txtaddress.Text + "' )");
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

        private void Blank()
        {
          
            txtaddress.Text = String.Empty;
            cmbSensorManuName.SelectedIndex = -1;
            //add = false;
        }
        private void cmbSensorManuName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbSensorManuName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = DbClass.getdata(CommandType.Text, "SELECT ManufactureAddress FROM manufacture where ID= '" + cmbSensorManuName.SelectedValue.ToString () + "'  ");

                if (dt1.Rows.Count > 0)
                {
                    txtaddress.Text = Convert.ToString(dt1.Rows[0][0]);
                }

                IDD = Convert.ToInt16(cmbSensorManuName.SelectedValue);
            }
            catch { }
        }

        private void cmbSensorManuName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtaddress_KeyPress(object sender, KeyPressEventArgs e)
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