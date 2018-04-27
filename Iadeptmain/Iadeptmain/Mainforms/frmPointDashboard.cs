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
using DevExpress.XtraCharts;

namespace Iadeptmain.Mainforms
{
    public partial class frmPointDashboard : DevExpress.XtraEditors.XtraForm
    {
        frmDashboardRibbon objmainDash = null;
        public frmDashboardRibbon DashMain
        {
            get
            {
                return objmainDash;
            }

            set
            {
                objmainDash = value;

            }
        }


        public frmPointDashboard()
        {
            InitializeComponent();
            Create_TreeListColumn();
        }
       

        string SelectedPoint = null;
        string Point_ID = null;
        public void Create_TreeListColumn()
        {
            try
            {
                trlDashboard.Columns.Add();
                trlDashboard.Columns[0].Caption = "Id";
                trlDashboard.Columns[0].VisibleIndex = -1;

                trlDashboard.Columns.Add();
                trlDashboard.Columns[1].Caption = "";
                trlDashboard.Columns[1].VisibleIndex = 0;

                trlDashboard.Columns.Add();
                trlDashboard.Columns[2].Caption = "Description";
                trlDashboard.Columns[2].VisibleIndex = -1;

            }
            catch { }

        }

        public void fillPointyList(string CurrentMachineID)
        {
            try
            {
                DataTable PointDT = DbClass.getdata(CommandType.Text, "select distinct p.Point_ID,p.PointName,p.PointDesc from  point p inner join point_data pd on p.Point_ID = pd.Point_ID where p.Machine_ID ='" + PublicClass.CurrentMachineID + "' order by p.Point_ID");

                foreach (DataRow PointRow in PointDT.Rows)
                {
                    trlDashboard.AppendNode(new object[] { Convert.ToString(PointRow["Point_ID"]), Convert.ToString(PointRow["PointName"]), Convert.ToString(PointRow["PointDesc"]) }, null);
                }
                SelectedPoint = Convert.ToString(PointDT.Rows[0]["PointName"]);
                Point_ID = Convert.ToString(PointDT.Rows[0]["Point_ID"]);
                FillGriddata();
                alldatabargraph(Point_ID);              
                if (SelectedPoint == null || SelectedPoint == "")
                {
                }
                else 
                {
                    objmainDash.bbstatus.Caption = "Opening Point Level";
                    trlDashboard.ExpandAll();
                }
            }
            catch
            {

            }
        }
        double[] serData = null;
        DataTable dtforGrid = new DataTable();
        public void alldatabargraph(string pointID)
        {
            serData = new double[3];          
            try
            {
                dtforGrid = DbClass.getdata(CommandType.Text, "Select distinct pd.*,tp.Alarm_ID,al.* from point_Data pd left join type_point tp on pd.Point_Type=tp.ID left join alarms_data al on tp.Alarm_ID=al.Alarm_ID where point_ID = '" + pointID + "' and measure_time in(Select max(measure_time) from point_data where point_ID = '" + pointID + "')");
                foreach (DataRow dracc in dtforGrid.Rows)
                {
                    dtForData.Rows.Add("Acceleration", Convert.ToString(dracc["Measure_time"]), Math.Round((Convert.ToDouble(dracc["accel_a"])), 3), Math.Round((Convert.ToDouble(dracc["accel_h"])), 3), Math.Round((Convert.ToDouble(dracc["accel_v"])), 3), Math.Round((Convert.ToDouble(dracc["accel_ch1"])), 3));
                    dtForData.Rows.Add("Velocity", Convert.ToString(dracc["Measure_time"]), Math.Round((Convert.ToDouble(dracc["vel_a"])), 3), Math.Round((Convert.ToDouble(dracc["vel_h"])), 3), Math.Round((Convert.ToDouble(dracc["vel_v"])), 3), Math.Round((Convert.ToDouble(dracc["vel_ch1"])), 3));
                    dtForData.Rows.Add("Displacement", Convert.ToString(dracc["Measure_time"]), Math.Round((Convert.ToDouble(dracc["displ_a"])), 3), Math.Round((Convert.ToDouble(dracc["displ_h"])), 3), Math.Round((Convert.ToDouble(dracc["displ_v"])), 3), Math.Round((Convert.ToDouble(dracc["displ_ch1"])), 3));
                    dtForData.Rows.Add("Bearing", Convert.ToString(dracc["Measure_time"]), Math.Round((Convert.ToDouble(dracc["bearing_a"])), 3), Math.Round((Convert.ToDouble(dracc["bearing_h"])), 3), Math.Round((Convert.ToDouble(dracc["bearing_v"])), 3), Math.Round((Convert.ToDouble(dracc["bearing_ch1"])), 3));
                    dtForData.Rows.Add("CreatFactor", Convert.ToString(dracc["Measure_time"]), Math.Round((Convert.ToDouble(dracc["crest_factor_a"])), 3), Math.Round((Convert.ToDouble(dracc["crest_factor_h"])), 3), Math.Round((Convert.ToDouble(dracc["crest_factor_v"])), 3), Math.Round((Convert.ToDouble(dracc["crest_factor_ch1"])), 3));
                    grdDashboard.DataSource = dtForData;
                }
                createbar(dtforGrid, "Acceleration");
                createbar(dtforGrid, "Velocity");
                createbar(dtforGrid, "Displacement");
                createbar(dtforGrid, "Bearing");
                createbar(dtforGrid, "CreatFactor");
            }
            catch { }
        }

