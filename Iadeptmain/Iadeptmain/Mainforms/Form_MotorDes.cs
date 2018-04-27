using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Iadeptmain.Classes;
using Iadeptmain.GlobalClasses;


namespace Iadeptmain.Mainforms
{
    public partial class Form_MotorDes : Form
    {
        public Form_MotorDes(string ItemName)
        {
            InitializeComponent();
            this.cmbSenDir.SelectedIndex = 0;
            this.cmbSenUnit.SelectedIndex = 0;
            AddImageforPictureBox(ItemName);
            SetWaterMarktexts(ItemName);
            cmbSenType.SelectedIndex = 0;
            LoadSensors();
            Sensor _Sensors = new Sensor();
        }

        DataTable dtSensorName = new DataTable();
        public void LoadSensors()
        {
            try
            {
                dtSensorName = DbClass.getdata(CommandType.Text, " select * from sensor_data where Sensor_id>5 and (Sensor_dir='1' or Sensor_dir='0') and (sensor_type='0' || sensor_type='1' ||sensor_type='2')");
                cmbSensors.Items.Clear();
                foreach (DataRow dr in dtSensorName.Rows)
                {
                    cmbSensors.Items.Add(Convert.ToString(dr["Sensor_name"]));
                }
               
            }
            catch { }
        }



        private void SetWaterMarktexts(string ItemName)
        {
            textBoxX1.WatermarkText = ItemName + " Name";
            textBoxX2.WatermarkText = "RPM Value of " + ItemName;
            textBoxX4.WatermarkText = "Serial Number of " + ItemName;
            textBoxX5.WatermarkText = "Make of " + ItemName;
        }

        private void AddImageforPictureBox(string ItemName)
        {
            //reflectionImageMotor.Image = Resources.c11;
            Imageclass.SetImages(reflectionImageMotor, ItemName);
        }

        bool additem = false;

        public bool _AddItem
        {
            get
            {
                return additem;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            additem = false;
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxX1.Text.ToString()))
            {
                if (!string.IsNullOrEmpty(cmbSensors.Text.ToString()))
                {                  
                    if (cmbSenDir.SelectedItem.ToString().ToLower() == "uniaxial")
                    {
                        if (!cbAxial.Checked && !cbVert.Checked && !cbHori.Checked)
                        {
                            MessageBox.Show("Select atleast one Sensor parameter");
                        }
                        else
                        {
                            //add data to database

                            additem = true;
                            dirval = calculateSenVal();
                            this.Close();
                        }

                    }
                    else
                    {
                        //add data to database
                        dirval = 7;
                        additem = true;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Sensor Name cannot be blank");
                }
            }
            else
            {
                MessageBox.Show("Name field cannot be blank");
            }
        }
        int dirval = 0;
        private int calculateSenVal()
        {
            int iPartVal = 0;
            int iTotalVal = 0;

            if (cmbSenDir.SelectedIndex == 0)
            {
                iTotalVal = 0;
            }
            else
            {
               // iTotalVal = 24;
                if (cbAxial.Checked)
                {
                    iPartVal = 1;
                    iTotalVal += iPartVal;
                }
                if (cbHori.Checked)
                {
                    iPartVal = 2;
                    iTotalVal += iPartVal;
                }
                if (cbVert.Checked)
                {
                    iPartVal = 4;
                    iTotalVal += iPartVal;
                }
            }
            return iTotalVal;
        }

