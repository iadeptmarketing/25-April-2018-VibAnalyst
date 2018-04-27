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
using System.Data.Odbc;
using Iadeptmain.GlobalClasses;
using System.Text.RegularExpressions;

namespace Iadeptmain.Mainforms
{
    public partial class Sensor : DevExpress.XtraEditors.XtraForm
    {

        string sensorid;
        bool add, edit;
        int IDD;
        int icpval;

        Boolean addition, deletion, modification, Preivew, uidd;

        public Sensor()
        {
            InitializeComponent();
            fillcmbName();
            fillcmbmanu();
            fillcmbType();
            fillcmbUnit();

            PublicClass.SeteUserSettings(ref addition, ref deletion, ref modification, ref Preivew, ref uidd, "Sensors");

            if (addition == false && modification == false)
            {
                btnSave.Enabled = false;
                btnNew.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                btnNew.Enabled = true;
            }
            if (addition == false)
            {
                btnNew.Enabled = false;
            }
            else
            {
                btnNew.Enabled = true;
            }
            if (deletion)
            {
                btnCancel.Enabled = true;
            }
            else
            {
                btnCancel.Enabled = false;
            }

        }

        private void fillcmbName()
        {
            try
            {

                cmbName.DataSource = DbClass.getdata(CommandType.Text, "select Sensor_ID,Sensor_name from sensor_data  where Sensor_ID>5");
                cmbName.DisplayMember = "Sensor_name";
                cmbName.ValueMember = "Sensor_ID";
            }
            catch { }
            finally { }

        }

        private void selSensitivity()
        {
            try
            {
                cmbSenDir.SelectedIndex = -1;
                txtSenCH1.Enabled = false;
                txtSenA.Enabled = false;
                txtSenH.Enabled = false;
                txtSenV.Enabled = false;
                txtSenCH1.Clear();
                txtSenA.Clear();
                txtSenH.Clear();
                txtSenV.Clear();
                txtSenCH1.Text = "100";
                txtSenA.Text = "100";
                txtSenH.Text = "100";
                txtSenV.Text = "100";
            }
            catch
            {

            }
        }

        private void fillcmbmanu()
        {
            try
            {
                cmbManu.DataSource = DbClass.getdata(CommandType.Text, "select id,ManufactureName from manufacture");
                cmbManu.DisplayMember = "ManufactureName";
                cmbManu.ValueMember = "ID";
            }
            catch { }
            finally { }
        }
        
      
        private void fillcmbType()
        {
            try
            {
                cmbType.DataSource = DbClass.getdata(CommandType.Text, "select distinct  SensorType ,Sensortypeint from Sensor_type  order by Sensortypeint asc");
                cmbType.DisplayMember = "SensorType";
                cmbType.ValueMember = "Sensortypeint";
            }
            catch { }
            finally { }
        }
        

        private void fillcmbUnit()
        {
            try
            {
                cmbUnit.DataSource = DbClass.getdata(CommandType.Text, " select distinct  unit,Sensorunitint from Sensor_type  where Sensortypeint= '" + cmbType.SelectedValue + "'"); ;
                cmbUnit.DisplayMember = "UNIT";
                cmbUnit.ValueMember = "Sensorunitint";
            }
            catch { }
        }

        bool modify = true;

        private void Blank()
        {
            try
            {
                if (modify == true)
                {

                    cmbName.Text = "";
                    cmbSenDir.Text = "";
                    cmbManu.Text = "";
                    cmbType.Text = "";
                    cmbUnit.Text = "";
                    txtSenCH1.Text = String.Empty;
                    txtSenA.Text = String.Empty;
                    txtSenH.Text = String.Empty;
                    txtSenV.Text = String.Empty;
                    txtSenOffset.Text = String.Empty;
                    chkBoxICP.Checked = true;
                    cmbName.SelectedIndex = -1;
                    cmbSenDir.SelectedIndex = -1;
                    cmbManu.SelectedIndex = -1;
                    cmbType.SelectedIndex = -1;
                    cmbUnit.SelectedIndex = -1;
                    cmbRange.SelectedIndex = -1;
                    selSensitivity();
                }
                else
                {
                    cmbName.Text = "";
                    cmbSenDir.Text = "";
                    cmbManu.Text = "";
                    cmbType.Text = "";
                    cmbUnit.Text = "";
                    txtSenCH1.Text = String.Empty;
                    txtSenA.Text = String.Empty;
                    txtSenH.Text = String.Empty;
                    txtSenV.Text = String.Empty;
                    txtSenOffset.Text = String.Empty;
                    chkBoxICP.Checked = false;
                    cmbName.SelectedIndex = -1;
                    cmbSenDir.SelectedIndex = -1;
                    cmbManu.SelectedIndex = -1;
                    cmbType.SelectedIndex = -1;
                    cmbUnit.SelectedIndex = -1;
                    cmbRange.SelectedIndex = -1;
                    selSensitivity();
                }

            }
            catch { }

        }