        private void createbar(DataTable dt,string value)
        {
            try
            {
                Series series1 = new Series("Series1", ViewType.StackedBar);
                Series series2 = new Series("Series2", ViewType.StackedBar);
                Series series3 = new Series("Series3", ViewType.StackedBar);
                ChartTitle testTitle = new ChartTitle();
                DataTable chartTable1 = new DataTable("Table1");
                chartTable1 = calculateSeries(dt, value);
                if (value == "Acceleration")
                {
                    chrtAcc.Series.Clear();
                    chrtAcc.Series.Add(series3);
                }
                else if (value == "Velocity")
                {
                    chrtVel.Series.Clear();
                    chrtVel.Series.Add(series3);
                }
                else if (value == "Displacement")
                {
                    chrtDispl.Series.Clear();
                    chrtDispl.Series.Add(series3);
                }
                else if (value == "Bearing")
                {
                    chrtBear.Series.Clear();
                    chrtBear.Series.Add(series3);
                }
                else if (value == "CreatFactor")
                {
                    chrtCF.Series.Clear();
                    chrtCF.Series.Add(series3);
                }
                series3.DataSource = chartTable1;
                series3.ArgumentScaleType = ScaleType.Auto;
                series3.ArgumentDataMember = "Names";
                series3.ValueScaleType = ScaleType.Numerical;
                series3.ValueDataMembers.AddRange(new string[] { "No Alarm" });
                if (value == "Acceleration")
                {
                    chrtAcc.Series.Add(series2);
                }
                else if (value == "Velocity")
                {
                    chrtVel.Series.Add(series2);
                }
                else if (value == "Displacement")
                {
                    chrtDispl.Series.Add(series2);
                }
                else if (value == "Bearing")
                {
                    chrtBear.Series.Add(series2);
                }
                else if (value == "CreatFactor")
                {
                    chrtCF.Series.Add(series2);
                }
                series2.DataSource = chartTable1;
                series2.ArgumentScaleType = ScaleType.Auto;
                series2.ArgumentDataMember = "Names";
                series2.ValueScaleType = ScaleType.Numerical;
                series2.ValueDataMembers.AddRange(new string[] { "Low Alarm" });
                if (value == "Acceleration")
                {
                    chrtAcc.Series.Add(series1);
                }
                else if (value == "Velocity")
                {
                    chrtVel.Series.Add(series1);
                }
                else if (value == "Displacement")
                {
                    chrtDispl.Series.Add(series1);
                }
                else if (value == "Bearing")
                {
                    chrtBear.Series.Add(series1);
                }
                else if (value == "CreatFactor")
                {
                    chrtCF.Series.Add(series1);
                }
                series1.DataSource = chartTable1;
                series1.ArgumentScaleType = ScaleType.Auto;
                series1.ArgumentDataMember = "Names";
                series1.ValueScaleType = ScaleType.Numerical;
                series1.ValueDataMembers.AddRange(new string[] { "High Alarm" });
                series1.Name = "High Alarm";
                series2.Name = "Low Alarm";
                series3.Name = "No Alarm";
                if (value == "Acceleration")
                {
                    chrtAcc.Dock = DockStyle.Fill;
                }
                else if (value == "Velocity")
                {
                    chrtVel.Dock = DockStyle.Fill;
                }
                else if (value == "Displacement")
                {
                    chrtDispl.Dock = DockStyle.Fill;
                }
                else if (value == "Bearing")
                {
                    chrtBear.Dock = DockStyle.Fill;
                }
                else if (value == "CreatFactor")
                {
                    chrtCF.Dock = DockStyle.Fill;
                }
            }
            catch { }
        }

