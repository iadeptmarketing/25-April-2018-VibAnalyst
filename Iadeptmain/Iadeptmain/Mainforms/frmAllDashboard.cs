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
using System.Collections;
using DevExpress.XtraCharts;
using Iadeptmain.BaseUserControl;

namespace Iadeptmain.Mainforms
{
    public partial class frmAllDashboard : DevExpress.XtraEditors.XtraForm
    {
        public frmAllDashboard()
        {
            InitializeComponent();
        }
      
        List<Plant> datasource;
        public int level = 0;
        Plant curentPlant;
        Area currentArea;
        Train currenTrain;
        Machine currentMachine;
        RecordPoint currentPoint;
        DataGridView grControl;
        frmIAdeptMain _objMain = null;
        IadeptUserControl objUserControl = null;
        frmDashboardRibbon objmainDash = null;
        double[] finalValueForAlarm = new double[3];
        ArrayList AllData = new ArrayList();
        ArrayList pointData = new ArrayList();
        public string CurrentNodeParent = null;
        public string CurrnetNode = null;
        public int CurrentNodeParentID;
        public int CurrentNodeID;

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
        List<Plant> CreateData()
        {
            Random rnd = new Random();
            List<Plant> plants = new List<Plant>();
            DataTable Factorydt = new DataTable();
            DataTable AreaDT = new DataTable();
            DataTable TrainDt = new DataTable();
            DataTable MachineDt = new DataTable();
            DataTable PointDt = new DataTable();
            int r = 0;
            try
            {
                Factorydt = DbClass.getdata(CommandType.Text, "select FACTORY_ID ,NAME,Description  from factory_info ");
                AreaDT = DbClass.getdata(CommandType.Text, "select Area_ID,NAME,DESCRIPTION,FactoryID  from area_info ");
                TrainDt = DbClass.getdata(CommandType.Text, "select Train_ID,NAME,Description ,Area_ID from train_info ");
                MachineDt = DbClass.getdata(CommandType.Text, "select  Machine_ID ,NAME ,Description,TrainID from machine_info  ");
                PointDt = DbClass.getdata(CommandType.Text, "SELECT  Point_ID ,POINTNAME ,PointDesc,Machine_ID  FROM POINT  ");

                foreach (DataRow FactoryRow in Factorydt.Rows)
                {
                    Plant plant = new Plant() { plantID = Convert.ToInt32(FactoryRow["FACTORY_ID"]), Name = Convert.ToString(FactoryRow["Name"]), Areas = new List<Area>() };
                    plants.Add(plant);
                    foreach (DataRow AreaRow in AreaDT.Select("FactoryID = '" + Convert.ToString(FactoryRow["Factory_ID"]) + "'"))
                    {
                        Area area = new Area() { arID = Convert.ToInt32(AreaRow["Area_ID"]), Name = Convert.ToString(AreaRow["Name"]), Trains = new List<Train>() };
                        plant.Areas.Add(area);
                        foreach (DataRow TrainRow in TrainDt.Select("Area_ID = '" + Convert.ToString(AreaRow["Area_ID"]) + "' "))
                        {
                            Train Train = new Train() { trID = Convert.ToInt32(TrainRow["Train_ID"]), Name = Convert.ToString(TrainRow["name"]), Machines = new List<Machine>() };
                            area.Trains.Add(Train);
                            foreach (DataRow MachineRow in MachineDt.Select("TrainID = '" + Convert.ToString(TrainRow["Train_ID"]) + "'  "))
                            {
                                Machine machine = new Machine() { macID = Convert.ToInt32(MachineRow["Machine_ID"]), Name = Convert.ToString(MachineRow["name"]), Points = new List<RecordPoint>() };
                                Train.Machines.Add(machine);
                                foreach (DataRow PointRow in PointDt.Select(" Machine_ID = '" + Convert.ToString(MachineRow["Machine_ID"]) + "' "))
                                {
                                    RecordPoint point = new RecordPoint() { PointID = Convert.ToInt32(PointRow["Point_ID"]), Name = Convert.ToString(PointRow["POINTNAME"]), Points = new List<RecordPoint>() };
                                    machine.Points.Add(point);
                                }
                                //foreach (DataRow PointRow in PointDt.Select(" Machine_ID = '" + Convert.ToString(MachineRow["Machine_ID"]) + "' "))
                                //{
                                //    RecordPoint point = new RecordPoint() { Argument = "Argument" + pointCount, Value = rnd.Next(10) };
                                //    machine.Points.Add(point);
                                //}
                                //foreach (int pointCount = 1; pointCount < 4; pointCount++)
                                //{
                                //    RecordPoint point = new RecordPoint() { Name = "Argument" + pointCount, PointID = rnd.Next(10) };
                                //    machine.Points.Add(point);
                                //}
                            }
                        }
                    }
                }
            }
            catch { }
            return plants;
        }
        class Plant
        {
            public string Name { get; set; }
            public int plantID { get; set; }
            public List<Area> Areas { get; set; }
        }
        class Area
        {
            public string Name { get; set; }
            public int arID { get; set; }
            public List<Train> Trains { get; set; }
        }
        class Train
        {
            public string Name { get; set; }
            public int trID { get; set; }
            public List<Machine> Machines { get; set; }

        }
        class Machine
        {
            public string Name { get; set; }
            public int macID { get; set; }
            public List<RecordPoint> Points { get; set; }
        }
        class RecordPoint
        {
            public string Name { get; set; }
            public int PointID { get; set; }
            public List<RecordPoint> Points { get; set; }
        }