        private int chekdata(int useid)
        {
            OdbcDataReader objReader = null;
            OdbcCommand objCommand = null;

            string DTbs = null;

            try
            {


                DataTable dtname = new DataTable();
                OdbcDataAdapter da = new OdbcDataAdapter("SELECT Sensor_Name FROM sensor_data  where Sensor_Id = '" + cmbName.SelectedIndex + "' and defaulttype = 0", PublicClass.conn);
                da.Fill(dtname);
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
            finally { }

            return useid;

        }

        private void chekdatavalue()
        {


            if (chkBoxICP.Checked == true)
            {
                icpval = 1;
            }
            else
            {
                icpval = 0;
            }
        }

        private void numeric_only(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !Char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            modify = true;
            Blank();

        }

        private void Sensor_Load(object sender, EventArgs e)
        {
            modify = false;
            Blank();
            cmbName.Focus();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillcmbUnit();
            try
            {
                string stName = cmbType.Text.Trim();

                if (stName == "Acceleration" || stName == "Velocity" || stName == "Displacement")
                {
                    cmbSenDir.Enabled = true;
                }
                else if (stName == "Temperature" || stName == "Pressure" || stName == "Current" || stName == "Sound")
                {
                    cmbSenDir.SelectedIndex = 1;
                    cmbSenDir.Enabled = false;
                }
                else
                {
                    cmbSenDir.Text = "";
                }
            }
            catch
            { }
        }

        private void txtSenCH1_KeyPress(object sender, KeyPressEventArgs e)
        {
            numeric_only(sender, e);
        }

        private void txtSenA_KeyPress(object sender, KeyPressEventArgs e)
        {
            numeric_only(sender, e);
        }

        private void txtSenH_KeyPress(object sender, KeyPressEventArgs e)
        {
            numeric_only(sender, e);
        }

        private void txtSenV_KeyPress(object sender, KeyPressEventArgs e)
        {
            numeric_only(sender, e);
        }

        private void txtSenOffset_KeyPress(object sender, KeyPressEventArgs e)
        {
            numeric_only(sender, e);
        }

        DataTable dt4 = new DataTable();

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sen_c = null;
            if (cmbName.Text.Trim() == "")
            {
                MessageBox.Show(this, "Name can't be  blank", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbManu.Text.Trim() == "" || cmbType.Text.Trim() == "" || cmbUnit.Text.Trim() == "" || txtSenA.Text == "" || txtSenH.Text == "" || txtSenV.Text == "" || txtSenCH1.Text == "" || cmbRange.Text.Trim() == "" || txtSenOffset.Text == "")
            {
                MessageBox.Show(this, "Please fill all option", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            chekdatavalue();
            try
            {
                dt4.Rows.Clear();
                OdbcDataAdapter da = new OdbcDataAdapter("select distinct * from sensor_data where   Sensor_Name = '" + cmbName.Text.Trim() + "' ", PublicClass.conn);
                da.Fill(dt4);
                if (dt4.Rows.Count > 0)
                {
                    sensorid = Convert.ToString(dt4.Rows[0]["Sensor_ID"]);
                    edit = true;
                    add = false;
                }
                else
                {
                    edit = false;
                    add = true;
                }
            }
            catch { }
            finally { }
            if (add == true)
            {
                try
                {
                    if (txtSenA.Text == "" || txtSenA.Text == null)
                    {
                        txtSenA.Text = "0";
                    }
                    if (txtSenH.Text == "" || txtSenH.Text == null)
                    {
                        txtSenH.Text = "0";
                    }
                    if (txtSenV.Text == "" || txtSenV.Text == null)
                    {
                        txtSenV.Text = "0";
                    }
                    if (txtSenCH1.Text == "" || txtSenCH1.Text == null)
                    {
                        txtSenCH1.Text = "0";
                    }
                    if (txtSenOffset.Text == "" || txtSenOffset.Text == null)
                    {
                        txtSenOffset.Text = "0";
                    }
                    if (cmbRange.SelectedIndex == -1)
                    {
                        cmbRange.SelectedIndex = 0;
                    }

                    if (cmbSenDir.SelectedIndex == 1)
                    {
                        if ((int)cmbType.SelectedValue == 5)
                        {
                            string sen_a = Convert.ToString(txtSenA.Text).Trim();
                            SensitivityForCurrent(sen_a, ref sen_c, false);
                            txtSenH.Text = txtSenA.Text;
                            txtSenV.Text = txtSenA.Text;
                            txtSenCH1.Text = txtSenA.Text;
                        }
                        else
                        {
                            txtSenH.Text = txtSenA.Text;
                            txtSenV.Text = txtSenA.Text;
                            txtSenCH1.Text = txtSenA.Text;
                        }
                    }
                        

                    if (Convert.ToInt32(txtSenA.Text) == 0)
                    {
                        edit = false;
                        add = false;
                        MessageBox.Show(this, "Please make sure that you fill correct value for sensitivity..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (addition == true)
                    {
                        if ((int)cmbType.SelectedValue != 5)
                        {
                            DbClass.executequery(CommandType.StoredProcedure, "call insert_sensor_data ('" + cmbManu.SelectedValue + "' , '" + cmbName.Text + "','" + cmbType.SelectedValue + "','" + txtSenCH1.Text + "' , '" + txtSenA.Text + "' , '" + txtSenH.Text + "' , '" + txtSenV.Text + "','" + cmbUnit.SelectedValue + "','" + cmbSenDir.SelectedIndex + "','" + icpval + "','" + txtSenOffset.Text + "', '" + cmbRange.SelectedIndex + "') ");
                        }
                        else
                        {
                            DbClass.executequery(CommandType.StoredProcedure, "call insert_sensor_data ('" + cmbManu.SelectedValue + "' , '" + cmbName.Text + "','" + cmbType.SelectedValue + "','" + sen_c + "' , '" + sen_c + "' , '" + sen_c + "' , '" + sen_c + "','" + cmbUnit.SelectedValue + "','" + cmbSenDir.SelectedIndex + "','" + icpval + "','" + txtSenOffset.Text + "', '" + cmbRange.SelectedIndex + "') ");
                        }
                        
                        MessageBox.Show(this, "Data saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillcmbName();
                        fillcmbmanu();
                        fillcmbType();
                        fillcmbUnit();
                        Blank();
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to create new Sensor");
                        modify = false;
                        Blank();

                    }
                }
                catch { }
                finally { }
            }
            else if (edit == true)
            {
                if (cmbSenDir.SelectedIndex == 1)
                {
                    if ((int)cmbType.SelectedValue == 5)
                    {
                        string sen_a = Convert.ToString(txtSenA.Text).Trim();
                        SensitivityForCurrent(sen_a, ref sen_c, false);
                        txtSenH.Text = txtSenA.Text;
                        txtSenV.Text = txtSenA.Text;
                        txtSenCH1.Text = txtSenA.Text;
                    }
                    else
                    {
                        txtSenH.Text = txtSenA.Text;
                        txtSenV.Text = txtSenA.Text;
                        txtSenCH1.Text = txtSenA.Text;
                    }
                   
                }
                try
                {
                    DataTable dt1 = DbClass.getdata(CommandType.Text, "Select * from measure where Sensor_ID = '" + sensorid + "'");
                    if (dt1.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "Sensor Already use in Point Type", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbName.SelectedValue = cmbName.Text.ToString();
                        return;
                    }
                    else
                    {
                        if (modification == true)
                        {
                            if (cmbName.Text.Trim() != Convert.ToString(dt4.Rows[0]["Sensor_name"]).Trim() || Convert.ToInt32(cmbType.SelectedValue) != Convert.ToInt32((dt4.Rows[0]["Sensor_type"])) || txtSenA.Text.Trim() != Convert.ToString(dt4.Rows[0]["Sensitivity_a"]).Trim() || txtSenH.Text.Trim() != Convert.ToString(dt4.Rows[0]["Sensitivity_h"]).Trim() || txtSenV.Text.Trim() != Convert.ToString(dt4.Rows[0]["Sensitivity_v"]).Trim() || txtSenCH1.Text.Trim() != Convert.ToString(dt4.Rows[0]["Senitivity_Ch1"]).Trim() || Convert.ToInt32(cmbUnit.SelectedValue) != Convert.ToInt32(dt4.Rows[0]["Sensor_unit"]) || cmbSenDir.SelectedIndex != Convert.ToInt32(dt4.Rows[0]["Sensor_dir"]) || txtSenOffset.Text.Trim() != Convert.ToString(dt4.Rows[0]["Sensor_offset"]).Trim() || cmbRange.SelectedIndex != Convert.ToInt32(dt4.Rows[0]["Input_Range"]) || icpval != Convert.ToInt32(dt4.Rows[0]["Sensor_icp"]))
                            {
                                if ((int)cmbType.SelectedValue != 5)
                                {
                                    DbClass.executequery(CommandType.Text, " call  update_sensor_data ('" + cmbManu.SelectedValue + "' , '" + cmbName.Text + "','" + cmbType.SelectedValue + "','" + txtSenCH1.Text + "' , '" + txtSenA.Text + "' , '" + txtSenH.Text + "' , '" + txtSenV.Text + "','" + cmbUnit.SelectedValue + "','" + cmbSenDir.SelectedIndex + "','" + icpval + "','" + txtSenOffset.Text + "', '" + cmbRange.SelectedIndex + "','" + sensorid + "')");
                                }
                                else
                                {
                                    DbClass.executequery(CommandType.Text, " call  update_sensor_data ('" + cmbManu.SelectedValue + "' , '" + cmbName.Text + "','" + cmbType.SelectedValue + "','" + sen_c + "' , '" + sen_c + "' , '" + sen_c + "' , '" + sen_c + "','" + cmbUnit.SelectedValue + "','" + cmbSenDir.SelectedIndex + "','" + icpval + "','" + txtSenOffset.Text + "', '" + cmbRange.SelectedIndex + "','" + sensorid + "')");
                                }
                               
                                MessageBox.Show(this, "Data saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            fillcmbName();
                            fillcmbmanu();
                            fillcmbType();
                            fillcmbUnit();
                            selSensitivity();
                            modify = false;
                            Blank();
                        }
                        else
                        {
                            MessageBox.Show("You are not allowed to modify a Sensor");
                        }
                    }
                }
                catch { }
                finally { }
            }
        }

        private void cmbName_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.StoredProcedure, "call retrieveSensor_data(" + cmbName.SelectedValue + ") ");
                foreach (DataRow dr in dt.Rows)
                {
                    sensorid = Convert.ToString(dr["sensor_id"]);

                    cmbName.Text = Convert.ToString(dr["Sensor_name"]);

                    cmbManu.SelectedValue = Convert.ToString(dr["Manufacture_ID"]);
                   
                    int r = Convert.ToInt16(dr["Sensor_icp"]);
                    if (r == 1)
                    {
                        chkBoxICP.Checked = true;
                    }
                    else
                    {
                        chkBoxICP.Checked = false;
                    }
                    cmbSenDir.SelectedIndex = Convert.ToInt32(dr["Sensor_dir"]);
                    cmbRange.SelectedIndex = Convert.ToInt32(dr["Input_Range"]);
                    txtSenOffset.Text = Convert.ToString(dr["Sensor_offset"]).Trim();
                    cmbType.SelectedValue = Convert.ToInt32(dr["sensor_type"]);

                    if (Convert.ToInt32(dr["sensor_type"]) == 5)
                    {
                        string sen_a = Convert.ToString(dr["Sensitivity_a"]).Trim();
                        string sen_c = null;
                        SensitivityForCurrent(sen_a, ref sen_c, true);
                        txtSenA.Text = sen_c;
                        txtSenH.Text = sen_c;
                        txtSenV.Text = sen_c;
                        txtSenCH1.Text = sen_c;
                    }
                    else
                    {
                        txtSenA.Text = Convert.ToString(dr["Sensitivity_a"]).Trim();
                        txtSenH.Text = Convert.ToString(dr["Sensitivity_h"]).Trim();
                        txtSenV.Text = Convert.ToString(dr["Sensitivity_v"]).Trim();
                        txtSenCH1.Text = Convert.ToString(dr["Senitivity_Ch1"]).Trim();
                    }

                    fillcmbUnit();
                    cmbUnit.SelectedValue = Convert.ToInt32(dr["Sensor_unit"]);
                }
                if (deletion)
                {
                    btnCancel.Enabled = true;
                }
                else
                {
                    btnCancel.Enabled = false;
                }
            }
            catch { }
            finally { }
        }


        private void SensitivityForCurrent(string sen_a, ref string sen_c ,bool s)
        {
            try
            { 
               if(s)
               {
                   sen_c = Convert.ToString(1000 * (double.Parse(sen_a)));
               }
               else
               {
                   sen_c = Convert.ToString((double.Parse(sen_a))/1000);
               }
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbName.Text != "")
                {
                    if (Convert.ToString(cmbName.SelectedItem) != null || Convert.ToString(cmbName.SelectedItem) != "")
                    {
                        if ((MessageBox.Show("Are You Sure You Want to Delete this Sensor", "Sensor Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                        {
                            DataTable dt1 = DbClass.getdata(CommandType.Text, "Select * from measure where Sensor_ID = '" + sensorid + "'");
                            if (dt1.Rows.Count > 0)
                            {
                                MessageBox.Show(this, "Sensor Already use in Point Type", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                if (deletion == true)
                                {
                                    DbClass.executequery(CommandType.Text, "call DeleteSensor ('" + cmbName.SelectedValue.ToString() + "')");
                                    MessageBox.Show(this, "Sensor Delete Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    fillcmbName();
                                    Blank();
                                }
                                else
                                {
                                    MessageBox.Show(this, "You haven't Right for Deletion", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Select any Sensor.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            catch { }
        }

        private void cmbSenDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cmbIndex = Convert.ToString(cmbSenDir.SelectedIndex);
                if (cmbIndex == "0")
                {
                    txtSenCH1.Enabled = false;
                    txtSenA.Enabled = true;
                    txtSenH.Enabled = true;
                    txtSenV.Enabled = true;
                    //chkBoxICP.Checked = true;
                }
                if (cmbIndex == "1")
                {
                    txtSenCH1.Enabled = false;
                    txtSenA.Enabled = true;
                    txtSenH.Enabled = false;
                    txtSenV.Enabled = false;
                    //chkBoxICP.Checked = true;

                }
                if (cmbIndex == "2")
                {
                    txtSenCH1.Enabled = true;
                    txtSenA.Enabled = true;
                    txtSenH.Enabled = true;
                    txtSenV.Enabled = true;
                    // chkBoxICP.Checked = true;

                }
            }
            catch
            {

            }
        }

        private void cmbName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbName.Text).Trim() != "" && cmbManu.Text.Trim() == "")
                {
                    DataTable dt1 = DbClass.getdata(CommandType.Text, "Select * from Sensor_data where Sensor_name = '" + Convert.ToString(cmbName.Text).Trim() + "'");
                    if (dt1.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "Name Already Exit..Please enter another name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbName.Text = "";
                        cmbName.Focus();
                        return;
                    }
                }
                else
                {
                }
            }
            catch
            { }
        }

        private bool CheckIntegerCharacter(string Name)
        {
            bool bC = false;
            try
            {

                if (Name.Contains("0") || Name.Contains("1") || Name.Contains("2") || Name.Contains("3") || Name.Contains("4") || Name.Contains("5") || Name.Contains("6") || Name.Contains("7") || Name.Contains("8") || Name.Contains("9"))
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
        private void cmbName_KeyPress(object sender, KeyPressEventArgs e)
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