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
using System.Data.SqlClient;
using System.Collections;
using System.Data.Odbc;
using Iadeptmain.GlobalClasses;
using Iadeptmain.Mainforms;
using Iadeptmain.BaseUserControl;
using System.Data.Common;

namespace Iadeptmain.Mainforms
{
    public partial class Alarms : DevExpress.XtraEditors.XtraForm
    {

        DataTable dt = new DataTable();
        DataTable stddeviationalarmdt = new DataTable();
        DataTable PerAlarmdt = new DataTable();
        frmIAdeptMain _objMain;
        
        string sPercentageAlarmName = null;
        string sStandardAlarmName = null;
        float fStandardAlarmValue = 0;
        double fPercentageAlarmValue = 0;
        string snewalarm = null;
        string sdeletealarm = null;
        string sNewSDAlarm = null;
        Boolean addition, deletion, modification, Preivew, uidd;

        //string FName = null;
        //string BAName = null;
        //double FValue;
        //double fCount;
        //double BAValue;
        //double xAxis;
        //double yAxis;


        public Alarms()
        {
            InitializeComponent();

            if (PublicClass.currentInstrument == "SKF/DI")
            {
                cmbAlarmType.Properties.Items.Clear();
                cmbAlarmType.Properties.Items.Add("--Select--");
                cmbAlarmType.Properties.Items.Add("Acceleration");
                cmbAlarmType.Properties.Items.Add("Velocity");
                cmbAlarmType.Properties.Items.Add("Displacement");
            }
            FillAlarm1ComboBox();
            FillSDAlarmCombo();
            FillPAlarmCombo();

            PublicClass.SeteUserSettings(ref addition, ref deletion, ref modification, ref Preivew, ref uidd, "Alarms");

            if(addition == false && modification == false)
            {
                //tsbtnSave.Enabled = false;
            }
            else
            {
                tsbtnSave.Enabled = true;
            }


           
        }

        private void cmbAlarmlist_SelectedIndexChanged(object sender, EventArgs e)
        {

            float faccel_a1 = 0;
            // double faccel_a1 = 0;
            float faccel_h1 = 0;
            float faccel_v1 = 0;
            float faccel_a2 = 0;
            float faccel_h2 = 0;
            float faccel_v2 = 0;
            float faccel_ch11 = 0;
            float faccel_ch12 = 0;

            float fvel_a1 = 0;
            float fvel_h1 = 0;
            float fvel_v1 = 0;
            float fvel_a2 = 0;
            float fvel_h2 = 0;
            float fvel_v2 = 0;
            float fvel_ch11 = 0;
            float fvel_ch12 = 0;

            float fdispl_a1 = 0;
            float fdispl_h1 = 0;
            float fdispl_v1 = 0;
            float fdispl_a2 = 0;
            float fdispl_h2 = 0;
            float fdispl_v2 = 0;
            float fdispl_ch11 = 0;
            float fdispl_ch12 = 0;

            float fbearing_a1 = 0;
            float fbearing_h1 = 0;
            float fbearing_v1 = 0;
            float fbearing_a2 = 0;
            float fbearing_h2 = 0;
            float fbearing_v2 = 0;
            float fbearing_ch11 = 0;
            float fbearing_ch12 = 0;

            float ftemperature_1 = 0;
            float ftemperature_2 = 0;

            float fcrestfactor_a1 = 0;
            float fcrestfactor_h1 = 0;
            float fcrestfactor_v1 = 0;
            float fcrestfactor_a2 = 0;
            float fcrestfactor_h2 = 0;
            float fcrestfactor_v2 = 0;
            float fcrestfactor_ch11 = 0;
            float fcrestfactor_ch12 = 0;
            string sTEST = null;


            try
            {
                if (cmbAlarmlist.SelectedItem != null)
                {
                    sTEST = cmbAlarmlist.SelectedItem.ToString();
                }
                else
                {
                    sTEST = "None";
                }
                int iAlarmController = 0;
                if (iAlarmController < 0)
                {
                    iAlarmController = 0;
                }

                {

                    DataTable dt = new DataTable();
                    dt = DbClass.getdata(CommandType.StoredProcedure, "call AlarmData_By_AlarmName('" + sTEST + "')");


                    foreach (DataRow dr in dt.Rows)
                    {
                        faccel_a1 = (float)(dr["accel_a1"]);
                        faccel_a2 = (float)(dr["accel_a2"]);
                        faccel_v1 = (float)(dr["accel_v1"]);
                        faccel_v2 = (float)(dr["accel_v2"]);
                        faccel_h1 = (float)(dr["accel_h1"]);
                        faccel_h2 = (float)(dr["accel_h2"]);

                        fvel_a1 = (float)(dr["vel_a1"]);
                        fvel_a2 = (float)(dr["vel_a2"]);
                        fvel_v1 = (float)(dr["vel_v1"]);
                        fvel_v2 = (float)(dr["vel_v2"]);
                        fvel_h1 = (float)(dr["vel_h1"]);
                        fvel_h2 = (float)(dr["vel_h2"]);

                        fdispl_a1 = (float)(dr["displ_a1"]);
                        fdispl_a2 = (float)(dr["displ_a2"]);
                        fdispl_v1 = (float)(dr["displ_v1"]);
                        fdispl_v2 = (float)(dr["displ_v2"]);
                        fdispl_h1 = (float)(dr["displ_h1"]);
                        fdispl_h2 = (float)(dr["displ_h2"]);

                        fbearing_a1 = (float)(dr["bearing_a1"]);
                        fbearing_a2 = (float)(dr["bearing_a2"]);
                        fbearing_v1 = (float)(dr["bearing_v1"]);
                        fbearing_v2 = (float)(dr["bearing_v2"]);
                        fbearing_h1 = (float)(dr["bearing_h1"]);
                        fbearing_h2 = (float)(dr["bearing_h2"]);

                        ftemperature_1 = (float)(dr["temperature_1"]);
                        ftemperature_2 = (float)(dr["temperature_2"]);

                        fcrestfactor_a1 = (float)(dr["crest_factor_a1"]);
                        fcrestfactor_a2 = (float)(dr["crest_factor_a2"]);
                        fcrestfactor_v1 = (float)(dr["crest_factor_v1"]);
                        fcrestfactor_v2 = (float)(dr["crest_factor_v2"]);
                        fcrestfactor_h1 = (float)(dr["crest_factor_h1"]);
                        fcrestfactor_h2 = (float)(dr["crest_factor_h2"]);

                        faccel_ch11 = (float)(dr["accel_ch11"]);
                        faccel_ch12 = (float)(dr["accel_ch12"]);
                        fvel_ch11 = (float)(dr["vel_ch11"]);
                        fvel_ch12 = (float)(dr["vel_ch12"]);
                        fdispl_ch11 = (float)(dr["displ_ch11"]);
                        fdispl_ch12 = (float)(dr["displ_ch12"]);
                        fbearing_ch11 = (float)(dr["bearing_ch11"]);
                        fbearing_ch12 = (float)(dr["bearing_ch12"]);
                        fcrestfactor_ch11 = (float)(dr["crest_factor_ch11"]);
                        fcrestfactor_ch12 = (float)(dr["crest_factor_ch12"]);


                    }
                }
                try
                {

                    txtAxialHigh.Text = faccel_a1.ToString();
                    txtAxialLow.Text = faccel_a2.ToString();
                    txtHorizontalHigh.Text = faccel_h1.ToString();
                    txtHorizontalLow.Text = faccel_h2.ToString();
                    txtVerticalHigh.Text = faccel_v1.ToString();
                    txtVerticalLow.Text = faccel_v2.ToString();

                    txtVAxialHigh.Text = fvel_a1.ToString();
                    txtVAxialLow.Text = fvel_a2.ToString();
                    txtVHorizHigh.Text = fvel_h1.ToString();
                    txtVHorizLow.Text = fvel_h2.ToString();
                    txtVVertHigh.Text = fvel_v1.ToString();
                    txtVVertLow.Text = fvel_v2.ToString();

                    txtDAxialHigh.Text = fdispl_a1.ToString();
                    txtDAxialLow.Text = fdispl_a2.ToString();
                    txtDHorizHigh.Text = fdispl_h1.ToString();
                    txtDHorizLow.Text = fdispl_h2.ToString();
                    txtDVertHigh.Text = fdispl_v1.ToString();
                    txtDVertLow.Text = fdispl_v2.ToString();

                    txtBAxialHigh.Text = fbearing_a1.ToString();
                    txtBAxialLow.Text = fbearing_a2.ToString();
                    txtBHorizHigh.Text = fbearing_h1.ToString();
                    txtBHorizLow.Text = fbearing_h2.ToString();
                    txtBVertHigh.Text = fbearing_v1.ToString();
                    txtBVertLow.Text = fbearing_v2.ToString();

                    txtTHigh.Text = ftemperature_1.ToString();
                    txtTLow.Text = ftemperature_2.ToString();
                }
                catch
                {
                }

                try
                {

                    txtCFAxialHigh.Text = fcrestfactor_a1.ToString();
                    txtCFAxialLow.Text = fcrestfactor_a2.ToString();
                    txtCFHorizHigh.Text = fcrestfactor_h1.ToString();
                    txtCFHorizLow.Text = fcrestfactor_h2.ToString();
                    txtCFVertHigh.Text = fcrestfactor_v1.ToString();
                    txtCFVertLow.Text = fcrestfactor_v2.ToString();
                    txtCh1High.Text = faccel_ch11.ToString();
                    txtCh1Low.Text = faccel_ch12.ToString();
                    txtVCH1High.Text = fvel_ch11.ToString();
                    txtVCH1Low.Text = fvel_ch12.ToString();
                    txtDCh1High.Text = fdispl_ch11.ToString();
                    txtDCh1Low.Text = fdispl_ch12.ToString();
                    txtBCh1High.Text = fbearing_ch11.ToString();
                    txtBCh1Low.Text = fbearing_ch12.ToString();
                    txtCFCH1High.Text = fcrestfactor_ch11.ToString();
                    txtCFCH1Low.Text = fcrestfactor_ch12.ToString();
                }
                catch
                {
                }
            }
            catch
            {

            }

        }

        private void FillAlarm1ComboBox()
        {
            try
            {
                cmbAlarmlist.Properties.Items.Clear();
                dt = DbClass.getdata(CommandType.StoredProcedure, " call GetAlarmName");
                foreach (DataRow dr in dt.Rows)
                {
                    cmbAlarmlist.Properties.Items.Add(dr["Alarm_Name"]);
                    
                }
                cmbAlarmlist.SelectedIndex = -1;
                cmbAlarmType.SelectedIndex = 0;

            }
            catch
            {
            }
        }

        private void FillSDAlarmCombo()
        {
            try
            {
                stddeviationalarmdt = DbClass.getdata(CommandType.StoredProcedure, "call GetSDAlarmWithValue");
                cmbSDAlarmList.Properties.Items.Clear();
                foreach (DataRow dr in stddeviationalarmdt.Rows)
                {
                    cmbSDAlarmList.Properties.Items.Add(Convert.ToString(dr["STDAlarm_Name"]));
                    txtSDValue.Text = Convert.ToString(dr["Deviation_accel"]);
                }
                cmbSDAlarmList.SelectedIndex = 0;
            }
            catch
            {
            }

        }

