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
using Iadeptmain.GlobalClasses;
using Iadeptmain.Classes;

namespace Iadeptmain.Mainforms
{
    public partial class frmNewDataBaseCreation : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();

        BearingData objbearingdata = new BearingData();
        public frmNewDataBaseCreation()
        {
            InitializeComponent();
            Fill_InstruemntName();
            cmbInstNameSelected.Enabled = false;
        }

        private void Fill_InstruemntName()
        {
            try {
            
                dt = DbClass.getdata(CommandType.StoredProcedure, "Call InstrumentName('"+PublicClass.currentInstrument+"')");
                foreach (DataRow dr in dt.Rows)
                {
                    cmbInstNameSelected.Properties.Items.Add(dr["instrumentname"]);
                }
                cmbInstNameSelected.SelectedIndex = 0;                
            }
            catch { }        
        }

        public bool check = false;
        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = false;
                PublicClass.a = 0;
                if (tbNewMySqlDB.Text == "")
                {
                    status = false;
                    checkstatus = status;
                    MessageBox.Show(this, "DataBase Name can't be Blank.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (PublicClass.ValidateDatabase(tbNewMySqlDB.Text.Trim()))
                    {
                        CreateDataBase(tbNewMySqlDB.Text.Trim(), status);
                    }
                    else
                    {
                        MessageBox.Show(this, "Use Alphanumeric characters only.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbNewMySqlDB.Text = "";
                        return;
                    }
                    if (!status)
                    {
                        MessageBox.Show(this, "DataBase Created successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }            
                check = true;
            }
            catch { }
        }

        public bool checkstatus;
        public bool CreateDataBase(string DBName,bool status)
        {
            try
            {               
                //if (DBName == "")
                //{
                //    status = false;
                //    checkstatus = status;
                //    MessageBox.Show(this, "DataBase Name can't be Blank", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return status;
                //}
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = '" + DBName + "'");
                if (dt.Rows.Count > 0)
                {
                    status = false;
                    checkstatus = status;
                    MessageBox.Show("This DataBase is Already Exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return status;
                }
                else
                {

                    DbClass.executequery(CommandType.Text, "CREATE database  " + DBName + " ");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " . `alarms_data` (`Alarm_ID` int(10) unsigned NOT NULL auto_increment,`Alarm_Name` varchar(45) NOT NULL,`accel_a1` float default NULL,`accel_h1` float default NULL, `accel_v1` float default NULL,`accel_ch11` float default NULL, `vel_a1` float default NULL, `vel_h1` float default NULL, `vel_v1` float default NULL,`vel_ch11` float default NULL,`displ_a1` float default NULL,`displ_h1` float default NULL, `displ_v1` float default NULL,`displ_ch11` float default NULL,`crest_factor_a1` float default NULL, `crest_factor_h1` float default NULL, `crest_factor_v1` float default NULL, `crest_factor_ch11` float default NULL, `bearing_a1` float default NULL, `bearing_h1` float default NULL, `bearing_v1` float default NULL,`bearing_ch11` float default NULL, `accel_a2` float default NULL,`accel_h2` float default NULL,`accel_v2` float default NULL,`accel_ch12` float default NULL,`vel_a2` float default NULL,`vel_h2` float default NULL, `vel_v2` float default NULL, `vel_ch12` float default NULL,`displ_a2` float default NULL, `displ_h2` float default NULL, `displ_v2` float default NULL, `displ_ch12` float default NULL,`crest_factor_a2` float default NULL, `crest_factor_h2` float default NULL, `crest_factor_v2` float default NULL,`crest_factor_ch12` float default NULL, `bearing_a2` float default NULL,`bearing_h2` float default NULL, `bearing_v2` float default NULL,`bearing_ch12` float unsigned default NULL,`temperature_1` float default NULL, `temperature_2` float default NULL, `Date` datetime default NULL, PRIMARY KEY  (`Alarm_ID`)) ");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " . `alarms_data`(`Alarm_Name`,`accel_a1`,`accel_h1`,`accel_v1`,`accel_ch11`,`vel_a1`,`vel_h1`,`vel_v1`,`vel_ch11`,`displ_a1`,`displ_h1`,`displ_v1`,`displ_ch11`,`crest_factor_a1`,`crest_factor_h1`,`crest_factor_v1`,`crest_factor_ch11`,`bearing_a1`,`bearing_h1`,`bearing_v1`,`bearing_ch11`,`accel_a2`,`accel_h2`,`accel_v2`,`accel_ch12`,`vel_a2`,`vel_h2`,`vel_v2`,`vel_ch12`,`displ_a2`,`displ_h2`,`displ_v2`,`displ_ch12`,`crest_factor_a2`,`crest_factor_h2`,`crest_factor_v2`,`crest_factor_ch12`,`bearing_a2`,`bearing_h2`,`bearing_v2`,`bearing_ch12`,`temperature_1`,`temperature_2`,`Date`)VALUES('None','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','" + PublicClass.GetDatetime() + "')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " . `alarms_data`(`Alarm_Name`,`accel_a1`,`accel_h1`,`accel_v1`,`accel_ch11`,`vel_a1`,`vel_h1`,`vel_v1`,`vel_ch11`,`displ_a1`,`displ_h1`,`displ_v1`,`displ_ch11`,`crest_factor_a1`,`crest_factor_h1`,`crest_factor_v1`,`crest_factor_ch11`,`bearing_a1`,`bearing_h1`,`bearing_v1`,`bearing_ch11`,`accel_a2`,`accel_h2`,`accel_v2`,`accel_ch12`,`vel_a2`,`vel_h2`,`vel_v2`,`vel_ch12`,`displ_a2`,`displ_h2`,`displ_v2`,`displ_ch12`,`crest_factor_a2`,`crest_factor_h2`,`crest_factor_v2`,`crest_factor_ch12`,`bearing_a2`,`bearing_h2`,`bearing_v2`,`bearing_ch12`,`temperature_1`,`temperature_2`,`Date`)VALUES('ISO-G1-R','0','0','0','0','7.1','7.1','7.1','7.1','90','90','90','90','9999','9999','9999','9999','0','0','0','0','0','0','0','0','2.3','2.3','2.3','2.3','29','29','29','29','9999','9999','9999','9999','0','0','0','0','0','0','" + PublicClass.GetDatetime() + "')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " . `alarms_data`(`Alarm_Name`,`accel_a1`,`accel_h1`,`accel_v1`,`accel_ch11`,`vel_a1`,`vel_h1`,`vel_v1`,`vel_ch11`,`displ_a1`,`displ_h1`,`displ_v1`,`displ_ch11`,`crest_factor_a1`,`crest_factor_h1`,`crest_factor_v1`,`crest_factor_ch11`,`bearing_a1`,`bearing_h1`,`bearing_v1`,`bearing_ch11`,`accel_a2`,`accel_h2`,`accel_v2`,`accel_ch12`,`vel_a2`,`vel_h2`,`vel_v2`,`vel_ch12`,`displ_a2`,`displ_h2`,`displ_v2`,`displ_ch12`,`crest_factor_a2`,`crest_factor_h2`,`crest_factor_v2`,`crest_factor_ch12`,`bearing_a2`,`bearing_h2`,`bearing_v2`,`bearing_ch12`,`temperature_1`,`temperature_2`,`Date`)VALUES('ISO-G1-F','0','0','0','0','11','11','11','11','140','140','140','140','9999','9999','9999','9999','0','0','0','0','0','0','0','0','3.5','3.5','3.5','3.5','45','45','45','45','9999','9999','9999','9999','0','0','0','0','0','0','" + PublicClass.GetDatetime() + "')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " . `alarms_data`(`Alarm_Name`,`accel_a1`,`accel_h1`,`accel_v1`,`accel_ch11`,`vel_a1`,`vel_h1`,`vel_v1`,`vel_ch11`,`displ_a1`,`displ_h1`,`displ_v1`,`displ_ch11`,`crest_factor_a1`,`crest_factor_h1`,`crest_factor_v1`,`crest_factor_ch11`,`bearing_a1`,`bearing_h1`,`bearing_v1`,`bearing_ch11`,`accel_a2`,`accel_h2`,`accel_v2`,`accel_ch12`,`vel_a2`,`vel_h2`,`vel_v2`,`vel_ch12`,`displ_a2`,`displ_h2`,`displ_v2`,`displ_ch12`,`crest_factor_a2`,`crest_factor_h2`,`crest_factor_v2`,`crest_factor_ch12`,`bearing_a2`,`bearing_h2`,`bearing_v2`,`bearing_ch12`,`temperature_1`,`temperature_2`,`Date`)VALUES('ISO-G2-R','0','0','0','0','4.5','4.5','4.5','4.5','71','71','71','71','9999','9999','9999','9999','0','0','0','0','0','0','0','0','1.4','1.4','1.4','1.4','22','22','22','22','9999','9999','9999','9999','0','0','0','0','0','0','" + PublicClass.GetDatetime() + "')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " . `alarms_data`(`Alarm_Name`,`accel_a1`,`accel_h1`,`accel_v1`,`accel_ch11`,`vel_a1`,`vel_h1`,`vel_v1`,`vel_ch11`,`displ_a1`,`displ_h1`,`displ_v1`,`displ_ch11`,`crest_factor_a1`,`crest_factor_h1`,`crest_factor_v1`,`crest_factor_ch11`,`bearing_a1`,`bearing_h1`,`bearing_v1`,`bearing_ch11`,`accel_a2`,`accel_h2`,`accel_v2`,`accel_ch12`,`vel_a2`,`vel_h2`,`vel_v2`,`vel_ch12`,`displ_a2`,`displ_h2`,`displ_v2`,`displ_ch12`,`crest_factor_a2`,`crest_factor_h2`,`crest_factor_v2`,`crest_factor_ch12`,`bearing_a2`,`bearing_h2`,`bearing_v2`,`bearing_ch12`,`temperature_1`,`temperature_2`,`Date`)VALUES('ISO-G2-F','0','0','0','0','7.1','7.1','7.1','7.1','113','113','113','113','9999','9999','9999','9999','0','0','0','0','0','0','0','0','2.3','2.3','2.3','2.3','37','37','37','37','9999','9999','9999','9999','0','0','0','0','0','0','" + PublicClass.GetDatetime() + "')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " . `alarms_data`(`Alarm_Name`,`accel_a1`,`accel_h1`,`accel_v1`,`accel_ch11`,`vel_a1`,`vel_h1`,`vel_v1`,`vel_ch11`,`displ_a1`,`displ_h1`,`displ_v1`,`displ_ch11`,`crest_factor_a1`,`crest_factor_h1`,`crest_factor_v1`,`crest_factor_ch11`,`bearing_a1`,`bearing_h1`,`bearing_v1`,`bearing_ch11`,`accel_a2`,`accel_h2`,`accel_v2`,`accel_ch12`,`vel_a2`,`vel_h2`,`vel_v2`,`vel_ch12`,`displ_a2`,`displ_h2`,`displ_v2`,`displ_ch12`,`crest_factor_a2`,`crest_factor_h2`,`crest_factor_v2`,`crest_factor_ch12`,`bearing_a2`,`bearing_h2`,`bearing_v2`,`bearing_ch12`,`temperature_1`,`temperature_2`,`Date`)VALUES('ISO-G3-R','0','0','0','0','7.1','7.1','7.1','7.1','56','56','56','56','9999','9999','9999','9999','0','0','0','0','0','0','0','0','2.3','2.3','2.3','2.3','18','18','18','18','9999','9999','9999','9999','0','0','0','0','0','0','" + PublicClass.GetDatetime() + "')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " . `alarms_data`(`Alarm_Name`,`accel_a1`,`accel_h1`,`accel_v1`,`accel_ch11`,`vel_a1`,`vel_h1`,`vel_v1`,`vel_ch11`,`displ_a1`,`displ_h1`,`displ_v1`,`displ_ch11`,`crest_factor_a1`,`crest_factor_h1`,`crest_factor_v1`,`crest_factor_ch11`,`bearing_a1`,`bearing_h1`,`bearing_v1`,`bearing_ch11`,`accel_a2`,`accel_h2`,`accel_v2`,`accel_ch12`,`vel_a2`,`vel_h2`,`vel_v2`,`vel_ch12`,`displ_a2`,`displ_h2`,`displ_v2`,`displ_ch12`,`crest_factor_a2`,`crest_factor_h2`,`crest_factor_v2`,`crest_factor_ch12`,`bearing_a2`,`bearing_h2`,`bearing_v2`,`bearing_ch12`,`temperature_1`,`temperature_2`,`Date`)VALUES('ISO-G3-F','0','0','0','0','11','11','11','11','90','90','90','90','9999','9999','9999','9999','0','0','0','0','0','0','0','0','3.5','3.5','3.5','3.5','28','28','28','28','9999','9999','9999','9999','0','0','0','0','0','0','" + PublicClass.GetDatetime() + "')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " . `alarms_data`(`Alarm_Name`,`accel_a1`,`accel_h1`,`accel_v1`,`accel_ch11`,`vel_a1`,`vel_h1`,`vel_v1`,`vel_ch11`,`displ_a1`,`displ_h1`,`displ_v1`,`displ_ch11`,`crest_factor_a1`,`crest_factor_h1`,`crest_factor_v1`,`crest_factor_ch11`,`bearing_a1`,`bearing_h1`,`bearing_v1`,`bearing_ch11`,`accel_a2`,`accel_h2`,`accel_v2`,`accel_ch12`,`vel_a2`,`vel_h2`,`vel_v2`,`vel_ch12`,`displ_a2`,`displ_h2`,`displ_v2`,`displ_ch12`,`crest_factor_a2`,`crest_factor_h2`,`crest_factor_v2`,`crest_factor_ch12`,`bearing_a2`,`bearing_h2`,`bearing_v2`,`bearing_ch12`,`temperature_1`,`temperature_2`,`Date`)VALUES('ISO-G4-R','0','0','0','0','4.5','4.5','4.5','4.5','36','36','36','36','9999','9999','9999','9999','0','0','0','0','0','0','0','0','1.4','1.4','1.4','1.4','11','11','11','11','9999','9999','9999','9999','0','0','0','0','0','0','" + PublicClass.GetDatetime() + "')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " . `alarms_data`(`Alarm_Name`,`accel_a1`,`accel_h1`,`accel_v1`,`accel_ch11`,`vel_a1`,`vel_h1`,`vel_v1`,`vel_ch11`,`displ_a1`,`displ_h1`,`displ_v1`,`displ_ch11`,`crest_factor_a1`,`crest_factor_h1`,`crest_factor_v1`,`crest_factor_ch11`,`bearing_a1`,`bearing_h1`,`bearing_v1`,`bearing_ch11`,`accel_a2`,`accel_h2`,`accel_v2`,`accel_ch12`,`vel_a2`,`vel_h2`,`vel_v2`,`vel_ch12`,`displ_a2`,`displ_h2`,`displ_v2`,`displ_ch12`,`crest_factor_a2`,`crest_factor_h2`,`crest_factor_v2`,`crest_factor_ch12`,`bearing_a2`,`bearing_h2`,`bearing_v2`,`bearing_ch12`,`temperature_1`,`temperature_2`,`Date`)VALUES('ISO-G4-F','0','0','0','0','7.1','7.1','7.1','7.1','56','56','56','56','9999','9999','9999','9999','0','0','0','0','0','0','0','0','2.3','2.3','2.3','2.3','18','18','18','18','9999','9999','9999','9999','0','0','0','0','0','0','" + PublicClass.GetDatetime() + "')");
                    PublicClass.statusbar(dbCreateProgbar);


                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`area_info` (`Area_ID` int(10) unsigned NOT NULL auto_increment,`Name` varchar(45) NOT NULL,`Description` varchar(500) default NULL, `Code` varchar(45) default NULL,`Address` varchar(45) default NULL, `Location` varchar(45) default NULL, `Position` varchar(45) default NULL, `FactoryID` int(11) default NULL, `PreviousID` int(11) default NULL,`NextID` int(11) default NULL, `DateCreated` datetime default NULL,PRIMARY KEY  (`Area_ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " . `band_data` (  `ID` int(11) NOT NULL auto_increment,  `BandAlarm_Name` varchar(45) default NULL,  `Freq` varchar(45) default NULL,  `X` longtext NOT NULL,  `Y` longtext NOT NULL,  `Axis_type` int(11) NOT NULL,  `Counter` int(11) NOT NULL default '0',  `Group_Id` int(11) NOT NULL,  `DateTime` datetime NOT NULL, PRIMARY KEY  (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `bandalarm_data` (`Bandalarmsgroup_id` int(10) unsigned NOT NULL auto_increment, `bandalarmsgroup_Name` varchar(45) NOT NULL, PRIMARY KEY  (`Bandalarmsgroup_id`))");
                    PublicClass.statusbar(dbCreateProgbar);
                    
                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " . `demodulate_data` (  `ID` int(11) NOT NULL auto_increment,  `Demodulate_Name` varchar(45) default NULL,  `Freq` varchar(45) default NULL,  `X` longtext NOT NULL,  `Y` longtext NOT NULL,  `Axis_type` int(11) NOT NULL,  `Counter` int(11) NOT NULL default '0',  `DateTime` datetime NOT NULL,  `Group_ID` int(11) default NULL, PRIMARY KEY  (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `detection` (`ID` int(11) NOT NULL auto_increment,`DetectionName` varchar(45) default NULL,PRIMARY KEY  (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " . `di_point` (`ID` int(11) NOT NULL auto_increment,`Type_ID` int(11) NOT NULL,`FullScale` varchar(45) NOT NULL,`Sensitivity` varchar(45) NOT NULL,  `Couple` varchar(45) NOT NULL,  `DetectionType` varchar(45) NOT NULL,`WindowType` varchar(45) NOT NULL,`FilterType` varchar(45) NOT NULL,`FilterValue` varchar(45) NOT NULL,`Direction` varchar(45) NOT NULL,`CollectionType` varchar(45) NOT NULL,`MeasureType` varchar(45) NOT NULL,`Resolution` varchar(45) NOT NULL,`Frequency` varchar(45) NOT NULL,`Orders` varchar(45) NOT NULL,`Overlap` varchar(45) NOT NULL,`TriggerType` varchar(45) NOT NULL,`Slope` varchar(45) NOT NULL,`Levels` varchar(45) NOT NULL,`TriggerRange` varchar(45) NOT NULL,`ChannelType` varchar(45) NOT NULL,`SpecAvg` varchar(45) NOT NULL,`TimeAvg` varchar(45) NOT NULL,`Type_Unit` varchar(45) default NULL,PRIMARY KEY  (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`c911_measurement` (  `ID` INT NOT NULL AUTO_INCREMENT,  `type_id` INT NULL,  `Channel1` INT NULL,  `SelectRadio1` VARCHAR(45) NULL,  `EV_Frequency` INT NULL,  `Channel2` INT NULL,  `SelectRadio2` VARCHAR(45) NULL,  `Spectrum_LineNo` INT NULL,  `Window_Type` INT NULL,  `Fmin` INT NULL,  `Fmax` INT NULL,  `Trigger_Mode` INT NULL,  `Avg_Mode` INT NULL,  `N` VARCHAR(45) NULL,  `Comments` VARCHAR(500) NULL,  PRIMARY KEY (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `display` (`DisplayID` int(11) NOT NULL,`Overall_Accel_a` float default NULL,  `Overall_Accel_h` float default NULL,`Overall_accel_v` float default NULL,`Overall_accel_ch1` float default NULL,`Overall_vel_a` float default NULL,`Overall_vel_h` float default NULL,`Overall_vel_v` float default NULL,`Overall_vel_ch1` float default NULL,`Overall_displ_a` float default NULL,`Overall_displ_h` float default NULL,`Overall_displ_v` float default NULL,`Overall_displ_ch1` float default NULL,`TimeGraph_a` longtext,`TimeGraph_h` longtext,`TimeGraph_v` longtext,`TimeGraph_ch1` longtext,`PowerGraph_a` longtext,`PowerGraph_h` longtext,`PowerGraph_v` longtext,`PowerGraph_ch1` longtext,`PowerGraph_a1` longtext,`PowerGraph_h1` longtext,`PowerGraph_v1` longtext,`PowerGraph_ch11` longtext,`Power2Graph_a` longtext,`Power2Graph_h` longtext,`Power2Graph_v` longtext,`Power2Graph_ch1` longtext,`Power2Graph_a1` longtext,`Power2Graph_h1` longtext,`Power2Graph_ch11` longtext,`Power3Graph_a` longtext,`Power3Graph_h` longtext,`Power3Graph_v` longtext,`Power3Graph_ch1` longtext,`Power3Graph_a1` longtext,`Power3Graph_h1` longtext,`Power3Graph_v1` longtext,`Power3Graph_ch11` longtext,`CepstrumGraph_a` longtext,`CepstrumGraph_h` longtext,  `CepstrumGraph_v` longtext,`CepstrumGraph_ch1` longtext,`DemodulateGraph_a` longtext,`DemodulateGraph_h` longtext,  `DemodulateGraph_v` longtext,`DemodulateGraph_Ch1` longtext,PRIMARY KEY  (`DisplayID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ".  `factory_info` (  `Factory_ID` int(10) unsigned NOT NULL auto_increment,  `Name` varchar(45) NOT NULL,  `Description` varchar(45) default NULL,  `Address` varchar(45) default NULL,  `Location` varchar(45) default NULL,  `DateCreated` datetime default NULL,  `PreviousID` int(11) default NULL,`NextID` int(11) default NULL,  PRIMARY KEY  (`Factory_ID`)) ");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`faultfreq_data` (  `Pf_ID` int(10) unsigned NOT NULL auto_increment,  `pf_name` varchar(45) default NULL,  `pf_freq` double default NULL,  `Date` datetime default NULL,  PRIMARY KEY  (`Pf_ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .  `instruments` (  `uid` int(11) NOT NULL auto_increment,  `instrumentname` varchar(50) default NULL,  PRIMARY KEY  (`uid`))");

                    //
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`instruments`(`instrumentname`)  VALUES('Impaq-Benstone')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`instruments`(`instrumentname`)  VALUES('SKF/DI')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`instruments`(`instrumentname`)  VALUES('Kohtect-C911')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`instruments`(`instrumentname`)  VALUES('ROHZ/IADEPT')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`instruments`(`instrumentname`)  VALUES('FieldPaq2')");
                    //

                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " . `login_data` (  `ID` int(10) unsigned NOT NULL auto_increment,  `User_ID` varchar(45) NOT NULL,  `uPassword` varchar(45) NOT NULL,  `Upload` varchar(45) NOT NULL,  `Download` varchar(45) NOT NULL,  PRIMARY KEY  (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`login_data`(`User_ID`,`uPassword`,`Upload`,`Download`) VALUES('admin','admin','0','0')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " . `machine_info` (  `Machine_ID` int(10) unsigned NOT NULL auto_increment,  `Name` varchar(45) NOT NULL,  `Description` varchar(1000) default NULL,  `ManufactureID` varchar(45) default NULL,  `Type` varchar(45) default NULL,  `Cost_GroupID` varchar(45) default NULL,  `LastMaintaince_Date` datetime default NULL,  `MaintainceSchedule` datetime default NULL,  `WorkOrder` varchar(45) default NULL,  `WorkCompletionDate` datetime default NULL,  `Serial_No` varchar(45) default NULL,  `NextMaintaincedate` datetime default NULL,  `MachinePart_No` varchar(45) default NULL,  `Purchase_Date` datetime default NULL,  `Est_RunningHrs` int(10) unsigned default NULL,  `RPM_Driven` int(10) unsigned default NULL,  `RPM_Driver` int(10) unsigned default NULL,  `RPM3` int(10) unsigned default NULL,  `RPM4` int(10) unsigned default NULL,  `Change_SrNo` varchar(45) default NULL,  `BearingID` int(11) default NULL,  `BearingID2` int(11) default NULL,  `BearingID3` int(11) default NULL,  `GearID1` int(11) default NULL,  `GearID2` int(11) default NULL,  `GearID3` int(11) default NULL,  `TrainID` int(11) default NULL,  `PreviousID` int(11) default NULL,  `NextID` int(11) default NULL,  `Position` int(11) default NULL,  `DateCreated` datetime default NULL,`PulseRev` int(11) default NULL , PRIMARY KEY  (`Machine_ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " . `machine_pic` (`ID` int(11) NOT NULL auto_increment,  `Picture` longtext NOT NULL,  `MachineID` int(11) default NULL,  `Description` varchar(45) default NULL,PRIMARY KEY  (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " . `comp_image` ( `ID` int(11) NOT NULL AUTO_INCREMENT, `Company_Name` varchar(45) DEFAULT NULL, `Company_logoimage` longtext NOT NULL,PRIMARY KEY (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " . `manufacture` (  `ID` int(11) NOT NULL auto_increment,`ManufactureName` varchar(45) default NULL,  `ManufactureAddress` varchar(45) default NULL,  PRIMARY KEY  (`ID`))");

                    //
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`manufacture`(`ManufactureName`,`ManufactureAddress`)  VALUES( 'CTC','USA')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`manufacture`(`ManufactureName`,`ManufactureAddress`)   VALUES( 'IMI','USA')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`manufacture`(`ManufactureName`,`ManufactureAddress`)   VALUES( 'PCB','USA')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`manufacture`(`ManufactureName`,`ManufactureAddress`)   VALUES( 'Wilcoxon','USA')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`manufacture`(`ManufactureName`,`ManufactureAddress`)   VALUES( 'MMF','Germany')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`manufacture`(`ManufactureName`,`ManufactureAddress`)   VALUES( 'Monitran','UK')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`manufacture`(`ManufactureName`,`ManufactureAddress`)   VALUES( 'Sensonics','UK')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`manufacture`(`ManufactureName`,`ManufactureAddress`)   VALUES( 'PICO','USA')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`manufacture`(`ManufactureName`,`ManufactureAddress`)   VALUES( 'Raytek','USA')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`manufacture`(`ManufactureName`,`ManufactureAddress`)   VALUES( 'Omega','USA')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`manufacture`(`ManufactureName`,`ManufactureAddress`)   VALUES( 'Dytran','USA')");
                    PublicClass.statusbar(dbCreateProgbar);
                    //
                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`measure` (  `ID` int(10) unsigned NOT NULL auto_increment,  `Type_ID` int(11) default NULL,  `acc_filter` varchar(45) default NULL,  `vel_filter` varchar(45) default NULL,  `displ_filter` varchar(45) default NULL,  `crest_factor_filter` varchar(45) default NULL, `bearing_acc_hp_filter` VARCHAR(45) NULL DEFAULT NULL, `overall_bearing_filter` varchar(45) default NULL,  `ordertrace_average_times` varchar(45) default NULL,  `ordertrace_resolution` varchar(45) default NULL,  `ordertrace_order` varchar(45) default NULL,  `ordertrace_trigger_slope` varchar(45) default NULL,  `time_band` varchar(45) default NULL,  `time_resoltion` varchar(45) default NULL,  `time_overlap` varchar(45) default NULL, `SensorDir` int(11) default NULL, `Sensor_ID` int(11) default NULL,  `TemperatureID` int(11) default NULL,  `power_multiple` varchar(45) default NULL,  `power_band` varchar(45) default NULL,  `power_resolution` varchar(45) default NULL,  `power_band1` varchar(45) default NULL,  `power_resolution1` varchar(45) default NULL,  `power2_band` varchar(45) default NULL,  `power2_resolution` varchar(45) default NULL,  `power2_band1` varchar(45) default NULL,  `power2_resolution1` varchar(45) default NULL,  `power3_band` varchar(45) default NULL,  `power3_resolution` varchar(45) default NULL,  `power3_band1` varchar(45) default NULL,  `power3_resolution1` varchar(45) default NULL,  `power_window` varchar(45) default NULL,  `power_average_times` varchar(45) default NULL,  `power_overlap` varchar(45) default NULL,  `power_zoom` int(10) unsigned default NULL,  `power_zoom_startfeq` float default NULL,  `cepstrum_band` varchar(45) default NULL,  `cepstrum_resolution` varchar(45) default NULL,  `cepstrum_window` varchar(45) default NULL,  `cepstrum_average_times` varchar(45) default NULL,  `cepstrum_overlap` varchar(45) default NULL,  `cepstrum_zoom` varchar(45) default NULL,  `cepstrum_zoom_startfeq` float default NULL,  `demodulate_band` varchar(45) default NULL,  `demodulate_resolution` varchar(45) default NULL,  `demodulate_window` varchar(45) default NULL,  `demodulate_average_times` varchar(45) default NULL,  `demodulate_filter` varchar(45) default NULL,  `Date` datetime default NULL,`OctaveSetting` varchar(45) default NULL,`OctaveBar` varchar(45) default NULL,  PRIMARY KEY  (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " . `machine_record`( `Id` int(11) NOT NULL auto_increment,`Date` datetime default NULL,`Machine_Id` int(11) default NULL,`Note_id` int(11) default NULL,PRIMARY KEY  (`Id`))");
                    PublicClass.statusbar(dbCreateProgbar);


                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`measure_type` (  `ID` int(11) NOT NULL auto_increment,  `Type_ID` int(11) NOT NULL, `OAcc` tinyint(1) NOT NULL, `OVel` tinyint(1) NOT NULL,`ODisp` tinyint(1) NOT NULL,  `OBear` tinyint(1) NOT NULL,`OTWF` tinyint(1) NOT NULL,  `OPS` tinyint(1) NOT NULL,  `ODS` tinyint(1) NOT NULL,  `Temp` tinyint(1) NOT NULL,  `Process` tinyint(1) NOT NULL,  `crestfactor` tinyint(1) NOT NULL,  `Ordertrace` tinyint(1) NOT NULL,  `Cepstrum` tinyint(1) NOT NULL,`CalcMeasure` int(11) NOT NULL,  PRIMARY KEY  (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`notes` (  `Notes_ID` int(11) NOT NULL auto_increment,  `Notes_Desc` varchar(2000) default NULL,  `Note_Type` varchar(45) default NULL,  `Date` datetime default NULL,  PRIMARY KEY  (`Notes_ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`point_note2` (`Date` DATETIME NOT NULL,`Point_Id` INT NOT NULL,`Note_ID` INT NOT NULL AUTO_INCREMENT,`Note` VARCHAR(1000) NULL,`Point_DataID` int NULL ,PRIMARY KEY (`Note_ID`)) ");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`percentage_alarm` (  `Percentage_AlarmID` int(11) NOT NULL auto_increment,  `PerAlarm_Name` varchar(45) default NULL,  `Per_Accel` varchar(45) default NULL,  `Per_Vel` varchar(45) default NULL,  `Per_Displ` varchar(45) default NULL,  `Per_Bearing` varchar(45) default NULL,  PRIMARY KEY  (`Percentage_AlarmID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO  " + DBName + " .`percentage_alarm`(`PerAlarm_Name`,`Per_Accel`,`Per_Vel`,`Per_Displ`,`Per_Bearing`)VALUES('None','0','0','0','0')");

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ".`company_data` (`id` INT NOT NULL,`Company_Name` VARCHAR(45) NULL,`Company_logoimage` VARCHAR(45) NULL,PRIMARY KEY (`id`))");
                    
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " . `point` (  `Point_ID` int(11) NOT NULL auto_increment,  `PointName` varchar(45) NOT NULL,  `PointDesc` varchar(45) default NULL,  `PointType_ID` int(11) NULL,  `Alarm_ID` int(11) NULL,  `StdDeviation_ID` int(11) NULL,  `PerAlarm_ID` int(11) NULL,  `Point_DisplayID` int(11) NULL,  `DataCreated` varchar(45) NULL,  `Change_ID` int(11) NULL,  `PreviousID` int(11) default NULL,  `NextID` int(11) default NULL,  `Machine_ID` int(11) default NULL,  `DataSchedule` varchar(45) default NULL,`PointStatus` int(11) default NULL,`PointSchedule` int(11) default NULL,  PRIMARY KEY  (`Point_ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`point_alarm` (  `PointID` int(11) NOT NULL,  `Alarm_ID` int(11) NOT NULL)");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`point_balarm` (  `Point_ID` int(11) NOT NULL,  `BA_ID` int(11) NOT NULL)");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`point_bearing` (  `Bearing_ID` int(11) NOT NULL auto_increment,  `Point_ID` int(11) default NULL,  `Manufacture` varchar(45) default NULL,  `BearingNumber` varchar(45) default NULL,  `MachineID` int(11) default NULL,  `BALLS` varchar(45) default NULL,  `FTF` varchar(45) default NULL,  `BSF` varchar(45) default NULL,  `BPFO` varchar(45) default NULL,  `BPFI` varchar(45) default NULL,   `BDIR` varchar(45) DEFAULT NULL,  `BDOR` varchar(45) DEFAULT NULL , `BCA` varchar(45) DEFAULT NULL  ,`BDRE` varchar(45) DEFAULT NULL , `BNRE` varchar(45) DEFAULT NULL,`Status` varchar(45) DEFAULT NULL,PRIMARY KEY  (`Bearing_ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`point_data` (  `Data_ID` int(10) unsigned NOT NULL auto_increment,  `Point_ID` int(11) default NULL,  `Point_name` varchar(45) NOT NULL,  `Point_Type` varchar(45) NOT NULL,  `Measure_time` datetime default NULL,  `accel_a` float default NULL, `accel_h` float default NULL,  `accel_v` float default NULL,  `accel_ch1` float default NULL,  `vel_a` float default NULL,  `vel_h` float default NULL,  `vel_v` float default NULL,  `vel_ch1` float default NULL,  `displ_a` float default NULL,  `displ_h` float default NULL,  `displ_v` float default NULL,  `displ_ch1` float default NULL,  `crest_factor_a` float default NULL,  `crest_factor_h` float default NULL,  `crest_factor_v` float default NULL,  `crest_factor_ch1` float default NULL,  `bearing_a` float default NULL,  `bearing_h` float default NULL,  `bearing_v` float default NULL,  `bearing_ch1` float default NULL,  `ordertrace_a_real` float default NULL,  `ordertrace_h_real` float default NULL,  `ordertrace_v_real` float default NULL,  `ordertrace_ch1_real` float default NULL,  `ordertrace_a_image` float default NULL,  `ordertrace_h_image` float default NULL,  `ordertrace_v_image` float default NULL,  `ordertrace_ch1_image` float default NULL,  `ordertrace_rpm` int(10) unsigned default NULL,  `temperature` float default NULL,  `Process` float default NULL,  `auto_measure` int(10) unsigned default NULL,  `record_status` smallint(5) unsigned default NULL,  `Notes1` varchar(45) default NULL,  `Notes2` varchar(45) default NULL,  `IDateTime` datetime default NULL,  `Manual` varchar(500) default NULL,  `timeA_X` longtext,  `timeA_Y` longtext,  `timeH_X` longtext,  `timeH_Y` longtext,  `timeV_X` longtext,  `timeV_Y` longtext,  `timeCH1_X` longtext,  `timeCH1_Y` longtext,  `PA_X` longtext,  `PA_Y` longtext,  `PH_X` longtext,  `PH_Y` longtext,  `PV_X` longtext,  `PV_Y` longtext,  `PCH1_X` longtext,  `PCH1_Y` longtext,  `P1A_X` longtext,  `P1A_Y` longtext,  `P1H_X` longtext,  `P1H_Y` longtext,  `P1V_X` longtext,  `P1V_Y` longtext,  `P1CH1_X` longtext,  `P1CH1_Y` longtext,  `P2A_X` longtext,  `P2A_Y` longtext,  `P2H_X` longtext,  `P2H_Y` longtext,  `P2V_X` longtext,  `P2V_Y` longtext,  `P2CH1_X` longtext,  `P2CH1_Y` longtext,  `P21A_X` longtext,  `P21A_Y` longtext,  `P21H_X` longtext,  `P21H_Y` longtext,  `P21V_X` longtext,  `P21V_Y` longtext,  `P21CH1_X` longtext,  `P21CH1_Y` longtext,  `P3A_X` longtext,  `P3A_Y` longtext,  `P3H_X` longtext,  `P3H_Y` longtext,  `P3V_X` longtext,  `P3V_Y` longtext,  `P3CH1_X` longtext,  `P3CH1_Y` longtext,  `P31A_X` longtext,  `P31A_Y` longtext,  `P31H_X` longtext,  `P31H_Y` longtext,  `P31V_X` longtext,  `P31V_Y` longtext,  `P31CH1_X` longtext,  `P31CH1_Y` longtext,  `CEPA_X` longtext,  `CEPA_Y` longtext,  `CEPH_X` longtext,  `CEPH_Y` longtext,  `CEPV_X` longtext, `CEPV_Y` longtext,  `CEPCH1_X` longtext,  `CEPCH1_Y` longtext,  `DEMA_X` longtext,  `DEMA_Y` longtext,  `DEMH_X` longtext,  `DEMH_Y` longtext,  `DEMV_X` longtext,  `DEMV_Y` longtext,  `DEMCH1_X` longtext,  `DEMCH1_Y` longtext,Counter int(11) default NULL,  PRIMARY KEY  (`Data_ID`))ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=latin1");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`point_demodulate` (`Point_ID` int(11) NOT NULL,`Demodulate_ID` int(11) NOT NULL)");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`point_display` (`Point_ID` int(11) NOT NULL ,`DisplayType_ID` int(11) NOT NULL)");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`point_faultfreq` (`Point_ID` int(11) NOT NULL,`FaultFreq_ID` int(11) NOT NULL)");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`point_notes` (`Point_ID` int(11) NOT NULL,`Notes_ID` int(11) NOT NULL)");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `proj_design` ( `id` int(11) NOT NULL  AUTO_INCREMENT, `UserName` varchar(45) NOT NULL, `Password` varchar(45) NOT NULL  , `pDesign` varchar(500) DEFAULT NULL, `pColor` varchar(500) DEFAULT NULL,  `pFont` varchar(500) DEFAULT NULL, PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8");
                    PublicClass.statusbar(dbCreateProgbar);


                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `sensor_data` (  `Sensor_ID` int(10) unsigned NOT NULL auto_increment,  `Sensor_name` varchar(45) default NULL,  `Sensor_type` varchar(45) NOT NULL,  `Sensitivity_a` varchar(45) default NULL,  `Sensitivity_h` varchar(45) default NULL,  `Sensitivity_v` varchar(45) default NULL,  `Senitivity_Ch1` varchar(45) default NULL,  `Sensor_unit` varchar(45) default NULL,  `Sensor_dir` varchar(45) default NULL,  `Sensor_icp` varchar(45) default NULL,  `Sensor_offset` varchar(45) default NULL,  `defaulttype` int(11) default NULL,  `Manufacture_ID` int(11) default NULL,  `Input_Range` int(11) default NULL,  PRIMARY KEY  (`Sensor_ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    /////////////////// Insert Value in Sensor //////////////////////////

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_data`(`Sensor_name`,`Sensor_type`,`Sensitivity_a`,`Sensitivity_h`,`Sensitivity_v`,`Senitivity_Ch1`,`Sensor_unit`,`Sensor_dir`,`Sensor_icp`,`Sensor_offset`,`defaulttype`,`Manufacture_ID`,`Input_Range`)VALUES( ' defaulticp ' ,'0' ,'100' ,'100' ,'100' ,'100' ,'0' ,'1' ,'1' ,'0' ,'1' ,'0','0')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_data`(`Sensor_name`,`Sensor_type`,`Sensitivity_a`,`Sensitivity_h`,`Sensitivity_v`,`Senitivity_Ch1`,`Sensor_unit`,`Sensor_dir`,`Sensor_icp`,`Sensor_offset`,`defaulttype`,`Manufacture_ID`,`Input_Range`)VALUES( 'defaultTemp', '3', '1' ,'1' ,'1' ,'1' ,'0' ,'1', '1', '0', '1', ' 0','0')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_data`(`Sensor_name`,`Sensor_type`,`Sensitivity_a`,`Sensitivity_h`,`Sensitivity_v`,`Senitivity_Ch1`,`Sensor_unit`,`Sensor_dir`,`Sensor_icp`,`Sensor_offset`,`defaulttype`,`Manufacture_ID`,`Input_Range`)VALUES( 'defaultdisp', '2' ,'8' ,'8' ,'8' ,'8' ,'1' ,'1', '0', '0', '1', '0','1')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_data`(`Sensor_name`,`Sensor_type`,`Sensitivity_a`,`Sensitivity_h`,`Sensitivity_v`,`Senitivity_Ch1`,`Sensor_unit`,`Sensor_dir`,`Sensor_icp`,`Sensor_offset`,`defaulttype`,`Manufacture_ID`,`Input_Range`)VALUES( 'defaultcurrent' ,'5' ,'10', '10', '10', '10' ,'0', '1', '0', '0', '1', '0', '1')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_data`(`Sensor_name`,`Sensor_type`,`Sensitivity_a`,`Sensitivity_h`,`Sensitivity_v`,`Senitivity_Ch1`,`Sensor_unit`,`Sensor_dir`,`Sensor_icp`,`Sensor_offset`,`defaulttype`,`Manufacture_ID`,`Input_Range`)VALUES( 'defaultpressure' ,'4', '20' ,'20' ,'20', '20', '1' ,'1', '1', '0', '1', '0', '1')");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `sensor_type` (  `ID` int(11) NOT NULL auto_increment,  `SensorType` varchar(45) default NULL,  `Unit` varchar(45) default NULL,  `Sensortypeint` int(11) default NULL,  `Sensorunitint` int(11) default NULL,  PRIMARY KEY  (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    //-------------Insert value in for Sensor Type---------------------------------------//
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Acceleration', 'Gs' ,'0', '0')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Acceleration', 'gal' ,'0', '1')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Acceleration', 'm/s2' ,'0', '2')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Velocity', 'mm/sec' ,'1', '0')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Velocity' ,'in/sec', '1', '1')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Velocity' ,'cm/sec', '1' ,'2')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Displacement', 'mil', '2', '0')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Displacement', 'um', '2', '1')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Temperature', 'DegC', '3', '0')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Temperature', 'DegF', '3', '1')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Pressure' ,'Pa', '4', '0')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Pressure' ,'Bar', '4', '1')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Current', 'mA', '5' ,'0')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Sound', 'dB', '6' ,'0')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`sensor_type`(`SensorType`,`Unit`,`Sensortypeint`,`Sensorunitint`)  VALUES( 'Sound', 'Pascal', '6' ,'1')");
                    PublicClass.statusbar(dbCreateProgbar);

                    //---------------------------------------------------------------------------//

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`stddeviationalarm` (  `STDDeviationAlarm_ID` int(11) NOT NULL auto_increment,  `STDAlarm_Name` varchar(45) default NULL,  `Deviation_accel` varchar(45) default NULL,  `Deviation_Vel` varchar(45) default NULL,  `Deviation_Displ` varchar(45) default NULL,  `Deviation_Bearing` varchar(45) default NULL,  PRIMARY KEY  (`STDDeviationAlarm_ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO  " + DBName + " . `stddeviationalarm`(`STDAlarm_Name`,`Deviation_accel`,`Deviation_Vel`,`Deviation_Displ`,`Deviation_Bearing`) VALUES('None','0','0','0','0')");

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`train_info` (  `Train_ID` int(10) unsigned NOT NULL auto_increment,  `Name` varchar(45) NOT NULL,  `Description` varchar(450) default NULL,  `Code` varchar(45) default NULL,  `Address` varchar(45) default NULL,  `Location` varchar(45) default NULL,  `Position` varchar(45) default NULL,  `PreviousID` int(11) default NULL,  `NextID` int(11) default NULL,  `Area_ID` int(11) default NULL,  `Date` datetime default NULL,  PRIMARY KEY  (`Train_ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + " .`type_point` (  `ID` int(11) NOT NULL auto_increment,  `Type_ID` int(10) DEFAULT NULL,  `Point_Name` varchar(45) NOT NULL,  `Point_dir` smallint(5) unsigned default NULL,  `Instrumentname` varchar(45) default NULL,  `Point_record_status` smallint(5) unsigned default NULL,  `point_status` tinyint(3) unsigned default NULL,  `point_schedule` tinyint(3) unsigned default NULL,  `point_measurement` int(10) unsigned default NULL,  `vibration_sensor` int(10) unsigned default NULL,  `temperature_sensor` int(10) unsigned default NULL,  `unit_id` int(10) unsigned default NULL,  `measure_id` int(10) unsigned default NULL,  `note_id` int(10) unsigned default NULL,  `Alarm_ID` int(10) unsigned default NULL,  `Percentage_AlarmID` int(11) default NULL,  `STDDeviationAlarm_ID` int(11) default NULL, `Band_ID` int(11) default NULL , `machine_id` int(10) unsigned default NULL,  `record_id` int(10) unsigned default NULL,  `Factory_id` int(11) default NULL,  `Area_id` int(11) default NULL,  `Train_id` int(11) default NULL,  `Description` varchar(200) default NULL,  `Date` datetime default NULL,  `SDT` varchar(45) default NULL,  PRIMARY KEY  (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `units` (  `Unit_ID` int(10) unsigned NOT NULL auto_increment,  `accel_unit` varchar(45) default NULL,  `vel_unit` varchar(45) default NULL,  `displ_unit` varchar(45) default NULL,  `pressure_unit` varchar(45) default NULL,  `current_unit` varchar(45) default NULL,  `temperature_unit` varchar(45) default NULL,  `process_unit` varchar(45) default NULL,  `accel_detection` varchar(45) default NULL,  `vel_detection` varchar(45) default NULL,  `displ_detection` varchar(45) default NULL,  `pressure_detection` varchar(45) default NULL,  `current_detection` varchar(45) default NULL,  `ordertrace_unit_type` varchar(45) default NULL,  `time_unit_type` varchar(45) default NULL,  `power_unit_type` varchar(45) default NULL,  `cepstrum_unit_type` varchar(45) default NULL,  `demodulate_unit_type` varchar(45) default NULL,  `Type_ID` int(11) default NULL,  `Date` datetime default NULL,  PRIMARY KEY  (`Unit_ID`)) ");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `userdetail` (  `ID` int(11) NOT NULL auto_increment,  `UserName` varchar(45) default NULL,  `Password` varchar(45) default NULL,  `Login` int(11) default NULL,  `LastloginDate` datetime default NULL,  `DatabaseName` varchar(45) default NULL,  PRIMARY KEY  (`ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`userdetail`(`UserName`,`Password`,`Login`,`LastloginDate`,`DatabaseName`) VALUES('admin', 'admin','0','" + PublicClass.GetDatetime() + "' , '" + DBName + "')");



                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `usersettings` (  `UsrID` int(11) NOT NULL auto_increment,  `UserName` varchar(45) default NULL,  `TabName` varchar(45) default NULL,  `UserDetailID` int(11) default NULL,`Addition` int(11) default NULL,  `Deletion` int(11) default NULL,  `Modification` int(11) default NULL,  `ReportView` int(11) default NULL,  `UpDown` int(11) default NULL,  `Other` int(11) default NULL,  PRIMARY KEY  (`UsrID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `database_backup` (`DataBaseName` varchar(50) NOT NULL, `BackupDateTime` datetime NOT NULL)");
                    PublicClass.statusbar(dbCreateProgbar);

                
                    
                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `machine_diagram_train` ( `id` int(11) NOT NULL auto_increment,`area_id` varchar(50) default NULL,`train_id` int(11) default NULL, `datetime` datetime default NULL, PRIMARY KEY  (`id`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `machine_diagram` ( `id` int(11) NOT NULL auto_increment, `Area_id` int(11) default NULL, `datetime` datetime default NULL, PRIMARY KEY  (`id`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `machine_type` ( `id` int(11) NOT NULL auto_increment, `Area_Id` int(11) default NULL, `Mac_Id` int(11) default NULL, `Mac_Name` varchar(45) default NULL, `Mac_type` varchar(45) default NULL, `Mac_RPM` int(11) default NULL, `Mac_Make` varchar(45) default NULL, `Mac_SerialNo` int(11) default NULL, `Sen_ID` varchar(45) default NULL, `Sen_type` int(11) default NULL, `sen_unit` int(11) default NULL, `sen_dir` int(11) default NULL, `Sen_cal` int(11) default NULL, `Sen_X` int(11) default NULL, `Sen_Y` int(11) default NULL, `Sen_Z` int(11) default NULL,`Mac_Tag` int(11) default NULL, PRIMARY KEY  (`id`))");
                    PublicClass.statusbar(dbCreateProgbar);


                    //-------------Insert value in for User Settings---------------------------------------//

                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`usersettings`(`UserName`,`TabName`,`UserDetailID`,`Addition`,`Deletion`,`Modification`,`ReportView`,`UpDown`,`Other`) VALUES('admin','Route','1','1','1','1','1','1','0')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`usersettings`(`UserName`,`TabName`,`UserDetailID`,`Addition`,`Deletion`,`Modification`,`ReportView`,`UpDown`,`Other`) VALUES('admin','Alarms','1','1','1','1','1','1','0')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`usersettings`(`UserName`,`TabName`,`UserDetailID`,`Addition`,`Deletion`,`Modification`,`ReportView`,`UpDown`,`Other`) VALUES('admin','Sensors','1','1','1','1','1','1','0')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`usersettings`(`UserName`,`TabName`,`UserDetailID`,`Addition`,`Deletion`,`Modification`,`ReportView`,`UpDown`,`Other`) VALUES('admin','Point Type','1','1','1','1','1','1','0')");
                    DbClass.executequery(CommandType.Text, "INSERT INTO " + DBName + " .`usersettings`(`UserName`,`TabName`,`UserDetailID`,`Addition`,`Deletion`,`Modification`,`ReportView`,`UpDown`,`Other`) VALUES('admin','Reports','1','1','1','1','1','1','0')");
                    
                    ////////////////-----StoredProcedure Creation-------------////////////////

                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE " + DBName + " . `AlarmData_By_AlarmName`(in ssSelectedAlarmName varchar(45)) BEGIN select * from alarms_data where Alarm_Name =  ssSelectedAlarmName ; END");
                    PublicClass.statusbar(dbCreateProgbar);


                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE " + DBName + " . `AlarmId_By_CurrentPointId`(in pid int ) BEGIN Select Alarm_ID from point where Point_ID= pid; END");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE " + DBName + " .  `BandData_By_ID`(in iId int) BEGIN select * from  band_data a where ID = iId ;  END");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE " + DBName + " .  `CheckPointTypeId`(in v_type_id int) BEGIN select distinct  a.PointType_ID from POINT a  inner join  type_point b on a.PointType_ID=b.id  where PointType_ID=v_type_id; END");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE " + DBName + " .  `DatabaseName`(in v_instrumentname varchar(45)) BEGIN Select Database_name as SCHEMA_NAME from route.databasename where InstrumentName=v_instrumentname; END");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE " + DBName + " . `Delete_BandDataByID`(in bID int,in bgID int) BEGIN Delete  from band_data where Counter = bID and Group_ID = bgID ; END");
                    PublicClass.statusbar(dbCreateProgbar);


                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Delete_DemoDataByID`(in dID int,in bgID int) BEGIN Delete from demodulate_data  where Counter = dID and Group_ID = bgID; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Delete_FaultFrequencyById`(in fid int) BEGIN Delete from faultfreq_data where Pf_ID = fid ; Delete from point_faultfreq where FaultFreq_ID = fid ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Delete_Notes`(in cid int ) BEGIN delete from notes Where  Notes_ID = cid ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `DeleteAlarms_By_AlarmName`(in sAlarmname varchar(45)) BEGIN Delete from alarms_data where Alarm_Name=sAlarmname; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `DeletePAlarm_By_PName`(in paName varchar(45)) BEGIN Delete from percentage_alarm where PerAlarm_Name= paName ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Deletepointtype`(in v_type_id int) BEGIN delete from  measure_type   where type_id =v_type_id ; delete from  measure   where type_id =v_type_id ; delete from  units   where type_id =v_type_id ; delete from  di_point   where type_id =v_type_id;  delete from   type_point where ID =v_type_id; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    //DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `deleteroute`(in type_id int)BEGIN delete from route_data where id=type_id; delete from route_data1 where id=type_id; END ");
                    //PublicClass.statusbar(progbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `DeleteSensor`(in Sen_id int) BEGIN delete from sensor_data where Sensor_ID=Sen_id; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `DeleteSTDAlarm_by_Name`(in stdName varchar(45)) BEGIN Delete from stddeviationalarm where STDAlarm_Name = stdName ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_AlarmData`() BEGIN select * from alarms_data ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_AlarmId_By_AlarmName`(in ssAlarmName varchar(45)) BEGIN select Alarm_ID from Alarms_data where Alarm_Name = ssAlarmName ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_cNotes`(in nId int) BEGIN Select Notes_Desc , Note_type from notes where Notes_ID = nId ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_DemoBand`(in dPointid int) BEGIN SELECT  distinct  Demodulate_Name,Freq ,X,Y FROM  demodulate_data where  group_id  = dPointid; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_DemoDAtaByID`(in dID int) BEGIN select * from  demodulate_data a where ID = dID ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_Faultfrequency`(in fpointid int) BEGIN SELECT  distinct  pf_name,pf_freq ,a.pf_id  FROM   faultfreq_data  a  join  point_faultfreq b on a.pf_id =b.FaultFreq_ID where  b.point_id  = fpointid ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `GetPointTypeId_By_AlarmId`(in AlarmID int) BEGIN  select distinct Type_ID,Point_Name from type_point where Alarm_ID=AlarmID ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_FaultFrequencyByID`(in fID int) BEGIN select * from  faultfreq_data a where pf_id = fID;  END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_MaxFFreqId`() BEGIN select max(pf_id) from  faultfreq_data ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_MaxIDOfBandData`() BEGIN select max(ID) from  band_data ;  END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_MaxIdOfDemoBand`() BEGIN select max(ID) from  demodulate_data ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_Notes`() BEGIN select Notes_Desc , Note_type  , Date , Notes_ID from  notes order by notes_id asc; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_PAlarmID_By_PAlarmName`(in paName varchar(45)) BEGIN select  Percentage_AlarmID from percentage_alarm where PerAlarm_Name = paName ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_Point_Alarm`() BEGIN select * from Point_Alarm; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_Point_by_AnyPointId`(in aPid int ) BEGIN select  * from Point where  Point_ID = aPid ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_PowerBand`(in pPointid int) BEGIN SELECT distinct  BandAlarm_Name,Freq , X , Y  FROM band_data   where  group_id  = pPointid; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Get_STDAlarm`() BEGIN Select * from stddeviationalarm; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `GetAlarmID`(in spointid int) BEGIN select b.PointID,a.Alarm_ID,s.STDDeviationAlarm_ID,Percentage_AlarmID from alarms_data a left join point_alarm b on a.Alarm_ID=b.Alarm_ID left  join stddeviationalarm s on b.PointID=s.Point_ID left join  percentage_alarm pa on pa.Point_ID= b.PointID  where b.PointID=spointid ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `GetAlarmName`() BEGIN SELECT distinct Alarm_Name FROM alarms_data; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `GetPAlarmWithValue`() BEGIN select distinct PerAlarm_Name,Per_Accel  from percentage_alarm; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `GetPointId_By_AlarmId`(in ssAID int) BEGIN select PointID from Point_Alarm where Alarm_ID=ssAID ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `GetPointId_by_PAlarmId`(in perAlarmID int) BEGIN select  Point_ID from Point where  PerAlarm_ID =  perAlarmID ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `GetPointId_By_StdDeviation_ID`(in stdAlarmid int) BEGIN select  Point_ID from point where  StdDeviation_ID = stdAlarmid ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `GetSDAlarmWithValue`() BEGIN select distinct STDAlarm_Name,Deviation_accel  from stddeviationalarm; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_Alarm`(in accel_aa1 varchar(45) , in accel_hh1 varchar(45) , in accel_vv1 varchar(45) , in accel_aa2 varchar(45), in accel_hh2 varchar(45) , in accel_vv2 varchar(45), in accel_chh11 varchar(45), in accel_chh12 varchar(45), in vel_aa1 varchar(45), in vel_hh1 varchar(45), in vel_vv1 varchar(45), in vel_aa2 varchar(45), in vel_hh2 varchar(45), in vel_vv2 varchar(45), in vel_chh11 varchar(45),  in vel_chh12 varchar(45), in displ_aa1 varchar(45), in displ_hh1 varchar(45), in displ_vv1 varchar(45), in displ_aa2 varchar(45), in displ_hh2 varchar(45), in displ_vv2 varchar(45), in displ_chh11 varchar(45), in displ_chh12 varchar(45), in bearing_aa1 varchar(45), in bearing_hh1 varchar(45), in bearing_vv1 varchar(45), in bearing_aa2 varchar(45), in bearing_hh2 varchar(45), in bearing_vv2 varchar(45), in bearing_chh11 varchar(45), in bearing_chh12 varchar(45), in crestfactor_aa1 varchar(45), in crestfactor_hh1 varchar(45), in crestfactor_vv1 varchar(45), in crestfactor_aa2 varchar(45), in crestfactor_hh2 varchar(45), in crestfactor_vv2 varchar(45), in crestfactor_chh11 varchar(45), in crestfactor_chh12 varchar(45), in temperature_11 varchar(45), in temperature_12 varchar(45), in sAName varchar(45) ) BEGIN Insert into alarms_data(  accel_a1,accel_h1,accel_v1,accel_a2,accel_h2,accel_v2,accel_ch11,accel_ch12,  vel_a1,vel_h1,vel_v1,vel_a2,vel_h2,vel_v2, vel_ch11,vel_ch12,  displ_a1,displ_h1,displ_v1,displ_a2,displ_h2,displ_v2, displ_ch11,displ_ch12,    bearing_a1,bearing_h1,bearing_v1,bearing_a2,bearing_h2,bearing_v2, bearing_ch11,bearing_ch12, crest_factor_a1,crest_factor_h1,crest_factor_v1,crest_factor_a2,crest_factor_h2,crest_factor_v2,crest_factor_ch11,crest_factor_ch12, temperature_1,temperature_2,Alarm_Name) values(accel_aa1 , accel_hh1 , accel_vv1 , accel_aa2 , accel_hh2 , accel_vv2 , accel_chh11 , accel_chh12 ,vel_aa1, vel_hh1 , vel_vv1 , vel_aa2 , vel_hh2 ,vel_vv2 , vel_chh11 , vel_chh12,displ_aa1 , displ_hh1 , displ_vv1 , displ_aa2 , displ_hh2 , displ_vv2 , displ_chh11 ,displ_chh12 ,bearing_aa1 , bearing_hh1 , bearing_vv1 , bearing_aa2 , bearing_hh2 , bearing_vv2 , bearing_chh11 , bearing_chh12,crestfactor_aa1 , crestfactor_hh1, crestfactor_vv1, crestfactor_aa2 , crestfactor_hh2 , crestfactor_vv2, crestfactor_chh11 , crestfactor_chh12,temperature_11 , temperature_12 ,sAName );END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_DemodulateBand`(in baName varchar(45) , in baFreq varchar(45) , in xAxis varchar(45) , in yAxis varchar(45) , in cCounter int , in baDate datetime , in v_group_id int, in v_axis_type int) BEGIN DECLARE  demoid int ; Insert into demodulate_data (Demodulate_Name , Freq , X , Y ,Counter ,  DateTime,group_id,axis_type) values(baName , baFreq , xAxis, yAxis , cCounter ,  baDate,v_group_id,v_axis_type); select  Max(ID) into demoid from demodulate_data ;END");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_Di_Point`(in  V_Type_ID varchar(45),in  V_FullScale  varchar(45),in  V_Sensitivity  varchar(45),in  V_Couple  varchar(45),in  V_DetectionType  varchar(45),in  V_WindowType  varchar(45),in  V_FilterType  varchar(45),in  V_FilterValue  varchar(45),in  V_Direction  varchar(45),in  V_CollectionType  varchar(45),in  V_MeasureType  varchar(45),in  V_Resolution  varchar(45),in  V_Frequency  varchar(45),in  V_Orders  varchar(45),in  V_SpecAvg varchar(45),in  V_TimeAvg varchar(45),in  V_Overlap  varchar(45),in  V_TriggerType  varchar(45),in  V_Slope  varchar(45),in  V_Levels  varchar(45),in  V_TriggerRange  varchar(45),in  V_ChannelType  varchar(45),in V_Type_Unit varchar(45)) BEGIN insert into di_point(Type_ID,FullScale,Sensitivity,Couple,DetectionType,WindowType,FilterType,FilterValue,Direction,CollectionType,MeasureType,Resolution,Frequency,Orders,SpecAvg, TimeAvg,Overlap,TriggerType,Slope,Levels,TriggerRange,ChannelType,Type_Unit) values (V_Type_ID,V_FullScale,V_Sensitivity,V_Couple,V_DetectionType,V_WindowType,V_FilterType,V_FilterValue,V_Direction,V_CollectionType,V_MeasureType,V_Resolution,V_Frequency,V_Orders,V_SpecAvg, V_TimeAvg,V_Overlap,V_TriggerType,V_Slope,V_Levels,V_TriggerRange,V_ChannelType,V_Type_Unit);END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_FaultFrequency`(in ColFName varchar(45), in ColFFValue varchar(45) , in cDate datetime , in pointid int) BEGIN DECLARE  ffid int;Insert into faultfreq_data (pf_name , pf_freq , Date) values(ColFName , ColFFValue , cDate);select  Max(Pf_ID) into ffid from faultfreq_data ;insert  point_faultfreq  ( Point_ID,FaultFreq_ID ) values ( pointid , ffid ); END");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_manufacture`(in sname varchar(45), in saddress varchar(50)) BEGIN Insert into  manufacture (ManufactureName,ManufactureAddress) values(sname,saddress) ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_Measure`( in  v_acc_filter varchar(45) , in   v_vel_filter  varchar(45) , in  v_displ_filter  varchar(45) ,in   v_overall_bearing_filter  varchar(45)  , in   v_crest_factor_filter  varchar(45) ,in   v_bearingaccHP_filter  varchar(45) , in   v_time_band  varchar(45) ,in   v_time_resoltion  varchar(45) , in   v_time_overlap  varchar(45) ,in  v_Date   varchar(45) ,in v_sensordir varchar(45),in v_sensor_id  varchar(45) ,in v_temp_id varchar(45),in  v_power_band  varchar(45) ,in v_power_resolution  varchar(45)   , in v_power_band1  varchar(45) , in v_power_resolution1  varchar(45) ,in v_power2_band  varchar(45)  , in v_power2_resolution  varchar(45),in v_power2_band1  varchar(45),in v_power2_resolution1  varchar(45), in v_power3_band  varchar(45),in  v_power3_resolution  varchar(45), in  v_power3_band1  varchar(45), in v_power3_resolution1  varchar(45),in  v_power_window  varchar(45) ,in v_power_overlap  varchar(45), in v_power_average_times  varchar(45), in v_power_zoom  varchar(45), in v_power_zoom_startfeq  varchar(45),in v_cepstrum_band  varchar(45), in v_cepstrum_resolution  varchar(45),in v_cepstrum_window  varchar(45),in v_cepstrum_average_times  varchar(45), in v_cepstrum_overlap  varchar(45),in v_cepstrum_zoom  varchar(45), in v_cepstrum_zoom_startfeq  varchar(45), in v_demodulate_band  varchar(45), in v_demodulate_resolution  varchar(45),in v_demodulate_window  varchar(45),in v_demodulate_average_times  varchar(45),in v_demodulate_filter  varchar(45), in v_ordertrace_average_times  varchar(45), in v_ordertrace_resolution  varchar(45), in v_ordertrace_order  varchar(45), in v_ordertrace_trigger_slope  varchar(45) , in v_power_multiple varchar(45),in   v_Point_ID  varchar(45),in v_octaveSeting varchar(45),in v_octavebar varchar(45)) BEGIN Insert Into measure(acc_filter, vel_filter, displ_filter, overall_bearing_filter, crest_factor_filter, bearing_acc_hp_filter, time_band, time_resoltion, time_overlap,Date,Sensordir, sensor_id , TemperatureID, power_band  ,power_resolution   ,power_band1 ,power_resolution1  ,power2_band   ,power2_resolution, power2_band1,power2_resolution1,power3_band,power3_resolution,power3_band1,power3_resolution1, power_window,power_overlap,power_average_times,power_zoom,power_zoom_startfeq,cepstrum_band, cepstrum_resolution,cepstrum_window,cepstrum_average_times,cepstrum_overlap,cepstrum_zoom,cepstrum_zoom_startfeq,demodulate_band,demodulate_resolution,demodulate_window,demodulate_average_times ,demodulate_filter,ordertrace_average_times,ordertrace_resolution,ordertrace_order,ordertrace_trigger_slope,power_multiple,Type_ID,OctaveSetting,OctaveBar) values(  v_acc_filter, v_vel_filter, v_displ_filter, v_overall_bearing_filter ,v_crest_factor_filter,v_bearingaccHP_filter,   v_time_band, v_time_resoltion, v_time_overlap,v_Date,v_sensordir,v_sensor_id ,v_temp_id,v_power_band  ,v_power_resolution   ,v_power_band1 ,v_power_resolution1  ,v_power2_band   ,v_power2_resolution ,v_power2_band1,v_power2_resolution1,v_power3_band,v_power3_resolution,v_power3_band1,v_power3_resolution1 ,v_power_window,v_power_overlap,v_power_average_times,v_power_zoom,v_power_zoom_startfeq,v_cepstrum_band,v_cepstrum_resolution,v_cepstrum_window,v_cepstrum_average_times,v_cepstrum_overlap,v_cepstrum_zoom,v_cepstrum_zoom_startfeq,v_demodulate_band,v_demodulate_resolution,v_demodulate_window,v_demodulate_average_times,v_demodulate_filter,v_ordertrace_average_times,v_ordertrace_resolution,v_ordertrace_order,v_ordertrace_trigger_slope ,v_power_multiple,v_Point_ID,v_octaveSeting,v_octavebar ) ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    //DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_Measure_Band`( in  v_power_band  varchar(45) ,in v_power_resolution  varchar(45)   , in v_power_band1  varchar(45) , in v_power_resolution1  varchar(45) ,in v_power2_band  varchar(45)  , in v_power2_resolution  varchar(45),in v_power2_band1  varchar(45),in v_power2_resolution1  varchar(45), in v_power3_band  varchar(45),in  v_power3_resolution  varchar(45), in  v_power3_band1  varchar(45), in v_power3_resolution1  varchar(45), in  v_power_window  varchar(45) ,in v_power_overlap  varchar(45), in v_power_average_times  varchar(45), in v_power_zoom  varchar(45), in v_power_zoom_startfeq  varchar(45),in v_cepstrum_band  varchar(45), in v_cepstrum_resolution  varchar(45),in v_cepstrum_window  varchar(45),in v_cepstrum_average_times  varchar(45), in v_cepstrum_overlap  varchar(45),in v_cepstrum_zoom  varchar(45), in v_cepstrum_zoom_startfeq  varchar(45), in v_demodulate_band  varchar(45), in v_demodulate_resolution  varchar(45),in v_demodulate_window  varchar(45),in v_demodulate_average_times  varchar(45), in v_demodulate_filter  varchar(45), in v_ordertrace_average_times  varchar(45), in v_ordertrace_resolution  varchar(45), in v_ordertrace_order  varchar(45), in v_ordertrace_trigger_slope  varchar(45) , in v_power_multiple varchar(45), in  v_Point_ID   varchar(45) ) BEGIN insert into   measure( power_band  ,power_resolution   ,power_band1 ,power_resolution1  ,power2_band   ,power2_resolution, power2_band1,power2_resolution1,power3_band,power3_resolution,power3_band1,power3_resolution1, power_window,power_overlap,power_average_times,power_zoom,power_zoom_startfeq,cepstrum_band, cepstrum_resolution,cepstrum_window,cepstrum_average_times,cepstrum_overlap,cepstrum_zoom,cepstrum_zoom_startfeq,demodulate_band,demodulate_resolution,demodulate_window,demodulate_average_times ,demodulate_filter,ordertrace_average_times,ordertrace_resolution,ordertrace_order,ordertrace_trigger_slope,power_multiple,Type_ID) values( v_power_band  ,v_power_resolution   ,v_power_band1 ,v_power_resolution1  ,v_power2_band   ,v_power2_resolution ,v_power2_band1,v_power2_resolution1,v_power3_band,v_power3_resolution,v_power3_band1,v_power3_resolution1 ,v_power_window,v_power_overlap,v_power_average_times,v_power_zoom,v_power_zoom_startfeq,v_cepstrum_band,v_cepstrum_resolution,v_cepstrum_window,v_cepstrum_average_times,v_cepstrum_overlap,v_cepstrum_zoom,v_cepstrum_zoom_startfeq,v_demodulate_band,v_demodulate_resolution,v_demodulate_window,v_demodulate_average_times,v_demodulate_filter,v_ordertrace_average_times,v_ordertrace_resolution,v_ordertrace_order,v_ordertrace_trigger_slope ,v_power_multiple,v_Point_ID);END ");
                    //PublicClass.statusbar(progbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `insert_measure_type`(in  vOAcc char(1), in  vOVel char(1), in  vODisp char(1), in vOBear char (1),in  vOTWF char(1), in  vOPS char (1),in  vODS char (1),  in vTemp char(1), in vProcess char(1),in vcrestfactor char(1) , in  vOrdertrace char(1), in  vCepstrum char(1) , in    vPoint_ID int,in calmeasure int ) BEGIN insert into  measure_type  (  OAcc, OVel, ODisp, OBear, OTWF, OPS, ODS, Temp, Process, crestfactor, Ordertrace, Cepstrum , Type_ID ,CalcMeasure  ) values (  vOAcc,  vOVel ,  vODisp, vOBear, vOTWF ,vOPS,vODS ,vTemp ,vProcess ,vcrestfactor, vOrdertrace , vCepstrum ,vPoint_ID,calmeasure  );END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_Notes`(in nDesc varchar(2000) , in nType varchar(10) , in ndate DateTime) BEGIN insert into notes(Notes_Desc , Note_type  , Date) values( nDesc , nType , ndate ) ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_PAlarm`(in txtPName varchar(45), in txtPAccValue varchar(45), in txtPVelValue varchar(45), in txtPDispValue varchar(45), in txtPBearValue varchar(45)) BEGIN INSERT INTO percentage_alarm(PerAlarm_Name , Per_Accel , Per_Vel ,Per_Displ , Per_Bearing) VALUES(txtPName , txtPAccValue , txtPVelValue , txtPDispValue , txtPBearValue);END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_Point_Alarm`(in point_id int , in AlarmId int) BEGIN Insert into point_alarm(PointID,Alarm_ID) values(point_id,AlarmId);END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_Point_Type`(in v_type_id varchar(45),in v_Point_name varchar(45) ,in v_Instrument_Name varchar(45)) BEGIN insert into type_point (type_id,Point_name ,instrumentname) values (v_type_id,v_Point_name,v_Instrument_Name);END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_PowerBand`(in baName varchar(45) , in baFreq varchar(45) , in xAxis varchar(45) , in yAxis varchar(45) , in cCounter int , in baDate datetime  , in v_Group_id int , in v_Axis_Type int) BEGIN DECLARE  baId int ;Insert into band_data (BandAlarm_Name , Freq , X , Y ,Counter ,  DateTime,Group_id,axis_type) values(baName , baFreq , xAxis, yAxis , cCounter ,  baDate,v_Group_id,v_Axis_Type); select  Max(ID) into baId from band_data ; END");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_SDAlarm`(in txtSDName varchar(45), in txtSDAccValue varchar(45), in txtSDVelValue varchar(45), in txtSDDispValue varchar(45), in txtSDBearValue varchar(45)) BEGIN INSERT INTO stddeviationalarm ( STDAlarm_Name, Deviation_accel, Deviation_Vel, Deviation_Displ, Deviation_Bearing)  VALUES(txtSDName , txtSDAccValue , txtSDVelValue ,txtSDDispValue , txtSDBearValue);END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `insert_sensor_data`(in mid varchar(10), in cname varchar(50),in ctype varchar(50),in ch1 varchar(10) ,in a varchar(10),in h varchar(10),in v varchar(10),in uni varchar(10),in dir varchar(10) ,in icpval varchar(10) ,in  Offsett varchar(10),in  cRange varchar(10)) BEGIN insert sensor_data (Manufacture_ID,Sensor_name,sensor_type, Senitivity_Ch1, Sensitivity_a, Sensitivity_h, Sensitivity_v, Sensor_unit, Sensor_dir, Sensor_icp, Sensor_offset, Input_Range) values (mid , cname,ctype,ch1 , a , h ,  v,uni,dir  ,icpval,Offsett, cRange );END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `insert_SensorType`(in s_name varchar(45) ,in unit varchar(45)) BEGIN insert sensor_type (SensorType,Unit) values (s_name,unit) ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `insert_Units`(in   v_accel_unit int ,in  v_accel_detection  int ,in  v_vel_unit  int ,in  v_vel_detection  int ,in  v_displ_unit  int ,in v_displ_detection   int ,in v_temperature_unit  int ,in v_process_unit  varchar(45) ,in v_pressure_unit  int ,in v_pressure_detection  int ,in v_current_unit  int ,in v_current_detection  int ,in v_time_unit_type  int ,in v_power_unit_type  int ,in v_demodulate_unit_type  int ,in v_ordertrace_unit_type  int ,in v_cepstrum_unit_type  int ,in v_Date  varchar(45) , in  Type_ID   int )BEGIN insert into units(accel_unit,accel_detection,vel_unit,vel_detection,displ_unit,displ_detection,temperature_unit,process_unit,pressure_unit,pressure_detection,current_unit,current_detection,time_unit_type,power_unit_type,demodulate_unit_type,ordertrace_unit_type,cepstrum_unit_type,Date,Type_ID) values(v_accel_unit,v_accel_detection,v_vel_unit,v_vel_detection,v_displ_unit,v_displ_detection,v_temperature_unit,v_process_unit,v_pressure_unit,v_pressure_detection,v_current_unit,v_current_detection,v_time_unit_type,v_power_unit_type,v_demodulate_unit_type,v_ordertrace_unit_type,v_cepstrum_unit_type,v_Date,Type_ID);END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `InstrumentName`(in v_Instrument varchar(50)) BEGIN SELECT distinct uid,instrumentname FROM instruments where instrumentname=v_Instrument;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `PAID_By_CurrentPointID`(in ssPointID int) BEGIN select Percentage_AlarmID from percentage_alarm where Point_ID = ssPointID ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `PAlarmId_By_CurrentPointId`(in pId int) BEGIN select PerAlarm_ID from Point where Point_ID = pId;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `PointName_By_AnyPointId`( in currentPointId int) BEGIN select PointName from point where Point_ID = currentPointId;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `PointName_By_CurrentPointId`(in ssPointId int) BEGIN select PointName from point where Point_ID=ssPointId;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `retreive_point_type`(in SPointID varchar(45)) BEGIN SELECT distinct a.ID,a.type_id ,a.point_name,a.Instrumentname  ,t.point_id  FROM type_point a  inner join point_type t on a.type_id=t.type_id  WHERE  t.Point_ID = SPointID ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `retreive_PType`(in aa int) BEGIN Select ID,type_id,Point_name,Instrumentname from type_point where ID=aa;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `retrieveSensor_data`(in aa int) BEGIN select distinct sensor_id, Manufacture_ID,Sensor_name,sensor_type, Senitivity_Ch1, Sensitivity_a, Sensitivity_h,Sensitivity_v, Sensor_unit, Sensor_dir, Sensor_icp, Sensor_offset,Input_Range from sensor_data where   sensor_id = aa; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Retrive_All_Aram_TypeId`(in   V_ID   varchar(10)) BEGIN select distinct  a.Percentage_AlarmID,pa.PerAlarm_Name,a.STDDeviationAlarm_ID,std.STDAlarm_Name,a.Alarm_ID ,da.Alarm_Name from type_point a left join percentage_alarm pa on a.Percentage_AlarmID=pa.Percentage_AlarmID left join  stddeviationalarm std on a.STDDeviationAlarm_ID=std.STDDeviationAlarm_ID left join  alarms_data da on a.Alarm_ID=da.Alarm_ID where id =V_ID ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Retrive_Di_Point`(IN V_Type_ID VARCHAR(40)) BEGIN SELECT FullScale,Sensitivity,Couple,DetectionType,WindowType,FilterType,FilterValue,Direction,CollectionType,MeasureType,Resolution,Frequency,Orders,SpecAvg, TimeAvg,Overlap,TriggerType,Slope,Levels,TriggerRange, ChannelType,Type_Unit from di_point where Type_ID=V_Type_ID;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Retrive_measure`(in v_point_id int) BEGIN SELECT  mea.acc_filter, mea.vel_filter, mea.displ_filter,mea. overall_bearing_filter , mea.crest_factor_filter, mea.bearing_acc_hp_filter ,mea. time_band, mea.time_resoltion,mea. time_overlap,Date ,mea.Sensordir,mea.Sensor_ID,mea.TemperatureID,sen.sensor_dir FROM   measure mea inner join sensor_data sen on sen.Sensor_ID=mea.Sensor_ID where   mea.Type_ID=v_point_id ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Retrive_Measure_Band`(  in  v_Point_ID   varchar(45) ) BEGIN select distinct  power_band  ,power_resolution   ,power_band1 ,power_resolution1  ,power2_band   ,power2_resolution,  power2_band1,power2_resolution1,power3_band,power3_resolution,power3_band1,power3_resolution1,  power_window,power_overlap,power_average_times,power_zoom,power_zoom_startfeq,cepstrum_band, cepstrum_resolution,cepstrum_window,cepstrum_average_times,cepstrum_overlap,cepstrum_zoom, cepstrum_zoom_startfeq,demodulate_band,demodulate_resolution,demodulate_window,demodulate_average_times , demodulate_filter,ordertrace_average_times,ordertrace_resolution,ordertrace_order,ordertrace_trigger_slope ,power_multiple,OctaveSetting,OctaveBar  from   measure where Type_ID = v_Point_ID  ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Retrive_measure_type`(in v_point_id int) BEGIN select ID, OAcc, OVel, ODisp, OBear, OTWF, OPS, ODS, Temp, Process, crestfactor, Ordertrace, Cepstrum ,Calcmeasure from measure_type where Type_ID=v_point_id;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Retrive_Units`(in v_point_id varchar(10)) BEGIN select accel_unit,accel_detection,vel_unit,vel_detection,displ_unit,displ_detection,temperature_unit,process_unit,pressure_unit,pressure_detection,current_unit,current_detection,time_unit_type,power_unit_type,demodulate_unit_type,ordertrace_unit_type,cepstrum_unit_type  from units where  Type_ID =v_point_id; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `SDAlarmId_By_CurrentPointId`(in pid int) BEGIN Select StdDeviation_ID from point where Point_ID = pid;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `STDAlarmId_By_STDAlarmName`(in stdName varchar(45)) BEGIN select  STDDeviationAlarm_ID from stddeviationalarm where STDAlarm_Name=stdName ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `STDAlarmID_By_STDPointId`(in stdPointId int) BEGIN select StdDeviationAlarm_ID from stddeviationalarm where Point_ID =stdPointId;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Update_Alarm`( in accel_aa1 varchar(50) ,in accel_hh1 varchar(50),in accel_vv1 varchar(50), in accel_aa2 varchar(50),in accel_hh2 varchar(50),in accel_vv2 varchar(50),in accel_chh11 varchar(50),in accel_chh12 varchar(50),in vel_chh11 varchar(50),in vel_chh12 varchar(50),in displ_chh11 varchar(50),in displ_chh12 varchar(50),in bearing_chh11 varchar(50),in bearing_chh12 varchar(50),in crestfactor_chh11 varchar(50),in crestfactor_chh12 varchar(50),in vel_aa1 varchar(50),in vel_hh1 varchar(50),in vel_vv1 varchar(50),in vel_aa2 varchar(50),in vel_hh2 varchar(50),in vel_vv2 varchar(50),in displ_aa1 varchar(50),in displ_hh1 varchar(50),in displ_vv1 varchar(50),in displ_aa2 varchar(50),in displ_hh2 varchar(50),in displ_vv2 varchar(50),in bearing_aa1 varchar(50),in bearing_hh1 varchar(50),in bearing_vv1 varchar(50),in bearing_aa2 varchar(50),in bearing_hh2 varchar(50),in bearing_vv2 varchar(50),in temperature_11 varchar(50),in temperature_12 varchar(50),in crestfactor_aa1 varchar(50),in crestfactor_hh1 varchar(50),in crestfactor_vv1 varchar(50),in crestfactor_aa2 varchar(50),in crestfactor_hh2 varchar(50),in crestfactor_vv2 varchar(50),in saname varchar(50)) BEGIN Update alarms_data set accel_a1= accel_aa1,accel_h1=accel_hh1, accel_v1=accel_vv1, accel_a2=accel_aa2, accel_h2=accel_hh2,accel_v2=accel_vv2, accel_ch11=accel_chh11, accel_ch12=accel_chh12,vel_ch11=vel_chh11, vel_ch12=vel_chh12, displ_ch11=displ_chh11,displ_ch12=displ_chh12, bearing_ch11=bearing_chh11,bearing_ch12=bearing_chh12,crest_factor_ch11=crestfactor_chh11,crest_factor_ch12=crestfactor_chh12,vel_a1=vel_aa1,vel_h1=vel_hh1, vel_v1=vel_vv1, vel_a2=vel_aa2,  vel_h2=vel_hh2, vel_v2=vel_vv2, displ_a1=displ_aa1, displ_h1=displ_hh1, displ_v1=displ_vv1, displ_a2=displ_aa2,displ_h2=displ_hh2,displ_v2=displ_vv2, bearing_a1= bearing_aa1 ,bearing_h1= bearing_hh1 ,bearing_v1= bearing_vv1 , bearing_a2= bearing_aa2 , bearing_h2= bearing_hh2 ,bearing_v2= bearing_vv2 ,temperature_1= temperature_11 ,temperature_2= temperature_12 ,crest_factor_a1= crestfactor_aa1 ,crest_factor_h1= crestfactor_hh1 , crest_factor_v1= crestfactor_vv1 ,crest_factor_a2= crestfactor_aa2 ,crest_factor_h2= crestfactor_hh2 , crest_factor_v2= crestfactor_vv2 where Alarm_Name =saname;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Update_All_Aram_TypeId`(in  V_Percentage_AlarmID varchar(10),in  V_STDDeviationAlarm_ID  varchar(10),in  V_Alarm_ID  varchar(10),in   V_ID   varchar(10)) BEGIN update type_point set Percentage_AlarmID =V_Percentage_AlarmID,STDDeviationAlarm_ID=V_STDDeviationAlarm_ID,Alarm_ID =V_Alarm_ID where id=V_ID;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Update_BandData`(in bName varchar(45) ,  in bFreq double , in xX double , in yY double , dDate datetime , in iId int ,in v_group_id int ) BEGIN Update band_data set BandAlarm_Name = bName , Freq = bFreq , X = xX , Y = yY ,  DateTime = dDate   where Counter = iId  and group_id=v_group_id  ; END");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Update_DemoData`(in dName varchar(45) ,  in dFreq double , in dX double , in dY double , ddDate datetime , in dId int, in v_group_id int) BEGIN Update demodulate_data set Demodulate_Name = dName , Freq = dFreq , X = dX , Y = dY ,  DateTime = ddDate  where Counter = dId  and group_id=v_group_id ; END");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `update_di_point`(in  V_Type_ID varchar(45),in  V_FullScale  varchar(45),in  V_Sensitivity  varchar(45),in  V_Couple  varchar(45),in  V_DetectionType  varchar(45),in  V_WindowType  varchar(45),in  V_FilterType  varchar(45),in  V_FilterValue  varchar(45),in  V_Direction  varchar(45),in  V_CollectionType  varchar(45),in  V_MeasureType  varchar(45),in  V_Resolution  varchar(45),in  V_Frequency  varchar(45),in  V_Orders  varchar(45),in  V_SpecAvg varchar(45),in  V_TimeAvg varchar(45),in  V_Overlap  varchar(45),in  V_TriggerType  varchar(45),in  V_Slope  varchar(45),in  V_Levels  varchar(45),in  V_TriggerRange  varchar(45),in  V_ChannelType  varchar(45),in V_Type_Unit varchar(45)) BEGIN update di_point set  FullScale = V_FullScale,Sensitivity = V_Sensitivity,Couple= V_Couple,DetectionType= V_DetectionType,WindowType= V_WindowType,FilterType= V_FilterType,FilterValue= V_FilterValue,Direction= V_Direction,CollectionType= V_CollectionType,MeasureType= V_MeasureType,Resolution= V_Resolution,Frequency= V_Frequency,Orders= V_Orders,SpecAvg= V_SpecAvg ,TimeAvg= V_TimeAvg,Overlap= V_Overlap,TriggerType= V_TriggerType,Slope= V_Slope,Levels= V_Levels,TriggerRange= V_TriggerRange,ChannelType= V_ChannelType,Type_Unit= V_Type_Unit WHERE Type_ID =V_Type_ID;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Update_FaultFrequency`(in fName varchar(45) , in fFreq double ,  in fDate DateTime , in fID int ) BEGIN Update faultfreq_data set pf_name = fName , pf_freq = fFreq , Date =fDate where Pf_ID = fID ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Update_manufacture`( in idd int,  in sname varchar(45), in saddress varchar(50)) BEGIN update  manufacture  set  ManufactureName=  sname,  ManufactureAddress=saddress where id =idd ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `update_Measure`( in  v_acc_filter varchar(45) ,in   v_vel_filter  varchar(45) , in  v_displ_filter  varchar(45) ,in   v_overall_bearing_filter  varchar(45) ,in   v_crest_factor_filter  varchar(45),in   v_bearingacchp_filter  varchar(45) ,in   v_time_band  varchar(45) ,in   v_time_resoltion  varchar(45) ,in   v_time_overlap  varchar(45) ,in  v_Date   varchar(45)  ,in v_sensordir int,in  v_sensor_ID    varchar(45),in  v_temp_ID    varchar(45),in  v_power_band  varchar(45) ,in v_power_resolution  varchar(45),in v_power_band1  varchar(45) , in v_power_resolution1  varchar(45) ,in v_power2_band  varchar(45)  ,in v_power2_resolution  varchar(45),in v_power2_band1  varchar(45),in v_power2_resolution1  varchar(45), in v_power3_band  varchar(45),in  v_power3_resolution  varchar(45), in  v_power3_band1  varchar(45), in v_power3_resolution1  varchar(45), in  v_power_window  varchar(45) ,in v_power_overlap  varchar(45), in v_power_average_times  varchar(45),in v_power_zoom  varchar(45),in v_power_zoom_startfeq  varchar(45),in v_cepstrum_band  varchar(45), in v_cepstrum_resolution  varchar(45),in v_cepstrum_window  varchar(45),in v_cepstrum_average_times  varchar(45),in v_cepstrum_overlap  varchar(45),in v_cepstrum_zoom  varchar(45), in v_cepstrum_zoom_startfeq  varchar(45),in v_demodulate_band  varchar(45), in v_demodulate_resolution  varchar(45),in v_demodulate_window  varchar(45),in v_demodulate_average_times  varchar(45),in v_demodulate_filter  varchar(45), in v_ordertrace_average_times  varchar(45), in v_ordertrace_resolution  varchar(45),in v_ordertrace_order  varchar(45), in v_ordertrace_trigger_slope  varchar(45)  ,in  v_power_multiple  varchar(45),in   v_Point_ID  varchar(45),in v_octaveSeting varchar(45),in v_octavebar varchar(45) ) BEGIN update  measure  set  acc_filter = v_acc_filter, vel_filter=v_vel_filter, displ_filter =v_displ_filter, overall_bearing_filter=v_overall_bearing_filter ,crest_factor_filter=v_crest_factor_filter, bearing_acc_hp_filter=v_bearingacchp_filter , time_band=v_time_band,time_resoltion=v_time_resoltion, time_overlap=v_time_overlap, Date =v_Date ,Sensordir=v_sensordir,sensor_ID=v_sensor_ID,TemperatureID=v_temp_ID ,power_band = v_power_band,power_resolution=v_power_resolution   ,power_band1= v_power_band1 ,power_resolution1=v_power_resolution1  ,power2_band=v_power2_band   ,power2_resolution=v_power2_resolution,power2_band1=v_power2_band1 ,power2_resolution1 =v_power2_resolution1 ,power3_band =v_power3_band ,power3_resolution=v_power3_resolution,power3_band1=v_power3_band1,power3_resolution1=v_power3_resolution1,power_window =v_power_window ,power_overlap =v_power_overlap,power_average_times =v_power_average_times,power_zoom=v_power_zoom,power_zoom_startfeq =v_power_zoom_startfeq,cepstrum_band=v_cepstrum_band, cepstrum_resolution= v_cepstrum_resolution,cepstrum_window =v_cepstrum_window,cepstrum_average_times =v_cepstrum_average_times,cepstrum_overlap =v_cepstrum_overlap,cepstrum_zoom =v_cepstrum_zoom, cepstrum_zoom_startfeq=v_cepstrum_zoom_startfeq,demodulate_band=v_demodulate_band,demodulate_resolution=v_demodulate_resolution,demodulate_window=v_demodulate_window,demodulate_average_times=v_demodulate_average_times ,demodulate_filter=v_demodulate_filter,ordertrace_average_times=v_ordertrace_average_times,ordertrace_resolution=v_ordertrace_resolution,ordertrace_order=v_ordertrace_order,ordertrace_trigger_slope=v_ordertrace_trigger_slope,power_multiple=v_power_multiple,OctaveSetting=v_octaveSeting ,OctaveBar=v_octavebar where Type_ID = v_Point_ID ; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `update_Measure_Band`( in  v_power_band  varchar(45) ,in v_power_resolution  varchar(45)   , in v_power_band1  varchar(45) , in v_power_resolution1  varchar(45) ,in v_power2_band  varchar(45)  , in v_power2_resolution  varchar(45),in v_power2_band1  varchar(45),in v_power2_resolution1  varchar(45), in v_power3_band  varchar(45),in  v_power3_resolution  varchar(45), in  v_power3_band1  varchar(45), in v_power3_resolution1  varchar(45), in  v_power_window  varchar(45) ,in v_power_overlap  varchar(45), in v_power_average_times  varchar(45), in v_power_zoom  varchar(45), in v_power_zoom_startfeq  varchar(45),in v_cepstrum_band  varchar(45), in v_cepstrum_resolution  varchar(45),in v_cepstrum_window  varchar(45),in v_cepstrum_average_times  varchar(45), in v_cepstrum_overlap  varchar(45),in v_cepstrum_zoom  varchar(45), in v_cepstrum_zoom_startfeq  varchar(45), in v_demodulate_band  varchar(45), in v_demodulate_resolution  varchar(45),in v_demodulate_window  varchar(45),in v_demodulate_average_times  varchar(45), in v_demodulate_filter  varchar(45), in v_ordertrace_average_times  varchar(45), in v_ordertrace_resolution  varchar(45), in v_ordertrace_order  varchar(45), in v_ordertrace_trigger_slope  varchar(45)  , in  v_power_multiple  varchar(45), in  v_Point_ID   varchar(45) ) BEGIN update    measure  set  power_band =  v_power_band,power_resolution=v_power_resolution   ,power_band1= v_power_band1 ,power_resolution1=v_power_resolution1  ,power2_band=v_power2_band   ,power2_resolution=v_power2_resolution,power2_band1=v_power2_band1 ,power2_resolution1 =v_power2_resolution1 ,power3_band =v_power3_band ,power3_resolution=v_power3_resolution,power3_band1=v_power3_band1,power3_resolution1=v_power3_resolution1, power_window =v_power_window ,power_overlap =v_power_overlap,power_average_times =v_power_average_times,power_zoom=v_power_zoom,power_zoom_startfeq =v_power_zoom_startfeq,cepstrum_band=v_cepstrum_band, cepstrum_resolution= v_cepstrum_resolution,cepstrum_window =v_cepstrum_window,cepstrum_average_times =v_cepstrum_average_times,cepstrum_overlap =v_cepstrum_overlap,cepstrum_zoom =v_cepstrum_zoom, cepstrum_zoom_startfeq=v_cepstrum_zoom_startfeq,demodulate_band=v_demodulate_band,demodulate_resolution=v_demodulate_resolution,demodulate_window=v_demodulate_window,demodulate_average_times=v_demodulate_average_times ,demodulate_filter=v_demodulate_filter,ordertrace_average_times=v_ordertrace_average_times,ordertrace_resolution=v_ordertrace_resolution,ordertrace_order=v_ordertrace_order,ordertrace_trigger_slope=v_ordertrace_trigger_slope,power_multiple=v_power_multiple where Type_ID=v_Point_ID;   END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `update_measure_type`(in  vOAcc char(1), in  vOVel char(1), in  vODisp char(1), in vOBear char (1),in  vOTWF char(1), in  vOPS char (1),in  vODS char (1),  in vTemp char(1), in vProcess char(1),in vcrestfactor char(1) , in  vOrdertrace char(1), in  vCepstrum char(1) , in    vPoint_ID int, in calmeasure int) BEGIN update measure_type set  OAcc =vOAcc, OVel=vOVel, ODisp=vODisp, OBear=vOBear, OTWF=vOTWF, OPS=vOPS,ODS=vODS, Temp=vTemp, Process=vProcess, crestfactor=vcrestfactor , Ordertrace=vOrdertrace, Cepstrum=vCepstrum,Calcmeasure=calmeasure where Type_ID=vPoint_ID;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Update_Notes`(in nDesc varchar(200) , in nDate DateTime , in nType int , in nId int) BEGIN Update Notes set Notes_Desc = nDesc   , Date  = nDate  , Note_type  = nType  where Notes_ID = nId ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Update_Point_Type`(in v_Point_id varchar(45),in v_Point_name varchar(45) ,in v_Instrument_Name varchar(45),in Idd varchar(45)) BEGIN update  type_point set   type_id=v_Point_id,Point_name=v_Point_name  ,instrumentname=v_Instrument_Name where ID =Idd;END ");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `update_SensorType`(in Idd int ,in s_name varchar(45),in s_unit varchar(45)) BEGIN update sensor_type set Unit = s_unit ,SensorType = s_name   where id = Idd  ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `update_Units`( in   v_accel_unit int ,in  v_accel_detection  int ,in  v_vel_unit  int ,in  v_vel_detection  int ,in  v_displ_unit  int ,in v_displ_detection   int ,in v_temperature_unit  int ,in v_process_unit  varchar(45) ,in v_pressure_unit  int ,in v_pressure_detection  int ,in v_current_unit  int ,in v_current_detection  int ,in v_time_unit_type  int ,in v_power_unit_type varchar(45) ,in v_demodulate_unit_type  int ,in v_ordertrace_unit_type  int ,in v_cepstrum_unit_type  int ,in v_Date  varchar(45) ,in  v_Point_ID   int ) BEGIN update  units  set accel_unit =v_accel_unit,accel_detection=v_accel_detection,vel_unit=v_vel_unit,vel_detection =v_vel_detection,displ_unit =v_displ_unit,displ_detection=v_displ_detection,temperature_unit=v_temperature_unit,process_unit=v_process_unit,pressure_unit=v_pressure_unit,pressure_detection=v_pressure_detection,current_unit=v_current_unit,current_detection=v_current_detection,time_unit_type=v_time_unit_type,power_unit_type=v_power_unit_type,demodulate_unit_type=v_demodulate_unit_type,ordertrace_unit_type=v_ordertrace_unit_type,cepstrum_unit_type=v_cepstrum_unit_type,date=v_Date where  Type_ID =v_Point_ID ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `UpdatePoint_For_AllAlarmId`(in a_Id int , in sd_Id int , in per_ID int , in p_id int ) BEGIN update Point set Alarm_ID=a_Id , StdDeviation_ID=sd_Id , PerAlarm_ID=per_ID where Point_ID = p_id ;END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `UpdatePoint_For_PAlarmId`(in ssPerAlarmID int , in pSPointID int) BEGIN update Point set PerAlarm_ID = ssPerAlarmID  where Point_ID =  PublicClass.pSPointID ;END ");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE TABLE " + DBName + ". `allreport` (`Report_ID` int(11) NOT NULL auto_increment,`ReportName` varchar(500) NOT NULL, `ReportStatus` varchar(100) DEFAULT NULL,  PRIMARY KEY  (`Report_ID`))");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `UpdatePoint_For_STDAlarmId`(in stdId int , in cpid int) BEGIN update Point set StdDeviation_ID =stdId where Point_ID = cpid; END ");
                    PublicClass.statusbar(dbCreateProgbar);
                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `update_sensor_data`(in mid varchar(10), in cname varchar(50),in ctype varchar(50),in ch1 varchar(10) ,in a varchar(10),in h varchar(10),in v varchar(10),in uni varchar(10),in dir varchar(10) ,in icpval varchar(10) ,in  Offsett varchar(10),in  cRange varchar(10) ,in idd varchar(10)) BEGIN update sensor_data set  Manufacture_ID=mid,Sensor_name=cname,sensor_type=ctype, Senitivity_Ch1=ch1, Sensitivity_a=a, Sensitivity_h=h, Sensitivity_v=v, Sensor_unit=uni, Sensor_dir=dir, Sensor_icp=icpval, Sensor_offset=Offsett, Input_Range=cRange where sensor_id=idd;END ");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `update_PointTYpeDB`(in PointID varchar(45), in bandID varchar(45)) BEGIN DECLARE  Typeid int; select PointType_ID into Typeid from point where point_ID = PointID ;Update type_point set Band_ID = bandID  where ID = Typeid;END ");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.StoredProcedure, "CREATE PROCEDURE  " + DBName + " . `Insert_PointTypeDB`(in TypeName varchar(45),in TID int,in InstName varchar(45) ,in AlarmID varchar(45) ,in sdID varchar(45), in perID varchar(45) ,in CreationDate Date,  in pointid int) BEGIN DECLARE  Typeid int; Insert into type_point(Point_Name,Type_ID,Instrumentname,Alarm_ID,STDDeviationAlarm_ID,Percentage_AlarmID,Date) values(TypeName , TID ,InstName,AlarmID,sdID,perID,CreationDate); select  Max(ID) into Typeid from type_point ; Update point set PointType_ID = Typeid where Point_ID = pointid ;END ");
                    PublicClass.statusbar(dbCreateProgbar);

                    DbClass.executequery(CommandType.Text, "CREATE VIEW " + DBName + ". `v_allrecord` AS select `po`.`Point_ID` AS `Point_id`,`po`.`PointName` AS `PointName`,`ma`.`Machine_ID` AS `machine_id`,`ma`.`Name` AS `MachineName`,`ta`.`Train_ID` AS `train_id`,`ta`.`Name` AS `TrainName`,`ar`.`Area_ID` AS `area_id`,`ar`.`Name` AS `AreaName`,`fa`.`Factory_ID` AS `factory_id`,`fa`.`Name` AS `FactoryName`,`tp`.`Alarm_ID` AS `alarm_id`,`tp`.`ID` AS `Pointtype_id` from (((((" + DBName + ".`point` `Po` left join " + DBName + ".`machine_info` `ma` on((`po`.`Machine_ID` = `ma`.`Machine_ID`))) left join " + DBName + ".`train_info` `ta` on((`ma`.`TrainID` = `ta`.`Train_ID`))) left join " + DBName + ".`area_info` `ar` on((`ta`.`Area_ID` = `ar`.`Area_ID`))) left join " + DBName + ".`factory_info` `fa` on((`ar`.`FactoryID` = `fa`.`Factory_ID`))) left join " + DBName + ".`type_point` `tp` on((`po`.`PointType_ID` = `tp`.`ID`)))");

                    dbCreateProgbar.Value = 100;
                }
              
                dbCreateProgbar.Value = 0;

                PublicClass.CreateConnection("route");

                DbClass.executequery(CommandType.Text, "Insert into databasename(Database_Name,InstrumentName)values('" + DBName + "','" + PublicClass.currentInstrument + "')");
                DataTable dttest = DbClass.getdata(CommandType.Text, "select * from lastdatabase where Instrumentname = '" + PublicClass.currentInstrument + "'");
                if (dttest.Rows.Count > 0)
                {
                    DbClass.executequery(CommandType.Text, "Update lastdatabase set DBName= '" + DBName + "' where Instrumentname = '" + PublicClass.currentInstrument + "' ");
                }
                else
                {
                    DbClass.executequery(CommandType.Text, "insert into lastdatabase(UserName,DBName,Instrumentname)values('Admin','" + DBName + "','" + PublicClass.currentInstrument + "')");
                }
                DbClass.executequery(CommandType.Text, "SET GLOBAL max_allowed_packet=1073741824");
                PublicClass.CreateConnection(DBName);

                cmbInstNameSelected.Enabled = false;
                this.Close();
                status = true;
                checkstatus = status;
                PublicClass.flagAlarm = true;
            }
            catch
            {
                status = false;
                checkstatus = status;
                MessageBox.Show(this, "Some Error is Generated", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return status;
                this.Close();
            }
            return status;
        }

        private void tbNewMySqlDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PublicClass.chkTxtboxKey(e))
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