        public void CreateCharts(int level) 
        {
            try
            {
                tblDashboard.Controls.Clear();
                string pointIDs = null;
                string pids = null;
                switch (level)
                {
                    case 0:
                        foreach (var plantRecord in datasource)
                        {
                            curentPlant = plantRecord;
                            PublicClass.CurrentLevel = 0;
                            objmainDash.bbback.Enabled = false;
                            ChartControl chart = CreateChart();
                            chart.Titles.Add(new ChartTitle() { Text = plantRecord.Name });
                            chart.Series[0].Tag = plantRecord;
                            chart.Series[0].Name = plantRecord.Name;
                            chart.Series[0].DataSource = GetPlantData(plantRecord.plantID, "Plant");
                            objmainDash.bbstatus.Caption = "Opening Plant Level";
                        }
                        break;
                    case 1:
                        foreach (var area in curentPlant.Areas)
                        {
                            currentArea = area;
                            PublicClass.CurrentPlantID = Convert.ToString(curentPlant.plantID);
                            PublicClass.CurrentLevel = 0;
                            ChartControl chart = CreateChart();
                            chart.Titles.Add(new ChartTitle() { Text = area.Name });
                            chart.Series[0].Tag = area;
                            chart.Series[0].Name = area.Name;
                            chart.Series[0].DataSource = GetAreaData(area.arID, "Area");
                            objmainDash.bbstatus.Caption = "Opening Area Level";
                        }
                        break;
                    case 2:
                        foreach (var train in currentArea.Trains)
                        {
                            currenTrain = train;
                            PublicClass.CurrentAreaID = Convert.ToString(currentArea.arID);
                            PublicClass.CurrentLevel = 1;
                            ChartControl chart = CreateChart();
                            chart.Titles.Add(new ChartTitle() { Text = train.Name });
                            chart.Series[0].Tag = train;
                            chart.Series[0].Name = train.Name;
                            chart.Series[0].DataSource = GetTrainData(train.trID, "Train");
                            objmainDash.bbstatus.Caption = "Opening Train Level";
                        }
                        break;
                    case 3:
                        foreach (var machine in currenTrain.Machines)
                        {
                            currentMachine = machine;
                            PublicClass.CurrentTrainID = Convert.ToString(currenTrain.trID);
                            PublicClass.CurrentLevel = 2;
                            ChartControl chart = CreateChart();
                            chart.Titles.Add(new ChartTitle() { Text = machine.Name });
                            chart.Series[0].Tag = machine;
                            chart.Series[0].Name = machine.Name;
                            chart.Series[0].DataSource = GetMachineData(machine.macID, "Machine");
                            objmainDash.bbstatus.Caption = "Opening Machine Level";
                        }
                        break;
                    case 4:
                        {
                            PublicClass.CurrentLevel = 3;
                            PublicClass.CurrentMachineID = Convert.ToString(currentMachine.macID);
                            objmainDash.showAlPointData(currentMachine.macID);
                            objmainDash.bbstatus.Caption = "Opening Point Level";
                            break;
                        }
                }
            }
            catch { }
        }

