using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data .SqlClient ;
using System.Configuration;
using System.Data.Odbc;
using System.Xml;
using Iadeptmain.GlobalClasses;
using System.Net;
using System.Text.RegularExpressions;
using Iadeptmain.Mainforms;

namespace Iadeptmain.GlobalClasses
{
    
  public  class PublicClass
    {
        public static OdbcConnection conn = new OdbcConnection();
        public static int a, actualspeed;
        public static string servername, databasename, uid, pwd;
        public static string servername1, databasename1, uid1, pwd1;
       public static string factoryName,factoryID;
       public static DataTable factoryadd = new DataTable();
       public static int factoryaddid, CurrentLevel;
       public static DataTable ResourcAddNode = new DataTable();
       public static DataTable ElementAddNode = new DataTable();
       public static DataTable SubElementAddNode = new DataTable();
       public static DataTable PointAddNode = new DataTable();
       public static Boolean LoginStatus, checkgraph, ReportStatus, flag, flagAlarm, trendbool,zoom, overlaybool, Axialoverlap, horoverlap, veroverlap, chanoverlap;
       public static string User_Name, checkname,chkcurrent, Routelevel, checkphase, User_IP,XMin,XMax, finalpath, chartscale, StartingDate, EndDate, AlarmName, CurrentMachineID, CurrentPlantID, CurrentAreaID, CurrentTrainID, checkdirection, text, sensordirtype, TimeV, footername, Description, User_DataBase, Power1, GraphClicked, lastDigraph, User_DataSource, uName, uPassword, uDataBase, uID, cUserName, cPassword, cUID, AHVCH1, Gtrend, x_Unit, y_Unit, Chart_Footer;
       public static double[] darrXData, darrYData, darrtrendX, darrtrendY;
       public static string SFactoryID, SAreaID,checkpole, Data_ID,Path, ReportName,pointIDs,checkparent, STrainID,nodelevel,checkgraphtime, currentInstrument,InstrumentSerial, designStyle, ColorStyle, fontStyle, cDataBaseName, sBkpDBName, SMachineID, SPointID, SPointTypeId, sdfconnection, routename, ssNodeType, pointtext, tym, graphname,graphtym, timeimage, powerimage, power1image, power2image, power21image, power3image, power31image, demoimage, cepimage, trendimage;
       public static string NodeNAmne = null;
       public static double Xline, Yline;
       public static string LevelName = null;
       public static string RouteId = null;
       public static Image FAlarmImage;
           
       public static void set_enter(TextBox t)
       {
           t.SelectionStart = 0;
           t.SelectionLength = t.TextLength;
           t.BackColor = Color.PapayaWhip;
       }
        public static void set_leave(TextBox t)
        {
            t.Text = t.Text.ToUpper();
            t.SelectionStart = 0;
            t.SelectionLength = 0;
            t.BackColor = Color.White;
        }
        public static void set_comboenter(ComboBox c)
        {
            try
            {
                c.SelectionStart = 0;
                c.SelectionLength = c.SelectedText.Length;
                c.BackColor = Color.PapayaWhip;
            }
            catch (Exception)
            { }
            
        }
        public static void SeteUserSettings(ref  bool P_add, ref bool P_del, ref bool P_mod, ref bool P_rView, ref bool P_UD, string tabName)
        {
            try
            {
                DataTable dt1 = new DataTable();
                dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  Addition,Deletion,Modification,ReportView,UpDown FROM usersettings where UserDetailID = '" + PublicClass.cUID + "'  and TabName= '" + tabName.Trim() + "'  ");
                foreach (DataRow dr in dt1.Rows)
                {
                    P_add = Convert.ToBoolean(dr["Addition"]);
                    P_del = Convert.ToBoolean(dr["Deletion"]);
                    P_mod = Convert.ToBoolean(dr["Modification"]);
                    P_rView = Convert.ToBoolean(dr["ReportView"]);
                    P_UD = Convert.ToBoolean(dr["UpDown"]);

                }
            }
            catch { }
        }


        public static void set_comboleave(ComboBox c)
        {
            try
            {
                c.SelectionStart = 0;
                c.SelectionLength = 0;
                c.BackColor = Color.White;
            }
            catch (Exception)
            { }

           }
        public static void set_checked(CheckBox c)
        {
            if (c.Checked == true)
            {
                c.Text = "Yes";
            }
            else
            {
                c.Text = "No";
            }
        }
        public static int  get_checkboxValue(CheckBox c)
        {
            int i = 0;
            if (c.Checked == true)
            {
                i = 1;
            }
            else
            {
                i = 0;
            }

            return i;
        }
        public static void set_checkboxValue(CheckBox c, int i)
        {

            if (i == 1)
            {
                c.Checked = true;
            }
            else
            {
                c.Checked = false;
            }
        }
        #region set default value
        public static string DefVal(object VAR, string defvalue)
        {
            string val = "";
            if (VAR == System.DBNull.Value)
            {
                val = defvalue;
            }
            else if (Convert.ToString(VAR) == "")
            {
                val = defvalue;
            }
            else
            {
                val = Convert.ToString(VAR);
            }

            return val;
        }
        #endregion