        public string Make
        {
            get
            {
                if (!string.IsNullOrEmpty(textBoxX5.Text))
                {
                    return textBoxX5.Text;
                }
                else
                {
                    return "Not Known";
                }
            }
        }
        public string RPM
        {
            get
            {
                if (!string.IsNullOrEmpty(textBoxX2.Text))
                {
                    return textBoxX2.Text;
                }
                else
                {
                    return "1";
                }

            }
        }
        public string SerialNo
        {
            get
            {
                if (!string.IsNullOrEmpty(textBoxX4.Text))
                {
                    return textBoxX4.Text;
                }
                else
                {
                    return "1";
                }
            }
        }
        public bool CBAxial
        {
            get
            {
                return cbAxial.Checked;
            }
        }
        public bool CBHor
        {
            get
            {
                return cbHori.Checked;
            }
        }
        public bool CBVer
        {
            get
            {
                return cbVert.Checked;
            }
        }
        public string ButtonName
        {
            get
            {
                if (!string.IsNullOrEmpty(textBoxX1.Text))
                {
                    return textBoxX1.Text;
                }
                else
                {
                    return "Not Known";
                }
            }
        }
        public string SensorUnit
        {
            get
            {
                // return cmbSenUnit.SelectedItem.ToString();
                return cmbSenUnit.SelectedIndex.ToString();
            }
        }
        public string SensorDir
        {
            get
            {
                // return cmbSenDir.SelectedItem.ToString();
                return cmbSenDir.SelectedIndex.ToString();
            }
        }
    

        public string SensorType
        {
            get
            {
                return cmbSenType.SelectedIndex.ToString();
            }
        }
        public string SensitivityX
        {
            get
            {
                if (!string.IsNullOrEmpty(tbSenX.Text))
                {
                    return tbSenX.Text;
                }
                else
                {
                    return "100";
                }

            }
        }
        public string SensitivityY
        {
            get
            {
                if (!string.IsNullOrEmpty(tbSenY.Text))
                {
                    return tbSenY.Text;
                }
                else
                {
                    return "100";
                }
            }
        }
        public string SensitivityZ
        {
            get
            {
                if (!string.IsNullOrEmpty(tbSenZ.Text))
                {
                    return tbSenZ.Text;
                }
                else
                {
                    return "100";
                }
            }
        }
        public int SenVal
        {
            get
            {
                return dirval;
            }
        }
               
        public string SensorID
        {
            get
            {
                return sensorID;
            }
        }

