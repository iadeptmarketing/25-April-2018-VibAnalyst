using DevExpress.XtraTreeList.Nodes;
using Iadeptmain.GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iadeptmain.Mainforms;
using System.Data.Odbc;
using Microsoft.SqlServerCe.Client;
using System.Collections;
using System.Drawing;
using System.IO;
using trial6;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DevExpress.XtraSplashScreen;



namespace Iadeptmain.Classes
{     
    public partial class UploadData
    {
        frmIAdeptMain _objMain;
        FrmPointType objpointType = null;
        frmupdownload _objupdown = null;
        RAPI _objRapiImpaq = null;
        string id=null;
        string routename=null;
        string routelevel =null;
        string routelevelid =null;
        string databasename = null;
        string Routelevelname = null;
        string date = null;
        int iSensorCtr = 1;
        //Areafields
        string iNewAreaID = null;
        string iNewAreaName = null;
        string AreaparentID = null;
        //trainfields
        string iNewTrainID = null;
        string iNewTrainName = null;
        string TrainparentID = null;


        string[] FacIds = null;
        string[] ResIds = null;
        string[] EleIds = null;
        string[] SubEleIds = null;
        string _sCurrentDatabaseName = null;
        string CrtRt = null;
        ResizeArray_Interface _ResizeArray = new ResizeArray_Control();
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

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        bool bccc = false;
        public bool CancClicked
        {
            get
            {
                return bccc;
            }
            set
            {
                bccc = value;
            }
        }
        bool bSmErr = false;
        public bool IsAnyError
        {
            get
            {
                return bSmErr;
            }
            set
            {
                bSmErr = value;
            }
        }
        int iPointCounter1 = 0;

        private string GetProperStringForNotes(string RouteName)
        {
            string TotalInformation = null;
            try
            {
                DataTable dt = new DataTable();
                dt = RouteConn.getdata(CommandType.Text, "select * from route_data where Route_Name='" + RouteName + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    string Routenm = Convert.ToString(dr["Route_Name"]);
                    string Database = Convert.ToString(dr["DatabaseName"]);
                    //string date = Convert.ToString(dr["Date"]);
                    string date = Convert.ToDateTime(Convert.ToString(dr["Date"])).ToString("dd/MM/yyyy HH:mm:ss");
                   
                    if (TotalInformation == null)
                    {
                        TotalInformation = "!" + RouteName + "@" + Database + "#" + date;
                    }
                }

            }
            catch { }
            return TotalInformation;
        }