        //public void DrawGridControlOnForm(ArrayList allData, string MacName)
        //{
        //    try
        //    {
        //        string[] pointName = (string[])allData[0];
        //        double[] value = (double[])allData[2];
        //        string[] color = (string[])allData[1];
        //        string[] alarmType = (string[])allData[3];
        //        grControl = new DataGridView();
        //        DataTable gridTable1 = new DataTable("Table2");
        //        gridTable1.Columns.Add("AlarmType", typeof(string));
        //        for (int i = 0; i < pointName.Length; i++)
        //        {
        //            gridTable1.Columns.Add(Convert.ToString(pointName[i]), typeof(string));
        //        }
        //        for (int i = 0; i < alarmType.Length; i++)
        //        {
        //            if (alarmType[i] != null)
        //            {
        //                DataRow row = gridTable1.NewRow();
        //                row["AlarmType"] = Convert.ToString(alarmType[i]);
        //                //for (int k = 0; k < alarmType.Length; k++)
        //                //{
        //                //    row[Convert.ToString(pointName[i])] = Convert.ToString(value[k]);
        //                //}
        //                row[Convert.ToString(pointName[i])] = Convert.ToString(value[i]);
        //                gridTable1.Rows.Add(row);
        //            }
        //        }
        //        grControl.DataSource = gridTable1;
        //        tblDashboard.Controls.Add(grControl, 0, 1);
        //        grControl.Dock = DockStyle.Fill;
        //        grControl.ReadOnly = true;
        //        grControl.EnableHeadersVisualStyles = false;
        //        grControl.ColumnHeadersDefaultCellStyle.BackColor = Color.SkyBlue;
        //        grControl.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
        //        grControl.BackgroundColor = Color.Gray;
        //        grControl.BringToFront();
        //    }
        //    catch { }
        //}
        

        //public void DrawBarChartOnForm(ArrayList allData, string MacName)
        //{
        //    try
        //    {
        //        string[] pointName = (string[])allData[0];
        //        double[] value = (double[])allData[2];
        //        string[] color = (string[])allData[1];
        //        string[] alarmType = (string[])allData[3];

        //        ChartControl barChartControl = new ChartControl();
        //        Series series1 = new Series("Series1", ViewType.Bar);
        //        DataTable chartTable1 = new DataTable("Table1");
        //        chartTable1.Columns.Add("Names", typeof(string));
        //        chartTable1.Columns.Add("Value", typeof(double));
        //        chartTable1.Columns.Add("AlarmType", typeof(string));
        //        chartTable1.Columns.Add("Color", typeof(string));
        //        for (int i = 0; i < pointName.Length; i++)
        //        {
        //            chartTable1.Rows.Add(Convert.ToString(pointName[i]), value[i], alarmType[i], color[i]);
        //        }
        //        barChartControl.Series.Clear();
        //        barChartControl.Series.Add(series1);
        //        series1.DataSource = chartTable1;
        //        series1.ArgumentScaleType = ScaleType.Auto;
        //        series1.ArgumentDataMember = "Names";
        //        series1.ValueScaleType = ScaleType.Numerical;
        //        series1.ValueDataMembers.AddRange(new string[] { "Value" });





        //        series1.Name = MacName;
        //        barChartControl.Titles.Clear();
        //        barChartControl.Titles.Add(new ChartTitle() { Text = MacName });
        //        tblDashboard.ColumnCount = 1;
        //        tblDashboard.RowCount = 2;
        //        tblDashboard.Controls.Add(barChartControl, 0, 0);
        //        barChartControl.Dock = DockStyle.Fill;
        //    }
        //    catch { }
        //}

        //ChartControl CreateChart(string point)
        //{
        //    ChartControl chart = new ChartControl();
        //    try
        //    {
        //        chart.Click += new EventHandler(chart_Click);
        //        tblDashboard.ColumnCount = 1;
        //        tblDashboard.RowCount = 2;
        //        tblDashboard.Controls.Add(chart);
        //        chart.Dock = DockStyle.Fill;
        //        Series series = new Series("", ViewType.SideBySideRangeBar);
        //        chart.Series.Add(series);
        //        series.ArgumentDataMember = "Argument";
        //        series.ValueDataMembers.AddRange("Value");
        //    }
        //    catch { }
        //    return chart;
        //}

        int i = 0;
        void chart_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            try
            {
                var Ldraw = e.LegendDrawOptions as Pie3DDrawOptions;
               Ldraw.FillStyle.FillMode = FillMode3D.Solid;
              
                switch (e.SeriesPoint.Argument.ToString())
                {
                    case "High Value":
                        {
                            e.SeriesDrawOptions.Color = Color.Red;
                            Ldraw.Color = Color.Red;
                            break;
                        }
                    case "Low Value":
                        {
                            e.SeriesDrawOptions.Color = Color.Yellow;
                            Ldraw.Color = Color.Yellow;
                            break;
                        }
                    case "Normal Value":
                        {
                            e.SeriesDrawOptions.Color = Color.Green;
                              Ldraw.Color = Color.Green;
                            break;
                        }
                }
            }
            catch { }
                       
        }

