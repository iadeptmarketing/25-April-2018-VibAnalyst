using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Iadeptmain.GlobalClasses;
using Iadeptmain.Classes;
using System.Globalization;

namespace Iadeptmain.Mainforms
{
    public partial class frmDBConverter : DevExpress.XtraEditors.XtraForm
    {
        frmNewDataBaseCreation objDBCreate = new frmNewDataBaseCreation();
        public frmDBConverter()
        {
            InitializeComponent();
            Fill_InstruemntName();
            Fill_DatabaseName();
        }

        public bool tscancel = false;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            tscancel = true;
        }

        private void Fill_InstruemntName()
        {
            try
            {

                DataTable dt = DbClass.getdata(CommandType.StoredProcedure, "Call InstrumentName('" + PublicClass.currentInstrument + "')");
                foreach (DataRow dr in dt.Rows)
                {
                    cmnInstrument.Properties.Items.Add(dr["instrumentname"]);
                }
                cmnInstrument.SelectedIndex = 0;
            }
            catch { }

        }
        private void Fill_DatabaseName()
        {
            try
            {
                DataTable dt1 = DbClass.getdata(CommandType.StoredProcedure, "SELECT SCHEMA_NAME  FROM INFORMATION_SCHEMA.SCHEMATA where DEFAULT_CHARACTER_SET_NAME ='utf8' or DEFAULT_CHARACTER_SET_NAME ='latin1'");
                foreach (DataRow dr in dt1.Rows)
                {
                    cmbOldDB.Properties.Items.Add(dr["SCHEMA_NAME"]);
                }
                cmbOldDB.SelectedIndex = -1;
            }
            catch { }
        }

        //int a = 0;
        //private void statusbar()
        //{

        //    try
        //    {
        //        a = progbar.Value;
        //        if (a > 100)
        //            a = 0;
        //        progbar.Value = a + 2;
        //    }
        //    catch { }
        //}