        public void Fill_Value()
        {
            try
            {
                _objMain.lblStatus.Caption = "Status: Start Filling values";
                iPointCounter1 = 0;
                DataTable dt = new DataTable();
                dt = RouteConn.getdata(CommandType.Text, "select distinct rdd.ID,rdd.Route_Name,rdd.Route_Level,rdd.DatabaseName,rdd.Date,rd1.Type_ID from route_data rdd left join route_data1 rd1 on rdd.ID=rd1.ID  where rdd.ID='" + PublicClass.RouteId + "' order by ID asc");
                SqlceClass.executequery(CommandType.Text, "delete from plants");
                SqlceClass.executequery(CommandType.Text, "delete from trains");
                SqlceClass.executequery(CommandType.Text, "delete from areas");
                SqlceClass.executequery(CommandType.Text, "delete from machines");
                SqlceClass.executequery(CommandType.Text, "delete from points");
                foreach (DataRow dr in dt.Rows)
                {
                    id = Convert.ToString(dr["id"]);
                    routename = Convert.ToString(dr["Route_Name"]);
                    routelevel = Convert.ToString(dr["Route_Level"]);
                    routelevelid = Convert.ToString(dr["Type_Id"]);
                    databasename = Convert.ToString(dr["DatabaseName"]);
                    // Routelevelname = Convert.ToString(dr["Name"]);
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
                                insert_Plant(routelevelid);
                                break;
                            }
                        case "Area":
                            {
                                insert_Area(routelevelid);
                                break;
                            }
                        case "Train":
                            {
                                insert_Train(routelevelid);
                                break;
                            }
                        case "Machine":
                            {
                                insert_Machine(routelevelid);
                                break;
                            }
                        case "Point":
                            {
                                insert_PointValue(routelevelid);
                                break;
                            }
                    }
                }
            }
            catch (Exception ex)
            {              
            }
        }

        public void insert_Machine_Description(string Machine_id)
        {
            try
            {
                _objMain.lblStatus.Caption = "Status: Filling Machine Description Data";
                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.Text, "SELECT * FROM machine_record where Machine_ID ='" + Machine_id + "'  LIMIT 3");
                int record = 1;
                foreach (DataRow dr in dtt.Rows)
                {
                    if (record == 1)
                    {
                        SqlceClass.executequery(CommandType.Text, "update machines set description1_id = '" + Convert.ToString(dr["note_id"]) + "'  where Machine_ID ='" + Machine_id + "'  ");
                    }
                    if (record == 2)
                    {
                        SqlceClass.executequery(CommandType.Text, "update machines set description2_id = '" + Convert.ToString(dr["note_id"]) + "'  where Machine_ID ='" + Machine_id + "'  ");

                    }
                    if (record == 3)
                    {
                        SqlceClass.executequery(CommandType.Text, "update machines set description3_id = '" + Convert.ToString(dr["note_id"]) + "'  where Machine_ID ='" + Machine_id + "'  ");
                    }
                    record = record + 1;
                }

            }
            catch { }
        }

        private void insert_Machine_Record()
        {
            try
            {
                SqlceClass.executequery(CommandType.Text, "delete from machine_record");
                _objMain.lblStatus.Caption = "Status: Filling Machine Record Data";
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "Select * from machine_record");
                foreach (DataRow dr in dt.Rows)
                {
                    string v_Note_id = Convert.ToString(dr["Note_id"]);
                    string v_Machine_Id = Convert.ToString(dr["Machine_Id"]);
                    // string v_Date = Convert.ToString(dr["Date"]);
                    string v_Id = Convert.ToString(dr["Id"]);


                    //version 7
                    DateTime CentuaryBegain = new DateTime(1970, 1, 1, 5, 30, 0, 0);
                    DateTime currentDate = Convert.ToDateTime(Convert.ToString(dr["Date"]));
                    //DateTime.
                    long elapsedTicks = currentDate.Ticks - CentuaryBegain.Ticks;
                    TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                    string[] dddd = elapsedSpan.TotalSeconds.ToString().Split(new string[] { "." }, StringSplitOptions.None);
                    int iddd = Convert.ToInt32(dddd[0].ToString());


                    SqlceClass.executequery(CommandType.Text, "insert into machine_record(mr_id,record_time,note_id,machine_id)values(" + v_Id + "," + iddd + "," + v_Note_id + "," + v_Machine_Id + ")");
                }
            }
            catch { }

        }

       
         public void insert_alarms()
        {
            try
            {
                _objMain.lblStatus.Caption = "Status: Filling Alarms Data";
                DataTable dtunit = new DataTable();
                dtunit = DbClass.getdata(CommandType.Text, "select  distinct ad.* from alarms_data ad inner join type_point tp on tp.Alarm_ID=ad.Alarm_ID");
                foreach (DataRow drunit in dtunit.Rows)
                {
                    int iPointID = Convert.ToInt32(drunit["Alarm_ID"]);
                    float faccAxialHigh = (float)Convert.ToDouble(drunit["accel_a1"]);
                    float faccAxialLow = (float)Convert.ToDouble(drunit["accel_a2"]);
                    float faccHorizHigh = (float)Convert.ToDouble(drunit["accel_h1"]);
                    float faccHorizLow = (float)Convert.ToDouble(drunit["accel_h2"]);
                    float faccVerHigh = (float)Convert.ToDouble(drunit["accel_v1"]);
                    float faccVerLow = (float)Convert.ToDouble(drunit["accel_v2"]);


                    float fvelAxialHigh = (float)Convert.ToDouble(drunit["vel_a1"]);
                    float fvelAxialLow = (float)Convert.ToDouble(drunit["vel_a2"]);
                    float fvelVerHigh = (float)Convert.ToDouble(drunit["vel_v1"]);
                    float fvelVerLow = (float)Convert.ToDouble(drunit["vel_v2"]);
                    float fvelHorizHigh = (float)Convert.ToDouble(drunit["vel_h1"]);
                    float fvelHorizLow = (float)Convert.ToDouble(drunit["vel_h2"]);


                    float fDispAxialHigh = (float)Convert.ToDouble(drunit["displ_a1"]);
                    float fDispAxialLow = (float)Convert.ToDouble(drunit["displ_a2"]);
                    float fDispVerHigh = (float)Convert.ToDouble(drunit["displ_v1"]);
                    float fDispVerLow = (float)Convert.ToDouble(drunit["displ_v2"]);
                    float fDispHorizHigh = (float)Convert.ToDouble(drunit["displ_h1"]);
                    float fDispHorizLow = (float)Convert.ToDouble(drunit["displ_h2"]);

                    float fBearAxialHigh = (float)Convert.ToDouble(drunit["bearing_a1"]);
                    float fBearAxialLow = (float)Convert.ToDouble(drunit["bearing_a2"]);
                    float fBearVerHigh = (float)Convert.ToDouble(drunit["bearing_h1"]);
                    float fBearVerLow = (float)Convert.ToDouble(drunit["bearing_h2"]);
                    float fBearHorizHigh = (float)Convert.ToDouble(drunit["bearing_v1"]);
                    float fBearHorizLow = (float)Convert.ToDouble(drunit["bearing_v2"]);



                    float fcrestfactorAxialHigh = (float)Convert.ToDouble(drunit["crest_factor_a1"]);
                    float fcrestfactorAxialLow = (float)Convert.ToDouble(drunit["crest_factor_a2"]);
                    float fcrestfactorVerHigh = (float)Convert.ToDouble(drunit["crest_factor_h1"]);
                    float fcrestfactorVerLow = (float)Convert.ToDouble(drunit["crest_factor_h2"]);
                    float fcrestfactorHorizHigh = (float)Convert.ToDouble(drunit["crest_factor_v1"]);
                    float fcrestfactorHorizLow = (float)Convert.ToDouble(drunit["crest_factor_v2"]);



                    float faccch1High = (float)Convert.ToDouble(drunit["accel_ch11"]);
                    float faccch1Low = (float)Convert.ToDouble(drunit["accel_ch12"]);
                    float fvelch1High = (float)Convert.ToDouble(drunit["vel_ch11"]);
                    float fvelch1Low = (float)Convert.ToDouble(drunit["vel_ch12"]);
                    float fDispch1High = (float)Convert.ToDouble(drunit["displ_ch11"]);
                    float fDispch1Low = (float)Convert.ToDouble(drunit["displ_ch12"]);
                    float fBearch1High = (float)Convert.ToDouble(drunit["bearing_ch11"]);
                    float fBearch1Low = (float)Convert.ToDouble(drunit["bearing_ch12"]);
                    float fcrestfactorch1High = (float)Convert.ToDouble(drunit["crest_factor_ch11"]);
                    float fcrestfactorch1Low = (float)Convert.ToDouble(drunit["crest_factor_ch12"]);

                    float fTempHigh = (float)Convert.ToDouble(drunit["temperature_1"]);
                    float fTemplow = (float)Convert.ToDouble(drunit["temperature_2"]);


                    string ss = "insert into alarms(alarm_id,accel_ch11,accel_ch12,accel_a1,accel_h1,accel_v1,accel_a2,accel_h2,accel_v2,vel_ch11,vel_ch12,vel_a1,vel_h1,vel_v1,vel_a2,vel_h2,vel_v2,displ_ch11,displ_ch12,displ_a1,displ_h1,displ_v1,displ_a2,displ_h2,displ_v2,bearing_ch11,bearing_ch12,bearing_a1,bearing_h1,bearing_v1,bearing_a2,bearing_h2,bearing_v2,temperature_1,temperature_2,crest_factor_ch11,crest_factor_ch12,crest_factor_a1,crest_factor_h1 ,crest_factor_v1 ,crest_factor_a2 ,crest_factor_h2 ,crest_factor_v2 )values(" +
                    iPointID + "," + faccch1High + "," + faccch1Low + "," + faccAxialHigh + "," + faccHorizHigh + "," + faccVerHigh + "," + faccAxialLow + "," + faccHorizLow + "," + faccVerLow + "," +
                    fvelch1High + "," + fvelch1Low + "," + fvelAxialHigh + "," + fvelHorizHigh + "," + fvelVerHigh + "," + fvelAxialLow + "," + fvelHorizLow + "," + fvelVerLow + "," +
                    fDispch1High + "," + fDispch1Low + "," + fDispAxialHigh + "," + fDispHorizHigh + "," + fDispVerHigh + "," + fDispAxialLow + "," + fDispHorizLow + "," + fDispVerLow + "," +
                    fBearch1High + "," + fBearch1Low + "," + fBearAxialHigh + "," + fBearHorizHigh + "," + fBearVerHigh + "," + fBearAxialLow + "," + fBearHorizLow + "," + fBearVerLow + "," + fTempHigh + "," + fTemplow + "," +
                    fcrestfactorch1High + "," + fcrestfactorch1Low + "," + fcrestfactorAxialHigh + "," + fcrestfactorHorizHigh + "," + fcrestfactorVerHigh + "," + fcrestfactorAxialLow + "," + fcrestfactorHorizLow + "," + fcrestfactorVerLow + ")"; // for version 6 and above
                    SqlceClass.executequery(CommandType.Text, ss);

                }
            }
            catch { }

        }
        public void Inser_Measures()
        {
            string ss = "delete from measures";
            _objMain.lblStatus.Caption = "Status: Filling Measures Data";
            SqlceClass.executequery(CommandType.Text, ss);
            try
            {
              
                DataTable dtunit = new DataTable();
                dtunit = DbClass.getdata(CommandType.Text, "select pt.point_ID,pt.PointName,pt.PointType_ID from point pt inner join type_point tp on pt.PointType_ID=tp.ID where pt.PointType_ID !='0' group by pt.PointType_ID order by pt.point_ID;");
                foreach (DataRow drunit in dtunit.Rows)
                {
                    string itypeID = Convert.ToString(drunit["PointType_ID"]);
                    DataTable dtun = new DataTable();
                    dtun = DbClass.getdata(CommandType.Text, "select * from measure where Type_ID='" + itypeID + "'");
                    foreach (DataRow drun in dtun.Rows)
                    {
                        try
                        {
                            int iPointID = Convert.ToInt32(drun["ID"]);
                            byte btAcc_Filter = Convert.ToByte(drun["acc_filter"]);
                            byte btVel_Filter = Convert.ToByte((string)(drun["vel_filter"]));
                            byte btDispl_Filter = Convert.ToByte((string)(drun["displ_filter"]));
                            byte btOverall_Bearing_filter = Convert.ToByte((string)(drun["overall_bearing_filter"]));
                            byte btBearingacchp_filter = Convert.ToByte((string)(drun["bearing_acc_hp_filter"]));
                            byte btTime_Band = Convert.ToByte((string)(drun["time_band"]));
                            byte btTime_Resolution = Convert.ToByte((string)(drun["time_resoltion"]));
                            byte btTime_Overlap = Convert.ToByte((string)(drun["time_overlap"]));
                            byte btPower_Band = Convert.ToByte((string)(drun["power_band"]));
                            byte btPower_Resolution = Convert.ToByte((string)(drun["power_resolution"]));
                            byte btPower_Window = Convert.ToByte((string)(drun["power_window"]));
                            byte btPower_Average_Times = Convert.ToByte((string)(drun["power_average_times"]));
                            byte btPower_Overlap = Convert.ToByte((string)(drun["power_overlap"]));
                            int btPower_Zoom = Convert.ToInt32(drun["power_zoom"]);
                            float fPower_Zoom_Startfreq = (float)(Convert.ToDouble(drun["power_zoom_startfeq"]));
                            byte btDemodulate_Band = Convert.ToByte((string)(drun["demodulate_band"]));
                            byte btDemodulate_Resolution = Convert.ToByte((string)(drun["demodulate_resolution"]));
                            byte btDemodulate_Window = Convert.ToByte((string)(drun["demodulate_window"]));
                            byte btDemodulate_Average_Times = Convert.ToByte((string)(drun["demodulate_average_times"]));
                            byte btDemodulate_Filter = Convert.ToByte((string)(drun["demodulate_filter"]));
                            byte btPower_Multiple_Bands = Convert.ToByte((string)(drun["power_multiple"]));
                            byte btPower_Band1 = Convert.ToByte((string)(drun["power_band1"]));
                            byte btPower_Resolution1 = Convert.ToByte((string)(drun["power_resolution1"]));
                            byte btCrest_Factor_Filter = Convert.ToByte((string)(drun["crest_factor_filter"]));
                            byte btOrderTraceAvgTimes = Convert.ToByte((string)(drun["ordertrace_average_times"]));

                            byte btOrderTraceResolution = Convert.ToByte((string)(drun["ordertrace_resolution"]));
                            float btOrderTraceOrder = (float)(Convert.ToDouble(drun["ordertrace_order"]));
                            byte btOrderTracetriggerSlope = Convert.ToByte((string)(drun["ordertrace_trigger_slope"]));
                            byte btPower2_Band = Convert.ToByte((string)(drun["power2_band"]));
                            byte btPower2_Resolution = Convert.ToByte((string)(drun["power2_resolution"]));
                            byte btPower2_Band1 = Convert.ToByte((string)(drun["power2_band1"]));
                            byte btPower2_Resolution1 = Convert.ToByte((string)(drun["power2_resolution1"]));

                            byte btPower3_Band = Convert.ToByte((string)(drun["power3_band"]));
                            byte btPower3_Resolution = Convert.ToByte((string)(drun["power3_resolution"]));
                            byte btPower3_Band1 = Convert.ToByte((string)(drun["power3_band1"]));
                            byte btPower3_Resolution1 = Convert.ToByte((string)(drun["power3_resolution1"]));
                            byte btcepstrumBand = Convert.ToByte((string)(drun["cepstrum_band"]));
                            byte btcepstrumResolution = Convert.ToByte((string)(drun["cepstrum_resolution"]));
                            byte btcepstrumWindow = Convert.ToByte((string)(drun["cepstrum_window"]));
                            byte btcepstrumAvgTimes = Convert.ToByte((string)(drun["cepstrum_average_times"]));
                            byte btcepstrumOverlap = Convert.ToByte((string)(drun["cepstrum_overlap"]));
                            int btcepstrumZoom = Convert.ToInt32(drun["cepstrum_zoom"]);
                            float fcepstrumStartFreq = (float)(Convert.ToDouble(drun["cepstrum_zoom_startfeq"]));

                            string yy = "insert into measures(measure_id,acc_filter,vel_filter,displ_filter,overall_bearing_filter,time_band,time_resolution,time_overlap,power_band,power_resolution,power_window,power_average_times,power_overlap,power_zoom,power_zoom_startfreq,demodulate_band,demodulate_resolution,demodulate_window,demodulate_average_times,demodulate_filter,power_multiple,power_band1,power_resolution1,crest_factor_filter, ordertrace_average_times, ordertrace_resolution, ordertrace_order, ordertrace_trigger_slope, power2_band, power2_resolution, power2_band1, power2_resolution1, power3_band, power3_resolution, power3_band1, power3_resolution1, cepstrum_band, cepstrum_resolution, cepstrum_window, cepstrum_average_times, cepstrum_overlap, cepstrum_zoom, cepstrum_zoom_startfreq,bearing_acc_hp_filter)values(" + iPointID
                                + ",'" + btAcc_Filter + "','" + btVel_Filter + "','" + btDispl_Filter + "','" + btOverall_Bearing_filter + "','" + btTime_Band + "'," + btTime_Resolution + ",'" + btTime_Overlap + "'," + btPower_Band + "," + btPower_Resolution + "," + btPower_Window + "," + btPower_Average_Times + "," + btPower_Overlap + "," + btPower_Zoom + "," + fPower_Zoom_Startfreq + "," + btDemodulate_Band + "," + btDemodulate_Resolution + "," + btDemodulate_Window + "," + btDemodulate_Average_Times + "," + btDemodulate_Filter + "," + btPower_Multiple_Bands + "," + btPower_Band1 + "," + btPower_Resolution1 + ",'" + btCrest_Factor_Filter + "'," + btOrderTraceAvgTimes + "," + btOrderTraceResolution + "," + btOrderTraceOrder + "," + btOrderTracetriggerSlope + "," + btPower2_Band + "," + btPower2_Resolution + "," + btPower2_Band1 + "," + btPower2_Resolution1 + "," + btPower3_Band + "," + btPower3_Resolution + "," + btPower3_Band1 + "," + btPower3_Resolution1 + "," + btcepstrumBand + "," + btcepstrumResolution + "," + btcepstrumWindow + "," + btcepstrumAvgTimes + "," + btcepstrumOverlap + "," + btcepstrumZoom + "," + fcepstrumStartFreq + ",'" + btBearingacchp_filter + "')";
                            SqlceClass.executequery(CommandType.Text, yy);
                        }
                        catch { }
                    }
                }
            }
            catch (SqlCeException ex)
            {
                throw ex;
            }
        }

        int powermeasurement;
        public void Inser_Measuresforunschedule(int type) 
        {
            _objMain.lblStatus.Caption = "Status: Filling Measures for Unschedule Point Data";
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

                    DbClass.executequery(CommandType.Text, "Insert Into measure(acc_filter, vel_filter , displ_filter, overall_bearing_filter, crest_factor_filter,bearing_acc_hp_filter, time_band, time_resoltion, time_overlap,Date,Sensordir, sensor_id , TemperatureID, power_band  ,power_resolution   ,power_band1 ,power_resolution1  ,power2_band   ,power2_resolution, power2_band1,power2_resolution1,power3_band,power3_resolution,power3_band1,power3_resolution1, power_window,power_overlap,power_average_times,power_zoom,power_zoom_startfeq,cepstrum_band, cepstrum_resolution,cepstrum_window,cepstrum_average_times,cepstrum_overlap,cepstrum_zoom,cepstrum_zoom_startfeq,demodulate_band,demodulate_resolution,demodulate_window,demodulate_average_times ,demodulate_filter,ordertrace_average_times,ordertrace_resolution,ordertrace_order,ordertrace_trigger_slope,power_multiple,Type_ID)values(  '" + acc_filter+ "' ,'" + vel_filter + "' ,'" + displ_filter+ "' ,'" + overallbearhp_filter+ "' ,'" + cfFilter + "' ,'" + bearhp_filter+ "' ,'" + timeband+ "' ,'" + timeResol+ "' ,'" + timeoverlap+ "' ,'" + PublicClass.GetDatetime()+ "' ,'" + SensorDir+ "' ,'" + sensor_id+ "' ,'" + temperature_id+ "' ,'" + pbgroup1+ "' ,'" + pwrResG1+ "' ,'" + pwrB1G1+ "' ,'" + pwrRes1G1+ "' ,'" + pwrB2G1+ "' ,'" + pwrRes2G2+ "' ,'" + pwr2B1G2+ "' ,'" + pwr2Res1G1+ "' ,'" + pwr3BG3+ "' ,'" + pwr3Res3G3+ "' ,'" + pwr3B1G3+ "' ,'" + pwr3Res1G3+ "' ,'" + pwrWindow+ "' ,'" + pwrOverlap+ "' ,'" + pwrAvgTime+ "' ,'" + pwrZoom+ "' ,'" + pwrZoomSTF+ "' ,'" + cepBand+ "' ,'" + cepResol+ "' ,'" + cepWindow+ "' ,'" + cepAvgTime+ "' ,'" + cepOverlap+ "' ,'" + cepZoom+ "' ,'" + cepZoomSTF+ "' ,'" + demoBand+ "' ,'" + demoResol+ "' ,'" + demoWindow+ "' ,'" + demoAvgTime+ "' ,'" + demofilter+ "' ,'" + otveragetimes	+ "' ,'" + otresolution+ "' ,'" + otorder+ "' ,'" + ottriggerslope+ "' ,'" + pwrmultiple+ "' ,'" + type + "')");

                }

            }
            catch { }
        }



        private void CalcGeneralPageVariables2(int Target,int type)
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
                        DbClass.executequery(CommandType.Text, "insert into  measure_type  (  OAcc, OVel, ODisp, OBear, OTWF, OPS, ODS, Temp, Process, crestfactor, Ordertrace, Cepstrum , Type_ID ,CalcMeasure  ) values('" + setvalue(OvAcc) + "','" + setvalue(OvVel) + "','" + setvalue(OvDisp) + "','" + setvalue(OvBear) + "','" + setvalue(TWave) + "','" + setvalue(PSpec) + "','" + setvalue(DSpec) + "','" + setvalue(temp) + "','" + setvalue(process) + "','" + setvalue(crestfactorCheck) + "','" + setvalue(ODT) + "','" + setvalue(Cepstr) + "','" +type + "','" + Target + "')");
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
        public void ConvertPointTypeunschedule()
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
                    string PointTypeName = Convert.ToString("UnschedulePointType-" + untypeid);
                    DbClass.executequery(CommandType.Text, "Insert into type_point(Point_Name,Type_ID,Instrumentname,Alarm_ID,STDDeviationAlarm_ID,Percentage_AlarmID,Band_ID) values('" + PointTypeName + "','1','" + instname + "','" + AlarmID + "','" + sdID + "','" + perID + "','0')");
                    DataTable dt1 = DbClass.getdata(CommandType.Text, "select distinct ID from type_point where Point_name='" + PointTypeName + "'");
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        untypeid = (Convert.ToInt32(dr1["ID"]));
                    }
                }
            }
            catch { }
          
        }


        private void Insert_Bandalarms()
        {
            try
            {
                string mac1 = mac;
                int number = 0;
                string newList = "";
                foreach (string item in mac1.Split(new char[] { ',' }))
                {
                    if (number > 0)
                    {
                        newList = newList + "," + "'" + item + "'";
                    }
                    else
                    {
                        newList = "'" + item + "'";
                    }
                    number++;
                }
                _objMain.lblStatus.Caption = "Status: Filling BandAlarms Group Data";
                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.Text, "select  distinct  a.Group_id as 'BandGroupid',a.Axis_type,po.point_id ,p.id as 'pointtypeid' from  band_data a inner join type_point p on a.group_id=p.band_id inner join point po on p.id=po.pointtype_id left join machine_info mac on po.machine_id=mac.machine_id where mac.machine_id IN ("+newList+")");

                SqlceClass.executequery(CommandType.Text, "delete from  bandalarms");
                int i = 0;
                foreach (DataRow dr in dtt.Rows)
                {
                    string v_bandalarms_id = Convert.ToString(i + 1);
                    string v_bandalarms_group_id = PublicClass.DefVal(Convert.ToString(dr["BandGroupid"]).Trim(), "0");
                    string v_axis_type = PublicClass.DefVal(Convert.ToString(dr["Axis_type"]).Trim(), "0");
                    string v_point_id = PublicClass.DefVal(Convert.ToString(dr["point_id"]).Trim(), "0");
                    SqlceClass.executequery(CommandType.Text, "insert into bandalarms values ('" + v_bandalarms_id + "','" + v_bandalarms_group_id + "','" + v_axis_type + "','" + v_point_id + "') ");
                    i = i + 1;
                }
            }
            catch
            {

            }
        }      

        private void InsertbandALarms()
        {
            string ss = "delete from bandalarm";
            _objMain.lblStatus.Caption = "Status: Filling Band Alarms Data";
            SqlceClass.executequery(CommandType.Text, ss);
            try
            {
                int i = 0;
                DataTable dtunit = new DataTable();
                dtunit = DbClass.getdata(CommandType.Text, "select distinct bd.BandAlarm_Name,bd.Freq,bd.x,bd.y,bd.Group_Id from band_data bd");
                foreach (DataRow drunit in dtunit.Rows)
                {
                    string ibandID = Convert.ToString(i + 1); 
                   
                    string v_BandAlarm_Name = Convert.ToString(drunit["BandAlarm_Name"]);
                    double ibandFreq = Convert.ToDouble(drunit["Freq"]);
                    double bandX = Convert.ToDouble(drunit["x"]);
                    double bandY = Convert.ToDouble(drunit["y"]);
                    string ibandPT_ID = Convert.ToString(drunit["Group_Id"]);
                    string yy = "insert into bandalarm(bandalarm_id,bandalarm_name,Freq,alarm1,alarm2,Group_id) values(" + ibandID + ",'" + v_BandAlarm_Name + "'  ,'" + ibandFreq + "'," + bandX + "," + bandY + "," + ibandPT_ID + ")";

                    SqlceClass.executequery(CommandType.Text, yy);
                    i = i + 1;
                }
            }
            catch { }
        }
       
        private void insert_fault_freq()
        {
            string ss = "delete from point_faultfreq";
            _objMain.lblStatus.Caption = "Status: Filling Fault Frequency Data";
            SqlceClass.executequery(CommandType.Text, ss);
            try
            {
                if (_objupdown != null)
                {
                    _objupdown.ShowMessage("Status:Reading faultfreq Data");
                }
                DataTable dtunit = new DataTable();
                dtunit = DbClass.getdata(CommandType.Text, "SELECT * FROM faultfreq_data ffd inner join point_faultfreq pff on pff.FaultFreq_ID=ffd.Pf_ID");
                foreach (DataRow drunit in dtunit.Rows)
                {

                    int iPfID = Convert.ToInt32(drunit["Pf_ID"]);
                    string iPfname = Convert.ToString(drunit["pf_name"]);
                    string iPfFreq = Convert.ToString(drunit["pf_freq"]);
                    string iPfPointID = Convert.ToString(drunit["Point_ID"]);



                    string yy = "insert into point_faultfreq(pf_id,pf_name,pf_freq,point_id) values(" + iPfID + ",'" + iPfname + "'," + iPfFreq + "," + iPfPointID + ")";
                    SqlceClass.executequery(CommandType.Text, yy);
                }
            }
            catch { }
        }

        private void insert_point_record()
        {
            string ss = "delete from point_record";
            _objMain.lblStatus.Caption = "Status: Filling Point Record Data";
            SqlceClass.executequery(CommandType.Text, ss);
            try
            {
                if (_objupdown != null)
                {
                    _objupdown.ShowMessage("Status:Reading point_record Data");
                }
                DataTable dtunit = new DataTable();
                dtunit = DbClass.getdata(CommandType.Text, "SELECT * FROM point_data");
                foreach (DataRow drunit in dtunit.Rows)
                {
                    int pr_id = Convert.ToInt32(drunit["Data_id"]);
                    DateTime CentuaryBegain = new DateTime(1970, 1, 1, 5, 30, 0, 0);
                    DateTime currentDate = Convert.ToDateTime(Convert.ToString(drunit["measure_time"]));
                    long elapsedTicks = currentDate.Ticks - CentuaryBegain.Ticks;
                    TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                    string[] dddd = elapsedSpan.TotalSeconds.ToString().Split(new string[] { "." }, StringSplitOptions.None);
                    int measure_time = Convert.ToInt32(dddd[0].ToString());
                    float accel_a = (float)Convert.ToDouble(drunit["accel_a"]);
                    float accel_h = (float)Convert.ToDouble(drunit["accel_h"]);
                    float accel_v = (float)Convert.ToDouble(drunit["accel_v"]);
                    float accel_ch1 = (float)Convert.ToDouble(drunit["accel_ch1"]);

                    float vel_a = (float)Convert.ToDouble(drunit["vel_a"]);
                    float vel_h = (float)Convert.ToDouble(drunit["vel_h"]);
                    float vel_v = (float)Convert.ToDouble(drunit["vel_v"]);
                    float vel_ch1 = (float)Convert.ToDouble(drunit["vel_ch1"]);

                    float displ_a = (float)Convert.ToDouble(drunit["displ_a"]);
                    float displ_h = (float)Convert.ToDouble(drunit["displ_h"]);
                    float displ_v = (float)Convert.ToDouble(drunit["displ_v"]);
                    float displ_ch1 = (float)Convert.ToDouble(drunit["displ_ch1"]);

                    float bearing_a = (float)Convert.ToDouble(drunit["bearing_a"]);
                    float bearing_h = (float)Convert.ToDouble(drunit["bearing_h"]);
                    float bearing_v = (float)Convert.ToDouble(drunit["bearing_v"]);
                    float bearing_ch1 = (float)Convert.ToDouble(drunit["bearing_ch1"]);

                    float temperature = (float)Convert.ToDouble(drunit["temperature"]);
                    float process = (float)Convert.ToDouble(drunit["process"]);

                    float crestfactor_a = (float)Convert.ToDouble(drunit["crest_factor_a"]);
                    float crestfactor_h = (float)Convert.ToDouble(drunit["crest_factor_h"]);
                    float crestfactor_v = (float)Convert.ToDouble(drunit["crest_factor_v"]);
                    float crestfactor_ch1 = (float)Convert.ToDouble(drunit["crest_factor_ch1"]);

                    float ordertrace_Rpm = (float)Convert.ToDouble(drunit["ordertrace_rpm"]);

                    float ordertrace_a_real = (float)Convert.ToDouble(drunit["ordertrace_a_real"]);
                    float ordertrace_h_real = (float)Convert.ToDouble(drunit["ordertrace_h_real"]);
                    float ordertrace_v_real = (float)Convert.ToDouble(drunit["ordertrace_v_real"]);
                    float ordertrace_ch1_real = (float)Convert.ToDouble(drunit["ordertrace_ch1_real"]);

                    float ordertrace_a_image = (float)Convert.ToDouble(drunit["ordertrace_a_image"]);
                    float ordertrace_h_image = (float)Convert.ToDouble(drunit["ordertrace_h_image"]);
                    float ordertrace_v_image = (float)Convert.ToDouble(drunit["ordertrace_v_image"]);
                    float ordertrace_ch1_image = (float)Convert.ToDouble(drunit["ordertrace_ch1_image"]);

                    string point_id = Convert.ToString(drunit["Point_ID"]);

                    string yy = "Insert into point_record(pr_id,measure_time,accel_a,accel_h,accel_v,accel_ch1,vel_a,vel_h,vel_v,vel_ch1,displ_a,displ_h,displ_v,displ_ch1,bearing_a,bearing_h,bearing_v,bearing_ch1,temperature,process,point_id,                                        crest_factor_a,crest_factor_h,crest_factor_v,crest_factor_ch1,ordertrace_a_real,ordertrace_h_real,ordertrace_v_real,ordertrace_ch1_real,ordertrace_a_image,ordertrace_h_image,ordertrace_v_image,ordertrace_ch1_image,ordertrace_Rpm) values(" + pr_id + "," + measure_time + "," + accel_a + "," + accel_h + "," + accel_v + "," + accel_ch1 + "," + vel_a + "," + vel_h + "," + vel_v + "," + vel_ch1 + "," + displ_a + "," + displ_h + "," + displ_v + "," + displ_ch1 + "," + bearing_a + "," + bearing_h + "," + bearing_v + "," + bearing_ch1 + "," + temperature + "," + process + "," + point_id + "," + crestfactor_a + "," + crestfactor_h + "," + crestfactor_v + "," + crestfactor_ch1 + "," + ordertrace_a_real + "," + ordertrace_h_real + "," + ordertrace_v_real + "," + ordertrace_ch1_real + "," + ordertrace_a_image + "," + ordertrace_h_image + "," + ordertrace_v_image + "," + ordertrace_ch1_image + "," + ordertrace_Rpm + ")";
                    SqlceClass.executequery(CommandType.Text, yy);

                }
            }
            catch { }


        }

        private void insert_routes()
        {
            string ss = "delete from routes";
            _objMain.lblStatus.Caption = "Status: Filling Route Information Data";
            SqlceClass.executequery(CommandType.Text, ss);
            try
            {
                if (_objupdown != null)
                {
                    _objupdown.ShowMessage("Status:Reading Routes Data");
                }
                try
                {
                    //version 7
                    DateTime CentuaryBegain = new DateTime(1970, 1, 1, 5, 30, 0, 0);
                    DateTime currentDate = DateTime.Now;
                    //DateTime.
                    long elapsedTicks = currentDate.Ticks - CentuaryBegain.Ticks;
                    TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                    string[] dddd = elapsedSpan.TotalSeconds.ToString().Split(new string[] { "." }, StringSplitOptions.None);
                    int iddd = Convert.ToInt32(dddd[0].ToString());
                    string yy = "insert into routes(hierarchy_level,total_count,download_time,upload_time,archive_count,skip_count,backup_route)values(" + 0 + "," + iPointCounter1 + "," + iddd + "," + 0 + "," + 0 + "," + 0 + "," + 0 + ")";//version 7
                    SqlceClass.executequery(CommandType.Text, yy);
                }
                catch { }
            }
            catch (Exception Ex)
            {
            }
        }
        private void insert_sensors()
        {
            string ss = "delete from sensors";
            _objMain.lblStatus.Caption = "Status: Filling Sensors Data";
            SqlceClass.executequery(CommandType.Text, ss);

            objpointType = new FrmPointType();

            try
            {
                if (_objupdown != null)
                {
                    _objupdown.ShowMessage("Status:Reading Sensors Data");
                }
                DataTable dtsen = new DataTable();
                dtsen = DbClass.getdata(CommandType.Text, "select * from sensor_data order by Sensor_ID asc");
                foreach (DataRow drsen in dtsen.Rows)
                {
                    string iSensorID = Convert.ToString(drsen["Sensor_ID"]);
                    string sSensorName = Convert.ToString(drsen["Sensor_name"]);
                    string btSensorType = Convert.ToString(drsen["Sensor_type"]);
                    string fSenstivity_A = Convert.ToString(drsen["Sensitivity_a"]);
                    string fSenstivity_H = Convert.ToString(drsen["Sensitivity_h"]);
                    string fSenstivity_V = Convert.ToString(drsen["Sensitivity_v"]);
                    string fSenstivity_ch1 = Convert.ToString(drsen["Senitivity_Ch1"]);
                    string btSensor_Unit = Convert.ToString(drsen["Sensor_unit"]);
                    string btSensor_dir = Convert.ToString(drsen["Sensor_dir"]);
                    string btSensor_icp = Convert.ToString(drsen["Sensor_icp"]);
                    string fSensor_offset = Convert.ToString(drsen["Sensor_offset"]);
                    // string fInput_Range = Convert.ToString(drsen["Input_Range"]);


                    string yy = "insert into sensors(sensor_id,sensor_name,sensor_type,sensitivity_ch1,sensitivity_a,sensitivity_h,sensitivity_v,sensor_unit,sensor_dir,sensor_icp,sensor_offset)values(" + iSensorID + ",'" + sSensorName + "'," + btSensorType + "," + fSenstivity_ch1 + "," + fSenstivity_A + "," + fSenstivity_H + "," + fSenstivity_V + "," + btSensor_Unit + "," + btSensor_dir + "," + btSensor_icp + "," + fSensor_offset + ")";
                    SqlceClass.executequery(CommandType.Text, yy);
                }
            }
            catch { }
        }
        private void insert_notes()
        {
            string ss = "delete from notes";
            _objMain.lblStatus.Caption = "Status: Filling Notes Data";
            SqlceClass.executequery(CommandType.Text, ss);
            try
            {
                if (_objupdown != null)
                {
                    _objupdown.ShowMessage("Status:Reading Notes Data");
                }
                DataTable dtnote = new DataTable();

                dtnote = DbClass.getdata(CommandType.Text, "SELECT * FROM notes  where note_type='2'");
                //dtnote = DbClass.getdata(CommandType.Text, "SELECT * FROM notes where note_type='2' order by Notes_ID");
                foreach (DataRow drnote in dtnote.Rows)
                {
                    string iNoteID = Convert.ToString(drnote["Notes_ID"]);
                    string iNoteDesc = Convert.ToString(drnote["Notes_Desc"]);
                    //string iNoteType = Convert.ToString(drnote["Note_type"]);

                    string yy = "insert into notes(note_id,note_content)values(" + iNoteID + ",'" + iNoteDesc + "')";
                    SqlceClass.executequery(CommandType.Text, yy);


                    //   string iNoteID = Convert.ToString(drnote["Notes_ID"]);
                    //   string iNoteDesc = Convert.ToString(drnote["Notes_Desc"]);
                    ////   string iNoteType = Convert.ToString(drnote["Note_type"]);

                    //   string yy = "insert into notes(note_id,note_content)values(" + iNoteID + ",'" + iNoteDesc + "')";
                    //   SqlceClass.executequery(CommandType.Text, yy);

                }

            }
            catch { }
        }

        private void insert_units()
        {           
            SqlceClass.executequery(CommandType.Text, "delete from units");
            _objMain.lblStatus.Caption = "Status: Filling Units Data";
            try
            {                
                DataTable dtunit = new DataTable();
                dtunit = DbClass.getdata(CommandType.Text, "select pt.point_ID,pt.PointName,pt.PointType_ID from point pt inner join type_point tp on pt.PointType_ID=tp.ID where pt.PointType_ID !='0'");
                foreach (DataRow drunit in dtunit.Rows)
                {
                    string itypeID = Convert.ToString(drunit["PointType_ID"]);
                    DataTable dtun = new DataTable();
                    dtun = DbClass.getdata(CommandType.Text, "select distinct un.Unit_ID,un.accel_unit,un.vel_unit,un.displ_unit,un.temperature_unit,un.process_unit,un.accel_detection,un.vel_detection,un.displ_detection,un.time_unit_type,un.power_unit_type,un.demodulate_unit_type,un.pressure_unit,un.current_unit,un.pressure_detection,un.current_detection,un.ordertrace_unit_type,un.cepstrum_unit_type,sen.Input_Range from units un inner join type_point tp on tp.ID=un.Type_ID left join measure mea on mea.Type_ID=tp.ID left join sensor_data sen on sen.Sensor_ID=mea.Sensor_ID where un.type_id='" + itypeID + "'");
                    foreach (DataRow drun in dtun.Rows)
                    {
                        string iPointID = Convert.ToString(drun["Unit_ID"]);
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
                        SqlceClass.executequery(CommandType.Text, "insert into units(unit_id,accel_unit,vel_unit,displ_unit,temperature_unit,process_unit,accel_detection,vel_detection,displ_detection,time_unit_type,power_unit_type,demodulate_unit_type,pressure_unit, current_unit, pressure_detection,current_detection, ordertrace_unit_type, cepstrum_unit_type,Input_Range)values(" + iPointID + "," + btAccel_Unit + "," + btVel_Unit + "," + btDispl_Unit + "," + btTemperature_Unit + ",'" + sProcess_Unit + "'," + btAccel_Detection + "," + btVel_Detection + "," + btDispl_Detection + "," + btTime_Unit_Type + "," + btPower_unit_type + "," + btDemodulate_Unit_Type + "," + btPressureUnit + "," + btCurrentUnit + "," + btPressure_detection + "," + btCurrent_detection + "," + btordertrace_unit_type + "," + btcepstrum_unit_type + "," + btInput_Range + ")");
                    }
                }
            }
            catch { }
        }

        private void insert_unitsforunschedule(int type)
        {
            _objMain.lblStatus.Caption = "Status: Filling Units for Unschedule Point Data";
            try
            {
                DataTable dtun = SqlceClass.getdata(CommandType.Text, "Select * from units where unit_id='" + point_new_record_id + "'", "Data Source=" + connvalu);
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
                    DbClass.executequery(CommandType.Text," insert into units(accel_unit,accel_detection,vel_unit,vel_detection,displ_unit,displ_detection,temperature_unit,process_unit,pressure_unit,pressure_detection,current_unit,current_detection,time_unit_type,power_unit_type,demodulate_unit_type,ordertrace_unit_type,cepstrum_unit_type,Date,Type_ID) values('" + btAccel_Unit+ "','" + btAccel_Detection+ "','" + btVel_Unit+ "','" + btVel_Detection+ "','" + btDispl_Unit+ "','" + btDispl_Detection+ "','" + btTemperature_Unit+ "','" + sProcess_Unit+ "','" + btPressureUnit+ "','" + btPressure_detection+ "','" + btCurrentUnit+ "','" + btCurrent_detection+ "','" + btTime_Unit_Type+ "','" + btPower_unit_type+ "','" + btDemodulate_Unit_Type+ "','" + btordertrace_unit_type+ "','" + btcepstrum_unit_type+ "','" + PublicClass.GetDatetime()+ "','" + type + "')");

                }

            }
            catch { }
        }

        private void insert_nodes()
        {
            string Notes = GetProperStringForNotes(PublicClass.routename);
            try
            {
               string ss = "update system_info set note='" + Notes + "'";
               SqlceClass.executequery(CommandType.Text, ss);

            }
            catch (Exception ex)
            {
              
            }
        }
        DataTable dtfactory = new DataTable();
        DataTable dtarea = new DataTable();
        DataTable dttrain = new DataTable();
        DataTable dtmachine = new DataTable();
        DataTable dtpoint = new DataTable();
        private void retriveImage(string s ,ref int picture_type,ref  byte[] machine_picture  )
        {
                        
            try
            {
                string Filename = s;
                if (Filename.Trim() != "")
                {
                    Filename = Filename.Replace('-', '\\');
                    Image imgImage = Image.FromFile(Filename);
                    byte[] machine_image = ImageToByte(imgImage);
                    if (machine_image == null)
                    {
                        machine_image = new byte[0];
                    }
                    else
                        picture_type = 1;
                    machine_picture = machine_image;
                }
            }
            catch { }
        }

        public void InsertNotes()
        {
            try
            {
                DataTable dtNoteMachine = SqlceClass.getdata(CommandType.Text, "Select desc_content FROM descriptions", "Data Source=" + connvalu);
                foreach (DataRow dr in dtNoteMachine.Rows)
                {
                    string desc = Convert.ToString(dr["desc_content"]);

                    DataTable dtNot = DbClass.getdata(CommandType.Text, "Select * from notes where Notes_Desc ='" + desc + "'");

                    if (dtNot.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "Insert notes(Notes_Desc,Note_Type,Date) values('" + desc + "','1','" + PublicClass.GetDatetime() + "')");
                    }
                }
                DataTable dtNotePoint = SqlceClass.getdata(CommandType.Text, "Select note_content FROM notes", "Data Source=" + connvalu);
                foreach (DataRow dr in dtNotePoint.Rows)
                {
                    string descP = Convert.ToString(dr["note_content"]);

                    DataTable dtNotPT = DbClass.getdata(CommandType.Text, "Select * from notes where Notes_Desc ='" + descP + "'");

                    if (dtNotPT.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        DbClass.executequery(CommandType.Text, "Insert notes(Notes_Desc,Note_Type,Date) values('" + descP + "','2','" + PublicClass.GetDatetime() + "')");
                    }
                }
            }
            catch
            {      }
        }


        public string[] GetRPMValues(string machineid)
        {
            string Pulse = "1"; string Rpm = "1800";
            string[] RPMValues = new string[2];
            try
            {
                DataTable dt2 = new DataTable();
                dt2 = DbClass.getdata(CommandType.Text, "Select PulseRev,rpm_driven from machine_info where machine_id = '" + machineid + "'");
                foreach (DataRow dr2 in dt2.Rows)
                {
                    Pulse = Convert.ToString(dr2["PulseRev"]);
                    Rpm = Convert.ToString(dr2["rpm_driven"]);
                }
            }
            catch (Exception ex)
            {
            }
            RPMValues[0] = Rpm;
            RPMValues[1] = Pulse;
            return RPMValues;
        }

        private void updateimage(byte[] machine_picture, string id)
        {
            try
            {
                string sNewCommandText = null;
                string sConnectionString = null;
                sNewCommandText = "update Machines SET machine_picture = @pic Where machine_id = '" + id  .Trim ()+ "' ";
                sConnectionString = PublicClass.sdfconnection;
                using (SqlCeConnection con = new SqlCeConnection(sConnectionString))
                using (SqlCeCommand cmd = new SqlCeCommand(sNewCommandText, con))
                {
                    con.Open();
                    cmd.Parameters.Add("@pic", SqlDbType.Image, machine_picture.Length).Value = machine_picture;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch { }
        }
        private void insertPoint(string pointid)
        {
            DataTable Pointdt = new DataTable();

            Pointdt = DbClass.getdata(CommandType.Text, "select distinct * from point where point_id='" + pointid + "' ");

            foreach (DataRow dr2 in Pointdt.Select("point_id ='" + pointid + "' "))
            {
                try
                {
                    DataTable dtpoint = new DataTable();
                    dtpoint = DbClass.getdata(CommandType.Text, "select pt.point_ID,pt.PointName,pt.PointType_ID from point pt inner join type_point tp on pt.PointType_ID=tp.id where pt.PointType_ID !='0' and tp.Instrumentname='" + PublicClass.currentInstrument + "' and pt.point_ID ='" + pointid + "' ");
                    foreach (DataRow dr in dtpoint.Rows)
                    {
                        string ptID = Convert.ToString(dr["Point_ID"]);
                        string ptName = Convert.ToString(dr["PointName"]);
                        string ptTypeID = Convert.ToString(dr["PointType_ID"]);
                        DataTable gettypeID = new DataTable();


                        DataTable dt1 = new DataTable();
                        dt1 = DbClass.getdata(CommandType.Text, "select pt.point_id,pt.pointname,pt.pointtype_id,mt.Calcmeasure,mea.Sensordir,pt.PointStatus,pt.PointSchedule,unit.unit_id,mea.ID,tp.alarm_id, pt.machine_id,sd.sensor_name,mea.sensor_id,mea.temperatureID  , tp.note_id,tp.point_record_status , tp.point_status , tp.point_schedule , tp.point_measurement , tp.record_id FROM type_point tp inner join measure_type mt on tp.ID=mt.Type_ID left join point pt on tp.ID=pt.PointType_ID left join measure mea on tp.ID=mea.Type_ID left join sensor_data sd on sd.sensor_type= mea.Sensor_ID left join units unit on tp.ID = unit.Type_ID where pt.Point_ID = '" + ptID + "' group by pt.point_id");
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            string pUnitid = Convert.ToString(dr1["unit_id"]);
                            string mesID = Convert.ToString(dr1["ID"]);
                            string pAlarmId = Convert.ToString(dr1["alarm_id"]);
                            string pMachineID = Convert.ToString(dr1["machine_id"]);
                            string pStatus = Convert.ToString(dr1["point_status"]);
                            string pSchedule = Convert.ToString(dr1["PointSchedule"]);
                            string pMeasurment = Convert.ToString(dr1["Calcmeasure"]);
                            string vibSensor = Convert.ToString(dr1["sensor_id"]);
                            string tempSensor = Convert.ToString(dr1["TemperatureID"]);

                            string pRecordID = Convert.ToString(dr1["record_id"]);
                            string pRecordStatus = Convert.ToString(dr1["PointStatus"]);
                            string pdir = Convert.ToString(dr1["Sensordir"]);

                            SqlceClass.executequery(CommandType.Text, "insert into Points(Point_id,Point_name,point_dir,point_record_status,point_status,point_schedule,point_measurement,vibration_sensor,temperature_sensor,unit_id,measure_id,alarm_id,machine_id,record_id) values(" + ptID + ",'" + ptName + "','" + pdir + "','" + pRecordStatus + "','" + pStatus + "','" + pSchedule + "','" + pMeasurment + "','" + vibSensor + "','" + tempSensor + "','" + pUnitid + "','" + mesID + "','" + (pAlarmId) + "','" + (pMachineID) + "','" + (pRecordID) + "')");
                            iPointCounter1 = iPointCounter1 + 1;

                        }

                    }
                }
                catch { }                                                                                              // (" + ptID + ",'" + ptName + "','"   + pdir + "','" + pRecordStatus + "','" + pStatus + "','" + pSchedule + "','" + pMeasurment + "','" + vibSensor + "','" + tempSensor + "','" + pUnitid + "','" + mesID + "','" + (pNoteID) + "','" + (pAlarmId) + "','" + (pMachineID) + "','" + (pRecordID) + "')";




                //SqlceClass.executequery(CommandType.Text, "insert into Points(Point_id,Point_name,point_dir,point_record_status,point_status,point_schedule,point_measurement,vibration_sensor,temperature_sensor,unit_id,measure_id,note_id,alarm_id,record_id,machine_id)values(" + routelevelid + ",'" + Convert.ToString(dr["pointname"]) + "','" + Convert.ToString(dr["Area_ID"]) + "') ");
            }

        }
        private void insert_Plant(string factory_id)
        {
            try
            {
                dtfactory = DbClass.getdata(CommandType.Text, "select distinct * from factory_info where Factory_ID='" + factory_id + "' ");
                dtarea = DbClass.getdata(CommandType.Text, "select distinct * from Area_Info  ");
                dttrain = DbClass.getdata(CommandType.Text, "select distinct * from train_info ");
                dtmachine = DbClass.getdata(CommandType.Text, "select distinct a.*,p.Picture from machine_info a left join machine_pic p on a.Machine_ID=p.MachineID ");
                dtpoint = DbClass.getdata(CommandType.Text, "select distinct * from point  ");
                foreach (DataRow drfactory in dtfactory.Select("Factory_ID ='" + routelevelid + "' "))
                {
                    SqlceClass.executequery(CommandType.Text, "insert into plants(plant_id,plant_name)values('" + factory_id + "','" + Convert.ToString(drfactory["name"]) + "') ");
                    _objMain.lblStatus.Caption = "Status: Inserting Plant values";
                    foreach (DataRow drarea in dtarea.Select("FactoryID='" + Convert.ToString(drfactory["Factory_ID"]).Trim() + "' "))
                    {
                        _objMain.lblStatus.Caption = "Status: Inserting Area values";
                        SqlceClass.executequery(CommandType.Text, "insert into areas(area_id,area_name,plant_id)values('" + Convert.ToString(drarea["area_id"]) + "','" + Convert.ToString(drarea["name"]) + "' ,'" + Convert.ToString(drarea["FactoryID"]) + "') ");
                        foreach (DataRow drtrain in dttrain.Select("area_id= '" + Convert.ToString(drarea["area_id"]).Trim() + "' "))
                        {
                            _objMain.lblStatus.Caption = "Status: Inserting Train values";
                            SqlceClass.executequery(CommandType.Text, "insert into trains(train_id,train_name,Area_ID)values('" + Convert.ToString(drtrain["train_id"]) + "','" + Convert.ToString(drtrain["name"]) + "','" + Convert.ToString(drarea["Area_ID"]) + "') ");

                            foreach (DataRow drMachine in dtmachine.Select("trainid ='" + Convert.ToString(drtrain["train_id"]).Trim() + "'  "))
                            {
                                _objMain.lblStatus.Caption = "Status: Inserting Machine values";
                                string[] RPMValues = GetRPMValues(Convert.ToString(drMachine["machine_id"]));
                                int RpmValue = Convert.ToInt32(RPMValues[0]);
                                int PulseValue = Convert.ToInt32(RPMValues[1]);                                
                                int picture_type = 0;
                                byte[] machine_picture = null;
                                retriveImage(Convert.ToString(drMachine["Picture"]).Trim(), ref picture_type, ref machine_picture);
                                SqlceClass.executequery(CommandType.Text, "insert into machines(machine_id,machine_name,machine_rpm,machine_pulsesrev,description1_id,description2_id,description3_id, picture_type,train_id)values('" + Convert.ToString(drMachine["machine_id"]) + "','" + Convert.ToString(drMachine["name"]) + "'," + RpmValue + "," + PulseValue + ",'0','0','0'," + picture_type + "  ,'" + Convert.ToString(drtrain["train_id"]) + "') ");
                                mac += Convert.ToString(drMachine["machine_id"]) + ",";
                                if (picture_type == 1)
                                {
                                    _objMain.lblStatus.Caption = "Status: Updating Machine Images";
                                    updateimage(machine_picture, Convert.ToString(drMachine["machine_id"]).Trim());
                                }
                                insert_Machine_Description(Convert.ToString(drMachine["machine_id"]));
                                //iPointCounter1 = 0;
                                foreach (DataRow drpoint in dtpoint.Select("machine_id='" + Convert.ToString(drMachine["machine_id"]).Trim() + "' "))
                                {
                                    _objMain.lblStatus.Caption = "Status: Inserting Points Data";
                                    insertPoint(Convert.ToString(drpoint["Point_ID"]));
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void insert_Area(string Factory_id)
        {

            try
            {

                //SqlceClass.executequery(CommandType.Text, "delete from plants");
                //SqlceClass.executequery(CommandType.Text, "delete from trains");
                //SqlceClass.executequery(CommandType.Text, "delete from areas");
                //SqlceClass.executequery(CommandType.Text, "delete from machines");
                //SqlceClass.executequery(CommandType.Text, "delete from points");


                dtarea = DbClass.getdata(CommandType.Text, "select distinct * from Area_Info  ");
                dttrain = DbClass.getdata(CommandType.Text, "select distinct * from train_info ");
                dtmachine = DbClass.getdata(CommandType.Text, "select distinct a.*,p.Picture from machine_info a left join machine_pic p on a.Machine_ID=p.MachineID ");
                dtpoint = DbClass.getdata(CommandType.Text, "select distinct * from point  ");
                _objMain.lblStatus.Caption = "Status: Inserting Plant values";
                SqlceClass.executequery(CommandType.Text, "insert into plants(plant_id,plant_name)values('" + Factory_id + "','Default') ");
                foreach (DataRow drarea in dtarea.Select("area_id='" + Factory_id.Trim() + "' "))
                {
                    _objMain.lblStatus.Caption = "Status: Inserting Area values";
                    if (PublicClass.LevelName == "Area")
                    {
                        SqlceClass.executequery(CommandType.Text, "insert into areas(area_id,area_name,plant_id)values('" + Convert.ToString(drarea["area_id"]) + "','" + Convert.ToString(drarea["name"]) + "' ,'" + Factory_id + "') ");
                    }
                    else
                    {
                        SqlceClass.executequery(CommandType.Text, "insert into areas(area_id,area_name,plant_id)values('" + Convert.ToString(drarea["area_id"]) + "','" + Convert.ToString(drarea["name"]) + "' ,'" + Convert.ToString(drarea["FactoryID"]) + "') ");
                    }
                    foreach (DataRow drtrain in dttrain.Select("area_id= '" + Convert.ToString(drarea["area_id"]).Trim() + "' "))
                    {
                        _objMain.lblStatus.Caption = "Status: Inserting Train values";
                        SqlceClass.executequery(CommandType.Text, "insert into trains(train_id,train_name,Area_ID)values('" + Convert.ToString(drtrain["train_id"]) + "','" + Convert.ToString(drtrain["name"]) + "','" + Convert.ToString(drarea["Area_ID"]) + "') ");

                        foreach (DataRow drMachine in dtmachine.Select("trainid ='" + Convert.ToString(drtrain["train_id"]).Trim() + "'  "))
                        {
                            _objMain.lblStatus.Caption = "Status: Inserting Machine values";
                            string[] RPMValues = GetRPMValues(Convert.ToString(drMachine["machine_id"]));
                            int RpmValue = Convert.ToInt32(RPMValues[0]);
                            int PulseValue = Convert.ToInt32(RPMValues[1]); 
                            int picture_type = 0;
                            byte[] machine_picture = null;
                            retriveImage(Convert.ToString(drMachine["Picture"]).Trim(), ref picture_type, ref machine_picture);
                            SqlceClass.executequery(CommandType.Text, "insert into machines(machine_id,machine_name,machine_rpm,machine_pulsesrev,description1_id,description2_id,description3_id, picture_type,train_id)values('" + Convert.ToString(drMachine["machine_id"]) + "','" + Convert.ToString(drMachine["name"]) + "'," + RpmValue + "," + PulseValue + ",'0','0','0'," + picture_type + "  ,'" + Convert.ToString(drtrain["train_id"]) + "') ");
                            mac += Convert.ToString(drMachine["machine_id"]) + ",";
                            if (picture_type == 1)
                            {
                                _objMain.lblStatus.Caption = "Status: Uploading Machine Images";
                                updateimage(machine_picture, Convert.ToString(drMachine["machine_id"]).Trim());
                            }
                            insert_Machine_Description(Convert.ToString(drMachine["machine_id"]).Trim());
                            foreach (DataRow drpoint in dtpoint.Select("machine_id='" + Convert.ToString(drMachine["machine_id"]).Trim() + "' "))
                            {
                                _objMain.lblStatus.Caption = "Status: Inserting Point values";
                                insertPoint(Convert.ToString(drpoint["Point_ID"]));
                            }
                        }
                    }
                }
            }
            catch { }

        }

        private void insert_Train(string Factory_id)
        {

            try
            {

                //SqlceClass.executequery(CommandType.Text, "delete from plants");
                //SqlceClass.executequery(CommandType.Text, "delete from trains");
                //SqlceClass.executequery(CommandType.Text, "delete from areas");
                //SqlceClass.executequery(CommandType.Text, "delete from machines");
                //SqlceClass.executequery(CommandType.Text, "delete from points");


                dtarea = DbClass.getdata(CommandType.Text, "select distinct * from Area_Info  ");
                dttrain = DbClass.getdata(CommandType.Text, "select distinct * from train_info ");
                dtmachine = DbClass.getdata(CommandType.Text, "select distinct a.*,p.Picture from machine_info a left join machine_pic p on a.Machine_ID=p.MachineID ");
                dtpoint = DbClass.getdata(CommandType.Text, "select distinct * from point  ");
                _objMain.lblStatus.Caption = "Status: Inserting Plant values";
                SqlceClass.executequery(CommandType.Text, "insert into plants(plant_id,plant_name)values('" + Factory_id + "','Default') ");

                _objMain.lblStatus.Caption = "Status: Inserting Area values";
                SqlceClass.executequery(CommandType.Text, "insert into areas(area_id,area_name,plant_id)values('" + Factory_id + "','Default' ,'" + Factory_id + "') ");
                foreach (DataRow drtrain in dttrain.Select("train_id= '" + Factory_id + "' "))
                {
                    _objMain.lblStatus.Caption = "Status: Inserting Train values";
                    if (PublicClass.LevelName == "Train")
                    {
                        SqlceClass.executequery(CommandType.Text, "insert into trains(train_id,train_name,Area_ID)values('" + Convert.ToString(drtrain["train_id"]) + "','" + Convert.ToString(drtrain["name"]) + "','" + Factory_id + "') ");
                    }
                    else
                    {
                        SqlceClass.executequery(CommandType.Text, "insert into trains(train_id,train_name,Area_ID)values('" + Convert.ToString(drtrain["train_id"]) + "','" + Convert.ToString(drtrain["name"]) + "','" + Convert.ToString(drtrain["Area_ID"]) + "') ");
                    }
                    foreach (DataRow drMachine in dtmachine.Select("trainid ='" + Convert.ToString(drtrain["train_id"]).Trim() + "'  "))
                    {
                        _objMain.lblStatus.Caption = "Status: Inserting Machine values";
                        string[] RPMValues = GetRPMValues(Convert.ToString(drMachine["machine_id"]));
                        int RpmValue = Convert.ToInt32(RPMValues[0]);
                        int PulseValue = Convert.ToInt32(RPMValues[1]); 
                        int picture_type = 0;
                        byte[] machine_picture = null;
                        retriveImage(Convert.ToString(drMachine["Picture"]).Trim(), ref picture_type, ref machine_picture);
                        SqlceClass.executequery(CommandType.Text, "insert into machines(machine_id,machine_name,machine_rpm,machine_pulsesrev,description1_id,description2_id,description3_id, picture_type,train_id)values('" + Convert.ToString(drMachine["machine_id"]) + "','" + Convert.ToString(drMachine["name"]) + "'," + RpmValue + "," + PulseValue + ",'0','0','0'," + picture_type + "  ,'" + Convert.ToString(drtrain["train_id"]) + "') ");
                        mac += Convert.ToString(drMachine["machine_id"]) + ",";
                        if (picture_type == 1)
                        {
                            _objMain.lblStatus.Caption = "Status: Uploading Machine Images";
                            updateimage(machine_picture, Convert.ToString(drMachine["machine_id"]).Trim());
                        }
                        //iPointCounter1 = 0;
                        insert_Machine_Description(Convert.ToString(drMachine["machine_id"]).Trim());
                        foreach (DataRow drpoint in dtpoint.Select("machine_id='" + Convert.ToString(drMachine["machine_id"]).Trim() + "' "))
                        {
                            _objMain.lblStatus.Caption = "Status: Inserting Point values";
                            insertPoint(Convert.ToString(drpoint["Point_ID"]));
                        }

                    }

                }

            }
            catch { }
        }

        string mac = null;         
         private void insert_Machine(string Factory_id)
         {
             try
             {

                 //SqlceClass.executequery(CommandType.Text, "delete from plants");
                 //SqlceClass.executequery(CommandType.Text, "delete from trains");
                 //SqlceClass.executequery(CommandType.Text, "delete from areas");
                 //SqlceClass.executequery(CommandType.Text, "delete from machines");
                 //SqlceClass.executequery(CommandType.Text, "delete from points");


                 dtarea = DbClass.getdata(CommandType.Text, "select distinct * from Area_Info  ");
                 dttrain = DbClass.getdata(CommandType.Text, "select distinct * from train_info ");
                 dtmachine = DbClass.getdata(CommandType.Text, "select distinct a.*,p.Picture from machine_info a left join machine_pic p on a.Machine_ID=p.MachineID ");
                 dtpoint = DbClass.getdata(CommandType.Text, "select distinct * from point  ");
                 _objMain.lblStatus.Caption = "Status: Inserting Plant values";
                 SqlceClass.executequery(CommandType.Text, "insert into plants(plant_id,plant_name)values('" + Factory_id + "','Default') ");

                 _objMain.lblStatus.Caption = "Status: Inserting Area values";
                 SqlceClass.executequery(CommandType.Text, "insert into areas(area_id,area_name,plant_id)values('" + Factory_id + "','Default' ,'" + Factory_id + "') ");

                 _objMain.lblStatus.Caption = "Status: Inserting Train values";
                 SqlceClass.executequery(CommandType.Text, "insert into trains(train_id,train_name,Area_ID)values('" + Factory_id + "','Default','" + Factory_id + "') ");

                 foreach (DataRow drMachine in dtmachine.Select("machine_id ='" + Factory_id + "'  "))
                 {
                     _objMain.lblStatus.Caption = "Status: Inserting Machine values";
                     string[] RPMValues = GetRPMValues(Convert.ToString(drMachine["machine_id"]));
                     int RpmValue = Convert.ToInt32(RPMValues[0]);
                     int PulseValue = Convert.ToInt32(RPMValues[1]); 
                     int picture_type = 0;
                     byte[] machine_picture = null;
                     retriveImage(Convert.ToString(drMachine["Picture"]).Trim(), ref picture_type, ref machine_picture);
                     if (PublicClass.LevelName == "Machine")
                     {
                         SqlceClass.executequery(CommandType.Text, "insert into machines(machine_id,machine_name,machine_rpm,machine_pulsesrev,description1_id,description2_id,description3_id, picture_type,train_id)values('" + Convert.ToString(drMachine["machine_id"]) + "','" + Convert.ToString(drMachine["name"]) + "'," + RpmValue + "," + PulseValue + ",'0','0','0'," + picture_type + "  ,'" + Factory_id + "') ");
                     }
                     else
                     {
                         SqlceClass.executequery(CommandType.Text, "insert into machines(machine_id,machine_name,machine_rpm,machine_pulsesrev,description1_id,description2_id,description3_id, picture_type,train_id)values('" + Convert.ToString(drMachine["machine_id"]) + "','" + Convert.ToString(drMachine["name"]) + "'," + RpmValue + "," + PulseValue + ",'0','0','0'," + picture_type + "  ,'" + Convert.ToString(drMachine["trainid"]) + "') ");
                     }
                     mac+= Convert.ToString(drMachine["machine_id"])+',';
                     if (picture_type == 1)
                     {
                         _objMain.lblStatus.Caption = "Status: Uploading Machine Images";
                         updateimage(machine_picture, Convert.ToString(drMachine["machine_id"]).Trim());
                     }
                     //   iPointCounter1 = 0;
                     insert_Machine_Description(Convert.ToString(drMachine["machine_id"]).Trim());
                     foreach (DataRow drpoint in dtpoint.Select("machine_id='" + Convert.ToString(drMachine["machine_id"]).Trim() + "' "))
                     {
                         _objMain.lblStatus.Caption = "Status: Inserting Point values";
                         insertPoint(Convert.ToString(drpoint["Point_ID"]));
                     }

                 }
             }
             catch { }
         }

         private void insert_PointValue(string Factory_id)
         {
             try
             {
                 int picture_type = 0;
                 byte[] machine_picture = null;
                 //SqlceClass.executequery(CommandType.Text, "delete from plants");
                 //SqlceClass.executequery(CommandType.Text, "delete from trains");
                 //SqlceClass.executequery(CommandType.Text, "delete from areas");
                 //SqlceClass.executequery(CommandType.Text, "delete from machines");
                 //SqlceClass.executequery(CommandType.Text, "delete from points");


                 //dtarea = DbClass.getdata(CommandType.Text, "select distinct * from Area_Info  ");
                 //dttrain = DbClass.getdata(CommandType.Text, "select distinct * from train_info ");
                 //dtmachine = DbClass.getdata(CommandType.Text, "select distinct a.*,p.Picture from machine_info a left join machine_pic p on a.Machine_ID=p.MachineID ");
                 dtpoint = DbClass.getdata(CommandType.Text, "select distinct * from point ");

                 //SqlceClass.executequery(CommandType.Text, "insert into plants(plant_id,plant_name)values('" + Factory_id + "','Default') ");

                 //SqlceClass.executequery(CommandType.Text, "insert into areas(area_id,area_name,plant_id)values('" + Factory_id + "','Default' ,'" + Factory_id + "') ");

                 //SqlceClass.executequery(CommandType.Text, "insert into trains(train_id,train_name,Area_ID)values('" + Factory_id + "','Default','" + Factory_id + "') ");


                 //  SqlceClass.executequery(CommandType.Text, "insert into machines(machine_id,machine_name,machine_rpm,machine_pulsesrev, picture_type,train_id)values('" + Factory_id + "','Default', '1','1','1'  ,'" + Factory_id + "') ");


                 foreach (DataRow drpoint in dtpoint.Select("Point_ID='" + Factory_id + "' "))
                 {
                     // iPointCounter1 = iPointCounter1 + 1;
                     insertPoint(Convert.ToString(drpoint["Point_ID"]));
                 }


                 DataTable dtt = new DataTable();
                 dtt = DbClass.getdata(CommandType.Text, "select distinct p.Point_ID as Point_id , m.Machine_ID ,t.Train_ID ,a.Area_ID,f.Factory_ID from    point p left join machine_info m  on p.Machine_ID=m.Machine_ID left join train_info t on m.TrainID=t.Train_ID left join area_info a on t.Area_ID=a.Area_ID left join factory_info f on a.FactoryID=f.Factory_ID where p.point_id='" + Factory_id + "'  ");
                 foreach (DataRow dr in dtt.Rows)
                 {
                     _objMain.lblStatus.Caption = "Status: Inserting Plant values";
                     SqlceClass.executequery(CommandType.Text, "insert into plants(plant_id,plant_name)values('" + Convert.ToString(dr["Factory_ID"]) + "','Default') ");

                     _objMain.lblStatus.Caption = "Status: Inserting Area values";
                     SqlceClass.executequery(CommandType.Text, "insert into areas(area_id,area_name,plant_id)values('" + Convert.ToString(dr["Area_ID"]) + "','Default' ,'" + Convert.ToString(dr["Factory_ID"]) + "') ");

                     _objMain.lblStatus.Caption = "Status: Inserting Train values";
                     SqlceClass.executequery(CommandType.Text, "insert into trains(train_id,train_name,Area_ID)values('" + Convert.ToString(dr["Train_ID"]) + "','Default','" + Convert.ToString(dr["Area_ID"]) + "') ");

                     _objMain.lblStatus.Caption = "Status: Inserting Machine values";
                     string[] RPMValues = GetRPMValues(Convert.ToString(dr["machine_id"]));
                     int RpmValue = Convert.ToInt32(RPMValues[0]);
                     int PulseValue = Convert.ToInt32(RPMValues[1]);
                     SqlceClass.executequery(CommandType.Text, "insert into machines(machine_id,machine_name,machine_rpm,machine_pulsesrev,description1_id,description2_id,description3_id, picture_type,train_id)values('" + Convert.ToString(dr["Machine_ID"]) + "','Default', '" + RpmValue + "','" + PulseValue + "','0','0','0','" + picture_type + "'  ,'" + Convert.ToString(dr["Train_ID"]) + "') ");

                     retriveImage(Convert.ToString(dr["Picture"]).Trim(), ref picture_type, ref machine_picture);
                     if (picture_type == 1)
                     {
                         _objMain.lblStatus.Caption = "Status: Uploading Machine Images";
                         updateimage(machine_picture, Convert.ToString(dr["machine_id"]).Trim());
                     }
                     insert_Machine_Description(Convert.ToString(dr["machine_id"]).Trim());
                 }


             }
             catch { }
         }

         private void insert_descrption()
         {
             string ss = "delete from descriptions";
             _objMain.lblStatus.Caption = "Status: Filling Description Data";
             SqlceClass.executequery(CommandType.Text, ss);
             try
             {
                 if (_objupdown != null)
                 {
                     _objupdown.ShowMessage("Status:Reading Notes Data");
                 }
                 DataTable dtnote = new DataTable();
                 dtnote = DbClass.getdata(CommandType.Text, "SELECT * FROM notes where note_type='1' order by Notes_ID");
                 foreach (DataRow drnote in dtnote.Rows)
                 {
                     string iNoteID = Convert.ToString(drnote["Notes_ID"]);
                     string iNoteDesc = Convert.ToString(drnote["Notes_Desc"]);
                     string yy = "insert into descriptions(desc_id,desc_content)values(" + iNoteID + ",'" + iNoteDesc + "')";
                     SqlceClass.executequery(CommandType.Text, yy);
                 }
             }
             catch { }
         }

        public void UploadValuesToBenstone()
        {
            try
            {              
                Fill_Value();               
                insert_alarms();                
                Inser_Measures();               
                InsertbandALarms();                
                Insert_Bandalarms();               
                insert_fault_freq();               
                insert_point_record();                
                insert_routes();                
                insert_sensors();                
                insert_notes();                
                insert_units();                
                insert_nodes();                
                insert_descrption();                
                insert_Machine_Record();
                
                string s = "completed";
               
               
            }
            catch { }
        }
       
        public void UploadValuesToBenstone_Old()
        {
            int Ctr = 0;
            FacIds = new string[0];
            ResIds = new string[0];
            EleIds = new string[0];
            SubEleIds = new string[0];
            string sConnectionString = null;
            string objCurrentNode = PublicClass.routename;
            DataTable objPlantDataTable = null;
            DataTable objAreaDataTable = null;
            DataTable objTrainDataTable = null;
            DataTable objMachineDataTable = null;
            DataTable objPointDataTable = null;

            DataTable objAreaDataTable1 = new DataTable();
            objAreaDataTable1.Columns.Add("AreaID");
            objAreaDataTable1.Columns.Add("AreaName");
            objAreaDataTable1.Columns.Add("ParentID");

            DataTable objTrainDataTable1 = new DataTable();
            objTrainDataTable1.Columns.Add("TrainID");
            objTrainDataTable1.Columns.Add("TrainName");
            objTrainDataTable1.Columns.Add("ParentID");


            DataTable objMachineDataTable1 = new DataTable();
            objMachineDataTable1.Columns.Add("MachineID");
            objMachineDataTable1.Columns.Add("MachineName");
            objMachineDataTable1.Columns.Add("ParentID");
            objMachineDataTable1.Columns.Add("Rpm");
            objMachineDataTable1.Columns.Add("Rev");

         
            DataTable objPointDataTable1 = new DataTable();
            objPointDataTable1.Columns.Add("PointID");
            objPointDataTable1.Columns.Add("Point_Name");
            objPointDataTable1.Columns.Add("ParentID");


            DataTable objBandAlarmDataTable = null;
            DataTable objFaultDataTable = null;
            DataTable objNotesDataTable = null;
            DataTable objPointRecordTable = null;
            ArrayList arlpointID = null;
            ArrayList data = null;
            try
            {
                if (objCurrentNode != null)
                {
                    _objupdown = new frmupdownload();
                    int iNewCtr = 1;
                    bool bStatus = false;
                    int iPointCounter = 0;
                    using (SqlCeConnection objNewConnection = new SqlCeConnection())
                    {
                        if (_objupdown != null)
                        {
                            _objupdown.ShowMessage("Status:Reading Plants Data");
                        }


                        DataTable dt = new DataTable();
                        dt = DbClass.getdata(CommandType.Text, "select rdd.ID,rdd.Route_Name,rdd.Route_Level,rdd.DatabaseName,rdd.Date,rd1.Type_ID from route_data rdd inner join route_data1 rd1 on rdd.ID=rd1.ID where rdd.Route_Name='" + PublicClass.routename + "' order by ID asc");

                        foreach (DataRow dr in dt.Rows)
                        {
                            id = Convert.ToString(dr["id"]);
                            routename = Convert.ToString(dr["Route_Name"]);
                            routelevel = Convert.ToString(dr["Route_Level"]);
                            routelevelid = Convert.ToString(dr["Type_Id"]);
                            databasename = Convert.ToString(dr["DatabaseName"]);
                            date = Convert.ToString(dr["date"]);

                        }

                        if (_objupdown != null)
                        {
                            _objupdown.ShowMessage("Status:Reading Area Data");
                        }
                        if (routelevelid != null)
                        {
                            Ctr = 0;
                            int CtrAr = 0;
                            try
                            {
                                for (int i = 0; i < routelevelid.Length; i++)
                                {

                                    objAreaDataTable = DbClass.getdata(CommandType.Text, "select * from Area_Info where FactoryID='" + routelevelid + "' order by Position asc");

                                    foreach (DataRow dr in objAreaDataTable.Rows)
                                    {
                                        _ResizeArray.IncreaseArrayString(ref ResIds, 1);
                                        iNewAreaID = Convert.ToString(dr["Area_ID"]);
                                        iNewAreaName = Convert.ToString(dr["Name"]);
                                        AreaparentID = Convert.ToString(dr["FactoryID"]);

                                        ResIds[Ctr] = iNewAreaID;
                                        DataRow objNewRow = objAreaDataTable1.NewRow();
                                        objNewRow["AreaID"] = iNewAreaID;
                                        objNewRow["AreaName"] = iNewAreaName;
                                        objNewRow["ParentID"] = AreaparentID;
                                        objAreaDataTable1.Rows.Add(objNewRow);
                                        Ctr++;

                                    }
                                    CtrAr++;
                                }
                            }
                            catch { }
                        }
                        if (_objupdown != null)
                        {
                            _objupdown.ShowMessage("Status:Reading Train Data");
                        }
                        if (iNewAreaID != null)
                        {
                            Ctr = 0;
                            int CtrAr = 0;
                            for (int i = 0; i < ResIds.Length; i++)
                            {
                                objTrainDataTable = DbClass.getdata(CommandType.Text, "select * from train_info where Area_ID='" + ResIds[i] + "' order by Position asc");

                                foreach (DataRow dr in objTrainDataTable.Rows)
                                {
                                    _ResizeArray.IncreaseArrayString(ref EleIds, 1);
                                    iNewTrainID = Convert.ToString(dr["Train_ID"]);
                                    iNewTrainName = Convert.ToString(dr["Name"]);
                                    TrainparentID = Convert.ToString(dr["Area_ID"]);

                                    EleIds[Ctr] = iNewTrainID;
                                    DataRow objNewRow = objTrainDataTable1.NewRow();
                                    objNewRow["TrainID"] = Convert.ToString(iNewTrainID);
                                    objNewRow["TrainName"] = iNewTrainName;
                                    objNewRow["ParentID"] = TrainparentID;


                                    objTrainDataTable1.Rows.Add(objNewRow);
                                    Ctr++;

                                }
                                //CtrAr++;
                            }

                        }
                        string smachineID = null;
                        if (_objupdown != null)
                        {
                            _objupdown.ShowMessage("Status:Reading Machine Data");
                        }
                        if (iNewTrainID != null)
                        {
                            Ctr = 0;
                            int CtrMach = 0;
                            for (int i = 0; i < EleIds.Length; i++)
                            {
                                objMachineDataTable = DbClass.getdata(CommandType.Text, "select * from machine_info where TrainID='" + EleIds[i] + "' order by Machine_ID asc");

                                foreach (DataRow dr in objMachineDataTable.Rows)
                                {
                                    string iNewMachineID = Convert.ToString(dr["Machine_ID"]);
                                    string sMachineName = Convert.ToString(dr["Name"]);
                                    string iMachineTrainID = Convert.ToString(dr["TrainID"]);
                                    _ResizeArray.IncreaseArrayString(ref SubEleIds, 1);
                                    SubEleIds[Ctr] = iNewMachineID;
                                    smachineID = iNewMachineID;
                                    double RpmValue = 1;
                                    double PulseValue = 1;


                                    DataRow objNewRow = objMachineDataTable1.NewRow();
                                    objNewRow["MachineID"] = iNewMachineID;
                                    objNewRow["MachineName"] = sMachineName;
                                    objNewRow["ParentID"] = iMachineTrainID;
                                    objNewRow["Rpm"] = RpmValue;
                                    objNewRow["Rev"] = PulseValue;
                                    objMachineDataTable1.Rows.Add(objNewRow);
                                    Ctr++;
                                }
                                // CtrMach++;
                            }

                        }

                        if (_objupdown != null)
                        {
                            _objupdown.ShowMessage("Status:Reading Point Data");
                        }
                        if (smachineID != null)
                        {
                            Ctr = 0;
                            int CtrSub = 0;
                            for (int i = 0; i < SubEleIds.Length; i++)
                            {
                                objPointDataTable = DbClass.getdata(CommandType.Text, "select * from point where Machine_ID='" + SubEleIds[i] + "'");

                                foreach (DataRow dr in objPointDataTable.Rows)
                                {
                                    try
                                    {
                                        string iNewPointID = Convert.ToString(dr["Point_ID"]);
                                        string sPointName = Convert.ToString(dr["PointName"]);
                                        string iPointMachineID = Convert.ToString(dr["Machine_ID"]);
                                        DataRow objNewRow = objPointDataTable1.NewRow();
                                        objNewRow["PointID"] = iNewPointID;
                                        objNewRow["Point_Name"] = sPointName;
                                        objNewRow["ParentID"] = iPointMachineID;
                                        objPointDataTable1.Rows.Add(objNewRow);
                                        Ctr++;
                                    }
                                    catch { }

                                }
                                // CtrSub++;
                            }
                        }

                        if (_objupdown != null)
                        {
                            _objupdown.ShowMessage("Status:Reading Points");
                        }
                        DataTable dt2 = null;
                        arlpointID = new ArrayList();
                        dt2 = DbClass.getdata(CommandType.Text, "select * from point order by Point_id");

                        foreach (DataRow dr in dt2.Rows)
                        {
                            arlpointID.Add(Convert.ToString(dr["Point_id"]));
                        }

                        objBandAlarmDataTable = DbClass.getdata(CommandType.Text, "select distinct bd.BandAlarm_Name,bd.Freq,bd.X,bd.Y,pb.Point_ID from band_data bd inner join point_balarm pb on pb.BA_ID=bd.ID");
                        objBandAlarmDataTable.Columns.Add("BandName");
                        objBandAlarmDataTable.Columns.Add("Freq1");
                        objBandAlarmDataTable.Columns.Add("X1");
                        objBandAlarmDataTable.Columns.Add("Y1");
                        objBandAlarmDataTable.Columns.Add("point_id1");

                        foreach (DataRow dr in objBandAlarmDataTable.Rows)
                        {
                            string bandname = Convert.ToString(dr["BandAlarm_Name"]);
                            float Freqv = (float)Convert.ToDouble(dr["Freq"]);
                            float alarm1 = (float)Convert.ToDouble(dr["X"]);
                            float alarm2 = (float)Convert.ToDouble(dr["Y"]);
                            int PointID = (int)dr["Point_ID"];
                            DataRow objNewRow = objBandAlarmDataTable.NewRow();
                            objNewRow["Freq1"] = Freqv;
                            objNewRow["X1"] = alarm1;
                            objNewRow["Y1"] = alarm2;
                            objNewRow["BandName"] = bandname;
                            objNewRow["point_id1"] = PointID;
                        }


                        objFaultDataTable = DbClass.getdata(CommandType.Text, "select * from faultfreq_data fd inner join point_faultfreq pff on pff.FaultFreq_ID= fd.pf_ID ");
                        objFaultDataTable.Columns.Add("faultName");
                        objFaultDataTable.Columns.Add("Freq");
                        objFaultDataTable.Columns.Add("point_id");
                        foreach (DataRow dr in objFaultDataTable.Rows)
                        {
                            string faultName = Convert.ToString(dr["pf_name"]);
                            float Freqv = (float)Convert.ToDouble(dr["pf_Freq"]);
                            int PointID = (int)dr["Point_ID"];
                            DataRow objNewRow = objFaultDataTable.NewRow();
                            objNewRow["Freq"] = Freqv;
                            objNewRow["faultName"] = faultName;
                            objNewRow["point_id"] = PointID;

                        }

                        try
                        {
                            objPointRecordTable = new DataTable();
                            SqlCeCommand objNewCommand1 = new SqlCeCommand();
                            SqlCeDataReader objceReader = null;
                            objNewConnection.ConnectionString = PublicClass.sdfconnection;
                            string sNewCommandText = null;
                            objNewConnection.Open();
                            data = new ArrayList();
                            objPointRecordTable = new DataTable();
                            objPointRecordTable.Columns.Add("pr_id");
                            objPointRecordTable.Columns.Add("measure_time");
                            objPointRecordTable.Columns.Add("accel_a");
                            objPointRecordTable.Columns.Add("accel_h");
                            objPointRecordTable.Columns.Add("accel_v");
                            objPointRecordTable.Columns.Add("accel_ch1");
                            objPointRecordTable.Columns.Add("vel_a");
                            objPointRecordTable.Columns.Add("vel_h");
                            objPointRecordTable.Columns.Add("vel_v");
                            objPointRecordTable.Columns.Add("vel_ch1");
                            objPointRecordTable.Columns.Add("displ_a");
                            objPointRecordTable.Columns.Add("displ_h");
                            objPointRecordTable.Columns.Add("displ_v");
                            objPointRecordTable.Columns.Add("displ_ch1");
                            objPointRecordTable.Columns.Add("bearing_a");
                            objPointRecordTable.Columns.Add("bearing_h");
                            objPointRecordTable.Columns.Add("bearing_v");
                            objPointRecordTable.Columns.Add("bearing_ch1");
                            objPointRecordTable.Columns.Add("temperature");
                            objPointRecordTable.Columns.Add("process");
                            objPointRecordTable.Columns.Add("time_a");
                            objPointRecordTable.Columns.Add("time_h");
                            objPointRecordTable.Columns.Add("time_v");
                            objPointRecordTable.Columns.Add("time_ch1");
                            objPointRecordTable.Columns.Add("power_a");
                            objPointRecordTable.Columns.Add("power_h");
                            objPointRecordTable.Columns.Add("power_v");
                            objPointRecordTable.Columns.Add("power_ch1");
                            objPointRecordTable.Columns.Add("demodulate_a");
                            objPointRecordTable.Columns.Add("demodulate_h");
                            objPointRecordTable.Columns.Add("demodulate_v");
                            objPointRecordTable.Columns.Add("demodulate_ch1");

                            objPointRecordTable.Columns.Add("point_id");

                            objPointRecordTable.Columns.Add("crest_factor_a");
                            objPointRecordTable.Columns.Add("crest_factor_h");
                            objPointRecordTable.Columns.Add("crest_factor_v");
                            objPointRecordTable.Columns.Add("crest_factor_ch1");

                            objPointRecordTable.Columns.Add("power_a1");
                            objPointRecordTable.Columns.Add("power_h1");
                            objPointRecordTable.Columns.Add("power_v1");
                            objPointRecordTable.Columns.Add("power_ch11");

                            objPointRecordTable.Columns.Add("power1_a");
                            objPointRecordTable.Columns.Add("power1_h");
                            objPointRecordTable.Columns.Add("power1_v");
                            objPointRecordTable.Columns.Add("power1_ch1");


                            objPointRecordTable.Columns.Add("power1_a1");
                            objPointRecordTable.Columns.Add("power1_h1");
                            objPointRecordTable.Columns.Add("power1_v1");
                            objPointRecordTable.Columns.Add("power1_ch11");

                            objPointRecordTable.Columns.Add("power2_a");
                            objPointRecordTable.Columns.Add("power2_h");
                            objPointRecordTable.Columns.Add("power2_v");
                            objPointRecordTable.Columns.Add("power2_ch1");

                            objPointRecordTable.Columns.Add("power2_a1");
                            objPointRecordTable.Columns.Add("power2_h1");
                            objPointRecordTable.Columns.Add("power2_v1");
                            objPointRecordTable.Columns.Add("power2_ch11");


                            DataRow objNewRow = null;
                            ArrayList arlcheck = new ArrayList();
                            for (int ictr = 0; ictr < arlpointID.Count; ictr++)
                            {
                                try
                                {
                                    sNewCommandText = "select * from point_record order by pr_id desc";
                                    objNewCommand1.CommandText = sNewCommandText;
                                    objNewCommand1.Connection = objNewConnection;
                                    objceReader = objNewCommand1.ExecuteReader();
                                    while (objceReader.Read())
                                    {
                                        objNewRow = objPointRecordTable.NewRow();


                                        float point_id = (float)Convert.ToDouble(objceReader["point_id"]);
                                        bool present = false;
                                        for (int ixctr = 0; ixctr < arlcheck.Count; ixctr++)
                                        {
                                            if (point_id == (float)Convert.ToDouble(arlcheck[ixctr]))
                                            {
                                                present = true;
                                                break;
                                            }
                                        }
                                        if (present == false)
                                        {
                                            arlcheck.Add(point_id);
                                            int pr_id = Convert.ToInt32(objceReader["pr_id"]);
                                            int measure_time = Convert.ToInt32(objceReader["measure_time"]);
                                            float accel_a = (float)Convert.ToDouble(objceReader["accel_a"]);
                                            float accel_h = (float)Convert.ToDouble(objceReader["accel_h"]);
                                            float accel_v = (float)Convert.ToDouble(objceReader["accel_v"]);
                                            float accel_ch1 = (float)Convert.ToDouble(objceReader["accel_ch1"]);

                                            float vel_a = (float)Convert.ToDouble(objceReader["vel_a"]);
                                            float vel_h = (float)Convert.ToDouble(objceReader["vel_h"]);
                                            float vel_v = (float)Convert.ToDouble(objceReader["vel_v"]);
                                            float vel_ch1 = (float)Convert.ToDouble(objceReader["vel_ch1"]);

                                            float displ_a = (float)Convert.ToDouble(objceReader["displ_a"]);
                                            float displ_h = (float)Convert.ToDouble(objceReader["displ_h"]);
                                            float displ_v = (float)Convert.ToDouble(objceReader["displ_v"]);
                                            float displ_ch1 = (float)Convert.ToDouble(objceReader["displ_ch1"]);


                                            float bearing_a = (float)Convert.ToDouble(objceReader["bearing_a"]);
                                            float bearing_h = (float)Convert.ToDouble(objceReader["bearing_h"]);
                                            float bearing_v = (float)Convert.ToDouble(objceReader["bearing_v"]);
                                            float bearing_ch1 = (float)Convert.ToDouble(objceReader["bearing_ch1"]);

                                            float crestfactor_a = 0;
                                            float crestfactor_h = 0;
                                            float crestfactor_v = 0;
                                            float crestfactor_ch1 = 0;


                                            float ordertrace_a_real = 0;
                                            float ordertrace_h_real = 0;
                                            float ordertrace_v_real = 0;
                                            float ordertrace_ch1_real = 0;
                                            float ordertrace_a_image = 0;
                                            float ordertrace_h_image = 0;
                                            float ordertrace_v_image = 0;
                                            float ordertrace_ch1_image = 0;
                                            float ordertrace_Rpm = 0;
                                            try
                                            {
                                                crestfactor_a = (float)Convert.ToDouble(objceReader["crest_factor_a"]);
                                                crestfactor_h = (float)Convert.ToDouble(objceReader["crest_factor_h"]);
                                                crestfactor_v = (float)Convert.ToDouble(objceReader["crest_factor_v"]);
                                                crestfactor_ch1 = (float)Convert.ToDouble(objceReader["crest_factor_ch1"]);

                                            }
                                            catch
                                            {
                                            }

                                            try
                                            {
                                                ordertrace_a_real = (float)Convert.ToDouble(objceReader["ordertrace_a_real"]);
                                                ordertrace_h_real = (float)Convert.ToDouble(objceReader["ordertrace_h_real"]);
                                                ordertrace_v_real = (float)Convert.ToDouble(objceReader["ordertrace_v_real"]);
                                                ordertrace_ch1_real = (float)Convert.ToDouble(objceReader["ordertrace_ch1_real"]);

                                                ordertrace_a_image = (float)Convert.ToDouble(objceReader["ordertrace_a_image"]);
                                                ordertrace_h_image = (float)Convert.ToDouble(objceReader["ordertrace_h_image"]);
                                                ordertrace_v_image = (float)Convert.ToDouble(objceReader["ordertrace_v_image"]);
                                                ordertrace_ch1_image = (float)Convert.ToDouble(objceReader["ordertrace_ch1_image"]);
                                                ordertrace_Rpm = (float)Convert.ToDouble(objceReader["ordertrace_Rpm"]);

                                            }
                                            catch { }

                                            objNewRow["pr_id"] = pr_id;
                                            objNewRow["measure_time"] = measure_time;

                                            objNewRow["accel_a"] = accel_a;
                                            objNewRow["accel_h"] = accel_h;
                                            objNewRow["accel_v"] = accel_v;
                                            objNewRow["accel_ch1"] = accel_ch1;

                                            objNewRow["vel_a"] = vel_a;
                                            objNewRow["vel_h"] = vel_h;
                                            objNewRow["vel_v"] = vel_v;
                                            objNewRow["vel_ch1"] = vel_ch1;

                                            objNewRow["displ_a"] = displ_a;
                                            objNewRow["displ_h"] = displ_h;
                                            objNewRow["displ_v"] = displ_v;
                                            objNewRow["displ_ch1"] = displ_ch1;

                                            objNewRow["bearing_a"] = bearing_a;
                                            objNewRow["bearing_h"] = bearing_h;
                                            objNewRow["bearing_v"] = bearing_v;
                                            objNewRow["bearing_ch1"] = bearing_ch1;

                                            objNewRow["temperature"] = (float)Convert.ToDouble(objceReader["temperature"]);
                                            objNewRow["process"] = (float)Convert.ToDouble(objceReader["process"]);





                                            objNewRow["point_id"] = point_id;

                                            objNewRow["crest_factor_a"] = crestfactor_a;
                                            objNewRow["crest_factor_h"] = crestfactor_h;
                                            objNewRow["crest_factor_v"] = crestfactor_v;
                                            objNewRow["crest_factor_ch1"] = crestfactor_ch1;


                                            objNewRow["ordertrace_a_real"] = ordertrace_a_real;
                                            objNewRow["ordertrace_h_real"] = ordertrace_h_real;
                                            objNewRow["ordertrace_v_real"] = ordertrace_v_real;
                                            objNewRow["ordertrace_ch1_real"] = ordertrace_ch1_real;

                                            objNewRow["ordertrace_a_image"] = ordertrace_a_image;
                                            objNewRow["ordertrace_h_image"] = ordertrace_h_image;
                                            objNewRow["ordertrace_v_image"] = ordertrace_v_image;
                                            objNewRow["ordertrace_ch1_image"] = ordertrace_ch1_image;
                                            objNewRow["ordertrace_Rpm"] = ordertrace_Rpm;

                                            objPointRecordTable.Rows.Add(objNewRow);
                                        }
                                    }
                                    objceReader.Close();
                                }
                                catch (Exception ex)
                                { }
                                finally
                                {
                                    objceReader.Close();

                                }
                            }
                        }
                        catch (Exception ex)
                        { }

                        try
                        {
                            _sCurrentDatabaseName = PublicClass.databasename;
                            CrtRt = objCurrentNode;
                            if (CrtRt == "")
                            {
                                do
                                {
                                    CrtRt = objCurrentNode;
                                } while (CrtRt == "");
                            }

                            if (_sCurrentDatabaseName != null)
                            {
                                sConnectionString = PublicClass.sdfconnection;
                            }

                            SqlCeCommand objNewCommand = new SqlCeCommand();
                            string sNewCommandText = null;


                            //Inserting Values in Plants
                            sNewCommandText = "delete from Plants";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();

                            try
                            {
                                if (Convert.ToInt32(routelevelid) != 0 && routename != "")
                                {
                                    if (_objupdown != null)
                                    {
                                        _objupdown.ShowMessage("Status:Filling Plants");
                                    }

                                    sNewCommandText = "insert into plants(plant_id,plant_name)values(" + routelevelid + ",'" + routename + "')";
                                    objNewCommand.CommandText = sNewCommandText;
                                    objNewCommand.Connection = objNewConnection;
                                    objNewCommand.ExecuteNonQuery();
                                }
                            }
                            catch { }


                            sNewCommandText = "delete from Areas";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();


                            foreach (DataRow objDataRow in objAreaDataTable1.Rows)
                            {
                                int iAreaID = Convert.ToInt16(objDataRow["AreaID"]);
                                string sAreaName = (string)objDataRow["AreaName"];
                                int iAreaPlantID = Convert.ToInt16(objDataRow["ParentID"]);
                                if (iAreaID != 0 && sAreaName != "")
                                {
                                    if (_objupdown != null)
                                    {
                                        _objupdown.ShowMessage("Status:Filling Areas");
                                    }

                                    sNewCommandText = "insert into Areas(area_id,area_name,plant_id)values(" + iAreaID + ",'" + sAreaName + "'," + iAreaPlantID + ")";
                                    objNewCommand.CommandText = sNewCommandText;
                                    objNewCommand.Connection = objNewConnection;
                                    objNewCommand.ExecuteNonQuery();
                                }

                            }

                            sNewCommandText = "delete from Trains";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();

                            foreach (DataRow objDataRow in objTrainDataTable1.Rows)
                            {

                                int iTrainID = Convert.ToInt16(objDataRow["TrainID"]);
                                string sTrainName = (string)objDataRow["TrainName"];
                                int iTrainAreaID = Convert.ToInt16(objDataRow["ParentId"]);

                                if (iTrainID != 0 && sTrainName != "")
                                {
                                    if (_objupdown != null)
                                    {
                                        _objupdown.ShowMessage("Status:Filling Trains");
                                    }
                                    sNewCommandText = "insert into Trains(train_id,train_name,area_id)values(" + iTrainID + ",'" + sTrainName + "'," + iTrainAreaID + ")";
                                    objNewCommand.CommandText = sNewCommandText;
                                    objNewCommand.Connection = objNewConnection;
                                    objNewCommand.ExecuteNonQuery();
                                }
                            }

                            sNewCommandText = "delete from Machines";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();

                            foreach (DataRow objDataRow in objMachineDataTable1.Rows)
                            {
                                int picture_type = 0;
                                byte[] machine_picture = null;
                                int iMachineID = Convert.ToInt16(objDataRow["MachineID"]);
                                string sMachineName = (string)objDataRow["MachineName"];
                                int iMachineTrainID = Convert.ToInt16(objDataRow["ParentID"]);
                                if (iMachineID != 0 && sMachineName != "")
                                {
                                    double iMachinesrv = Convert.ToInt16(objDataRow["Rev"]);
                                    double iMachineRpm = Convert.ToInt16(objDataRow["Rpm"]);

                                    if (_objupdown != null)
                                    {
                                        _objupdown.ShowMessage("Status:Filling Machine");
                                    }
                                    try
                                    {


                                        string ss = null;
                                        ss = iMachineID.ToString();
                                        DataTable machdt = new DataTable();
                                        machdt = DbClass.getdata(CommandType.Text, "SELECT * FROM machine_pic where MachineID='" + ss + "'");
                                        foreach (DataRow dr in machdt.Rows)
                                        {
                                            string Filename = Convert.ToString(dr["Picture"]);
                                            Filename = Filename.Replace('-', '\\');
                                            Image imgImage = Image.FromFile(Filename);
                                            byte[] machine_image = ImageToByte(imgImage);
                                            if (machine_image == null)
                                            {
                                                machine_image = new byte[0];
                                            }
                                            else
                                                picture_type = 1;
                                            machine_picture = machine_image;
                                        }


                                    }
                                    catch { }

                                    sNewCommandText = "insert into Machines(machine_id,machine_name,machine_rpm,machine_pulsesrev, picture_type,train_id) values(" + iMachineID + ",'" + sMachineName + "'," + iMachineRpm + "," + iMachinesrv + "," + picture_type + "," + iMachineTrainID + ")";
                                    objNewCommand.CommandText = sNewCommandText;
                                    objNewCommand.Connection = objNewConnection;
                                    objNewCommand.ExecuteNonQuery();
                                    if (picture_type == 1)
                                    {

                                        sNewCommandText = "update Machines SET machine_picture = @pic Where machine_id = " + iMachineID + " ";

                                        using (SqlCeConnection con = new SqlCeConnection(sConnectionString))
                                        using (SqlCeCommand cmd = new SqlCeCommand(sNewCommandText, objNewConnection))
                                        {
                                            con.Open();
                                            cmd.Parameters.Add("@pic", SqlDbType.Image, machine_picture.Length).Value = machine_picture;
                                            cmd.ExecuteNonQuery();
                                            con.Close();
                                        }
                                    }

                                }
                            }
                            sNewCommandText = "delete from points";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();
                            foreach (DataRow objDataRow in objPointDataTable1.Rows)
                            {
                                int iPointID = Convert.ToInt16(objDataRow["PointID"]);
                                string sPointName = (string)objDataRow["Point_Name"];
                                int iPointMachineID = Convert.ToInt16(objDataRow["ParentID"]);

                                if (iPointID != 0 && sPointName != "")
                                {
                                    if (_objupdown != null)
                                    {
                                        _objupdown.ShowMessage("Status:Filling Point Table Data");
                                    }
                                    try
                                    {
                                        DataTable dtpoint = new DataTable();
                                        dtpoint = DbClass.getdata(CommandType.Text, "select pt.point_ID,pt.PointName,pt.PointType_ID from point pt inner join type_point tp on pt.PointType_ID=tp.Type_ID where pt.PointType_ID !='0' and tp.Instrumentname='"+PublicClass.currentInstrument+"'");
                                        foreach (DataRow dr in dtpoint.Rows)
                                        {
                                            string ptID = Convert.ToString(dr["Point_ID"]);
                                            string ptName = Convert.ToString(dr["PointName"]);
                                            string ptTypeID = Convert.ToString(dr["PointType_ID"]);
                                            DataTable gettypeID = new DataTable();


                                            DataTable dt1 = new DataTable();
                                            dt1 = DbClass.getdata(CommandType.Text, " select pt.point_id,pt.pointname,pt.pointtype_id,mea.power_multiple,unit.unit_id,mea.ID,tp.alarm_id, pt.machine_id,sd.sensor_name,mea.sensor_id,mea.temperatureID  , tp.note_id,tp.point_record_status , tp.point_status , tp.point_schedule , tp.point_measurement , tp.record_id FROM type_point tp inner join measure_type mt on tp.Type_ID=mt.Type_ID left join point pt on tp.Type_ID=pt.PointType_ID left join measure mea on tp.Type_ID=mea.Type_ID left join sensor_data sd on sd.sensor_type= mea.Sensor_ID left join units unit on tp.Type_ID = unit.Type_ID where pt.Point_ID = '" + ptID + "' group by pt.point_id");
                                            foreach (DataRow dr1 in dt1.Rows)
                                            {
                                                string pUnitid = Convert.ToString(dr1["unit_id"]);
                                                string mesID = Convert.ToString(dr1["ID"]);
                                                string pAlarmId = Convert.ToString(dr1["alarm_id"]);
                                                string pMachineID = Convert.ToString(dr1["machine_id"]);
                                                string pStatus = Convert.ToString(dr1["point_status"]);
                                                string pSchedule = Convert.ToString(dr1["point_schedule"]);
                                                string pMeasurment = Convert.ToString(dr1["point_measurement"]);
                                                string vibSensor = Convert.ToString(dr1["sensor_id"]);
                                                string tempSensor = Convert.ToString(dr1["TemperatureID"]);
                                                string pNoteID = Convert.ToString(dr1["note_id"]);
                                                string pRecordID = Convert.ToString(dr1["record_id"]);
                                                string pRecordStatus = Convert.ToString(dr1["point_record_status"]);
                                                string pdir = Convert.ToString(dr1["power_multiple"]);

                                                sNewCommandText = "insert into Points(Point_id,Point_name,point_dir,point_record_status,point_status,point_schedule,point_measurement,vibration_sensor,temperature_sensor,unit_id,measure_id,note_id,alarm_id,machine_id,record_id) values(" + ptID + ",'" + ptName + "','"
                                                    + pdir + "','" + pRecordStatus + "','" + pStatus + "','" + pSchedule + "','" + pMeasurment + "','" + vibSensor + "','" + tempSensor + "','" + pUnitid + "','" + mesID + "','" + (pNoteID) + "','" + (pAlarmId) + "','" + (pMachineID) + "','" + (pRecordID) + "')";
                                                objNewCommand.CommandText = sNewCommandText;
                                                objNewCommand.Connection = objNewConnection;
                                                objNewCommand.ExecuteNonQuery();


                                            }

                                        }
                                    }
                                    catch { }



                                }



                            }






                            sNewCommandText = "delete from sensors";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();

                            try
                            {
                                if (_objupdown != null)
                                {
                                    _objupdown.ShowMessage("Status:Reading Sensors Data");
                                }
                                DataTable dtsen = new DataTable();
                                dtsen = DbClass.getdata(CommandType.Text, "select * from sensor_data order by Sensor_ID asc");
                                foreach (DataRow drsen in dtsen.Rows)
                                {
                                    string iSensorID = Convert.ToString(drsen["Sensor_ID"]);
                                    string sSensorName = Convert.ToString(drsen["Sensor_name"]);
                                    string btSensorType = Convert.ToString(drsen["Sensor_type"]);
                                    string fSenstivity_A = Convert.ToString(drsen["Sensitivity_a"]);
                                    string fSenstivity_H = Convert.ToString(drsen["Sensitivity_h"]);
                                    string fSenstivity_V = Convert.ToString(drsen["Sensitivity_v"]);
                                    string fSenstivity_ch1 = Convert.ToString(drsen["Senitivity_Ch1"]);
                                    string btSensor_Unit = Convert.ToString(drsen["Sensor_unit"]);
                                    string btSensor_dir = Convert.ToString(drsen["Sensor_dir"]);
                                    string btSensor_icp = Convert.ToString(drsen["Sensor_icp"]);
                                    string fSensor_offset = Convert.ToString(drsen["Sensor_offset"]);                                    
                                    sNewCommandText = "insert into sensors(sensor_id,sensor_name,sensor_type,sensitivity_ch1,sensitivity_a,sensitivity_h,sensitivity_v,sensor_unit,sensor_dir,sensor_icp,sensor_offset)values(" + iSensorID + ",'" + sSensorName + "'," + btSensorType + "," + fSenstivity_ch1 + "," + fSenstivity_A + "," + fSenstivity_H + "," + fSenstivity_V + "," + btSensor_Unit + "," + btSensor_dir + "," + btSensor_icp + "," + fSensor_offset + ")";
                                    objNewCommand.CommandText = sNewCommandText;
                                    objNewCommand.Connection = objNewConnection;
                                    objNewCommand.ExecuteNonQuery();
                                    iSensorCtr++;
                                }


                            }
                            catch { }


                            sNewCommandText = "delete from notes";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();
                            try
                            {
                                if (_objupdown != null)
                                {
                                    _objupdown.ShowMessage("Status:Reading Notes Data");
                                }
                                DataTable dtnote = new DataTable();
                                dtnote = DbClass.getdata(CommandType.Text, "SELECT * FROM notes where Note_Type='2' order by Notes_ID");
                                foreach (DataRow drnote in dtnote.Rows)
                                {
                                    string iNoteID = Convert.ToString(drnote["Notes_ID"]);
                                    string iNoteDesc = Convert.ToString(drnote["Notes_Desc"]);
                                   // string iNoteType = Convert.ToString(drnote["Note_type"]);

                                    sNewCommandText = "insert into notes(note_id,note_desc)values(" + iNoteID + ",'" + iNoteDesc + "')";
                                    objNewCommand.CommandText = sNewCommandText;
                                    objNewCommand.Connection = objNewConnection;
                                    objNewCommand.ExecuteNonQuery();

                                }

                            }
                            catch { }

                            sNewCommandText = "delete from units";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();
                            try
                            {
                                if (_objupdown != null)
                                {
                                    _objupdown.ShowMessage("Status:Reading Notes Data");
                                }
                                DataTable dtunit = new DataTable();
                                dtunit = DbClass.getdata(CommandType.Text, "select pt.point_ID,pt.PointName,pt.PointType_ID from point pt inner join type_point tp on pt.PointType_ID=tp.Type_ID where pt.PointType_ID !='0'");
                                foreach (DataRow drunit in dtunit.Rows)
                                {
                                    string itypeID = Convert.ToString(drunit["PointType_ID"]);
                                    DataTable dtun = new DataTable();
                                    dtun = DbClass.getdata(CommandType.Text, "select * from units where type_id='" + itypeID + "'");
                                    foreach (DataRow drun in dtun.Rows)
                                    {
                                        string iPointID = Convert.ToString(drun["Unit_ID"]);
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
                                        int btInput_Range = 0;


                                        sNewCommandText = "insert into units(unit_id,accel_unit,vel_unit,displ_unit,temperature_unit,process_unit,accel_detection,vel_detection,displ_detection,time_unit_type,power_unit_type,demodulate_unit_type,pressure_unit, current_unit, pressure_detection,current_detection, ordertrace_unit_type, cepstrum_unit_type,Input_Range)values(" + iPointID + "," + btAccel_Unit + "," + btVel_Unit + "," + btDispl_Unit + "," + btTemperature_Unit + ",'" + sProcess_Unit + "'," + btAccel_Detection + "," + btVel_Detection + "," + btDispl_Detection + "," + btTime_Unit_Type + "," + btPower_unit_type + "," + btDemodulate_Unit_Type + "," + btPressureUnit + "," + btCurrentUnit + "," + btPressure_detection + "," + btCurrent_detection + "," + btordertrace_unit_type + "," + btcepstrum_unit_type + "," + btInput_Range + ")";
                                        objNewCommand.CommandText = sNewCommandText;
                                        objNewCommand.Connection = objNewConnection;
                                        objNewCommand.ExecuteNonQuery();

                                    }



                                }



                            }
                            catch { }

                            sNewCommandText = "delete from point_faultfreq";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();
                            try
                            {
                                if (_objupdown != null)
                                {
                                    _objupdown.ShowMessage("Status:Reading faultfreq Data");
                                }
                                DataTable dtunit = new DataTable();
                                dtunit = DbClass.getdata(CommandType.Text, "SELECT * FROM faultfreq_data ffd inner join point_faultfreq pff on pff.FaultFreq_ID=ffd.Pf_ID");
                                foreach (DataRow drunit in dtunit.Rows)
                                {

                                    int iPfID = Convert.ToInt32(drunit["Pf_ID"]);
                                    string iPfname = Convert.ToString(drunit["pf_name"]);
                                    string iPfFreq = Convert.ToString(drunit["pf_freq"]);
                                    string iPfPointID = Convert.ToString(drunit["Point_ID"]);



                                    sNewCommandText = "insert into point_faultfreq(pf_id,pf_name,pf_freq,point_id) values(" + iPfID + ",'" + iPfname + "'," + iPfFreq + "," + iPfPointID + ")";
                                    objNewCommand.CommandText = sNewCommandText;
                                    objNewCommand.Connection = objNewConnection;
                                    objNewCommand.ExecuteNonQuery();

                                    iPointCounter++;
                                }
                            }
                            catch { }


                            sNewCommandText = "delete from alarms";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();
                            try
                            {
                                if (_objupdown != null)
                                {
                                    _objupdown.ShowMessage("Status:Reading Alarms Data");
                                }
                                DataTable dtunit = new DataTable();
                                dtunit = DbClass.getdata(CommandType.Text, "select * from alarms_data ad inner join point_alarm tp on tp.Alarm_ID=ad.Alarm_ID");
                                foreach (DataRow drunit in dtunit.Rows)
                                {
                                    int iPointID = Convert.ToInt32(drunit["Alarm_ID"]);
                                    float faccAxialHigh = (float)Convert.ToDouble(drunit["accel_a1"]);
                                    float faccAxialLow = (float)Convert.ToDouble(drunit["accel_a2"]);
                                    float faccHorizHigh = (float)Convert.ToDouble(drunit["accel_h1"]);
                                    float faccHorizLow = (float)Convert.ToDouble(drunit["accel_h2"]);
                                    float faccVerHigh = (float)Convert.ToDouble(drunit["accel_v1"]);
                                    float faccVerLow = (float)Convert.ToDouble(drunit["accel_v2"]);


                                    float fvelAxialHigh = (float)Convert.ToDouble(drunit["vel_a1"]);
                                    float fvelAxialLow = (float)Convert.ToDouble(drunit["vel_a2"]);
                                    float fvelVerHigh = (float)Convert.ToDouble(drunit["vel_v1"]);
                                    float fvelVerLow = (float)Convert.ToDouble(drunit["vel_v2"]);
                                    float fvelHorizHigh = (float)Convert.ToDouble(drunit["vel_h1"]);
                                    float fvelHorizLow = (float)Convert.ToDouble(drunit["vel_h2"]);


                                    float fDispAxialHigh = (float)Convert.ToDouble(drunit["displ_a1"]);
                                    float fDispAxialLow = (float)Convert.ToDouble(drunit["displ_a2"]);
                                    float fDispVerHigh = (float)Convert.ToDouble(drunit["displ_v1"]);
                                    float fDispVerLow = (float)Convert.ToDouble(drunit["displ_v2"]);
                                    float fDispHorizHigh = (float)Convert.ToDouble(drunit["displ_h1"]);
                                    float fDispHorizLow = (float)Convert.ToDouble(drunit["displ_h2"]);

                                    float fBearAxialHigh = (float)Convert.ToDouble(drunit["bearing_a1"]);
                                    float fBearAxialLow = (float)Convert.ToDouble(drunit["bearing_a2"]);
                                    float fBearVerHigh = (float)Convert.ToDouble(drunit["bearing_h1"]);
                                    float fBearVerLow = (float)Convert.ToDouble(drunit["bearing_h2"]);
                                    float fBearHorizHigh = (float)Convert.ToDouble(drunit["bearing_v1"]);
                                    float fBearHorizLow = (float)Convert.ToDouble(drunit["bearing_v2"]);



                                    float fcrestfactorAxialHigh = (float)Convert.ToDouble(drunit["crest_factor_a1"]);
                                    float fcrestfactorAxialLow = (float)Convert.ToDouble(drunit["crest_factor_a2"]);
                                    float fcrestfactorVerHigh = (float)Convert.ToDouble(drunit["crest_factor_h1"]);
                                    float fcrestfactorVerLow = (float)Convert.ToDouble(drunit["crest_factor_h2"]);
                                    float fcrestfactorHorizHigh = (float)Convert.ToDouble(drunit["crest_factor_v1"]);
                                    float fcrestfactorHorizLow = (float)Convert.ToDouble(drunit["crest_factor_v2"]);



                                    float faccch1High = (float)Convert.ToDouble(drunit["accel_ch11"]);
                                    float faccch1Low = (float)Convert.ToDouble(drunit["accel_ch12"]);
                                    float fvelch1High = (float)Convert.ToDouble(drunit["vel_ch11"]);
                                    float fvelch1Low = (float)Convert.ToDouble(drunit["vel_ch12"]);
                                    float fDispch1High = (float)Convert.ToDouble(drunit["displ_ch11"]);
                                    float fDispch1Low = (float)Convert.ToDouble(drunit["displ_ch12"]);
                                    float fBearch1High = (float)Convert.ToDouble(drunit["bearing_ch11"]);
                                    float fBearch1Low = (float)Convert.ToDouble(drunit["bearing_ch12"]);
                                    float fcrestfactorch1High = (float)Convert.ToDouble(drunit["crest_factor_ch11"]);
                                    float fcrestfactorch1Low = (float)Convert.ToDouble(drunit["crest_factor_ch12"]);

                                    float fTempHigh = (float)Convert.ToDouble(drunit["temperature_1"]);
                                    float fTemplow = (float)Convert.ToDouble(drunit["temperature_2"]);


                                    sNewCommandText = "insert into alarms(alarm_id,accel_ch11,accel_ch12,accel_a1,accel_h1,accel_v1,accel_a2,accel_h2,accel_v2,vel_ch11,vel_ch12,vel_a1,vel_h1,vel_v1,vel_a2,vel_h2,vel_v2,displ_ch11,displ_ch12,displ_a1,displ_h1,displ_v1,displ_a2,displ_h2,displ_v2,bearing_ch11,bearing_ch12,bearing_a1,bearing_h1,bearing_v1,bearing_a2,bearing_h2,bearing_v2,temperature_1,temperature_2,crestfactor_ch11,crestfactor_ch12,crestfactor_a1,crestfactor_h1 ,crestfactor_v1 ,crestfactor_a2 ,crestfactor_h2 ,crestfactor_v2 )values(" +
                                    iPointID + "," + faccch1High + "," + faccch1Low + "," + faccAxialHigh + "," + faccHorizHigh + "," + faccVerHigh + "," + faccAxialLow + "," + faccHorizLow + "," + faccVerLow + "," +
                                    fvelch1High + "," + fvelch1Low + "," + fvelAxialHigh + "," + fvelHorizHigh + "," + fvelVerHigh + "," + fvelAxialLow + "," + fvelHorizLow + "," + fvelVerLow + "," +
                                    fDispch1High + "," + fDispch1Low + "," + fDispAxialHigh + "," + fDispHorizHigh + "," + fDispVerHigh + "," + fDispAxialLow + "," + fDispHorizLow + "," + fDispVerLow + "," +
                                    fBearch1High + "," + fBearch1Low + "," + fBearAxialHigh + "," + fBearHorizHigh + "," + fBearVerHigh + "," + fBearAxialLow + "," + fBearHorizLow + "," + fBearVerLow + "," + fTempHigh + "," + fTemplow + "," +
                                    fcrestfactorch1High + "," + fcrestfactorch1Low + "," + fcrestfactorAxialHigh + "," + fcrestfactorHorizHigh + "," + fcrestfactorVerHigh + "," + fcrestfactorAxialLow + "," + fcrestfactorHorizLow + "," + fcrestfactorVerLow + ")"; // for version 6 and above
                                    objNewCommand.CommandText = sNewCommandText;
                                    objNewCommand.Connection = objNewConnection;
                                    objNewCommand.ExecuteNonQuery();

                                }
                            }
                            catch { }


                            sNewCommandText = "delete from bandalarm";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();
                            try
                            {
                                if (_objupdown != null)
                                {
                                    _objupdown.ShowMessage("Status:Reading bandalarm Data");
                                }
                                DataTable dtunit = new DataTable();
                                dtunit = DbClass.getdata(CommandType.Text, "SELECT distinct * FROM band_data ffd inner join point_balarm pff on pff.BA_ID=ffd.ID group by pff.BA_ID");
                                foreach (DataRow drunit in dtunit.Rows)
                                {

                                    int ibandID = Convert.ToInt32(drunit["ID"]);
                                    int ibandaxis = 0;
                                    string ibandFreq = Convert.ToString(drunit["Freq"]);
                                    string bandX = Convert.ToString(drunit["X"]);
                                    int bandY = Convert.ToInt32(drunit["Y"]);
                                    string ibandPT_ID = Convert.ToString(drunit["Point_ID"]);




                                    sNewCommandText = "insert into bandalarm(bandalarm_id,Freq,alarm1,alarm2,axis_type,point_id) values(" + ibandID + ",'" + ibandFreq + "'," + bandX + "," + bandY + "," + ibandaxis + "," + ibandPT_ID + ")";
                                    objNewCommand.CommandText = sNewCommandText;
                                    objNewCommand.Connection = objNewConnection;
                                    objNewCommand.ExecuteNonQuery();




                                }
                            }
                            catch { }


                            string Notes = GetProperStringForNotes(PublicClass.routename);
                            try
                            {
                                objNewCommand.CommandText = "update system_info set note='" + Notes + "'";
                                objNewCommand.Connection = objNewConnection;
                                objNewCommand.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {
                                //ErrorLogFile(ex);
                            }






                            sNewCommandText = "delete from measures";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();
                            try
                            {
                                if (_objupdown != null)
                                {
                                    _objupdown.ShowMessage("Status:Reading measures Data");
                                }
                                DataTable dtunit = new DataTable();
                                dtunit = DbClass.getdata(CommandType.Text, "select pt.point_ID,pt.PointName,pt.PointType_ID from point pt inner join type_point tp on pt.PointType_ID=tp.Type_ID where pt.PointType_ID !='0' group by pt.PointType_ID order by pt.point_ID;");
                                foreach (DataRow drunit in dtunit.Rows)
                                {
                                    string itypeID = Convert.ToString(drunit["PointType_ID"]);
                                    DataTable dtun = new DataTable();
                                    dtun = DbClass.getdata(CommandType.Text, "select * from measure where Type_ID='" + itypeID + "'");
                                    foreach (DataRow drun in dtun.Rows)
                                    {
                                        try
                                        {

                                            int iPointID = Convert.ToInt32(drun["ID"]);
                                            byte btAcc_Filter = Convert.ToByte(drun["acc_filter"]);
                                            byte btVel_Filter = Convert.ToByte((string)(drun["vel_filter"]));
                                            byte btDispl_Filter = Convert.ToByte((string)(drun["displ_filter"]));
                                            byte btOverall_Bearing_filter = Convert.ToByte((string)(drun["overall_bearing_filter"]));
                                            byte btTime_Band = Convert.ToByte((string)(drun["time_band"]));
                                            byte btTime_Resolution = Convert.ToByte((string)(drun["time_resoltion"]));
                                            byte btTime_Overlap = Convert.ToByte((string)(drun["time_overlap"]));
                                            byte btPower_Band = Convert.ToByte((string)(drun["power_band"]));
                                            byte btPower_Resolution = Convert.ToByte((string)(drun["power_resolution"]));
                                            byte btPower_Window = Convert.ToByte((string)(drun["power_window"]));
                                            byte btPower_Average_Times = Convert.ToByte((string)(drun["power_average_times"]));
                                            byte btPower_Overlap = Convert.ToByte((string)(drun["power_overlap"]));
                                            int btPower_Zoom = Convert.ToInt32(drun["power_zoom"]);
                                            float fPower_Zoom_Startfreq = (float)(Convert.ToDouble(drun["power_zoom_startfeq"]));
                                            byte btDemodulate_Band = Convert.ToByte((string)(drun["demodulate_band"]));
                                            byte btDemodulate_Resolution = Convert.ToByte((string)(drun["demodulate_resolution"]));
                                            byte btDemodulate_Window = Convert.ToByte((string)(drun["demodulate_window"]));
                                            byte btDemodulate_Average_Times = Convert.ToByte((string)(drun["demodulate_average_times"]));
                                            byte btDemodulate_Filter = Convert.ToByte((string)(drun["demodulate_filter"]));
                                            byte btPower_Multiple_Bands = Convert.ToByte((string)(drun["power_multiple"]));
                                            byte btPower_Band1 = Convert.ToByte((string)(drun["power_band1"]));
                                            byte btPower_Resolution1 = Convert.ToByte((string)(drun["power_resolution1"]));
                                            byte btCrest_Factor_Filter = Convert.ToByte((string)(drun["crest_factor_filter"]));
                                            byte btOrderTraceAvgTimes = Convert.ToByte((string)(drun["ordertrace_average_times"]));

                                            byte btOrderTraceResolution = Convert.ToByte((string)(drun["ordertrace_resolution"]));
                                            float btOrderTraceOrder = (float)(Convert.ToDouble(drun["ordertrace_order"]));
                                            byte btOrderTracetriggerSlope = Convert.ToByte((string)(drun["ordertrace_trigger_slope"]));
                                            byte btPower2_Band = Convert.ToByte((string)(drun["power2_band"]));
                                            byte btPower2_Resolution = Convert.ToByte((string)(drun["power2_resolution"]));
                                            byte btPower2_Band1 = Convert.ToByte((string)(drun["power2_band1"]));
                                            byte btPower2_Resolution1 = Convert.ToByte((string)(drun["power2_resolution1"]));

                                            byte btPower3_Band = Convert.ToByte((string)(drun["power3_band"]));
                                            byte btPower3_Resolution = Convert.ToByte((string)(drun["power3_resolution"]));
                                            byte btPower3_Band1 = Convert.ToByte((string)(drun["power3_band1"]));
                                            byte btPower3_Resolution1 = Convert.ToByte((string)(drun["power3_resolution1"]));
                                            byte btcepstrumBand = Convert.ToByte((string)(drun["cepstrum_band"]));
                                            byte btcepstrumResolution = Convert.ToByte((string)(drun["cepstrum_resolution"]));
                                            byte btcepstrumWindow = Convert.ToByte((string)(drun["cepstrum_window"]));
                                            byte btcepstrumAvgTimes = Convert.ToByte((string)(drun["cepstrum_average_times"]));
                                            byte btcepstrumOverlap = Convert.ToByte((string)(drun["cepstrum_overlap"]));
                                            int btcepstrumZoom = Convert.ToInt32(drun["cepstrum_zoom"]);
                                            float fcepstrumStartFreq = (float)(Convert.ToDouble(drun["cepstrum_zoom_startfeq"]));

                                            // sNewCommandText = "insert into measures(measure_id,acc_filter,vel_filter,displ_filter,overall_bearing_filter,time_band,time_resolution,time_overlap,power_band,power_resolution,power_window,power_average_times,power_overlap,power_zoom,power_zoom_startfreq,demodulate_band,demodulate_resolution,demodulate_window,demodulate_average_times,demodulate_filter,power_multiple,power_band1,power_resolution1,crest_factor_filter, ordertrace_average_times, ordertrace_resolution, ordertrace_order, ordertrace_trigger_slope, power2_band, power2_resolution, power2_band1, power2_resolution1, power3_band, power3_resolution, power3_band1, power3_resolution1, cepstrum_band, cepstrum_resolution, cepstrum_window, cepstrum_average_times, cepstrum_overlap, cepstrum_zoom, cepstrum_zoom_startfreq)values('" + iPointID + "','" + btAcc_Filter + "','" + btVel_Filter + "','" + btDispl_Filter + "','" + btOverall_Bearing_filter + "','" + btTime_Band + "','" + btTime_Resolution + "','" + btTime_Overlap + "','" + btPower_Band + "','" + btPower_Resolution + "','" + btPower_Window + "','" + btPower_Average_Times + "','" + btPower_Overlap + "','" + btPower_Zoom + "','" + fPower_Zoom_Startfreq + "','" + btDemodulate_Band + "','" + btDemodulate_Resolution + "','" + btDemodulate_Window + "','" + btDemodulate_Average_Times + "','" + btDemodulate_Filter + "','" + btPower_Multiple_Bands + "','" + btPower_Band1 + "','" + btPower_Resolution1 + "','" + btCrest_Factor_Filter + "','" + btOrderTraceAvgTimes + "','" + btOrderTraceResolution + "','" + btOrderTraceOrder + "','" + btOrderTracetriggerSlope + "','" + btPower2_Band + "','" + btPower2_Resolution + "','" + btPower2_Band1 + "','" + btPower2_Resolution1 + "','" + btPower3_Band + "','" + btPower3_Resolution + "','" + btPower3_Band1 + "','" + btPower3_Resolution1 + "','" + btcepstrumBand + "','" + btcepstrumResolution + "','" + btcepstrumWindow + "','" + btcepstrumAvgTimes + "','" + btcepstrumOverlap + "','" + btcepstrumZoom + "','" + fcepstrumStartFreq + "')";


                                            sNewCommandText = "insert into measures(measure_id,acc_filter,vel_filter,displ_filter,overall_bearing_filter,time_band,time_resolution,time_overlap,power_band,power_resolution,power_window,power_average_times,power_overlap,power_zoom,power_zoom_startfreq,demodulate_band,demodulate_resolution,demodulate_window,demodulate_average_times,demodulate_filter,power_multiple,power_band1,power_resolution1,crest_factor_filter, ordertrace_average_times, ordertrace_resolution, ordertrace_order, ordertrace_trigger_slope, power2_band, power2_resolution, power2_band1, power2_resolution1, power3_band, power3_resolution, power3_band1, power3_resolution1, cepstrum_band, cepstrum_resolution, cepstrum_window, cepstrum_average_times, cepstrum_overlap, cepstrum_zoom, cepstrum_zoom_startfreq)values(" + iPointID
                                                + ",'" + btAcc_Filter + "','" + btVel_Filter + "','" + btDispl_Filter + "','" + btOverall_Bearing_filter + "','" + btTime_Band + "'," + btTime_Resolution + ",'" + btTime_Overlap + "'," + btPower_Band + "," + btPower_Resolution + "," + btPower_Window + "," + btPower_Average_Times + "," + btPower_Overlap + "," + btPower_Zoom + "," + fPower_Zoom_Startfreq + "," + btDemodulate_Band + "," + btDemodulate_Resolution + "," + btDemodulate_Window + "," + btDemodulate_Average_Times + "," + btDemodulate_Filter + "," + btPower_Multiple_Bands + "," + btPower_Band1 + "," + btPower_Resolution1 + ",'" + btCrest_Factor_Filter + "'," + btOrderTraceAvgTimes + "," + btOrderTraceResolution + "," + btOrderTraceOrder + "," + btOrderTracetriggerSlope + "," + btPower2_Band + "," + btPower2_Resolution + "," + btPower2_Band1 + "," + btPower2_Resolution1 + "," + btPower3_Band + "," + btPower3_Resolution + "," + btPower3_Band1 + "," + btPower3_Resolution1 + "," + btcepstrumBand + "," + btcepstrumResolution + "," + btcepstrumWindow + "," + btcepstrumAvgTimes + "," + btcepstrumOverlap + "," + btcepstrumZoom + "," + fcepstrumStartFreq + ")";
                                            objNewCommand.CommandText = sNewCommandText;
                                            objNewCommand.Connection = objNewConnection;
                                            objNewCommand.ExecuteNonQuery();
                                        }
                                        catch { }
                                    }
                                }
                            }
                            catch (SqlCeException ex)
                            {
                                throw ex;
                            }

                            sNewCommandText = "delete from routes";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();
                            try
                            {
                                if (_objupdown != null)
                                {
                                    _objupdown.ShowMessage("Status:Reading Routes Data");
                                }

                                try
                                {
                                    //version 7
                                    DateTime CentuaryBegain = new DateTime(1970, 1, 1, 5, 30, 0, 0);
                                    DateTime currentDate = DateTime.Now;
                                    //DateTime.
                                    long elapsedTicks = currentDate.Ticks - CentuaryBegain.Ticks;
                                    TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                                    string[] dddd = elapsedSpan.TotalSeconds.ToString().Split(new string[] { "." }, StringSplitOptions.None);
                                    int iddd = Convert.ToInt32(dddd[0].ToString());
                                    sNewCommandText = "insert into routes(hierarchy_level,total_count,download_time,upload_time,archive_count,skip_count,backup_route)values(" + 0 + "," + iPointCounter + "," + iddd + "," + 0 + "," + 0 + "," + 0 + "," + 0 + ")";//version 7
                                    objNewCommand.CommandText = sNewCommandText;
                                    objNewCommand.Connection = objNewConnection;
                                    objNewCommand.ExecuteNonQuery();
                                }
                                catch { }
                            }
                            catch (Exception Ex)
                            {
                            }


                            sNewCommandText = "delete from point_record";
                            objNewCommand.CommandText = sNewCommandText;
                            objNewCommand.Connection = objNewConnection;
                            objNewCommand.ExecuteNonQuery();
                            try
                            {
                                if (_objupdown != null)
                                {
                                    _objupdown.ShowMessage("Status:Reading point_record Data");
                                }
                                DataTable dtunit = new DataTable();
                                dtunit = DbClass.getdata(CommandType.Text, "SELECT * FROM point_data");
                                foreach (DataRow drunit in dtunit.Rows)
                                {
                                    int pr_id = Convert.ToInt32(drunit["Data_id"]);
                                    int measure_time = 1397467258;
                                    float accel_a = (float)Convert.ToDouble(drunit["accel_a"]);
                                    float accel_h = (float)Convert.ToDouble(drunit["accel_h"]);
                                    float accel_v = (float)Convert.ToDouble(drunit["accel_v"]);
                                    float accel_ch1 = (float)Convert.ToDouble(drunit["accel_ch1"]);

                                    float vel_a = (float)Convert.ToDouble(drunit["vel_a"]);
                                    float vel_h = (float)Convert.ToDouble(drunit["vel_h"]);
                                    float vel_v = (float)Convert.ToDouble(drunit["vel_v"]);
                                    float vel_ch1 = (float)Convert.ToDouble(drunit["vel_ch1"]);

                                    float displ_a = (float)Convert.ToDouble(drunit["displ_a"]);
                                    float displ_h = (float)Convert.ToDouble(drunit["displ_h"]);
                                    float displ_v = (float)Convert.ToDouble(drunit["displ_v"]);
                                    float displ_ch1 = (float)Convert.ToDouble(drunit["displ_ch1"]);

                                    float bearing_a = (float)Convert.ToDouble(drunit["bearing_a"]);
                                    float bearing_h = (float)Convert.ToDouble(drunit["bearing_h"]);
                                    float bearing_v = (float)Convert.ToDouble(drunit["bearing_v"]);
                                    float bearing_ch1 = (float)Convert.ToDouble(drunit["bearing_ch1"]);

                                    float temperature = (float)Convert.ToDouble(drunit["temperature"]);
                                    float process = (float)Convert.ToDouble(drunit["process"]);

                                    float crestfactor_a = (float)Convert.ToDouble(drunit["crest_factor_a"]);
                                    float crestfactor_h = (float)Convert.ToDouble(drunit["crest_factor_h"]);
                                    float crestfactor_v = (float)Convert.ToDouble(drunit["crest_factor_v"]);
                                    float crestfactor_ch1 = (float)Convert.ToDouble(drunit["crest_factor_ch1"]);

                                    float ordertrace_a_real = 0;
                                    float ordertrace_h_real = 0;
                                    float ordertrace_v_real = 0;
                                    float ordertrace_ch1_real = 0;

                                    float ordertrace_a_image = 0;
                                    float ordertrace_h_image = 0;
                                    float ordertrace_v_image = 0;
                                    float ordertrace_ch1_image = 0;
                                    float ordertrace_Rpm = 0;

                                    int point_id = 1;

                                    sNewCommandText = "Insert into point_record(pr_id,measure_time,accel_a,accel_h,accel_v,accel_ch1,vel_a,vel_h,vel_v,vel_ch1,displ_a,displ_h,displ_v,displ_ch1,bearing_a,bearing_h,bearing_v,bearing_ch1,temperature,process,point_id,                                        crest_factor_a,crest_factor_h,crest_factor_v,crest_factor_ch1,ordertrace_a_real,ordertrace_h_real,ordertrace_v_real,ordertrace_ch1_real,ordertrace_a_image,ordertrace_h_image,ordertrace_v_image,ordertrace_ch1_image,ordertrace_Rpm) values(" + pr_id + "," + measure_time + "," + accel_a + "," + accel_h + "," + accel_v + "," + accel_ch1 + "," + vel_a + "," + vel_h + "," + vel_v + "," + vel_ch1 + "," + displ_a + "," + displ_h + "," + displ_v + "," + displ_ch1 + "," + bearing_a + "," + bearing_h + "," + bearing_v + "," + bearing_ch1 + "," + temperature + "," + process + "," + point_id + "," + crestfactor_a + "," + crestfactor_h + "," + crestfactor_v + "," + crestfactor_ch1 + "," + ordertrace_a_real + "," + ordertrace_h_real + "," + ordertrace_v_real + "," + ordertrace_ch1_real + "," + ordertrace_a_image + "," + ordertrace_h_image + "," + ordertrace_v_image + "," + ordertrace_ch1_image + "," + ordertrace_Rpm + ")";
                                    objNewCommand.CommandText = sNewCommandText;
                                    objNewCommand.Connection = objNewConnection;
                                    objNewCommand.ExecuteNonQuery();


                                }
                            }
                            catch { }


                        }

                        catch (Exception ex)
                        { }
                    }

                }


            }
            catch
            { }
        }

        // code for download
        internal void CallCheckConnections()
        {
            try
            {
                _objMain.lblStatus.Caption = "Status: Check All Connections";
                CheckAllConnections(PublicClass.routename);
                if (AckToCopy == true)
                {
                    _objMain.lblStatus.Caption = "Status: Inserting Point Record Data";
                    insertdata();
                    _objMain.lblStatus.Caption = "Status: Inserting Point Notes";
                    InsertNotes();
                    _objMain.lblStatus.Caption = "Status: Inserting Point Data";
                    Insert_Point();
                    _objMain.lblStatus.Caption = "Status: Inserting Point Notes";
                    InsertNotes();
                    PublicClass.flagAlarm = true;
                    SplashScreenManager.CloseForm();
                    _objMain.lblStatus.Caption = "Status: Download Data Sucessfully";
                    MessageBox.Show("Data Download Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    _objMain.lblStatus.Caption = "Status: Error in Upload Data";
                    MessageBox.Show("Please Check your Connection Properly", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                }
            }
            catch { }
        }
        
        bool AckForSame = false;
        private bool CheckForRightSDF(string ConnStr)
        {           
            SqlCeCommand objCOmmandCE = null;
            SqlCeDataReader objReaderCE = null;           
            string ToCompare = null;
            string ToFinalCompare = null;           
            connvalu = ConnStr;
            try
            {
                using (SqlCeConnection objCOnnectionCE = new SqlCeConnection())
                {
                    objCOnnectionCE.ConnectionString = "Data Source=" + ConnStr;
                    
                    objCOnnectionCE.Open();
                    objCOmmandCE = new SqlCeCommand();
                    objCOmmandCE.CommandText = "select * From system_info order by version";
                    objCOmmandCE.Connection = objCOnnectionCE;
                    objReaderCE = objCOmmandCE.ExecuteReader();
                    if (objReaderCE.Read())
                    {
                        ToCompare = Convert.ToString(objReaderCE["note"]);
                    } objReaderCE.Close();

                    string[] RtNm = ToCompare.Split(new string[] { "!", "@" }, StringSplitOptions.RemoveEmptyEntries);
                    if (RtNm.Length > 1)
                    {
                        if (RtNm[0] != null)
                        {
                            string[] ObjToExtrct = ConnStr.Split(new string[] { "Temp", "\\", ".sdf" }, StringSplitOptions.RemoveEmptyEntries);
                            if (ObjToExtrct[ObjToExtrct.Length - 1] != null)
                            {
                                ToFinalCompare = GetProperStringForNotes(ObjToExtrct[ObjToExtrct.Length - 1]);
                            }
                        }
                        ToFinalCompare = ToFinalCompare.TrimStart(new char[] { ' ' });
                        ToFinalCompare = ToFinalCompare.TrimEnd(new char[] { ' ' });
                        ToCompare = ToCompare.TrimStart(new char[] { ' ' });
                        ToCompare = ToCompare.TrimEnd(new char[] { ' ' });
                        if (ToFinalCompare == ToCompare)
                        {
                            AckForSame = true;
                        }
                        else
                        {
                            AckForSame = false;
                        }
                    }

                }
                
            }
            catch (Exception ex)
            {
               
            }
            return AckForSame;
        }
        bool IsInstrument = true;
        bool AckToCopy = true;
        private void CheckAllConnections(string Name)
        {            
            string PathToUpLoad = null;
            _objRapiImpaq = new RAPI();
            SqlCeCommand objCommandCE = null;
            SqlCeDataReader objReaderCE = null;
           
            try
            {              
                bSmErr = false;
                frmdownload dw = new frmdownload();
                _objMain.lblStatus.Caption = "Status: Select the Right Route";
                dw.ShowDialog();
                SplashScreenManager.ShowForm(typeof(WaitForm4));
                IsInstrument = dw.IsInstrumentSelected;
                if (IsInstrument == false)
                {
                    PathToUpLoad = dw.PCPath;
                    if (dw.IsCancelClicked == false)
                    {
                        AckToCopy = CheckForRightSDF(PathToUpLoad);
                    }  
                }
                else
                {                   
                    AckToCopy = true;
                }

                if (AckToCopy)
                {
                    if (dw.IsCancelClicked == false)
                    {
                        if (IsInstrument)
                        {
                            if (_objRapiImpaq.DevicePresent)
                            {
                                string path = Path.GetTempPath();
                                _objRapiImpaq.Connect();
                                if (File.Exists(path + Name + ".sdf"))
                                {
                                    if (PublicClass.currentInstrument == "Impaq-Benstone")
                                    {
                                        _objRapiImpaq.CopyFileFromDevice(path + Name + ".sdf", @"\Storage Card\" + "impaqElite" + @"\DataCollector\Data\" + Name + ".sdf", true);
                                    }
                                    else
                                    { _objRapiImpaq.CopyFileFromDevice(path + Name + ".sdf", @"\Storage Card\" + "FieldpaqII" + @"\DataCollector\Data\" + Name + ".sdf", true); }
                                    AckToCopy = CheckForRightSDF(path + Name + ".sdf");
                                    if (AckToCopy == true)
                                    {

                                    }
                                    else
                                    {
                                        AckToCopy = false;
                                        MessageBox.Show("Select valid Route and Try again");
                                        bSmErr = true;
                                    }
                                }
                                else 
                                {
                                    AckToCopy = false;
                                    MessageBox.Show("Select the Route and try again");
                                    bSmErr = true;
                                }
                            }
                            else
                            {
                                SplashScreenManager.CloseForm();
                                bSmErr = true;
                                MessageBox.Show("Device Not Connected");
                            }
                        }
                        else
                        {
                            try
                            {
                                string path = Path.GetTempPath();
                                File.Copy(PathToUpLoad, path + Name + ".sdf", true);
                            }
                            catch 
                            {
                                bSmErr = true;
                                AckToCopy = false;
                                MessageBox.Show("Error in Path to Download");
                            }
                        }
                    }
                    else
                    {
                        AckToCopy = false;
                        bccc = true;
                    }
                }
                else
                {
                    SplashScreenManager.CloseForm();
                    MessageBox.Show("Route not valid For Download.Select Valid Route");
                    bSmErr = true;
                }
            }
            catch { SplashScreenManager.CloseForm(); AckToCopy = false; MessageBox.Show("Error in upload data"); }
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

        public void Insert_Point()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SqlceClass.getdata(CommandType.Text, "select *  from POINTS  ", "Data Source=" + connvalu);
                DataTable dtpoint = new DataTable();


                foreach (DataRow dr in dt.Rows)
                {
                    dtpoint = DbClass.getdata(CommandType.Text, "select * from point where point_id= '" + Convert.ToString(dr["point_id"]).Trim() + "'");
                    if (dtpoint.Rows.Count > 0)
                    {
                        string ss = Convert.ToString(dr["point_id"]).Trim();
                    }
                    else
                    {
                        //  For insert///
                        string ss1 = Convert.ToString(dr["point_id"]).Trim();
                    }

                }
            }
            catch
            {

            }
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

                        dtt = DbClass.getdata(CommandType.Text, "select distinct  Pointname ,PointType_ID , DataCreated from point where Point_ID ='" + v_point_id.Trim() + "'  and PointSchedule='1' ");
                        string v_Point_Type = "";
                        foreach (DataRow drr in dtt.Rows)
                        {
                            v_Point_Type = Convert.ToString(drr["PointType_ID"]);
                            // datecreated = Convert.ToDateTime(drr["DataCreated"]).ToString("yyyy-MM-dd HH:mm:ss");
                        }

                        string v_Notes1 = "";
                        string v_Notes2 = "";
                        string v_Manual = "";
                        DataTable dt2 = DbClass.getdata(CommandType.Text,"select Data_ID,Point_ID,Point_name,point_type,Measure_time from point_data where Point_ID='"+v_point_id+"' and Measure_time='"+v_measure_time+"'");

                        if (v_point_schedule == "1" && v_Point_Type != "")
                        {
                            if (dt2.Rows.Count>0)
                            {

                            }
                            else
                            {
                                DbClass.executequery(CommandType.Text, " insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,  accel_a,  accel_h,    accel_v,accel_ch1, vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values       ( '" + v_point_id + "' ,'" + v_point_name + "', '" + v_Point_Type + "', '" + v_measure_time + "' , '" + v_accel_a + "' ,'" + v_accel_h + "','" + v_accel_v + "' ,'" + v_accel_ch1 + "' , '" + v_vel_a + "'   ,'" + v_vel_h + "' ,'" + v_vel_v + "'  ,'" + v_vel_ch1 + "' ,'" + v_displ_a + "' ,  '" + v_displ_h + "' , '" + v_displ_v + "' ,'" + v_displ_ch1 + "'  ,'" + v_crest_factor_a + "', '" + v_crest_factor_h + "'  ,'" + v_crest_factor_v + "' , '" + v_crest_factor_ch1 + "',  '" + v_bearing_a + "' ,'" + v_bearing_h + "', '" + v_bearing_v + "',  '" + v_bearing_ch1 + "'  ,'" + v_ordertrace_a_real + "'  ,'" + v_ordertrace_h_real + "' ,'" + v_ordertrace_v_real + "',  '" + v_ordertrace_ch1_real + "'  ,   '" + v_ordertrace_a_image + "','" + v_ordertrace_h_image + "','" + v_ordertrace_v_image + "','" + v_ordertrace_ch1_image + "', '" + v_ordertrace_rpm + "'  ,  '" + v_time_a_X + "', '" + v_time_h_X + "', '" + v_time_v_X + "' ,'" + v_time_ch1_X + "' ,'" + v_power_a_X + "','" + v_power_h_X + "' ,'" + v_power_v_X + "','" + v_power_ch_X + "' ,'" + v_power_a1_X + "','" + v_power_h1_X + "' ,'" + v_power_v1_X + "' , '" + v_power_ch1_X + "'  ,'" + v_power2_a_X + "','" + v_power2_h_X + "','" + v_power2_v_X + "' ,'" + v_power2_ch1_X + "'  ,'" + v_power2_a1_X + "','" + v_power2_h1_X + "','" + v_power2_v1_X + "','" + v_power2_ch11_X + "','" + v_power3_a_X + "','" + v_power3_h_X + "', '" + v_power3_v_X + "', '" + v_power3_ch1_X + "' ,'" + v_power3_a1_X + "','" + v_power3_h1_X + "','" + v_power3_v1_X + "','" + v_power3_ch11_X + "' ,'" + v_cepstrum_a_X + "','" + v_cepstrum_h_X + "','" + v_cepstrum_v_X + "','" + v_cepstrum_ch1_X + "', '" + v_demodulate_a_X + "','" + v_demodulate_h_X + "','" + v_demodulate_v_X + "', '" + v_demodulate_ch1_X + "'  ,  '" + v_time_a_Y + "', '" + v_time_h_Y + "', '" + v_time_v_Y + "' ,'" + v_time_CH1_Y + "' ,'" + v_power_a_Y + "','" + v_power_h_Y + "' ,'" + v_power_v_Y + "','" + v_power_ch_Y + "' ,'" + v_power_a1_Y + "','" + v_power_h1_Y + "' ,'" + v_power_v1_Y + "' , '" + v_power_ch1_Y + "'  ,'" + v_power2_a_Y + "','" + v_power2_h_Y + "','" + v_power2_v_Y + "' ,'" + v_power2_ch1_Y + "'  ,'" + v_power2_a1_Y + "','" + v_power2_h1_Y + "','" + v_power2_v1_Y + "','" + v_power2_ch11_Y + "','" + v_power3_a_Y + "','" + v_power3_h_Y + "', '" + v_power3_v_Y + "', '" + v_power3_ch1_Y + "' ,'" + v_power3_a1_Y + "','" + v_power3_h1_Y + "','" + v_power3_v1_Y + "','" + v_power3_ch11_Y + "' ,'" + v_cepstrum_a_Y + "','" + v_cepstrum_h_Y + "','" + v_cepstrum_v_Y + "','" + v_cepstrum_ch1_Y + "', '" + v_demodulate_a_Y + "','" + v_demodulate_h_Y + "','" + v_demodulate_v_Y + "', '" + v_demodulate_ch1_Y + "'     ,  '" + v_temperature + "', '" + v_process + "','" + v_auto_measure + "','" + v_record_status + "' ,'" + v_Notes1 + "' ,'" + v_Notes2 + "',  '" + PublicClass.GetDatetime() + "' ,'" + v_Manual + "')  ");
                                pointID += v_point_id + ",";
                            }
                               
                        }
                        else if (v_point_schedule == "0" && v_Point_Type != "")
                        {
                            int point_new_id = Insert_unschedule_point(v_point_name, v_machine_id, v_measure_time, v_point_id);
                            //DbClass.executequery(CommandType.Text, " insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,     accel_a,  accel_h,    accel_v,accel_ch1,            vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,                  crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    Time_a,     Time_h,     Time_v,Time_ch1,       Power_a, Power_h,    Power_v,  Power_ch1,    Power_a1, Power_h1,  Power_v1,   Power_ch11,   Power2_a,   Power2_h,   Power2_v,  Power2_ch1,     Power2_a1,  Power2_h1,  Power2_v1,  Power2_ch11,  Power3_a,  Power3_h, Power3_v,  Power3_ch1,   Power3_a1,   Power3_h1,  Power3_v1,  Power3_ch11,   Cepstrum_a,    Cepstrum_h,  Cepstrum_v, Cepstrum_ch1,    demodulate_a,   demodulate_h, demodulate_v, demodulate_ch1,   temperature,    Process,   auto_measure,   record_status,    Notes1,Notes2,  IDateTime,   Manual) values                                                                                                                                                                                                            ( '" + point_new_id + "' ,'" + v_point_name + "', '" + v_Point_Type + "', '" + v_measure_time + "' , '" + v_accel_a + "' ,'" + v_accel_h + "','" + v_accel_v + "' ,'" + v_accel_ch1 + "' , '" + v_vel_a + "'   ,'" + v_vel_h + "' ,'" + v_vel_v + "'  ,'" + v_vel_ch1 + "' ,'" + v_displ_a + "' ,  '" + v_displ_h + "' , '" + v_displ_v + "' ,'" + v_displ_ch1 + "'  ,'" + v_crest_factor_a + "', '" + v_crest_factor_h + "'  ,'" + v_crest_factor_v + "' , '" + v_crest_factor_ch1 + "',  '" + v_bearing_a + "' ,'" + v_bearing_h + "', '" + v_bearing_v + "',  '" + v_bearing_ch1 + "'  ,'" + v_ordertrace_a_real + "'  ,'" + v_ordertrace_h_real + "' ,'" + v_ordertrace_v_real + "',  '" + v_ordertrace_ch1_real + "'  ,   '" + v_ordertrace_a_image + "','" + v_ordertrace_h_image + "','" + v_ordertrace_v_image + "','" + v_ordertrace_ch1_image + "', '" + v_ordertrace_rpm + "'  ,  '" + v_time_a_X + "', '" + v_time_h_X + "', '" + v_time_v_X + "' ,'" + v_time_ch1_X + "' ,'" + v_power_a_X + "','" + v_power_h_X + "' ,'" + v_power_v_X + "','" + v_power_ch_X + "' ,'" + v_power_a1_X + "','" + v_power_h1_X + "' ,'" + v_power_v1_X + "' , '" + v_power_ch1_X + "'  ,'" + v_power2_a_X + "','" + v_power2_h_X + "','" + v_power2_v_X + "' ,'" + v_power2_ch1_X + "'  ,'" + v_power2_a1_X + "','" + v_power2_h1_X + "','" + v_power2_v1_X + "','" + v_power2_ch11_X + "','" + v_power3_a_X + "','" + v_power3_h_X + "', '" + v_power3_v_X + "', '" + v_power3_ch1_X + "' ,'" + v_power3_a1_X + "','" + v_power3_h1_X + "','" + v_power3_v1_X + "','" + v_power3_ch11_X + "' ,'" + v_cepstrum_a_X + "','" + v_cepstrum_h_X + "','" + v_cepstrum_v_X + "','" + v_cepstrum_ch1_X + "', '" + v_demodulate_a_X + "','" + v_demodulate_h_X + "','" + v_demodulate_v_X + "', '" + v_demodulate_ch1_X + "',  '" + v_temperature + "', '" + v_process + "','" + v_auto_measure + "','" + v_record_status + "' ,'" + v_Notes1 + "' ,'" + v_Notes2 + "',  '" + PublicClass.GetDatetime() + "' ,'" + v_Manual + "')  ");
                            DbClass.executequery(CommandType.Text, " insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,     accel_a,  accel_h,    accel_v,accel_ch1,            vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,                  crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values       ( '" + point_new_id + "' ,'" + v_point_name + "', '" + v_Point_Type + "', '" + v_measure_time + "' , '" + v_accel_a + "' ,'" + v_accel_h + "','" + v_accel_v + "' ,'" + v_accel_ch1 + "' , '" + v_vel_a + "'   ,'" + v_vel_h + "' ,'" + v_vel_v + "'  ,'" + v_vel_ch1 + "' ,'" + v_displ_a + "' ,  '" + v_displ_h + "' , '" + v_displ_v + "' ,'" + v_displ_ch1 + "'  ,'" + v_crest_factor_a + "', '" + v_crest_factor_h + "'  ,'" + v_crest_factor_v + "' , '" + v_crest_factor_ch1 + "',  '" + v_bearing_a + "' ,'" + v_bearing_h + "', '" + v_bearing_v + "',  '" + v_bearing_ch1 + "'  ,'" + v_ordertrace_a_real + "'  ,'" + v_ordertrace_h_real + "' ,'" + v_ordertrace_v_real + "',  '" + v_ordertrace_ch1_real + "'  ,   '" + v_ordertrace_a_image + "','" + v_ordertrace_h_image + "','" + v_ordertrace_v_image + "','" + v_ordertrace_ch1_image + "', '" + v_ordertrace_rpm + "'  ,  '" + v_time_a_X + "', '" + v_time_h_X + "', '" + v_time_v_X + "' ,'" + v_time_ch1_X + "' ,'" + v_power_a_X + "','" + v_power_h_X + "' ,'" + v_power_v_X + "','" + v_power_ch_X + "' ,'" + v_power_a1_X + "','" + v_power_h1_X + "' ,'" + v_power_v1_X + "' , '" + v_power_ch1_X + "'  ,'" + v_power2_a_X + "','" + v_power2_h_X + "','" + v_power2_v_X + "' ,'" + v_power2_ch1_X + "'  ,'" + v_power2_a1_X + "','" + v_power2_h1_X + "','" + v_power2_v1_X + "','" + v_power2_ch11_X + "','" + v_power3_a_X + "','" + v_power3_h_X + "', '" + v_power3_v_X + "', '" + v_power3_ch1_X + "' ,'" + v_power3_a1_X + "','" + v_power3_h1_X + "','" + v_power3_v1_X + "','" + v_power3_ch11_X + "' ,'" + v_cepstrum_a_X + "','" + v_cepstrum_h_X + "','" + v_cepstrum_v_X + "','" + v_cepstrum_ch1_X + "', '" + v_demodulate_a_X + "','" + v_demodulate_h_X + "','" + v_demodulate_v_X + "', '" + v_demodulate_ch1_X + "'  ,  '" + v_time_a_Y + "', '" + v_time_h_Y + "', '" + v_time_v_Y + "' ,'" + v_time_CH1_Y + "' ,'" + v_power_a_Y + "','" + v_power_h_Y + "' ,'" + v_power_v_Y + "','" + v_power_ch_Y + "' ,'" + v_power_a1_Y + "','" + v_power_h1_Y + "' ,'" + v_power_v1_Y + "' , '" + v_power_ch1_Y + "'  ,'" + v_power2_a_Y + "','" + v_power2_h_Y + "','" + v_power2_v_Y + "' ,'" + v_power2_ch1_Y + "'  ,'" + v_power2_a1_Y + "','" + v_power2_h1_Y + "','" + v_power2_v1_Y + "','" + v_power2_ch11_Y + "','" + v_power3_a_Y + "','" + v_power3_h_Y + "', '" + v_power3_v_Y + "', '" + v_power3_ch1_Y + "' ,'" + v_power3_a1_Y + "','" + v_power3_h1_Y + "','" + v_power3_v1_Y + "','" + v_power3_ch11_Y + "' ,'" + v_cepstrum_a_Y + "','" + v_cepstrum_h_Y + "','" + v_cepstrum_v_Y + "','" + v_cepstrum_ch1_Y + "', '" + v_demodulate_a_Y + "','" + v_demodulate_h_Y + "','" + v_demodulate_v_Y + "', '" + v_demodulate_ch1_Y + "'     ,  '" + v_temperature + "', '" + v_process + "','" + v_auto_measure + "','" + v_record_status + "' ,'" + v_Notes1 + "' ,'" + v_Notes2 + "',  '" + PublicClass.GetDatetime() + "' ,'" + v_Manual + "')  ");
                        }
                        else if (v_point_schedule == "0" && v_Point_Type == "")
                        {
                            int point_new_id = Insert_unschedule_point(v_point_name, v_machine_id, v_measure_time, v_point_id);
                            DbClass.executequery(CommandType.Text, " insert into point_data (Point_ID,Point_name, Point_Type,  Measure_time,     accel_a,  accel_h,    accel_v,accel_ch1,            vel_a,        vel_h, vel_v, vel_ch1,      displ_a,   displ_h,    displ_v, displ_ch1,                  crest_factor_a,    crest_factor_h,    crest_factor_v,   crest_factor_ch1 ,          bearing_a,       bearing_h,  bearing_v,  bearing_ch1,        ordertrace_a_real,   ordertrace_h_real,  ordertrace_v_real ,ordertrace_ch1_real ,     ordertrace_a_image,   ordertrace_h_image,    ordertrace_v_image, ordertrace_ch1_image,   ordertrace_rpm,    TimeA_X,     timeH_X,     timeV_X,timeCH1_X,       PA_X, PH_X,    PV_X,  PCH1_X,    P1A_X, P1H_X,  P1V_X,   P1CH1_X,   P2A_X,   P2H_X,   P2V_X,  P2CH1_X,     P21A_X,  P21H_X,  P21V_X,  P21CH1_X,  P3A_X,  P3H_X, P3V_X,  P3CH1_X,   P31A_X,   P31H_X,  P31V_X,  P31CH1_X,   CEPA_X,    CEPH_X,  CEPV_X, CEPCH1_X,    DEMA_X,   DEMH_X, DEMV_X, DEMCH1_X,      timeA_Y,        timeH_Y,     timeV_Y,    timeCH1_Y,     PA_Y,     PH_Y,    PV_Y,    PCH1_Y,P1A_Y,P1H_Y,P1V_Y,P1CH1_Y,P2A_Y,P2H_Y,P2V_Y,P2CH1_Y,P21A_Y,P21H_Y,P21V_Y,P21CH1_Y,P3A_Y,P3H_Y,P3V_Y,P3CH1_Y,P31A_Y,P31H_Y,P31V_Y,P31CH1_Y,CEPA_Y,CEPH_Y,CEPV_Y,CEPCH1_Y,DEMA_Y,DEMH_Y,DEMV_Y,DEMCH1_Y ,            temperature,    Process,   auto_measure,   record_status,    Notes1, Notes2,  IDateTime,   Manual) values       ( '" + point_new_id + "' ,'" + v_point_name + "', '" + untypeid + "', '" + v_measure_time + "' , '" + v_accel_a + "' ,'" + v_accel_h + "','" + v_accel_v + "' ,'" + v_accel_ch1 + "' , '" + v_vel_a + "'   ,'" + v_vel_h + "' ,'" + v_vel_v + "'  ,'" + v_vel_ch1 + "' ,'" + v_displ_a + "' ,  '" + v_displ_h + "' , '" + v_displ_v + "' ,'" + v_displ_ch1 + "'  ,'" + v_crest_factor_a + "', '" + v_crest_factor_h + "'  ,'" + v_crest_factor_v + "' , '" + v_crest_factor_ch1 + "',  '" + v_bearing_a + "' ,'" + v_bearing_h + "', '" + v_bearing_v + "',  '" + v_bearing_ch1 + "'  ,'" + v_ordertrace_a_real + "'  ,'" + v_ordertrace_h_real + "' ,'" + v_ordertrace_v_real + "',  '" + v_ordertrace_ch1_real + "'  ,   '" + v_ordertrace_a_image + "','" + v_ordertrace_h_image + "','" + v_ordertrace_v_image + "','" + v_ordertrace_ch1_image + "', '" + v_ordertrace_rpm + "'  ,  '" + v_time_a_X + "', '" + v_time_h_X + "', '" + v_time_v_X + "' ,'" + v_time_ch1_X + "' ,'" + v_power_a_X + "','" + v_power_h_X + "' ,'" + v_power_v_X + "','" + v_power_ch_X + "' ,'" + v_power_a1_X + "','" + v_power_h1_X + "' ,'" + v_power_v1_X + "' , '" + v_power_ch1_X + "'  ,'" + v_power2_a_X + "','" + v_power2_h_X + "','" + v_power2_v_X + "' ,'" + v_power2_ch1_X + "'  ,'" + v_power2_a1_X + "','" + v_power2_h1_X + "','" + v_power2_v1_X + "','" + v_power2_ch11_X + "','" + v_power3_a_X + "','" + v_power3_h_X + "', '" + v_power3_v_X + "', '" + v_power3_ch1_X + "' ,'" + v_power3_a1_X + "','" + v_power3_h1_X + "','" + v_power3_v1_X + "','" + v_power3_ch11_X + "' ,'" + v_cepstrum_a_X + "','" + v_cepstrum_h_X + "','" + v_cepstrum_v_X + "','" + v_cepstrum_ch1_X + "', '" + v_demodulate_a_X + "','" + v_demodulate_h_X + "','" + v_demodulate_v_X + "', '" + v_demodulate_ch1_X + "'  ,  '" + v_time_a_Y + "', '" + v_time_h_Y + "', '" + v_time_v_Y + "' ,'" + v_time_CH1_Y + "' ,'" + v_power_a_Y + "','" + v_power_h_Y + "' ,'" + v_power_v_Y + "','" + v_power_ch_Y + "' ,'" + v_power_a1_Y + "','" + v_power_h1_Y + "' ,'" + v_power_v1_Y + "' , '" + v_power_ch1_Y + "'  ,'" + v_power2_a_Y + "','" + v_power2_h_Y + "','" + v_power2_v_Y + "' ,'" + v_power2_ch1_Y + "'  ,'" + v_power2_a1_Y + "','" + v_power2_h1_Y + "','" + v_power2_v1_Y + "','" + v_power2_ch11_Y + "','" + v_power3_a_Y + "','" + v_power3_h_Y + "', '" + v_power3_v_Y + "', '" + v_power3_ch1_Y + "' ,'" + v_power3_a1_Y + "','" + v_power3_h1_Y + "','" + v_power3_v1_Y + "','" + v_power3_ch11_Y + "' ,'" + v_cepstrum_a_Y + "','" + v_cepstrum_h_Y + "','" + v_cepstrum_v_Y + "','" + v_cepstrum_ch1_Y + "', '" + v_demodulate_a_Y + "','" + v_demodulate_h_Y + "','" + v_demodulate_v_Y + "', '" + v_demodulate_ch1_Y + "'     ,  '" + v_temperature + "', '" + v_process + "','" + v_auto_measure + "','" + v_record_status + "' ,'" + v_Notes1 + "' ,'" + v_Notes2 + "',  '" + PublicClass.GetDatetime() + "' ,'" + v_Manual + "')  ");
                            pointID += v_point_id + ",";
                        }

                    }
                
            }
            catch { }
            PublicClass.pointIDs = pointID;
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

        int prevous_id, nextid;
        int point_new_record_id;

        public int Insert_unschedule_point(string pointName, string machineid, string createddate,string point_id)
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
                    dt1 = DbClass.getdata(CommandType.Text, "select max(point_id)point_id,max(previousid)previousid,max(nextid)nextid from point");
                    foreach (DataRow dr in dt1.Rows)
                    {
                        point_new_record_id = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["point_id"]), "0")) + 1;
                        prevous_id = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["previousid"]), "0")) + 1;
                        nextid = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["nextid"]), "0")) + 1;

                    }
                    DbClass.executequery(CommandType.Text, " insert into point(point_id,PointName,PointDesc,Machine_ID,DataCreated,previousid,nextid,DataSchedule,PointStatus,PointSchedule) values('" + point_new_record_id + "','" + pointName + "','" + pointName + "','" + machineid + "','" + Convert.ToDateTime(createddate).ToString(("yyyy/MM/dd HH:mm:ss")) + "','" + Convert.ToString(prevous_id) + "','" + Convert.ToString(nextid) + "','7 Days','0','1'  ) ");
                    string ppp = null;
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

        
        int iMeasureID = 0;
        byte PowerBand = 0;
        byte PowerResolution = 0;
        string pwrzoom = "0";
        string pwrzoomstartfreq = "0";
        public string get_PowerResolution(string iPointID, string ss, byte[] btArgs, string stype)
        {
            string[] sarrXTData = new string[0];
            string Value = "";
            try
            {
                //power_band1,power_resolution1
                DataTable dt = new DataTable();
                dt = SqlceClass.getdata(CommandType.Text, "select measure_id, " + ss + ",power_zoom,power_zoom_startfreq from measures where measure_id='" + iPointID + "' ", "Data Source=" + connvalu);
                foreach (DataRow objReader in dt.Rows)
                {
                    iMeasureID = (int)objReader[0];
                    PowerBand = (byte)objReader[1];    // band
                    PowerResolution = (byte)objReader[2];   //resoultion
                    try
                    {
                        pwrzoom = Convert.ToString(objReader[3]);   // zoom
                        pwrzoomstartfreq = Convert.ToString(objReader[4]);   // zoomstartfreq
                    }
                    catch { }
                }
                //string sXValue = GetTimeData(iPointID, btTimeA, MeasureTimeBand, "Time", MeasureTimeResolution);
                //ValueType = GetTimeData(iPointID, btArgs, PowerBand, "Power", PowerResolution);
                Value = GetTimeData(Convert.ToInt16(iPointID), btArgs, PowerBand, stype, PowerResolution,pwrzoomstartfreq,pwrzoom);
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

        public string get_CepstrumResolution(string iPointID, string ss, byte[] btArgs, string stype)
        {
            string[] sarrXTData = new string[0];
            string Value = "";
            try
            {
                //cep_band1,cep_resolution1
                DataTable dt = new DataTable();
                dt = SqlceClass.getdata(CommandType.Text, "select measure_id, " + ss + ",cepstrum_zoom,cepstrum_zoom_startfreq from measures where measure_id='" + iPointID + "' ", "Data Source=" + connvalu);
                foreach (DataRow objReader in dt.Rows)
                {
                    iMeasureID = (int)objReader[0];
                    PowerBand = (byte)objReader[1];    // band
                    PowerResolution = (byte)objReader[2];   //resoultion
                    try
                    {
                        pwrzoom = Convert.ToString(objReader[3]);   // zoom
                        pwrzoomstartfreq = Convert.ToString(objReader[4]);   // zoomstartfreq
                    }
                    catch { }
                }
              
                Value = GetTimeData(Convert.ToInt16(iPointID), btArgs, PowerBand, stype, PowerResolution,pwrzoomstartfreq,pwrzoom);
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

        double[] m_arrKeys = null; int appendvalue = 0;
        private string GetTimeData(int iPointID, byte[] btArgs, byte MeasureTimeBand, string sType, byte btResolution,string zoomstartfreq,string pwrzoom)
        {
            appendvalue = 0;
            StringBuilder sbXValues = null;
            try
            {
                sbXValues = new StringBuilder();
               
                int iFrequency = 0;
                if (pwrzoom == "1"&&sType=="Power")
                { iFrequency = Convert.ToInt32(zoomstartfreq); }
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
                if (pwrzoom == "1" && sType == "Power")
                { iResolution1 = Convert.ToInt32(zoomstartfreq); }
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
                if (pwrzoom == "1" && sType == "Power")
                { dCreateArray = Convert.ToDouble(zoomstartfreq); }
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
                if (pwrzoom == "1" && sType == "Power")
                {
                    appendvalue = Convert.ToInt32(zoomstartfreq);
                    CreateKeyBytes(dCreateArray);
                }
                else
                { CreateKeyBytes1(dCreateArray); }
                
               
                if (pwrzoom == "1" && sType == "Power")
                { appendvalue = Convert.ToInt32(zoomstartfreq); }
                sbXValues.Append(appendvalue);
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


            }//end(catch(Exception ex))
        }

        private void CreateKeyBytes(double dDifference)
        {
            try
            {
                double dNewDifference = dDifference;
                double finalvalue = dDifference;
                for (int iCtr = 0; iCtr < m_arrKeys.Length; iCtr++)
                {
                    if (iCtr == 0)
                    {
                        dNewDifference = appendvalue + dDifference;
                        m_arrKeys[iCtr] = dNewDifference;
                    }
                    else
                    {
                        dDifference = dNewDifference + finalvalue;
                        m_arrKeys[iCtr] = dDifference;
                        dNewDifference = m_arrKeys[iCtr];
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void CreateKeyBytes1(double dDifference)
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

    }
    }