        ChartControl CreateChart()
        {
            ChartControl chart = new ChartControl();
            try
            {
                chart.Click += new EventHandler(chart_Click);
                chart.CustomDrawSeriesPoint += new CustomDrawSeriesPointEventHandler(chart_CustomDrawSeriesPoint);
                tblDashboard.Controls.Add(chart);
                chart.Dock = DockStyle.Fill;
                Series series = new Series("", ViewType.Pie3D);
                chart.Series.Add(series);
                chart.Legend.Visible = true;
                series.ArgumentDataMember = "Argument";
                series.ValueDataMembers.AddRange("Value");
            }
            catch { }
            return chart;
        }

        void chart_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string ChildName = null;
                string ParentName = null;
                switch (level)
                {
                    case 0:
                        curentPlant = (sender as ChartControl).Series[0].Tag as Plant;
                        dt = DbClass.getdata(CommandType.Text, "Select Area_ID from area_info where FactoryID ='" + curentPlant .plantID+ "'");
                        ChildName = "Area";
                        ParentName="Plant";
                        objmainDash.bbstatus.Caption = "Opening Area Level";
                        objmainDash.bbback.Enabled = true;
                       // objmainDash.btnBack.Enabled = true;
                        break;
                    case 1:
                        currentArea = (sender as ChartControl).Series[0].Tag as Area;
                        dt = DbClass.getdata(CommandType.Text, "Select Train_ID from train_info where Area_ID ='" + currentArea.arID + "'");
                        ChildName = "Train";
                        ParentName="Area";
                        objmainDash.bbstatus.Caption = "Opening Train Level";
                        objmainDash.bbback.Enabled = true;
                        //objmainDash.btnBack.Enabled = true;
                        break;
                    case 2:
                        currenTrain = (sender as ChartControl).Series[0].Tag as Train;
                        dt = DbClass.getdata(CommandType.Text, "Select Machine_ID from machine_info where TrainID ='" + currenTrain.trID + "'");
                        ChildName = "Machine";
                        ParentName="Train";
                        objmainDash.bbstatus.Caption = "Opening Machine Level";
                        objmainDash.bbback.Enabled = true;
                        //objmainDash.btnBack.Enabled = true;
                        break;
                    case 3:
                        currentMachine = (sender as ChartControl).Series[0].Tag as Machine;
                        dt = DbClass.getdata(CommandType.Text, "Select Point_ID from point where Machine_ID ='" + currentMachine.macID + "'");
                        ChildName = "Point";
                        ParentName="Machine";
                        objmainDash.bbstatus.Caption = "Opening Point Level";
                        objmainDash.bbback.Enabled = true;
                       // objmainDash.btnBack.Enabled = true;
                        break;
                }
               