        private void textBoxX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                e.Handled = !(char.IsDigit(e.KeyChar) ||e.KeyChar == 8);
            }
            catch { }
        }

        private void textBox_KeyPressSpaceCheck(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = !e.Handled;// false;
            }
        }

        private void cmbSenDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbSenDir.SelectedItem.ToString().ToLower() == "uniaxial")
                {
                    SensorTriAxial = false;
                }
                else
                {
                    SensorTriAxial = true;
                }
            }
            catch { }
        }
        public bool SensorTriAxial
        {
            set
            {
                tbSenY.Visible = value;
                tbSenZ.Visible = value;
                labeluniY.Visible = value;
                labeluniZ.Visible = value;
                cbAxial.Visible = !value;
                cbHori.Visible = !value;
                cbVert.Visible = !value;
            }
        }

        private void cmbSenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillcmbUnit();
            }
            catch { }
            //cmbSenUnit.Items.Clear();
            //if (cmbSenType.SelectedItem.ToString() == "Acceleration")
            //{
            //    cmbSenUnit.Items.AddRange(new object[] { ("Gs"), ("gal"), ("m/s2") });
            //}
            //else if (cmbSenType.SelectedItem.ToString() == "Velocity")
            //{
            //    cmbSenUnit.Items.AddRange(new object[] { ("mm/s"), ("in/s"), ("cm/s") });
            //}
            //else if (cmbSenType.SelectedItem.ToString() == "Displacement")
            //{
            //    cmbSenUnit.Items.AddRange(new object[] { ("mil"), ("um") });
            //}
            //cmbSenUnit.SelectedIndex = 0;
        }

        private void groupPanel1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Sensor_Form _Sensors = new Sensor_Form();
                //_Sensors.ShowDialog();
                //SetSensorValues(_Sensors._SelectedSensorValues);
                //Sensor_ID = _Sensors.SensorID;
            }
            catch { }
        }


        private void SetSensorValues(string[] sensorvalues)
        {
            SetSensorType(Convert.ToInt32((sensorvalues[0]).ToString()));
            SetSensorUnit(Convert.ToInt32((sensorvalues[1].ToString())));
            SetSensorDirection(Convert.ToInt32((sensorvalues[2].ToString())));
            SetSensitivity((sensorvalues[3].ToString()), (sensorvalues[4].ToString()), (sensorvalues[5].ToString()));
            //SetCheckBox(Convert.ToBoolean(sensorvalues[6].ToString()), Convert.ToBoolean(sensorvalues[7].ToString()), Convert.ToBoolean(sensorvalues[8].ToString()));
        }

        private void SetCheckBox(bool Axial, bool Horizontal, bool Vertical)
        {
            cbAxial.Checked = Axial;
            cbHori.Checked = Horizontal;
            cbVert.Checked = Vertical;
        }


        private void SetSensitivity(string SenX, string SenY, string SenZ)
        {
            tbSenX.Text = SenX;
            tbSenY.Text = SenY;
            tbSenZ.Text = SenZ;
        }

        private void SetSensorDirection(int index)
        {
            cmbSenDir.SelectedIndex = index;
        }

        private void SetSensorUnit(int index)
        {
            cmbSenUnit.SelectedIndex = index;
        }

        private void SetSensorType(int index)
        {
            cmbSenType.SelectedIndex = index;
        }

        //----my code--//

        private void fillcmbType()
        {
            try
            {
                cmbSenType.DataSource = DbClass.getdata(CommandType.Text, "select distinct  SensorType ,Sensortypeint from Sensor_type where Sensortypeint<=2 order by Sensortypeint asc");
                cmbSenType.DisplayMember = "SensorType";
                cmbSenType.ValueMember = "Sensortypeint";
            }
            catch { }
            finally { }
        }

        private void fillcmbUnit()
        {
            try
            {
                cmbSenUnit.DataSource = DbClass.getdata(CommandType.Text, " select distinct  unit,Sensorunitint from Sensor_type  where Sensortypeint= '" + cmbSenType.SelectedValue + "'"); ;
                cmbSenUnit.DisplayMember = "UNIT";
                cmbSenUnit.ValueMember = "Sensorunitint";
            }
            catch { }
        }

        private void fillcmbdir(string dir)
        {
            try
            {
                if (dir == "0")
                {
                    cmbSenDir.SelectedIndex = 0;
                }
                else
                {
                    cmbSenDir.SelectedIndex = 1;
                }
            }
            catch { }
        }

        string sensorID = null;  
        private void cmbSensors_SelectedIndexChanged(object sender, EventArgs e)
        {                     
            try
            {
                foreach (DataRow drr in dtSensorName.Select("Sensor_name= '" + cmbSensors.Text + "' "))
                {
                    sensorID = Convert.ToString(drr["Sensor_id"]).Trim();
                }
                fillcmbType();
                fillcmbUnit();                
                DataTable dt = DbClass.getdata(CommandType.Text, " select * from sensor_data where Sensor_id='" + sensorID + "'");
                if (dt.Rows.Count > 0)
                {
                    cmbSenType.SelectedValue = Convert.ToInt32(dt.Rows[0]["sensor_type"]);
                    cmbSenUnit.SelectedValue = Convert.ToInt32(dt.Rows[0]["Sensor_unit"]);                  
                    fillcmbdir(Convert.ToString(dt.Rows[0]["Sensor_dir"]));
                    tbSenX.Text = Convert.ToString(dt.Rows[0]["Sensitivity_a"]);
                    tbSenY.Text = Convert.ToString(dt.Rows[0]["Sensitivity_h"]);
                    tbSenZ.Text = Convert.ToString(dt.Rows[0]["Sensitivity_v"]);
                }
                
            }
            catch { }


        }

        private void textBoxX4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }
    }
}
