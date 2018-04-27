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
using Iadeptmain.BaseUserControl;
using System.Data.SqlClient;
using Iadeptmain.GlobalClasses;
using System.Text.RegularExpressions;

namespace Iadeptmain.Mainforms
{
    public partial class FrmPointType : DevExpress.XtraEditors.XtraForm
    {
        frmIAdeptMain _objMain;
        DataTable dtSensorName = new DataTable();
        DataTable dttempName = new DataTable();
        DataTable dtPType = new DataTable();
        DataTable DtPercentageAlarm = new DataTable();
        DataTable DtDeviationAlarm = new DataTable();
        DataTable DtGeneralAlram = new DataTable();
        string v_sensor_id = null;
        string v_temp_id = null;
        string Idd = "";
        Boolean edit = false;
        string cbmsensornamedec, sensortype, Input_Range;
        int sensordir;
        Boolean sensoricp;
        Boolean addition, deletion, modification, Preivew, uidd;
        int sen = 0;
        int iTotalVal = 0;
        int iPartToAdd = 0;
        bool modify = true;
        bool Modify;
        int calcsensordir = 0;
        string typeid;
        string sSelectedValue = null;

        public FrmPointType()
        {
            InitializeComponent();
            PublicClass.SeteUserSettings(ref addition, ref deletion, ref modification, ref Preivew, ref uidd, "Point Type");
            fillcmbPointName();
            fillcmbPTypeInst();
            if (PublicClass.currentInstrument == "SKF/DI" || PublicClass.currentInstrument == "Kohtect-C911")
            {
                cmbPType.Properties.Items.Clear();
                cmbPType.Properties.Items.Add("--Select--");
                cmbPType.Properties.Items.Add("Vibration");
            }
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

        private void Retrive_Band_Alarm_Group()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select distinct Band_id from type_point where id= '" + typeid + "' ");
                string band_id = Convert.ToString(dt.Rows[0][0]);
                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.Text, "select distinct  bandalarmsgroup_Name from  bandalarm_data where Bandalarmsgroup_id = '" + band_id.Trim() + "'  ");
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    if (dtt.Rows.Count != 0)
                    {
                        cmbBandGroup.Text = Convert.ToString(dtt.Rows[0][0]);
                    }
                }
                else if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    if (dtt.Rows.Count != 0)
                    {
                        cmbBandC911.Text = Convert.ToString(dtt.Rows[0][0]);
                    }
                }
                else
                {
                    if (dtt.Rows.Count != 0)
                    {
                        cmbbandimxa.Text = Convert.ToString(dtt.Rows[0][0]);
                    }
                }
            }
            catch { }

        }

        private void Update_Band_Alarm_Group()
        {
            try
            {
                DataTable dt = new DataTable();
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    dt = DbClass.getdata(CommandType.Text, "select distinct  Bandalarmsgroup_id  from  bandalarm_data where  bandalarmsgroup_Name = '" + cmbBandGroup.Text.Trim() + "'  ");
                }
                else if (PublicClass.currentInstrument == "Kohtect-C911")
                { dt = DbClass.getdata(CommandType.Text, "select distinct  Bandalarmsgroup_id  from  bandalarm_data where  bandalarmsgroup_Name = '" + cmbBandC911.Text.Trim() + "'  "); }
                else { dt = DbClass.getdata(CommandType.Text, "select distinct  Bandalarmsgroup_id  from  bandalarm_data where  bandalarmsgroup_Name = '" + cmbbandimxa.Text.Trim() + "'  "); }
                string band_id = "";
                if (dt.Rows.Count == 0)
                {
                    band_id = "0";
                }
                else
                {
                    band_id = PublicClass.DefVal(Convert.ToString(dt.Rows[0][0]), "0");
                }

                DbClass.executequery(CommandType.Text, "update type_point set Band_id ='" + band_id + "'  where  id ='" + typeid + "' ");

            }
            catch { }
        }

        public void Fill_Band_Alarm_Group()
        {

            DataTable dt = new DataTable();
            dt = DbClass.getdata(CommandType.Text, "select distinct Bandalarmsgroup_id,bandalarmsgroup_Name from  bandalarm_data");
            dt.Rows.Add("0", "-- Select --");
            DataView view = dt.DefaultView;
            view.Sort = "Bandalarmsgroup_id ASC";
            DataTable dtt = new DataTable();
            dtt = view.ToTable();
            if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
            {
                cmbBandGroup.Properties.Items.Clear();
                foreach (DataRow dr in dtt.Rows)
                {
                    cmbBandGroup.Properties.Items.Add(Convert.ToString(dr["bandalarmsgroup_Name"]).Trim());
                }
                cmbBandGroup.Text = "-- Select --";
            }
            else if (PublicClass.currentInstrument == "Kohtect-C911")
            {
                cmbBandC911.Properties.Items.Clear();
                foreach (DataRow dr in dtt.Rows)
                {
                    cmbBandC911.Properties.Items.Add(Convert.ToString(dr["bandalarmsgroup_Name"]).Trim());
                }
                cmbBandC911.Text = "-- Select --";
            }
            else
            {
                cmbbandimxa.Properties.Items.Clear();
                foreach (DataRow dr in dtt.Rows)
                {
                    cmbbandimxa.Properties.Items.Add(Convert.ToString(dr["bandalarmsgroup_Name"]).Trim());
                }
                cmbbandimxa.Text = "-- Select --";
            }
        }

        private void fillcmbPTypeInst()
        {
            try
            {
                dtPType.Rows.Clear();
                dtPType = DbClass.getdata(CommandType.Text, "Select uid,instrumentname from instruments");
                dtPType.Rows.Add("0", "--Select--");
                DataView view = dtPType.DefaultView;
                view.Sort = "uid ASC";
                DataTable dt = new DataTable();
                dt = view.ToTable();

                cmbPTypeInst.Properties.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    cmbPTypeInst.Properties.Items.Add(Convert.ToString(dr["instrumentname"]));
                }
                if (PublicClass.currentInstrument == "FieldPaq2")
                {
                    if (cmbPType.Text == "Vibration")
                    {
                        cmbPTypeInst.SelectedIndex = 5;
                    }
                    else
                    {
                        cmbPTypeInst.SelectedIndex = 1;
                    }
                }
                else if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    if (cmbPType.Text == "Vibration")
                    {
                        cmbPTypeInst.SelectedIndex = 3;
                    }
                    else
                    {
                        cmbPTypeInst.SelectedIndex = 1;
                    }
                }
                else
                {
                    if (cmbPType.Text == "Vibration")
                    {
                        cmbPTypeInst.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbPTypeInst.SelectedIndex = 1;
                    }
                }
            }
            catch
            {
            }
        }

        public void Blank()
        {
            try
            {
                cmbPointTpname.Text = "";
                cmbPType.Text = "";
                cmbPType.SelectedIndex = 0;
                cmbPTypeInst.Enabled = false;
                cmbPTypeInst.Text = "--Select--";
            }
            catch { }
        }

        private void fillcmbPointName()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Rows.Clear();
                dt = DbClass.getdata(CommandType.StoredProcedure, "Select ID,Point_Name from type_point");
                if(addition)
                {
                    dt.Rows.Add("0", "Add New Point Type....");
                    dt.DefaultView.Sort = "id asc";
                }
                else
                {

                }
                cmbPointTpname.DataSource = dt;
                cmbPointTpname.DisplayMember = "Point_Name";
                cmbPointTpname.ValueMember = "ID";
                cmbPointTpname.SelectedIndex = -1;


            }
            catch { }
            finally { }
        }

        public void Fillsensorname()
        {
            try
            {

                string sTypye = cmbPType.Text;
                CmbSensorName.SelectedText = "";

                if (sSelectedValue == "Vibration")
                {
                    dtSensorName = DbClass.getdata(CommandType.Text, "Select distinct Sensor_ID,Sensor_name from sensor_data where sensor_type between '0' and '2'");
                    CmbSensorName.Properties.Items.Clear();
                    foreach (DataRow dr in dtSensorName.Rows)
                    {
                        CmbSensorName.Properties.Items.Add(Convert.ToString(dr["Sensor_name"]));
                    }
                    gbUniaxial.Enabled = true;
                    chkAxial.Enabled = true;
                    chkHorizontal.Enabled = true;
                    chkVertical.Enabled = true;
                }

                if (sSelectedValue == "Current")
                {
                    dtSensorName = DbClass.getdata(CommandType.Text, "select distinct Sensor_ID,Sensor_name from sensor_data where sensor_type = '5' ");
                    CmbSensorName.Properties.Items.Clear();
                    foreach (DataRow dr in dtSensorName.Rows)
                    {
                        CmbSensorName.Properties.Items.Add(Convert.ToString(dr["Sensor_name"]));
                    }
                    gbUniaxial.Enabled = false;
                    chkAxial.Enabled = false;
                    chkHorizontal.Enabled = false;
                    chkVertical.Enabled = false;
                }
                if (sSelectedValue == "Pressure")
                {
                    dtSensorName = DbClass.getdata(CommandType.Text, "select distinct Sensor_ID,Sensor_name from sensor_data where sensor_type = '4' ");
                    CmbSensorName.Properties.Items.Clear();
                    foreach (DataRow dr in dtSensorName.Rows)
                    {
                        CmbSensorName.Properties.Items.Add(Convert.ToString(dr["Sensor_name"]));
                    }
                    gbUniaxial.Enabled = false;
                    chkAxial.Enabled = false;
                    chkHorizontal.Enabled = false;
                    chkVertical.Enabled = false;
                }

                if (sSelectedValue == "Sound")
                {
                    dtSensorName = DbClass.getdata(CommandType.Text, "select distinct Sensor_ID,Sensor_name from sensor_data where sensor_type = '6'");
                    CmbSensorName.Properties.Items.Clear();
                    foreach (DataRow dr in dtSensorName.Rows)
                    {
                        CmbSensorName.Properties.Items.Add(Convert.ToString(dr["Sensor_name"]));
                    }
                    gbUniaxial.Enabled = true;
                    chkAxial.Enabled = true;
                    chkHorizontal.Enabled = true;
                    chkVertical.Enabled = true;
                }

            }
            catch { }
        }

        public void FillTempname()
        {
            try
            {
                dttempName = DbClass.getdata(CommandType.Text, "select distinct Sensor_ID,Sensor_name from sensor_data where sensor_type=3");
                cmbtempname.Properties.Items.Clear();
                foreach (DataRow dr in dttempName.Rows)
                {
                    cmbtempname.Properties.Items.Add(Convert.ToString(dr["Sensor_name"]));
                }
                cmbtempname.SelectedIndex = 0;

            }
            catch { }
        }

        public void BlankBb1()
        {
            try
            {
                cbAccelerationFilter.SelectedIndex = 0;
                cbVelocityFilter.SelectedIndex = 0;
                cbDispFilter.SelectedIndex = 0;
                cbBearingFilter.SelectedIndex = 0;
                cbCrestFilter.SelectedIndex = 0;
                cmbaccHPFilter.SelectedIndex = 0;
                cbTimeBand.SelectedIndex = 4;
                cbLines.SelectedIndex = 3;
                cbOverlap.SelectedIndex = 0;
                chkAxial.Checked = false;
                chkHorizontal.Checked = false;
                chkVertical.Checked = false;
                chkCH1.Checked = false;


            }
            catch { }
        }

        public void RetriveB1()
        {
            try
            {
                if (cmbPointTpname.Text.Trim() == "")
                {
                    MessageBox.Show(this, "Type Id is Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "call Retrive_measure ('" + typeid + "')");
                if (dt.Rows.Count > 0)
                {
                   // BlankBb1();
                    try
                    {
                        // calcsensordir = GetPointDir(Convert.ToInt32(dt.Rows[0]["sensor_dir"]));
                        CalcGeneralPageVariables2(Convert.ToInt32(dt.Rows[0]["sensordir"]));
                        sen = Convert.ToInt32(dt.Rows[0]["sensor_dir"]);
                        if (sen == 1)
                        {
                            gbUniaxial.Enabled = true;
                        }
                    }
                    catch { }
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                           
                            cbAccelerationFilter.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["acc_filter"]), "-1"));
                            cbVelocityFilter.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["vel_filter"]), "-1"));
                            cbDispFilter.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["displ_filter"]), "-1"));
                            cbBearingFilter.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["overall_bearing_filter"]), "-1"));
                            cbCrestFilter.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["crest_factor_filter"]), "-1"));
                            cmbaccHPFilter.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["bearing_acc_hp_filter"]), "-1"));
                            cbTimeBand.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["time_band"]), "-1"));
                            cbLines.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["time_resoltion"]), "-1"));
                            cbOverlap.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["time_overlap"]), "-1"));

                            foreach (DataRow drr in dtSensorName.Select("Sensor_ID= '" + Convert.ToString(dr["Sensor_ID"]).Trim() + "' "))
                            {
                                CmbSensorName.Text = Convert.ToString(drr["Sensor_name"]);
                                v_sensor_id = Convert.ToString(drr["Sensor_ID"]);
                            }
                            foreach (DataRow drr in dttempName.Select("Sensor_ID= '" + Convert.ToString(dr["TemperatureID"]).Trim() + "' "))
                            {
                                cmbtempname.Text = Convert.ToString(drr["Sensor_name"]);
                                v_temp_id = Convert.ToString(drr["Sensor_ID"]);
                            }
                        }
                        catch { }
                    }
                    RetriveallAlarmType();
                }

                else
                {
                    CmbSensorName.SelectedIndex = 0;
                }

            }
            catch { }
        }

        public void RetriveallAlarmType()
        {
            DataTable dtt = new DataTable();
            dtt = DbClass.getdata(CommandType.Text, "call Retrive_All_Aram_TypeId ('" + typeid + "')");
            cmbPAlarmList.Text = "";
            cmbSDAlarmList.Text = "";
            cmbAlarmlist.Text = "";
            foreach (DataRow dr in dtt.Rows)
            {
                try
                {
                    cmbPAlarmList.Text = Convert.ToString(dr["PerAlarm_Name"]).Trim();
                    cmbSDAlarmList.Text = Convert.ToString(dr["STDAlarm_Name"]).Trim();
                    cmbAlarmlist.Text = Convert.ToString(dr["Alarm_Name"]).Trim();
                }
                catch (Exception exe)
                {
                    int a = Iadeptmain.GlobalClasess.ExceptionHelper.LineNumber(exe);
                }
                if (cmbPAlarmList.Text == "")
                {
                    cmbPAlarmList.SelectedIndex = 0;
                }
                if (cmbSDAlarmList.Text == "")
                {
                    cmbSDAlarmList.SelectedIndex = 0;
                }
                if (cmbAlarmlist.Text == "")
                {
                    cmbAlarmlist.SelectedIndex = 0;
                }

            }

        }

        public void UpdateallAlarmType()
        {
            try
            {
                string V_PercentaveAlarm = "";
                string V_StdAlarm = "";
                string V_GeneralAlarm = "";
                foreach (DataRow dr in DtPercentageAlarm.Select("PerAlarm_Name=  '" + Convert.ToString(cmbPAlarmList.Text).Trim() + "' "))
                {
                    V_PercentaveAlarm = Convert.ToString(dr["Percentage_AlarmID"]);
                }

                foreach (DataRow dr in DtDeviationAlarm.Select("STDAlarm_Name=  '" + Convert.ToString(cmbSDAlarmList.Text).Trim() + "' "))
                {
                    V_StdAlarm = Convert.ToString(dr["STDDeviationAlarm_ID"]);
                }
                foreach (DataRow dr in DtGeneralAlram.Select("Alarm_Name=   '" + Convert.ToString(cmbAlarmlist.Text).Trim() + "' "))
                {
                    V_GeneralAlarm = Convert.ToString(dr["Alarm_ID"]);
                }

                DbClass.executequery(CommandType.StoredProcedure, "call Update_All_Aram_TypeId ('" + V_PercentaveAlarm + "','" + V_StdAlarm + "','" + V_GeneralAlarm + "','" + typeid + "') ");
            }
            catch { }
        }

        public void blankmeasures()
        {
            try
            {
                if (sSelectedValue == "Current" || sSelectedValue == "Pressure")
                {

                    lstmeasure.Enabled = false;
                    lstmeasure.Items[0].Checked = false;
                    lstmeasure.Items[1].Checked = false;
                    lstmeasure.Items[2].Checked = false;
                    lstmeasure.Items[3].Checked = false;
                    lstmeasure.Items[4].Checked = false;
                    lstmeasure.Items[5].Checked = true;
                    lstmeasure.Items[6].Checked = false;
                    lstmeasure.Items[7].Checked = false;
                    lstmeasure.Items[8].Checked = false;
                    lstmeasure.Items[9].Checked = false;
                    lstmeasure.Items[10].Checked = false;
                    lstmeasure.Items[11].Checked = false;

                }
                if (sSelectedValue == "Sound")
                {

                    lstmeasure.Enabled = false;
                    lstmeasure.Items[0].Checked = true;
                    lstmeasure.Items[1].Checked = false;
                    lstmeasure.Items[2].Checked = false;
                    lstmeasure.Items[3].Checked = false;
                    lstmeasure.Items[4].Checked = true;
                    lstmeasure.Items[5].Checked = true;
                    lstmeasure.Items[6].Checked = false;
                    lstmeasure.Items[7].Checked = false;
                    lstmeasure.Items[8].Checked = true;
                    lstmeasure.Items[9].Checked = false;
                    lstmeasure.Items[10].Checked = false;
                    lstmeasure.Items[11].Checked = false;

                }
                else
                {
                    lstmeasure.Items[0].Checked = true;
                    lstmeasure.Items[1].Checked = true;
                    lstmeasure.Items[2].Checked = true;
                    lstmeasure.Items[3].Checked = true;
                    lstmeasure.Items[4].Checked = true;
                    lstmeasure.Items[5].Checked = true;
                    lstmeasure.Items[6].Checked = true;
                    lstmeasure.Items[7].Checked = false;
                    lstmeasure.Items[8].Checked = false;
                    lstmeasure.Items[9].Checked = true;
                    lstmeasure.Items[10].Checked = true;
                    lstmeasure.Items[11].Checked = true;
                }
            }
            catch { }
        }

        public void RetriveBO()
        {
            try
            {

                if (cmbPointTpname.Text.Trim() == "")
                {
                    MessageBox.Show(this, "Type Id is Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = DbClass.getdata(CommandType.Text, "call Retrive_measure_type ('" + typeid + "')");
               
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        lstmeasure.Items[0].Checked = setvalue(Convert.ToInt32(dr["OAcc"]));
                        lstmeasure.Items[1].Checked = setvalue(Convert.ToInt32(dr["OVel"]));
                        lstmeasure.Items[2].Checked = setvalue(Convert.ToInt32(dr["ODisp"]));
                        lstmeasure.Items[3].Checked = setvalue(Convert.ToInt32(dr["OBear"]));
                        lstmeasure.Items[4].Checked = setvalue(Convert.ToInt32(dr["OTWF"]));
                        lstmeasure.Items[5].Checked = setvalue(Convert.ToInt32(dr["OPS"]));
                        lstmeasure.Items[6].Checked = setvalue(Convert.ToInt32(dr["ODS"]));
                        lstmeasure.Items[7].Checked = setvalue(Convert.ToInt32(dr["Temp"]));
                        lstmeasure.Items[8].Checked = setvalue(Convert.ToInt32(dr["Process"]));
                        lstmeasure.Items[9].Checked = setvalue(Convert.ToInt32(dr["crestfactor"]));
                        lstmeasure.Items[10].Checked = setvalue(Convert.ToInt32(dr["Ordertrace"]));
                        lstmeasure.Items[11].Checked = setvalue(Convert.ToInt32(dr["Cepstrum"]));
                    }
                    catch { }
                }

                if (cmbPType.SelectedItem.ToString() == "Sound")
                {
                    lstmeasure.Items[0].Checked = false;
                    lstmeasure.Items[1].Checked = false;
                    lstmeasure.Items[2].Checked = false;
                    lstmeasure.Items[3].Checked = false;
                    lstmeasure.Items[4].Checked = false;
                    lstmeasure.Items[5].Checked = true;
                    lstmeasure.Items[6].Checked = false;
                    lstmeasure.Items[7].Checked = false;
                    lstmeasure.Items[8].Checked = false;
                    lstmeasure.Items[9].Checked = false;
                    lstmeasure.Items[10].Checked = false;
                    lstmeasure.Items[11].Checked = false;
                   
                }
                if (cmbPType.SelectedItem.ToString() == "Current")
                {
                    lstmeasure.Items[0].Checked = false;
                    lstmeasure.Items[1].Checked = false;
                    lstmeasure.Items[2].Checked = false;
                    lstmeasure.Items[3].Checked = false;
                    lstmeasure.Items[4].Checked = false;
                    lstmeasure.Items[5].Checked = true;
                    lstmeasure.Items[6].Checked = false;
                    lstmeasure.Items[7].Checked = false;
                    lstmeasure.Items[8].Checked = false;
                    lstmeasure.Items[9].Checked = false;
                    lstmeasure.Items[10].Checked = false;
                    lstmeasure.Items[11].Checked = false;

                }
            }
            catch { }
        }

        public int setvalue(Boolean b)
        {
            int i = 0;
            if (b == false)
            {
                i = 0;

            }

            if (b == true)
            {

                i = 1;
            }
            return i;
        }

        public Boolean setvalue(int b)
        {
            Boolean i = false;
            if (b == 0)
            {
                i = false;
            }

            if (b == 1)
            {

                i = true;
            }
            return i;
        }

        public void FillPercentageAlram()
        {
            try
            {
                DtPercentageAlarm.Rows.Clear();
                DtPercentageAlarm = DbClass.getdata(CommandType.Text, "select distinct  Percentage_AlarmID ,PerAlarm_Name from percentage_alarm where Percentage_AlarmID>1");

                DtPercentageAlarm.Rows.Add("0", "--Select--");
                DataView view = DtPercentageAlarm.DefaultView;
                view.Sort = "Percentage_AlarmID ASC";
                DataTable dt = new DataTable();
                dt = view.ToTable();

                cmbPAlarmList.Properties.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    cmbPAlarmList.Properties.Items.Add(Convert.ToString(dr["PerAlarm_Name"]));
                }
                cmbPAlarmList.SelectedIndex = 0;

            }
            catch { }
        }

        public void FillDeviationAlram()
        {
            try
            {
                DtDeviationAlarm.Rows.Clear();
                DtDeviationAlarm = DbClass.getdata(CommandType.Text, "select distinct STDDeviationAlarm_ID,STDAlarm_Name from stddeviationalarm where STDDeviationAlarm_ID>1");

                DtDeviationAlarm.Rows.Add("0", "--Select--");
                DataView view = DtDeviationAlarm.DefaultView;
                view.Sort = "STDDeviationAlarm_ID ASC";
                DataTable dt = new DataTable();
                dt = view.ToTable();

                cmbSDAlarmList.Properties.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    cmbSDAlarmList.Properties.Items.Add(Convert.ToString(dr["STDAlarm_Name"]));
                }
                cmbSDAlarmList.SelectedIndex = 0;

            }
            catch { }
        }

        public void FillGernalAlram()
        {
            try
            {
                DtGeneralAlram.Rows.Clear();
                DtGeneralAlram = DbClass.getdata(CommandType.Text, "select distinct Alarm_ID,Alarm_Name from alarms_data where Alarm_ID>1");
                DtGeneralAlram.Rows.Add("0", "--Select--");
                DataView view = DtGeneralAlram.DefaultView;
                view.Sort = "Alarm_ID ASC";
                DataTable dt = new DataTable();
                dt = view.ToTable();
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    cmbAlarmlist.Properties.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbAlarmlist.Properties.Items.Add(Convert.ToString(dr["Alarm_Name"]));
                    }
                    cmbAlarmlist.SelectedIndex = 0;
                }
                else if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    cmbalarmC911.Properties.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbalarmC911.Properties.Items.Add(Convert.ToString(dr["Alarm_Name"]));
                    }
                    cmbalarmC911.SelectedIndex = 0;
                }
                else
                {
                    cmbAlarmImxa.Properties.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbAlarmImxa.Properties.Items.Add(Convert.ToString(dr["Alarm_Name"]));
                    }
                    cmbAlarmImxa.SelectedIndex = 0;
                }
            }
            catch { }
        }

        private string CalculateMultipleBandValue(bool G1P1, bool G1P2, bool G2P1, bool G2P2, bool G3P1, bool G3P2)
        {
            string returnstring = "1";
            int iPartToAdd = 0;
            int iTotal = 0;
            try
            {
                if (G1P1)
                {
                    iPartToAdd = 1;
                    iTotal += iPartToAdd;
                }
                if (G1P2)
                {
                    iPartToAdd = 2;
                    iTotal += iPartToAdd;
                }
                if (G2P1)
                {
                    iPartToAdd = 4;
                    iTotal += iPartToAdd;
                }
                if (G2P2)
                {
                    iPartToAdd = 8;
                    iTotal += iPartToAdd;
                }
                if (G3P1)
                {
                    iPartToAdd = 16;
                    iTotal += iPartToAdd;
                }
                if (G3P2)
                {
                    iPartToAdd = 32;
                    iTotal += iPartToAdd;
                }
                returnstring = iTotal.ToString();
            }
            catch
            {
            }
            return returnstring;
        }

        public void BlankRetriveB2()
        {
            try
            {
                cbPSBand.SelectedIndex = 4;
                cbPSLines.SelectedIndex = 3;
                cbPSBand1.SelectedIndex = 4;
                cbPSLines1.SelectedIndex = 3;
                cbG2PSBand.SelectedIndex = 4;
                cbG2PSLines.SelectedIndex = 3;
                cbG2PSBand1.SelectedIndex = 4;
                cbG2PSLines1.SelectedIndex = 3;
                cbG3PSBand.SelectedIndex = 4;
                cbG3PSLines.SelectedIndex = 3;
                cbG3PSBand1.SelectedIndex = 4;
                cbG3PSLines1.SelectedIndex = 3;
                cbPSWindow.SelectedIndex = 1;
                cbPSOverlap.SelectedIndex = 0;
                cbAvgTimes.SelectedIndex = 1;
                cbZoom.Checked = false;
                txtPSZoom.Text = "";
                cbCepBand.SelectedIndex = 4;
                cbCepLine.SelectedIndex = 3;
                cbCepWind.SelectedIndex = 0;
                cbCepAvgTime.SelectedIndex = 1;
                cbCepOverlap.SelectedIndex = 0;
                txtCepZoom.Text = "";
                cbDMBand.SelectedIndex = 4;
                cmbdmLines.SelectedIndex = 3;
                cmbdmWindow.SelectedIndex = 0;
                cmbdmAvgTimes.SelectedIndex = 1;
                cbFilter.SelectedIndex = 0;
                cbOTAvg.SelectedIndex = 0;
                cbOTLines.SelectedIndex = 0;
                txtOTOrder.Text = "1";
                cbOTSlope.SelectedIndex = 0;
                cbZoom.Checked = false;
                chkCepZoom.Checked = false;
                cbMultipleBand.Checked = false;
                chkbxG2P1.Checked = false;
                chkbxG2P2.Checked = false;
                chkbxG3P1.Checked = false;
                chkbxG3P2.Checked = false;
            }
            catch { }
        }

        public void RetriveB2()
        {
            try
            {
                if (cmbPointTpname.Text.Trim() == "")
                {
                    MessageBox.Show(this, "Type Id is Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "call Retrive_Measure_Band ('" + typeid + "')");
                //BlankRetriveB2();
                foreach (DataRow dr in dt.Select("power_band <>'' "))
                {
                    try
                    {
                        cbPSBand.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power_band"]), "0"));
                        cbPSLines.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power_resolution"]), "0"));
                        cbPSBand1.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power_band1"]), "0"));
                        cbPSLines1.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power_resolution1"]), "0"));
                        cbG2PSBand.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power2_band"]), "0"));
                        cbG2PSLines.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power2_resolution"]), "0"));
                        cbG2PSBand1.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power2_band1"]), "0"));
                        cbG2PSLines1.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power2_resolution1"]), "0"));
                        cbG3PSBand.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power3_band"]), "0"));
                        cbG3PSLines.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power3_resolution"]), "0"));
                        cbG3PSBand1.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power3_band1"]), "0"));
                        cbG3PSLines1.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power3_resolution1"]), "0"));
                        cbPSWindow.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power_window"]), "0"));
                        cbPSOverlap.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power_overlap"]), "0"));
                        cbAvgTimes.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power_average_times"]), "0"));
                        cbZoom.Checked = setvalue(Convert.ToInt32(dr["power_zoom"]));
                        try
                        {
                            if (cbZoom.Checked)
                            {
                                txtPSZoom.Enabled = true;
                                txtPSZoom.Text = Convert.ToString(dr["power_zoom_startfeq"]);
                            }
                            else
                            {
                                txtPSZoom.Enabled = false;
                                txtPSZoom.Text = "0";
                            }
                        }
                        catch { }

                        cmbOctave.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["OctaveSetting"]), "0"));
                        cmbBarstyle.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["OctaveBar"]), "0"));
                        cbCepBand.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["cepstrum_band"]), "0"));
                        cbCepLine.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["cepstrum_resolution"]), "0"));
                        cbCepWind.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["cepstrum_window"]), "0"));
                        cbCepAvgTime.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["cepstrum_average_times"]), "0"));
                        cbCepOverlap.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["cepstrum_overlap"]), "0"));
                        txtCepZoom.Text = Convert.ToString(dr["cepstrum_zoom_startfeq"]);
                        cbDMBand.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["demodulate_band"]), "0"));
                        cmbdmLines.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["demodulate_resolution"]), "0"));
                        cmbdmWindow.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["demodulate_window"]), "0"));
                        cmbdmAvgTimes.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["demodulate_average_times"]), "0"));
                        cbFilter.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["demodulate_filter"]), "0"));
                        cbOTAvg.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["ordertrace_average_times"]), "0"));
                        cbOTLines.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["ordertrace_resolution"]), "0"));
                        txtOTOrder.Text = PublicClass.DefVal(Convert.ToString(dr["ordertrace_order"]), "0");
                        cbOTSlope.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["ordertrace_trigger_slope"]), "0"));
                        //cbZoom.Checked = setvalue(Convert.ToInt32(dr["power_zoom"]));
                        chkCepZoom.Checked = setvalue(Convert.ToInt32(dr["cepstrum_zoom"]));
                        try
                        {
                            if (chkCepZoom.Checked)
                            {
                                txtCepZoom.Enabled = true;
                            }
                            else
                            {
                                txtCepZoom.Enabled = false;
                                txtCepZoom.Text = "0";
                            }
                        }
                        catch { }
                        string schkbxG1P2 = "0";
                        string schkbxG2P1 = "0";
                        string schkbxG3P1 = "0";
                        string sPowerMultipleBand = "0";
                        string schkbxG2P2 = "0";
                        string schkbxG3P2 = "0";

                        sPowerMultipleBand = Convert.ToString(dr["power_multiple"]);
                        CalculatePower_Multiple(ref sPowerMultipleBand, out schkbxG1P2, out schkbxG2P1, out schkbxG2P2, out schkbxG3P1, out schkbxG3P2);
                        cbMultipleBand.Checked = Convert.ToBoolean(Convert.ToInt32(schkbxG1P2));
                        chkbxG2P1.Checked = Convert.ToBoolean(Convert.ToInt32(schkbxG2P1));
                        chkbxG2P2.Checked = Convert.ToBoolean(Convert.ToInt32(schkbxG2P2));
                        chkbxG3P1.Checked = Convert.ToBoolean(Convert.ToInt32(schkbxG3P1));
                        chkbxG3P2.Checked = Convert.ToBoolean(Convert.ToInt32(schkbxG3P2));
                    }
                    catch { }
                }
                try
                {
                    if (cbZoom.Checked)
                    {
                        txtPSZoom.Enabled = true;
                    }
                    else
                    {
                        txtPSZoom.Enabled = false;
                        txtPSZoom.Text = "0";
                    }
                }
                catch { }

                try
                {
                    if (chkCepZoom.Checked)
                    {
                        txtCepZoom.Enabled = true;
                    }
                    else
                    {
                        txtCepZoom.Enabled = false;
                        txtCepZoom.Text = "0";
                    }
                }
                catch { }
            }
            catch { }
        }

        private string DeciamlToBinary1(int number)
        {
            string[] hexvalues = { "0", "1" };//, "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            string result = null, final = null;
            int rem = 0, div = 0;
            try
            {
                while (true)
                {
                    rem = (number % 2);
                    result += hexvalues[rem].ToString();

                    if (number < 2)
                        break;
                    result += ',';
                    number = (number / 2);

                }

                for (int i = (result.Length - 1); i >= 0; i--)
                {
                    final += result[i];
                }
            }
            catch (Exception ex)
            {
                //ErrorLogFile(ex);
            }

            return final;
        }

        private void CalculatePower_Multiple(ref string sPowerMultipleBand, out string schkbxG1P2, out string schkbxG2P1, out string schkbxG2P2, out string schkbxG3P1, out string schkbxG3P2)
        {

            try
            {
                string schkbxG1P1 = "0";
                schkbxG1P2 = "0";
                schkbxG2P1 = "0";
                schkbxG2P2 = "0";
                schkbxG3P1 = "0";
                schkbxG3P2 = "0";
                int Target = Convert.ToInt32(PublicClass.DefVal(sPowerMultipleBand, "0"));

                string[] HexValOfTarget = DeciamlToBinary1(Target).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);


                try
                {
                    schkbxG1P1 = HexValOfTarget[0].ToString();
                    schkbxG1P2 = HexValOfTarget[1].ToString();
                    schkbxG2P1 = HexValOfTarget[2].ToString();
                    schkbxG2P2 = HexValOfTarget[3].ToString();
                    schkbxG3P1 = HexValOfTarget[4].ToString();
                    schkbxG3P2 = HexValOfTarget[5].ToString();

                }
                catch
                {
                }


            }
            catch (Exception ex)
            {
                schkbxG1P2 = "0";
                schkbxG2P1 = "0";
                schkbxG2P2 = "0";
                schkbxG3P1 = "0";
                schkbxG3P2 = "0";
            }

        }

        private void RetriveB3()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.StoredProcedure, "call Retrive_Units ( '" + typeid + "')");
                //b3Blank();
                foreach (DataRow dr in dt.Rows)
                {

                    cbAcc.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["accel_unit"]), "-1"));
                    cbAccUnit.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["accel_detection"]), "-1"));
                    cbVel.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["vel_unit"]), "-1"));
                    cbVelUnit.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["vel_detection"]), "-1"));
                    cbDisp.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["displ_unit"]), "-1"));
                    cbDispUnit.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["displ_detection"]), "-1"));
                    cbTemp.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["temperature_unit"]), "-1"));
                    txtProcess.Text = (Convert.ToString(dr["process_unit"]));
                    cbPressure.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["pressure_unit"]), "-1"));
                    cbPressureUnit.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["pressure_detection"]), "-1"));
                    cbCurrent.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["current_unit"]), "-1"));
                    cbCurrentUnit.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["current_detection"]), "-1"));
                    cbTime.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["time_unit_type"]), "-1"));
                    cbSpectrum.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["power_unit_type"]), "-1"));
                    cbDemodulate.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["demodulate_unit_type"]), "-1"));
                    cbOrderTrace.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["ordertrace_unit_type"]), "-1"));
                    cbCepstrum.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["cepstrum_unit_type"]), "-1"));
                }
            }
            catch { }
        }

        private void blankC911()
        {
            cmbchannel1.SelectedIndex = 0;
            cmbenv.SelectedIndex = 0;
            cmbchannel2.SelectedIndex = 0;
            cmbwindow.SelectedIndex = 0;
            cmbspectral.SelectedIndex = 0;
            cmbFmin.SelectedIndex = 0;
            cmbfmax.SelectedIndex = 0;
            cmbtrigger.SelectedIndex = 0;
            cmbAvermode.SelectedIndex = 0;
            rblinA.Checked = true; rbamplinA.Checked = true;
            rbrnv.Checked = false; rbampint2.Checked = false;
            rbintv.Checked = false; rbampint1.Checked = false;
            rbint.Checked = false; rbampenv.Checked = false;
            txtcomment.Text = "";
        }

        public void RetriveC911()
        {
            try
            {
                DataTable dt1 = DbClass.getdata(CommandType.Text, "select * from c911_measurement where type_id='" + typeid + "'");
                blankC911();
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        cmbchannel1.SelectedIndex = Convert.ToInt32(Convert.ToString(dr1["channel1"]));
                        cmbenv.SelectedIndex = Convert.ToInt32(dr1["EV_Frequency"]);
                        cmbchannel2.SelectedIndex = Convert.ToInt32(dr1["Channel2"]);
                        cmbwindow.SelectedIndex = Convert.ToInt32(dr1["Window_Type"]);
                        cmbspectral.SelectedIndex = Convert.ToInt32(dr1["Spectrum_LineNo"]);
                        cmbFmin.SelectedIndex = Convert.ToInt32(dr1["Fmin"]);
                        cmbfmax.SelectedIndex = Convert.ToInt32(dr1["Fmax"]);
                        cmbtrigger.SelectedIndex = Convert.ToInt32(dr1["Trigger_Mode"]);
                        cmbAvermode.SelectedIndex = Convert.ToInt32(dr1["Avg_Mode"]);
                        txtN.Text = Convert.ToString(dr1["N"]);
                        txtcomment.Text = Convert.ToString(dr1["Comments"]);
                        string radio1 = Convert.ToString(dr1["SelectRadio1"]);
                        if (radio1 == "0")
                        { rblinA.Checked = true; }
                        else if (radio1 == "2") { rbint.Checked = true; }
                        else if (radio1 == "1") { rbintv.Checked = true; }
                        else if (radio1 == "3") { rbrnv.Checked = true; }
                        string radio2 = Convert.ToString(dr1["SelectRadio2"]);
                        if (radio2 == "0")
                        { rbamplinA.Checked = true; }
                        else if (radio2 == "2") { rbampint2.Checked = true; }
                        else if (radio2 == "1") { rbampint1.Checked = true; }
                        else if (radio2 == "3") { rbampenv.Checked = true; }
                    }
                }               
            }
            catch { }
        }


        public void RetriveSciMax()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "call Retrive_Di_Point ( '" + typeid + "')");
                BlankSCIMAX();
                foreach (DataRow dr in dt.Rows)
                {
                    cmbUnitsMain.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dt.Rows[0]["Type_Unit"]).Trim(), "-1"));
                    cmbDetectionType.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["DetectionType"]).Trim(), "-1"));
                    cmbFullScale.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["FullScale"]).Trim(), "-1"));
                    cmbWindowType.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["WindowType"]).Trim(), "-1"));
                    cmbFilterType.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["FilterType"]).Trim(), "-1"));
                    cmbFilterValue.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["FilterValue"]).Trim(), "-1"));
                    cmbDirection.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["Direction"]).Trim(), "0"));
                    cmbCollectionType.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["CollectionType"]).Trim(), "-1"));
                    cmbMeasureType.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["MeasureType"]).Trim(), "-1"));
                    cmbResolution.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["Resolution"]).Trim(), "-1"));
                    cmbFrequency.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["Frequency"]).Trim(), "-1"));
                    cmbOrders.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["Orders"]).Trim(), "-1"));
                    tbSpecAver.Text = Convert.ToString(dr["SpecAvg"]).Trim();
                    tbTimeAveg.Text = Convert.ToString(dr["TimeAvg"]).Trim();
                    cmbCouple.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["Couple"]).Trim(), "-1"));
                    tbOverlap.Text = Convert.ToString(dr["Overlap"]).Trim();
                    cmbTriggerType.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["TriggerType"]).Trim(), "-1"));
                    cmbSlope1.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["Slope"]).Trim(), "-1"));
                    tbLevel.Text = Convert.ToString(dr["Levels"]);
                    cmbTriggerRange.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["TriggerRange"]).Trim(), "-1"));
                    cmbChannelType.SelectedIndex = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["ChannelType"]).Trim(), "-1"));                   
                }
            }
            catch { }

        }

        public void BlankSCIMAX()
        {

            try
            {
                cmbUnitsMain.SelectedIndex = -1;
                cmbFullScale.SelectedIndex = -1;
                cmbCouple.SelectedIndex = -1;

                cmbDetectionType.SelectedIndex = -1;
                cmbWindowType.SelectedIndex = -1;
                cmbFilterType.SelectedIndex = -1;
                cmbFilterValue.SelectedIndex = -1;
                cmbDirection.SelectedIndex = -1;
                cmbCollectionType.SelectedIndex = -1;
                cmbMeasureType.SelectedIndex = -1;
                cmbResolution.SelectedIndex = -1;
                cmbFrequency.SelectedIndex = -1;
                cmbOrders.SelectedIndex = -1;
                cmbTriggerType.SelectedIndex = -1;
                cmbSlope1.SelectedIndex = -1;
                cmbTriggerRange.SelectedIndex = -1;
                cmbChannelType.SelectedIndex = -1;              
            }
            catch { }
        }

        public void b3Blank()
        {
            try
            {
                cbAcc.SelectedIndex = 0;
                cbAccUnit.SelectedIndex = 1;
                cbVel.SelectedIndex = 0;
                cbVelUnit.SelectedIndex = 0;
                cbDisp.SelectedIndex = 1;
                cbDispUnit.SelectedIndex = 2;
                cbTemp.SelectedIndex = 0;
                txtProcess.Text = "";
                cbPressure.SelectedIndex = 0;
                cbPressureUnit.SelectedIndex = 1;
                cbCurrent.SelectedIndex = 0;
                cbCurrentUnit.SelectedIndex = 1;
                cbTime.SelectedIndex = 0;
                cbSpectrum.SelectedIndex = 0;
                cbDemodulate.SelectedIndex = 0;
                cbOrderTrace.SelectedIndex = 0;
                cbCepstrum.SelectedIndex = 0;
            }
            catch { }
        }

        public int UnitsMain
        {
            get
            {
                return cmbUnitsMain.SelectedIndex;
            }
            set
            {
                cmbUnitsMain.SelectedIndex = value;
            }

        }

        public int FilterType
        {
            get
            {
                return cmbFilterType.SelectedIndex;
            }
            set
            {
                cmbFilterType.SelectedIndex = value;
            }
        }

        public int MeasureType
        {
            get
            {
                return cmbMeasureType.SelectedIndex;
            }
            set
            {
                cmbMeasureType.SelectedIndex = value;
            }
        }

        private int SetListView()
        {

            iPartToAdd = 0;
            int iTotal = 0;
            int i = lstmeasure.CheckedItems.Count;

            try
            {
                if (lstmeasure.CheckedItems.Count >= 0)
                {
                    foreach (ListViewItem lvItem in lstmeasure.Items)
                    {

                        string s = lvItem.Text;

                        if (lvItem.Checked)
                        {
                            switch (lvItem.Text)
                            {
                                case "Overall Acceleration":
                                    {
                                        iPartToAdd = 1;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                                case "Overall Velocity":
                                    {
                                        iPartToAdd = 2;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                                case "Overall Displacement":
                                    {
                                        iPartToAdd = 4;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                                case "Overall Bearing":
                                    {
                                        iPartToAdd = 8;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                                case "Time WaveForm":
                                    {
                                        iPartToAdd = 16;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                                case "Power Spectrum":
                                    {
                                        iPartToAdd = 32;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                                case "MCSA":
                                    {
                                        iPartToAdd = 32;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                                case "Demodulate Spectrum":
                                    {
                                        iPartToAdd = 64;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                                case "Temperature":
                                    {
                                        iPartToAdd = 128;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                                case "Process Parameter":
                                    {
                                        iPartToAdd = 256;
                                        iTotal += iPartToAdd;
                                        break;
                                    }

                                case "Crest Factor":
                                    {
                                        iPartToAdd = 512;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                                case "Amplitude & Phase":
                                    {
                                        iPartToAdd = 1024;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                                case "Cepstrum":
                                    {
                                        iPartToAdd = 2048;
                                        iTotal += iPartToAdd;
                                        break;
                                    }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }

            return iTotal;

        }

        public void savepointname()
        {
            int id = -1;
            try
            {
                if (Convert.ToString(txtPointtypename.Text).Trim() != "")
                {

                    DataTable dt1 = DbClass.getdata(CommandType.Text, "Select * from type_point where Point_Name = '" + Convert.ToString(txtPointtypename.Text).Trim() + "'");
                    if(dt1.Rows.Count > 0)
                    {
                        MessageBox.Show(this, "This name is already exist..Please enter another name","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        DbClass.executequery(CommandType.StoredProcedure, "call Insert_Point_Type ('" + cmbPType.SelectedIndex + "' , '" + Convert.ToString(txtPointtypename.Text).Trim() + "' ,'" + cmbPTypeInst.Text + "') ");

                        DataTable dt = new DataTable();
                        dt = DbClass.getdata(CommandType.Text, "select max(id) from type_point");
                        id = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dt.Rows[0][0]), "0"));
                        fillcmbPointName();
                        cmbPointTpname.Text = "";
                        txtPointtypename.Text = "";
                        cmbPointTpname.Visible = true;
                        cmbPointTpname.SelectedValue = id;
                        txtPointtypename.Visible = false;
                    }
                }
                else
                {
                    if (cmbPointTpname.SelectedIndex > 0)
                    {
                        BlankRetriveB2();
                        b3Blank();
                        BlankBb1();
                    }
                    else
                    {
                        // MessageBox.Show(this, "Point Type Name can not be blank..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPointtypename.Visible = false;
                        cmbPointTpname.Visible = true;
                        cmbPointTpname.SelectedIndex = -1;
                        return;
                    }
                }
                
               
            }
            catch { }
        }

        public int GetPointDir(int idirval)
        {
            int iPartVal = 0;
            iTotalVal = 0;
            try
            {
                if (idirval == 0 && chkAxial.Enabled == false && chkVertical.Enabled == false && chkHorizontal.Enabled == false && chkCH1.Checked == false)
                {

                    iTotalVal = 0;

                }
                else if (idirval == 2)
                {
                    iTotalVal = 32;

                }
                else
                {
                    if (chkAxial.Checked)
                    {
                        iPartVal = 1;
                        iTotalVal += iPartVal;
                    }
                    if (chkHorizontal.Checked)
                    {
                        iPartVal = 2;
                        iTotalVal += iPartVal;
                    }
                    if (chkVertical.Checked)
                    {
                        iPartVal = 4;
                        iTotalVal += iPartVal;
                    }

                    try
                    {
                        foreach (ListViewItem lvItem in lstmeasure.Items)
                        {
                            if (lvItem.Text == "Temperature" && lvItem.Checked)
                            {
                                iPartVal = 8;
                                iTotalVal += iPartVal;
                            }
                            else if (lvItem.Text == "Process Parameter" && lvItem.Checked)
                            {
                                iPartVal = 16;
                                iTotalVal += iPartVal;
                            }

                        }
                    }
                    catch
                    {

                    }


                }
            }
            catch { }
            return iTotalVal;
        }

        private void CalcGeneralPageVariables2(int Target)
        {
            int Target2 = 0;
            try
            {
                Target2 = Target;

                if (Target2 == 32)
                {
                    chkAxial.Checked = true;
                    chkHorizontal.Checked = true;
                    chkVertical.Checked = true;
                    chkCH1.Checked = true;
                    gbUniaxial.Enabled = false;
                }
                if (Target2 == 10 || Target2 == 2 || Target2 == 18 || Target2 == 26)
                {
                    chkHorizontal.Checked = true;
                    chkAxial.Checked = false;
                    chkVertical.Checked = false;
                    chkCH1.Checked = false;
                    gbUniaxial.Enabled = true;

                }
                if (Target2 == 12 || Target2 == 20 | Target2 == 28 || Target2 == 4)
                {
                    chkVertical.Checked = true;
                    chkAxial.Checked = false;
                    chkHorizontal.Checked = false;
                    chkCH1.Checked = false;
                    gbUniaxial.Enabled = true;
                }
                if (Target2 == 7 || Target2 == 15 || Target2 == 31 || Target2 == 23 || Target2 == 0)
                {
                    chkHorizontal.Checked = true;
                    chkVertical.Checked = true;
                    chkAxial.Checked = true;
                    chkCH1.Checked = false;
                    gbUniaxial.Enabled = false;
                }
                if (Target2 == 6 || Target2 == 14 || Target2 == 30 || Target2 == 22)
                {
                    chkHorizontal.Checked = true;
                    chkVertical.Checked = true;
                    chkAxial.Checked = false;
                    chkCH1.Checked = false;
                    gbUniaxial.Enabled = true;
                }
                if (Target2 == 5 || Target2 == 13 || Target2 == 21 || Target2 == 29)
                {
                    chkAxial.Checked = true;
                    chkVertical.Checked = true;
                    chkHorizontal.Checked = false;
                    chkCH1.Checked = false;
                    gbUniaxial.Enabled = true;
                }
                if (Target2 == 3 || Target2 == 27 || Target2 == 11 || Target2 == 19)
                {
                    chkAxial.Checked = true;
                    chkHorizontal.Checked = true;
                    chkVertical.Checked = false;
                    chkCH1.Checked = false;
                    gbUniaxial.Enabled = true;

                }
                if (Target2 == 1 || Target2 == 25 || Target2 == 17 || Target2 == 9)
                {
                    chkAxial.Checked = true;
                    chkHorizontal.Checked = false;
                    chkVertical.Checked = false;
                    chkCH1.Checked = false;
                    gbUniaxial.Enabled = true;
                }


            }
            catch (Exception ex)
            {

            }
        }
       
        
        
        private void editsensorfielddata(string sPointID)
        {
            int SensorID = 0;
            string Sensorty = null;
            try
            {
                int xx = 0;
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "SELECT *  FROM sensor_data where sensor_type != '3' and sensor_id= '" + sPointID + "' ");
                foreach (DataRow objDataReader in dt.Rows)
                {

                    cbmsensornamedec = Convert.ToString(objDataReader["Sensor_Name"]);
                    sensortype = Convert.ToString(objDataReader["sensor_type"]);

                    sensordir = Convert.ToInt16(PublicClass.DefVal(Convert.ToString(objDataReader["Sensor_dir"]), "0"));


                    sensoricp = Convert.ToBoolean(Convert.ToInt32(objDataReader["Sensor_icp"]));
                    Input_Range = Convert.ToString(objDataReader["Input_Range"]);
                    if (xx == SensorID)
                        break;
                    else
                        xx++;
                }


                if (sensordir == 2)
                {
                    chkHorizontal.Checked = true;
                    chkVertical.Checked = true;
                    chkAxial.Checked = true;
                    chkCH1.Checked = true;
                    gbUniaxial.Enabled = false;
                    chkCH1.Enabled = false;

                }
                else if (sensordir == 1)
                {
                    gbUniaxial.Enabled = true;
                    chkHorizontal.Checked = false;
                    chkVertical.Checked = false;
                    chkAxial.Checked = true;
                    chkCH1.Enabled = false;
                    chkCH1.Checked = false;
                }


                else
                {
                    chkHorizontal.Checked = true;
                    chkVertical.Checked = true;
                    chkAxial.Checked = true;
                    chkCH1.Checked = false;
                    chkCH1.Enabled = false;
                    gbUniaxial.Enabled = false;
                }
                cbICPPower.Checked = Convert.ToBoolean(sensoricp);
                //GetPointDir(sensordir);
                sen = sensordir;
            }
            catch { }
        }

        private void xtraTbPointType_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = new DataTable();
                string TabpageName = xtraTbPointType.SelectedTabPage.Name.ToString().Trim();
                switch (TabpageName)
                {
                    case "xtraTPB0":
                        {
                            RetriveBO();
                            //if (sSelectedValue == "Current" || sSelectedValue == "Pressure")
                            //{
                            //    lstmeasure.Enabled = false;
                            //}
                            //else
                            //{
                            dt1 = DbClass.getdata(CommandType.Text, "Select p.Point_ID , pt.ID, p.PointName,pt.Point_Name from point p left join type_point pt on p.PointType_ID = pt.ID   where pt.ID = '" + typeid + "' ");

                            if (dt1.Rows.Count > 0)
                            {
                                lstmeasure.Enabled = false;
                                lstmeasure.Items[5].Text = "Power Spectrum";
                            }
                            else if (currentType)
                            {
                                lstmeasure.Items[5].Text = "MCSA";
                                lstmeasure.Enabled = false;
                            }
                            else
                            {
                                lstmeasure.Items[5].Text = "Power Spectrum";
                                lstmeasure.Enabled = true;
                            }
                            break;
                        }
                    case "xtraTPB1":
                        {
                            Fillsensorname();
                            FillTempname();
                            FillPercentageAlram();
                            FillDeviationAlram();
                            FillGernalAlram();
                            Fill_Band_Alarm_Group();
                            RetriveB1();
                            RetriveallAlarmType();
                            Retrive_Band_Alarm_Group();

                            dt1 = DbClass.getdata(CommandType.Text, "Select p.Point_ID , pt.ID, p.PointName,pt.Point_Name from point p left join type_point pt on p.PointType_ID = pt.ID   where pt.ID = '" + typeid + "' ");

                            if (dt1.Rows.Count > 0)
                            {
                                xtraScB1.Enabled = false;
                            }
                            else if (currentType)
                            {
                                groupBox5.Enabled = false;
                                gbOverAll.Enabled = false;
                                gbTime.Enabled = false;
                                groupControl1.Enabled = true;
                            }
                            else
                            {
                                groupBox5.Enabled = true;
                                gbOverAll.Enabled = true;
                                gbTime.Enabled = true;
                                xtraScB1.Enabled = true;
                            }
                            break;

                        }
                    case "xtraTPB2":
                        {
                            RetriveB2();
                            dt1 = DbClass.getdata(CommandType.Text, "Select p.Point_ID , pt.ID, p.PointName,pt.Point_Name from point p left join type_point pt on p.PointType_ID = pt.ID   where pt.ID = '" + typeid + "' ");

                            if (dt1.Rows.Count > 0)
                            {
                                xtraSCB2.Enabled = false;
                            }
                            else if (currentType)
                            {
                                xtraSCB2.Enabled = true;
                                gbDemodulate.Enabled = false;
                                gbOrdertrace.Enabled = false;
                                gbCepstrum.Enabled = false;
                                hbPowerSpectrum.Enabled = true; ;
                                chkbxG1P1.Checked = true;
                                chkbxG1P1.Enabled = false;
                                cbMultipleBand.Enabled = false;
                                chkbxG2P1.Enabled = false;
                                chkbxG3P1.Enabled = false;
                            }
                            else
                            {
                                gbDemodulate.Enabled = true;
                                gbOrdertrace.Enabled = true;
                                gbCepstrum.Enabled = true;
                                hbPowerSpectrum.Enabled = true; ;
                                chkbxG1P1.Checked = true;
                                chkbxG1P1.Enabled = true;
                                xtraSCB2.Enabled = true;
                                cbMultipleBand.Enabled = true;
                                chkbxG2P1.Enabled = true;
                                chkbxG3P1.Enabled = true;
                            }

                            break;
                        }
                    case "xtraTPB3":
                        {
                            RetriveB3();
                            dt1 = DbClass.getdata(CommandType.Text, "Select p.Point_ID , pt.ID, p.PointName,pt.Point_Name from point p left join type_point pt on p.PointType_ID = pt.ID   where pt.ID = '" + typeid + "' ");
                            if (dt1.Rows.Count > 0)
                            {
                                gbUnitDetection.Enabled = false; gbMeasure.Enabled = false;
                            }
                            else
                            {
                                gbUnitDetection.Enabled = true; gbMeasure.Enabled = true;
                            }
                            break;
                        }
                    case "xtraTPIMXA":
                        {
                            FillGernalAlram();
                            Fill_Band_Alarm_Group();
                            RetriveSciMax();
                            DataTable dtt = new DataTable();
                            dtt = DbClass.getdata(CommandType.Text, "call Retrive_All_Aram_TypeId ('" + typeid + "')");
                            cmbAlarmImxa.Text = "";
                            foreach (DataRow dr in dtt.Rows)
                            {
                                try
                                {
                                    cmbAlarmImxa.Text = Convert.ToString(dr["Alarm_Name"]).Trim();
                                }
                                catch (Exception exe)
                                {
                                    int a = Iadeptmain.GlobalClasess.ExceptionHelper.LineNumber(exe);
                                }
                                if (cmbAlarmImxa.Text == "")
                                {
                                    cmbAlarmImxa.SelectedIndex = 0;
                                }
                            }
                            Retrive_Band_Alarm_Group();
                            dt1 = DbClass.getdata(CommandType.Text, "Select p.Point_ID , pt.ID, p.PointName,pt.Point_Name from point p left join type_point pt on p.PointType_ID = pt.ID   where pt.ID = '" + typeid + "' ");
                            if (dt1.Rows.Count > 0)
                            {
                                gbDI1.Enabled = false; grbAlarms.Enabled = false; gbDI2.Enabled = false;
                            }
                            else
                            {
                                gbDI1.Enabled = true; grbAlarms.Enabled = true; gbDI2.Enabled = true;
                            }
                            break;
                        }
                    case "xtraC911":
                        {
                            FillGernalAlram();
                            Fill_Band_Alarm_Group();
                            RetriveC911();
                            DataTable dtt = new DataTable();
                            dtt = DbClass.getdata(CommandType.Text, "call Retrive_All_Aram_TypeId ('" + typeid + "')");
                            cmbalarmC911.Text = "";
                            foreach (DataRow dr in dtt.Rows)
                            {
                                try
                                {
                                    cmbalarmC911.Text = Convert.ToString(dr["Alarm_Name"]).Trim();
                                }
                                catch (Exception exe)
                                {
                                    int a = Iadeptmain.GlobalClasess.ExceptionHelper.LineNumber(exe);
                                }
                                if (cmbalarmC911.Text == "")
                                {
                                    cmbalarmC911.SelectedIndex = 0;
                                }
                            }
                            Retrive_Band_Alarm_Group();
                            dt1 = DbClass.getdata(CommandType.Text, "Select p.Point_ID , pt.ID, p.PointName,pt.Point_Name from point p left join type_point pt on p.PointType_ID = pt.ID   where pt.ID = '" + typeid + "' ");
                            if (dt1.Rows.Count > 0)
                            {
                                gcC911.Enabled = false; gcC911.Enabled = false;
                            }
                            else
                            {
                                gcC911.Enabled = true; gcC911.Enabled = true;
                            }
                            break;
                        }
                }
            }
            catch { }
        }

        private void cmbPointTpname_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {     
                    if (Convert.ToString(cmbPointTpname.Text).Trim() == "Add New Point Type....")
                    {
                        txtPointtypename.Visible = true;
                        txtPointtypename.Focus();
                        cmbPointTpname.Visible = false;
                        cmbPType.SelectedIndex = 0;
                        string s = cmbPointTpname.Text;
                        if(addition)
                        {
                            tsbtnSave.Enabled = true;
                        }
                        else
                        {
                            tsbtnSave.Enabled = false;
                        }

                    }
                    else if (Convert.ToString(cmbPointTpname.Text).Trim() != "")
                    {
                        txtPointtypename.Visible = false;
                        cmbPType.Enabled = true;
                        cmbPointTpname.Visible = true;
                        string s = cmbPointTpname.Text;
                        if(modification)
                        {
                            tsbtnSave.Enabled = true;
                        }
                        else
                        {
                            tsbtnSave.Enabled = false;
                        }
                    }
                    else
                    {
                        txtPointtypename.Visible = false;
                        cmbPointTpname.Visible = true;
                    }
              
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.StoredProcedure, "call retreive_PType(" + cmbPointTpname.SelectedValue + ") ");
                foreach (DataRow dr in dt.Rows)
                {
                    typeid = Convert.ToString(dr["ID"]);
                    cmbPointTpname.Text = Convert.ToString(dr["Point_name"]);
                    int cmtype = Convert.ToInt32(dr["type_id"]);
                    if (cmtype != -1)
                    {
                        cmbPType.SelectedIndex = cmtype;//Convert.ToInt32(dr["type_id"]);
                        cmbPTypeInst.Text = Convert.ToString(dr["instrumentname"]).Trim();
                    }
                    else
                    {
                        cmbPType.SelectedIndex = -1;
                        cmbPTypeInst.SelectedIndex = -1;
                        blankmeasures();
                        BlankRetriveB2();
                        b3Blank();
                        BlankBb1();
                    }
                    
                }
            }
            catch
            {
                txtPointtypename.Visible = false;
                cmbPointTpname.Visible = true;
                fillcmbPointName();
            }
        }

        private void cbMultipleBand_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool checkvalue = cbMultipleBand.Checked;
                lblPowerBand1.Enabled = checkvalue;
                lblPowerLine1.Enabled = checkvalue;
                cbPSBand1.Enabled = checkvalue;
                cbPSLines1.Enabled = checkvalue;
            }
            catch { }
        }

        private void chkbxG2P2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool checkvalue = chkbxG2P2.Checked;
                lblG2P2Band.Enabled = checkvalue;
                lblG2P2Line.Enabled = checkvalue;
                cbG2PSBand1.Enabled = checkvalue;
                cbG2PSLines1.Enabled = checkvalue;
            }
            catch { }
        }

        private void chkbxG3P2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool checkvalue = chkbxG3P2.Checked;
                lblG3P2Band.Enabled = checkvalue;
                lblG3P2Line.Enabled = checkvalue;
                cbG3PSBand1.Enabled = checkvalue;
                cbG3PSLines1.Enabled = checkvalue;
            }
            catch { }
        }

        private void chkbxG2P1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool checkvalue = chkbxG2P1.Checked;
                if (checkvalue == false)
                {
                    chkbxG3P1.Checked = false;
                    chkbxG3P2.Checked = false;
                    chkbxG2P2.Checked = false;
                }
                chkbxG3P1.Enabled = checkvalue;
                chkbxG2P2.Enabled = checkvalue;
                cbG2PSBand.Enabled = checkvalue;
                cbG2PSLines.Enabled = checkvalue;
                lblG2P1Band.Enabled = checkvalue;
                lblG2P1Line.Enabled = checkvalue;
            }
            catch { }
        }

        private void chkbxG3P1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool checkvalue = chkbxG3P1.Checked;
                if (checkvalue == false)
                    chkbxG3P2.Checked = false;
                chkbxG3P2.Enabled = checkvalue;
                lblG3P1Band.Enabled = checkvalue;
                lblG3P1Line.Enabled = checkvalue;
                cbG3PSBand.Enabled = checkvalue;
                cbG3PSLines.Enabled = checkvalue;
            }
            catch { }
        }

        private void CmbSensorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow drr in dtSensorName.Select("Sensor_name= '" + CmbSensorName.Text + "' "))
                {
                    v_sensor_id = Convert.ToString(drr["Sensor_id"]).Trim();
                    //modify = false;
                }
                DataTable dt1 = new DataTable();
                dt1 = DbClass.getdata(CommandType.Text, "Select distinct Sensor_ID from measure where Sensor_ID = '" + v_sensor_id + "' and Type_ID = '" + typeid + "'");
                if (dt1.Rows.Count > 0)
                {
                    DataTable dt2 = new DataTable();
                    dt2 = DbClass.getdata(CommandType.Text, "Select  sensor_icp from sensor_data where Sensor_ID = '" + v_sensor_id + "'");
                    if (dt2.Rows.Count > 0)
                    {
                        sensoricp = Convert.ToBoolean(Convert.ToInt32(dt2.Rows[0]["Sensor_icp"]));
                        cbICPPower.Checked = Convert.ToBoolean(sensoricp);
                    }
                    //editsensorfielddata(Convert.ToString(v_sensor_id).Trim());
                }
                else
                {
                    editsensorfielddata(Convert.ToString(v_sensor_id).Trim());
                    GetPointDir(sen);

                    DbClass.executequery(CommandType.Text, "Update measure set SensorDir = '" + iTotalVal + "' , Sensor_ID = '" + v_sensor_id + "' where Type_ID= '" + typeid + "'");

                }

            }
            catch { }
        }


       public bool currentType;

        private void PType_Load(object sender, EventArgs e)
        {
            try
            {
                xtraTbPointType.SelectedTabPageIndex = 0;
                xtraTPPType.PageVisible = true;
                xtraTPB0.PageVisible = false;
                xtraTPB1.PageVisible = false;
                xtraTPB2.PageVisible = false;
                xtraTPB3.PageVisible = false;
                xtraTPIMXA.PageVisible = false;
                xtraC911.PageVisible = false;
                Blank();
                if(addition == true || modification == true)
                {
                    tsbtnSave.Enabled = true;
                }
                else
                {
                    tsbtnSave.Enabled = false;
                }
                if(deletion)
                {
                    tsbtnDelete.Enabled = true;
                }
                else
                {
                    tsbtnDelete.Enabled = false;
                }


            }
            catch { }

        }

        private void cmbUnitsMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbCollectionType.SelectedIndex = 1;
                cmbTriggerType.SelectedIndex = 0;
                cmbFullScale.Properties.Items.Clear();

                if (UnitsMain == 0 || UnitsMain == 11)
                {
                    cmbFullScale.Properties.Items.AddRange(new object[] { ("100 G"), ("50 G"), ("20 G"), ("10 G"), ("5 G"), ("2 G"), ("1 G"), (".5 G"), (".2 G"), (".1 G") });
                }
                if (UnitsMain == 1 || UnitsMain == 5)
                {
                    cmbFullScale.Properties.Items.AddRange(new object[] { ("20 IPS"), ("10 IPS"), ("5 IPS"), ("2 IPS"), ("1 IPS"), (".5 IPS"), (".2 IPS"), (".1 IPS") });
                }

                if (UnitsMain == 2 || UnitsMain == 6)
                {
                    cmbFullScale.Properties.Items.AddRange(new object[] { ("500 mm/s"), ("250 mm/s"), ("125 mm/s"), ("50 mm/s"), ("25 mm/s"), ("12.5 mm/s"), ("5 mm/s"), ("2.5 mm/s") });

                }
                if (UnitsMain == 3 || UnitsMain == 7 || UnitsMain == 9)
                {
                    cmbFullScale.Properties.Items.AddRange(new object[] { ("100 Mils"), ("50 Mils"), ("20 Mils"), ("10 Mils"), ("5 Mils"), ("2 Mils") });

                }
                if (UnitsMain == 4 || UnitsMain == 8 || UnitsMain == 10)
                {
                    cmbFullScale.Properties.Items.AddRange(new object[] { ("2500 um"), ("1250 um"), ("500 um"), ("250 um"), ("125 um"), ("50 um") });

                }
                if (UnitsMain == 12)
                {
                    cmbFullScale.Properties.Items.AddRange(new object[] { ("10 V"), ("5 V"), ("2 V"), ("1 V"), (".5 V"), (".2 V"), (".1 V"), (".05 V"), (".02 V"), (".01 V") });

                }
                if (UnitsMain == 13)
                {
                    cmbFullScale.Properties.Items.AddRange(new object[] { ("100000 RPM"), ("50000 RPM"), ("10000 RPM"), ("5000 RPM"), ("1000 RPM"), ("500 RPM"), ("100 RPM"), ("50 RPM"), ("10 RPM"), ("5 RPM") });
                    cmbTriggerType.SelectedIndex = 1;
                }
                if (UnitsMain > 13)
                {
                    cmbFullScale.Properties.Items.AddRange(new object[] { ("100000"), ("10000"), ("1000"), ("100"), ("10"), ("1"), (".1"), (".01"), (".001") });
                    cmbCollectionType.SelectedIndex = 0;
                }
                cmbFullScale.SelectedIndex = 0;

            }
            catch { }
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbFilterValue.Properties.Items.Clear();
                if (FilterType == 0)
                {
                    cmbFilterValue.Properties.Items.AddRange(new object[] { (" ") });
                }
                if (FilterType == 2)
                {
                    cmbFilterValue.Properties.Items.AddRange(new object[] { ("2 Hz"), ("10 Hz"), ("70 Hz") });

                }
                if (FilterType == 1 || FilterType == 3)
                {
                    cmbFilterValue.Properties.Items.AddRange(new object[] { ("None"), (".5 Hz to 1 KHz"), (".6 Hz to 1.25 KHz"), ("1 KHz to 10 KHz"), ("1.25 KHz to 2.5 KHz"), ("2.5 KHz to 5 KHz"), ("5 KHz to 10 KHz"), ("10 KHz to 20 KHz") });

                }

                cmbFilterValue.SelectedIndex = 0;

            }
            catch { }
        }

        private void cmbMeasureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbResolution.Properties.Items.Clear();
                if (MeasureType == 0 || MeasureType == 1)
                {
                    cmbResolution.Properties.Items.AddRange(new object[] { ("100"), ("200"), ("400"), ("800"), ("1600"), ("3200"), ("6400") });

                }
                if (MeasureType == 2 || MeasureType == 3)
                {
                    cmbResolution.Properties.Items.AddRange(new object[] { ("256"), ("512"), ("1024"), ("2048"), ("4096"), ("8192"), ("16384") });

                }
                cmbResolution.SelectedIndex = 3;
            }
            catch { }
        }


        private void txtPointtypename_Leave(object sender, EventArgs e)
        {
            try
            {
                savepointname();
                if(addition)
                {
                    tsbtnSave.Enabled = true;
                }
                else
                {
                    tsbtnSave.Enabled = false;
                }
                _objMain.lblStatus.Caption = "Status: Create Point Type Successfully";
            }
            catch { }
        }

        private void cmbPTypeInst_SelectedValueChanged(object sender, EventArgs e)
        {
            string sSelectedvalue = cmbPTypeInst.Text;

            switch (sSelectedvalue)
            {
                case "Impaq-Benstone":
                    {
                        xtraTPB0.PageVisible = true;
                        xtraTPB1.PageVisible = true;
                        xtraTPB2.PageVisible = true;
                        xtraTPB3.PageVisible = true;
                        xtraTPIMXA.PageVisible = false;
                        xtraC911.PageVisible = false;
                        break;
                    }
                case "FieldPaq2":
                    {
                        xtraTPB0.PageVisible = true;
                        xtraTPB1.PageVisible = true;
                        xtraTPB2.PageVisible = true;
                        xtraTPB3.PageVisible = true;
                        xtraTPIMXA.PageVisible = false;
                        xtraC911.PageVisible = false;
                        break;
                    }
                case "SKF/DI":
                    {
                        xtraTPB0.PageVisible = false;
                        xtraTPB1.PageVisible = false;
                        xtraTPB2.PageVisible = false;
                        xtraTPB3.PageVisible = false;
                        xtraTPIMXA.PageVisible = true;
                        xtraC911.PageVisible = false;
                        break;
                    }
                case "Kohtect-C911":
                    {
                        xtraTPB0.PageVisible = false;
                        xtraTPB1.PageVisible = false;
                        xtraTPB2.PageVisible = false;
                        xtraTPB3.PageVisible = false;
                        xtraTPIMXA.PageVisible = false;
                        xtraC911.PageVisible = true;
                        break;
                    }
                default:
                    {

                        xtraTPB0.PageVisible = false;
                        xtraTPB1.PageVisible = false;
                        xtraTPB2.PageVisible = false;
                        xtraTPB3.PageVisible = false;
                        xtraTPIMXA.PageVisible = false;
                        xtraC911.PageVisible = false;
                        break;
                    }
            }
        }

        private void cmbtempname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow drr in dttempName.Select("Sensor_name= '" + cmbtempname.Text + "' "))
                {
                    v_temp_id = Convert.ToString(drr["Sensor_id"]);
                }
            }
            catch { }
        }

        private void chkVertical_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAxial.Checked == false && chkHorizontal.Checked == false && chkVertical.Checked == false)
            {
                chkAxial.Checked = true;
            }
        }

        private void xtraTPPType_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmbPointTpname.Text).Trim() == "" || cmbPType.SelectedIndex < 0 || cmbPTypeInst.SelectedIndex < 0)
                {
                    cmbPointTpname.Focus();
                    return;
                }

                DataTable dt = new DataTable();

                dt = DbClass.getdata(CommandType.Text, "select distinct ID,Point_Name from type_point where Point_Name='" + cmbPointTpname.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    typeid = Convert.ToString(dt.Rows[0][0]);
                    Modify = true;
                    edit = false;
                }
                else
                {
                    Modify = false;
                    edit = true;

                }

                if (edit == true)
                {

                    DbClass.executequery(CommandType.StoredProcedure, "call Insert_Point_Type ('" + cmbPType.SelectedIndex + "' , '" + Convert.ToString(cmbPointTpname.Text).Trim() + "' ,'" + cmbPTypeInst.Text + "') ");

                }
                else if (Modify == true)
                {
                    DbClass.executequery(CommandType.StoredProcedure, "call Update_Point_Type ('" + cmbPType.SelectedIndex + "' , '" + Convert.ToString(cmbPointTpname.Text).Trim() + "' ,'" + cmbPTypeInst.Text + "','" + typeid + "') ");
                }
            }
            catch { }
        }

        public String selectedradio1;
        public string selectedradio2;
        public void RadioChkChannel1()
        {
            {
                try
                {
                    if (rbrnv.Checked)
                    {
                        selectedradio1 = "3";
                    }
                    else if (rbint.Checked)
                    {
                        selectedradio1 = "2";
                    }
                    else if (rbintv.Checked)
                    {
                        selectedradio1 = "1";
                    }
                    else
                    {
                        selectedradio1 = "0";
                    }
                }
                catch { }
            }

            {
                try
                {
                    if (rbampenv.Checked)
                    {
                        selectedradio2 = "3";
                    }
                    else if (rbampint2.Checked)
                    {
                        selectedradio2 = "2";
                    }
                    else if (rbampint1.Checked)
                    {
                        selectedradio2 = "1";
                    }
                    else
                    {
                        selectedradio2 = "0";
                    }
                }
                catch { }
            }
        }



        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string V_GeneralAlarm = "";
                if (txtPointtypename.Text.Trim() == "")
                {
                    if (cmbPointTpname.Text.Trim() == "" || cmbPointTpname.Text.Trim() == "Add New Point Type....")
                    {
                        MessageBox.Show(this, "Please Create New Point Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbPType.SelectedIndex = 0;
                        return;
                    }
                }
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    int Caclmeasure = SetListView();
                    GetPointDir(sen);
                    int cSensorID = iTotalVal;
                    string sMultipleBandValue = CalculateMultipleBandValue(chkbxG1P1.Checked, cbMultipleBand.Checked, chkbxG2P1.Checked, chkbxG2P2.Checked, chkbxG3P1.Checked, chkbxG3P2.Checked);

                    DataTable dtMesure = new DataTable();
                    dtMesure = DbClass.getdata(CommandType.Text, "Select * from measure where Type_ID = '" + typeid + "'");
                    if (dtMesure.Rows.Count > 0)
                    {
                        DbClass.executequery(CommandType.Text, "call update_Measure('" + Convert.ToString(cbAccelerationFilter.SelectedIndex) + "', '" + Convert.ToString(cbVelocityFilter.SelectedIndex) + "', '" + Convert.ToString(cbDispFilter.SelectedIndex) + "', '" + Convert.ToString(cbBearingFilter.SelectedIndex) + "' , '" + Convert.ToString(cbCrestFilter.SelectedIndex) + "' , '" + Convert.ToString(cmbaccHPFilter.SelectedIndex) + "'  , '" + Convert.ToString(cbTimeBand.SelectedIndex) + "' , '" + Convert.ToString(cbLines.SelectedIndex) + "', '" + Convert.ToString(cbOverlap.SelectedIndex) + "','" + PublicClass.GetDatetime() + "' ,'" + cSensorID + "','" + PublicClass.DefVal(v_sensor_id, "0") + "','" + PublicClass.DefVal(v_temp_id, "0") + "', '" + cbPSBand.SelectedIndex + "', '" + cbPSLines.SelectedIndex + "', '" + cbPSBand1.SelectedIndex + "','" + cbPSLines1.SelectedIndex + "','" + cbG2PSBand.SelectedIndex + "','" + cbG2PSLines.SelectedIndex + "','" + cbG2PSBand1.SelectedIndex + "','" + cbG2PSLines1.SelectedIndex + "','" + cbG3PSBand.SelectedIndex + "','" + cbG3PSLines.SelectedIndex + "','" + cbG3PSBand1.SelectedIndex + "','" + cbG3PSLines1.SelectedIndex + "','" + cbPSWindow.SelectedIndex + "','" + cbPSOverlap.SelectedIndex + "','" + cbAvgTimes.SelectedIndex + "','" + setvalue(Convert.ToBoolean(cbZoom.Checked)) + "','" + PublicClass.DefVal(Convert.ToString(txtPSZoom.Text), "0") + "','" + cbCepBand.SelectedIndex + "','" + cbCepLine.SelectedIndex + "','" + cbCepWind.SelectedIndex + "','" + cbCepAvgTime.SelectedIndex + "','" + cbCepOverlap.SelectedIndex + "','" + setvalue(Convert.ToBoolean(chkCepZoom.Checked)) + "','" + PublicClass.DefVal(Convert.ToString(txtCepZoom.Text), "0") + "','" + cbDMBand.SelectedIndex + "','" + cmbdmLines.SelectedIndex + "','" + cmbdmWindow.SelectedIndex + "','" + cmbdmAvgTimes.SelectedIndex + "','" + cbFilter.SelectedIndex + "','" + cbOTAvg.SelectedIndex + "','" + cbOTLines.SelectedIndex + "','" + PublicClass.DefVal(Convert.ToString(txtOTOrder.Text), "0") + "','" + cbOTSlope.SelectedIndex + "', '" + sMultipleBandValue + "' ,  '" + typeid + "','" + cmbOctave.SelectedIndex + "','" + cmbBarstyle.SelectedIndex + "' ) ");
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "call Insert_Measure('" + Convert.ToString(cbAccelerationFilter.SelectedIndex) + "', '" + Convert.ToString(cbVelocityFilter.SelectedIndex) + "', '" + Convert.ToString(cbDispFilter.SelectedIndex) + "', '" + Convert.ToString(cbBearingFilter.SelectedIndex) + "' , '" + Convert.ToString(cbCrestFilter.SelectedIndex) + "'  ,'" + Convert.ToString(cmbaccHPFilter.SelectedIndex) + "', '" + Convert.ToString(cbTimeBand.SelectedIndex) + "' , '" + Convert.ToString(cbLines.SelectedIndex) + "', '" + Convert.ToString(cbOverlap.SelectedIndex) + "','" + PublicClass.GetDatetime() + "' ,'" + cSensorID + "','" + PublicClass.DefVal(v_sensor_id, "0") + "','" + PublicClass.DefVal(v_temp_id, "0") + "', '" + cbPSBand.SelectedIndex + "', '" + cbPSLines.SelectedIndex + "', '" + cbPSBand1.SelectedIndex + "','" + cbPSLines1.SelectedIndex + "','" + cbG2PSBand.SelectedIndex + "','" + cbG2PSLines.SelectedIndex + "','" + cbG2PSBand1.SelectedIndex + "','" + cbG2PSLines1.SelectedIndex + "','" + cbG3PSBand.SelectedIndex + "','" + cbG3PSLines.SelectedIndex + "','" + cbG3PSBand1.SelectedIndex + "','" + cbG3PSLines1.SelectedIndex + "','" + cbPSWindow.SelectedIndex + "','" + cbPSOverlap.SelectedIndex + "','" + cbAvgTimes.SelectedIndex + "','" + setvalue(Convert.ToBoolean(cbZoom.Checked)) + "','" + PublicClass.DefVal(Convert.ToString(txtPSZoom.Text), "0") + "','" + cbCepBand.SelectedIndex + "','" + cbCepLine.SelectedIndex + "','" + cbCepWind.SelectedIndex + "','" + cbCepAvgTime.SelectedIndex + "','" + cbCepOverlap.SelectedIndex + "','" + setvalue(Convert.ToBoolean(chkCepZoom.Checked)) + "','" + PublicClass.DefVal(Convert.ToString(txtCepZoom.Text), "0") + "','" + cbDMBand.SelectedIndex + "','" + cmbdmLines.SelectedIndex + "','" + cmbdmWindow.SelectedIndex + "','" + cmbdmAvgTimes.SelectedIndex + "','" + cbFilter.SelectedIndex + "','" + cbOTAvg.SelectedIndex + "','" + cbOTLines.SelectedIndex + "','" + PublicClass.DefVal(Convert.ToString(txtOTOrder.Text), "0") + "','" + cbOTSlope.SelectedIndex + "', '" + sMultipleBandValue + "' ,  '" + typeid + "','" + cmbOctave.SelectedIndex + "','" + cmbBarstyle.SelectedIndex + "' ) ");
                    }

                    DataTable dtmeasureType = new DataTable();
                    dtmeasureType = DbClass.getdata(CommandType.Text, "Select * from measure_type where Type_ID = '" + typeid + "'");
                    if (dtmeasureType.Rows.Count > 0)
                    {

                        DbClass.executequery(CommandType.StoredProcedure, "call update_measure_type ('" + setvalue(Convert.ToBoolean(lstmeasure.Items[0].Checked)) + "' , '" + setvalue(Convert.ToBoolean(lstmeasure.Items[1].Checked)) + "' ,'" + setvalue(Convert.ToBoolean(lstmeasure.Items[2].Checked)) + "'  , '" + setvalue(Convert.ToBoolean(lstmeasure.Items[3].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[4].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[5].Checked)) + "' , '" + setvalue(Convert.ToBoolean(lstmeasure.Items[6].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[7].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[8].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[9].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[10].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[11].Checked)) + "'  ,'" + typeid + "','" + Caclmeasure + "' ) ");
                    }
                    else
                    {
                        DbClass.executequery(CommandType.StoredProcedure, "call insert_measure_type ('" + setvalue(Convert.ToBoolean(lstmeasure.Items[0].Checked)) + "' , '" + setvalue(Convert.ToBoolean(lstmeasure.Items[1].Checked)) + "' ,'" + setvalue(Convert.ToBoolean(lstmeasure.Items[2].Checked)) + "'  , '" + setvalue(Convert.ToBoolean(lstmeasure.Items[3].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[4].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[5].Checked)) + "' , '" + setvalue(Convert.ToBoolean(lstmeasure.Items[6].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[7].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[8].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[9].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[10].Checked)) + "', '" + setvalue(Convert.ToBoolean(lstmeasure.Items[11].Checked)) + "'  ,'" + typeid + "','" + Caclmeasure + "' ) ");
                    }

                    DataTable dtUnit = new DataTable();
                    dtUnit = DbClass.getdata(CommandType.Text, "Select * from units where Type_ID = '" + typeid + "'");
                    if (dtUnit.Rows.Count > 0)
                    {
                        DbClass.executequery(CommandType.Text, "call update_Units('" + cbAcc.SelectedIndex + "','" + cbAccUnit.SelectedIndex + "','" + cbVel.SelectedIndex + "', '" + cbVelUnit.SelectedIndex + "', '" + cbDisp.SelectedIndex + "','" + cbDispUnit.SelectedIndex + "','" + cbTemp.SelectedIndex + "','" + txtProcess.Text.Trim() + "','" + cbPressure.SelectedIndex + "','" + cbPressureUnit.SelectedIndex + "','" + cbCurrent.SelectedIndex + "','" + cbCurrentUnit.SelectedIndex + "','" + cbTime.SelectedIndex + "','" + cbSpectrum.SelectedIndex + "','" + cbDemodulate.SelectedIndex + "','" + cbOrderTrace.SelectedIndex + "','" + cbCepstrum.SelectedIndex + "','" + PublicClass.GetDatetime() + "' ,'" + typeid + "' ) ");

                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "call insert_Units('" + cbAcc.SelectedIndex + "','" + cbAccUnit.SelectedIndex + "','" + cbVel.SelectedIndex + "', '" + cbVelUnit.SelectedIndex + "', '" + cbDisp.SelectedIndex + "','" + cbDispUnit.SelectedIndex + "','" + cbTemp.SelectedIndex + "','" + txtProcess.Text + "','" + cbPressure.SelectedIndex + "','" + cbPressureUnit.SelectedIndex + "','" + cbCurrent.SelectedIndex + "','" + cbCurrentUnit.SelectedIndex + "','" + cbTime.SelectedIndex + "','" + cbSpectrum.SelectedIndex + "','" + cbDemodulate.SelectedIndex + "','" + cbOrderTrace.SelectedIndex + "','" + cbCepstrum.SelectedIndex + "','" + PublicClass.GetDatetime() + "' ,'" + typeid + "' ) ");
                    }

                    GetPointDir(sen);
                    if (sen == 2)
                    {
                        DbClass.executequery(CommandType.Text, "Update measure set SensorDir = '" + iTotalVal + "' where Type_ID = '" + typeid + "'");
                        //DbClass.executequery(CommandType.Text, "update measure_type set CalcMeasure = '4095' where Type_ID = '" + typeid + "'");
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "Update measure set SensorDir = '" + iTotalVal + "' where Type_ID = '" + typeid + "'");
                    }

                    UpdateallAlarmType();
                    Update_Band_Alarm_Group();
                    MessageBox.Show(this, "Data Saved successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    RadioChkChannel1();
                    DataTable dtMesure = new DataTable();
                    dtMesure = DbClass.getdata(CommandType.Text, "Select * from c911_measurement where Type_id = '" + typeid + "'");
                    if (dtMesure.Rows.Count > 0)
                    {
                        DbClass.executequery(CommandType.Text, "Update c911_measurement set Channel1='" + cmbchannel1.SelectedIndex + "',SelectRadio1='" + selectedradio1 + "',EV_Frequency='" + cmbenv.SelectedIndex + "', Channel2='" + cmbchannel2.SelectedIndex + "',SelectRadio2='" + selectedradio2 + "', Spectrum_LineNo='" + cmbspectral.SelectedIndex + "',Window_Type='" + cmbwindow.SelectedIndex + "',Fmin='" + cmbFmin.SelectedIndex + "',Fmax='" + cmbfmax.SelectedIndex + "',Trigger_Mode='" + cmbtrigger.SelectedIndex + "', Avg_Mode='" + cmbAvermode.SelectedIndex + "',N='" + txtN.Text + "', Comments='" + txtcomment.Text + "' where type_id='" + typeid + "'");
                        MessageBox.Show(this, "Data update successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        RadioChkChannel1();
                        DbClass.executequery(CommandType.Text, "insert Into c911_measurement(type_id,Channel1,SelectRadio1,EV_Frequency,Channel2,SelectRadio2,Spectrum_LineNo,Window_Type,Fmin,Fmax,Trigger_Mode,Avg_Mode,N,Comments) values('" + typeid + "','" + cmbchannel1.SelectedIndex + "','" + selectedradio1 + "','" + cmbenv.SelectedIndex + "', '" + cmbchannel2.SelectedIndex + "','" + selectedradio2 + "', '" + cmbspectral.SelectedIndex + "','" + cmbwindow.SelectedIndex + "','" + cmbFmin.SelectedIndex + "','" + cmbfmax.SelectedIndex + "','" + cmbtrigger.SelectedIndex + "','" + cmbAvermode.SelectedIndex + "','" + txtN.Text + "','" + txtcomment.Text + "')");
                        MessageBox.Show(this, "Data Saved successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // clear();
                    }
                    //cmbPointTpname.Text = "";
                    //cmbPointTpname.SelectedIndex = -1;
                }
                else
                {
                    DataTable dtDI = new DataTable();
                    dtDI = DbClass.getdata(CommandType.Text, "Select * from di_point where Type_ID = '" + typeid + "'");
                    if (dtDI.Rows.Count > 0)
                    {
                        DbClass.executequery(CommandType.Text, "call update_Di_Point('" + typeid + "'  , '" + cmbFullScale.SelectedIndex + "','" + tbSensitivity.Text + "','" + cmbCouple.SelectedIndex + "', '" + cmbDetectionType.SelectedIndex + "', '" + cmbWindowType.SelectedIndex + "','" + cmbFilterType.SelectedIndex + "','" + cmbFilterValue.SelectedIndex + "','" + cmbDirection.SelectedIndex + "','" + cmbCollectionType.SelectedIndex + "','" + cmbMeasureType.SelectedIndex + "','" + cmbResolution.SelectedIndex + "','" + cmbFrequency.SelectedIndex + "','" + cmbOrders.SelectedIndex + "','" + tbSpecAver.Text + "','" + tbTimeAveg.Text + "','" + tbOverlap.Text + "','" + cmbTriggerType.SelectedIndex + "','" + cmbSlope1.SelectedIndex + "' ,'" + tbLevel.Text + "' , '" + cmbTriggerRange.SelectedIndex + "','" + cmbChannelType.SelectedIndex + "','" + cmbUnitsMain.SelectedIndex + "') ");
                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "call insert_Di_Point('" + typeid + "'  , '" + cmbFullScale.SelectedIndex + "','" + tbSensitivity.Text + "','" + cmbCouple.SelectedIndex + "', '" + cmbDetectionType.SelectedIndex + "', '" + cmbWindowType.SelectedIndex + "','" + cmbFilterType.SelectedIndex + "','" + cmbFilterValue.SelectedIndex + "','" + cmbDirection.SelectedIndex + "','" + cmbCollectionType.SelectedIndex + "','" + cmbMeasureType.SelectedIndex + "','" + cmbResolution.SelectedIndex + "','" + cmbFrequency.SelectedIndex + "','" + cmbOrders.SelectedIndex + "','" + tbSpecAver.Text + "','" + tbTimeAveg.Text + "','" + tbOverlap.Text + "','" + cmbTriggerType.SelectedIndex + "','" + cmbSlope1.SelectedIndex + "' ,'" + tbLevel.Text + "' , '" + cmbTriggerRange.SelectedIndex + "','" + cmbChannelType.SelectedIndex + "' ,'" + cmbUnitsMain.SelectedIndex + "') ");
                    }
                    foreach (DataRow dr in DtGeneralAlram.Select("Alarm_Name=   '" + Convert.ToString(cmbAlarmImxa.Text).Trim() + "' "))
                    {
                        V_GeneralAlarm = Convert.ToString(dr["Alarm_ID"]);
                    }
                    DbClass.executequery(CommandType.StoredProcedure, "call Update_All_Aram_TypeId ('0','0','" + V_GeneralAlarm + "','" + typeid + "') ");
                    Update_Band_Alarm_Group();
                    MessageBox.Show(this, "Data Saved successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {

            }
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.Text, "call CheckPointTypeId ('" + typeid + "')");
                if (dtt.Rows.Count - 1 >= 0)
                {
                    MessageBox.Show(this, "Point Type is already in used", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (cmbPointTpname.Text == "")
                    {
                        MessageBox.Show(this, "Please select Any Point Type", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        DialogResult Drslt = MessageBox.Show(this, "Do you want to Delete", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (Drslt == DialogResult.Yes)
                        {
                            DbClass.executequery(CommandType.Text, "call Deletepointtype ('" + typeid + "')");
                            fillcmbPointName();
                            cmbPointTpname.Text = "";
                            cmbPointTpname.SelectedIndex = -1;
                            _objMain.lblStatus.Caption = "Status: Deleting Point Type Successfully";
                            xtraTbPointType.SelectedTabPage = xtraTPPType;
                            cmbPType.SelectedIndex = 0;
                        }
                    }
                 
                }
            }
            catch { }
        }

        private void txtPointtypename_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[a-zA-Z0-9]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = false;
            }
            else if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '_')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '(')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == ')')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '+')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '=')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cbZoom_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbZoom.Checked)
                {
                    txtPSZoom.Enabled = true;
                }
                else
                {
                    txtPSZoom.Enabled = false;
                    txtPSZoom.Text = "0";
                }
            }
            catch { }
        }

        private void chkCepZoom_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCepZoom.Checked)
                {
                    txtCepZoom.Enabled = true;
                }
                else
                {
                    txtCepZoom.Enabled = false;
                    txtCepZoom.Text = "0";
                }
            }
            catch { }
        }

        private void cmbPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPointTpname.Text == "")
                {
                    cmbPType.SelectedIndex = 0;
                    return;
                }
                currentType = false;
                sSelectedValue = cmbPType.Text;
                switch (sSelectedValue)
                {
                    case "Vibration":
                        {
                            fillcmbPTypeInst();
                            cmbPTypeInst.Enabled = false;
                            break;
                        }
                    case "Current":
                        {
                            fillcmbPTypeInst();
                            cmbPTypeInst.Enabled = false;
                            currentType = true;
                            break;
                        }
                    case "Pressure":
                        {
                            fillcmbPTypeInst();
                            cmbPTypeInst.Enabled = false;
                            break;
                        }
                    case "Sound":
                        {
                            fillcmbPTypeInst();
                            cmbPTypeInst.Enabled = false;
                            break;
                        }
                    case "Manual Entry":
                        {
                            cmbPTypeInst.Enabled = false;
                            cmbPTypeInst.Text = "";
                            break;
                        }
                    default:
                        {
                            cmbPTypeInst.Text = "--Select--";
                            cmbPTypeInst.Enabled = false;
                            break;
                        }
                }
                if (sSelectedValue != null && sSelectedValue != "")
                {
                    if (cmbPType.Text != "--Select--" && cmbPType.Text != "")
                    {
                        if (PublicClass.currentInstrument == "Impaq-Benstone")
                        {
                            cmbPTypeInst.SelectedIndex = 1;
                            cmbPTypeInst.Enabled = false;
                        }
                        else if (PublicClass.currentInstrument == "FieldPaq2")
                        {
                            cmbPTypeInst.SelectedIndex = 5;
                            cmbPTypeInst.Enabled = false;
                        }
                        else if (PublicClass.currentInstrument == "Kohtect-C911")
                        {
                            cmbPTypeInst.SelectedIndex = 3;
                            cmbPTypeInst.Enabled = false;
                        }
                        else
                        { cmbPTypeInst.SelectedIndex = 2; cmbPTypeInst.Enabled = false; }
                    }
                    else
                    { cmbPTypeInst.SelectedIndex = 0; cmbPTypeInst.Enabled = false; }
                }
                else
                { cmbPTypeInst.SelectedIndex = 0; cmbPTypeInst.Enabled = false; }

            }
            catch
            {
            }
        }

   
        private void txthigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled == char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != (char)Keys.Back)
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

