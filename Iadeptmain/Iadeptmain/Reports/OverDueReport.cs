using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Iadeptmain.GlobalClasses;
using System.Data.SqlClient;
using Iadeptmain.BaseUserControl;
using System.Data;

namespace Iadeptmain.Reports
{
    public partial class OverDueReport : DevExpress.XtraReports.UI.XtraReport
    {
        public OverDueReport()
        {
            InitializeComponent();
        }

        private string countdays(DateTime ToYear, DateTime FromYear)
        {
            string count = null;
            try
            {
                int Years = ToYear.Year - FromYear.Year;

                int month = ToYear.Month - FromYear.Month;

                int TotalMonths = (Years * 12) + month;

                TimeSpan objTimeSpan = ToYear - FromYear;
                //Total Hours  
                double TotalHours = objTimeSpan.TotalHours;
                //Total Minutes  
                double TotalMinutes = objTimeSpan.TotalMinutes;
                //Total Seconds  
                double TotalSeconds = objTimeSpan.TotalSeconds;
                //Total Mile Seconds  
                double TotalMileSeconds = objTimeSpan.TotalMilliseconds;

                //Assining values to td tags  
                double Days = Convert.ToDouble(objTimeSpan.TotalDays);
                count = Convert.ToString(Days);
            }
            catch { }
            return count;
        }


        private void xrTableCell10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = DbClass.getdata(CommandType.Text, "SELECT  distinct  p.pointname,p.point_id ,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id group by p.point_id");
                foreach (DataRow dr in dtData.Rows)
                {
                    string sPointID = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                    DataTable dt = DbClass.getdata(CommandType.Text, "SELECT p.Point_ID,p.pointname, p.PointDesc,p.PointType_ID , p.DataSchedule , max(pd.Measure_time) as Measure_time FROM POINT p inner join point_data pd  on p.Point_ID = pd.Point_ID where p.Point_ID='" + sPointID + "' group by pd.point_id");

                    DateTime currentDate = new DateTime();
                    currentDate = DateTime.Today;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            string dtSchedule = Convert.ToString(dr1["DataSchedule"]);
                            string LastDate = Convert.ToString(dr1["Measure_time"]);

                            DateTime FromYear = Convert.ToDateTime(currentDate);
                            DateTime ToYear = Convert.ToDateTime(LastDate);
                            string DueD = countdays(FromYear, ToYear);
                            double DueDays = Math.Round(Convert.ToDouble(DueD), 0);
                            string DueDay = Convert.ToString(DueDays);
                            string[] ssize = dtSchedule.Split();
                            int TotalDays = 0;
                            switch (ssize[1])
                            {
                                case "Days":
                                    TotalDays = Convert.ToInt32(ssize[0]);
                                    break;
                                case "Weeks":
                                    TotalDays = 7 * Convert.ToInt32(ssize[0]);
                                    break;
                                case "Months":
                                    TotalDays = 30 * Convert.ToInt32(ssize[0]);
                                    break;
                                case "Years":
                                    TotalDays = 365 * Convert.ToInt32(ssize[0]);
                                    break;
                            }
                            if (DueDays >= TotalDays)
                            {
                                xrTableCell10.BackColor = Color.Red;
                            }
                            else
                            {
                                xrTableCell10.BackColor = Color.Green;
                            }

                        }
                    }
                }
            }
            catch { }
        }

    }
}