        public DataTable calculateSeries(DataTable dt, string alarmType)
        {
            DataTable dtReturn = new DataTable();
            dtReturn.Columns.Add("Names", typeof(string));
            dtReturn.Columns.Add("No Alarm", typeof(double));
            dtReturn.Columns.Add("Low Alarm", typeof(double));
            dtReturn.Columns.Add("High Alarm", typeof(double));
            try
            {
                string V = null;
                switch(alarmType)
                {
                    case "Acceleration":
                        {
                            V = "accel"; 
                            break;
                        }
                    case "Velocity":
                        {
                            V = "vel";
                            break;
                        }
                    case "Displacement":
                        {
                            V = "displ";
                            break;
                        }
                    case "Bearing":
                        {
                            V = "bearing";
                            break;
                        }
                    case "CrestFactor":
                        {
                            V = "crest_factor";
                            break;
                        }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        if (Convert.ToDouble(dt.Rows[0][V + "_a"]) != 0.0)
                        {

                            if (Convert.ToString(dt.Rows[0][V + "_a1"]) != "" && Convert.ToString(dt.Rows[0][V + "_a2"]) != "")
                            {
                                serData = seriesData(Convert.ToDouble(dt.Rows[0][V + "_a"]), Convert.ToDouble(dt.Rows[0][V + "_a2"]), Convert.ToDouble(dt.Rows[0][V + "_a1"]));
                                dtReturn.Rows.Add("Axial", serData[0], serData[1], serData[2]);
                            }
                            else
                            {
                                dtReturn.Rows.Add("Axial", Convert.ToDouble(dt.Rows[0][V + "_a"]), 0, 0);
                            }
                        }
                        else
                        {
                            dtReturn.Rows.Add("Axial", 0.0, 0.0, 0.0);
                        }
                    }
                    else if (i == 1)
                    {
                        if (Convert.ToDouble(dt.Rows[0][V + "_h"]) != 0.0)
                        {
                            if (Convert.ToString(dt.Rows[0][V + "_h1"]) != "" && Convert.ToString(dt.Rows[0][V + "_h2"]) != "")
                            {
                                serData = seriesData(Convert.ToDouble(dt.Rows[0][V + "_h"]), Convert.ToDouble(dt.Rows[0][V + "_h2"]), Convert.ToDouble(dt.Rows[0][V + "_h1"]));
                                dtReturn.Rows.Add("Horizontal", serData[0], serData[1], serData[2]);
                            }
                            else
                            {
                                dtReturn.Rows.Add("Horizontal", Convert.ToDouble(dt.Rows[0][V + "_h"]), 0, 0);
                            }
                        }
                        else
                        {
                            dtReturn.Rows.Add("Horizontal", 0.0, 0.0, 0.0);
                        }
                    }
                    else if (i == 2)
                    {
                        if (Convert.ToDouble(dt.Rows[0][V + "_v"]) != 0.0)
                        {
                            if (Convert.ToString(dt.Rows[0][V + "_v1"]) != "" && Convert.ToString(dt.Rows[0][V + "_v2"]) != "")
                            {
                                serData = seriesData(Convert.ToDouble(dt.Rows[0][V + "_v"]), Convert.ToDouble(dt.Rows[0][V + "_v2"]), Convert.ToDouble(dt.Rows[0][V + "_v1"]));
                                dtReturn.Rows.Add("Vertical", serData[0], serData[1], serData[2]);
                            }
                            else
                            {
                                dtReturn.Rows.Add("Vertical", Convert.ToDouble(dt.Rows[0][V + "_v"]), 0, 0);
                            }
                        }
                        else
                        {
                            dtReturn.Rows.Add("Vertical", 0.0, 0.0, 0.0);
                        }
                    }
                    else if (i == 3)
                    {
                        if (Convert.ToDouble(dt.Rows[0][V + "_ch1"]) != 0.0)
                        {
                            if (Convert.ToString(dt.Rows[0][V + "_ch11"]) != "" && Convert.ToString(dt.Rows[0][V + "_ch12"]) != "")
                            {
                                serData = seriesData(Convert.ToDouble(dt.Rows[0][V + "_ch1"]), Convert.ToDouble(dt.Rows[0][V + "_ch12"]), Convert.ToDouble(dt.Rows[0][V + "_ch11"]));
                                dtReturn.Rows.Add("Channel1", serData[0], serData[1], serData[2]);
                            }
                            else
                            {
                                dtReturn.Rows.Add("Channel1", Convert.ToDouble(dt.Rows[0][V + "_ch1"]), 0, 0);
                            }
                            
                        }
                        else
                        {
                            dtReturn.Rows.Add("Channel1", 0.0, 0.0, 0.0);
                        }
                    }
                }
            }
            catch { }
            return dtReturn;
        }
        public double[] seriesData(double V , double  V1, double V2)
        {
            double[] sData = new double[3];
            try
            {
                if(V2 !=0)
                {
                    if (V > V2)
                    {
                        sData[0] = V1;
                        sData[1] = V2 - V1;
                        sData[2] = V - V2;
                    }
                    else if ((V > V1) && (V < V2))
                    {
                        sData[0] = V1;
                        sData[1] = V - V1;
                        sData[2] = 0.0;
                    }
                    else
                    {
                        sData[0] = V;
                        sData[1] = 0.0;
                        sData[2] = 0.0;
                    }
                }
                else
                {
                    sData[0] = 0.0;
                    sData[1] = 0.0;
                    sData[2] = 0.0;
                }
                
            }
            catch
            {
            }
            return sData;
        }

