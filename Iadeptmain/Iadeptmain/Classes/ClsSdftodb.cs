using Iadeptmain.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iadeptmain.Classes;
using Microsoft.SqlServerCe.Client;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.IO.Ports;
using System.Threading;
using Iadeptmain.Mainforms;
using DevExpress.XtraSplashScreen;
using System.ComponentModel;

namespace Iadeptmain.Classes
{
    public class ClsSdftodb
    {
        frmIAdeptMain _objMain; frmupdownload _objupdown = null;
        ResizeArray_Interface _ResizeArray = new ResizeArray_Control();
        public static string connval = "";
        public string sPathtosave = null;
        public string PCPath
        {
            get
            {
                return sPathtosave;
            }
            set
            {
                sPathtosave = value;
            }
        }

        public frmupdownload MainForm
        {
            get
            {
                return _objupdown;
            }
            set
            {
                _objupdown = value;
            }
        }
        public frmIAdeptMain Main
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


        bool AckForSame = false;
        private bool CheckForRightSDF(string ConnStr)
        {
            try
            {
                SqlCeCommand objCOmmandCE = null;
                SqlCeDataReader objReaderCE = null;
                using (SqlCeConnection objCOnnectionCE = new SqlCeConnection())
                {
                    objCOnnectionCE.ConnectionString = "Data Source=" + ConnStr;
                    objCOnnectionCE.Open();
                    connvalu = ConnStr;
                    AckForSame = true;
                }
            }
            catch { }
            return AckForSame;
        }

        public void alltransfer(string Dbname)
        {
            try
            {
                CheckForRightSDF(PCPath);
                if (AckForSame == true)
                {
                    ConvertSensors(Dbname);
                    ConvertAlarms(Dbname);
                    Converthierarchypoint(Dbname);
                    insertdata();
                    Converthierarchyfac(Dbname);
                    Converthierarchyare(Dbname);
                    Converthierarchytra(Dbname);
                    Converthierarchymac(Dbname);
                    Convertnotes(Dbname);
                    ConvertBandAlarm(Dbname);
                }
            }
            catch
            { }
        }
        string lastgroup; int count = 1;
        public string ConvertBandAlarm(string DBName)
        {
            try
            {
                DataTable dtSenOld = SqlceClass.getdata(CommandType.Text, "select * from bandalarm", "Data Source=" + connvalu);
                foreach (DataRow drsen in dtSenOld.Rows)
                {
                    string bandalarm_id = Convert.ToString(drsen["bandalarm_id"]);
                    string bandalarmgroup_name = "DefaultBand-" + bandalarm_id + "";
                    string bandalarm_name = Convert.ToString(drsen["bandalarm_name"]);
                    string freq = Convert.ToString(drsen["freq"]);
                    string alarm1 = Convert.ToString(drsen["alarm1"]);
                    string alarm2 = Convert.ToString(drsen["alarm2"]);
                    string groupid = Convert.ToString(drsen["group_id"]);
                    if (lastgroup != groupid)
                    {
                        count = 1;
                        DbClass.executequery(CommandType.Text, "Insert Into bandalarm_data(bandalarmsgroup_id,bandalarmsgroup_name)values('" + groupid + "','" + bandalarmgroup_name + "')");
                    }
                    else
                    {
                        count++;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        lastgroup = groupid;
                        DbClass.executequery(CommandType.Text, "Insert Into band_data(bandalarm_name,freq,X,Y,Axis_type,counter,Group_id,datetime)values('" + bandalarm_name + "','" + freq + "','" + alarm1 + "','" + alarm2 + "','" + i + "','" + count + "','" + groupid + "','" + PublicClass.GetDatetime() + "')");
                        // i++;
                    }

                }
            }
            catch
            { }
            return DBName;
        }


        public string Convertnotes(string DBName)
        {
            try
            {
                //machinenotes
                try
                {
                    DataTable dtnotesmac = new DataTable();
                    dtnotesmac = SqlceClass.getdata(CommandType.Text, "select * from descriptions", "Data Source=" + connvalu);
                    foreach (DataRow drmac in dtnotesmac.Rows)
                    {
                        string nDescid = Convert.ToString(drmac["desc_id"]);
                        string nDesc = Convert.ToString(drmac["desc_content"]);
                        DbClass.executequery(CommandType.Text, "insert into notes(Notes_id,Notes_Desc , Note_type  , Date) values( '" + nDescid + "','" + nDesc + "' , '1' , '" + PublicClass.GetDatetime() + "' )");
                    }
                }
                catch { }
                //pointnotes
                try
                {
                    DataTable dtnotes = new DataTable();
                    dtnotes = SqlceClass.getdata(CommandType.Text, "select * from notes", "Data Source=" + connvalu);
                    foreach (DataRow drfac in dtnotes.Rows)
                    {
                        string nDescid = Convert.ToString(drfac["note_id"]);
                        string nDesc = Convert.ToString(drfac["note_content"]);
                        DbClass.executequery(CommandType.Text, "insert into notes(Notes_id,Notes_Desc , Note_type  , Date) values( '" + nDescid + "','" + nDesc + "' , '2' , '" + PublicClass.GetDatetime() + "' )");
                    }
                }
                catch
                { }
                //machine_record
                try
                {
                    DataTable dtmr = new DataTable();
                    dtmr = SqlceClass.getdata(CommandType.Text, "select * from machine_record", "Data Source=" + connvalu);
                    foreach (DataRow drmr in dtmr.Rows)
                    {
                        string nrecordtime = GetValueForMeasureTime(Convert.ToString(drmr["record_time"]));
                        string nmacid = Convert.ToString(drmr["machine_id"]);
                        string nnoteid = Convert.ToString(drmr["note_id"]);
                        DbClass.executequery(CommandType.Text, "insert into machine_record(Date , Machine_id  , note_id) values( '" + nrecordtime + "' , '" + nmacid + "' , '" + nnoteid + "' )");

                    }
                }
                catch { }
                //faultfreq
                try
                {
                    DataTable dtmr = new DataTable();
                    dtmr = SqlceClass.getdata(CommandType.Text, "select * from point_faultfreq", "Data Source=" + connvalu);
                    foreach (DataRow drunit in dtmr.Rows)
                    {
                        int iPfID = Convert.ToInt32(drunit["Pf_ID"]);
                        string iPfname = Convert.ToString(drunit["pf_name"]);
                        string iPfFreq = Convert.ToString(drunit["pf_freq"]);
                        string iPfPointID = Convert.ToString(drunit["Point_ID"]);
                        DbClass.executequery(CommandType.Text, "Insert into point_faultfreq(Point_id,faultfreq_id)values('" + iPfPointID + "','" + iPfID + "')");
                        DbClass.executequery(CommandType.Text, "insert into faultfreq_data(pf_id,pf_name,pf_freq,date)values('" + iPfID + "','" + iPfname + "','" + iPfFreq + "','" + PublicClass.GetDatetime() + "')");
                    }
                }
                catch
                { }

            }
            catch
            { }
            return DBName;
        }



        public string Converthierarchyfac(string DBName)
        {
            try
            {
                DataTable dtfac = new DataTable();
                DbClass.executequery(CommandType.Text, "ALTER TABLE `factory_info` CHANGE COLUMN `Factory_ID` `Factory_ID` INT(10) UNSIGNED NOT NULL ;");
                dtfac = SqlceClass.getdata(CommandType.Text, "select * from plants", "Data Source=" + connvalu);
                foreach (DataRow drfac in dtfac.Rows)
                {
                    string facName = Convert.ToString(drfac["plant_name"]);
                    int hyPreviousID = 0;
                    int hyNextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into factory_info(Factory_ID,Name,Description,DateCreated,PreviousID,NextID) values('" + Convert.ToString(drfac["plant_id"]) + "','" + facName + "','Factory','" + PublicClass.GetDatetime() + "','" + hyPreviousID + "','" + hyNextId + "')");
                    DataTable dtfacfinal = DbClass.getdata(CommandType.Text, "Select max(factory_id) from factory_info ");
                    hyPreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtfacfinal.Rows[0][0]), "0"))) - 1;
                    hyNextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtfacfinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update factory_info set PreviousID = '" + hyPreviousID + "',NextID='" + hyNextId + "' where factory_id = '" + Convert.ToString(dtfacfinal.Rows[0][0]) + "'");
                }
                DbClass.executequery(CommandType.Text, "ALTER TABLE `factory_info` CHANGE COLUMN `Factory_ID` `Factory_ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ;");

            }
            catch
            { }
            return DBName;
        }

        public string Converthierarchyare(string DBName)
        {
            try
            {
                DataTable dtare = new DataTable();
                DbClass.executequery(CommandType.Text, "ALTER TABLE `area_info` CHANGE COLUMN `Area_ID` `Area_ID` INT(10) UNSIGNED NOT NULL ;");
                dtare = SqlceClass.getdata(CommandType.Text, "select * from Areas", "Data Source=" + connvalu);
                foreach (DataRow drare in dtare.Rows)
                {
                    string AreaName = Convert.ToString(drare["Area_name"]);
                    string facid = Convert.ToString(drare["plant_id"]);
                    int PreviousID = 0;
                    int NextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into area_info(Area_ID,Name,Description,FactoryID,PreviousID,NextID,DateCreated) values('" + Convert.ToString(drare["area_id"]) + "','" + AreaName + "','Area','" + facid + "','" + PreviousID + "','" + NextId + "','" + PublicClass.GetDatetime() + "')");
                    DataTable dtareafinal = DbClass.getdata(CommandType.Text, "Select max(Area_ID) from area_info ");
                    PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtareafinal.Rows[0][0]), "0"))) - 1;
                    NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtareafinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update area_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Area_ID = '" + Convert.ToString(dtareafinal.Rows[0][0]) + "'");
                }
                DbClass.executequery(CommandType.Text, "ALTER TABLE `area_info` CHANGE COLUMN `Area_ID` `Area_ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ;");
            }
            catch { }
            return DBName;
        }



        public string Converthierarchytra(string DBName)
        {
            try
            {
                DataTable dtare = new DataTable();
                DbClass.executequery(CommandType.Text, "ALTER TABLE `train_info` CHANGE COLUMN `Train_ID` `Train_ID` INT(10) UNSIGNED NOT NULL ;");
                dtare = SqlceClass.getdata(CommandType.Text, "select * from Trains", "Data Source=" + connvalu);
                foreach (DataRow drare in dtare.Rows)
                {
                    string trainName = Convert.ToString(drare["train_name"]);
                    string areid = Convert.ToString(drare["area_id"]);
                    int PreviousID = 0;
                    int NextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into train_info(Train_ID,Name,Description,PreviousID,NextID,Area_ID,Date) values('" + Convert.ToString(drare["train_id"]) + "','" + trainName + "','Train','" + PreviousID + "','" + NextId + "','" + areid + "','" + PublicClass.GetDatetime() + "')");
                    DataTable dtTrainfinal = DbClass.getdata(CommandType.Text, "Select max(Train_ID) from train_info ");
                    PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtTrainfinal.Rows[0][0]), "0"))) - 1;
                    NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtTrainfinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update train_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Train_ID = '" + Convert.ToString(dtTrainfinal.Rows[0][0]) + "'");
                }
                DbClass.executequery(CommandType.Text, "ALTER TABLE `train_info` CHANGE COLUMN `Train_ID` `Train_ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ;");
            }
            catch { }
            return DBName;
        }

        public string Converthierarchymac(string DBName)
        {
            try
            {
                DataTable dtare = new DataTable();
                DbClass.executequery(CommandType.Text, "ALTER TABLE `machine_info` CHANGE COLUMN `Machine_ID` `Machine_ID` INT(10) UNSIGNED NOT NULL ;");
                dtare = SqlceClass.getdata(CommandType.Text, "select * from Machines", "Data Source=" + connvalu);
                foreach (DataRow drare in dtare.Rows)
                {
                    string MachineName = Convert.ToString(drare["Machine_name"]);
                    string traid = Convert.ToString(drare["train_id"]);
                    string machine_rpm = Convert.ToString(drare["machine_rpm"]);
                    string machine_pulserev = Convert.ToString(drare["machine_pulsesrev"]);
                    int PreviousID = 0;
                    int NextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into machine_info(Machine_ID,Name,Description,PreviousID,NextID,TrainID,DateCreated,RPM_Driven,PulseRev) values('" + Convert.ToString(drare["machine_id"]) + "','" + MachineName + "','Machine','" + PreviousID + "','" + NextId + "','" + traid + "','" + PublicClass.GetDatetime() + "','" + machine_rpm + "','" + machine_pulserev + "')");
                    DataTable dtmacfinal = DbClass.getdata(CommandType.Text, "Select max(Machine_ID) from machine_info ");
                    PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtmacfinal.Rows[0][0]), "0"))) - 1;
                    NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtmacfinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update machine_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Machine_ID = '" + Convert.ToString(dtmacfinal.Rows[0][0]) + "'");

                }
                DbClass.executequery(CommandType.Text, "ALTER TABLE `machine_info` CHANGE COLUMN `Machine_ID` `Machine_ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ;");
            }
            catch { }
            return DBName;
        }


        public string Converthierarchypoint(string DBName)
        {
            try
            {
                DataTable dtare = new DataTable();
                dtare = SqlceClass.getdata(CommandType.Text, "select * from Points", "Data Source=" + connvalu);
                foreach (DataRow drare in dtare.Rows)
                {
                    string Position = Convert.ToString(drare["Point_id"]);
                    string pointNm = Convert.ToString(drare["Point_Name"]);
                    string prID = Convert.ToString(drare["Machine_id"]);
                    int PreviousID = 0;
                    int NextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into point(Point_ID,PointName,PointDesc,DataCreated,PreviousID,NextID,Machine_ID,DataSchedule,PointStatus,PointSchedule) values('" + Position + "','" + pointNm + "','Point','" + PublicClass.GetDatetime() + "','" + PreviousID + "','" + NextId + "','" + prID + "','7','0','1')");
                    DataTable dtpointfinal = DbClass.getdata(CommandType.Text, "Select max(Point_ID) from point ");
                    PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtpointfinal.Rows[0][0]), "0"))) - 1;
                    NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtpointfinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update point set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Point_ID = '" + Convert.ToString(dtpointfinal.Rows[0][0]) + "'");
                }
            }
            catch
            { }
            return DBName;
        }


        int prevous_id, nextid;
        int point_new_record_id;

        public int Insert_unschedule_point(string pointName, string machineid, string createddate, string point_id)
        {
            try
            {
                DataTable dt1 = new DataTable();
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select distinct point_id from point_data where point_id='" + point_id + "'");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        point_new_record_id = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr1["point_id"]), "0"));
                    }
                }
                else
                {
                    //dt1 = DbClass.getdata(CommandType.Text, "select max(point_id)point_id,max(previousid)previousid,max(nextid)nextid from point");
                    //foreach (DataRow dr in dt1.Rows)
                    //{
                    //    point_new_record_id = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["point_id"]), "0")) + 1;
                    //    prevous_id = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["previousid"]), "0")) + 1;
                    //    nextid = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["nextid"]), "0")) + 1;

                    //}
                    //DbClass.executequery(CommandType.Text, " insert into point(point_id,PointName,PointDesc,Machine_ID,DataCreated,previousid,nextid,DataSchedule,PointStatus,PointSchedule) values('" + point_new_record_id + "','" + pointName + "','" + pointName + "','" + machineid + "','" + Convert.ToDateTime(createddate).ToString(("yyyy/MM/dd HH:mm:ss")) + "','" + Convert.ToString(prevous_id) + "','" + Convert.ToString(nextid) + "','7 Days','0','1'  ) ");
                    point_new_record_id = Convert.ToInt32(point_id);
                    ConvertPointTypeunschedule();
                    Inser_Measuresforunschedule(untypeid);
                    insert_unitsforunschedule(untypeid);
                    CalcGeneralPageVariables2(powermeasurement, untypeid);
                    DbClass.executequery(CommandType.Text, "update point set PointType_Id='" + untypeid + "' where Point_ID='" + point_new_record_id + "'");

                }

            }
            catch { }
            return point_new_record_id;
        }


        public void ConvertPointTypeunschedule()
        {
            try
            {
                string sinstname = PublicClass.currentInstrument;
                DataTable dtpoint = DbClass.getdata(CommandType.Text, "select max(ID)typepoint_id from Type_point");
                foreach (DataRow drsen in dtpoint.Rows)
                {
                    untypeid = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(drsen["typepoint_id"]), "0")) + 1;

                    string AlarmID = "0";
                    string sdID = "0";
                    string perID = "0";
                    string PointTypeName = Convert.ToString("UnschedulePointType-" + untypeid);
                    DbClass.executequery(CommandType.Text, "Insert into type_point(Point_Name,Type_ID,Instrumentname,Alarm_ID,STDDeviationAlarm_ID,Percentage_AlarmID,Band_ID) values('" + PointTypeName + "','1','" + sinstname + "','" + AlarmID + "','" + sdID + "','" + perID + "','0')");
                    DataTable dt1 = DbClass.getdata(CommandType.Text, "select distinct ID from type_point where Point_name='" + PointTypeName + "'");
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        untypeid = (Convert.ToInt32(dr1["ID"]));
                    }
                    DataTable dt = SqlceClass.getdata(CommandType.Text, "select distinct pp.*,bd.bandalarm_group_id[Band] from points pp left join bandalarms bd on bd.point_id=pp.point_id where pp.Point_id='" + point_id + "'", "Data Source=" + connvalu);
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        string v_alarm = Convert.ToString(dr1["alarm_id"]);
                        int v_band = Convert.ToInt32(PublicClass.DefVal((dr1["Band"]), "0"));
                        string v_measure = Convert.ToString(dr1["measure_id"]);
                        string v_unit = Convert.ToString(dr1["unit_id"]);
                        DbClass.executequery(CommandType.Text, "update type_point set unit_id='" + v_unit + "',measure_id='" + v_measure + "',alarm_id='" + v_alarm + "',band_id='" + v_band + "' where ID='" + untypeid + "' ");

                    }
                }
            }
            catch { }

        }


        private void insert_unitsforunschedule(int type)
        {
            // _objMain.lblStatus.Caption = "Status: Filling Units for Unschedule Point Data";
            try
            {
               // DbClass.executequery(CommandType.Text, "ALTER TABLE `units` CHANGE COLUMN `Unit_ID` `Unit_ID` INT(10) UNSIGNED NOT NULL ");
                DataTable dtun = SqlceClass.getdata(CommandType.Text, "select * from units mea inner join Points pt on pt.unit_id=mea.unit_id where pt.point_id='" + point_new_record_id + "'", "Data Source=" + connvalu);

               // DataTable dtun = SqlceClass.getdata(CommandType.Text, "Select * from units where unit_id='" + type + "'", "Data Source=" + connvalu);
                foreach (DataRow drun in dtun.Rows)
                {
                    //string iPointID = Convert.ToString(drun["Unit_ID"]);
                    string btAccel_Unit = Convert.ToString(drun["accel_unit"]);
                    string btVel_Unit = Convert.ToString(drun["vel_unit"]);
                    string btDispl_Unit = Convert.ToString(drun["displ_unit"]);
                    string btTemperature_Unit = Convert.ToString(drun["temperature_unit"]);
                    string sProcess_Unit = Convert.ToString(drun["process_unit"]);

                    string btAccel_Detection = Convert.ToString(drun["accel_detection"]);
                    string btVel_Detection = Convert.ToString(drun["vel_detection"]);
                    string btDispl_Detection = Convert.ToString(drun["displ_detection"]);
                    string btTime_Unit_Type = Convert.ToString(drun["time_unit_type"]);
                    string btPower_unit_type = Convert.ToString(drun["power_unit_type"]);
                    string btDemodulate_Unit_Type = Convert.ToString(drun["demodulate_unit_type"]);
                    string btPressureUnit = Convert.ToString(drun["pressure_unit"]);
                    string btCurrentUnit = Convert.ToString(drun["current_unit"]);
                    string btPressure_detection = Convert.ToString(drun["pressure_detection"]);
                    string btCurrent_detection = Convert.ToString(drun["current_detection"]);
                    string btordertrace_unit_type = Convert.ToString(drun["ordertrace_unit_type"]);
                    string btcepstrum_unit_type = Convert.ToString(drun["cepstrum_unit_type"]);
                    byte btInput_Range = Convert.ToByte(drun["Input_Range"]);
                  //  DbClass.executequery(CommandType.Text, " insert into units(unit_id,accel_unit,accel_detection,vel_unit,vel_detection,displ_unit,displ_detection,temperature_unit,process_unit,pressure_unit,pressure_detection,current_unit,current_detection,time_unit_type,power_unit_type,demodulate_unit_type,ordertrace_unit_type,cepstrum_unit_type,Date,Type_ID) values('" + type + "','" + btAccel_Unit + "','" + btAccel_Detection + "','" + btVel_Unit + "','" + btVel_Detection + "','" + btDispl_Unit + "','" + btDispl_Detection + "','" + btTemperature_Unit + "','" + sProcess_Unit + "','" + btPressureUnit + "','" + btPressure_detection + "','" + btCurrentUnit + "','" + btCurrent_detection + "','" + btTime_Unit_Type + "','" + btPower_unit_type + "','" + btDemodulate_Unit_Type + "','" + btordertrace_unit_type + "','" + btcepstrum_unit_type + "','" + PublicClass.GetDatetime() + "','" + type + "')");
                      DbClass.executequery(CommandType.Text, " insert into units(accel_unit,accel_detection,vel_unit,vel_detection,displ_unit,displ_detection,temperature_unit,process_unit,pressure_unit,pressure_detection,current_unit,current_detection,time_unit_type,power_unit_type,demodulate_unit_type,ordertrace_unit_type,cepstrum_unit_type,Date,Type_ID) values('" + btAccel_Unit + "','" + btAccel_Detection + "','" + btVel_Unit + "','" + btVel_Detection + "','" + btDispl_Unit + "','" + btDispl_Detection + "','" + btTemperature_Unit + "','" + sProcess_Unit + "','" + btPressureUnit + "','" + btPressure_detection + "','" + btCurrentUnit + "','" + btCurrent_detection + "','" + btTime_Unit_Type + "','" + btPower_unit_type + "','" + btDemodulate_Unit_Type + "','" + btordertrace_unit_type + "','" + btcepstrum_unit_type + "','" + PublicClass.GetDatetime() + "','" + type + "')");
                }
              //  DbClass.executequery(CommandType.Text, "ALTER TABLE `units` CHANGE COLUMN `Unit_ID` `Unit_ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ;");

            }
            catch { }
        }


        int powermeasurement;
        public void Inser_Measuresforunschedule(int type)
        {
            // _objMain.lblStatus.Caption = "Status: Filling Measures for Unschedule Point Data";
            try
            {
                DataTable dtmeasure = SqlceClass.getdata(CommandType.Text, "select * from measures mea inner join Points pt on pt.measure_id=mea.measure_id where pt.point_id='" + point_new_record_id + "'", "Data Source=" + connvalu);
                foreach (DataRow drm in dtmeasure.Rows)
                {
                    powermeasurement = Convert.ToInt32(drm["point_measurement"]);
                    //int PointID = Convert.ToInt32(drm["PointPosition"]);
                    string SensorDir = Convert.ToString(drm["point_dir"]);
                    string sensor_id = Convert.ToString(drm["vibration_sensor"]);
                    string temperature_id = Convert.ToString(drm["temperature_sensor"]);
                    string acc_filter = Convert.ToString(drm["acc_filter"]);
                    string vel_filter = Convert.ToString(drm["vel_filter"]);
                    string displ_filter = Convert.ToString(drm["displ_filter"]);
                    string cfFilter = Convert.ToString(drm["crest_factor_filter"]);
                    string overallbearhp_filter = Convert.ToString(drm["overall_bearing_filter"]);
                    string bearhp_filter = Convert.ToString(drm["bearing_acc_hp_filter"]);

                    string otveragetimes = Convert.ToString(drm["ordertrace_average_times"]);
                    string otresolution = Convert.ToString(drm["ordertrace_resolution"]);
                    string otorder = Convert.ToString(drm["ordertrace_order"]);
                    string ottriggerslope = Convert.ToString(drm["ordertrace_trigger_slope"]);

                    string timeband = Convert.ToString(drm["time_band"]);
                    string timeResol = Convert.ToString(drm["time_resolution"]);
                    string timeoverlap = Convert.ToString(drm["time_overlap"]);

                    string pwrmultiple = Convert.ToString(drm["power_multiple"]);
                    string pbgroup1 = Convert.ToString(drm["power_band"]);
                    string pwrResG1 = Convert.ToString(drm["power_resolution"]);
                    string pwrB1G1 = Convert.ToString(drm["power_band1"]);
                    string pwrRes1G1 = Convert.ToString(drm["power_resolution1"]);
                    string pwrB2G1 = Convert.ToString(drm["power2_band"]);
                    string pwrRes2G2 = Convert.ToString(drm["power2_resolution"]);
                    string pwr2B1G2 = Convert.ToString(drm["power2_band1"]);
                    string pwr2Res1G1 = Convert.ToString(drm["power2_resolution1"]);
                    string pwr3BG3 = Convert.ToString(drm["power3_band"]);
                    string pwr3Res3G3 = Convert.ToString(drm["power3_resolution"]);
                    string pwr3B1G3 = Convert.ToString(drm["power3_band1"]);
                    string pwr3Res1G3 = Convert.ToString(drm["power3_resolution1"]);
                    string pwrWindow = Convert.ToString(drm["power_window"]);
                    string pwrAvgTime = Convert.ToString(drm["power_average_times"]);
                    string pwrOverlap = Convert.ToString(drm["power_overlap"]);
                    int pwrZoom = Convert.ToInt32(drm["power_zoom"]);
                    string pwrZoomSTF = Convert.ToString(drm["power_zoom_startfreq"]);
                    string cepBand = Convert.ToString(drm["cepstrum_band"]);
                    string cepResol = Convert.ToString(drm["cepstrum_resolution"]);
                    string cepWindow = Convert.ToString(drm["cepstrum_window"]);
                    string cepAvgTime = Convert.ToString(drm["cepstrum_average_times"]);
                    string cepOverlap = Convert.ToString(drm["cepstrum_overlap"]);
                    int cepZoom = Convert.ToInt32(drm["cepstrum_zoom"]);
                    string cepZoomSTF = Convert.ToString(drm["cepstrum_zoom_startfreq"]);
                    string demoBand = Convert.ToString(drm["demodulate_band"]);
                    string demoResol = Convert.ToString(drm["demodulate_resolution"]);
                    string demoWindow = Convert.ToString(drm["demodulate_window"]);
                    string demoAvgTime = Convert.ToString(drm["demodulate_average_times"]);
                    string demofilter = Convert.ToString(drm["demodulate_filter"]);

                    DbClass.executequery(CommandType.Text, "Insert Into measure(acc_filter, vel_filter , displ_filter, overall_bearing_filter, crest_factor_filter,bearing_acc_hp_filter, time_band, time_resoltion, time_overlap,Date,Sensordir, sensor_id , TemperatureID, power_band  ,power_resolution   ,power_band1 ,power_resolution1  ,power2_band   ,power2_resolution, power2_band1,power2_resolution1,power3_band,power3_resolution,power3_band1,power3_resolution1, power_window,power_overlap,power_average_times,power_zoom,power_zoom_startfeq,cepstrum_band, cepstrum_resolution,cepstrum_window,cepstrum_average_times,cepstrum_overlap,cepstrum_zoom,cepstrum_zoom_startfeq,demodulate_band,demodulate_resolution,demodulate_window,demodulate_average_times ,demodulate_filter,ordertrace_average_times,ordertrace_resolution,ordertrace_order,ordertrace_trigger_slope,power_multiple,Type_ID)values(  '" + acc_filter + "' ,'" + vel_filter + "' ,'" + displ_filter + "' ,'" + overallbearhp_filter + "' ,'" + cfFilter + "' ,'" + bearhp_filter + "' ,'" + timeband + "' ,'" + timeResol + "' ,'" + timeoverlap + "' ,'" + PublicClass.GetDatetime() + "' ,'" + SensorDir + "' ,'" + sensor_id + "' ,'" + temperature_id + "' ,'" + pbgroup1 + "' ,'" + pwrResG1 + "' ,'" + pwrB1G1 + "' ,'" + pwrRes1G1 + "' ,'" + pwrB2G1 + "' ,'" + pwrRes2G2 + "' ,'" + pwr2B1G2 + "' ,'" + pwr2Res1G1 + "' ,'" + pwr3BG3 + "' ,'" + pwr3Res3G3 + "' ,'" + pwr3B1G3 + "' ,'" + pwr3Res1G3 + "' ,'" + pwrWindow + "' ,'" + pwrOverlap + "' ,'" + pwrAvgTime + "' ,'" + pwrZoom + "' ,'" + pwrZoomSTF + "' ,'" + cepBand + "' ,'" + cepResol + "' ,'" + cepWindow + "' ,'" + cepAvgTime + "' ,'" + cepOverlap + "' ,'" + cepZoom + "' ,'" + cepZoomSTF + "' ,'" + demoBand + "' ,'" + demoResol + "' ,'" + demoWindow + "' ,'" + demoAvgTime + "' ,'" + demofilter + "' ,'" + otveragetimes + "' ,'" + otresolution + "' ,'" + otorder + "' ,'" + ottriggerslope + "' ,'" + pwrmultiple + "' ,'" + type + "')");

                }

            }
            catch { }
        }



        private void CalcGeneralPageVariables2(int Target, int type)
        {
            int Target2 = 0;
            try
            {
                bool OvAcc = false;
                bool OvVel = false;
                bool OvDisp = false;
                bool TWave = false;
                bool PSpec = false;
                bool DSpec = false;
                bool temp = false;
                bool process = false;
                bool bearing = false;
                bool ODT = false;
                bool Cepstr = false;
                bool crestfactorCheck = false;
                bool OvBear = false;

                Target2 = Target;

                if (Target2 >= 2048)
                {
                    Target2 = Target2 - 2048;
                    Cepstr = true;

                }
                if (Target2 >= 1024)
                {
                    Target2 = Target2 - 1024;
                    ODT = true;

                }
                if (Target2 >= 512)
                {
                    Target2 = Target2 - 512;
                    crestfactorCheck = true;

                }
                if (Target2 >= 256)
                {
                    Target2 = Target2 - 256;
                    process = true;

                }
                if (Target2 >= 128)
                {
                    Target2 = Target2 - 128;
                    temp = true;

                }
                if (Target2 >= 64)
                {
                    Target2 = Target2 - 64;
                    DSpec = true;

                }
                if (Target2 >= 32)
                {
                    Target2 = Target2 - 32;
                    PSpec = true;

                }
                if (Target2 >= 16)
                {
                    Target2 = Target2 - 16;
                    TWave = true;

                }
                if (Target2 >= 8)
                {
                    Target2 = Target2 - 8;
                    OvBear = true;

                }
                if (Target2 >= 4)
                {
                    Target2 = Target2 - 4;
                    OvDisp = true;

                }
                if (Target2 >= 2)
                {
                    Target2 = Target2 - 2;
                    OvVel = true;

                }
                if (Target2 >= 1)
                {
                    Target2 = Target2 - 1;
                    OvAcc = true;
                }


                try
                {
                    if (Target > 0)
                    {
                        DbClass.executequery(CommandType.Text, "insert into  measure_type  (  OAcc, OVel, ODisp, OBear, OTWF, OPS, ODS, Temp, Process, crestfactor, Ordertrace, Cepstrum , Type_ID ,CalcMeasure  ) values('" + setvalue(OvAcc) + "','" + setvalue(OvVel) + "','" + setvalue(OvDisp) + "','" + setvalue(OvBear) + "','" + setvalue(TWave) + "','" + setvalue(PSpec) + "','" + setvalue(DSpec) + "','" + setvalue(temp) + "','" + setvalue(process) + "','" + setvalue(crestfactorCheck) + "','" + setvalue(ODT) + "','" + setvalue(Cepstr) + "','" + type + "','" + Target + "')");
                    }
                }
                catch { }


            }
            catch (Exception ex)
            {

            }
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



        int PointIDUN; int untypeid;
        public void ConvertPointType(string point_id)
        {
            try
            {
                string instname = PublicClass.currentInstrument;
                DataTable dtpoint = DbClass.getdata(CommandType.Text, "select max(ID)typepoint_id from Type_point");
                foreach (DataRow drsen in dtpoint.Rows)
                {
                    untypeid = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(drsen["typepoint_id"]), "0")) + 1;

                    string AlarmID = "0";
                    string sdID = "0";
                    string perID = "0";
                    string PointTypeName = Convert.ToString("DefaultPointType-" + untypeid);
                    DbClass.executequery(CommandType.Text, "Insert into type_point(Point_Name,Type_ID,Instrumentname,Alarm_ID,STDDeviationAlarm_ID,Percentage_AlarmID,Band_ID) values('" + PointTypeName + "','1','" + instname + "','" + AlarmID + "','" + sdID + "','" + perID + "','0')");

                    DataTable dt1 = DbClass.getdata(CommandType.Text, "select distinct ID from type_point where Point_name='" + PointTypeName + "'");
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        untypeid = (Convert.ToInt32(dr1["ID"]));
                    }
                    DataTable dt = SqlceClass.getdata(CommandType.Text, "select distinct pp.*,bd.bandalarm_group_id[Band] from points pp left join bandalarms bd on bd.point_id=pp.point_id where pp.Point_id='" + point_id + "'", "Data Source=" + connvalu);
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        string v_alarm = Convert.ToString(dr1["alarm_id"]);
                        int v_band = Convert.ToInt32(PublicClass.DefVal((dr1["Band"]), "0"));
                        string v_measure = Convert.ToString(dr1["measure_id"]);
                        string v_unit = Convert.ToString(dr1["unit_id"]);
                        DbClass.executequery(CommandType.Text, "update type_point set unit_id='" + v_unit + "',measure_id='" + v_measure + "',alarm_id='" + v_alarm + "',band_id='" + v_band + "' where ID='" + untypeid + "' ");

                    }
                }
            }
            catch { }

        }


        public string GetValueForMeasureTime(string iMeasureTime)
        {
            string m_sCurrentPointsDateTime = null;
            try
            {
                DateTime objDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);

                double sTimeTaken = Convert.ToDouble(iMeasureTime);
                objDateTime = objDateTime.AddSeconds(sTimeTaken);
                DateTime objNewDateTime = objDateTime.ToLocalTime();
                m_sCurrentPointsDateTime = objNewDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch { }

            return m_sCurrentPointsDateTime;
        }

        public string Retrive_YxValue(byte[] btTimeA)
        {
            string[] sarrYTData = new string[0];
            StringBuilder sbYValues = new StringBuilder();
            string YTAData = "";
            try
            {
                if (btTimeA != null)
                {
                    int iLength = (btTimeA.GetLength(0) + 7) / 8;
                    double[] dTimeImage_A = new double[iLength];
                    for (int i = 0; i < iLength; i++)
                    {
                        dTimeImage_A[i] = BitConverter.ToDouble(btTimeA, i * 8);
                    }
                    for (int iLoop = 0; iLoop < dTimeImage_A.Length; iLoop++)
                    {
                        sbYValues.Append(dTimeImage_A[iLoop]);
                        sbYValues.Append("|");
                    }
                    string sTimeData = System.Text.Encoding.Default.GetString(btTimeA);
                    YTAData = Convert.ToString(sbYValues);

                    _ResizeArray.IncreaseArrayString(ref sarrYTData, 1);
                    sarrYTData[sarrYTData.Length - 1] = YTAData;
                    YTAData = sarrYTData[sarrYTData.Length - 1];
                }

            }
            catch { }
            return YTAData;

        }


        public string pointID = null;
        public void insertdata()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SqlceClass.getdata(CommandType.Text, " SELECT   R.*,p.point_name,  p.point_dir ,  p.point_record_status,  p.point_status,  p.point_schedule,  p.point_measurement,  p.vibration_sensor,  p.temperature_sensor,  p.unit_id,  p.measure_id,  p.alarm_id,  p.machine_id,  p.record_id    FROM POINTS P  LEFT JOIN point_record R ON P.point_id=R.point_id    ORDER BY R.point_id  ASC", "Data Source=" + connvalu);
                foreach (DataRow dr in dt.Rows)
                {
                    string v_pr_id = Convert.ToString(dr["pr_id"]);
                    string v_measure_time = GetValueForMeasureTime(Convert.ToString(dr["measure_time"]));
                    string v_accel_ch1 = Convert.ToString(dr["accel_ch1"]);
                    string v_accel_a = Convert.ToString(dr["accel_a"]);
                    string v_accel_h = Convert.ToString(dr["accel_h"]);
                    string v_accel_v = Convert.ToString(dr["accel_v"]);
                    string v_vel_ch1 = Convert.ToString(dr["vel_ch1"]);
                    string v_vel_a = Convert.ToString(dr["vel_a"]);
                    string v_vel_h = Convert.ToString(dr["vel_h"]);
                    string v_vel_v = Convert.ToString(dr["vel_v"]);
                    string v_displ_ch1 = Convert.ToString(dr["displ_ch1"]);
                    string v_displ_a = Convert.ToString(dr["displ_a"]);
                    string v_displ_h = Convert.ToString(dr["displ_h"]);
                    string v_displ_v = Convert.ToString(dr["displ_v"]);
                    string v_crest_factor_ch1 = Convert.ToString(dr["crest_factor_ch1"]);
                    string v_crest_factor_a = Convert.ToString(dr["crest_factor_a"]);
                    string v_crest_factor_h = Convert.ToString(dr["crest_factor_h"]);
                    string v_crest_factor_v = Convert.ToString(dr["crest_factor_v"]);
                    string v_bearing_ch1 = Convert.ToString(dr["bearing_ch1"]);
                    string v_bearing_a = Convert.ToString(dr["bearing_a"]);
                    string v_bearing_h = Convert.ToString(dr["bearing_h"]);
                    string v_bearing_v = Convert.ToString(dr["bearing_v"]);
                    string v_ordertrace_ch1_real = Convert.ToString(dr["ordertrace_ch1_real"]);
                    string v_ordertrace_ch1_image = Convert.ToString(dr["ordertrace_ch1_image"]);
                    string v_ordertrace_a_real = Convert.ToString(dr["ordertrace_a_real"]);
                    string v_ordertrace_a_image = Convert.ToString(dr["ordertrace_a_image"]);
                    string v_ordertrace_h_real = Convert.ToString(dr["ordertrace_h_real"]);
                    string v_ordertrace_h_image = Convert.ToString(dr["ordertrace_h_image"]);
                    string v_ordertrace_v_real = Convert.ToString(dr["ordertrace_v_real"]);
                    string v_ordertrace_v_image = Convert.ToString(dr["ordertrace_v_image"]);
                    string v_ordertrace_rpm = Convert.ToString(dr["ordertrace_rpm"]);
                    string v_point_id = Convert.ToString(dr["point_id"]);
                    string v_measure_id = Convert.ToString(dr["measure_id"]);
                    string v_alarm_id = Convert.ToString(dr["alarm_id"]);
                    string v_unit_id = Convert.ToString(dr["unit_id"]);
                    //-----variable-----//

                    string Time = "Time_Band,Time_resolution";
                    string v_time_ch1_X = null; string v_time_CH1_Y = null;
                    string v_time_a_X = null; string v_time_a_Y = null;
                    string v_time_h_X = null; string v_time_h_Y = null;
                    string v_time_v_X = null; string v_time_v_Y = null;

                    string Power = "power_band,power_resolution";
                    string v_power_ch_X = null; string v_power_ch_Y = null;
                    string v_power_a_X = null; string v_power_a_Y = null;
                    string v_power_h_X = null; string v_power_h_Y = null;
                    string v_power_v_X = null; string v_power_v_Y = null;

                    string Power1 = "power_band1,power_resolution1";
                    string v_power_ch1_X = null; string v_power_ch1_Y = null;
                    string v_power_a1_X = null; string v_power_a1_Y = null;
                    string v_power_h1_X = null; string v_power_h1_Y = null;
                    string v_power_v1_X = null; string v_power_v1_Y = null;

                    string Power2 = "power2_band,power2_resolution";
                    string v_power2_ch1_X = null; string v_power2_ch1_Y = null;
                    string v_power2_a_X = null; string v_power2_a_Y = null;
                    string v_power2_h_X = null; string v_power2_h_Y = null;
                    string v_power2_v_X = null; string v_power2_v_Y = null;

                    string Power2_1 = "power2_band1,power2_resolution1";
                    string v_power2_ch11_X = null; string v_power2_ch11_Y = null;
                    string v_power2_a1_X = null; string v_power2_a1_Y = null;
                    string v_power2_h1_X = null; string v_power2_h1_Y = null;
                    string v_power2_v1_X = null; string v_power2_v1_Y = null;


                    string Power3 = "power3_band,power3_resolution";
                    string v_power3_ch1_X = null; string v_power3_ch1_Y = null;
                    string v_power3_a_X = null; string v_power3_a_Y = null;
                    string v_power3_h_X = null; string v_power3_h_Y = null;
                    string v_power3_v_X = null; string v_power3_v_Y = null;

                    string Power3_1 = "power3_band1,power3_resolution1";
                    string v_power3_ch11_X = null; string v_power3_ch11_Y = null;
                    string v_power3_a1_X = null; string v_power3_a1_Y = null;
                    string v_power3_h1_X = null; string v_power3_h1_Y = null;
                    string v_power3_v1_X = null; string v_power3_v1_Y = null;


                    string cepstrum = "cepstrum_band,cepstrum_resolution";
                    string v_cepstrum_ch1_X = null; string v_cepstrum_ch1_Y = null;
                    string v_cepstrum_a_X = null; string v_cepstrum_a_Y = null;
                    string v_cepstrum_h_X = null; string v_cepstrum_h_Y = null;
                    string v_cepstrum_v_X = null; string v_cepstrum_v_Y = null;


                    string demodulate = "demodulate_band,demodulate_resolution";
                    string v_demodulate_ch1_X = null; string v_demodulate_ch1_Y = null;
                    string v_demodulate_a_X = null; string v_demodulate_a_Y = null;
                    string v_demodulate_h_X = null; string v_demodulate_h_Y = null;
                    string v_demodulate_v_X = null; string v_demodulate_v_Y = null;


                    //-----------------------take data from database -------------------------------------//

                    DataTable dt1 = DbClass.getdata(CommandType.Text, "Select timeA_X,timeA_Y,timeCH1_X,timeCH1_Y,timeV_X,timeV_Y,timeH_X,timeH_Y ,PA_X,PA_Y,PV_X,PV_Y,PH_X,PH_Y,PCH1_X,PCH1_Y,P1A_X,P1A_Y,P1V_X,P1V_Y,P1H_X,P1H_Y,P1CH1_X,P1CH1_Y,P21A_X,P21A_Y,P21V_X,P21V_Y ,P21H_X,P21H_Y,P21CH1_X,P21CH1_Y, P2A_X,P2A_Y,P2H_X,P2H_Y,P2V_X,P2V_Y,P2CH1_X,P2CH1_Y ,P3A_X,P3A_Y,P3V_X,P3V_Y,P3H_X,P3H_Y,P3CH1_X,P3CH1_Y , P3A_X,P3A_Y,P3V_X,P3V_Y,P3H_X,P3H_Y,P3CH1_X,P3CH1_Y , CEPA_X,CEPA_Y,CEPH_X,CEPH_Y,CEPV_X,CEPV_Y,CEPCH1_X,CEPCH1_Y , DEMA_X,DEMA_Y,DEMH_X,DEMH_Y,DEMV_X,DEMV_Y,DEMCH1_X,DEMCH1_Y from point_data where Point_ID ='" + v_point_id + "' and Measure_time ='" + v_measure_time + "'");
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt1.Rows)
                        {

                            if (Convert.ToString(dr1["timeCH1_X"]) != "")
                            {
                                v_time_ch1_X = Convert.ToString(dr1["timeCH1_X"]);
                                v_time_CH1_Y = Convert.ToString(dr1["timeCH1_Y"]);
                            }



                            if (Convert.ToString(dr1["timeA_X"]) != "")
                            {
                                v_time_a_X = Convert.ToString(dr1["timeA_X"]);
                                v_time_a_Y = Convert.ToString(dr1["timeA_X"]);

                            }


                            if (Convert.ToString(dr1["timeH_X"]) != "")
                            {
                                v_time_h_X = Convert.ToString(dr1["timeH_X"]);
                                v_time_h_Y = Convert.ToString(dr1["timeH_X"]);

                            }


                            if (Convert.ToString(dr1["timeV_X"]) != "")
                            {
                                v_time_h_X = Convert.ToString(dr1["timeV_X"]);
                                v_time_h_Y = Convert.ToString(dr1["timeV_X"]);

                            }

                            //-----------------------For Power Band-------------------------------------//




                            if (Convert.ToString(dr1["PCH1_X"]) != "")
                            {
                                v_power_ch_X = Convert.ToString(dr1["PCH1_X"]);
                                v_power_ch_X = Convert.ToString(dr1["PCH1_Y"]);

                            }

                            if (Convert.ToString(dr1["PA_X"]) != "")
                            {
                                v_power_a_X = Convert.ToString(dr1["PA_X"]);
                                v_power_a_Y = Convert.ToString(dr1["PA_Y"]);

                            }

                            if (Convert.ToString(dr1["PH_X"]) != "")
                            {
                                v_power_h_X = Convert.ToString(dr1["PH_X"]);
                                v_power_h_Y = Convert.ToString(dr1["PH_Y"]);

                            }



                            if (Convert.ToString(dr1["PV_X"]) != "")
                            {
                                v_power_v_X = Convert.ToString(dr1["PV_X"]);
                                v_power_v_Y = Convert.ToString(dr1["PV_Y"]);

                            }

                            //-----------------------For Power1 Band-------------------------------------//



                            if (Convert.ToString(dr1["P1CH1_X"]) != "")
                            {
                                v_power_ch1_X = Convert.ToString(dr1["P1CH1_X"]);
                                v_power_ch1_Y = Convert.ToString(dr1["P1CH1_Y"]);

                            }


                            if (Convert.ToString(dr1["P1A_X"]) != "")
                            {
                                v_power_a1_X = Convert.ToString(dr1["P1A_X"]);
                                v_power_a1_Y = Convert.ToString(dr1["P1A_Y"]);

                            }

                            if (Convert.ToString(dr1["P1H_X"]) != "")
                            {
                                v_power_h1_X = Convert.ToString(dr1["P1H_X"]);
                                v_power_h1_Y = Convert.ToString(dr1["P1H_Y"]);

                            }

                            if (Convert.ToString(dr1["P1V_X"]) != "")
                            {
                                v_power_v1_X = Convert.ToString(dr1["P1V_X"]);
                                v_power_v1_Y = Convert.ToString(dr1["P1V_Y"]);

                            }

                            //-----------------------For Power2 Band-------------------------------------//


                            if (Convert.ToString(dr1["P2CH1_X"]) != "")
                            {
                                v_power2_ch1_X = Convert.ToString(dr1["P2CH1_X"]);
                                v_power2_ch1_Y = Convert.ToString(dr1["P2CH1_Y"]);

                            }



                            if (Convert.ToString(dr1["P2A_X"]) != "")
                            {
                                v_power2_a_X = Convert.ToString(dr1["P2A_X"]);
                                v_power2_a_Y = Convert.ToString(dr1["P2A_Y"]);

                            }


                            if (Convert.ToString(dr1["P2H_X"]) != "")
                            {
                                v_power2_h_X = Convert.ToString(dr1["P2H_X"]);
                                v_power2_h_Y = Convert.ToString(dr1["P2H_Y"]);

                            }


                            if (Convert.ToString(dr1["P2V_X"]) != "")
                            {
                                v_power2_v_X = Convert.ToString(dr1["P2V_X"]);
                                v_power2_v_Y = Convert.ToString(dr1["P2V_Y"]);

                            }

                            //-----------------------For Power2-1 Band-------------------------------------//



                            if (Convert.ToString(dr1["P21CH1_X"]) != "")
                            {
                                v_power2_ch11_X = Convert.ToString(dr1["P21CH1_X"]);
                                v_power2_ch11_Y = Convert.ToString(dr1["P21CH1_Y"]);

                            }


                            if (Convert.ToString(dr1["P21A_X"]) != "")
                            {
                                v_power2_a1_X = Convert.ToString(dr1["P21A_X"]);
                                v_power2_a1_Y = Convert.ToString(dr1["P21A_Y"]);

                            }


                            if (Convert.ToString(dr1["P21H_X"]) != "")
                            {
                                v_power2_h1_X = Convert.ToString(dr1["P21H_X"]);
                                v_power2_h1_Y = Convert.ToString(dr1["P21H_Y"]);

                            }


                            if (Convert.ToString(dr1["P21V_X"]) != "")
                            {
                                v_power2_v1_X = Convert.ToString(dr1["P21V_X"]);
                                v_power2_v1_Y = Convert.ToString(dr1["P21V_Y"]);

                            }

                            //-----------------------For Power3 Band-------------------------------------//

                            if (Convert.ToString(dr1["P3CH1_X"]) != "")
                            {
                                v_power3_ch1_X = Convert.ToString(dr1["P3CH1_X"]);
                                v_power3_ch1_Y = Convert.ToString(dr1["P3CH1_Y"]);

                            }


                            if (Convert.ToString(dr1["P3A_X"]) != "")
                            {
                                v_power3_a_X = Convert.ToString(dr1["P3A_X"]);
                                v_power3_a_Y = Convert.ToString(dr1["P3A_Y"]);

                            }


                            if (Convert.ToString(dr1["P3H_X"]) != "")
                            {
                                v_power3_h_X = Convert.ToString(dr1["P3H_X"]);
                                v_power3_h_Y = Convert.ToString(dr1["P3H_Y"]);

                            }


                            if (Convert.ToString(dr1["P3V_X"]) != "")
                            {
                                v_power3_v_X = Convert.ToString(dr1["P3V_X"]);
                                v_power3_v_Y = Convert.ToString(dr1["P3V_Y"]);

                            }

                            //-----------------------For Power3-1 Band-------------------------------------//



                            if (Convert.ToString(dr1["P3CH1_X"]) != "")
                            {
                                v_power3_ch11_X = Convert.ToString(dr1["P3CH1_X"]);
                                v_power3_ch11_Y = Convert.ToString(dr1["P3CH1_Y"]);

                            }



                            if (Convert.ToString(dr1["P3CH1_X"]) != "")
                            {
                                v_power3_a1_X = Convert.ToString(dr1["P3A_X"]);
                                v_power3_a1_Y = Convert.ToString(dr1["P3A_Y"]);

                            }


                            if (Convert.ToString(dr1["P3H_X"]) != "")
                            {
                                v_power3_h1_X = Convert.ToString(dr1["P3H_X"]);
                                v_power3_h1_Y = Convert.ToString(dr1["P3H_Y"]);

                            }


                            if (Convert.ToString(dr1["P3V_X"]) != "")
                            {
                                v_power3_v1_X = Convert.ToString(dr1["P3V_X"]);
                                v_power3_v1_Y = Convert.ToString(dr1["P3V_Y"]);

                            }

                            //-----------------------For Cepstrum Band-------------------------------------//

                            if (Convert.ToString(dr1["CEPCH1_X"]) != "")
                            {
                                v_cepstrum_ch1_X = Convert.ToString(dr1["CEPCH1_X"]);
                                v_cepstrum_ch1_Y = Convert.ToString(dr1["CEPCH1_Y"]);

                            }


                            if (Convert.ToString(dr1["CEPA_X"]) != "")
                            {
                                v_cepstrum_a_X = Convert.ToString(dr1["CEPA_X"]);
                                v_cepstrum_a_Y = Convert.ToString(dr1["CEPA_Y"]);

                            }


                            if (Convert.ToString(dr1["CEPH_X"]) != "")
                            {
                                v_cepstrum_h_X = Convert.ToString(dr1["CEPH_X"]);
                                v_cepstrum_h_Y = Convert.ToString(dr1["CEPH_Y"]);

                            }


                            if (Convert.ToString(dr1["CEPV_X"]) != "")
                            {
                                v_cepstrum_v_X = Convert.ToString(dr1["CEPV_X"]);
                                v_cepstrum_v_Y = Convert.ToString(dr1["CEPV_Y"]);

                            }


                            //-----------------------For Demodulate Band-------------------------------------//

                            if (Convert.ToString(dr1["DEMCH1_X"]) != "")
                            {
                                v_demodulate_ch1_X = Convert.ToString(dr1["DEMCH1_X"]);
                                v_demodulate_ch1_Y = Convert.ToString(dr1["DEMCH1_Y"]);

                            }

                            if (Convert.ToString(dr1["DEMA_X"]) != "")
                            {
                                v_demodulate_a_X = Convert.ToString(dr1["DEMA_X"]);
                                v_demodulate_a_Y = Convert.ToString(dr1["DEMA_Y"]);

                            }


                            if (Convert.ToString(dr1["DEMH_X"]) != "")
                            {
                                v_demodulate_h_X = Convert.ToString(dr1["DEMH_X"]);
                                v_demodulate_h_Y = Convert.ToString(dr1["DEMH_Y"]);

                            }


                            if (Convert.ToString(dr1["DEMV_X"]) != "")
                            {
                                v_demodulate_v_X = Convert.ToString(dr1["DEMV_X"]);
                                v_demodulate_v_Y = Convert.ToString(dr1["DEMV_Y"]);

                            }

                        }

                    }
                    else
                    {
                        if (Convert.ToString(dr["time_ch1"]) != "")
                        {
                            v_time_ch1_X = get_PowerResolution(v_measure_id, Time, (byte[])(dr["time_ch1"]), "Time");
                            v_time_CH1_Y = Retrive_YxValue((byte[])dr["time_ch1"]);
                        }

                        if (Convert.ToString(dr["time_a"]) != "")
                        {
                            v_time_a_X = get_PowerResolution(v_measure_id, Time, (byte[])dr["time_a"], "Time");
                            v_time_a_Y = Retrive_YxValue((byte[])dr["time_a"]);
                        }

                        if (Convert.ToString(dr["time_h"]) != "")
                        {
                            v_time_h_X = get_PowerResolution(v_measure_id, Time, (byte[])dr["time_h"], "Time");
                            v_time_h_Y = Retrive_YxValue((byte[])dr["time_h"]);
                        }

                        if (Convert.ToString(dr["time_v"]) != "")
                        {
                            v_time_v_X = get_PowerResolution(v_measure_id, Time, (byte[])dr["time_v"], "Time");
                            v_time_v_Y = Retrive_YxValue((byte[])dr["time_v"]);
                        }


                        //-----------------------For Power Band-------------------------------------//



                        if (Convert.ToString(dr["power_ch1"]) != "")
                        {
                            v_power_ch_X = get_PowerResolution(v_measure_id, Power, (byte[])dr["power_ch1"], "Power");
                            v_power_ch_Y = Retrive_YxValuePD((byte[])dr["power_ch1"]);
                        }

                        if (Convert.ToString(dr["power_a"]) != "")
                        {
                            v_power_a_X = get_PowerResolution(v_measure_id, Power, (byte[])dr["power_a"], "Power");
                            v_power_a_Y = Retrive_YxValuePD((byte[])dr["power_a"]);
                        }


                        if (Convert.ToString(dr["power_h"]) != "")
                        {
                            v_power_h_X = get_PowerResolution(v_measure_id, Power, (byte[])dr["power_h"], "Power");
                            v_power_h_Y = Retrive_YxValuePD((byte[])dr["power_h"]);
                        }

                        if (Convert.ToString(dr["power_v"]) != "")
                        {
                            v_power_v_X = get_PowerResolution(v_measure_id, Power, (byte[])dr["power_v"], "Power");
                            v_power_v_Y = Retrive_YxValuePD((byte[])dr["power_v"]);
                        }

                        //-----------------------For Power1 Band-------------------------------------//


                        if (Convert.ToString(dr["power_ch11"]) != "")
                        {
                            v_power_ch1_X = get_PowerResolution(v_measure_id, Power1, (byte[])dr["power_ch11"], "Power");
                            v_power_ch1_Y = Retrive_YxValuePD((byte[])dr["power_ch11"]);
                        }

                        if (Convert.ToString(dr["power_a1"]) != "")
                        {
                            v_power_a1_X = get_PowerResolution(v_measure_id, Power1, (byte[])dr["power_a1"], "Power");
                            v_power_a1_Y = Retrive_YxValuePD((byte[])dr["power_a1"]);
                        }

                        if (Convert.ToString(dr["power_h1"]) != "")
                        {
                            v_power_h1_X = get_PowerResolution(v_measure_id, Power1, (byte[])dr["power_h1"], "Power");
                            v_power_h1_Y = Retrive_YxValuePD((byte[])dr["power_h1"]);
                        }

                        if (Convert.ToString(dr["power_v1"]) != "")
                        {
                            v_power_v1_X = get_PowerResolution(v_measure_id, Power1, (byte[])dr["power_v1"], "Power");
                            v_power_v1_Y = Retrive_YxValuePD((byte[])dr["power_v1"]);
                        }


                        //-----------------------For Power2 Band-------------------------------------//


                        if (Convert.ToString(dr["power2_ch1"]) != "")
                        {
                            v_power2_ch1_X = get_PowerResolution(v_measure_id, Power2, (byte[])dr["power2_ch1"], "Power");
                            v_power2_ch1_Y = Retrive_YxValuePD((byte[])dr["power2_ch1"]);
                        }

                        if (Convert.ToString(dr["power2_a"]) != "")
                        {
                            v_power2_a_X = get_PowerResolution(v_measure_id, Power2, (byte[])dr["power2_a"], "Power");
                            v_power2_a_Y = Retrive_YxValuePD((byte[])dr["power2_a"]);
                        }

                        if (Convert.ToString(dr["power2_h"]) != "")
                        {
                            v_power2_h_X = get_PowerResolution(v_measure_id, Power2, (byte[])dr["power2_h"], "Power");
                            v_power2_h_Y = Retrive_YxValuePD((byte[])dr["power2_h"]);
                        }

                        if (Convert.ToString(dr["power2_v"]) != "")
                        {
                            v_power2_v_X = get_PowerResolution(v_measure_id, Power2, (byte[])dr["power2_v"], "Power");
                            v_power2_v_Y = Retrive_YxValuePD((byte[])dr["power2_v"]);
                        }


                        //-----------------------For Power2-1 Band-------------------------------------//


                        if (Convert.ToString(dr["power2_ch11"]) != "")
                        {
                            v_power2_ch11_X = get_PowerResolution(v_measure_id, Power2_1, (byte[])dr["power2_ch11"], "Power");
                            v_power2_ch11_Y = Retrive_YxValuePD((byte[])dr["power2_ch11"]);
                        }

                        if (Convert.ToString(dr["power2_a1"]) != "")
                        {
                            v_power2_a1_X = get_PowerResolution(v_measure_id, Power2_1, (byte[])dr["power2_a1"], "Power");
                            v_power2_a1_Y = Retrive_YxValuePD((byte[])dr["power2_a1"]);
                        }

                        if (Convert.ToString(dr["power2_h1"]) != "")
                        {
                            v_power2_h1_X = get_PowerResolution(v_measure_id, Power2_1, (byte[])dr["power2_h1"], "Power");
                            v_power2_h1_Y = Retrive_YxValuePD((byte[])dr["power2_h1"]);
                        }

                        if (Convert.ToString(dr["power2_v1"]) != "")
                        {
                            v_power2_v1_X = get_PowerResolution(v_measure_id, Power2_1, (byte[])dr["power2_v1"], "Power");
                            v_power2_v1_Y = Retrive_YxValuePD((byte[])dr["power2_v1"]);
                        }


                        //-----------------------For Power3 Band-------------------------------------//


                        if (Convert.ToString(dr["power3_ch1"]) != "")
                        {
                            v_power3_ch1_X = get_PowerResolution(v_measure_id, Power3, (byte[])dr["power3_ch1"], "Power");
                            v_power3_ch1_Y = Retrive_YxValuePD((byte[])dr["power3_ch1"]);
                        }

                        if (Convert.ToString(dr["power3_a"]) != "")
                        {
                            v_power3_a_X = get_PowerResolution(v_measure_id, Power3, (byte[])dr["power3_a"], "Power");
                            v_power3_a_Y = Retrive_YxValuePD((byte[])dr["power3_a"]);
                        }

                        if (Convert.ToString(dr["power3_h"]) != "")
                        {
                            v_power3_h_X = get_PowerResolution(v_measure_id, Power3, (byte[])dr["power3_h"], "Power");
                            v_power3_h_Y = Retrive_YxValuePD((byte[])dr["power3_h"]);
                        }

                        if (Convert.ToString(dr["power3_v"]) != "")
                        {
                            v_power3_v_X = get_PowerResolution(v_measure_id, Power3, (byte[])dr["power3_v"], "Power");
                            v_power3_v_Y = Retrive_YxValuePD((byte[])dr["power3_v"]);
                        }

                        //-----------------------For Power3-1 Band-------------------------------------//

                        if (Convert.ToString(dr["power3_ch11"]) != "")
                        {
                            v_power3_ch11_X = get_PowerResolution(v_measure_id, Power3_1, (byte[])dr["power3_ch11"], "Power");
                            v_power3_ch11_Y = Retrive_YxValuePD((byte[])dr["power3_ch11"]);
                        }

                        if (Convert.ToString(dr["power3_a1"]) != "")
                        {
                            v_power3_a1_X = get_PowerResolution(v_measure_id, Power3_1, (byte[])dr["power3_a1"], "Power");
                            v_power3_a1_Y = Retrive_YxValuePD((byte[])dr["power3_a1"]);
                        }

                        if (Convert.ToString(dr["power3_h1"]) != "")
                        {
                            v_power3_h1_X = get_PowerResolution(v_measure_id, Power3_1, (byte[])dr["power3_h1"], "Power");
                            v_power3_h1_Y = Retrive_YxValuePD((byte[])dr["power3_h1"]);
                        }

                        if (Convert.ToString(dr["power3_v1"]) != "")
                        {
                            v_power3_v1_X = get_PowerResolution(v_measure_id, Power3_1, (byte[])dr["power3_v1"], "Power");
                            v_power3_v1_Y = Retrive_YxValuePD((byte[])dr["power3_v1"]);
                        }


                        //-----------------------For Cepstrum Band-------------------------------------//


                        if (Convert.ToString(dr["cepstrum_ch1"]) != "")
                        {
                            v_cepstrum_ch1_X = get_CepstrumResolution(v_measure_id, cepstrum, (byte[])dr["cepstrum_ch1"], "Cepstrum");
                            v_cepstrum_ch1_Y = Retrive_YxValuecep((byte[])dr["cepstrum_ch1"]);
                        }

                        if (Convert.ToString(dr["cepstrum_a"]) != "")
                        {
                            v_cepstrum_a_X = get_CepstrumResolution(v_measure_id, cepstrum, (byte[])dr["cepstrum_a"], "Cepstrum");
                            v_cepstrum_a_Y = Retrive_YxValuecep((byte[])dr["cepstrum_a"]);
                        }

                        if (Convert.ToString(dr["cepstrum_h"]) != "")
                        {
                            v_cepstrum_h_X = get_CepstrumResolution(v_measure_id, cepstrum, (byte[])dr["cepstrum_h"], "Cepstrum");
                            v_cepstrum_h_Y = Retrive_YxValuecep((byte[])dr["cepstrum_h"]);
                        }

                        if (Convert.ToString(dr["cepstrum_v"]) != "")
                        {
                            v_cepstrum_v_X = get_CepstrumResolution(v_measure_id, cepstrum, (byte[])dr["cepstrum_v"], "Cepstrum");
                            v_cepstrum_v_Y = Retrive_YxValuecep((byte[])dr["cepstrum_v"]);
                        }

                        //-----------------------For Demodulate Band-------------------------------------//

                        if (Convert.ToString(dr["demodulate_ch1"]) != "")
                        {
                            v_demodulate_ch1_X = get_PowerResolution(v_measure_id, demodulate, (byte[])dr["demodulate_ch1"], "Demodulate");
                            v_demodulate_ch1_Y = Retrive_YxValuePD((byte[])dr["demodulate_ch1"]);
                        }

                        if (Convert.ToString(dr["demodulate_a"]) != "")
                        {
                            v_demodulate_a_X = get_PowerResolution(v_measure_id, demodulate, (byte[])dr["demodulate_a"], "Demodulate");
                            v_demodulate_a_Y = Retrive_YxValuePD((byte[])dr["demodulate_a"]);
                        }

                        if (Convert.ToString(dr["demodulate_h"]) != "")
                        {
                            v_demodulate_h_X = get_PowerResolution(v_measure_id, demodulate, (byte[])dr["demodulate_h"], "Demodulate");
                            v_demodulate_h_Y = Retrive_YxValuePD((byte[])dr["demodulate_h"]);
                        }


                        if (Convert.ToString(dr["demodulate_v"]) != "")
                        {
                            v_demodulate_v_X = get_PowerResolution(v_measure_id, demodulate, (byte[])dr["demodulate_v"], "Demodulate");
                            v_demodulate_v_Y = Retrive_YxValuePD((byte[])dr["demodulate_v"]);
                        }
                    }
                    string v_temperature = Convert.ToString(dr["temperature"]);
                    string v_process = Convert.ToString(dr["process"]);
                    string v_auto_measure = Convert.ToString(dr["auto_measure"]);
                    string v_record_status = Convert.ToString(dr["record_status"]);
                    string v_point_schedule = Convert.ToString(dr["point_schedule"]).Trim();
                    string v_point_name = Convert.ToString(dr["point_name"]);
                    string v_machine_id = Convert.ToString(dr["machine_id"]);
                    DataTable dtt = new DataTable();
                    string v_Point_Type = "";
                    string v_Notes1 = "";
                    string v_Notes2 = "";
                    string v_Manual = "";
                    DataTable dt2 = DbClass.getdata(CommandType.Text, "select Data_ID,Point_ID,Point_name,point_type,Measure_time from point_data where Point_ID='" + v_point_id + "' and Measure_time='" + v_measure_time + "'");

                    if (v_point_schedule == "1" && v_Point_Type == "")
                    {
                        if (dt2.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            DataTable dt3 = DbClass.getdata(CommandType.Text, "select distinct point_id from point_data where point_id='" + v_point_id + "'");
                            if (dt3.Rows.Count > 0)
                            {
                                DbClass.executequery(CommandType.Text, " insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,  accel_a,  accel_h,    accel_v,accel_ch1, vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values       ( '" + v_point_id + "' ,'" + v_point_name + "', '" + untypeid + "', '" + v_measure_time + "' , '" + v_accel_a + "' ,'" + v_accel_h + "','" + v_accel_v + "' ,'" + v_accel_ch1 + "' , '" + v_vel_a + "'   ,'" + v_vel_h + "' ,'" + v_vel_v + "'  ,'" + v_vel_ch1 + "' ,'" + v_displ_a + "' ,  '" + v_displ_h + "' , '" + v_displ_v + "' ,'" + v_displ_ch1 + "'  ,'" + v_crest_factor_a + "', '" + v_crest_factor_h + "'  ,'" + v_crest_factor_v + "' , '" + v_crest_factor_ch1 + "',  '" + v_bearing_a + "' ,'" + v_bearing_h + "', '" + v_bearing_v + "',  '" + v_bearing_ch1 + "'  ,'" + v_ordertrace_a_real + "'  ,'" + v_ordertrace_h_real + "' ,'" + v_ordertrace_v_real + "',  '" + v_ordertrace_ch1_real + "'  ,   '" + v_ordertrace_a_image + "','" + v_ordertrace_h_image + "','" + v_ordertrace_v_image + "','" + v_ordertrace_ch1_image + "', '" + v_ordertrace_rpm + "'  ,  '" + v_time_a_X + "', '" + v_time_h_X + "', '" + v_time_v_X + "' ,'" + v_time_ch1_X + "' ,'" + v_power_a_X + "','" + v_power_h_X + "' ,'" + v_power_v_X + "','" + v_power_ch_X + "' ,'" + v_power_a1_X + "','" + v_power_h1_X + "' ,'" + v_power_v1_X + "' , '" + v_power_ch1_X + "'  ,'" + v_power2_a_X + "','" + v_power2_h_X + "','" + v_power2_v_X + "' ,'" + v_power2_ch1_X + "'  ,'" + v_power2_a1_X + "','" + v_power2_h1_X + "','" + v_power2_v1_X + "','" + v_power2_ch11_X + "','" + v_power3_a_X + "','" + v_power3_h_X + "', '" + v_power3_v_X + "', '" + v_power3_ch1_X + "' ,'" + v_power3_a1_X + "','" + v_power3_h1_X + "','" + v_power3_v1_X + "','" + v_power3_ch11_X + "' ,'" + v_cepstrum_a_X + "','" + v_cepstrum_h_X + "','" + v_cepstrum_v_X + "','" + v_cepstrum_ch1_X + "', '" + v_demodulate_a_X + "','" + v_demodulate_h_X + "','" + v_demodulate_v_X + "', '" + v_demodulate_ch1_X + "'  ,  '" + v_time_a_Y + "', '" + v_time_h_Y + "', '" + v_time_v_Y + "' ,'" + v_time_CH1_Y + "' ,'" + v_power_a_Y + "','" + v_power_h_Y + "' ,'" + v_power_v_Y + "','" + v_power_ch_Y + "' ,'" + v_power_a1_Y + "','" + v_power_h1_Y + "' ,'" + v_power_v1_Y + "' , '" + v_power_ch1_Y + "'  ,'" + v_power2_a_Y + "','" + v_power2_h_Y + "','" + v_power2_v_Y + "' ,'" + v_power2_ch1_Y + "'  ,'" + v_power2_a1_Y + "','" + v_power2_h1_Y + "','" + v_power2_v1_Y + "','" + v_power2_ch11_Y + "','" + v_power3_a_Y + "','" + v_power3_h_Y + "', '" + v_power3_v_Y + "', '" + v_power3_ch1_Y + "' ,'" + v_power3_a1_Y + "','" + v_power3_h1_Y + "','" + v_power3_v1_Y + "','" + v_power3_ch11_Y + "' ,'" + v_cepstrum_a_Y + "','" + v_cepstrum_h_Y + "','" + v_cepstrum_v_Y + "','" + v_cepstrum_ch1_Y + "', '" + v_demodulate_a_Y + "','" + v_demodulate_h_Y + "','" + v_demodulate_v_Y + "', '" + v_demodulate_ch1_Y + "'     ,  '" + v_temperature + "', '" + v_process + "','" + v_auto_measure + "','" + v_record_status + "' ,'" + v_Notes1 + "' ,'" + v_Notes2 + "',  '" + PublicClass.GetDatetime() + "' ,'" + v_Manual + "')  ");
                                //return;
                            }
                            else
                            {
                                if (v_point_id != "")
                                {
                                    point_new_record_id = Convert.ToInt32(v_point_id);
                                    ConvertPointType(v_point_id);
                                    Inser_Measuresforunschedule(untypeid);
                                    insert_unitsforunschedule(Convert.ToInt32(untypeid));
                                  //  insert_unitsforunschedule(Convert.ToInt32(v_unit_id));
                                    CalcGeneralPageVariables2(powermeasurement, untypeid);
                                    DbClass.executequery(CommandType.Text, "update point set PointType_Id='" + untypeid + "' where Point_ID='" + point_new_record_id + "'");
                                    DbClass.executequery(CommandType.Text, " insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,  accel_a,  accel_h,    accel_v,accel_ch1, vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values       ( '" + v_point_id + "' ,'" + v_point_name + "', '" + untypeid + "', '" + v_measure_time + "' , '" + v_accel_a + "' ,'" + v_accel_h + "','" + v_accel_v + "' ,'" + v_accel_ch1 + "' , '" + v_vel_a + "'   ,'" + v_vel_h + "' ,'" + v_vel_v + "'  ,'" + v_vel_ch1 + "' ,'" + v_displ_a + "' ,  '" + v_displ_h + "' , '" + v_displ_v + "' ,'" + v_displ_ch1 + "'  ,'" + v_crest_factor_a + "', '" + v_crest_factor_h + "'  ,'" + v_crest_factor_v + "' , '" + v_crest_factor_ch1 + "',  '" + v_bearing_a + "' ,'" + v_bearing_h + "', '" + v_bearing_v + "',  '" + v_bearing_ch1 + "'  ,'" + v_ordertrace_a_real + "'  ,'" + v_ordertrace_h_real + "' ,'" + v_ordertrace_v_real + "',  '" + v_ordertrace_ch1_real + "'  ,   '" + v_ordertrace_a_image + "','" + v_ordertrace_h_image + "','" + v_ordertrace_v_image + "','" + v_ordertrace_ch1_image + "', '" + v_ordertrace_rpm + "'  ,  '" + v_time_a_X + "', '" + v_time_h_X + "', '" + v_time_v_X + "' ,'" + v_time_ch1_X + "' ,'" + v_power_a_X + "','" + v_power_h_X + "' ,'" + v_power_v_X + "','" + v_power_ch_X + "' ,'" + v_power_a1_X + "','" + v_power_h1_X + "' ,'" + v_power_v1_X + "' , '" + v_power_ch1_X + "'  ,'" + v_power2_a_X + "','" + v_power2_h_X + "','" + v_power2_v_X + "' ,'" + v_power2_ch1_X + "'  ,'" + v_power2_a1_X + "','" + v_power2_h1_X + "','" + v_power2_v1_X + "','" + v_power2_ch11_X + "','" + v_power3_a_X + "','" + v_power3_h_X + "', '" + v_power3_v_X + "', '" + v_power3_ch1_X + "' ,'" + v_power3_a1_X + "','" + v_power3_h1_X + "','" + v_power3_v1_X + "','" + v_power3_ch11_X + "' ,'" + v_cepstrum_a_X + "','" + v_cepstrum_h_X + "','" + v_cepstrum_v_X + "','" + v_cepstrum_ch1_X + "', '" + v_demodulate_a_X + "','" + v_demodulate_h_X + "','" + v_demodulate_v_X + "', '" + v_demodulate_ch1_X + "'  ,  '" + v_time_a_Y + "', '" + v_time_h_Y + "', '" + v_time_v_Y + "' ,'" + v_time_CH1_Y + "' ,'" + v_power_a_Y + "','" + v_power_h_Y + "' ,'" + v_power_v_Y + "','" + v_power_ch_Y + "' ,'" + v_power_a1_Y + "','" + v_power_h1_Y + "' ,'" + v_power_v1_Y + "' , '" + v_power_ch1_Y + "'  ,'" + v_power2_a_Y + "','" + v_power2_h_Y + "','" + v_power2_v_Y + "' ,'" + v_power2_ch1_Y + "'  ,'" + v_power2_a1_Y + "','" + v_power2_h1_Y + "','" + v_power2_v1_Y + "','" + v_power2_ch11_Y + "','" + v_power3_a_Y + "','" + v_power3_h_Y + "', '" + v_power3_v_Y + "', '" + v_power3_ch1_Y + "' ,'" + v_power3_a1_Y + "','" + v_power3_h1_Y + "','" + v_power3_v1_Y + "','" + v_power3_ch11_Y + "' ,'" + v_cepstrum_a_Y + "','" + v_cepstrum_h_Y + "','" + v_cepstrum_v_Y + "','" + v_cepstrum_ch1_Y + "', '" + v_demodulate_a_Y + "','" + v_demodulate_h_Y + "','" + v_demodulate_v_Y + "', '" + v_demodulate_ch1_Y + "'     ,  '" + v_temperature + "', '" + v_process + "','" + v_auto_measure + "','" + v_record_status + "' ,'" + v_Notes1 + "' ,'" + v_Notes2 + "',  '" + PublicClass.GetDatetime() + "' ,'" + v_Manual + "')  ");
                                }
                            }
                        }
                    }
                    else if (v_point_schedule == "0" && v_Point_Type != "")
                    {
                        int point_new_id = Insert_unschedule_point(v_point_name, v_machine_id, v_measure_time, v_point_id);
                        DbClass.executequery(CommandType.Text, " insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,     accel_a,  accel_h,    accel_v,accel_ch1,            vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,                  crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values       ( '" + point_new_id + "' ,'" + v_point_name + "', '" + v_Point_Type + "', '" + v_measure_time + "' , '" + v_accel_a + "' ,'" + v_accel_h + "','" + v_accel_v + "' ,'" + v_accel_ch1 + "' , '" + v_vel_a + "'   ,'" + v_vel_h + "' ,'" + v_vel_v + "'  ,'" + v_vel_ch1 + "' ,'" + v_displ_a + "' ,  '" + v_displ_h + "' , '" + v_displ_v + "' ,'" + v_displ_ch1 + "'  ,'" + v_crest_factor_a + "', '" + v_crest_factor_h + "'  ,'" + v_crest_factor_v + "' , '" + v_crest_factor_ch1 + "',  '" + v_bearing_a + "' ,'" + v_bearing_h + "', '" + v_bearing_v + "',  '" + v_bearing_ch1 + "'  ,'" + v_ordertrace_a_real + "'  ,'" + v_ordertrace_h_real + "' ,'" + v_ordertrace_v_real + "',  '" + v_ordertrace_ch1_real + "'  ,   '" + v_ordertrace_a_image + "','" + v_ordertrace_h_image + "','" + v_ordertrace_v_image + "','" + v_ordertrace_ch1_image + "', '" + v_ordertrace_rpm + "'  ,  '" + v_time_a_X + "', '" + v_time_h_X + "', '" + v_time_v_X + "' ,'" + v_time_ch1_X + "' ,'" + v_power_a_X + "','" + v_power_h_X + "' ,'" + v_power_v_X + "','" + v_power_ch_X + "' ,'" + v_power_a1_X + "','" + v_power_h1_X + "' ,'" + v_power_v1_X + "' , '" + v_power_ch1_X + "'  ,'" + v_power2_a_X + "','" + v_power2_h_X + "','" + v_power2_v_X + "' ,'" + v_power2_ch1_X + "'  ,'" + v_power2_a1_X + "','" + v_power2_h1_X + "','" + v_power2_v1_X + "','" + v_power2_ch11_X + "','" + v_power3_a_X + "','" + v_power3_h_X + "', '" + v_power3_v_X + "', '" + v_power3_ch1_X + "' ,'" + v_power3_a1_X + "','" + v_power3_h1_X + "','" + v_power3_v1_X + "','" + v_power3_ch11_X + "' ,'" + v_cepstrum_a_X + "','" + v_cepstrum_h_X + "','" + v_cepstrum_v_X + "','" + v_cepstrum_ch1_X + "', '" + v_demodulate_a_X + "','" + v_demodulate_h_X + "','" + v_demodulate_v_X + "', '" + v_demodulate_ch1_X + "'  ,  '" + v_time_a_Y + "', '" + v_time_h_Y + "', '" + v_time_v_Y + "' ,'" + v_time_CH1_Y + "' ,'" + v_power_a_Y + "','" + v_power_h_Y + "' ,'" + v_power_v_Y + "','" + v_power_ch_Y + "' ,'" + v_power_a1_Y + "','" + v_power_h1_Y + "' ,'" + v_power_v1_Y + "' , '" + v_power_ch1_Y + "'  ,'" + v_power2_a_Y + "','" + v_power2_h_Y + "','" + v_power2_v_Y + "' ,'" + v_power2_ch1_Y + "'  ,'" + v_power2_a1_Y + "','" + v_power2_h1_Y + "','" + v_power2_v1_Y + "','" + v_power2_ch11_Y + "','" + v_power3_a_Y + "','" + v_power3_h_Y + "', '" + v_power3_v_Y + "', '" + v_power3_ch1_Y + "' ,'" + v_power3_a1_Y + "','" + v_power3_h1_Y + "','" + v_power3_v1_Y + "','" + v_power3_ch11_Y + "' ,'" + v_cepstrum_a_Y + "','" + v_cepstrum_h_Y + "','" + v_cepstrum_v_Y + "','" + v_cepstrum_ch1_Y + "', '" + v_demodulate_a_Y + "','" + v_demodulate_h_Y + "','" + v_demodulate_v_Y + "', '" + v_demodulate_ch1_Y + "'     ,  '" + v_temperature + "', '" + v_process + "','" + v_auto_measure + "','" + v_record_status + "' ,'" + v_Notes1 + "' ,'" + v_Notes2 + "',  '" + PublicClass.GetDatetime() + "' ,'" + v_Manual + "')  ");
                    }
                    else if (v_point_schedule == "0" && v_Point_Type == "")
                    {
                        int point_new_id = Insert_unschedule_point(v_point_name, v_machine_id, v_measure_time, v_point_id);
                        DbClass.executequery(CommandType.Text, " insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,     accel_a,  accel_h,    accel_v,accel_ch1,            vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,                  crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values       ( '" + point_new_id + "' ,'" + v_point_name + "', '" + untypeid + "', '" + v_measure_time + "' , '" + v_accel_a + "' ,'" + v_accel_h + "','" + v_accel_v + "' ,'" + v_accel_ch1 + "' , '" + v_vel_a + "'   ,'" + v_vel_h + "' ,'" + v_vel_v + "'  ,'" + v_vel_ch1 + "' ,'" + v_displ_a + "' ,  '" + v_displ_h + "' , '" + v_displ_v + "' ,'" + v_displ_ch1 + "'  ,'" + v_crest_factor_a + "', '" + v_crest_factor_h + "'  ,'" + v_crest_factor_v + "' , '" + v_crest_factor_ch1 + "',  '" + v_bearing_a + "' ,'" + v_bearing_h + "', '" + v_bearing_v + "',  '" + v_bearing_ch1 + "'  ,'" + v_ordertrace_a_real + "'  ,'" + v_ordertrace_h_real + "' ,'" + v_ordertrace_v_real + "',  '" + v_ordertrace_ch1_real + "'  ,   '" + v_ordertrace_a_image + "','" + v_ordertrace_h_image + "','" + v_ordertrace_v_image + "','" + v_ordertrace_ch1_image + "', '" + v_ordertrace_rpm + "'  ,  '" + v_time_a_X + "', '" + v_time_h_X + "', '" + v_time_v_X + "' ,'" + v_time_ch1_X + "' ,'" + v_power_a_X + "','" + v_power_h_X + "' ,'" + v_power_v_X + "','" + v_power_ch_X + "' ,'" + v_power_a1_X + "','" + v_power_h1_X + "' ,'" + v_power_v1_X + "' , '" + v_power_ch1_X + "'  ,'" + v_power2_a_X + "','" + v_power2_h_X + "','" + v_power2_v_X + "' ,'" + v_power2_ch1_X + "'  ,'" + v_power2_a1_X + "','" + v_power2_h1_X + "','" + v_power2_v1_X + "','" + v_power2_ch11_X + "','" + v_power3_a_X + "','" + v_power3_h_X + "', '" + v_power3_v_X + "', '" + v_power3_ch1_X + "' ,'" + v_power3_a1_X + "','" + v_power3_h1_X + "','" + v_power3_v1_X + "','" + v_power3_ch11_X + "' ,'" + v_cepstrum_a_X + "','" + v_cepstrum_h_X + "','" + v_cepstrum_v_X + "','" + v_cepstrum_ch1_X + "', '" + v_demodulate_a_X + "','" + v_demodulate_h_X + "','" + v_demodulate_v_X + "', '" + v_demodulate_ch1_X + "'  ,  '" + v_time_a_Y + "', '" + v_time_h_Y + "', '" + v_time_v_Y + "' ,'" + v_time_CH1_Y + "' ,'" + v_power_a_Y + "','" + v_power_h_Y + "' ,'" + v_power_v_Y + "','" + v_power_ch_Y + "' ,'" + v_power_a1_Y + "','" + v_power_h1_Y + "' ,'" + v_power_v1_Y + "' , '" + v_power_ch1_Y + "'  ,'" + v_power2_a_Y + "','" + v_power2_h_Y + "','" + v_power2_v_Y + "' ,'" + v_power2_ch1_Y + "'  ,'" + v_power2_a1_Y + "','" + v_power2_h1_Y + "','" + v_power2_v1_Y + "','" + v_power2_ch11_Y + "','" + v_power3_a_Y + "','" + v_power3_h_Y + "', '" + v_power3_v_Y + "', '" + v_power3_ch1_Y + "' ,'" + v_power3_a1_Y + "','" + v_power3_h1_Y + "','" + v_power3_v1_Y + "','" + v_power3_ch11_Y + "' ,'" + v_cepstrum_a_Y + "','" + v_cepstrum_h_Y + "','" + v_cepstrum_v_Y + "','" + v_cepstrum_ch1_Y + "', '" + v_demodulate_a_Y + "','" + v_demodulate_h_Y + "','" + v_demodulate_v_Y + "', '" + v_demodulate_ch1_Y + "'     ,  '" + v_temperature + "', '" + v_process + "','" + v_auto_measure + "','" + v_record_status + "' ,'" + v_Notes1 + "' ,'" + v_Notes2 + "',  '" + PublicClass.GetDatetime() + "' ,'" + v_Manual + "')  ");
                    }
                }
            }
            catch { }
            PublicClass.pointIDs = pointID;
        }


        string pointName = null; string machineid = null; string createddate = null; string point_id = null;
        int iMeasureID = 0;
        byte PowerBand = 0;
        byte PowerResolution = 0;
        public string get_PowerResolution(string iPointID, string ss, byte[] btArgs, string stype)
        {
            string[] sarrXTData = new string[0];
            string Value = "";
            try
            {
                //power_band1,power_resolution1
                DataTable dt = new DataTable();
                dt = SqlceClass.getdata(CommandType.Text, "select measure_id, " + ss + " from measures where measure_id='" + iPointID + "' ", "Data Source=" + connvalu);
                foreach (DataRow objReader in dt.Rows)
                {
                    iMeasureID = (int)objReader[0];
                    PowerBand = (byte)objReader[1];    // band
                    PowerResolution = (byte)objReader[2];   //resoultion
                }
                //string sXValue = GetTimeData(iPointID, btTimeA, MeasureTimeBand, "Time", MeasureTimeResolution);
                //ValueType = GetTimeData(iPointID, btArgs, PowerBand, "Power", PowerResolution);
                Value = GetTimeData(Convert.ToInt16(iPointID), btArgs, PowerBand, stype, PowerResolution);
                _ResizeArray.IncreaseArrayString(ref sarrXTData, 1);
                sarrXTData[sarrXTData.Length - 1] = Value;
                for (int i = 0; i < sarrXTData.Length; i++)
                {
                    Value = sarrXTData[sarrXTData.Length - 1];
                }
            }
            catch { }
            return Value;
        }

        public string Retrive_YxValuePD(byte[] btTimeA)
        {
            string[] sarrYTData = new string[0];
            StringBuilder sbYValues = new StringBuilder();
            string YTAData = "";
            try
            {
                if (btTimeA != null)
                {
                    int iLength = (btTimeA.GetLength(0) + 7) / 8;
                    double[] dTimeImage_A = new double[iLength];
                    for (int i = 0; i < iLength; i++)
                    {
                        dTimeImage_A[i] = Math.Sqrt(BitConverter.ToDouble(btTimeA, i * 8));
                    }
                    for (int iLoop = 0; iLoop < dTimeImage_A.Length; iLoop++)
                    {
                        sbYValues.Append(dTimeImage_A[iLoop]);
                        sbYValues.Append("|");
                    }
                    string sTimeData = System.Text.Encoding.Default.GetString(btTimeA);
                    YTAData = Convert.ToString(sbYValues);

                    _ResizeArray.IncreaseArrayString(ref sarrYTData, 1);
                    sarrYTData[sarrYTData.Length - 1] = YTAData;
                    YTAData = sarrYTData[sarrYTData.Length - 1];
                }

            }
            catch { }
            return YTAData;
        }


        public string get_CepstrumResolution(string iPointID, string ss, byte[] btArgs, string stype)
        {
            string[] sarrXTData = new string[0];
            string Value = "";
            try
            {
                //cep_band1,cep_resolution1
                DataTable dt = new DataTable();
                dt = SqlceClass.getdata(CommandType.Text, "select measure_id, " + ss + " from measures where measure_id='" + iPointID + "' ", "Data Source=" + connvalu);
                foreach (DataRow objReader in dt.Rows)
                {
                    iMeasureID = (int)objReader[0];
                    PowerBand = (byte)objReader[1];    // band
                    PowerResolution = (byte)objReader[2];   //resoultion
                }

                Value = GetTimeData(Convert.ToInt16(iPointID), btArgs, PowerBand, stype, PowerResolution);
                _ResizeArray.IncreaseArrayString(ref sarrXTData, 1);
                sarrXTData[sarrXTData.Length - 1] = Value;
                for (int i = 0; i < sarrXTData.Length; i++)
                {
                    Value = sarrXTData[sarrXTData.Length - 1];
                }
            }
            catch { }
            return Value;
        }

        public string Retrive_YxValuecep(byte[] btTimeA)
        {
            string[] sarrYTData = new string[0];
            StringBuilder sbYValues = new StringBuilder();
            string YTAData = "";
            try
            {
                if (btTimeA != null)
                {
                    int iLength = (btTimeA.GetLength(0) + 7) / 8;
                    double[] dTimeImage_A = new double[iLength];
                    for (int i = 0; i < iLength; i++)
                    {
                        dTimeImage_A[i] = Math.Sqrt(BitConverter.ToDouble(btTimeA, i * 8));
                    }
                    for (int iLoop = 0; iLoop < dTimeImage_A.Length; iLoop++)
                    {
                        sbYValues.Append(dTimeImage_A[iLoop]);
                        sbYValues.Append("|");
                    }
                    string sTimeData = System.Text.Encoding.Default.GetString(btTimeA);

                    YTAData = Convert.ToString(sbYValues);

                    _ResizeArray.IncreaseArrayString(ref sarrYTData, 1);
                    sarrYTData[sarrYTData.Length - 1] = YTAData;
                    YTAData = sarrYTData[sarrYTData.Length - 1];
                }
            }
            catch { }
            return YTAData;
        }

        double[] m_arrKeys = null;
        private string GetTimeData(int iPointID, byte[] btArgs, byte MeasureTimeBand, string sType, byte btResolution)
        {
            StringBuilder sbXValues = null;
            try
            {
                sbXValues = new StringBuilder();
                int iFrequency = 0;
                if (MeasureTimeBand == 0)
                {
                    iFrequency = 50;
                }
                else if (MeasureTimeBand == 1)
                    iFrequency = 100;
                else if (MeasureTimeBand == 2)
                    iFrequency = 200;
                else if (MeasureTimeBand == 3)
                    iFrequency = 500;
                else if (MeasureTimeBand == 4)
                    iFrequency = 1000;
                else if (MeasureTimeBand == 5)
                    iFrequency = 2000;
                else if (MeasureTimeBand == 6)
                    iFrequency = 5000;
                else if (MeasureTimeBand == 7)
                    iFrequency = 10000;
                else if (MeasureTimeBand == 8)
                    iFrequency = 20000;
                else if (MeasureTimeBand == 9)
                    iFrequency = 40000;


                int iResolution1 = 0;
                if (btResolution == 0)
                {
                    iResolution1 = 100;
                }
                else if (btResolution == 1)
                {
                    iResolution1 = 200;
                }
                else if (btResolution == 2)
                {
                    iResolution1 = 400;
                }
                else if (btResolution == 3)
                {
                    iResolution1 = 800;
                }
                else if (btResolution == 4)
                {
                    iResolution1 = 1600;
                }
                else if (btResolution == 5)
                {
                    iResolution1 = 3200;
                }
                else if (btResolution == 6)
                {
                    iResolution1 = 6400;
                }
                else if (btResolution == 7)
                {
                    iResolution1 = 12800;
                }

                int iLength = (btArgs.GetLength(0) + 7) / 8;
                double[] dTimeImage = new double[iLength];
                for (int i = 0; i < iLength; i++)
                    dTimeImage[i] = BitConverter.ToDouble(btArgs, i * 8);

                double dCreateArray = 0;
                if (sType == "Time")
                {
                    if (dTimeImage != null && dTimeImage.Length > 0)
                    {
                        dCreateArray = (1 / ((Convert.ToDouble(iFrequency)) * 2.56));
                    }
                }
                else if (sType == "Power" || sType == "Demodulate")
                {
                    dCreateArray = (Convert.ToDouble(iFrequency) / Convert.ToDouble(iResolution1));
                }
                else if (sType == "Cepstrum")
                {
                    dCreateArray = (1 / ((Convert.ToDouble(iFrequency)) * 2.56));
                }

                m_arrKeys = new double[dTimeImage.Length];
                CreateKeyBytes(dCreateArray);
                sbXValues.Append(0);
                sbXValues.Append("|");
                for (int iLoop = 0; iLoop < m_arrKeys.Length - 1; iLoop++)
                {
                    sbXValues.Append(m_arrKeys[iLoop]);
                    sbXValues.Append("|");
                }

                return sbXValues.ToString();
            }
            catch (Exception ex)
            {
                return sbXValues.ToString();


            }
        }

        private void CreateKeyBytes(double dDifference)
        {
            try
            {
                double dNewDifference = dDifference;

                for (int iCtr = 0; iCtr < m_arrKeys.Length; iCtr++)
                {
                    m_arrKeys[iCtr] = dDifference;
                    dDifference += dNewDifference;
                }
            }
            catch (Exception ex)
            {
            }
        }




        static string connvalu = "";
        public string ConvertSensors(string DBName)
        {
            try
            {
                DbClass.executequery(CommandType.Text, "truncate table Sensor_data");
                DataTable dtSenOld = SqlceClass.getdata(CommandType.Text, "select * from sensors", "Data Source=" + connvalu);
                foreach (DataRow drsen in dtSenOld.Rows)
                {
                    string SensorID = Convert.ToString(drsen["Sensor_Id"]);
                    string SensorName = Convert.ToString(drsen["Sensor_Name"]);
                    string SenType = Convert.ToString(drsen["Sensor_type"]);
                    string SensA = Convert.ToString(drsen["Sensitivity_a"]);
                    string SensH = Convert.ToString(drsen["Sensitivity_h"]);
                    string SensV = Convert.ToString(drsen["Sensitivity_v"]);
                    string SensCh1 = Convert.ToString(drsen["Sensitivity_ch1"]);
                    string SenUnit = Convert.ToString(drsen["Sensor_unit"]);
                    string SenDir = Convert.ToString(drsen["Sensor_dir"]);
                    string SenICP = Convert.ToString(drsen["Sensor_icp"]);
                    string SenOffset = Convert.ToString(drsen["Sensor_offset"]);
                    string SenManID = "1";
                    string SenInputRange = "0";
                    if (SensorID != "" || SensorID != null)
                    {
                        DbClass.executequery(CommandType.StoredProcedure, "call insert_sensor_data('" + SenManID + "' , '" + SensorName + "','" + SenType + "','" + SensCh1 + "' , '" + SensA + "' , '" + SensH + "' , '" + SensV + "','" + SenUnit + "','" + SenDir + "','" + SenICP + "','" + SenOffset + "', '" + SenInputRange + "') ");
                    }
                }
            }
            catch { }
            return DBName;
        }


        public string ConvertAlarms(string DBName)
        {
            try
            {
                DataTable dtAlarmOld = SqlceClass.getdata(CommandType.Text, "select * from Alarms", "Data Source=" + connvalu);
                foreach (DataRow drAlarm in dtAlarmOld.Rows)
                {
                    string alarmID = Convert.ToString(drAlarm["Alarm_id"]);
                    string AlarmName = "DefaultAlarm-" + alarmID + "";
                    string accel_a1 = Convert.ToString(drAlarm["accel_a1"]);
                    string accel_a2 = Convert.ToString(drAlarm["accel_a2"]);
                    string accel_v1 = Convert.ToString(drAlarm["accel_v1"]);
                    string accel_v2 = Convert.ToString(drAlarm["accel_v2"]);
                    string accel_h1 = Convert.ToString(drAlarm["accel_h1"]);
                    string accel_h2 = Convert.ToString(drAlarm["accel_h2"]);

                    string vel_a1 = Convert.ToString(drAlarm["vel_a1"]);
                    string vel_a2 = Convert.ToString(drAlarm["vel_a2"]);
                    string vel_v1 = Convert.ToString(drAlarm["vel_v1"]);
                    string vel_v2 = Convert.ToString(drAlarm["vel_v2"]);
                    string vel_h1 = Convert.ToString(drAlarm["vel_h1"]);
                    string vel_h2 = Convert.ToString(drAlarm["vel_h2"]);

                    string displ_a1 = Convert.ToString(drAlarm["displ_a1"]);
                    float displ_a2 = Convert.ToInt32(drAlarm["displ_a2"]);
                    string displ_v1 = Convert.ToString(drAlarm["displ_v1"]);
                    string displ_v2 = Convert.ToString(drAlarm["displ_v2"]);
                    string displ_h1 = Convert.ToString(drAlarm["displ_h1"]);
                    string displ_h2 = Convert.ToString(drAlarm["displ_h2"]);

                    string bearing_a1 = Convert.ToString(drAlarm["bearing_a1"]);
                    string bearing_a2 = Convert.ToString(drAlarm["bearing_a2"]);
                    string bearing_v1 = Convert.ToString(drAlarm["bearing_v1"]);
                    string bearing_v2 = Convert.ToString(drAlarm["bearing_v2"]);
                    string bearing_h1 = Convert.ToString(drAlarm["bearing_h1"]);
                    string bearing_h2 = Convert.ToString(drAlarm["bearing_h2"]);

                    string temperature_1 = Convert.ToString(drAlarm["temperature_1"]);
                    string temperature_2 = Convert.ToString(drAlarm["temperature_2"]);

                    string crestfactor_a1 = Convert.ToString(drAlarm["crest_factor_a1"]);
                    string crestfactor_a2 = Convert.ToString(drAlarm["crest_factor_a2"]);
                    string crestfactor_v1 = Convert.ToString(drAlarm["crest_factor_v1"]);
                    string crestfactor_v2 = Convert.ToString(drAlarm["crest_factor_v2"]);
                    string crestfactor_h1 = Convert.ToString(drAlarm["crest_factor_h1"]);
                    string crestfactor_h2 = Convert.ToString(drAlarm["crest_factor_h2"]);

                    string accel_ch11 = Convert.ToString(drAlarm["accel_ch11"]);
                    string accel_ch12 = Convert.ToString(drAlarm["accel_ch12"]);
                    string vel_ch11 = Convert.ToString(drAlarm["vel_ch11"]);
                    string vel_ch12 = Convert.ToString(drAlarm["vel_ch12"]);
                    string displ_ch11 = Convert.ToString(drAlarm["displ_ch11"]);
                    string displ_ch12 = Convert.ToString(drAlarm["displ_ch12"]);
                    string bearing_ch11 = Convert.ToString(drAlarm["bearing_ch11"]);
                    string bearing_ch12 = Convert.ToString(drAlarm["bearing_ch12"]);
                    string crestfactor_ch11 = Convert.ToString(drAlarm["crest_factor_ch11"]);
                    string crestfactor_ch12 = Convert.ToString(drAlarm["crest_factor_ch12"]);
                    if (Convert.ToString(alarmID) != "" || Convert.ToString(alarmID) != null)
                    {
                        DbClass.executequery(CommandType.Text, "ALTER TABLE `alarms_data` CHANGE COLUMN `Alarm_ID` `Alarm_ID` INT(10) UNSIGNED NOT NULL");
                        DbClass.executequery(CommandType.StoredProcedure, "Insert into alarms_data(  Alarm_ID,accel_a1,accel_h1,accel_v1,accel_a2,accel_h2,accel_v2,accel_ch11,accel_ch12,  vel_a1, vel_h1,vel_v1,vel_a2,vel_h2,vel_v2, vel_ch11,vel_ch12,  displ_a1,displ_h1,displ_v1,displ_a2,displ_h2,displ_v2, displ_ch11,displ_ch12,    bearing_a1,bearing_h1,bearing_v1,bearing_a2,bearing_h2,bearing_v2, bearing_ch11,bearing_ch12, crest_factor_a1,crest_factor_h1,crest_factor_v1,crest_factor_a2,crest_factor_h2,crest_factor_v2,crest_factor_ch11,crest_factor_ch12, temperature_1,temperature_2,Alarm_Name,Date) values('" + alarmID + "','" + accel_a1 + "','" + accel_h1 + "','" + accel_v1 + "','" + accel_a2 + "','" + accel_h2 + "','" + accel_v2 + "','" + accel_ch11 + "','" + accel_ch12 + "','" + vel_a1 + "','" + vel_h1 + "','" + vel_v1 + "','" + vel_a2 + "','" + vel_h2 + "','" + vel_v2 + "','" + vel_ch11 + "','" + vel_ch12 + "','" + displ_a1 + "','" + displ_h1 + "','" + displ_v1 + "','" + displ_a2 + "','" + displ_h2 + "','" + displ_v2 + "','" + displ_ch11 + "','" + displ_ch12 + "','" + bearing_a1 + "','" + bearing_h1 + "','" + bearing_v1 + "','" + bearing_a2 + "','" + bearing_h2 + "','" + bearing_v2 + "','" + bearing_ch11 + "','" + bearing_ch12 + "','" + crestfactor_a1 + "','" + crestfactor_h1 + "','" + crestfactor_v1 + "','" + crestfactor_a2 + "','" + crestfactor_h2 + "','" + crestfactor_v2 + "','" + crestfactor_ch11 + "','" + crestfactor_ch12 + "','" + temperature_1 + "','" + temperature_2 + "','" + AlarmName + "','" + PublicClass.GetDatetime() + "')");
                        DbClass.executequery(CommandType.Text, "ALTER TABLE `alarms_data` CHANGE COLUMN `Alarm_ID` `Alarm_ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT ;");
                    }
                }
            }
            catch (Exception ex) { }


            return DBName;
        }

        //---------For Machine Diagram----------//

        public void fillmachinediagram()
        {
            try
            {
                MD_factory();
                MD_Area(facid);
            }
            catch { }
        }

        string facid = null;
        public void MD_factory()
        {
            try
            {
                string facName = "Plant";
                int hyPreviousID = 0;
                int hyNextId = 0;
                DbClass.executequery(CommandType.Text, "Insert into factory_info(Name,Description,DateCreated,PreviousID,NextID) values('" + facName + "','Factory','" + PublicClass.GetDatetime() + "','" + hyPreviousID + "','" + hyNextId + "')");
                DataTable dtfacfinal = DbClass.getdata(CommandType.Text, "Select max(factory_id) from factory_info ");
                hyPreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtfacfinal.Rows[0][0]), "0"))) - 1;
                hyNextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtfacfinal.Rows[0][0]), "0"))) + 1;
                DbClass.executequery(CommandType.Text, "Update factory_info set PreviousID = '" + hyPreviousID + "',NextID='" + hyNextId + "' where factory_id = '" + Convert.ToString(dtfacfinal.Rows[0][0]) + "'");
                facid = Convert.ToString(dtfacfinal.Rows[0][0]);

            }
            catch
            { }
        }

        public void MD_Area(string facid11)
        {
            try
            {
                DataTable dtare = new DataTable();
                dtare = DbClass.getdata(CommandType.Text, "select * from machine_diagram");
                foreach (DataRow drare in dtare.Rows)
                {
                    string AreaName = "Area";
                    string facid = facid11;
                    string MDArea = Convert.ToString(drare["Area_id"]);
                    int PreviousID = 0;
                    int NextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into area_info(Name,Description,FactoryID,PreviousID,NextID,DateCreated) values('" + AreaName + "','Area','" + facid + "','" + PreviousID + "','" + NextId + "','" + PublicClass.GetDatetime() + "')");
                    DataTable dtareafinal = DbClass.getdata(CommandType.Text, "Select max(Area_ID) from area_info ");
                    PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtareafinal.Rows[0][0]), "0"))) - 1;
                    NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtareafinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update area_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Area_ID = '" + Convert.ToString(dtareafinal.Rows[0][0]) + "'");
                    MD_Train(Convert.ToString(dtareafinal.Rows[0][0]), MDArea);
                }
            }
            catch { }

        }


        public void MD_Train(string MD_Area_id, string MD_Area)
        {
            try
            {
                DataTable dtare = new DataTable();
                dtare = DbClass.getdata(CommandType.Text, "select * from machine_diagram_train where area_id='" + MD_Area + "'");
                foreach (DataRow drare in dtare.Rows)
                {
                    string trainName = "Train";
                    string areid = MD_Area_id;
                    string MD_Train = Convert.ToString(drare["train_id"]);
                    int PreviousID = 0;
                    int NextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into train_info(Name,Description,PreviousID,NextID,Area_ID,Date) values('" + trainName + "','Train','" + PreviousID + "','" + NextId + "','" + areid + "','" + PublicClass.GetDatetime() + "')");
                    DataTable dtTrainfinal = DbClass.getdata(CommandType.Text, "Select max(Train_ID) from train_info ");
                    PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtTrainfinal.Rows[0][0]), "0"))) - 1;
                    NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtTrainfinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update train_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Train_ID = '" + Convert.ToString(dtTrainfinal.Rows[0][0]) + "'");
                    MD_Mac(Convert.ToString(dtTrainfinal.Rows[0][0]), MD_Train);
                }
            }
            catch { }
        }

        public void MD_Mac(string Train_id, string MD_train)
        {
            try
            {
                DataTable dtare = new DataTable();
                dtare = DbClass.getdata(CommandType.Text, "select * from machine_type where mac_id='" + MD_train + "'");
                foreach (DataRow drare in dtare.Rows)
                {
                    string MachineName = Convert.ToString(drare["Mac_Name"]);
                    string traid = Train_id;
                    string machine_rpm = Convert.ToString(drare["Mac_RPM"]);
                    string Sen_ID = Convert.ToString(drare["Sen_ID"]);
                    string Sen_cal = Convert.ToString(drare["Sen_cal"]);
                    string machine_pulserev = "1";
                    int PreviousID = 0;
                    int NextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into machine_info(Name,Description,PreviousID,NextID,TrainID,DateCreated,RPM_Driven,PulseRev) values('" + MachineName + "','Machine','" + PreviousID + "','" + NextId + "','" + traid + "','" + PublicClass.GetDatetime() + "','" + machine_rpm + "','" + machine_pulserev + "')");
                    DataTable dtmacfinal = DbClass.getdata(CommandType.Text, "Select max(Machine_ID) from machine_info ");
                    PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtmacfinal.Rows[0][0]), "0"))) - 1;
                    NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtmacfinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update machine_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Machine_ID = '" + Convert.ToString(dtmacfinal.Rows[0][0]) + "'");
                    MDConvertPointType(Sen_ID, Sen_cal);
                    MD_point(Convert.ToString(dtmacfinal.Rows[0][0]), untypeid1);
                }
            }
            catch { }
        }

        public void MD_point(string Mac_id, int PT_ID)
        {
            try
            {
                string[] arlsttoreturn = new string[2];
                arlsttoreturn[0] = "DE";
                arlsttoreturn[1] = "NDE";
                DataTable dtare = new DataTable();
                for (int i = 0; i < arlsttoreturn.Length; i++)
                {
                    string pointNm = arlsttoreturn[i];
                    string prID = Mac_id;
                    int PreviousID = 0;
                    int NextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into point(PointName,PointDesc,DataCreated,PreviousID,NextID,Machine_ID,DataSchedule,PointStatus,PointSchedule) values('" + pointNm + "','Point','" + PublicClass.GetDatetime() + "','" + PreviousID + "','" + NextId + "','" + prID + "','7','0','1')");
                    DataTable dtpointfinal = DbClass.getdata(CommandType.Text, "Select max(Point_ID) from point ");
                    PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtpointfinal.Rows[0][0]), "0"))) - 1;
                    NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtpointfinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update point set PreviousID = '" + PreviousID + "',NextID='" + NextId + "',PointType_ID='" + PT_ID + "' where Point_ID = '" + Convert.ToString(dtpointfinal.Rows[0][0]) + "'");
                }
            }
            catch
            { }
        }


        int untypeid1;
        public void MDConvertPointType(string senid, string sendir)
        {
            try
            {
                string instname = PublicClass.currentInstrument;
                DataTable dtpoint = DbClass.getdata(CommandType.Text, "select max(ID)typepoint_id from Type_point");
                foreach (DataRow drsen in dtpoint.Rows)
                {
                    untypeid1 = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(drsen["typepoint_id"]), "0")) + 1;

                    string AlarmID = "0";
                    string sdID = "0";
                    string perID = "0";
                    string PointTypeName = Convert.ToString("DE-NDE-" + untypeid1);
                    DbClass.executequery(CommandType.Text, "Insert into type_point(Point_Name,Type_ID,Instrumentname,Alarm_ID,STDDeviationAlarm_ID,Percentage_AlarmID,Band_ID) values('" + PointTypeName + "','1','" + instname + "','" + AlarmID + "','" + sdID + "','" + perID + "','0')");

                    DataTable dt1 = DbClass.getdata(CommandType.Text, "select distinct ID from type_point where Point_name='" + PointTypeName + "'");
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        untypeid = (Convert.ToInt32(dr1["ID"]));
                    }
                }

                try
                {
                    DbClass.executequery(CommandType.Text, "insert into  measure_type  (  OAcc, OVel, ODisp, OBear, OTWF, OPS, ODS, Temp, Process, crestfactor, Ordertrace, Cepstrum , Type_ID ,CalcMeasure  ) values('1','1','1','1','1','1','1','0','0','1','1','1','" + untypeid1 + "','2687')");
                }
                catch { }

                try
                {
                    DbClass.executequery(CommandType.Text, "Insert Into measure(acc_filter, vel_filter , displ_filter, overall_bearing_filter, crest_factor_filter,bearing_acc_hp_filter, time_band, time_resoltion, time_overlap,Date,Sensordir, sensor_id , TemperatureID, power_band  ,power_resolution   ,power_band1 ,power_resolution1  ,power2_band   ,power2_resolution, power2_band1,power2_resolution1,power3_band,power3_resolution,power3_band1,power3_resolution1, power_window,power_overlap,power_average_times,power_zoom,power_zoom_startfeq,cepstrum_band, cepstrum_resolution,cepstrum_window,cepstrum_average_times,cepstrum_overlap,cepstrum_zoom,cepstrum_zoom_startfeq,demodulate_band,demodulate_resolution,demodulate_window,demodulate_average_times ,demodulate_filter,ordertrace_average_times,ordertrace_resolution,ordertrace_order,ordertrace_trigger_slope,power_multiple,Type_ID)values(  '3' ,'3' ,'3' ,'0' ,'3' ,'0' ,'4' ,'3' ,'0' ,'" + PublicClass.GetDatetime() + "' ,'" + sendir + "' ,'" + senid + "' ,'2' ,'4' ,'3' ,'4' ,'3' ,'4' ,'3' ,'4' ,'3' ,'4' ,'3' ,'4' ,'3' ,'1' ,'0' ,'1' ,'0' ,'0' ,'4' ,'3' ,'0' ,'1' ,'0' ,'0' ,'0' ,'4' ,'3' ,'0' ,'1' ,'0' ,'0' ,'0' ,'1' ,'0' ,'1' ,'" + untypeid1 + "')");
                }
                catch { }
                try
                {
                    DbClass.executequery(CommandType.Text, " insert into units(accel_unit,accel_detection,vel_unit,vel_detection,displ_unit,displ_detection,temperature_unit,process_unit,pressure_unit,pressure_detection,current_unit,current_detection,time_unit_type,power_unit_type,demodulate_unit_type,ordertrace_unit_type,cepstrum_unit_type,Date,Type_ID) values('0','1','0','0','1','2','0','','0','1','0','1','0','1','0','0','0','" + PublicClass.GetDatetime() + "','" + untypeid1 + "')");
                }
                catch { }

            }
            catch { }

        }


        //----work for DI----//


        private const string SHEXSIX = "\x06";
        public SerialPort m_objSerialPort = new SerialPort();
        byte[] arrLoopBreak = new byte[1]; byte[] objGetBytesFinal = null;
        public bool DiStatus = false;
        bool bAlreadyEntered = false;
        int Value = 0;
        bool PhaseExtraction = false;
        int dualChnl = 0;
        int iFScale = 0;    //fullscale--1
        int iMesure = 0;    //measuretype--5
        int iFltrType = 0;  //filter type--3
        int iFltrVal = 0;
        int iFreq = 0;      //frequency--4
        int iWin = 0;       //window--2
        int iCpl = 0;       //couple
        int iUnit = 0;      //unit
        int idetc = 0;      //detection
        int iLor = 0;       //line of resolution
        int isens = 100;      //sensitivity
        bool bmesure = false;
        string NewID = null;

        public void ConnectwithINST()
        {
            DiStatus = false;
            byte[] arrFiveByte = { 0x05 };
            int BaudRR = 115200;
            try
            {
                string sComPortName = null;
                string[] sComPortName1 = SerialPort.GetPortNames();
                if (sComPortName1.Length > 1)
                {
                    sComPortName = sComPortName1[sComPortName1.Length - 1];
                }
                else
                {
                    sComPortName = sComPortName1[0];
                }
                if (!string.IsNullOrEmpty(sComPortName))
                {
                    m_objSerialPort = new SerialPort(sComPortName, BaudRR, Parity.None, 8, StopBits.One);
                    m_objSerialPort.Open();
                    m_objSerialPort.DtrEnable = true;
                    m_objSerialPort.RtsEnable = true;
                    m_objSerialPort.Write(arrFiveByte, 0, arrFiveByte.Length);
                    CheckRoute();
                    DiStatus = true;
                }
            }
            catch
            { DiStatus = false; m_objSerialPort.Close(); }
        }

        StringBuilder objCompleteData = null;
        int sleep = 0;
        public void CheckRoute()
        {
            byte[] arrDataReceived = null;
            byte[] arrNewByte = { 0x01, 0x30, 0x30, 0x31, 0x30, 0x02, 0x03, 0x34, 0x36 };
            byte[] arrNewByte1 = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x46, 0x52, 0x45, 0x45, 0x03, 0x30, 0x34 };
            byte[] arrNewByte2 = { 0x06, 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x52, 0x46, 0x63, 0x3a, 0x5c, 0x7e, 0x70, 0x6c, 0x33, 0x30, 0x32, 0x5c, 0x63, 0x6f, 0x6e, 0x66, 0x69, 0x67, 0x5c, 0x63, 0x6f, 0x6e, 0x66, 0x69, 0x67, 0x2e, 0x70, 0x31, 0x31, 0x03, 0x30, 0x36 };
            byte[] arrNewByte3 = { 0x06, 0x01, 0x30, 0x30, 0x31, 0x36, 0x02, 0x30, 0x30, 0x30, 0x30, 0x03, 0x30, 0x43 };
            byte[] arrQuesInit1 = { 0x06, 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x46, 0x53, 0x63, 0x3a, 0x5c, 0x7e, 0x70, 0x6c, 0x33, 0x30, 0x32, 0x5c, 0x74, 0x6f, 0x75, 0x72 };
            byte[] arrQuesInit2 = { 0x5c, 0x6f, 0x66, 0x66, 0x74, 0x64, 0x61, 0x74, 0x61, 0x2e, 0x64, 0x61, 0x74, 0x03 };

            byte[] initcomplete = { 0x06, 0x04 };
            string sFinalRoute = null;
            try
            {
                arrDataReceived = new byte[1];
                objCompleteData = new StringBuilder();
                m_objSerialPort.Read(arrDataReceived, 0, arrDataReceived.Length);

                //Writing the First Byte array on the serial port byte array of length 9.
                if (arrDataReceived.Length > 0 && arrDataReceived[0].ToString() == "6")
                {
                    m_objSerialPort.Write(arrNewByte, 0, arrNewByte.Length);
                }
                while (m_objSerialPort.ReadByte().Equals(null)) ;
                while (true)
                {
                    string sData = m_objSerialPort.ReadExisting();
                    if (sData.Equals(""))
                        break;
                    string sFinalData = sData;
                }
                m_objSerialPort.Write(SHEXSIX);
                //while (m_objSerialPort.ReadByte().Equals(null)) ;
                //Reading four from the port
                while (true)
                {
                    string Four = m_objSerialPort.ReadExisting();
                    if (Four.Equals(""))
                        break;
                    string FourFinal = Four;
                    System.Diagnostics.Debug.WriteLine("test");
                }
                m_objSerialPort.Write(arrNewByte1, 0, arrNewByte1.Length);
                while (m_objSerialPort.ReadByte().Equals(null)) ;
                //Reading the Response from the port
                while (true)
                {
                    string sNextData = m_objSerialPort.ReadExisting();
                    if (sNextData.Equals(""))
                        break;
                    string sNextFinal = sNextData;
                }
                m_objSerialPort.Write(SHEXSIX);
                // while (m_objSerialPort.ReadByte().Equals(null));
                while (true)
                {
                    string Four1 = m_objSerialPort.ReadExisting();
                    if (Four1.Equals(""))
                        break;
                    string sFinalFour1 = Four1;
                }
                m_objSerialPort.Write(arrNewByte2, 0, arrNewByte2.Length);
                while (m_objSerialPort.ReadByte().Equals(null)) ;
                string ConfigData = null;
                while (true)
                {
                    string sNewData = m_objSerialPort.ReadExisting();
                    if (sNewData.Equals(""))
                        break;
                    string sFinalNewData = sNewData;
                    ConfigData += sNewData;
                }
                m_objSerialPort.Write(SHEXSIX);
                // while (m_objSerialPort.ReadByte().Equals(null));
                while (true)
                {
                    string Four2 = m_objSerialPort.ReadExisting();
                    if (Four2.Equals(""))
                        break;
                    string sFinalFour2 = Four2;
                }
                m_objSerialPort.Write(arrNewByte3, 0, arrNewByte3.Length);
                while (m_objSerialPort.ReadByte().Equals(null)) ;
                while (true)
                {
                    string sAgainData = m_objSerialPort.ReadExisting();
                    if (sAgainData.Equals(""))
                        break;
                    string sFinalAgainData = sAgainData;
                }

                m_objSerialPort.Write(SHEXSIX);
                while (m_objSerialPort.ReadByte().Equals(null)) ;
                sleep = 500;
                while (true)
                {
                    Thread.Sleep(sleep);
                    string sRouteData1 = m_objSerialPort.ReadExisting();
                    if (sRouteData1.Equals(""))
                        break;
                    objCompleteData.Append(sRouteData1);
                    sleep = 0;
                }
                sFinalRoute = Convert.ToString(objCompleteData);
                m_sarrData = sFinalRoute.Split(new char[] { '\x1f' });
                treeLength = m_sarrData.Length;
                string ff = "\x04";
                m_objSerialPort.Write(ff);
                FillRoutesCombo(m_sarrData);

            }
            catch { }
        }

        int treeLength;
        public string[] Routename = null;
        public StringBuilder sblRtNumbers = null;
        public void FillRoutesCombo(string[] m_sarrData)
        {
            sblRtNumbers = new StringBuilder();
            string first = null;
            string next = null;
            try
            {
                if (checkbool == "true")
                {
                    for (int iNewTest = 1; iNewTest <= (m_sarrData.Length - 2); iNewTest += 3)
                    {
                        sblRtNumbers.Append(m_sarrData[iNewTest]);
                        sblRtNumbers.Append("|");
                        sblRtNumbers.Append(m_sarrData[iNewTest + 1]);
                        sblRtNumbers.Append(",");
                    }
                }
                else
                {
                    int aa = 1;//00000601060000
                    try
                    {
                        string[] aa1 = m_sarrData[1].Split('1');
                        if (aa1[1] == "060000" || aa1[2] == "060000")
                        {
                            aa = 2;
                        }
                    }
                    catch { }
                    for (int iNewTest = aa; iNewTest <= (m_sarrData.Length - 3); iNewTest += 3)
                    {
                        sblRtNumbers.Append(m_sarrData[iNewTest]);
                        sblRtNumbers.Append("|");
                        sblRtNumbers.Append(m_sarrData[iNewTest + 1]);
                        sblRtNumbers.Append(",");
                    }
                }
                RouteNumbers = Convert.ToString(sblRtNumbers);
                Routename = RouteNumbers.Split(',');
                for (int a = 0; a < Routename.Length - 1; a++)
                {
                    string[] Routename1 = Convert.ToString(Routename[a]).Split('|');
                    string abc = Routename1[0];
                }
                treeLength = Routename.Length - 1;
            }
            catch { }
        }


        private string DeciamlToHexadeciaml1(int number)
        {
            string[] hexvalues = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            string result = null, final = null;
            int rem = 0;
            try
            {
                while (true)
                {
                    rem = (number % 16);
                    result += hexvalues[rem].ToString();
                    if (number < 16)
                        break;
                    //result += ',';
                    number = (number / 16);
                }

                //for (int i = 0; i <= (result.Length - 1); i++)
                //{
                for (int i = (result.Length - 1); i >= 0; i--)
                {
                    final += result[i];
                }
            }
            catch
            {
            }
            return final;
        }

        private string DeciamlToHexadeciaml(int number)
        {
            string[] hexvalues = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            string result = null, final = null;
            int rem = 0, div = 0;
            try
            {
                while (true)
                {
                    rem = (number % 16);
                    result += hexvalues[rem].ToString();

                    if (number < 16)
                        break;
                    result += ',';
                    number = (number / 16);
                }
                for (int i = (result.Length - 1); i >= 0; i--)
                {
                    final += result[i];
                }
            }
            catch { }
            return final;
        }
        private int findVal(string value)
        {
            int Ans = 0;
            try
            {
                switch (value)
                {
                    case "A":
                        Ans = 65;
                        break;
                    case "B":
                        Ans = 66;
                        break;
                    case "C":
                        Ans = 67;
                        break;
                    case "D":
                        Ans = 68;
                        break;
                    case "E":
                        Ans = 69;
                        break;
                    case "F":
                        Ans = 70;
                        break;
                    case "G":
                        Ans = 71;
                        break;
                    case "H":
                        Ans = 72;
                        break;
                    case "I":
                        Ans = 73;
                        break;
                    case "J":
                        Ans = 74;
                        break;
                    case "K":
                        Ans = 75;
                        break;
                    case "L":
                        Ans = 76;
                        break;
                    case "M":
                        Ans = 77;
                        break;
                    case "N":
                        Ans = 78;
                        break;
                    case "O":
                        Ans = 79;
                        break;
                    case "P":
                        Ans = 80;
                        break;
                    case "Q":
                        Ans = 81;
                        break;
                    case "R":
                        Ans = 82;
                        break;
                    case "S":
                        Ans = 83;
                        break;
                    case "T":
                        Ans = 84;
                        break;
                    case "U":
                        Ans = 85;
                        break;
                    case "V":
                        Ans = 86;
                        break;
                    case "W":
                        Ans = 87;
                        break;
                    case "X":
                        Ans = 88;
                        break;
                    case "Y":
                        Ans = 89;
                        break;
                    case "Z":
                        Ans = 90;
                        break;
                    case "0":
                        Ans = 48;
                        break;
                    case "1":
                        Ans = 49;
                        break;
                    case "2":
                        Ans = 50;
                        break;
                    case "3":
                        Ans = 51;
                        break;
                    case "4":
                        Ans = 52;
                        break;
                    case "5":
                        Ans = 53;
                        break;
                    case "6":
                        Ans = 54;
                        break;
                    case "7":
                        Ans = 55;
                        break;
                    case "8":
                        Ans = 56;
                        break;
                    case "9":
                        Ans = 57;
                        break;
                }
            }
            catch { }
            return Ans;
        }

        private string m_sCompleteData = null;
        public string checkbool = null; string path = Path.GetTempPath(); public bool dataDown = false; string Direct = null;
        public void Directdownload(string Dbname, int SelectedIndex)
        {
            try
            {
                string SelectedVals = sPathtosave;
                byte[] arrTour = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x52, 0x46, 0x63, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x74, 0x6F, 0x75, 0x72 };
                byte[] arrTourEnd = { 0x5C, 0x63, 0x74, 0x72, 0x6C, 0x2E, 0x63, 0x66, 0x67, 0x03 };
                byte[] arrQues = { 0x06, 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x52, 0x46, 0x63, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x74, 0x6F, 0x75, 0x72 };
                byte[] arrQuesEnd = { 0x5C, 0x74, 0x6F, 0x75, 0x72, 0x64, 0x61, 0x74, 0x61, 0x2E, 0x64, 0x61, 0x74, 0x03 };
                byte[] arrQuesEndOFF = { 0x5C, 0x6F, 0x66, 0x66, 0x74, 0x64, 0x61, 0x74, 0x61, 0x2E, 0x64, 0x61, 0x74, 0x03 };
                byte[] arrQuesEndHist = { 0x5C, 0x68, 0x69, 0x73, 0x74, 0x64, 0x61, 0x74, 0x61, 0x2E, 0x64, 0x61, 0x74, 0x03 };
                StringBuilder sbObjBuilder = new StringBuilder();
                int iPacketNumber = -1;
                try
                {
                    if (PublicClass.currentInstrument == "SKF/DI")
                    {
                        int length = 0;
                        int length1 = 0;
                        int count = SelectedIndex + 1;
                        int CountHigh = count / 10;
                        int CountLow = count % 10;
                        byte btThirty = 0x30;
                        byte CountHighConv = Convert.ToByte(btThirty + CountHigh);
                        byte CountLowConv = Convert.ToByte(btThirty + CountLow);
                        byte[] middleBoth1 = new byte[1];
                        byte[] middleBoth2 = new byte[1];
                        middleBoth1[0] = CountHighConv;
                        middleBoth2[0] = CountLowConv;
                        if (CountHigh == 0)
                        {
                            byte[] lastOne = new byte[1];
                            byte[] lastSec = new byte[1];
                            if (CountLow <= 2)
                                lastSec[0] = Convert.ToByte(0x37 + CountLow);
                            if (CountLow > 2)
                                lastSec[0] = Convert.ToByte(0x40 + (CountLow - 2));
                            lastOne[0] = 0x32;
                            if (lastSec[0] > 0x46)
                            {
                                lastSec[0] = 0x30;
                                lastOne[0] = 0x33;
                            }
                            int checkSUM = 0;
                            string Chksum = null;
                            string[] chkarray = null;
                            for (int i = 1; i < arrTour.Length; i++)
                            {
                                checkSUM += Convert.ToInt32(arrTour[i]);
                            }
                            for (int i = 0; i < middleBoth2.Length; i++)
                            {
                                checkSUM += Convert.ToInt32(middleBoth2[i]);
                            }
                            for (int i = 0; i < arrTourEnd.Length; i++)
                            {
                                checkSUM += Convert.ToInt32(arrTourEnd[i]);
                            }
                            checkSUM = checkSUM % 128;
                            Chksum = DeciamlToHexadeciaml(checkSUM);
                            chkarray = Chksum.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            if (chkarray.Length > 1)
                            {
                                lastOne = new byte[1];
                                lastOne[0] = Convert.ToByte(findVal(chkarray[0].ToString()));
                                lastSec = new byte[1];
                                lastSec[0] = Convert.ToByte(findVal(chkarray[1].ToString()));
                            }
                            else
                            {
                                lastOne = new byte[1];
                                lastOne[0] = Convert.ToByte(0);
                                lastSec = new byte[1];
                                lastSec[0] = Convert.ToByte(findVal(chkarray[0].ToString()));
                            }
                            m_objSerialPort.Write(arrTour, 0, arrTour.Length);//Sending First Question 
                            m_objSerialPort.Write(middleBoth2, 0, middleBoth2.Length);//Sending Route no
                            m_objSerialPort.Write(arrTourEnd, 0, arrTourEnd.Length);//Sending Second Part Of First Question
                            m_objSerialPort.Write(lastOne, 0, lastOne.Length);//Sending Last Byte
                            m_objSerialPort.Write(lastSec, 0, lastSec.Length);//Sending Last Byte


                            while (m_objSerialPort.ReadByte().Equals(null)) ;//Checking data on port

                            while (true)
                            {
                                Thread.Sleep(400);
                                string sAnss = m_objSerialPort.ReadExisting();//Recieving Data
                                if (sAnss.Equals(""))
                                    break;
                                string sFinalAnss = sAnss;
                            }
                            m_objSerialPort.Write(SHEXSIX);// Sending 06
                            while (m_objSerialPort.ReadByte().Equals(null)) ;//Checking Data On Port

                            byte sFinalFour1 = 0x04;
                            if (sFinalFour1 == 0x04)
                            {
                                byte[] last1 = new byte[1];
                                last1[0] = 0x36;
                                byte[] last2 = new byte[1];
                                byte[] Parameter = new byte[1];
                                Parameter[0] = 0x01;
                                last2[0] = Convert.ToByte(middleBoth2[0] - Parameter[0]);


                                checkSUM = 0;
                                Chksum = null;
                                for (int i = 2; i < arrQues.Length; i++)
                                {
                                    checkSUM += Convert.ToInt32(arrQues[i]);
                                }
                                for (int i = 0; i < middleBoth2.Length; i++)
                                {
                                    checkSUM += Convert.ToInt32(middleBoth2[i]);
                                }
                                for (int i = 0; i < arrQuesEnd.Length; i++)
                                {
                                    checkSUM += Convert.ToInt32(arrQuesEnd[i]);
                                }
                                checkSUM = checkSUM % 128;
                                Chksum = DeciamlToHexadeciaml(checkSUM);
                                chkarray = Chksum.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                if (chkarray.Length > 1)
                                {
                                    last1 = new byte[1];
                                    last1[0] = Convert.ToByte(findVal(chkarray[0].ToString()));
                                    last2 = new byte[1];
                                    last2[0] = Convert.ToByte(findVal(chkarray[1].ToString()));
                                }
                                else
                                {
                                    last1 = new byte[1];
                                    last1[0] = Convert.ToByte(0);
                                    last2 = new byte[1];
                                    last2[0] = Convert.ToByte(findVal(chkarray[0].ToString()));

                                }

                                m_objSerialPort.Write(arrQues, 0, arrQues.Length);//Sending Question 2
                                m_objSerialPort.Write(middleBoth2, 0, middleBoth2.Length);//Sending Route no
                                m_objSerialPort.Write(arrQuesEnd, 0, arrQuesEnd.Length);//Sending Second Part Of Question 2
                                m_objSerialPort.Write(last1, 0, last1.Length);//Sending Last Byte
                                m_objSerialPort.Write(last2, 0, last2.Length);//Sending Last byte
                            }
                            while (m_objSerialPort.ReadByte().Equals(null)) ;
                            do
                            {
                                byte[] objGetBytes = null;
                                iPacketNumber++;
                                Thread.Sleep(400);
                                objGetBytes = new byte[m_objSerialPort.BytesToRead];
                                m_objSerialPort.Read(objGetBytes, 0, objGetBytes.Length);
                                //Array.Resize(ref objGetBytesFinal, (objGetBytes.Length + (length1 * 2065)));
                                if (length1 == 0)
                                    Array.Resize(ref objGetBytesFinal, (objGetBytes.Length + (length1 * 2065)));//Sizing The Final Byte Array according to the no of recieved bytes
                                else
                                    Array.Resize(ref objGetBytesFinal, (objGetBytes.Length + objGetBytesFinal.Length));

                                for (int aa = 0; aa < objGetBytes.Length; aa++)
                                {
                                    objGetBytesFinal[length] = objGetBytes[aa];
                                    length++;
                                }
                                length1++;
                                arrLoopBreak[0] = NewDataSync();
                                for (int kk = 0; kk < 4; kk++)
                                {
                                    Array.Resize(ref objGetBytesFinal, 1 + objGetBytesFinal.Length);
                                    objGetBytesFinal[length] = 0;
                                    length++;
                                }

                                //-------same database download----------//
                                if (dataDown == true)
                                {
                                    if (Direct == "true")
                                    {
                                        if (File.Exists(Directpath))
                                        {
                                            File.Delete(Directpath);
                                        }
                                        byte[] TourData = MakeTourDatafrombytearray(objGetBytesFinal);
                                        using (FileStream objStream = new FileStream(Directpath, FileMode.Create, FileAccess.Write))
                                        {
                                            objStream.Write(TourData, 0, TourData.Length);
                                        }
                                    }
                                    else
                                    {
                                        if (arrLoopBreak[0] == 4)
                                            DataRecieved(PublicClass.RouteId);
                                        ValForBar = length1;
                                    }
                                }

                                else if (arrLoopBreak[0] == 4)
                                {
                                    if (File.Exists(path + "Tour.dat"))
                                    {
                                        File.Delete(path + "Tour.dat");
                                    }
                                    byte[] TourData = MakeTourDatafrombytearray(objGetBytesFinal);
                                    using (FileStream objStream = new FileStream(path + "Tour.dat", FileMode.Create, FileAccess.Write))
                                    {
                                        objStream.Write(TourData, 0, TourData.Length);
                                    }
                                }
                            } while (arrLoopBreak[0] != 4);
                            if (dataDown != true)
                            {
                                GenerateNewRouteFromFile(path + "Tour.dat");
                                string[] sTest = sbObjBuilder.ToString().Split(new string[] { "\x58\x02", "\x1b\x04" }, StringSplitOptions.None);
                                checkbool = "true";
                            }
                        }
                        if (CountHigh > 0)
                        {
                            byte[] FirQuesLast1 = new byte[1];
                            FirQuesLast1[0] = 0x35;
                            if (CountLow >= 8)
                                FirQuesLast1[0] = 0x36;
                            byte[] FirQuesLast2 = { 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x30, 0x31 };
                            byte[] SecQuesLast2 = { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39 };
                            int CountLow1 = CountLow;
                            if (CountHigh > 1)
                                CountLow1 = CountLow + 1;


                            byte[] pass1 = new byte[1];
                            pass1[0] = FirQuesLast2[CountLow1];
                            byte[] pass2 = new byte[1];
                            pass2[0] = SecQuesLast2[CountLow];
                            if (CountHigh > 1)
                                pass2[0] = SecQuesLast2[CountLow + 1];


                            m_objSerialPort.Write(arrTour, 0, arrTour.Length);//Sending Question 1
                            m_objSerialPort.Write(middleBoth1, 0, middleBoth1.Length);//Sending Route no
                            m_objSerialPort.Write(middleBoth2, 0, middleBoth2.Length);//Sending Route no
                            m_objSerialPort.Write(arrTourEnd, 0, arrTourEnd.Length);//Sending second part of question 1
                            m_objSerialPort.Write(FirQuesLast1, 0, FirQuesLast1.Length);//Sending End Byte of Question 1
                            m_objSerialPort.Write(pass1, 0, pass1.Length);//Sending End Byte Of Question 1


                            while (m_objSerialPort.ReadByte().Equals(null)) ;//Checking data on Ports

                            while (true)
                            {
                                Thread.Sleep(400);
                                string sAnss = m_objSerialPort.ReadExisting();//Reciving data
                                if (sAnss.Equals(""))
                                    break;
                                string sFinalAnss = sAnss;
                            }//end(while (true))

                            m_objSerialPort.Write(SHEXSIX);//Sending 05
                            while (m_objSerialPort.ReadByte().Equals(null)) ;//Checking Data on the Port

                            byte FourRecieve = 0x04;
                            if (FourRecieve == 0x04)
                            {
                                byte[] last1 = new byte[1];
                                last1[0] = 0x36;
                                byte[] last2 = new byte[1];
                                last2[0] = Convert.ToByte(middleBoth2[0] - 0x01);

                                m_objSerialPort.Write(arrQues, 0, arrQues.Length);//Sending Question 2
                                m_objSerialPort.Write(middleBoth1, 0, middleBoth1.Length);//Sending Route no
                                m_objSerialPort.Write(middleBoth2, 0, middleBoth2.Length);//Sending Route no
                                m_objSerialPort.Write(arrQuesEnd, 0, arrQuesEnd.Length);//Sending Second Part Of Question 2
                                m_objSerialPort.Write("\x31");
                                m_objSerialPort.Write(pass2, 0, pass2.Length);//Sending Last Byte Of Question 2
                            }

                            byte[] arrLoopBreak = new byte[1];
                            while (m_objSerialPort.ReadByte().Equals(null)) ;//Checking Presence of Data On the Port
                            do
                            {
                                byte[] objGetBytes = null;
                                iPacketNumber++;
                                Thread.Sleep(400);
                                objGetBytes = new byte[m_objSerialPort.BytesToRead];//Checking the no Of bytes to read
                                m_objSerialPort.Read(objGetBytes, 0, objGetBytes.Length);//Reading Bytes From The Port                                
                                Array.Resize(ref objGetBytesFinal, (objGetBytes.Length + (length1 * 2065)));//Resizing the final array according to the read bytes
                                for (int aa = 0; aa < objGetBytes.Length; aa++)
                                {
                                    objGetBytesFinal[length] = objGetBytes[aa];
                                    length++;
                                }
                                length1++;

                                arrLoopBreak[0] = NewDataSync();
                                for (int kk = 0; kk < 4; kk++)
                                {
                                    Array.Resize(ref objGetBytesFinal, 1 + objGetBytesFinal.Length);
                                    objGetBytesFinal[length] = 0;

                                    length++;
                                }
                                if (arrLoopBreak[0] == 4)
                                    DataRecieved(PublicClass.RouteId);//Calling Function For Sorting Data From the recieved bytes
                                ValForBar = length1;
                            } while (arrLoopBreak[0] != 4);

                            m_sCompleteData = sbObjBuilder.ToString();
                            string[] sTest = sbObjBuilder.ToString().Split(new string[] { "\x58\x02", "\x1b\x04" }, StringSplitOptions.None);
                        }
                    }
                    // m_objSerialPort.Close();
                }
                catch { }
            }
            catch
            { }
        }

        public void GenerateNewRouteFromFile(string FilePath)
        {
            try
            {
                using (FileStream objInput = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] MainArr = new byte[(int)objInput.Length];
                    int contents = objInput.Read(MainArr, 0, (int)objInput.Length);
                    ExtractOffDataDiForUsb(MainArr);
                }
            }
            catch { }
        }

        bool checkdata = false;
        private void DataRecieved(string ArrayForFac)
        {
            string anotherid = null;
            byte[] MainArr = MakeTourDatafrombytearray(objGetBytesFinal);
            ValForBar = 0;
            double[] FactorUMMS = { 200, 100, 50, 20, 10, 5, 2, 1 };
            double[] FactorUMIL = { 50, 25, 10, 5, 2.5, 1 };
            double[] FactorInspection = { 1000, 1000, 200, 200, 10, 10 };
            double[] LimitIPS = { 20, 10, 5, 2, 1, .5, .2, .1, .05, .02, .01, .005, .002, .001 };
            double[] LimitMMS = { 500, 250, 125, 50, 25, 12.5, 5, 2.5, 1.25, .5, .25, .125, .05, .025 };
            double[] LimitMIL = { 100, 50, 20, 10, 5, 2, 1, .5, .2, .1, .05, .02 };
            double[] LimitUM = { 2500, 1250, 500, 250, 125, 50, 25, 12.5, 5, 2.5, 1.25, 0.5 };
            double[] LimitG = { 100, 50, 20, 10, 5, 2, 1, .5, .2, .1, .05, .02, .01, .005, .002, .001 };
            double[] LimitVolt = { 10, 5, 2, 1, .5, .2, .1, .05, .02, .01, .005, 20, 50 };
            double[] LimitInspection = { 100000, 10000, 1000, 100, 10, 1, .1, .01, .001 };
            double[] LimitRPM = { 100000, 50000, 10000, 5000, 1000, 500, 100, 50, 10, 5, 1 };
            double[] FreqArray = { 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 40000, 25 };
            double[] ResolutionFFT = { 100, 200, 400, 800, 1600, 3200, 6400 };
            double[] ResolutionTime = { 256, 512, 1024, 2048, 4096, 8192, 16384 };
            string PreviousFacName = null;
            string PreviousEqupname = null;
            string PreviousComname = null;
            string PreviousSubCompname = null;
            string PreviousPointName = null;
            bool SamePointDifferentChannel = false;
            byte[] arrComponent = new byte[16];
            string ComponentName = null;
            byte[] arrSubComponent = new byte[16];
            string PointName = null;
            byte[] arrSubComponent1 = new byte[16];
            string SubCmpName = null;
            byte[] arrType = new byte[16];

            string EquipmentName = null;
            byte[] arrEquipmentArr = new byte[16];

            int lCounter = 0;
            int Ctr = 0;
            bool Breaker = false;
            int bbr = 0;
            int dtCtr = 0;


            bool tobreak = false;
            bool NewArray = true;
            double LimitVal = 0.0;
            string PointDate = null;
            string PointMonth = null;
            string PointYear = null;
            string PointHour = null;
            string PointMinute = null;
            string PointSecond = null;
            bool DateFound = false;
            byte[] NameExtracter = new byte[17];
            int iFScale = 0;
            string sUnit = null;
            int CtrToStart = 0;
            string sPointDescription = null;
            try
            {
                do
                {
                    int startZero = 0; int dtfCtr = 0; string[] Parameters = null;
                    double CalculatedFullScale = 0;
                    double key = 0.0;
                    double OriginalFac = 0.0;
                    double[] DataFinal = new double[1];
                    byte[] Data = new byte[1];
                    double[] Xvalues = null;
                    tobreak = false;
                    int Factor = 0;
                    int KeyFactor = 0;
                    bool AckGetBt = false;
                    try
                    {
                        do
                        {
                            if (MainArr[CtrToStart] == 0x58 && MainArr[CtrToStart + 1] == 0x02 && MainArr[CtrToStart + 2] == 0x06 && MainArr[CtrToStart + 3] == 0x01)
                            {
                                dualChnl = 0;
                                iWin = 0;
                                iLor = 0;
                                iFScale = 0;
                                iUnit = 0;
                                iMesure = 0;
                                iFltrType = 0;
                                iFltrVal = 0;
                                iFreq = 0;
                                idetc = 0;
                                bmesure = false;
                                string sCT = null;
                                int newCtr = CtrToStart + 4;
                                byte[] fs = new byte[1];

                                fs[0] = MainArr[newCtr];
                                string fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                string[] fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                                if (fsvalacc.Length > 1)
                                {
                                    sCT = (fsvalacc[0].ToString());
                                }
                                else
                                {
                                    sCT = (fsvalacc[0].ToString());
                                }
                                newCtr = CtrToStart + 10;
                                string SFH = null;
                                for (int i = newCtr, j = 0; j < 5; i++, j++)
                                {

                                    if (j == 4)
                                    {
                                        if (MainArr[i].ToString() == "32")
                                        {
                                            if (SFH == "2000")
                                            {
                                                dualChnl = 0;
                                            }
                                            else
                                            {
                                                dualChnl = 1;
                                            }
                                        }
                                        else
                                        {
                                            dualChnl = 0;
                                        }
                                    }
                                    SFH += MainArr[i].ToString();
                                }
                                CtrToStart = CtrToStart + 15;
                                while (true)
                                {
                                    if (MainArr[CtrToStart].ToString() == "0")
                                    {
                                        CtrToStart++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                for (int NmCtr = 0; NmCtr < 17; NmCtr++)
                                {
                                    NameExtracter[NmCtr] = MainArr[CtrToStart];
                                    CtrToStart++;
                                }
                                ComponentName = Encoding.ASCII.GetString(NameExtracter);
                                ComponentName = ComponentName.Trim(new char[] { '\0' });
                                NameExtracter = new byte[17];
                                for (int NmCtr = 0; NmCtr < 17; NmCtr++)
                                {
                                    NameExtracter[NmCtr] = MainArr[CtrToStart];
                                    CtrToStart++;
                                }
                                PointName = Encoding.ASCII.GetString(NameExtracter);
                                PointName = PointName.Trim(new char[] { '\0' });
                                NameExtracter = new byte[17];
                                for (int NmCtr = 0; NmCtr < 17; NmCtr++)
                                {
                                    NameExtracter[NmCtr] = MainArr[CtrToStart];
                                    CtrToStart++;
                                }
                                FinalPointName = PointName;
                                SubCmpName = Encoding.ASCII.GetString(NameExtracter);
                                SubCmpName = SubCmpName.Trim(new char[] { '\0' });
                                NameExtracter = new byte[17];
                                for (int NmCtr = 0; NmCtr < 17; NmCtr++)
                                {
                                    NameExtracter[NmCtr] = MainArr[CtrToStart];
                                    CtrToStart++;
                                }
                                sPointDescription = Encoding.ASCII.GetString(NameExtracter);
                                sPointDescription = sPointDescription.Trim(new char[] { '\0' });
                                NameExtracter = new byte[17];
                                AckGetBt = true;
                                bool ResFound = false;
                                int OverallFactor = 0;
                                int MaxToLook = 0;
                                int MaxToLookForFF = 0;
                                overalFound = false;
                                sUnit = null;
                                newCtr = CtrToStart + 21;
                                fs = new byte[2];
                                fs[1] = MainArr[newCtr];
                                fs[0] = MainArr[newCtr + 1];
                                fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                string fsval1 = DeciamlToHexadeciaml(Convert.ToInt32(fs[1].ToString()));
                                fsvalacc = fsval1.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                string[] fsvalacc1 = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                if (fsvalacc1.Length > 1)
                                {
                                    sUnit += (fsvalacc1[1].ToString());
                                }
                                else
                                {
                                    sUnit += (fsvalacc1[0].ToString());
                                }
                                if (fsvalacc.Length > 1)
                                {
                                    sUnit += (fsvalacc[0].ToString());
                                    iFScale = Convert.ToInt32(fsvalacc[1].ToString());
                                }
                                else
                                {
                                    try
                                    {
                                        iFScale = Convert.ToInt32(fsvalacc[0].ToString());
                                    }
                                    catch
                                    {
                                        iFScale = Convert.ToInt32(HexadecimaltoDecimal(fsvalacc[0].ToString()));
                                    }
                                }

                                iUnit = Convert.ToInt32(sUnit);
                                switch (iUnit)
                                {
                                    case 0:
                                        {//accel(G)
                                            iUnit = 0;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitG[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;
                                        }
                                    case 1:
                                        {//A -> V (IPS)
                                            iUnit = 1;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitIPS[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;
                                        }
                                    case 11:
                                        {//A -> V (MM/S)
                                            iUnit = 2;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitMMS[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;
                                        }
                                    case 2:
                                        {//VEL (IPS)
                                            iUnit = 5;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitIPS[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;
                                        }
                                    case 21:
                                        {//VEL (MM/S)
                                            iUnit = 6;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitMMS[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;

                                        }
                                    case 3:
                                        {//A -> D (MILS)
                                            iUnit = 3;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitMIL[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;
                                        }
                                    case 31:
                                        {//A -> D (UM)
                                            iUnit = 4;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitUM[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;
                                        }
                                    case 4:
                                        {//V -> D (MILS)
                                            iUnit = 7;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitMIL[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;
                                        }
                                    case 41:
                                        {//V -> D (UM)
                                            iUnit = 8;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitUM[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;
                                        }
                                    case 5:
                                        {//DISP (MILS)
                                            iUnit = 9;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitMIL[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;
                                        }
                                    case 51:
                                        {//DISP (UM)
                                            iUnit = 10;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitUM[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;
                                        }
                                    case 9:
                                        {//esp
                                            iUnit = 11;
                                            break;
                                        }
                                    case 6:
                                        {//volt
                                            iUnit = 12;
                                            try
                                            {
                                                CalculatedFullScale = (double)LimitVolt[iFScale];
                                            }
                                            catch
                                            {
                                                CalculatedFullScale = iFScale;
                                            }
                                            break;
                                        }
                                    case 8:
                                        {//RPM
                                            iUnit = 13;
                                            break;
                                        }
                                }

                                string sFT = null;
                                string sFV = null;
                                fs = new byte[2];
                                fs[0] = MainArr[newCtr + 2];
                                fs[1] = MainArr[newCtr + 3];
                                fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                fsval1 = DeciamlToHexadeciaml(Convert.ToInt32(fs[1].ToString()));
                                fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                fsvalacc1 = fsval1.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                if (fsvalacc.Length > 1)
                                {
                                    for (int i = 0; i < fsvalacc.Length; i++)
                                    {
                                        sFT = sFT + fsvalacc[i].ToString();
                                    }
                                }
                                else
                                {
                                    sFT = fsvalacc[0].ToString();
                                }

                                if (fsvalacc1.Length > 1)
                                {
                                    for (int i = 0; i < fsvalacc1.Length; i++)
                                    {
                                        sFV = sFV + fsvalacc1[i].ToString();
                                    }
                                }
                                else
                                {
                                    sFV = fsvalacc1[0].ToString();
                                }

                                if (sFT == "80")
                                {
                                    if (sFV == "8")
                                    {
                                        iFltrVal = 1;
                                        iFltrType = 2;
                                    }
                                    else if (sFV == "4")
                                    {
                                        iFltrVal = 4; iFltrType = 1;
                                    }
                                    else if (sFV == "5")
                                    {
                                        iFltrVal = 6; iFltrType = 1;
                                    }
                                    else if (sFV == "C")
                                    {
                                        iFltrVal = 4; iFltrType = 3;
                                    }
                                    else if (sFV == "D")
                                    {
                                        iFltrVal = 6;
                                        iFltrType = 3;
                                    }
                                }
                                else if (sFT == "0")
                                {
                                    if (sFV == "8")
                                    {
                                        iFltrVal = 0;
                                        iFltrType = 2;
                                    }
                                    else if (sFV == "9")
                                    {
                                        iFltrVal = 2;
                                        iFltrType = 2;
                                    }
                                    else if (sFV == "4")
                                    {
                                        iFltrVal = 2;
                                        iFltrType = 1;
                                    }
                                    else if (sFV == "5")
                                    {
                                        iFltrVal = 5;
                                        iFltrType = 1;
                                    }
                                    else if (sFV == "6")
                                    {
                                        iFltrVal = 7;
                                        iFltrType = 1;
                                    }
                                    else if (sFV == "C")
                                    {
                                        iFltrVal = 2;
                                        iFltrType = 3;
                                    }
                                    else if (sFV == "D")
                                    {
                                        iFltrVal = 5;
                                        iFltrType = 3;
                                    }
                                    else if (sFV == "E")
                                    {
                                        iFltrVal = 7;
                                        iFltrType = 3;
                                    }
                                    else if (sFV == "0")
                                    {
                                        iFltrVal = 0;
                                        iFltrType = 0;
                                        iMesure = 0;
                                    }
                                }
                                else
                                {
                                    if (sFV == "0")
                                    {
                                        iCpl = Convert.ToInt32(fsvalacc[0].ToString());
                                    }
                                }
                                do
                                {
                                    if ((MainArr[CtrToStart] == 0x3F && MainArr[CtrToStart - 1] == 0x3F && MainArr[CtrToStart - 2] == 0x3F && MainArr[CtrToStart - 3] == 0x3F && MainArr[CtrToStart - 4] == 0x3F && MainArr[CtrToStart - 5] == 0x3F) || (MainArr[CtrToStart] == 0xFF && MainArr[CtrToStart - 1] == 0xFF && MainArr[CtrToStart - 2] == 0xFF && MainArr[CtrToStart - 3] == 0xFF && MainArr[CtrToStart - 4] == 0xFF && MainArr[CtrToStart - 5] == 0xFF))
                                    {
                                        newCtr = CtrToStart - 7;
                                        fs = new byte[2];
                                        fs[0] = MainArr[newCtr];
                                        fs[1] = MainArr[newCtr + 1];
                                        fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                        fsval1 = DeciamlToHexadeciaml(Convert.ToInt32(fs[1].ToString()));
                                        fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        if (fsvalacc.Length > 1)
                                        {
                                            iMesure = Convert.ToInt32(fsvalacc[1].ToString());
                                        }
                                        else
                                        {
                                            iMesure = Convert.ToInt32(fsvalacc[0].ToString());
                                        }
                                        newCtr = CtrToStart + 4;
                                        fs = new byte[1];
                                        fs[0] = MainArr[newCtr];

                                        fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                        fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        if (fsvalacc.Length > 1)
                                        {
                                            idetc = Convert.ToInt32(fsvalacc[1].ToString());
                                        }
                                        else
                                        {
                                            idetc = Convert.ToInt32(fsvalacc[0].ToString());
                                        }

                                        try
                                        {
                                            newCtr = CtrToStart + 18;
                                            PointSecond = Convert.ToString(MainArr[newCtr]);
                                            PointMinute = Convert.ToString(MainArr[newCtr + 1]);
                                            PointHour = Convert.ToString(MainArr[newCtr + 2]);
                                            PointDate = Convert.ToString(MainArr[newCtr + 3]);
                                            PointMonth = Convert.ToString(MainArr[newCtr + 4]);
                                            PointYear = Convert.ToString(MainArr[newCtr + 5]);
                                            PointYear = Convert.ToString((Convert.ToInt16(PointYear)) + 1900);
                                            PointMonth += "/" + PointDate + "/" + PointYear + " " + PointHour + ":" + PointMinute + ":" + PointSecond;
                                            DateFound = true;
                                        }
                                        catch (Exception eee)
                                        {
                                            DateFound = false;
                                        }


                                        KeyFactor = CtrToStart - 11;
                                        if (MainArr[KeyFactor - 12] != 0x1b)
                                        {
                                            try
                                            {
                                                Factor = Convert.ToInt16(DeciamlToHexadeciaml1(MainArr[KeyFactor]));
                                            }
                                            catch
                                            {
                                                Factor = Convert.ToInt16(MainArr[KeyFactor]);
                                            }
                                        }
                                        else
                                            Factor = 0;
                                        Factor = Factor % 10;

                                        OverallFactor = CtrToStart + 7;

                                        OverallValueDecoded = 0.0;
                                        do
                                        {
                                            if (MainArr[OverallFactor] != 0x00)
                                            {
                                                OverallValueDecoded = ((MainArr[OverallFactor + 1] * 256 + MainArr[OverallFactor]));
                                                int xx = ((short)MainArr[OverallFactor]) << 8 + MainArr[OverallFactor + 1];

                                                overalFound = true;
                                            }
                                            else if (MainArr[OverallFactor] == 0x00)
                                            {
                                                OverallValueDecoded = (MainArr[OverallFactor + 1]);
                                                int xx = ((short)MainArr[OverallFactor]) << 8 + MainArr[OverallFactor + 1];

                                                overalFound = true;
                                            }
                                        } while (overalFound == false);

                                        newCtr = CtrToStart + 31;
                                        fs = new byte[1];
                                        fs[0] = MainArr[newCtr];

                                        fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                        fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        string sLor = null;
                                        if (fsvalacc.Length > 1)
                                        {
                                            for (int i = 0; i < fsvalacc.Length; i++)
                                            {
                                                sLor = sLor + fsvalacc[i].ToString();
                                            }
                                        }
                                        else
                                        {
                                            sLor = fsvalacc[0].ToString();
                                        }
                                        iLor = Convert.ToInt32(sLor);
                                        if (iLor > 6)
                                        {
                                            iLor = 0;
                                        }
                                        switch (iLor)
                                        {
                                            case 0:
                                                {
                                                    iLor = 2;
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    iLor = 0;
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    iLor = 1;
                                                    break;
                                                }
                                        }
                                        newCtr++;
                                        fs = new byte[2];
                                        fs[0] = MainArr[newCtr];
                                        fs[1] = MainArr[newCtr + 2];
                                        fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                        fsval1 = DeciamlToHexadeciaml(Convert.ToInt32(fs[1].ToString()));
                                        fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        fsvalacc1 = fsval1.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        string win = null;
                                        string frq = null;

                                        if (fsvalacc.Length > 1)
                                        {
                                            for (int i = 0; i < fsvalacc.Length; i++)
                                            {
                                                win = win + fsvalacc[i].ToString();
                                            }
                                        }
                                        else
                                        {
                                            win = fsvalacc[0].ToString();
                                        }

                                        if (fsvalacc1.Length > 1)
                                        {
                                            for (int i = 0; i < fsvalacc1.Length; i++)
                                            {
                                                frq = frq + fsvalacc1[i].ToString();
                                            }
                                        }
                                        else
                                        {
                                            frq = fsvalacc1[0].ToString();
                                        }

                                        try
                                        {
                                            iWin = Convert.ToInt32(win);
                                            iFreq = Convert.ToInt32(frq);
                                        }
                                        catch
                                        {
                                            iFreq = 3;
                                        }
                                        if (iFreq > 9)
                                        {
                                            iFreq = 3;
                                        }

                                        CtrToStart = CtrToStart + 57;
                                        for (int NmCtr = 0; NmCtr < 17; NmCtr++)
                                        {
                                            if ((MainArr[CtrToStart] < 58 && MainArr[CtrToStart] > 47) || (MainArr[CtrToStart] < 91 && MainArr[CtrToStart] > 64) || (MainArr[CtrToStart] < 123 && MainArr[CtrToStart] > 96))
                                                NameExtracter[NmCtr] = MainArr[CtrToStart];
                                            CtrToStart++;
                                        }
                                        ResFound = true;
                                        EquipmentName = Encoding.ASCII.GetString(NameExtracter);
                                        EquipmentName = EquipmentName.Trim(new char[] { '\0' });

                                        try
                                        {
                                            newCtr = CtrToStart;
                                            do
                                            {
                                                if (MainArr[newCtr + 5] == 0x6c || MainArr[newCtr + 5] == 0x6d)
                                                {
                                                    PointSecond = Convert.ToString(MainArr[newCtr]);
                                                    PointMinute = Convert.ToString(MainArr[newCtr + 1]);
                                                    PointHour = Convert.ToString(MainArr[newCtr + 2]);
                                                    PointDate = Convert.ToString(MainArr[newCtr + 3]);
                                                    PointMonth = Convert.ToString(MainArr[newCtr + 4]);
                                                    PointYear = Convert.ToString(MainArr[newCtr + 5]);
                                                    PointYear = Convert.ToString((Convert.ToInt16(PointYear) - 100) + 2000);
                                                    PointMonth += "/" + PointDate + "/" + PointYear + " " + PointHour + ":" + PointMinute + ":" + PointSecond;
                                                    DateFound = true;
                                                }
                                                newCtr--;
                                            } while (DateFound == false);
                                        }
                                        catch { }
                                        DateFound = false;

                                    }
                                    CtrToStart++;
                                } while (ResFound == false);
                                break;
                            }
                            CtrToStart++;
                        } while (true);
                    }
                    catch
                    {
                    }
                    double[] dd = null;
                    bbr = 0;
                    dtfCtr = 0;
                    startZero = 0;
                    DataFinal = new double[1];
                    Data = new byte[1];
                    Breaker = false;
                    NewArray = true;
                    bool CompFlag = false;
                    DateFound = false;
                    ValForBar++;
                    string spram = PointInformation(ArrayForFac, EquipmentName, ComponentName, SubCmpName, PointName);
                    if (PreviousFacName == ArrayForFac && PreviousEqupname == EquipmentName && PreviousComname == ComponentName && PreviousSubCompname == SubCmpName && PreviousPointName == PointName)
                        SamePointDifferentChannel = true;
                    else
                        SamePointDifferentChannel = false;

                    PreviousFacName = ArrayForFac;
                    PreviousEqupname = EquipmentName;
                    PreviousComname = ComponentName;
                    PreviousSubCompname = SubCmpName;
                    PreviousPointName = PointName;

                    ValForBar++;
                    if (spram != null)
                    {
                        Parameters = spram.Split(new string[] { "," }, StringSplitOptions.None);//Extracting Parameters Of the Point For Finding There Keys To Decode Data
                        ISVolt = false;
                        IsInspection = false;

                        if (Convert.ToInt16(Parameters[0]) == 12)
                        {
                            ISVolt = true;
                        }
                        if (Convert.ToInt16(Parameters[0]) > 13)
                        {
                            IsInspection = true;
                        }

                        if (Convert.ToInt16(Parameters[0]) == 2 || Convert.ToInt16(Parameters[0]) == 6)
                        {
                            key = .0000763;//Setting The Key Value For Decoding
                        }
                        else if (Convert.ToInt16(Parameters[0]) == 1 || Convert.ToInt16(Parameters[0]) == 5)
                        {
                            key = .00000305;//Setting The Key Value For Decoding
                        }
                        else if (Convert.ToInt16(Parameters[0]) == 3 || Convert.ToInt16(Parameters[0]) == 7 || Convert.ToInt16(Parameters[0]) == 9 || Convert.ToInt16(Parameters[0]) == 12)
                        {
                            key = .0000610;//Setting the key Value For Decoding
                        }
                        else if (Convert.ToInt16(Parameters[0]) == 4 || Convert.ToInt16(Parameters[0]) == 8 || Convert.ToInt16(Parameters[0]) == 10)
                        {
                            key = .001533;//Setting the Key Value For Decoding
                        }
                        else if (Convert.ToInt16(Parameters[0]) == 0 || Convert.ToInt16(Parameters[0]) == 11 || Convert.ToInt16(Parameters[0]) > 13)
                        {
                            key = .00000305;//Setting The Key Value For Decoding
                        }
                        //KeyFactor = CtrToStart;
                        //bool KeyFacFound = false;
                        //do//Extracting Multiplication Factor For Decoding
                        //{
                        //    if ((objGetBytesFinal[KeyFactor] == 255 && objGetBytesFinal[KeyFactor + 1] == 255 && objGetBytesFinal[KeyFactor + 2] == 255 && objGetBytesFinal[KeyFactor + 3] == 255 && objGetBytesFinal[KeyFactor + 4] == 255 && objGetBytesFinal[KeyFactor + 5] == 255) || (objGetBytesFinal[KeyFactor] == 63 && objGetBytesFinal[KeyFactor + 1] == 63 && objGetBytesFinal[KeyFactor + 2] == 63 && objGetBytesFinal[KeyFactor + 3] == 63 && objGetBytesFinal[KeyFactor + 4] == 63 && objGetBytesFinal[KeyFactor + 5] == 63))
                        //    {
                        //        //KeyFactor = KeyFactor - 6;
                        //        if (objGetBytesFinal[KeyFactor - 7] != 0x1b)
                        //        {
                        //            try
                        //            {
                        //                Factor = Convert.ToInt16(DeciamlToHexadeciaml1(objGetBytesFinal[KeyFactor]));
                        //            }
                        //            catch
                        //            {
                        //                Factor = 0;
                        //            }
                        //        }
                        //        else
                        //            Factor = 0;
                        //        KeyFacFound = true;//Setting Factor Found Variable to True
                        //    }
                        //    KeyFactor--;
                        //    Factor = Factor % 10;

                        //} while (KeyFacFound == false);

                        int KeyFactor1 = CtrToStart;
                        bool KeyFacFound = false;
                        //do//Extracting Multiplication Factor For Decoding
                        //{
                        //    if ((objGetBytesFinal[KeyFactor1] == 255 && objGetBytesFinal[KeyFactor1 + 1] == 255 && objGetBytesFinal[KeyFactor1 + 2] == 255 && objGetBytesFinal[KeyFactor1 + 3] == 255 && objGetBytesFinal[KeyFactor1 + 4] == 255 && objGetBytesFinal[KeyFactor1 + 5] == 255) || (objGetBytesFinal[KeyFactor1] == 63 && objGetBytesFinal[KeyFactor1 + 1] == 63 && objGetBytesFinal[KeyFactor1 + 2] == 63 && objGetBytesFinal[KeyFactor1 + 3] == 63 && objGetBytesFinal[KeyFactor1 + 4] == 63 && objGetBytesFinal[KeyFactor1 + 5] == 63))
                        //    {
                        //        //KeyFactor1 = KeyFactor1 - 6;
                        //        if (objGetBytesFinal[KeyFactor1 - 7] != 0x1b)
                        //        {
                        //            try
                        //            {
                        //                Factor = Convert.ToInt16(DeciamlToHexadeciaml1(objGetBytesFinal[KeyFactor1-6]));
                        //            }
                        //            catch
                        //            {
                        //                Factor = 0;
                        //            }
                        //        }
                        //        else
                        //            Factor = 0;
                        //        KeyFacFound = true;//Setting Factor Found Variable to True
                        //    }
                        //    KeyFactor1--;
                        //    Factor = Factor % 10;

                        //} while (KeyFacFound == false);
                        Ctr = CtrToStart;
                        int k = 0;

                        int KeyToSerch = CtrToStart;
                        bool OrbtPt = false;
                        for (int ik = 0; ik < 90; ik++)
                        {
                            if (MainArr[KeyToSerch] == 0x58 && MainArr[KeyToSerch + 1] == 0x02 && MainArr[KeyToSerch + 2] == 0x06 && MainArr[KeyToSerch + 3] == 0x01 || KeyToSerch == MainArr.Length - 3)
                            {
                                OrbtPt = true;
                                break;
                            }
                            KeyToSerch++;
                        }
                        if (!OrbtPt)
                        {
                            KeyFactor = CtrToStart + 82;
                            //if (MainArr[KeyFactor] == 0)
                            //{
                            //   // KeyFactor++;
                            //}
                        }
                        do
                        {
                            if (KeyFactor != MainArr.Length - 3)
                            {
                                {
                                    if (KeyFactor > MainArr.Length)
                                    {
                                        tobreak = true;
                                        NewArray = false;
                                    }
                                }
                            }

                            if (NewArray == true)
                            {
                                if (KeyFactor >= MainArr.Length)
                                {
                                    tobreak = true;
                                }
                                else if (KeyFactor <= MainArr.Length - 3)
                                {
                                    if (MainArr[KeyFactor] == 0x58 && MainArr[KeyFactor + 1] == 0x02 && MainArr[KeyFactor + 2] == 0x06 && MainArr[KeyFactor + 3] == 0x01)
                                        tobreak = true;
                                }

                                if (tobreak == false)
                                {
                                    try
                                    {//change for time graph
                                        // if (measuretypedi == "2")
                                        {
                                            if (MainArr[KeyFactor + 11] == 0x46 && MainArr[KeyFactor + 12] == 0x02 && MainArr[KeyFactor + 13] == 0x30 && MainArr[KeyFactor + 5] == 0x00 && MainArr[KeyFactor + 4] == 0x00 && MainArr[KeyFactor + 6] == 0x00 && MainArr[KeyFactor + 7] == 0x00 || MainArr[KeyFactor + 8] == 0x00 && MainArr[KeyFactor + 9] == 0x00 && MainArr[KeyFactor + 6] == 0x00 && MainArr[KeyFactor + 7] == 0x00)
                                            {
                                                Data[dtCtr] = MainArr[KeyFactor];
                                                KeyFactor += 16;
                                            }
                                            else
                                            {
                                                Data[dtCtr] = MainArr[KeyFactor];
                                            }
                                        }
                                        //else
                                        //{
                                        //    Data[dtCtr] = MainArr[KeyFactor];
                                        //}
                                    }
                                    catch
                                    {
                                        tobreak = true;
                                    }
                                }
                                dtCtr++;
                                KeyFactor++;
                                Array.Resize(ref Data, Data.Length + 1);
                            }
                        } while (tobreak == false);



                        /////////////////////////////////////////////////////////

                        if (Convert.ToInt16(Parameters[0]) == 2 || Convert.ToInt16(Parameters[0]) == 6 || Convert.ToInt16(Parameters[0]) == 1 || Convert.ToInt16(Parameters[0]) == 5)
                        {
                            if (Factor <= 7)
                                OriginalFac = FactorUMMS[Factor];//Setting the Factor Value
                            else
                                OriginalFac = 1;
                        }
                        else if (Convert.ToInt16(Parameters[0]) == 3 || Convert.ToInt16(Parameters[0]) == 7 || Convert.ToInt16(Parameters[0]) == 9 || Convert.ToInt16(Parameters[0]) == 4 || Convert.ToInt16(Parameters[0]) == 8 || Convert.ToInt16(Parameters[0]) == 10)
                        {
                            if (Factor <= 5)
                                OriginalFac = FactorUMIL[Factor];//Setting the factor value
                            else
                                OriginalFac = 1;
                        }
                        else if (Convert.ToInt16(Parameters[0]) == 0 || Convert.ToInt16(Parameters[0]) == 11)
                        {

                            if (Factor <= 7 && Factor != 0)
                            {
                                Factor = Factor - 2;
                                if (Factor >= 0)
                                {
                                    OriginalFac = FactorUMMS[Factor];//Setting The Factor Value
                                }
                                else
                                    OriginalFac = 1;
                            }
                            else
                                OriginalFac = 1;
                        }

                        else if (Convert.ToInt16(Parameters[0]) == 12)
                        {
                            if (Factor <= 7 && Factor != 0)
                            {
                                Factor = Factor - 2;
                                if (Factor >= 0)
                                {
                                    OriginalFac = FactorUMMS[Factor];//Setting The Factor Value
                                }
                                else
                                {
                                    Factor = 0;
                                    OriginalFac = 1;
                                }
                            }
                            else
                                OriginalFac = 1;
                        }


                        else if (Convert.ToInt16(Parameters[0]) > 13)
                        {
                            if (Factor <= 5)
                            {

                                if (Factor >= 0)
                                {
                                    OriginalFac = FactorUMMS[Factor] * FactorInspection[Factor];//Setting The Factor Value
                                    if (Factor == 3)
                                    {
                                        OriginalFac = 1000;
                                    }
                                }
                                else
                                {
                                    Factor = 0;
                                    OriginalFac = 1;
                                }
                            }
                            else
                                OriginalFac = 1;
                        }
                        ////////////////////////////////////////////////////////



                        dtCtr = 0;
                        for (int d = 0; d < startZero; d++)
                        {
                            DataFinal[dtfCtr] = 0.0;
                            Array.Resize(ref DataFinal, DataFinal.Length + 1);
                            dtfCtr++;
                        }
                        if (Convert.ToInt16(Parameters[1]) == 0 || Convert.ToInt16(Parameters[1]) == 1)
                        {
                            do
                            {
                                Ctr++;
                                if (MainArr[Ctr] == 0x1b)
                                {
                                    startZero = Convert.ToInt16(MainArr[Ctr + 1]);
                                    if (startZero == 4)
                                        startZero = 1;
                                    else
                                        startZero = (startZero - 2) / 2;
                                    bbr = 1;
                                }
                                if (MainArr[Ctr] == 0x58 && MainArr[Ctr + 1] == 0x02 && MainArr[Ctr + 2] == 0x06 && MainArr[Ctr + 3] == 0x01 || Ctr == MainArr.Length - 3)
                                {
                                    bbr = 1;
                                    Ctr = Ctr - 2;
                                }
                            } while (bbr == 0);
                            Ctr = Ctr + 2;
                        }
                        else if (Convert.ToInt16(Parameters[1]) == 2 || Convert.ToInt16(Parameters[1]) == 3)
                        {
                            Ctr = Ctr + 5;
                        }
                        ValForBar++;
                        dtCtr = 0;
                        for (int d = 0; d < startZero; d++)
                        {
                            DataFinal[dtfCtr] = 0.0;
                            Array.Resize(ref DataFinal, DataFinal.Length + 1);
                            dtfCtr++;
                        }

                        if (Convert.ToInt16(Parameters[3]) < 3)
                        {
                            if (Convert.ToInt16(Parameters[1]) == 2 || Convert.ToInt16(Parameters[1]) == 3)
                            {
                                if (NewID == anotherid)
                                {
                                    checkdata = true;
                                }
                                else { checkdata = false; }
                                key = key * OriginalFac;
                                dd = CalculateData(DataFinal, Data, CalculatedFullScale);
                                Xvalues = new double[dd.Length];
                                double Difference = Convert.ToDouble(1 / (FreqArray[Convert.ToInt16(Parameters[4])] * 2.56));
                                Difference = Math.Round(Difference, 6);
                                for (int values = 0; values < dd.Length; values++)
                                {
                                    Xvalues[values] = Convert.ToDouble(Difference * (values + 1));
                                }
                                if (overalFound == true)
                                {
                                    OverallValueDecoded = Math.Round(((OverallValueDecoded * CalculatedFullScale) / 32767), 3);
                                }
                                FillDataIntoDatabaseUsb(NewID, Xvalues, dd, SamePointDifferentChannel, PointMonth, Parameters[5]);
                                anotherid = NewID;
                            }
                            else if (Convert.ToInt16(Parameters[1]) == 0 || Convert.ToInt16(Parameters[1]) == 1)
                            {
                                if (NewID == anotherid)
                                {
                                    checkdata = true;
                                }
                                else { checkdata = false; }
                                if (Convert.ToInt16(Parameters[1]) == 1)
                                    PhaseExtraction = true;
                                else
                                    PhaseExtraction = false;

                                key = key * OriginalFac;

                                dd = PointDataExtractorForFFT(key, dtfCtr, DataFinal, Data, Convert.ToInt16(Parameters[2]));
                                // dd = CalculateData(DataFinal, Data, CalculatedFullScale);


                                Xvalues = new double[dd.Length];
                                double Difference = Convert.ToDouble(FreqArray[Convert.ToInt16(Parameters[4])] / ResolutionFFT[Convert.ToInt16(Parameters[2])]);
                                for (int values = 0; values < dd.Length; values++)
                                {
                                    Xvalues[values] = Convert.ToDouble(Difference * (values));
                                }
                                if (overalFound == true)
                                {
                                    OverallValueDecoded = Math.Round(((OverallValueDecoded * CalculatedFullScale) / 32767), 3);
                                }
                                FillDataIntoDatabaseUsb(NewID, Xvalues, dd, SamePointDifferentChannel, PointMonth, Parameters[5]);
                                anotherid = NewID;
                            }
                        }
                        else if (Convert.ToInt16(Parameters[3]) >= 3)
                        {
                            if (Convert.ToInt16(Parameters[1]) == 2)
                            {
                                if (NewID == anotherid)
                                {
                                    checkdata = true;
                                }
                                else { checkdata = false; }
                                key = key * OriginalFac;
                                dd = CalculateData(DataFinal, Data, CalculatedFullScale);
                                Xvalues = new double[dd.Length];
                                double Difference = Convert.ToDouble(1 / (FreqArray[Convert.ToInt16(Parameters[4])] * 2.56));
                                Difference = Math.Round(Difference, 6);
                                for (int values = 0; values < dd.Length; values++)
                                {
                                    Xvalues[values] = Convert.ToDouble(Difference * (values + 1));
                                }
                                if (overalFound == true)
                                {
                                    OverallValueDecoded = Math.Round(((OverallValueDecoded * CalculatedFullScale) / 32767), 3);
                                }
                                FillDataIntoDatabaseUsb(NewID, Xvalues, dd, SamePointDifferentChannel, PointMonth, Parameters[5]);
                                anotherid = NewID;
                            }
                            else if (Convert.ToInt16(Parameters[1]) == 3 || Convert.ToInt16(Parameters[1]) == 1)
                            {
                                if (NewID == anotherid)
                                {
                                    checkdata = true;
                                }
                                else { checkdata = false; }
                                if (Convert.ToInt16(Parameters[1]) == 1)
                                    PhaseExtraction = true;
                                else
                                    PhaseExtraction = false;
                                key = key * OriginalFac;
                                //dd = CalculateData(DataFinal, Data, CalculatedFullScale);
                                dd = PointDataExtractorForFFT(key, dtfCtr, DataFinal, Data, Convert.ToInt16(Parameters[2]));
                                Xvalues = new double[dd.Length];
                                double Difference = Convert.ToDouble(1 / (FreqArray[Convert.ToInt16(Parameters[4])] * 2.56));
                                Difference = Math.Round(Difference, 6);

                                for (int values = 0; values < dd.Length; values++)
                                {
                                    Xvalues[values] = Convert.ToDouble(Difference * (values + 1));
                                }
                                if (overalFound == true)
                                {
                                    OverallValueDecoded = Math.Round(((OverallValueDecoded * CalculatedFullScale) / 32767), 3);
                                }
                                FillDataIntoDatabaseUsb(NewID, Xvalues, dd, SamePointDifferentChannel, PointMonth, Parameters[5]);
                                anotherid = NewID;
                            }
                            else if (Convert.ToInt16(Parameters[1]) == 0)
                            {
                                if (NewID == anotherid)
                                {
                                    checkdata = true;
                                }
                                else { checkdata = false; }
                                key = key * OriginalFac;
                                dd = CalculateData(DataFinal, Data, CalculatedFullScale);
                                Xvalues = new double[dd.Length];
                                double Difference = Convert.ToDouble(FreqArray[Convert.ToInt16(Parameters[4])] / ResolutionFFT[Convert.ToInt16(Parameters[2])]);
                                for (int values = 0; values < dd.Length; values++)
                                {
                                    Xvalues[values] = Convert.ToDouble(Difference * (values));
                                }
                                if (overalFound == true)
                                {
                                    OverallValueDecoded = Math.Round(((OverallValueDecoded * CalculatedFullScale) / 32767), 3);
                                }
                                FillDataIntoDatabaseUsb(NewID, Xvalues, dd, SamePointDifferentChannel, PointMonth, Parameters[5]);
                                anotherid = NewID;
                            }
                        }
                    }
                    ValForBar++;
                    if (tobreak == true)
                    {
                        ComponentName = null;
                        PointName = null;
                        SubCmpName = null;
                        arrSubComponent = new byte[16];
                        arrComponent = new byte[16];
                        arrSubComponent1 = new byte[16];
                        arrType = new byte[16];
                        EquipmentName = null;
                        arrEquipmentArr = new byte[16];
                        PointDate = null;
                        PointMonth = null;
                        PointYear = null;
                        PointHour = null;
                        PointMinute = null;
                        PointSecond = null;
                        OverallValueDecoded = 0.0;
                    }
                } while (tobreak == true);
            }
            catch { }
        }
        string PhaseAng = null; string phaseAng1 = null;
        private double[] PointDataExtractorForFFT(double target, int dtfCtr, double[] DataFinal, byte[] Data, int parameter)
        {
            int dtCtr = 0;
            int[] TotalPointsCompleter = { 100, 200, 400, 800, 1600, 3200, 6400 };
            int ack = 0;
            double PhaseValues = 0;
            PhaseAng = null;
            StringBuilder sblPhase = new StringBuilder();
            try
            {
                bool bb = false;
                for (int i = 0; i < Data.Length - 1; i++)
                {
                    if (i >= 1525)
                    {

                    }
                    int zeros = 0;
                    ack = 0;
                    if (Data[dtCtr] == 0x1b && Data[dtCtr + 1] != 0x1b)
                    {
                        while (ack == 0)
                        {
                            i++;
                            dtCtr++;
                            zeros = Convert.ToInt16(Data[dtCtr] / 2) + zeros;
                            ack = 1;
                            dtCtr++;
                            if (Data[dtCtr] == 0x00)
                            {
                                i++;
                                dtCtr++;
                                ack = 1;
                            }
                            else if (Data[dtCtr] == 0x1b)
                                ack = 0;
                        }
                    }
                    else if (Data[dtCtr] == 0x1b && Data[dtCtr + 1] == 0x1b)
                    {

                        if (Data[dtCtr + 2] > Data[dtCtr + 3])
                        {
                            i = i + 1;
                            dtCtr = dtCtr + 2;
                        }
                        else if ((Data[dtCtr + 1] > Data[dtCtr + 2]))
                        {
                            dtCtr = dtCtr + 1;
                        }
                        else
                        {
                            i = i + 2;
                            dtCtr = dtCtr + 3;
                        }

                    }
                    for (int j = 0; j < zeros; j++)
                    {
                        DataFinal[dtfCtr] = 0.0;
                        Array.Resize(ref DataFinal, DataFinal.Length + 1);
                        dtfCtr++;
                    }
                    if (PhaseExtraction == true)
                    {
                        //if (Data[dtCtr] == 0x34 && Data[dtCtr + 1] == 0x01 && Data[dtCtr + 2] == 0x16 && Data[dtCtr + 3] == 0x00 && Data[dtCtr + 5] != 0x1b)
                        if (Data[dtCtr] == 0x34 && Data[dtCtr + 1] == 0x01)
                        // if (Data[dtCtr] == 0x34 && Data[dtCtr + 1] == 0x01 && Data[dtCtr + 2] == 0x26 && Data[dtCtr + 3] == 0x00 && Data[dtCtr + 5] != 0x1b)
                        {
                            dtCtr = dtCtr + 10;
                            for (int PhCtr = 0; PhCtr < 16; PhCtr++)
                            {
                                PhaseValues = Math.Round(((Data[dtCtr + 1] * 256 + Data[dtCtr]) * target), 8);
                                // double before1 = 123.45;
                                PhaseValues = Math.Round(PhaseValues, 3, MidpointRounding.ToEven);
                                sblPhase.Append(Convert.ToString(PhaseValues));
                                sblPhase.Append("|");
                                //Array.Resize(ref DataFinal, DataFinal.Length + 1);
                                PhCtr++;
                                dtCtr = dtCtr + 2;
                                PhaseValues = Data[dtCtr] + Data[dtCtr + 1] * 256;
                                sblPhase.Append(Convert.ToString(PhaseValues));
                                sblPhase.Append(",");
                                dtCtr = dtCtr + 2;

                            }
                            if (sblPhase != null)
                                PhaseAng = Convert.ToString(sblPhase);
                            break;
                        }
                    }
                    // if (dtCtr < (2 * TotalPointsCompleter[parameter]))
                    {
                        bb = false;
                        try
                        {
                            if (Data[dtCtr + 1] == 0x1b)
                            {
                                bb = true;
                            }
                            else
                            {
                                bb = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            bb = false;
                        }

                        if (bb)
                        {
                            if (ISVolt)
                            {
                                DataFinal[dtfCtr] = Math.Round((((Data[dtCtr]) * target) / 200), 8);
                            }
                            else
                            {
                                DataFinal[dtfCtr] = Math.Round(((Data[dtCtr]) * target), 8);
                            }
                            Array.Resize(ref DataFinal, DataFinal.Length + 1);
                            dtfCtr++;
                            i++;
                            dtCtr++;
                        }
                        else
                        {
                            if (ISVolt)
                            {
                                DataFinal[dtfCtr] = Math.Round((((Data[dtCtr + 1] * 256 + Data[dtCtr]) * target) / 200), 8);

                            }
                            else
                            {
                                DataFinal[dtfCtr] = Math.Round(((Data[dtCtr + 1] * 256 + Data[dtCtr]) * target), 8);
                            }
                            Array.Resize(ref DataFinal, DataFinal.Length + 1);
                            dtCtr = dtCtr + 2;
                            dtfCtr++;
                            i++;

                        }
                    }
                }
                if (DataFinal.Length < TotalPointsCompleter[parameter])
                {
                    for (int i = DataFinal.Length; i <= TotalPointsCompleter[parameter]; i++)
                    {
                        DataFinal[dtfCtr] = 0.0;
                        Array.Resize(ref DataFinal, DataFinal.Length + 1);
                        dtfCtr++;
                    }
                }
            }
            catch (Exception ex)
            {
                //ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            return DataFinal;
        }


        private string PointInformation(string ArrayForFac, string EquipmentN, string ComponentN, string SubCmpN, string PointName)
        {
            string sFinalInformation = null;
            string[] arrExtractedVals = null;
            string sUid = null;
            string sAns = null;
            bool Present = false;
            string sNames = null; char space = ' ';
            EquipmentN = EquipmentN.TrimEnd(new char[] { space });
            EquipmentN = EquipmentN.TrimStart(new char[] { space });
            ComponentN = ComponentN.TrimEnd(new char[] { space });
            ComponentN = ComponentN.TrimStart(new char[] { space });
            SubCmpN = SubCmpN.TrimEnd(new char[] { space });
            SubCmpN = SubCmpN.TrimStart(new char[] { space });
            PointName = PointName.TrimEnd(new char[] { space });
            PointName = PointName.TrimStart(new char[] { space });
            try
            {
                DataTable dt;
                string[] requiredNames = ArrayForFac.Split(new string[] { "." }, StringSplitOptions.None);
                if (PublicClass.Routelevel == "Point")
                {
                    dt = DbClass.getdata(CommandType.Text, "select Point_ID,PointName from point where Point_ID='" + requiredNames[0] + "'");
                }
                else
                {
                    dt = DbClass.getdata(CommandType.Text, "select pt.Point_ID,pt.PointName from point pt inner join machine_info mac on pt.Machine_ID=mac.Machine_ID left join train_info tra on mac.TrainID=tra.Train_ID left join area_info are on tra.Area_ID=are.Area_ID left join factory_info fac on are.FactoryID=fac.Factory_ID where fac.Factory_ID='" + requiredNames[0] + "'");
                }
                foreach (DataRow dr in dt.Rows)
                {
                    sNames = Convert.ToString(dr["PointName"]);
                    if (sNames == PointName.Replace('\0', ' '))
                    {
                        sUid = Convert.ToString(dr["Point_ID"]);
                        break;
                    }
                }
                sFinalInformation = PointInformationExtract1(sUid);
                arrExtractedVals = sFinalInformation.Split(new string[] { "@", "#", "^", "&", ">", "?", "{", "}", ";" }, StringSplitOptions.None);//Splitting parameters to have an array for sorting particular parametres
                if (arrExtractedVals.Length > 9)
                {
                    sAns = arrExtractedVals[1] + "," + arrExtractedVals[5] + "," + arrExtractedVals[6] + "," + arrExtractedVals[9] + "," + arrExtractedVals[7] + "," + arrExtractedVals[3];//Sorting Particular parameters
                }
            }
            catch { }
            return sAns;
        }


        private byte NewDataSync()
        {
            byte[] arrReceivedFour1 = new byte[1];
            try
            {
                m_objSerialPort.Write(SHEXSIX);
                m_objSerialPort.Read(arrReceivedFour1, 0, arrReceivedFour1.Length);
            }
            catch { }
            return (arrReceivedFour1[0]);

        }




        public byte[] MakeTourDatafrombytearray(byte[] ByteArray)
        {
            UInt64 CtrForUsb = 0;
            byte[] BytesFortourData = new byte[0];
            UInt64 Uploadlength = Convert.ToUInt64(ByteArray.Length);
            try
            {
                do
                {
                    if ((ByteArray[CtrForUsb] == 46 && ByteArray[CtrForUsb + 1] == 01 && ByteArray[CtrForUsb + 2] == 00 && ByteArray[CtrForUsb + 3] == 00 && ByteArray[CtrForUsb + 4] == 88) || (ByteArray[CtrForUsb] == 88 && ByteArray[CtrForUsb + 1] == 02 && ByteArray[CtrForUsb + 2] == 06 && ByteArray[CtrForUsb + 3] == 01))
                    {
                        UInt64 i = CtrForUsb;
                        do
                        {
                            if (ByteArray[i] != 0x1b)
                            {
                                Array.Resize(ref BytesFortourData, BytesFortourData.Length + 1);
                                BytesFortourData[BytesFortourData.Length - 1] = ByteArray[i];
                            }
                            else
                            {
                                int ZeroCtr = Convert.ToInt32(ByteArray[i + 1]);
                                if (ZeroCtr == 27)
                                {
                                    Array.Resize(ref BytesFortourData, BytesFortourData.Length + 1);
                                    i++;
                                }
                                else
                                {
                                    Array.Resize(ref BytesFortourData, BytesFortourData.Length + ZeroCtr);
                                    i++;
                                }

                            }

                            i++;
                        }
                        while (i < Uploadlength);
                        break;
                    }
                    CtrForUsb++;

                } while (CtrForUsb < Uploadlength);
            }
            catch { }
            return BytesFortourData;
        }


        private int HexadecimaltoDecimal(string hexadecimal)
        {
            int result = 0;

            for (int i = 0; i < hexadecimal.Length; i++)
            {
                result += Convert.ToInt32(this.GetNumberFromNotation(hexadecimal[i]) * Math.Pow(16, Convert.ToInt32(hexadecimal.Length) - (i + 1)));
            }
            return Convert.ToInt32(result);
        }
        private int GetNumberFromNotation(char c)
        {
            if (c == 'A')
                return 10;
            else if (c == 'B')
                return 11;
            else if (c == 'C')
                return 12;
            else if (c == 'D')
                return 13;
            else if (c == 'E')
                return 14;
            else if (c == 'F')
                return 15;
            return Convert.ToInt32(c.ToString());
        }
        string sResourceID = null;
        string sElementID = null;
        string sSubElementID = null;
        string FinalPointName = null;
        bool overalFound = false;
        private void ExtractOffDataDiForUsb(byte[] MainArr)
        {
            bool AckGetBt = false;
            int CtrToStart = 0;
            double[] FactorUMMS = { 200, 100, 50, 20, 10, 5, 2, 1 };
            double[] FactorUMIL = { 50, 25, 10, 5, 2.5, 1 };
            int arrchannel = 0;
            string sPointName = null;
            string sPointDescription = null;
            string sFactoryName = null;
            string sResourceName = null;
            string sElementName = null;
            string sSubElementName = null;
            byte[] NameExtracter = new byte[17];
            double[] FactorInspection = { 1000, 1000, 200, 200, 10, 10 };
            double[] LimitIPS = { 20, 10, 5, 2, 1, .5, .2, .1, .05, .02, .01, .005, .002, .001 };
            double[] LimitMMS = { 500, 250, 125, 50, 25, 12.5, 5, 2.5, 1.25, .5, .25, .125, .05, .025 };
            double[] LimitMIL = { 100, 50, 20, 10, 5, 2, 1, .5, .2, .1, .05, .02 };
            double[] LimitUM = { 2500, 1250, 500, 250, 125, 50, 25, 12.5, 5, 2.5, 1.25, 0.5 };
            double[] LimitG = { 100, 50, 20, 10, 5, 2, 1, .5, .2, .1, .05, .02, .01, .005, .002, .001 };
            double[] LimitVolt = { 10, 5, 2, 1, .5, .2, .1, .05, .02, .01, .005, 20, 50 };
            double[] LimitInspection = { 100000, 10000, 1000, 100, 10, 1, .1, .01, .001 };
            double[] LimitRPM = { 100000, 50000, 10000, 5000, 1000, 500, 100, 50, 10, 5, 1 };
            double[] FreqArray = { 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 40000, 25 };
            double[] ResolutionFFT = { 100, 200, 400, 800, 1600, 3200, 6400 };
            double[] ResolutionTime = { 256, 512, 1024, 2048, 4096, 8192, 16384 };
            string PreviousFacName = null;
            string PreviousEqupname = null;
            string PreviousComname = null;
            string PreviousSubCompname = null;
            string PreviousPointName = null;
            bool SamePointDifferentChannel = false;
            NewID = null;
            dualChnl = 0;
            iFScale = 0;    //fullscale--1
            iMesure = 0;    //measuretype--5
            iFltrType = 0;  //filter type--3
            iFltrVal = 0;
            iFreq = 0;      //frequency--4
            iWin = 0;       //window--2
            iCpl = 0;       //couple
            iUnit = 0;      //unit
            idetc = 0;      //detection
            iLor = 0;       //line of resolution
            isens = 100;      //sensitivity
            bmesure = false;
            bool dataEntered = false;
            bool ISVolt = false;
            bool IsInspection = false;
            bool ISUm = false;
            double OverallValueDecoded = 0.0;
            double CalculatedFullScale = 0;

            string PointDate = null;
            string PointMonth = null;
            string PointYear = null;
            string PointHour = null;
            string PointMinute = null;
            string PointSecond = null;
            bool DateFound = false;
            int offptctr = 0;
            {
                try
                {
                    Value = 0;
                    do
                    {
                        try
                        {
                            int Factor = 0;
                            int KeyFactor = 0;
                            AckGetBt = false;
                            try
                            {
                                do
                                {
                                    if (MainArr[CtrToStart] == 0x58 && MainArr[CtrToStart + 1] == 0x02 && MainArr[CtrToStart + 2] == 0x06 && MainArr[CtrToStart + 3] == 0x01)
                                    {
                                        dualChnl = 0;
                                        iWin = 0;
                                        iLor = 0;
                                        iFScale = 0;
                                        iUnit = 0;
                                        iMesure = 0;
                                        iFltrType = 0;
                                        iFltrVal = 0;
                                        iFreq = 0;
                                        idetc = 0;
                                        bmesure = false;
                                        string sUnit = null;
                                        string sCT = null;
                                        int newCtr = CtrToStart + 4;
                                        byte[] fs = new byte[1];

                                        fs[0] = MainArr[newCtr];
                                        string fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                        string[] fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                                        if (fsvalacc.Length > 1)
                                        {
                                            sCT = (fsvalacc[0].ToString());
                                        }
                                        else
                                        {
                                            sCT = (fsvalacc[0].ToString());
                                        }
                                        newCtr = CtrToStart + 10;
                                        string SFH = null;
                                        for (int i = newCtr, j = 0; j < 5; i++, j++)
                                        {

                                            if (j == 4)
                                            {
                                                if (MainArr[i].ToString() == "32")
                                                {
                                                    if (SFH == "2000")
                                                    {
                                                        dualChnl = 0;
                                                    }
                                                    else
                                                    {
                                                        dualChnl = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    dualChnl = 0;
                                                }
                                            }
                                            SFH += MainArr[i].ToString();
                                        }
                                        CtrToStart = CtrToStart + 15;
                                        while (true)
                                        {
                                            if (MainArr[CtrToStart].ToString() == "0")
                                            {
                                                CtrToStart++;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        for (int NmCtr = 0; NmCtr < 17; NmCtr++)
                                        {
                                            NameExtracter[NmCtr] = MainArr[CtrToStart];
                                            CtrToStart++;
                                        }
                                        sElementName = Encoding.ASCII.GetString(NameExtracter);
                                        sElementName = sElementName.Trim(new char[] { '\0' });
                                        NameExtracter = new byte[17];
                                        for (int NmCtr = 0; NmCtr < 17; NmCtr++)
                                        {
                                            NameExtracter[NmCtr] = MainArr[CtrToStart];
                                            CtrToStart++;
                                        }
                                        sPointName = Encoding.ASCII.GetString(NameExtracter);
                                        sPointName = sPointName.Trim(new char[] { '\0' });
                                        NameExtracter = new byte[17];
                                        for (int NmCtr = 0; NmCtr < 17; NmCtr++)
                                        {
                                            NameExtracter[NmCtr] = MainArr[CtrToStart];
                                            CtrToStart++;
                                        }
                                        sSubElementName = Encoding.ASCII.GetString(NameExtracter);
                                        sSubElementName = sSubElementName.Trim(new char[] { '\0' });
                                        NameExtracter = new byte[17];
                                        for (int NmCtr = 0; NmCtr < 17; NmCtr++)
                                        {
                                            NameExtracter[NmCtr] = MainArr[CtrToStart];
                                            CtrToStart++;
                                        }
                                        sPointDescription = Encoding.ASCII.GetString(NameExtracter);
                                        sPointDescription = sPointDescription.Trim(new char[] { '\0' });
                                        NameExtracter = new byte[17];
                                        AckGetBt = true;
                                        bool ResFound = false;
                                        int OverallFactor = 0;
                                        int MaxToLook = 0;
                                        int MaxToLookForFF = 0;
                                        overalFound = false;
                                        sUnit = null;
                                        newCtr = CtrToStart + 21;
                                        fs = new byte[2];
                                        fs[1] = MainArr[newCtr];
                                        fs[0] = MainArr[newCtr + 1];
                                        fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                        string fsval1 = DeciamlToHexadeciaml(Convert.ToInt32(fs[1].ToString()));
                                        fsvalacc = fsval1.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        string[] fsvalacc1 = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        if (fsvalacc1.Length > 1)
                                        {
                                            sUnit += (fsvalacc1[1].ToString());
                                        }
                                        else
                                        {
                                            sUnit += (fsvalacc1[0].ToString());
                                        }
                                        if (fsvalacc.Length > 1)
                                        {
                                            sUnit += (fsvalacc[0].ToString());
                                            iFScale = Convert.ToInt32(fsvalacc[1].ToString());
                                        }
                                        else
                                        {
                                            try
                                            {
                                                iFScale = Convert.ToInt32(fsvalacc[0].ToString());
                                            }
                                            catch
                                            {
                                                iFScale = Convert.ToInt32(HexadecimaltoDecimal(fsvalacc[0].ToString()));
                                            }
                                        }

                                        iUnit = Convert.ToInt32(sUnit);
                                        switch (iUnit)
                                        {
                                            case 0:
                                                {//accel(G)
                                                    iUnit = 0;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitG[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;
                                                }
                                            case 1:
                                                {//A -> V (IPS)
                                                    iUnit = 1;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitIPS[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;
                                                }
                                            case 11:
                                                {//A -> V (MM/S)
                                                    iUnit = 2;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitMMS[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;
                                                }
                                            case 2:
                                                {//VEL (IPS)
                                                    iUnit = 5;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitIPS[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;
                                                }
                                            case 21:
                                                {//VEL (MM/S)
                                                    iUnit = 6;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitMMS[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;

                                                }
                                            case 3:
                                                {//A -> D (MILS)
                                                    iUnit = 3;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitMIL[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;
                                                }
                                            case 31:
                                                {//A -> D (UM)
                                                    iUnit = 4;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitUM[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;
                                                }
                                            case 4:
                                                {//V -> D (MILS)
                                                    iUnit = 7;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitMIL[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;
                                                }
                                            case 41:
                                                {//V -> D (UM)
                                                    iUnit = 8;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitUM[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;
                                                }
                                            case 5:
                                                {//DISP (MILS)
                                                    iUnit = 9;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitMIL[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;
                                                }
                                            case 51:
                                                {//DISP (UM)
                                                    iUnit = 10;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitUM[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;
                                                }
                                            case 9:
                                                {//esp
                                                    iUnit = 11;
                                                    break;
                                                }
                                            case 6:
                                                {//volt
                                                    iUnit = 12;
                                                    try
                                                    {
                                                        CalculatedFullScale = (double)LimitVolt[iFScale];
                                                    }
                                                    catch
                                                    {
                                                        CalculatedFullScale = iFScale;
                                                    }
                                                    break;
                                                }
                                            case 8:
                                                {//RPM
                                                    iUnit = 13;
                                                    break;
                                                }
                                        }

                                        string sFT = null;
                                        string sFV = null;
                                        fs = new byte[2];
                                        fs[0] = MainArr[newCtr + 2];
                                        fs[1] = MainArr[newCtr + 3];
                                        fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                        fsval1 = DeciamlToHexadeciaml(Convert.ToInt32(fs[1].ToString()));
                                        fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        fsvalacc1 = fsval1.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        if (fsvalacc.Length > 1)
                                        {
                                            for (int i = 0; i < fsvalacc.Length; i++)
                                            {
                                                sFT = sFT + fsvalacc[i].ToString();
                                            }
                                        }
                                        else
                                        {
                                            sFT = fsvalacc[0].ToString();
                                        }

                                        if (fsvalacc1.Length > 1)
                                        {
                                            for (int i = 0; i < fsvalacc1.Length; i++)
                                            {
                                                sFV = sFV + fsvalacc1[i].ToString();
                                            }
                                        }
                                        else
                                        {
                                            sFV = fsvalacc1[0].ToString();
                                        }

                                        if (sFT == "80")
                                        {
                                            if (sFV == "8")
                                            {
                                                iFltrVal = 1;
                                                iFltrType = 2;
                                            }
                                            else if (sFV == "4")
                                            {
                                                iFltrVal = 4; iFltrType = 1;
                                            }
                                            else if (sFV == "5")
                                            {
                                                iFltrVal = 6; iFltrType = 1;
                                            }
                                            else if (sFV == "C")
                                            {
                                                iFltrVal = 4; iFltrType = 3;
                                            }
                                            else if (sFV == "D")
                                            {
                                                iFltrVal = 6;
                                                iFltrType = 3;
                                            }
                                        }
                                        else if (sFT == "0")
                                        {
                                            if (sFV == "8")
                                            {
                                                iFltrVal = 0;
                                                iFltrType = 2;
                                            }
                                            else if (sFV == "9")
                                            {
                                                iFltrVal = 2;
                                                iFltrType = 2;
                                            }
                                            else if (sFV == "4")
                                            {
                                                iFltrVal = 2;
                                                iFltrType = 1;
                                            }
                                            else if (sFV == "5")
                                            {
                                                iFltrVal = 5;
                                                iFltrType = 1;
                                            }
                                            else if (sFV == "6")
                                            {
                                                iFltrVal = 7;
                                                iFltrType = 1;
                                            }
                                            else if (sFV == "C")
                                            {
                                                iFltrVal = 2;
                                                iFltrType = 3;
                                            }
                                            else if (sFV == "D")
                                            {
                                                iFltrVal = 5;
                                                iFltrType = 3;
                                            }
                                            else if (sFV == "E")
                                            {
                                                iFltrVal = 7;
                                                iFltrType = 3;
                                            }
                                            else if (sFV == "0")
                                            {
                                                iFltrVal = 0;
                                                iFltrType = 0;
                                                iMesure = 0;
                                            }
                                        }
                                        else
                                        {
                                            if (sFV == "0")
                                            {
                                                iCpl = Convert.ToInt32(fsvalacc[0].ToString());
                                            }
                                        }
                                        do
                                        {
                                            if ((MainArr[CtrToStart] == 0x3F && MainArr[CtrToStart - 1] == 0x3F && MainArr[CtrToStart - 2] == 0x3F && MainArr[CtrToStart - 3] == 0x3F && MainArr[CtrToStart - 4] == 0x3F && MainArr[CtrToStart - 5] == 0x3F) || (MainArr[CtrToStart] == 0xFF && MainArr[CtrToStart - 1] == 0xFF && MainArr[CtrToStart - 2] == 0xFF && MainArr[CtrToStart - 3] == 0xFF && MainArr[CtrToStart - 4] == 0xFF && MainArr[CtrToStart - 5] == 0xFF))
                                            {
                                                newCtr = CtrToStart - 7;

                                                fs = new byte[2];
                                                fs[0] = MainArr[newCtr];
                                                fs[1] = MainArr[newCtr + 1];
                                                fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                                fsval1 = DeciamlToHexadeciaml(Convert.ToInt32(fs[1].ToString()));
                                                fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                                if (fsvalacc.Length > 1)
                                                {
                                                    iMesure = Convert.ToInt32(fsvalacc[1].ToString());
                                                }
                                                else
                                                {
                                                    iMesure = Convert.ToInt32(fsvalacc[0].ToString());
                                                }


                                                newCtr = CtrToStart + 4;

                                                fs = new byte[1];
                                                fs[0] = MainArr[newCtr];

                                                fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                                fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                                if (fsvalacc.Length > 1)
                                                {
                                                    idetc = Convert.ToInt32(fsvalacc[1].ToString());
                                                }
                                                else
                                                {
                                                    idetc = Convert.ToInt32(fsvalacc[0].ToString());
                                                }

                                                try
                                                {
                                                    newCtr = CtrToStart + 18;
                                                    PointSecond = Convert.ToString(MainArr[newCtr]);
                                                    PointMinute = Convert.ToString(MainArr[newCtr + 1]);
                                                    PointHour = Convert.ToString(MainArr[newCtr + 2]);
                                                    PointDate = Convert.ToString(MainArr[newCtr + 3]);
                                                    PointMonth = Convert.ToString(MainArr[newCtr + 4]);
                                                    PointYear = Convert.ToString(MainArr[newCtr + 5]);
                                                    PointYear = Convert.ToString((Convert.ToInt16(PointYear)) + 1900);
                                                    PointMonth += "/" + PointDate + "/" + PointYear + " " + PointHour + ":" + PointMinute + ":" + PointSecond;
                                                    DateFound = true;
                                                }
                                                catch
                                                {
                                                    DateFound = false;
                                                }
                                                KeyFactor = CtrToStart - 11;
                                                if (MainArr[KeyFactor - 12] != 0x1b)
                                                {
                                                    try
                                                    {
                                                        Factor = Convert.ToInt16(DeciamlToHexadeciaml1(MainArr[KeyFactor]));
                                                    }
                                                    catch
                                                    {
                                                        Factor = Convert.ToInt16(MainArr[KeyFactor]);
                                                    }
                                                }
                                                else
                                                    Factor = 0;
                                                Factor = Factor % 10;
                                                OverallFactor = CtrToStart + 7;
                                                OverallValueDecoded = 0.0;
                                                do
                                                {
                                                    if (MainArr[OverallFactor] != 0x00)
                                                    {
                                                        OverallValueDecoded = ((MainArr[OverallFactor + 1] * 256 + MainArr[OverallFactor]));
                                                        int xx = ((short)MainArr[OverallFactor]) << 8 + MainArr[OverallFactor + 1];
                                                        overalFound = true;
                                                    }
                                                    else if (MainArr[OverallFactor] == 0x00)
                                                    {
                                                        OverallValueDecoded = (MainArr[OverallFactor + 1]);
                                                        int xx = ((short)MainArr[OverallFactor]) << 8 + MainArr[OverallFactor + 1];

                                                        overalFound = true;
                                                    }
                                                } while (overalFound == false);

                                                newCtr = CtrToStart + 31;
                                                fs = new byte[1];
                                                fs[0] = MainArr[newCtr];

                                                fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                                fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                                string sLor = null;
                                                if (fsvalacc.Length > 1)
                                                {
                                                    for (int i = 0; i < fsvalacc.Length; i++)
                                                    {
                                                        sLor = sLor + fsvalacc[i].ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    sLor = fsvalacc[0].ToString();
                                                }
                                                iLor = Convert.ToInt32(sLor);
                                                if (iLor > 6)
                                                {
                                                    iLor = 0;
                                                }
                                                switch (iLor)
                                                {
                                                    case 0:
                                                        {
                                                            iLor = 2;
                                                            break;
                                                        }
                                                    case 1:
                                                        {
                                                            iLor = 0;
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            iLor = 1;
                                                            break;
                                                        }
                                                }
                                                newCtr++;
                                                fs = new byte[2];
                                                fs[0] = MainArr[newCtr];
                                                fs[1] = MainArr[newCtr + 2];
                                                fsval = DeciamlToHexadeciaml(Convert.ToInt32(fs[0].ToString()));
                                                fsval1 = DeciamlToHexadeciaml(Convert.ToInt32(fs[1].ToString()));
                                                fsvalacc = fsval.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                                fsvalacc1 = fsval1.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                                string win = null;
                                                string frq = null;

                                                if (fsvalacc.Length > 1)
                                                {
                                                    for (int i = 0; i < fsvalacc.Length; i++)
                                                    {
                                                        win = win + fsvalacc[i].ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    win = fsvalacc[0].ToString();
                                                }

                                                if (fsvalacc1.Length > 1)
                                                {
                                                    for (int i = 0; i < fsvalacc1.Length; i++)
                                                    {
                                                        frq = frq + fsvalacc1[i].ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    frq = fsvalacc1[0].ToString();
                                                }

                                                try
                                                {
                                                    iWin = Convert.ToInt32(win);
                                                    iFreq = Convert.ToInt32(frq);
                                                }
                                                catch
                                                {
                                                    iFreq = 3;
                                                }
                                                if (iFreq > 9)
                                                {
                                                    iFreq = 3;
                                                }

                                                CtrToStart = CtrToStart + 57;
                                                for (int NmCtr = 0; NmCtr < 17; NmCtr++)
                                                {
                                                    if ((MainArr[CtrToStart] < 58 && MainArr[CtrToStart] > 47) || (MainArr[CtrToStart] < 91 && MainArr[CtrToStart] > 64) || (MainArr[CtrToStart] < 123 && MainArr[CtrToStart] > 96))
                                                        NameExtracter[NmCtr] = MainArr[CtrToStart];
                                                    CtrToStart++;
                                                }
                                                ResFound = true;
                                                sResourceName = Encoding.ASCII.GetString(NameExtracter);
                                                sResourceName = sResourceName.Trim(new char[] { '\0' });

                                                try
                                                {
                                                    newCtr = CtrToStart;
                                                    do
                                                    {
                                                        if (MainArr[newCtr + 5] == 0x6c || MainArr[newCtr + 5] == 0x6d)
                                                        {
                                                            PointSecond = Convert.ToString(MainArr[newCtr]);
                                                            PointMinute = Convert.ToString(MainArr[newCtr + 1]);
                                                            PointHour = Convert.ToString(MainArr[newCtr + 2]);
                                                            PointDate = Convert.ToString(MainArr[newCtr + 3]);
                                                            PointMonth = Convert.ToString(MainArr[newCtr + 4]);
                                                            PointYear = Convert.ToString(MainArr[newCtr + 5]);
                                                            PointYear = Convert.ToString((Convert.ToInt16(PointYear) - 100) + 2000);
                                                            PointMonth += "/" + PointDate + "/" + PointYear + " " + PointHour + ":" + PointMinute + ":" + PointSecond;


                                                            DateFound = true;
                                                        }
                                                        newCtr--;
                                                    } while (DateFound == false);
                                                }
                                                catch { }
                                                DateFound = false;

                                            }
                                            CtrToStart++;
                                        } while (ResFound == false);
                                        break;
                                    }
                                    CtrToStart++;
                                } while (true);
                            }
                            catch
                            {
                            }

                            if (AckGetBt)
                            {
                                sFactoryName = "DefaultPlant";
                                if (PreviousFacName != sFactoryName)
                                {
                                    string name = sFactoryName.TrimEnd(new char[] { ' ' });
                                    name = name.TrimStart(new char[] { ' ' });
                                    string desc = "Plant";
                                    InsertItemsInDataBase("Plant", null, name + "|" + desc, iUnit, iFScale, iCpl, idetc, iWin, iFltrType, iFltrVal, iMesure, iLor, iFreq, dualChnl);
                                    PreviousFacName = sFactoryName;
                                }
                                if (PreviousEqupname != sResourceName)
                                {
                                    string name = sResourceName.TrimEnd(new char[] { ' ' });
                                    name = name.TrimStart(new char[] { ' ' });
                                    string desc = "Area";
                                    InsertItemsInDataBase("Area", "1P", name + "|" + desc, iUnit, iFScale, iCpl, idetc, iWin, iFltrType, iFltrVal, iMesure, iLor, iFreq, dualChnl);
                                }
                                if (PreviousComname != sElementName)
                                {
                                    string name = sElementName.TrimEnd(new char[] { ' ' });
                                    name = name.TrimStart(new char[] { ' ' });
                                    string desc = "Train";
                                    InsertItemsInDataBase("Train", sResourceID, name + "|" + desc, iUnit, iFScale, iCpl, idetc, iWin, iFltrType, iFltrVal, iMesure, iLor, iFreq, dualChnl);
                                }
                                if (PreviousSubCompname != sSubElementName)
                                {
                                    string name = sSubElementName.TrimEnd(new char[] { ' ' });
                                    name = name.TrimStart(new char[] { ' ' });
                                    string desc = "Machine";
                                    InsertItemsInDataBase("Machine", sElementID, name + "|" + desc, iUnit, iFScale, iCpl, idetc, iWin, iFltrType, iFltrVal, iMesure, iLor, iFreq, dualChnl);
                                }
                                if (dualChnl == offptctr)
                                {
                                    arrchannel++;
                                }
                                int BdualChannel = 0;
                                if (PreviousPointName != sPointName)
                                {
                                    dualChnl = 0;
                                }
                                else
                                {
                                    dualChnl = 1;
                                }
                                if (dualChnl == 1)
                                {
                                    SamePointDifferentChannel = true;
                                    if (dataEntered)
                                    {
                                        BdualChannel = 1;
                                    }
                                    else
                                    {
                                        BdualChannel = 0;
                                    }
                                }
                                else
                                {
                                    SamePointDifferentChannel = false;
                                    dataEntered = false;
                                    BdualChannel = 0;
                                    NewID = null;
                                }
                                offptctr = dualChnl;
                                {
                                    if (!SamePointDifferentChannel)
                                    {
                                        if (NewID == null)
                                        {
                                            string name = sPointName.TrimEnd(new char[] { ' ' });
                                            name = name.TrimStart(new char[] { ' ' });
                                            string desc = sPointDescription.TrimEnd(new char[] { ' ' });
                                            desc = desc.TrimStart(new char[] { ' ' });
                                            FinalPointName = name;
                                            InsertItemsInDataBase("Point", sSubElementID, name + "|" + desc, iUnit, iFScale, iCpl, idetc, iWin, iFltrType, iFltrVal, iMesure, iLor, iFreq, dualChnl);
                                        }
                                    }
                                }
                                if (dataEntered)
                                {
                                    bAlreadyEntered = true;
                                }
                                else
                                {
                                    bAlreadyEntered = false;
                                }
                                if (NewID != null)
                                {
                                    if (dualChnl == 1)
                                    {
                                        // SetChannelForDualMode(NewID, 1);
                                    }
                                    else
                                    {
                                        //SetPointParameters(NewID, iUnit, iFScale, iCpl, idetc, iWin, iFltrType, iFltrVal, iMesure, iLor, iFreq, dualChnl);
                                    }
                                    int startZero = 0;
                                    double[] DataFinal = new double[1];
                                    double[] dd = null;
                                    double[] Xvalues = null;
                                    byte[] Data = new byte[1];
                                    int dtCtr = 0;
                                    int dtfCtr = 0;
                                    bool tobreak = false;
                                    bool NewArray = true;
                                    {
                                        string[] Parameters = { iUnit.ToString(), iMesure.ToString(), iLor.ToString(), "0", iFreq.ToString(), idetc.ToString() };
                                        ISVolt = false;
                                        IsInspection = false;
                                        ISUm = false;
                                        if (Convert.ToInt16(Parameters[0]) == 12)
                                        {
                                            ISVolt = true;
                                        }
                                        if (Convert.ToInt16(Parameters[0]) > 13)
                                        {
                                            IsInspection = true;
                                        }

                                        if (Convert.ToInt16(Parameters[0]) == 4 || Convert.ToInt16(Parameters[0]) == 8 || Convert.ToInt16(Parameters[0]) == 10)
                                        {
                                            ISUm = true;
                                        }
                                        if (PreviousFacName == sFactoryName && PreviousEqupname == sResourceName && PreviousComname == sElementName && PreviousSubCompname == sSubElementName && PreviousPointName == sPointName)
                                        {
                                            SamePointDifferentChannel = true;
                                        }
                                        else
                                            SamePointDifferentChannel = false;
                                        PreviousFacName = sFactoryName;
                                        PreviousEqupname = sResourceName;
                                        PreviousComname = sElementName;
                                        PreviousSubCompname = sSubElementName;
                                        PreviousPointName = sPointName;
                                        do
                                        {
                                            if (KeyFactor != MainArr.Length - 3)
                                            {
                                                {
                                                    if (KeyFactor > MainArr.Length)
                                                    {
                                                        tobreak = true;
                                                        NewArray = false;
                                                    }
                                                }
                                            }
                                            if (NewArray == true)
                                            {
                                                if (KeyFactor >= MainArr.Length)
                                                {
                                                    tobreak = true;
                                                }
                                                else if (KeyFactor <= MainArr.Length - 3)
                                                {
                                                    if (MainArr[KeyFactor] == 0x58 && MainArr[KeyFactor + 1] == 0x02 && MainArr[KeyFactor + 2] == 0x06 && MainArr[KeyFactor + 3] == 0x01)
                                                        tobreak = true;
                                                }
                                                if (tobreak == false)
                                                {
                                                    try
                                                    {
                                                        if (MainArr[KeyFactor + 11] == 0x46 && MainArr[KeyFactor + 12] == 0x02 && MainArr[KeyFactor + 13] == 0x30 && MainArr[KeyFactor + 5] == 0x00 && MainArr[KeyFactor + 4] == 0x00 && MainArr[KeyFactor + 6] == 0x00 && MainArr[KeyFactor + 7] == 0x00)
                                                        {
                                                            Data[dtCtr] = MainArr[KeyFactor];
                                                            KeyFactor += 16;
                                                        }
                                                        else
                                                        {
                                                            Data[dtCtr] = MainArr[KeyFactor];
                                                        }
                                                    }
                                                    catch { tobreak = true; }

                                                }
                                                dtCtr++;
                                                KeyFactor++;
                                                Array.Resize(ref Data, Data.Length + 1);
                                            }

                                        } while (tobreak == false);

                                        dtCtr = 0;
                                        for (int d = 0; d < startZero; d++)
                                        {
                                            DataFinal[dtfCtr] = 0.0;
                                            Array.Resize(ref DataFinal, DataFinal.Length + 1);
                                            dtfCtr++;
                                        }
                                        if (Convert.ToInt16(Parameters[3]) < 3)
                                        {
                                            if (Convert.ToInt16(Parameters[1]) == 2 || Convert.ToInt16(Parameters[1]) == 3)
                                            {
                                                dd = CalculateData(DataFinal, Data, CalculatedFullScale);

                                                Xvalues = new double[dd.Length];

                                                double Difference = Convert.ToDouble(1 / (FreqArray[Convert.ToInt16(Parameters[4])] * 2.56));
                                                Difference = Math.Round(Difference, 6);
                                                for (int values = 0; values < dd.Length; values++)
                                                {
                                                    Xvalues[values] = Convert.ToDouble(Difference * (values));
                                                }
                                                if (overalFound == true)
                                                {
                                                    OverallValueDecoded = Math.Round(((OverallValueDecoded * CalculatedFullScale) / 32767), 3);
                                                }

                                                FillDataIntoDatabaseUsb(NewID, Xvalues, dd, Convert.ToBoolean(BdualChannel), PointMonth, Parameters[5]);
                                                dataEntered = !dataEntered;
                                            }
                                            else if (Convert.ToInt16(Parameters[1]) == 0 || Convert.ToInt16(Parameters[1]) == 1)
                                            {
                                                if (Convert.ToInt16(Parameters[1]) == 1)
                                                    PhaseExtraction = true;
                                                else
                                                    PhaseExtraction = false;
                                                dd = CalculateData(DataFinal, Data, CalculatedFullScale);
                                                int actLength = (dd.Length / 100) * 100;
                                                Xvalues = new double[actLength + 1];
                                                double Difference = Convert.ToDouble(FreqArray[Convert.ToInt16(Parameters[4])] / ResolutionFFT[Convert.ToInt16(Parameters[2])]);
                                                for (int values = 0; values < actLength + 1; values++)
                                                {
                                                    Xvalues[values] = Convert.ToDouble(Difference * (values));
                                                }
                                                if (overalFound == true)
                                                {
                                                    OverallValueDecoded = Math.Round(((OverallValueDecoded * CalculatedFullScale) / 32767), 3);
                                                }

                                                FillDataIntoDatabaseUsb(NewID, Xvalues, dd, Convert.ToBoolean(BdualChannel), PointMonth, Parameters[5]);
                                                dataEntered = !dataEntered;
                                            }
                                            else
                                            {
                                                dd = CalculateData(DataFinal, Data, CalculatedFullScale);
                                                Xvalues = new double[dd.Length];
                                                double Difference = Convert.ToDouble(1 / (FreqArray[Convert.ToInt16(Parameters[4])] * 2.56));
                                                Difference = Math.Round(Difference, 6);
                                                for (int values = 0; values < dd.Length; values++)
                                                {
                                                    Xvalues[values] = Convert.ToDouble(Difference * (values));
                                                }
                                                if (overalFound == true)
                                                {
                                                    OverallValueDecoded = Math.Round(((OverallValueDecoded * CalculatedFullScale) / 32767), 3);
                                                }
                                                //FillGapDataIntoDatabaseUsb(NewID, Xvalues, dd, Convert.ToBoolean(BdualChannel), PointMonth, Parameters[5]);
                                            }
                                        }
                                        else if (Convert.ToInt16(Parameters[3]) >= 3)
                                        {
                                            if (Convert.ToInt16(Parameters[1]) == 2)
                                            {
                                                dd = CalculateData(DataFinal, Data, CalculatedFullScale);
                                                Xvalues = new double[dd.Length];
                                                double Difference = Convert.ToDouble(1 / (FreqArray[Convert.ToInt16(Parameters[4])] * 2.56));
                                                Difference = Math.Round(Difference, 6);
                                                for (int values = 0; values < dd.Length; values++)
                                                {
                                                    Xvalues[values] = Convert.ToDouble(Difference * (values));
                                                }
                                                if (overalFound == true)
                                                {
                                                    OverallValueDecoded = Math.Round(((OverallValueDecoded * CalculatedFullScale) / 32767), 3);
                                                }

                                                FillDataIntoDatabaseUsb(NewID, Xvalues, dd, false, PointMonth, Parameters[5]);
                                                dataEntered = !dataEntered;

                                            }
                                            else if (Convert.ToInt16(Parameters[1]) == 3)
                                            {
                                                dd = CalculateData(DataFinal, Data, CalculatedFullScale);

                                                Xvalues = new double[dd.Length];
                                                double Difference = Convert.ToDouble(1 / (FreqArray[Convert.ToInt16(Parameters[4])] * 2.56));
                                                Difference = Math.Round(Difference, 6);

                                                for (int values = 0; values < dd.Length; values++)
                                                {
                                                    Xvalues[values] = Convert.ToDouble(Difference * (values));
                                                }
                                                if (overalFound == true)
                                                {
                                                    OverallValueDecoded = Math.Round(((OverallValueDecoded * CalculatedFullScale) / 32767), 3);
                                                }
                                                FillDataIntoDatabaseUsb(NewID, Xvalues, dd, false, PointMonth, Parameters[5]);
                                            }
                                            else if (Convert.ToInt16(Parameters[1]) == 0)
                                            {
                                                dd = CalculateData(DataFinal, Data, CalculatedFullScale);
                                                Xvalues = new double[dd.Length];
                                                double Difference = Convert.ToDouble(FreqArray[Convert.ToInt16(Parameters[4])] / ResolutionFFT[Convert.ToInt16(Parameters[2])]);
                                                for (int values = 0; values < dd.Length; values++)
                                                {
                                                    Xvalues[values] = Convert.ToDouble(Difference * (values));
                                                }
                                                if (overalFound == true)
                                                {
                                                    OverallValueDecoded = Math.Round(((OverallValueDecoded * CalculatedFullScale) / 32767), 3);
                                                }
                                                FillDataIntoDatabaseUsb(NewID, Xvalues, dd, false, PointMonth, Parameters[5]);
                                            }
                                            else
                                            {
                                                dataEntered = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }

                    } while (CtrToStart < MainArr.Length - 3);
                }
                catch { }
            }
        }


        private double[] CalculateData(double[] DataFinal, byte[] Data, double iFScale)
        {
            try
            {
                if (File.Exists(path + "Temp.dat"))
                {
                    File.Delete(path + "Temp.dat");
                }
                using (FileStream objStream = new FileStream(path + "Temp.dat", FileMode.Create, FileAccess.Write))
                {
                    objStream.Write(Data, 0, Data.Length);
                }
                double[] soundBytes = new double[0];
                string spath = path + "Temp.dat";
                try
                {
                    using (FileStream wav = new FileStream(spath, FileMode.Open, FileAccess.Read))
                    {
                        int ctr = 0;
                        short sample;
                        double[] narray = new double[0];
                        BinaryReader fr = new BinaryReader(wav);
                        while (true)
                        {
                            sample = fr.ReadInt16();
                            double SampleVal = Convert.ToDouble(sample);
                            Array.Resize(ref soundBytes, soundBytes.Length + 1);
                            if (SampleVal < 100)
                            {
                                SampleVal = Math.Round(SampleVal, 2);
                                soundBytes[soundBytes.Length - 1] = (SampleVal);
                            }
                            else
                            {
                                SampleVal = Math.Round(SampleVal);
                                soundBytes[soundBytes.Length - 1] = (SampleVal);
                            }
                            ctr++;
                        }
                    }
                }
                catch { }
                double MainCalculatedValue = 0;
                {
                    MainCalculatedValue = iFScale;
                }
                DataFinal = new double[soundBytes.Length];
                for (int i = 0; i < soundBytes.Length; i++)
                {
                    DataFinal[i] = (soundBytes[i] * MainCalculatedValue) / 32767;
                }
            }
            catch { }
            return DataFinal;
        }

        public void InsertItemsInDataBase(string sNodeType, string sParentID, string sDescription, int iUnit, int iFScale, int iCpl, int idetc, int iWin, int iFltrType, int iFltrVal, int iMesure, int iLor, int iFreq, int Channel)
        {
            try
            {
                if (sNodeType != "" && sParentID != "" && sDescription != "")
                {
                    string[] sSplittedValue = sDescription.Split(new char[] { '|' });
                    string sFactoryName = sSplittedValue[0];
                    string sFactoryDescription = sSplittedValue[1];
                    if (sNodeType == "Plant")
                    {
                        try
                        {
                            string facName = sFactoryName;
                            int hyPreviousID = 0;
                            int hyNextId = 0;
                            DbClass.executequery(CommandType.Text, "Insert into factory_info(Name,Description,DateCreated,PreviousID,NextID) values('" + facName + "','Factory','" + PublicClass.GetDatetime() + "','" + hyPreviousID + "','" + hyNextId + "')");
                            DataTable dtfacfinal = DbClass.getdata(CommandType.Text, "Select max(factory_id) from factory_info ");
                            hyPreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtfacfinal.Rows[0][0]), "0"))) - 1;
                            hyNextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtfacfinal.Rows[0][0]), "0"))) + 1;
                            DbClass.executequery(CommandType.Text, "Update factory_info set PreviousID = '" + hyPreviousID + "',NextID='" + hyNextId + "' where factory_id = '" + Convert.ToString(dtfacfinal.Rows[0][0]) + "'");
                            facid = Convert.ToString(dtfacfinal.Rows[0][0]);
                        }
                        catch
                        { }
                    }
                    else if (sNodeType == "Area")
                    {
                        string AreaName = sFactoryName;
                        string facid1 = facid;
                        int PreviousID = 0;
                        int NextId = 0;
                        DbClass.executequery(CommandType.Text, "Insert into area_info(Name,Description,FactoryID,PreviousID,NextID,DateCreated) values('" + AreaName + "','Area','" + facid1 + "','" + PreviousID + "','" + NextId + "','" + PublicClass.GetDatetime() + "')");
                        DataTable dtareafinal = DbClass.getdata(CommandType.Text, "Select max(Area_ID) from area_info ");
                        PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtareafinal.Rows[0][0]), "0"))) - 1;
                        NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtareafinal.Rows[0][0]), "0"))) + 1;
                        DbClass.executequery(CommandType.Text, "Update area_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Area_ID = '" + Convert.ToString(dtareafinal.Rows[0][0]) + "'");
                    }
                    else if (sNodeType == "Train")
                    {
                        string AreaName = sFactoryName;
                        string facid2 = facid;
                        int PreviousID = 0;
                        int NextId = 0;
                        DbClass.executequery(CommandType.Text, "Insert into train_info(Name,Description,PreviousID,NextID,Area_ID,Date) values('" + AreaName + "','Train','" + PreviousID + "','" + NextId + "','" + facid2 + "','" + PublicClass.GetDatetime() + "')");
                        DataTable dtTrainfinal = DbClass.getdata(CommandType.Text, "Select max(Train_ID) from train_info ");
                        PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtTrainfinal.Rows[0][0]), "0"))) - 1;
                        NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtTrainfinal.Rows[0][0]), "0"))) + 1;
                        DbClass.executequery(CommandType.Text, "Update train_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Train_ID = '" + Convert.ToString(dtTrainfinal.Rows[0][0]) + "'");
                    }
                    else if (sNodeType == "Machine")
                    {
                        string AreaName = sFactoryName;
                        string facid3 = facid;
                        int PreviousID = 0;
                        int NextId = 0;
                        DbClass.executequery(CommandType.Text, "Insert into machine_info(Name,Description,PreviousID,NextID,TrainID,DateCreated,RPM_Driven,PulseRev) values('" + sFactoryName + "','Machine','" + PreviousID + "','" + NextId + "','" + facid3 + "','" + PublicClass.GetDatetime() + "','1800','1')");
                        DataTable dtmacfinal = DbClass.getdata(CommandType.Text, "Select max(Machine_ID) from machine_info ");
                        PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtmacfinal.Rows[0][0]), "0"))) - 1;
                        NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtmacfinal.Rows[0][0]), "0"))) + 1;
                        DbClass.executequery(CommandType.Text, "Update machine_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Machine_ID = '" + Convert.ToString(dtmacfinal.Rows[0][0]) + "'");
                    }
                    else
                    {
                        if (Channel == 1)
                        {
                            Channel = 3;
                        }
                        DIPointType(iUnit, iFScale, iCpl, idetc, iWin, iFltrType, iFltrVal, iMesure, iLor, iFreq, Channel);
                        string prID = facid;
                        int PreviousID = 0;
                        int NextId = 0;
                        DbClass.executequery(CommandType.Text, "Insert into point(PointName,PointDesc,DataCreated,PreviousID,NextID,Machine_ID,DataSchedule,PointStatus,PointSchedule) values('" + sFactoryName + "','Point','" + PublicClass.GetDatetime() + "','" + PreviousID + "','" + NextId + "','" + prID + "','7','0','1')");
                        DataTable dtpointfinal = DbClass.getdata(CommandType.Text, "Select max(Point_ID) from point ");
                        PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtpointfinal.Rows[0][0]), "0"))) - 1;
                        NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtpointfinal.Rows[0][0]), "0"))) + 1;
                        DbClass.executequery(CommandType.Text, "Update point set PreviousID = '" + PreviousID + "',NextID='" + NextId + "',PointType_ID='" + untypeid + "' where Point_ID = '" + Convert.ToString(dtpointfinal.Rows[0][0]) + "'");
                        NewID = Convert.ToString(dtpointfinal.Rows[0][0]);
                    }
                }
            }
            catch { }
        }

        public void DIPointType(int iUnit, int iFScale, int iCpl, int idetc, int iWin, int iFltrType, int iFltrVal, int iMesure, int iLor, int iFreq, int Channel)
        {
            try
            {
                DataTable dtpoint = DbClass.getdata(CommandType.Text, "select max(ID)typepoint_id from Type_point");
                foreach (DataRow drsen in dtpoint.Rows)
                {
                    untypeid1 = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(drsen["typepoint_id"]), "0")) + 1;
                    string AlarmID = "0";
                    string sdID = "0";
                    string perID = "0";
                    string PointTypeName = Convert.ToString("DI-" + untypeid1);
                    DbClass.executequery(CommandType.Text, "Insert into type_point(Point_Name,Type_ID,Instrumentname,Alarm_ID,STDDeviationAlarm_ID,Percentage_AlarmID,Band_ID) values('" + PointTypeName + "','1','SKF/DI','" + AlarmID + "','" + sdID + "','" + perID + "','0')");

                    DataTable dt1 = DbClass.getdata(CommandType.Text, "select distinct ID from type_point where Point_name='" + PointTypeName + "'");
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        untypeid = (Convert.ToInt32(dr1["ID"]));
                    }
                    try
                    {
                        DbClass.executequery(CommandType.Text, "insert into di_point(Type_ID,FullScale,Sensitivity,Couple,DetectionType,WindowType,FilterType,FilterValue,Direction,CollectionType,MeasureType,Resolution,Frequency,Orders,SpecAvg, TimeAvg,Overlap,TriggerType,Slope,Levels,TriggerRange,ChannelType,Type_Unit) values('" + untypeid + "','" + iFScale + "','100.00','" + iCpl + "','" + idetc + "','" + iWin + "','" + iFltrType + "','" + iFltrVal + "','0','1','" + iMesure + "','" + iLor + "','" + iFreq + "','7','1','4','50','0','0','10','0','" + Channel + "','" + iUnit + "')");
                    }
                    catch { }
                }

            }
            catch { }
        }


        private bool CheckValsToEnter(double[] Vals)
        {
            int CtrToTest = Vals.Length / 2;
            bool Ack = true;
            double First = 0.0;
            try
            {
                for (int i = 0; i < CtrToTest; i++)
                {
                    if (First == Vals[i] && Vals[i] == 0.0)
                    {
                        Ack = false;
                    }
                    else
                    {
                        Ack = true;
                        break;
                    }
                    First = Vals[i];
                }
            }
            catch { }
            return Ack;
        }

        private double FindOverallVal(string Target)
        {
            double OverallVal = 0.0;
            int Ctr = 1;
            try
            {
                string[] XYVals = Target.Split(new string[] { "," }, StringSplitOptions.None);
                for (int i = 10; i < XYVals.Length; i++)
                {
                    string[] Val = XYVals[i].Split(new string[] { "|" }, StringSplitOptions.None);
                    double Xval = Convert.ToDouble(Val[0]);
                    double Yval = Convert.ToDouble(Val[1]);
                    if (OverallVal < Yval)
                        OverallVal = Yval;
                    Ctr++;
                }
            }
            catch { }
            return OverallVal;
        }

        private double FindOverallValPeakToPeak(string Target)
        {
            double OverallValH = 0.0;
            double OverallValL = 0.0;
            double Difference = 0.0;
            int Ctr = 1;
            try
            {
                string[] XYVals = Target.Split(new string[] { "," }, StringSplitOptions.None);
                string[] Val = null;
                double Xval = 0;
                double Yval = 0;
                for (int i = 10; i < XYVals.Length; i++)
                {
                    Val = XYVals[i].Split(new string[] { "|" }, StringSplitOptions.None);
                    Xval = Convert.ToDouble(Val[0]);
                    Yval = Convert.ToDouble(Val[1]);
                    if (OverallValH < Yval && Yval > 0)
                        OverallValH = Yval;
                    else if (OverallValL > Yval && Yval < 0)
                        OverallValL = Yval;
                    Ctr++;
                }

            }
            catch { }
            Difference = OverallValH - OverallValL;
            return Difference;
        }

        private double FindOverallValRms(string Target)
        {
            double OverallVal = 0.0;
            int Ctr = 1;
            try
            {
                string[] XYVals = Target.Split(new string[] { "," }, StringSplitOptions.None);
                for (int i = 10; i < XYVals.Length; i++)
                {
                    string[] Val = XYVals[i].Split(new string[] { "|" }, StringSplitOptions.None);
                    double Xval = Convert.ToDouble(Val[0]);
                    double Yval = Convert.ToDouble(Val[1]);
                    OverallVal = OverallVal + (Yval * Yval);
                    Ctr++;
                }
                OverallVal = Convert.ToDouble(OverallVal / Ctr);
                OverallVal = Math.Sqrt(OverallVal);
            }
            catch { }
            return OverallVal;
        }

        bool ISVolt = false;
        bool IsInspection = false;
        bool ISUm = false; double OverallValueDecoded = 0.0; string anotheroverall = null;
        private void FillDataIntoDatabaseUsb(string UID, double[] XValues, double[] YValues, bool SamePointDifferentChannel, string PointDate, string Detection)
        {
            try
            {
                StringBuilder DataXY = new StringBuilder();
                StringBuilder DataX = new StringBuilder();
                StringBuilder DataY = new StringBuilder();
                string XYFinalData = null;
                double overallVal = 0.0;
                string ValueX = ""; string ValueY = "";
                string[] sarrXTData = new string[0];

                if (CheckValsToEnter(YValues) || IsInspection)
                {
                    try
                    {
                        if (YValues.Length > 2)
                        {
                            if (measuretypedi == "2")
                            {
                                DataXY.Append("0|" + Convert.ToString(YValues[0]) + ",");
                                DataX.Append("0");
                                DataX.Append("|");
                                DataY.Append(Convert.ToString(YValues[0]));
                                DataY.Append("|");
                                for (int i = 1; i < XValues.Length; i++)
                                {
                                    DataXY.Append(Convert.ToString(XValues[i - 1]));
                                    DataXY.Append("|");
                                    DataX.Append(Convert.ToString(XValues[i - 1]));
                                    DataX.Append("|");
                                    DataXY.Append(Convert.ToString(YValues[i]));
                                    DataXY.Append(",");
                                    DataY.Append(Convert.ToString(YValues[i]));
                                    DataY.Append("|");
                                }
                            }
                            else
                            {
                                DataXY.Append("0|0,");
                                DataX.Append("0");
                                DataX.Append("|");
                                DataY.Append("0");
                                DataY.Append("|");
                                for (int i = 1; i < XValues.Length; i++)
                                {
                                    DataXY.Append(Convert.ToString(XValues[i]));
                                    DataXY.Append("|");
                                    DataX.Append(Convert.ToString(XValues[i]));
                                    DataX.Append("|");
                                    DataXY.Append(Convert.ToString(YValues[i]));
                                    DataXY.Append(",");
                                    DataY.Append(Convert.ToString(YValues[i]));
                                    DataY.Append("|");
                                }
                            }
                            XYFinalData = Convert.ToString(DataXY);
                            ValueX = Convert.ToString(DataX);
                            ValueY = Convert.ToString(DataY);

                            if (Convert.ToInt16(Detection) == 1 || Convert.ToInt16(Detection) == 3)
                            {
                                if (OverallValueDecoded == 0.0)
                                {
                                    overallVal = FindOverallVal(XYFinalData);
                                    overallVal = Math.Round(overallVal, 6);
                                }
                                else
                                    overallVal = OverallValueDecoded;
                            }
                            else if (Convert.ToInt16(Detection) == 0)
                            {
                                if (OverallValueDecoded == 0.0)
                                {
                                    overallVal = FindOverallValRms(XYFinalData);
                                    overallVal = Math.Round(overallVal, 6);
                                }
                                else
                                    overallVal = OverallValueDecoded;
                            }
                            else if (Convert.ToInt16(Detection) == 2 || Convert.ToInt16(Detection) == 4)
                            {
                                if (OverallValueDecoded == 0.0)
                                {
                                    overallVal = FindOverallValPeakToPeak(XYFinalData);
                                    overallVal = Math.Round(overallVal, 6);
                                }
                                else
                                    overallVal = OverallValueDecoded;
                            }
                            try
                            {
                                string v_point_id = NewID;
                                string v_point_name = FinalPointName;
                                string v_Point_Type = typeidfordi;
                                string v_measure_time = Convert.ToDateTime(PointDate).ToString("yyyy-MM-dd HH:mm:ss");
                                // string v_measure_time = Convert.ToDateTime(PublicClass.GetDatetime()).ToString("yyyy-MM-dd HH:mm:ss");
                                string v_accel_ch1 = "0";
                                string v_accel_a = "0";
                                string v_accel_h = "0";
                                string v_accel_v = "0";
                                string v_vel_ch1 = "0";
                                string v_vel_a = "0";
                                string v_vel_h = "0";
                                string v_vel_v = "0";
                                string v_displ_ch1 = "0";
                                string v_displ_a = "0";
                                string v_displ_h = "0";
                                string v_displ_v = "0";
                                string v_crest_factor_ch1 = "0";
                                string v_crest_factor_a = "0";
                                string v_crest_factor_h = "0";
                                string v_crest_factor_v = "0";
                                string v_bearing_ch1 = "0";
                                string v_bearing_a = "0";
                                string v_bearing_h = "0";
                                string v_bearing_v = "0";
                                string v_ordertrace_ch1_real = "0";
                                string v_ordertrace_ch1_image = "0";
                                string v_ordertrace_a_real = "0";
                                string v_ordertrace_a_image = "0";
                                string v_ordertrace_h_real = "0";
                                string v_ordertrace_h_image = "0";
                                string v_ordertrace_v_real = "0";
                                string v_ordertrace_v_image = "0";
                                string v_ordertrace_rpm = "0";

                                string v_time_a_X = "0|"; string v_time_a_Y = "";
                                string v_time_h_X = "0|"; string v_time_h_Y = "";
                                string v_time_v_X = "0|"; string v_time_v_Y = "";
                                string v_time_CH1_X = "0|"; string v_time_CH1_Y = "";

                                string v_power_a_X = "0|"; string v_power_a_Y = "";
                                string v_power_h_X = "0|"; string v_power_h_Y = "";
                                string v_power_v_X = "0|"; string v_power_v_Y = "";
                                string v_power_Ch1_X = "0|"; string v_power_Ch1_Y = "";

                                switch (directionDi)
                                {
                                    case "2"://other radial
                                        {
                                            if (typeIDforDI == "0" || typeIDforDI == "23")
                                            {
                                                if (checkdata == false)
                                                {
                                                    v_accel_h = Convert.ToString(overallVal);
                                                    anotheroverall = v_accel_h;
                                                }
                                                else
                                                { v_accel_h = anotheroverall + "," + Convert.ToString(overallVal); }
                                            }
                                            //vel
                                            else if (typeIDforDI == "1" || typeIDforDI == "2" || typeIDforDI == "5" || typeIDforDI == "6" || typeIDforDI == "24" || typeIDforDI == "25")
                                            { v_vel_h = Convert.ToString(overallVal); }
                                            //disp
                                            else if (typeIDforDI == "3" || typeIDforDI == "4" || typeIDforDI == "7" || typeIDforDI == "8" || typeIDforDI == "9" || typeIDforDI == "10" || typeIDforDI == "26" || typeIDforDI == "27")
                                            {
                                                v_displ_h = Convert.ToString(overallVal);
                                            }
                                            if (measuretypedi == "0" || measuretypedi == "1")
                                            {
                                                if (checkdata == false)
                                                {
                                                    v_power_h_X = ValueX;
                                                    v_power_h_Y = ValueY;
                                                }
                                                else
                                                {
                                                    v_power_Ch1_X = ValueX;
                                                    v_power_Ch1_Y = ValueY;
                                                }
                                            }
                                            else if (measuretypedi == "2")
                                            {
                                                if (checkdata == false)
                                                {
                                                    v_time_h_X = ValueX;
                                                    v_time_h_Y = ValueY;
                                                }
                                                else
                                                {
                                                    v_time_CH1_X = ValueX;
                                                    v_time_CH1_Y = ValueY;
                                                }
                                            }
                                            break;
                                        }
                                    case "0"://hor
                                        {
                                            //Acc
                                            if (typeIDforDI == "0" || typeIDforDI == "23")
                                            {
                                                if (checkdata == false)
                                                {
                                                    v_accel_h = Convert.ToString(overallVal);
                                                    anotheroverall = v_accel_h;
                                                }
                                                else
                                                { v_accel_h = anotheroverall + "," + Convert.ToString(overallVal); }
                                            }
                                            //vel
                                            else if (typeIDforDI == "1" || typeIDforDI == "2" || typeIDforDI == "5" || typeIDforDI == "6" || typeIDforDI == "24" || typeIDforDI == "25")
                                            { v_vel_h = Convert.ToString(overallVal); }
                                            //disp
                                            else if (typeIDforDI == "3" || typeIDforDI == "4" || typeIDforDI == "7" || typeIDforDI == "8" || typeIDforDI == "9" || typeIDforDI == "10" || typeIDforDI == "26" || typeIDforDI == "27")
                                            {
                                                v_displ_h = Convert.ToString(overallVal);
                                            }
                                            if (measuretypedi == "0" || measuretypedi == "1")
                                            {
                                                if (checkdata == false)
                                                {
                                                    v_power_h_X = ValueX;
                                                    v_power_h_Y = ValueY;
                                                }
                                                else
                                                {
                                                    v_power_Ch1_X = ValueX;
                                                    v_power_Ch1_Y = ValueY;
                                                }
                                            }
                                            else if (measuretypedi == "2")
                                            {
                                                if (checkdata == false)
                                                {
                                                    v_time_h_X = ValueX;
                                                    v_time_h_Y = ValueY;
                                                }
                                                else
                                                {
                                                    v_time_CH1_X = ValueX;
                                                    v_time_CH1_Y = ValueY;
                                                }
                                            }
                                            break;
                                        }
                                    case "1"://ver
                                        {
                                            //Acc
                                            if (typeIDforDI == "0" || typeIDforDI == "23")
                                            {
                                                v_accel_v = Convert.ToString(overallVal);
                                            }
                                            //vel
                                            else if (typeIDforDI == "1" || typeIDforDI == "2" || typeIDforDI == "5" || typeIDforDI == "6" || typeIDforDI == "24" || typeIDforDI == "25")
                                            { v_vel_v = Convert.ToString(overallVal); }
                                            //disp
                                            else if (typeIDforDI == "3" || typeIDforDI == "4" || typeIDforDI == "7" || typeIDforDI == "8" || typeIDforDI == "9" || typeIDforDI == "10" || typeIDforDI == "26" || typeIDforDI == "27")
                                            {
                                                v_displ_v = Convert.ToString(overallVal);
                                            }
                                            if (measuretypedi == "0" || measuretypedi == "1")
                                            {
                                                if (checkdata == false)
                                                {
                                                    v_power_v_X = ValueX;
                                                    v_power_v_Y = ValueY;
                                                }
                                                else
                                                {
                                                    v_power_Ch1_X = ValueX;
                                                    v_power_Ch1_Y = ValueY;
                                                }
                                            }
                                            else if (measuretypedi == "2")
                                            {
                                                if (checkdata == false)
                                                {
                                                    v_time_v_X = ValueX;
                                                    v_time_v_Y = ValueY;
                                                }
                                                else
                                                {
                                                    v_time_CH1_X = ValueX;
                                                    v_time_CH1_Y = ValueY;
                                                }
                                            }
                                            break;
                                        }
                                    case "3"://Axial
                                        {
                                            //Acc
                                            if (typeIDforDI == "0" || typeIDforDI == "23")
                                            {
                                                v_accel_a = Convert.ToString(overallVal);
                                            }
                                            //vel
                                            else if (typeIDforDI == "1" || typeIDforDI == "2" || typeIDforDI == "5" || typeIDforDI == "6" || typeIDforDI == "24" || typeIDforDI == "25")
                                            {
                                                v_vel_a = Convert.ToString(overallVal);
                                            }
                                            //disp
                                            else if (typeIDforDI == "3" || typeIDforDI == "4" || typeIDforDI == "7" || typeIDforDI == "8" || typeIDforDI == "9" || typeIDforDI == "10" || typeIDforDI == "26" || typeIDforDI == "27")
                                            {
                                                v_displ_a = Convert.ToString(overallVal);
                                            }
                                            if (measuretypedi == "0" || measuretypedi == "1")
                                            {
                                                if (checkdata == false)
                                                {
                                                    v_power_a_X = ValueX;
                                                    v_power_a_Y = ValueY;
                                                }
                                                else
                                                {
                                                    v_power_Ch1_X = ValueX;
                                                    v_power_Ch1_Y = ValueY;
                                                }
                                            }
                                            else if (measuretypedi == "2")
                                            {
                                                if (checkdata == false)
                                                {
                                                    v_time_a_X = ValueX;
                                                    v_time_a_Y = ValueY;
                                                }
                                                else
                                                {
                                                    v_time_CH1_X = ValueX;
                                                    v_time_CH1_Y = ValueY;
                                                }
                                            }
                                            break;
                                        }
                                }
                                // DbClass.executequery(CommandType.Text, " insert into point_data(Point_ID,Point_name, Point_Type,  Measure_time,  accel_a,  accel_h,    accel_v,accel_ch1, vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values       ( '" + NewID + "' ,'" + FinalPointName + "', '" + untypeid + "', '" + PointDate + "' , '" + overallVal + "' ,'" + overallVal + "','" + overallVal + "' ,'" + overallVal + "' , '0'   ,'0' ,'0'  ,'0' ,'0' , '0', '0' ,'0' ,'0', '0' ,'0','0', '0' ,'0','0', '0'  ,'0' ,'0' ,'0', '0' , '0','0','0','0', '0' ,  '0|', '0|', '0|' ,'0|' ,'" + ValueX + "','0|' ,'0|','0|' ,'0|','0|' ,'0|' , '0|'  ,'0|','0|','0|' ,'0|'  ,'0|','0|','0|','0|','0|','0|', '0|', '0|' ,'0|','0|','0|','0|' ,'0|','0|','0|','0|', '0|','0|','0|', '0|'  ,  '', '', '' ,'' ,'" + ValueY + "','' ,'','' ,'','' ,'' , ''  ,'','','' ,''  ,'','','','','','', '', '' ,'','','','' ,'','','','', '','','', ''     ,  '0', '0','0','0' ,'' ,'',  '" + PublicClass.GetDatetime() + "' ,'')  ");
                                if (checkdata == false)
                                {
                                    //if (PhaseExtraction)
                                    //{
                                    //    if (PhaseAng != null)
                                    //    {
                                    //        // point_phase
                                    //        DbClass.executequery(CommandType.Text, "Insert into point_phase(Point_ID,Point_Phase) Values ('" + v_point_id + "','" + PhaseAng + "')");

                                    //    }
                                    //}
                                    phaseAng1 = PhaseAng;
                                    DbClass.executequery(CommandType.Text, "insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,  accel_a,  accel_h,    accel_v,accel_ch1, vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values       ( '" + v_point_id + "' ,'" + v_point_name + "','" + v_Point_Type + "', '" + v_measure_time + "' , '" + v_accel_a + "' ,'" + v_accel_h + "','" + v_accel_v + "' ,'" + v_accel_ch1 + "' , '" + v_vel_a + "'   ,'" + v_vel_h + "' ,'" + v_vel_v + "'  ,'" + v_vel_ch1 + "' ,'" + v_displ_a + "' ,  '" + v_displ_h + "' , '" + v_displ_v + "' ,'" + v_displ_ch1 + "'  ,'" + v_crest_factor_a + "', '" + v_crest_factor_h + "'  ,'" + v_crest_factor_v + "' , '" + v_crest_factor_ch1 + "',  '" + v_bearing_a + "' ,'" + v_bearing_h + "', '" + v_bearing_v + "',  '" + v_bearing_ch1 + "'  ,'" + v_ordertrace_a_real + "'  ,'" + v_ordertrace_h_real + "' ,'" + v_ordertrace_v_real + "',  '" + v_ordertrace_ch1_real + "'  ,   '" + v_ordertrace_a_image + "','" + v_ordertrace_h_image + "','" + v_ordertrace_v_image + "','" + v_ordertrace_ch1_image + "', '" + v_ordertrace_rpm + "'  ,  '" + v_time_a_X + "', '" + v_time_h_X + "', '" + v_time_v_X + "' ,'0|' ,'" + v_power_a_X + "','" + v_power_h_X + "' ,'" + v_power_v_X + "','0|' ,'0|','0|' ,'0|' ,'0|' ,'0|' ,'0|' ,'0|'  ,'0|'   ,'0|' ,'0|' ,'0|' ,'0|' ,'0|' ,'0|' ,'0|' ,'0|'  ,'0|' ,'0|' ,'0|' ,'0|'  ,'0|' ,'0|' ,'0|' ,'0|' , '0|' ,'0|' ,'0|' , '0|'   ,  '" + v_time_a_Y + "', '" + v_time_h_Y + "', '" + v_time_v_Y + "' ,'0|' ,'" + v_power_a_Y + "','" + v_power_h_Y + "' ,'" + v_power_v_Y + "','0|' ,'0|' ,'0|'  ,'0|'  ,'0|'   ,'0|' ,'0|' ,'0|' ,'0|'  ,'0|' ,'0|' ,'0|' ,'0|' ,'0|' ,'0|' ,'0|' ,'0|'  ,'0|' ,'0|' ,'0|' ,'0|'  ,'0|' ,'0|' ,'0|' ,'0|' ,'0|' ,'0|' ,'0|' , '0|'    ,  '0','0','0','0' ,'' ,'',  '" + PublicClass.GetDatetime() + "' , '" + PhaseAng + "') ");
                                }
                                else
                                {
                                    string manual = phaseAng1 + "?" + PhaseAng;
                                    if (measuretypedi == "2")
                                    {
                                        //string manual = phaseAng1 + "??" + PhaseAng;
                                        DbClass.executequery(CommandType.Text, "update point_data set manual='" + manual + "', accel_Ch1='" + overallVal + "', timeCH1_X='" + v_time_CH1_X + "',timeCH1_Y='" + v_time_CH1_Y + "' where Point_ID='" + v_point_id + "'");
                                    }
                                    else
                                    {
                                        DbClass.executequery(CommandType.Text, "update point_data set manual='" + manual + "', accel_Ch1='" + overallVal + "', PCH1_X='" + v_power_Ch1_X + "',PCH1_Y='" + v_power_Ch1_Y + "' where Point_ID='" + v_point_id + "'");
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                    catch { }
                }


            }
            catch { }
        }

        //-----------upload------//

        bool UsbSlcted = false;
        public bool UsbSelected
        {
            get
            {
                return UsbSlcted;
            }
            set
            {
                UsbSlcted = value;
            }
        }


        public void C911callconnection()
        {
            try
            {
                string PathToUpLoad = null;
                frmdownload dw = new frmdownload();
                _objMain.lblStatus.Caption = "Status: Select the Right Route";
                dw.ShowDialog();
                bool IsInstrument = dw.IsInstrumentSelected;
                if (dw.IsCancelClicked == false)
                {
                    SplashScreenManager.ShowForm(typeof(WaitForm4));
                    if (IsInstrument == false)
                    {
                        PathToUpLoad = dw.PCPath;
                        PublicClass.Path = PathToUpLoad;
                    }
                    else
                    {
                        PathToUpLoad = dw.textBox1.Text;
                        PublicClass.Path = PathToUpLoad;
                    }
                    if (dw.IsInstrumentSelected == true)
                    {
                        C911downloaddata(PublicClass.routename, PublicClass.Path);
                        if (check == "true")
                        {
                            _objMain.lblStatus.Caption = "Status: Download Route Successfully";
                            MessageBox.Show("Route Download Sucessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Connection Error..Connect Device Properly", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        SplashScreenManager.CloseForm();
                    }
                }
            }
            catch { }
        }

        string Directpath = null;
        public void callconnection()
        {
            try
            {
                frmdownload dw = new frmdownload();
                _objMain.lblStatus.Caption = "Status: Select the Right Route";
                dw.ShowDialog();
                if (dw.IsCancelClicked == false)
                {
                    SplashScreenManager.ShowForm(typeof(WaitForm4));
                    dataDown = true;
                    DataTable dt = new DataTable();
                    string lastvlue = PublicClass.RouteId;
                    dt = DbClass.getdata(CommandType.Text, "select rd1.type_id,rd.route_level from route.route_data rd inner join route.route_data1 rd1 on rd1.id=rd.id where rd.id='" + PublicClass.RouteId + "' ");
                    PublicClass.RouteId = Convert.ToString(dt.Rows[0]["type_id"]);
                    PublicClass.Routelevel = Convert.ToString(dt.Rows[0]["route_level"]);
                    ConnectwithINST();
                    bool Ackk = FactoryAlreadyInInstrument(PublicClass.routename);
                    if (Ackk == true)
                    {
                        if (dw.IsInstrumentSelected == true)
                        {
                            Direct = null;
                            Directdownload(PublicClass.User_DataBase, CtrPresntChk);
                            if (checkbool == "false")
                            {
                                MessageBox.Show("Connection Error..Connect Device Properly", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Route Download Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PublicClass.RouteId = lastvlue;
                                SplashScreenManager.CloseForm();

                            }
                        }
                        else
                        {
                            Direct = "true";
                            Directpath = dw.PCPath;
                            Directdownload(PublicClass.User_DataBase, CtrPresntChk);
                            MessageBox.Show("Route Download Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PublicClass.RouteId = lastvlue;
                            SplashScreenManager.CloseForm();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Route Not Exist/Instrument Not Connected Properly", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PublicClass.RouteId = lastvlue;
                        SplashScreenManager.CloseForm();
                        //return;
                    }
                }
            }
            catch { }
            try
            {
                if (m_objSerialPort.IsOpen == true)
                {
                    m_objSerialPort.Write("\x06");
                    m_objSerialPort.Write("\x04");
                    m_objSerialPort.Close();
                }
            }
            catch { }
        }




        Hashtable objListOfAvgs = new Hashtable();
        int[] ResArray = new int[0];
        string[] ResArrayDirection = new string[0]; double[] AlrVals = null;
        private byte[] UploadArray = new byte[1];
        private int UpArrayCount = 0; bool checkcatch = true;
        string TourName = null; int HeightCountOfTour = 0; public int CtrPresntChk = 0;
        public bool FactoryAlreadyInInstrument(string FactoryInDatabase)
        {
            CtrPresntChk = 0;
            FactoryInDatabase = FactoryInDatabase.TrimEnd(new char[] { ' ' });
            FactoryInDatabase = FactoryInDatabase.TrimStart(new char[] { ' ' });
            string RoutesInInst = null;
            bool Ack = false;
            try
            {
                for (int a = 0; a < Routename.Length - 1; a++)
                {
                    string[] Routename1 = Convert.ToString(Routename[a]).Split('|');
                    RoutesInInst = Routename1[0].TrimEnd(new char[] { ' ' });
                    if (RoutesInInst == FactoryInDatabase)
                        Ack = true;
                    if (Ack == false)
                        CtrPresntChk++;
                }
            }
            catch { checkcatch = false; }
            return Ack;
        }


        int ValForBar = 0;
        private byte[] RouteNoForDeletion(string target, string RouteNM)
        {
            string[] Routes = RouteNM.Split(new string[] { ",", "|" }, StringSplitOptions.None);
            string numbertosend = null;
            byte[] Number = null;
            char test = Convert.ToChar(" ");
            string[] targetwithmedia = target.ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                for (int i = 0; i < Routes.Length; i++)
                {
                    Routes[i] = Routes[i].TrimEnd(new char[] { test });
                    if (Routes[i] == targetwithmedia[0].Trim())
                        numbertosend = Routes[i + 1];
                    if (numbertosend != null)
                        break;
                }
                Number = Encoding.ASCII.GetBytes(numbertosend);
            }
            catch { }
            return Number;
        }

        public void DIDelete(string Dbname, string ID, string RouteNum)
        {
            try
            {
                byte[] Q1 = { 0x01, 0x30, 0x30, 0x32, 0x38, 0x02 };
                byte[] Q12 = { 0x1F, 0x00, 0x00, 0x03 };
                byte[] Q2 = { 0x01, 0x30, 0x30, 0x32, 0x44, 0x02, 0x03, 0x35, 0x42 };
                byte[] Q3 = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x44, 0x45, 0x4C, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x32, 0x33 };
                byte[] Q4 = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x36, 0x38 };
                byte[] Q5 = { 0x01, 0x30, 0x32, 0x37, 0x46, 0x02, 0x30, 0x30, 0x36, 0x31, 0x00, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x94, 0x2A, 0xE4, 0x8F, 0xCC, 0xF6, 0x43, 0x8C, 0xA8, 0xF8, 0xFF, 0x01, 0x00, 0xC8, 0xFF, 0xFF, 0x20, 0x1B, 0x05 };
                byte[] Q51 = { 0x1B, 0x03, 0x08, 0x00, 0x0B, 0x1B, 0x08, 0x07, 0x00, 0x50, 0x39, 0xF8, 0x03, 0x1B, 0x04, 0x10, 0x1B, 0x04, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x06, 0x1B, 0x03, 0x70, 0xD4, 0x0C, 0x00, 0x98, 0x72, 0x8E, 0x01, 0x24, 0xF5, 0x10, 0x0E, 0x84, 0xF5, 0x10, 0x0E, 0x60, 0x8E, 0x01, 0xCC, 0xF4, 0x10, 0x0E, 0x30, 0xDE, 0x8A, 0x01, 0x0B, 0x00, 0xFF, 0x01, 0xDC, 0xF6, 0x10, 0x0E, 0x00, 0x00, 0x10, 0x0E, 0x1B, 0x17, 0x03 };
                byte[] Q6 = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x52, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x36, 0x36 };
                byte[] Q7 = { 0x01, 0x30, 0x30, 0x31, 0x36, 0x02, 0x03, 0x34, 0x43 };
                byte[] Q5Test = { 0x01, 0x30, 0x32, 0x37, 0x46, 0x02, 0x30, 0x30, 0x36, 0x31, 0x00, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x94, 0x2A, 0xE4, 0x8F, 0xCC, 0xF6, 0x43, 0x8C, 0xA8, 0xF8, 0xFF, 0x01, 0x00, 0xC8, 0xFF, 0xFF, 0x20, 0x1B, 0x05, 0x02, 0x1B, 0x03, 0x08, 0x00, 0x0B, 0x1B, 0x08, 0x07, 0x00, 0x50, 0x39, 0xF8, 0x03, 0x1B, 0x04, 0x10, 0x1B, 0x04, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x06, 0x1B, 0x03, 0x70, 0xD4, 0x0C, 0x00, 0x98, 0x72, 0x8E, 0x01, 0x24, 0xF5, 0x10, 0x0E, 0x84, 0xF5, 0x10, 0x0E, 0x60, 0x8E, 0x01, 0xCC, 0xF4, 0x10, 0x0E, 0x30, 0xDE, 0x8A, 0x01, 0x0B, 0x00, 0xFF, 0x01, 0xDC, 0xF6, 0x10, 0x0E, 0x00, 0x00, 0x10, 0x0E, 0x1B, 0x17, 0x03, 0x33, 0x43 };
                byte Recieve = 0;
                int Count = 0;
                byte[] testbyte1 = new byte[2];
                byte[] RouteNo = new byte[1];
                StringBuilder Routes = new StringBuilder();
                ValForBar++;
                byte[] no = RouteNoForDeletion(Dbname, RouteNum);
                m_objSerialPort.Write(SHEXFIVE);//Sending 05
                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                ValForBar++;

                m_objSerialPort.Write(SHEXFIVE);//Sending 05
                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                Count = 0;
                ValForBar++;

                Count = Count + SumOfByteArray(Q1) + SumOfByteArray(Q12) + SumOfByteArray(no);
                m_objSerialPort.Write(Q1, 0, Q1.Length);//Sending Question 1
                //RouteNo = Encoding.ASCII.GetBytes(Convert.ToString(iSelectedIndex + 1));
                m_objSerialPort.Write(no, 0, no.Length);//Sending Key Of The Route
                m_objSerialPort.Write(Q12, 0, Q12.Length);//Sending Secong Part Of Question 1
                ValForBar++;


                byte[] test = SelectValueToBeSended(Convert.ToUInt64(Count));//Extracting Ending Value of Q1
                m_objSerialPort.Write(test, 0, test.Length);//Sending The End value of Q1
                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                m_objSerialPort.Write(SHEXFIVE);//Sending 05
                ValForBar++;

                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                m_objSerialPort.Write(Q2, 0, Q2.Length);// Sending Question 2
                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                m_objSerialPort.Write(SHEXFIVE);//Sending 05
                ValForBar++;

                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                m_objSerialPort.Write(Q3, 0, Q3.Length);//Sending Question 3
                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                m_objSerialPort.Write(Q4, 0, Q4.Length);//Sending Q4
                ValForBar++;

                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                Count = 0;
                m_objSerialPort.Write(Q5Test, 0, Q5Test.Length);//Sending Question 5

                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                ValForBar++;
                InitializeAgain();
                FillRoutesCombo(m_sarrData);
                RouteNumbers = sblRtNumbers.ToString();

            }
            catch { }
        }



        public void C911uploaddata(string routename, string path)
        {
            try
            {
                RootExtracter(routename);
                check = "true";
            }
            catch { check = "false"; }
        }

        public void C911downloaddata(string routename, string path)
        {
            try
            {

                check = "true";
            }
            catch { check = "false"; }
        }

        public void DIuploaddata(string routename)
        {
            try
            {
                if (routename != null)
                {
                    ConnectwithINST();
                    if (UsbSelected == false)
                    {
                        bool Ackk = FactoryAlreadyInInstrument(routename);
                        if (Ackk == true)
                        {
                            DIDelete(routename, Convert.ToString(CtrPresntChk), RouteNumbers);
                        }
                    }
                    if (checkcatch == true)
                    {
                        UploadValuesExtraction(routename, treeLength);
                        _objMain.lblStatus.Caption = "Complete";
                    }
                    m_objSerialPort.Write("\x06");
                    m_objSerialPort.Write("\x04");
                    m_objSerialPort.Close();

                }
            }
            catch { }
        }

        StringBuilder sFinalRoot = null;
        string id = null;
        string routename = null;
        string routelevel = null;
        string routelevelid = null;
        string databasename = null;
        string date = null;
        DataTable dtfactory = new DataTable();
        DataTable dtarea = new DataTable();
        DataTable dttrain = new DataTable();
        DataTable dtmachine = new DataTable();
        DataTable dtpoint = new DataTable();
        StringBuilder Plant = null;
        StringBuilder Area = null;
        StringBuilder Train = null;
        StringBuilder machine = null;
        StringBuilder point = null;


        private string RootExtracter(string RouteToUpload)
        {
            try
            {
                _objMain.lblStatus.Caption = "Status: Start Filling values";
                DataTable dt = new DataTable();
                dt = RouteConn.getdata(CommandType.Text, "select distinct rdd.ID,rdd.Route_Name,rdd.Route_Level,rdd.DatabaseName,rdd.Date,rd1.Type_ID from route_data rdd left join route_data1 rd1 on rdd.ID=rd1.ID  where rdd.ID='" + PublicClass.RouteId + "' order by ID asc");
                foreach (DataRow dr in dt.Rows)
                {
                    id = Convert.ToString(dr["id"]);
                    routename = Convert.ToString(dr["Route_Name"]);
                    routelevel = Convert.ToString(dr["Route_Level"]);
                    routelevelid = Convert.ToString(dr["Type_Id"]);
                    databasename = Convert.ToString(dr["DatabaseName"]);
                    date = Convert.ToString(dr["date"]);
                    DataTable objAreaDataTable = new DataTable();
                    string Level_Name = PublicClass.LevelName;
                    switch (Level_Name)
                    {
                        case " --Select--":
                            {
                                break;
                            }
                        case "Plant":
                            {
                                if (PublicClass.currentInstrument == "Kohtect-C911")
                                {
                                    insertPlant(routelevelid);
                                }
                                else
                                {
                                    insert_Plant(routelevelid);
                                }
                                break;
                            }
                        case "Area":
                            {
                                if (PublicClass.currentInstrument == "Kohtect-C911")
                                {
                                    insert_Area(routelevelid);
                                }
                                else
                                { insert_Area(routelevelid); }
                                break;
                            }
                        case "Train":
                            {
                                if (PublicClass.currentInstrument == "Kohtect-C911")
                                {
                                    insert_Train(routelevelid);
                                }
                                else
                                {
                                    insert_Train(routelevelid);
                                }
                                break;
                            }
                        case "Machine":
                            {
                                if (PublicClass.currentInstrument == "Kohtect-C911")
                                {
                                    insert_Machine(routelevelid);
                                }
                                else
                                {
                                    insert_Machine(routelevelid);
                                }
                                break;
                            }
                        case "Point":
                            {
                                if (PublicClass.currentInstrument == "Kohtect-C911")
                                {
                                    insert_Point(routelevelid);
                                }
                                else
                                {
                                    insert_Point(routelevelid);
                                }
                                break;
                            }
                    }
                }
            }
            catch { }
            return Convert.ToString(sFinalRoot);
        }

        private void insertPlant(string factory_id)
        {
            try
            {
                string root = PublicClass.Path;
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                dtfactory = DbClass.getdata(CommandType.Text, "select distinct * from factory_info where Factory_ID='" + factory_id + "' ");
                dtarea = DbClass.getdata(CommandType.Text, "select distinct * from Area_Info  ");
                dttrain = DbClass.getdata(CommandType.Text, "select distinct * from train_info ");
                dtmachine = DbClass.getdata(CommandType.Text, "select distinct * from machine_info");
                dtpoint = DbClass.getdata(CommandType.Text, "select distinct * from point");
                foreach (DataRow drfactory in dtfactory.Select("Factory_ID ='" + routelevelid + "'"))
                {                   
                    Directory.CreateDirectory(Path.Combine(root, Convert.ToString(drfactory["name"])));  
                  
                    //creating routes.src file //
                    string fileName = root + "\\" + "routes.src";
                    try
                    {
                        if (File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }
                        else
                        {
                            StreamReader sr = null; //new StreamReader();
                            StreamWriter sw = null;//new StreamWriter();
                            try
                            {
                                byte[] lastOne = new byte[1];
                                byte[] lastSec = new byte[1];
                                int checkSUM = 0;
                                string Chksum = null;
                                string[] chkarray = null;
                                byte[] MainArr;

                                FileStream objStream = null; FileStream objStream1 = null;
                                byte[] Q1 = { 0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                                byte[] Q2 = { 0x00 }; byte[] Q3 = { 0x2F };
                                byte[] Q4 = { 0x01, 0x00, 0x00, 0x03, 0xE8, 0x02, 0x00, 0x01, 0x03, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02 };
                               // byte[] Q5 = { 0x0E }; byte[] Q6 = { 0xCF };

                                // string filename = @"C:\Users\SONY\Desktop\Route3.src";
                                using (objStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                {
                                    objStream.Write(Q1, 0, Q1.Length);
                                    for (int i = 0; i < 240; i++)
                                    {
                                        objStream.Write(Q2, 0, Q2.Length);
                                    }

                                    byte[] facilityDescription = System.Text.Encoding.ASCII.GetBytes("route");
                                    objStream.Write(facilityDescription, 0, facilityDescription.Length);
                                    objStream.Write(Q3, 0, Q3.Length);

                                    byte[] facilityDescription1 = System.Text.Encoding.ASCII.GetBytes("plant");
                                    objStream.Write(facilityDescription1, 0, facilityDescription1.Length);
                                    objStream.Write(Q3, 0, Q3.Length);

                                    byte[] facilityDescription2 = System.Text.Encoding.ASCII.GetBytes("train");
                                    objStream.Write(facilityDescription2, 0, facilityDescription2.Length);
                                    objStream.Write(Q3, 0, Q3.Length);

                                    byte[] facilityDescription3 = System.Text.Encoding.ASCII.GetBytes("machine");
                                    objStream.Write(facilityDescription3, 0, facilityDescription3.Length);

                                    for (int i = 0; i < 168; i++)
                                    {
                                        objStream.Write(Q2, 0, Q2.Length);
                                    }

                                    objStream.Write(Q4, 0, Q4.Length);

                                    for (int i = 0; i < 46; i++)
                                    {
                                        objStream.Write(Q2, 0, Q2.Length);
                                    }
                                    MainArr = new byte[(int)objStream.Length];
                                    int contents = objStream.Read(MainArr, 0, (int)objStream.Length);
                                    byte[] NameExtracter = new byte[contents];

                                    for (int i = 1; i < NameExtracter.Length; i++)
                                    {
                                        checkSUM += Convert.ToInt32(NameExtracter[i]);
                                    }

                                    checkSUM = checkSUM % 128;
                                    Chksum = DeciamlToHexadeciaml(checkSUM);
                                    chkarray = Chksum.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                    if (chkarray.Length > 1)
                                    {
                                        lastOne = new byte[1];
                                        lastOne[0] = Convert.ToByte(findVal(chkarray[0].ToString()));
                                        lastSec = new byte[1];
                                        lastSec[0] = Convert.ToByte(findVal(chkarray[1].ToString()));
                                    }
                                    else
                                    {
                                        lastOne = new byte[1];
                                        lastOne[0] = Convert.ToByte(0);
                                        lastSec = new byte[1];
                                        lastSec[0] = Convert.ToByte(findVal(chkarray[0].ToString()));
                                    }

                                    objStream.Write(lastOne, 0, lastOne.Length);
                                    objStream.Write(lastSec, 0, lastSec.Length);



                                }

                                //calc CheckSUM for last two bytes

                                using (objStream1 = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                                {
                                    MainArr = new byte[(int)objStream1.Length];
                                    int contents = objStream1.Read(MainArr, 0, (int)objStream1.Length);
                                    byte[] NameExtracter = new byte[contents];

                                    for (int i = 1; i < NameExtracter.Length; i++)
                                    {
                                        checkSUM += Convert.ToInt32(NameExtracter[i]);
                                    }

                                    checkSUM = checkSUM % 128;
                                    Chksum = DeciamlToHexadeciaml(checkSUM);
                                    chkarray = Chksum.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                    if (chkarray.Length > 1)
                                    {
                                        lastOne = new byte[1];
                                        lastOne[0] = Convert.ToByte(findVal(chkarray[0].ToString()));
                                        lastSec = new byte[1];
                                        lastSec[0] = Convert.ToByte(findVal(chkarray[1].ToString()));
                                    }
                                    else
                                    {
                                        lastOne = new byte[1];
                                        lastOne[0] = Convert.ToByte(0);
                                        lastSec = new byte[1];
                                        lastSec[0] = Convert.ToByte(findVal(chkarray[0].ToString()));
                                    }

                                    objStream1.Write(lastOne, 0, lastOne.Length);
                                    objStream1.Write(lastSec, 0, lastSec.Length);
                                }

                                
                            }
                            catch { }
                        }
                    }
                    catch { }

                    //------------------//

                    root = root + "\\" + Convert.ToString(drfactory["name"]);
                    foreach (DataRow drarea in dtarea.Select("FactoryID='" + Convert.ToString(drfactory["Factory_ID"]).Trim() + "' "))
                    {                       
                        Directory.CreateDirectory(Path.Combine(root, Convert.ToString(drarea["name"])));
                        root = root + "\\" + Convert.ToString(drarea["name"]);

                        foreach (DataRow drtrain in dttrain.Select("area_id= '" + Convert.ToString(drarea["area_id"]).Trim() + "' "))
                        {
                            Directory.CreateDirectory(Path.Combine(root, Convert.ToString(drtrain["name"])));
                            root = root + "\\" + Convert.ToString(drtrain["name"]);
                            foreach (DataRow drMachine in dtmachine.Select("trainid ='" + Convert.ToString(drtrain["train_id"]).Trim() + "'  "))
                            {
                                Directory.CreateDirectory(Path.Combine(root, Convert.ToString(drMachine["name"])));
                                root = root + "\\" + Convert.ToString(drMachine["name"]);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        int cCounter = 0; int pcount = 0; int Acount = 0; int Tcount = 0; int Mcount = 0;
        private void insert_Plant(string factory_id)
        {
            try
            {
                sFinalRoot = new StringBuilder();
                dtfactory = DbClass.getdata(CommandType.Text, "select distinct * from factory_info where Factory_ID='" + factory_id + "' ");
                dtarea = DbClass.getdata(CommandType.Text, "select distinct * from Area_Info  ");
                dttrain = DbClass.getdata(CommandType.Text, "select distinct * from train_info ");
                dtmachine = DbClass.getdata(CommandType.Text, "select distinct * from machine_info");
                dtpoint = DbClass.getdata(CommandType.Text, "select distinct * from point");
                foreach (DataRow drfactory in dtfactory.Select("Factory_ID ='" + routelevelid + "'"))
                {
                    Plant = new StringBuilder();
                    _objMain.lblStatus.Caption = "Status: Inserting Plant values";
                    Plant.Append(factory_id); Plant.Append("."); Plant.Append(Convert.ToString(drfactory["name"]));
                    Plant.Append("."); Plant.Append(Convert.ToString(drfactory["Description"])); Plant.Append("//");
                    sFinalRoot.Append(Plant); sFinalRoot.Append("E!");

                    foreach (DataRow drarea in dtarea.Select("FactoryID='" + Convert.ToString(drfactory["Factory_ID"]).Trim() + "' "))
                    {
                        Area = new StringBuilder();
                        if (Acount > 0)
                        {
                            sFinalRoot.Append(Plant); sFinalRoot.Append("E!");
                            Tcount = 0; cCounter = 0;
                        }
                        _objMain.lblStatus.Caption = "Status: Inserting Area values";
                        Area.Append(Convert.ToString(drarea["area_id"])); Area.Append("."); Area.Append(Convert.ToString(drarea["name"]));
                        Area.Append("."); Area.Append(Convert.ToString(drarea["Description"]));
                        sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");

                        foreach (DataRow drtrain in dttrain.Select("area_id= '" + Convert.ToString(drarea["area_id"]).Trim() + "' "))
                        {
                            Train = new StringBuilder();
                            if (Tcount > 0)
                            {
                                sFinalRoot.Append(Plant); sFinalRoot.Append("E!");
                                sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");
                                cCounter = 0;
                            }
                            _objMain.lblStatus.Caption = "Status: Inserting Train values";
                            Train.Append(Convert.ToString(drtrain["train_id"])); Train.Append("."); Train.Append(Convert.ToString(drtrain["name"]));
                            Train.Append("."); Train.Append(Convert.ToString(drtrain["Description"]));
                            sFinalRoot.Append(Train); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("S!");

                            foreach (DataRow drMachine in dtmachine.Select("trainid ='" + Convert.ToString(drtrain["train_id"]).Trim() + "'  "))
                            {
                                machine = new StringBuilder();
                                if (cCounter > 0)
                                {
                                    sFinalRoot.Append(Plant); sFinalRoot.Append("E!");
                                    sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");
                                    sFinalRoot.Append(Train); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("S!");
                                }
                                string mac = Convert.ToString(drMachine["machine_id"]);
                                _objMain.lblStatus.Caption = "Status: Inserting Machine values";
                                machine.Append(Convert.ToString(drMachine["machine_id"])); machine.Append("."); machine.Append(Convert.ToString(drMachine["name"]));
                                machine.Append("."); machine.Append(Convert.ToString(drMachine["Description"]));
                                sFinalRoot.Append(machine); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("P..");
                                point = new StringBuilder();
                                foreach (DataRow drpoint in dtpoint.Select("machine_id='" + mac.Trim() + "' "))
                                {
                                    _objMain.lblStatus.Caption = "Status: Inserting Points Data";
                                    DataTable dtpt = new DataTable();
                                    dtpt = DbClass.getdata(CommandType.Text, "select pt.point_ID,pt.PointName,pt.PointType_ID,pt.PointDesc from point pt inner join type_point tp on pt.PointType_ID=tp.id where pt.PointType_ID !='0' and pt.point_ID ='" + Convert.ToString(drpoint["Point_ID"]) + "'&& pt.machine_id='" + mac + "' ");
                                    foreach (DataRow dr in dtpt.Rows)
                                    {
                                        point.Append(Convert.ToString(dr["Point_ID"])); point.Append("."); point.Append(Convert.ToString(dr["PointName"]));
                                        point.Append("."); point.Append(Convert.ToString(dr["PointDesc"])); point.Append("//");
                                    }
                                }
                                sFinalRoot.Append(point);
                                sFinalRoot.Append("NW");
                                cCounter++;
                            }
                            Tcount++;
                        }
                        Acount++;
                    }
                }
            }
            catch { }
        }

        private void insert_Area(string factory_id)
        {
            try
            {
                cCounter = 0;
                sFinalRoot = new StringBuilder();
                dtarea = DbClass.getdata(CommandType.Text, "select distinct * from Area_Info");
                dttrain = DbClass.getdata(CommandType.Text, "select distinct * from train_info");
                dtmachine = DbClass.getdata(CommandType.Text, "select distinct * from machine_info");
                dtpoint = DbClass.getdata(CommandType.Text, "select distinct * from point");

                Plant = new StringBuilder();
                _objMain.lblStatus.Caption = "Status: Inserting Plant values";
                Plant.Append(factory_id); Plant.Append("."); Plant.Append("DefaultPlant");
                Plant.Append("."); Plant.Append("Plant"); Plant.Append("//");
                sFinalRoot.Append(Plant); sFinalRoot.Append("E!");

                foreach (DataRow drarea in dtarea.Select("area_id='" + factory_id + "'"))
                {
                    Area = new StringBuilder();
                    if (Acount > 0)
                    {
                        sFinalRoot.Append(Plant); sFinalRoot.Append("E!");
                        Tcount = 0; cCounter = 0;
                    }
                    _objMain.lblStatus.Caption = "Status: Inserting Area values";
                    Area.Append(Convert.ToString(drarea["area_id"])); Area.Append("."); Area.Append(Convert.ToString(drarea["name"]));
                    Area.Append("."); Area.Append(Convert.ToString(drarea["Description"]));
                    sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");

                    foreach (DataRow drtrain in dttrain.Select("area_id= '" + Convert.ToString(drarea["area_id"]).Trim() + "' "))
                    {
                        Train = new StringBuilder();
                        if (Tcount > 0)
                        {
                            sFinalRoot.Append(Plant); sFinalRoot.Append("E!");
                            sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");
                            cCounter = 0;
                        }
                        _objMain.lblStatus.Caption = "Status: Inserting Train values";
                        Train.Append(Convert.ToString(drtrain["train_id"])); Train.Append("."); Train.Append(Convert.ToString(drtrain["name"]));
                        Train.Append("."); Train.Append(Convert.ToString(drtrain["Description"]));
                        sFinalRoot.Append(Train); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("S!");

                        foreach (DataRow drMachine in dtmachine.Select("trainid ='" + Convert.ToString(drtrain["train_id"]).Trim() + "'"))
                        {
                            machine = new StringBuilder();
                            if (cCounter > 0)
                            {
                                sFinalRoot.Append(Plant); sFinalRoot.Append("E!");
                                sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");
                                sFinalRoot.Append(Train); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("S!");
                            }
                            string mac = Convert.ToString(drMachine["machine_id"]);
                            _objMain.lblStatus.Caption = "Status: Inserting Machine values";
                            machine.Append(Convert.ToString(drMachine["machine_id"])); machine.Append("."); machine.Append(Convert.ToString(drMachine["name"]));
                            machine.Append("."); machine.Append(Convert.ToString(drMachine["Description"]));
                            sFinalRoot.Append(machine); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("P..");
                            point = new StringBuilder();
                            foreach (DataRow drpoint in dtpoint.Select("machine_id='" + mac.Trim() + "' "))
                            {
                                _objMain.lblStatus.Caption = "Status: Inserting Points Data";
                                DataTable dtpt = new DataTable();
                                dtpt = DbClass.getdata(CommandType.Text, "select pt.point_ID,pt.PointName,pt.PointType_ID,pt.PointDesc from point pt inner join type_point tp on pt.PointType_ID=tp.id where pt.PointType_ID !='0' and pt.point_ID ='" + Convert.ToString(drpoint["Point_ID"]) + "'&& pt.machine_id='" + mac + "' ");
                                foreach (DataRow dr in dtpt.Rows)
                                {
                                    point.Append(Convert.ToString(dr["Point_ID"])); point.Append("."); point.Append(Convert.ToString(dr["PointName"]));
                                    point.Append("."); point.Append(Convert.ToString(dr["PointDesc"])); point.Append("//");
                                }
                            }
                            sFinalRoot.Append(point);
                            sFinalRoot.Append("NW");
                            cCounter++;
                        }
                        Tcount++;
                    }
                    Acount++;
                }
            }
            catch { }
        }

        private void insert_Train(string factory_id)
        {
            try
            {
                sFinalRoot = new StringBuilder();
                dtarea = DbClass.getdata(CommandType.Text, "select distinct * from Area_Info  ");
                dttrain = DbClass.getdata(CommandType.Text, "select distinct * from train_info ");
                dtmachine = DbClass.getdata(CommandType.Text, "select distinct * from machine_info");
                dtpoint = DbClass.getdata(CommandType.Text, "select distinct * from point");


                Plant = new StringBuilder();
                _objMain.lblStatus.Caption = "Status: Inserting Plant values";
                Plant.Append(factory_id); Plant.Append("."); Plant.Append("DefaultPlant");
                Plant.Append("."); Plant.Append("Plant"); Plant.Append("//");
                sFinalRoot.Append(Plant); sFinalRoot.Append("E!");

                Area = new StringBuilder();
                _objMain.lblStatus.Caption = "Status: Inserting Area values";
                Area.Append(factory_id); Area.Append("."); Area.Append("DefaultArea");
                Area.Append("."); Area.Append("Area");
                sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");

                foreach (DataRow drtrain in dttrain.Select("train_id= '" + factory_id + "' "))
                {
                    Train = new StringBuilder();
                    if (Tcount > 0)
                    {
                        sFinalRoot.Append(Plant); sFinalRoot.Append("E!");
                        sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");
                        cCounter = 0;
                    }
                    _objMain.lblStatus.Caption = "Status: Inserting Train values";
                    Train.Append(Convert.ToString(drtrain["train_id"])); Train.Append("."); Train.Append(Convert.ToString(drtrain["name"]));
                    Train.Append("."); Train.Append(Convert.ToString(drtrain["Description"]));
                    sFinalRoot.Append(Train); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("S!");

                    foreach (DataRow drMachine in dtmachine.Select("trainid ='" + Convert.ToString(drtrain["train_id"]).Trim() + "'  "))
                    {
                        machine = new StringBuilder();
                        if (cCounter > 0)
                        {
                            sFinalRoot.Append(Plant); sFinalRoot.Append("E!");
                            sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");
                            sFinalRoot.Append(Train); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("S!");
                        }
                        string mac = Convert.ToString(drMachine["machine_id"]);
                        _objMain.lblStatus.Caption = "Status: Inserting Machine values";
                        machine.Append(Convert.ToString(drMachine["machine_id"])); machine.Append("."); machine.Append(Convert.ToString(drMachine["name"]));
                        machine.Append("."); machine.Append(Convert.ToString(drMachine["Description"]));
                        sFinalRoot.Append(machine); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("P..");
                        point = new StringBuilder();
                        foreach (DataRow drpoint in dtpoint.Select("machine_id='" + mac.Trim() + "' "))
                        {
                            _objMain.lblStatus.Caption = "Status: Inserting Points Data";
                            DataTable dtpt = new DataTable();
                            dtpt = DbClass.getdata(CommandType.Text, "select pt.point_ID,pt.PointName,pt.PointType_ID,pt.PointDesc from point pt inner join type_point tp on pt.PointType_ID=tp.id where pt.PointType_ID !='0' and pt.point_ID ='" + Convert.ToString(drpoint["Point_ID"]) + "'&& pt.machine_id='" + mac + "' "); foreach (DataRow dr in dtpt.Rows)
                            {
                                point.Append(Convert.ToString(dr["Point_ID"])); point.Append("."); point.Append(Convert.ToString(dr["PointName"]));
                                point.Append("."); point.Append(Convert.ToString(dr["PointDesc"])); point.Append("//");
                            }
                        }
                        sFinalRoot.Append(point); sFinalRoot.Append("NW"); cCounter++;
                    }
                    Tcount++;
                }

            }
            catch { }
        }

        private void insert_Machine(string factory_id)
        {
            try
            {
                sFinalRoot = new StringBuilder();
                dtarea = DbClass.getdata(CommandType.Text, "select distinct * from Area_Info  ");
                dttrain = DbClass.getdata(CommandType.Text, "select distinct * from train_info ");
                dtmachine = DbClass.getdata(CommandType.Text, "select distinct * from machine_info");
                dtpoint = DbClass.getdata(CommandType.Text, "select distinct * from point");

                Plant = new StringBuilder();
                _objMain.lblStatus.Caption = "Status: Inserting Plant values";
                Plant.Append(factory_id); Plant.Append("."); Plant.Append("DefaultPlant");
                Plant.Append("."); Plant.Append("Plant");
                sFinalRoot.Append(Plant); sFinalRoot.Append("E!");

                Area = new StringBuilder();
                _objMain.lblStatus.Caption = "Status: Inserting Area values";
                Area.Append(factory_id); Area.Append("."); Area.Append("DefaultArea");
                Area.Append("."); Area.Append("Area");
                sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");

                Train = new StringBuilder();
                _objMain.lblStatus.Caption = "Status: Inserting Train values";
                Train.Append(factory_id); Train.Append("."); Train.Append("DefaultTrain");
                Train.Append("."); Train.Append("Train");
                sFinalRoot.Append(Train); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("S!");

                foreach (DataRow drMachine in dtmachine.Select("machine_id ='" + factory_id + "'  "))
                {
                    machine = new StringBuilder();
                    if (cCounter > 0)
                    {
                        sFinalRoot.Append(Plant); sFinalRoot.Append("E!");
                        sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");
                        sFinalRoot.Append(Train); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("S!");
                    }
                    string mac = Convert.ToString(drMachine["machine_id"]);
                    _objMain.lblStatus.Caption = "Status: Inserting Machine values";
                    machine.Append(Convert.ToString(drMachine["machine_id"])); machine.Append("."); machine.Append(Convert.ToString(drMachine["name"]));
                    machine.Append("."); machine.Append(Convert.ToString(drMachine["Description"]));
                    sFinalRoot.Append(machine); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("P..");
                    point = new StringBuilder();

                    foreach (DataRow drpoint in dtpoint.Select("machine_id='" + mac.Trim() + "' "))
                    {
                        _objMain.lblStatus.Caption = "Status: Inserting Points Data";
                        DataTable dtpt = new DataTable();
                        dtpt = DbClass.getdata(CommandType.Text, "select pt.point_ID,pt.PointName,pt.PointType_ID,pt.PointDesc from point pt inner join type_point tp on pt.PointType_ID=tp.id where pt.PointType_ID !='0' and pt.point_ID ='" + Convert.ToString(drpoint["Point_ID"]) + "'&& pt.machine_id='" + mac + "' ");
                        foreach (DataRow dr in dtpt.Rows)
                        {
                            point.Append(Convert.ToString(dr["Point_ID"])); point.Append("."); point.Append(Convert.ToString(dr["PointName"]));
                            point.Append("."); point.Append(Convert.ToString(dr["PointDesc"])); point.Append("//");
                        }
                    }
                    sFinalRoot.Append(point); sFinalRoot.Append("NW"); cCounter++;
                }

            }
            catch { }
        }

        private void insert_Point(string factory_id)
        {
            try
            {
                sFinalRoot = new StringBuilder();
                dtarea = DbClass.getdata(CommandType.Text, "select distinct * from Area_Info");
                dttrain = DbClass.getdata(CommandType.Text, "select distinct * from train_info ");
                dtmachine = DbClass.getdata(CommandType.Text, "select distinct * from machine_info");
                dtpoint = DbClass.getdata(CommandType.Text, "select distinct * from point");

                Plant = new StringBuilder();
                _objMain.lblStatus.Caption = "Status: Inserting Plant values";
                Plant.Append(factory_id); Plant.Append("."); Plant.Append("DefaultPlant");
                Plant.Append("."); Plant.Append("Plant");
                sFinalRoot.Append(Plant); sFinalRoot.Append("E!");

                Area = new StringBuilder();
                _objMain.lblStatus.Caption = "Status: Inserting Area values";
                Area.Append(factory_id); Area.Append("."); Area.Append("DefaultArea");
                Area.Append("."); Area.Append("Area");
                sFinalRoot.Append(Area); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("C!");

                Train = new StringBuilder();
                _objMain.lblStatus.Caption = "Status: Inserting Train values";
                Train.Append(factory_id); Train.Append("."); Train.Append("DefaultTrain");
                Train.Append("."); Train.Append("Train");
                sFinalRoot.Append(Train); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("S!");

                machine = new StringBuilder();
                _objMain.lblStatus.Caption = "Status: Inserting Machine values";
                machine.Append(factory_id); machine.Append("."); machine.Append("DefaultMachine");
                machine.Append("."); machine.Append("Machine");
                sFinalRoot.Append(machine); sFinalRoot.Append("."); sFinalRoot.Append("//"); sFinalRoot.Append("P..");

                point = new StringBuilder();
                foreach (DataRow drpoint in dtpoint.Select("Point_ID='" + factory_id + "' "))
                {
                    _objMain.lblStatus.Caption = "Status: Inserting Points Data";
                    DataTable dtpt = new DataTable();
                    dtpt = DbClass.getdata(CommandType.Text, "select pt.point_ID,pt.PointName,pt.PointType_ID,pt.PointDesc from point pt inner join type_point tp on pt.PointType_ID=tp.id where pt.PointType_ID !='0' and pt.point_ID ='" + Convert.ToString(drpoint["Point_ID"]) + "' ");
                    foreach (DataRow dr in dtpt.Rows)
                    {
                        point.Append(Convert.ToString(dr["Point_ID"])); point.Append("."); point.Append(Convert.ToString(dr["PointName"]));
                        point.Append("."); point.Append(Convert.ToString(dr["PointDesc"])); point.Append("//");
                    }
                    sFinalRoot.Append(point); sFinalRoot.Append("NW");
                }
            }
            catch { }
        }

        string directionDi, measuretypedi, typeIDforDI, pointnamefordi, typeidfordi, channeltypefordi;
        private string PointInformationExtract1(string target)
        {
            directionDi = null; measuretypedi = null;
            NewID = target;
            string CompleteInformation = null;
            try
            {
                DataTable dt = DbClass.getdata(CommandType.Text, "select * from di_point di inner join type_point tp on di.Type_ID=tp.ID left join point pt on tp.id=pt.PointType_ID where pt.Point_ID='" + target + "'");
                foreach (DataRow drsen in dt.Rows)
                {
                    CompleteInformation = "@" + Convert.ToString(drsen["Type_Unit"]) + "#" + Convert.ToString(drsen["FullScale"]) + "$" + Convert.ToString(drsen["Sensitivity"]) + "%" + Convert.ToString(drsen["Couple"]) + "^" + Convert.ToString(drsen["DetectionType"]) + "&" + Convert.ToString(drsen["WindowType"]) + "*" + Convert.ToString(drsen["FilterType"]) + "+" + Convert.ToString(drsen["FilterValue"]) + "=" + Convert.ToString(drsen["Direction"]) + "<" + Convert.ToString(drsen["CollectionType"]) + ">" + Convert.ToString(drsen["MeasureType"]) + "?" + Convert.ToString(drsen["Resolution"]) + "{" + Convert.ToString(drsen["Frequency"]) + "}" + Convert.ToString(drsen["Orders"]) + "~" + Convert.ToString(drsen["Overlap"]) + "`" + Convert.ToString(drsen["TriggerType"]) + "[" + Convert.ToString(drsen["Slope"]) + "]" + Convert.ToString(drsen["Levels"]) + ":" + Convert.ToString(drsen["TriggerRange"]) + ";" + Convert.ToString(drsen["ChannelType"]);
                    directionDi = Convert.ToString(drsen["Direction"]); measuretypedi = Convert.ToString(drsen["MeasureType"]); typeIDforDI = Convert.ToString(drsen["Type_Unit"]);
                    typeidfordi = Convert.ToString(drsen["Type_ID"]); channeltypefordi = Convert.ToString(drsen["ChannelType"]);
                }
            }
            catch { }
            return CompleteInformation;
        }

        private string PointInformationExtract(string target, string t1, string t2)
        {
            string CompleteInformation = null;
            try
            {
                DataTable dt = DbClass.getdata(CommandType.Text, "select * from di_point di inner join type_point tp on di.Type_ID=tp.ID left join point pt on tp.id=pt.PointType_ID where pt.Point_ID='" + target + "'");
                int i = AlrVals.Length;
                Array.Resize(ref AlrVals, AlrVals.Length + 3);
                foreach (DataRow drsen in dt.Rows)
                {
                    CompleteInformation = "@" + Convert.ToString(drsen["Type_Unit"]) + "#" + Convert.ToString(drsen["FullScale"]) + "$" + Convert.ToString(drsen["Sensitivity"]) + "%" + Convert.ToString(drsen["Couple"]) + "^" + Convert.ToString(drsen["DetectionType"]) + "&" + Convert.ToString(drsen["WindowType"]) + "*" + Convert.ToString(drsen["FilterType"]) + "+" + Convert.ToString(drsen["FilterValue"]) + "=" + Convert.ToString(drsen["Direction"]) + "<" + Convert.ToString(drsen["CollectionType"]) + ">" + Convert.ToString(drsen["MeasureType"]) + "?" + Convert.ToString(drsen["Resolution"]) + "{" + Convert.ToString(drsen["Frequency"]) + "}" + Convert.ToString(drsen["Orders"]) + "~" + Convert.ToString(drsen["Overlap"]) + "`" + Convert.ToString(drsen["TriggerType"]) + "[" + Convert.ToString(drsen["Slope"]) + "]" + Convert.ToString(drsen["Levels"]) + ":" + Convert.ToString(drsen["TriggerRange"]) + ";" + Convert.ToString(drsen["ChannelType"]);
                    AlrVals[i] = 0;//Convert.ToDouble(drsen["LowAlarm"]);
                    AlrVals[i + 1] = 0;//Convert.ToDouble(drsen["MediumAlarm"]);
                    AlrVals[i + 2] = 0;//Convert.ToDouble(drsen["HighAlarm"]);
                    objListOfAvgs.Add(t1 + "|" + t2 + "!!" + CompleteInformation, Convert.ToString(drsen["SpecAvg"]) + "!" + Convert.ToString(drsen["TimeAvg"]));

                }
            }
            catch { }

            return CompleteInformation;
        }

        public string check = null;
        private void UploadValuesExtraction(string RouteToUpload, int TotalRT)
        {
            TotalInternalTour = TotalRT;
            int Ctr = 0;
            int mCtr = 0;
            try
            {
                objListOfAvgs = new Hashtable();
                string test = RootExtracter(RouteToUpload);
                string[] parameters = test.Split(new string[] { "E!", "C!", "S!", "P..", "NW" }, StringSplitOptions.None);
                string Facility = null;
                string FacilityDis = null;
                string Equipment = null;
                string EquipmentDis = null;
                string Component = null;
                string ComponentDis = null;
                string SubComponent = null;
                string SubComponentDis = null;
                string Point = null;
                bool same = false;
                ResArray = new int[0];
                ResArrayDirection = new string[0];
                int ParLnth = parameters.Length;
                do
                {
                    AlrVals = new double[0];
                    string[] splitter = null;
                    string[] splitter1 = null;
                    string[] splitter2 = null;
                    StringBuilder points = new StringBuilder();
                    splitter = parameters[0 + Ctr].Split(new string[] { "." }, StringSplitOptions.None);
                    splitter1 = splitter[1].Split(new string[] { "//" }, StringSplitOptions.None);
                    splitter2 = splitter[2].Split(new string[] { "//" }, StringSplitOptions.None);
                    Facility = splitter1[0];
                    FacilityDis = splitter2[0];
                    splitter = parameters[1 + Ctr].Split(new string[] { "." }, StringSplitOptions.None);
                    splitter1 = splitter[1].Split(new string[] { "//" }, StringSplitOptions.None);
                    splitter2 = splitter[2].Split(new string[] { "//" }, StringSplitOptions.None);

                    Equipment = splitter1[0];

                    EquipmentDis = splitter2[0];
                    splitter = parameters[2 + Ctr].Split(new string[] { "." }, StringSplitOptions.None);
                    splitter1 = splitter[1].Split(new string[] { "//" }, StringSplitOptions.None);
                    splitter2 = splitter[2].Split(new string[] { "//" }, StringSplitOptions.None);

                    Component = splitter1[0];

                    ComponentDis = splitter2[0];
                    splitter = parameters[3 + Ctr].Split(new string[] { "." }, StringSplitOptions.None);
                    splitter1 = splitter[1].Split(new string[] { "//" }, StringSplitOptions.None);
                    splitter2 = splitter[2].Split(new string[] { "//" }, StringSplitOptions.None);

                    SubComponent = splitter1[0];

                    SubComponentDis = splitter2[0];
                    splitter = parameters[4 + Ctr].Split(new string[] { "//" }, StringSplitOptions.None);
                    if (splitter.Length > 0)
                    {
                        objListOfAvgs = new Hashtable();
                        for (int i = 0; i < splitter.Length - 1; i++)
                        {
                            string[] tt = splitter[i].Split(new string[] { "." }, StringSplitOptions.None);
                            points.Append(tt[1]);
                            points.Append("|");
                            points.Append(tt[2]);
                            points.Append("!!");
                            string Information = PointInformationExtract(tt[0], tt[1], tt[2]);
                            points.Append(Information);
                            points.Append(",");
                        }
                    }
                    Point = Convert.ToString(points);
                    if (Point == "")
                    {
                        check = "false";
                        return;
                    }
                    if (UsbSelected)
                    {
                        _objMain.lblStatus.Caption = "SynchronisingOK";
                        UploadRootsDupForUsb(RouteToUpload, FacilityDis, Equipment, EquipmentDis, Component, ComponentDis, SubComponent, SubComponentDis, Point, same, AlrVals);
                    }
                    else
                    {
                        _objMain.lblStatus.Caption = "SynchronisingOK";
                        UploadRootsDup(RouteToUpload, FacilityDis, Equipment, EquipmentDis, Component, ComponentDis, SubComponent, SubComponentDis, Point, same, AlrVals);
                    }
                    mCtr++;
                    Ctr = 5 * mCtr;
                    ParLnth = ParLnth - 5;
                    same = true;
                } while (ParLnth > 2);
                if (UsbSelected)
                {
                    Value = 0;
                    MakeUsbArrayForTourData();
                    check = "true";
                }
                else
                {
                    UploadRoots(RouteToUpload, FacilityDis, Equipment, EquipmentDis, Component, ComponentDis, SubComponent, SubComponentDis, Point);
                    check = "true";
                }
                UploadArray = new byte[1];
                UpArrayCount = 0;
            }
            catch { }
        }

        private int UpArrayCount1 = 0;
        private void UploadRootsDupForUsb(string Fac, string FacDis, string Equi, string EquiDis, string Comp, string CompDis, string Sub, string SubDis, string target, bool same, double[] Alarms)
        {
            float Alarm1 = 0;
            float Alarm2 = 0;
            float Alarm3 = 0;
            string sAlarm1 = null;
            string sAlarm2 = null;
            string sAlarm3 = null;
            double[] FactorUMMS = { 500, 250, 125, 50, 25, 12.5, 5, 2.5 };
            double[] FactorUMIL = { 100, 50, 20, 10, 5, 2 };
            double[] FactorG = { 100, 50, 20, 10, 5, 2, 1, .5, .2, .1 };
            double[] FactorUM = { 2500, 1250, 500, 250, 125, 50 };
            double[] FactorIPS = { 20, 10, 5, 2, 1, .5, .2, .1 };
            double[] FactorV = { 10, 5, 2, 1, .5, .2, .1, .05, .02, .01 };
            double[] FactorRPM = { 100000, 50000, 10000, 5000, 1000, 500, 100, 50, 10, 5 };
            double[] FactorOther = { 100000, 10000, 1000, 100, 10, 1, .1, .01, .001 };

            string[] Points = target.Split(new string[] { "," }, StringSplitOptions.None);//Spliting The Points To be send below a particular hararchie
            int PointCounter = 0;
            string[] Information = null;
            StringBuilder DataOfAllThePoints = new StringBuilder();
            int AlrCtr = 0;
            try
            {
                do
                {
                    Information = Points[PointCounter].Split(new string[] { "!!", "@", "#", "$", "%", "^", "&", "*", "+", "=", "<", ">", "?", "{", "}", "~", "`", "[", "]", ":", ";" }, StringSplitOptions.None);//Splitting The Whole Information For Extracting User Selected Values
                    Alarm1 = (float)Alarms[AlrCtr];
                    AlrCtr++;
                    Alarm2 = (float)Alarms[AlrCtr];
                    AlrCtr++;
                    Alarm3 = (float)Alarms[AlrCtr];
                    AlrCtr++;
                    int couple = Convert.ToInt16(Information[5]);//Extracting The Value Of Couple Selected by the user

                    couple = couple * 16;//Calculating value of couple to be send according to the value selected by the user
                    // MessageBox.Show("couple" + couple);
                    int DetectionType = Convert.ToInt16(Information[6]);//Extracting the value Of Detection Type Selected by the user
                    //MessageBox.Show("DetectionType" + DetectionType);
                    int Window = Convert.ToInt16(Information[7]);//Extracting The Value of Window type selected by the user
                    //MessageBox.Show("Window" + Window);
                    int Collection = Convert.ToInt16(Information[11]);//Extracting the value of Collection Type Selected by the user
                    //MessageBox.Show("Collection" + Collection);
                    int Frequency = Convert.ToInt16(Information[14]);//Extracting the value of frequency selected by the user
                    //MessageBox.Show("Frequency" + Frequency);
                    int Overlap = Convert.ToInt16(Information[16]);//Extracting the value of overlap selected by the user
                    //MessageBox.Show("Overlap" + Overlap);
                    int Trigger = Convert.ToInt16(Information[17]);//Extracting the value of trigger selected by the user

                    Trigger = Trigger * 2;//Calculating the value of trigger to be send according to the value selected by the user
                    //MessageBox.Show("Trigger" + Trigger);
                    int Slope = Convert.ToInt16(Information[18]);//Extracting the value of slope type selected by the user
                    //MessageBox.Show("Slope" + Slope);
                    int TriggerRange = Convert.ToInt16(Information[20]);//Extracting the value of trigger range selected by the user
                    TriggerRange = TriggerRange * 64;//Calculating the value if trigger range to be send according to the value selected by the user
                    //MessageBox.Show("TriggerRange" + TriggerRange);
                    int Channel = Convert.ToInt16(Information[21]);//Extracting the value of channel type choosen by the user
                    //MessageBox.Show("Channel" + Channel);
                    int fullScale = 0;
                    int FullScaleFinalVal = 0;
                    int Filter = Convert.ToInt16(Information[8]);//Extracting the value of Filter Used by the user
                    //MessageBox.Show("Filter" + Filter);
                    int FilterType = 0;
                    int MainValue = 0;
                    int Unit = Convert.ToInt16(Information[2]);//Extracting the value of Unit selected by the user
                    //MessageBox.Show("Unit" + Unit);
                    byte ValForSub = 0;
                    double MultiPlicationFacTorForAlarm = 0;
                    double MulFacSec = 0;
                    byte[] FirstToSendAlarm = new byte[2];
                    byte[] SecondToSendAlarm = new byte[2];
                    fullScale = Convert.ToInt16(Information[3]);
                    if (Unit == 2 || Unit == 6)
                    {
                        MultiPlicationFacTorForAlarm = .0000763;//Extracting key factor in case if alarm According To Unit
                        MulFacSec = FactorUMMS[fullScale];//Extracting Another Key Factor For Sending With Alarm Values
                    }
                    else if (Unit == 1 || Unit == 5)
                    {
                        MultiPlicationFacTorForAlarm = .00000305;//Extracting Key Factor In Case Of Alarm According To Unit
                        MulFacSec = FactorIPS[fullScale];//Extracting Another Key Factor For Sending With alarm According To Unit
                    }
                    else if (Unit == 3 || Unit == 7 || Unit == 9)
                    {
                        MultiPlicationFacTorForAlarm = .0000610;//Extracting key Factor In case of alarm According to Unit
                        MulFacSec = FactorUMIL[fullScale];//Extracting Another Key Factor For Sending With Alarm According to Unit
                    }
                    else if (Unit == 4 || Unit == 8 || Unit == 10)
                    {
                        MultiPlicationFacTorForAlarm = .001533;//Extracting Key factor in case of Alarm according to Unit
                        MulFacSec = FactorUM[fullScale];//Extracting Key factor For Sending With Alarm According To Unit
                    }
                    else if (Unit == 0 || Unit == 11)
                    {
                        MulFacSec = FactorG[fullScale];//Extracting Key Factor for sending wioth alarm according to unit
                    }
                    else if (Unit == 12)
                    {
                        MulFacSec = FactorV[fullScale];
                    }
                    else if (Unit == 13)
                    {
                        MulFacSec = FactorRPM[fullScale];
                    }
                    else
                    {
                        MulFacSec = FactorOther[fullScale];
                    }




                    if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))//Checking Alarm Values Not To Be null
                    {
                    }
                    else
                    {
                        try
                        {
                            double tt = Convert.ToDouble(Alarm2);
                            //sAlarm2 = DeciamlToHexadeciaml(Convert.ToInt16(((Convert.ToDouble(Alarm2) / MultiPlicationFacTorForAlarm) / MulFacSec)));//Calculating the alarm value to be send and converting it into Hexadecimal value
                            sAlarm2 = DeciamlToHexadeciaml(Convert.ToInt32(Convert.ToDouble(Alarm2 * 32767) / MulFacSec));//Calculating the alarm value to be send and converting it into Hexadecimal value

                            string[] AlSep = sAlarm2.Split(new string[] { "," }, StringSplitOptions.None);//Splitting its value for getting single bit
                            string Final1 = null;
                            string Final2 = null;
                            for (int i = AlSep.Length - 2; i <= AlSep.Length - 1; i++)
                            {
                                Final1 += AlSep[i];
                            }
                            for (int i = 0; i < AlSep.Length - 2; i++)
                            {
                                Final2 += AlSep[i];
                            }
                            try
                            {
                                FirstToSendAlarm[0] = Convert.ToByte(HexadecimaltoDecimal(Final1));
                            }
                            catch
                            {
                                FirstToSendAlarm[0] = Convert.ToByte(HexadecimaltoDecimal("FF"));
                            }
                            try
                            {
                                if (Final2 != null)
                                {
                                    FirstToSendAlarm[1] = Convert.ToByte(HexadecimaltoDecimal(Final2));
                                }
                            }
                            catch
                            {
                                if (Final2 != null)
                                {
                                    FirstToSendAlarm[1] = Convert.ToByte(HexadecimaltoDecimal("FF"));
                                }
                            }
                            //sAlarm3 = DeciamlToHexadeciaml(Convert.ToInt16(((Convert.ToDouble(Alarm3) / MultiPlicationFacTorForAlarm) / MulFacSec)));//Calculating the alarm value to be send and converting it into Hexadecimal value
                            sAlarm3 = DeciamlToHexadeciaml(Convert.ToInt32(Convert.ToDouble(Alarm3 * 32767) / MulFacSec));//Calculating the alarm value to be send and converting it into Hexadecimal value
                            AlSep = sAlarm3.Split(new string[] { "," }, StringSplitOptions.None);//Splitting its value for getting single bit
                            Final1 = null;
                            Final2 = null;
                            for (int i = AlSep.Length - 2; i <= AlSep.Length - 1; i++)
                            {
                                Final1 += AlSep[i];
                            }
                            for (int i = 0; i < AlSep.Length - 2; i++)
                            {
                                Final2 += AlSep[i];
                            }
                            try
                            {
                                SecondToSendAlarm[0] = Convert.ToByte(HexadecimaltoDecimal(Final1));
                            }
                            catch
                            {
                                SecondToSendAlarm[0] = Convert.ToByte(HexadecimaltoDecimal("FF"));
                            }
                            try
                            {
                                if (Final2 != null)
                                    SecondToSendAlarm[1] = Convert.ToByte(HexadecimaltoDecimal(Final2));
                            }
                            catch
                            {
                                if (Final2 != null)
                                    SecondToSendAlarm[1] = Convert.ToByte(HexadecimaltoDecimal("FF"));
                            }
                        }
                        catch
                        {
                        }
                    }
                    int Measure = Convert.ToInt16(Information[12]);//Extracting the value of measure type selected by the user
                    byte Order = Convert.ToByte(Information[15]);//Extracting the value of Order selected by the user
                    Order = Convert.ToByte(Order + 1);//Calculating the Value of Order To be send According To the selected value
                    byte LinesOfResolutin = Convert.ToByte(Information[13]);//Extracting the value Lines of resolution selected by the user
                    int[] FFt = { 100, 200, 400, 800, 1600, 3200, 6400 };
                    int[] Tm = { 256, 512, 1024, 2048, 4096, 8192, 16384 };
                    Array.Resize(ref ResArray, ResArray.Length + 1);
                    Array.Resize(ref ResArrayDirection, ResArrayDirection.Length + 1);
                    if (Measure == 0 || Measure == 1)
                    {
                        ResArray[ResArray.Length - 1] = FFt[Convert.ToInt32(LinesOfResolutin)];
                    }
                    else
                    {
                        ResArray[ResArray.Length - 1] = Tm[Convert.ToInt32(LinesOfResolutin)];
                    }
                    // MessageBox.Show("LinesOfResolutin" + LinesOfResolutin);
                    int BytesTotal = 0;

                    byte[] facilityName = System.Text.Encoding.ASCII.GetBytes(Fac);//Extracting factory name and converting its ASCII codes to there byte equivalent

                    int FacilityNameTotal = SumOfByteArray(facilityName);//Calculation there sum for calculating end key of the name

                    byte[] facilityDescription = System.Text.Encoding.ASCII.GetBytes(FacDis);//Converting Factory descryption to byte array
                    int FacilityDescTotal = SumOfByteArray(facilityDescription);//Calculating There Sum For Calculating End Key Of the Name

                    byte[] equipmentName = System.Text.Encoding.ASCII.GetBytes(Equi);//Converting Equipment Name to byte array
                    string DataToSend88 = Equi;
                    byte ForData88 = Convert.ToByte(0x35 - (equipmentName.Length));//Calculating end byte of equipment name
                    int equipmentNameTotal = SumOfByteArray(equipmentName);//Calculating the sum for finding end key

                    byte[] RouteNameBytes = System.Text.Encoding.ASCII.GetBytes(Fac);                  //Factory Name
                    string RouteName = Fac;
                    int RouteNameTotal = SumOfByteArray(RouteNameBytes);


                    byte[] equipmentDescription = System.Text.Encoding.ASCII.GetBytes(EquiDis);

                    int equipmeneDescTotal = SumOfByteArray(equipmentDescription);

                    byte[] componentName = System.Text.Encoding.ASCII.GetBytes(Comp);//Converting Component name to byte array
                    string DataToSend4 = Comp;
                    byte ForData4 = Convert.ToByte(0x11 - (componentName.Length));//Finding its end key
                    int componentNameTotal = SumOfByteArray(componentName);//Calculating the sum For finding End Key

                    byte[] componentDescription = System.Text.Encoding.ASCII.GetBytes(CompDis);//Converting Component Description To byte Array
                    int componentdescTotal = SumOfByteArray(componentDescription);//Calculating Its Sum For Finding Key

                    byte[] subcomponentName = System.Text.Encoding.ASCII.GetBytes(Sub);//Converting Sub COmponent name to byte array
                    string DataToSend6 = Sub;
                    byte ForData6 = Convert.ToByte(0x11 - (subcomponentName.Length));//Calculating Its Key to send
                    int subcomponentNameTotal = SumOfByteArray(subcomponentName);//Calculating Its End Key


                    byte[] subcomponentDescription = System.Text.Encoding.ASCII.GetBytes(SubDis);//Converting Sub COmponent Descryption to byte array
                    int subcomponentdescTotal = SumOfByteArray(subcomponentDescription);//Calculating its key to send
                    string[] ptName = Information[0].Split(new string[] { "|" }, StringSplitOptions.None);//Extracting Point Names
                    byte[] PointName = System.Text.Encoding.ASCII.GetBytes(ptName[0]);//Converting Point Name To byte array
                    string DataToSend5 = ptName[0];
                    byte ForData5 = Convert.ToByte(0x11 - (PointName.Length));//Claculating its key
                    int PointNameTotal = SumOfByteArray(PointName);//Calculating its End Key



                    byte[] PointDesc = System.Text.Encoding.ASCII.GetBytes(ptName[1]);//Converting point descryption to byte array
                    string DataToSend7 = ptName[1];
                    if (Information[3] == "0")
                        Information[3] = "1";
                    fullScale = Convert.ToInt16(Information[3]);
                    //MessageBox.Show("fullScale" + fullScale);
                    if (fullScale == 0 && Unit != 2 && Unit != 4 && Unit != 6 && Unit != 8 && Unit != 10)
                        ValForSub = 0x27;//Assigning value to be subtracted from the key
                    else

                        ValForSub = 0x26;

                    byte ForData7 = Convert.ToByte(ValForSub - (PointDesc.Length));
                    int PointDescTotal = SumOfByteArray(PointDesc);

                    byte DataToSend8 = Convert.ToByte(fullScale);


                    if (Unit == 0 || Unit == 11)
                    {

                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 217;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x29;
                        else

                            ValForSub = 0x26;

                    }
                    if (Unit == 1)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 218;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else

                            ValForSub = 0x26;


                    }
                    if (Unit == 2)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 234;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else

                            ValForSub = 0x26;



                    }
                    if (Unit == 3)
                    {

                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 220;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else

                            ValForSub = 0x26;

                    }
                    if (Unit == 4)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 240;
                        if (fullScale <= 4)
                            FullScaleFinalVal = fullScale - 4;
                        else if (fullScale > 4)
                            FullScaleFinalVal = -4;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else

                            ValForSub = 0x26;


                    }
                    if (Unit == 5)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 219;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else

                            ValForSub = 0x26;


                    }
                    if (Unit == 6)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 235;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else

                            ValForSub = 0x26;


                    }
                    if (Unit == 7)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 221;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else

                            ValForSub = 0x26;


                    }
                    if (Unit == 8)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 241;
                        if (fullScale <= 4)
                            FullScaleFinalVal = fullScale - 4;
                        else if (fullScale > 4)
                            FullScaleFinalVal = -4;

                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else

                            ValForSub = 0x26;


                    }
                    if (Unit == 9)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 351;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else

                            ValForSub = 0x26;


                    }
                    if (Unit == 10)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 371;
                        if (fullScale <= 4)
                            FullScaleFinalVal = fullScale - 4;
                        else if (fullScale > 4)
                            FullScaleFinalVal = -4;

                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else

                            ValForSub = 0x26;


                    }
                    if (Unit == 12 || Unit > 12)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 351;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else

                            ValForSub = 0x26;
                    }


                    //MessageBox.Show("fullScale after Unit test" + fullScale);
                    byte[] unitCode = new byte[1];



                    if (Unit == 1 || Unit == 2)
                        unitCode[0] = Convert.ToByte(0x01);
                    else if (Unit == 3 || Unit == 4)
                        unitCode[0] = Convert.ToByte(0x03);
                    else if (Unit == 5 || Unit == 6)
                        unitCode[0] = Convert.ToByte(0x02);
                    else if (Unit == 7 || Unit == 8)
                        unitCode[0] = Convert.ToByte(0x04);
                    else if (Unit == 9 || Unit == 10)
                        unitCode[0] = Convert.ToByte(0x05);
                    else if (Unit == 0)
                        unitCode[0] = Convert.ToByte(0x00);
                    else if (Unit == 11)
                        unitCode[0] = Convert.ToByte(0x09);
                    else if (Unit == 12)
                        unitCode[0] = Convert.ToByte(0x06);
                    else if (Unit == 13)
                        unitCode[0] = Convert.ToByte(0x08);
                    else if (Unit == 14)
                        unitCode[0] = Convert.ToByte(0x10);
                    else if (Unit == 15)
                        unitCode[0] = Convert.ToByte(0x11);
                    else if (Unit == 16)
                        unitCode[0] = Convert.ToByte(0x12);
                    else if (Unit == 17)
                        unitCode[0] = Convert.ToByte(0x13);
                    else if (Unit == 18)
                        unitCode[0] = Convert.ToByte(0x14);
                    else if (Unit == 19)
                        unitCode[0] = Convert.ToByte(0x15);
                    else if (Unit == 20)
                        unitCode[0] = Convert.ToByte(0x16);
                    else if (Unit == 21)
                        unitCode[0] = Convert.ToByte(0x17);
                    else if (Unit == 22)
                        unitCode[0] = Convert.ToByte(0x18);
                    else if (Unit == 23)
                        unitCode[0] = Convert.ToByte(0x19);
                    else if (Unit == 24)
                        unitCode[0] = Convert.ToByte(0x20);
                    else if (Unit == 25)
                        unitCode[0] = Convert.ToByte(0x21);
                    else if (Unit == 26)
                        unitCode[0] = Convert.ToByte(0x22);
                    else if (Unit == 27)
                        unitCode[0] = Convert.ToByte(0x23);


                    byte ZeroFullScale = 0;
                    if (Unit == 0 || Unit == 1 || Unit == 3 || Unit == 5 || Unit == 7 || Unit == 9 || Unit == 11 || Unit == 12 || Unit > 12)
                    {
                        if (fullScale == 0)
                            ZeroFullScale = 0;
                        else if (fullScale > 0)
                            ZeroFullScale = Convert.ToByte(0 + fullScale);
                    }
                    if (Unit == 2 || Unit == 4 || Unit == 6 || Unit == 8 || Unit == 10)
                    {
                        if (fullScale == 0)
                            ZeroFullScale = 0x10;
                        else if (fullScale > 0)
                            ZeroFullScale = Convert.ToByte(0x10 + fullScale);
                    }



                    byte AfterUnitCode = 0x00;
                    byte AfterUnitCode1 = 0x00;
                    int FilterVal = Convert.ToInt16(Information[9]);
                    //MessageBox.Show("FilterVal" + FilterVal);
                    byte[] BeforeFF = new byte[2];
                    bool Excep = true;

                    if (Filter == 2)
                    {
                        if (FilterVal == 0)
                        {
                            AfterUnitCode1 = 0x08;
                        }
                        else if (FilterVal == 1)
                        {
                            AfterUnitCode = 0x80;
                            AfterUnitCode1 = 0x08;
                        }
                        else if (FilterVal == 2)
                        {
                            AfterUnitCode = 0x00;
                            AfterUnitCode1 = 0x09;
                        }
                        BeforeFF[0] = Convert.ToByte(Measure);
                        BeforeFF[1] = 0x00;
                    }
                    else if (Filter == 1)
                    {
                        if (FilterVal >= 0 && FilterVal <= 3)
                        {
                            AfterUnitCode1 = 0x04;
                        }
                        else if (FilterVal == 4)
                        {
                            AfterUnitCode = 0x80;
                            AfterUnitCode1 = 0x04;
                        }
                        else if (FilterVal == 5)
                        {
                            AfterUnitCode = 0x00;
                            AfterUnitCode1 = 0x05;
                        }
                        else if (FilterVal == 6)
                        {
                            AfterUnitCode = 0x80;
                            AfterUnitCode1 = 0x05;
                        }
                        else if (FilterVal == 7)
                        {
                            AfterUnitCode = 0x00;
                            AfterUnitCode1 = 0x06;
                        }

                        BeforeFF[0] = Convert.ToByte(Measure);
                        BeforeFF[1] = 0x00;

                    }
                    else if (Filter == 3)
                    {
                        if (FilterVal >= 0 && FilterVal <= 3)
                        {
                            AfterUnitCode1 = 0x0c;
                        }
                        else if (FilterVal == 4)
                        {
                            AfterUnitCode = 0x80;
                            AfterUnitCode1 = 0x0c;
                        }
                        else if (FilterVal == 5)
                        {
                            AfterUnitCode = 0x00;
                            AfterUnitCode1 = 0x0d;
                        }
                        else if (FilterVal == 6)
                        {
                            AfterUnitCode = 0x80;
                            AfterUnitCode1 = 0x0d;
                        }
                        else if (FilterVal == 7)
                        {
                            AfterUnitCode = 0x00;
                            AfterUnitCode1 = 0x0e;
                        }
                        BeforeFF[0] = Convert.ToByte(Measure);
                        BeforeFF[1] = 0x00;
                    }
                    else if (Filter == 0 && Measure == 0)
                    {
                        BeforeFF[0] = 0x1b;
                        BeforeFF[1] = 0x04;
                        if (Unit == 0)
                            BeforeFF[1]++;

                    }
                    else if (Filter == 0 && Measure > 0)
                    {
                        BeforeFF[0] = Convert.ToByte(Measure);
                        BeforeFF[1] = 0x00;
                        AfterUnitCode1 = 0x00;
                        Excep = false;

                    }

                    if (TriggerRange > 0)
                    {
                        AfterUnitCode = Convert.ToByte(TriggerRange + AfterUnitCode);
                        BeforeFF[1] = 0x03;
                    }
                    if (Trigger > 0)
                    {
                        AfterUnitCode = Convert.ToByte(Trigger + AfterUnitCode);
                        BeforeFF[1] = 0x03;
                    }
                    if (couple > 0)
                    {
                        BeforeFF[1] = 0x03;
                        AfterUnitCode = Convert.ToByte(AfterUnitCode + couple);
                    }

                    byte[] DetctionInformationToSend = new byte[5];

                    if (DetectionType > 0)
                    {
                        DetctionInformationToSend[0] = 0x1b;
                        DetctionInformationToSend[1] = 0x03;
                        DetctionInformationToSend[2] = Convert.ToByte(DetectionType);
                        DetctionInformationToSend[3] = 0x1b;
                        DetctionInformationToSend[4] = 0x08;
                    }

                    byte ToSendAfterOrder = Convert.ToByte(Collection);

                    SensitivityFunction(Convert.ToInt32(Information[4]));

                    byte sensPrev = Convert.ToByte(senstivityPrev);
                    byte sensval = Convert.ToByte(sensitivityvalue);
                    byte sensnext = Convert.ToByte(sensitivitynext);

                    byte[] SensitivityToSend = new byte[0];
                    if (senstivityPrev != 0)
                    {
                        Array.Resize(ref SensitivityToSend, SensitivityToSend.Length + 1);
                        SensitivityToSend[SensitivityToSend.Length - 1] = sensPrev;
                    }
                    Array.Resize(ref SensitivityToSend, SensitivityToSend.Length + 1);
                    SensitivityToSend[SensitivityToSend.Length - 1] = sensval;
                    Array.Resize(ref SensitivityToSend, SensitivityToSend.Length + 1);
                    SensitivityToSend[SensitivityToSend.Length - 1] = sensnext;

                    //MakeArray(SensitivityToSend);

                    byte[] ConsTantToSend = SensitivityToSend;// { 0xC8, 0x42 };
                    byte[] ConsTantToSend1 = { 0x1B, 0x03, 0x32, 0x73, 0x1B, 0x11 };
                    byte[] ConsTantToSend11 = { 0x1B, 0x03, 0x5a, 0x1B, 0x12 };
                    string zero = "\x00";
                    byte[] WindowNotZero = new byte[3];
                    byte[] WindowZero = new byte[2];
                    byte[] LinesFourHund = new byte[2];



                    if (Filter == 0)
                    {
                        FilterType = -8;
                    }
                    if (Filter == 1)
                    {
                        FilterType = -4;
                    }
                    if (Filter == 3)
                    {
                        FilterType = 4;
                    }
                    int filterFreq = 0;
                    if (Filter == 2 && Convert.ToInt16(Information[9]) == 1)
                    {
                        filterFreq = -127;
                    }
                    if (Filter == 2 && Convert.ToInt16(Information[9]) == 2)
                    {
                        filterFreq = 1;
                    }
                    //MessageBox.Show("Information[9]" + Information[9].ToString());
                    if (Filter == 1 || Filter == 3)
                    {
                        if (Convert.ToInt16(Information[9]) == 4)
                        {
                            filterFreq = -127;
                        }
                        else if (Convert.ToInt16(Information[9]) == 5)
                        {
                            filterFreq = 1;
                        }
                        else if (Convert.ToInt16(Information[9]) == 6)
                        {
                            filterFreq = -126;
                        }
                        else if (Convert.ToInt16(Information[9]) == 7)
                        {
                            filterFreq = 2;
                        }
                    }

                    int MeasureType = 0;
                    int FreqVal = 0;
                    int FreqValSelect = 0;
                    if (Measure == 1 || Measure == 2)
                    {
                        MeasureType = 1;
                    }
                    if (Measure == 0 || Measure == 1)
                    {
                        FreqVal = Convert.ToInt16(Information[13]);
                        // MessageBox.Show("Information[13]]" + Information[13].ToString());
                        if (FreqVal < 3)
                        {
                            if (FreqVal == 0)
                                FreqValSelect = -2;
                            else if (FreqVal == 1)
                                FreqValSelect = -1;
                            else if (FreqVal == 2)
                                FreqValSelect = -3;

                        }
                        else if (FreqVal > 3)
                        {
                            FreqValSelect = FreqVal - 3;
                        }
                    }

                    if (Measure == 2 || Measure == 3)
                    {
                        if (FreqVal != 2)
                        {
                            if (FreqVal == 1)
                                FreqValSelect = 1;
                            else if (FreqVal > 2)
                                FreqValSelect = FreqVal - 1;
                        }
                    }

                    BytesTotal = MainValue + equipmentNameTotal + componentNameTotal + subcomponentNameTotal + PointNameTotal + PointDescTotal + couple + DetectionType + Window + Collection + Frequency + Trigger + Slope + TriggerRange + Channel + FullScaleFinalVal + FilterType + filterFreq + MeasureType + FreqValSelect + Overlap + ConsTantToSend.Length;


                    byte FirstByte = 0;
                    byte SecondByte = 0x00;
                    if (BytesTotal >= 256)
                    {
                        do
                        {
                            BytesTotal = BytesTotal - 256;
                            SecondByte++;
                        } while (BytesTotal >= 256);
                        FirstByte = Convert.ToByte(BytesTotal);
                    }
                    else if (BytesTotal < 256)
                    {
                        FirstByte = Convert.ToByte(BytesTotal);

                    }
                    if (FirstByte == 0x1b)
                        FirstByte++;




                    byte[] FirstQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x52, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x36, 0x36 };
                    byte[] ThirdQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x4D, 0x44, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] FourthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] FourthQuestionEnd = { 0x5C, 0x74, 0x6F, 0x75, 0x72, 0x64, 0x61, 0x74, 0x61, 0x2E, 0x64, 0x61, 0x74, 0x03 };
                    byte[] FifthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] FifthQuestionEnd = { 0x5C, 0x74, 0x6F, 0x75, 0x72, 0x69, 0x6E, 0x66, 0x6F, 0x2E, 0x64, 0x61, 0x74, 0x03 };

                    byte[] SixthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] SixthQuestionEnd = { 0x5C, 0x63, 0x74, 0x72, 0x6C, 0x2E, 0x63, 0x66, 0x67, 0x03 };

                    byte[] EightQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] EightQuestionEnd = { 0x5C, 0x6E, 0x6F, 0x74, 0x65, 0x2E, 0x64, 0x61, 0x74, 0x03 };


                    byte[] NinthQuestion = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x30, 0x34, 0x2E, 0x01, 0x00, 0x00, 0x03, 0x35, 0x36 };


                    byte[] TenthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] TenthQuestionEnd = { 0x5C, 0x6F, 0x66, 0x66, 0x74, 0x64, 0x61, 0x74, 0x61, 0x2E, 0x64, 0x61, 0x74, 0x03 };

                    byte[] EleventhQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x44, 0x45, 0x4C, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x32, 0x33 };
                    byte[] TwelevthQuestion = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x36, 0x38 };
                    byte[] ThirteenthQuestion = { 0x01, 0x30, 0x32, 0x37, 0x46, 0x02, 0x30, 0x30, 0x36, 0x31, 0x00, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x94, 0x2A, 0xE4, 0x8F, 0xCC, 0xF6, 0x43, 0x8C, 0xA8, 0xF8, 0xFF, 0x01, 0x00, 0xC8, 0xFF, 0xFF, 0x20, 0x1B, 0x05 };
                    byte[] ThirteenthQuestionEnd = { 0x1B, 0x03, 0x08, 0x00, 0x0B, 0x1B, 0x08, 0x07, 0x00, 0x50, 0x39, 0xF8, 0x03, 0x1B, 0x04, 0x10, 0x1B, 0x04, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x06, 0x1B, 0x03, 0x70, 0xD4, 0x0C, 0x00, 0x98, 0x72, 0x8E, 0x01, 0x24, 0xF5, 0x10, 0x0E, 0x84, 0xF5, 0x10, 0x0E, 0x60, 0x8E, 0x01, 0xCC, 0xF4, 0x10, 0x0E, 0x30, 0xDE, 0x8A, 0x01, 0x0B, 0x00, 0xFF, 0x01, 0xDC, 0xF6, 0x10, 0x0E, 0x00, 0x00, 0x10, 0x0E, 0x1B, 0x17, 0x03 };

                    byte[] DateQues = { 0x06, 0x01, 0x30, 0x30, 0x34, 0x41, 0x02 };
                    byte[] DateQuesEnd = { 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x03 };
                    byte[] DateEnd = new byte[2];
                    byte[] testArr = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x35, 0x44, 0x2E, 0x01, 0x00, 0x00, 0x58, 0x02, 0x06, 0x01, 0xae, 0x07, 0x1B, 0x04, 0x02, 0x1B, 0x04, 0x4D, 0x68, 0x6C, 0x1B, 0x0E, 0x4D, 0x68, 0x6C, 0x31, 0x1B, 0x0D, 0x4D, 0x4F, 0x54, 0x4F, 0x52, 0x1B, 0x0C, 0x4D, 0x4F, 0x54, 0x4F, 0x52, 0x31, 0x1B, 0x26, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x1B, 0x03, 0x01, 0x1B, 0x08, 0x01, 0x1B, 0x0C, 0xC8, 0x42, 0x08, 0x00, 0x01, 0x1B, 0x03, 0x03, 0x04, 0x1B, 0x03, 0x32, 0x73, 0x1B, 0x11, 0x4D, 0x31, 0x32, 0x33, 0x1B, 0x31, 0x0A, 0x1B, 0x1E, 0x03, 0x00, 0x32, 0x01, 0x1B, 0x05, 0x33, 0x01, 0x24, 0x03, 0x1B, 0xF4, 0x00, 0x00, 0x03 };
                    byte[] TestArr1 = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x36, 0x35, 0x2E, 0x01, 0x00, 0x00, 0x58, 0x02, 0x06, 0x01, 0xae, 0x07, 0x1B, 0x04, 0x02, 0x1B, 0x04 };
                    byte[] TestArr2 = { 0x1b, 0x0e };
                    byte[] TestArr3 = { 0x1b, 0x0d };
                    byte[] TestArr4 = { 0x1b, 0x0c };
                    byte[] TestArr5 = { 0x1b, 0x20 };

                    byte[] TestArr6 = { 0x03, 0x00, 0x00, 0x08, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x1B, 0x03, 0x01, 0x1B, 0x08, 0x01, 0x1B, 0x0C, 0xC8, 0x42, 0x08, 0x00, 0x01, 0x03, 0x00, 0x00, 0x03, 0x04, 0x1B, 0x03, 0x32, 0x73, 0x1B, 0x11 };
                    byte[] TestArr7 = { 0x1b, 0x22 };
                    byte[] TestArr8 = { 0x0A, 0x1B, 0x1E, 0x03, 0x00, 0x32, 0x01, 0x1B, 0x05, 0x33, 0x01, 0x44, 0x06, 0x1B, 0xF6, 0x00, 0x00, 0x03 };
                    byte[] Start = { 0x01, 0x30, 0x30, 0x31, 0x36, 0x02, 0x03, 0x34, 0x43 };
                    byte[] DataBase = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x30, 0x45, 0x1B, 0x04, 0x08, 0x45, 0x3A, 0x5C, 0x74, 0x65, 0x73, 0x74, 0x5C, 0x01, 0x1B, 0x03, 0x03, 0x37, 0x35 };

                    byte[] RouteTestName = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x31, 0x36, 0x2E, 0x01, 0x00, 0x00, 0x2F, 0x01, 0x23, 0x00, 0x68, 0x00, 0x61, 0x1B, 0x10, 0x04, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x1B, 0x09, 0x03, 0x34, 0x42 };
                    byte[] TestDate = { 0x06, 0x01, 0x30, 0x30, 0x34, 0x41, 0x02, 0x30, 0x42, 0x1F, 0x32, 0x31, 0x1F, 0x30, 0x43, 0x1F, 0x30, 0x42, 0x1F, 0x30, 0x41, 0x1F, 0x36, 0x42, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x03, 0x37, 0x35 };



                    byte[] RouteNameToSend1 = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30 };
                    byte[] RouteNameToSend21 = new byte[1];
                    byte[] RouteNameToSend22 = new byte[1];
                    byte[] RouteNameToSend3 = { 0x2E, 0x01, 0x00, 0x00, 0x2F, 0x01, 0x23, 0x00 };
                    byte[] RouteNameToSend4 = { 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x1B, 0x09, 0x03 };
                    byte[] StartDataToSend1 = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02 };
                    byte[] StartDataToSend2 = { 0x2E, 0x01, 0x00, 0x00 };
                    byte[] StartDataToSend22 = { 0x58, 0x02, 0x06, 0x01 };
                    byte[] StartDataToSend3b = { 0x1B, 0x04 };
                    byte[] StartDataToSend3 = { 0x1B, 0x04, 0x02, 0x1b, 0x04 };
                    byte[] StartDataToSend3l = { 0x1B, 0x04 };
                    byte[] StartDataToSend3ForDualChannel = { 0x1B, 0x04 };
                    byte[] StartDataToSend3ForDualChannelAndCounter0 = { 0x1B, 0x03, 0x20 };
                    byte[] StartDataToSend3ForDualChannelAndCounter1 = { 0x00, 0x00, 0x01, 0x20 };





                    byte[] ThirdQuestionEnd = new byte[2];
                    byte[] FourthLastByte = new byte[2];
                    byte ThirdEnd1 = 0x35;
                    byte ThirdEnd2 = 0x32;
                    byte FourthEnd1 = 0x30;
                    byte FourthEnd2 = 0x31;
                    byte FifthEnd1 = 0x31;
                    byte FifthEnd2 = 0x33;
                    byte[] FifthLastByte = new byte[2];
                    byte SixthEnd1 = 0x34;
                    byte SixthEnd2 = 0x39;
                    byte[] SixthLastByte = new byte[2];
                    byte EightEnd1 = 0x35;
                    byte EightEnd2 = 0x33;
                    byte[] EightLastByte = new byte[2];
                    byte TenthEnd1 = 0x36;
                    byte TenthEnd2 = 0x36;
                    byte[] TenthLastByte = new byte[2];
                    byte LastMiddleByte = 2;
                    byte[] LastMiddleFinal = new byte[1];
                    byte ThirteenEnd1 = 0x33;
                    byte ThirteenEnd2 = 0x43;
                    byte[] ThirteenLastByte = new byte[2];
                    byte[] Tour = new byte[1];
                    byte[] Tour1 = new byte[1];
                    byte[] TourSingle = new byte[1];
                    int RouteToSend = TotalRoutes + 1;
                    RouteNameTotal = RouteNameTotal + RouteToSend + 3;
                    byte[] RouteNameMiddleBytes = new byte[2];
                    RouteNameMiddleBytes[1] = 0x00;

                    int bytesReadSending = 0;
                    if (RouteNameBytes.Length >= 1)
                    {
                        bytesReadSending = RouteNameBytes.Length;
                        bytesReadSending = bytesReadSending + 21;
                        string noOfBytes = DeciamlToHexadeciaml(bytesReadSending);
                        string[] noOfbytesTosend = null;

                        noOfbytesTosend = noOfBytes.Split(new string[] { "," }, StringSplitOptions.None);
                        RouteNameToSend21 = Encoding.ASCII.GetBytes(noOfbytesTosend[0]);
                        RouteNameToSend22 = Encoding.ASCII.GetBytes(noOfbytesTosend[1]);

                    }


                    while (RouteNameTotal >= 256)
                    {
                        if (RouteNameTotal >= 256)
                            RouteNameTotal = RouteNameTotal - 256;
                        RouteNameMiddleBytes[1]++;
                    }
                    RouteNameMiddleBytes[0] = Convert.ToByte(RouteNameTotal);
                    int lastByteTotal = 0;
                    lastByteTotal = (RouteNameMiddleBytes[0] + 1) * 2;
                    int MonitorForByte = 0;
                    int MonitorForByte1 = 0;
                    int addingBytes = 0;
                    if (RouteNameMiddleBytes[1] == 1)
                    {
                        while (lastByteTotal > 128)
                        {
                            if (lastByteTotal > 256)
                            {
                                lastByteTotal = lastByteTotal - 256;
                                MonitorForByte = 256;
                            }
                            else if (lastByteTotal > 128)
                            {
                                lastByteTotal = lastByteTotal - 128;
                                MonitorForByte1 = 128;
                            }
                        }
                        if (MonitorForByte == 256 && MonitorForByte1 == 128)
                            lastByteTotal = lastByteTotal + 1;

                        else if (MonitorForByte == 256)
                            lastByteTotal = lastByteTotal + 1;
                        else if (MonitorForByte1 == 128)
                            lastByteTotal = lastByteTotal + 1;
                        else
                            lastByteTotal = lastByteTotal - 6;
                    }

                    else if (RouteNameMiddleBytes[1] >= 2)
                    {

                        addingBytes = RouteNameMiddleBytes[1];
                        while (lastByteTotal > 128)
                        {
                            lastByteTotal = lastByteTotal - 128;

                        }
                        lastByteTotal = lastByteTotal + addingBytes;

                    }
                    else if (RouteNameMiddleBytes[1] == 0)
                    {

                        while (lastByteTotal > 128)
                        {
                            lastByteTotal = lastByteTotal - 128;

                        }
                        lastByteTotal = lastByteTotal;
                    }


                    byte[] AfterRouteName = new byte[1];

                    AfterRouteName[0] = Convert.ToByte(0x11 - RouteNameBytes.Length);
                    int lastByteHexTotal = 0;
                    byte[] RouteNumberForRouteName = new byte[1];
                    RouteNumberForRouteName[0] = Convert.ToByte(RouteToSend);
                    if (lastByteTotal > 10)
                        lastByteHexTotal = lastByteTotal - 10;
                    else if (lastByteTotal > 8)
                        lastByteHexTotal = lastByteTotal - 8;
                    else if (lastByteTotal > 6)
                        lastByteHexTotal = lastByteTotal - 6;
                    else if (lastByteTotal > 4)
                        lastByteHexTotal = lastByteTotal - 4;
                    else if (lastByteTotal > 2)
                        lastByteHexTotal = lastByteTotal - 2;

                    string LastbytesString = DeciamlToHexadeciaml(lastByteHexTotal);


                    string[] LastBytesArrForRoute = null;

                    LastBytesArrForRoute = LastbytesString.Split(new string[] { "," }, StringSplitOptions.None);
                    byte[] LastByteArrForRouteName1 = new byte[1];
                    byte[] LastByteArrForRouteName2 = new byte[1];
                    if (LastBytesArrForRoute.Length == 2)
                    {
                        LastByteArrForRouteName1 = Encoding.ASCII.GetBytes(LastBytesArrForRoute[0]);
                        LastByteArrForRouteName2 = Encoding.ASCII.GetBytes(LastBytesArrForRoute[1]);
                    }
                    else if (LastBytesArrForRoute.Length == 1)
                    {
                        LastByteArrForRouteName1[0] = Convert.ToByte(0x30);
                        LastByteArrForRouteName2 = Encoding.ASCII.GetBytes(LastBytesArrForRoute[0]);
                    }


                    if (RouteToSend < 10)
                    {
                        TourSingle[0] = Convert.ToByte(0x30 + RouteToSend);
                    }
                    else if (RouteToSend >= 10)
                    {
                        int high = RouteToSend / 10;
                        int low = RouteToSend % 10;
                        Tour[0] = Convert.ToByte(0x30 + high);
                        Tour1[0] = Convert.ToByte(0x30 + low);
                    }
                    for (int i = 2; i <= RouteToSend; i++)
                    {
                        LastMiddleByte++;
                    }
                    LastMiddleByte--;


                    LastMiddleFinal[0] = LastMiddleByte;
                    int Run = 2;
                    byte lastRun = 0x00;
                    int lastRunHigh = 0;
                    int lastRunLow = 0;
                    for (int i = 2; i <= RouteToSend; i++)
                    {

                        if (RouteToSend < 10)
                        {
                            ThirdEnd2++;
                            if (ThirdEnd2 == 0x3a)
                                ThirdEnd2 = 0x41;

                        }
                        else if (RouteToSend >= 10)
                        {
                            lastRunLow = RouteToSend % 10;
                            lastRunHigh = RouteToSend / 10;
                            ThirdEnd1 = 0x30;
                            ThirdEnd2 = Convert.ToByte(48 + (lastRunLow + 2) + (lastRunHigh - 1));

                            if (ThirdEnd2 >= 0x3a)
                                ThirdEnd2 = Convert.ToByte(0x41 + (ThirdEnd2 - 0x3a));




                        }
                        Run++;
                    }


                    ThirdQuestionEnd[0] = ThirdEnd1;
                    ThirdQuestionEnd[1] = ThirdEnd2;
                    Run = 2;
                    lastRun = 0x00;
                    lastRunHigh = 0;
                    lastRunLow = 0;
                    for (int i = 2; i <= RouteToSend; i++)
                    {

                        if (RouteToSend < 10)
                        {
                            FourthEnd2++;
                        }
                        else if (RouteToSend >= 10)
                        {
                            lastRunLow = RouteToSend % 10;
                            lastRunHigh = RouteToSend / 10;
                            FourthEnd1 = 0x33;
                            FourthEnd2 = Convert.ToByte(48 + (lastRunLow + 1) + (lastRunHigh - 1));

                            if (FourthEnd2 >= 0x3a)
                                FourthEnd2 = Convert.ToByte(0x41 + (FourthEnd2 - 0x3a));



                        }
                        Run++;
                        System.Diagnostics.Debug.WriteLine(FourthEnd2);
                    }

                    FourthLastByte[0] = FourthEnd1;
                    FourthLastByte[1] = FourthEnd2;
                    Run = 2;
                    lastRun = 0x00;
                    lastRunHigh = 0;
                    lastRunLow = 0;
                    for (int i = 2; i <= RouteToSend; i++)
                    {

                        if (RouteToSend < 10)
                        {
                            FifthEnd2++;
                            if (FifthEnd2 == 0x3a)
                                FifthEnd2 = 0x41;
                        }
                        else if (RouteToSend >= 10)
                        {
                            lastRunLow = RouteToSend % 10;
                            lastRunHigh = RouteToSend / 10;
                            FifthEnd1 = 0x34;
                            FifthEnd2 = Convert.ToByte(48 + (lastRunLow + 3) + (lastRunHigh - 1));

                            if (FifthEnd2 >= 0x3a)
                                FifthEnd2 = Convert.ToByte(0x41 + (FifthEnd2 - 0x3a));
                        }

                        Run++;
                        System.Diagnostics.Debug.WriteLine(FifthEnd2);
                    }

                    FifthLastByte[0] = FifthEnd1;
                    FifthLastByte[1] = FifthEnd2;
                    Run = 2;
                    lastRun = 0x00;


                    for (int i = 2; i <= RouteToSend; i++)
                    {

                        if (RouteToSend < 10)
                        {
                            SixthEnd2++;
                            if (SixthEnd2 == 0x3a)
                                SixthEnd2 = 0x41;
                            if (SixthEnd2 == 0x47)
                            {
                                SixthEnd1++;
                                SixthEnd2 = 0x30;
                            }

                        }

                        else if (RouteToSend >= 10)
                        {
                            SixthEnd2++;
                            if (SixthEnd2 == 0x3a)
                                SixthEnd2 = 0x41;

                            if (Run == 10)
                            {


                                SixthEnd1 = 0x37;
                                SixthEnd2 = 0x39;
                                if (SixthEnd2 == 0x3a)
                                    SixthEnd2 = 0x41;
                            }

                            if (SixthEnd2 == 0x32)
                            {
                                lastRun++;
                                SixthEnd1 = 0x37;
                                SixthEnd2 = Convert.ToByte(0x39 + lastRun);

                            }
                            if (SixthEnd2 == 0x47)
                            {
                                SixthEnd1 = 0x30;
                                SixthEnd2 = 0x30;
                            }
                            if (Run <= 10 && SixthEnd2 == 0x47)
                            {
                                SixthEnd1 = 0x35;
                                SixthEnd2 = 0x30;
                            }
                            if (Run <= 10 && SixthEnd2 == 0x3a)
                                SixthEnd2 = 0x41;
                        }
                        Run++;
                    }

                    SixthLastByte[0] = SixthEnd1;
                    SixthLastByte[1] = SixthEnd2;
                    Run = 2;
                    lastRun = 0x00;
                    for (int i = 2; i <= RouteToSend; i++)
                    {

                        if (RouteToSend < 10)
                        {
                            EightEnd2++;
                            if (EightEnd2 == 0x3a)
                                EightEnd2 = 0x41;
                        }
                        else if (RouteToSend > 10)
                        {
                            if (Run == 10)
                            {

                                Run = 0;
                                EightEnd1 = 0x30;
                                EightEnd2 = Convert.ToByte(51 + lastRun);

                                lastRun++;

                            }
                            EightEnd2++;
                            if (EightEnd2 == 0x3a)
                                EightEnd2 = 0x41;


                        }
                        Run++;
                    }
                    EightLastByte[0] = EightEnd1;
                    EightLastByte[1] = EightEnd2;


                    Run = 2;
                    lastRun = 0x00;
                    for (int i = 2; i <= RouteToSend; i++)
                    {

                        if (RouteToSend < 10)
                        {
                            TenthEnd2++;
                            if (TenthEnd2 == 0x3a)
                                TenthEnd2 = 0x41;
                        }
                        else if (RouteToSend > 10)
                        {
                            if (Run == 10)
                            {
                                Run = 0;
                                TenthEnd1 = 0x31;
                                TenthEnd2 = Convert.ToByte(54 + lastRun);
                                lastRun++;
                            }
                            TenthEnd2++;
                            if (TenthEnd2 == 0x3a)
                                TenthEnd2 = 0x41;
                        }
                        Run++;
                    }
                    TenthLastByte[0] = TenthEnd1;
                    TenthLastByte[1] = TenthEnd2;

                    Run = 2;
                    lastRun = 0x00;
                    for (int i = 2; i <= RouteToSend; i++)
                    {


                        if (ThirteenEnd2 == 0x3a)
                            ThirteenEnd2 = 0x41;
                        if (ThirteenEnd2 == 0x47)
                        {
                            ThirteenEnd2 = 0x30;
                            ThirteenEnd1++;
                        }
                        ThirteenEnd2++;
                    }
                    ThirteenEnd2--;
                    ThirteenLastByte[0] = ThirteenEnd1;
                    ThirteenLastByte[1] = ThirteenEnd2;
                    byte[] Entrance = new byte[4];
                    byte[] FirstByteArr = new byte[1];
                    FirstByteArr[0] = FirstByte;
                    byte[] SecondByteArr = new byte[1];
                    SecondByteArr[0] = SecondByte;
                    byte[] ForData4Arr = new byte[1];
                    ForData4Arr[0] = ForData4;
                    byte[] ForData5Arr = new byte[1];
                    ForData5Arr[0] = ForData5;
                    byte[] ForData6Arr = new byte[1];
                    ForData6Arr[0] = ForData6;
                    byte[] ForData7Arr = new byte[1];
                    ForData7Arr[0] = ForData7;
                    byte[] ZeroFullScaleArr = new byte[1];
                    ZeroFullScaleArr[0] = ZeroFullScale;
                    byte[] AfterUnitCodeArr = new byte[1];
                    AfterUnitCodeArr[0] = AfterUnitCode;
                    byte[] AfterUnitCode1Arr = new byte[1];
                    AfterUnitCode1Arr[0] = AfterUnitCode1;
                    byte[] OrderArr = new byte[1];
                    OrderArr[0] = Order;
                    byte[] ToSendAfterOrderArr = new byte[1];
                    ToSendAfterOrderArr[0] = ToSendAfterOrder;
                    byte[] ToSendAfterCollectionArr = new byte[1];
                    byte[] FrequencyArr = new byte[1];
                    FrequencyArr[0] = Convert.ToByte(Frequency);
                    byte[] ForData88Arr = new byte[1];
                    ForData88Arr[0] = ForData88;
                    byte[] OverlapArr = new byte[1];
                    OverlapArr[0] = Convert.ToByte(Overlap);
                    int TotalReadingBytes = StartDataToSend2.Length + 1 + 2 + DataToSend88.Length + 1 + ForData88Arr.Length + ConsTantToSend1.Length + OrderArr.Length + ConsTantToSend.Length + BeforeFF.Length + 6 + AfterUnitCode1Arr.Length + AfterUnitCode1Arr.Length + ForData7Arr.Length + DataToSend7.Length + 1 + ForData6Arr.Length + DataToSend6.Length + 1 + ForData5Arr.Length + DataToSend5.Length + 1 + FirstByteArr.Length + SecondByteArr.Length + StartDataToSend3.Length + DataToSend4.Length + 1 + ForData4Arr.Length;
                    if (ZeroFullScale != 0)
                        TotalReadingBytes = TotalReadingBytes + ZeroFullScaleArr.Length;
                    //if (unitCode[0] != 0)
                    TotalReadingBytes = TotalReadingBytes + unitCode.Length;
                    if (Filter != 0 || AfterUnitCode != 0)
                        TotalReadingBytes = TotalReadingBytes + AfterUnitCodeArr.Length;
                    if (DetectionType != 0)
                        TotalReadingBytes = TotalReadingBytes + DetctionInformationToSend.Length;
                    else if (DetectionType == 0)
                        TotalReadingBytes = TotalReadingBytes + 2;

                    // MessageBox.Show("Date Pass2");
                    if (LinesOfResolutin != 2)
                    {
                        TotalReadingBytes = TotalReadingBytes + ToSendAfterOrderArr.Length;
                        if (LinesOfResolutin < 2)
                            TotalReadingBytes = TotalReadingBytes + ToSendAfterCollectionArr.Length;
                        else if (LinesOfResolutin > 2)
                            TotalReadingBytes = TotalReadingBytes + ToSendAfterCollectionArr.Length;
                        if (Window == 0 && Frequency == 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + 3;

                        }
                        else
                        {
                            TotalReadingBytes = TotalReadingBytes + 4;
                        }
                    }
                    if (LinesOfResolutin == 2)
                    {
                        if (Collection == 0 && Window == 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + 2;
                            if (Frequency != 0)
                            {
                                TotalReadingBytes = TotalReadingBytes + FrequencyArr.Length;
                            }
                            TotalReadingBytes = TotalReadingBytes + 1;
                        }
                        if (Collection != 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + 4;

                            if (Frequency != 0)
                            {
                                TotalReadingBytes = TotalReadingBytes + FrequencyArr.Length;
                            }
                            TotalReadingBytes = TotalReadingBytes + 1;
                        }
                        if (Window != 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + 6;

                        }

                        if (Collection != 0 && Window != 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + 2;
                            TotalReadingBytes = TotalReadingBytes + ToSendAfterOrderArr.Length;
                            if (Window == 0)
                            {
                                TotalReadingBytes = TotalReadingBytes + 2;
                                TotalReadingBytes = TotalReadingBytes + 1;

                            }
                            else
                            {
                                TotalReadingBytes = TotalReadingBytes + 4;
                            }
                        }
                    }
                    if (Slope == 0)
                    {
                        TotalReadingBytes = TotalReadingBytes + 4;
                    }
                    else if (Slope == 1)
                    {
                        TotalReadingBytes = TotalReadingBytes + 6;
                    }



                    if (Measure == 0)
                    {
                        TotalReadingBytes = TotalReadingBytes + 10;
                    }
                    else if (Measure == 1)
                    {
                        TotalReadingBytes = TotalReadingBytes + 19;
                    }

                    else if (Measure == 2)
                        TotalReadingBytes = TotalReadingBytes + 10;
                    if ((Channel == 3 || Channel == 4) && Measure != 3)
                        TotalReadingBytes = TotalReadingBytes * 2;
                    else if ((Channel == 3 || Channel == 4) && Measure == 3)
                        TotalReadingBytes = TotalReadingBytes * 4;
                    string hexReadingBytes = DeciamlToHexadeciaml(TotalReadingBytes);
                    string[] arr = null;

                    arr = hexReadingBytes.Split(new string[] { "," }, StringSplitOptions.None);
                    byte[] arrToConvert1 = new byte[1];
                    byte[] arrToConvert2 = new byte[1];
                    byte[] arrToConvert3 = new byte[1];
                    if (arr.Length == 2)
                    {
                        arrToConvert1 = Encoding.ASCII.GetBytes(arr[0]);
                        arrToConvert2 = Encoding.ASCII.GetBytes(arr[1]);
                        Entrance[0] = 0x30;
                        Entrance[1] = 0x30;
                        Entrance[2] = Convert.ToByte(arrToConvert1[0]);
                        Entrance[3] = Convert.ToByte(arrToConvert2[0]);
                    }
                    else if (arr.Length == 3)
                    {
                        arrToConvert1 = Encoding.ASCII.GetBytes(arr[1]);
                        arrToConvert2 = Encoding.ASCII.GetBytes(arr[2]);
                        arrToConvert3 = Encoding.ASCII.GetBytes(arr[0]);
                        Entrance[0] = 0x30;
                        Entrance[1] = Convert.ToByte(arrToConvert3[0]);
                        Entrance[2] = Convert.ToByte(arrToConvert1[0]);
                        Entrance[3] = Convert.ToByte(arrToConvert2[0]);

                    }
                    byte Recieve = 0;

                    byte[] FinalByteArr = new byte[1];
                    byte[] FinalbyteEnd = new byte[2];
                    byte[] DateLast = new byte[2];
                    if (PointCounter == 0 && same == false)
                    {
                    }
                    int RouteSendingTimes = 0;
                    RouteSendingTimes = Measure + 1;
                    int ApproximateByteForDataEnd = FirstByte;

                    if (Measure == 2)
                        BeforeFF[0]++;

                    string OneB = "\x1b";
                    string ZeroC = "\x0c";
                    string[] ValuesAvgs = null;
                    if (objListOfAvgs.ContainsKey((object)Points[PointCounter]))
                    {
                        ValuesAvgs = objListOfAvgs[Points[PointCounter]].ToString().Split(new string[] { "!" }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else
                    {
                        ValuesAvgs = new string[2];
                        ValuesAvgs[0] = "4";
                        ValuesAvgs[1] = "1";
                    }

                    string[] ArryForSpectAvgs = DeciamlToHexadeciaml(Convert.ToInt32(ValuesAvgs[0])).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    byte[] AyyAvg = null;

                    byte[] CnstFst = { 0x1B, 0x03, 0x5a, 0x1B, 0x12 };
                    byte[] CnstScnd = { 0x5a, 0x1B, 0x12 };
                    bool OnBOth = false;

                    if (ArryForSpectAvgs.Length == 4)
                    {
                        AyyAvg = new byte[2];

                        AyyAvg[0] = Convert.ToByte(HexadecimaltoDecimal(ArryForSpectAvgs[2] + ArryForSpectAvgs[3]));
                        AyyAvg[1] = Convert.ToByte(HexadecimaltoDecimal(ArryForSpectAvgs[0] + ArryForSpectAvgs[1]));

                        OnBOth = false;


                    }
                    else if (ArryForSpectAvgs.Length == 3)
                    {
                        AyyAvg = new byte[2];
                        AyyAvg[0] = Convert.ToByte(HexadecimaltoDecimal(ArryForSpectAvgs[1] + ArryForSpectAvgs[2]));
                        AyyAvg[1] = Convert.ToByte(HexadecimaltoDecimal("0" + ArryForSpectAvgs[0]));

                        OnBOth = false;

                    }
                    else if (ArryForSpectAvgs.Length == 2)
                    {
                        AyyAvg = new byte[1];
                        AyyAvg[0] = Convert.ToByte(HexadecimaltoDecimal(ArryForSpectAvgs[0] + ArryForSpectAvgs[1]));

                        OnBOth = true;


                    }
                    else if (ArryForSpectAvgs.Length == 1)
                    {
                        AyyAvg = new byte[1];
                        AyyAvg[0] = Convert.ToByte(HexadecimaltoDecimal(0 + ArryForSpectAvgs[0]));

                        OnBOth = true;

                    }
                    byte[] TimeAvg = new byte[1];
                    TimeAvg[0] = Convert.ToByte(ValuesAvgs[1]);

                    byte[] ConsTantToSend1now = { 0x00, 0x00, 0x32, 0x73, 0x1B, 0x11 };
                    byte[] ConsTantToSend1nowiftru = { 0x1B, 0x03, 0x32, 0x73, 0x1B, 0x11 };
                    byte[] ConsTantToSend11now = { 0x00, 0x00, 0x5a, 0x1B, 0x12 };
                    byte[] ConsTantToSend11nowiftru = { 0x1B, 0x03, 0x5a, 0x1B, 0x12 };

                    UpArrayCount1 = 0;
                    UploadArrayFactoryNameForUSB = new byte[1];

                    byte[] RtName = System.Text.Encoding.ASCII.GetBytes(Fac);
                    int rtTotal = SumOfByteArray(RtName);

                    //MessageBox.Show(RouteNameToSend1.ToString());
                    MakeArrayForFactoryNameInUSb(RouteNameToSend1);
                    //MessageBox.Show(RouteNameToSend21.ToString());
                    MakeArrayForFactoryNameInUSb(RouteNameToSend21);
                    //MessageBox.Show(RouteNameToSend22.ToString());
                    MakeArrayForFactoryNameInUSb(RouteNameToSend22);
                    //MessageBox.Show(RouteNameToSend3.ToString());
                    MakeArrayForFactoryNameInUSb(RouteNameToSend3);
                    //MessageBox.Show(RouteNameMiddleBytes.ToString());
                    MakeArrayForFactoryNameInUSb(RouteNameMiddleBytes);


                    MakeArrayForFactoryNameInUSb(Encoding.ASCII.GetBytes(RouteName));
                    MakeArrayForFactoryNameInUSb(Encoding.ASCII.GetBytes(OneB));
                    //MessageBox.Show(AfterRouteName.ToString());
                    MakeArrayForFactoryNameInUSb(AfterRouteName);
                    // MessageBox.Show(RouteNumberForRouteName.ToString());
                    MakeArrayForFactoryNameInUSb(RouteNumberForRouteName);
                    //MessageBox.Show(RouteNameToSend4.ToString());
                    MakeArrayForFactoryNameInUSb(RouteNameToSend4);
                    Array.Resize(ref MeasureTypeForArrayMaking, MeasureTypeForArrayMaking.Length + 1);
                    MeasureTypeForArrayMaking[MeasureTypeForArrayMaking.Length - 1] = Measure;

                    if (Channel == 0 || Channel == 1 || Channel == 2)
                    {
                        ResArrayDirection[ResArrayDirection.Length - 1] = "X";
                        if (Measure == 0)
                        {

                            if (PointCounter == 0 && same == false)
                            {

                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }
                            MakeArray(StartDataToSend22);
                            MakeArray(FirstByteArr);
                            MakeArray(SecondByteArr);
                            MakeArray(StartDataToSend3b);
                            byte[] aaa = new byte[1];
                            aaa[0] = Convert.ToByte(0x02 + PointCounter);
                            if (aaa[0] == 0x1b)
                            {
                                byte[] aaa11 = new byte[1];
                                aaa11[0] = Convert.ToByte(0);
                                MakeArray(aaa11);
                            }
                            else
                            {
                                MakeArray(aaa);
                            }
                            MakeArray(StartDataToSend3l);
                            byte[] DataToSend4Change = ChangeName(DataToSend4);
                            MakeArray(DataToSend4Change);
                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            MakeArray(OB);
                            MakeArray(ForData4Arr);
                            byte[] DataToSend5Change = ChangeName(DataToSend5);
                            MakeArray(DataToSend5Change);
                            MakeArray(OB);
                            MakeArray(ForData5Arr);
                            byte[] DataToSend6Change = ChangeName(DataToSend6);
                            MakeArray(DataToSend6Change);
                            MakeArray(OB);
                            MakeArray(ForData6Arr);
                            byte[] DataToSend7Change = ChangeName(DataToSend7);
                            MakeArray(DataToSend7Change);
                            MakeArray(OB);
                            MakeArray(ForData7Arr);
                            if (ZeroFullScale != 0)
                            {
                                MakeArray(ZeroFullScaleArr);
                            }
                            if (Filter == 0 && Unit == 0)
                            {
                                int kk = 0;
                            }
                            else
                            {
                                MakeArray(unitCode);
                            }
                            if (Filter != 0 || AfterUnitCode != 0 || Excep == false)
                            {
                                MakeArray(AfterUnitCodeArr);
                            }
                            if (Filter != 0 || Excep == false)
                                MakeArray(AfterUnitCode1Arr);
                            MakeArray(BeforeFF);

                            byte[] ZC = new byte[1];
                            ZC[0] = 0x0c;
                            for (int i = 0; i < 6; i++)
                            {
                                byte[] ff = new byte[1];
                                ff[0] = 0xff;
                                MakeArray(ff);
                            }
                            if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                            {

                                if (DetectionType != 0)
                                {

                                    MakeArray(DetctionInformationToSend);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                                else if (DetectionType == 0)
                                {

                                    MakeArray(OB);
                                    MakeArray(ZC);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                            }
                            else
                            {
                                byte[] Cnst = { 0x00, 0x00, 0x01 };
                                byte[] Detec = new byte[1];
                                Detec[0] = DetctionInformationToSend[2];
                                byte[] Cnst2 = { 0x1b, 0x08 };
                                byte[] Cnst3 = { 0x1b, 0x08 };
                                MakeArray(Cnst);
                                MakeArray(Detec);
                                MakeArray(Cnst2);
                                MakeArray(TimeAvg);
                                MakeArray(FirstToSendAlarm);
                                MakeArray(SecondToSendAlarm);
                                MakeArray(Cnst3);

                            }
                            MakeArray(ConsTantToSend);
                            MakeArray(OrderArr);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = 0x00;


                            if (LinesOfResolutin != 2)
                            {
                                MakeArray(ZZ);
                                MakeArray(ToSendAfterOrderArr);
                                if (LinesOfResolutin < 2)
                                {
                                    ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                else if (LinesOfResolutin > 2)
                                {
                                    ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                if (Window == 0 && Frequency == 0)
                                {
                                    WindowZero[0] = 0x1b;
                                    WindowZero[1] = 0x03;
                                    MakeArray(WindowZero);
                                    byte[] zerofour = new byte[1];
                                    zerofour[0] = 0x04;
                                }

                                else
                                {

                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    MakeArray(WindowNotZero);
                                }
                            }
                            if (LinesOfResolutin == 2)
                            {
                                if (Collection != 0 && Window != 0)
                                {

                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);

                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    //frq[1] = 0x04;
                                    MakeArray(frq);
                                }
                                if (Collection == 0 && Window != 0)
                                {

                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);

                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    //WindowNotZero[3] = 0x04;
                                    MakeArray(WindowNotZero);

                                }
                                if (Collection != 0 && Window == 0)
                                {

                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);

                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    //frq[1] = 0x04;
                                    MakeArray(frq);

                                }

                                if (Collection == 0 && Window == 0)
                                {

                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x05;
                                    MakeArray(LinesFourHund);
                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    //frq[1] = 0x04;
                                    MakeArray(frq);



                                }
                            }


                            if (OnBOth)
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend1nowiftru);
                            }
                            else
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend1now);
                            }


                            byte[] DataToSend88Change = ChangeName(DataToSend88);
                            MakeArray(DataToSend88Change);
                            MakeArray(OB);
                            MakeArray(ForData88Arr);

                            if (Slope == 0)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                MakeArray(AfterEquipID);
                            }
                            else if (Slope == 1)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                MakeArray(AfterEquipID);
                            }

                            MakeArray(ZZ);
                            MakeArray(OverlapArr);
                            if (Measure == 0 && LinesOfResolutin == 0)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0xCC, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xCD, };

                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 1)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x94, 0x01, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF2, 0x00, 0x00, };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 2)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x24, 0x03, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF4, 0x00, 0x00, };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 3)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x44, 0x06, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF6, 0x00, 0x00, };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 4)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x84, 0x0c, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF8, 0x00, 0x00, };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 5)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x19, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFA, 0x00, 0x00, };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 6)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x32, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFC, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }

                            PointCounter++;
                        }

                        else if (Measure == 1)
                        {


                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }
                            MakeArray(StartDataToSend22);
                            MakeArray(FirstByteArr);
                            MakeArray(SecondByteArr);

                            MakeArray(StartDataToSend3b);
                            byte[] aaa = new byte[1];
                            aaa[0] = Convert.ToByte(0x02 + PointCounter);
                            if (aaa[0] == 0x1b)
                            {
                                byte[] aaa11 = new byte[1];
                                aaa11[0] = Convert.ToByte(0);
                                MakeArray(aaa11);
                            }
                            else
                            {
                                MakeArray(aaa);
                            }
                            MakeArray(StartDataToSend3l);


                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            byte[] DataToSend4Change = ChangeName(DataToSend4);
                            MakeArray(DataToSend4Change);
                            MakeArray(OB);
                            MakeArray(ForData4Arr);
                            byte[] DataToSend5Change = ChangeName(DataToSend5);
                            MakeArray(DataToSend5Change);
                            MakeArray(OB);
                            MakeArray(ForData5Arr);
                            byte[] DataToSend6Change = ChangeName(DataToSend6);
                            MakeArray(DataToSend6Change);
                            MakeArray(OB);
                            MakeArray(ForData6Arr);
                            byte[] DataToSend7Change = ChangeName(DataToSend7);
                            MakeArray(DataToSend7Change);
                            MakeArray(OB);
                            MakeArray(ForData7Arr);
                            if (ZeroFullScale != 0)
                                MakeArray(ZeroFullScaleArr);
                            if (Filter == 0 && Unit == 0)
                            {
                                int kk = 0;
                            }
                            else
                            {
                                MakeArray(unitCode);
                            }
                            if (Filter != 0 || AfterUnitCode != 0 || Excep == false)
                                MakeArray(AfterUnitCodeArr);
                            if (Filter != 0 || Excep == false)
                                MakeArray(AfterUnitCode1Arr);
                            MakeArray(BeforeFF);
                            for (int i = 0; i < 6; i++)
                            {
                                byte[] ff = new byte[1];
                                ff[0] = 0xff;

                                MakeArray(ff);
                            }
                            if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                            {
                                if (DetectionType != 0)
                                {
                                    MakeArray(DetctionInformationToSend);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                                else if (DetectionType == 0)
                                {

                                    MakeArray(OB);
                                    MakeArray(ZC);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                            }
                            else
                            {
                                byte[] Cnst = { 0x00, 0x00, 0x01 };
                                byte[] Detec = new byte[1];
                                Detec[0] = DetctionInformationToSend[2];
                                byte[] Cnst2 = { 0x1b, 0x08 };
                                byte[] Cnst3 = { 0x1b, 0x08 };
                                MakeArray(Cnst);
                                MakeArray(Detec);
                                MakeArray(Cnst2);
                                MakeArray(TimeAvg);
                                MakeArray(FirstToSendAlarm);
                                MakeArray(SecondToSendAlarm);
                                MakeArray(Cnst3);
                            }
                            MakeArray(ConsTantToSend);
                            MakeArray(OrderArr);


                            if (LinesOfResolutin != 2)
                            {
                                MakeArray(ZZ);
                                MakeArray(ToSendAfterOrderArr);
                                if (LinesOfResolutin < 2)
                                {
                                    ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                else if (LinesOfResolutin > 2)
                                {
                                    ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                if (Window == 0 && Frequency == 0)
                                {
                                    WindowZero[0] = 0x1b;
                                    WindowZero[1] = 0x03;
                                    MakeArray(WindowZero);
                                    string zerofour = "\x04";
                                    //MakeArray(ZF);
                                }
                                else
                                {
                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    MakeArray(WindowNotZero);

                                }
                            }

                            if (LinesOfResolutin == 2)
                            {
                                if (Collection != 0 && Window != 0)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);

                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    //frq[1] = 0x04;
                                    MakeArray(frq);
                                }
                                if (Collection == 0 && Window != 0)
                                {

                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);

                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    MakeArray(WindowNotZero);

                                }
                                if (Collection != 0 && Window == 0)
                                {

                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);

                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    MakeArray(frq);

                                }

                                if (Collection == 0 && Window == 0)
                                {

                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x05;
                                    MakeArray(LinesFourHund);
                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    MakeArray(frq);

                                }
                            }


                            if (OnBOth)
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend1nowiftru);
                            }
                            else
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend1now);
                            }

                            byte[] DataToSend88Change = ChangeName(DataToSend88);
                            MakeArray(DataToSend88Change);

                            MakeArray(OB);
                            MakeArray(ForData88Arr);

                            if (Slope == 0)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                MakeArray(AfterEquipID);
                            }
                            else if (Slope == 1)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                MakeArray(AfterEquipID);
                            }
                            MakeArray(ZZ);
                            MakeArray(OverlapArr);
                            if (Measure == 1 && LinesOfResolutin == 0)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0xCC, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xCD, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }

                            }
                            if (Measure == 1 && LinesOfResolutin == 1)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x94, 0x01, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF2, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }

                            }
                            if (Measure == 1 && LinesOfResolutin == 2)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x24, 0x03, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF4, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }

                            }
                            if (Measure == 1 && LinesOfResolutin == 3)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x44, 0x06, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF6, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }

                            }
                            if (Measure == 1 && LinesOfResolutin == 4)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x84, 0x0c, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF8, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }

                            }
                            if (Measure == 1 && LinesOfResolutin == 5)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x19, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFA, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }

                            }
                            if (Measure == 1 && LinesOfResolutin == 6)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x32, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFC, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }

                            }
                            PointCounter++;
                        }

                        else if (Measure == 2)
                        {
                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            byte[] ZT = new byte[1];
                            ZT[0] = Convert.ToByte(0x03);
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }

                            MakeArray(StartDataToSend22);
                            MakeArray(FirstByteArr);
                            MakeArray(SecondByteArr);
                            MakeArray(StartDataToSend3b);
                            byte[] aaa = new byte[1];
                            aaa[0] = Convert.ToByte(0x02 + PointCounter);
                            if (aaa[0] == 0x1b)
                            {
                                byte[] aaa11 = new byte[1];
                                aaa11[0] = Convert.ToByte(0);
                                MakeArray(aaa11);
                            }
                            else
                            {
                                MakeArray(aaa);
                            }
                            MakeArray(StartDataToSend3l);
                            byte[] DataToSend4Change = ChangeName(DataToSend4);
                            MakeArray(DataToSend4Change);
                            MakeArray(OB);

                            MakeArray(ForData4Arr);
                            byte[] DataToSend5Change = ChangeName(DataToSend5);
                            MakeArray(DataToSend5Change);
                            MakeArray(OB);
                            MakeArray(ForData5Arr);
                            byte[] DataToSend6Change = ChangeName(DataToSend6);
                            MakeArray(DataToSend6Change);
                            MakeArray(OB);
                            MakeArray(ForData6Arr);
                            byte[] DataToSend7Change = ChangeName(DataToSend7);
                            MakeArray(DataToSend7Change);
                            MakeArray(OB);
                            MakeArray(ForData7Arr);
                            int kk = 0;
                            if (ZeroFullScale != 0)
                            {
                                MakeArray(ZeroFullScaleArr);
                            }
                            if (Filter == 0 && Unit == 0)
                            {
                                kk = 1;
                                MakeArray(OB);
                                MakeArray(ZT);
                            }
                            else
                            {
                                MakeArray(unitCode);
                            }
                            if ((Filter != 0 || AfterUnitCode != 0 || Excep == false) && kk == 0)
                            {
                                MakeArray(AfterUnitCodeArr);
                            }
                            if ((Filter != 0 || Excep == false) && kk == 0)
                                MakeArray(AfterUnitCode1Arr);
                            MakeArray(BeforeFF);
                            for (int i = 0; i < 6; i++)
                            {
                                byte[] ff = new byte[1];
                                ff[0] = 0xff;
                                MakeArray(ff);
                            }
                            if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                            {
                                if (DetectionType != 0)
                                {
                                    MakeArray(DetctionInformationToSend);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                                else if (DetectionType == 0)
                                {
                                    MakeArray(OB);
                                    MakeArray(ZC);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                            }
                            else
                            {
                                byte[] Cnst = { 0x00, 0x00, 0x01 };
                                byte[] Detec = new byte[1];
                                Detec[0] = DetctionInformationToSend[2];
                                byte[] Cnst2 = { 0x1b, 0x08 };
                                byte[] Cnst3 = { 0x1b, 0x08 };
                                MakeArray(Cnst);
                                MakeArray(Detec);
                                MakeArray(Cnst2);
                                MakeArray(TimeAvg);
                                MakeArray(FirstToSendAlarm);
                                MakeArray(SecondToSendAlarm);
                                MakeArray(Cnst3);
                            }
                            MakeArray(ConsTantToSend);
                            MakeArray(OrderArr);


                            if (LinesOfResolutin != 2)
                            {
                                MakeArray(ZZ);
                                MakeArray(ToSendAfterOrderArr);
                                if (LinesOfResolutin < 2)
                                {
                                    ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                else if (LinesOfResolutin > 2)
                                {
                                    ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                if (Window == 0 && Frequency == 0)
                                {
                                    WindowZero[0] = 0x1b;
                                    WindowZero[1] = 0x03;
                                    MakeArray(WindowZero);
                                    string zerofour = "\x04";
                                    //MakeArray(ZF);
                                }
                                else
                                {

                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    //WindowNotZero[3] = 0x04;
                                    MakeArray(WindowNotZero);
                                }
                            }
                            if (LinesOfResolutin == 2)
                            {
                                if (Collection != 0 && Window != 0)
                                {


                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);

                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    //frq[1] = 0x04;
                                    MakeArray(frq);
                                }
                                if (Collection == 0 && Window != 0)
                                {

                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);

                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    //WindowNotZero[3] = 0x04;
                                    MakeArray(WindowNotZero);

                                }
                                if (Collection != 0 && Window == 0)
                                {

                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);

                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    //frq[1] = 0x04;
                                    MakeArray(frq);

                                }

                                if (Collection == 0 && Window == 0)
                                {

                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x05;
                                    MakeArray(LinesFourHund);
                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    //frq[1] = 0x04;
                                    MakeArray(frq);

                                }
                            }

                            if (OnBOth)
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend11nowiftru);
                            }
                            else
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend11now);
                            }
                            byte[] DataToSend88Change = ChangeName(DataToSend88);
                            MakeArray(DataToSend88Change);
                            MakeArray(OB);
                            MakeArray(ForData88Arr);

                            if (Slope == 0)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                MakeArray(AfterEquipID);
                            }
                            else if (Slope == 1)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                MakeArray(AfterEquipID);
                            }
                            MakeArray(ZZ);
                            MakeArray(OverlapArr);

                            if (Measure == 2 && LinesOfResolutin == 0)
                            {


                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x02, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF3, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }

                            if (Measure == 2 && LinesOfResolutin == 1)
                            {

                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x04, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF5, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }

                            if (Measure == 2 && LinesOfResolutin == 2)
                            {

                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x08, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF7, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }

                            if (Measure == 2 && LinesOfResolutin == 3)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x10, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF9, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }

                            if (Measure == 2 && LinesOfResolutin == 4)
                            {

                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x20, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFB, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 2 && LinesOfResolutin == 5)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x40, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFD, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }

                            if (Measure == 2 && LinesOfResolutin == 6)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x80, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFF, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            PointCounter++;
                        }
                    }

                    else if (Channel == 3 || Channel == 4)
                    {
                        ResArrayDirection[ResArrayDirection.Length - 1] = "XY";
                        int dualChannelCounter = 0;
                        if (Measure == 0)
                        {


                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }
                            do
                            {

                                MakeArray(StartDataToSend22);
                                MakeArray(FirstByteArr);
                                MakeArray(SecondByteArr);


                                MakeArray(StartDataToSend3ForDualChannel);



                                byte[] aaa = new byte[1];
                                aaa[0] = Convert.ToByte(0x02 + PointCounter);
                                if (aaa[0] == 0x1b)
                                {
                                    byte[] aaa11 = new byte[1];
                                    aaa11[0] = Convert.ToByte(0);
                                    MakeArray(aaa11);
                                }
                                else
                                {
                                    MakeArray(aaa);
                                }



                                if (dualChannelCounter == 0)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter0);
                                else if (dualChannelCounter == 1)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter1);

                                byte[] DataToSend4Change = ChangeName(DataToSend4);
                                MakeArray(DataToSend4Change);
                                MakeArray(OB);
                                MakeArray(ForData4Arr);
                                byte[] DataToSend5Change = ChangeName(DataToSend5);
                                MakeArray(DataToSend5Change);
                                MakeArray(OB);
                                MakeArray(ForData5Arr);
                                byte[] DataToSend6Change = ChangeName(DataToSend6);
                                MakeArray(DataToSend6Change);
                                MakeArray(OB);
                                MakeArray(ForData6Arr);
                                byte[] DataToSend7Change = ChangeName(DataToSend7);
                                MakeArray(DataToSend7Change);
                                MakeArray(OB);
                                MakeArray(ForData7Arr);
                                if (ZeroFullScale != 0)
                                    MakeArray(ZeroFullScaleArr);
                                if (Filter == 0 && Unit == 0)
                                {
                                    int kk = 0;
                                }
                                else
                                {
                                    MakeArray(unitCode);
                                }
                                if (Filter != 0 || AfterUnitCode != 0 || Excep == false)
                                    MakeArray(AfterUnitCodeArr);
                                if (Filter != 0 || Excep == false)
                                    MakeArray(AfterUnitCode1Arr);
                                MakeArray(BeforeFF);

                                for (int i = 0; i < 6; i++)
                                {
                                    byte[] ff = new byte[1];
                                    ff[0] = 0xff;
                                    MakeArray(ff);
                                }
                                if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                                {
                                    if (DetectionType != 0)
                                    {
                                        MakeArray(DetctionInformationToSend);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                    else if (DetectionType == 0)
                                    {
                                        MakeArray(OB);
                                        MakeArray(ZC);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                }
                                else
                                {
                                    byte[] Cnst = { 0x00, 0x00, 0x01 };
                                    byte[] Detec = new byte[1];
                                    Detec[0] = DetctionInformationToSend[2];
                                    byte[] Cnst2 = { 0x1b, 0x08 };
                                    byte[] Cnst3 = { 0x1b, 0x08 };
                                    MakeArray(Cnst);
                                    MakeArray(Detec);
                                    MakeArray(Cnst2);
                                    MakeArray(TimeAvg);
                                    MakeArray(FirstToSendAlarm);
                                    MakeArray(SecondToSendAlarm);
                                    MakeArray(Cnst3);
                                }
                                MakeArray(ConsTantToSend);

                                MakeArray(OrderArr);


                                if (LinesOfResolutin != 2)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    if (LinesOfResolutin < 2)
                                    {
                                        ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    else if (LinesOfResolutin > 2)
                                    {
                                        ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    if (Window == 0 && Frequency == 0)
                                    {
                                        WindowZero[0] = 0x1b;
                                        WindowZero[1] = 0x03;
                                        MakeArray(WindowZero);
                                        string zerofour = "\x04";
                                        //MakeArray(ZF);
                                    }
                                    else
                                    {

                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        //WindowNotZero[3] = 0x04;
                                        MakeArray(WindowNotZero);
                                    }
                                }
                                if (LinesOfResolutin == 2)
                                {
                                    if (Collection != 0 && Window != 0)
                                    {


                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);

                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        //frq[1] = 0x04;
                                        MakeArray(frq);
                                    }
                                    if (Collection == 0 && Window != 0)
                                    {

                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);

                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);

                                        MakeArray(WindowNotZero);

                                    }
                                    if (Collection != 0 && Window == 0)
                                    {

                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);

                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        //frq[1] = 0x04;
                                        MakeArray(frq);

                                    }

                                    if (Collection == 0 && Window == 0)
                                    {

                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x05;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        //frq[1] = 0x04;
                                        MakeArray(frq);

                                    }
                                }


                                if (OnBOth)
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend11nowiftru);
                                }
                                else
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend11now);
                                }

                                byte[] DataToSend88Change = ChangeName(DataToSend88);
                                MakeArray(DataToSend88Change);
                                MakeArray(OB);
                                MakeArray(ForData88Arr);

                                if (Slope == 0)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                else if (Slope == 1)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                MakeArray(ZZ);
                                MakeArray(OverlapArr);
                                dualChannelCounter++;
                                if (dualChannelCounter == 2)
                                    dualChannelCounter = 0;
                                if (Measure == 0 && LinesOfResolutin == 0)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0xCC, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xCD };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 1)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x94, 0x01, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF2, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 2)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x24, 0x03, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF4, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 3)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x44, 0x06, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF6, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 4)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x84, 0x0C, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF8, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 5)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x19, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFA, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 6)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x32, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFC, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                            } while (dualChannelCounter == 1);
                            PointCounter++;
                        }

                        else if (Measure == 1)
                        {
                            dualChannelCounter = 0;

                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }
                            do
                            {
                                MakeArray(StartDataToSend22);
                                MakeArray(FirstByteArr);
                                MakeArray(SecondByteArr);
                                MakeArray(StartDataToSend3ForDualChannel);
                                byte[] aaa = new byte[1];
                                aaa[0] = Convert.ToByte(0x02 + PointCounter);
                                if (aaa[0] == 0x1b)
                                {
                                    byte[] aaa11 = new byte[1];
                                    aaa11[0] = Convert.ToByte(0);
                                    MakeArray(aaa11);
                                }
                                else
                                {
                                    MakeArray(aaa);
                                }


                                if (dualChannelCounter == 0)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter0);
                                else if (dualChannelCounter == 1)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter1);

                                byte[] DataToSend4Change = ChangeName(DataToSend4);
                                MakeArray(DataToSend4Change);
                                MakeArray(OB);
                                MakeArray(ForData4Arr);
                                byte[] DataToSend5Change = ChangeName(DataToSend5);
                                MakeArray(DataToSend5Change);
                                MakeArray(OB);
                                MakeArray(ForData5Arr);
                                byte[] DataToSend6Change = ChangeName(DataToSend6);
                                MakeArray(DataToSend6Change);
                                MakeArray(OB);
                                MakeArray(ForData6Arr);
                                byte[] DataToSend7Change = ChangeName(DataToSend7);
                                MakeArray(DataToSend7Change);
                                MakeArray(OB);
                                MakeArray(ForData7Arr);
                                if (ZeroFullScale != 0)
                                    MakeArray(ZeroFullScaleArr);
                                if (Filter == 0 && Unit == 0)
                                {
                                    int kk = 0;
                                }
                                else
                                {
                                    MakeArray(unitCode);
                                }
                                if (Filter != 0 || AfterUnitCode != 0 || Excep == false)
                                    MakeArray(AfterUnitCodeArr);
                                if (Filter != 0 || Excep == false)
                                    MakeArray(AfterUnitCode1Arr);

                                MakeArray(BeforeFF);
                                for (int i = 0; i < 6; i++)
                                {
                                    byte[] ff = new byte[1];
                                    ff[0] = 0xff;
                                    MakeArray(ff);
                                }

                                if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                                {
                                    if (DetectionType != 0)
                                    {
                                        MakeArray(DetctionInformationToSend);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                    else if (DetectionType == 0)
                                    {
                                        MakeArray(OB);
                                        MakeArray(ZC);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                }
                                else
                                {
                                    byte[] Cnst = { 0x00, 0x00, 0x01 };
                                    byte[] Detec = new byte[1];
                                    Detec[0] = DetctionInformationToSend[2];
                                    byte[] Cnst2 = { 0x1b, 0x08 };
                                    byte[] Cnst3 = { 0x1b, 0x08 };
                                    MakeArray(Cnst);
                                    MakeArray(Detec);
                                    MakeArray(Cnst2);
                                    MakeArray(TimeAvg);
                                    MakeArray(FirstToSendAlarm);
                                    MakeArray(SecondToSendAlarm);
                                    MakeArray(Cnst3);
                                }

                                SensitivityFunction(Convert.ToInt32(Information[4]));
                                MakeArray(ConsTantToSend);
                                MakeArray(OrderArr);


                                if (LinesOfResolutin != 2)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    if (LinesOfResolutin < 2)
                                    {
                                        ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    else if (LinesOfResolutin > 2)
                                    {
                                        ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    if (Window == 0 && Frequency == 0)
                                    {
                                        WindowZero[0] = 0x1b;
                                        WindowZero[1] = 0x03;
                                        MakeArray(WindowZero);
                                        string zerofour = "\x04";
                                        //MakeArray(ZF);
                                    }
                                    else
                                    {

                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        //WindowNotZero[3] = 0x04;
                                        MakeArray(WindowNotZero);
                                    }
                                }
                                if (LinesOfResolutin == 2)
                                {
                                    if (Collection != 0 && Window != 0)
                                    {


                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);

                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        //frq[1] = 0x04;
                                        MakeArray(frq);
                                    }
                                    if (Collection == 0 && Window != 0)
                                    {

                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);

                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);
                                    }
                                    if (Collection != 0 && Window == 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);

                                    }

                                    if (Collection == 0 && Window == 0)
                                    {

                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x05;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                }
                                if (OnBOth)
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend1nowiftru);
                                }
                                else
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend1now);
                                }
                                byte[] DataToSend88Change = ChangeName(DataToSend88);
                                MakeArray(DataToSend88Change);
                                MakeArray(OB);
                                MakeArray(ForData88Arr);

                                if (Slope == 0)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                else if (Slope == 1)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                MakeArray(ZZ);
                                MakeArray(OverlapArr);
                                dualChannelCounter++;
                                if (dualChannelCounter == 2)
                                    dualChannelCounter = 0;

                                if (Measure == 1 && LinesOfResolutin == 0)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0xCC, 0x1B, 0xCD, 0x34, 0x01, 0x26, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }

                                }
                                if (Measure == 1 && LinesOfResolutin == 1)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x94, 0x01, 0x1B, 0xF2, 0x00, 0x00, 0x34, 0x01, 0x26, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }

                                }
                                if (Measure == 1 && LinesOfResolutin == 2)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x24, 0x03, 0x1B, 0xF4, 0x00, 0x00, 0x34, 0x01, 0x26, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }

                                }
                                if (Measure == 1 && LinesOfResolutin == 3)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x44, 0x06, 0x1B, 0xF6, 0x00, 0x00, 0x34, 0x01, 0x26, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }

                                }
                                if (Measure == 1 && LinesOfResolutin == 4)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x84, 0x0c, 0x1B, 0xF8, 0x00, 0x00, 0x34, 0x01, 0x26, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }

                                }
                                if (Measure == 1 && LinesOfResolutin == 5)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x19, 0x1B, 0xFA, 0x00, 0x00, 0x34, 0x01, 0x26, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }

                                }
                                if (Measure == 1 && LinesOfResolutin == 6)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x32, 0x1B, 0xFC, 0x00, 0x00, 0x34, 0x01, 0x26, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                            } while (dualChannelCounter == 1);
                            PointCounter++;
                        }

                        else if (Measure == 2)
                        {
                            dualChannelCounter = 0;

                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            byte[] ZT = new byte[1];
                            ZT[0] = Convert.ToByte(0x03);
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }

                            do
                            {
                                MakeArray(StartDataToSend22);
                                MakeArray(FirstByteArr);
                                MakeArray(SecondByteArr);
                                MakeArray(StartDataToSend3ForDualChannel);
                                byte[] aaa = new byte[1];
                                aaa[0] = Convert.ToByte(0x02 + PointCounter);
                                if (aaa[0] == 0x1b)
                                {
                                    byte[] aaa11 = new byte[1];
                                    aaa11[0] = Convert.ToByte(0);
                                    MakeArray(aaa11);
                                }
                                else
                                {
                                    MakeArray(aaa);
                                }



                                if (dualChannelCounter == 0)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter0);
                                else if (dualChannelCounter == 1)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter1);

                                byte[] DataToSend4Change = ChangeName(DataToSend4);
                                MakeArray(DataToSend4Change);
                                MakeArray(OB);
                                MakeArray(ForData4Arr);
                                byte[] DataToSend5Change = ChangeName(DataToSend5);
                                MakeArray(DataToSend5Change);
                                MakeArray(OB);
                                MakeArray(ForData5Arr);
                                byte[] DataToSend6Change = ChangeName(DataToSend6);
                                MakeArray(DataToSend6Change);
                                MakeArray(OB);
                                MakeArray(ForData6Arr);
                                byte[] DataToSend7Change = ChangeName(DataToSend7);
                                MakeArray(DataToSend7Change);
                                MakeArray(OB);
                                MakeArray(ForData7Arr);
                                int kk = 0;
                                if (ZeroFullScale != 0)
                                    MakeArray(ZeroFullScaleArr);
                                if (Filter == 0 && Unit == 0)
                                {
                                    kk = 1;
                                    MakeArray(OB);
                                    MakeArray(ZT);
                                }
                                else
                                {
                                    MakeArray(unitCode);
                                }
                                if ((Filter != 0 || AfterUnitCode != 0 || Excep == false) && kk == 0)
                                    MakeArray(AfterUnitCodeArr);
                                if ((Filter != 0 || Excep == false) && kk == 0)
                                    MakeArray(AfterUnitCode1Arr);
                                MakeArray(BeforeFF);
                                for (int i = 0; i < 6; i++)
                                {
                                    byte[] ff = new byte[1];
                                    ff[0] = 0xff;
                                    MakeArray(ff);
                                }
                                if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                                {
                                    if (DetectionType != 0)
                                    {
                                        MakeArray(DetctionInformationToSend);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                    else if (DetectionType == 0)
                                    {
                                        MakeArray(OB);
                                        MakeArray(ZC);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                }
                                else
                                {
                                    byte[] Cnst = { 0x00, 0x00, 0x01 };
                                    byte[] Detec = new byte[1];
                                    Detec[0] = DetctionInformationToSend[2];
                                    byte[] Cnst2 = { 0x1b, 0x08 };
                                    byte[] Cnst3 = { 0x1b, 0x08 };
                                    MakeArray(Cnst);
                                    MakeArray(Detec);
                                    MakeArray(Cnst2);
                                    MakeArray(TimeAvg);
                                    MakeArray(FirstToSendAlarm);
                                    MakeArray(SecondToSendAlarm);
                                    MakeArray(Cnst3);
                                }
                                MakeArray(ConsTantToSend);
                                MakeArray(OrderArr);

                                if (LinesOfResolutin != 2)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    if (LinesOfResolutin < 2)
                                    {
                                        ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    else if (LinesOfResolutin > 2)
                                    {
                                        ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    if (Window == 0 && Frequency == 0)
                                    {
                                        WindowZero[0] = 0x1b;
                                        WindowZero[1] = 0x03;
                                        MakeArray(WindowZero);
                                        string zerofour = "\x04";
                                    }
                                    else
                                    {
                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);
                                    }
                                }
                                if (LinesOfResolutin == 2)
                                {
                                    if (Collection != 0 && Window != 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                    if (Collection == 0 && Window != 0)
                                    {

                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);

                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);

                                    }
                                    if (Collection != 0 && Window == 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);

                                    }

                                    if (Collection == 0 && Window == 0)
                                    {
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x05;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                }
                                if (OnBOth)
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend11nowiftru);
                                }
                                else
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend11now);
                                }
                                byte[] DataToSend88Change = ChangeName(DataToSend88);
                                MakeArray(DataToSend88Change);
                                MakeArray(OB);
                                MakeArray(ForData88Arr);

                                if (Slope == 0)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                else if (Slope == 1)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                MakeArray(ZZ);
                                MakeArray(OverlapArr);
                                dualChannelCounter++;
                                if (dualChannelCounter == 2)
                                    dualChannelCounter = 0;
                                if (Measure == 2 && LinesOfResolutin == 0)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x02, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF3, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 1)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x04, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF5, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 2)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x08, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF7, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 3)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x10, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF9, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 4)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x20, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFB, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 5)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x40, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFD, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 6)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x80, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFF, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                            } while (dualChannelCounter == 1);

                            PointCounter++;
                        }
                        else if (Measure == 3)
                        {
                            dualChannelCounter = 0;

                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            byte[] TZ = new byte[1];
                            TZ[0] = Convert.ToByte(0x30);
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }

                            do
                            {
                                MakeArray(StartDataToSend22);
                                MakeArray(FirstByteArr);
                                MakeArray(SecondByteArr);
                                MakeArray(StartDataToSend3ForDualChannel);

                                byte[] aaa = new byte[1];
                                aaa[0] = Convert.ToByte(0x02 + PointCounter);
                                if (aaa[0] == 0x1b)
                                {
                                    byte[] aaa11 = new byte[1];
                                    aaa11[0] = Convert.ToByte(0);
                                    MakeArray(aaa11);
                                }
                                else
                                {
                                    MakeArray(aaa);
                                }

                                if (dualChannelCounter == 0 || dualChannelCounter == 2)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter0);
                                else if (dualChannelCounter == 1 || dualChannelCounter == 3)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter1);

                                byte[] DataToSend4Change = ChangeName(DataToSend4);
                                MakeArray(DataToSend4Change);
                                MakeArray(OB);
                                MakeArray(ForData4Arr);
                                byte[] DataToSend5Change = ChangeName(DataToSend5);
                                MakeArray(DataToSend5Change);
                                MakeArray(OB);
                                MakeArray(ForData5Arr);
                                byte[] DataToSend6Change = ChangeName(DataToSend6);
                                MakeArray(DataToSend6Change);
                                MakeArray(OB);
                                MakeArray(ForData6Arr);
                                byte[] DataToSend7Change = ChangeName(DataToSend7);
                                MakeArray(DataToSend7Change);
                                MakeArray(OB);
                                MakeArray(ForData7Arr);
                                if (ZeroFullScale != 0)
                                    MakeArray(ZeroFullScaleArr);
                                if (Filter == 0 && Unit == 0)
                                {
                                    int kk = 0;
                                }
                                else
                                {
                                    MakeArray(unitCode);
                                }
                                if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                {
                                    byte[] sennd = { 0x30, 0x00, 0x05, 0x00 };
                                    MakeArray(sennd);
                                }
                                else
                                {
                                    if (Filter != 0 || AfterUnitCode != 0)
                                        MakeArray(AfterUnitCodeArr);
                                    if (Filter != 0)
                                        MakeArray(AfterUnitCode1Arr);
                                    if (Filter == 0)
                                    {
                                        MakeArray(TZ);
                                        MakeArray(ZZ);
                                    }
                                    MakeArray(BeforeFF);
                                }

                                for (int i = 0; i < 6; i++)
                                {
                                    byte[] ff = new byte[1];
                                    ff[0] = 0xff;
                                    MakeArray(ff);
                                }
                                if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                                {
                                    if (DetectionType != 0)
                                    {
                                        MakeArray(DetctionInformationToSend);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                    else if (DetectionType == 0)
                                    {
                                        MakeArray(OB);
                                        MakeArray(ZC);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                }
                                else
                                {
                                    byte[] Cnst = { 0x00, 0x00, 0x01 };
                                    byte[] Detec = new byte[1];
                                    Detec[0] = DetctionInformationToSend[2];
                                    byte[] Cnst2 = { 0x1b, 0x08 };
                                    byte[] Cnst3 = { 0x1b, 0x08 };
                                    MakeArray(Cnst);
                                    MakeArray(Detec);
                                    MakeArray(Cnst2);
                                    MakeArray(TimeAvg);
                                    MakeArray(FirstToSendAlarm);
                                    MakeArray(SecondToSendAlarm);
                                    MakeArray(Cnst3);
                                }
                                MakeArray(ConsTantToSend);
                                MakeArray(OrderArr);
                                if (LinesOfResolutin != 2)
                                {
                                    MakeArray(ZZ);
                                    byte[] sender1 = new byte[1];
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                        sender1[0] = 0x00;
                                    else
                                        sender1[0] = 0x04;
                                    MakeArray(sender1);
                                    if (LinesOfResolutin < 2)
                                    {
                                        ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    else if (LinesOfResolutin > 2)
                                    {
                                        ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    if (Window == 0 && Frequency == 0)
                                    {
                                        WindowZero[0] = 0x1b;
                                        WindowZero[1] = 0x03;
                                        MakeArray(WindowZero);
                                        string zerofour = "\x04";
                                    }
                                    else
                                    {
                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);
                                    }
                                }
                                if (LinesOfResolutin == 2)
                                {
                                    if (Collection != 0 && Window != 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                    if (Collection == 0 && Window != 0)
                                    {
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);
                                    }
                                    if (Collection != 0 && Window == 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);

                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }

                                    if (Collection == 0 && Window == 0)
                                    {
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x05;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                }
                                if (OnBOth)
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend11nowiftru);
                                }
                                else
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend11now);
                                }
                                byte[] DataToSend88Change = ChangeName(DataToSend88);
                                MakeArray(DataToSend88Change);
                                MakeArray(OB);

                                MakeArray(ForData88Arr);

                                if (Slope == 0)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                else if (Slope == 1)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                MakeArray(ZZ);
                                MakeArray(OverlapArr);
                                if (Measure == 3 && LinesOfResolutin == 0)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);
                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x02, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF3, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 1)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);
                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x04, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF5, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 2)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);
                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x08, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF7, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 3)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);
                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x10, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xF9, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 4)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);
                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x20, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFB, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 5)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);

                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x40, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFD, 0x00, 0x00 };
                                        MakeArray(FinalEnd);

                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 6)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);
                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x80, 0xFC, 0xFC, 0xFC, 0xFC, 0xFC, 0x1B, 0xFF, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                dualChannelCounter++;
                                if (dualChannelCounter < 4)
                                {
                                    int kkk = 1;
                                }

                            } while (dualChannelCounter < 4);
                            PointCounter++;
                            if (dualChannelCounter == 4)
                                dualChannelCounter = 0;
                        }
                    }
                } while (Points.Length - 1 != PointCounter);
            }
            catch { }
        }







        int[] MeasureTypeForArrayMaking = new int[0];
        private void MakeUsbArrayForTourData()
        {
            UInt64 CtrForUsb = 0;
            byte[] BytesFortourData = new byte[0];
            int CtrForRes = 0;
            int dualChnl = 0;
            int MsrCtr = 0;
            UInt64 iCtrMsr = 0;
            UInt64 Uploadlength = Convert.ToUInt64(UploadArray.Length);
            try
            {
                do
                {
                    //if ((UploadArray[CtrForUsb] == 46 && UploadArray[CtrForUsb + 1] == 01 && UploadArray[CtrForUsb + 2] == 00 && UploadArray[CtrForUsb + 3] == 00 && UploadArray[CtrForUsb + 4] == 88) || (UploadArray[CtrForUsb] == 88 && UploadArray[CtrForUsb + 1] == 02 && UploadArray[CtrForUsb + 2] == 06 && UploadArray[CtrForUsb + 3] == 01))
                    //{
                    UInt64 i = CtrForUsb;
                    CtrForRes = Convert.ToInt32(CtrForUsb);
                    do
                    {
                        if (UploadArray[i] == 0xFC && UploadArray[i + 1] == 0xFC && UploadArray[i + 2] == 0xFC && UploadArray[i + 3] == 0xFC && UploadArray[i + 4] == 0xFC)
                        {

                            int ZeroCtr = ResArray[CtrForRes];
                            int Measure = MeasureTypeForArrayMaking[CtrForRes];
                            if (ZeroCtr == 100)
                            {
                                ZeroCtr = (ZeroCtr * 2) + 5;
                            }
                            else if (ZeroCtr == 200 || ZeroCtr == 400 || ZeroCtr == 800 || ZeroCtr == 1600 || ZeroCtr == 3200 || ZeroCtr == 6400)
                            {
                                ZeroCtr = (ZeroCtr * 2) + 4;
                            }
                            else
                            {
                                ZeroCtr = (ZeroCtr * 2) + 2;
                            }
                            Array.Resize(ref BytesFortourData, BytesFortourData.Length + ZeroCtr);
                            CtrForUsb = i - 1;
                            if (ResArrayDirection[CtrForRes] == "X")
                            {
                                CtrForRes++;
                                dualChnl = 0;
                            }
                            else if (ResArrayDirection[CtrForRes] == "XY" && dualChnl == 0)
                            {
                                dualChnl++;
                            }
                            else if (ResArrayDirection[CtrForRes] == "XY" && dualChnl == 1)
                            {
                                CtrForRes++;
                                dualChnl = 0;
                            }
                            if (Measure == 1)
                            {
                                MsrCtr = 0;
                                iCtrMsr = i + 9;
                                do
                                {
                                    if (UploadArray[iCtrMsr] != 0xFC)
                                    {
                                        if (UploadArray[iCtrMsr] != 0x1b)
                                        {
                                            Array.Resize(ref BytesFortourData, BytesFortourData.Length + 1);
                                            BytesFortourData[BytesFortourData.Length - 1] = UploadArray[iCtrMsr];
                                        }
                                        else if (UploadArray[iCtrMsr] == 0x1b && UploadArray[iCtrMsr + 1] == 0xf4 && UploadArray[iCtrMsr + 2] == 0x1b && UploadArray[iCtrMsr + 3] == 0x05)
                                        {
                                            int ZeroCtr11 = 807;
                                            Array.Resize(ref BytesFortourData, BytesFortourData.Length + ZeroCtr11);
                                            break;
                                        }
                                        if (MsrCtr >= 10)
                                        {
                                            break;
                                        }
                                        MsrCtr++;
                                    }
                                    iCtrMsr++;
                                } while (true);
                            }
                            break;
                        }
                        else
                        {
                            if (UploadArray[i] != 0x1b)
                            {
                                Array.Resize(ref BytesFortourData, BytesFortourData.Length + 1);
                                BytesFortourData[BytesFortourData.Length - 1] = UploadArray[i];
                            }
                            else
                            {
                                int ZeroCtr = Convert.ToInt32(UploadArray[i + 1]);
                                Array.Resize(ref BytesFortourData, BytesFortourData.Length + ZeroCtr);
                                i++;
                            }
                        }
                        i++;
                    }
                    while (i < Uploadlength);
                    _objMain.lblStatus.Caption = "CreatingOK";
                    //}
                    CtrForUsb++;

                } while (true);
            }
            catch { }

            TourName = "TOUR" + Convert.ToString(HeightCountOfTour + 1);
            if (File.Exists(PublicClass.Path))
            {
                File.Delete(PublicClass.Path);
            }
            using (FileStream objStream = new FileStream(PublicClass.Path, FileMode.Create, FileAccess.Write))
            {
                objStream.Write(BytesFortourData, 0, BytesFortourData.Length);
            }

            // MakeTourDataFile(BytesFortourData);
        }

        private byte[] MakeUsbArrayForTourDataFacName()
        {
            int CtrForUsb = 0;
            byte[] BytesFortourData = new byte[0];
            int CtrForRes = 0;
            bool tt = false;
            try
            {
                do
                {
                    if (UploadArrayFactoryNameForUSB[CtrForUsb] == 46 && UploadArrayFactoryNameForUSB[CtrForUsb + 1] == 01 && UploadArrayFactoryNameForUSB[CtrForUsb + 2] == 00 && UploadArrayFactoryNameForUSB[CtrForUsb + 3] == 00)
                    {

                        for (int i = CtrForUsb; i < UploadArrayFactoryNameForUSB.Length - 3; i++)
                        {
                            if (UploadArrayFactoryNameForUSB[i] == 0xFC && UploadArrayFactoryNameForUSB[i + 1] == 0xFC && UploadArrayFactoryNameForUSB[i + 2] == 0xFC && UploadArrayFactoryNameForUSB[i + 3] == 0xFC && UploadArrayFactoryNameForUSB[i + 4] == 0xFC)
                            {
                                int ZeroCtr = ResArray[CtrForRes];
                                if (ZeroCtr == 100 || ZeroCtr == 200 || ZeroCtr == 400 || ZeroCtr == 800 || ZeroCtr == 1600 || ZeroCtr == 3200 || ZeroCtr == 6400)
                                {
                                    ZeroCtr = (ZeroCtr * 2) + 4;
                                }
                                else
                                {
                                    ZeroCtr = (ZeroCtr * 2) + 2;
                                }
                                for (int j = 0; j < ZeroCtr; j++)
                                {
                                    Array.Resize(ref BytesFortourData, BytesFortourData.Length + 1);
                                    BytesFortourData[BytesFortourData.Length - 1] = 0x00;
                                }
                                CtrForRes++;
                                break;
                            }
                            else
                            {
                                if (UploadArrayFactoryNameForUSB[i] != 0x1b)
                                {
                                    Array.Resize(ref BytesFortourData, BytesFortourData.Length + 1);
                                    BytesFortourData[BytesFortourData.Length - 1] = UploadArrayFactoryNameForUSB[i];
                                }
                                else
                                {
                                    int ZeroCtr = Convert.ToInt32(UploadArrayFactoryNameForUSB[i + 1]);
                                    for (int j = 0; j < ZeroCtr; j++)
                                    {
                                        Array.Resize(ref BytesFortourData, BytesFortourData.Length + 1);
                                        BytesFortourData[BytesFortourData.Length - 1] = 0x00;
                                    }
                                    i++;
                                }
                                tt = true;
                            }

                        }
                        if (tt == true)
                            break;
                    }
                    CtrForUsb++;
                } while (true);
            }
            catch { }
            return BytesFortourData;
        }


        byte[] UploadArrayFactoryNameForUSB = new byte[1];
        private void MakeArrayForFactoryNameInUSb(byte[] Target)
        {
            try
            {
                Array.Resize(ref UploadArrayFactoryNameForUSB, UploadArrayFactoryNameForUSB.Length + Target.Length);
                for (int i = 0; i < Target.Length; i++)
                {
                    UploadArrayFactoryNameForUSB[UpArrayCount] = Target[i];
                    UpArrayCount++;
                }
            }
            catch { }
        }


        private void MakeTourDataFile(byte[] Arry)
        {
            try
            {
                _objMain.lblStatus.Caption = "CreatingOK";
                TourName = "TOUR" + Convert.ToString(HeightCountOfTour + 1);
                if (File.Exists(path + "DiFiles\\" + TourName + "\\ctrl.cfg"))
                {
                    File.Delete(path + "DiFiles\\" + TourName + "\\ctrl.cfg");
                }

                using (FileStream objStream = new FileStream(path + "DiFiles\\" + TourName + "\\ctrl.cfg", FileMode.Create, FileAccess.Write))
                {
                    byte[] ToWrite = MakeUsbArrayForTourDataFacName();
                    objStream.Write(ToWrite, 0, ToWrite.Length);
                }


                if (File.Exists(path + "DiFiles\\" + TourName + "\\tourdata.dat"))
                {
                    File.Delete(path + "DiFiles\\" + TourName + "\\tourdata.dat");
                }
                using (FileStream objStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "DiFiles\\" + TourName + "\\tourdata.dat", FileMode.Create, FileAccess.Write))
                {
                    objStream.Write(Arry, 0, Arry.Length);
                }
                if (File.Exists(path + "DiFiles\\" + TourName + "\\tourinfo.dat"))
                {
                    File.Delete(path + "DiFiles\\" + TourName + "\\tourinfo.dat");
                }

                using (FileStream objStream = new FileStream(path + "DiFiles\\" + TourName + "\\tourinfo.dat", FileMode.Create, FileAccess.Write))
                {
                    byte[] Arr1 = { 0x00, 0x00, 0x00, 0x00, 0x08, 0x45, 0x3A, 0x5C, 0x74, 0x65, 0x73, 0x74, 0x5C, 0x01, 0x00, 0x00, 0x00 };
                    objStream.Write(Arr1, 0, Arr1.Length);
                }

                if (File.Exists(path + "DiFiles\\" + TourName + "\\offtdata.dat"))
                {
                    File.Delete(path + "DiFiles\\" + TourName + "\\offtdata.dat");
                }

                using (FileStream objStream = new FileStream(path + "DiFiles\\" + TourName + "\\offtdata.dat", FileMode.Create, FileAccess.Write))
                {
                    byte[] Arr1 = { 0x2E, 0x01, 0x00, 0x00 };
                    objStream.Write(Arr1, 0, Arr1.Length);
                }

                if (File.Exists(path + "DiFiles\\" + TourName + "\\note.dat"))
                {
                    File.Delete(path + "DiFiles\\" + TourName + "\\note.dat");
                }
                using (FileStream objStream = new FileStream(path + "DiFiles\\" + TourName + "\\note.dat", FileMode.Create, FileAccess.Write))
                {
                    byte[] Arr1 = { 0x2E, 0x01, 0x00, 0x00 };
                    objStream.Write(Arr1, 0, Arr1.Length);
                }
            }
            catch { }
        }

        int TotalRoutes = 0;
        private void UploadRootsDup(string Fac, string FacDis, string Equi, string EquiDis, string Comp, string CompDis, string Sub, string SubDis, string target, bool same, double[] Alarms)
        {
            float Alarm1 = 0;
            float Alarm2 = 0;
            float Alarm3 = 0;
            string sAlarm2 = null;
            string sAlarm3 = null;
            double[] FactorUMMS = { 500, 250, 125, 50, 25, 12.5, 5, 2.5 };
            double[] FactorUMIL = { 100, 50, 20, 10, 5, 2 };
            double[] FactorG = { 100, 50, 20, 10, 5, 2, 1, .5, .2, .1 };
            double[] FactorUM = { 2500, 1250, 500, 250, 125, 50 };
            double[] FactorIPS = { 20, 10, 5, 2, 1, .5, .2, .1 };
            double[] FactorV = { 10, 5, 2, 1, .5, .2, .1, .05, .02, .01 };
            double[] FactorRPM = { 100000, 50000, 10000, 5000, 1000, 500, 100, 50, 10, 5 };
            double[] FactorOther = { 100000, 10000, 1000, 100, 10, 1, .1, .01, .001 };
            string[] Points = target.Split(new string[] { "," }, StringSplitOptions.None);
            int PointCounter = 0;
            string[] Information = null;
            StringBuilder DataOfAllThePoints = new StringBuilder();
            int AlrCtr = 0;
            try
            {
                do
                {
                    Information = Points[PointCounter].Split(new string[] { "!!", "@", "#", "$", "%", "^", "&", "*", "+", "=", "<", ">", "?", "{", "}", "~", "`", "[", "]", ":", ";" }, StringSplitOptions.None);//Splitting The Whole Information For Extracting User Selected Values
                    Alarm1 = (float)Alarms[AlrCtr];
                    AlrCtr++;
                    Alarm2 = (float)Alarms[AlrCtr];
                    AlrCtr++;
                    Alarm3 = (float)Alarms[AlrCtr];
                    AlrCtr++;
                    int couple = Convert.ToInt16(Information[5]);//Extracting The Value Of Couple Selected by the user
                    couple = couple * 16;//Calculating value of couple to be send according to the value selected by the user
                    int DetectionType = Convert.ToInt16(Information[6]);//Extracting the value Of Detection Type Selected by the user
                    int Window = Convert.ToInt16(Information[7]);//Extracting The Value of Window type selected by the user
                    int Collection = Convert.ToInt16(Information[11]);//Extracting the value of Collection Type Selected by the user
                    int Frequency = Convert.ToInt16(Information[14]);//Extracting the value of frequency selected by the user
                    int Overlap = Convert.ToInt16(Information[16]);//Extracting the value of overlap selected by the user
                    int Trigger = Convert.ToInt16(Information[17]);//Extracting the value of trigger selected by the user
                    Trigger = Trigger * 2;//Calculating the value of trigger to be send according to the value selected by the user
                    int Slope = Convert.ToInt16(Information[18]);//Extracting the value of slope type selected by the user
                    int TriggerRange = Convert.ToInt16(Information[20]);//Extracting the value of trigger range selected by the user
                    TriggerRange = TriggerRange * 64;//Calculating the value if trigger range to be send according to the value selected by the user
                    int Channel = Convert.ToInt16(Information[21]);//Extracting the value of channel type choosen by the user
                    int fullScale = Convert.ToInt16(Information[3]);
                    int FullScaleFinalVal = Convert.ToInt16(Information[3]);
                    int Filter = Convert.ToInt16(Information[9]);//Extracting the value of Filter Used by the user
                    int FilterType = Convert.ToInt16(Information[8]);
                    int MainValue = 0;
                    int senstivity = Convert.ToInt32(Information[4]);
                    int senstivityCount = senstivity.ToString().Length;
                    int Unit = Convert.ToInt16(Information[2]);//Extracting the value of Unit selected by the user
                    byte ValForSub = 0;
                    double MultiPlicationFacTorForAlarm = 0;
                    double MulFacSec = 0;
                    byte[] FirstToSendAlarm = new byte[2];
                    byte[] SecondToSendAlarm = new byte[2];
                    fullScale = Convert.ToInt16(Information[3]);//Extracting The Infoprmation Of Full Scale Selected by the user
                    if (Unit == 2 || Unit == 6)
                    {
                        MultiPlicationFacTorForAlarm = .0000763;//Extracting key factor in case if alarm According To Unit
                        MulFacSec = FactorUMMS[fullScale];//Extracting Another Key Factor For Sending With Alarm Values
                    }
                    else if (Unit == 1 || Unit == 5)
                    {
                        MultiPlicationFacTorForAlarm = .00000305;//Extracting Key Factor In Case Of Alarm According To Unit
                        MulFacSec = FactorIPS[fullScale];//Extracting Another Key Factor For Sending With alarm According To Unit
                    }
                    else if (Unit == 3 || Unit == 7 || Unit == 9)
                    {
                        MultiPlicationFacTorForAlarm = .0000610;//Extracting key Factor In case of alarm According to Unit
                        MulFacSec = FactorUMIL[fullScale];//Extracting Another Key Factor For Sending With Alarm According to Unit
                    }
                    else if (Unit == 4 || Unit == 8 || Unit == 10)
                    {
                        MultiPlicationFacTorForAlarm = .001533;//Extracting Key factor in case of Alarm according to Unit
                        MulFacSec = FactorUM[fullScale];//Extracting Key factor For Sending With Alarm According To Unit
                    }
                    else if (Unit == 0 || Unit == 11)
                    {
                        MulFacSec = FactorG[fullScale];//Extracting Key Factor for sending wioth alarm according to unit                       
                    }
                    else if (Unit == 12)
                    {
                        MulFacSec = FactorV[fullScale];
                    }
                    else if (Unit == 13)
                    {
                        MulFacSec = FactorRPM[fullScale];
                    }
                    else
                    {
                        MulFacSec = FactorOther[fullScale];
                    }
                    if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))//Checking Alarm Values Not To Be null
                    {
                    }
                    else
                    {
                        try
                        {
                            double tt = Convert.ToDouble(Alarm2);
                            sAlarm2 = DeciamlToHexadeciaml(Convert.ToInt32(Convert.ToDouble(Alarm2 * 32767) / MulFacSec));//Calculating the alarm value to be send and converting it into Hexadecimal value
                            string[] AlSep = sAlarm2.Split(new string[] { "," }, StringSplitOptions.None);//Splitting its value for getting single bit
                            string Final1 = null;
                            string Final2 = null;
                            for (int i = AlSep.Length - 2; i <= AlSep.Length - 1; i++)
                            {
                                Final1 += AlSep[i];
                            }
                            for (int i = 0; i < AlSep.Length - 2; i++)
                            {
                                Final2 += AlSep[i];
                            }
                            try
                            {
                                FirstToSendAlarm[0] = Convert.ToByte(HexadecimaltoDecimal(Final1));
                            }
                            catch
                            {
                                FirstToSendAlarm[0] = Convert.ToByte(HexadecimaltoDecimal("FF"));
                            }
                            try
                            {
                                if (Final2 != null)
                                {
                                    FirstToSendAlarm[1] = Convert.ToByte(HexadecimaltoDecimal(Final2));
                                }
                            }
                            catch
                            {
                                if (Final2 != null)
                                {
                                    FirstToSendAlarm[1] = Convert.ToByte(HexadecimaltoDecimal("FF"));
                                }
                            }
                            sAlarm3 = DeciamlToHexadeciaml(Convert.ToInt32(Convert.ToDouble(Alarm3 * 32767) / MulFacSec));//Calculating the alarm value to be send and converting it into Hexadecimal value
                            AlSep = sAlarm3.Split(new string[] { "," }, StringSplitOptions.None);//Splitting its value for getting single bit
                            Final1 = null;
                            Final2 = null;
                            for (int i = AlSep.Length - 2; i <= AlSep.Length - 1; i++)
                            {
                                Final1 += AlSep[i];
                            }
                            for (int i = 0; i < AlSep.Length - 2; i++)
                            {
                                Final2 += AlSep[i];
                            }
                            try
                            {
                                SecondToSendAlarm[0] = Convert.ToByte(HexadecimaltoDecimal(Final1));
                            }
                            catch
                            {
                                SecondToSendAlarm[0] = Convert.ToByte(HexadecimaltoDecimal("FF"));
                            }
                            try
                            {
                                if (Final2 != null)
                                    SecondToSendAlarm[1] = Convert.ToByte(HexadecimaltoDecimal(Final2));
                            }
                            catch
                            {
                                if (Final2 != null)
                                    SecondToSendAlarm[1] = Convert.ToByte(HexadecimaltoDecimal("FF"));
                            }
                        }
                        catch
                        {
                        }
                    }
                    int Measure = Convert.ToInt16(Information[12]);//Extracting the value of measure type selected by the user
                    byte Order = Convert.ToByte(Information[15]);//Extracting the value of Order selected by the user
                    Order = Convert.ToByte(Order + 1);//Calculating the Value of Order To be send According To the selected value
                    byte LinesOfResolutin = Convert.ToByte(Information[13]);//Extracting the value Lines of resolution selected by the user
                    //ResArray[ResArray.Length - 1] = Convert.ToInt32(LinesOfResolutin);
                    int BytesTotal = 0;
                    byte[] facilityName = System.Text.Encoding.ASCII.GetBytes(Fac);//Extracting factory name and converting its ASCII codes to there byte equivalent

                    int FacilityNameTotal = SumOfByteArray(facilityName);//Calculation there sum for calculating end key of the name

                    byte[] facilityDescription = System.Text.Encoding.ASCII.GetBytes(FacDis);//Converting Factory descryption to byte array
                    int FacilityDescTotal = SumOfByteArray(facilityDescription);//Calculating There Sum For Calculating End Key Of the Name

                    byte[] equipmentName = System.Text.Encoding.ASCII.GetBytes(Equi);//Converting Equipment Name to byte array
                    string DataToSend88 = Equi;
                    byte ForData88 = Convert.ToByte(0x35 - (equipmentName.Length));//Calculating end byte of equipment name
                    int equipmentNameTotal = SumOfByteArray(equipmentName);//Calculating the sum for finding end key

                    byte[] RouteNameBytes = System.Text.Encoding.ASCII.GetBytes(Fac);                  //Factory Name
                    string RouteName = Fac;
                    int RouteNameTotal = SumOfByteArray(RouteNameBytes);

                    byte[] equipmentDescription = System.Text.Encoding.ASCII.GetBytes(EquiDis);

                    int equipmeneDescTotal = SumOfByteArray(equipmentDescription);

                    byte[] componentName = System.Text.Encoding.ASCII.GetBytes(Comp);//Converting Component name to byte array
                    string DataToSend4 = Comp;
                    byte ForData4 = Convert.ToByte(0x11 - (componentName.Length));//Finding its end key
                    int componentNameTotal = SumOfByteArray(componentName);//Calculating the sum For finding End Key

                    byte[] componentDescription = System.Text.Encoding.ASCII.GetBytes(CompDis);//Converting Component Description To byte Array
                    int componentdescTotal = SumOfByteArray(componentDescription);//Calculating Its Sum For Finding Key

                    byte[] subcomponentName = System.Text.Encoding.ASCII.GetBytes(Sub);//Converting Sub COmponent name to byte array
                    string DataToSend6 = Sub;
                    byte ForData6 = Convert.ToByte(0x11 - (subcomponentName.Length));//Calculating Its Key to send
                    int subcomponentNameTotal = SumOfByteArray(subcomponentName);//Calculating Its End Key


                    byte[] subcomponentDescription = System.Text.Encoding.ASCII.GetBytes(SubDis);//Converting Sub COmponent Descryption to byte array
                    int subcomponentdescTotal = SumOfByteArray(subcomponentDescription);//Calculating its key to send
                    string[] ptName = Information[0].Split(new string[] { "|" }, StringSplitOptions.None);//Extracting Point Names
                    byte[] PointName = System.Text.Encoding.ASCII.GetBytes(ptName[0]);//Converting Point Name To byte array
                    string DataToSend5 = ptName[0];
                    byte ForData5 = Convert.ToByte(0x11 - (PointName.Length));//Claculating its key
                    int PointNameTotal = SumOfByteArray(PointName);//Calculating its End Key



                    byte[] PointDesc = System.Text.Encoding.ASCII.GetBytes(ptName[1]);//Converting point descryption to byte array
                    string DataToSend7 = ptName[1];
                    if (Information[3] == "0")
                        Information[3] = "1";
                    fullScale = Convert.ToInt16(Information[3]);
                    if (fullScale == 0 && Unit != 2 && Unit != 4 && Unit != 6 && Unit != 8 && Unit != 10)
                        ValForSub = 0x27;
                    else
                        ValForSub = 0x26;

                    byte ForData7 = Convert.ToByte(ValForSub - (PointDesc.Length));
                    int PointDescTotal = SumOfByteArray(PointDesc);
                    byte DataToSend8 = Convert.ToByte(fullScale);
                    if (Unit == 0 || Unit == 11)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 217;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x29;
                        else
                            ValForSub = 0x26;
                    }
                    if (Unit == 1)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 218;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else
                            ValForSub = 0x26;
                    }
                    if (Unit == 2)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 234;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else
                            ValForSub = 0x26;
                    }
                    if (Unit == 3)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 220;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else
                            ValForSub = 0x26;
                    }
                    if (Unit == 4)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 240;
                        if (fullScale <= 4)
                            FullScaleFinalVal = fullScale - 4;
                        else if (fullScale > 4)
                            FullScaleFinalVal = -4;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else
                            ValForSub = 0x26;
                    }
                    if (Unit == 5)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 219;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else
                            ValForSub = 0x26;
                    }
                    if (Unit == 6)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 235;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else
                            ValForSub = 0x26;
                    }
                    if (Unit == 7)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 221;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else
                            ValForSub = 0x26;
                    }
                    if (Unit == 8)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 241;
                        if (fullScale <= 4)
                            FullScaleFinalVal = fullScale - 4;
                        else if (fullScale > 4)
                            FullScaleFinalVal = -4;

                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else
                            ValForSub = 0x26;
                    }
                    if (Unit == 9)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 351;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else
                            ValForSub = 0x26;
                    }
                    if (Unit == 10)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 371;
                        if (fullScale <= 4)
                            FullScaleFinalVal = fullScale - 4;
                        else if (fullScale > 4)
                            FullScaleFinalVal = -4;

                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else
                            ValForSub = 0x26;
                    }
                    if (Unit == 12 || Unit > 12)
                    {
                        fullScale = Convert.ToInt16(Information[3]);
                        MainValue = 351;
                        FullScaleFinalVal = fullScale;
                        if (fullScale == 0)
                            ValForSub = 0x27;
                        else
                            ValForSub = 0x26;
                    }
                    byte[] unitCode = new byte[1];
                    if (Unit == 1 || Unit == 2)
                        unitCode[0] = Convert.ToByte(0x01);
                    else if (Unit == 3 || Unit == 4)
                        unitCode[0] = Convert.ToByte(0x03);
                    else if (Unit == 5 || Unit == 6)
                        unitCode[0] = Convert.ToByte(0x02);
                    else if (Unit == 7 || Unit == 8)
                        unitCode[0] = Convert.ToByte(0x04);
                    else if (Unit == 9 || Unit == 10)
                        unitCode[0] = Convert.ToByte(0x05);
                    else if (Unit == 0)
                        unitCode[0] = Convert.ToByte(0x00);
                    else if (Unit == 11)
                        unitCode[0] = Convert.ToByte(0x09);
                    else if (Unit == 12)
                        unitCode[0] = Convert.ToByte(0x06);
                    else if (Unit == 13)
                        unitCode[0] = Convert.ToByte(0x08);
                    else if (Unit == 14)
                        unitCode[0] = Convert.ToByte(0x10);
                    else if (Unit == 15)
                        unitCode[0] = Convert.ToByte(0x11);
                    else if (Unit == 16)
                        unitCode[0] = Convert.ToByte(0x12);
                    else if (Unit == 17)
                        unitCode[0] = Convert.ToByte(0x13);
                    else if (Unit == 18)
                        unitCode[0] = Convert.ToByte(0x14);
                    else if (Unit == 19)
                        unitCode[0] = Convert.ToByte(0x15);
                    else if (Unit == 20)
                        unitCode[0] = Convert.ToByte(0x16);
                    else if (Unit == 21)
                        unitCode[0] = Convert.ToByte(0x17);
                    else if (Unit == 22)
                        unitCode[0] = Convert.ToByte(0x18);
                    else if (Unit == 23)
                        unitCode[0] = Convert.ToByte(0x19);
                    else if (Unit == 24)
                        unitCode[0] = Convert.ToByte(0x20);
                    else if (Unit == 25)
                        unitCode[0] = Convert.ToByte(0x21);
                    else if (Unit == 26)
                        unitCode[0] = Convert.ToByte(0x22);
                    else if (Unit == 27)
                        unitCode[0] = Convert.ToByte(0x23);

                    byte ZeroFullScale = 0;
                    if (Unit == 0 || Unit == 1 || Unit == 3 || Unit == 5 || Unit == 7 || Unit == 9 || Unit == 11 || Unit == 12 || Unit > 12)
                    {
                        if (fullScale == 0)
                            ZeroFullScale = 0;
                        else if (fullScale > 0)
                            ZeroFullScale = Convert.ToByte(0 + fullScale);
                    }
                    if (Unit == 2 || Unit == 4 || Unit == 6 || Unit == 8 || Unit == 10)
                    {
                        if (fullScale == 0)
                            ZeroFullScale = 0x10;
                        else if (fullScale > 0)
                            ZeroFullScale = Convert.ToByte(0x10 + fullScale);
                    }
                    byte AfterUnitCode = 0x00;
                    byte AfterUnitCode1 = 0x00;
                    int FilterVal = Convert.ToInt16(Information[9]);
                    byte[] BeforeFF = new byte[2];
                    bool Excep = true;
                    if (Filter == 2)
                    {
                        if (FilterVal == 0)
                        {
                            AfterUnitCode1 = 0x08;
                        }
                        else if (FilterVal == 1)
                        {
                            AfterUnitCode = 0x80;
                            AfterUnitCode1 = 0x08;
                        }
                        else if (FilterVal == 2)
                        {
                            AfterUnitCode = 0x00;
                            AfterUnitCode1 = 0x09;
                        }
                        BeforeFF[0] = Convert.ToByte(Measure);
                        BeforeFF[1] = 0x00;
                    }
                    else if (Filter == 1)
                    {
                        if (FilterVal >= 0 && FilterVal <= 3)
                        {
                            AfterUnitCode1 = 0x04;
                        }
                        else if (FilterVal == 4)
                        {
                            AfterUnitCode = 0x80;
                            AfterUnitCode1 = 0x04;
                        }
                        else if (FilterVal == 5)
                        {
                            AfterUnitCode = 0x00;
                            AfterUnitCode1 = 0x05;
                        }
                        else if (FilterVal == 6)
                        {
                            AfterUnitCode = 0x80;
                            AfterUnitCode1 = 0x05;
                        }
                        else if (FilterVal == 7)
                        {
                            AfterUnitCode = 0x00;
                            AfterUnitCode1 = 0x06;
                        }
                        BeforeFF[0] = Convert.ToByte(Measure);
                        BeforeFF[1] = 0x00;
                    }

                    else if (Filter == 3)
                    {
                        if (FilterVal >= 0 && FilterVal <= 3)
                        {
                            AfterUnitCode1 = 0x0c;
                        }
                        else if (FilterVal == 4)
                        {
                            AfterUnitCode = 0x80;
                            AfterUnitCode1 = 0x0c;
                        }
                        else if (FilterVal == 5)
                        {
                            AfterUnitCode = 0x00;
                            AfterUnitCode1 = 0x0d;
                        }
                        else if (FilterVal == 6)
                        {
                            AfterUnitCode = 0x80;
                            AfterUnitCode1 = 0x0d;
                        }
                        else if (FilterVal == 7)
                        {
                            AfterUnitCode = 0x00;
                            AfterUnitCode1 = 0x0e;
                        }
                        BeforeFF[0] = Convert.ToByte(Measure);
                        BeforeFF[1] = 0x00;
                    }
                    else if (Filter == 0 && Measure == 0)
                    {
                        BeforeFF[0] = 0x1b;
                        BeforeFF[1] = 0x04;
                        if (Unit == 0)
                            BeforeFF[1]++;
                    }
                    else if (Filter == 0 && Measure > 0)
                    {
                        BeforeFF[0] = Convert.ToByte(Measure);
                        BeforeFF[1] = 0x00;
                        AfterUnitCode1 = 0x00;
                        Excep = false;
                    }

                    if (TriggerRange > 0)
                    {
                        AfterUnitCode = Convert.ToByte(TriggerRange + AfterUnitCode);
                        BeforeFF[1] = 0x03;
                    }
                    if (Trigger > 0)
                    {
                        AfterUnitCode = Convert.ToByte(Trigger + AfterUnitCode);
                        BeforeFF[1] = 0x03;
                    }
                    if (couple > 0)
                    {
                        BeforeFF[1] = 0x03;
                        AfterUnitCode = Convert.ToByte(AfterUnitCode + couple);
                    }

                    byte[] DetctionInformationToSend = new byte[5];

                    if (DetectionType > 0)
                    {
                        DetctionInformationToSend[0] = 0x1b;
                        DetctionInformationToSend[1] = 0x03;
                        DetctionInformationToSend[2] = Convert.ToByte(DetectionType);
                        DetctionInformationToSend[3] = 0x1b;
                        DetctionInformationToSend[4] = 0x08;
                    }

                    byte ToSendAfterOrder = Convert.ToByte(Collection);

                    SensitivityFunction(Convert.ToInt32(Information[4]));

                    byte sensPrev = Convert.ToByte(senstivityPrev);
                    byte sensval = Convert.ToByte(sensitivityvalue);
                    byte sensnext = Convert.ToByte(sensitivitynext);

                    byte[] SensitivityToSend = new byte[0];
                    if (senstivityPrev != 0)
                    {
                        Array.Resize(ref SensitivityToSend, SensitivityToSend.Length + 1);
                        SensitivityToSend[SensitivityToSend.Length - 1] = sensPrev;
                    }
                    Array.Resize(ref SensitivityToSend, SensitivityToSend.Length + 1);
                    SensitivityToSend[SensitivityToSend.Length - 1] = sensval;
                    Array.Resize(ref SensitivityToSend, SensitivityToSend.Length + 1);
                    SensitivityToSend[SensitivityToSend.Length - 1] = sensnext;

                    byte[] ConsTantToSend = SensitivityToSend;

                    byte[] ConsTantToSend1 = { 0x1B, 0x03, 0x32, 0x73, 0x1B, 0x11 };
                    byte[] ConsTantToSend11 = { 0x1B, 0x03, 0x5a, 0x1B, 0x12 };
                    string zero = "\x00";
                    byte[] WindowNotZero = new byte[3];
                    byte[] WindowZero = new byte[2];
                    byte[] LinesFourHund = new byte[2];

                    if (Filter == 0)
                    {
                        FilterType = -8;
                    }
                    if (Filter == 1)
                    {
                        FilterType = -4;
                    }
                    if (Filter == 3)
                    {
                        FilterType = 4;
                    }
                    int filterFreq = 0;
                    if (Filter == 2 && Convert.ToInt16(Information[9]) == 1)
                    {
                        filterFreq = -127;
                    }
                    if (Filter == 2 && Convert.ToInt16(Information[9]) == 2)
                    {
                        filterFreq = 1;
                    }

                    if (Filter == 1 || Filter == 3)
                    {
                        if (Convert.ToInt16(Information[9]) == 4)
                        {
                            filterFreq = -127;
                        }
                        else if (Convert.ToInt16(Information[9]) == 5)
                        {
                            filterFreq = 1;
                        }
                        else if (Convert.ToInt16(Information[9]) == 6)
                        {
                            filterFreq = -126;
                        }
                        else if (Convert.ToInt16(Information[9]) == 7)
                        {
                            filterFreq = 2;
                        }
                    }
                    int MeasureType = 0;
                    int FreqVal = 0;
                    int FreqValSelect = 0;
                    if (Measure == 1 || Measure == 2)
                    {
                        MeasureType = 1;
                    }
                    if (Measure == 0 || Measure == 1)
                    {
                        FreqVal = Convert.ToInt16(Information[13]);
                        if (FreqVal < 3)
                        {
                            if (FreqVal == 0)
                                FreqValSelect = -2;
                            else if (FreqVal == 1)
                                FreqValSelect = -1;
                            else if (FreqVal == 2)
                                FreqValSelect = -3;

                        }
                        else if (FreqVal > 3)
                        {
                            FreqValSelect = FreqVal - 3;
                        }
                    }
                    if (Measure == 2 || Measure == 3)
                    {
                        if (FreqVal != 2)
                        {
                            if (FreqVal == 1)
                                FreqValSelect = 1;
                            else if (FreqVal > 2)
                                FreqValSelect = FreqVal - 1;
                        }
                    }
                    BytesTotal = MainValue + equipmentNameTotal + componentNameTotal + subcomponentNameTotal + PointNameTotal + PointDescTotal + couple + DetectionType + Window + Collection + Frequency + Trigger + Slope + TriggerRange + Channel + FullScaleFinalVal + FilterType + filterFreq + MeasureType + FreqValSelect + Overlap + 2;
                    byte FirstByte = 0;
                    byte SecondByte = 0x00;
                    if (BytesTotal >= 256)
                    {
                        do
                        {
                            BytesTotal = BytesTotal - 256;
                            SecondByte++;
                        } while (BytesTotal >= 256);
                        FirstByte = Convert.ToByte(BytesTotal);
                    }
                    else if (BytesTotal < 256)
                    {
                        FirstByte = Convert.ToByte(BytesTotal);
                    }
                    if (FirstByte == 0x1b)
                        FirstByte++;

                    byte[] FirstQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x52, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x36, 0x36 };
                    byte[] ThirdQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x4D, 0x44, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] FourthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] FourthQuestionEnd = { 0x5C, 0x74, 0x6F, 0x75, 0x72, 0x64, 0x61, 0x74, 0x61, 0x2E, 0x64, 0x61, 0x74, 0x03 };
                    byte[] FifthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] FifthQuestionEnd = { 0x5C, 0x74, 0x6F, 0x75, 0x72, 0x69, 0x6E, 0x66, 0x6F, 0x2E, 0x64, 0x61, 0x74, 0x03 };

                    byte[] SixthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] SixthQuestionEnd = { 0x5C, 0x63, 0x74, 0x72, 0x6C, 0x2E, 0x63, 0x66, 0x67, 0x03 };

                    byte[] EightQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] EightQuestionEnd = { 0x5C, 0x6E, 0x6F, 0x74, 0x65, 0x2E, 0x64, 0x61, 0x74, 0x03 };

                    byte[] NinthQuestion = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x30, 0x34, 0x2E, 0x01, 0x00, 0x00, 0x03, 0x35, 0x36 };

                    byte[] TenthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                    byte[] TenthQuestionEnd = { 0x5C, 0x6F, 0x66, 0x66, 0x74, 0x64, 0x61, 0x74, 0x61, 0x2E, 0x64, 0x61, 0x74, 0x03 };

                    byte[] EleventhQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x44, 0x45, 0x4C, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x32, 0x33 };
                    byte[] TwelevthQuestion = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x36, 0x38 };
                    byte[] ThirteenthQuestion = { 0x01, 0x30, 0x32, 0x37, 0x46, 0x02, 0x30, 0x30, 0x36, 0x31, 0x00, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x94, 0x2A, 0xE4, 0x8F, 0xCC, 0xF6, 0x43, 0x8C, 0xA8, 0xF8, 0xFF, 0x01, 0x00, 0xC8, 0xFF, 0xFF, 0x20, 0x1B, 0x05 };
                    byte[] ThirteenthQuestionEnd = { 0x1B, 0x03, 0x08, 0x00, 0x0B, 0x1B, 0x08, 0x07, 0x00, 0x50, 0x39, 0xF8, 0x03, 0x1B, 0x04, 0x10, 0x1B, 0x04, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x06, 0x1B, 0x03, 0x70, 0xD4, 0x0C, 0x00, 0x98, 0x72, 0x8E, 0x01, 0x24, 0xF5, 0x10, 0x0E, 0x84, 0xF5, 0x10, 0x0E, 0x60, 0x8E, 0x01, 0xCC, 0xF4, 0x10, 0x0E, 0x30, 0xDE, 0x8A, 0x01, 0x0B, 0x00, 0xFF, 0x01, 0xDC, 0xF6, 0x10, 0x0E, 0x00, 0x00, 0x10, 0x0E, 0x1B, 0x17, 0x03 };

                    byte[] DateQues = { 0x06, 0x01, 0x30, 0x30, 0x34, 0x41, 0x02 };
                    byte[] DateQuesEnd = { 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x03 };
                    byte[] DateEnd = new byte[2];
                    byte[] testArr = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x35, 0x44, 0x2E, 0x01, 0x00, 0x00, 0x58, 0x02, 0x06, 0x01, 0xae, 0x07, 0x1B, 0x04, 0x02, 0x1B, 0x04, 0x4D, 0x68, 0x6C, 0x1B, 0x0E, 0x4D, 0x68, 0x6C, 0x31, 0x1B, 0x0D, 0x4D, 0x4F, 0x54, 0x4F, 0x52, 0x1B, 0x0C, 0x4D, 0x4F, 0x54, 0x4F, 0x52, 0x31, 0x1B, 0x26, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x1B, 0x03, 0x01, 0x1B, 0x08, 0x01, 0x1B, 0x0C, 0xC8, 0x42, 0x08, 0x00, 0x01, 0x1B, 0x03, 0x03, 0x04, 0x1B, 0x03, 0x32, 0x73, 0x1B, 0x11, 0x4D, 0x31, 0x32, 0x33, 0x1B, 0x31, 0x0A, 0x1B, 0x1E, 0x03, 0x00, 0x32, 0x01, 0x1B, 0x05, 0x33, 0x01, 0x24, 0x03, 0x1B, 0xF4, 0x00, 0x00, 0x03 };
                    byte[] TestArr1 = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x36, 0x35, 0x2E, 0x01, 0x00, 0x00, 0x58, 0x02, 0x06, 0x01, 0xae, 0x07, 0x1B, 0x04, 0x02, 0x1B, 0x04 };
                    byte[] TestArr2 = { 0x1b, 0x0e };
                    byte[] TestArr3 = { 0x1b, 0x0d };
                    byte[] TestArr4 = { 0x1b, 0x0c };
                    byte[] TestArr5 = { 0x1b, 0x20 };

                    byte[] TestArr6 = { 0x03, 0x00, 0x00, 0x08, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x1B, 0x03, 0x01, 0x1B, 0x08, 0x01, 0x1B, 0x0C, 0xC8, 0x42, 0x08, 0x00, 0x01, 0x03, 0x00, 0x00, 0x03, 0x04, 0x1B, 0x03, 0x32, 0x73, 0x1B, 0x11 };
                    byte[] TestArr7 = { 0x1b, 0x22 };
                    byte[] TestArr8 = { 0x0A, 0x1B, 0x1E, 0x03, 0x00, 0x32, 0x01, 0x1B, 0x05, 0x33, 0x01, 0x44, 0x06, 0x1B, 0xF6, 0x00, 0x00, 0x03 };
                    byte[] Start = { 0x01, 0x30, 0x30, 0x31, 0x36, 0x02, 0x03, 0x34, 0x43 };
                    byte[] DataBase = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x30, 0x45, 0x1B, 0x04, 0x08, 0x45, 0x3A, 0x5C, 0x74, 0x65, 0x73, 0x74, 0x5C, 0x01, 0x1B, 0x03, 0x03, 0x37, 0x35 };

                    byte[] RouteTestName = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x31, 0x36, 0x2E, 0x01, 0x00, 0x00, 0x2F, 0x01, 0x23, 0x00, 0x68, 0x00, 0x61, 0x1B, 0x10, 0x04, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x1B, 0x09, 0x03, 0x34, 0x42 };
                    byte[] TestDate = { 0x06, 0x01, 0x30, 0x30, 0x34, 0x41, 0x02, 0x30, 0x42, 0x1F, 0x32, 0x31, 0x1F, 0x30, 0x43, 0x1F, 0x30, 0x42, 0x1F, 0x30, 0x41, 0x1F, 0x36, 0x42, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x03, 0x37, 0x35 };

                    byte[] RouteNameToSend1 = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30 };
                    byte[] RouteNameToSend21 = new byte[1];
                    byte[] RouteNameToSend22 = new byte[1];
                    byte[] RouteNameToSend3 = { 0x2E, 0x01, 0x00, 0x00, 0x2F, 0x01, 0x23, 0x00 };
                    byte[] RouteNameToSend4 = { 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x1B, 0x09, 0x03 };
                    byte[] StartDataToSend1 = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02 };
                    byte[] StartDataToSend2 = { 0x2E, 0x01, 0x00, 0x00 };
                    byte[] StartDataToSend22 = { 0x58, 0x02, 0x06, 0x01 };
                    byte[] StartDataToSend3b = { 0x1B, 0x04 };
                    byte[] StartDataToSend3 = { 0x1B, 0x04, 0x02, 0x1b, 0x04 };
                    byte[] StartDataToSend3l = { 0x1B, 0x04 };
                    byte[] StartDataToSend3ForDualChannel = { 0x1B, 0x04 };
                    byte[] StartDataToSend3ForDualChannelAndCounter0 = { 0x1B, 0x03, 0x20 };
                    byte[] StartDataToSend3ForDualChannelAndCounter1 = { 0x00, 0x00, 0x01, 0x20 };
                    byte[] ThirdQuestionEnd = new byte[2];
                    byte[] FourthLastByte = new byte[2];
                    byte ThirdEnd1 = 0x35;
                    byte ThirdEnd2 = 0x32;
                    byte FourthEnd1 = 0x30;
                    byte FourthEnd2 = 0x31;
                    byte FifthEnd1 = 0x31;
                    byte FifthEnd2 = 0x33;
                    byte[] FifthLastByte = new byte[2];
                    byte SixthEnd1 = 0x34;
                    byte SixthEnd2 = 0x39;
                    byte[] SixthLastByte = new byte[2];
                    byte EightEnd1 = 0x35;
                    byte EightEnd2 = 0x33;
                    byte[] EightLastByte = new byte[2];
                    byte TenthEnd1 = 0x36;
                    byte TenthEnd2 = 0x36;
                    byte[] TenthLastByte = new byte[2];
                    byte LastMiddleByte = 2;
                    byte[] LastMiddleFinal = new byte[1];
                    byte ThirteenEnd1 = 0x33;
                    byte ThirteenEnd2 = 0x43;
                    byte[] ThirteenLastByte = new byte[2];
                    byte[] Tour = new byte[1];
                    byte[] Tour1 = new byte[1];
                    byte[] TourSingle = new byte[1];
                    int RouteToSend = TotalRoutes + 1;
                    RouteNameTotal = RouteNameTotal + RouteToSend + 3;
                    byte[] RouteNameMiddleBytes = new byte[2];
                    RouteNameMiddleBytes[1] = 0x00;

                    int bytesReadSending = 0;
                    if (RouteNameBytes.Length >= 1)
                    {
                        bytesReadSending = RouteNameBytes.Length;
                        bytesReadSending = bytesReadSending + 21;
                        string noOfBytes = DeciamlToHexadeciaml(bytesReadSending);
                        string[] noOfbytesTosend = null;

                        noOfbytesTosend = noOfBytes.Split(new string[] { "," }, StringSplitOptions.None);
                        RouteNameToSend21 = Encoding.ASCII.GetBytes(noOfbytesTosend[0]);
                        RouteNameToSend22 = Encoding.ASCII.GetBytes(noOfbytesTosend[1]);
                    }
                    while (RouteNameTotal >= 256)
                    {
                        if (RouteNameTotal >= 256)
                            RouteNameTotal = RouteNameTotal - 256;
                        RouteNameMiddleBytes[1]++;
                    }
                    RouteNameMiddleBytes[0] = Convert.ToByte(RouteNameTotal);
                    int lastByteTotal = 0;
                    lastByteTotal = (RouteNameMiddleBytes[0] + 1) * 2;
                    int MonitorForByte = 0;
                    int MonitorForByte1 = 0;
                    int addingBytes = 0;
                    if (RouteNameMiddleBytes[1] == 1)
                    {
                        while (lastByteTotal > 128)
                        {
                            if (lastByteTotal > 256)
                            {
                                lastByteTotal = lastByteTotal - 256;
                                MonitorForByte = 256;
                            }
                            else if (lastByteTotal > 128)
                            {
                                lastByteTotal = lastByteTotal - 128;
                                MonitorForByte1 = 128;
                            }
                        }
                        if (MonitorForByte == 256 && MonitorForByte1 == 128)
                            lastByteTotal = lastByteTotal + 1;

                        else if (MonitorForByte == 256)
                            lastByteTotal = lastByteTotal + 1;
                        else if (MonitorForByte1 == 128)
                            lastByteTotal = lastByteTotal + 1;
                        else
                            lastByteTotal = lastByteTotal - 6;
                    }
                    else if (RouteNameMiddleBytes[1] >= 2)
                    {
                        addingBytes = RouteNameMiddleBytes[1];
                        while (lastByteTotal > 128)
                        {
                            lastByteTotal = lastByteTotal - 128;

                        }
                        lastByteTotal = lastByteTotal + addingBytes;
                    }
                    else if (RouteNameMiddleBytes[1] == 0)
                    {
                        while (lastByteTotal > 128)
                        {
                            lastByteTotal = lastByteTotal - 128;
                        }
                        lastByteTotal = lastByteTotal;
                    }
                    byte[] AfterRouteName = new byte[1];

                    AfterRouteName[0] = Convert.ToByte(0x11 - RouteNameBytes.Length);
                    int lastByteHexTotal = 0;
                    byte[] RouteNumberForRouteName = new byte[1];
                    RouteNumberForRouteName[0] = Convert.ToByte(RouteToSend);
                    if (lastByteTotal > 10)
                        lastByteHexTotal = lastByteTotal - 10;
                    else if (lastByteTotal > 8)
                        lastByteHexTotal = lastByteTotal - 8;
                    else if (lastByteTotal > 6)
                        lastByteHexTotal = lastByteTotal - 6;
                    else if (lastByteTotal > 4)
                        lastByteHexTotal = lastByteTotal - 4;
                    else if (lastByteTotal > 2)
                        lastByteHexTotal = lastByteTotal - 2;

                    string LastbytesString = DeciamlToHexadeciaml(lastByteHexTotal);
                    string[] LastBytesArrForRoute = null;
                    LastBytesArrForRoute = LastbytesString.Split(new string[] { "," }, StringSplitOptions.None);
                    byte[] LastByteArrForRouteName1 = new byte[1];
                    byte[] LastByteArrForRouteName2 = new byte[1];
                    if (LastBytesArrForRoute.Length == 2)
                    {
                        LastByteArrForRouteName1 = Encoding.ASCII.GetBytes(LastBytesArrForRoute[0]);
                        LastByteArrForRouteName2 = Encoding.ASCII.GetBytes(LastBytesArrForRoute[1]);
                    }
                    else if (LastBytesArrForRoute.Length == 1)
                    {
                        LastByteArrForRouteName1[0] = Convert.ToByte(0x30);
                        LastByteArrForRouteName2 = Encoding.ASCII.GetBytes(LastBytesArrForRoute[0]);
                    }
                    if (RouteToSend < 10)
                    {
                        TourSingle[0] = Convert.ToByte(0x30 + RouteToSend);
                    }
                    else if (RouteToSend >= 10)
                    {
                        int high = RouteToSend / 10;
                        int low = RouteToSend % 10;
                        Tour[0] = Convert.ToByte(0x30 + high);
                        Tour1[0] = Convert.ToByte(0x30 + low);
                    }
                    for (int i = 2; i <= RouteToSend; i++)
                    {
                        LastMiddleByte++;
                    }
                    LastMiddleByte--;
                    LastMiddleFinal[0] = LastMiddleByte;
                    int Run = 2;
                    byte lastRun = 0x00;
                    int lastRunHigh = 0;
                    int lastRunLow = 0;
                    for (int i = 2; i <= RouteToSend; i++)
                    {

                        if (RouteToSend < 10)
                        {
                            ThirdEnd2++;
                            if (ThirdEnd2 == 0x3a)
                                ThirdEnd2 = 0x41;

                        }
                        else if (RouteToSend >= 10)
                        {
                            lastRunLow = RouteToSend % 10;
                            lastRunHigh = RouteToSend / 10;
                            ThirdEnd1 = 0x30;
                            ThirdEnd2 = Convert.ToByte(48 + (lastRunLow + 2) + (lastRunHigh - 1));

                            if (ThirdEnd2 >= 0x3a)
                                ThirdEnd2 = Convert.ToByte(0x41 + (ThirdEnd2 - 0x3a));
                        }
                        Run++;
                    }
                    ThirdQuestionEnd[0] = ThirdEnd1;
                    ThirdQuestionEnd[1] = ThirdEnd2;
                    Run = 2;
                    lastRun = 0x00;
                    lastRunHigh = 0;
                    lastRunLow = 0;
                    for (int i = 2; i <= RouteToSend; i++)
                    {
                        if (RouteToSend < 10)
                        {
                            FourthEnd2++;
                        }
                        else if (RouteToSend >= 10)
                        {
                            lastRunLow = RouteToSend % 10;
                            lastRunHigh = RouteToSend / 10;
                            FourthEnd1 = 0x33;
                            FourthEnd2 = Convert.ToByte(48 + (lastRunLow + 1) + (lastRunHigh - 1));

                            if (FourthEnd2 >= 0x3a)
                                FourthEnd2 = Convert.ToByte(0x41 + (FourthEnd2 - 0x3a));
                        }
                        Run++;
                        System.Diagnostics.Debug.WriteLine(FourthEnd2);
                    }
                    FourthLastByte[0] = FourthEnd1;
                    FourthLastByte[1] = FourthEnd2;
                    Run = 2;
                    lastRun = 0x00;
                    lastRunHigh = 0;
                    lastRunLow = 0;
                    for (int i = 2; i <= RouteToSend; i++)
                    {

                        if (RouteToSend < 10)
                        {
                            FifthEnd2++;
                            if (FifthEnd2 == 0x3a)
                                FifthEnd2 = 0x41;
                        }
                        else if (RouteToSend >= 10)
                        {
                            lastRunLow = RouteToSend % 10;
                            lastRunHigh = RouteToSend / 10;
                            FifthEnd1 = 0x34;
                            FifthEnd2 = Convert.ToByte(48 + (lastRunLow + 3) + (lastRunHigh - 1));
                            if (FifthEnd2 >= 0x3a)
                                FifthEnd2 = Convert.ToByte(0x41 + (FifthEnd2 - 0x3a));
                        }
                        Run++;
                        System.Diagnostics.Debug.WriteLine(FifthEnd2);
                    }
                    FifthLastByte[0] = FifthEnd1;
                    FifthLastByte[1] = FifthEnd2;
                    Run = 2;
                    lastRun = 0x00;
                    for (int i = 2; i <= RouteToSend; i++)
                    {
                        if (RouteToSend < 10)
                        {
                            SixthEnd2++;
                            if (SixthEnd2 == 0x3a)
                                SixthEnd2 = 0x41;
                            if (SixthEnd2 == 0x47)
                            {
                                SixthEnd1++;
                                SixthEnd2 = 0x30;
                            }
                        }
                        else if (RouteToSend >= 10)
                        {
                            SixthEnd2++;
                            if (SixthEnd2 == 0x3a)
                                SixthEnd2 = 0x41;
                            if (Run == 10)
                            {
                                SixthEnd1 = 0x37;
                                SixthEnd2 = 0x39;
                                if (SixthEnd2 == 0x3a)
                                    SixthEnd2 = 0x41;
                            }

                            if (SixthEnd2 == 0x32)
                            {
                                lastRun++;
                                SixthEnd1 = 0x37;
                                SixthEnd2 = Convert.ToByte(0x39 + lastRun);
                            }
                            if (SixthEnd2 == 0x47)
                            {
                                SixthEnd1 = 0x30;
                                SixthEnd2 = 0x30;
                            }
                            if (Run <= 10 && SixthEnd2 == 0x47)
                            {
                                SixthEnd1 = 0x35;
                                SixthEnd2 = 0x30;
                            }
                            if (Run <= 10 && SixthEnd2 == 0x3a)
                                SixthEnd2 = 0x41;
                        }
                        Run++;
                    }
                    SixthLastByte[0] = SixthEnd1;
                    SixthLastByte[1] = SixthEnd2;
                    Run = 2;
                    lastRun = 0x00;
                    for (int i = 2; i <= RouteToSend; i++)
                    {

                        if (RouteToSend < 10)
                        {
                            EightEnd2++;
                            if (EightEnd2 == 0x3a)
                                EightEnd2 = 0x41;
                        }
                        else if (RouteToSend > 10)
                        {
                            if (Run == 10)
                            {
                                Run = 0;
                                EightEnd1 = 0x30;
                                EightEnd2 = Convert.ToByte(51 + lastRun);
                                lastRun++;
                            }
                            EightEnd2++;
                            if (EightEnd2 == 0x3a)
                                EightEnd2 = 0x41;
                        }
                        Run++;
                        System.Diagnostics.Debug.WriteLine(FifthEnd2);
                    }
                    EightLastByte[0] = EightEnd1;
                    EightLastByte[1] = EightEnd2;
                    Run = 2;
                    lastRun = 0x00;
                    for (int i = 2; i <= RouteToSend; i++)
                    {
                        if (RouteToSend < 10)
                        {
                            TenthEnd2++;
                            if (TenthEnd2 == 0x3a)
                                TenthEnd2 = 0x41;
                        }
                        else if (RouteToSend > 10)
                        {
                            if (Run == 10)
                            {
                                Run = 0;
                                TenthEnd1 = 0x31;
                                TenthEnd2 = Convert.ToByte(54 + lastRun);
                                lastRun++;
                            }
                            TenthEnd2++;
                            if (TenthEnd2 == 0x3a)
                                TenthEnd2 = 0x41;
                        }
                        Run++;
                        System.Diagnostics.Debug.WriteLine(TenthEnd2);
                    }
                    TenthLastByte[0] = TenthEnd1;
                    TenthLastByte[1] = TenthEnd2;
                    Run = 2;
                    lastRun = 0x00;
                    for (int i = 2; i <= RouteToSend; i++)
                    {
                        if (ThirteenEnd2 == 0x3a)
                            ThirteenEnd2 = 0x41;
                        if (ThirteenEnd2 == 0x47)
                        {
                            ThirteenEnd2 = 0x30;
                            ThirteenEnd1++;
                        }
                        ThirteenEnd2++;
                        System.Diagnostics.Debug.WriteLine(TenthEnd2);
                    }
                    ThirteenEnd2--;
                    ThirteenLastByte[0] = ThirteenEnd1;
                    ThirteenLastByte[1] = ThirteenEnd2;
                    byte[] Entrance = new byte[4];
                    byte[] FirstByteArr = new byte[1];
                    FirstByteArr[0] = FirstByte;
                    byte[] SecondByteArr = new byte[1];
                    SecondByteArr[0] = SecondByte;
                    byte[] ForData4Arr = new byte[1];
                    ForData4Arr[0] = ForData4;
                    byte[] ForData5Arr = new byte[1];
                    ForData5Arr[0] = ForData5;
                    byte[] ForData6Arr = new byte[1];
                    ForData6Arr[0] = ForData6;
                    byte[] ForData7Arr = new byte[1];
                    ForData7Arr[0] = ForData7;
                    byte[] ZeroFullScaleArr = new byte[1];
                    ZeroFullScaleArr[0] = ZeroFullScale;
                    byte[] AfterUnitCodeArr = new byte[1];
                    AfterUnitCodeArr[0] = AfterUnitCode;
                    byte[] AfterUnitCode1Arr = new byte[1];
                    AfterUnitCode1Arr[0] = AfterUnitCode1;
                    byte[] OrderArr = new byte[1];
                    OrderArr[0] = Order;
                    byte[] ToSendAfterOrderArr = new byte[1];
                    ToSendAfterOrderArr[0] = ToSendAfterOrder;
                    byte[] ToSendAfterCollectionArr = new byte[1];
                    byte[] FrequencyArr = new byte[1];
                    FrequencyArr[0] = Convert.ToByte(Frequency);
                    byte[] ForData88Arr = new byte[1];
                    ForData88Arr[0] = ForData88;
                    byte[] OverlapArr = new byte[1];
                    OverlapArr[0] = Convert.ToByte(Overlap);

                    int TotalReadingBytes = StartDataToSend2.Length + 1 + 2 + DataToSend88.Length + 1 + ForData88Arr.Length + ConsTantToSend1.Length + OrderArr.Length + ConsTantToSend.Length + BeforeFF.Length + 6 + AfterUnitCode1Arr.Length + AfterUnitCode1Arr.Length + ForData7Arr.Length + DataToSend7.Length + 1 + ForData6Arr.Length + DataToSend6.Length + 1 + ForData5Arr.Length + DataToSend5.Length + 1 + FirstByteArr.Length + SecondByteArr.Length + StartDataToSend3.Length + DataToSend4.Length + 1 + ForData4Arr.Length;
                    if (ZeroFullScale != 0)
                        TotalReadingBytes = TotalReadingBytes + ZeroFullScaleArr.Length;
                    //if (unitCode[0] != 0)
                    TotalReadingBytes = TotalReadingBytes + unitCode.Length;
                    if (Filter != 0 || AfterUnitCode != 0)
                        TotalReadingBytes = TotalReadingBytes + AfterUnitCodeArr.Length;
                    if (DetectionType != 0)
                        TotalReadingBytes = TotalReadingBytes + DetctionInformationToSend.Length;
                    else if (DetectionType == 0)
                        TotalReadingBytes = TotalReadingBytes + 2;

                    if (LinesOfResolutin != 2)
                    {
                        TotalReadingBytes = TotalReadingBytes + ToSendAfterOrderArr.Length;
                        if (LinesOfResolutin < 2)
                            TotalReadingBytes = TotalReadingBytes + ToSendAfterCollectionArr.Length;
                        else if (LinesOfResolutin > 2)
                            TotalReadingBytes = TotalReadingBytes + ToSendAfterCollectionArr.Length;
                        if (Window == 0 && Frequency == 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + 3;
                        }
                        else
                        {
                            TotalReadingBytes = TotalReadingBytes + 4;
                        }
                    }
                    if (LinesOfResolutin == 2)
                    {
                        if (Collection == 0 && Window == 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + 2;
                            if (Frequency != 0)
                            {
                                TotalReadingBytes = TotalReadingBytes + FrequencyArr.Length;
                            }
                            TotalReadingBytes = TotalReadingBytes + 1;
                        }
                        if (Collection != 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + 4;

                            if (Frequency != 0)
                            {
                                TotalReadingBytes = TotalReadingBytes + FrequencyArr.Length;
                            }
                            TotalReadingBytes = TotalReadingBytes + 1;
                        }
                        if (Window != 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + 6;
                        }
                        if (Collection != 0 && Window != 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + 2;
                            TotalReadingBytes = TotalReadingBytes + ToSendAfterOrderArr.Length;
                            if (Window == 0)
                            {
                                TotalReadingBytes = TotalReadingBytes + 2;
                                TotalReadingBytes = TotalReadingBytes + 1;
                            }
                            else
                            {
                                TotalReadingBytes = TotalReadingBytes + 4;
                            }
                        }
                    }
                    if (Slope == 0)
                    {
                        TotalReadingBytes = TotalReadingBytes + 4;
                    }
                    else if (Slope == 1)
                    {
                        TotalReadingBytes = TotalReadingBytes + 6;
                    }
                    if (Measure == 0)
                    {
                        TotalReadingBytes = TotalReadingBytes + 10;
                    }
                    else if (Measure == 1)
                    {
                        TotalReadingBytes = TotalReadingBytes + 19;
                    }
                    else if (Measure == 2)
                        TotalReadingBytes = TotalReadingBytes + 10;
                    if ((Channel == 3 || Channel == 4) && Measure != 3)
                        TotalReadingBytes = TotalReadingBytes * 2;
                    else if ((Channel == 3 || Channel == 4) && Measure == 3)
                        TotalReadingBytes = TotalReadingBytes * 4;
                    string hexReadingBytes = DeciamlToHexadeciaml(TotalReadingBytes);
                    string[] arr = null;

                    arr = hexReadingBytes.Split(new string[] { "," }, StringSplitOptions.None);
                    byte[] arrToConvert1 = new byte[1];
                    byte[] arrToConvert2 = new byte[1];
                    byte[] arrToConvert3 = new byte[1];
                    if (arr.Length == 2)
                    {
                        arrToConvert1 = Encoding.ASCII.GetBytes(arr[0]);
                        arrToConvert2 = Encoding.ASCII.GetBytes(arr[1]);
                        Entrance[0] = 0x30;
                        Entrance[1] = 0x30;
                        Entrance[2] = Convert.ToByte(arrToConvert1[0]);
                        Entrance[3] = Convert.ToByte(arrToConvert2[0]);
                    }
                    else if (arr.Length == 3)
                    {
                        arrToConvert1 = Encoding.ASCII.GetBytes(arr[1]);
                        arrToConvert2 = Encoding.ASCII.GetBytes(arr[2]);
                        arrToConvert3 = Encoding.ASCII.GetBytes(arr[0]);
                        Entrance[0] = 0x30;
                        Entrance[1] = Convert.ToByte(arrToConvert3[0]);
                        Entrance[2] = Convert.ToByte(arrToConvert1[0]);
                        Entrance[3] = Convert.ToByte(arrToConvert2[0]);
                    }
                    byte Recieve = 0;
                    byte[] FinalByteArr = new byte[1];
                    byte[] FinalbyteEnd = new byte[2];
                    byte[] DateLast = new byte[2];
                    if (PointCounter == 0 && same == false)
                    {
                    }
                    int RouteSendingTimes = 0;
                    RouteSendingTimes = Measure + 1;
                    int ApproximateByteForDataEnd = FirstByte;
                    if (Measure == 2)
                        BeforeFF[0]++;
                    string OneB = "\x1b";
                    string ZeroC = "\x0c";
                    string[] ValuesAvgs = null;
                    if (objListOfAvgs.ContainsKey((object)Points[PointCounter]))
                    {
                        ValuesAvgs = objListOfAvgs[Points[PointCounter]].ToString().Split(new string[] { "!" }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else
                    {
                        ValuesAvgs = new string[2];
                        ValuesAvgs[0] = "4";
                        ValuesAvgs[1] = "1";
                    }
                    string[] ArryForSpectAvgs = DeciamlToHexadeciaml(Convert.ToInt32(ValuesAvgs[0])).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    byte[] AyyAvg = null;
                    byte[] CnstFst = { 0x1B, 0x03, 0x5a, 0x1B, 0x12 };
                    byte[] CnstScnd = { 0x5a, 0x1B, 0x12 };
                    bool OnBOth = false;
                    if (ArryForSpectAvgs.Length == 4)
                    {
                        AyyAvg = new byte[2];
                        AyyAvg[0] = Convert.ToByte(HexadecimaltoDecimal(ArryForSpectAvgs[2] + ArryForSpectAvgs[3]));
                        AyyAvg[1] = Convert.ToByte(HexadecimaltoDecimal(ArryForSpectAvgs[0] + ArryForSpectAvgs[1]));
                        OnBOth = false;
                    }
                    else if (ArryForSpectAvgs.Length == 3)
                    {
                        AyyAvg = new byte[2];
                        AyyAvg[0] = Convert.ToByte(HexadecimaltoDecimal(ArryForSpectAvgs[1] + ArryForSpectAvgs[2]));
                        AyyAvg[1] = Convert.ToByte(HexadecimaltoDecimal("0" + ArryForSpectAvgs[0]));
                        OnBOth = false;
                    }
                    else if (ArryForSpectAvgs.Length == 2)
                    {
                        AyyAvg = new byte[1];
                        AyyAvg[0] = Convert.ToByte(HexadecimaltoDecimal(ArryForSpectAvgs[0] + ArryForSpectAvgs[1]));
                        OnBOth = true;
                    }
                    else if (ArryForSpectAvgs.Length == 1)
                    {
                        AyyAvg = new byte[1];
                        AyyAvg[0] = Convert.ToByte(HexadecimaltoDecimal(0 + ArryForSpectAvgs[0]));
                        OnBOth = true;
                    }
                    byte[] TimeAvg = new byte[1];
                    TimeAvg[0] = Convert.ToByte(ValuesAvgs[1]);
                    byte[] ConsTantToSend1now = { 0x00, 0x00, 0x32, 0x73, 0x1B, 0x11 };
                    byte[] ConsTantToSend1nowiftru = { 0x1B, 0x03, 0x32, 0x73, 0x1B, 0x11 };
                    byte[] ConsTantToSend11now = { 0x00, 0x00, 0x5a, 0x1B, 0x12 };
                    byte[] ConsTantToSend11nowiftru = { 0x1B, 0x03, 0x5a, 0x1B, 0x12 };

                    if (Channel == 0 || Channel == 1 || Channel == 2)
                    {
                        if (Measure == 0)
                        {
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }
                            MakeArray(StartDataToSend22);
                            MakeArray(FirstByteArr);
                            MakeArray(SecondByteArr);
                            MakeArray(StartDataToSend3b);
                            byte[] aaa = new byte[1];
                            aaa[0] = Convert.ToByte(0x02 + PointCounter);
                            if (aaa[0] == 0x1b)
                            {
                                byte[] aaa11 = new byte[1];
                                aaa11[0] = Convert.ToByte(0);
                                MakeArray(aaa11);
                            }
                            else
                            {
                                MakeArray(aaa);
                            }
                            MakeArray(StartDataToSend3l);
                            byte[] DataToSend4Change = ChangeName(DataToSend4);
                            MakeArray(DataToSend4Change);
                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            MakeArray(OB);
                            MakeArray(ForData4Arr);
                            byte[] DataToSend5Change = ChangeName(DataToSend5);
                            MakeArray(DataToSend5Change);
                            MakeArray(OB);
                            MakeArray(ForData5Arr);
                            byte[] DataToSend6Change = ChangeName(DataToSend6);
                            MakeArray(DataToSend6Change);
                            MakeArray(OB);
                            MakeArray(ForData6Arr);
                            byte[] DataToSend7Change = ChangeName(DataToSend7);
                            MakeArray(DataToSend7Change);
                            MakeArray(OB);
                            MakeArray(ForData7Arr);
                            if (ZeroFullScale != 0)
                            {
                                MakeArray(ZeroFullScaleArr);
                            }
                            if (Filter == 0 && Unit == 0)
                            {
                                int kk = 0;
                            }
                            else
                            {
                                MakeArray(unitCode);
                            }
                            if (Filter != 0 || AfterUnitCode != 0 || Excep == false)
                            {
                                MakeArray(AfterUnitCodeArr);
                            }
                            if (Filter != 0 || Excep == false)
                                MakeArray(AfterUnitCode1Arr);
                            MakeArray(BeforeFF);
                            byte[] ZC = new byte[1];
                            ZC[0] = 0x0c;
                            for (int i = 0; i < 6; i++)
                            {
                                byte[] ff = new byte[1];
                                ff[0] = 0xff;
                                MakeArray(ff);
                            }
                            if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                            {
                                if (DetectionType != 0)
                                {
                                    MakeArray(DetctionInformationToSend);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                                else if (DetectionType == 0)
                                {
                                    MakeArray(OB);
                                    MakeArray(ZC);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                            }
                            else
                            {
                                byte[] Cnst = { 0x00, 0x00, 0x01 };
                                byte[] Detec = new byte[1];
                                Detec[0] = DetctionInformationToSend[2];
                                byte[] Cnst2 = { 0x1b, 0x08 };
                                byte[] Cnst3 = { 0x1b, 0x08 };
                                MakeArray(Cnst);
                                MakeArray(Detec);
                                MakeArray(Cnst2);
                                byte[] xTimeAvg = { 0x60, 0x00 };
                                MakeArray(TimeAvg);
                                MakeArray(FirstToSendAlarm);
                                MakeArray(SecondToSendAlarm);
                                MakeArray(Cnst3);
                            }
                            MakeArray(ConsTantToSend);
                            MakeArray(OrderArr);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = 0x00;
                            if (LinesOfResolutin != 2)
                            {
                                MakeArray(ZZ);
                                MakeArray(ToSendAfterOrderArr);
                                if (LinesOfResolutin < 2)
                                {
                                    ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                else if (LinesOfResolutin > 2)
                                {
                                    ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                if (Window == 0 && Frequency == 0)
                                {
                                    WindowZero[0] = 0x1b;
                                    WindowZero[1] = 0x03;
                                    MakeArray(WindowZero);
                                    byte[] zerofour = new byte[1];
                                    zerofour[0] = 0x04;
                                    MakeArray(WindowZero);
                                }
                                else
                                {
                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    MakeArray(WindowNotZero);
                                }
                            }
                            if (LinesOfResolutin == 2)
                            {
                                if (Collection != 0 && Window != 0)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);
                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    MakeArray(frq);
                                }
                                if (Collection == 0 && Window != 0)
                                {
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);
                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    MakeArray(WindowNotZero);
                                }
                                if (Collection != 0 && Window == 0)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);
                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    MakeArray(frq);
                                }
                                if (Collection == 0 && Window == 0)
                                {
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x05;
                                    MakeArray(LinesFourHund);
                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    MakeArray(frq);
                                }
                            }
                            if (OnBOth)
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend1nowiftru);
                            }
                            else
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend1now);
                            }
                            byte[] DataToSend88Change = ChangeName(DataToSend88);
                            MakeArray(DataToSend88Change);
                            MakeArray(OB);
                            MakeArray(ForData88Arr);
                            if (Slope == 0)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                MakeArray(AfterEquipID);
                            }
                            else if (Slope == 1)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                MakeArray(AfterEquipID);
                            }

                            MakeArray(ZZ);
                            MakeArray(OverlapArr);
                            if (Measure == 0 && LinesOfResolutin == 0)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0xCC, 0x1B, 0xCD, };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 1)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x94, 0x01, 0x1B, 0xF2, 0x00, 0x00, };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 2)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x24, 0x03, 0x1B, 0xF4, 0x00, 0x00, };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 3)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x44, 0x06, 0x1B, 0xF6, 0x00, 0x00, };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 4)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x84, 0x0c, 0x1B, 0xF8, 0x00, 0x00, };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 5)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x19, 0x1B, 0xFA, 0x00, 0x00, };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 0 && LinesOfResolutin == 6)
                            {
                                byte[] FinalEnd = { 0x01, 0x0a, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x32, 0x1B, 0xFC, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            PointCounter++;
                        }
                        else if (Measure == 1)
                        {
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }
                            MakeArray(StartDataToSend22);
                            MakeArray(FirstByteArr);
                            MakeArray(SecondByteArr);

                            MakeArray(StartDataToSend3b);
                            byte[] aaa = new byte[1];
                            aaa[0] = Convert.ToByte(0x02 + PointCounter);
                            if (aaa[0] == 0x1b)
                            {
                                byte[] aaa11 = new byte[1];
                                aaa11[0] = Convert.ToByte(0);
                                MakeArray(aaa11);
                            }
                            else
                            {
                                MakeArray(aaa);
                            }
                            MakeArray(StartDataToSend3l);
                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            byte[] DataToSend4Change = ChangeName(DataToSend4);
                            MakeArray(DataToSend4Change);
                            MakeArray(OB);
                            MakeArray(ForData4Arr);
                            byte[] DataToSend5Change = ChangeName(DataToSend5);
                            MakeArray(DataToSend5Change);
                            MakeArray(OB);
                            MakeArray(ForData5Arr);
                            byte[] DataToSend6Change = ChangeName(DataToSend6);
                            MakeArray(DataToSend6Change);
                            MakeArray(OB);
                            MakeArray(ForData6Arr);
                            byte[] DataToSend7Change = ChangeName(DataToSend7);
                            MakeArray(DataToSend7Change);
                            MakeArray(OB);
                            MakeArray(ForData7Arr);
                            if (ZeroFullScale != 0)
                                MakeArray(ZeroFullScaleArr);
                            if (Filter == 0 && Unit == 0)
                            {
                                int kk = 0;
                            }
                            else
                            {
                                MakeArray(unitCode);
                            }
                            if (Filter != 0 || AfterUnitCode != 0 || Excep == false)
                                MakeArray(AfterUnitCodeArr);
                            if (Filter != 0 || Excep == false)
                                MakeArray(AfterUnitCode1Arr);
                            MakeArray(BeforeFF);
                            for (int i = 0; i < 6; i++)
                            {
                                byte[] ff = new byte[1];
                                ff[0] = 0xff;

                                MakeArray(ff);
                            }
                            if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                            {
                                if (DetectionType != 0)
                                {
                                    MakeArray(DetctionInformationToSend);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                                else if (DetectionType == 0)
                                {
                                    MakeArray(OB);
                                    MakeArray(ZC);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                            }
                            else
                            {
                                byte[] Cnst = { 0x00, 0x00, 0x01 };
                                byte[] Detec = new byte[1];
                                Detec[0] = DetctionInformationToSend[2];
                                byte[] Cnst2 = { 0x1b, 0x08 };
                                byte[] Cnst3 = { 0x1b, 0x08 };
                                MakeArray(Cnst);
                                MakeArray(Detec);
                                MakeArray(Cnst2);
                                MakeArray(TimeAvg);
                                MakeArray(FirstToSendAlarm);
                                MakeArray(SecondToSendAlarm);
                                MakeArray(Cnst3);
                            }
                            MakeArray(ConsTantToSend);
                            MakeArray(OrderArr);
                            if (LinesOfResolutin != 2)
                            {
                                MakeArray(ZZ);
                                MakeArray(ToSendAfterOrderArr);
                                if (LinesOfResolutin < 2)
                                {
                                    ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                else if (LinesOfResolutin > 2)
                                {
                                    ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                if (Window == 0 && Frequency == 0)
                                {
                                    WindowZero[0] = 0x1b;
                                    WindowZero[1] = 0x03;
                                    MakeArray(WindowZero);
                                    string zerofour = "\x04";
                                }
                                else
                                {
                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    MakeArray(WindowNotZero);
                                }
                            }
                            if (LinesOfResolutin == 2)
                            {
                                if (Collection != 0 && Window != 0)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);
                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    MakeArray(frq);
                                }
                                if (Collection == 0 && Window != 0)
                                {
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);
                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    MakeArray(WindowNotZero);
                                }
                                if (Collection != 0 && Window == 0)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);

                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    MakeArray(frq);
                                }
                                if (Collection == 0 && Window == 0)
                                {
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x05;
                                    MakeArray(LinesFourHund);
                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    MakeArray(frq);
                                }
                            }
                            if (OnBOth)
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend1nowiftru);
                            }
                            else
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend1now);
                            }
                            byte[] DataToSend88Change = ChangeName(DataToSend88);
                            MakeArray(DataToSend88Change);

                            MakeArray(OB);
                            MakeArray(ForData88Arr);

                            if (Slope == 0)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                MakeArray(AfterEquipID);
                            }
                            else if (Slope == 1)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                MakeArray(AfterEquipID);
                            }
                            MakeArray(ZZ);
                            MakeArray(OverlapArr);
                            if (Measure == 1 && LinesOfResolutin == 0)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0xCC, 0x1B, 0xCD, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 1 && LinesOfResolutin == 1)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x94, 0x01, 0x1B, 0xF2, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 1 && LinesOfResolutin == 2)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x24, 0x03, 0x1B, 0xF4, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 1 && LinesOfResolutin == 3)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x44, 0x06, 0x1B, 0xF6, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 1 && LinesOfResolutin == 4)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x84, 0x0c, 0x1B, 0xF8, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 1 && LinesOfResolutin == 5)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x19, 0x1B, 0xFA, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 1 && LinesOfResolutin == 6)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x32, 0x1B, 0xFC, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            PointCounter++;
                        }
                        else if (Measure == 2)
                        {
                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            byte[] ZT = new byte[1];
                            ZT[0] = Convert.ToByte(0x03);
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }

                            MakeArray(StartDataToSend22);
                            MakeArray(FirstByteArr);
                            MakeArray(SecondByteArr);
                            MakeArray(StartDataToSend3b);
                            byte[] aaa = new byte[1];
                            aaa[0] = Convert.ToByte(0x02 + PointCounter);
                            if (aaa[0] == 0x1b)
                            {
                                byte[] aaa11 = new byte[1];
                                aaa11[0] = Convert.ToByte(0);
                                MakeArray(aaa11);
                            }
                            else
                            {
                                MakeArray(aaa);
                            }
                            MakeArray(StartDataToSend3l);
                            byte[] DataToSend4Change = ChangeName(DataToSend4);
                            MakeArray(DataToSend4Change);
                            MakeArray(OB);

                            MakeArray(ForData4Arr);
                            byte[] DataToSend5Change = ChangeName(DataToSend5);
                            MakeArray(DataToSend5Change);
                            MakeArray(OB);
                            MakeArray(ForData5Arr);
                            byte[] DataToSend6Change = ChangeName(DataToSend6);
                            MakeArray(DataToSend6Change);
                            MakeArray(OB);
                            MakeArray(ForData6Arr);
                            byte[] DataToSend7Change = ChangeName(DataToSend7);
                            MakeArray(DataToSend7Change);
                            MakeArray(OB);
                            MakeArray(ForData7Arr);
                            int kk = 0;
                            if (ZeroFullScale != 0)
                            {
                                MakeArray(ZeroFullScaleArr);
                            }
                            if (Filter == 0 && Unit == 0)
                            {
                                kk = 1;
                                MakeArray(OB);
                                MakeArray(ZT);
                            }
                            else
                            {
                                MakeArray(unitCode);
                            }
                            if ((Filter != 0 || AfterUnitCode != 0 || Excep == false) && kk == 0)
                            {
                                MakeArray(AfterUnitCodeArr);
                            }
                            if ((Filter != 0 || Excep == false) && kk == 0)
                                MakeArray(AfterUnitCode1Arr);
                            MakeArray(BeforeFF);
                            for (int i = 0; i < 6; i++)
                            {
                                byte[] ff = new byte[1];
                                ff[0] = 0xff;
                                MakeArray(ff);
                            }
                            if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                            {
                                if (DetectionType != 0)
                                {
                                    MakeArray(DetctionInformationToSend);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                                else if (DetectionType == 0)
                                {
                                    MakeArray(OB);
                                    MakeArray(ZC);
                                    byte[] CCnst = { 0x1b, 0x0c };
                                    MakeArray(TimeAvg);
                                    MakeArray(CCnst);
                                }
                            }
                            else
                            {
                                byte[] Cnst = { 0x00, 0x00, 0x01 };
                                byte[] Detec = new byte[1];
                                Detec[0] = DetctionInformationToSend[2];
                                byte[] Cnst2 = { 0x1b, 0x08 };
                                byte[] Cnst3 = { 0x1b, 0x08 };
                                MakeArray(Cnst);
                                MakeArray(Detec);
                                MakeArray(Cnst2);
                                MakeArray(TimeAvg);
                                MakeArray(FirstToSendAlarm);
                                MakeArray(SecondToSendAlarm);
                                MakeArray(Cnst3);
                            }
                            MakeArray(ConsTantToSend);
                            MakeArray(OrderArr);
                            if (LinesOfResolutin != 2)
                            {
                                MakeArray(ZZ);
                                MakeArray(ToSendAfterOrderArr);
                                if (LinesOfResolutin < 2)
                                {
                                    ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                else if (LinesOfResolutin > 2)
                                {
                                    ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                    MakeArray(ToSendAfterCollectionArr);
                                }
                                if (Window == 0 && Frequency == 0)
                                {
                                    WindowZero[0] = 0x1b;
                                    WindowZero[1] = 0x03;
                                    MakeArray(WindowZero);
                                    string zerofour = "\x04";
                                }
                                else
                                {
                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    MakeArray(WindowNotZero);
                                }
                            }
                            if (LinesOfResolutin == 2)
                            {
                                if (Collection != 0 && Window != 0)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);
                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    MakeArray(frq);
                                }
                                if (Collection == 0 && Window != 0)
                                {
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);
                                    WindowNotZero[0] = Convert.ToByte(Window);
                                    WindowNotZero[1] = 0x00;
                                    WindowNotZero[2] = Convert.ToByte(Frequency);
                                    MakeArray(WindowNotZero);
                                }
                                if (Collection != 0 && Window == 0)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x03;
                                    MakeArray(LinesFourHund);
                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    MakeArray(frq);
                                }
                                if (Collection == 0 && Window == 0)
                                {
                                    LinesFourHund[0] = 0x1b;
                                    LinesFourHund[1] = 0x05;
                                    MakeArray(LinesFourHund);
                                    byte[] frq = new byte[1];
                                    frq[0] = Convert.ToByte(Frequency);
                                    MakeArray(frq);
                                }
                            }
                            if (OnBOth)
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend11nowiftru);
                            }
                            else
                            {
                                MakeArray(AyyAvg);
                                MakeArray(ConsTantToSend11now);
                            }
                            byte[] DataToSend88Change = ChangeName(DataToSend88);
                            MakeArray(DataToSend88Change);
                            MakeArray(OB);
                            MakeArray(ForData88Arr);

                            if (Slope == 0)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                MakeArray(AfterEquipID);
                            }
                            else if (Slope == 1)
                            {
                                byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                MakeArray(AfterEquipID);
                            }
                            MakeArray(ZZ);
                            MakeArray(OverlapArr);

                            if (Measure == 2 && LinesOfResolutin == 0)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x02, 0x1B, 0xF3, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }

                            if (Measure == 2 && LinesOfResolutin == 1)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x04, 0x1B, 0xF5, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }

                            if (Measure == 2 && LinesOfResolutin == 2)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x08, 0x1B, 0xF7, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }

                            if (Measure == 2 && LinesOfResolutin == 3)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x10, 0x1B, 0xF9, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }

                            if (Measure == 2 && LinesOfResolutin == 4)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x20, 0x1B, 0xFB, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 2 && LinesOfResolutin == 5)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x40, 0x1B, 0xFD, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            if (Measure == 2 && LinesOfResolutin == 6)
                            {
                                byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x80, 0x1B, 0xFF, 0x00, 0x00 };
                                MakeArray(FinalEnd);
                                Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                {
                                    FinalByteArr[resctr] = FinalEnd[resctr];
                                }
                            }
                            PointCounter++;
                        }
                    }
                    else if (Channel == 3 || Channel == 4)
                    {
                        int dualChannelCounter = 0;
                        if (Measure == 0)
                        {
                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }
                            do
                            {
                                MakeArray(StartDataToSend22);
                                MakeArray(FirstByteArr);
                                MakeArray(SecondByteArr);
                                MakeArray(StartDataToSend3ForDualChannel);
                                byte[] aaa = new byte[1];
                                aaa[0] = Convert.ToByte(0x02 + PointCounter);
                                if (aaa[0] == 0x1b)
                                {
                                    byte[] aaa11 = new byte[1];
                                    aaa11[0] = Convert.ToByte(0);
                                    MakeArray(aaa11);
                                }
                                else
                                {
                                    MakeArray(aaa);
                                }
                                if (dualChannelCounter == 0)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter0);
                                else if (dualChannelCounter == 1)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter1);

                                byte[] DataToSend4Change = ChangeName(DataToSend4);
                                MakeArray(DataToSend4Change);
                                MakeArray(OB);
                                MakeArray(ForData4Arr);
                                byte[] DataToSend5Change = ChangeName(DataToSend5);
                                MakeArray(DataToSend5Change);
                                MakeArray(OB);
                                MakeArray(ForData5Arr);
                                byte[] DataToSend6Change = ChangeName(DataToSend6);
                                MakeArray(DataToSend6Change);
                                MakeArray(OB);
                                MakeArray(ForData6Arr);
                                byte[] DataToSend7Change = ChangeName(DataToSend7);
                                MakeArray(DataToSend7Change);
                                MakeArray(OB);
                                MakeArray(ForData7Arr);
                                if (ZeroFullScale != 0)
                                    MakeArray(ZeroFullScaleArr);
                                if (Filter == 0 && Unit == 0)
                                {
                                    int kk = 0;
                                }
                                else
                                {
                                    MakeArray(unitCode);
                                }
                                if (Filter != 0 || AfterUnitCode != 0 || Excep == false)
                                    MakeArray(AfterUnitCodeArr);
                                if (Filter != 0 || Excep == false)
                                    MakeArray(AfterUnitCode1Arr);
                                MakeArray(BeforeFF);
                                for (int i = 0; i < 6; i++)
                                {
                                    byte[] ff = new byte[1];
                                    ff[0] = 0xff;
                                    MakeArray(ff);
                                }
                                if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                                {
                                    if (DetectionType != 0)
                                    {
                                        MakeArray(DetctionInformationToSend);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                    else if (DetectionType == 0)
                                    {
                                        MakeArray(OB);
                                        MakeArray(ZC);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                }
                                else
                                {
                                    byte[] Cnst = { 0x00, 0x00, 0x01 };
                                    byte[] Detec = new byte[1];
                                    Detec[0] = DetctionInformationToSend[2];
                                    byte[] Cnst2 = { 0x1b, 0x08 };
                                    byte[] Cnst3 = { 0x1b, 0x08 };
                                    MakeArray(Cnst);
                                    MakeArray(Detec);
                                    MakeArray(Cnst2);
                                    MakeArray(TimeAvg);
                                    MakeArray(FirstToSendAlarm);
                                    MakeArray(SecondToSendAlarm);
                                    MakeArray(Cnst3);
                                }
                                MakeArray(ConsTantToSend);
                                MakeArray(OrderArr);
                                if (LinesOfResolutin != 2)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    if (LinesOfResolutin < 2)
                                    {
                                        ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    else if (LinesOfResolutin > 2)
                                    {
                                        ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    if (Window == 0 && Frequency == 0)
                                    {
                                        WindowZero[0] = 0x1b;
                                        WindowZero[1] = 0x03;
                                        MakeArray(WindowZero);
                                        string zerofour = "\x04";
                                    }
                                    else
                                    {
                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);
                                    }
                                }
                                if (LinesOfResolutin == 2)
                                {
                                    if (Collection != 0 && Window != 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                    if (Collection == 0 && Window != 0)
                                    {
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);
                                    }
                                    if (Collection != 0 && Window == 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                    if (Collection == 0 && Window == 0)
                                    {

                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x05;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                }
                                if (OnBOth)
                                {
                                    MakeArray(AyyAvg);

                                    MakeArray(ConsTantToSend11nowiftru);
                                }
                                else
                                {
                                    MakeArray(AyyAvg);

                                    MakeArray(ConsTantToSend11now);
                                }
                                byte[] DataToSend88Change = ChangeName(DataToSend88);
                                MakeArray(DataToSend88Change);
                                MakeArray(OB);
                                MakeArray(ForData88Arr);

                                if (Slope == 0)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                else if (Slope == 1)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                MakeArray(ZZ);
                                MakeArray(OverlapArr);
                                dualChannelCounter++;
                                if (dualChannelCounter == 2)
                                    dualChannelCounter = 0;
                                if (Measure == 0 && LinesOfResolutin == 0)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0xCC, 0x1B, 0xCD };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 1)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x94, 0x01, 0x1B, 0xF2, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 2)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x24, 0x03, 0x1B, 0xF4, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 3)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x44, 0x06, 0x1B, 0xF6, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 4)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x84, 0x0C, 0x1B, 0xF8, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 5)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x19, 0x1B, 0xFA, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 0 && LinesOfResolutin == 6)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x32, 0x1B, 0xFC, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                            } while (dualChannelCounter == 1);
                            PointCounter++;
                        }
                        else if (Measure == 1)
                        {
                            dualChannelCounter = 0;

                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }
                            do
                            {
                                MakeArray(StartDataToSend22);
                                MakeArray(FirstByteArr);
                                MakeArray(SecondByteArr);
                                MakeArray(StartDataToSend3ForDualChannel);
                                byte[] aaa = new byte[1];
                                aaa[0] = Convert.ToByte(0x02 + PointCounter);
                                if (aaa[0] == 0x1b)
                                {
                                    byte[] aaa11 = new byte[1];
                                    aaa11[0] = Convert.ToByte(0);
                                    MakeArray(aaa11);
                                }
                                else
                                {
                                    MakeArray(aaa);
                                }
                                if (dualChannelCounter == 0)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter0);
                                else if (dualChannelCounter == 1)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter1);

                                byte[] DataToSend4Change = ChangeName(DataToSend4);
                                MakeArray(DataToSend4Change);
                                MakeArray(OB);
                                MakeArray(ForData4Arr);
                                byte[] DataToSend5Change = ChangeName(DataToSend5);
                                MakeArray(DataToSend5Change);
                                MakeArray(OB);
                                MakeArray(ForData5Arr);
                                byte[] DataToSend6Change = ChangeName(DataToSend6);
                                MakeArray(DataToSend6Change);
                                MakeArray(OB);
                                MakeArray(ForData6Arr);
                                byte[] DataToSend7Change = ChangeName(DataToSend7);
                                MakeArray(DataToSend7Change);
                                MakeArray(OB);
                                MakeArray(ForData7Arr);
                                if (ZeroFullScale != 0)
                                    MakeArray(ZeroFullScaleArr);
                                if (Filter == 0 && Unit == 0)
                                {
                                    int kk = 0;
                                }
                                else
                                {
                                    MakeArray(unitCode);
                                }
                                if (Filter != 0 || AfterUnitCode != 0 || Excep == false)
                                    MakeArray(AfterUnitCodeArr);
                                if (Filter != 0 || Excep == false)
                                    MakeArray(AfterUnitCode1Arr);

                                MakeArray(BeforeFF);
                                for (int i = 0; i < 6; i++)
                                {
                                    byte[] ff = new byte[1];
                                    ff[0] = 0xff;
                                    MakeArray(ff);
                                }
                                if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                                {
                                    if (DetectionType != 0)
                                    {
                                        MakeArray(DetctionInformationToSend);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                    else if (DetectionType == 0)
                                    {
                                        MakeArray(OB);
                                        MakeArray(ZC);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                }
                                else
                                {
                                    byte[] Cnst = { 0x00, 0x00, 0x01 };
                                    byte[] Detec = new byte[1];
                                    Detec[0] = DetctionInformationToSend[2];
                                    byte[] Cnst2 = { 0x1b, 0x08 };
                                    byte[] Cnst3 = { 0x1b, 0x08 };
                                    MakeArray(Cnst);
                                    MakeArray(Detec);
                                    MakeArray(Cnst2);
                                    MakeArray(TimeAvg);
                                    MakeArray(FirstToSendAlarm);
                                    MakeArray(SecondToSendAlarm);
                                    MakeArray(Cnst3);
                                }
                                MakeArray(ConsTantToSend);
                                MakeArray(OrderArr);
                                if (LinesOfResolutin != 2)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    if (LinesOfResolutin < 2)
                                    {
                                        ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    else if (LinesOfResolutin > 2)
                                    {
                                        ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    if (Window == 0 && Frequency == 0)
                                    {
                                        WindowZero[0] = 0x1b;
                                        WindowZero[1] = 0x03;
                                        MakeArray(WindowZero);
                                        string zerofour = "\x04";
                                    }
                                    else
                                    {
                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);
                                    }
                                }
                                if (LinesOfResolutin == 2)
                                {
                                    if (Collection != 0 && Window != 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                    if (Collection == 0 && Window != 0)
                                    {
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);
                                    }
                                    if (Collection != 0 && Window == 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);

                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                    if (Collection == 0 && Window == 0)
                                    {
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x05;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                }
                                if (OnBOth)
                                {
                                    MakeArray(AyyAvg);

                                    MakeArray(ConsTantToSend1nowiftru);
                                }
                                else
                                {
                                    MakeArray(AyyAvg);

                                    MakeArray(ConsTantToSend1now);
                                }
                                byte[] DataToSend88Change = ChangeName(DataToSend88);
                                MakeArray(DataToSend88Change);
                                MakeArray(OB);
                                MakeArray(ForData88Arr);
                                if (Slope == 0)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                else if (Slope == 1)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                MakeArray(ZZ);
                                MakeArray(OverlapArr);
                                dualChannelCounter++;
                                if (dualChannelCounter == 2)
                                    dualChannelCounter = 0;

                                if (Measure == 1 && LinesOfResolutin == 0)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0xCC, 0x1B, 0xCD, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 1 && LinesOfResolutin == 1)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x94, 0x01, 0x1B, 0xF2, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 1 && LinesOfResolutin == 2)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x24, 0x03, 0x1B, 0xF4, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 1 && LinesOfResolutin == 3)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x44, 0x06, 0x1B, 0xF6, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 1 && LinesOfResolutin == 4)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x84, 0x0c, 0x1B, 0xF8, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 1 && LinesOfResolutin == 5)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x19, 0x1B, 0xFA, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 1 && LinesOfResolutin == 6)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x04, 0x32, 0x1B, 0xFC, 0x00, 0x00, 0x34, 0x01, 0x26, 0x1B, 0xF4, 0x1B, 0x05 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length + 1);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                            } while (dualChannelCounter == 1);
                            PointCounter++;
                        }
                        else if (Measure == 2)
                        {
                            dualChannelCounter = 0;

                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            byte[] ZT = new byte[1];
                            ZT[0] = Convert.ToByte(0x03);
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }
                            do
                            {
                                MakeArray(StartDataToSend22);
                                MakeArray(FirstByteArr);
                                MakeArray(SecondByteArr);
                                MakeArray(StartDataToSend3ForDualChannel);
                                byte[] aaa = new byte[1];
                                aaa[0] = Convert.ToByte(0x02 + PointCounter);
                                if (aaa[0] == 0x1b)
                                {
                                    byte[] aaa11 = new byte[1];
                                    aaa11[0] = Convert.ToByte(0);
                                    MakeArray(aaa11);
                                }
                                else
                                {
                                    MakeArray(aaa);
                                }
                                if (dualChannelCounter == 0)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter0);
                                else if (dualChannelCounter == 1)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter1);

                                byte[] DataToSend4Change = ChangeName(DataToSend4);
                                MakeArray(DataToSend4Change);
                                MakeArray(OB);
                                MakeArray(ForData4Arr);
                                byte[] DataToSend5Change = ChangeName(DataToSend5);
                                MakeArray(DataToSend5Change);
                                MakeArray(OB);
                                MakeArray(ForData5Arr);
                                byte[] DataToSend6Change = ChangeName(DataToSend6);
                                MakeArray(DataToSend6Change);
                                MakeArray(OB);
                                MakeArray(ForData6Arr);
                                byte[] DataToSend7Change = ChangeName(DataToSend7);
                                MakeArray(DataToSend7Change);
                                MakeArray(OB);
                                MakeArray(ForData7Arr);
                                int kk = 0;
                                if (ZeroFullScale != 0)
                                    MakeArray(ZeroFullScaleArr);
                                if (Filter == 0 && Unit == 0)
                                {
                                    kk = 1;
                                    MakeArray(OB);
                                    MakeArray(ZT);
                                }
                                else
                                {
                                    MakeArray(unitCode);
                                }
                                if ((Filter != 0 || AfterUnitCode != 0 || Excep == false) && kk == 0)
                                    MakeArray(AfterUnitCodeArr);
                                if ((Filter != 0 || Excep == false) && kk == 0)
                                    MakeArray(AfterUnitCode1Arr);
                                MakeArray(BeforeFF);
                                for (int i = 0; i < 6; i++)
                                {
                                    byte[] ff = new byte[1];
                                    ff[0] = 0xff;
                                    MakeArray(ff);
                                }
                                if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                                {
                                    if (DetectionType != 0)
                                    {
                                        MakeArray(DetctionInformationToSend);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                    else if (DetectionType == 0)
                                    {
                                        MakeArray(OB);
                                        MakeArray(ZC);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                }
                                else
                                {
                                    byte[] Cnst = { 0x00, 0x00, 0x01 };
                                    byte[] Detec = new byte[1];
                                    Detec[0] = DetctionInformationToSend[2];
                                    byte[] Cnst2 = { 0x1b, 0x08 };
                                    byte[] Cnst3 = { 0x1b, 0x08 };
                                    MakeArray(Cnst);
                                    MakeArray(Detec);
                                    MakeArray(Cnst2);
                                    MakeArray(TimeAvg);
                                    MakeArray(FirstToSendAlarm);
                                    MakeArray(SecondToSendAlarm);
                                    MakeArray(Cnst3);
                                }
                                MakeArray(ConsTantToSend);
                                MakeArray(OrderArr);


                                if (LinesOfResolutin != 2)
                                {
                                    MakeArray(ZZ);
                                    MakeArray(ToSendAfterOrderArr);
                                    if (LinesOfResolutin < 2)
                                    {
                                        ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    else if (LinesOfResolutin > 2)
                                    {
                                        ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    if (Window == 0 && Frequency == 0)
                                    {
                                        WindowZero[0] = 0x1b;
                                        WindowZero[1] = 0x03;
                                        MakeArray(WindowZero);
                                        string zerofour = "\x04";
                                    }
                                    else
                                    {
                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);
                                    }
                                }
                                if (LinesOfResolutin == 2)
                                {
                                    if (Collection != 0 && Window != 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                    if (Collection == 0 && Window != 0)
                                    {
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);
                                    }
                                    if (Collection != 0 && Window == 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                    if (Collection == 0 && Window == 0)
                                    {
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x05;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                }
                                if (OnBOth)
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend11nowiftru);
                                }
                                else
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend11now);
                                }
                                byte[] DataToSend88Change = ChangeName(DataToSend88);
                                MakeArray(DataToSend88Change);
                                MakeArray(OB);
                                MakeArray(ForData88Arr);

                                if (Slope == 0)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                else if (Slope == 1)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                MakeArray(ZZ);
                                MakeArray(OverlapArr);
                                dualChannelCounter++;
                                if (dualChannelCounter == 2)
                                    dualChannelCounter = 0;
                                if (Measure == 2 && LinesOfResolutin == 0)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x02, 0x1B, 0xF3, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 1)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x04, 0x1B, 0xF5, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 2)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x08, 0x1B, 0xF7, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 3)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x10, 0x1B, 0xF9, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 4)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x20, 0x1B, 0xFB, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 5)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x40, 0x1B, 0xFD, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                                if (Measure == 2 && LinesOfResolutin == 6)
                                {
                                    byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x80, 0x1B, 0xFF, 0x00, 0x00 };
                                    MakeArray(FinalEnd);
                                    Array.Resize(ref FinalByteArr, FinalEnd.Length);
                                    for (int resctr = 0; resctr < FinalEnd.Length; resctr++)
                                    {
                                        FinalByteArr[resctr] = FinalEnd[resctr];
                                    }
                                }
                            } while (dualChannelCounter == 1);
                            PointCounter++;
                        }
                        else if (Measure == 3)
                        {
                            dualChannelCounter = 0;

                            byte[] OB = new byte[1];
                            OB[0] = Convert.ToByte(0x1b);
                            byte[] ZC = new byte[1];
                            ZC[0] = Convert.ToByte(0x0c);
                            byte[] ZZ = new byte[1];
                            ZZ[0] = Convert.ToByte(0x00);
                            byte[] ZF = new byte[1];
                            ZF[0] = Convert.ToByte(0x04);
                            byte[] TZ = new byte[1];
                            TZ[0] = Convert.ToByte(0x30);
                            if (PointCounter == 0 && same == false)
                            {
                                MakeArray(StartDataToSend1);
                                MakeArray(Entrance);
                                MakeArray(StartDataToSend2);
                            }

                            do
                            {
                                MakeArray(StartDataToSend22);
                                MakeArray(FirstByteArr);
                                MakeArray(SecondByteArr);
                                MakeArray(StartDataToSend3ForDualChannel);
                                byte[] aaa = new byte[1];
                                aaa[0] = Convert.ToByte(0x02 + PointCounter);
                                if (aaa[0] == 0x1b)
                                {
                                    byte[] aaa11 = new byte[1];
                                    aaa11[0] = Convert.ToByte(0);
                                    MakeArray(aaa11);
                                }
                                else
                                {
                                    MakeArray(aaa);
                                }
                                if (dualChannelCounter == 0 || dualChannelCounter == 2)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter0);
                                else if (dualChannelCounter == 1 || dualChannelCounter == 3)
                                    MakeArray(StartDataToSend3ForDualChannelAndCounter1);

                                byte[] DataToSend4Change = ChangeName(DataToSend4);
                                MakeArray(DataToSend4Change);
                                MakeArray(OB);
                                MakeArray(ForData4Arr);
                                byte[] DataToSend5Change = ChangeName(DataToSend5);
                                MakeArray(DataToSend5Change);
                                MakeArray(OB);
                                MakeArray(ForData5Arr);
                                byte[] DataToSend6Change = ChangeName(DataToSend6);
                                MakeArray(DataToSend6Change);
                                MakeArray(OB);
                                MakeArray(ForData6Arr);
                                byte[] DataToSend7Change = ChangeName(DataToSend7);
                                MakeArray(DataToSend7Change);
                                MakeArray(OB);
                                MakeArray(ForData7Arr);
                                if (ZeroFullScale != 0)
                                    MakeArray(ZeroFullScaleArr);
                                if (Filter == 0 && Unit == 0)
                                {
                                    int kk = 0;
                                }
                                else
                                {
                                    MakeArray(unitCode);
                                }
                                if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                {
                                    byte[] sennd = { 0x30, 0x00, 0x05, 0x00 };
                                    MakeArray(sennd);
                                }
                                else
                                {
                                    if (Filter != 0 || AfterUnitCode != 0)
                                        MakeArray(AfterUnitCodeArr);
                                    if (Filter != 0)
                                        MakeArray(AfterUnitCode1Arr);
                                    if (Filter == 0)
                                    {
                                        MakeArray(TZ);
                                        MakeArray(ZZ);
                                    }
                                    MakeArray(BeforeFF);
                                }

                                for (int i = 0; i < 6; i++)
                                {
                                    byte[] ff = new byte[1];
                                    ff[0] = 0xff;
                                    MakeArray(ff);
                                }
                                if ((Alarm1 == null && Alarm2 == null && Alarm3 == null) || (Alarm1 == 0 && Alarm2 == 0 && Alarm3 == 0))
                                {
                                    if (DetectionType != 0)
                                    {
                                        MakeArray(DetctionInformationToSend);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                    else if (DetectionType == 0)
                                    {
                                        MakeArray(OB);
                                        MakeArray(ZC);
                                        byte[] CCnst = { 0x1b, 0x0c };
                                        MakeArray(TimeAvg);
                                        MakeArray(CCnst);
                                    }
                                }
                                else
                                {
                                    byte[] Cnst = { 0x00, 0x00, 0x01 };
                                    byte[] Detec = new byte[1];
                                    Detec[0] = DetctionInformationToSend[2];
                                    byte[] Cnst2 = { 0x1b, 0x08 };
                                    byte[] Cnst3 = { 0x1b, 0x08 };
                                    MakeArray(Cnst);
                                    MakeArray(Detec);
                                    MakeArray(Cnst2);
                                    MakeArray(TimeAvg);
                                    MakeArray(FirstToSendAlarm);
                                    MakeArray(SecondToSendAlarm);
                                    MakeArray(Cnst3);
                                }
                                MakeArray(ConsTantToSend);
                                MakeArray(OrderArr);
                                if (LinesOfResolutin != 2)
                                {
                                    MakeArray(ZZ);
                                    byte[] sender1 = new byte[1];
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                        sender1[0] = 0x00;
                                    else
                                        sender1[0] = 0x04;
                                    MakeArray(sender1);
                                    if (LinesOfResolutin < 2)
                                    {
                                        ToSendAfterCollectionArr[0] = Convert.ToByte(LinesOfResolutin + 1);
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    else if (LinesOfResolutin > 2)
                                    {
                                        ToSendAfterCollectionArr[0] = LinesOfResolutin;
                                        MakeArray(ToSendAfterCollectionArr);
                                    }
                                    if (Window == 0 && Frequency == 0)
                                    {
                                        WindowZero[0] = 0x1b;
                                        WindowZero[1] = 0x03;
                                        MakeArray(WindowZero);
                                        string zerofour = "\x04";
                                    }
                                    else
                                    {
                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);
                                    }
                                }
                                if (LinesOfResolutin == 2)
                                {
                                    if (Collection != 0 && Window != 0)
                                    {
                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                    if (Collection == 0 && Window != 0)
                                    {
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        WindowNotZero[0] = Convert.ToByte(Window);
                                        WindowNotZero[1] = 0x00;
                                        WindowNotZero[2] = Convert.ToByte(Frequency);
                                        MakeArray(WindowNotZero);

                                    }
                                    if (Collection != 0 && Window == 0)
                                    {

                                        MakeArray(ZZ);
                                        MakeArray(ToSendAfterOrderArr);
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x03;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }

                                    if (Collection == 0 && Window == 0)
                                    {
                                        LinesFourHund[0] = 0x1b;
                                        LinesFourHund[1] = 0x05;
                                        MakeArray(LinesFourHund);
                                        byte[] frq = new byte[1];
                                        frq[0] = Convert.ToByte(Frequency);
                                        MakeArray(frq);
                                    }
                                }
                                if (OnBOth)
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend11nowiftru);
                                }
                                else
                                {
                                    MakeArray(AyyAvg);
                                    MakeArray(ConsTantToSend11now);
                                }
                                byte[] DataToSend88Change = ChangeName(DataToSend88);
                                MakeArray(DataToSend88Change);
                                MakeArray(OB);

                                MakeArray(ForData88Arr);

                                if (Slope == 0)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x1B, 0x1E, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                else if (Slope == 1)
                                {
                                    byte[] AfterEquipID = { 0x0A, 0x00, 0x01, 0x1B, 0x1C, 0x03 };
                                    MakeArray(AfterEquipID);
                                }
                                MakeArray(ZZ);
                                MakeArray(OverlapArr);
                                if (Measure == 3 && LinesOfResolutin == 0)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);
                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x02, 0x1B, 0xF3, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 1)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);
                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x04, 0x1B, 0xF5, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 2)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);
                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x08, 0x1B, 0xF7, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 3)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);
                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x10, 0x1B, 0xF9, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 4)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);

                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x20, 0x1B, 0xFB, 0x00, 0x00 };
                                        MakeArray(FinalEnd);

                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 5)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);

                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x40, 0x1B, 0xFD, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                if (Measure == 3 && LinesOfResolutin == 6)
                                {
                                    if (dualChannelCounter == 0 || dualChannelCounter == 1)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04 };
                                        MakeArray(FinalEnd);

                                    }
                                    else if (dualChannelCounter == 2 || dualChannelCounter == 3)
                                    {
                                        byte[] FinalEnd = { 0x01, 0x0A, 0x1B, 0x04, 0x33, 0x01, 0x02, 0x80, 0x1B, 0xFF, 0x00, 0x00 };
                                        MakeArray(FinalEnd);
                                    }
                                }
                                dualChannelCounter++;
                                if (dualChannelCounter < 4)
                                {
                                    int kkk = 1;
                                }
                            } while (dualChannelCounter < 4);
                            PointCounter++;
                            if (dualChannelCounter == 4)
                                dualChannelCounter = 0;
                        }
                    }
                } while (Points.Length - 1 != PointCounter);
            }
            catch
            {
            }
        }

        private void MakeArray(byte[] Target)
        {
            try
            {
                Array.Resize(ref UploadArray, UploadArray.Length + Target.Length);
                for (int i = 0; i < Target.Length; i++)
                {
                    UploadArray[UpArrayCount] = Target[i];
                    UpArrayCount++;
                }
            }
            catch { }
        }

        private byte[] ChangeName(string Target)
        {
            byte[] Ans = new byte[Target.Length];
            char[] Test = Target.ToCharArray();
            try
            {
                for (int i = 0; i < Target.Length; i++)
                {
                    Ans[i] = Convert.ToByte((Test[i]));
                }
            }
            catch { }
            return Ans;
        }

        private int SumOfByteArray(byte[] a)
        {
            int SumOfBytes = 0;
            try
            {
                for (int i = 0; i < a.Length; i++)
                {
                    SumOfBytes = a[i] + SumOfBytes;
                }
            }
            catch { }
            return SumOfBytes;
        }

        int senstivityPrev = 0;
        int sensitivityvalue = 0;
        int sensitivitynext = 0;
        private void SensitivityFunction(int sensitivity)
        {
            int result = 0;
            int a = 0;
            int b = 0;
            int mulFac = 64;
            int Variable = 1;
            bool b128 = false;
            int next = 64;
            double prev = 0;
            double prevFactor = 0;
            try
            {
                int number = sensitivity;

                if (number == 0)
                {
                    result = 0;
                }
                else if (number == 1)
                {
                    result = 128;
                    next = 63;
                }
                else if (number == 2)
                {
                    result = 0;
                    next = 64;
                }
                else if (number > 2 && number <= 256)
                {
                    for (int i = 3; i <= number; i++)
                    {
                        if (i > 255)
                        {
                        }
                        if (b128)
                        {
                            result = Variable * mulFac;
                            result += 128;
                        }
                        else
                        {
                            result = Variable * mulFac;
                        }
                        if (result == 128)
                        {
                            mulFac = mulFac / 2;
                            b128 = true; Variable = 0;
                        }
                        if (result == 256)
                        {
                            result = 0;
                            mulFac = mulFac / 2;
                            b128 = false;
                            Variable = 0;
                            next++;
                        }
                        Variable++;
                    }
                }
                else
                {
                    mulFac = 1;
                    double NewMulfac = 0.5;
                    next = 67;
                    int count = 0;
                    int starter = 1;
                    int newstarter = 0;
                    Variable = 128;
                    bool bbreak = false;
                    for (int i = 256; i <= number; i++)
                    {
                        int sssssss = i;
                        prev = 256 * NewMulfac;
                        count = Convert.ToInt32((double)1 / NewMulfac);
                        if (starter == 2)
                        {
                            starter = 0;
                        }
                        if (newstarter == 2)
                        {
                            newstarter = 0;
                        }
                        for (int j = 0; j < count; j++)
                        {

                            if (i > 1020)
                            {
                            } prev = 256 * NewMulfac;
                            if (count < 4)
                            {
                                prev = prev * (j);
                            }
                            else if (count < 8)
                            {
                                prev = prev * (j + 1);
                            }
                            else if (count < 16)
                            {
                                prev = prev * (j + 1);
                            }
                            else
                            {
                            }
                            if (prev == 256)
                            {
                                if (Variable == 0)
                                {
                                    Variable += 1;
                                }
                                prev = 0;
                            }
                            if (Variable > 256)
                            {
                                Variable = 0;
                            }

                            result = Variable * mulFac;

                            if (result == 128 && i > 300 && !b128)
                            {
                                starter = 2;
                                NewMulfac = NewMulfac / 2;
                                b128 = true;
                            }
                            if (result == 256 && newstarter == 0)
                            {
                                newstarter = 2;
                                result = 0;
                                NewMulfac = NewMulfac / 2;
                                b128 = false;

                                next++;
                                i++;
                                break;
                            }
                            if (result == 256)
                            {
                                result = 0;
                            }
                            if (i == number)
                            {
                                bbreak = true;
                                break;
                            }
                            i++;
                        }
                        if (bbreak)
                        {
                            break;
                        }
                        Variable++;
                        i--;
                    }
                }
                senstivityPrev = Convert.ToInt32(prev);
                sensitivityvalue = Convert.ToInt32(result);
                sensitivitynext = Convert.ToInt32(next);
            }
            catch
            {
            }
        }


        public const string SHEXFIVE = "\x05";
        private const string SHEXFOUR = "\x04";
        public byte DataSyncWrite()
        {
            byte[] arrReceivedSix1 = new byte[1];
            try
            {
                m_objSerialPort.Read(arrReceivedSix1, 0, arrReceivedSix1.Length);
            }
            catch { }
            return (arrReceivedSix1[0]);

        }

        public byte[] SelectValueToBeSended(UInt64 target)
        {
            byte[] ans = new byte[2];
            string[] hexVal = null;
            byte[] ans1 = new byte[1];
            byte[] ans2 = new byte[1];
            try
            {
                target = target % 128;
                hexVal = DeciamlToHexadeciaml(Convert.ToInt16(target)).Split(new string[] { "," }, StringSplitOptions.None);
                if (hexVal.Length == 2)
                {
                    ans1 = Encoding.ASCII.GetBytes(hexVal[0]);
                    ans2 = Encoding.ASCII.GetBytes(hexVal[1]);
                }
                else if (hexVal.Length == 1)
                {
                    ans2 = Encoding.ASCII.GetBytes(hexVal[0]);
                    ans1[0] = Convert.ToByte(48);
                }
                ans[0] = ans1[0];
                ans[1] = ans2[0];
                if (ans[0] != 48 && ans[1] == 48)
                {
                    ans[0]--;
                    ans[1] = 70;
                }
                else
                    ans[1]--;
                if (ans[1] == 64)
                    ans[1] = 57;
            }
            catch { }
            return ans;
        }

        string MediumforStorage = null;
        public string UsbMedium
        {
            get
            {
                return MediumforStorage;
            }
            set
            {
                MediumforStorage = value;
            }
        }
        int TotalInternalTour = 0;
        int TotalCardTour = 0;
        private void UploadRoots(string Fac, string FacDis, string Equi, string EquiDis, string Comp, string CompDis, string Sub, string SubDis, string target)
        {
            string[] Points = target.Split(new string[] { "," }, StringSplitOptions.None);
            int PointCounter = 0;
            string[] Information = null;
            StringBuilder DataOfAllThePoints = new StringBuilder();
            try
            {
                Information = Points[PointCounter].Split(new string[] { "!!", "@", "#", "$", "%", "^", "&", "*", "+", "=", "<", ">", "?", "{", "}", "~", "`", "[", "]", ":", ";" }, StringSplitOptions.None);

                //int couple = m_objMainControl.Couple;                       //Couple value
                int couple = Convert.ToInt16(Information[5]);
                couple = couple * 16;
                //int DetectionType = m_objMainControl.DetectionType;         //Detection Type
                int DetectionType = Convert.ToInt16(Information[6]);
                //int Window = m_objMainControl.WindowType;
                int Window = Convert.ToInt16(Information[7]);
                //int Collection = m_objMainControl.CollectionType;
                int Collection = Convert.ToInt16(Information[11]);
                //int Frequency = m_objMainControl.Frequency;
                int Frequency = Convert.ToInt16(Information[14]);
                //int Overlap = Convert.ToInt16(m_objMainControl.Overlap);
                int Overlap = Convert.ToInt16(Information[16]);
                //int Trigger = m_objMainControl.TriggerType;
                int Trigger = Convert.ToInt16(Information[17]);
                Trigger = Trigger * 2;
                //int Slope = m_objMainControl.Slope;
                int Slope = Convert.ToInt16(Information[18]);
                //int TriggerRange = m_objMainControl.TriggerRange;
                int TriggerRange = Convert.ToInt16(Information[20]);
                TriggerRange = TriggerRange * 64;
                //int Channel = m_objMainControl.ChannelType;
                int Channel = Convert.ToInt16(Information[21]);
                int fullScale = 0;
                int FullScaleFinalVal = 0;
                //int Filter = m_objMainControl.FilterType;
                int Filter = Convert.ToInt16(Information[8]);
                int FilterType = 0;
                int MainValue = 0;
                //int Unit = m_objMainControl.UnitsMain;
                int Unit = Convert.ToInt16(Information[2]);
                byte ValForSub = 0;
                //int Measure = m_objMainControl.MeasureType;
                int Measure = Convert.ToInt16(Information[12]);
                //byte Order = Convert.ToByte(m_objMainControl.Orders);
                byte Order = Convert.ToByte(Information[15]);
                Order = Convert.ToByte(Order + 1);
                //byte LinesOfResolutin = Convert.ToByte(m_objMainControl.Resolution);
                byte LinesOfResolutin = Convert.ToByte(Information[13]);
                int BytesTotal = 0;
                //byte[] facilityName = System.Text.Encoding.ASCII.GetBytes(m_objMainControl.FacilityId);                     //factory name
                byte[] facilityName = System.Text.Encoding.ASCII.GetBytes(Fac);                     //factory name

                int FacilityNameTotal = SumOfByteArray(facilityName);

                //byte[] facilityDescription = System.Text.Encoding.ASCII.GetBytes(m_objMainControl.FacilityDescription);     //facility description
                byte[] facilityDescription = System.Text.Encoding.ASCII.GetBytes(FacDis);
                int FacilityDescTotal = SumOfByteArray(facilityDescription);

                //byte[] equipmentName = System.Text.Encoding.ASCII.GetBytes(m_objMainControl.EquipmentId);                   //Equipment Name
                byte[] equipmentName = System.Text.Encoding.ASCII.GetBytes(Equi);
                //string DataToSend88 = m_objMainControl.EquipmentId;
                string DataToSend88 = Equi;
                byte ForData88 = Convert.ToByte(0x35 - (equipmentName.Length));
                int equipmentNameTotal = SumOfByteArray(equipmentName);

                //byte[] equipmentDescription = System.Text.Encoding.ASCII.GetBytes(m_objMainControl.EquipmentDescription);
                byte[] equipmentDescription = System.Text.Encoding.ASCII.GetBytes(EquiDis);
                int equipmeneDescTotal = SumOfByteArray(equipmentDescription);

                //byte[] RouteNameBytes = System.Text.Encoding.ASCII.GetBytes(m_objMainControl.FactoryName);                  //Factory Name
                byte[] RouteNameBytes = System.Text.Encoding.ASCII.GetBytes(Fac);                  //Factory Name
                //string RouteName = m_objMainControl.FactoryName;
                string RouteName = Fac;
                int RouteNameTotal = SumOfByteArray(RouteNameBytes);




                //byte[] componentName = System.Text.Encoding.ASCII.GetBytes(m_objMainControl.ComponentId);
                byte[] componentName = System.Text.Encoding.ASCII.GetBytes(Comp);
                //string DataToSend4 = m_objMainControl.ComponentId;
                string DataToSend4 = Comp;
                byte ForData4 = Convert.ToByte(0x11 - (componentName.Length));
                int componentNameTotal = SumOfByteArray(componentName);

                //byte[] componentDescription = System.Text.Encoding.ASCII.GetBytes(m_objMainControl.ComponentDescription);
                byte[] componentDescription = System.Text.Encoding.ASCII.GetBytes(CompDis);
                int componentdescTotal = SumOfByteArray(componentDescription);

                //byte[] subcomponentName = System.Text.Encoding.ASCII.GetBytes(m_objMainControl.SubComponentID);
                byte[] subcomponentName = System.Text.Encoding.ASCII.GetBytes(Sub);
                //string DataToSend6 = m_objMainControl.SubComponentID;
                string DataToSend6 = Sub;
                byte ForData6 = Convert.ToByte(0x11 - (subcomponentName.Length));
                int subcomponentNameTotal = SumOfByteArray(subcomponentName);

                //byte[] subcomponentDescription = System.Text.Encoding.ASCII.GetBytes(m_objMainControl.SubComponentDescription);

                byte[] subcomponentDescription = System.Text.Encoding.ASCII.GetBytes(SubDis);
                int subcomponentdescTotal = SumOfByteArray(subcomponentDescription);
                string[] ptName = Information[0].Split(new string[] { "|" }, StringSplitOptions.None);
                //byte[] PointName = System.Text.Encoding.ASCII.GetBytes(m_objMainControl.PointId);
                byte[] PointName = System.Text.Encoding.ASCII.GetBytes(ptName[0]);
                //string DataToSend5 = m_objMainControl.PointId;
                string DataToSend5 = ptName[0];
                byte ForData5 = Convert.ToByte(0x11 - (PointName.Length));
                int PointNameTotal = SumOfByteArray(PointName);
                byte[] PointDesc = System.Text.Encoding.ASCII.GetBytes(ptName[1]);
                string DataToSend7 = ptName[1];
                fullScale = Convert.ToInt16(Information[3]);
                if (fullScale == 0 && Unit != 2 && Unit != 4 && Unit != 6 && Unit != 8 && Unit != 10)
                    ValForSub = 0x27;
                else

                    ValForSub = 0x26;

                byte ForData7 = Convert.ToByte(ValForSub - (PointDesc.Length));
                int PointDescTotal = SumOfByteArray(PointDesc);
                byte DataToSend8 = Convert.ToByte(fullScale);

                if (Unit == 0)
                {
                    fullScale = Convert.ToInt16(Information[3]);
                    MainValue = 217;
                    FullScaleFinalVal = fullScale;
                    if (fullScale == 0)
                        ValForSub = 0x29;
                    else
                        ValForSub = 0x26;
                }
                if (Unit == 1)
                {
                    fullScale = Convert.ToInt16(Information[3]);
                    MainValue = 218;
                    FullScaleFinalVal = fullScale;
                    if (fullScale == 0)
                        ValForSub = 0x27;
                    else
                        ValForSub = 0x26;
                }
                if (Unit == 2)
                {
                    fullScale = Convert.ToInt16(Information[3]);
                    MainValue = 234;
                    FullScaleFinalVal = fullScale;
                    if (fullScale == 0)
                        ValForSub = 0x27;
                    else

                        ValForSub = 0x26;
                }
                if (Unit == 3)
                {
                    fullScale = Convert.ToInt16(Information[3]);
                    MainValue = 220;
                    FullScaleFinalVal = fullScale;
                    if (fullScale == 0)
                        ValForSub = 0x27;
                    else
                        ValForSub = 0x26;
                }
                if (Unit == 4)
                {
                    fullScale = Convert.ToInt16(Information[3]);
                    MainValue = 240;
                    if (fullScale <= 4)
                        FullScaleFinalVal = fullScale - 4;
                    else if (fullScale > 4)
                        FullScaleFinalVal = -4;
                    if (fullScale == 0)
                        ValForSub = 0x27;
                    else

                        ValForSub = 0x26;
                }
                if (Unit == 5)
                {
                    fullScale = Convert.ToInt16(Information[3]);
                    MainValue = 219;
                    FullScaleFinalVal = fullScale;
                    if (fullScale == 0)
                        ValForSub = 0x27;
                    else
                        ValForSub = 0x26;
                }
                if (Unit == 6)
                {
                    fullScale = Convert.ToInt16(Information[3]);
                    MainValue = 235;
                    FullScaleFinalVal = fullScale;
                    if (fullScale == 0)
                        ValForSub = 0x27;
                    else
                        ValForSub = 0x26;
                }
                if (Unit == 7)
                {
                    fullScale = Convert.ToInt16(Information[3]);
                    MainValue = 221;
                    FullScaleFinalVal = fullScale;
                    if (fullScale == 0)
                        ValForSub = 0x27;
                    else
                        ValForSub = 0x26;
                }
                if (Unit == 8)
                {
                    fullScale = Convert.ToInt16(Information[3]);
                    MainValue = 241;
                    if (fullScale <= 4)
                        FullScaleFinalVal = fullScale - 4;
                    else if (fullScale > 4)
                        FullScaleFinalVal = -4;

                    if (fullScale == 0)
                        ValForSub = 0x27;
                    else

                        ValForSub = 0x26;
                }
                if (Unit == 9)
                {
                    fullScale = Convert.ToInt16(Information[3]);
                    MainValue = 351;
                    FullScaleFinalVal = fullScale;
                    if (fullScale == 0)
                        ValForSub = 0x27;
                    else
                        ValForSub = 0x26;
                }
                if (Unit == 10)
                {
                    fullScale = Convert.ToInt16(Information[3]);
                    MainValue = 371;
                    if (fullScale <= 4)
                        FullScaleFinalVal = fullScale - 4;
                    else if (fullScale > 4)
                        FullScaleFinalVal = -4;

                    if (fullScale == 0)
                        ValForSub = 0x27;
                    else
                        ValForSub = 0x26;
                }
                byte[] unitCode = new byte[1];

                if (Unit == 1 || Unit == 2)
                    unitCode[0] = Convert.ToByte(0x01);
                else if (Unit == 3 || Unit == 4)
                    unitCode[0] = Convert.ToByte(0x03);
                else if (Unit == 5 || Unit == 6)
                    unitCode[0] = Convert.ToByte(0x02);
                else if (Unit == 7 || Unit == 8)
                    unitCode[0] = Convert.ToByte(0x04);
                else if (Unit == 9 || Unit == 10)
                    unitCode[0] = Convert.ToByte(0x05);
                else if (Unit == 0)
                    unitCode[0] = Convert.ToByte(0x00);


                byte ZeroFullScale = 0;
                if (Unit == 0 || Unit == 1 || Unit == 3 || Unit == 5 || Unit == 7 || Unit == 9)
                {
                    if (fullScale == 0)
                        ZeroFullScale = 0;
                    else if (fullScale > 0)
                        ZeroFullScale = Convert.ToByte(0 + fullScale);
                }
                if (Unit == 2 || Unit == 4 || Unit == 6 || Unit == 8 || Unit == 10)
                {
                    if (fullScale == 0)
                        ZeroFullScale = 0x10;
                    else if (fullScale > 0)
                        ZeroFullScale = Convert.ToByte(0x10 + fullScale);
                }
                byte AfterUnitCode = 0x00;
                byte AfterUnitCode1 = 0x00;
                int FilterVal = Convert.ToInt16(Information[9]);
                byte[] BeforeFF = new byte[2];

                if (Filter == 2)
                {
                    if (FilterVal == 0)
                    {
                        AfterUnitCode1 = 0x08;
                    }
                    else if (FilterVal == 1)
                    {
                        AfterUnitCode = 0x80;
                        AfterUnitCode1 = 0x08;
                    }
                    else if (FilterVal == 2)
                    {
                        AfterUnitCode = 0x00;
                        AfterUnitCode1 = 0x09;
                    }
                    BeforeFF[0] = Convert.ToByte(Measure);
                    BeforeFF[1] = 0x00;
                }
                else if (Filter == 1)
                {
                    if (FilterVal >= 0 && FilterVal <= 3)
                    {
                        AfterUnitCode1 = 0x04;
                    }
                    else if (FilterVal == 4)
                    {
                        AfterUnitCode = 0x80;
                        AfterUnitCode1 = 0x04;
                    }
                    else if (FilterVal == 5)
                    {
                        AfterUnitCode = 0x00;
                        AfterUnitCode1 = 0x05;
                    }
                    else if (FilterVal == 6)
                    {
                        AfterUnitCode = 0x80;
                        AfterUnitCode1 = 0x05;
                    }
                    else if (FilterVal == 7)
                    {
                        AfterUnitCode = 0x00;
                        AfterUnitCode1 = 0x06;
                    }
                    BeforeFF[0] = Convert.ToByte(Measure);
                    BeforeFF[1] = 0x00;
                }

                else if (Filter == 3)
                {
                    if (FilterVal >= 0 && FilterVal <= 3)
                    {
                        AfterUnitCode1 = 0x0c;
                    }
                    else if (FilterVal == 4)
                    {
                        AfterUnitCode = 0x80;
                        AfterUnitCode1 = 0x0c;
                    }
                    else if (FilterVal == 5)
                    {
                        AfterUnitCode = 0x00;
                        AfterUnitCode1 = 0x0d;
                    }
                    else if (FilterVal == 6)
                    {
                        AfterUnitCode = 0x80;
                        AfterUnitCode1 = 0x0d;
                    }
                    else if (FilterVal == 7)
                    {
                        AfterUnitCode = 0x00;
                        AfterUnitCode1 = 0x0e;
                    }
                    BeforeFF[0] = Convert.ToByte(Measure);
                    BeforeFF[1] = 0x00;
                }
                else if (Filter == 0 && Measure == 0)
                {
                    BeforeFF[0] = 0x1b;
                    BeforeFF[1] = 0x04;
                    if (Unit == 0)
                        BeforeFF[1]++;
                }
                else if (Filter == 0 && Measure > 0)
                {
                    BeforeFF[0] = Convert.ToByte(Measure);
                    BeforeFF[1] = 0x00;
                    AfterUnitCode1 = 0x00;
                }

                if (TriggerRange > 0)
                {
                    AfterUnitCode = Convert.ToByte(TriggerRange + AfterUnitCode);
                    BeforeFF[1] = 0x03;
                }
                if (Trigger > 0)
                {
                    AfterUnitCode = Convert.ToByte(Trigger + AfterUnitCode);
                    BeforeFF[1] = 0x03;
                }
                if (couple > 0)
                {
                    BeforeFF[1] = 0x03;
                    AfterUnitCode = Convert.ToByte(AfterUnitCode + couple);
                }

                byte[] DetctionInformationToSend = new byte[5];

                if (DetectionType > 0)
                {
                    DetctionInformationToSend[0] = 0x1b;
                    DetctionInformationToSend[1] = 0x03;
                    DetctionInformationToSend[2] = Convert.ToByte(DetectionType);
                    DetctionInformationToSend[3] = 0x1b;
                    DetctionInformationToSend[4] = 0x08;
                }

                byte ToSendAfterOrder = Convert.ToByte(Collection);
                byte[] ConsTantToSend = { 0x01, 0x1B, 0x0C, 0xC8, 0x42 };
                byte[] ConsTantToSend1 = { 0x1B, 0x03, 0x32, 0x73, 0x1B, 0x11 };
                byte[] ConsTantToSend11 = { 0x1B, 0x03, 0x5a, 0x1B, 0x12 };

                byte[] WindowNotZero = new byte[4];
                byte[] WindowZero = new byte[2];
                byte[] LinesFourHund = new byte[2];

                if (Filter == 0)
                {
                    FilterType = -8;
                }
                if (Filter == 1)
                {
                    FilterType = -4;
                }
                if (Filter == 3)
                {
                    FilterType = 4;
                }
                int filterFreq = 0;
                if (Filter == 2 && Convert.ToInt16(Information[9]) == 1)
                {
                    filterFreq = -127;
                }
                if (Filter == 2 && Convert.ToInt16(Information[9]) == 2)
                {
                    filterFreq = 1;
                }

                if (Filter == 1 || Filter == 3)
                {
                    if (Convert.ToInt16(Information[9]) == 4)
                    {
                        filterFreq = -127;
                    }
                    else if (Convert.ToInt16(Information[9]) == 5)
                    {
                        filterFreq = 1;
                    }
                    else if (Convert.ToInt16(Information[9]) == 6)
                    {
                        filterFreq = -126;
                    }
                    else if (Convert.ToInt16(Information[9]) == 7)
                    {
                        filterFreq = 2;
                    }
                }
                int MeasureType = 0;
                int FreqVal = 0;
                int FreqValSelect = 0;
                if (Measure == 1 || Measure == 2)
                {
                    MeasureType = 1;
                }
                if (Measure == 0 || Measure == 1)
                {
                    FreqVal = Convert.ToInt16(Information[13]);
                    if (FreqVal < 3)
                    {
                        if (FreqVal == 0)
                            FreqValSelect = -2;
                        else if (FreqVal == 1)
                            FreqValSelect = -1;
                        else if (FreqVal == 2)
                            FreqValSelect = -3;
                    }
                    else if (FreqVal > 3)
                    {
                        FreqValSelect = FreqVal - 3;
                    }
                }

                if (Measure == 2 || Measure == 3)
                {
                    if (FreqVal != 2)
                    {
                        if (FreqVal == 1)
                            FreqValSelect = 1;
                        else if (FreqVal > 2)
                            FreqValSelect = FreqVal - 1;
                    }
                }

                BytesTotal = MainValue + equipmentNameTotal + componentNameTotal + subcomponentNameTotal + PointNameTotal + PointDescTotal + couple + DetectionType + Window + Collection + Frequency + Trigger + Slope + TriggerRange + Channel + FullScaleFinalVal + FilterType + filterFreq + MeasureType + FreqValSelect + Overlap;

                byte FirstByte = 0;
                byte SecondByte = 0x00;
                if (BytesTotal >= 256)
                {
                    do
                    {
                        BytesTotal = BytesTotal - 256;
                        SecondByte++;
                    } while (BytesTotal >= 256);
                    FirstByte = Convert.ToByte(BytesTotal);
                }
                else if (BytesTotal < 256)
                {
                    FirstByte = Convert.ToByte(BytesTotal);
                }

                if (FirstByte == 0x1b)
                    FirstByte++;

                byte[] FirstQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x52, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x36, 0x36 };
                byte[] ThirdQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x4D, 0x44, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };

                byte[] FourthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };

                byte[] FourthQuestionEnd = { 0x5C, 0x74, 0x6F, 0x75, 0x72, 0x64, 0x61, 0x74, 0x61, 0x2E, 0x64, 0x61, 0x74, 0x03 };
                byte[] FifthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };

                byte[] FifthQuestionEnd = { 0x5C, 0x74, 0x6F, 0x75, 0x72, 0x69, 0x6E, 0x66, 0x6F, 0x2E, 0x64, 0x61, 0x74, 0x03 };

                byte[] SixthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                byte[] SixthQuestionEnd = { 0x5C, 0x63, 0x74, 0x72, 0x6C, 0x2E, 0x63, 0x66, 0x67, 0x03 };

                byte[] EightQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                byte[] EightQuestionEnd = { 0x5C, 0x6E, 0x6F, 0x74, 0x65, 0x2E, 0x64, 0x61, 0x74, 0x03 };

                byte[] NinthQuestion = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x30, 0x34, 0x2E, 0x01, 0x00, 0x00, 0x03, 0x35, 0x36 };

                byte[] TenthQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x50, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x54, 0x6F, 0x75, 0x72 };
                byte[] TenthQuestionEnd = { 0x5C, 0x6F, 0x66, 0x66, 0x74, 0x64, 0x61, 0x74, 0x61, 0x2E, 0x64, 0x61, 0x74, 0x03 };

                byte[] EleventhQuestion = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x44, 0x45, 0x4C, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x32, 0x33 };
                byte[] TwelevthQuestion = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x36, 0x38 };
                byte[] ThirteenthQuestion = { 0x01, 0x30, 0x32, 0x37, 0x46, 0x02, 0x30, 0x30, 0x36, 0x31, 0x00, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x94, 0x2A, 0xE4, 0x8F, 0xCC, 0xF6, 0x43, 0x8C, 0xA8, 0xF8, 0xFF, 0x01, 0x00, 0xC8, 0xFF, 0xFF, 0x20, 0x1B, 0x05 };
                byte[] ThirteenthQuestionEnd = { 0x1B, 0x03, 0x08, 0x00, 0x0B, 0x1B, 0x08, 0x07, 0x00, 0x50, 0x39, 0xF8, 0x03, 0x1B, 0x04, 0x10, 0x1B, 0x04, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x06, 0x1B, 0x03, 0x70, 0xD4, 0x0C, 0x00, 0x98, 0x72, 0x8E, 0x01, 0x24, 0xF5, 0x10, 0x0E, 0x84, 0xF5, 0x10, 0x0E, 0x60, 0x8E, 0x01, 0xCC, 0xF4, 0x10, 0x0E, 0x30, 0xDE, 0x8A, 0x01, 0x0B, 0x00, 0xFF, 0x01, 0xDC, 0xF6, 0x10, 0x0E, 0x00, 0x00, 0x10, 0x0E, 0x1B, 0x17, 0x03 };


                if (MediumforStorage == "Storage Card")
                {
                    ThirdQuestion[8] = 0x41;
                    FourthQuestion[8] = 0x41;
                    FifthQuestion[8] = 0x41;
                    SixthQuestion[8] = 0x41;
                    EightQuestion[8] = 0x41;
                    TenthQuestion[8] = 0x41;
                }

                byte[] DateQues = { 0x06, 0x01, 0x30, 0x30, 0x34, 0x41, 0x02 };
                byte[] DateQuesEnd = { 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x03 };
                byte[] DateEnd = new byte[2];
                byte[] testArr = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x35, 0x44, 0x2E, 0x01, 0x00, 0x00, 0x58, 0x02, 0x06, 0x01, 0xae, 0x07, 0x1B, 0x04, 0x02, 0x1B, 0x04, 0x4D, 0x68, 0x6C, 0x1B, 0x0E, 0x4D, 0x68, 0x6C, 0x31, 0x1B, 0x0D, 0x4D, 0x4F, 0x54, 0x4F, 0x52, 0x1B, 0x0C, 0x4D, 0x4F, 0x54, 0x4F, 0x52, 0x31, 0x1B, 0x26, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x1B, 0x03, 0x01, 0x1B, 0x08, 0x01, 0x1B, 0x0C, 0xC8, 0x42, 0x08, 0x00, 0x01, 0x1B, 0x03, 0x03, 0x04, 0x1B, 0x03, 0x32, 0x73, 0x1B, 0x11, 0x4D, 0x31, 0x32, 0x33, 0x1B, 0x31, 0x0A, 0x1B, 0x1E, 0x03, 0x00, 0x32, 0x01, 0x1B, 0x05, 0x33, 0x01, 0x24, 0x03, 0x1B, 0xF4, 0x00, 0x00, 0x03 };
                byte[] TestArr1 = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x36, 0x35, 0x2E, 0x01, 0x00, 0x00, 0x58, 0x02, 0x06, 0x01, 0xae, 0x07, 0x1B, 0x04, 0x02, 0x1B, 0x04 };
                byte[] TestArr2 = { 0x1b, 0x0e };
                byte[] TestArr3 = { 0x1b, 0x0d };
                byte[] TestArr4 = { 0x1b, 0x0c };
                byte[] TestArr5 = { 0x1b, 0x20 };

                byte[] TestArr6 = { 0x03, 0x00, 0x00, 0x08, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x1B, 0x03, 0x01, 0x1B, 0x08, 0x01, 0x1B, 0x0C, 0xC8, 0x42, 0x08, 0x00, 0x01, 0x03, 0x00, 0x00, 0x03, 0x04, 0x1B, 0x03, 0x32, 0x73, 0x1B, 0x11 };
                byte[] TestArr7 = { 0x1b, 0x22 };
                byte[] TestArr8 = { 0x0A, 0x1B, 0x1E, 0x03, 0x00, 0x32, 0x01, 0x1B, 0x05, 0x33, 0x01, 0x44, 0x06, 0x1B, 0xF6, 0x00, 0x00, 0x03 };
                byte[] Start = { 0x01, 0x30, 0x30, 0x31, 0x36, 0x02, 0x03, 0x34, 0x43 };
                byte[] DataBase = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x30, 0x45, 0x1B, 0x04, 0x08, 0x45, 0x3A, 0x5C, 0x74, 0x65, 0x73, 0x74, 0x5C, 0x01, 0x1B, 0x03, 0x03, 0x37, 0x35 };
                byte[] RouteTestName = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30, 0x31, 0x36, 0x2E, 0x01, 0x00, 0x00, 0x2F, 0x01, 0x23, 0x00, 0x68, 0x00, 0x61, 0x1B, 0x10, 0x04, 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x1B, 0x09, 0x03, 0x34, 0x42 };
                byte[] TestDate = { 0x06, 0x01, 0x30, 0x30, 0x34, 0x41, 0x02, 0x30, 0x42, 0x1F, 0x32, 0x31, 0x1F, 0x30, 0x43, 0x1F, 0x30, 0x42, 0x1F, 0x30, 0x41, 0x1F, 0x36, 0x42, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x1F, 0x00, 0x00, 0x00, 0x00, 0x03, 0x37, 0x35 };

                byte[] RouteNameToSend1 = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x30, 0x30 };
                byte[] RouteNameToSend21 = new byte[1];
                byte[] RouteNameToSend22 = new byte[1];
                byte[] RouteNameToSend3 = { 0x2E, 0x01, 0x00, 0x00, 0x2F, 0x01, 0x23, 0x00 };
                byte[] RouteNameToSend4 = { 0x00, 0x01, 0x00, 0x01, 0x00, 0x01, 0x1B, 0x09, 0x03 };
                byte[] StartDataToSend1 = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02 };
                byte[] StartDataToSend2 = { 0x2E, 0x01, 0x00, 0x00 };
                byte[] StartDataToSend22 = { 0x58, 0x02, 0x06, 0x01 };
                byte[] StartDataToSend3b = { 0x1B, 0x04 };
                byte[] StartDataToSend3 = { 0x1B, 0x04, 0x02, 0x1b, 0x04 };
                byte[] StartDataToSend3l = { 0x1B, 0x04 };
                byte[] StartDataToSend3ForDualChannel = { 0x1B, 0x04, 0x02 };
                byte[] StartDataToSend3ForDualChannelAndCounter0 = { 0x1B, 0x03, 0x20 };
                byte[] StartDataToSend3ForDualChannelAndCounter1 = { 0x00, 0x00, 0x01, 0x20 };
                byte[] ThirdQuestionEnd = new byte[2];
                byte[] FourthLastByte = new byte[2];
                byte ThirdEnd1 = 0x35;
                byte ThirdEnd2 = 0x32;
                byte FourthEnd1 = 0x30;
                byte FourthEnd2 = 0x31;
                byte FifthEnd1 = 0x31;
                byte FifthEnd2 = 0x33;
                byte[] FifthLastByte = new byte[2];
                byte SixthEnd1 = 0x34;
                byte SixthEnd2 = 0x39;
                byte[] SixthLastByte = new byte[2];
                byte EightEnd1 = 0x35;
                byte EightEnd2 = 0x33;
                byte[] EightLastByte = new byte[2];
                byte TenthEnd1 = 0x36;
                byte TenthEnd2 = 0x36;
                byte[] TenthLastByte = new byte[2];
                byte LastMiddleByte = 2;
                byte[] LastMiddleFinal = new byte[1];
                byte ThirteenEnd1 = 0x33;
                byte ThirteenEnd2 = 0x43;
                byte[] ThirteenLastByte = new byte[2];
                byte[] Tour = new byte[1];
                byte[] Tour1 = new byte[1];
                byte[] TourSingle = new byte[1];
                int RouteToSend = TotalRoutes + 1;

                if (MediumforStorage == "Storage Card")
                {
                    RouteToSend = TotalCardTour + 1;
                }
                else
                {
                    RouteToSend = TotalInternalTour + 1;
                }

                RouteNameTotal = RouteNameTotal + RouteToSend + 3;
                byte[] RouteNameMiddleBytes = new byte[2];
                RouteNameMiddleBytes[1] = 0x00;


                int bytesReadSending = 0;
                if (RouteNameBytes.Length >= 1)
                {
                    bytesReadSending = RouteNameBytes.Length;
                    bytesReadSending = bytesReadSending + 21;
                    string noOfBytes = DeciamlToHexadeciaml(bytesReadSending);
                    string[] noOfbytesTosend = null;

                    noOfbytesTosend = noOfBytes.Split(new string[] { "," }, StringSplitOptions.None);
                    RouteNameToSend21 = Encoding.ASCII.GetBytes(noOfbytesTosend[0]);
                    RouteNameToSend22 = Encoding.ASCII.GetBytes(noOfbytesTosend[1]);

                }


                while (RouteNameTotal >= 256)
                {
                    if (RouteNameTotal >= 256)
                        RouteNameTotal = RouteNameTotal - 256;
                    RouteNameMiddleBytes[1]++;

                }
                RouteNameMiddleBytes[0] = Convert.ToByte(RouteNameTotal);
                int lastByteTotal = 0;
                lastByteTotal = (RouteNameMiddleBytes[0] + 1) * 2;
                int MonitorForByte = 0;
                int MonitorForByte1 = 0;
                int addingBytes = 0;
                if (RouteNameMiddleBytes[1] == 1)
                {
                    while (lastByteTotal > 128)
                    {
                        if (lastByteTotal > 256)
                        {
                            lastByteTotal = lastByteTotal - 256;
                            MonitorForByte = 256;
                        }
                        else if (lastByteTotal > 128)
                        {
                            lastByteTotal = lastByteTotal - 128;
                            MonitorForByte1 = 128;
                        }
                    }
                    if (MonitorForByte == 256 && MonitorForByte1 == 128)
                        lastByteTotal = lastByteTotal + 1;

                    else if (MonitorForByte == 256)
                        lastByteTotal = lastByteTotal + 1;
                    else if (MonitorForByte1 == 128)
                        lastByteTotal = lastByteTotal + 1;
                    else
                        lastByteTotal = lastByteTotal - 6;
                }

                else if (RouteNameMiddleBytes[1] >= 2)
                {

                    addingBytes = RouteNameMiddleBytes[1];
                    while (lastByteTotal > 128)
                    {
                        lastByteTotal = lastByteTotal - 128;
                    }
                    lastByteTotal = lastByteTotal + addingBytes;

                }
                else if (RouteNameMiddleBytes[1] == 0)
                {

                    while (lastByteTotal > 128)
                    {
                        lastByteTotal = lastByteTotal - 128;
                    }
                    lastByteTotal = lastByteTotal;
                }


                byte[] AfterRouteName = new byte[1];

                AfterRouteName[0] = Convert.ToByte(0x11 - RouteNameBytes.Length);
                int lastByteHexTotal = 0;
                byte[] RouteNumberForRouteName = new byte[1];
                RouteNumberForRouteName[0] = Convert.ToByte(RouteToSend);
                if (lastByteTotal > 10)
                    lastByteHexTotal = lastByteTotal - 10;
                else if (lastByteTotal > 8)
                    lastByteHexTotal = lastByteTotal - 8;
                else if (lastByteTotal > 6)
                    lastByteHexTotal = lastByteTotal - 6;
                else if (lastByteTotal > 4)
                    lastByteHexTotal = lastByteTotal - 4;
                else if (lastByteTotal > 2)
                    lastByteHexTotal = lastByteTotal - 2;

                string LastbytesString = DeciamlToHexadeciaml(lastByteHexTotal);
                string[] LastBytesArrForRoute = null;
                LastBytesArrForRoute = LastbytesString.Split(new string[] { "," }, StringSplitOptions.None);
                byte[] LastByteArrForRouteName1 = new byte[1];
                byte[] LastByteArrForRouteName2 = new byte[1];
                if (LastBytesArrForRoute.Length == 2)
                {
                    LastByteArrForRouteName1 = Encoding.ASCII.GetBytes(LastBytesArrForRoute[0]);
                    LastByteArrForRouteName2 = Encoding.ASCII.GetBytes(LastBytesArrForRoute[1]);
                }
                else if (LastBytesArrForRoute.Length == 1)
                {
                    LastByteArrForRouteName1[0] = Convert.ToByte(0x30);
                    LastByteArrForRouteName2 = Encoding.ASCII.GetBytes(LastBytesArrForRoute[0]);
                }
                if (RouteToSend < 10)
                {
                    TourSingle[0] = Convert.ToByte(0x30 + RouteToSend);
                }
                else if (RouteToSend >= 10)
                {
                    int high = RouteToSend / 10;
                    int low = RouteToSend % 10;
                    Tour[0] = Convert.ToByte(0x30 + high);
                    Tour1[0] = Convert.ToByte(0x30 + low);
                }
                for (int i = 2; i <= RouteToSend; i++)
                {
                    LastMiddleByte++;
                }
                LastMiddleByte--;
                LastMiddleFinal[0] = LastMiddleByte;
                int Run = 2;
                byte lastRun = 0x00;
                int lastRunHigh = 0;
                int lastRunLow = 0;
                for (int i = 2; i <= RouteToSend; i++)
                {

                    if (RouteToSend < 10)
                    {
                        ThirdEnd2++;
                        if (ThirdEnd2 == 0x3a)
                            ThirdEnd2 = 0x41;
                    }
                    else if (RouteToSend >= 10)
                    {
                        lastRunLow = RouteToSend % 10;
                        lastRunHigh = RouteToSend / 10;
                        ThirdEnd1 = 0x30;
                        ThirdEnd2 = Convert.ToByte(48 + (lastRunLow + 2) + (lastRunHigh - 1));

                        if (ThirdEnd2 >= 0x3a)
                            ThirdEnd2 = Convert.ToByte(0x41 + (ThirdEnd2 - 0x3a));
                    }
                    Run++;
                }

                ThirdQuestionEnd[0] = ThirdEnd1;
                ThirdQuestionEnd[1] = ThirdEnd2;
                Run = 2;
                lastRun = 0x00;
                lastRunHigh = 0;
                lastRunLow = 0;
                for (int i = 2; i <= RouteToSend; i++)
                {
                    if (RouteToSend < 10)
                    {
                        FourthEnd2++;
                    }
                    else if (RouteToSend >= 10)
                    {
                        lastRunLow = RouteToSend % 10;
                        lastRunHigh = RouteToSend / 10;
                        FourthEnd1 = 0x33;
                        FourthEnd2 = Convert.ToByte(48 + (lastRunLow + 1) + (lastRunHigh - 1));

                        if (FourthEnd2 >= 0x3a)
                            FourthEnd2 = Convert.ToByte(0x41 + (FourthEnd2 - 0x3a));
                    }
                    Run++;
                    System.Diagnostics.Debug.WriteLine(FourthEnd2);
                }

                FourthLastByte[0] = FourthEnd1;
                FourthLastByte[1] = FourthEnd2;
                Run = 2;
                lastRun = 0x00;
                lastRunHigh = 0;
                lastRunLow = 0;
                for (int i = 2; i <= RouteToSend; i++)
                {
                    if (RouteToSend < 10)
                    {
                        FifthEnd2++;
                        if (FifthEnd2 == 0x3a)
                            FifthEnd2 = 0x41;
                    }
                    else if (RouteToSend >= 10)
                    {
                        lastRunLow = RouteToSend % 10;
                        lastRunHigh = RouteToSend / 10;
                        FifthEnd1 = 0x34;
                        FifthEnd2 = Convert.ToByte(48 + (lastRunLow + 3) + (lastRunHigh - 1));

                        if (FifthEnd2 >= 0x3a)
                            FifthEnd2 = Convert.ToByte(0x41 + (FifthEnd2 - 0x3a));
                    }

                    Run++;
                    System.Diagnostics.Debug.WriteLine(FifthEnd2);
                }

                FifthLastByte[0] = FifthEnd1;
                FifthLastByte[1] = FifthEnd2;
                Run = 2;
                lastRun = 0x00;


                for (int i = 2; i <= RouteToSend; i++)
                {
                    if (RouteToSend < 10)
                    {
                        SixthEnd2++;
                        if (SixthEnd2 == 0x3a)
                            SixthEnd2 = 0x41;
                        if (SixthEnd2 == 0x47)
                        {
                            SixthEnd1++;
                            SixthEnd2 = 0x30;
                        }
                    }

                    else if (RouteToSend >= 10)
                    {
                        SixthEnd2++;
                        if (SixthEnd2 == 0x3a)
                            SixthEnd2 = 0x41;

                        if (Run == 10)
                        {
                            SixthEnd1 = 0x37;
                            SixthEnd2 = 0x39;
                            if (SixthEnd2 == 0x3a)
                                SixthEnd2 = 0x41;
                        }

                        if (SixthEnd2 == 0x32)
                        {
                            lastRun++;
                            SixthEnd1 = 0x37;
                            SixthEnd2 = Convert.ToByte(0x39 + lastRun);
                        }
                        if (SixthEnd2 == 0x47)
                        {
                            SixthEnd1 = 0x30;
                            SixthEnd2 = 0x30;
                        }
                        if (Run <= 10 && SixthEnd2 == 0x47)
                        {
                            SixthEnd1 = 0x35;
                            SixthEnd2 = 0x30;
                        }
                        if (Run <= 10 && SixthEnd2 == 0x3a)
                            SixthEnd2 = 0x41;
                    }
                    Run++;
                }
                SixthLastByte[0] = SixthEnd1;
                SixthLastByte[1] = SixthEnd2;
                Run = 2;
                lastRun = 0x00;
                for (int i = 2; i <= RouteToSend; i++)
                {

                    if (RouteToSend < 10)
                    {
                        EightEnd2++;
                        if (EightEnd2 == 0x3a)
                            EightEnd2 = 0x41;
                    }
                    else if (RouteToSend > 10)
                    {
                        if (Run == 10)
                        {
                            Run = 0;
                            EightEnd1 = 0x30;
                            EightEnd2 = Convert.ToByte(51 + lastRun);
                            lastRun++;
                        }
                        EightEnd2++;
                        if (EightEnd2 == 0x3a)
                            EightEnd2 = 0x41;
                    }
                    Run++;
                    System.Diagnostics.Debug.WriteLine(FifthEnd2);
                }
                //EightEnd2--;
                EightLastByte[0] = EightEnd1;
                EightLastByte[1] = EightEnd2;


                Run = 2;
                lastRun = 0x00;
                for (int i = 2; i <= RouteToSend; i++)
                {
                    if (RouteToSend < 10)
                    {
                        TenthEnd2++;
                        if (TenthEnd2 == 0x3a)
                            TenthEnd2 = 0x41;
                    }
                    else if (RouteToSend > 10)
                    {
                        if (Run == 10)
                        {

                            Run = 0;
                            TenthEnd1 = 0x31;
                            TenthEnd2 = Convert.ToByte(54 + lastRun);

                            lastRun++;

                        }
                        TenthEnd2++;
                        if (TenthEnd2 == 0x3a)
                            TenthEnd2 = 0x41;
                    }
                    Run++;
                    System.Diagnostics.Debug.WriteLine(TenthEnd2);
                }

                TenthLastByte[0] = TenthEnd1;
                TenthLastByte[1] = TenthEnd2;

                Run = 2;
                lastRun = 0x00;
                for (int i = 2; i <= RouteToSend; i++)
                {
                    if (ThirteenEnd2 == 0x3a)
                        ThirteenEnd2 = 0x41;
                    if (ThirteenEnd2 == 0x47)
                    {
                        ThirteenEnd2 = 0x30;
                        ThirteenEnd1++;
                    }
                    ThirteenEnd2++;
                    System.Diagnostics.Debug.WriteLine(TenthEnd2);
                }
                ThirteenEnd2--;
                ThirteenLastByte[0] = ThirteenEnd1;
                ThirteenLastByte[1] = ThirteenEnd2;
                byte[] Entrance = new byte[4];

                byte[] FirstByteArr = new byte[1];
                FirstByteArr[0] = FirstByte;
                byte[] SecondByteArr = new byte[1];
                SecondByteArr[0] = SecondByte;
                byte[] ForData4Arr = new byte[1];
                ForData4Arr[0] = ForData4;
                byte[] ForData5Arr = new byte[1];
                ForData5Arr[0] = ForData5;
                byte[] ForData6Arr = new byte[1];
                ForData6Arr[0] = ForData6;
                byte[] ForData7Arr = new byte[1];
                ForData7Arr[0] = ForData7;
                byte[] ZeroFullScaleArr = new byte[1];
                ZeroFullScaleArr[0] = ZeroFullScale;
                byte[] AfterUnitCodeArr = new byte[1];
                AfterUnitCodeArr[0] = AfterUnitCode;
                byte[] AfterUnitCode1Arr = new byte[1];
                AfterUnitCode1Arr[0] = AfterUnitCode1;
                byte[] OrderArr = new byte[1];
                OrderArr[0] = Order;
                byte[] ToSendAfterOrderArr = new byte[1];
                ToSendAfterOrderArr[0] = ToSendAfterOrder;
                byte[] ToSendAfterCollectionArr = new byte[1];
                byte[] FrequencyArr = new byte[1];
                FrequencyArr[0] = Convert.ToByte(Frequency);
                byte[] ForData88Arr = new byte[1];
                ForData88Arr[0] = ForData88;
                byte[] OverlapArr = new byte[1];
                OverlapArr[0] = Convert.ToByte(Overlap);
                string OneF = "\x1f";

                int TotalReadingBytes = StartDataToSend2.Length + 1 + 2 + DataToSend88.Length + 1 + ForData88Arr.Length + ConsTantToSend1.Length + OrderArr.Length + ConsTantToSend.Length + BeforeFF.Length + 6 + AfterUnitCode1Arr.Length + AfterUnitCode1Arr.Length + ForData7Arr.Length + DataToSend7.Length + 1 + ForData6Arr.Length + DataToSend6.Length + 1 + ForData5Arr.Length + DataToSend5.Length + 1 + FirstByteArr.Length + SecondByteArr.Length + StartDataToSend3.Length + DataToSend4.Length + 1 + ForData4Arr.Length;
                if (ZeroFullScale != 0)
                    TotalReadingBytes = TotalReadingBytes + ZeroFullScaleArr.Length;

                TotalReadingBytes = TotalReadingBytes + unitCode.Length;
                if (Filter != 0 || AfterUnitCode != 0)
                    TotalReadingBytes = TotalReadingBytes + AfterUnitCodeArr.Length;
                if (DetectionType != 0)
                    TotalReadingBytes = TotalReadingBytes + DetctionInformationToSend.Length;
                else if (DetectionType == 0)
                    TotalReadingBytes = TotalReadingBytes + 2;


                if (LinesOfResolutin != 2)
                {
                    TotalReadingBytes = TotalReadingBytes + ToSendAfterOrderArr.Length;
                    if (LinesOfResolutin < 2)
                        TotalReadingBytes = TotalReadingBytes + ToSendAfterCollectionArr.Length;
                    else if (LinesOfResolutin > 2)
                        TotalReadingBytes = TotalReadingBytes + ToSendAfterCollectionArr.Length;
                    if (Window == 0 && Frequency == 0)
                    {
                        TotalReadingBytes = TotalReadingBytes + 3;

                    }
                    else
                    {
                        TotalReadingBytes = TotalReadingBytes + 4;
                    }
                }
                if (LinesOfResolutin == 2)
                {
                    if (Collection == 0 && Window == 0)
                    {
                        TotalReadingBytes = TotalReadingBytes + 2;
                        if (Frequency != 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + FrequencyArr.Length;
                        }
                        TotalReadingBytes = TotalReadingBytes + 1;
                    }
                    if (Collection != 0)
                    {
                        TotalReadingBytes = TotalReadingBytes + 4;

                        if (Frequency != 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + FrequencyArr.Length;
                        }
                        TotalReadingBytes = TotalReadingBytes + 1;
                    }
                    if (Window != 0)
                    {
                        TotalReadingBytes = TotalReadingBytes + 6;
                    }

                    if (Collection != 0 && Window != 0)
                    {
                        TotalReadingBytes = TotalReadingBytes + 2;
                        TotalReadingBytes = TotalReadingBytes + ToSendAfterOrderArr.Length;
                        if (Window == 0)
                        {
                            TotalReadingBytes = TotalReadingBytes + 2;
                            TotalReadingBytes = TotalReadingBytes + 1;

                        }
                        else
                        {
                            TotalReadingBytes = TotalReadingBytes + 4;
                        }
                    }
                }
                if (Slope == 0)
                {
                    TotalReadingBytes = TotalReadingBytes + 4;
                }
                else if (Slope == 1)
                {
                    TotalReadingBytes = TotalReadingBytes + 6;
                }

                if (Measure == 0)
                {
                    TotalReadingBytes = TotalReadingBytes + 10;
                }
                else if (Measure == 1)
                {
                    TotalReadingBytes = TotalReadingBytes + 19;
                }

                else if (Measure == 2)
                    TotalReadingBytes = TotalReadingBytes + 10;
                if ((Channel == 3 || Channel == 4) && Measure != 3)
                    TotalReadingBytes = TotalReadingBytes * 2;
                else if ((Channel == 3 || Channel == 4) && Measure == 3)
                    TotalReadingBytes = TotalReadingBytes * 4;
                string hexReadingBytes = DeciamlToHexadeciaml(TotalReadingBytes);
                string[] arr = null;

                arr = hexReadingBytes.Split(new string[] { "," }, StringSplitOptions.None);
                byte[] arrToConvert1 = new byte[1];
                byte[] arrToConvert2 = new byte[1];
                byte[] arrToConvert3 = new byte[1];
                if (arr.Length == 2)
                {
                    arrToConvert1 = Encoding.ASCII.GetBytes(arr[0]);
                    arrToConvert2 = Encoding.ASCII.GetBytes(arr[1]);

                    Entrance[0] = 0x30;
                    Entrance[1] = 0x30;
                    Entrance[2] = Convert.ToByte(arrToConvert1[0]);
                    Entrance[3] = Convert.ToByte(arrToConvert2[0]);
                }
                else if (arr.Length == 3)
                {
                    arrToConvert1 = Encoding.ASCII.GetBytes(arr[1]);
                    arrToConvert2 = Encoding.ASCII.GetBytes(arr[2]);
                    arrToConvert3 = Encoding.ASCII.GetBytes(arr[0]);

                    Entrance[0] = 0x30;
                    Entrance[1] = Convert.ToByte(arrToConvert3[0]);
                    Entrance[2] = Convert.ToByte(arrToConvert1[0]);
                    Entrance[3] = Convert.ToByte(arrToConvert2[0]);

                }
                byte Recieve = 0;
                byte[] FinalByteArr = new byte[1];
                byte[] FinalbyteEnd = new byte[2];
                byte[] DateLast = new byte[2];

                //ConnectwithINST();
                m_objSerialPort.Write(SHEXFIVE);
                Recieve = DataSyncWrite();
                int RouteSendingTimes = 0;
                RouteSendingTimes = Measure + 1;
                int ApproximateByteForDataEnd = FirstByte;

                if (Measure == 2)
                    BeforeFF[0]++;

                int plus = 0;
                string OneB = "\x1b";

                int whilecounter = 6;
                int ArrayCounter = 0;

                int totalSendings = (UploadArray.Length / 2048) + 1;
                if (Channel >= 0)
                {
                    if (PointCounter > -1)
                    {
                        if (PointCounter == 0)
                        {
                            m_objSerialPort.Write(FirstQuestion, 0, FirstQuestion.Length);
                            int sleep = 500;
                            while (true)
                            {
                                Thread.Sleep(sleep);
                                string Four = m_objSerialPort.ReadExisting();
                                if (Four.Equals(""))
                                    break;
                                string FourFinal = Four;
                                sleep = 0;

                            }
                            byte[] split = new byte[1];
                            split[0] = 0x1f;
                            m_objSerialPort.Write(SHEXSIX);
                            m_objSerialPort.Write(SHEXFIVE);
                            byte[] ZSIX = new byte[1];
                            ZSIX[0] = 0x06;
                            byte[] ZFIVE = new byte[1];
                            ZFIVE[0] = 0x05;
                            do
                            {
                                Recieve = DataSyncWrite();
                            } while (Recieve != 6);

                            plus = 0;
                            m_objSerialPort.Write(ThirdQuestion, 0, ThirdQuestion.Length);
                            plus = SumOfByteArray(ThirdQuestion);
                            if (TourSingle[0] != 0)
                            {
                                m_objSerialPort.Write(TourSingle, 0, TourSingle.Length);
                                plus = plus + SumOfByteArray(TourSingle);
                            }
                            else
                            {
                                m_objSerialPort.Write(Tour, 0, Tour.Length);
                                m_objSerialPort.Write(Tour1, 0, Tour1.Length);
                                plus = plus + SumOfByteArray(Tour);
                                plus = plus + SumOfByteArray(Tour1);
                            }
                            m_objSerialPort.Write("\x03");
                            plus = plus + 3;

                            byte[] ThreeEnd = SelectValueToBeSended(Convert.ToUInt64(plus)); ;
                            m_objSerialPort.Write(ThreeEnd, 0, ThreeEnd.Length);
                            Recieve = DataSyncWrite();
                            m_objSerialPort.Write(SHEXFIVE);
                            Recieve = DataSyncWrite();
                            plus = 0;
                            m_objSerialPort.Write(FourthQuestion, 0, FourthQuestion.Length);
                            plus = plus + SumOfByteArray(FourthQuestion);
                            if (TourSingle[0] != 0)
                            {
                                m_objSerialPort.Write(TourSingle, 0, TourSingle.Length);
                                plus = plus + SumOfByteArray(TourSingle);
                            }
                            else
                            {
                                m_objSerialPort.Write(Tour, 0, Tour.Length);
                                m_objSerialPort.Write(Tour1, 0, Tour1.Length);
                                plus = plus + SumOfByteArray(Tour);
                                plus = plus + SumOfByteArray(Tour1);
                            }
                            m_objSerialPort.Write(FourthQuestionEnd, 0, FourthQuestionEnd.Length);
                            plus = plus + SumOfByteArray(FourthQuestionEnd);

                            byte[] FourEnd = SelectValueToBeSended(Convert.ToUInt64(plus));
                            m_objSerialPort.Write(FourEnd, 0, FourEnd.Length);
                            Recieve = DataSyncWrite();
                        }
                        string EndStr = null;
                        byte[] testbyte = null;
                        int kk = ArrayCounter;
                        byte[] test1 = { 0x01 };
                        byte[] Mid = new byte[1];
                        byte[] MidPrev = new byte[1];
                        byte[] test2 = { 0x37, 0x46, 0x02 };
                        int dualSendCtr = 0;
                        int singleSendCtr = 0;
                        int tt = 0;
                        byte[] MiCobt = new byte[1];
                        byte[] MipreCobt = new byte[1];
                        byte bSingl = 0x1;
                        byte bDouble = 0x0;
                        string sSin = null;
                        string sDou = null;
                        ValForBar = 0;
                        for (int sendCtr = 0; sendCtr < totalSendings; sendCtr++)
                        {

                            if (sSin == "F")
                            {
                                bSingl = 0;
                                singleSendCtr = 0;
                                sSin = DeciamlToHexadeciaml1(bSingl + singleSendCtr);
                                MiCobt = Encoding.ASCII.GetBytes(sSin);
                                Mid[0] = MiCobt[0];

                                dualSendCtr++;
                                sDou = DeciamlToHexadeciaml1(bDouble + dualSendCtr);
                                MipreCobt = Encoding.ASCII.GetBytes(sDou);
                                MidPrev[0] = MipreCobt[0];

                            }

                            sSin = DeciamlToHexadeciaml1(bSingl + singleSendCtr);
                            MiCobt = Encoding.ASCII.GetBytes(sSin);
                            Mid[0] = MiCobt[0];
                            sDou = DeciamlToHexadeciaml1(bDouble + dualSendCtr);
                            MipreCobt = Encoding.ASCII.GetBytes(sDou);
                            MidPrev[0] = MipreCobt[0];

                            byte[] toSend = ChoosingDataValues(sendCtr);
                            tt = SumOfByteArray(toSend);
                            byte[] AfterTest2 = numberOfBytesToSend(Convert.ToUInt64(toSend.Length));
                            if (sendCtr != totalSendings - 1)
                            {
                                EndStr = "\x17";
                                tt = tt + 23;
                            }
                            else if (sendCtr == totalSendings - 1)
                            {
                                EndStr = "\x03";
                                tt = tt + 3;
                            }
                            if (sendCtr > 0)
                            {
                                m_objSerialPort.Write(test1, 0, test1.Length);
                                m_objSerialPort.Write(MidPrev, 0, MidPrev.Length);
                                m_objSerialPort.Write(Mid, 0, Mid.Length);
                                m_objSerialPort.Write(test2, 0, test2.Length);
                                if (totalSendings == sendCtr + 1)
                                {
                                    AfterTest2[3]--;
                                    AfterTest2[3]--;
                                    if (AfterTest2[3] == 64)
                                        AfterTest2[3] = 57;

                                }
                                m_objSerialPort.Write(AfterTest2, 0, AfterTest2.Length);
                                tt = tt + SumOfByteArray(test1);
                                tt = tt + SumOfByteArray(test2);
                                tt = tt + SumOfByteArray(Mid);
                                tt = tt + SumOfByteArray(MidPrev);
                                tt = tt + SumOfByteArray(AfterTest2);
                            }
                            testbyte = SelectValueToBeSended(Convert.ToUInt64(tt));
                            m_objSerialPort.Write(toSend, 0, toSend.Length);
                            m_objSerialPort.Write(EndStr);
                            m_objSerialPort.Write(testbyte, 0, testbyte.Length);
                            Recieve = DataSyncWrite();

                            singleSendCtr++;
                            ValForBar++;
                            _objMain.lblStatus.Caption = "StatusUpLoad";
                        }

                        ValForBar++;
                        _objMain.lblStatus.Caption = "TransferOngoing";
                        m_objSerialPort.Write(SHEXFIVE);
                        do
                        {
                            Recieve = DataSyncWrite();
                        } while (Recieve != 6);
                        m_objSerialPort.Write(SHEXFIVE);
                        ValForBar++;
                        Recieve = DataSyncWrite();
                        plus = 0;
                        m_objSerialPort.Write(FifthQuestion, 0, FifthQuestion.Length);
                        plus = plus + SumOfByteArray(FifthQuestion);
                        if (TourSingle[0] != 0)
                        {
                            m_objSerialPort.Write(TourSingle, 0, TourSingle.Length);
                            plus = plus + SumOfByteArray(TourSingle);
                        }
                        else
                        {
                            m_objSerialPort.Write(Tour, 0, Tour.Length);
                            m_objSerialPort.Write(Tour1, 0, Tour1.Length);
                            plus = plus + SumOfByteArray(Tour);
                            plus = plus + SumOfByteArray(Tour1);
                        }
                        m_objSerialPort.Write(FifthQuestionEnd, 0, FifthQuestionEnd.Length);
                        plus = plus + SumOfByteArray(FifthQuestionEnd);
                        byte[] FifthEnd = SelectValueToBeSended(Convert.ToUInt64(plus));
                        m_objSerialPort.Write(FifthEnd, 0, FifthEnd.Length);


                        Recieve = DataSyncWrite();
                        ValForBar++;
                        m_objSerialPort.Write(DataBase, 0, DataBase.Length);

                        Recieve = DataSyncWrite();
                        ValForBar++;
                        m_objSerialPort.Write(SHEXFIVE);
                        Recieve = DataSyncWrite();
                        ValForBar++;
                        plus = 0;
                        m_objSerialPort.Write(SixthQuestion, 0, SixthQuestion.Length);
                        plus = plus + SumOfByteArray(SixthQuestion);
                        if (TourSingle[0] != 0)
                        {
                            m_objSerialPort.Write(TourSingle, 0, TourSingle.Length);
                            plus = plus + SumOfByteArray(TourSingle);
                        }
                        else
                        {
                            m_objSerialPort.Write(Tour, 0, Tour.Length);
                            m_objSerialPort.Write(Tour1, 0, Tour1.Length);
                            plus = plus + SumOfByteArray(Tour);
                            plus = plus + SumOfByteArray(Tour1);
                        }
                        m_objSerialPort.Write(SixthQuestionEnd, 0, SixthQuestionEnd.Length);
                        plus = plus + SumOfByteArray(SixthQuestionEnd);
                        byte[] SixEnd = SelectValueToBeSended(Convert.ToUInt64(plus));
                        m_objSerialPort.Write(SixEnd, 0, SixEnd.Length);

                        Recieve = DataSyncWrite();
                        ValForBar++;
                        plus = 0;
                        byte[] RtName = System.Text.Encoding.ASCII.GetBytes(Fac);
                        int rtTotal = SumOfByteArray(RtName);
                        m_objSerialPort.Write(RouteNameToSend1, 0, RouteNameToSend1.Length);
                        m_objSerialPort.Write(RouteNameToSend21, 0, RouteNameToSend21.Length);
                        m_objSerialPort.Write(RouteNameToSend22, 0, RouteNameToSend22.Length);
                        m_objSerialPort.Write(RouteNameToSend3, 0, RouteNameToSend3.Length);
                        m_objSerialPort.Write(RouteNameMiddleBytes, 0, RouteNameMiddleBytes.Length);

                        m_objSerialPort.Write(RouteName);
                        m_objSerialPort.Write(OneB);
                        m_objSerialPort.Write(AfterRouteName, 0, AfterRouteName.Length);
                        m_objSerialPort.Write(RouteNumberForRouteName, 0, RouteNumberForRouteName.Length);

                        m_objSerialPort.Write(RouteNameToSend4, 0, RouteNameToSend4.Length);
                        plus = rtTotal + SumOfByteArray(RouteNameToSend1) + SumOfByteArray(RouteNameToSend21) + SumOfByteArray(RouteNameToSend22) + SumOfByteArray(RouteNameToSend3) + SumOfByteArray(RouteNameMiddleBytes) + 27 + SumOfByteArray(AfterRouteName) + SumOfByteArray(RouteNumberForRouteName) + SumOfByteArray(RouteNameToSend4);
                        byte[] routeNameEnd = SelectValueToBeSended(Convert.ToUInt64(plus));
                        m_objSerialPort.Write(routeNameEnd, 0, routeNameEnd.Length);

                        Recieve = DataSyncWrite();
                        ValForBar++;
                        LastByteArrForRouteName2[0]++;
                        if (LastByteArrForRouteName2[0] == 0x3a)
                            LastByteArrForRouteName2[0] = 0x41;
                        if (LastByteArrForRouteName2[0] == 0x48)
                        {
                            LastByteArrForRouteName1[0]++;
                            LastByteArrForRouteName2[0] = 0x30;
                        }
                        if (LastByteArrForRouteName1[0] == 0x3a)
                            LastByteArrForRouteName1[0] = 0x41;
                        if (LastByteArrForRouteName1[0] == 0x48)
                        {
                            LastByteArrForRouteName1[0] = 0x30;
                            LastByteArrForRouteName2[0] = 0x30;
                        }
                        whilecounter = Recieve;
                        ValForBar++;
                        plus = 0;
                        m_objSerialPort.Write(SHEXFIVE);
                        Recieve = DataSyncWrite();
                        ValForBar++;
                        m_objSerialPort.Write(EightQuestion, 0, EightQuestion.Length);
                        plus = SumOfByteArray(EightQuestion);
                        if (TourSingle[0] != 0)
                        {
                            m_objSerialPort.Write(TourSingle, 0, TourSingle.Length);
                            plus = plus + SumOfByteArray(TourSingle);
                        }
                        else
                        {
                            m_objSerialPort.Write(Tour, 0, Tour.Length);
                            m_objSerialPort.Write(Tour1, 0, Tour1.Length);
                            plus = plus + SumOfByteArray(Tour);
                            plus = plus + SumOfByteArray(Tour1);
                        }
                        m_objSerialPort.Write(EightQuestionEnd, 0, EightQuestionEnd.Length);
                        plus = plus + SumOfByteArray(EightQuestionEnd);

                        byte[] EightEnd = SelectValueToBeSended(Convert.ToUInt64(plus));

                        m_objSerialPort.Write(EightEnd, 0, EightEnd.Length);
                        Recieve = DataSyncWrite();
                        ValForBar++;
                        m_objSerialPort.Write(NinthQuestion, 0, NinthQuestion.Length);
                        Recieve = DataSyncWrite();
                        ValForBar++;
                        m_objSerialPort.Write(SHEXFIVE);
                        Recieve = DataSyncWrite();
                        ValForBar++;
                        plus = 0;
                        m_objSerialPort.Write(TenthQuestion, 0, TenthQuestion.Length);
                        plus = SumOfByteArray(TenthQuestion);
                        if (TourSingle[0] != 0)
                        {
                            m_objSerialPort.Write(TourSingle, 0, TourSingle.Length);
                            plus = plus + SumOfByteArray(TourSingle);
                        }
                        else
                        {
                            m_objSerialPort.Write(Tour, 0, Tour.Length);
                            m_objSerialPort.Write(Tour1, 0, Tour1.Length);
                            plus = plus + SumOfByteArray(Tour);
                            plus = plus + SumOfByteArray(Tour1);
                        }
                        m_objSerialPort.Write(TenthQuestionEnd, 0, TenthQuestionEnd.Length);

                        plus = plus + SumOfByteArray(TenthQuestionEnd);
                        byte[] TenthEnd = SelectValueToBeSended(Convert.ToUInt64(plus));
                        m_objSerialPort.Write(TenthEnd, 0, TenthEnd.Length);

                        Recieve = DataSyncWrite();
                        ValForBar++;
                        m_objSerialPort.Write(NinthQuestion, 0, NinthQuestion.Length);
                        Recieve = DataSyncWrite();
                        ValForBar++;
                        m_objSerialPort.Write(SHEXFIVE);
                        Recieve = DataSyncWrite();
                        ValForBar++;
                        m_objSerialPort.Write(EleventhQuestion, 0, EleventhQuestion.Length);
                        Recieve = DataSyncWrite();
                        ValForBar++;
                        m_objSerialPort.Write(TwelevthQuestion, 0, TwelevthQuestion.Length);
                        Recieve = DataSyncWrite();
                        ValForBar++;
                        plus = 0;
                        m_objSerialPort.Write(ThirteenthQuestion, 0, ThirteenthQuestion.Length);
                        plus = SumOfByteArray(ThirteenthQuestion);

                        m_objSerialPort.Write(LastMiddleFinal, 0, LastMiddleFinal.Length);
                        plus = plus + SumOfByteArray(LastMiddleFinal);
                        m_objSerialPort.Write(ThirteenthQuestionEnd, 0, ThirteenthQuestionEnd.Length);
                        plus = plus + SumOfByteArray(ThirteenthQuestionEnd);
                        byte[] ThirteenEnd = SelectValueToBeSended(Convert.ToUInt64(plus));
                        m_objSerialPort.Write(ThirteenEnd, 0, ThirteenEnd.Length);
                        ValForBar++;
                        do
                        {
                            Recieve = DataSyncWrite();
                        } while (Recieve != 6);
                        InitializeAgain();

                    }
                }
            }
            catch
            {
            }
        }

        //Initialising the instrument again
        public string[] m_sarrData = null;
        public void InitializeAgain()
        {
            byte[] Q1 = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x52, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x36, 0x36 };
            byte[] Q2 = { 0x01, 0x30, 0x30, 0x31, 0x36, 0x02, 0x03, 0x34, 0x43 };
            byte Recieve = 0;
            int strDtaLnth = 0;
            try
            {
                m_objSerialPort.Write(SHEXSIX);//Sending 06
                m_objSerialPort.Write(SHEXFIVE);//Sending 05
                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);

                m_objSerialPort.Write(SHEXFIVE);//Sending 05
                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);

                m_objSerialPort.Write(Q1, 0, Q1.Length);//Writing First Question
                int sleep = 500;
                string ConfigData = null;
                while (true)
                {
                    Thread.Sleep(sleep);
                    string sData = m_objSerialPort.ReadExisting();//Checking If Data is Present On the Port
                    ConfigData += sData;
                    if (sData != "")
                        break;
                }
                int TourMemory = 0;
                TotalInternalTour = 0;
                TotalCardTour = 0;
                byte[] config = Encoding.ASCII.GetBytes(ConfigData);
                byte[] exactConfig = MakeExactDatafrombytearray(config);



                for (int tm = 36, tmctr = 0; tmctr < 4; tm++, tmctr++)
                {
                    TourMemory += Convert.ToInt32(exactConfig[tm]);
                }

                for (int tm = 40, tmctr = 0; tmctr < 2; tm++, tmctr++)
                {
                    TotalInternalTour += Convert.ToInt32(exactConfig[tm]);
                }
                for (int tm = 42, tmctr = 0; tmctr < 2; tm++, tmctr++)
                {
                    TotalCardTour += Convert.ToInt32(exactConfig[tm]);
                }
                while (true)
                {
                    Thread.Sleep(sleep);
                    string sData = m_objSerialPort.ReadExisting();//Reading Ans Frm the Port against Question 1
                    if (sData.Equals(""))
                        break;
                    sleep = 0;
                }
                m_objSerialPort.Write(SHEXSIX);//Sending 06 as an acknowledge
                m_objSerialPort.Write(SHEXFIVE);//Sending 05
                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                m_objSerialPort.Write(Q2, 0, Q2.Length);//Sending Question 2
                sleep = 500;
                while (true)
                {
                    Thread.Sleep(sleep);
                    string sData = m_objSerialPort.ReadExisting();//Checking the presence of data on the port
                    if (sData != "")
                        break;
                }
                sleep = 500;
                strDtaLnth = 0;
                while (true)
                {
                    Thread.Sleep(sleep);
                    string sData = m_objSerialPort.ReadExisting();//Recieving the Answer against question 2
                    if (sData.Equals(""))
                        break;
                    sleep = 0;
                }
                string sFinalRoute = null;
                m_objSerialPort.Write(SHEXSIX);//Sending 06 as an acknowledge
                string sData1 = null;
                sleep = 500;
                while (true)
                {
                    Thread.Sleep(sleep);
                    sData1 = m_objSerialPort.ReadExisting();//Checking port For Data
                    if (sData1 != "")
                        break;
                }
                sFinalRoute += sData1;
                sleep = 500;
                while (true)
                {
                    Thread.Sleep(sleep);
                    sData1 = m_objSerialPort.ReadExisting();//Reciving Data Having Route Names Which are present in Instrument
                    if (sData1.Equals(""))
                        break;
                    sFinalRoute += sData1;
                    sleep = 0;
                }
                m_objSerialPort.Write(SHEXSIX);//Sending 06 as an acknowledge

                m_sarrData = sFinalRoute.Split(new char[] { '\x1f' });//Splitting the whole data with 1F for sorting the names of the routes in recieved data
                string RouteNo2 = null;
                for (int iNewTest = 1; iNewTest <= (m_sarrData.Length - 2); iNewTest += 3)
                {
                    RouteNo2 += m_sarrData[iNewTest];
                    RouteNo2 += "|";
                    RouteNo2 += m_sarrData[iNewTest + 1];
                    RouteNo2 += ",";
                }
                RouteNumbers = RouteNo2;
                RouteNames = m_sarrData;
            }
            catch { }
        }

        string[] RouteNames = null;
        private string RouteNumbers = null;
        public byte[] MakeExactDatafrombytearray(byte[] ByteArray)
        {
            UInt64 CtrForUsb = 0;
            byte[] BytesFortourData = new byte[0];
            UInt64 Uploadlength = Convert.ToUInt64(ByteArray.Length);
            try
            {
                do
                {
                    UInt64 i = CtrForUsb;
                    do
                    {
                        {
                            if (ByteArray[i] != 0x1b)
                            {
                                Array.Resize(ref BytesFortourData, BytesFortourData.Length + 1);
                                BytesFortourData[BytesFortourData.Length - 1] = ByteArray[i];
                            }
                            else
                            {
                                int ZeroCtr = Convert.ToInt32(ByteArray[i + 1]);
                                Array.Resize(ref BytesFortourData, BytesFortourData.Length + ZeroCtr);
                                i++;
                            }
                        }
                        i++;
                    }
                    while (i < Uploadlength);
                    break;
                } while (CtrForUsb < Uploadlength);
            }
            catch { }
            return BytesFortourData;
        }





        private byte[] ChoosingDataValues(int length)
        {
            byte[] FinalByte = null;

            int dataCtr = length * 2048;
            try
            {
                if ((dataCtr + 2048) < UploadArray.Length)
                {
                    for (int i = 0; i < 2048; i++)
                    {
                        Array.Resize(ref FinalByte, i + 1);
                        FinalByte[i] = UploadArray[dataCtr];
                        dataCtr++;
                    }
                }
                else
                {
                    for (int i = 0; i < UploadArray.Length; i++)
                    {
                        Array.Resize(ref FinalByte, i + 1);
                        FinalByte[i] = UploadArray[dataCtr];
                        dataCtr++;
                    }
                }
            }
            catch { }
            return FinalByte;
        }

        private byte[] numberOfBytesToSend(UInt64 target)
        {
            string[] mainStr = DeciamlToHexadeciamlUint(target).Split(new string[] { "," }, StringSplitOptions.None);
            byte[] ansbyte = new byte[4];
            byte[] test = new byte[1];
            int k = 3;
            try
            {
                for (int i = mainStr.Length - 1; i >= 0; i--)
                {
                    test = Encoding.ASCII.GetBytes(mainStr[i]);
                    ansbyte[k] = test[0];
                    k--;

                }
                for (int j = k; j >= k; j--)
                {
                    ansbyte[k] = Convert.ToByte(0x30);

                }
            }
            catch { }
            return ansbyte;
        }

        private string DeciamlToHexadeciamlUint(UInt64 number)
        {
            string[] hexvalues = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            string result = null, final = null;
            UInt64 rem = 0, div = 0;
            try
            {
                while (true)
                {
                    rem = (number % 16);
                    result += hexvalues[rem].ToString();

                    if (number < 16)
                        break;
                    result += ',';
                    number = (number / 16);
                }

                for (int i = (result.Length - 1); i >= 0; i--)
                {
                    final += result[i];
                }
            }
            catch { }
            return final;
        }
    }
}