        private void FillPAlarmCombo()
        {
            try
            {
                PerAlarmdt = DbClass.getdata(CommandType.StoredProcedure, " call GetPAlarmWithValue ");
                cmbPAlarmList.Properties.Items.Clear();
                foreach (DataRow dr in PerAlarmdt.Rows)
                {
                    cmbPAlarmList.Properties.Items.Add(Convert.ToString(dr["PerAlarm_Name"]));
                    txtPValue.Text = Convert.ToString(dr["Per_Accel"]);
                }
                cmbPAlarmList.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        public void CallCancel()
        {
            string sSelectedAlarmName = null;
            try
            {
                if (cmbAlarmlist.SelectedItem != null)
                {
                    sSelectedAlarmName = cmbAlarmlist.SelectedItem.ToString();
                }
                else
                {
                    sSelectedAlarmName = "None";
                    cmbAlarmlist.SelectedIndex = 0;
                }

                if (sSelectedAlarmName != "None")
                {
                    cmbAlarmlist.SelectedIndex = 0;
                    cmbAlarmlist.SelectedItem = sSelectedAlarmName;
                }
                else
                {
                    txtAxialHigh.Text = "0";
                    txtAxialLow.Text = "0";
                    txtHorizontalHigh.Text = "0";
                    txtHorizontalLow.Text = "0";
                    txtVerticalHigh.Text = "0";
                    txtVerticalLow.Text = "0";
                    txtCh1High.Text = "0";
                    txtCh1Low.Text = "0";

                    txtVAxialHigh.Text = "0";
                    txtVAxialLow.Text = "0";
                    txtVHorizHigh.Text = "0";
                    txtVHorizLow.Text = "0";
                    txtVVertHigh.Text = "0";
                    txtVVertLow.Text = "0";
                    txtVCH1High.Text = "0";
                    txtVCH1Low.Text = "0";

                    txtDAxialHigh.Text = "0";
                    txtDAxialLow.Text = "0";
                    txtDHorizHigh.Text = "0";
                    txtDHorizLow.Text = "0";
                    txtDVertHigh.Text = "0";
                    txtDVertLow.Text = "0";
                    txtDCh1High.Text = "0";
                    txtDCh1Low.Text = "0";

                    txtBAxialHigh.Text = "0";
                    txtBAxialLow.Text = "0";
                    txtBHorizHigh.Text = "0";
                    txtBHorizLow.Text = "0";
                    txtBVertHigh.Text = "0";
                    txtBVertLow.Text = "0";
                    txtBCh1High.Text = "0";
                    txtBCh1Low.Text = "0";

                    txtCFAxialHigh.Text = "0";
                    txtCFAxialLow.Text = "0";
                    txtCFHorizHigh.Text = "0";
                    txtCFHorizLow.Text = "0";
                    txtCFVertHigh.Text = "0";
                    txtCFVertLow.Text = "0";
                    txtCFCH1High.Text = "0";
                    txtCFCH1Low.Text = "0";

                    txtTHigh.Text = "0";
                    txtTLow.Text = "0";
                }
            }
            catch (Exception e)
            {

            }
        }
     
        
        private void alarmtxtbox_KeyUp(object sender, KeyEventArgs e)
        {
            string sSelectedAlarmName = null;
            try
            {
                if (cmbAlarmlist.SelectedItem != null)
                {
                    sSelectedAlarmName = cmbAlarmlist.SelectedItem.ToString();
                }
                else
                {
                    sSelectedAlarmName = "None";
                    cmbAlarmlist.SelectedIndex = 0;
                }

                if (sSelectedAlarmName != null)
                {
                  //  bool Change = getValuesFromDataBase(sSelectedAlarmName);
                    //if (Change)
                    //{
                    //    tsbtnSave.Enabled = false;
                    //}
                    //else
                    //{
                    //    tsbtnSave.Enabled = true;
                    //}
                }

            }
            catch
            {

            }
        }

        private bool getValuesFromDataBase(string sSelectedAlarmName)
        {

            float faccel_a1 = 0;
            float faccel_h1 = 0;
            float faccel_v1 = 0;
            float faccel_a2 = 0;
            float faccel_h2 = 0;
            float faccel_v2 = 0;
            float faccel_ch11 = 0;
            float faccel_ch12 = 0;

            float fvel_a1 = 0;
            float fvel_h1 = 0;
            float fvel_v1 = 0;
            float fvel_a2 = 0;
            float fvel_h2 = 0;
            float fvel_v2 = 0;
            float fvel_ch11 = 0;
            float fvel_ch12 = 0;

            float fdispl_a1 = 0;
            float fdispl_h1 = 0;
            float fdispl_v1 = 0;
            float fdispl_a2 = 0;
            float fdispl_h2 = 0;
            float fdispl_v2 = 0;
            float fdispl_ch11 = 0;
            float fdispl_ch12 = 0;

            float fbearing_a1 = 0;
            float fbearing_h1 = 0;
            float fbearing_v1 = 0;
            float fbearing_a2 = 0;
            float fbearing_h2 = 0;
            float fbearing_v2 = 0;
            float fbearing_ch11 = 0;
            float fbearing_ch12 = 0;

            float ftemperature_1 = 0;
            float ftemperature_2 = 0;

            float fcrestfactor_a1 = 0;
            float fcrestfactor_h1 = 0;
            float fcrestfactor_v1 = 0;
            float fcrestfactor_a2 = 0;
            float fcrestfactor_h2 = 0;
            float fcrestfactor_v2 = 0;
            float fcrestfactor_ch11 = 0;
            float fcrestfactor_ch12 = 0;

            float accel_a1 = 0;
            float accel_h1 = 0;
            float accel_v1 = 0;
            float accel_a2 = 0;
            float accel_h2 = 0;
            float accel_v2 = 0;
            float accel_ch11 = 0;
            float accel_ch12 = 0;

            float vel_a1 = 0;
            float vel_h1 = 0;
            float vel_v1 = 0;
            float vel_a2 = 0;
            float vel_h2 = 0;
            float vel_v2 = 0;
            float vel_ch11 = 0;
            float vel_ch12 = 0;

            float displ_a1 = 0;
            float displ_h1 = 0;
            float displ_v1 = 0;
            float displ_a2 = 0;
            float displ_h2 = 0;
            float displ_v2 = 0;
            float displ_ch11 = 0;
            float displ_ch12 = 0;

            float bearing_a1 = 0;
            float bearing_h1 = 0;
            float bearing_v1 = 0;
            float bearing_a2 = 0;
            float bearing_h2 = 0;
            float bearing_v2 = 0;
            float bearing_ch11 = 0;
            float bearing_ch12 = 0;

            float temperature_1 = 0;
            float temperature_2 = 0;

            float crestfactor_a1 = 0;
            float crestfactor_h1 = 0;
            float crestfactor_v1 = 0;
            float crestfactor_a2 = 0;
            float crestfactor_h2 = 0;
            float crestfactor_v2 = 0;
            float crestfactor_ch11 = 0;
            float crestfactor_ch12 = 0;
            bool ack = true;
            string sTEST = sSelectedAlarmName;
            try
            {

                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.StoredProcedure, "call AlarmData_By_AlarmName('" + sTEST + "')");


                foreach (DataRow dr in dt.Rows)
                {
                    try 
                    {
                        faccel_a1 = (float)(dr["accel_a1"]);
                        faccel_a2 = (float)(dr["accel_a2"]);
                        faccel_v1 = (float)(dr["accel_v1"]);
                        faccel_v2 = (float)(dr["accel_v2"]);
                        faccel_h1 = (float)(dr["accel_h1"]);
                        faccel_h2 = (float)(dr["accel_h2"]);

                        fvel_a1 = (float)(dr["vel_a1"]);
                        fvel_a2 = (float)(dr["vel_a2"]);
                        fvel_v1 = (float)(dr["vel_v1"]);
                        fvel_h1 = (float)(dr["vel_h1"]);
                        fvel_h2 = (float)(dr["vel_h2"]);

                        fdispl_a1 = (float)(dr["displ_a1"]);
                        fdispl_a2 = (float)(dr["displ_a2"]);
                        fdispl_v1 = (float)(dr["displ_v1"]);
                        fdispl_v2 = (float)(dr["displ_v2"]);
                        fdispl_h1 = (float)(dr["displ_h1"]);
                        fdispl_h2 = (float)(dr["displ_h2"]);

                        fbearing_a1 = (float)(dr["bearing_a1"]);
                        fbearing_a2 = (float)(dr["bearing_a2"]);
                        fbearing_v1 = (float)(dr["bearing_v1"]);
                        fbearing_v2 = (float)(dr["bearing_v2"]);
                        fbearing_h1 = (float)(dr["bearing_h1"]);
                        fbearing_h2 = (float)(dr["bearing_h2"]);

                        ftemperature_1 = (float)(dr["temperature_1"]);
                        ftemperature_2 = (float)(dr["temperature_2"]);

                        fcrestfactor_a1 = (float)(dr["crest_factor_a1"]);
                        fcrestfactor_a2 = (float)(dr["crest_factor_a2"]);
                        fcrestfactor_v1 = (float)(dr["crest_factor_v1"]);
                        fcrestfactor_v2 = (float)(dr["crest_factor_v2"]);
                        fcrestfactor_h1 = (float)(dr["crest_factor_h1"]);
                        fcrestfactor_h2 = (float)(dr["crest_factor_h2"]);

                        faccel_ch11 = (float)(dr["accel_ch11"]);
                        faccel_ch12 = (float)(dr["accel_ch12"]);
                        fvel_ch11 = (float)(dr["vel_ch11"]);
                        fvel_ch12 = (float)(dr["vel_ch12"]);
                        fdispl_ch11 = (float)(dr["displ_ch11"]);
                        fdispl_ch12 = (float)(dr["displ_ch12"]);
                        fbearing_ch11 = (float)(dr["bearing_ch11"]);
                        fbearing_ch12 = (float)(dr["bearing_ch12"]);
                        fcrestfactor_ch11 = (float)(dr["crest_factor_ch11"]);
                        fcrestfactor_ch12 = (float)(dr["crest_factor_ch12"]);
                    }
                    catch
                    {

                    }
                }

                accel_a1 = (float)Convert.ToDouble(txtAxialHigh.Text);
                accel_h1 = (float)Convert.ToDouble(txtHorizontalHigh.Text);
                accel_v1 = (float)Convert.ToDouble(txtVerticalHigh.Text);
                accel_a2 = (float)Convert.ToDouble(txtAxialLow.Text);
                accel_h2 = (float)Convert.ToDouble(txtHorizontalLow.Text);
                accel_v2 = (float)Convert.ToDouble(txtVerticalLow.Text);

                vel_a1 = (float)Convert.ToDouble(txtVAxialHigh.Text);
                vel_h1 = (float)Convert.ToDouble(txtVHorizHigh.Text);
                vel_v1 = (float)Convert.ToDouble(txtVVertHigh.Text);
                vel_a2 = (float)Convert.ToDouble(txtVAxialLow.Text);
                vel_h2 = (float)Convert.ToDouble(txtVHorizLow.Text);
                vel_v2 = (float)Convert.ToDouble(txtVVertLow.Text);

                displ_a1 = (float)Convert.ToDouble(txtDAxialHigh.Text);
                displ_h1 = (float)Convert.ToDouble(txtDHorizHigh.Text);
                displ_v1 = (float)Convert.ToDouble(txtDVertHigh.Text);
                displ_a2 = (float)Convert.ToDouble(txtDAxialLow.Text);
                displ_h2 = (float)Convert.ToDouble(txtDHorizLow.Text);
                displ_v2 = (float)Convert.ToDouble(txtDVertLow.Text);

                bearing_a1 = (float)Convert.ToDouble(txtBAxialHigh.Text);
                bearing_h1 = (float)Convert.ToDouble(txtBHorizHigh.Text);
                bearing_v1 = (float)Convert.ToDouble(txtBVertHigh.Text);
                bearing_a2 = (float)Convert.ToDouble(txtBAxialLow.Text);
                bearing_h2 = (float)Convert.ToDouble(txtBHorizLow.Text);
                bearing_v2 = (float)Convert.ToDouble(txtBVertLow.Text);

                temperature_1 = (float)Convert.ToDouble(txtTHigh.Text);
                temperature_2 = (float)Convert.ToDouble(txtTLow.Text);

                crestfactor_a1 = (float)Convert.ToDouble(txtCFAxialHigh.Text);
                crestfactor_h1 = (float)Convert.ToDouble(txtCFHorizHigh.Text);
                crestfactor_v1 = (float)Convert.ToDouble(txtCFVertHigh.Text);
                crestfactor_a2 = (float)Convert.ToDouble(txtCFAxialLow.Text);
                crestfactor_h2 = (float)Convert.ToDouble(txtCFHorizLow.Text);
                crestfactor_v2 = (float)Convert.ToDouble(txtCFVertLow.Text);

                accel_ch11 = (float)Convert.ToDouble(txtCh1High.Text);
                accel_ch12 = (float)Convert.ToDouble(txtCh1Low.Text);
                vel_ch11 = (float)Convert.ToDouble(txtVCH1High.Text);
                vel_ch12 = (float)Convert.ToDouble(txtVCH1Low.Text);
                displ_ch11 = (float)Convert.ToDouble(txtDCh1High.Text);
                displ_ch12 = (float)Convert.ToDouble(txtDCh1Low.Text);
                bearing_ch11 = (float)Convert.ToDouble(txtBCh1High.Text);
                bearing_ch12 = (float)Convert.ToDouble(txtBCh1Low.Text);
                crestfactor_ch11 = (float)Convert.ToDouble(txtCFCH1High.Text);
                crestfactor_ch12 = (float)Convert.ToDouble(txtCFCH1Low.Text);
                
                try
                {

                    if (faccel_a1 != accel_a1 || faccel_a2 != accel_a2 || faccel_h1 != accel_h1 || faccel_h2 != accel_h2 || faccel_v1 != accel_v1 || faccel_v2 != accel_v2 || faccel_ch11 != accel_ch11 || faccel_ch12 != accel_ch12 || fvel_a1 != vel_a1 || fvel_a2 != vel_a2 || fvel_h1 != vel_h1 || fvel_h2 != vel_h2 || fvel_v1 != vel_v1 || fvel_v2 != vel_v2 || fvel_ch11 != vel_ch11 || fvel_ch12 != vel_ch12 || fdispl_a1 != displ_a1 || fdispl_a2 != displ_a2 || fdispl_h1 != displ_h1 || fdispl_h2 != displ_h2 || fdispl_v1 != displ_v1 || fdispl_v2 != displ_v2 || fdispl_ch11 != displ_ch11 || fdispl_ch12 != displ_ch12 || fbearing_a1 != bearing_a1 || fbearing_a2 != bearing_a2 || fbearing_h1 != bearing_h1 || fbearing_h2 != bearing_h2 || fbearing_v1 != bearing_v1 || fbearing_v2 != bearing_v2 || fbearing_ch11 != bearing_ch11 || fbearing_ch12 != bearing_ch12 || ftemperature_1 != temperature_1 || ftemperature_2 != temperature_2 || fcrestfactor_a1 != crestfactor_a1 || fcrestfactor_a2 != crestfactor_a2 || fcrestfactor_h1 != crestfactor_h1 || fcrestfactor_h2 != crestfactor_h2 || fcrestfactor_v1 != crestfactor_v1 || fcrestfactor_v2 != crestfactor_v2 || fcrestfactor_ch11 != crestfactor_ch11 || fcrestfactor_ch12 != crestfactor_ch12)
                    {
                        ack = false;
                    }
                }
                catch
                {
                }
            }

            catch
            {

            }
            return ack;
        }

        public string sAddNewAlarm
        {
            get
            {
                return snewalarm;
            }
            set
            {
                snewalarm = value;

                cmbAlarmlist.Properties.Items.Add(snewalarm);
            }
        }

        public string sDeleteoldAlarm
        {
            get
            {
                return sdeletealarm;
            }
            set
            {
                sdeletealarm = value;
                cmbAlarmlist.Properties.Items.Remove(sdeletealarm);
            }
        }

        private void CopyAllAlarmValues(string HighAxial, string LowAxial, string HighVert, string LowVert, string HighHori, string LowHori, string HighCH1, string LowCH1)
        {
            try
            {
                txtAxialHigh.Text = HighAxial;
                txtAxialLow.Text = LowAxial;
                txtVerticalHigh.Text = HighVert;
                txtVerticalLow.Text = LowVert;
                txtHorizontalHigh.Text = HighHori;
                txtHorizontalLow.Text = LowHori;
                txtCh1High.Text = HighCH1;
                txtCh1Low.Text = LowCH1;

                txtVAxialHigh.Text = HighAxial;
                txtVAxialLow.Text = LowAxial;
                txtVVertHigh.Text = HighVert;
                txtVVertLow.Text = LowVert;
                txtVHorizHigh.Text = HighHori;
                txtVHorizLow.Text = LowHori;
                txtVCH1High.Text = HighCH1;
                txtVCH1Low.Text = LowCH1;

                txtBAxialHigh.Text = HighAxial;
                txtBAxialLow.Text = LowAxial;
                txtBVertHigh.Text = HighVert;
                txtBVertLow.Text = LowVert;
                txtBHorizHigh.Text = HighHori;
                txtBHorizLow.Text = LowHori;
                txtBCh1High.Text = HighCH1;
                txtBCh1Low.Text = LowCH1;

                txtDAxialHigh.Text = HighAxial;
                txtDAxialLow.Text = LowAxial;
                txtDVertHigh.Text = HighVert;
                txtDVertLow.Text = LowVert;
                txtDHorizHigh.Text = HighHori;
                txtDHorizLow.Text = LowHori;
                txtDCh1High.Text = HighCH1;
                txtDCh1Low.Text = LowCH1;

                txtCFAxialHigh.Text = HighAxial;
                txtCFAxialLow.Text = LowAxial;
                txtCFVertHigh.Text = HighVert;
                txtCFVertLow.Text = LowVert;
                txtCFHorizHigh.Text = HighHori;
                txtCFHorizLow.Text = LowHori;
                txtCFCH1High.Text = HighCH1;
                txtCFCH1Low.Text = LowCH1;

                alarmtxtbox_KeyUp(null, null);
            }
            catch
            {
            }
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {

            float accel_a1 = 0;
            float accel_h1 = 0;
            float accel_v1 = 0;
            float accel_a2 = 0;
            float accel_h2 = 0;
            float accel_v2 = 0;
            float accel_ch11 = 0;
            float accel_ch12 = 0;

            float vel_a1 = 0;
            float vel_h1 = 0;
            float vel_v1 = 0;
            float vel_a2 = 0;
            float vel_h2 = 0;
            float vel_v2 = 0;
            float vel_ch11 = 0;
            float vel_ch12 = 0;

            float displ_a1 = 0;
            float displ_h1 = 0;
            float displ_v1 = 0;
            float displ_a2 = 0;
            float displ_h2 = 0;
            float displ_v2 = 0;
            float displ_ch11 = 0;
            float displ_ch12 = 0;

            float bearing_a1 = 0;
            float bearing_h1 = 0;
            float bearing_v1 = 0;
            float bearing_a2 = 0;
            float bearing_h2 = 0;
            float bearing_v2 = 0;
            float bearing_ch11 = 0;
            float bearing_ch12 = 0;

            float temperature_1 = 0;
            float temperature_2 = 0;

            float crestfactor_a1 = 0;
            float crestfactor_h1 = 0;
            float crestfactor_v1 = 0;
            float crestfactor_a2 = 0;
            float crestfactor_h2 = 0;
            float crestfactor_v2 = 0;
            float crestfactor_ch11 = 0;
            float crestfactor_ch12 = 0;


            float faccel_a1 = 0;
            float faccel_h1 = 0;
            float faccel_v1 = 0;
            float faccel_a2 = 0;
            float faccel_h2 = 0;
            float faccel_v2 = 0;
            float faccel_ch11 = 0;
            float faccel_ch12 = 0;

            float fvel_a1 = 0;
            float fvel_h1 = 0;
            float fvel_v1 = 0;
            float fvel_a2 = 0;
            float fvel_h2 = 0;
            float fvel_v2 = 0;
            float fvel_ch11 = 0;
            float fvel_ch12 = 0;

            float fdispl_a1 = 0;
            float fdispl_h1 = 0;
            float fdispl_v1 = 0;
            float fdispl_a2 = 0;
            float fdispl_h2 = 0;
            float fdispl_v2 = 0;
            float fdispl_ch11 = 0;
            float fdispl_ch12 = 0;

            float fbearing_a1 = 0;
            float fbearing_h1 = 0;
            float fbearing_v1 = 0;
            float fbearing_a2 = 0;
            float fbearing_h2 = 0;
            float fbearing_v2 = 0;
            float fbearing_ch11 = 0;
            float fbearing_ch12 = 0;

            float ftemperature_1 = 0;
            float ftemperature_2 = 0;

            float fcrestfactor_a1 = 0;
            float fcrestfactor_h1 = 0;
            float fcrestfactor_v1 = 0;
            float fcrestfactor_a2 = 0;
            float fcrestfactor_h2 = 0;
            float fcrestfactor_v2 = 0;
            float fcrestfactor_ch11 = 0;
            float fcrestfactor_ch12 = 0;
            bool bAlarmEntry = true;

            string sToLowerAlarmNameFD = null;
            string sToLowerAlarmNameFF = null;
            string sSelectedAlarmName = null;

            string sAName = null;
            string sPointID = null;
            string sPointName = null;
            bool bGenerated = false;
            bool bAlready = false;
            string sAlarmID = null;
            string sAID = null;
            try
            {
                if (cmbAlarmlist.SelectedItem != null)
                {
                    sSelectedAlarmName = cmbAlarmlist.SelectedItem.ToString();

                }
                else
                {
                    sSelectedAlarmName = "None";
                    cmbAlarmlist.SelectedIndex = 0;
                }

                if (sSelectedAlarmName != null)
                {
                    bool Change = getValuesFromDataBase(sSelectedAlarmName);

                    if (!Change)
                    {
                        try
                        {
                            accel_a1 = (float)Convert.ToDouble(txtAxialHigh.Text);
                            accel_h1 = (float)Convert.ToDouble(txtHorizontalHigh.Text);
                            accel_v1 = (float)Convert.ToDouble(txtVerticalHigh.Text);
                            accel_a2 = (float)Convert.ToDouble(txtAxialLow.Text);
                            accel_h2 = (float)Convert.ToDouble(txtHorizontalLow.Text);
                            accel_v2 = (float)Convert.ToDouble(txtVerticalLow.Text);

                            vel_a1 = (float)Convert.ToDouble(txtVAxialHigh.Text);
                            vel_h1 = (float)Convert.ToDouble(txtVHorizHigh.Text);
                            vel_v1 = (float)Convert.ToDouble(txtVVertHigh.Text);
                            vel_a2 = (float)Convert.ToDouble(txtVAxialLow.Text);
                            vel_h2 = (float)Convert.ToDouble(txtVHorizLow.Text);
                            vel_v2 = (float)Convert.ToDouble(txtVVertLow.Text);

                            displ_a1 = (float)Convert.ToDouble(txtDAxialHigh.Text);
                            displ_h1 = (float)Convert.ToDouble(txtDHorizHigh.Text);
                            displ_v1 = (float)Convert.ToDouble(txtDVertHigh.Text);
                            displ_a2 = (float)Convert.ToDouble(txtDAxialLow.Text);
                            displ_h2 = (float)Convert.ToDouble(txtDHorizLow.Text);
                            displ_v2 = (float)Convert.ToDouble(txtDVertLow.Text);

                            bearing_a1 = (float)Convert.ToDouble(txtBAxialHigh.Text);
                            bearing_h1 = (float)Convert.ToDouble(txtBHorizHigh.Text);
                            bearing_v1 = (float)Convert.ToDouble(txtBVertHigh.Text);
                            bearing_a2 = (float)Convert.ToDouble(txtBAxialLow.Text);
                            bearing_h2 = (float)Convert.ToDouble(txtBHorizLow.Text);
                            bearing_v2 = (float)Convert.ToDouble(txtBVertLow.Text);

                            temperature_1 = (float)Convert.ToDouble(txtTHigh.Text);
                            temperature_2 = (float)Convert.ToDouble(txtTLow.Text);

                            crestfactor_a1 = (float)Convert.ToDouble(txtCFAxialHigh.Text);
                            crestfactor_h1 = (float)Convert.ToDouble(txtCFHorizHigh.Text);
                            crestfactor_v1 = (float)Convert.ToDouble(txtCFVertHigh.Text);
                            crestfactor_a2 = (float)Convert.ToDouble(txtCFAxialLow.Text);
                            crestfactor_h2 = (float)Convert.ToDouble(txtCFHorizLow.Text);
                            crestfactor_v2 = (float)Convert.ToDouble(txtCFVertLow.Text);

                            accel_ch11 = (float)Convert.ToDouble(txtCh1High.Text);
                            accel_ch12 = (float)Convert.ToDouble(txtCh1Low.Text);
                            vel_ch11 = (float)Convert.ToDouble(txtVCH1High.Text);
                            vel_ch12 = (float)Convert.ToDouble(txtVCH1Low.Text);
                            displ_ch11 = (float)Convert.ToDouble(txtDCh1High.Text);
                            displ_ch12 = (float)Convert.ToDouble(txtDCh1Low.Text);
                            bearing_ch11 = (float)Convert.ToDouble(txtBCh1High.Text);
                            bearing_ch12 = (float)Convert.ToDouble(txtBCh1Low.Text);
                            crestfactor_ch11 = (float)Convert.ToDouble(txtCFCH1High.Text);
                            crestfactor_ch12 = (float)Convert.ToDouble(txtCFCH1Low.Text);
                        }
                        catch 
                        { 
                        }
                        
                        if (accel_a1 < accel_a2 || accel_h1 < accel_h2 || accel_v1 < accel_v2 || vel_a1 < vel_a2 || vel_h1 < vel_h2 || vel_v1 < vel_v2 || displ_a1 < displ_a2 || displ_h1 < displ_h2 || displ_v1 < displ_v2 || bearing_a1 < bearing_a2 || bearing_h1 < bearing_h2 || bearing_v1 < bearing_v2 || temperature_1 < temperature_2 || crestfactor_a1 < crestfactor_a2 || crestfactor_h1 < crestfactor_h2 || crestfactor_v1 < crestfactor_v2 || accel_ch11 < accel_ch12 || vel_ch11 < vel_ch12 || displ_ch11 < displ_ch12 || bearing_ch11 < bearing_ch12 || crestfactor_ch11 < crestfactor_ch12)
                        {
                            bAlarmEntry = false;

                            MessageBox.Show("Values not Correct for Alarm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (accel_a1 < 0 || accel_a2 < 0 || accel_h1 < 0 || accel_h2 < 0 || accel_v1 < 0 || accel_v2 < 0 || vel_a1 < 0 || vel_a2 < 0 || vel_h1 < 0 || vel_h2 < 0 || vel_v1 < 0 || vel_v2 < 0 || displ_a1 < 0 || displ_a2 < 0 || displ_h1 < 0 || displ_h2 < 0 || displ_v1 < 0 || displ_v2 < 0 || bearing_a1 < 0 || bearing_a2 < 0 || bearing_h1 < 0 || bearing_h2 < 0 || bearing_v1 < 0 || bearing_v2 < 0 || crestfactor_a1 < 0 || crestfactor_a2 < 0 || crestfactor_h1 < 0 || crestfactor_h2 < 0 || crestfactor_v1 < 0 || crestfactor_v2 < 0 || accel_ch11 < 0 || accel_ch12 < 0 || vel_ch11 < 0 || vel_ch12 < 0 || displ_ch11 < 0 || displ_ch12 < 0 || bearing_ch11 < 0 || bearing_ch12 < 0 || crestfactor_ch11 < 0 || crestfactor_ch12 < 0)
                        {
                            bAlarmEntry = false;

                            MessageBox.Show("Negative Values not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DialogResult Drslt = MessageBox.Show("Press Yes to Modify this alarm" + "\n" + "Press NO to Create New Alarm" + "\n" + "Press Cancel to Close", "Alarm Modification", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                          
                            if (Drslt == DialogResult.Yes)
                            {
                                 if(modification == false)
                                 {
                                     MessageBox.Show("Not allowed");
                                     return;
                                 }
                                if (sSelectedAlarmName == "None")
                                {
                                    MessageBox.Show("Cannot Modify this alarm");
                                    bAlarmEntry = false;
                                }
                                else
                                {
                                    DataTable dt = new DataTable();

                                    dt = DbClass.getdata(CommandType.StoredProcedure, "call Get_AlarmId_By_AlarmName('"+ sSelectedAlarmName +"')");

                                  

                                    foreach (DataRow dr in dt.Rows)
                                    {
                                    
                                        sAID = Convert.ToString(dr["Alarm_ID"]);
                                    }

                                    DataTable dtt = new DataTable();
                                    dtt = DbClass.getdata(CommandType.StoredProcedure, "call GetPointTypeId_By_AlarmId('" + sAID + "')");

                                    foreach(DataRow dr in dtt.Rows)
                                    {
                                        sPointID = Convert.ToString(dr["Type_ID"]);
                                        sPointName = Convert.ToString(dr["Point_Name"]);
                                    }
                                    if (dtt.Rows.Count > 0)
                                    {
                                        bGenerated = true;
                                        MessageBox.Show("Alarm In Use on Point Type " + sPointName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        dt = DbClass.getdata(CommandType.StoredProcedure, "call AlarmData_By_AlarmName` ('" + sSelectedAlarmName.Trim() + "')");
                                        //dt = DbClass.getdata(CommandType.Text, "select * from alarms_data where   Alarm_Name=   '" + sSelectedAlarmName.Trim() + "' ");

                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            faccel_a1 = (float)(dr["accel_a1"]);
                                            faccel_a2 = (float)(dr["accel_a2"]);
                                            faccel_v1 = (float)(dr["accel_v1"]);
                                            faccel_v2 = (float)(dr["accel_v2"]);
                                            faccel_h1 = (float)(dr["accel_h1"]);
                                            faccel_h2 = (float)(dr["accel_h2"]);

                                            fvel_a1 = (float)(dr["vel_a1"]);
                                            fvel_a2 = (float)(dr["vel_a2"]);
                                            fvel_v1 = (float)(dr["vel_v1"]);
                                            fvel_v2 = (float)(dr["vel_v2"]);
                                            fvel_h1 = (float)(dr["vel_h1"]);
                                            fvel_h2 = (float)(dr["vel_h2"]);

                                            fdispl_a1 = (float)(dr["displ_a1"]);
                                            fdispl_a2 = (float)(dr["displ_a2"]);
                                            fdispl_v1 = (float)(dr["displ_v1"]);
                                            fdispl_v2 = (float)(dr["displ_v2"]);
                                            fdispl_h1 = (float)(dr["displ_h1"]);
                                            fdispl_h2 = (float)(dr["displ_h2"]);

                                            fbearing_a1 = (float)(dr["bearing_a1"]);
                                            fbearing_a2 = (float)(dr["bearing_a2"]);
                                            fbearing_v1 = (float)(dr["bearing_v1"]);
                                            fbearing_v2 = (float)(dr["bearing_v2"]);
                                            fbearing_h1 = (float)(dr["bearing_h1"]);
                                            fbearing_h2 = (float)(dr["bearing_h2"]);

                                            ftemperature_1 = (float)(dr["temperature_1"]);
                                            ftemperature_2 = (float)(dr["temperature_2"]);

                                            fcrestfactor_a1 = (float)(dr["crest_factor_a1"]);
                                            fcrestfactor_a2 = (float)(dr["crest_factor_a2"]);
                                            fcrestfactor_v1 = (float)(dr["crest_factor_v1"]);
                                            fcrestfactor_v2 = (float)(dr["crest_factor_v2"]);
                                            fcrestfactor_h1 = (float)(dr["crest_factor_h1"]);
                                            fcrestfactor_h2 = (float)(dr["crest_factor_h2"]);

                                            faccel_ch11 = (float)(dr["accel_ch11"]);
                                            faccel_ch12 = (float)(dr["accel_ch12"]);
                                            fvel_ch11 = (float)(dr["vel_ch11"]);
                                            fvel_ch12 = (float)(dr["vel_ch12"]);
                                            fdispl_ch11 = (float)(dr["displ_ch11"]);
                                            fdispl_ch12 = (float)(dr["displ_ch12"]);
                                            fbearing_ch11 = (float)(dr["bearing_ch11"]);
                                            fbearing_ch12 = (float)(dr["bearing_ch12"]);
                                            fcrestfactor_ch11 = (float)(dr["crest_factor_ch11"]);
                                            fcrestfactor_ch12 = (float)(dr["crest_factor_ch12"]);

                                            try
                                            {

                                                if (faccel_a1 == accel_a1 && faccel_a2 == accel_a2 && faccel_h1 == accel_h1 && faccel_h2 == accel_h2 && faccel_v1 == accel_v1 && faccel_v2 == accel_v2 && fvel_a1 == vel_a1 && fvel_a2 == vel_a2 && fvel_h1 == vel_h1 && fvel_h2 == vel_h2 && fvel_v1 == vel_v1 && fvel_v2 == vel_v2 && fdispl_a1 == displ_a1 && fdispl_a2 == displ_a2 && fdispl_h1 == displ_h1 && fdispl_h2 == displ_h2 && fdispl_v1 == displ_v1 && fdispl_v2 == displ_v2 && fbearing_a1 == bearing_a1 && fbearing_a2 == bearing_a2 && fbearing_h1 == bearing_h1 && fbearing_h2 == bearing_h2 && fbearing_v1 == bearing_v1 && fbearing_v2 == bearing_v2 && ftemperature_1 == temperature_1 && ftemperature_2 == temperature_2 && fcrestfactor_a1 == crestfactor_a1 && fcrestfactor_a2 == crestfactor_a2 && fcrestfactor_h1 == crestfactor_h1 && fcrestfactor_h2 == crestfactor_h2 && fcrestfactor_v1 == crestfactor_v1 && fcrestfactor_v2 == crestfactor_v2 &&
                                                    faccel_ch11 == accel_ch11 && faccel_ch12 == accel_ch12 &&
                                                    fvel_ch11 == vel_ch11 && fvel_ch12 == vel_ch12 &&
                                                    fdispl_ch11 == displ_ch11 && fdispl_ch12 == displ_ch12 &&
                                                    fbearing_ch11 == bearing_ch11 && fbearing_ch12 == bearing_ch12 &&
                                                    fcrestfactor_ch11 == crestfactor_ch11 && fcrestfactor_ch12 == crestfactor_ch12)
                                                {
                                                    bAlready = true;
                                                    MessageBox.Show("Alarm Already Generated for the same Values", "Alarms", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            catch
                                            {

                                            }

                                            try
                                            {

                                                if (accel_a1 < accel_a2 || accel_h1 < accel_h2 || accel_v1 < accel_v2 || vel_a1 < vel_a2 || vel_h1 < vel_h2 || vel_v1 < vel_v2 || displ_a1 < displ_a2 || displ_h1 < displ_h2 || displ_v1 < displ_v2 || bearing_a1 < bearing_a2 || bearing_h1 < bearing_h2 || bearing_v1 < bearing_v2 || temperature_1 < temperature_2 || crestfactor_a1 < crestfactor_a2 || crestfactor_h1 < crestfactor_h2 || crestfactor_v1 < crestfactor_v2 || accel_ch11 < accel_ch12 || vel_ch11 < vel_ch12 || displ_ch11 < displ_ch12 || bearing_ch11 < bearing_ch12 || crestfactor_ch11 < crestfactor_ch12)
                                                {
                                                    bAlready = true;
                                                    MessageBox.Show("Values not Correct for Alarm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            catch
                                            {
                                            }

                                        }
                                        if (bAlready == false)
                                        {
                                            try
                                            {

                                                DbClass.executequery(CommandType.StoredProcedure, " call   Update_Alarm ( " + accel_a1 + "," + accel_h1 + "," + accel_v1 + ", " + accel_a2 + ", " + accel_h2 + "," + accel_v2 +
                                                                                                          ", " + accel_ch11 + "," + accel_ch12 +
                                                                                                          ", " + vel_ch11 + "," + vel_ch12 +
                                                                                                          "," + displ_ch11 + "," + displ_ch12 +
                                                                                                           ", " + bearing_ch11 + ", " + bearing_ch12 +
                                                                                                            ", " + crestfactor_ch11 + ", " + crestfactor_ch12 +
                                                                                                          ", " + vel_a1 + ", " + vel_h1 + "," + vel_v1 + ", " + vel_a2 + ", " + vel_h2 + ", " + vel_v2 +
                                                                                                          ", " + displ_a1 + ", " + displ_h1 + ", " + displ_v1 + ", " + displ_a2 + ", " + displ_h2 + "," + displ_v2 +
                                                                                                          "," + bearing_a1 + ", " + bearing_h1 + "," + bearing_v1 + "," + bearing_a2 + "," + bearing_h2 + ", " + bearing_v2 + "," + temperature_1 + ", " + temperature_2 +
                                                                                                          ", " + crestfactor_a1 + "," + crestfactor_h1 + ", " + crestfactor_v1 + ", " + crestfactor_a2 + ", " + crestfactor_h2 + ", " + crestfactor_v2 + " ,'" + sSelectedAlarmName.Trim() + "'  )");

                                            }
                                            catch
                                            {

                                            }

                                            MessageBox.Show("Alarm Values Modified", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            cmbAlarmlist.SelectedIndex = 0;
                                            cmbAlarmType.SelectedIndex = 0;
                                        }
                                    }

                                    DataTable ddt = new DataTable();
                                    ddt = DbClass.getdata(CommandType.StoredProcedure, "call AlarmData_By_AlarmName ('" + sSelectedAlarmName.Trim() + "')");

                                    foreach (DataRow dr in ddt.Rows)
                                    {
                                        faccel_a1 = (float)(dr["accel_a1"]);
                                        faccel_a2 = (float)(dr["accel_a2"]);
                                        faccel_v1 = (float)(dr["accel_v1"]);
                                        faccel_v2 = (float)(dr["accel_v2"]);
                                        faccel_h1 = (float)(dr["accel_h1"]);
                                        faccel_h2 = (float)(dr["accel_h2"]);

                                        fvel_a1 = (float)(dr["vel_a1"]);
                                        fvel_a2 = (float)(dr["vel_a2"]);
                                        fvel_v1 = (float)(dr["vel_v1"]);
                                        fvel_v2 = (float)(dr["vel_v2"]);
                                        fvel_h1 = (float)(dr["vel_h1"]);
                                        fvel_h2 = (float)(dr["vel_h2"]);

                                        fdispl_a1 = (float)(dr["displ_a1"]);
                                        fdispl_a2 = (float)(dr["displ_a2"]);
                                        fdispl_v1 = (float)(dr["displ_v1"]);
                                        fdispl_v2 = (float)(dr["displ_v2"]);
                                        fdispl_h1 = (float)(dr["displ_h1"]);
                                        fdispl_h2 = (float)(dr["displ_h2"]);

                                        fbearing_a1 = (float)(dr["bearing_a1"]);
                                        fbearing_a2 = (float)(dr["bearing_a2"]);
                                        fbearing_v1 = (float)(dr["bearing_v1"]);
                                        fbearing_v2 = (float)(dr["bearing_v2"]);
                                        fbearing_h1 = (float)(dr["bearing_h1"]);
                                        fbearing_h2 = (float)(dr["bearing_h2"]);

                                        ftemperature_1 = (float)(dr["temperature_1"]);
                                        ftemperature_2 = (float)(dr["temperature_2"]);

                                        fcrestfactor_a1 = (float)(dr["crest_factor_a1"]);
                                        fcrestfactor_a2 = (float)(dr["crest_factor_a2"]);
                                        fcrestfactor_v1 = (float)(dr["crest_factor_v1"]);
                                        fcrestfactor_v2 = (float)(dr["crest_factor_v2"]);
                                        fcrestfactor_h1 = (float)(dr["crest_factor_h1"]);
                                        fcrestfactor_h2 = (float)(dr["crest_factor_h2"]);

                                        faccel_ch11 = (float)(dr["accel_ch11"]);
                                        faccel_ch12 = (float)(dr["accel_ch12"]);
                                        fvel_ch11 = (float)(dr["vel_ch11"]);
                                        fvel_ch12 = (float)(dr["vel_ch12"]);
                                        fdispl_ch11 = (float)(dr["displ_ch11"]);
                                        fdispl_ch12 = (float)(dr["displ_ch12"]);
                                        fbearing_ch11 = (float)(dr["bearing_ch11"]);
                                        fbearing_ch12 = (float)(dr["bearing_ch12"]);
                                        fcrestfactor_ch11 = (float)(dr["crest_factor_ch11"]);
                                        fcrestfactor_ch12 = (float)(dr["crest_factor_ch12"]);

                                    }

                                    txtAxialHigh.Text = faccel_a1.ToString();
                                    txtAxialLow.Text = faccel_a2.ToString();
                                    txtHorizontalHigh.Text = faccel_h1.ToString();
                                    txtHorizontalLow.Text = faccel_h2.ToString();
                                    txtVerticalHigh.Text = faccel_v1.ToString();
                                    txtVerticalLow.Text = faccel_v2.ToString();

                                    txtVAxialHigh.Text = fvel_a1.ToString();
                                    txtVAxialLow.Text = fvel_a2.ToString();
                                    txtVHorizHigh.Text = fvel_h1.ToString();
                                    txtVHorizLow.Text = fvel_h2.ToString();
                                    txtVVertHigh.Text = fvel_v1.ToString();
                                    txtVVertLow.Text = fvel_v2.ToString();

                                    txtDAxialHigh.Text = fdispl_a1.ToString();
                                    txtDAxialLow.Text = fdispl_a2.ToString();
                                    txtDHorizHigh.Text = fdispl_h1.ToString();
                                    txtDHorizLow.Text = fdispl_h2.ToString();
                                    txtDVertHigh.Text = fdispl_v1.ToString();
                                    txtDVertLow.Text = fdispl_v2.ToString();

                                    txtBAxialHigh.Text = fbearing_a1.ToString();
                                    txtBAxialLow.Text = fbearing_a2.ToString();
                                    txtBHorizHigh.Text = fbearing_h1.ToString();
                                    txtBHorizLow.Text = fbearing_h2.ToString();
                                    txtBVertHigh.Text = fbearing_v1.ToString();
                                    txtBVertLow.Text = fbearing_v2.ToString();

                                    txtTHigh.Text = ftemperature_1.ToString();
                                    txtTLow.Text = ftemperature_2.ToString();

                                    txtCFAxialHigh.Text = fcrestfactor_a1.ToString();
                                    txtCFAxialLow.Text = fcrestfactor_a2.ToString();
                                    txtCFHorizHigh.Text = fcrestfactor_h1.ToString();
                                    txtCFHorizLow.Text = fcrestfactor_h2.ToString();
                                    txtCFVertHigh.Text = fcrestfactor_v1.ToString();
                                    txtCFVertLow.Text = fcrestfactor_v2.ToString();

                                    txtCh1High.Text = faccel_ch11.ToString();
                                    txtCh1Low.Text = faccel_ch12.ToString();
                                    txtVCH1High.Text = fvel_ch11.ToString();
                                    txtVCH1Low.Text = fvel_ch12.ToString();
                                    txtDCh1High.Text = fdispl_ch11.ToString();
                                    txtDCh1Low.Text = fdispl_ch12.ToString();
                                    txtBCh1High.Text = fbearing_ch11.ToString();
                                    txtBCh1Low.Text = fbearing_ch12.ToString();
                                    txtCFCH1High.Text = fcrestfactor_ch11.ToString();
                                    txtCFCH1Low.Text = fcrestfactor_ch12.ToString();

                                }
                            }

                            else if (Drslt == DialogResult.No)
                            {

                                if(addition == false)
                                {
                                    MessageBox.Show("You have not allowed to make new Alarms");
                                    return;
                                }
                                

                                NewAlarm objNewAlarm = new NewAlarm();
                                objNewAlarm.ShowDialog();

                                string sAlarmName = objNewAlarm.AlarmName;
                                sToLowerAlarmNameFF = sAlarmName.ToLower();

                                try
                                {

                                    if (accel_a1 < accel_a2 || accel_h1 < accel_h2 || accel_v1 < accel_v2 || vel_a1 < vel_a2 || vel_h1 < vel_h2 || vel_v1 < vel_v2 || displ_a1 < displ_a2 || displ_h1 < displ_h2 || displ_v1 < displ_v2 || bearing_a1 < bearing_a2 || bearing_h1 < bearing_h2 || bearing_v1 < bearing_v2 || temperature_1 < temperature_2 || crestfactor_a1 < crestfactor_a2 || crestfactor_h1 < crestfactor_h2 || crestfactor_v1 < crestfactor_v2 || accel_ch11 < accel_ch12 || vel_ch11 < vel_ch12 || displ_ch11 < displ_ch12 || bearing_ch11 < bearing_ch12 || crestfactor_ch11 < crestfactor_ch12)
                                    {
                                        bAlarmEntry = false;

                                        MessageBox.Show("Values not Correct for Alarm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch
                                {

                                }
                                if (sAlarmName != null && sAlarmName != "")
                                {

                                    string AlarmName = null;
                                    dt = DbClass.getdata(CommandType.StoredProcedure, "call Get_AlarmData");

                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        faccel_a1 = (float)(dr["accel_a1"]);
                                        faccel_a2 = (float)(dr["accel_a2"]);
                                        faccel_v1 = (float)(dr["accel_v1"]);
                                        faccel_v2 = (float)(dr["accel_v2"]);
                                        faccel_h1 = (float)(dr["accel_h1"]);
                                        faccel_h2 = (float)(dr["accel_h2"]);

                                        fvel_a1 = (float)(dr["vel_a1"]);
                                        fvel_a2 = (float)(dr["vel_a2"]);
                                        fvel_v1 = (float)(dr["vel_v1"]);
                                        fvel_v2 = (float)(dr["vel_v2"]);
                                        fvel_h1 = (float)(dr["vel_h1"]);
                                        fvel_h2 = (float)(dr["vel_h2"]);

                                        fdispl_a1 = (float)(dr["displ_a1"]);
                                        fdispl_a2 = (float)(dr["displ_a2"]);
                                        fdispl_v1 = (float)(dr["displ_v1"]);
                                        fdispl_v2 = (float)(dr["displ_v2"]);
                                        fdispl_h1 = (float)(dr["displ_h1"]);
                                        fdispl_h2 = (float)(dr["displ_h2"]);

                                        fbearing_a1 = (float)(dr["bearing_a1"]);
                                        fbearing_a2 = (float)(dr["bearing_a2"]);
                                        fbearing_v1 = (float)(dr["bearing_v1"]);
                                        fbearing_v2 = (float)(dr["bearing_v2"]);
                                        fbearing_h1 = (float)(dr["bearing_h1"]);
                                        fbearing_h2 = (float)(dr["bearing_h2"]);

                                        ftemperature_1 = (float)(dr["temperature_1"]);
                                        ftemperature_2 = (float)(dr["temperature_2"]);

                                        fcrestfactor_a1 = (float)(dr["crest_factor_a1"]);
                                        fcrestfactor_a2 = (float)(dr["crest_factor_a2"]);
                                        fcrestfactor_v1 = (float)(dr["crest_factor_v1"]);
                                        fcrestfactor_v2 = (float)(dr["crest_factor_v2"]);
                                        fcrestfactor_h1 = (float)(dr["crest_factor_h1"]);
                                        fcrestfactor_h2 = (float)(dr["crest_factor_h2"]);

                                        faccel_ch11 = (float)(dr["accel_ch11"]);
                                        faccel_ch12 = (float)(dr["accel_ch12"]);
                                        fvel_ch11 = (float)(dr["vel_ch11"]);
                                        fvel_ch12 = (float)(dr["vel_ch12"]);
                                        fdispl_ch11 = (float)(dr["displ_ch11"]);
                                        fdispl_ch12 = (float)(dr["displ_ch12"]);
                                        fbearing_ch11 = (float)(dr["bearing_ch11"]);
                                        fbearing_ch12 = (float)(dr["bearing_ch12"]);
                                        fcrestfactor_ch11 = (float)(dr["crest_factor_ch11"]);
                                        fcrestfactor_ch12 = (float)(dr["crest_factor_ch12"]);

                                        AlarmName = dr["Alarm_Name"].ToString();
                                        sToLowerAlarmNameFD = AlarmName.ToLower();

                                        try
                                        {

                                            if (faccel_a1 == accel_a1 && faccel_a2 == accel_a2 && faccel_h1 == accel_h1 && faccel_h2 == accel_h2 && faccel_v1 == accel_v1 && faccel_v2 == accel_v2 && fvel_a1 == vel_a1 && fvel_a2 == vel_a2 && fvel_h1 == vel_h1 && fvel_h2 == vel_h2 && fvel_v1 == vel_v1 && fvel_v2 == vel_v2 && fdispl_a1 == displ_a1 && fdispl_a2 == displ_a2 && fdispl_h1 == displ_h1 && fdispl_h2 == displ_h2 && fdispl_v1 == displ_v1 && fdispl_v2 == displ_v2 && fbearing_a1 == bearing_a1 && fbearing_a2 == bearing_a2 && fbearing_h1 == bearing_h1 && fbearing_h2 == bearing_h2 && fbearing_v1 == bearing_v1 && fbearing_v2 == bearing_v2 && ftemperature_1 == temperature_1 && ftemperature_2 == temperature_2 && fcrestfactor_a1 == crestfactor_a1 && fcrestfactor_a2 == crestfactor_a2 && fcrestfactor_h1 == crestfactor_h1 && fcrestfactor_h2 == crestfactor_h2 && fcrestfactor_v1 == crestfactor_v1 && fcrestfactor_v2 == crestfactor_v2 &&
                                                faccel_ch11 == accel_ch11 && faccel_ch12 == accel_ch12 &&
                                                fvel_ch11 == vel_ch11 && fvel_ch12 == vel_ch12 &&
                                                fdispl_ch11 == displ_ch11 && fdispl_ch12 == displ_ch12 &&
                                                fbearing_ch11 == bearing_ch11 && fbearing_ch12 == bearing_ch12 &&
                                                fcrestfactor_ch11 == crestfactor_ch11 && fcrestfactor_ch12 == crestfactor_ch12)
                                            {
                                                bAlready = true;
                                                MessageBox.Show("Alarm Already Generated for the same Values", "Alarms", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else if (sToLowerAlarmNameFD == sToLowerAlarmNameFF)
                                            {
                                                bAlarmEntry = false;

                                                MessageBox.Show("Alarm Already Exists with the same Name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        catch
                                        {
                                           
                                        }
                                    }
                                }
                                else if (sAlarmName == null)
                                {
                                    bAlarmEntry = false;
                                }
                                else if (sAlarmName == "")
                                {
                                    bAlarmEntry = false;
                                    MessageBox.Show("Alarm Name not Entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                try
                                {

                                    string alarmid = null;
                                     DataTable dtn = new DataTable();
                                     dtn = DbClass.getdata(CommandType.StoredProcedure, "call AlarmId_By_CurrentPointTypeId('" + PublicClass.SPointTypeId + "')");

                                    foreach (DataRow dr in dtn.Rows)
                                    {
                                        alarmid = Convert.ToString(dr["Alarm_ID"]);
                                    }
                                    
                                    if (dtn.Rows.Count > 0)
                                    {
                                        bGenerated = true;
                                    }
                                    if (bGenerated == true)
                                    {
                                        dt = DbClass.getdata(CommandType.StoredProcedure, "call PointName_By_CurrentPointTypeId('" + PublicClass.SPointTypeId + "')");
                                        //dt = DbClass.getdata(CommandType.Text, "select PointName from point where Point_ID='" + PublicClass.SPointID + "'");

                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            sPointName = Convert.ToString(dr["Point_Name"]);
                                        }

                                        MessageBox.Show("Another Alarm is alredy set on point Type " + sPointName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        bAlarmEntry = false;
                                    }

                                }
                                catch 
                                {
                                }
                                


                                if (bAlarmEntry == true)
                                {
                                    try
                                    {

                                        DbClass.executequery(CommandType.StoredProcedure, "call Insert_Alarm (" + accel_a1 + "," + accel_h1 + "," + accel_v1 + "," + accel_a2 + "," + accel_h2 + "," + accel_v2 + "," + accel_ch11 + "," + accel_ch12 + "," + vel_a1 + "," + vel_h1 + "," + vel_v1 + "," + vel_a2 + "," + vel_h2 + "," + vel_v2 + "," + vel_ch11 + "," + vel_ch12 + "," + displ_a1 + "," + displ_h1 + "," + displ_v1 + "," + displ_a2 + "," + displ_h2 + "," + displ_v2 + "," + displ_ch11 + "," + displ_ch12 + "," + bearing_a1 + "," + bearing_h1 + "," + bearing_v1 + "," + bearing_a2 + "," + bearing_h2 + "," + bearing_v2 + "," + bearing_ch11 + "," + bearing_ch12 + "," + crestfactor_a1 + "," + crestfactor_h1 + "," + crestfactor_v1 + "," + crestfactor_a2 + "," + crestfactor_h2 + "," + crestfactor_v2 + "," + crestfactor_ch11 + "," + crestfactor_ch12 + "," + temperature_1 + "," + temperature_2 + ",'" + sAlarmName + "')");

                                       
                                    }
                                    catch
                                    {

                                    }
                                    MessageBox.Show("Alarm Values Accecpted", "Alarms", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                   
                                    FillAlarm1ComboBox();
                                  
                                    cmbAlarmlist.SelectedIndex = 0;
                                    cmbAlarmType.SelectedIndex = 0;
                                    _objMain.lblStatus.Caption = "Status: Alarms Saved Successfully";
                                }
                            }

                            else if (Drslt == DialogResult.Cancel)
                            {
                                CallCancel();
                                _objMain.lblStatus.Caption = "Status: Alarms Canceled";
                            }
                            //if (bAlarmEntry)
                            //{
                            //    tsbtnSave.Enabled = false;
                            //}

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void DeleteGeneralAlarm()
        {
            string vPointID = null;
            int sAlarmID = 0;
            
                if (Convert.ToString(cmbAlarmlist.SelectedItem).Trim () != "None")
                {
                   sAlarmID = getAlarmID(Convert.ToString(cmbAlarmlist.SelectedItem));

                    if (Convert.ToString(cmbAlarmlist.SelectedItem).Trim() != null)
                    {
                        DataTable dts = new DataTable();
                        dts = DbClass.getdata(CommandType.StoredProcedure, "call GetPointTypeId_By_AlarmId('" + sAlarmID + "')");
                        foreach (DataRow dr in dts.Rows)
                        {
                            vPointID = Convert.ToString(dr["Type_ID"]);
                        }
                        if (dts.Rows.Count > 0)
                        {
                            MessageBox.Show("Alarm is using on Point ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if(deletion)
                        {
                            DbClass.executequery(CommandType.StoredProcedure, "call DeleteAlarms_By_AlarmName('" + Convert.ToString(cmbAlarmlist.SelectedItem).Trim() + "')");

                            FillAlarm1ComboBox();
                            cmbAlarmlist.SelectedText = "--Select--";
                            cmbAlarmType.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("You are not allowed to delete alarms");
                        }

                    }
                   
                }

              
        }

        public void DeleteSDAlarm()
        {
            string sdAlarmid = null;           
            try
            {
                if (Convert.ToString(cmbSDAlarmList.SelectedItem).Trim() != "None")
                {
                    stddeviationalarmdt = DbClass.getdata(CommandType.StoredProcedure, " call STDAlarmId_By_STDAlarmName('" + Convert.ToString(cmbSDAlarmList.SelectedItem).Trim() + "')");
                    foreach (DataRow dr in stddeviationalarmdt.Rows)
                    {
                        sdAlarmid = Convert.ToString(dr["STDDeviationAlarm_ID"]);
                    }

                    DataTable dtt = new DataTable();
                    dtt = DbClass.getdata(CommandType.Text, "select tp.id from stddeviationalarm sd inner join type_point tp on tp.STDDeviationAlarm_ID=sd.STDDeviationAlarm_ID where sd.STDDeviationAlarm_ID='" + sdAlarmid + "' ");
                    if (dtt.Rows.Count > 0)
                    {
                        MessageBox.Show("Deviation Alarm Use in Point Type ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (deletion)
                    {
                        DbClass.executequery(CommandType.StoredProcedure, "call DeleteSTDAlarm_by_Name('" + Convert.ToString(cmbSDAlarmList.SelectedItem).Trim() + "')");
                        _objMain.lblStatus.Caption = "Status: Deviation Alarm Deleted Successfully";
                        MessageBox.Show("Alarms Deleted Successfully", "Alarm Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillSDAlarmCombo();
                        cmbSDAlarmList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete alarms");
                    }
                }
            }
            catch
            {
            }           
        }

        public void DeletePAlarm()
        {
            if (Convert.ToString(cmbPAlarmList.SelectedItem).Trim() != "None")
            {
                string pAlarmID = null;              
                try
                {
                    PerAlarmdt = DbClass.getdata(CommandType.StoredProcedure, " call Get_PAlarmID_By_PAlarmName('" + Convert.ToString(cmbPAlarmList.SelectedItem).Trim() + "')");
                    foreach (DataRow dr in PerAlarmdt.Rows)
                    {
                        pAlarmID = Convert.ToString(dr["Percentage_AlarmID"]);
                    }
                    DataTable dtp = new DataTable();
                    dtp = DbClass.getdata(CommandType.Text, "select tp.id from percentage_alarm pa inner join type_point tp on tp.Percentage_AlarmID=pa.Percentage_AlarmID where pa.Percentage_AlarmID='" + pAlarmID + "'");
                    if (dtp.Rows.Count > 0)
                    {
                        MessageBox.Show("Percentage Alarm use in Point Type ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (deletion)
                    {
                        DbClass.executequery(CommandType.StoredProcedure, "call DeletePAlarm_By_PName('" + Convert.ToString(cmbPAlarmList.SelectedItem).Trim() + "')");
                        _objMain.lblStatus.Caption = "Status: Deleted Percentage Alarm Successfully";
                        MessageBox.Show("Alarms Deleted Successfully", "Alarm Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillPAlarmCombo();
                        cmbPAlarmList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to delete alarms");
                    }
                }
                catch { }
            }
        }


        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            string sSelectedAlarmName = "";
            try
            {
                sSelectedAlarmName = Convert.ToString(cmbAlarmlist.SelectedItem).Trim();
                if (sSelectedAlarmName != "")
                {
                    if(deletion == false)
                    {
                        MessageBox.Show("You have not allowed to delete any alarms");
                        return;
                    }

                    if ((MessageBox.Show("Are You Sure You Want to Delete this Alarm", "Alarm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                    {
                        if (sSelectedAlarmName == "None" || sSelectedAlarmName == "ISO-G1-R" || sSelectedAlarmName == "ISO-G1-F" || sSelectedAlarmName == "ISO-G2-R" || sSelectedAlarmName == "ISO-G2-F" || sSelectedAlarmName == "ISO-G3-R" || sSelectedAlarmName == "ISO-G3-F" || sSelectedAlarmName == "ISO-G4-R" || sSelectedAlarmName == "ISO-G4-F")
                        {
                            MessageBox.Show("Can Not Delete these Alarm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                        else if (cmbAlarmlist.SelectedItem != null)
                        {
                            DeleteGeneralAlarm();
                            _objMain.lblStatus.Caption = "Status: Deleted General Alarms Successfully";
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select alarm for delete");
                    _objMain.lblStatus.Caption = "Status: Select Alarm";
                }

            }

            catch { }  
             
        }

        public frmIAdeptMain MainForm
        {
            get
            {
                return _objMain;
            }

            set
            {
                _objMain = value;

            }

        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            try
            {
                _objMain.fillform();
            }
            catch { }
        }

        private void Alarms_Load(object sender, EventArgs e)
        {
            gbAcceleration.Visible = false;
            gbBearing.Visible = false;
            gbCrestFactor.Visible = false;
            gbDisplacement.Visible = false;
            gbVelocity.Visible = false;
            gbTemperature.Visible = false;
            cmbAlarmlist.SelectedIndex = 0;
            cmbAlarmType.SelectedIndex = 0;
            cmbSDAlarmList.SelectedIndex = 0;
            cmbPAlarmList.SelectedIndex = 0;
            //tsbtnSave.Enabled = false;
            fillASetting();
           
        }

        private void cmbAlarmType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string ss = cmbAlarmType.Text.Trim();
                pnlAlarmType.Controls.Remove(gbAcceleration);
                pnlAlarmType.Controls.Remove(gbBearing);
                pnlAlarmType.Controls.Remove(gbCrestFactor);
                pnlAlarmType.Controls.Remove(gbDisplacement);
                pnlAlarmType.Controls.Remove(gbVelocity);
                pnlAlarmType.Controls.Remove(gbTemperature);

                switch (ss.Trim())
                {
                    case "Acceleration":
                        {
                            gbAcceleration.Visible = true;
                            gbAcceleration.Dock = DockStyle.Fill;
                            if (PublicClass.currentInstrument == "SKF/DI")
                            {
                                txtCh1High.Enabled = false;
                                txtCh1Low.Enabled = false;
                            }
                            pnlAlarmType.Controls.Add(gbAcceleration);                           
                            break;

                        }
                    case "Velocity":
                        {
                            gbVelocity.Visible = true;
                            gbVelocity.Dock = DockStyle.Fill;
                            if (PublicClass.currentInstrument == "SKF/DI")
                            {
                                txtVCH1High.Enabled = false;
                                txtVCH1Low.Enabled = false;
                            }
                            pnlAlarmType.Controls.Add(gbVelocity);
                            break;
                        }
                    case "Displacement":
                        {
                            gbDisplacement.Visible = true;
                            gbDisplacement.Dock = DockStyle.Fill;
                            if (PublicClass.currentInstrument == "SKF/DI")
                            {
                                txtDCh1High.Enabled = false;
                                txtDCh1Low.Enabled = false;
                            }
                            pnlAlarmType.Controls.Add(gbDisplacement);
                            break;
                        }
                    case "Bearing":
                        {
                            gbBearing.Visible = true;
                            gbBearing.Dock = DockStyle.Fill;
                            pnlAlarmType.Controls.Add(gbBearing);
                            break;
                        }
                    case "Crest Factor":
                        {
                            gbCrestFactor.Visible = true;
                            gbCrestFactor.Dock = DockStyle.Fill;
                            pnlAlarmType.Controls.Add(this.gbCrestFactor);
                            break;
                        }
                    case "Temperature":
                        {
                            this.gbTemperature.Visible = true;
                            gbTemperature.Dock = DockStyle.Fill;
                            pnlAlarmType.Controls.Add(gbTemperature);
                            break;
                        }
                    default:
                        {
                            gbAcceleration.Visible = false;
                            gbBearing.Visible = false;
                            gbCrestFactor.Visible = false;
                            gbDisplacement.Visible = false;
                            gbVelocity.Visible = false;
                            gbTemperature.Visible = false;
                            break;
                        }
                }
            }
            catch
            {
            }
        }

        string HighAxial = null;
        string LowAxial = null;
        string HighVert = null;
        string LowVert = null;
        string HighHori = null;
        string LowHori = null;
        string HighCH1 = null;
        string LowCH1 = null;

        public void CopyToAll(string HighAxial, string LowAxial, string HighVert, string LowVert, string HighHori, string LowHori, string HighCH1, string LowCH1)
        {
            string aTypename = Convert.ToString(cmbAlarmType.Text.Trim());
            if (HighAxial != "0" || LowAxial != "0" || HighVert != "0" || LowVert != "0" || HighHori != "0" || LowHori != "0" || HighCH1 != "0" || LowCH1 != "0") 
            {
                if ((HighAxial != "0" && HighVert != "0") || (LowAxial != "0" && LowVert != "0"))
                {
                    MessageBox.Show(this, "Remaining values for High and Low should be 0 for copy to all this");
                    return;
                }
                else if ((HighVert != "0" && HighHori != "0") || (LowVert != "0" && LowHori != "0"))
                {
                    MessageBox.Show(this, "Remaining values for High and Low should be 0 for copy to all this");
                    return;
                }
                else if ((HighHori != "0" && HighCH1 != "0") || (LowHori != "0" && LowCH1 != "0"))
                {
                    MessageBox.Show(this, "Remaining values for High and Low should be 0 for copy to all this");
                    return;
                }
                else if ((HighCH1 != "0" && HighAxial != "0") || (LowCH1 != "0" && LowAxial != "0"))
                {
                    MessageBox.Show(this, "Remaining values for High and Low should be 0 for copy to all this");
                    return;
                }
                    switch (aTypename)
                    {
                        case "Acceleration":
                            {
                                if (HighAxial != "0" || LowAxial != "0")
                                {
                                    setValueForAcceleration(HighAxial, LowAxial);
                                } 
                                else if (HighVert != "0" || LowVert != "0")
                                {
                                    setValueForAcceleration(HighVert, LowVert);
                                }
                                else if (HighHori != "0" || LowHori != "0")
                                {
                                    setValueForAcceleration(HighHori, LowHori);
                                }
                                else if (HighHori != "0" || LowHori != "0")
                                {
                                    setValueForAcceleration(HighCH1, LowCH1);
                                }
                                break;
                            }
                        case "Velocity":
                            {
                                if (HighAxial != "0" || LowAxial != "0")
                                {
                                    setValueForVelocity(HighAxial, LowAxial);
                                }
                                else if (HighVert != "0" || LowVert != "0")
                                {
                                    setValueForVelocity(HighVert, LowVert);
                                }
                                else if (HighHori != "0" || LowHori != "0")
                                {
                                    setValueForVelocity(HighHori, LowHori);
                                }
                                else if (HighHori != "0" || LowHori != "0")
                                {
                                    setValueForVelocity(HighCH1, LowCH1);
                                }
                                
                                break;
                            }
                        case "Displacement":
                            {
                                if (HighAxial != "0" || LowAxial != "0")
                                {
                                    setValueForDisplacement(HighAxial, LowAxial);
                                }
                                else if (HighVert != "0" || LowVert != "0")
                                {
                                    setValueForDisplacement(HighVert, LowVert);
                                }
                                else if (HighHori != "0" || LowHori != "0")
                                {
                                    setValueForDisplacement(HighHori, LowHori);
                                }
                                else if (HighHori != "0" || LowHori != "0")
                                {
                                    setValueForDisplacement(HighCH1, LowCH1);
                                }
                                
                                break;
                            }
                        case "Bearing":
                            {
                                if (HighAxial != "0" || LowAxial != "0")
                                {
                                    setValueForBearing(HighAxial, LowAxial);
                                }
                                else if (HighVert != "0" || LowVert != "0")
                                {
                                    setValueForBearing(HighVert, LowVert);
                                }
                                else if (HighHori != "0" || LowHori != "0")
                                {
                                    setValueForBearing(HighHori, LowHori);
                                }
                                else if (HighHori != "0" || LowHori != "0")
                                {
                                    setValueForBearing(HighCH1, LowCH1);
                                }
                                
                                break;
                            }
                        case "Crest Factor":
                            {
                                if (HighAxial != "0" || LowAxial != "0")
                                {
                                    setValueForCrestFactor(HighAxial, LowAxial);
                                }
                                else if (HighVert != "0" || LowVert != "0")
                                {
                                    setValueForCrestFactor(HighVert, LowVert);
                                }
                                else if (HighHori != "0" || LowHori != "0")
                                {
                                    setValueForCrestFactor(HighHori, LowHori);
                                }
                                else if (HighHori != "0" || LowHori != "0")
                                {
                                    setValueForCrestFactor(HighCH1, LowCH1);
                                }
                                
                                break;
                            }
                        
                    }
                

            }
            
           
        }

        public void setValueForAcceleration(string aHigh , string aLow)
        {
            try
            {
                txtAxialHigh.Text = aHigh;
                txtAxialLow.Text = aLow;
                txtVerticalHigh.Text = aHigh;
                txtVerticalLow.Text = aLow;
                txtHorizontalHigh.Text = aHigh;
                txtHorizontalLow.Text = aLow;
                txtCh1High.Text = aHigh;
                txtCh1Low.Text = aLow;
            }
            catch
            {

            }
        }

        public void setValueForVelocity(string vHigh , string vLow )
        {
            try
            {
                txtVAxialHigh.Text = vHigh;
                txtVAxialLow.Text = vLow;
                txtVVertHigh.Text = vHigh;
                txtVVertLow.Text = vLow;
                txtVHorizHigh.Text = vHigh;
                txtVHorizLow.Text = vLow;
                txtVCH1High.Text = vHigh;
                txtVCH1Low.Text = vLow;
            }
            catch
            {

            }
        }

        public void setValueForDisplacement(string dHigh , string dLow)
        {
            try
            {
                txtDAxialHigh.Text = dHigh;
                txtDAxialLow.Text = dLow;
                txtDVertHigh.Text = dHigh;
                txtDVertLow.Text = dLow;
                txtDHorizHigh.Text = dHigh;
                txtDHorizLow.Text = dLow;
                txtDCh1High.Text = dHigh;
                txtDCh1Low.Text = dLow;
            }
            catch
            {

            }
        }

        public void setValueForCrestFactor(string cfHigh , string cfLow)
        {
            try
            {
                txtCFAxialHigh.Text = cfHigh;
                txtCFAxialLow.Text = cfLow;
                txtCFVertHigh.Text = cfHigh;
                txtCFVertLow.Text = cfLow;
                txtCFHorizHigh.Text = cfHigh;
                txtCFHorizLow.Text = cfLow;
                txtCFCH1High.Text = cfHigh;
                txtCFCH1Low.Text = cfLow;
            }
            catch
            {

            }
        }

        public void setValueForBearing(string bHigh , string bLow)
        {
            try
            {
                txtBAxialHigh.Text = bHigh;
                txtBAxialLow.Text = bLow;
                txtBVertHigh.Text = bHigh;
                txtBVertLow.Text = bLow;
                txtBHorizHigh.Text = bHigh;
                txtBHorizLow.Text = bLow;
                txtBCh1High.Text = bHigh;
                txtBCh1Low.Text = bLow;
            }
            catch
            {

            }
        }

        private void btnCTAAcc_Click(object sender, EventArgs e)
        {
            try
            {

                string HighAxial = txtAxialHigh.Text;
                string LowAxial = txtAxialLow.Text;
                string HighVert = txtVerticalHigh.Text;
                string LowVert = txtVerticalLow.Text;
                string HighHori = txtHorizontalHigh.Text;
                string LowHori = txtHorizontalLow.Text;
                string HighCH1 = txtCh1High.Text;
                string LowCH1 = txtCh1Low.Text;

                CopyToAll(HighAxial, LowAxial, HighVert, LowVert, HighHori, LowHori, HighCH1, LowCH1);
            }

            catch { }

        }

        private void btnCTAVel_Click(object sender, EventArgs e)
        {
            try
            {
                string HighAxial = txtVAxialHigh.Text;
                string LowAxial = txtVAxialLow.Text;
                string HighVert = txtVVertHigh.Text;
                string LowVert = txtVVertLow.Text;
                string HighHori = txtVHorizHigh.Text;
                string LowHori = txtVHorizLow.Text;
                string HighCH1 = txtVCH1High.Text;
                string LowCH1 = txtVCH1Low.Text;

                CopyToAll(HighAxial, LowAxial, HighVert, LowVert, HighHori, LowHori, HighCH1, LowCH1);
            }
            catch
            {
            }


        }

        private void btnCTADisp_Click(object sender, EventArgs e)
        {
            try
            {
                


                string HighAxial = txtDAxialHigh.Text;
                string LowAxial = txtDAxialLow.Text;
                string HighVert = txtDVertHigh.Text;
                string LowVert = txtDVertLow.Text;
                string HighHori = txtDHorizHigh.Text;
                string LowHori = txtDHorizLow.Text;
                string HighCH1 = txtDCh1High.Text;
                string LowCH1 = txtDCh1Low.Text;

                CopyToAll(HighAxial, LowAxial, HighVert, LowVert, HighHori, LowHori, HighCH1, LowCH1);
                _objMain.lblStatus.Caption = "Status: Copying Alarms";
            }
            catch
            {
            }

        }

        private void btnCTABear_Click(object sender, EventArgs e)
        {
            try
            {
                string HighAxial = txtBAxialHigh.Text;
                string LowAxial = txtBAxialLow.Text;
                string HighVert = txtBVertHigh.Text;
                string LowVert = txtBVertLow.Text;
                string HighHori = txtBHorizHigh.Text;
                string LowHori = txtBHorizLow.Text;
                string HighCH1 = txtBCh1High.Text;
                string LowCH1 = txtBCh1Low.Text;

                CopyToAll(HighAxial, LowAxial, HighVert, LowVert, HighHori, LowHori, HighCH1, LowCH1);
            }
            catch
            {

            }
        }

        private void btnCTACF_Click(object sender, EventArgs e)
        {

            try
            {
                string HighAxial = txtCFAxialHigh.Text;
                string LowAxial = txtCFAxialLow.Text;
                string HighVert = txtCFVertHigh.Text;
                string LowVert = txtCFVertLow.Text;
                string HighHori = txtCFHorizHigh.Text;
                string LowHori = txtCFHorizLow.Text;
                string HighCH1 = txtCFCH1High.Text;
                string LowCH1 = txtCFCH1Low.Text;

                CopyToAll(HighAxial, LowAxial, HighVert, LowVert, HighHori, LowHori, HighCH1, LowCH1);
            }
            catch
            {

            }
        }

        public string AddSDAlarm
        {
            get
            {
                return sNewSDAlarm;
            }
            set
            {
                sNewSDAlarm = value;
                cmbSDAlarmList.Properties.Items.Add((sNewSDAlarm));
            }
        }

        private void btnSDNew_Click(object sender, EventArgs e)
        {
            _objMain.lblStatus.Caption = "Status: Creating New Standard Deviation Alarms";
            string SDAlarmNameFD = null;
            float fSDalarmValueFD = 0;
            bool bEntry = true;
            try
            {
                frmSDAlarm sd = new frmSDAlarm();
                sd.ShowDialog();

                sStandardAlarmName = sd.SDPercentName;
                fStandardAlarmValue = sd.SDPercentValue;

                if( bEntry == true)
                {
                    if(sStandardAlarmName == "" || fStandardAlarmValue == 0.0)
                    {
                        MessageBox.Show("You have not entered any alarm Name");
                        return;
                    }


                    DataTable dt = new DataTable();

                    dt = DbClass.getdata(CommandType.StoredProcedure, " call Get_STDAlarm");

                    foreach (DataRow dr in dt.Rows)
                    {
                        SDAlarmNameFD = Convert.ToString(dr["STDAlarm_Name"]);
                        fSDalarmValueFD = (float)Convert.ToDouble(dr["Deviation_accel"]);
                        

                        if (SDAlarmNameFD == sStandardAlarmName)
                        {
                            bEntry = false;
                            MessageBox.Show("Alarm with Same Name Found");
                            return;
                        }
                        if (fStandardAlarmValue != 0)
                        {
                            if (fSDalarmValueFD == fStandardAlarmValue)
                            {
                                bEntry = false;
                                MessageBox.Show("Alarm with Same Value Found");
                                return;
                            }
                        }
                    }
                    bEntry = false ;

                }
                if(bEntry == false)
                {
                    try
                    {
                        DbClass.executequery(CommandType.StoredProcedure, " call Insert_SDAlarm('" + sStandardAlarmName.Trim() + "','" + fStandardAlarmValue + "','" + fStandardAlarmValue + "','" + fStandardAlarmValue + "','" + fStandardAlarmValue + "')");
                        MessageBox.Show("Alarm Values Accecpted", "SD Alarms", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillSDAlarmCombo();
                        cmbSDAlarmList.SelectedItem = sStandardAlarmName.Trim();
                        _objMain.lblStatus.Caption = "Status: Creating New Standard Deviation Alarms Successfully";
                    }
                    catch
                    {

                    }
                }

            }
            catch
            {
            }
        }

        private void cmbSDAlarmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                foreach (DataRow dr in stddeviationalarmdt.Select("STDAlarm_Name = '" + Convert.ToString(cmbSDAlarmList.Text).Trim() + "' "))
                {
                    txtSDValue.Text = Convert.ToString(dr["Deviation_accel"]);
                }


            }
            catch { }
        }

      
        private void btnPNew_Click(object sender, EventArgs e)
        {
            _objMain.lblStatus.Caption = "Status: Creating New Percentage Alarms";
            string PAlarmNameFD = null;
            float fPalarmValueFD = 0;
            bool bEntry = true;
            try
            {
                frmPAlarm objPAlarm = new frmPAlarm();
                objPAlarm.ShowDialog();

                if (Convert.ToString(objPAlarm.txtPName.Text).Trim() == "")
                {
                    return;
                }
                sPercentageAlarmName = objPAlarm.txtPName.Text.Trim();
                fPercentageAlarmValue = Convert.ToDouble(objPAlarm.txtPValue.Text);

                if (bEntry == true)
                {
                    DataTable dt = new DataTable();

                    dt = DbClass.getdata(CommandType.Text, "Select PerAlarm_Name , Per_Accel from percentage_alarm");

                    foreach (DataRow dr in dt.Rows)
                    {
                        PAlarmNameFD = Convert.ToString(dr["PerAlarm_Name"]);
                        fPalarmValueFD = (float)Convert.ToDouble(dr["Per_Accel"]);

                        if (PAlarmNameFD == sPercentageAlarmName)
                        {
                            bEntry = false;
                            MessageBox.Show("Alarm with Same Name Found");
                            return;
                        }
                        
                            if (fPalarmValueFD == fPercentageAlarmValue)
                            {
                                bEntry = false;
                                MessageBox.Show("Alarm with Same Value Found");
                                return;
                            }
                        
                    }
                    bEntry = false;

                }
                if (bEntry == false)
                {
                    try
                    {
                        DbClass.executequery(CommandType.StoredProcedure, "call Insert_PAlarm('" + sPercentageAlarmName + "','" + fPercentageAlarmValue + "','" + fPercentageAlarmValue + "','" + fPercentageAlarmValue + "','" + fPercentageAlarmValue + "')");

                        MessageBox.Show("Alarm Values Accecpted", "Percentage Alarms", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
                        FillPAlarmCombo();
                        cmbPAlarmList.SelectedItem = sPercentageAlarmName.Trim();
                        _objMain.lblStatus.Caption = "Status: Creating New Percentage Alarms Successfully";
                    }
                    catch
                    {

                    }
                }




              // FillPAlarmCombo();

            }
            catch
            { }
        }

        private void btnDelPAlarm_Click(object sender, EventArgs e)
        {
            //string pAlarmID = null;
            //string sPointID = "";
            //try
            //{
            //    string pName = cmbPAlarmList.Text;
            //    if (pName.Trim() == "None")
            //    {
            //        MessageBox.Show("Can Not Delete this Alarm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //    else
            //    {
            //        if ((MessageBox.Show("Are You Sure You Want to Delete this Alarm", "Alarm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            //        {


            //            PerAlarmdt = DbClass.getdata(CommandType.StoredProcedure, " call Get_PAlarmID_By_PAlarmName('" + pName + "')");
            //            foreach (DataRow dr in PerAlarmdt.Rows)
            //            {
            //                pAlarmID = Convert.ToString(dr["Percentage_AlarmID"]);
            //            }
            //            DataTable dtp = new DataTable();
            //            dtp = DbClass.getdata(CommandType.Text, "select distinct a.Point_ID, a.PointType_ID, b.id, aa.Percentage_AlarmID from  point a left join type_point b on  a.PointType_ID=b.ID  left join  percentage_alarm aa on aa.Percentage_AlarmID=b.Percentage_AlarmID where aa.Percentage_AlarmID= '" + pAlarmID + "'");
            //            foreach(DataRow dr in dtp.Rows)
            //            {
            //                sPointID = Convert.ToString(dr["Point_ID"]);
            //            }
            //            if(dtp.Rows.Count > 0)
            //            {
            //                MessageBox.Show("Alarm In Use on Point ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //                return;
            //            }
            //            else
            //            {
            //                DbClass.executequery(CommandType.StoredProcedure, "call DeletePAlarm_By_PName('" + pName + "')");
            //                MessageBox.Show("Alarm Deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                FillPAlarmCombo();
            //                cmbPAlarmList.SelectedIndex = 0;
            //            }

            //        }
            //    }

            //}
            //catch
            //{
            //}

        }

        private void cmbPAlarmList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow dr in PerAlarmdt.Select("PerAlarm_Name = '" + Convert.ToString(cmbPAlarmList.Text).Trim() + "' "))
                {
                    txtPValue.Text = Convert.ToString(dr["Per_Accel"]);
                }
            }
            catch 
            { 
            }

        }
        
        private void dgvFaultFreq_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            
        }
       
        public int getAlarmID(string AlarmName)
        {
            int aID = 0 ;
            try
            {
                 DataTable dtaID = DbClass.getdata(CommandType.StoredProcedure, "call AlarmData_By_AlarmName('" + AlarmName + "') ");
                aID = Convert.ToInt32(dtaID.Rows[0]["Alarm_ID"]);
            }
            catch{}
            return aID;
        }
        private void dgvBAPH_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dgvBAPH.IsCurrentCellDirty)
            //{
            //    dgvBAPH.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }

        private void dgvBAPH_Leave(object sender, EventArgs e)
        {

         
        }

        private void dgvBAPH_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvBADA_Leave(object sender, EventArgs e)
        {
            

        }

        private void dgvBADA_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvBADA_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
        }

        private void dgvFaultFreq_Leave(object sender, EventArgs e)
        {
          
        }

        private void dgvFaultFreq_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvFaultFreq_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void dgvBADA_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dgvBAPH_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        public void ChangeTextboxSettings()
        {
            try
            {
                if(chkSettings == true)
                {
                    txtAxialHigh.Enabled = false;
                    txtHorizontalHigh.Enabled = false;
                    txtVerticalHigh.Enabled = false;
                    txtAxialLow.Enabled = false;
                    txtHorizontalLow.Enabled = false;
                    txtVerticalLow.Enabled = false;
                    txtCh1High.Enabled = false;
                    txtCh1Low.Enabled = false;

                    txtVAxialHigh.Enabled = false;
                    txtVHorizHigh.Enabled = false;
                    txtVVertHigh.Enabled = false;
                    txtVAxialLow.Enabled = false;
                    txtVHorizLow.Enabled = false; ;
                    txtVVertLow.Enabled = false;
                    txtVCH1High.Enabled = false;
                    txtVCH1Low.Enabled = false;

                    txtDAxialHigh.Enabled = false;
                    txtDHorizHigh.Enabled = false;
                    txtDVertHigh.Enabled = false;
                    txtDAxialLow.Enabled = false;
                    txtDHorizLow.Enabled = false;
                    txtDVertLow.Enabled = false;
                    txtDCh1High.Enabled = false;
                    txtDCh1Low.Enabled = false;

                    txtBAxialHigh.Enabled = false;
                    txtBHorizHigh.Enabled = false;
                    txtBVertHigh.Enabled = false;
                    txtBAxialLow.Enabled = false;
                    txtBHorizLow.Enabled = false;
                    txtBVertLow.Enabled = false;
                    txtBCh1High.Enabled = false;
                    txtBCh1Low.Enabled = false;

                    txtCFAxialHigh.Enabled = false;
                    txtCFHorizHigh.Enabled = false;
                    txtCFVertHigh.Enabled = false;
                    txtCFAxialLow.Enabled = false;
                    txtCFHorizLow.Enabled = false;
                    txtCFVertLow.Enabled = false;
                    txtCFCH1High.Enabled = false;
                    txtCFCH1Low.Enabled = false;

                    txtTHigh.Enabled = false;
                    txtTLow.Enabled = false;

                    txtSDValue.Enabled = false;
                    txtPValue.Enabled = false;

                    btnCTAAcc.Enabled = false;
                    btnCTABear.Enabled = false;
                    btnCTACF.Enabled = false;
                    btnCTADisp.Enabled = false;
                    btnCTAVel.Enabled = false;

                    btnSDNew.Enabled = false;
                    btnPNew.Enabled = false;


                
                }
                else
                {
                    txtAxialHigh.Enabled = true;
                    txtHorizontalHigh.Enabled = true;
                    txtVerticalHigh.Enabled = true;
                    txtAxialLow.Enabled = true;
                    txtHorizontalLow.Enabled = true;
                    txtVerticalLow.Enabled = true;
                    txtCh1High.Enabled = true;
                    txtCh1Low.Enabled = true;

                    txtVAxialHigh.Enabled = true;
                    txtVHorizHigh.Enabled = true;
                    txtVVertHigh.Enabled = true;
                    txtVAxialLow.Enabled = true;
                    txtVHorizLow.Enabled = true; ;
                    txtVVertLow.Enabled = true;
                    txtVCH1High.Enabled = true;
                    txtVCH1Low.Enabled = true;

                    txtDAxialHigh.Enabled = true;
                    txtDHorizHigh.Enabled = true;
                    txtDVertHigh.Enabled = true;
                    txtDAxialLow.Enabled = true;
                    txtDHorizLow.Enabled = true;
                    txtDVertLow.Enabled = true;
                    txtDCh1High.Enabled = true;
                    txtDCh1Low.Enabled = true;

                    txtBAxialHigh.Enabled = true;
                    txtBHorizHigh.Enabled = true;
                    txtBVertHigh.Enabled = true;
                    txtBAxialLow.Enabled = true;
                    txtBHorizLow.Enabled = true;
                    txtBVertLow.Enabled = true;
                    txtBCh1High.Enabled = true;
                    txtBCh1Low.Enabled = true;

                    txtCFAxialHigh.Enabled = true;
                    txtCFHorizHigh.Enabled = true;
                    txtCFVertHigh.Enabled = true;
                    txtCFAxialLow.Enabled = true;
                    txtCFHorizLow.Enabled = true;
                    txtCFVertLow.Enabled = true;
                    txtCFCH1High.Enabled = true;
                    txtCFCH1Low.Enabled = true;

                    txtTHigh.Enabled = true;
                    txtTLow.Enabled = true;

                    txtSDValue.Enabled = true;
                    txtPValue.Enabled = true;

                    btnCTAAcc.Enabled = true;
                    btnCTABear.Enabled = true;
                    btnCTACF.Enabled = true;
                    btnCTADisp.Enabled = true;
                    btnCTAVel.Enabled = true;

                    btnSDNew.Enabled = true;
                    btnPNew.Enabled = true;
                
                }

                

            }
            catch
            {

            }
        }
        public bool chkSettings = false;

       public void fillASetting()
        {
            try
            {
            }
            catch
            {
            }
        }

       private void btnDevDelete_Click(object sender, EventArgs e)
       {
           try
           {
               string sSdAlarmName = null;
               sSdAlarmName = Convert.ToString(cmbSDAlarmList.SelectedItem).Trim();
               if ((MessageBox.Show("Are You Sure You Want to Delete this Alarm", "Alarm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
               {
                   if (sSdAlarmName == "None")
                   {
                       MessageBox.Show("Can Not Delete these Alarm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return;
                   }
                   if (sSdAlarmName != null || sSdAlarmName != "")
                   {
                       DeleteSDAlarm();
                      
                   }
               }
               else
               {
                   return;
               }
           }
           catch { }
           
       }

       private void btnPerDelete_Click(object sender, EventArgs e)
       {
           try
           {
               string sPerAlarmName = null;
               sPerAlarmName = Convert.ToString(cmbPAlarmList.SelectedItem).Trim();
               if ((MessageBox.Show("Are You Sure You Want to Delete this Alarm", "Alarm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
               {
                   if (sPerAlarmName == "None")
                   {
                       MessageBox.Show("Can Not Delete these Alarm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return;
                   }
                   if (sPerAlarmName != null || sPerAlarmName != "")
                   {
                       DeletePAlarm();                      
                   }
               }
               else
               {
                   return;
               }
           }
           catch { }
       }

    }
}