                if(dt.Rows.Count > 0)
                {
                    level++;
                    CreateCharts(level);
                }
                else
                {
                    MessageBox.Show(this, "There is no " + ChildName + " in this " + ParentName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch { }
        }

        //List<RecordPoint> GetFilteredData()
        //{
        //    return datasource.Where(plant => (curentPlant == null) || (plant == curentPlant))
        //        .SelectMany(plant => plant.Areas.Where(area => (currentArea == null) || (area == currentArea))
        //                            .SelectMany(area => area.Trains.Where(Train => (currenTrain == null) || (Train == currenTrain))
        //            .SelectMany(Train => Train.Machines.Where(machine => (currentMachine == null) || (machine == currentMachine))
        //            .SelectMany(machine => machine.Points.Select(point => point))))).ToList();
        //}

        public DataTable GetPlantData(int NodeID, string nodeType)
        {
            DataTable FinalDataPlant = new DataTable();
            DataTable dtForChildNode = new DataTable();
            double[] allvalPlant = new double[3];
            int red = 0;
            int yellow = 0;
            int green = 0;
            try
            {
                DataTable dtArea = DbClass.getdata(CommandType.Text, "Select distinct Area_ID ,  Name from area_info where FactoryID = '" + NodeID + "'");
                if (dtArea.Rows.Count > 0)
                {
                    foreach (DataRow drForArea in dtArea.Rows)
                    {
                        dtForChildNode = GetAreaData(Convert.ToInt32(drForArea["Area_ID"]), "Train");
                        if (Convert.ToDouble(dtForChildNode.Rows[0]["Value"]) != 0.0)
                        {
                            red = red + 1;
                        }
                        else if (Convert.ToDouble(dtForChildNode.Rows[1]["Value"]) != 0.0)
                        {
                            yellow = yellow + 1;
                        }
                        else if (Convert.ToDouble(dtForChildNode.Rows[2]["Value"]) != 0.0)
                        {
                            green = green + 1;
                        }
                    }
                    int totalPoint = dtForChildNode.Rows.Count;
                    try
                    {
                        if (red != 0)
                        {
                            allvalPlant[0] = Convert.ToDouble(red * 100 / totalPoint);
                            if (yellow == 0 && green == 0)
                            {
                                allvalPlant[0] = 100;
                            }
                        }
                        else
                        {
                            allvalPlant[0] = 0;
                        }
                        if (yellow != 0)
                        {
                            allvalPlant[1] = Convert.ToDouble(yellow * 100 / totalPoint);
                            if (red == 0 && green == 0)
                            {
                                allvalPlant[1] = 100;
                            }
                        }
                        else
                        {
                            allvalPlant[1] = 0;
                        }
                        if (green != 0)
                        {
                            allvalPlant[2] = Convert.ToDouble(green * 100 / totalPoint);
                            if (yellow == 0 && red == 0)
                            {
                                allvalPlant[2] = 100;
                            }
                        }
                        else if (red == 0 && yellow == 0)
                        {
                            allvalPlant[2] = 100;
                        }
                        else
                        {
                            allvalPlant[2] = 0;
                        }
                    }
                    catch { }
                }
                else
                {
                    allvalPlant[0] = 0.0;
                    allvalPlant[1] = 0.0;
                    allvalPlant[2] = 100.0;
                }
                FinalDataPlant.Columns.Add("Argument", typeof(string));
                FinalDataPlant.Columns.Add("Value", typeof(double));
                FinalDataPlant.Rows.Add("High Value", allvalPlant[0]);
                FinalDataPlant.Rows.Add("Low Value", allvalPlant[1]);
                FinalDataPlant.Rows.Add("Normal Value", allvalPlant[2]);
            }
            catch { }
            return FinalDataPlant;
        }

        public DataTable GetAreaData(int NodeID, string nodeType)
        {
            DataTable FinalDataArea = new DataTable();
            DataTable dtForChildNode = new DataTable();
            double[] allvalArea = new double[3];
            int red = 0;
            int yellow = 0;
            int green = 0;
            try
            {
                DataTable dtTrain = DbClass.getdata(CommandType.Text, "select distinct Train_ID ,Name from train_info where Area_ID = '" + NodeID + "'");
                if (dtTrain.Rows.Count > 0)
                {
                    foreach (DataRow drForTrain in dtTrain.Rows)
                    {
                        dtForChildNode = GetTrainData(Convert.ToInt32(drForTrain["Train_ID"]), "Train");
                        if (Convert.ToDouble(dtForChildNode.Rows[0]["Value"]) != 0.0)
                        {
                            red = red + 1;
                        }
                        else if (Convert.ToDouble(dtForChildNode.Rows[1]["Value"]) != 0.0)
                        {
                            yellow = yellow + 1;
                        }
                        else if (Convert.ToDouble(dtForChildNode.Rows[2]["Value"]) != 0.0)
                        {
                            green = green + 1;
                        }
                    }
                    int totalPoint = dtForChildNode.Rows.Count;
                    try
                    {
                        if (red != 0)
                        {
                            allvalArea[0] = Convert.ToDouble(red * 100 / totalPoint);
                            if (yellow == 0 && green == 0)
                            {
                                allvalArea[0] = 100;
                            }
                        }
                        else
                        {
                            allvalArea[0] = 0;
                        }
                        if (yellow != 0)
                        {
                            allvalArea[1] = Convert.ToDouble(yellow * 100 / totalPoint);
                            if (red == 0 && green == 0)
                            {
                                allvalArea[1] = 100;
                            }
                        }
                        else
                        {
                            allvalArea[1] = 0;
                        }
                        if (green != 0)
                        {
                            allvalArea[2] = Convert.ToDouble(green * 100 / totalPoint);
                            if (yellow == 0 && red == 0)
                            {
                                allvalArea[2] = 100;
                            }
                        }
                        else if (red == 0 && yellow == 0)
                        {
                            allvalArea[2] = 100;
                        }
                        else
                        {
                            allvalArea[2] = 0;
                        }
                    }
                    catch { }
                }
                else
                {
                    allvalArea[0] = 0.0;
                    allvalArea[1] = 0.0;
                    allvalArea[2] = 100.0;
                }
                FinalDataArea.Columns.Add("Argument", typeof(string));
                FinalDataArea.Columns.Add("Value", typeof(double));
                FinalDataArea.Rows.Add("High Value", allvalArea[0]);
                FinalDataArea.Rows.Add("Low Value", allvalArea[1]);
                FinalDataArea.Rows.Add("Normal Value", allvalArea[2]);
            }
            catch { }
            return FinalDataArea;
        }

        public DataTable GetTrainData(int NodeID, string nodeType)
        {
            DataTable FinalDataTrain = new DataTable();
            DataTable dtForChildNode = new DataTable();
            double[] allvalTrain = new double[3];
            int red = 0;
            int yellow = 0;
            int green = 0;
            try
            {
                DataTable dtMachine = DbClass.getdata(CommandType.Text, "select Machine_ID , name from machine_info where TrainID = '" + NodeID + "'");
                if (dtMachine.Rows.Count > 0)
                {
                    foreach (DataRow drForTrain in dtMachine.Rows)
                    {
                        dtForChildNode = GetMachineData(Convert.ToInt32(drForTrain["Machine_ID"]), "Machine");
                        if (Convert.ToDouble(dtForChildNode.Rows[0]["Value"]) != 0.0)
                        {
                            red = red + 1;
                        }
                        else if (Convert.ToDouble(dtForChildNode.Rows[1]["Value"]) != 0.0)
                        {
                            yellow = yellow + 1;
                        }
                        else if (Convert.ToDouble(dtForChildNode.Rows[2]["Value"]) != 0.0)
                        {
                            green = green + 1;
                        }
                    }
                    int totalPoint = dtForChildNode.Rows.Count;
                    try
                    {
                        if (red != 0)
                        {
                            allvalTrain[0] = Convert.ToDouble(red * 100 / totalPoint);
                        }
                        else
                        {
                            allvalTrain[0] = 0;
                        }
                        if (yellow != 0)
                        {
                            allvalTrain[1] = Convert.ToDouble(yellow * 100 / totalPoint);
                        }
                        else
                        {
                            allvalTrain[1] = 0;
                        }
                        if (green != 0)
                        {
                            allvalTrain[2] = Convert.ToDouble(green * 100 / totalPoint);
                        }
                        else if (red == 0 && yellow == 0)
                        {
                            allvalTrain[2] = 100;
                        }
                        else
                        {
                            allvalTrain[2] = 0;
                        }
                    }
                    catch { }
                }
                else
                {
                    allvalTrain[0] = 0.0;
                    allvalTrain[1] = 0.0;
                    allvalTrain[2] = 100.0;
                }
                FinalDataTrain.Columns.Add("Argument", typeof(string));
                FinalDataTrain.Columns.Add("Value", typeof(double));
                FinalDataTrain.Rows.Add("High Value", allvalTrain[0]);
                FinalDataTrain.Rows.Add("Low Value", allvalTrain[1]);
                FinalDataTrain.Rows.Add("Normal Value", allvalTrain[2]);
            }
            catch { }
            return FinalDataTrain;
        }

        public DataTable GetMachineData(int NodeID, string nodeType)
        {
            DataTable FinalDataMachine = new DataTable();
            double[] allval = new double[3];
            try
            {
                int red = 0;
                int yellow = 0;
                int green = 0;
                DataTable dtMachine = DbClass.getdata(CommandType.Text, "select distinct Point_ID , PointName from point where Machine_ID = '" + NodeID + "'");
                if (dtMachine.Rows.Count > 0)
                {
                    foreach (DataRow drPoint in dtMachine.Rows)
                    {
                        int AlarmToken = getLegend("point_id =" + Convert.ToString(drPoint["Point_ID"]));
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
                        int totalPoint = dtMachine.Rows.Count;
                        try
                        {
                            if (red != 0)
                            {
                                allval[0] = Convert.ToDouble(red * 100 / totalPoint);
                            }
                            else
                            {
                                allval[0] = 0;
                            }
                            if (yellow != 0)
                            {
                                allval[1] = Convert.ToDouble(yellow * 100 / totalPoint);
                            }
                            else
                            {
                                allval[1] = 0;
                            }
                            if (green != 0)
                            {
                                allval[2] = Convert.ToDouble(green * 100 / totalPoint);
                            }
                            else if (red == 0 && yellow == 0)
                            {
                                allval[2] = 100;
                            }
                            else
                            {
                                allval[2] = 0;
                            }
                        }
                        catch { }
                    }
                }
                else
                {
                    allval[0] = 0.0;
                    allval[1] = 0.0;
                    allval[2] = 100.0;
                }
                FinalDataMachine.Columns.Add("Argument", typeof(string));
                FinalDataMachine.Columns.Add("Value", typeof(double));
                FinalDataMachine.Rows.Add("High Value", allval[0]);
                FinalDataMachine.Rows.Add("Low Value", allval[1]);
                FinalDataMachine.Rows.Add("Normal Value", allval[2]);

            }
            catch { }
            return FinalDataMachine;
        }

        public ArrayList GetPointData(int MachineID)
        {
            double[] allvalPoint = null;
            string[] colorcode = null;
            string[] PointName = null;
            string[] arrAlarm = null;
            int red = 0;
            int yellow = 0;
            int green = 0;
            try
            {
                DataTable dtPoint = DbClass.getdata(CommandType.Text, "Select distinct Point_ID ,  PointName from point where Machine_ID ='" + MachineID + "'");
                allvalPoint = new double[dtPoint.Rows.Count];
                PointName = new string[dtPoint.Rows.Count];
                colorcode = new string[dtPoint.Rows.Count];
                arrAlarm = new string[dtPoint.Rows.Count];
                int i = 0;
                if (dtPoint.Rows.Count > 0)
                {
                    foreach (DataRow drPoint in dtPoint.Rows)
                    {
                        int AlarmToken = getLegend("point_id =" + Convert.ToString(drPoint["Point_ID"]));
                        if (AlarmToken == 2)
                        {
                            colorcode[i] = "Red";
                        }
                        else if (AlarmToken == 1)
                        {
                            colorcode[i] = "Yellow";
                        }
                        else if (AlarmToken == 0)
                        {
                            colorcode[i] = "Green";
                        }
                        PointName[i] = Convert.ToString(drPoint["PointName"]);
                        allvalPoint[i] = GetAlarmType(Convert.ToInt32(drPoint["Point_ID"]), PublicClass.AlarmName);
                        arrAlarm[i] = PublicClass.AlarmName;
                        i++;
                    }
                    pointData.Add(PointName);
                    pointData.Add(colorcode);
                    pointData.Add(allvalPoint);
                    pointData.Add(arrAlarm);

                }
                else
                {
                }
            }
            catch { }
            return pointData;
        }

        public DataTable GetPointData(int NodeID, string nodeType)
        {
            DataTable FinalDataPoint = new DataTable();
            double[] allvalPoint = null;
            string[] PointName = null;

            try
            {
                int red = 0;
                int yellow = 0;
                int green = 0;
                DataTable dtPoint = DbClass.getdata(CommandType.Text, "Select distinct Point_ID ,  PointName from point where Point_ID = '" + NodeID + "'");
                allvalPoint = new double[3];
                PointName = new string[dtPoint.Rows.Count];
                int i = 0;
                if (dtPoint.Rows.Count > 0)
                {
                    foreach (DataRow drPoint in dtPoint.Rows)
                    {
                        int AlarmToken = getLegend("point_id =" + Convert.ToString(drPoint["Point_ID"]));
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
                        PointName[i] = Convert.ToString(drPoint["PointName"]);
                        i++;
                        //arrAlarm = GetAlarmType(i, Convert.ToInt32(drPoint["Point_ID"]), PublicClass.AlarmName);
                    }
                    int totalPoint = dtPoint.Rows.Count;
                    try
                    {
                        if (red != 0)
                        {
                            allvalPoint[0] = Convert.ToDouble(red * 100 / totalPoint);
                        }
                        else
                        {
                            allvalPoint[0] = 0;
                        }
                        if (yellow != 0)
                        {
                            allvalPoint[1] = Convert.ToDouble(yellow * 100 / totalPoint);
                        }
                        else
                        {
                            allvalPoint[1] = 0;
                        }
                        if (green != 0)
                        {
                            allvalPoint[2] = Convert.ToDouble(green * 100 / totalPoint);
                        }
                        else if (red == 0 && yellow == 0)
                        {
                            allvalPoint[2] = 100;
                        }
                        else
                        {
                            allvalPoint[2] = 0;
                        }
                    }
                    catch { }
                }
                else
                {
                    allvalPoint[0] = 0.0;
                    allvalPoint[1] = 0.0;
                    allvalPoint[2] = 100.0;
                }
                FinalDataPoint.Columns.Add("Argument", typeof(string));
                FinalDataPoint.Columns.Add("Value", typeof(double));
                for (int k = 0; k < allvalPoint.Length; k++)
                {
                    FinalDataPoint.Rows.Add(PointName[k], allvalPoint[k]);
                }
            }
            catch { }
            return FinalDataPoint;
        }
       
        public int getLegend(string Query)
        {
            int i = 0;
            try
            {
                DataTable dtt = new DataTable();
                dtt = DbClass.getdata(CommandType.Text, "select distinct  alarm_id from v_AllRecord  where " + Query + " and Alarm_ID <> '' ");
                if (dtt.Rows.Count > 0)
                {
                    string ids = "pd." + Query;
                    foreach (DataRow dr in dtt.Rows)
                    {
                        i = objUserControl.checkValueForFlagGenerate(ids, PublicClass.DefVal(Convert.ToString(dr["alarm_id"]), "0"), i);
                    }
                }
                else
                {
                    PublicClass.AlarmName = null;
                }



            }
            catch { }
            return i;
        }

        public double GetAlarmType(int pointid, string alarmType)
        {

            double alarmvalue = 0.0;

            try
            {
                switch (alarmType)
                {
                    case "Acceleration":
                        {
                            DataTable dtalarmvalue = DbClass.getdata(CommandType.Text, "Select Data_ID , greatest(accel_a , accel_h,accel_v,accel_ch1) as Acceleration_Value from point_data where Point_ID = '" + pointid + "' and Measure_time IN(Select max(Measure_time) from point_data where Point_ID = '" + pointid + "')");
                            alarmvalue = Convert.ToDouble(dtalarmvalue.Rows[0]["Acceleration_Value"]);
                            break;
                        }
                    case "Velocity":
                        {
                            DataTable dtalarmvalue = DbClass.getdata(CommandType.Text, "Select Data_ID , greatest(vel_a , vel_h,vel_v,vel_ch1) as Velocity_Value  from point_data where Point_ID = '" + pointid + "' and Measure_time IN(Select max(Measure_time) from point_data where Point_ID = '" + pointid + "')");
                            alarmvalue = Convert.ToDouble(dtalarmvalue.Rows[0]["Velocity_Value"]);
                            break;
                        }
                    case "Displacement":
                        {
                            DataTable dtalarmvalue = DbClass.getdata(CommandType.Text, "Select Data_ID , greatest(displ_a,displ_h,displ_v,displ_ch1) as Displacement_Value from point_data where Point_ID = '" + pointid + "' and Measure_time IN(Select max(Measure_time) from point_data where Point_ID = '" + pointid + "')");
                            alarmvalue = Convert.ToDouble(dtalarmvalue.Rows[0]["Displacement_Value"]);
                            break;
                        }
                    case "CreastFactor":
                        {
                            DataTable dtalarmvalue = DbClass.getdata(CommandType.Text, "Select Data_ID , greatest(crest_factor_a , crest_factor_h , crest_factor_v , crest_factor_ch1) as CreastFactor_Value from point_data where Point_ID = '" + pointid + "' and Measure_time IN(Select max(Measure_time) from point_data where Point_ID = '" + pointid + "')");
                            alarmvalue = Convert.ToDouble(dtalarmvalue.Rows[0]["CreastFactor_Value"]);
                            break;
                        }
                    case "Bearing":
                        {
                            DataTable dtalarmvalue = DbClass.getdata(CommandType.Text, "Select Data_ID , greatest(bearing_a , bearing_h , bearing_v , bearing_ch1) as Bearing_Value from point_data where Point_ID = '" + pointid + "' and Measure_time IN(Select max(Measure_time) from point_data where Point_ID = '" + pointid + "')");
                            alarmvalue = Convert.ToDouble(dtalarmvalue.Rows[0]["Bearing_Value"]);
                            break;
                        }
                }
            }
            catch { }
            return alarmvalue;
        }

        public void FunctionForBack(int level)
        {
          //  int aa = level;
            datasource = CreateData();
            CreateCharts(level);
        }

        private void frmAllDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                datasource = CreateData();
                CreateCharts(0);
            }
            catch { }
        }
    }









}