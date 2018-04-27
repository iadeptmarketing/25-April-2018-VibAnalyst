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
using Iadeptmain.BaseUserControl;
using Iadeptmain.Reports;
using DevExpress.XtraCharts;
using System.Collections;

namespace Iadeptmain.Mainforms
{
    public partial class frmDashboard : DevExpress.XtraEditors.XtraForm
    {
        public frmDashboard()
        {
            InitializeComponent();
            Create_TreeListColumn();
        }
        frmIAdeptMain _objMain = null;
        IadeptUserControl objUserControl = null;

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

        public IadeptUserControl UserControl
        {
            get
            {
                return objUserControl;
            }

            set
            {
                objUserControl = value;

            }
        }

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

        private void fillFactoryList()
        {
            try
            {

                DataTable Factorydt = DbClass.getdata(CommandType.Text, "select Factory_ID,Name,Description from  factory_info");

                foreach (DataRow FactoryRow in Factorydt.Rows)
                {
                    trlDashboard.AppendNode(new object[] { Convert.ToString(FactoryRow["Factory_ID"]), Convert.ToString(FactoryRow["Name"]), Convert.ToString(FactoryRow["Description"]) }, null);
                }
                SelectedFactory = Convert.ToString(Factorydt.Rows[0]["Name"]);
                Factory_ID = Convert.ToString(Factorydt.Rows[0]["Factory_ID"]);
                if (SelectedFactory == null || SelectedFactory == "")
                {
                }
                else
                {
                    DrawPieChartOnForm(Factory_ID, myPieLocation, myPieSize);
                    DrawBarChartOnForm(Factory_ID);
                    FillDataGrid(Factory_ID);
                }
            }
            catch
            {

            }
        }

        private void frmDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _objMain.fillform();
            }
            catch
            {

            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            fillFactoryList();
        }

