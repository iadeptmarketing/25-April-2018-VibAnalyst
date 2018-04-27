using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Iadeptmain.Mainforms
{
    
    public partial class NewAlarm : DevExpress.XtraEditors.XtraForm
    {

        float accel_a1 = 0;
        float accel_h1 = 0;
        float accel_v1 = 0;
        float accel_a2 = 0;
        float accel_h2 = 0;
        float accel_v2 = 0;

        float vel_a1 = 0;
        float vel_h1 = 0;
        float vel_v1 = 0;
        float vel_a2 = 0;
        float vel_h2 = 0;
        float vel_v2 = 0;

        float displ_a1 = 0;
        float displ_h1 = 0;
        float displ_v1 = 0;
        float displ_a2 = 0;
        float displ_h2 = 0;
        float displ_v2 = 0;

        float bearing_a1 = 0;
        float bearing_h1 = 0;
        float bearing_v1 = 0;
        float bearing_a2 = 0;
        float bearing_h2 = 0;
        float bearing_v2 = 0;

        float temperature_1 = 0;
        float temperature_2 = 0;

        float crestfactor_a1 = 0;
        float crestfactor_h1 = 0;
        float crestfactor_v1 = 0;
        float crestfactor_a2 = 0;
        float crestfactor_h2 = 0;
        float crestfactor_v2 = 0;

        string sAlarmName = null;

        public NewAlarm()
        {
            InitializeComponent();
           
            txtAlarmname.KeyUp += new KeyEventHandler(txtAlarmname_KeyUp);
            
        }
        int PointPressCtrPtd = 0;
        void txtAlarmname_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        public float AccA1
        {
            get
            {
                return accel_a1;
            }
            set
            {
                accel_a1 = value;
            }
        }

        public float AccA2
        {
            get
            {
                return accel_a2;
            }
            set
            {
                accel_a2 = value;
            }
        }

        public float AccH1
        {
            get
            {
                return accel_h1;
            }
            set
            {
                accel_h1 = value;
            }
        }

        public float AccH2
        {
            get
            {
                return accel_h2;
            }
            set
            {
                accel_h2 = value;
            }
        }

        public float AccV1
        {
            get
            {
                return accel_v1;
            }
            set
            {
                accel_v1 = value;
            }
        }

        public float AccV2
        {
            get
            {
                return accel_v2;
            }
            set
            {
                accel_v2 = value;
            }
        }

        public float VelA1
        {
            get
            {
                return vel_a1;
            }
            set
            {
                vel_a1 = value;
            }
        }

        public float VelA2
        {
            get
            {
                return vel_a2;
            }
            set
            {
                vel_a2 = value;
            }
        }

        public float VelH1
        {
            get
            {
                return vel_h1;
            }
            set
            {
                vel_h1 = value;
            }
        }

        public float VelH2
        {
            get
            {
                return vel_h2;
            }
            set
            {
                vel_h2 = value;
            }
        }

        public float VelV1
        {
            get
            {
                return vel_v1;
            }
            set
            {
                vel_v1 = value;
            }
        }

        public float VelV2
        {
            get
            {
                return vel_v2;
            }
            set
            {
                vel_v2 = value;
            }
        }

        public float DispA1
        {
            get
            {
                return displ_a1;
            }
            set
            {
                displ_a1 = value;
            }
        }

        public float DispA2
        {
            get
            {
                return displ_a2;
            }
            set
            {
                displ_a2 = value;
            }
        }

        public float DispH1
        {
            get
            {
                return displ_h1;
            }
            set
            {
                displ_h1 = value;
            }
        }

        public float DispH2
        {
            get
            {
                return displ_h2;
            }
            set
            {
                displ_h2 = value;
            }
        }

        public float DispV1
        {
            get
            {
                return displ_v1;
            }
            set
            {
                displ_v1 = value;
            }
        }

        public float DispV2
        {
            get
            {
                return displ_v2;
            }
            set
            {
                displ_v2 = value;
            }
        }

        public float BearingA1
        {
            get
            {
                return bearing_a1;
            }
            set
            {
                bearing_a1 = value;
            }
        }

        public float BearingA2
        {
            get
            {
                return bearing_a2;
            }
            set
            {
                bearing_a2 = value;
            }
        }

        public float BearingH1
        {
            get
            {
                return bearing_h1;
            }
            set
            {
                bearing_h1 = value;
            }
        }

        public float BearingH2
        {
            get
            {
                return bearing_h2;
            }
            set
            {
                bearing_h2 = value;
            }
        }

        public float BearingV1
        {
            get
            {
                return bearing_v1;
            }
            set
            {
                bearing_v1 = value;
            }
        }

        public float BearingV2
        {
            get
            {
                return bearing_v2;
            }
            set
            {
                bearing_v2 = value;
            }
        }

        public float Temperature1
        {
            get
            {
                return temperature_1;
            }
            set
            {
                temperature_1 = value;
            }
        }

        public float Temperature2
        {
            get
            {
                return temperature_2;
            }
            set
            {
                temperature_2 = value;
            }
        }

        public string AlarmName
        {
            get
            {
                return sAlarmName;
            }
            set
            {
                sAlarmName = value;
            }
        }

        public float crestfactorA1
        {
            get
            {
                return crestfactor_a1;
            }
            set
            {
                crestfactor_a1 = value;
            }
        }

        public float crestfactorA2
        {
            get
            {
                return crestfactor_a2;
            }
            set
            {
                crestfactor_a2 = value;
            }
        }

        public float crestfactorH1
        {
            get
            {
                return crestfactor_h1;
            }
            set
            {
                crestfactor_h1 = value;
            }
        }

        public float crestfactorH2
        {
            get
            {
                return crestfactor_h2;
            }
            set
            {
                crestfactor_h2 = value;
            }
        }

        public float crestfactorV1
        {
            get
            {
                return crestfactor_v1;
            }
            set
            {
                crestfactor_v1 = value;
            }
        }

        public float crestfactorV2
        {
            get
            {
                return crestfactor_v2;
            }
            set
            {
                crestfactor_v2 = value;
            }
        }

        string sErrorLogPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
        FileStream aa = null;
        StreamWriter sw = null;
        Alarms _objAlarms = new Alarms();
        frmIAdeptMain objMain = null;

        public frmIAdeptMain Main
        {
            get
            {
                return objMain;
            }
            set
            {
                objMain = value;
            }
        }

        private bool CheckForSpecialCharacter(string Name)
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
                return bC;

            }
            catch (Exception ex)
            {
                return bC;
            }
        }

        private void ErrorLogFile(Exception ex)
        {
            try
            {
                if (ex.Message == "Exception of type 'System.OutOfMemoryException' was thrown.")
                {
                    MessageBox.Show("System Memory is low. Please Close Some Applications and Try again", "Low Memory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (!File.Exists(sErrorLogPath + "\\FMErrorLog.txt"))
                {
                    aa = new FileStream(sErrorLogPath + "\\FMErrorLog.txt", FileMode.Create, FileAccess.ReadWrite);
                }
                else
                {
                    aa = new FileStream(sErrorLogPath + "\\FMErrorLog.txt", FileMode.Append, FileAccess.Write);
                }
                sw = new StreamWriter(aa);
                sw.WriteLine(ex.Message + "      " + ex.StackTrace + "          " + System.DateTime.Now.ToString("MM/dd/yyyy HH:m:s tt"));
                sw.Close();
            }
            catch (Exception ex1)
            {
            }

        }

        private void txtAlarmname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && char.IsWhiteSpace(e.KeyChar) && !(e.KeyChar == '-') && !(e.KeyChar == '_') && !(e.KeyChar == '\b');
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            string sErrorVariable = null;
            bool bNegetive = false;

            try
            {

                string sFalName = txtAlarmname.Text.ToString().TrimStart(' ');
                sFalName = sFalName.TrimEnd(' ');
                if (!string.IsNullOrEmpty(sFalName))
                {
                    if (sFalName.Length > 8)
                    {
                        MessageBox.Show("Alarm Name should not be more than 8 characters");
                    }
                    else
                    {
                        this.AlarmName = sFalName;
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Alarm name not entered");
                }

            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);

                MessageBox.Show("Values not Correct for Alarm at " + "\n" + sErrorVariable, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            try
            {

                _objAlarms.CallCancel();
                this.Close();
            }
            catch (Exception ex)
            {
                //ErrorLogFile(ex);
                //System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        
    }
}