        private void cmnInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(txtNewDB.Text).Trim() != "" && Convert.ToString(cmbOldDB.Text).Trim()!="")
                {
                    PublicClass.a = 0;
                    bool st = false;
                    PublicClass.statusbar(dbConverProgbar);

                    for (int i = 0; i < 20; i++)
                    {
                        PublicClass.statusbar(dbConverProgbar);
                    }
                    st = objDBCreate.CreateDataBase(Convert.ToString(txtNewDB.Text).Trim(), st);
                    string lastDBName = Convert.ToString(cmbOldDB.Text).Trim();
                    if (st == true)
                    {
                        ConvertFactory(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertArea(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertTrain(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertMachine(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertPoint(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertAlarms(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertSensors(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertPointType(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertMeasurement(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertMeasures(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertUnit(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertPointData(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        ConvertNotes(lastDBName);
                        PublicClass.statusbar(dbConverProgbar);
                        PublicClass.flagAlarm = true;
                        dbConverProgbar.Value = 100;
                        MessageBox.Show(this, "DataBase Convert Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PublicClass.CreateConnection(txtNewDB.Text);
                        this.Close();
                    }
                }
                else
                { MessageBox.Show(this, "DataBase Name can't be Blank", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            }
            catch { }
        }
        public string TextDec(string Target)
        {
            string FinalEncrypData = null;
            string[] TargetArr = Target.Split(new string[] { "." }, StringSplitOptions.None);
            //byte[] MainByte = Encoding.ASCII.GetBytes(
            StringBuilder Str = null;

            for (int iCtr = 0; iCtr < TargetArr.Length; iCtr++)
            {
                string sText = TargetArr[iCtr].Trim(new char[] { '-', '>' });
            }


            int a = 0;
            if (TargetArr.Length == 1)
                a = TargetArr.Length;
            else
                a = TargetArr.Length - 1;

            Int64[] MainTarget = new Int64[a];
            if (TargetArr.Length == 1)
            {
                if (TargetArr[0] != "")
                {
                    for (int i = 0; i < TargetArr.Length; i++)
                    {
                        MainTarget[i] = Convert.ToInt64(TargetArr[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < TargetArr.Length - 1; i++)
                {
                    MainTarget[i] = Convert.ToInt64(TargetArr[i]);
                }
            }
            try
            {
                Str = new StringBuilder();
                for (int i = 0; i < MainTarget.Length; i++)
                {
                    MainTarget[i] = Convert.ToInt64((MainTarget[i] / 63342) - i);
                    string converted = compareVal(MainTarget[i]);
                    Str.Append(converted);

                }
                FinalEncrypData = Convert.ToString(Str);

            }
            catch (Exception ex)
            {
            }
            return FinalEncrypData;
        }

        public string compareVal(Int64 Val)
        {
            string Ans = null;
            try
            {
                switch (Val)
                {
                    case 65: Ans = "A"; break;
                    case 66: Ans = "B"; break;
                    case 67: Ans = "C"; break;
                    case 68: Ans = "D"; break;
                    case 69: Ans = "E"; break;
                    case 70: Ans = "F"; break;
                    case 71: Ans = "G"; break;
                    case 72: Ans = "H"; break;
                    case 73: Ans = "I"; break;
                    case 74: Ans = "J"; break;
                    case 75: Ans = "K"; break;
                    case 76: Ans = "L"; break;
                    case 77: Ans = "M"; break;
                    case 78: Ans = "N"; break;
                    case 79: Ans = "O"; break;
                    case 80: Ans = "P"; break;
                    case 81: Ans = "Q"; break;
                    case 82: Ans = "R"; break;
                    case 83: Ans = "S"; break;
                    case 84: Ans = "T"; break;
                    case 85: Ans = "U"; break;
                    case 86: Ans = "V"; break;
                    case 87: Ans = "W"; break;
                    case 88: Ans = "X"; break;
                    case 89: Ans = "Y"; break;
                    case 90: Ans = "Z"; break;

                    case 97: Ans = "a"; break;
                    case 98: Ans = "b"; break;
                    case 99: Ans = "c"; break;
                    case 100: Ans = "d"; break;
                    case 101: Ans = "e"; break;
                    case 102: Ans = "f"; break;
                    case 103: Ans = "g"; break;
                    case 104: Ans = "h"; break;
                    case 105: Ans = "i"; break;
                    case 106: Ans = "j"; break;
                    case 107: Ans = "k"; break;
                    case 108: Ans = "l"; break;
                    case 109: Ans = "m"; break;
                    case 110: Ans = "n"; break;
                    case 111: Ans = "o"; break;
                    case 112: Ans = "p"; break;
                    case 113: Ans = "q"; break;
                    case 114: Ans = "r"; break;
                    case 115: Ans = "s"; break;
                    case 116: Ans = "t"; break;
                    case 117: Ans = "u"; break;
                    case 118: Ans = "v"; break;
                    case 119: Ans = "w"; break;
                    case 120: Ans = "x"; break;
                    case 121: Ans = "y"; break;
                    case 122: Ans = "z"; break;

                    case 48: Ans = "0"; break;
                    case 49: Ans = "1"; break;
                    case 50: Ans = "2"; break;
                    case 51: Ans = "3"; break;
                    case 52: Ans = "4"; break;
                    case 53: Ans = "5"; break;
                    case 54: Ans = "6"; break;
                    case 55: Ans = "7"; break;
                    case 56: Ans = "8"; break;
                    case 57: Ans = "9"; break;
                    case 32: Ans = " "; break;
                    case 46: Ans = "."; break;
                    case 45: Ans = "-"; break;
                    case 95: Ans = "_"; break;
                    case 44: Ans = ","; break;

                }


            }
            catch (Exception ex)
            {
            }
            return Ans;
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

        public string  ConvertFactory(string DBName)
        {
            try
            {
                DataTable dtFactoryOld = DbClass.getdata(CommandType.Text, "Select* from `" + Convert.ToString(DBName).Trim() + "`.factory");
            foreach (DataRow drfac in dtFactoryOld.Rows)
            {

                var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                var match = numAlpha.Match(Convert.ToString(drfac["UID"]));
                int PointID = int.Parse(match.Groups["Numeric"].Value);
                string facName = Convert.ToString(TextDec((string)drfac["ID"]));
                string description = Convert.ToString(TextDec((string)drfac["Description"]));
                if (Convert.ToString(PointID) != "" || Convert.ToString(PointID) != null)
                {
                    int PreviousID = 0;
                    int NextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into factory_info(Name,Description,DateCreated,PreviousID,NextID) values('" + facName + "','','" + PublicClass.GetDatetime() + "','" + PreviousID + "','" + NextId + "')");
                    DataTable dtfacfinal = DbClass.getdata(CommandType.Text, "Select max(factory_id) from factory_info ");
                    PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtfacfinal.Rows[0][0]), "0"))) - 1;
                    NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtfacfinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update factory_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where factory_id = '" + Convert.ToString(dtfacfinal.Rows[0][0]) + "'");
                }
            }
            }
            catch
            {

            }
            return DBName;
        }

        public string ConvertArea(string DBName)
        {
            try
            {
                DataTable dtAreaOld = DbClass.getdata(CommandType.Text, "Select* from `" + Convert.ToString(DBName).Trim() + "`.resource");
            foreach (DataRow drAre in dtAreaOld.Rows)
            {
                //string id = Convert.ToString(drAre["UID"]);
                var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                var match = numAlpha.Match(Convert.ToString(drAre["UID"]));
                int PointID = int.Parse(match.Groups["Numeric"].Value);
                string areaName = Convert.ToString(TextDec((string)drAre["ID"]));
                string description = Convert.ToString(TextDec((string)drAre["Description"]));
                string ParentID = Convert.ToString(drAre["FactoryParentID"]);
                var numAlphapr = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                var matchpr = numAlpha.Match(ParentID);
                int prID = int.Parse(matchpr.Groups["Numeric"].Value);
                if (Convert.ToString(PointID) != "" || Convert.ToString(PointID) != null)
                {
                    int PreviousID = 0;
                    int NextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into area_info(Name,Description,FactoryID,PreviousID,NextID,DateCreated) values('" + areaName + "','" + description + "','" + prID + "','" + PreviousID + "','" + NextId + "','" + PublicClass.GetDatetime() + "')");
                    DataTable dtareafinal = DbClass.getdata(CommandType.Text, "Select max(Area_ID) from area_info ");
                    PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtareafinal.Rows[0][0]), "0"))) - 1;
                    NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtareafinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update area_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Area_ID = '" + Convert.ToString(dtareafinal.Rows[0][0]) + "'");
                }
            }
            }
            catch
            {

            }
            return DBName;
        }

        public string ConvertTrain(string DBName)
        {
            try
            {
                DataTable dtTrainOld = DbClass.getdata(CommandType.Text, "Select* from `" + Convert.ToString(DBName).Trim() + "`.element");
            foreach (DataRow drTra in dtTrainOld.Rows)
            {
                var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                var match = numAlpha.Match(Convert.ToString(drTra["UID"]));
                int PointID = int.Parse(match.Groups["Numeric"].Value);
                string trainName = Convert.ToString(TextDec((string)drTra["ID"]));
                string description = Convert.ToString(TextDec((string)drTra["Description"]));
                string ParentID = Convert.ToString(drTra["ResourceParentID"]);
                var numAlphapr = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                var matchpr = numAlpha.Match(ParentID);
                int prID = int.Parse(matchpr.Groups["Numeric"].Value);
                if (Convert.ToString(PointID) != "" || Convert.ToString(PointID) != null)
                {
                    int PreviousID = 0;
                    int NextId = 0;
                    DbClass.executequery(CommandType.Text, "Insert into train_info(Name,Description,PreviousID,NextID,Area_ID,Date) values('" + trainName + "','" + description + "','" + PreviousID + "','" + NextId + "','" + prID + "','" + PublicClass.GetDatetime() + "')");
                    DataTable dtTrainfinal = DbClass.getdata(CommandType.Text, "Select max(Train_ID) from train_info ");
                    PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtTrainfinal.Rows[0][0]), "0"))) - 1;
                    NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtTrainfinal.Rows[0][0]), "0"))) + 1;
                    DbClass.executequery(CommandType.Text, "Update train_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Train_ID = '" + Convert.ToString(dtTrainfinal.Rows[0][0]) + "'");
                }
            }
            }
            catch
            {

            }
            return DBName;
        }

        public string ConvertMachine(string DBName)
        {
            try
            {
                DataTable dtMacineOld = DbClass.getdata(CommandType.Text, "Select se.UID,se.ID,se.Description,se.ElementParentID,se.NodePosition,se.NodeType , mv.PulseRev , mv.Rpm from `" + Convert.ToString(DBName).Trim() + "`.subelement se left join `" + Convert.ToString(DBName).Trim() + "`.machinevalue mv on se.UID = mv.machine_id");
                foreach (DataRow drMac in dtMacineOld.Rows)
                {
                    var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                    var match = numAlpha.Match(Convert.ToString(drMac["UID"]));
                    int PointID = int.Parse(match.Groups["Numeric"].Value);
                    string machineName = Convert.ToString(TextDec((string)drMac["ID"]));
                    string description = Convert.ToString(TextDec((string)drMac["Description"]));
                    string ParentID = Convert.ToString(drMac["ElementParentID"]);
                    string Position = Convert.ToString(drMac["NodePosition"]);
                    var numAlphapr = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                    var matchpr = numAlpha.Match(ParentID);
                    int prID = int.Parse(matchpr.Groups["Numeric"].Value);
                    if (Convert.ToString(PointID) != "" || Convert.ToString(PointID) != null)
                    {
                        int PreviousID = 0;
                        int NextId = 0;
                        DbClass.executequery(CommandType.Text, "Insert into machine_info(Name,Description,PreviousID,NextID,TrainID,Position,DateCreated,RPM_Driven,PulseRev) values('" + machineName + "','" + description + "','" + PreviousID + "','" + NextId + "','" + prID + "','" + Position + "','" + PublicClass.GetDatetime() + "','" + Convert.ToString(drMac["Rpm"]) + "','" + Convert.ToString(drMac["PulseRev"]) + "')");
                        DataTable dtmacfinal = DbClass.getdata(CommandType.Text, "Select max(Machine_ID) from machine_info ");
                        PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtmacfinal.Rows[0][0]), "0"))) - 1;
                        NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtmacfinal.Rows[0][0]), "0"))) + 1;
                        DbClass.executequery(CommandType.Text, "Update machine_info set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Machine_ID = '" + Convert.ToString(dtmacfinal.Rows[0][0]) + "'");
                    }
                }
            }
            catch { }
            try
            {
                DataTable dtMacinePic = DbClass.getdata(CommandType.Text, "Select * from " + Convert.ToString(DBName).Trim() + ".tblimages");
                foreach (DataRow drMacPic in dtMacinePic.Rows)
                {
                    string id = Convert.ToString(drMacPic["Type"]);
                    var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                    var match = numAlpha.Match(id);
                    char[] characters = id.ToCharArray();
                    //var day = char.Parse(match.Groups["Alpha"].Value);
                    int PointID = int.Parse(match.Groups["Numeric"].Value);
                    string macPath = Convert.ToString(drMacPic["Description"]);
                    string macStatus = Convert.ToString(drMacPic["FullDescription"]);
                  
                   if (characters[characters.Length - 1] == 'M')
                   {
                       DbClass.executequery(CommandType.Text, "Insert into machine_pic(Picture,MachineID,Description) values('" + macPath + "','" + PointID + "','" + macStatus + "')");
                   }
                }
            }
            catch { }
          
            return DBName;
        }

        public string ConvertPoint(string DBName)
        {
            try
            {
                DataTable dtPointOld = DbClass.getdata(CommandType.Text, "Select* from `" + Convert.ToString(DBName).Trim() + "`.point");
                DbClass.executequery(CommandType.Text, "ALTER TABLE `point` CHANGE COLUMN `Point_ID` `Point_ID` INT(11) NOT NULL ");
                foreach (DataRow drPoint in dtPointOld.Rows)
                {
                    var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                    var match = numAlpha.Match(Convert.ToString(drPoint["UID"]));
                    int PointID = int.Parse(match.Groups["Numeric"].Value);
                    string pointName = Convert.ToString(TextDec((string)drPoint["ID"]));
                    string description = Convert.ToString(TextDec((string)drPoint["Description"]));
                    string ParentID = Convert.ToString(drPoint["ParentID"]);
                    string Position = Convert.ToString(drPoint["PointPosition"]);
                    string CreateDate = Convert.ToString(drPoint["LastCollected"]);

                    var numAlphapr = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                    var matchpr = numAlpha.Match(ParentID);
                    int prID = int.Parse(matchpr.Groups["Numeric"].Value);
                   
                    if (Convert.ToString(PointID) != "" || Convert.ToString(PointID) != null)
                    {
                        int PreviousID = 0;
                        int NextId = 0;
                        DbClass.executequery(CommandType.Text, "Insert into point(Point_ID,PointName,PointDesc,DataCreated,PreviousID,NextID,Machine_ID,DataSchedule,PointStatus,PointSchedule) values('" + Position + "','" + pointName + "','" + description + "','" + CreateDate + "','" + PreviousID + "','" + NextId + "','" + prID + "','7Days','0','1')");
                        DataTable dtpointfinal = DbClass.getdata(CommandType.Text, "Select max(Point_ID) from point ");
                        PreviousID = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtpointfinal.Rows[0][0]), "0"))) - 1;
                        NextId = (Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dtpointfinal.Rows[0][0]), "0"))) + 1;
                        DbClass.executequery(CommandType.Text, "Update point set PreviousID = '" + PreviousID + "',NextID='" + NextId + "' where Point_ID = '" + Convert.ToString(dtpointfinal.Rows[0][0]) + "'");
                    }
                }
                DbClass.executequery(CommandType.Text, "ALTER TABLE `point` CHANGE COLUMN `Point_ID` `Point_ID` INT(11) NOT NULL AUTO_INCREMENT ");
            }
            catch
            {

            }
            return DBName;
        }

        public string ConvertAlarms(string DBName)
        {
            try
            {
                DataTable dtAlarmOld = DbClass.getdata(CommandType.Text, "Select* from `" + Convert.ToString(DBName).Trim() + "`.alarms  where idAlarms != '1'");
                foreach (DataRow drAlarm in dtAlarmOld.Rows)
                {
                    string alarmID = Convert.ToString(drAlarm["idAlarms"]);
                    string AlarmName = Convert.ToString(drAlarm["alarm_name"]);
                    float accel_a1 = (float)(drAlarm["accel_a1"]);
                    float accel_a2 = (float)(drAlarm["accel_a2"]);
                    float accel_v1 = (float)(drAlarm["accel_v1"]);
                    float accel_v2 = (float)(drAlarm["accel_v2"]);
                    float accel_h1 = (float)(drAlarm["accel_h1"]);
                    float accel_h2 = (float)(drAlarm["accel_h2"]);

                    float vel_a1 = (float)(drAlarm["vel_a1"]);
                    float vel_a2 = (float)(drAlarm["vel_a2"]);
                    float vel_v1 = (float)(drAlarm["vel_v1"]);
                    float vel_v2 = (float)(drAlarm["vel_v2"]);
                    float vel_h1 = (float)(drAlarm["vel_h1"]);
                    float vel_h2 = (float)(drAlarm["vel_h2"]);

                    float displ_a1 = (float)(drAlarm["displ_a1"]);
                    float displ_a2 = (float)(drAlarm["displ_a2"]);
                    float displ_v1 = (float)(drAlarm["displ_v1"]);
                    float displ_v2 = (float)(drAlarm["displ_v2"]);
                    float displ_h1 = (float)(drAlarm["displ_h1"]);
                    float displ_h2 = (float)(drAlarm["displ_h2"]);

                    float bearing_a1 = (float)(drAlarm["bearing_a1"]);
                    float bearing_a2 = (float)(drAlarm["bearing_a2"]);
                    float bearing_v1 = (float)(drAlarm["bearing_v1"]);
                    float bearing_v2 = (float)(drAlarm["bearing_v2"]);
                    float bearing_h1 = (float)(drAlarm["bearing_h1"]);
                    float bearing_h2 = (float)(drAlarm["bearing_h2"]);

                    float temperature_1 = (float)(drAlarm["temperature_1"]);
                    float temperature_2 = (float)(drAlarm["temperature_2"]);

                    float crestfactor_a1 = (float)(drAlarm["crestfactor_a1"]);
                    float crestfactor_a2 = (float)(drAlarm["crestfactor_a2"]);
                    float crestfactor_v1 = (float)(drAlarm["crestfactor_v1"]);
                    float crestfactor_v2 = (float)(drAlarm["crestfactor_v2"]);
                    float crestfactor_h1 = (float)(drAlarm["crestfactor_h1"]);
                    float crestfactor_h2 = (float)(drAlarm["crestfactor_h2"]);

                    float accel_ch11 = (float)(drAlarm["accel_ch11"]);
                    float accel_ch12 = (float)(drAlarm["accel_ch12"]);
                    float vel_ch11 = (float)(drAlarm["vel_ch11"]);
                    float vel_ch12 = (float)(drAlarm["vel_ch12"]);
                    float displ_ch11 = (float)(drAlarm["displ_ch11"]);
                    float displ_ch12 = (float)(drAlarm["displ_ch12"]);
                    float bearing_ch11 = (float)(drAlarm["bearing_ch11"]);
                    float bearing_ch12 = (float)(drAlarm["bearing_ch12"]);
                    float crestfactor_ch11 = (float)(drAlarm["crestfactor_ch11"]);
                    float crestfactor_ch12 = (float)(drAlarm["crestfactor_ch12"]);
                    if (Convert.ToString(alarmID) != "" || Convert.ToString(alarmID) != null)
                    {
                        DbClass.executequery(CommandType.StoredProcedure, "call " + PublicClass.User_DataBase + ".Insert_Alarm (" + accel_a1 + "," + accel_h1 + "," + accel_v1 + "," + accel_a2 + "," + accel_h2 + "," + accel_v2 + "," + accel_ch11 + "," + accel_ch12 + "," + vel_a1 + "," + vel_h1 + "," + vel_v1 + "," + vel_a2 + "," + vel_h2 + "," + vel_v2 + "," + vel_ch11 + "," + vel_ch12 + "," + displ_a1 + "," + displ_h1 + "," + displ_v1 + "," + displ_a2 + "," + displ_h2 + "," + displ_v2 + "," + displ_ch11 + "," + displ_ch12 + "," + bearing_a1 + "," + bearing_h1 + "," + bearing_v1 + "," + bearing_a2 + "," + bearing_h2 + "," + bearing_v2 + "," + bearing_ch11 + "," + bearing_ch12 + "," + crestfactor_a1 + "," + crestfactor_h1 + "," + crestfactor_v1 + "," + crestfactor_a2 + "," + crestfactor_h2 + "," + crestfactor_v2 + "," + crestfactor_ch11 + "," + crestfactor_ch12 + "," + temperature_1 + "," + temperature_2 + ",'" + AlarmName + "')");
                    }
                }
            }
            catch (Exception ex) { }
            try
            {
                DataTable dtsdAlarmOld = DbClass.getdata(CommandType.Text, "Select* from `" + Convert.ToString(DBName).Trim() + "`.sdalarms where Guid != '1'");
                 foreach (DataRow drsdAlarm in dtsdAlarmOld.Rows)
                 {
                     string sdID = Convert.ToString(drsdAlarm["Guid"]);
                     string SDName = Convert.ToString(drsdAlarm["Name"]);
                     string SDValue = Convert.ToString(drsdAlarm["Value"]);
                     if (Convert.ToString(sdID) != "" || Convert.ToString(sdID) != null)
                     {
                         DbClass.executequery(CommandType.StoredProcedure, "call " + PublicClass.User_DataBase + ".Insert_SDAlarm ('" + SDName + "','" + SDValue + "','" + SDValue + "','" + SDValue + "','" + SDValue + "'");
                     }
                 }
            }
            catch (Exception ex) { }
            try
            {
                DataTable dtperAlarmOld = DbClass.getdata(CommandType.Text, "Select* from `" + DBName + "`.palarms where Guid != '1'");
                 foreach (DataRow drperAlarm in dtperAlarmOld.Rows)
                 {
                     string perID = Convert.ToString(drperAlarm["Guid"]);
                     string perName = Convert.ToString(drperAlarm["Name"]);
                     string perValue = Convert.ToString(drperAlarm["Value"]);
                     if (Convert.ToString(perID) != "" || Convert.ToString(perID) != null)
                     {
                         DbClass.executequery(CommandType.StoredProcedure, "call " + PublicClass.User_DataBase + ".Insert_PAlarm ('" + perName + "','" + perValue + "','" + perValue + "','" + perValue + "','" + perValue + "'");
                     }
                 }
            }
            catch {}
            try
            {
                string chkID = null;
                string lastFreq = null;
                string BGID = null;
                DataTable dtbandAlarmOld = DbClass.getdata(CommandType.Text, "Select* from `" + DBName + "`.bandalarm order by point_id asc");
                int a = 1;
                foreach (DataRow drbandAlarm in dtbandAlarmOld.Rows)
                {
                    string baID = Convert.ToString(drbandAlarm["idbandalarm"]);
                    string baFreq = Convert.ToString(drbandAlarm["Freq"]);
                    string LowValue = Convert.ToString(drbandAlarm["alarm1"]);
                    string HighValue = Convert.ToString(drbandAlarm["alarm2"]);
                    string axistype = Convert.ToString(drbandAlarm["axis_type"]);
                    string PointID = Convert.ToString(drbandAlarm["point_id"]);
                    string groupID = null;
                    string BandGroupName = null;
                   
                    if (Convert.ToString(baID) != "" || Convert.ToString(baID) != null)
                    {
              
                        if (PointID != chkID || baFreq != lastFreq)
                        {
                          
                            if (PointID != chkID)
                            {
                                BandGroupName = Convert.ToString("DefaultGroup" + Convert.ToString(PointID) + "-" + baFreq);
                                DbClass.executequery(CommandType.Text, "Insert into " + PublicClass.User_DataBase + ".bandalarm_data(bandalarmsgroup_Name) values('" + BandGroupName + "')");
                                DataTable dtbgid = DbClass.getdata(CommandType.Text, "select Bandalarmsgroup_id from " + PublicClass.User_DataBase + ".bandalarm_data where bandalarmsgroup_Name = '" + BandGroupName + "' ");
                                BGID = Convert.ToString(dtbgid.Rows[0]["Bandalarmsgroup_id"]);
                            }
                            string bandName = Convert.ToString("DefaultPower" + PointID +"-"+baFreq);
                            string DemobandName = Convert.ToString("DefaultDemo" + PointID + "-" + baFreq);
                            //for (int axisId = 0; axisId <= 3; axisId++)
                            //{
                                DbClass.executequery(CommandType.StoredProcedure, "call " + PublicClass.User_DataBase + ".Insert_PowerBand ('" + bandName + "','" + baFreq + "','" + LowValue + "','" + HighValue + "','" + a + "','" + PublicClass.GetDatetime() + "','" + BGID + "','" + axistype + "')");
                                DbClass.executequery(CommandType.StoredProcedure, "call " + PublicClass.User_DataBase + ".Insert_DemodulateBand ('" + DemobandName + "','" + baFreq + "','" + LowValue + "','" + HighValue + "','" + a + "','" + PublicClass.GetDatetime() + "','" + BGID + "','" + axistype + "')");
                            //}
                            chkID = PointID;
                            lastFreq = baFreq;
                            a++;
                        }
                       
                    }
                   
                }
            }
            catch { }
            try
            {
                DataTable dtFFOld = DbClass.getdata(CommandType.Text, "Select* from `" + DBName + "`.point_faultfreq order by pf_id asc");
                foreach (DataRow drFF in dtFFOld.Rows)
                {
                    string id = Convert.ToString(drFF["point_id"]);
                    string fName = Convert.ToString(drFF["pf_name"]);
                    string freq = Convert.ToString(drFF["pf_freq"]);
                    var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                    var match = numAlpha.Match(id);
                    int PointID = int.Parse(match.Groups["Numeric"].Value);

                    DbClass.executequery(CommandType.StoredProcedure, "call Insert_FaultFrequency('" + fName.Trim() + "' , '" + freq + "' , '" + PublicClass.GetDatetime() + "','" + PointID + "')");
                }
            }
            catch { }
            try
            {
                DataTable dtFFOld = DbClass.getdata(CommandType.Text, "Select* from `" + DBName + "`.point_bearingdata order by point_id asc");
                foreach (DataRow drFF in dtFFOld.Rows)
                {
                    string id = Convert.ToString(drFF["point_id"]);
                    string status = Convert.ToString(drFF["Selected"]);
                    string BDIR = Convert.ToString(drFF["BDIR"]);
                    string BDOR = Convert.ToString(drFF["BDOR"]);
                    string BCA = Convert.ToString(drFF["BCA"]);
                    string BDRE = Convert.ToString(drFF["BDRE"]);
                    string BNRE = Convert.ToString(drFF["BNRE"]);
                    string Manufacturer = Convert.ToString(drFF["Manufacturer"]);
                    string BearingNumber = Convert.ToString(drFF["BearingNumber"]);

                    var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                    var match = numAlpha.Match(id);
                    int PointID = int.Parse(match.Groups["Numeric"].Value);
                }
            }
            catch { }

            
            return DBName;
        }

        public string ConvertSensors(string DBName)
        {
            try
            {
                DataTable dtSenOld = DbClass.getdata(CommandType.Text, "Select * from `" + DBName + "`.sensors where Sensor_Id not in (Select Sensor_Id from `" + DBName + "`.sensors where Sensor_Id between '1' and '5')");
                foreach (DataRow drsen in dtSenOld.Rows)
                {
                    string SensorID = Convert.ToString(drsen["Sensor_Id"]);
                    string SensorName = Convert.ToString(drsen["SensorName"]);
                    string SenType = Convert.ToString(drsen["SensorType"]);
                    string SensA = Convert.ToString(drsen["Sensitivity_a"]);
                    string SensH = Convert.ToString(drsen["Sensitivity_h"]);
                    string SensV = Convert.ToString(drsen["Sensitivity_v"]);
                    string SensCh1 = Convert.ToString(drsen["Sensitivity_ch1"]);
                    string SenUnit = Convert.ToString(drsen["Sensor_unit"]);
                    string SenDir = Convert.ToString(drsen["Sensor_dir"]);
                    string SenICP = Convert.ToString(drsen["Sensor_icp"]);
                    string SenOffset = Convert.ToString(drsen["Sensor_offset"]);
                    //string SendefaultType = Convert.ToString(drAlarm["Defaulttype"]);
                    string SenManID = Convert.ToString(drsen["ManID"]);
                    string SenInputRange = Convert.ToString(drsen["Input_Range"]);
                    if (SensorID != "" || SensorID != null)
                    {
                        DbClass.executequery(CommandType.StoredProcedure, "call insert_sensor_data('" + SenManID + "' , '" + SensorName + "','" + SenType + "','" + SensCh1 + "' , '" + SensA + "' , '" + SensH + "' , '" + SensV + "','" + SenUnit + "','" + SenDir + "','" + SenICP + "','" + SenOffset + "', '" + SenInputRange + "') ");
                    }
                }
            }
            catch { }
            try
            {
                DataTable dtManu = DbClass.getdata(CommandType.Text, "Select * from `" + DBName + "`.manufacturer where  ID not in(Select ID from `" + DBName + "`.manufacturer where ID between '1' and '11')");
                foreach (DataRow drman in dtManu.Rows)
                {
                    string ManuID = Convert.ToString(drman["ID"]);
                    string ManName = Convert.ToString(drman["ManufacturerName"]);
                    string ManuAdd = Convert.ToString(drman["ManufacturerAddress"]);
                    DbClass.executequery(CommandType.Text, "Insert into manufacture(ManufactureName,ManufacturerAddress) vaules('" + ManName + "','" + ManuAdd + "')");
                }
            }
            catch { }
            try
            {
                DataTable dtSenType = DbClass.getdata(CommandType.Text, "Select * from `" + DBName + "`.sensors1 where  ID not in(Select ID from `" + DBName + "`.sensors1 where ID between '1' and '13')");
                foreach (DataRow drSenType in dtSenType.Rows)
                {
                    string TypeID = Convert.ToString(drSenType["ID"]);
                    string SenType = Convert.ToString(drSenType["SensorType"]);
                    string Unit = Convert.ToString(drSenType["UNIT"]);
                    string SenTypeint = Convert.ToString(drSenType["SensorTypeInt"]);
                    string SenUnitInt = Convert.ToString(drSenType["sensorunitint"]);
                    DbClass.executequery(CommandType.Text, "Insert into sensor_type(SensorType,UNIT,SensorTypeInt,sensorunitint) vaules('" + SenType + "','" + Unit + "','" + SenTypeint + "','" + SenUnitInt + "')");
                }
            }
            catch { }
            return DBName;
        }

        public string ConvertPointType(string DBName)
        {
            try
            {
                string instname = PublicClass.currentInstrument;
                DataTable dtpoint = DbClass.getdata(CommandType.Text, "Select distinct p.UID as PointID , a.idAlarms as AlarmID , sd.Guid as sdAlarmID , pal.Guid as perAlarmID  from `" + DBName + "`.point p right join `" + DBName + "`.point_alarm pa on p.UID = pa.point_id right join `" + DBName + "`.alarms a on a.alarm_name = pa.Alarm_Name inner join `" + DBName + "`.point_standardalarm ps on ps.PointID = p.UID inner join `" + DBName + "`.sdalarms sd on ps.Name = sd.Name  inner join `" + DBName + "`.point_percentalarm pr on pr.PointID = p.UID inner join `" + DBName + "`.palarms pal on pr.Name = pal.Name  where p.UID <> '' ");
                foreach (DataRow drsen in dtpoint.Rows)
                {
                    string id = Convert.ToString(drsen["PointID"]);
                    var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                    var match = numAlpha.Match(id);
                    int PointID = int.Parse(match.Groups["Numeric"].Value);
                    string AlarmID = Convert.ToString(drsen["AlarmID"]);
                    string sdID = Convert.ToString(drsen["sdAlarmID"]);
                    string perID = Convert.ToString(drsen["perAlarmID"]);
                    string PointTypeName = Convert.ToString("DefaultPointType-" + id);
                    DbClass.executequery(CommandType.Text, "Call Insert_PointTypeDB('" + PointTypeName + "','1','"+instname+"','" + AlarmID + "','" + sdID + "','" + perID + "','" + PublicClass.GetDatetime() + "','" + PointID + "')");
                }
            }
            catch { }
            try
            {
                DataTable dtpoint = DbClass.getdata(CommandType.Text, "select Bandalarmsgroup_id ,bandalarmsgroup_Name from bandalarm_data");
                foreach (DataRow drsen in dtpoint.Rows)
                {
                    string id = Convert.ToString(drsen["bandalarmsgroup_Name"]);
                    var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*[ _]?)(?<Numeric>[0-9]*)");
                    var match = numAlpha.Match(id);
                    int PointID = int.Parse(match.Groups["Numeric"].Value);
                    string bandGroupID = Convert.ToString(drsen["Bandalarmsgroup_id"]);
                    DbClass.executequery(CommandType.StoredProcedure, "call update_PointTYpeDB('" + PointID + "','" + bandGroupID + "')");
                }
            }
            catch { }
            return DBName;
        }

        private int SetListView(string DBName , string ptID)
        {
            int iTotal = 0;
            int iPartToAdd = 0;
            try
            {
                DataTable dtMeasure = DbClass.getdata(CommandType.Text, "Select p .PointPosition ,m.OAcc , m.OVel , m.ODisp ,m.OBear,m.OTWF,m.OPS,m.ODS,m.Temp,m.Process,m.crestfactor,m.Ordertrace,m.Cepstrum from `" + DBName + "`.measurement m inner join `" + DBName + "`.point p on m.point_id = p.UID");
                foreach (DataRow drmeasure in dtMeasure.Rows)
                {
                    iTotal = 0;
                    int Acc = Convert.ToInt32(drmeasure["OAcc"]);
                    int vel = Convert.ToInt32(drmeasure["OVel"]);
                    int disp = Convert.ToInt32(drmeasure["ODisp"]);
                    int Bear = Convert.ToInt32(drmeasure["OBear"]);
                    int TimeWave = Convert.ToInt32(drmeasure["OTWF"]);
                    int PowerSpectra = Convert.ToInt32(drmeasure["OPS"]);
                    int DemoSpectra = Convert.ToInt32(drmeasure["ODS"]);
                    int tmp = Convert.ToInt32(drmeasure["Temp"]);
                    int Process = Convert.ToInt32(drmeasure["Process"]);
                    int CrestFact = Convert.ToInt32(drmeasure["crestfactor"]);
                    int PointID = Convert.ToInt32(drmeasure["PointPosition"]);
                    int OT = Convert.ToInt32(drmeasure["Ordertrace"]);
                    int Cepst = Convert.ToInt32(drmeasure["Cepstrum"]);

                    if (Acc == 1)
                    {
                        iPartToAdd = 1;
                        iTotal += iPartToAdd;
                    }
                    else
                    {

                    }
                    if (vel == 1)
                    {
                        iPartToAdd = 2;
                        iTotal += iPartToAdd;
                    }

                    if (disp == 1)
                    {
                        iPartToAdd = 4;
                        iTotal += iPartToAdd;
                    }

                    if (Bear == 1)
                    {
                        iPartToAdd = 8;
                        iTotal += iPartToAdd;
                    }

                    if (TimeWave == 1)
                    {
                        iPartToAdd = 16;
                        iTotal += iPartToAdd;
                    }

                    if (PowerSpectra == 1)
                    {
                        iPartToAdd = 32;
                        iTotal += iPartToAdd;
                    }
                    if (DemoSpectra == 1)
                    {
                        iPartToAdd = 64;
                        iTotal += iPartToAdd;
                    }

                    if (tmp == 1)
                    {
                        iPartToAdd = 128;
                        iTotal += iPartToAdd;
                    }

                    if (Process == 1)
                    {
                        iPartToAdd = 256;
                        iTotal += iPartToAdd;
                    }
                    if (CrestFact == 1)
                    {
                        iPartToAdd = 512;
                        iTotal += iPartToAdd;
                    }
                    if (OT == 1)
                    {
                        iPartToAdd = 1024;
                        iTotal += iPartToAdd;
                    }
                    if (Cepst == 1)
                    {
                        iPartToAdd = 2048;
                        iTotal += iPartToAdd;
                    }

                    DataTable dt = DbClass.getdata(CommandType.Text, "Select PointType_ID from point where Point_ID ='" + PointID + "'");
                    DbClass.executequery(CommandType.StoredProcedure, "call insert_measure_type ('" +  setvalue(Convert.ToBoolean(Acc)) + "' , '" + setvalue(Convert.ToBoolean(vel)) + "' ,'" + setvalue(Convert.ToBoolean(disp)) + "'  , '" + setvalue(Convert.ToBoolean(Bear)) + "', '" + setvalue(Convert.ToBoolean(TimeWave)) + "', '" + setvalue(Convert.ToBoolean(PowerSpectra)) + "' , '" + setvalue(Convert.ToBoolean(DemoSpectra)) + "', '" + setvalue(Convert.ToBoolean(tmp)) + "', '" + setvalue(Convert.ToBoolean(Process)) + "', '" + setvalue(Convert.ToBoolean(CrestFact)) + "', '" + setvalue(Convert.ToBoolean(OT)) + "', '" + setvalue(Convert.ToBoolean(Cepst)) + "'  ,'"+dt.Rows[0]["PointType_ID"] +"','" + iTotal + "' ) ");
                  
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }

            return iTotal;

        }

        public string ConvertMeasurement(string DBName)
        {
            try
            {
                string PointID = null;
                int Calmsr = SetListView(DBName, PointID);

            }
            catch { }
            return DBName;
        }

        public string ConvertMeasures(string DBName)
        {
            try
            {
                DataTable dtmeasure = DbClass.getdata(CommandType.Text, "SELECT pt.PointDir as SensorDir,p.PointPosition,pm.* FROM `" + DBName + "`.pointnewval pt inner join `" + DBName + "`.point_measures pm on pm.point_id=pt.Guid left join `" + DBName + "`.point p on p.UID = pm.Point_ID");
                foreach(DataRow drm in dtmeasure.Rows)
                {
                    int PointID = Convert.ToInt32(drm["PointPosition"]);
                    string SensorDir = Convert.ToString(drm["SensorDir"]);
                    string acc_filter = Convert.ToString(TextDec((string)drm["acc_filter"]));
                    string vel_filter = Convert.ToString(TextDec((string)drm["vel_filter"]));
                    string displ_filter = Convert.ToString(TextDec((string)drm["displ_filter"]));
                    string cfFilter = Convert.ToString(TextDec((string)drm["crest_factor_filter"]));
                    string demoFilter = Convert.ToString(TextDec((string)drm["demodulate_filter"]));
                    string bearhp_filter = Convert.ToString(TextDec((string)drm["overall_bearing_filter"]));
                    string otveragetimes = Convert.ToString(TextDec((string)drm["ordertrace_average_times"]));
                    string otresolution = Convert.ToString(TextDec((string)drm["ordertrace_resolution"]));
                    string otorder = Convert.ToString(TextDec((string)drm["ordertrace_order"]));
                    string ottriggerslope= Convert.ToString(TextDec((string)drm["ordertrace_trigger_slope"]));
                    string timeband = Convert.ToString(TextDec((string)drm["time_band"]));
                    string timeResol = Convert.ToString(TextDec((string)drm["time_resolution"]));
                    string timeoverlap = Convert.ToString(TextDec((string)drm["time_overlap"]));
                    string pwrmultiple = Convert.ToString(TextDec((string)drm["power_multiple"]));
                    string pbgroup1 = Convert.ToString(TextDec((string)drm["power_band_Group1"]));
                    string pwrResG1 = Convert.ToString(TextDec((string)drm["power_resolution_Group1"]));
                    string pwrB1G1 = Convert.ToString(TextDec((string)drm["power_band1_Group1"]));
                    string pwrRes1G1 = Convert.ToString(TextDec((string)drm["power_resolution1_Group1"]));
                    string pwrB2G1 = Convert.ToString(TextDec((string)drm["power2_band_Group2"]));
                    string pwrRes2G2 = Convert.ToString(TextDec((string)drm["power2_resolution_Group2"]));
                    string pwr2B1G2 = Convert.ToString(TextDec((string)drm["power2_band1_Group2"]));
                    string pwr2Res1G1 = Convert.ToString(TextDec((string)drm["power2_resolution1_Group2"]));
                    string pwr3BG3 = Convert.ToString(TextDec((string)drm["power3_band_Group3"]));
                    string pwr3Res3G3 = Convert.ToString(TextDec((string)drm["power3_resolution_Group3"]));
                    string pwr3B1G3 = Convert.ToString(TextDec((string)drm["power3_band1_Group3"]));
                    string pwr3Res1G3 = Convert.ToString(TextDec((string)drm["power3_resolution1_Group3"]));
                    string pwrWindow = Convert.ToString(TextDec((string)drm["power_window"]));
                    string pwrAvgTime = Convert.ToString(TextDec((string)drm["power_average_times"]));
                    string pwrOverlap = Convert.ToString(TextDec((string)drm["power_overlap"]));
                    int pwrZoom = Convert.ToInt32(TextDec((string)drm["power_zoom"]));
                    string pwrZoomSTF = Convert.ToString(drm["power_zoom_startfreq"]);
                    string cepBand = Convert.ToString(TextDec((string)drm["cepstrum_band"]));
                    string cepResol = Convert.ToString(TextDec((string)drm["cepstrum_resolution"]));
                    string cepWindow = Convert.ToString(TextDec((string)drm["cepstrum_window"]));
                    string cepAvgTime = Convert.ToString(TextDec((string)drm["cepstrum_average_times"]));
                    string cepOverlap = Convert.ToString(TextDec((string)drm["cepstrum_overlap"]));
                    int cepZoom = Convert.ToInt32(TextDec((string)drm["cepstrum_zoom"]));
                    string cepZoomSTF = Convert.ToString(drm["cepstrum_zoom_startfreq"]);
                    string demoBand = Convert.ToString(TextDec((string)drm["demodulate_band"]));
                    string demoResol = Convert.ToString(TextDec((string)drm["demodulate_resolution"]));
                    string demoWindow = Convert.ToString(TextDec((string)drm["demodulate_window"]));
                    string demoAvgTime = Convert.ToString(TextDec((string)drm["demodulate_average_times"]));


                    DataTable dt = DbClass.getdata(CommandType.Text, "Select PointType_ID from point where Point_ID ='" + PointID + "'");
                    DbClass.executequery(CommandType.Text, "call Insert_Measure('" + acc_filter + "', '" + vel_filter + "', '" + displ_filter + "', '" + bearhp_filter+ "' , '" + cfFilter + "'  ,'0', '" + timeband + "' , '" + timeResol + "', '" + timeoverlap + "','" + PublicClass.GetDatetime() + "' ,'" + SensorDir + "','0','0', '" + pbgroup1+ "', '" + pwrResG1 + "', '" + pwrB1G1 + "','" + pwrRes1G1 + "','" + pwrB2G1 + "','" + pwrRes2G2 + "',   '" + pwr2B1G2 + "','" + pwr2Res1G1 + "','" + pwr3BG3 + "','" + pwr3Res3G3 + "','" + pwr3B1G3 + "','" + pwr3Res1G3 + "','" + pwrWindow + "','" + pwrOverlap + "','" + pwrAvgTime + "', '" + setvalue(Convert.ToBoolean(pwrZoom)) + "','" + PublicClass.DefVal(Convert.ToString(pwrZoomSTF), "0") + "','" + cepBand + "','" + cepResol + "','" + cepWindow + "','" + cepAvgTime + "','" + cepOverlap + "','" + setvalue(Convert.ToBoolean(cepZoom)) + "','" + PublicClass.DefVal(Convert.ToString(cepZoomSTF), "0") + "',  '" + demoBand + "','" + demoResol + "','" + demoWindow + "','" +demoAvgTime + "',    '" + demoFilter + "','" + otveragetimes + "','" + otresolution + "','" + PublicClass.DefVal(Convert.ToString(otorder), "0") + "','" + ottriggerslope + "', '" + pwrmultiple + "' ,  '" + dt.Rows[0]["PointType_ID"] + "' ) ");
                }

            }
            catch { }
            try
            {
                string tempID = null;
                string SenID = null;
                DataTable dtmea = DbClass.getdata(CommandType.Text, "select p.PointPosition,sen.sensorid , sen.sensor_type from `" + DBName + "`.point_sensors sen left join `" + DBName + "`.point p on sen.point_id = p.UID ");
                foreach(DataRow drme in dtmea.Rows)
                {
                    int PointID = Convert.ToInt32(drme["PointPosition"]);
                    string SensorID = Convert.ToString(drme["sensorid"]);
                    string sensorType = Convert.ToString(drme["sensor_type"]);

                    if (SensorID != "2" && sensorType != "3")
                    {
                        SenID = SensorID;
                    }
                    else
                    {
                        tempID = SensorID;
                    }
                    
                    DataTable dt = DbClass.getdata(CommandType.Text, "Select PointType_ID from point where Point_ID ='" + PointID + "'");

                    DbClass.executequery(CommandType.Text, "Update measure set Sensor_ID = '" + SenID + "' , TemperatureID = '" + tempID + "' where Type_ID ='" + dt.Rows[0]["PointType_ID"] + "'");
                }
            }
            catch { }
            return DBName;
        }

        public string ConvertUnit(string DBName)
        {
            try
            {
                DataTable dtmeasure = DbClass.getdata(CommandType.Text, "SELECT   u.* , p.PointPosition from `" + DBName + "`.point_unit u left join `" + DBName + "`.point p on u.Point_ID = p.UID");
                 foreach (DataRow drm in dtmeasure.Rows)
                 {
                     int PointID = Convert.ToInt32(drm["PointPosition"]);
                     string accUnit = Convert.ToString(TextDec((string)drm["accel_unit"]));
                     string velUnit = Convert.ToString(TextDec((string)drm["vel_unit"]));
                     string dispUnit = Convert.ToString(TextDec((string)drm["displ_unit"]));
                     string tempUnit = Convert.ToString(TextDec((string)drm["temprature_unit"]));
                     string procUnit = Convert.ToString(TextDec((string)drm["process_unit"]));
                     string pressUnit = Convert.ToString(TextDec((string)drm["pressure_unit"]));
                     string currUnit = Convert.ToString(TextDec((string)drm["current_unit"]));
                     string accDetectio = Convert.ToString(TextDec((string)drm["accel_detection"]));
                     string velDetectio = Convert.ToString(TextDec((string)drm["vel_detection"]));
                     string dispDetectio = Convert.ToString(TextDec((string)drm["displ_detection"]));
                     string pressDetectio = Convert.ToString(TextDec((string)drm["pressure_detection"]));
                     string currDetectio = Convert.ToString(TextDec((string)drm["current_detection"]));
                     string timeUnitType = Convert.ToString(TextDec((string)drm["time_unit_type"]));
                     string pwrUnitType = Convert.ToString(TextDec((string)drm["power_unit_type"]));
                     string demoUnitType = Convert.ToString(TextDec((string)drm["demodulate_unit_type"]));
                     string OTUnitType = Convert.ToString(TextDec((string)drm["ordertrace_unit_type"]));
                     string cepsUnitType = Convert.ToString(TextDec((string)drm["cepstrum_unit_type"]));

                     DataTable dt = DbClass.getdata(CommandType.Text, "Select PointType_ID from point where Point_ID ='" + PointID + "'");
                     DbClass.executequery(CommandType.Text, "call insert_Units('" + accUnit + "', '" + accDetectio + "', '" + velUnit + "', '" + velDetectio + "' , '" + dispUnit + "'  ,'" + dispDetectio + "', '" + tempUnit + "' , '" + procUnit + "', '" + pressUnit + "','" + pressDetectio + "' ,'" + currUnit + "', '" + currDetectio + "', '" + timeUnitType + "', '" + pwrUnitType + "','" + demoUnitType + "','" + OTUnitType + "','" + cepsUnitType + "','" + PublicClass.GetDatetime() + "', '" + dt.Rows[0]["PointType_ID"] + "' ) ");
                 }
            }
            catch { }
            return DBName;
        }

        public string ConvertPointData(string DBName)
        {

            string ax = null;
            string ay = null;
            string hx = null;
            string hy = null;
            string vx = null;
            string vy = null;
            string ch1x = null;
            string ch1y = null;

            try
            {
                DataTable dtOverall = DbClass.getdata(CommandType.Text, "SELECT distinct p.UID , p.PointPosition,pr.* ,pra.idPoint_RecordOverall , pra.Time , dp.A_X ,dp.A_Y,dp.H_X , dp.H_Y , dp.V_X , dp.V_Y , dp.CH1_X , dp.CH1_Y  FROM  `" + DBName + "`.point_record pr left join `" + DBName + "`.point_recordoverall pra on pr.Guid = pra.idPoint_RecordOverall left join `" + DBName + "`.Point p on p.UID = pra.point_id  left join `" + DBName + "`.data_power dp on dp.DateTime = pra.Time");
                foreach (DataRow dro in dtOverall.Rows)
                {
                    string PointID = Convert.ToString(dro["PointPosition"]);
                    string PtID = Convert.ToString(dro["UID"]);

                    string measurTime = Convert.ToString(dro["Time"]);
                    try
                    {
                        string[] formats = {"MM-dd-yyyy HH:m:ss tt","M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt", 
                                            "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss", 
                                            "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt", 
                                            "M/d/yyyy h:mm", "M/d/yyyy h:mm", 
                                            "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm"};

                        DateTime dt11 = DateTime.ParseExact(measurTime, formats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                        measurTime = dt11.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    catch { }

                    string accel_a = Convert.ToString(dro["accel_a"]);
                    string accel_h = Convert.ToString(dro["accel_h"]);
                    string accel_v = Convert.ToString(dro["accel_v"]);
                    string accel_ch1 = Convert.ToString(dro["accel_ch1"]);

                    string vel_a = Convert.ToString(dro["vel_a"]);
                    string vel_h = Convert.ToString(dro["vel_h"]);
                    string vel_v = Convert.ToString(dro["vel_v"]);
                    string vel_ch1 = Convert.ToString(dro["vel_ch1"]);

                    string dis_a = Convert.ToString(dro["displ_a"]);
                    string dis_h = Convert.ToString(dro["displ_h"]);
                    string dis_v = Convert.ToString(dro["displ_v"]);
                    string dis_ch1 = Convert.ToString(dro["displ_ch1"]);

                    string bear_a = Convert.ToString(dro["bearing_a"]);
                    string bear_h = Convert.ToString(dro["bearing_h"]);
                    string bear_v = Convert.ToString(dro["bearing_v"]);
                    string bear_ch1 = Convert.ToString(dro["bearing_ch1"]);

                    string cf_a = Convert.ToString(dro["crest_factor_a"]);
                    string cf_h = Convert.ToString(dro["crest_factor_h"]);
                    string cf_v = Convert.ToString(dro["crest_factor_v"]);
                    string cf_ch1 = Convert.ToString(dro["crest_factor_ch1"]);

                    string otr_a = Convert.ToString(dro["ordertrace_a_real"]);
                    string otr_h = Convert.ToString(dro["ordertrace_h_real"]);
                    string otr_v = Convert.ToString(dro["ordertrace_v_real"]);
                    string otr_ch1 = Convert.ToString(dro["ordertrace_ch1_real"]);

                    string oti_a = Convert.ToString(dro["ordertrace_a_image"]);
                    string oti_h = Convert.ToString(dro["ordertrace_h_image"]);
                    string oti_v = Convert.ToString(dro["ordertrace_v_image"]);
                    string oti_ch1 = Convert.ToString(dro["ordertrace_ch1_image"]);

                    string rpm = Convert.ToString(dro["ordertrace_Rpm"]);
                    string temp = Convert.ToString(dro["temperature"]);

                    ax = Convert.ToString(dro["A_X"]);
                    ay = Convert.ToString(dro["A_Y"]);
                    hx = Convert.ToString(dro["H_X"]);
                    hy = Convert.ToString(dro["H_Y"]);
                    vx = Convert.ToString(dro["V_X"]);
                    vy = Convert.ToString(dro["V_Y"]);
                    ch1x = Convert.ToString(dro["CH1_X"]);
                    ch1y = Convert.ToString(dro["CH1_Y"]);

                    DataTable dt = DbClass.getdata(CommandType.Text, "Select PointType_ID , PointName from point where Point_ID ='" + PointID + "'");

                    DbClass.executequery(CommandType.Text, "Insert point_data (Point_ID,Point_name,Point_Type, Measure_time,accel_a,accel_h,accel_v,accel_ch1,vel_a,vel_h,vel_v,vel_ch1,displ_a,displ_h,displ_v,displ_ch1,bearing_a,bearing_h,bearing_v,bearing_ch1,crest_factor_a,crest_factor_h,crest_factor_v,crest_factor_ch1,ordertrace_a_real,ordertrace_h_real,ordertrace_v_real,ordertrace_ch1_real,ordertrace_a_image,ordertrace_h_image,ordertrace_v_image,ordertrace_ch1_image,ordertrace_rpm,temperature , IDateTime,PA_X,PA_Y,PH_X,PH_Y,PV_X,PV_Y,PCH1_X,PCH1_Y) values('" + PointID + "','" + dt.Rows[0]["PointName"] + "','" + dt.Rows[0]["PointType_ID"] + "','" + measurTime + "','" + accel_a + "','" + accel_h + "','" + accel_v + "','" + accel_ch1 + "','" + vel_a + "','" + vel_h + "','" + vel_v + "','" + vel_ch1 + "','" + dis_a + "','" + dis_h + "','" + dis_v + "','" + dis_ch1 + "','" + bear_a + "','" + bear_h + "','" + bear_v + "','" + bear_ch1 + "','" + cf_a + "','" + cf_h + "','" + cf_v + "','" + cf_ch1 + "','" + otr_a + "','" + otr_h + "','" + otr_v + "','" + otr_ch1 + "','" + oti_a + "','" + oti_h + "','" + oti_v + "','" + oti_ch1 + "','" + rpm + "','" + temp + "','" + PublicClass.GetDatetime() + "','" + ax + "','" + ay + "','" + hx + "','" + hy + "','" + vx + "','" + vy + "','" + ch1x + "','" + ch1y + "')");
                    DataTable dt1 = DbClass.getdata(CommandType.Text, "Select max(ID) PointName from point_data ");
                    try
                    {
                        DataTable dtTime = DbClass.getdata(CommandType.Text, "Select t.A_X ,t.A_Y,t.H_X , t.H_Y , t.V_X , t.V_Y , t.CH1_X , t.CH1_Y from `" + DBName + "`.data_time t left join `" + DBName + "`.point_record pr on pr.Time = t.DateTime where Point_ID = '" + PtID + "'");
                        foreach (DataRow drtime in dtTime.Rows)
                        {
                            ax = Convert.ToString(drtime["A_X"]);
                            ay = Convert.ToString(drtime["A_Y"]);
                            hx = Convert.ToString(drtime["H_X"]);
                            hy = Convert.ToString(drtime["H_Y"]);
                            vx = Convert.ToString(drtime["V_X"]);
                            vy = Convert.ToString(drtime["V_Y"]);
                            ch1x = Convert.ToString(drtime["CH1_X"]);
                            ch1y = Convert.ToString(drtime["CH1_Y"]);

                            DbClass.executequery(CommandType.Text, "Update point_data set timeA_X = '" + ax + "',timeA_Y = '" + ay + "',timeH_X = '" + hx + "',timeH_Y = '" + hy + "',timeV_X = '" + vx + "',timeV_Y = '" + vy + "' , timeCH1_X = '" + ch1x + "' , timeCH1_Y = '" + ch1y + "' where ID = '" + dt1.Rows[0]["ID"] + "'");
                        }
                    }
                    catch { }

                    try
                    {
                        DataTable dtPower1 = DbClass.getdata(CommandType.Text, "Select dp1.A_X ,dp1.A_Y,dp1.H_X , dp1.H_Y , dp1.V_X , dp1.V_Y , dp1.CH1_X , dp1.CH1_Y from `" + DBName + "`.data_power1 dp1 left join `" + DBName + "`.point_record pr on pr.Time = dp1.DateTime where Point_ID = '" + PtID + "'");
                        foreach (DataRow drpwr in dtPower1.Rows)
                        {
                            ax = Convert.ToString(drpwr["A_X"]);
                            ay = Convert.ToString(drpwr["A_Y"]);
                            hx = Convert.ToString(drpwr["H_X"]);
                            hy = Convert.ToString(drpwr["H_Y"]);
                            vx = Convert.ToString(drpwr["V_X"]);
                            vy = Convert.ToString(drpwr["V_Y"]);
                            ch1x = Convert.ToString(drpwr["CH1_X"]);
                            ch1y = Convert.ToString(drpwr["CH1_Y"]);

                            DbClass.executequery(CommandType.Text, "Update point_data set P1A_X = '" + ax + "',P1A_Y = '" + ay + "',P1H_X = '" + hx + "',P1H_Y = '" + hy + "',P1V_X = '" + vx + "',P1V_Y = '" + vy + "' , P1CH1_X = '" + ch1x + "' , P1CH1_Y = '" + ch1y + "' where ID = '" + dt1.Rows[0]["ID"] + "'");
                        }
                    }
                    catch { }

                    try
                    {
                        DataTable dtPower2 = DbClass.getdata(CommandType.Text, "Select dp2.A_X ,dp2.A_Y,dp2.H_X , dp2.H_Y , dp2.V_X , dp2.V_Y , dp2.CH1_X , dp2.CH1_Y from `" + DBName + "`.data2_power dp2 left join `" + DBName + "`.point_record pr on pr.Time = dp2.DateTime where Point_ID = '" + PtID + "'");
                        foreach (DataRow drpwr2 in dtPower2.Rows)
                        {
                            ax = Convert.ToString(drpwr2["A_X"]);
                            ay = Convert.ToString(drpwr2["A_Y"]);
                            hx = Convert.ToString(drpwr2["H_X"]);
                            hy = Convert.ToString(drpwr2["H_Y"]);
                            vx = Convert.ToString(drpwr2["V_X"]);
                            vy = Convert.ToString(drpwr2["V_Y"]);
                            ch1x = Convert.ToString(drpwr2["CH1_X"]);
                            ch1y = Convert.ToString(drpwr2["CH1_Y"]);

                            DbClass.executequery(CommandType.Text, "Update point_data set P2A_X = '" + ax + "',P2A_Y = '" + ay + "',P2H_X = '" + hx + "',P2H_Y = '" + hy + "',P2V_X = '" + vx + "',P2V_Y = '" + vy + "' , P2CH1_X = '" + ch1x + "' , P2CH1_Y = '" + ch1y + "' where ID = '" + dt1.Rows[0]["ID"] + "'");
                        }
                    }
                    catch { }

                    try
                    {
                        DataTable dtPower21 = DbClass.getdata(CommandType.Text, "Select dp21.A_X ,dp21.A_Y,dp21.H_X , dp21.H_Y , dp21.V_X , dp21.V_Y , dp21.CH1_X , dp21.CH1_Y  from `" + DBName + "`.data2_power1 dp21 left join `" + DBName + "`.point_record pr on pr.Time = d3p.DateTime where Point_ID = '" + PtID + "'");
                        foreach (DataRow drpwr21 in dtPower21.Rows)
                        {
                            ax = Convert.ToString(drpwr21["A_X"]);
                            ay = Convert.ToString(drpwr21["A_Y"]);
                            hx = Convert.ToString(drpwr21["H_X"]);
                            hy = Convert.ToString(drpwr21["H_Y"]);
                            vx = Convert.ToString(drpwr21["V_X"]);
                            vy = Convert.ToString(drpwr21["V_Y"]);
                            ch1x = Convert.ToString(drpwr21["CH1_X"]);
                            ch1y = Convert.ToString(drpwr21["CH1_Y"]);

                            DbClass.executequery(CommandType.Text, "Update point_data set P21A_X = '" + ax + "',P21A_Y = '" + ay + "',P21H_X = '" + hx + "',P21H_Y = '" + hy + "',P21V_X = '" + vx + "',P21V_Y = '" + vy + "' , P21CH1_X = '" + ch1x + "' , P21CH1_Y = '" + ch1y + "' where ID = '" + dt1.Rows[0]["ID"] + "'");
                        }
                    }
                    catch { }

                    try
                    {
                        DataTable dtPower3 = DbClass.getdata(CommandType.Text, "Select d3p.A_X ,d3p.A_Y,d3p.H_X , d3p.H_Y , d3p.V_X , d3p.V_Y , d3p.CH1_X , d3p.CH1_Y from `" + DBName + "`.data3_power d3p left join `" + DBName + "`.point_record pr on pr.Time = dp21.DateTime where Point_ID = '" + PtID + "'");
                        foreach (DataRow drpwr3 in dtPower3.Rows)
                        {
                            ax = Convert.ToString(drpwr3["A_X"]);
                            ay = Convert.ToString(drpwr3["A_Y"]);
                            hx = Convert.ToString(drpwr3["H_X"]);
                            hy = Convert.ToString(drpwr3["H_Y"]);
                            vx = Convert.ToString(drpwr3["V_X"]);
                            vy = Convert.ToString(drpwr3["V_Y"]);
                            ch1x = Convert.ToString(drpwr3["CH1_X"]);
                            ch1y = Convert.ToString(drpwr3["CH1_Y"]);

                            DbClass.executequery(CommandType.Text, "Update point_data set P3A_X = '" + ax + "',P3A_Y = '" + ay + "',P3H_X = '" + hx + "',P3H_Y = '" + hy + "',P3V_X = '" + vx + "',P3V_Y = '" + vy + "' , P3CH1_X = '" + ch1x + "' , P3CH1_Y = '" + ch1y + "' where ID = '" + dt1.Rows[0]["ID"] + "'");
                        }
                    }
                    catch { }

                    try
                    {
                        DataTable dtPower31 = DbClass.getdata(CommandType.Text, "Select d3p1.A_X ,d3p1.A_Y,d3p1.H_X , d3p1.H_Y , d3p1.V_X , d3p1.V_Y , d3p1.CH1_X , d3p1.CH1_Y from `" + DBName + "`.data3_power1 d3p1 left join `" + DBName + "`.point_record pr on pr.Time = d3p1.DateTime where Point_ID = '" + PtID + "'");
                        foreach (DataRow drpwr31 in dtPower31.Rows)
                        {
                            ax = Convert.ToString(drpwr31["A_X"]);
                            ay = Convert.ToString(drpwr31["A_Y"]);
                            hx = Convert.ToString(drpwr31["H_X"]);
                            hy = Convert.ToString(drpwr31["H_Y"]);
                            vx = Convert.ToString(drpwr31["V_X"]);
                            vy = Convert.ToString(drpwr31["V_Y"]);
                            ch1x = Convert.ToString(drpwr31["CH1_X"]);
                            ch1y = Convert.ToString(drpwr31["CH1_Y"]);

                            DbClass.executequery(CommandType.Text, "Update point_data set P31A_X = '" + ax + "',P31A_Y = '" + ay + "',P31H_X = '" + hx + "',P31H_Y = '" + hy + "',P31V_X = '" + vx + "',P31V_Y = '" + vy + "' , P31CH1_X = '" + ch1x + "' , P31CH1_Y = '" + ch1y + "' where ID = '" + dt1.Rows[0]["ID"] + "'");
                        }
                    }
                    catch { }

                    try
                    {
                        DataTable dtPower31 = DbClass.getdata(CommandType.Text, "Select d3p1.A_X ,d3p1.A_Y,d3p1.H_X , d3p1.H_Y , d3p1.V_X , d3p1.V_Y , d3p1.CH1_X , d3p1.CH1_Y from `" + DBName + "`.data3_power1 d3p1 left join `" + DBName + "`.point_record pr on pr.Time = d3p1.DateTime where Point_ID = '" + PtID + "'");
                        foreach (DataRow drpwr31 in dtPower31.Rows)
                        {
                            ax = Convert.ToString(drpwr31["A_X"]);
                            ay = Convert.ToString(drpwr31["A_Y"]);
                            hx = Convert.ToString(drpwr31["H_X"]);
                            hy = Convert.ToString(drpwr31["H_Y"]);
                            vx = Convert.ToString(drpwr31["V_X"]);
                            vy = Convert.ToString(drpwr31["V_Y"]);
                            ch1x = Convert.ToString(drpwr31["CH1_X"]);
                            ch1y = Convert.ToString(drpwr31["CH1_Y"]);

                            DbClass.executequery(CommandType.Text, "Update point_data set P31A_X = '" + ax + "',P31A_Y = '" + ay + "',P31H_X = '" + hx + "',P31H_Y = '" + hy + "',P31V_X = '" + vx + "',P31V_Y = '" + vy + "' , P31CH1_X = '" + ch1x + "' , P31CH1_Y = '" + ch1y + "' where ID = '" + dt1.Rows[0]["ID"] + "'");
                        }
                    }
                    catch { }

                    try
                    {
                        DataTable dtCep = DbClass.getdata(CommandType.Text, "Select cep.A_X ,cep.A_Y,cep.H_X , cep.H_Y , cep.V_X , cep.V_Y , cep.CH1_X , cep.CH1_Y from `" + DBName + "`.data_cepstrum cep left join `" + DBName + "`.point_record pr on pr.Time = cep.DateTime where Point_ID = '" + PtID + "'");
                        foreach (DataRow drCep in dtCep.Rows)
                        {
                            ax = Convert.ToString(drCep["A_X"]);
                            ay = Convert.ToString(drCep["A_Y"]);
                            hx = Convert.ToString(drCep["H_X"]);
                            hy = Convert.ToString(drCep["H_Y"]);
                            vx = Convert.ToString(drCep["V_X"]);
                            vy = Convert.ToString(drCep["V_Y"]);
                            ch1x = Convert.ToString(drCep["CH1_X"]);
                            ch1y = Convert.ToString(drCep["CH1_Y"]);

                            DbClass.executequery(CommandType.Text, "Update point_data set CEPA_X = '" + ax + "',CEPA_Y = '" + ay + "',CEPH_X = '" + hx + "',CEPH_Y = '" + hy + "',CEPV_X = '" + vx + "',CEPV_Y = '" + vy + "' , CEPCH1_X = '" + ch1x + "' , CEPCH1_Y = '" + ch1y + "' where ID = '" + dt1.Rows[0]["ID"] + "'");
                        }
                    }
                    catch { }

                    try
                    {
                        DataTable dtDemo = DbClass.getdata(CommandType.Text, "Select demo.A_X ,demo.A_Y,demo.H_X , demo.H_Y , demo.V_X , demo.V_Y , demo.CH1_X , demo.CH1_Y from `" + DBName + "`.data_demodulate demo left join `" + DBName + "`.point_record pr on pr.Time = demo.DateTime where Point_ID = '" + PtID + "'");
                        foreach (DataRow drdem in dtDemo.Rows)
                        {
                            ax = Convert.ToString(drdem["A_X"]);
                            ay = Convert.ToString(drdem["A_Y"]);
                            hx = Convert.ToString(drdem["H_X"]);
                            hy = Convert.ToString(drdem["H_Y"]);
                            vx = Convert.ToString(drdem["V_X"]);
                            vy = Convert.ToString(drdem["V_Y"]);
                            ch1x = Convert.ToString(drdem["CH1_X"]);
                            ch1y = Convert.ToString(drdem["CH1_Y"]);

                            DbClass.executequery(CommandType.Text, "Update point_data set DEMA_X = '" + ax + "',DEMA_Y = '" + ay + "',DEMH_X = '" + hx + "',DEMH_Y = '" + hy + "',DEMV_X = '" + vx + "',DEMV_Y = '" + vy + "' , DEMCH1_X = '" + ch1x + "' , DEMCH1_Y = '" + ch1y + "' where ID = '" + dt1.Rows[0]["ID"] + "'");
                        }
                    }
                    catch { }

                }

            }
            catch { }
            return DBName;
        }

        public string ConvertNotes(string DBName)
        {
            try
            {
                DataTable dtNotes = DbClass.getdata(CommandType.Text, "Select * from `" + DBName + "`.kribhconote1");
                foreach (DataRow dr in dtNotes.Rows)
                {
                    string notes = Convert.ToString(dr["notes"]).Trim();
                    DbClass.executequery(CommandType.Text, "insert into notes(Notes_Desc , Note_Type , Date) values('" + notes + "','2','" + PublicClass.GetDatetime() + "')");

                }

                DataTable dtNote2 = DbClass.getdata(CommandType.Text, "Select p.PointPosition , pr.Note1 , pr.Note2 from `" + DBName + "`.point_record pr left join `" + DBName + "`.point p on p.UID = pr.Point_Id");
                foreach (DataRow dr1 in dtNote2.Rows)
                {
                    string pointID = Convert.ToString(dr1["PointPosition"]);
                    string Note1 = Convert.ToString(dr1["Note1"]);
                    string Note2 = Convert.ToString(dr1["Note2"]);
                    DataTable dt1 = DbClass.getdata(CommandType.Text, "Select Notes_ID from notes where Notes_Desc ='" + Note1 + "'");
                    DataTable dt2 = DbClass.getdata(CommandType.Text, "Select Note_ID from point_note2 where Point_Id ='" + pointID + "'");

                    DbClass.executequery(CommandType.Text, "Update point_data set Notes1 = '" + Convert.ToString(dt1.Rows[0]["Notes_ID"]) + "' , Notes2 = '" + Convert.ToString(dt2.Rows[0]["Note_ID"]) + "' where Point_Id = '" + pointID + "' ");

                }

            }
            catch { }

            return DBName;
        }

        private void txtNewDB_KeyPress(object sender, KeyPressEventArgs e)
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