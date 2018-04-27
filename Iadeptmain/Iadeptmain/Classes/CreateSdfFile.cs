using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServerCe.Client;
//using System.Data.SqlServerCe;
using System.Threading.Tasks;
using Iadeptmain.GlobalClasses;
using System.Data;
using Iadeptmain.Mainforms;

namespace Iadeptmain.Classes
{
    class CreateSdfFile
    {
        string strConnection = null;
        frmIAdeptMain _objMain;
        public void CreateDatabaseInSdfFormat()
        {
            strConnection ="Data Source=" + PublicClass.finalpath; 
            SqlCeConnection con = new SqlCeConnection(strConnection);
            PublicClass.sdfconnection = strConnection;
            try
            {
                SqlCeEngine objEngine = new SqlCeEngine(strConnection);
                objEngine.CreateDatabase();
                objEngine.Dispose();
                CreateNewDatabaseStructure();
            }
            catch (Exception ex)
            {
             
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
          
        internal void CreateDatabaseInSdfFormat(string versionoption)
        {
            strConnection = "Data Source=" + PublicClass.finalpath;
            PublicClass.sdfconnection = strConnection;
            try
            {
                SqlCeEngine objEngine = new SqlCeEngine(strConnection);
                objEngine.CreateDatabase();
                objEngine.Dispose();
                if (versionoption == "Elite")
                {
                    _objMain.lblStatus.Caption = "Status: Creating Sdf Database";
                    CreateNewDatabaseStructure();
                    _objMain.lblStatus.Caption = "Status: Creating Sdf Database Successfully";
                }
                else
                {
                  
                }
            }
            catch (Exception ex)
            {
              
            }
        }
        private void CreateNewDatabaseStructure()
        {
            try
            {
                SqlceClass.executequery(CommandType.Text, "create table routes(download_time int,upload_time int,hierarchy_level tinyint,total_count int,archive_count int,skip_count int,backup_route tinyint)"); // query for version 7 and above database in Elite                  
                SqlceClass.executequery(CommandType.Text, "create table system_info(version int NOT NULL,note nvarchar(256))");
                SqlceClass.executequery(CommandType.Text, "insert into system_info(version) values(7)");
                SqlceClass.executequery(CommandType.Text, "create table plants(plant_id int,plant_name nvarchar(32) NOT NULL,primary key(plant_id))");
                SqlceClass.executequery(CommandType.Text, "create table areas(area_id int,area_name nvarchar(32) NOT NULL,plant_id int,primary key(area_id))");
                SqlceClass.executequery(CommandType.Text, "create table trains(train_id int,train_name nvarchar(32) NOT NULL,area_id int,primary key(train_id))");
                
                SqlceClass.executequery(CommandType.Text, "create table machines(machine_id int,machine_name nvarchar(32) NOT NULL,machine_rpm real,machine_pulsesrev real,description1_id int,description2_id int,description3_id int,picture_type tinyint NOT NULL,machine_picture image,train_id int,primary key(machine_id))");
                //SqlceClass.executequery(CommandType.Text, "create table machines(machine_id int,machine_name nvarchar(32),machine_rpm real,machine_pulsesrev real,desc1_id int,desc2_id int,desc3_id int,picture_type tinyint Default 0,machine_picture image,train_id int,primary key(machine_id))");
                //SqlceClass.executequery(CommandType.Text, "create table machines(machine_id int,machine_name nvarchar(32),machine_rpm real,machine_pulsesrev real,note1_id int,note2_id int,note3_id int,picture_type tinyint Default 0,machine_picture image,train_id int,primary key(machine_id))");
                
                SqlceClass.executequery(CommandType.Text, "create table points(point_id int , point_name nvarchar(32) NOT NULL,point_dir smallint,point_record_status smallint,point_status tinyint,point_schedule tinyint,point_measurement int,vibration_sensor int,temperature_sensor int,unit_id int,measure_id int,alarm_id int,machine_id int,record_id int,primary key(point_id))");
                try
                {
                    SqlceClass.executequery(CommandType.Text, "create table point_record(pr_id int,measure_time int,accel_ch1 float,accel_a float,accel_h float,accel_v float,vel_ch1 float,vel_a float,vel_h float,vel_v float,displ_ch1 float,displ_a float,displ_h float,displ_v float,crest_factor_ch1 float,crest_factor_a float,crest_factor_h float,crest_factor_v float,bearing_ch1 float,bearing_a float,bearing_h float ,bearing_v float,ordertrace_ch1_real float ,ordertrace_ch1_image float ,ordertrace_a_real float ,ordertrace_a_image float ,ordertrace_h_real float ,ordertrace_h_image float ,ordertrace_v_real float ,ordertrace_v_image float,ordertrace_rpm int, time_ch1 image,time_a image,time_h image,time_v image,                                                 power_ch1 image,power_a image,power_h image,power_v image,power_ch11 image,power_a1 image,power_h1 image,power_v1 image,                            power2_ch1 image,power2_a image,power2_h image,power2_v image,power2_ch11 image,power2_a1 image,power2_h1 image,power2_v1 image,                            power3_ch1 image,power3_a image,power3_h image,power3_v image,power3_ch11 image,power3_a1 image,power3_h1 image,power3_v1 image,                        cepstrum_ch1 image,cepstrum_a image,cepstrum_h image,cepstrum_v image,demodulate_ch1 image,                                               demodulate_a image,demodulate_h image,demodulate_v image,temperature float,process float,auto_measure int,record_status smallint,point_id int,primary key(pr_id))");
                }
                catch
                {
                    SqlceClass.executequery(CommandType.Text, "create table point_record(pr_id int,measure_time int,accel_a float,accel_h float,accel_v float,vel_a float,vel_h float,vel_v float,displ_a float,displ_h float,displ_v float,bearing_a float,bearing_h float ,bearing_v float,time_a image,time_h image,time_v image,power_a image,power_h image,power_v image,demodulate_a image,demodulate_h image,demodulate_v image,temperature float,process float,point_id int,primary key(pr_id))");
                }
                SqlceClass.executequery(CommandType.Text, "create table point_faultfreq(pf_id int,pf_name nvarchar(32) NOT NULL,pf_freq real,point_id int,primary key(pf_id))");
                SqlceClass.executequery(CommandType.Text, "create table sensors(sensor_id int ,sensor_name nvarchar(32) NOT NULL,sensor_type tinyint,sensitivity_ch1 float,sensitivity_a float,sensitivity_h float,sensitivity_v float,sensor_unit tinyint,sensor_dir tinyint ,sensor_icp tinyint,sensor_offset real, primary key(sensor_id))");
                SqlceClass.executequery(CommandType.Text, "create table units(unit_id int,accel_unit tinyint,vel_unit tinyint,displ_unit tinyint,pressure_unit tinyint,current_unit tinyint,temperature_unit tinyint,process_unit nvarchar(32),accel_detection tinyint,vel_detection tinyint,displ_detection tinyint,pressure_detection tinyint,current_detection tinyint,ordertrace_unit_type tinyint,time_unit_type tinyint,power_unit_type tinyint,cepstrum_unit_type tinyint,demodulate_unit_type tinyint, input_range tinyint ,primary key(unit_id))");
                SqlceClass.executequery(CommandType.Text, "create table measures(measure_id int,acc_filter tinyint,vel_filter tinyint,displ_filter tinyint,crest_factor_filter tinyint,overall_bearing_filter tinyint,bearing_acc_hp_filter tinyint,ordertrace_average_times tinyint,ordertrace_resolution tinyint  ,ordertrace_order real     ,ordertrace_trigger_slope tinyint  ,time_band tinyint,time_resolution tinyint,time_overlap tinyint,  power_multiple tinyint  ,                    power_band tinyint,power_resolution tinyint,power_band1 tinyint,power_resolution1 tinyint,                                   power2_band tinyint,power2_resolution tinyint,                   power2_band1 tinyint,power2_resolution1 tinyint,                 power3_band tinyint,power3_resolution tinyint,               power3_band1 tinyint,power3_resolution1 tinyint,            power_window tinyint,power_average_times tinyint,power_overlap tinyint,power_zoom tinyint,power_zoom_startfreq real,        cepstrum_band tinyint,cepstrum_resolution tinyint,cepstrum_window tinyint,cepstrum_average_times tinyint,cepstrum_overlap tinyint,cepstrum_zoom tinyint,cepstrum_zoom_startfreq real,          demodulate_band tinyint,demodulate_resolution tinyint,demodulate_window tinyint,demodulate_average_times tinyint,demodulate_filter tinyint,primary key(measure_id))");
                SqlceClass.executequery(CommandType.Text, "create table notes(note_id int,note_content nvarchar(256),primary key(note_id))");
                SqlceClass.executequery(CommandType.Text, "Insert into notes(note_id  ,note_content ) values (1,'None')");
                SqlceClass.executequery(CommandType.Text, "create table alarms(alarm_id int,accel_ch11 float,accel_a1 float,accel_h1 float,accel_v1 float,accel_ch12 float,accel_a2 float,accel_h2 float,accel_v2 float,vel_ch11 float,vel_a1 float,vel_h1 float,vel_v1 float,                    vel_ch12 float,vel_a2 float,vel_h2 float,vel_v2 float,                    displ_ch11 float,displ_a1 float,displ_h1 float,displ_v1 float,                        displ_ch12 float,displ_a2 float,displ_h2 float,displ_v2 float,                            crest_factor_ch11 float,crest_factor_a1 float,crest_factor_h1 float,crest_factor_v1 float,crest_factor_ch12 float,crest_factor_a2 float,crest_factor_h2 float,crest_factor_v2 float,                                    bearing_ch11 float,bearing_a1 float,bearing_h1 float,bearing_v1 float,                                        bearing_ch12 float,bearing_a2 float,bearing_h2 float,bearing_v2 float,temperature_1 float,temperature_2 float,primary key(alarm_id))");
                SqlceClass.executequery(CommandType.Text, "create table bandalarm(bandalarm_id int ,bandalarm_name nvarchar(32) NOT NULL ,freq float,alarm1 float,alarm2 float ,group_id int,primary key(bandalarm_id))");
                SqlceClass.executequery(CommandType.Text, "create table machine_record(mr_id int,record_time int,note_id int,machine_id int,primary key(mr_id))");
                SqlceClass.executequery(CommandType.Text, "create table descriptions(desc_id int,desc_content nvarchar(256),primary key(desc_id))");
                SqlceClass.executequery(CommandType.Text, "create table bandalarms (bandalarms_id int,bandalarm_group_id int, axis_type int , point_id int,primary key(bandalarms_id))");
                //----------Create Indexes for tables-----//
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_ALARM_ID] ON [alarms] ([alarm_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_AREA_ID] ON [areas] ([plant_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_BAND_ALARM] ON [bandalarm] ([group_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_BAND_ALARMS] ON [bandalarms] ([axis_type] ASC, [point_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_DESC_ID] ON [descriptions] ([desc_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_MACHINE_RECORD_ID] ON [machine_record] ([mr_id] ASC, [machine_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_MACHINE_ID] ON [machines] ([train_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_MEASURE_ID] ON [measures] ([measure_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_NOTE_ID] ON [notes] ([note_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_POINT_FAULTFREQ_ID] ON [point_faultfreq] ([point_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_POINT_RECORD_ID] ON [point_record] ([point_id] ASC, [pr_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_POINT_ID] ON [points] ([point_id] ASC, [machine_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_SENSOR_ID] ON [sensors] ([sensor_type] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_TRAIN_ID] ON [trains] ([area_id] ASC)");
                SqlceClass.executequery(CommandType.Text, "CREATE INDEX [IDX_UNIT_ID] ON [units] ([unit_id] ASC)");             
            }

            catch (Exception ex)
            {

            }
        }
    

    }
}