        DataTable dtForData = new DataTable();

        public void FillGriddata()
        {
            try
            {
                dtForData.Columns.Add("AlarmType", typeof(string));
                dtForData.Columns.Add("DateTime", typeof(string));
                dtForData.Columns.Add("Axial", typeof(double));
                dtForData.Columns.Add("Horizontal", typeof(double));
                dtForData.Columns.Add("Vertical", typeof(double));
                dtForData.Columns.Add("Channel1", typeof(double));
            }
            catch { }
        }

        private void frmPointDashboard_Load(object sender, EventArgs e)
        {
          
        }

        private void trlDashboard_Click(object sender, EventArgs e)
        {
        }

        private void trlDashboard_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Point_ID = (string)trlDashboard.FocusedNode.GetDisplayText(0);
                
                while (gridView1.RowCount != 0)
                {
                    gridView1.SelectAll();
                    gridView1.DeleteSelectedRows();
                }

                bool chkPointData = GetPointData(Point_ID);
                if(chkPointData)
                {
                    FillGriddata();
                    alldatabargraph(Point_ID);                
                }
                else
                {
                    MessageBox.Show(this, "Data not taken in this point..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    return;
                }
               
               
            }
            catch { }
        }

        public bool GetPointData(string ptID)
        {
            bool sts = false;
            try
            {
                DataTable dtPoint = DbClass.getdata(CommandType.Text, "select * from point_data where point_id='" + ptID + "'");
                if(dtPoint.Rows.Count> 0)
                {
                    sts = true;
                }
                else
                {
                    sts = false;
                }
            }
            catch { }
            return sts;
        }
    }
}