        public int getLegend(string Query)
        {
            int i = 0;
            try
            {
                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.Text, "select distinct  alarm_id from v_AllRecord  where " + Query + " and Alarm_ID <> '' ");
                string ids = "pd." + Query;
                foreach (DataRow dr in dtt.Rows)
                {
                    i = objUserControl.checkValueForFlagGenerate(ids, PublicClass.DefVal(Convert.ToString(dr["alarm_id"]), "0"), i);
                }
            }
            catch { }
            return i;
        }

        public double[] CalculateLegendForFactory(string factID)
        {
            try
            {
                allLegend[0] = 0.0;
                allLegend[1] = 0.0;
                allLegend[2] = 0.0;
                int red = 0;
                int yellow = 0;
                int green = 0;
                DataTable dtallPoint = DbClass.getdata(CommandType.Text, "Select f.Factory_ID , f.Name , a.Area_ID , a.Name , t.Train_ID ,t.Name , m.Machine_ID , m.Name , p.Point_ID , p.PointName from factory_info f inner join area_info a on f.Factory_ID = a.FactoryID inner join train_info t on a.Area_ID = t.Area_ID inner join machine_info m on t.Train_ID = m.TrainID inner join point p on m.Machine_ID = p.Machine_ID where f.Factory_ID = '" + factID + "'");
                foreach (DataRow dr1 in dtallPoint.Rows)
                {
                    int AlarmToken =getLegend("point_id =" + Convert.ToString(dr1["Point_ID"]));
                    if (AlarmToken == 2)
                    {
                        red = red + 1;
                    }
                    else if (AlarmToken == 1)
                    {
                        yellow = yellow + 1;
                    }
                    else if (AlarmToken == 0)
                    {
                        green = green + 1;
                    }
                }
                int totalPoint = dtallPoint.Rows.Count;
                allLegend[0] = Convert.ToDouble(red * 100 / totalPoint);
                allLegend[1] = Convert.ToDouble(yellow * 100 / totalPoint);
                allLegend[2] = Convert.ToDouble(green * 100 / totalPoint);
            }
            catch {}
            return allLegend;
        }

        public void FillDataGrid(string factID)
        {
            try
            {
                DataTable dt = DbClass.getdata(CommandType.Text, "select count(distinct a.Area_ID) as Area_ID , count( distinct t.Train_ID) as Train_ID , count( distinct m.Machine_ID) as Machine_ID , count(distinct p.Point_ID) as Point_ID  from area_info a inner join train_info t on a.Area_ID = t.Area_ID inner join machine_info m  on t.Train_ID = m.TrainID inner join point p on m.Machine_ID=p.Machine_ID where a.FactoryID = '" + factID + "'");
                DataTable table = new DataTable();
                table.Columns.Add("ElementName");
                table.Columns.Add("TotalCount");
                foreach (DataRow dr1 in dt.Rows)
                {
                    table.Rows.Add("Area Count", Convert.ToString(dr1["Area_ID"]));
                    table.Rows.Add("Train Count", Convert.ToString(dr1["Train_ID"]));
                    table.Rows.Add("Machine Count", Convert.ToString(dr1["Machine_ID"]));
                    table.Rows.Add("Point Count", Convert.ToString(dr1["Point_ID"]));
                }
                gridControl1.DataSource = table;
            }
            catch
            {
            }

        }
     



        public ArrayList CalculateLegendForMachine(int[] MacIDs)
        {
             arrAllData = new ArrayList();
            
            try
            {
                
                double[] HighValue = new double[MacIDs.Length];
                double[] LowValue = new double[MacIDs.Length];
                double[] NormalValue = new double[MacIDs.Length];

               
                for(int i = 0; i < MacIDs.Length;i++)
                {
                    int red = 0;
                    int yellow = 0;
                    int green = 0;
                    DataTable dtallPoint = DbClass.getdata(CommandType.Text, "SELECT p.Point_ID,p.PointName , m.Name as MachineName , m.Machine_ID FROM machine_info m inner join  point p on m.Machine_ID = p.Machine_ID where m.Machine_ID ='" + MacIDs[i] + "'");
                    foreach (DataRow dr1 in dtallPoint.Rows)
                    {
                        int AlarmToken = getLegend("point_id =" + Convert.ToString(dr1["Point_ID"]));
                        if (AlarmToken == 2)
                        {
                            red = red + 1;
                        }
                        else if (AlarmToken == 1)
                        {
                            yellow = yellow + 1;
                        }
                        else if (AlarmToken == 0)
                        {
                            green = green + 1;
                        }
                    }
                    try
                    {
                        int totalPoint = dtallPoint.Rows.Count;
                        if(red ==0)
                        {
                            HighValue[i] = red;
                        }
                        else
                        {
                            HighValue[i] = Convert.ToDouble(red * 100 / totalPoint);
                        }
                        if (yellow == 0)
                        {
                            LowValue[i] = yellow;
                        }
                        else
                        {
                            LowValue[i] = Convert.ToDouble(yellow * 100 / totalPoint);
                        }
                        if (green == 0)
                        {
                            NormalValue[i] = green;
                        }
                        else
                        {
                            NormalValue[i] = Convert.ToDouble(green * 100 / totalPoint);
                        }
                        
                        
                    }
                    catch
                    {

                    }
                    
                }
                arrAllData.Add(HighValue);
                arrAllData.Add(LowValue);
                arrAllData.Add(NormalValue);
            }
            catch { }
            return arrAllData;
        }
      
        public void DrawPieChartOnForm(string factoryID, Point myPieLocation, Size myPieSize)
        {
            try
            {
                CalculateLegendForFactory(factoryID);
                Series series = new Series("Series1", ViewType.Pie3D);
                ChartTitle testTitle = new ChartTitle();
                Pie3DSeriesView myView = (Pie3DSeriesView)series.View;
                if(allLegend[0] == 0.0 && allLegend[1] == 0.0 && allLegend[2]== 0.0)
                {
                    pnlPieChart.Controls.Clear();
                    MessageBox.Show(this, "No data has been taken on any Point in this Plant....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    double[] myPiePercent = { allLegend[0], allLegend[1], allLegend[2] };
                    Color[] myPieColors = { Color.Red, Color.Yellow, Color.Green };
                    DataTable chartTable = new DataTable("Table1");
                    chartTable.Columns.Add("Names", typeof(string));
                    chartTable.Columns.Add("Value", typeof(double));
                    chartTable.Rows.Add("High Alarm", allLegend[0]);
                    chartTable.Rows.Add("Low Alarm", allLegend[1]);
                    chartTable.Rows.Add("No Alarm", allLegend[2]);
                    pieChartControl.Series.Clear();
                    pieChartControl.Series.Add(series);
                    series.DataSource = chartTable;
                    series.ArgumentScaleType = ScaleType.Numerical;
                    series.ArgumentDataMember = "Value";
                    series.ValueScaleType = ScaleType.Numerical;
                    series.ValueDataMembers.AddRange(new string[] { "Value" });
                    series.Name = Convert.ToString(SelectedFactory);
                    pieChartControl.Titles.Clear();
                    myView.Titles.Add(new SeriesTitle());
                    myView.Titles[0].Text = series.Name;
                    pieChartControl.Dock = DockStyle.Fill; 
                   
                }
            }
            catch { }
        }

        string[] allMachineName = null;
        int[] allMachineIDs = null;
        double[] HighVal = null;
        double[] LowVal = null;
        double[] NoVal = null;
        string SelectedFactory = null;
        double[] allLegend = new double[3];
        ArrayList arrAllData = null;
        string Factory_ID = null;
        Point myPieLocation;
        Size myPieSize;

        private void AllMachineRecord(string factID)
        {
            try
            {
                int i = 0;
                DataTable dt = DbClass.getdata(CommandType.Text, "select f.Factory_ID , f.Name , m.Machine_ID , m.Name as MachineName from factory_info f inner join area_info a on f.Factory_ID = a.FactoryID inner join train_info t on a.Area_ID = t.Area_ID inner join machine_info m on t.Train_ID = m.TrainID where f.Factory_ID = '" + factID + "'");
                allMachineName = new string[dt.Rows.Count];
                allMachineIDs = new int[dt.Rows.Count];
                foreach(DataRow dr1 in dt.Rows)
                {
                    allMachineName[i] = Convert.ToString(dr1["MachineName"]);
                    allMachineIDs[i] = Convert.ToInt32(dr1["Machine_ID"]);
                    i++;
                }
            }
            catch
            {
            }
        }

        public void DrawBarChartOnForm(string factoryID)
        {
            try
            {
                AllMachineRecord(factoryID);
                CalculateLegendForMachine(allMachineIDs);
                HighVal = (double[])arrAllData[0];
                LowVal = (double[])arrAllData[1];
                NoVal = (double[])arrAllData[2];
                Series series1 = new Series("Series1", ViewType.Bar);
                Series series2 = new Series("Series2", ViewType.Bar);
                Series series3 = new Series("Series3", ViewType.Bar);
                ChartTitle testTitle = new ChartTitle();
                if (allLegend[0] == 0.0 && allLegend[1] == 0.0 && allLegend[2] == 0.0)
                {
                    MessageBox.Show(this, "No data has been taken on any Point in this Plant....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DataTable chartTable1 = new DataTable("Table1");
                    chartTable1.Columns.Add("Names", typeof(string));
                    chartTable1.Columns.Add("High Alarm", typeof(double));
                    chartTable1.Columns.Add("Low Alarm", typeof(double));
                    chartTable1.Columns.Add("No Alarm", typeof(double));
                    for (int i = 0; i < allMachineName.Length; i++ )
                    {
                        chartTable1.Rows.Add(Convert.ToString(allMachineName[i]), HighVal[i], LowVal[i], NoVal[i]);
                    }
                      
                    barChartControl.Series.Clear();

                    barChartControl.Series.Add(series1);
                    series1.DataSource = chartTable1;
                    series1.ArgumentScaleType = ScaleType.Auto;
                    series1.ArgumentDataMember = "Names";
                    series1.ValueScaleType = ScaleType.Numerical;
                    series1.ValueDataMembers.AddRange(new string[] { "High Alarm" });

                    barChartControl.Series.Add(series2);
                    series2.DataSource = chartTable1;
                    series2.ArgumentScaleType = ScaleType.Auto;
                    series2.ArgumentDataMember = "Names";
                    series2.ValueScaleType = ScaleType.Numerical;
                    series2.ValueDataMembers.AddRange(new string[] { "Low Alarm" });

                    barChartControl.Series.Add(series3);
                    series3.DataSource = chartTable1;
                    series3.ArgumentScaleType = ScaleType.Auto;
                    series3.ArgumentDataMember = "Names";
                    series3.ValueScaleType = ScaleType.Numerical;
                    series3.ValueDataMembers.AddRange(new string[] { "No Alarm" });

                    series1.Name = "High Alarm";
                    series2.Name = "Low Alarm";
                    series3.Name = "No Alarm";
                    barChartControl.Titles.Clear();

                    barChartControl.Dock = DockStyle.Fill;
                }
            }
            catch { }
        }
        
        private void trlDashboard_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                SelectedFactory = (string)trlDashboard.FocusedNode.GetDisplayText(1);
                Factory_ID = (string)trlDashboard.FocusedNode.GetDisplayText(0);

                 myPieLocation = new Point(10, 400);
                 myPieSize = new Size(500, 500);
                if (SelectedFactory == null || SelectedFactory == "")
                {
                }
                else
                {
                  DrawPieChartOnForm(Factory_ID, myPieLocation, myPieSize);
                  DrawBarChartOnForm(Factory_ID);
                }
            }
            catch
            {
            }
        }

        private void pieChartControl_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            //try
            //{
            //    Pie3DDrawOptions options = (Pie3DDrawOptions)e.SeriesDrawOptions;
            //    string NAME = e.SeriesPoint.Argument;
            //    string NM = Convert.ToString(allLegend[0]);
            //    if (e.SeriesPoint.Argument == Convert.ToString(allLegend[0]))
            //    {
            //        options.Color = Color.Red;
            //    }
            //    else if (e.SeriesPoint.Argument == Convert.ToString(allLegend[1]))
            //    {
            //        options.Color = Color.Yellow;
            //    }
            //    else if (e.SeriesPoint.Argument == Convert.ToString(allLegend[2]))
            //    {
            //        options.Color = Color.Green;
            //    }
            //}
            //catch
            //{

            //}
        }

        private void barChartControl_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            //try
            //{
            //    BarDrawOptions options = (BarDrawOptions)e.SeriesDrawOptions;
            //    if (e.SeriesPoint.Argument == Convert.ToString(allLegend[0]))
            //    {
            //        options.Color = Color.Red;
            //    }
            //    else if (e.SeriesPoint.Argument == Convert.ToString(allLegend[1]))
            //    {
            //        options.Color = Color.Yellow;
            //    }
            //    else if (e.SeriesPoint.Argument == Convert.ToString(allLegend[2]))
            //    {
            //        options.Color = Color.Green;
            //    }
            //}
            //catch
            //{

            //}
        }
    }
}
        
  
    


    