        public static bool chkKeyEnter(KeyPressEventArgs e)
        {
            bool sts = false;
            try
            {
                var regex = new Regex(@"[a-zA-Z0-9]");
                if (regex.IsMatch(e.KeyChar.ToString()))
                {
                    sts = true;
                }
                else if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
                {
                    sts = true;
                }
                else if (e.KeyChar == '-')
                {
                    sts = true;
                }
                else if (e.KeyChar == '_')
                {
                    sts = true;
                }
                else if (e.KeyChar == '(')
                {
                    sts = true;
                }
                else if (e.KeyChar == ')')
                {
                    sts = true;
                }
                else if (e.KeyChar == '+')
                {
                    sts = true;
                }
                else if (e.KeyChar == '=')
                {
                    sts = true;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch { }
            return sts;
        }

        public static bool chkTxtboxKey(KeyPressEventArgs e)
        {
            bool sts = false;
            try
            {
                var regex = new Regex(@"[a-zA-Z0-9]");
                if (((regex.IsMatch(e.KeyChar.ToString())) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == Convert.ToChar(Keys.Delete)) && (e.KeyChar != '.'))
                {
                    sts = true;
                }
                else
                {
                }
            }
            catch { }
            return sts;
        }
        #region Initilization of Connection
        public static bool CheckForSpecialCharacter(string Name)
        {
            bool bC = false;
            try
            {
                if (Name.Contains("~"))
                {
                    bC = true;
                }
                else if (Name.Contains("`"))
                {
                    bC = true;
                }
                else if (Name.Contains("!"))
                {
                    bC = true;
                }
                else if (Name.Contains("@"))
                {
                    bC = true;
                }
                else if (Name.Contains("#"))
                {
                    bC = true;
                }
                else if (Name.Contains("$"))
                {
                    bC = true;
                }
                else if (Name.Contains("%"))
                {
                    bC = true;
                }
                else if (Name.Contains("^"))
                {
                    bC = true;
                }
                else if (Name.Contains("&"))
                {
                    bC = true;
                }
                else if (Name.Contains("*"))
                {
                    bC = true;
                }
                else if (Name.Contains("+"))
                {
                    bC = true;
                }
                else if (Name.Contains("="))
                {
                    bC = true;
                }
                else if (Name.Contains("|"))
                {
                    bC = true;
                }
                else if (Name.Contains("/"))
                {
                    bC = true;
                }
                else if (Name.Contains("<"))
                {
                    bC = true;
                }
                else if (Name.Contains(">"))
                {
                    bC = true;
                }
                else if (Name.Contains(","))
                {
                    bC = true;
                }
                else if (Name.Contains("_"))
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

        public static void CreateConnection(string db)
        {
            try
            {
                PublicClass.User_DataBase = db;
              // PublicClass.conn.ConnectionString = "DRIVER= {MySQL ODBC 3.51 Driver}; server= localhost; Database= " + PublicClass.User_DataBase.Trim() + "; User=root";
                PublicClass.conn.ConnectionString = "DRIVER= {MySQL ODBC 3.51 Driver}; server= localhost; Database= " + PublicClass.User_DataBase.Trim() + "; User=root; password=1234";
               // PublicClass.conn.ConnectionString = "DRIVER= {MySQL ODBC 5.1 Driver}; server= localhost; Database= " + PublicClass.User_DataBase.Trim() + "; User=root; password=1234; OPTION=3;";
              
               //PublicClass.conn.ConnectionString = "DRIVER= {MySQL ODBC 5.3 ANSI Driver}; server= localhost; Database= " + PublicClass.User_DataBase.Trim() + "; User=root; password=1234";
            }
            catch { }
        }

        public static void CreateConnection(string ser, string db, string id, string pwd)
        {
            try
            {
                servername = ser;
                databasename = db;
                uid = id;
                pwd = " ";


                if (PublicClass.conn.State == ConnectionState.Open)
                {
                    PublicClass.conn.Close();

                }
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                //connectionStringsSection.ConnectionStrings["ConnectionString"].ConnectionString = "DRIVER= {MySQL ODBC 3.51 Driver};server=" + servername.ToString().Trim() + ";uid=" + uid + ";pwd= " + pwd + ";database=" + databasename + ";";
                connectionStringsSection.ConnectionStrings["ConnectionString"].ConnectionString = "DRIVER= {MySQL ODBC 3.51 Driver};server=" + servername.ToString().Trim() + ";uid=" + uid + ";pwd= " + pwd + ";database=" + databasename + ";";
                config.Save();
                ConfigurationManager.RefreshSection("ConnectionString");
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            catch { }
        }
            

        #endregion

        #region Set Validation
        public static void only_no(KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public static void only_numeric(KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '+')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public static void only_char(KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public static void NoSpacing(KeyPressEventArgs e)
        {
            if (e.KeyChar==32)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        #endregion

        public static void statusbar(ToolStripProgressBar pbName)
        {
            try
            {
                a = pbName.Value;
                if (a > 100)
                    a = 0;
                pbName.Value = a + 1;
            }
            catch { }
        }
        public static string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();

        }
        public static string GetDatetime()
        {
            string ss = "";
            try
            {
                 ss = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch {}
            return ss; 
        }

        public static bool ValidateDatabase(string Name)
        {
            bool temp = false;

            if (Name.All(char.IsLetterOrDigit) || Name.Any(char.IsLetter) || !Name.All(char.IsDigit))
            {
                if (Name.All(char.IsLetterOrDigit) && Name.Any(char.IsLetter))
                {
                    temp = true;
                }
            }
            return temp;
        }
    }
}
