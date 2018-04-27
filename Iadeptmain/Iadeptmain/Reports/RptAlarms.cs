using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Reports
{
    public partial class RptAlarms : DevExpress.XtraReports.UI.XtraReport
    {
        public RptAlarms()
        {
            InitializeComponent();
        }

        private void xrTableCell19_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select accel_a1,accel_a2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell19.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["accel_a2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["accel_a1"]);

                if(accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell19.BackColor = Color.Red;

                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell19.BackColor = Color.Yellow;

                    }
                    else
                    {
                        xrTableCell19.BackColor = Color.PaleGreen;

                    }
                }
                else
                {
                    xrTableCell19.BackColor = Color.PaleGreen;
                }
               
            }
            catch { }
        }

        private void xrTableCell22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select accel_h1,accel_h2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell22.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["accel_h2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["accel_h1"]);

                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell22.BackColor = Color.Red;

                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell22.BackColor = Color.Yellow;

                    }
                    else
                    {
                        xrTableCell22.BackColor = Color.PaleGreen;

                    }
                }
                else
                {
                    xrTableCell22.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell26_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select accel_v1,accel_v2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell26.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["accel_v2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["accel_v1"]);

                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell26.BackColor = Color.Red;

                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell26.BackColor = Color.Yellow;

                    }
                    else
                    {
                        xrTableCell26.BackColor = Color.PaleGreen;

                    }
                }
                else
                {
                    xrTableCell26.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell42_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select accel_ch11,accel_ch12 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell42.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["accel_ch12"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["accel_ch11"]);
                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell42.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell42.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell42.BackColor = Color.PaleGreen;
                    }  
                }
                else
                {
                    xrTableCell42.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select vel_a1,vel_a2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell1.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["vel_a2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["vel_a1"]);
                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell1.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell1.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell1.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell1.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell51_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select vel_h1,vel_h2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell51.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["vel_h2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["vel_h1"]);
                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell51.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell51.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell51.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell51.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select vel_v1,vel_v2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell17.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["vel_v2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["vel_v1"]);
                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell17.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell17.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell17.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell17.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell43_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select vel_ch11,vel_ch12 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell43.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["vel_ch12"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["vel_ch11"]);
                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell43.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell43.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell43.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell43.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select displ_a1,displ_a2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell16.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["displ_a2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["displ_a1"]);
                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell16.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell16.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell16.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell16.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select displ_h1,displ_h2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell28.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["displ_h2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["displ_h1"]);
                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell28.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell28.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell28.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell28.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select displ_v1,displ_v2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell2.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["displ_v2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["displ_v1"]);

                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell2.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell2.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell2.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell2.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell44_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select displ_ch11,displ_ch12 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell44.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["displ_ch12"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["displ_ch11"]);
                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell44.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell44.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell44.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell44.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell23_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select bearing_a1,bearing_a2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell23.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["bearing_a2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["bearing_a1"]);

                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell23.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell23.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell23.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell23.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select bearing_h1,bearing_h2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell18.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["bearing_h2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["bearing_h1"]);
                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell18.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell18.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell18.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell18.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select bearing_v1,bearing_v2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell20.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["bearing_v2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["bearing_v1"]);

                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell20.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell20.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell20.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell20.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell45_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select bearing_ch12,bearing_ch11 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell45.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["bearing_ch12"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["bearing_ch11"]);

                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell45.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell45.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell45.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell45.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

        private void xrTableCell3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                string AlarmName = Convert.ToString(xrTableCell21.Text);
                DataTable dtacc = DbClass.getdata(CommandType.Text, "Select temperature_1,temperature_2 from alarms_data where Alarm_Name = '" + AlarmName + "'");
                double faccel_a = Convert.ToDouble(xrTableCell3.Text);
                double accvalLow = Convert.ToDouble(dtacc.Rows[0]["temperature_2"]);
                double accvalHigh = Convert.ToDouble(dtacc.Rows[0]["temperature_1"]);
                if (accvalLow != 0.0 && accvalHigh != 0.0)
                {
                    if (accvalLow < faccel_a && faccel_a >= accvalHigh)
                    {
                        xrTableCell3.BackColor = Color.Red;
                    }
                    else if (accvalLow < faccel_a && faccel_a < accvalHigh)
                    {
                        xrTableCell3.BackColor = Color.Yellow;
                    }
                    else
                    {
                        xrTableCell3.BackColor = Color.PaleGreen;
                    }
                }
                else
                {
                    xrTableCell3.BackColor = Color.PaleGreen;
                }
            }
            catch { }
        }

    }
}
