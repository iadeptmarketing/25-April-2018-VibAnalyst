using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Iadeptmain.GlobalClasses;
using Iadeptmain.Mainforms;
using System.Data.SqlClient;
using System.Collections;
using com.iAM.chart2dnet;
using Iadeptmain.Classes;
using Iadeptmain.BaseUserControl;
using Iadeptmain.Datasets;
using DevExpress.XtraEditors;

namespace Iadeptmain.Reports
{
    public partial class frmReport : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        frmIAdeptMain objMain = null;
        IadeptUserControl _objusercontrol=null;        
        public frmReport()
        {
            InitializeComponent();
            FillReportList();
        }

        public frmIAdeptMain MainForm
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

         public IadeptUserControl usercontrol
        {
            get
            {
                return _objusercontrol;
            }
            set
            {
                _objusercontrol = value;
            }
        }

        private void frmReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            objMain.WindowState = FormWindowState.Maximized;
        }

        public bool dailysts = false;
        public bool autosts = false;
        public void FillReportList()
        {
            try
            {
                lbReportingList.Items.Clear();
                DataTable dt = new DataTable();
                if (dailysts)
                {
                    autosts = false;
                    dt = DbClass.getdata(CommandType.Text, "Select distinct ReportName from allreport where ReportStatus='Daily'");
                }
                else if (autosts)
                {
                    dailysts = false;
                    dt = DbClass.getdata(CommandType.Text, "Select distinct ReportName from allreport where ReportStatus='Auto'");
                }
                else
                {
                    dailysts = false;
                    autosts = false;
                    dt = DbClass.getdata(CommandType.Text, "Select distinct ReportName from allreport ");
                }
                foreach (DataRow dr in dt.Rows)
                {
                    string rName = Convert.ToString(dr["ReportName"]);
                    lbReportingList.Items.Add(rName);
                }
            }
            catch
            {            }
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        private byte[] byteImageData;


        public string GetMachine(string Machine_id)
        {
            string manchinename = "";
            try
            {

                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "Select distinct machine_id,name from machine_info where name= '" + Machine_id.Trim() + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    manchinename = Convert.ToString(dr["machine_id"]);
                }
            }
            catch
            {
            }
            return manchinename;
        }



        public void GetDetail(string Machine_id, ref string Plantname, ref string Plantid, ref string AreaName, ref string Areaid, ref string TrainName, ref string Trainid, ref string MachineName)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select ma.machine_id,ma.Name 'MachineName',ta.train_id ,ta.Name as 'TrainName' ,ar.area_id,ar.Name as 'AreaName' ,fa.factory_id,fa.name as 'FactoryName'   from  machine_info ma left join train_info ta on ma.trainid=ta.train_id left join Area_info ar on ta.train_id= ar.area_id left join factory_info fa on ar.factoryid =fa.factory_id   where ma.machine_id= '" + Machine_id.Trim() + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    Machine_id = Convert.ToString(dr["machine_id"]);
                    MachineName = Convert.ToString(dr["MachineName"]);

                    Plantname = Convert.ToString(dr["FactoryName"]);
                    Plantid = Convert.ToString(dr["factory_id"]);

                    Areaid = Convert.ToString(dr["area_id"]);
                    AreaName = Convert.ToString(dr["AreaName"]);

                    Trainid = Convert.ToString(dr["train_id"]);
                    TrainName = Convert.ToString(dr["TrainName"]);
                }
            }
            catch
            {
            }
        }

        StringBuilder sbMultiValue = null;
        ImpaqHandler objImpaqHandler = new ImpaqHandler();
        ArrayList arrXYVals = new ArrayList();
        PointGeneral1 mpointgenerl = new PointGeneral1();
        double[] xx = new double[5];
        int[] yy = new int[5];
        double[] dXVals = null;
        double[] dYVals = null;
        ArrayList tempdates1 = new ArrayList();
        string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };

        string Yunits = null; string Xunits = null;
        public ChartView GeneratingGraphsForPointsNew(string sGraphtype, string sGraphDirection, string sPointID, string sPlantName, string sPointName)
        {           
            ChartView _ChartView = null;
            try
            {
                if (tempdates1.Count != 0)
                {
                    ArrayList tempdates = new ArrayList();
                    tempdates.Add(tempdates1[tempdates1.Count - 1]);

                    PublicClass.SPointID = sPointID;


                    arrXYVals = objImpaqHandler.GetAllPlotValues(sPointID, null, tempdates, sGraphtype, sGraphDirection);
                    mpointgenerl.RemoveChartObjects();
                    string P = sGraphDirection + sGraphtype;

                    if (arrXYVals.Count > 0)
                    {
                        dXVals = (double[])arrXYVals[0];
                        dYVals = (double[])arrXYVals[1];
                        ArrayList newxyval = new ArrayList();
                        double[][] darrValues = { dXVals, dYVals };
                        newxyval.Add(darrValues);
                        if (dXVals.Length > 1 && dYVals.Length > 1)
                        {
                            LineGraphControl _lineGraph = new LineGraphControl();
                            if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                            {
                                Yunits = mpointgenerl.getUnitValuesforgraph(sGraphtype);
                                Xunits = null;
                                switch (sGraphtype)
                                {
                                    case "Time":
                                    case "Cepstrum":
                                        {
                                            Xunits = "Sec";
                                            break;
                                        }
                                    case "Power":
                                    case "Power1":
                                    case "Power2":
                                    case "Power21":
                                    case "Power3":
                                    case "Power31":
                                    case "Demodulate":
                                        {
                                            Xunits = "Hz";
                                            break;
                                        }
                                    case "Trend":
                                        {
                                            Xunits = "Date and Time";
                                            break;
                                        }
                                }
                            }
                            else if (PublicClass.currentInstrument == "Kohtect-C911")
                            {
                                string unitDI = mpointgenerl.getUnitValuesC911();
                                string[] SelectedunitIDs = unitDI.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                Xunits = SelectedunitIDs[0];
                                Yunits = SelectedunitIDs[1];
                            }
                            else
                            {
                                string unitDI = mpointgenerl.getExtractCurrentUnit();
                                string[] SelectedunitIDs = unitDI.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                Xunits = SelectedunitIDs[0];
                                Yunits = SelectedunitIDs[1];
                            }
                            _ChartView = _lineGraph.DrawReportGraph(arrXYVals, ColorCode, Xunits, Yunits);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            return _ChartView;
        }
        //string Xunits = null; string Yunits = null;
        public ChartView GeneratingGraphsForPointsNew2(string sGraphtype, string sGraphDirection, string sPointID, string sPlantName, string sPointName , Double RPM)
        {   
            int[] Peeks = new int[0];
            double[] Peeks1 = new double[0];
            Peeks.Initialize();
            Peeks1.Initialize();
            Xdata12[0] = 0;
            Xdata12[1] = 0;
            Xdata12[2] = 0;
            Xdata12[3] = 0;
            Xdata12[4] = 0;

            Ydata12[0] = 0;
            Ydata12[1] = 0;
            Ydata12[2] = 0;
            Ydata12[3] = 0;
            Ydata12[4] = 0;

            ChartView _ChartView = null;
            try
            {
                if (tempdates1.Count != 0)
                {
                    ArrayList tempdates = new ArrayList();
                    tempdates.Add(tempdates1[tempdates1.Count - 1]);

                    PublicClass.SPointID = sPointID;


                    arrXYVals = objImpaqHandler.GetAllPlotValues(sPointID, null, tempdates, sGraphtype, sGraphDirection);
                    mpointgenerl.RemoveChartObjects();
                    string P = sGraphDirection + sGraphtype;

                    if (arrXYVals.Count > 0)
                    {
                        dXVals = (double[])arrXYVals[0];
                        dYVals = (double[])arrXYVals[1];
                        ArrayList newxyval = new ArrayList();
                        double[][] darrValues = { dXVals, dYVals };
                        newxyval.Add(darrValues);
                        if (dXVals.Length > 1 && dYVals.Length > 1)
                        {                          
                            LineGraphControl _lineGraph = new LineGraphControl();
                            if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                            {
                                Yunits = mpointgenerl.getUnitValuesforgraph(sGraphtype);                               
                                switch (sGraphtype)
                                {
                                    case "Time":
                                    case "Cepstrum":
                                        {
                                            Xunits = "Sec";
                                            break;
                                        }
                                    case "Power":
                                    case "Power1":
                                    case "Power2":
                                    case "Power21":
                                    case "Power3":
                                    case "Power31":
                                    case "Demodulate":
                                        {
                                            Xunits = "Hz";
                                            break;
                                        }
                                    case "Trend":
                                        {
                                            Xunits = "Date and Time";
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                string unitDI = null;
                                if (PublicClass.currentInstrument == "Kohtect-C911")
                                { unitDI = mpointgenerl.getUnitValuesC911(); }
                                else
                                {
                                    unitDI = mpointgenerl.getExtractCurrentUnit();
                                }
                                string[] SelectedunitIDs = unitDI.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                Xunits = SelectedunitIDs[0];
                                Yunits = SelectedunitIDs[1];
                            }
                            //_ChartView = _lineGraph.DrawReportGraph(arrXYVals, ColorCode, Xunits, Yunits);
                            if (PublicClass.ReportName == "Multi Overall and Multi Graph(Fault Frequency Based)")
                            {
                                _ChartView = _lineGraph.DrawReportGraph2(arrXYVals, ColorCode, Xunits, Yunits, RPM, objMain, PublicClass.ReportName, sPointID);
                                for (int i = 0; i < _lineGraph.xx1.Length; i++)
                                {
                                    if (_lineGraph.xx1[i] == 0)
                                        break;
                                    Xdata12[i] = _lineGraph.xx1[i];
                                    Ydata12[i] = _lineGraph.yy1[i];
                                }

                            }
                            else if (PublicClass.ReportName == "Multi Overall and Multi Graph(RPM Based)" || PublicClass.ReportName == "RPM Report for User selected Machine")
                            {
                                _ChartView = _lineGraph.DrawReportGraph2(arrXYVals, ColorCode, Xunits, Yunits, RPM, objMain, PublicClass.ReportName, sPointID);
                                for (int i = 0; i < _lineGraph.xx1.Length; i++)
                                {
                                    if (_lineGraph.xx1[i] == 0)
                                    {
                                        break;
                                    }
                                    Xdata12[i] = _lineGraph.xx1[i];
                                    Ydata12[i] = _lineGraph.yy1[i];
                                }

                            }
                            else if (PublicClass.ReportName == "Multi Overall and Multi Graph(Highest Peaks Based)")
                            {
                                double[] ff = new double[5];
                                double Fst = 0;
                                double Scnd = 0;
                                double Thrd = 0;
                                try
                                {
                                    for (int i = 2; i < dYVals.Length; i++)
                                    {
                                        Fst = dYVals[i - 2];
                                        Scnd = dYVals[i - 1];
                                        Thrd = dYVals[i];

                                        if (Fst < Scnd && Scnd > Thrd)
                                        {
                                            Array.Resize(ref Peeks, Peeks.Length + 1);
                                            Peeks[Peeks.Length - 1] = i - 1;
                                            Array.Resize(ref Peeks1, Peeks1.Length + 1);
                                            Peeks1[Peeks1.Length - 1] = dYVals[i - 1];

                                        }

                                    }
                                }
                                catch (Exception ex)
                                {
                                }
                                xx[0] = 0;
                                xx[1] = 0;
                                xx[2] = 0;
                                xx[3] = 0;
                                xx[4] = 0;
                                int pos = 0;
                                for (int ictrx = 0; ictrx < 5; ictrx++)
                                {
                                    for (int jctrx = ictrx; jctrx < Peeks1.Length; jctrx++)
                                    {
                                        if (xx[ictrx] < Peeks1[jctrx])
                                        {
                                            xx[ictrx] = Peeks1[jctrx];
                                            yy[ictrx] = Peeks[jctrx];
                                            pos = jctrx;
                                        }
                                    }
                                    Peeks1[pos] = 0;
                                    Peeks[pos] = 0;
                                }
                                _ChartView = _lineGraph.DrawReportGraph2(arrXYVals, ColorCode, Xunits, Yunits, RPM, objMain, PublicClass.ReportName, sPointID, yy);

                                for (int i = 0; i < _lineGraph.xx1.Length; i++)
                                {
                                    if (_lineGraph.xx1[i] == 0)
                                        break;
                                    Xdata12[i] = _lineGraph.xx1[i];
                                    Ydata12[i] = _lineGraph.yy1[i];
                                }
                            }
                            else if (PublicClass.ReportName == "Multi Overall and Multi Graph(Dominant Frequency Based)")
                            {
                                double[] ff = new double[5];
                                xx[0] = 0;

                                for (int ictrx = 0; ictrx < 1; ictrx++)
                                {
                                    for (int jctrx = ictrx; jctrx < dYVals.Length; jctrx++)
                                    {
                                        if (xx[ictrx] < dYVals[jctrx])
                                        {
                                            xx[ictrx] = dYVals[jctrx];
                                            yy[ictrx] = jctrx;
                                        }
                                    }
                                }
                                _ChartView = _lineGraph.DrawReportGraph2(arrXYVals, ColorCode, Xunits, Yunits, RPM, objMain, PublicClass.ReportName, sPointID, yy);
                                for (int i = 0; i < _lineGraph.xx1.Length; i++)
                                {
                                    if (_lineGraph.xx1[i] == 0)
                                    {
                                        break;
                                    }
                                       
                                    Xdata12[i] = _lineGraph.xx1[i];
                                    Ydata12[i] = _lineGraph.yy1[i];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
            return _ChartView;
        }

        private void GetOverallValues(string PointID, string type)
        {
            try
            {
                sbMultiValue = new StringBuilder();
                DataTable dt = new DataTable();
                string Query = "";
                if (Convert.ToString(type) == "Acceleration")
                {
                    Query = "accel_a,accel_h ,accel_v,accel_ch1";
                }
                else if (Convert.ToString(type) == "Velocity")
                {
                    Query = "vel_a,vel_h ,vel_v,vel_ch1";
                }
                else if (Convert.ToString(type) == "Displacement")
                {
                    Query = "displ_a,displ_h ,displ_v,displ_ch1";
                }
                else if (Convert.ToString(type) == "Bearing")
                {
                    Query = "bearing_a,bearing_h ,bearing_v,bearing_ch1";
                }
                dt = DbClass.getdata(CommandType.Text, "select  distinct " + Query + " ,Measure_time from point_data where point_id='" + PointID.Trim() + "' and Data_ID = '"+dataID+"'");

                sbMultiValue = new StringBuilder();
                int row = 0;
                foreach (DataRow drr in dt.Rows)
                {
                    sbMultiValue.Append(Convert.ToString(dt.Rows[row][0]).Trim());
                    sbMultiValue.Append("=");

                    sbMultiValue.Append(Convert.ToString(dt.Rows[row][1]).Trim());
                    sbMultiValue.Append("=");

                    sbMultiValue.Append(Convert.ToString(dt.Rows[row][2]).Trim());
                    sbMultiValue.Append("=");

                    sbMultiValue.Append(Convert.ToString(dt.Rows[row][3]).Trim());
                    sbMultiValue.Append("=");
                    sbMultiValue.Append(Convert.ToString(dt.Rows[row][4]).Trim());
                    sbMultiValue.Append("=");
                    row = row + 1;
                }
            }
            catch (Exception ex)
            {
            }
        }
        double[] Xdata12 = new double[5];
        double[] Ydata12 = new double[5];
        string dataID = null;       
        string ptID = null;
        frmreportselection frmselection = null;
        public void overallgraphforDi(string GType, string Overallvalue, string rp_name)
        {
            try
            {
                string PlantName = null; string pointname = null;
                string graphlabel = null; string graphdir = null;
                string sselctedPID = null; string chkPoint = null;
                ArrayList arrtime = new ArrayList();
                DataTable dtpoint_data = new DataTable(); DataTable dtpoint_data1 = new DataTable();
                dataID = null;
                ChartView _chartview = new ChartView();
                string graphtypevalue = GType;
                string overallvalue = Overallvalue;
                string[] AddValue = { "Axial", "Horizontal", "Vertical", "Channel1" };
                if (Convert.ToString(graphtypevalue).Trim() == "")
                {
                    return;
                }
                RptAllforDI objOverAllReport = new RptAllforDI();
                objOverAllReport.xrLabel2.Text = rp_name;
                objOverAllReport.xrTable4.Visible = true;
                //objOverAllReport.xrTable3.Visible = false;
                objOverAllReport.DetailReport1.Visible = true;
                frmHierrarchySelection MyReport = new frmHierrarchySelection();
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        objOverAllReport.xrLabel1.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        objOverAllReport.xrPictureBox1.Image = Image.FromFile(clogo);
                    }
                }
                catch { }
                MyReport.ShowDialog();
                splashScreenManager1.ShowWaitForm();
                string[] SelectedMachineIDs = MyReport.Machine_id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string mID = Convert.ToString(SelectedMachineIDs[0]);

                dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where Machine_ID ='" + mID + "' group by p.point_id");
                foreach (DataRow dr in dtpoint_data.Rows)
                {
                    sselctedPID += "'" + Convert.ToString(dr["point_id"]).Trim() + "',";
                }
                string newsssid = sselctedPID.Remove(sselctedPID.Length - 1);
                string newssgain = null;
                DataTable dt1 = new DataTable();
                if (PublicClass.ReportName == "With Single Channel Time Graph" || PublicClass.ReportName == "With Single Channel Power Graph" || PublicClass.ReportName == "Single Channel Graph for User Selected Machine")
                {
                    graphlabel = "Single Channel";
                    if (PublicClass.currentInstrument == "Kohtect-C911")
                    {
                        dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and (di.Channel1 !='3' and di.Channel2='3')or(di.Channel1 ='3' and di.Channel2!='3') and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                    }
                    else
                    {
                        newssgain = "'0','1','2'";
                        dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.ChannelType in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                    }
                }
                else if (PublicClass.ReportName == "With Dual Channel Time Graph" || PublicClass.ReportName == "With Dual Channel Power Graph" || PublicClass.ReportName == "Dual Channel Graph for User Selected Machine")
                {
                    graphlabel = "Dual Channel";
                    if (PublicClass.currentInstrument == "Kohtect-C911")
                    {
                        dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and (di.Channel1 !='3' and di.Channel2 !='3') and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                    }
                    else
                    {
                        newssgain = "'3','4'";
                        dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.ChannelType in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                    }
                }
                else if (PublicClass.ReportName == "Overall Values Of Displacement with Time Graph" || PublicClass.ReportName == "Overall Values Of Displacement with Power Graph")
                {
                    graphlabel = "Displacement Graph";
                    graphdir = "displ_";
                    if (PublicClass.currentInstrument == "Kohtect-C911")
                    {
                        newssgain = "'2'";
                        dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.SelectRadio1 in(" + newssgain + ") or di.SelectRadio2 in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                    }
                    else
                    {
                        newssgain = "'3','4','7','8','9','10','26','27'";
                        dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.Type_Unit in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                    }
                }
                else if (PublicClass.ReportName == "Overall Values Of Acceleration with Time Graph" || PublicClass.ReportName == "Overall Values Of Acceleration with Power Graph")
                {
                    graphlabel = "Acceleration Graph";
                    graphdir = "accel_";
                    if (PublicClass.currentInstrument == "Kohtect-C911")
                    {
                        newssgain = "'0'";
                        dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.SelectRadio1 in(" + newssgain + ") or di.SelectRadio2 in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                    }
                    else
                    {
                        newssgain = "'0','23'";
                        dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time,pa.accel_a,pa.accel_h,pa.accel_v,pa.accel_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.Type_Unit in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                    }
                }
                else
                {
                    graphlabel = "Velocity Graph";
                    graphdir = "vel_";
                    if (PublicClass.currentInstrument == "Kohtect-C911")
                    {
                        newssgain = "'0'";
                        dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.SelectRadio1 in(" + newssgain + ") or di.SelectRadio2 in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                    }
                    else
                    {
                        newssgain = "'1','2','5','6','24','25'";
                        dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.Type_Unit in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                    }
                }
                if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    foreach (DataRow dr in dt1.Rows)
                    {
                        string pointid = Convert.ToString(dr["point_id"]).Trim();
                        ptID = pointid;
                        PublicClass.SPointID = pointid;
                        if (ptID != chkPoint)
                        {
                            string measuretime = null;
                            string unitDI = mpointgenerl.getUnitValuesC911();
                            string[] SelectedunitIDs = unitDI.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                            Yunits = SelectedunitIDs[1];

                            dtpoint_data1 = DbClass.getdata(CommandType.Text, "select distinct alar.alarm_name,fac.name as fname,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "' group by pd.Point_id");
                            foreach (DataRow dr1 in dtpoint_data1.Rows)
                            {
                                DataRow hieRow = objOverAllReport.multiData1.HirarchyTable.NewRow();
                                hieRow["Factory"] = Convert.ToString(dr1["fname"]);
                                PlantName = Convert.ToString(dr1["fname"]);
                                hieRow["Area"] = Convert.ToString(dr1["areaname"]);
                                hieRow["Train"] = Convert.ToString(dr1["tname"]);
                                hieRow["Machine"] = Convert.ToString(dr1["macname"]);
                                hieRow["Point"] = Convert.ToString(dr1["pname"]);
                                pointname = Convert.ToString(dr1["pname"]);
                                hieRow["Point_Id"] = PublicClass.SPointID;
                                objOverAllReport.multiData1.HirarchyTable.Rows.Add(hieRow);
                                objOverAllReport.multiData1.HirarchyTable.AcceptChanges();
                                DataTable dtagain = DbClass.getdata(CommandType.Text, "select distinct di.Channel1,di.Channel2,di.SelectRadio1,di.SelectRadio2,alar.alarm_name,fac.name as fname,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "'");
                                foreach (DataRow dr2 in dtagain.Rows)
                                {
                                    string overalltype = null;
                                    DataRow hieRow1 = objOverAllReport.multiData1.Data.NewRow();
                                    hieRow1["Date"] = Convert.ToString(dr2["Measuredate"]);
                                    measuretime = Convert.ToDateTime(dr2["Measuredate"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    hieRow1["Point_ID"] = Convert.ToString(dr["point_id"]).Trim();
                                    string chl1 = Convert.ToString(dr2["Channel1"]);
                                    string chl2 = Convert.ToString(dr2["Channel2"]);
                                    string dir1 = Convert.ToString(dr2["SelectRadio1"]);
                                    string dir2 = Convert.ToString(dr2["SelectRadio2"]);
                                    if (chl1 == "0" || chl1 == "1" || chl1 == "2")
                                    {
                                        if (dir1 == "0")
                                        { overalltype = "accel_h"; }
                                        else if (dir1 == "1")
                                        { overalltype = "vel_h"; }
                                        else if (dir1 == "2")
                                        { overalltype = "displ_h"; }
                                        hieRow1["Label"] = "CH:- 1";
                                    }
                                    else
                                    {
                                        if (dir2 == "0")
                                        { overalltype = "accel_v"; }
                                        else if (dir2 == "1")
                                        { overalltype = "vel_v"; }
                                        else if (dir2 == "2")
                                        { overalltype = "displ_v"; }
                                        hieRow1["Label"] = "CH:- 2";
                                    }
                                    hieRow1["Value"] = Convert.ToString(dr2[overalltype]) + ' ' + Yunits;
                                    objOverAllReport.multiData1.Data.Rows.Add(hieRow1);
                                    objOverAllReport.multiData1.Data.AcceptChanges();

                                    //---creating graph--// 
                                    tempdates1.Add(measuretime);
                                    for (int aa = 0; aa < AddValue.Length; aa++)
                                    {
                                        if (GType == "Time")
                                        {
                                            _chartview = GeneratingGraphsForPointsNew("Time", AddValue[aa], pointid, PlantName, pointname);
                                        }
                                        else if (GType == "Power")
                                        {
                                            _chartview = GeneratingGraphsForPointsNew("Power", AddValue[aa], pointid, PlantName, pointname);
                                        }
                                        else
                                        {
                                            _chartview = GeneratingGraphsForPointsNew("Power", AddValue[aa], pointid, PlantName, pointname);
                                        }
                                        if (_chartview != null)
                                        {
                                            BufferedImage objImage = new BufferedImage(_chartview);
                                            Image GraphImage = (Image)objImage.GetBufferedImage();
                                            byteImageData = ImageToByte(GraphImage);
                                            DataRow ObjGraphRow = objOverAllReport.multiData1.GraphImage.NewRow();
                                            ObjGraphRow["Graph"] = byteImageData;
                                            ObjGraphRow["Point_ID"] = pointid;
                                            ObjGraphRow["GraphLabel"] = graphlabel + " " + AddValue[aa];//Convert.ToString(sarrMultiReportName[rr] + " " + AddValue[aa]);
                                            objOverAllReport.multiData1.GraphImage.Rows.Add(ObjGraphRow);
                                            objOverAllReport.multiData1.GraphImage.AcceptChanges();
                                        }
                                    }
                                }
                            }
                        }
                        chkPoint = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                    }
                }
                else
                {
                    foreach (DataRow dr in dt1.Rows)
                    {
                        string pointid = Convert.ToString(dr["point_id"]).Trim();
                        ptID = pointid; string measuretime = null;
                        PublicClass.SPointID = pointid;
                        if (ptID != chkPoint)
                        {          
                            dtpoint_data1 = DbClass.getdata(CommandType.Text, "select distinct alar.alarm_name,fac.name as fname,di.ChannelType as ChannelType,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join di_point di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "' group by pd.Point_id");
                            foreach (DataRow dr1 in dtpoint_data1.Rows)
                            {
                                DataRow hieRow = objOverAllReport.multiData1.HirarchyTable.NewRow();
                                hieRow["Factory"] = Convert.ToString(dr1["fname"]);
                                PlantName = Convert.ToString(dr1["fname"]);
                                hieRow["Area"] = Convert.ToString(dr1["areaname"]);
                                hieRow["Train"] = Convert.ToString(dr1["tname"]);
                                hieRow["Machine"] = Convert.ToString(dr1["macname"]);
                                hieRow["Point"] = Convert.ToString(dr1["pname"]);
                                pointname = Convert.ToString(dr1["pname"]);
                                hieRow["Point_Id"] = PublicClass.SPointID;
                                objOverAllReport.multiData1.HirarchyTable.Rows.Add(hieRow);
                                objOverAllReport.multiData1.HirarchyTable.AcceptChanges();
                                int aa = 0;
                                DataTable dtagain = DbClass.getdata(CommandType.Text, "select distinct di.Type_Unit,pd.data_id,alar.alarm_name,fac.name as fname,di.ChannelType as ChannelType,di.direction as direction,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join di_point di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "'");
                                foreach (DataRow dr2 in dtagain.Rows)
                                {
                                    if (graphlabel == "Dual Channel" || graphlabel == "Single Channel")
                                    {
                                        string cc = Convert.ToString(dr2["Type_Unit"]);
                                        if (cc == "0" || cc == "23")
                                        {
                                            graphdir = "accel_";
                                        }
                                        else if (cc == "3" || cc == "4" || cc == "7" || cc == "8" || cc == "9" || cc == "10" || cc == "26" || cc == "27")
                                        {
                                            graphdir = "displ_";
                                        }
                                        else if (cc == "1" || cc == "2" || cc == "5" || cc == "6" || cc == "24" || cc == "25")
                                        {
                                            graphdir = "vel_";
                                        }
                                    }
                                    for (aa = 0; aa >= 0; aa++)
                                    {
                                        if (Convert.ToString(dr1["ChannelType"]) == "0" || Convert.ToString(dr1["ChannelType"]) == "1" || Convert.ToString(dr1["ChannelType"]) == "2")
                                        {
                                            if (aa == 1)
                                            {
                                                break;
                                            }
                                        }
                                        else if (Convert.ToString(dr1["ChannelType"]) == "3" || Convert.ToString(dr1["ChannelType"]) == "4")
                                        {
                                            if (aa == 3)
                                            {
                                                break;
                                            }
                                        }
                                        string bb = null; string valueover = null;
                                        string intdir = Convert.ToString(dr2["direction"]);
                                        if (graphdir == "accel_")
                                        {
                                            if (intdir == "0")//h
                                            {
                                                bb = "accel_h";
                                                valueover = Convert.ToString(dr2["accel_h"]);
                                            }
                                            else if (intdir == "1")//v
                                            {
                                                bb = "accel_v"; valueover = Convert.ToString(dr2["accel_v"]);
                                            }
                                            else if (intdir == "2")//a
                                            {
                                                bb = "accel_a"; valueover = Convert.ToString(dr2["accel_a"]);
                                            }
                                            //aa = 1;
                                        }
                                        else if (graphdir == "displ_")
                                        {
                                            if (intdir == "0")//h
                                            {
                                                bb = "displ_h"; valueover = Convert.ToString(dr2["displ_h"]);
                                            }
                                            else if (intdir == "1")//v
                                            {
                                                bb = "displ_v"; valueover = Convert.ToString(dr2["displ_v"]);
                                            }
                                            else if (intdir == "2")//a
                                            {
                                                bb = "displ_a"; valueover = Convert.ToString(dr2["displ_a"]);
                                            }
                                        }
                                        else if (graphdir == "vel_")
                                        {
                                            if (intdir == "0")//h
                                            {
                                                bb = "vel_h"; valueover = Convert.ToString(dr2["vel_h"]);
                                            }
                                            else if (intdir == "1")//v
                                            {
                                                bb = "vel_v"; valueover = Convert.ToString(dr2["vel_v"]);
                                            }
                                            else if (intdir == "2")//a
                                            {
                                                bb = "vel_a"; valueover = Convert.ToString(dr2["vel_a"]);
                                            }
                                        }
                                        PublicClass.Data_ID = Convert.ToString(dr2["data_id"]);
                                        DataRow hieRow1 = objOverAllReport.multiData1.Data.NewRow();
                                        hieRow1["Date"] = Convert.ToString(dr2["Measuredate"]);
                                        measuretime = Convert.ToDateTime(dr2["Measuredate"]).ToString("yyyy-MM-dd HH:mm:ss");
                                        hieRow1["Point_ID"] = Convert.ToString(dr["point_id"]).Trim();
                                        if (Convert.ToString(dr1["ChannelType"]) == "0" || Convert.ToString(dr1["ChannelType"]) == "1" || Convert.ToString(dr1["ChannelType"]) == "2")
                                        {
                                            hieRow1["Value"] = valueover + ' ' + Yunits;
                                            hieRow1["Label"] = "CH:- 1";
                                        }
                                        else if (Convert.ToString(dr1["ChannelType"]) == "3" || Convert.ToString(dr1["ChannelType"]) == "4")
                                        {
                                            if (aa == 0)
                                            {
                                                hieRow1["Value"] = valueover + ' ' + Yunits;
                                                hieRow1["Label"] = "CH:- 1";
                                                aa++;
                                            }
                                            else
                                            {
                                                if (graphdir == "accel_")
                                                {
                                                    valueover = Convert.ToString(dr2["accel_ch1"]);
                                                }
                                                else if (graphdir == "displ_")
                                                { valueover = Convert.ToString(dr2["displ_ch1"]); }
                                                else if (graphdir == "vel_")
                                                { valueover = Convert.ToString(dr2["vel_ch1"]); }

                                                hieRow1["Value"] = valueover + ' ' + Yunits;
                                                hieRow1["Label"] = "CH:- 2";
                                            }
                                        }
                                        objOverAllReport.multiData1.Data.Rows.Add(hieRow1);
                                        objOverAllReport.multiData1.Data.AcceptChanges();

                                    }
                                }
                            }
                            tempdates1.Add(measuretime);
                            for (int aa = 0; aa < AddValue.Length; aa++)
                            {
                                if (GType == "Time")
                                {
                                    _chartview = GeneratingGraphsForPointsNew("Time", AddValue[aa], pointid, PlantName, pointname);
                                }
                                else if (GType == "Power")
                                {
                                    _chartview = GeneratingGraphsForPointsNew("Power", AddValue[aa], pointid, PlantName, pointname);
                                }
                                else
                                {
                                    _chartview = GeneratingGraphsForPointsNew("Power", AddValue[aa], pointid, PlantName, pointname);
                                }
                                if (_chartview != null)
                                {
                                    BufferedImage objImage = new BufferedImage(_chartview);
                                    Image GraphImage = (Image)objImage.GetBufferedImage();
                                    byteImageData = ImageToByte(GraphImage);
                                    DataRow ObjGraphRow = objOverAllReport.multiData1.GraphImage.NewRow();
                                    ObjGraphRow["Graph"] = byteImageData;
                                    ObjGraphRow["Point_ID"] = pointid;
                                    ObjGraphRow["GraphLabel"] = graphlabel + " " + AddValue[aa];//Convert.ToString(sarrMultiReportName[rr] + " " + AddValue[aa]);
                                    objOverAllReport.multiData1.GraphImage.Rows.Add(ObjGraphRow);
                                    objOverAllReport.multiData1.GraphImage.AcceptChanges();
                                }
                            }
                        }
                        chkPoint = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                    }
                }
                printControl1.PrintingSystem = objOverAllReport.PrintingSystem;
                objOverAllReport.CreateDocument();
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }

        public void Timetofft(string GType, string Overallvalue, string rp_name)
        {
            try
            {
                string graphlabel = null; string graphdir = null;
                string sselctedPID = null; string chkPoint = null;
                ArrayList arrtime = new ArrayList();
                dataID = null;
                ChartView _chartview = new ChartView();
                string graphtypevalue = GType;
                string overallvalue = Overallvalue;
                string[] AddValue = { "Axial", "Horizontal", "Vertical", "Channel1" };
                if (Convert.ToString(graphtypevalue).Trim() == "")
                {
                    return;
                }
                RptAllforDI objOverAllReport = new RptAllforDI();
                objOverAllReport.xrLabel2.Text = rp_name;
                objOverAllReport.xrTable4.Visible = true;
                //objOverAllReport.xrTable3.Visible = false;
                objOverAllReport.DetailReport1.Visible = true;
                frmHierrarchySelection MyReport = new frmHierrarchySelection();
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        objOverAllReport.xrLabel1.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        objOverAllReport.xrPictureBox1.Image = Image.FromFile(clogo);
                    }
                }
                catch { }
                MyReport.ShowDialog();
                splashScreenManager1.ShowWaitForm();
                string[] SelectedMachineIDs = MyReport.Machine_id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string mID = Convert.ToString(SelectedMachineIDs[0]);

                DataTable dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where Machine_ID ='" + mID + "' group by p.point_id");
                foreach (DataRow dr in dtpoint_data.Rows)
                {
                    sselctedPID += "'" + Convert.ToString(dr["point_id"]).Trim() + "',";
                }
                string newsssid = sselctedPID.Remove(sselctedPID.Length - 1);
                string newssgain = null;
                DataTable dt1 = new DataTable();
                if (PublicClass.ReportName == "Time wave to FFT Graph")
                {
                    graphlabel = "Time TO FFT";
                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.MeasureType='2' and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                }
                else if (PublicClass.ReportName == "With Single Channel Time Graph" || PublicClass.ReportName == "With Single Channel Power Graph")
                {
                    graphlabel = "Single Channel";
                    newssgain = "'0','1','2'";
                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.ChannelType in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                }
                else if (PublicClass.ReportName == "With Dual Channel Time Graph" || PublicClass.ReportName == "With Dual Channel Power Graph")
                {
                    graphlabel = "Dual Channel";
                    newssgain = "'3','4'";
                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.ChannelType in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                }
                else if (PublicClass.ReportName == "Overall Values Of Displacement with Time Graph" || PublicClass.ReportName == "Overall Values Of Displacement with Power Graph")
                {
                    graphlabel = "Displacement Graph";
                    graphdir = "displ_";
                    newssgain = "'3','4','7','8','9','10','26','27'";
                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.Type_Unit in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                }
                else if (PublicClass.ReportName == "Overall Values Of Acceleration with Time Graph" || PublicClass.ReportName == "Overall Values Of Acceleration with Power Graph")
                {
                    graphlabel = "Acceleration Graph";
                    graphdir = "accel_";
                    newssgain = "'0','23'";
                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time,pa.accel_a,pa.accel_h,pa.accel_v,pa.accel_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.Type_Unit in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                }
                else
                {
                    graphlabel = "Velocity Graph";
                    graphdir = "vel_";
                    newssgain = "'1','2','5','6','24','25'";
                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.Type_Unit in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                }
                foreach (DataRow dr in dt1.Rows)
                {
                    string pointid = Convert.ToString(dr["point_id"]).Trim();
                    ptID = pointid; string measuretime = null;
                    PublicClass.SPointID = pointid;
                    if (ptID != chkPoint)
                    {
                        string PlantName = null; string pointname = null;
                        DataTable dtpoint_data1 = new DataTable();
                        dtpoint_data1 = DbClass.getdata(CommandType.Text, "select distinct alar.alarm_name,fac.name as fname,di.ChannelType as ChannelType,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join di_point di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "' group by pd.Point_id");
                        foreach (DataRow dr1 in dtpoint_data1.Rows)
                        {
                            DataRow hieRow = objOverAllReport.multiData1.HirarchyTable.NewRow();
                            hieRow["Factory"] = Convert.ToString(dr1["fname"]);
                            PlantName = Convert.ToString(dr1["fname"]);
                            hieRow["Area"] = Convert.ToString(dr1["areaname"]);
                            hieRow["Train"] = Convert.ToString(dr1["tname"]);
                            hieRow["Machine"] = Convert.ToString(dr1["macname"]);
                            hieRow["Point"] = Convert.ToString(dr1["pname"]);
                            pointname = Convert.ToString(dr1["pname"]);
                            hieRow["Point_Id"] = PublicClass.SPointID;
                            objOverAllReport.multiData1.HirarchyTable.Rows.Add(hieRow);
                            objOverAllReport.multiData1.HirarchyTable.AcceptChanges();
                            int aa = 0;
                            DataTable dtagain = DbClass.getdata(CommandType.Text, "select distinct pd.data_id,alar.alarm_name,fac.name as fname,di.ChannelType as ChannelType,di.direction as direction,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join di_point di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "'");
                            foreach (DataRow dr2 in dtagain.Rows)
                            {
                                if (graphlabel == "Dual Channel" || graphlabel == "Time TO FFT" || graphlabel == "Single Channel")
                                {
                                    string cc = Convert.ToString(dr2["direction"]);
                                    if (cc == "0" || cc == "23")
                                    {
                                        graphdir = "accel_";
                                    }
                                    else if (cc == "3" || cc == "4" || cc == "7" || cc == "8" || cc == "9" || cc == "10" || cc == "26" || cc == "27")
                                    {
                                        graphdir = "displ_";
                                    }
                                    else if (cc == "1" || cc == "2" || cc == "5" || cc == "6" || cc == "24" || cc == "25")
                                    {
                                        graphdir = "vel_";
                                    }
                                }
                                for (aa = 0; aa >= 0; aa++)
                                {
                                    if (aa == 3)
                                    {
                                        break;
                                    }
                                    string bb = null; string valueover = null;
                                    string intdir = Convert.ToString(dr2["direction"]);
                                    if (graphdir == "accel_")
                                    {
                                        if (intdir == "0")//h
                                        {
                                            bb = "accel_h";
                                            valueover = Convert.ToString(dr2["accel_h"]);
                                        }
                                        else if (intdir == "1")//v
                                        {
                                            bb = "accel_v"; valueover = Convert.ToString(dr2["accel_v"]);
                                        }
                                        else if (intdir == "2")//a
                                        {
                                            bb = "accel_a"; valueover = Convert.ToString(dr2["accel_a"]);
                                        }
                                        //aa = 1;
                                    }
                                    else if (graphdir == "displ_")
                                    {
                                        if (intdir == "0")//h
                                        {
                                            bb = "displ_h"; valueover = Convert.ToString(dr2["displ_h"]);
                                        }
                                        else if (intdir == "1")//v
                                        {
                                            bb = "displ_v"; valueover = Convert.ToString(dr2["displ_v"]);
                                        }
                                        else if (intdir == "2")//a
                                        {
                                            bb = "displ_a"; valueover = Convert.ToString(dr2["displ_a"]);
                                        }
                                    }
                                    else if (graphdir == "vel_")
                                    {
                                        if (intdir == "0")//h
                                        {
                                            bb = "vel_h"; valueover = Convert.ToString(dr2["vel_h"]);
                                        }
                                        else if (intdir == "1")//v
                                        {
                                            bb = "vel_v"; valueover = Convert.ToString(dr2["vel_v"]);
                                        }
                                        else if (intdir == "2")//a
                                        {
                                            bb = "vel_a"; valueover = Convert.ToString(dr2["vel_a"]);
                                        }
                                    }
                                    PublicClass.Data_ID = Convert.ToString(dr2["data_id"]);
                                    DataRow hieRow1 = objOverAllReport.multiData1.Data.NewRow();
                                    hieRow1["Date"] = Convert.ToString(dr2["Measuredate"]);
                                    measuretime = Convert.ToDateTime(dr2["Measuredate"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    hieRow1["Point_ID"] = Convert.ToString(dr["point_id"]).Trim();
                                    if (Convert.ToString(dr1["ChannelType"]) == "0" || Convert.ToString(dr1["ChannelType"]) == "1" || Convert.ToString(dr1["ChannelType"]) == "2")
                                    {
                                        hieRow1["Value"] = valueover + ' ' + Yunits;
                                        hieRow1["Label"] = "CH:- 1";
                                    }
                                    else if (Convert.ToString(dr1["ChannelType"]) == "3" || Convert.ToString(dr1["ChannelType"]) == "4")
                                    {
                                        if (aa == 0)
                                        {
                                            hieRow1["Value"] = valueover + ' ' + Yunits;
                                            hieRow1["Label"] = "CH:- 1";
                                            aa++;
                                        }
                                        else
                                        {
                                            if (graphdir == "accel_")
                                            {
                                                valueover = Convert.ToString(dr2["accel_ch1"]);
                                            }
                                            else if (graphdir == "displ_")
                                            { valueover = Convert.ToString(dr2["displ_ch1"]); }
                                            else if (graphdir == "vel_")
                                            { valueover = Convert.ToString(dr2["vel_ch1"]); }

                                            hieRow1["Value"] = valueover + ' ' + Yunits;
                                            hieRow1["Label"] = "CH:- 2";
                                        }
                                    }
                                    objOverAllReport.multiData1.Data.Rows.Add(hieRow1);
                                    objOverAllReport.multiData1.Data.AcceptChanges();

                                }
                            }
                        }
                        tempdates1.Add(measuretime);
                        for (int aa = 0; aa < AddValue.Length; aa++)
                        {
                            if (GType == "Time")
                            {
                                _chartview = GeneratingGraphsForPointsNew("Time", AddValue[aa], pointid, PlantName, pointname);
                            }
                            else if (GType == "Power")
                            {
                                _chartview = GeneratingGraphsForPointsNew("Power", AddValue[aa], pointid, PlantName, pointname);
                            }
                            else
                            {
                                _chartview = GeneratingGraphsForPointsNew("Power", AddValue[aa], pointid, PlantName, pointname);
                            }
                            if (_chartview != null)
                            {
                                BufferedImage objImage = new BufferedImage(_chartview);
                                Image GraphImage = (Image)objImage.GetBufferedImage();
                                byteImageData = ImageToByte(GraphImage);
                                DataRow ObjGraphRow = objOverAllReport.multiData1.GraphImage.NewRow();
                                ObjGraphRow["Graph"] = byteImageData;
                                ObjGraphRow["Point_ID"] = pointid;
                                ObjGraphRow["GraphLabel"] = graphlabel + " " + AddValue[aa];//Convert.ToString(sarrMultiReportName[rr] + " " + AddValue[aa]);
                                objOverAllReport.multiData1.GraphImage.Rows.Add(ObjGraphRow);
                                objOverAllReport.multiData1.GraphImage.AcceptChanges();
                                if (GType == "Time")
                                {
                                    ChartView _chartview1 = new ChartView();
                                    ConvertToFFT.TWFtoFFT _Convert = new ConvertToFFT.TWFtoFFT();
                                    ArrayList NewValues = _Convert.ConvertTWFtoFFT(dXVals, dYVals, "Sec", Yunits);
                                    if (NewValues != null)
                                    {
                                        dXVals = (double[])NewValues[0];
                                        dYVals = (double[])NewValues[1];
                                        Yunits = (string)NewValues[3];
                                        objMain.DrawLineGraphsforDi(dXVals, dYVals, "Sec", Yunits);
                                        _chartview1 = objMain._ChartViewDI;
                                        BufferedImage objImage1 = new BufferedImage(_chartview1);
                                        Image GraphImage1 = (Image)objImage1.GetBufferedImage();
                                        byteImageData = ImageToByte(GraphImage1);
                                        DataRow ObjGraphRow1 = objOverAllReport.multiData1.GraphImage.NewRow();
                                        ObjGraphRow1["Graph"] = byteImageData;
                                        ObjGraphRow1["Point_ID"] = pointid;
                                        ObjGraphRow1["GraphLabel"] = graphlabel + " " + AddValue[aa];//Convert.ToString(sarrMultiReportName[rr] + " " + AddValue[aa]);
                                        objOverAllReport.multiData1.GraphImage.Rows.Add(ObjGraphRow1);
                                        objOverAllReport.multiData1.GraphImage.AcceptChanges();
                                    }

                                }
                            }
                        }
                    }
                    chkPoint = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                }
                printControl1.PrintingSystem = objOverAllReport.PrintingSystem;
                objOverAllReport.CreateDocument();
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }

        string GType = null;
        public void trendforDi(string GType, string Overallvalue, string rp_name)
        {
            try
            {
                ArrayList arrXYVals = null;
                ArrayList arrtime = new ArrayList();
                dataID = null;               
                ChartView _chartview = new ChartView();
                string graphtypevalue = GType;
                string overallvalue = Overallvalue;
                if (Convert.ToString(graphtypevalue).Trim() == "")
                {
                    return;
                }
                RptAllforDI objOverAllReport = new RptAllforDI();
                objOverAllReport.xrLabel2.Text = rp_name;
                objOverAllReport.DetailReport1.Visible = true;
                frmHierrarchySelection MyReport = new frmHierrarchySelection();
                MyReport.ShowDialog();
                splashScreenManager1.ShowWaitForm();
                string[] SelectedMachineIDs = MyReport.Machine_id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string mID = Convert.ToString(SelectedMachineIDs[0]);
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        objOverAllReport.xrLabel1.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        objOverAllReport.xrPictureBox1.Image = Image.FromFile(clogo);
                    }
                }
                catch { }

                DataTable dtpoint_data = new DataTable();
                if (PublicClass.ReportName == "Point Report with Overall Trend Graph")
                {
                    StringBuilder sbm = new StringBuilder();
                    for(int i=0;i< SelectedMachineIDs.Length;i++)
                    {
                        sbm.Append ("'" + SelectedMachineIDs[i] + "',");
                       
                    }
                    sbm.Replace(",}", "}");
                    sbm.Remove(sbm.Length-1, 1);
                    string macid = Convert.ToString(sbm);




                    dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where p.point_id IN (" + macid + ") group by p.point_id");
                }
                else
                {
                    dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where Machine_ID ='" + mID + "' group by p.point_id");
                }
                foreach (DataRow dr in dtpoint_data.Rows)
                {
                    double dAccel_h = 0; double dX= 0;
                    double[] dYData = null; double[] dXData = null;
                    arrXYVals = new ArrayList();
                    LineGraphControl _LineGraph = new LineGraphControl();
                    string pointid = Convert.ToString(dr["point_id"]).Trim();
                    DataTable dt = DbClass.getdata(CommandType.Text, "select distinct alar.alarm_name,fac.name as fname,di.Type_Unit,di.direction,di.ChannelType as ChannelType,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join di_point di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "'");
                    if (dt.Rows.Count > 1)
                    {
                        dYData = new double[dt.Rows.Count]; dXData = new double[dt.Rows.Count]; int count = 0;
                        string[] XDataLabels = new string[dt.Rows.Count];
                        PublicClass.SPointID = pointid; string unitDI = null;
                        if (PublicClass.currentInstrument == "Kohtect-C911")
                        { unitDI = mpointgenerl.getUnitValuesC911(); }
                        else
                        { unitDI = mpointgenerl.getExtractCurrentUnit(); }
                        string[] SelectedunitIDs = unitDI.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        Yunits = SelectedunitIDs[1];
                        DataRow hieRow = objOverAllReport.multiData1.HirarchyTable.NewRow();
                        hieRow["Factory"] = Convert.ToString(dt.Rows[0]["fname"]);
                        hieRow["Area"] = Convert.ToString(dt.Rows[0]["areaname"]);
                        hieRow["Train"] = Convert.ToString(dt.Rows[0]["tname"]);
                        hieRow["Machine"] = Convert.ToString(dt.Rows[0]["macname"]);
                        hieRow["Point"] = Convert.ToString(dt.Rows[0]["pname"]);
                        hieRow["Point_Id"] = pointid;
                        objOverAllReport.multiData1.HirarchyTable.Rows.Add(hieRow);
                        objOverAllReport.multiData1.HirarchyTable.AcceptChanges();
                        if (PublicClass.currentInstrument == "Kohtect-C911")
                        {
                            DataTable dtagain = DbClass.getdata(CommandType.Text, "select distinct di.Channel1,di.Channel2,di.SelectRadio1,di.SelectRadio2,alar.alarm_name,fac.name as fname,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "'");
                            foreach (DataRow dr2 in dtagain.Rows)
                            {
                                string overalltype = null;
                                DataRow hieRow1 = objOverAllReport.multiData1.Data.NewRow();
                                hieRow1["Date"] = Convert.ToString(dr2["Measuredate"]);
                                string sTime = Convert.ToDateTime(dr2["Measuredate"]).ToString("yyyy-MM-dd HH:mm:ss");
                                arrtime.Add(sTime);
                                XDataLabels[count] = sTime;
                                dX = arrtime.Count;
                                dXData[count] = dX;
                                string chl1 = Convert.ToString(dr2["Channel1"]);
                                string chl2 = Convert.ToString(dr2["Channel2"]);
                                string dir1 = Convert.ToString(dr2["SelectRadio1"]);
                                string dir2 = Convert.ToString(dr2["SelectRadio2"]);
                                if (chl1 == "0" || chl1 == "1" || chl1 == "2")
                                {
                                    if (dir1 == "0")
                                    { overalltype = "accel_h"; }
                                    else if (dir1 == "1")
                                    { overalltype = "vel_h"; }
                                    else if (dir1 == "2")
                                    { overalltype = "displ_h"; }
                                    hieRow1["Label"] = "CH:- 1";
                                }
                                else
                                {
                                    if (dir2 == "0")
                                    { overalltype = "accel_v"; }
                                    else if (dir2 == "1")
                                    { overalltype = "vel_v"; }
                                    else if (dir2 == "2")
                                    { overalltype = "displ_v"; }
                                    hieRow1["Label"] = "CH:- 2";
                                }
                                dAccel_h = Convert.ToDouble(dr2[overalltype]);
                                dYData[count] = dAccel_h;
                                hieRow1["Value"] = Convert.ToString(dr2[overalltype]) + ' ' + Yunits;
                                hieRow1["Point_ID"] = Convert.ToString(dr["point_id"]).Trim();
                                count++;
                                objOverAllReport.multiData1.Data.Rows.Add(hieRow1);
                                objOverAllReport.multiData1.Data.AcceptChanges();
                            }
                        }
                        else
                        {
                            foreach (DataRow dr2 in dt.Rows)
                            {
                                DataRow hieRow1 = objOverAllReport.multiData1.Data.NewRow();
                                hieRow1["Date"] = Convert.ToString(dr2["Measuredate"]);
                                string sTime = Convert.ToDateTime(dr2["Measuredate"]).ToString("yyyy-MM-dd HH:mm:ss");
                                arrtime.Add(sTime);
                                XDataLabels[count] = sTime;
                                dX = arrtime.Count;
                                dXData[count] = dX;
                                string TypeUnit = Convert.ToString(dr2["Type_Unit"]);
                                string dir = Convert.ToString(dr2["direction"]);
                                string overalltype = null; string overtype = null;
                                if (TypeUnit == "0" || TypeUnit == "23")
                                {
                                    overtype = "accel_";
                                }
                                else if (TypeUnit == "1" || TypeUnit == "2" || TypeUnit == "5" || TypeUnit == "6" || TypeUnit == "24" || TypeUnit == "25")
                                {
                                    overtype = "vel_";
                                }
                                else if (TypeUnit == "3" || TypeUnit == "4" || TypeUnit == "7" || TypeUnit == "8" || TypeUnit == "9" || TypeUnit == "10" || TypeUnit == "26" || TypeUnit == "27")
                                {
                                    overtype = "displ_";
                                }
                                if (dir == "0")
                                {
                                    overalltype = overtype + "h"; overtype = "Horizontal";
                                }
                                else if (dir == "1")
                                {
                                    overalltype = overtype + "v"; overtype = "Vertical";
                                }
                                else if (dir == "3")
                                {
                                    overalltype = overtype + "a"; overtype = "Axial";
                                }
                                dAccel_h = Convert.ToDouble(dr2[overalltype]);
                                dYData[count] = dAccel_h;
                                hieRow1["Value"] = Convert.ToString(dr2[overalltype]) + ' ' + Yunits;
                                hieRow1["Point_ID"] = Convert.ToString(dr["point_id"]).Trim();
                                if (Convert.ToString(dr2["ChannelType"]) == "0" || Convert.ToString(dr2["ChannelType"]) == "1" || Convert.ToString(dr2["ChannelType"]) == "2")
                                {
                                    if (dir == "2")
                                    { hieRow1["Label"] = "CH:- 1"; }
                                    else
                                    { hieRow1["Label"] = "CH:- 1" + ' ' + "(" + overtype + ")"; }
                                }
                                else if (Convert.ToString(dr2["ChannelType"]) == "3" || Convert.ToString(dr2["ChannelType"]) == "4")
                                {
                                    if (dir == "2")
                                    { hieRow1["Label"] = "CH:- 2"; }
                                    else
                                    { hieRow1["Label"] = "CH:- 2" + ' ' + "(" + overtype + ")"; }
                                }
                                count++;
                                objOverAllReport.multiData1.Data.Rows.Add(hieRow1);
                                objOverAllReport.multiData1.Data.AcceptChanges();
                            }
                        }

                        _LineGraph.DrawLineGraph(dXData, dYData, XDataLabels);
                        if (_LineGraph.chartVu != null)
                        {
                            _chartview = _LineGraph.chartVu;
                            BufferedImage objImage = new BufferedImage(_chartview);
                            Image GraphImage = (Image)objImage.GetBufferedImage();
                            byteImageData = ImageToByte(GraphImage);
                            DataRow ObjGraphRow = objOverAllReport.multiData1.GraphImage.NewRow();
                            ObjGraphRow["Graph"] = byteImageData;
                            ObjGraphRow["Point_ID"] = pointid;
                            ObjGraphRow["GraphLabel"] = "Trend Graph";//Convert.ToString(sarrMultiReportName[rr] + " " + AddValue[aa]);
                            objOverAllReport.multiData1.GraphImage.Rows.Add(ObjGraphRow);
                            objOverAllReport.multiData1.GraphImage.AcceptChanges();
                        }
                    }
                }
                printControl1.PrintingSystem = objOverAllReport.PrintingSystem;
                objOverAllReport.CreateDocument();
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }


        public void newCreateSingleReportNew(string GType, string Overallvalue,string rp_name)
        {
            try
            {
                dataID = null;
                ptID = null;
                string ckPoint = null;
                string[] sarrMultiValue = null;
                ChartView _chartview = new ChartView();
                string graphtypevalue = GType;
                string overallvalue = Overallvalue;
                if (Convert.ToString(graphtypevalue).Trim() == "")
                {
                    return;
                }
                RptAllgraph objSingleReport = new RptAllgraph();
                objSingleReport.lblTitle.Text = rp_name;
                frmHierrarchySelection MyReport = new frmHierrarchySelection();
                MyReport.ShowDialog();
                splashScreenManager1.ShowWaitForm();
                string[] SelectedMachineIDs = MyReport.Machine_id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string mID = Convert.ToString(SelectedMachineIDs[0]);

                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        objSingleReport.xrLabel2.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');                        
                        objSingleReport.pictureBox1.Image = Image.FromFile(clogo);

                    }
                }
                catch { }
                               
                //DataTable dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id order by p.point_id");

                DataTable dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where Machine_ID ='" + mID + "' order by p.point_id");

                foreach (DataRow dr in dtpoint_data.Rows)
                {
                    DataRow hieRow = objSingleReport.allReportData1.HirarchyTable.NewRow();
                    PublicClass.ReportStatus = true;
                    dataID = Convert.ToString(dr["Data_ID"]);
                    PublicClass.Data_ID = dataID;
                    ptID = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                    string Machine_id = Convert.ToString(Convert.ToString(dr["Machine_ID"]).Trim());
                    string Plantname = "";
                    string Plantid = "";
                    string MachineName = "";
                    string AreaName = "";
                    string Areaid = "";
                    string TrainName = "";
                    string Trainid = "";

                    if (ptID != ckPoint)
                    {
                        GetDetail(Machine_id, ref Plantname, ref Plantid, ref AreaName, ref Areaid, ref TrainName, ref Trainid, ref MachineName);
                        hieRow["Plant"] = Plantname.Trim();
                        hieRow["Area"] = AreaName.Trim();
                        hieRow["Train"] = TrainName.Trim();
                        hieRow["Machine"] = MachineName.Trim();
                        hieRow["Point"] = Convert.ToString(Convert.ToString(dr["pointname"]).Trim());
                        hieRow["Point_ID"] = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());

                        tempdates1.Add(Convert.ToString(dr["Measure_time"]));
                        PublicClass.tym = Convert.ToDateTime(dr["Measure_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                        objSingleReport.allReportData1.HirarchyTable.Rows.Add(hieRow);
                        objSingleReport.allReportData1.HirarchyTable.AcceptChanges();

                        string[] sarrMultiReportName = graphtypevalue.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                        string[] sarrOverall = overallvalue.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                        string[] AddValue = { "Axial", "Horizontal", "Vertical", "Channel1" };
                        for (int ss = 0; ss < sarrOverall.Length; ss++)
                        {
                            DataTable dtDataID = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where p.point_id ='" + ptID + "' and Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'   order by p.point_id ");

                            foreach (DataRow dr3 in dtDataID.Rows)
                            {
                                dataID = Convert.ToString(dr3["Data_ID"]);

                                GetOverallValues(Convert.ToString(dr["point_id"]).Trim(), Convert.ToString(sarrOverall[ss]));
                                int rrr = 0;
                               

                                sarrMultiValue = (sbMultiValue.ToString()).Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

                                for (int aa = 0; aa < AddValue.Length; aa++)
                                {
                                    if (sarrMultiValue[rrr] != "0")
                                    {
                                        DataRow DateRow = objSingleReport.allReportData1.Data.NewRow();
                                        DateRow["Value"] = sarrMultiValue[rrr].ToString().Trim();
                                        DateRow["Date"] = sarrMultiValue[4].ToString().Trim();
                                        DateRow["PointID_Data"] = Convert.ToString(dr["point_id"]).Trim();
                                        DateRow["Label"] = Convert.ToString(sarrOverall[ss] + " " + AddValue[aa]);
                                        objSingleReport.allReportData1.Data.Rows.Add(DateRow);
                                        objSingleReport.allReportData1.Data.AcceptChanges();
                                    }
                                    rrr = rrr + 1;
                                }
                            }
                        }
                        for (int rr = 0; rr < sarrMultiReportName.Length; rr++)
                        {
                            DataTable dtDataID = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where p.point_id ='" + ptID + "' and Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  order by p.point_id ");

                            foreach (DataRow dr3 in dtDataID.Rows)
                            {
                                PublicClass.ReportStatus = true;
                                PublicClass.tym = Convert.ToString(dr3["Measure_time"]);
                                PublicClass.Data_ID = Convert.ToString(dr3["Data_ID"]);
                                int rrr = 0;
                                for (int aa = 0; aa < AddValue.Length; aa++)
                                {
                                    PublicClass.ReportStatus = true;
                                    _chartview = GeneratingGraphsForPointsNew(Convert.ToString(sarrMultiReportName[rr]), Convert.ToString(AddValue[aa]), Convert.ToString(dr["Point_id"]).Trim(), Plantname, Convert.ToString(dr["pointname"]).Trim());

                                    if (_chartview != null)
                                    {
                                        BufferedImage objImage = new BufferedImage(_chartview);
                                        Image GraphImage = (Image)objImage.GetBufferedImage();
                                        byteImageData = ImageToByte(GraphImage);
                                        DataRow ObjGraphRow = objSingleReport.allReportData1.GraphImage.NewRow();
                                        ObjGraphRow["Graph"] = byteImageData;
                                        ObjGraphRow["PointID_Graph"] = Convert.ToString(dr["point_id"]).Trim();
                                        ObjGraphRow["GraphLabel"] = Convert.ToString(sarrMultiReportName[rr] + " " + AddValue[aa]);
                                        objSingleReport.allReportData1.GraphImage.Rows.Add(ObjGraphRow);
                                        objSingleReport.allReportData1.GraphImage.AcceptChanges();
                                        rrr = rrr + 1;
                                    }                          
                                }
                            }
                        }
                    }
                    ckPoint = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                }
                printControl1.PrintingSystem = objSingleReport.PrintingSystem;
                objSingleReport.CreateDocument();               
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }


        private void MultiOverall_MultiGraph(string rp_name)
        {
            try
            {
                dataID = null;
                ptID = null;
                string chkPoint = null;
                int count;
                Double RPM = 0;
                string Display = null;
                string[] sarrMultiValue = null;
                ChartView _chartview = new ChartView();
                frmselection = new frmreportselection();
                frmselection.ShowDialog();
                string graphtypevalue = frmselection.GraphType;
                string overallvalue = frmselection.overalltype;
                if (Convert.ToString(graphtypevalue).Trim() == "")
                {
                    return;
                }
                rptmultireport objMultireporting = new rptmultireport();
                objMultireporting.lblTitle.Text = rp_name;
               
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        objMultireporting.xrLabel2.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        objMultireporting.xrPictureBox3.Image = Image.FromFile(clogo);
                    }
                }
                catch { }
                DataTable dtpoint_data = new DataTable();
                count = 0;
                if (PublicClass.ReportName == "RPM Report for User selected Machine" || PublicClass.ReportName == "Multi Overall and Multi Graph(RPM Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Fault Frequency Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Dominant Frequency Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Highest Peaks Based)")
                {
                    frmHierrarchySelection MyReport = new frmHierrarchySelection();
                    MyReport.ShowDialog();
                    splashScreenManager1.ShowWaitForm();
                    string[] SelectedMachineIDs = MyReport.Machine_id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    string MachineIDs = null;
                    for (int i = 0; i < SelectedMachineIDs.Length; i++)
                    {
                        MachineIDs += Convert.ToString(SelectedMachineIDs[i]).Trim() + ",";
                    }
                    int number = 0;
                    string newList = "";
                    foreach (string item in MachineIDs.Split(new char[] { ',' }))
                    {
                        if (number > 0)
                        {
                            newList = newList + "," + "'" + item + "'";
                        }
                        else
                        {
                            newList = "'" + item + "'";
                        }
                        number++;
                    }
                    if (PublicClass.currentInstrument == "Kohtect-C911")
                    {
                        string newssgain = null;
                        string[] sarrOverall1 = overallvalue.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                        if (sarrOverall1[0] == "Acceleration")
                        {
                            newssgain = "'0'";
                            dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT distinct  P.Machine_ID,pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID   where  di.SelectRadio1 in(" + newssgain + ") or di.SelectRadio2 in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                        }
                        else if (sarrOverall1[0] == "Displacement")
                        {
                            newssgain = "'2'";
                            dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT distinct P.Machine_ID, pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID   where  di.SelectRadio1 in(" + newssgain + ") or di.SelectRadio2 in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                        }
                        else if (sarrOverall1[0] == "Velocity")
                        {
                            newssgain = "'1'";
                            dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT distinct  P.Machine_ID,pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID   where  di.SelectRadio1 in(" + newssgain + ") or di.SelectRadio2 in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                        }
                    }
                    else
                    {
                        dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where Machine_ID IN(" + newList + ") and  pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'order by p.point_id");
                    }
                }
                else
                {
                    splashScreenManager1.ShowWaitForm();
                    dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time FROM  point_data  pa inner join point p on pa.point_id=p.point_id  where pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "' order by p.point_id");
                }
                foreach (DataRow dr in dtpoint_data.Rows)
                {
                    DataRow hieRow = objMultireporting.multiData1.HirarchyTable.NewRow();
                    PublicClass.ReportStatus = true;
                    dataID = Convert.ToString(dr["Data_ID"]);
                    PublicClass.Data_ID = dataID;
                    ptID = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                    string Machine_id = Convert.ToString(Convert.ToString(dr["Machine_ID"]).Trim());
                    string Plantname = "";
                    string Plantid = "";
                    string MachineName = "";
                    string AreaName = "";
                    string Areaid = "";
                    string TrainName = "";
                    string Trainid = "";

                    if (ptID != chkPoint)
                    {
                        GetDetail(Machine_id, ref Plantname, ref Plantid, ref AreaName, ref Areaid, ref TrainName, ref Trainid, ref MachineName);
                        hieRow["Factory"] = Plantname.Trim();
                        hieRow["Area"] = AreaName.Trim();
                        hieRow["Train"] = TrainName.Trim();
                        hieRow["Machine"] = MachineName.Trim();
                        hieRow["Point"] = Convert.ToString(Convert.ToString(dr["pointname"]).Trim());
                        hieRow["Point_ID"] = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());

                        tempdates1.Add(Convert.ToString(dr["Measure_time"]));
                        PublicClass.tym = Convert.ToDateTime(dr["Measure_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                        objMultireporting.multiData1.HirarchyTable.Rows.Add(hieRow);
                        objMultireporting.multiData1.HirarchyTable.AcceptChanges();

                        string[] sarrMultiReportName = graphtypevalue.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                        string[] sarrOverall = overallvalue.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                        string[] AddValue = { "Axial", "Horizontal", "Vertical", "Channel1" };
                        for (int ss = 0; ss < sarrOverall.Length; ss++)
                        {
                            DataTable dtDataID = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where p.point_id ='" + ptID + "' and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "' order by p.point_id");
                            foreach (DataRow dr3 in dtDataID.Rows)
                            {
                                dataID = Convert.ToString(dr3["Data_ID"]);

                                GetOverallValues(Convert.ToString(dr["point_id"]).Trim(), Convert.ToString(sarrOverall[ss]));

                                if (PublicClass.ReportName == "RPM Report for User selected Machine" || PublicClass.ReportName == "Multi Overall and Multi Graph(RPM Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Fault Frequency Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Dominant Frequency Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Highest Peaks Based)")
                                {
                                    DataTable dtrpm = DbClass.getdata(CommandType.Text, "select ordertrace_rpm from Point_Data where Point_id = '" + ptID + "' and Data_ID = '" + dataID + "'");
                                    foreach (DataRow dr1 in dtrpm.Rows)
                                    {
                                        RPM = Convert.ToDouble(dr1["ordertrace_rpm"].ToString());
                                    }
                                    if (RPM == 0)
                                    {
                                        DataTable dtmid = DbClass.getdata(CommandType.Text, "select RPM_Driven from machine_info where machine_id in (Select Machine_ID from point where Point_ID = '" + ptID + "') ");

                                        foreach (DataRow dr2 in dtmid.Rows)
                                        {
                                            RPM = Convert.ToDouble(dr2["RPM_Driven"].ToString());
                                        }
                                    }
                                }

                                else if (PublicClass.ReportName == "Multi Overall and Multi Graph(Fault Frequency Based)")
                                {
                                    Display = "Dominant Freq";
                                }
                                else if (PublicClass.ReportName == "Multi Overall and Multi Graph(Dominant Frequency Based)")
                                {
                                    Display = "High Freq";
                                }
                                else if (PublicClass.ReportName == "Multi Overall and Multi Graph(Highest Peaks Based)")
                                {
                                    Display = "Fault Freq";
                                }
                                else
                                {
                                }
                                int rrr = 0;
                                //int counter = 0;

                                sarrMultiValue = (sbMultiValue.ToString()).Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

                                for (int aa = 0; aa < AddValue.Length; aa++)
                                {
                                    if (sarrMultiValue[rrr] != "0")
                                    {
                                        DataRow DateRow = objMultireporting.multiData1.Data.NewRow();

                                        DateRow["Value"] = sarrMultiValue[rrr].ToString().Trim();
                                        DateRow["Date"] = sarrMultiValue[4].ToString().Trim();
                                        DateRow["point_id"] = Convert.ToString(dr["point_id"]).Trim();
                                        DateRow["Label"] = Convert.ToString(sarrOverall[ss] + " " + AddValue[aa]);
                                        objMultireporting.multiData1.Data.Rows.Add(DateRow);
                                        objMultireporting.multiData1.Data.AcceptChanges();
                                    }
                                    rrr = rrr + 1;

                                }
                            }

                        }
                        for (int rr = 0; rr < sarrMultiReportName.Length; rr++)
                        {
                            DataTable dtDataID = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa  inner join point p on pa.point_id=p.point_id where p.point_id ='" + ptID + "' and pa.Measure_time between '"+PublicClass.StartingDate+"' and '"+PublicClass.EndDate+"' order by p.point_id ");

                            foreach (DataRow dr3 in dtDataID.Rows)
                            {
                                PublicClass.ReportStatus = true;
                                PublicClass.tym = Convert.ToString(dr3["Measure_time"]);
                                PublicClass.Data_ID = Convert.ToString(dr3["Data_ID"]);
                                int rrr = 0;
                                for (int aa = 0; aa < AddValue.Length; aa++)
                                {
                                    PublicClass.ReportStatus = true;
                                    if (RPM == 0)
                                    {
                                        _chartview = GeneratingGraphsForPointsNew(Convert.ToString(sarrMultiReportName[rr]), Convert.ToString(AddValue[aa]), Convert.ToString(dr["Point_id"]).Trim(), Plantname, Convert.ToString(dr["pointname"]).Trim());

                                        if (_chartview != null)
                                        {
                                            objMultireporting.xrPictureBox1.Visible = true;
                                            objMultireporting.xrPictureBox2.Visible = false;
                                            objMultireporting.xrLabel1.Visible = true;
                                            objMultireporting.xrLabel3.Visible = false;
                                            BufferedImage objImage = new BufferedImage(_chartview);
                                            Image GraphImage = (Image)objImage.GetBufferedImage();
                                            byteImageData = ImageToByte(GraphImage);
                                            DataRow ObjGraphRow = objMultireporting.multiData1.GraphImage.NewRow();
                                            ObjGraphRow["Graph"] = byteImageData;
                                            ObjGraphRow["Point_Id"] = Convert.ToString(dr["point_id"]).Trim();
                                            ObjGraphRow["GraphLabel"] = Convert.ToString(sarrMultiReportName[rr] + " " + AddValue[aa]);
                                            objMultireporting.multiData1.GraphImage.Rows.Add(ObjGraphRow);
                                            objMultireporting.multiData1.GraphImage.AcceptChanges();
                                            rrr = rrr + 1;
                                        }
                                    }
                                    else
                                    {
                                        _chartview = GeneratingGraphsForPointsNew2(Convert.ToString(sarrMultiReportName[rr]), Convert.ToString(AddValue[aa]), Convert.ToString(dr["Point_id"]).Trim(), Plantname, Convert.ToString(dr["pointname"]).Trim(), RPM);

                                        if (_chartview != null)
                                        {
                                            objMultireporting.xrPictureBox1.Visible = false;
                                            objMultireporting.xrPictureBox2.Visible = true;
                                            objMultireporting.xrLabel1.Visible = false;
                                            objMultireporting.xrLabel3.Visible = true;
                                            BufferedImage objImage = new BufferedImage(_chartview);
                                            Image GraphImage = (Image)objImage.GetBufferedImage();
                                            byteImageData = ImageToByte(GraphImage);
                                            DataRow ObjGraphRow = objMultireporting.multiData1.GraphImage1.NewRow();
                                            ObjGraphRow["Graph"] = byteImageData;
                                            ObjGraphRow["PointIDGraph"] = Convert.ToString(dr["point_id"]).Trim();
                                            ObjGraphRow["GraphLabel"] = Convert.ToString(sarrMultiReportName[rr] + " " + AddValue[aa]);
                                            //ObjGraphRow["Text"] = Display.Trim();


                                            int check = 0;
                                            if (Xdata12[0] != 0)
                                            {
                                                check = 1;
                                                ObjGraphRow["X"] = (Xdata12[0] * 60).ToString();
                                                ObjGraphRow["Y"] = (Math.Round(Ydata12[0], 2)).ToString();
                                            }
                                            else
                                            {
                                                ObjGraphRow["X"] = "0";
                                                ObjGraphRow["Y"] = "0";
                                            }
                                            if (Xdata12[1] != 0)
                                            {
                                                check = 1;
                                                ObjGraphRow["X1"] = (Xdata12[1] * 60).ToString();
                                                ObjGraphRow["Y1"] = (Math.Round(Ydata12[1], 2)).ToString();
                                            }
                                            else
                                            {
                                                ObjGraphRow["X1"] = "0";
                                                ObjGraphRow["Y1"] = "0";
                                            }
                                            if (Xdata12[2] != 0)
                                            {
                                                check = 1;
                                                ObjGraphRow["X2"] = (Xdata12[2] * 60).ToString();
                                                ObjGraphRow["Y2"] = (Math.Round(Ydata12[2], 2)).ToString();
                                            }
                                            else
                                            {
                                                ObjGraphRow["X2"] = "0";
                                                ObjGraphRow["Y2"] = "0";
                                            }
                                            if (Xdata12[3] != 0)
                                            {
                                                check = 1;
                                                ObjGraphRow["X3"] = (Xdata12[3] * 60).ToString();
                                                ObjGraphRow["Y3"] = (Math.Round(Ydata12[3], 2)).ToString();
                                            }
                                            else
                                            {
                                                ObjGraphRow["X3"] = "0";
                                                ObjGraphRow["Y3"] = "0";
                                            }
                                            if (Xdata12[4] != 0)
                                            {
                                                check = 1;
                                                ObjGraphRow["X4"] = (Xdata12[4] * 60).ToString();
                                                ObjGraphRow["Y4"] = (Math.Round(Ydata12[4], 2)).ToString();
                                            }
                                            else
                                            {
                                                ObjGraphRow["X4"] = "0";
                                                ObjGraphRow["Y4"] = "0";
                                            }

                                            rrr = rrr + 1;
                                            objMultireporting.multiData1.GraphImage1.Rows.Add(ObjGraphRow);
                                            objMultireporting.multiData1.GraphImage1.AcceptChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    chkPoint = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                }
                try
                {
                    if (PublicClass.ReportName == "RPM Report for User selected Machine"||PublicClass.ReportName == "Multi Overall and Multi Graph(RPM Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Fault Frequency Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Dominant Frequency Based)" || PublicClass.ReportName == "Multi Overall and Multi Graph(Highest Peaks Based)")
                    {
                        objMultireporting.DetailReport1.Visible = false;
                        objMultireporting.DetailReport2.Visible = true;
                    }
                    else
                    {
                        objMultireporting.DetailReport1.Visible = true;
                        objMultireporting.DetailReport2.Visible = false;
                    }
                }
                catch
                {
                }
                printControl1.PrintingSystem = objMultireporting.PrintingSystem;
                objMultireporting.CreateDocument();
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }
               
        string GraphType = null;
        string OverallType = null;
        string reportname = null;
        public void Set_Report_data(string ReportName)
        {
            try
            {
                DataTable dtData = CheckForData();
                if (dtData.Rows.Count > 0)
                {
                }
                else
                {
                    MessageBox.Show(this, "Data has not been taken on this route.." + System.Environment.NewLine + "OR" + System.Environment.NewLine + "Data not available on selected measure time span..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                PublicClass.ReportName = Convert.ToString(ReportName);
                PublicClass.ReportStatus = true;
                switch (ReportName)
                {                   
                    case "Vibration Measurement Report":
                        {
                            ReportasperKribhco2();
                            break;
                        }
                    case "OverDue Points":
                        {
                            reportname = "OverDue Points";
                            overduepoint(reportname);
                            break;
                        }
                   
                    case "OverAll Values":
                        {
                            if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                            {
                                reportname = "Overall Vibration Report";
                                NewOverall(reportname);
                            }
                            else
                            {
                                if (PublicClass.currentInstrument == "Impaq-Benstone")
                                { reportname = "Overall Vibration Report"; }
                                else
                                {
                                    reportname = "Overall Report";
                                }
                                NewOverallForDI(reportname);
                            }
                            break;
                        }
                    case "Single Channel Graph for User Selected Machine":
                        {
                            reportname = "Single Channel Graph";
                            overallgraphforDi("Single", "", reportname);
                            break;
                        }
                    case "Time wave to FFT Graph":
                        {
                            reportname = "Time wave to FFT Graph";
                            Timetofft("Time", "Single", reportname);
                            break;
                        }
                    case "With Single Channel Time Graph":
                        {
                            reportname = "Single Channel Graph";
                            overallgraphforDi("Time", "Single", reportname);
                            break;
                        }
                    case "With Single Channel Power Graph":
                        {
                            reportname = "Single Channel Graph";
                            overallgraphforDi("Power", "Single", reportname);
                            break;
                        }
                    case "Dual Channel Graph for User Selected Machine":
                        {
                            reportname = "Dual Channel Graph";
                            overallgraphforDi("Single", "", reportname);
                            break;
                        }
                    case "With Dual Channel Time Graph":
                        {
                            reportname = "Dual Channel Graph";
                            overallgraphforDi("Time", "Dual", reportname);
                            break;
                        }
                    case "With Dual Channel Power Graph":
                        {
                            reportname = "Dual Channel Graph";
                            overallgraphforDi("Power", "Dual", reportname);
                            break;
                        }
                    case "Overall Values Of Velocity with Time Graph":
                        {
                            reportname = "Overall Values Of Velocity with Time Graph";
                            overallgraphforDi("Time", "Velocity", reportname);
                            break;
                        }
                    case "Overall Values Of Velocity with Power Graph":
                        {
                            GType = "Power";
                            reportname = "Overall Values Of Velocity with Power Graph";
                            if (PublicClass.currentInstrument == "Kohtect-C911")
                            {
                                NewOverallForDI(reportname);
                            }
                            else
                            {
                                overallgraphforDi("Power", "Velocity", reportname);
                            }
                            break;
                        }
                    case "Overall Values Of Acceleration with Time Graph":
                        {
                            reportname = "Overall Values Of Acceleration with Time Graph";
                            overallgraphforDi("Time", "Acceleration", reportname);
                            break;
                        }
                    case "Overall Values Of Acceleration with Power Graph":
                        {
                            GType = "Power";
                            reportname = "Overall Values Of Acceleration with Power Graph";
                            if (PublicClass.currentInstrument == "Kohtect-C911")
                            {
                                NewOverallForDI(reportname);
                            }
                            else
                            {
                                overallgraphforDi("Power", "Acceleration", reportname);
                            }
                            break;
                        }
                    case "Overall Values Of Displacement with Time Graph":
                        {
                            reportname = "Overall Values Of Displacement with Time Graph";
                            overallgraphforDi("Time", "Displacement", reportname);
                            break;
                        }
                    case "Overall Values Of Displacement with Power Graph":
                        {
                            GType = "Power";
                            reportname = "Overall Values Of Displacement with Power Graph";
                            if (PublicClass.currentInstrument == "Kohtect-C911")
                            {
                                NewOverallForDI(reportname);
                            }
                            else
                            {
                                overallgraphforDi("Power", "Displacement", reportname);
                            }
                            break;
                        }
                    case "Report for Overall Values Of All Velocity":
                        {
                            reportname = "Overall Values Of All Velocity";
                            NewOverallForDI(reportname);
                            break;
                        }
                    case "Report for Overall Values Of All Acceleration":
                        {
                            reportname = "Overall Values Of All Acceleration";
                            NewOverallForDI(reportname);
                            break;
                        }
                    case "Report for Overall Values Of All Displacement":
                        {
                            reportname = "Overall Values Of All Displacement";
                            NewOverallForDI(reportname);
                            break;
                        }
                    case "General Report Navy":
                        {                           
                            Generalnavy();
                            break;
                        }
                    case "Multi Overall and Multi Graph":
                        {
                            reportname = "Multi Overall and Multi Spectrum";
                            MultiOverall_MultiGraph(reportname);
                            break;
                        }                       
                    case "Multi Overall and Multi Graph(RPM Based)":
                        {
                            reportname = "Multi Overall and Multi Spectrum (RPM Based)";
                            MultiOverall_MultiGraph(reportname);
                            break;
                        }
                    case "RPM Report for User selected Machine":
                        {
                            reportname = "RPM Report for User selected Machine";
                            MultiOverall_MultiGraph(reportname);
                            break; 
                        }
                    case "Multi Overall and Multi Graph(Fault Frequency Based)":
                        {
                            reportname = "Multi Overall and Multi Spectrum (Fault Frequency Based)";
                            MultiOverall_MultiGraph(reportname);
                           break;
                        }
                    case "Multi Overall and Multi Graph(Dominant Frequency Based)":
                        {
                            reportname = "Multi Overall and Multi Spectrum (Dominant Frequency Based)";
                            MultiOverall_MultiGraph(reportname);
                            break;
                        }
                    case "Multi Overall and Multi Graph(Highest Peaks Based)":
                        {
                            reportname = "Multi Overall and Multi Spectrum (Highest Peaks Based)";
                            MultiOverall_MultiGraph(reportname);
                            break;
                        }
                    case "Notes Report":
                        {
                            pointnotes();
                            break;
                        }
                    case "All Route DownLoad Report":
                        {
                            reportname = "All Route Download Report";
                            AllRouteReport();
                            break;
                        }
                    case "OverAll Values with Difference and Graphical Analysis":
                        {
                            reportname = "Overall Values with Difference and Spectrumical Analysis";
                            if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                            {
                                DifferenceReporting(reportname);
                            }
                            else
                            {
                                DiffandGraphforDI("Difference", "", reportname);
                            }
                            break;
                        }

                    case "1 Overall and 1 Graph":
                        {
                            reportname = "Overall Vibration Report";
                            oneoverallonegraph(reportname);
                            break;
                        }
//---------------------------------------------Trend Graph-------------------------------------------------------------------------------------
                    case "Overall Trend Values with Graph":
                        {
                            reportname = "overall Trend Values with Graph";
                            trendforDi("Trend", "", reportname);
                            break;
                        }
                    case "Overall Trend Values":
                        {
                            reportname = "Overall Trend Report";
                            NewOverallForDI(reportname);
                            break;
                        }
                    case "Point Report with Overall Trend Graph":
                        {
                            reportname = "Point Report with Overall Trend Graph";
                            trendforDi("Trend", "", reportname);
                            break;
                        }

 //---------------------------------------------Time Graph--------------------------------------------------------------------------------------
                   
                    case "Acceleration with Time Graph":
                        {
                            reportname = "Acceleration with Time Waveform";
                            GraphType = "Time";
                            OverallType = "Acceleration";
                            newCreateSingleReportNew(GraphType, OverallType,reportname);
                            break;
                        }
                   
                    case "Velocity with Time Graph":
                        {
                            reportname = "Velocity with Time Waveform";
                            GraphType = "Time";
                            OverallType = "Velocity";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                           
                        }
                    case "Displacement  with Time Graph":
                        {
                            reportname = "Displacement  with Time Waveform";
                            GraphType = "Time";
                            OverallType = "Displacement";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            
                            break;
                        }
                    case "Bearing with Time Graph":
                        {
                            reportname = "Bearing with Time Waveform";
                            GraphType = "Time";
                            OverallType = "Bearing";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }


//---------------------------------------------Power Graph--------------------------------------------------------------------------------------

                    case "Acceleration with Power Graph":
                        {
                            reportname = "Acceleration with Power Spectrum";
                            GraphType = "Power";
                            OverallType = "Acceleration";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }                   
                    case "Velocity with Power Graph":
                        {
                            reportname = "Velocity with Power Spectrum";
                            GraphType = "Power";
                            OverallType = "Velocity";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Displacement with Power Graph":
                        {
                            reportname = "Displacement with Power Spectrum";
                            GraphType = "Power";
                            OverallType = "Displacement";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Bearing with Power Graph":
                        {
                            reportname = "Bearing with Power Spectrum";
                            GraphType = "Power";
                            OverallType = "Bearing";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }

 //---------------------------------------------Power1 Graph--------------------------------------------------------------------------------------

                    case "Acceleration with Power1 Graph":
                        {
                            reportname = "Acceleration with Power1 Spectrum";
                            GraphType = "Power1";
                            OverallType = "Acceleration";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }

                    case "Velocity with Power1 Graph":
                        {
                            reportname = "Velocity with Power1 Spectrum";
                            GraphType = "Power1";
                            OverallType = "Velocity";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Displacement with Power1 Graph":
                        {
                            reportname = "Displacement with Power1 Spectrum";
                            GraphType = "Power1";
                            OverallType = "Displacement";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Bearing with Power1 Graph":
                        {
                            reportname = "Bearing with Power1 Spectrum";
                            GraphType = "Power1";
                            OverallType = "Bearing";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }


  //---------------------------------------------Power2 Graph--------------------------------------------------------------------------------------

                    case "Acceleration with power2Graph Graph":
                        {
                            reportname = "Acceleration with Power2 Spectrum";
                            GraphType = "Power2";
                            OverallType = "Acceleration";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }

                    case "Velocity with power2Graph Graph":
                        {
                            reportname = "Velocity with Power2 Spectrum";
                            GraphType = "Power2";
                            OverallType = "Velocity";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Displacement with power2Graph Graph":
                        {
                            reportname = "Displacement with Power2 Spectrum";
                            GraphType = "Power2";
                            OverallType = "Displacement";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Bearing with power2Graph Graph":
                        {
                            reportname = "Bearing with Power2 Spectrum";
                            GraphType = "Power2";
                            OverallType = "Bearing";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }


  //---------------------------------------------Power21 Graph--------------------------------------------------------------------------------------

                    case "Acceleration with power2Graph1 Graph":
                        {
                            reportname = "Acceleration with Power2 Spectrum1";
                            GraphType = "Power21";
                            OverallType = "Acceleration";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }

                    case "Velocity with power2Graph1 Graph":
                        {
                            reportname = "Velocity with Power2 Spectrum 1";
                            GraphType = "Power21";
                            OverallType = "Velocity";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Displacement with power2Graph1 Graph":
                        {
                            reportname = "Displacement with Power2 Spectrum1";
                            GraphType = "Power21";
                            OverallType = "Displacement";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Bearing with power2Graph1 Graph":
                        {
                            reportname = "Bearing with Power2 Spectrum1";
                            GraphType = "Power21";
                            OverallType = "Bearing";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }


   //---------------------------------------------Power3 Graph--------------------------------------------------------------------------------------

                    case "Acceleration with power3Graph Graph":
                        {
                            reportname = "Acceleration with Power3 Spectrum";
                            GraphType = "Power3";
                            OverallType = "Acceleration";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }

                    case "Velocity with power3Graph Graph":
                        {
                            reportname = "Velocity with Power3 Spectrum";
                            GraphType = "Power3";
                            OverallType = "Velocity";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Displacement with power3Graph Graph":
                        {
                            reportname = "Displacement with Power3 Spectrum";
                            GraphType = "Power3";
                            OverallType = "Displacement";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Bearing with power3Graph Graph":
                        {
                            reportname = "Bearing with Power3 Spectrum";
                            GraphType = "Power3";
                            OverallType = "Bearing";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }


  //---------------------------------------------Power31 Graph--------------------------------------------------------------------------------------

                    case "Acceleration with power3Graph1 Graph":
                        {
                            reportname = "Acceleration with Power3 Spectrum1";
                            GraphType = "Power31";
                            OverallType = "Acceleration";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }

                    case "Velocity with power3Graph1 Graph":
                        {
                            reportname = "Velocity with Power3 Spectrum1";
                            GraphType = "Power31";
                            OverallType = "Velocity";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Displacement with power3Graph1 Graph":
                        {
                            reportname = "Displacement with Power3 Spectrum1";
                            GraphType = "Power31";
                            OverallType = "Displacement";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }

                    case "Bearing with power3Graph1 Graph":
                        {
                            reportname = "Bearing with Power3 Spectrum1";
                            GraphType = "Power31";
                            OverallType = "Bearing";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                        
 //---------------------------------------------Demodulate Graph--------------------------------------------------------------------------------------

                    case "Acceleration  with Demodulate Graph":
                        {
                            reportname = "Overall Vibration Report";
                            GraphType = "Demodulate";
                            OverallType = "Acceleration";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }

                    case "Velocity with Demodulate Graph":
                        {
                            reportname = "Overall Vibration Report";
                            GraphType = "Demodulate";
                            OverallType = "Velocity";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Displacement  with Demodulate Graph":
                        {
                            reportname = "Overall Vibration Report";
                            GraphType = "Demodulate";
                            OverallType = "Displacement";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Bearing with Demodulate Graph":
                        {
                            reportname = "Overall Vibration Report";
                            GraphType = "Demodulate";
                            OverallType = "Bearing";
                            newCreateSingleReportNew(GraphType, OverallType, reportname);
                            break;
                        }
                    case "Points with Alarms":
                        {
                            reportname = "Points with Alarms";                            
                            PointwithAlarms(reportname);
                            break;
                        }
                    case "Alarm in User Selected Machine":
                        {
                            reportname = "Alarms in User Selected Machine";
                            PointwithAlarms(reportname);
                            break;
                        }
                    case "Alarm in User Selected Train":
                        {
                            reportname = "Alarms in User Selected Train";
                            PointwithAlarms(reportname);
                            break;
                        }
                    case "Alarm in User Selected Area":
                        {
                            reportname = "Alarms in User Selected Area";
                            PointwithAlarms(reportname);
                            break;
                        }
                    case "Alarm in User Selected Plant":
                        {
                            reportname = "Alarms in User Selected Plant";
                            PointwithAlarms(reportname);
                            break;
                        }
                    case "Route Time Based Report":
                        {
                            reportname = "Route Time based Report";          
                            RouteTimeBasedReport();
                            break;
                        }                   
                    default:
                        {
                            MessageBox.Show("Method not implemented");
                            break;
                        }
                }
                string status = null;
               DataTable dtReport = DbClass.getdata(CommandType.Text, "Select ReportStatus from allreport where ReportName = '" + PublicClass.ReportName + "'");
               foreach (DataRow dr in dtReport.Rows)
               {
                   status += Convert.ToString(dr["ReportStatus"]) + ",";
               }

               if (status == "Selected,Auto,")
               {
                   btnAutoGenerateReport.Enabled = true;
               }
               else
               {
                   btnAutoGenerateReport.Enabled = false;
               }

            }
            catch
            {
            }
        }

        ArrayList m_arrListPointID = null;
        public ArrayList GetValues(string sReport,string DataID)
        {
            string sCommandtext = null;
            string sConnectionString = null;
            int iPointID = 0;
            StringBuilder sbValues = null;
            double dAccel_a = 0;
            double dAccel_h = 0;
            double dAccel_v = 0;
            double dvel_a = 0;
            double dvel_h = 0;
            double dvel_v = 0;
            double ddisp_a = 0;
            double ddisp_h = 0;
            double ddisp_v = 0;
            double dbearing_a = 0;
            double dbearing_h = 0;
            double dbearing_v = 0;

            double dcrestfactor_a = 0;
            double dcrestfactor_h = 0;
            double dcrestfactor_v = 0;

            double dtemp = 0;
            ArrayList arrListToReturn = null;
            double[] dOldAccel = null;
            double[] dOldVel = null;
            double[] dOldDispl = null;
            double[] dOldBearing = null; double[] dOldTemp = null;
            double[] dOldcrestfactor = null;

            double[] dNewAccelValue = null;
            double[] dNewVelValue = null;
            double[] dNewDisplValue = null; double[] dnewTemp = null;
            double[] dNewBearingValue = null;
            double[] dNewcrestfactorValue = null;
            double dNewAccel_a = 0;
            double dNewAccel_h = 0;
            double dNewAccel_v = 0;
            double dNewvel_a = 0;
            double dNewvel_h = 0;
            double dNewvel_v = 0;
            double dNewdisp_a = 0;
            double dNewdisp_h = 0;
            double dNewdisp_v = 0;
            double dNewbearing_a = 0;
            double dNewbearing_h = 0;
            double dNewbearing_v = 0;
            double dNewTemperature = 0;

            double dNewcrestfactor_a = 0;
            double dNewcrestfactor_h = 0;
            double dNewcrestfactor_v = 0;
            try
            {
                arrListToReturn = new ArrayList();
                //for (int iNewCtr = 0; iNewCtr < m_arrListPointID.Count; iNewCtr++)
                //{
               // string sPointID = sPointID;
                    dOldAccel = new double[3];
                    dOldVel = new double[3];
                    dOldDispl = new double[3];
                    dOldBearing = new double[3];
                    dOldcrestfactor = new double[3];
                    dNewAccelValue = new double[3];
                    dNewVelValue = new double[3];
                    dNewDisplValue = new double[3];
                    dNewBearingValue = new double[3];
                    dNewcrestfactorValue = new double[3];
                   // iPointID = Convert.ToInt32(sPointID);
                    dAccel_a = 0;
                    dAccel_h = 0;
                    dAccel_v = 0;

                    dvel_a = 0;
                    dvel_h = 0;
                    dvel_v = 0;

                    ddisp_a = 0;
                    ddisp_h = 0;
                    ddisp_v = 0;

                    dbearing_a = 0;
                    dbearing_h = 0;
                    dbearing_v = 0;

                    dcrestfactor_a = 0;
                    dcrestfactor_h = 0;
                    dcrestfactor_v = 0;
                    dtemp = 0;


                    dNewAccel_a = 0;
                    dNewAccel_h = 0;
                    dNewAccel_v = 0;

                    dNewvel_a = 0;
                    dNewvel_h = 0;
                    dNewvel_v = 0;

                    dNewdisp_a = 0;
                    dNewdisp_h = 0;
                    dNewdisp_v = 0;

                    dNewbearing_a = 0;
                    dNewbearing_h = 0;
                    dNewbearing_v = 0;

                    dNewcrestfactor_a = 0;
                    dNewcrestfactor_h = 0;
                    dNewcrestfactor_v = 0;

                    dNewTemperature = 0;
                    int ireader = 0;

                    DataTable dt = DbClass.getdata(CommandType.Text, "select * from point_data where Data_ID=" + DataID + "");
                    foreach (DataRow objReader in dt.Rows)
                    {
                        ireader += 1;
                        if (ireader == 1)
                        {
                            dNewAccel_a = Math.Round(Convert.ToDouble(objReader["accel_a"]), 5);
                            dNewAccel_h = Math.Round(Convert.ToDouble(objReader["accel_h"]), 5);
                            dNewAccel_v = Math.Round(Convert.ToDouble(objReader["accel_v"]), 5);

                            dNewvel_a = Math.Round(Convert.ToDouble(objReader["vel_a"]), 5);
                            dNewvel_h = Math.Round(Convert.ToDouble(objReader["vel_h"]), 5);
                            dNewvel_v = Math.Round(Convert.ToDouble(objReader["vel_v"]), 5);

                            dNewdisp_a = Math.Round(Convert.ToDouble(objReader["displ_a"]), 5);
                            dNewdisp_h = Math.Round(Convert.ToDouble(objReader["displ_h"]), 5);
                            dNewdisp_v = Math.Round(Convert.ToDouble(objReader["displ_v"]), 5);

                            dNewbearing_a = Math.Round(Convert.ToDouble(objReader["bearing_a"]), 5);
                            dNewbearing_h = Math.Round(Convert.ToDouble(objReader["bearing_h"]), 5);
                            dNewbearing_v = Math.Round(Convert.ToDouble(objReader["bearing_v"]), 5);
                            try
                            {
                                dNewcrestfactor_a = Math.Round(Convert.ToDouble(objReader["crest_factor_a"]), 5);
                                dNewcrestfactor_h = Math.Round(Convert.ToDouble(objReader["crest_factor_h"]), 5);
                                dNewcrestfactor_v = Math.Round(Convert.ToDouble(objReader["crest_factor_v"]), 5);
                            }
                            catch
                            {
                            }

                        }
                        else if (ireader == 2)
                        {
                            dAccel_a = Math.Round(Convert.ToDouble(objReader["accel_a"]), 5);
                            dAccel_h = Math.Round(Convert.ToDouble(objReader["accel_h"]), 5);
                            dAccel_v = Math.Round(Convert.ToDouble(objReader["accel_v"]), 5);

                            dvel_a = Math.Round(Convert.ToDouble(objReader["vel_a"]), 5);
                            dvel_h = Math.Round(Convert.ToDouble(objReader["vel_h"]), 5);
                            dvel_v = Math.Round(Convert.ToDouble(objReader["vel_v"]), 5);

                            ddisp_a = Math.Round(Convert.ToDouble(objReader["displ_a"]), 5);
                            ddisp_h = Math.Round(Convert.ToDouble(objReader["displ_h"]), 5);
                            ddisp_v = Math.Round(Convert.ToDouble(objReader["displ_v"]), 5);

                            dbearing_a = Math.Round(Convert.ToDouble(objReader["bearing_a"]), 5);
                            dbearing_h = Math.Round(Convert.ToDouble(objReader["bearing_h"]), 5);
                            dbearing_v = Math.Round(Convert.ToDouble(objReader["bearing_v"]), 5);
                            try
                            {
                                dNewcrestfactor_a = Math.Round(Convert.ToDouble(objReader["crest_factor_a"]), 5);
                                dNewcrestfactor_h = Math.Round(Convert.ToDouble(objReader["crest_factor_h"]), 5);
                                dNewcrestfactor_v = Math.Round(Convert.ToDouble(objReader["crest_factor_v"]), 5);
                            }
                            catch
                            {
                            }
                        }
                        else
                            break;

                    }
                    for (int iCtr = 0; iCtr < 3; iCtr++)
                    {
                        if (iCtr == 0)
                        {
                            dOldAccel[iCtr] = dAccel_a;
                            dOldVel[iCtr] = dvel_a;
                            dOldDispl[iCtr] = ddisp_a;
                            dOldBearing[iCtr] = dbearing_a;
                            dOldcrestfactor[iCtr] = dcrestfactor_a;
                            dNewAccelValue[iCtr] = dNewAccel_a;
                            dNewVelValue[iCtr] = dNewvel_a;
                            dNewDisplValue[iCtr] = dNewdisp_a;
                            dNewBearingValue[iCtr] = dNewbearing_a;
                            dNewcrestfactorValue[iCtr] = dNewcrestfactor_a;
                        }
                        else if (iCtr == 1)
                        {
                            dOldAccel[iCtr] = dAccel_h;
                            dOldVel[iCtr] = dvel_h;
                            dOldDispl[iCtr] = ddisp_h;
                            dOldBearing[iCtr] = dbearing_h;
                            dOldcrestfactor[iCtr] = dcrestfactor_h;
                            dNewAccelValue[iCtr] = dNewAccel_h;
                            dNewVelValue[iCtr] = dNewvel_h;
                            dNewDisplValue[iCtr] = dNewdisp_h;
                            dNewBearingValue[iCtr] = dNewbearing_h;
                            dNewcrestfactorValue[iCtr] = dNewcrestfactor_h;

                        }
                        else if (iCtr == 2)
                        {
                            dOldAccel[iCtr] = dAccel_v;
                            dOldVel[iCtr] = dvel_v;
                            dOldDispl[iCtr] = ddisp_v;
                            dOldBearing[iCtr] = dbearing_v;
                            dOldcrestfactor[iCtr] = dcrestfactor_v;
                            dNewAccelValue[iCtr] = dNewAccel_v;
                            dNewVelValue[iCtr] = dNewvel_v;
                            dNewDisplValue[iCtr] = dNewdisp_v;
                            dNewBearingValue[iCtr] = dNewbearing_v;
                            dNewcrestfactorValue[iCtr] = dNewcrestfactor_v;
                        }
                    }
                    arrListToReturn.Add(dOldAccel);
                    arrListToReturn.Add(dOldVel);
                    arrListToReturn.Add(dOldDispl);
                    arrListToReturn.Add(dOldBearing);
                    arrListToReturn.Add(dOldcrestfactor);
                    arrListToReturn.Add(dNewAccelValue);
                    arrListToReturn.Add(dNewVelValue);
                    arrListToReturn.Add(dNewDisplValue);
                    arrListToReturn.Add(dNewBearingValue);
                    arrListToReturn.Add(dNewcrestfactorValue);

                //}
               
            }
            catch (Exception ex)
            {
                return arrListToReturn;
            }
            return arrListToReturn;
        }

        internal void CreateSimpleDocument(string m_sPointInformation, ArrayList arrGotValues, ref Datasets.overallvalues.DFDataTableDataTable _Table)
        {
            string Plantname = "";
            string Plantid = "";
            string MachineName = "";
            string AreaName = "";
            string Areaid = "";
            string TrainName = "";
            string Trainid = "";
            int iCounter = arrGotValues.Count / 8;
            int x = 0;
            int y = 0;
            ArrayList sarrDataold = new ArrayList();
            ArrayList sarrDatanew = new ArrayList();
            ArrayList sarrDatadiff = new ArrayList();
            string sal = "Old";
            int arraycounter = 0;
            try
            {
                DataTable dt = DbClass.getdata(CommandType.Text, "select distinct machine_id,PointName from point where point_id='" + m_sPointInformation + "'");

                GetDetail(dt.Rows[0]["Machine_ID"].ToString(), ref Plantname, ref Plantid, ref AreaName, ref Areaid, ref TrainName, ref Trainid, ref MachineName);

                ChartView _chartview = GeneratingGraphsForPointsNew("Power", "Axial", m_sPointInformation, Plantname, dt.Rows[0]["PointName"].ToString());

                for (int i = arraycounter; i < arrGotValues.Count; i++)
                {
                    x += 1;
                    arraycounter += 1;
                    double[] arrval = (double[])arrGotValues[i];
                    for (int j = 0; j < arrval.Length; j++)
                    {
                        double val = arrval[j];
                        if (sal == "Old")
                        {
                            sarrDataold.Add(val.ToString());
                        }
                        else
                        {
                            sarrDatanew.Add(val.ToString());
                        }


                    }
                    if (x == 4)
                    {
                        y += 1;
                        if (sal == "New")
                        {
                            sal = "Old";
                        }
                        else
                        {
                            sal = "New";
                        }
                        x = 0;
                        if (y == 2)
                        {
                            break;
                        }
                    }
                }

                DataRow diffDataSet = _Table.NewRow();
                diffDataSet["Oldaa"] = sarrDataold[0].ToString();
                diffDataSet["Oldah"] = sarrDataold[1].ToString();
                diffDataSet["Oldav"] = sarrDataold[2].ToString();
                diffDataSet["Oldva"] = sarrDataold[3].ToString();
                diffDataSet["Oldvh"] = sarrDataold[4].ToString();
                diffDataSet["Oldvv"] = sarrDataold[5].ToString();
                diffDataSet["Oldba"] = sarrDataold[6].ToString();
                diffDataSet["Oldbh"] = sarrDataold[7].ToString();
                diffDataSet["Oldbv"] = sarrDataold[8].ToString();
                diffDataSet["Oldda"] = sarrDataold[9].ToString();
                diffDataSet["Olddh"] = sarrDataold[10].ToString();
                diffDataSet["Olddv"] = sarrDataold[11].ToString();
                diffDataSet["Curraa"] = sarrDatanew[0].ToString();
                diffDataSet["Currah"] = sarrDatanew[1].ToString();
                diffDataSet["Currav"] = sarrDatanew[2].ToString();
                diffDataSet["Currva"] = sarrDatanew[3].ToString();
                diffDataSet["Currvh"] = sarrDatanew[4].ToString();
                diffDataSet["Currvv"] = sarrDatanew[5].ToString();
                diffDataSet["Currba"] = sarrDatanew[6].ToString();
                diffDataSet["Currbh"] = sarrDatanew[7].ToString();
                diffDataSet["Currbv"] = sarrDatanew[8].ToString();
                diffDataSet["Currda"] = sarrDatanew[9].ToString();
                diffDataSet["Currdh"] = sarrDatanew[10].ToString();
                diffDataSet["Currdv"] = sarrDatanew[11].ToString();
                diffDataSet["Diffaa"] = Convert.ToString(Convert.ToDouble(sarrDatanew[0]) - Convert.ToDouble(sarrDataold[0]));
                diffDataSet["Diffah"] = Convert.ToString(Convert.ToDouble(sarrDatanew[1]) - Convert.ToDouble(sarrDataold[1]));
                diffDataSet["Diffav"] = Convert.ToString(Convert.ToDouble(sarrDatanew[2]) - Convert.ToDouble(sarrDataold[2]));
                diffDataSet["Diffva"] = Convert.ToString(Convert.ToDouble(sarrDatanew[3]) - Convert.ToDouble(sarrDataold[3]));
                diffDataSet["Diffvh"] = Convert.ToString(Convert.ToDouble(sarrDatanew[4]) - Convert.ToDouble(sarrDataold[4]));
                diffDataSet["Diffvv"] = Convert.ToString(Convert.ToDouble(sarrDatanew[5]) - Convert.ToDouble(sarrDataold[5]));
                diffDataSet["Diffba"] = Convert.ToString(Convert.ToDouble(sarrDatanew[6]) - Convert.ToDouble(sarrDataold[6]));
                diffDataSet["Diffbh"] = Convert.ToString(Convert.ToDouble(sarrDatanew[7]) - Convert.ToDouble(sarrDataold[7]));
                diffDataSet["Diffbv"] = Convert.ToString(Convert.ToDouble(sarrDatanew[8]) - Convert.ToDouble(sarrDataold[8]));
                diffDataSet["Diffda"] = Convert.ToString(Convert.ToDouble(sarrDatanew[9]) - Convert.ToDouble(sarrDataold[9]));
                diffDataSet["Diffdh"] = Convert.ToString(Convert.ToDouble(sarrDatanew[10]) - Convert.ToDouble(sarrDataold[10]));
                diffDataSet["Diffdv"] = Convert.ToString(Convert.ToDouble(sarrDatanew[11]) - Convert.ToDouble(sarrDataold[11]));

                sarrDatanew = new ArrayList();
                sarrDataold = new ArrayList();

                diffDataSet["Point_ID"] = m_sPointInformation;
                diffDataSet["Plant_Name"] = Plantname;
                diffDataSet["Area_Name"] = AreaName;
                diffDataSet["Train_Name"] = TrainName;
                diffDataSet["Machine_Name"] = MachineName;
                diffDataSet["PointName"] = dt.Rows[0]["PointName"].ToString();

                if (_chartview != null)
                { 
                    //BufferedImage objImage = new BufferedImage(_chartview);
                    //Image GraphImage = (Image)objImage.GetBufferedImage();
                    //byteImageData = ImageToByte(GraphImage);
                    //DataRow ObjGraphRow = objMultireporting.multiData1.GraphImage.NewRow();
                    //ObjGraphRow["Graph"] = byteImageData;
                    //ObjGraphRow["Point_Id"] = Convert.ToString(dr["point_id"]).Trim();
                    //ObjGraphRow["GraphLabel"] = Convert.ToString(sarrMultiReportName[rr] + " " + AddValue[aa]);
                    //objMultireporting.multiData1.GraphImage.Rows.Add(ObjGraphRow);
                    //objMultireporting.multiData1.GraphImage.AcceptChanges();
                   
                }
                _Table.AcceptChanges();

            }
            catch
            { }
        }

        private void DifferenceReportingforDi(string rp_name)
        {
            try
            {
                string Machine_ID = null;
                string[] SelectedMachineIDs = null;
                RptOverallwithgraph objOverAllReport = new RptOverallwithgraph();
                objOverAllReport.lblTitle.Text = rp_name;
                splashScreenManager1.ShowWaitForm();
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        objOverAllReport.xrLabel2.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        objOverAllReport.xrPictureBox3.Image = Image.FromFile(clogo);
                    }
                }
                catch { }
                if (PublicClass.ReportName == "OverAll Values with Difference and Graphical Analysis")
                {
                    DataTable dtPoint = DbClass.getdata(CommandType.Text, "SELECT f.Factory_ID as 'FactoryID',a.Area_ID as 'Area_ID' ,t.Train_ID as 'TrainID', m.Machine_ID as 'MachineID'  FROM machine_info m left join train_info t on m.TrainID = t.Train_ID left join area_info a on a.Area_ID=t.Area_ID left join factory_info f on f.Factory_ID=a.FactoryID");
                    foreach (DataRow dr in dtPoint.Rows)
                    {
                        Machine_ID += Convert.ToString(dr["MachineID"]) + ",";
                    }
                    SelectedMachineIDs = Machine_ID.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }
                for (int xx = 0; xx < SelectedMachineIDs.Length; xx++)
                {
                    string sselctedPID = null;
                    DataTable dtpointid = new DataTable();
                    dtpointid = DbClass.getdata(CommandType.Text, "Select * from point p left join machine_info m on m.machine_id=p.machine_id where m.machine_id= '" + SelectedMachineIDs[xx] + "' ");

                    foreach (DataRow dr in dtpointid.Rows)
                    {
                        sselctedPID += "'" + Convert.ToString(dr["point_id"]).Trim() + "',";
                    }
                    string newsssid = sselctedPID.Remove(sselctedPID.Length - 1);

                    DataTable dt1 = new DataTable();

                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct pa.Data_ID,pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id  where pa.point_id IN (" + newsssid + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'   group by data_id order by point_id");

                    foreach (DataRow dr in dt1.Rows)
                    {
                        DataRow Tempdatarow = objOverAllReport.overallvalues1.DFDataTable.NewRow();


                        objOverAllReport.overallvalues1.DFDataTable.Rows.Add(Tempdatarow);
                        objOverAllReport.overallvalues1.DFDataTable.AcceptChanges();


                    }
                }


            }
            catch { }
        }


        
        ArrayList arrReturnedArray = null;
        private void DifferenceReporting(string rp_name)
        {
            try
            {
                string Machine_ID = null;
                string[] SelectedMachineIDs = null;
                RptOverallwithgraph objOverAllReport = new RptOverallwithgraph();
                objOverAllReport.lblTitle.Text = rp_name;
                splashScreenManager1.ShowWaitForm();
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        objOverAllReport.xrLabel2.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        objOverAllReport.xrPictureBox3.Image = Image.FromFile(clogo);
                    }
                }
                catch { }
                if (PublicClass.ReportName == "OverAll Values with Difference and Graphical Analysis")
                {
                    DataTable dtPoint = DbClass.getdata(CommandType.Text, "SELECT f.Factory_ID as 'FactoryID',a.Area_ID as 'Area_ID' ,t.Train_ID as 'TrainID', m.Machine_ID as 'MachineID'  FROM machine_info m left join train_info t on m.TrainID = t.Train_ID left join area_info a on a.Area_ID=t.Area_ID left join factory_info f on f.Factory_ID=a.FactoryID");
                    foreach (DataRow dr in dtPoint.Rows)
                    {
                        Machine_ID += Convert.ToString(dr["MachineID"]) + ",";
                    }
                    SelectedMachineIDs = Machine_ID.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }
                for (int xx = 0; xx < SelectedMachineIDs.Length; xx++)
                {
                    string sselctedPID = null;
                    DataTable dtpointid = new DataTable();
                    dtpointid = DbClass.getdata(CommandType.Text, "Select * from point p left join machine_info m on m.machine_id=p.machine_id where m.machine_id= '" + SelectedMachineIDs[xx] + "' ");

                    foreach (DataRow dr in dtpointid.Rows)
                    {
                        sselctedPID += "'" + Convert.ToString(dr["point_id"]).Trim() + "',";
                    }

                    string newsssid = sselctedPID.Remove(sselctedPID.Length - 1);

                    DataTable dt1 = new DataTable();

                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id  where pa.point_id IN (" + newsssid + ") and pa.Measure_time between '"+PublicClass.StartingDate+"' and '"+PublicClass.EndDate+"'   group by data_id order by point_id");
                   
                    foreach (DataRow dr in dt1.Rows)
                    {
                        string pointid = Convert.ToString(dr["point_id"]).Trim();
                        string data_id = Convert.ToString(dr["Data_ID"]).Trim();
                        DataTable dtpoint_data = new DataTable();
                        dtpoint_data = DbClass.getdata(CommandType.Text, "select alar.alarm_name,fac.name as fname,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "' and pd.Data_ID='" + data_id + "'");
                        arrReturnedArray = GetValues("Devex", data_id);
                        overallvalues.DFDataTableDataTable _Table = new overallvalues.DFDataTableDataTable();
                        CreateSimpleDocument(pointid, arrReturnedArray, ref _Table);
                        foreach (DataRow _DataRow in dtpoint_data.Rows)
                        {
                            DataRow Tempdatarow = objOverAllReport.overallvalues1.DFDataTable.NewRow();
                            Tempdatarow["Oldaa"] = _DataRow["Oldaa"].ToString().Trim();
                            Tempdatarow["Oldah"] = _DataRow["Oldah"].ToString().Trim();
                            Tempdatarow["Oldav"] = _DataRow["Oldav"].ToString().Trim();
                            Tempdatarow["Oldva"] = _DataRow["Oldva"].ToString().Trim();
                            Tempdatarow["Oldvh"] = _DataRow["Oldvh"].ToString().Trim();
                            Tempdatarow["Oldvv"] = _DataRow["Oldvv"].ToString().Trim();
                            Tempdatarow["Oldba"] = _DataRow["Oldba"].ToString().Trim();
                            Tempdatarow["Oldbh"] = _DataRow["Oldbh"].ToString().Trim();
                            Tempdatarow["Oldbv"] = _DataRow["Oldbv"].ToString().Trim();
                            Tempdatarow["Oldda"] = _DataRow["Oldda"].ToString().Trim();
                            Tempdatarow["Olddh"] = _DataRow["Olddh"].ToString().Trim();
                            Tempdatarow["Olddv"] = _DataRow["Olddv"].ToString().Trim();
                            Tempdatarow["Curraa"] = _DataRow["Curraa"].ToString().Trim();
                            Tempdatarow["Currah"] = _DataRow["Currah"].ToString().Trim();
                            Tempdatarow["Currav"] = _DataRow["Currav"].ToString().Trim();
                            Tempdatarow["Currva"] = _DataRow["Currva"].ToString().Trim();
                            Tempdatarow["Currvh"] = _DataRow["Currvh"].ToString().Trim();
                            Tempdatarow["Currvv"] = _DataRow["Currvv"].ToString().Trim();
                            Tempdatarow["Currba"] = _DataRow["Currba"].ToString().Trim();
                            Tempdatarow["Currbh"] = _DataRow["Currbh"].ToString().Trim();
                            Tempdatarow["Currbv"] = _DataRow["Currbv"].ToString().Trim();
                            Tempdatarow["Currda"] = _DataRow["Currda"].ToString().Trim();
                            Tempdatarow["Currdh"] = _DataRow["Currdh"].ToString().Trim();
                            Tempdatarow["Currdv"] = _DataRow["Currdv"].ToString().Trim();
                            Tempdatarow["Diffaa"] = _DataRow["Diffaa"].ToString().Trim();
                            Tempdatarow["Diffah"] = _DataRow["Diffah"].ToString().Trim();
                            Tempdatarow["Diffav"] = _DataRow["Diffav"].ToString().Trim();
                            Tempdatarow["Diffva"] = _DataRow["Diffva"].ToString().Trim();
                            Tempdatarow["Diffvh"] = _DataRow["Diffvh"].ToString().Trim();
                            Tempdatarow["Diffvv"] = _DataRow["Diffvv"].ToString().Trim();
                            Tempdatarow["Diffba"] = _DataRow["Diffba"].ToString().Trim();
                            Tempdatarow["Diffbh"] = _DataRow["Diffbh"].ToString().Trim();
                            Tempdatarow["Diffbv"] = _DataRow["Diffbv"].ToString().Trim();
                            Tempdatarow["Diffda"] = _DataRow["Diffda"].ToString().Trim();
                            Tempdatarow["Diffdh"] = _DataRow["Diffdh"].ToString().Trim();
                            Tempdatarow["Diffdv"] = _DataRow["Diffdv"].ToString().Trim();
                            Tempdatarow["Graph"] = _DataRow["Graph"];
                            Tempdatarow["GraphLabel"] = _DataRow["GraphLabel"].ToString().Trim();
                            Tempdatarow["Point_ID"] = _DataRow["Point_ID"].ToString().Trim();
                            Tempdatarow["Plant_Name"] = _DataRow["Plant_Name"].ToString().Trim();
                            Tempdatarow["Area_Name"] = _DataRow["Area_Name"].ToString().Trim();
                            Tempdatarow["Train_Name"] = _DataRow["Train_Name"].ToString().Trim();
                            Tempdatarow["Machine_Name"] = _DataRow["Machine_Name"].ToString().Trim();
                            Tempdatarow["PointName"] = _DataRow["PointName"].ToString().Trim();

                            objOverAllReport.overallvalues1.DFDataTable.Rows.Add(Tempdatarow);
                            objOverAllReport.overallvalues1.DFDataTable.AcceptChanges();
                        }
                    }


                }
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }

        private void overduepoint(string reportname)
        {
            try
            {
                int inctr = 0;
                OverDueReport rptnote = new OverDueReport();
                rptnote.xrLabel2.Text = "Point Notes Report";
                rptnote.xrTable5.Visible = false;
                rptnote.DetailReport.Visible = false;
                splashScreenManager1.ShowWaitForm();
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        rptnote.xrLabel1.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        rptnote.xrPictureBox1.Image = Image.FromFile(clogo);
                    }
                }
                catch { }

                DataTable dtpoint_data = new DataTable();
                dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where  pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "' order by p.point_id");

                foreach (DataRow dr in dtpoint_data.Rows)
                {
                    DataRow hieRow = rptnote.multiData1.PointrecordDueDate.NewRow();
                    dataID = Convert.ToString(dr["Data_ID"]);
                    PublicClass.Data_ID = dataID;
                    ptID = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                    string Machine_id = Convert.ToString(Convert.ToString(dr["Machine_ID"]).Trim());
                    string Plantname = "";
                    string Plantid = "";
                    string MachineName = "";
                    string AreaName = "";
                    string Areaid = "";
                    string TrainName = "";
                    string Trainid = "";

                    GetDetail(Machine_id, ref Plantname, ref Plantid, ref AreaName, ref Areaid, ref TrainName, ref Trainid, ref MachineName);
                    hieRow["FactoryName"] = Plantname.Trim();
                    hieRow["ResourceName"] = AreaName.Trim();
                    hieRow["ElementName"] = TrainName.Trim();
                    hieRow["SuElementName"] = MachineName.Trim();
                    hieRow["PointName"] = Convert.ToString(Convert.ToString(dr["pointname"]).Trim());
                    hieRow["PointID"] = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                    string sPointID = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                    DataTable dt = DbClass.getdata(CommandType.Text, "SELECT p.Point_ID,p.pointname, p.PointDesc,p.PointType_ID , p.DataSchedule , max(pd.Measure_time) as Measure_time FROM POINT p inner join point_data pd  on p.Point_ID = pd.Point_ID where p.Point_ID='" + sPointID + "' and Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "' group by pd.point_id");

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
                            string DueD = _objusercontrol.countdays(FromYear, ToYear);
                            double DueDays = Math.Round(Convert.ToDouble(DueD), 0);
                            string DueDay = Convert.ToString(DueDays);
                            DueDay = DueDay + "Days";
                            hieRow["DueDate"] = DueDay;
                        }
                    }

                    rptnote.multiData1.PointrecordDueDate.Rows.Add(hieRow);
                    rptnote.multiData1.PointrecordDueDate.AcceptChanges();
                }
                printControl1.PrintingSystem = rptnote.PrintingSystem;
                rptnote.CreateDocument();
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }


        //---make by varsha---//
        public void DiffandGraphforDI(string GType, string Overallvalue, string rp_name)
        {
            try
            {               
                RptAllforDI objOverAllReport = new RptAllforDI();              
                objOverAllReport.xrTableCell16.Text = "Previous OverAll Value";
                objOverAllReport.xrTableCell18.Text = "Current OverAll Value";
                objOverAllReport.xrTableCell19.Text = "Difference";
                ArrayList arrXYVals = null;
                ArrayList arrtime = new ArrayList();
                dataID = null;
                ChartView _chartview = new ChartView();
                string graphtypevalue = GType;
                string overallvalue = Overallvalue;
                if (Convert.ToString(graphtypevalue).Trim() == "")
                {
                    return;
                }

                objOverAllReport.xrLabel2.Text = rp_name;
                objOverAllReport.DetailReport1.Visible = true;
                frmHierrarchySelection MyReport = new frmHierrarchySelection();
                MyReport.ShowDialog();
                splashScreenManager1.ShowWaitForm();
                string[] SelectedMachineIDs = MyReport.Machine_id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string mID = Convert.ToString(SelectedMachineIDs[0]);
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        objOverAllReport.xrLabel1.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        objOverAllReport.xrPictureBox1.Image = Image.FromFile(clogo);
                    }
                }
                catch
                {
                }

                DataTable dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where Machine_ID ='" + mID + "' group by p.point_id");
                foreach (DataRow dr in dtpoint_data.Rows)
                {
                    int counterctrl = 0;
                    double dAccel_h = 0;
                    double dX = 0;
                    double dAccel_h1 = 0;
                    double dX1 = 0;
                    double[] dYData = null;
                    double[] dXData = null;
                    arrXYVals = new ArrayList();
                    LineGraphControl _LineGraph = new LineGraphControl();
                    string pointid = Convert.ToString(dr["point_id"]).Trim();

                    DataTable dt = DbClass.getdata(CommandType.Text, "select distinct pd.Data_ID as Data_ID,alar.alarm_name,fac.name as fname,di.ChannelType as ChannelType,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join di_point di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "' order by pd.data_id desc");
                    if (dt.Rows.Count > 1)
                    {
                        dYData = new double[dt.Rows.Count];
                        dXData = new double[dt.Rows.Count];
                        int count = 0;
                        string[] XDataLabels = new string[dt.Rows.Count];
                        string PlantName = null;
                        string pointname = null;
                        PublicClass.SPointID = pointid;                        
                        string measuretime = null;
                        string unitDI = mpointgenerl.getExtractCurrentUnit();
                        string[] SelectedunitIDs = unitDI.Split(new string[] { "," },StringSplitOptions.RemoveEmptyEntries);
                        Yunits = SelectedunitIDs[1];
                        DataRow hieRow = objOverAllReport.multiData1.HirarchyTable.NewRow();
                        hieRow["Factory"] = Convert.ToString(dt.Rows[0]["fname"]);
                        PlantName = Convert.ToString(dt.Rows[0]["fname"]);
                        hieRow["Area"] = Convert.ToString(dt.Rows[0]["areaname"]);
                        hieRow["Train"] = Convert.ToString(dt.Rows[0]["tname"]);
                        hieRow["Machine"] = Convert.ToString(dt.Rows[0]["macname"]);
                        hieRow["Point"] = Convert.ToString(dt.Rows[0]["pname"]);
                        pointname = Convert.ToString(dt.Rows[0]["pname"]);
                        hieRow["Point_Id"] = pointid;
                        objOverAllReport.multiData1.HirarchyTable.Rows.Add(hieRow);
                        objOverAllReport.multiData1.HirarchyTable.AcceptChanges();

                        bool sts = false;
                        DataRow hieRow1 = objOverAllReport.multiData1.Data.NewRow();
                        foreach (DataRow dr2 in dt.Rows)
                        {                          
                            PublicClass.Data_ID = Convert.ToString(dr2["Data_ID"]);                            
                            measuretime = Convert.ToDateTime(dr2["Measuredate"]).ToString("yyyy-MM-dd HH:mm:ss");
                            arrtime.Add(measuretime);
                            XDataLabels[count] = measuretime;
                            dX = arrtime.Count;
                            dXData[count] = dX;

                            counterctrl++;
                            if (counterctrl == 2)
                            {                                
                                dAccel_h1 = Convert.ToDouble(dr2["accel_a"]);
                                dAccel_h1 = Math.Round(dAccel_h1, 2);
                                hieRow1["Value"] = dAccel_h1 + " " + Yunits;
                                sts = true;
                            }
                            if (counterctrl == 1)
                            {
                                dX1 = Convert.ToDouble(dr2["accel_a"]);
                                dX1 = Math.Round(dX1, 2);
                                hieRow1["Date"] = dX1 + " " + Yunits;
                                sts = false;
                            }
                            if (sts)
                            {
                                double dY = dX1 - dAccel_h1;
                                hieRow1["Label"] = dY + " " + Yunits;
                            }
                            hieRow1["Point_ID"] = pointid;
                            count++;
                        }
                        objOverAllReport.multiData1.Data.Rows.Add(hieRow1);
                        objOverAllReport.multiData1.Data.AcceptChanges();
                        tempdates1.Add(measuretime);
                        _chartview = GeneratingGraphsForPointsNew("Power", "Axial", pointid, PlantName, pointname);
                        if (_chartview != null)
                        {
                            BufferedImage objImage = new BufferedImage(_chartview);
                            Image GraphImage = (Image)objImage.GetBufferedImage();
                            byteImageData = ImageToByte(GraphImage);
                            DataRow ObjGraphRow = objOverAllReport.multiData1.GraphImage.NewRow();
                            ObjGraphRow["Graph"] = byteImageData;
                            ObjGraphRow["Point_ID"] = pointid;
                            ObjGraphRow["GraphLabel"] = " Graph : Channel 1";//Convert.ToString(sarrMultiReportName[rr] + " " + AddValue[aa]);
                            objOverAllReport.multiData1.GraphImage.Rows.Add(ObjGraphRow);
                            objOverAllReport.multiData1.GraphImage.AcceptChanges();
                        }
                    }
                }
                printControl1.PrintingSystem = objOverAllReport.PrintingSystem;
                objOverAllReport.CreateDocument();
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }

             
        private void NewOverallForDI(string report_name)
        {
            try
            {
                ptID = null;
                string chkPoint = null;
                string Machine_ID = null; string graphlabel = null; string PlantName = null; string pointname = null;
                string[] SelectedMachineIDs = null; ChartView _chartview = new ChartView();
                string[] AddValue = { "Axial", "Horizontal", "Vertical", "Channel1" };
                RptAllforDI objOverAllReport = new RptAllforDI();
                objOverAllReport.xrLabel2.Text = report_name;
                if (PublicClass.ReportName == "Overall Values Of Acceleration with Power Graph" || PublicClass.ReportName == "Overall Values Of Velocity with Power Graph" || PublicClass.ReportName == "Overall Values Of Displacement with Power Graph")
                {
                    objOverAllReport.DetailReport1.Visible = true;
                }
                else
                {
                    objOverAllReport.DetailReport1.Visible = false;
                }
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    try
                    {
                        foreach (DataRow dr in dtcompimage.Rows)
                        {
                            string cname = Convert.ToString(dr["Company_Name"]).Trim();
                            objOverAllReport.xrLabel1.Text = cname;
                            string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                            clogo = clogo.Replace('-', '\\');
                            objOverAllReport.xrPictureBox1.Image = Image.FromFile(clogo);
                        }
                    }
                    catch { }
                    if (PublicClass.ReportName == "OverAll Values" || PublicClass.ReportName == "Report for Overall Values Of All Displacement" || PublicClass.ReportName == "Overall Trend Values" || PublicClass.ReportName == "Report for Overall Values Of All Acceleration" || PublicClass.ReportName == "Report for Overall Values Of All Velocity" || PublicClass.ReportName == "Overall Values Of Acceleration with Power Graph" || PublicClass.ReportName == "Overall Values Of Velocity with Power Graph" || PublicClass.ReportName == "Overall Values Of Displacement with Power Graph")
                    {
                        DataTable dtPoint = DbClass.getdata(CommandType.Text, "SELECT f.Factory_ID as 'FactoryID',a.Area_ID as 'Area_ID' ,t.Train_ID as 'TrainID', m.Machine_ID as 'MachineID'  FROM machine_info m left join train_info t on m.TrainID = t.Train_ID left join area_info a on a.Area_ID=t.Area_ID left join factory_info f on f.Factory_ID=a.FactoryID");
                        foreach (DataRow dr in dtPoint.Rows)
                        {
                            Machine_ID += Convert.ToString(dr["MachineID"]) + ",";
                        }
                        SelectedMachineIDs = Machine_ID.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    for (int xx = 0; xx < SelectedMachineIDs.Length; xx++)
                    {
                        string sselctedPID = null;
                        DataTable dtpointid = new DataTable();
                        dtpointid = DbClass.getdata(CommandType.Text, "Select * from point p left join machine_info m on m.machine_id=p.machine_id where m.machine_id= '" + SelectedMachineIDs[xx] + "' ");

                        foreach (DataRow dr in dtpointid.Rows)
                        {
                            sselctedPID += "'" + Convert.ToString(dr["point_id"]).Trim() + "',";
                        }

                        string newsssid = sselctedPID.Remove(sselctedPID.Length - 1);
                        string newssgain = null;
                        DataTable dt1 = new DataTable();
                        if (PublicClass.ReportName == "OverAll Values")
                        {
                            if (PublicClass.currentInstrument == "Kohtect-C911")
                            {
                                dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct p.pointname,pa.*  FROM point_data  pa inner join point p on pa.point_id=p.point_id  where pa.point_id IN (" + newsssid + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                            }
                            else
                            {
                                dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id  where pa.point_id IN (" + newsssid + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                            }
                        }
                        else if (PublicClass.ReportName == "Report for Overall Values Of All Displacement" || PublicClass.ReportName == "Overall Values Of Displacement with Power Graph")
                        {
                            if (PublicClass.currentInstrument == "Kohtect-C911")
                            {
                                graphlabel = "Displacement";
                                newssgain = "'2'";
                                dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.SelectRadio1 in(" + newssgain + ") or di.SelectRadio2 in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                            }
                            else
                            {
                                newssgain = "'3','4','7','8','9','10','26','27'";
                                dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.Type_Unit in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                            }
                        }
                        else if (PublicClass.ReportName == "Report for Overall Values Of All Acceleration" || PublicClass.ReportName == "Overall Values Of Acceleration with Power Graph") 
                        {
                            if (PublicClass.currentInstrument == "Kohtect-C911")
                            {
                                graphlabel = "Acceleration";
                                newssgain = "'0'";
                                dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.SelectRadio1 in(" + newssgain + ") or di.SelectRadio2 in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                            }
                            else
                            {
                                newssgain = "'0','23'";
                                dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.Type_Unit in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                            }
                        }
                        else if (PublicClass.ReportName == "Overall Trend Values")
                        {
                            dt1 = DbClass.getdata(CommandType.Text, "SELECT pd.point_id,pd.point_name ,COUNT( point_name ) `tot` FROM point_data pd  left join point p on pd.point_id=p.point_id left join machine_info mac on mac.machine_id=p.machine_id where mac.machine_id='" + SelectedMachineIDs[xx] + "' GROUP BY point_name HAVING `tot` >1");
                            //dt1 = DbClass.getdata(CommandType.Text, "SELECT point_id, COUNT( point_name ) `tot` FROM point_data GROUP BY point_name HAVING `tot` >1 ");
                        }
                        else
                        {
                            if (PublicClass.currentInstrument == "Kohtect-C911")
                            {
                                graphlabel = "Velocity";
                                newssgain = "'1'";
                                dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.SelectRadio1 in(" + newssgain + ") or di.SelectRadio2 in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                            }
                            else
                            {
                                newssgain = "'1','2','5','6','24','25'";
                                dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id left join type_point tp on tp.id=p.pointtype_id left join di_point di on di.Type_ID=tp.ID   where pa.point_id IN (" + newsssid + ") and di.Type_Unit in(" + newssgain + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");
                            }
                        }

                        if (PublicClass.currentInstrument == "Kohtect-C911")
                        {
                            foreach (DataRow dr in dt1.Rows)
                            {
                                string pointid = Convert.ToString(dr["point_id"]).Trim();
                                ptID = pointid;
                                //string data_id = Convert.ToString(dr["Data_ID"]).Trim();
                                PublicClass.SPointID = pointid;
                                if (ptID != chkPoint)
                                {
                                    string measuretime = null;
                                    string unitDI = mpointgenerl.getUnitValuesC911();
                                    string[] SelectedunitIDs = unitDI.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                    Yunits = SelectedunitIDs[1];
                                    DataTable dtpoint_data = new DataTable();
                                    dtpoint_data = DbClass.getdata(CommandType.Text, "select distinct alar.alarm_name,fac.name as fname,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "' group by pd.Point_id");
                                    foreach (DataRow dr1 in dtpoint_data.Rows)
                                    {
                                        DataRow hieRow = objOverAllReport.multiData1.HirarchyTable.NewRow();
                                        hieRow["Factory"] = Convert.ToString(dr1["fname"]);
                                        PlantName = Convert.ToString(dr1["fname"]);
                                        hieRow["Area"] = Convert.ToString(dr1["areaname"]);
                                        hieRow["Train"] = Convert.ToString(dr1["tname"]);
                                        hieRow["Machine"] = Convert.ToString(dr1["macname"]);
                                        hieRow["Point"] = Convert.ToString(dr1["pname"]);
                                        pointname = Convert.ToString(dr1["pname"]);
                                        hieRow["Point_Id"] = PublicClass.SPointID;
                                        objOverAllReport.multiData1.HirarchyTable.Rows.Add(hieRow);
                                        objOverAllReport.multiData1.HirarchyTable.AcceptChanges();
                                        DataTable dtagain = DbClass.getdata(CommandType.Text, "select distinct di.Channel1,di.Channel2,di.SelectRadio1,di.SelectRadio2,alar.alarm_name,fac.name as fname,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "'");
                                        foreach (DataRow dr2 in dtagain.Rows)
                                        {
                                            string overalltype = null;
                                            DataRow hieRow1 = objOverAllReport.multiData1.Data.NewRow();
                                            hieRow1["Date"] = Convert.ToString(dr2["Measuredate"]);
                                            measuretime = Convert.ToDateTime(dr2["Measuredate"]).ToString("yyyy-MM-dd HH:mm:ss");
                                            hieRow1["Point_ID"] = Convert.ToString(dr["point_id"]).Trim();
                                            string chl1 = Convert.ToString(dr2["Channel1"]);
                                            string chl2 = Convert.ToString(dr2["Channel2"]);
                                            string dir1 = Convert.ToString(dr2["SelectRadio1"]);
                                            string dir2 = Convert.ToString(dr2["SelectRadio2"]);
                                            if (chl1 == "0" || chl1 == "1" || chl1 == "2")
                                            {
                                                if (dir1 == "0")
                                                { overalltype = "accel_h"; }
                                                else if (dir1 == "1")
                                                { overalltype = "vel_h"; }
                                                else if (dir1 == "2")
                                                { overalltype = "displ_h"; }
                                                hieRow1["Label"] = "CH:- 1";
                                            }
                                            else
                                            {
                                                if (dir2 == "0")
                                                { overalltype = "accel_v"; }
                                                else if (dir2 == "1")
                                                { overalltype = "vel_v"; }
                                                else if (dir2 == "2")
                                                { overalltype = "displ_v"; }
                                                hieRow1["Label"] = "CH:- 2";
                                            }
                                            hieRow1["Value"] = Convert.ToString(dr2[overalltype]) + ' ' + Yunits;
                                            objOverAllReport.multiData1.Data.Rows.Add(hieRow1);
                                            objOverAllReport.multiData1.Data.AcceptChanges();


                                            if (PublicClass.currentInstrument == "Kohtect-C911")
                                            {
                                                if (PublicClass.ReportName == "Overall Values Of Acceleration with Power Graph" || PublicClass.ReportName == "Overall Values Of Velocity with Power Graph" || PublicClass.ReportName == "Overall Values Of Displacement with Power Graph")
                                                {
                                                    tempdates1.Add(measuretime);
                                                    for (int aa = 0; aa < AddValue.Length; aa++)
                                                    {
                                                        if (GType == "Time")
                                                        {
                                                            _chartview = GeneratingGraphsForPointsNew("Time", AddValue[aa], pointid, PlantName, pointname);
                                                        }
                                                        else if (GType == "Power")
                                                        {
                                                            _chartview = GeneratingGraphsForPointsNew("Power", AddValue[aa], pointid, PlantName, pointname);
                                                        }
                                                        else
                                                        {
                                                            _chartview = GeneratingGraphsForPointsNew("Power", AddValue[aa], pointid, PlantName, pointname);
                                                        }
                                                        if (_chartview != null)
                                                        {
                                                            BufferedImage objImage = new BufferedImage(_chartview);
                                                            Image GraphImage = (Image)objImage.GetBufferedImage();
                                                            byteImageData = ImageToByte(GraphImage);
                                                            DataRow ObjGraphRow = objOverAllReport.multiData1.GraphImage.NewRow();
                                                            ObjGraphRow["Graph"] = byteImageData;
                                                            ObjGraphRow["Point_ID"] = pointid;
                                                            ObjGraphRow["GraphLabel"] = graphlabel + " " + AddValue[aa];//Convert.ToString(sarrMultiReportName[rr] + " " + AddValue[aa]);
                                                            objOverAllReport.multiData1.GraphImage.Rows.Add(ObjGraphRow);
                                                            objOverAllReport.multiData1.GraphImage.AcceptChanges();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                chkPoint = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dt1.Rows)
                            {
                                string pointid = Convert.ToString(dr["point_id"]).Trim();
                                ptID = pointid;
                                //string data_id = Convert.ToString(dr["Data_ID"]).Trim();
                                PublicClass.SPointID = pointid;
                                if (ptID != chkPoint)
                                {
                                    string unitDI = mpointgenerl.getExtractCurrentUnit();
                                    string[] SelectedunitIDs = unitDI.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                    Yunits = SelectedunitIDs[1];
                                    DataTable dtpoint_data = new DataTable();
                                    dtpoint_data = DbClass.getdata(CommandType.Text, "select distinct alar.alarm_name,fac.name as fname,di.ChannelType as ChannelType,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join di_point di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "' group by pd.Point_id");
                                    foreach (DataRow dr1 in dtpoint_data.Rows)
                                    {
                                        DataRow hieRow = objOverAllReport.multiData1.HirarchyTable.NewRow();
                                        hieRow["Factory"] = Convert.ToString(dr1["fname"]);
                                        hieRow["Area"] = Convert.ToString(dr1["areaname"]);
                                        hieRow["Train"] = Convert.ToString(dr1["tname"]);
                                        hieRow["Machine"] = Convert.ToString(dr1["macname"]);
                                        hieRow["Point"] = Convert.ToString(dr1["pname"]);
                                        hieRow["Point_Id"] = PublicClass.SPointID;
                                        objOverAllReport.multiData1.HirarchyTable.Rows.Add(hieRow);
                                        objOverAllReport.multiData1.HirarchyTable.AcceptChanges();
                                        DataTable dtagain = DbClass.getdata(CommandType.Text, "select distinct di.Type_Unit,di.direction,alar.alarm_name,fac.name as fname,di.ChannelType as ChannelType,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join di_point di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "'");
                                        foreach (DataRow dr2 in dtagain.Rows)
                                        {
                                            DataRow hieRow1 = objOverAllReport.multiData1.Data.NewRow();
                                            hieRow1["Date"] = Convert.ToString(dr2["Measuredate"]);
                                            string TypeUnit = Convert.ToString(dr2["Type_Unit"]);
                                            string dir = Convert.ToString(dr2["direction"]);
                                            string overalltype = null; string overtype = null;
                                            if (TypeUnit == "0" || TypeUnit == "23")
                                            {
                                                overtype = "accel_";
                                            }
                                            else if (TypeUnit == "1" || TypeUnit == "2" || TypeUnit == "5" || TypeUnit == "6" || TypeUnit == "24" || TypeUnit == "25")
                                            {
                                                overtype = "vel_";
                                            }
                                            else if (TypeUnit == "3" || TypeUnit == "4" || TypeUnit == "7" || TypeUnit == "8" || TypeUnit == "9" || TypeUnit == "10" || TypeUnit == "26" || TypeUnit == "27")
                                            {
                                                overtype = "displ_";
                                            }
                                            if (dir == "0")
                                            {
                                                overalltype = overtype + "h"; overtype = "Horizontal";
                                            }
                                            else if (dir == "1")
                                            {
                                                overalltype = overtype + "v"; overtype = "Vertical";
                                            }
                                            else if (dir == "3")
                                            {
                                                overalltype = overtype + "a"; overtype = "Axial";
                                            }
                                            hieRow1["Value"] = Convert.ToString(dr2[overalltype]) + ' ' + Yunits;
                                            hieRow1["Point_ID"] = Convert.ToString(dr["point_id"]).Trim();
                                            if (Convert.ToString(dr1["ChannelType"]) == "0" || Convert.ToString(dr1["ChannelType"]) == "1" || Convert.ToString(dr1["ChannelType"]) == "2")
                                            {
                                                if (dir == "2")
                                                { hieRow1["Label"] = "CH:- 1"; }
                                                else
                                                { hieRow1["Label"] = "CH:- 1" + ' ' + "(" + overtype + ")"; }
                                            }
                                            else if (Convert.ToString(dr1["ChannelType"]) == "3" || Convert.ToString(dr1["ChannelType"]) == "4")
                                            {
                                                if (dir == "2")
                                                { hieRow1["Label"] = "CH:- 2"; }
                                                else
                                                { hieRow1["Label"] = "CH:- 2" + ' ' + "(" + overtype + ")"; }
                                            }
                                            objOverAllReport.multiData1.Data.Rows.Add(hieRow1);
                                            objOverAllReport.multiData1.Data.AcceptChanges();
                                        }

                                    }
                                }
                                chkPoint = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                            }
                        }
                    } 
                    printControl1.PrintingSystem = objOverAllReport.PrintingSystem;
                    objOverAllReport.CreateDocument();

                }
                catch { }
               // splashScreenManager1.CloseWaitForm();
            }
            catch { }
        }


        private void NewOverall(string report_name)
        {
            try
            {
                string Machine_ID = null;
                string[] SelectedMachineIDs = null;
                rptnewoverall objOverAllReport = new rptnewoverall();
                objOverAllReport.lblTitle.Text = report_name;
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        objOverAllReport.xrLabel2.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        objOverAllReport.xrPictureBox3.Image = Image.FromFile(clogo);
                    }
                }
                catch { }

                if (PublicClass.ReportName == "OverAll Values")
                {
                    DataTable dtPoint = DbClass.getdata(CommandType.Text, "SELECT f.Factory_ID as 'FactoryID',a.Area_ID as 'Area_ID' ,t.Train_ID as 'TrainID', m.Machine_ID as 'MachineID'  FROM machine_info m left join train_info t on m.TrainID = t.Train_ID left join area_info a on a.Area_ID=t.Area_ID left join factory_info f on f.Factory_ID=a.FactoryID");
                    foreach (DataRow dr in dtPoint.Rows)
                    {
                        Machine_ID += Convert.ToString(dr["MachineID"]) + ",";
                    }
                    SelectedMachineIDs = Machine_ID.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    frmHierrarchySelection MyReport = new frmHierrarchySelection();
                    MyReport.ShowDialog();
                    splashScreenManager1.ShowWaitForm();
                    SelectedMachineIDs = MyReport.Machine_id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }
                for (int xx = 0; xx < SelectedMachineIDs.Length; xx++)
                {
                    string sselctedPID = null;
                    DataTable dtpointid = new DataTable();
                    dtpointid = DbClass.getdata(CommandType.Text, "Select * from point p left join machine_info m on m.machine_id=p.machine_id where m.machine_id= '" + SelectedMachineIDs[xx] + "' ");

                    foreach (DataRow dr in dtpointid.Rows)
                    {
                        sselctedPID += "'" + Convert.ToString(dr["point_id"]).Trim() + "',";
                    }

                    string newsssid = sselctedPID.Remove(sselctedPID.Length - 1);

                    DataTable dt1 = new DataTable();

                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.measure_time, pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id  where pa.point_id IN (" + newsssid + ") and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");

                    foreach (DataRow dr in dt1.Rows)
                    {
                        string pointid = Convert.ToString(dr["point_id"]).Trim();
                        string data_id = Convert.ToString(dr["Data_ID"]).Trim();
                        DataTable dtpoint_data = new DataTable();
                        dtpoint_data = DbClass.getdata(CommandType.Text, "select alar.alarm_name,fac.name as fname,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "' and pd.Data_ID='" + data_id + "'");
                        foreach (DataRow dr1 in dtpoint_data.Rows)
                        {
                            DataRow hieRow = objOverAllReport.overallvalues1.PointRecordOverAll.NewRow();
                            hieRow["Factory_Name"] = Convert.ToString(dr1["fname"]);
                            hieRow["Resource_Name"] = Convert.ToString(dr1["areaname"]);
                            hieRow["Element_Name"] = Convert.ToString(dr1["tname"]);
                            hieRow["Sub_Element_Name"] = Convert.ToString(dr1["macname"]);
                            hieRow["pointname"] = Convert.ToString(dr1["pname"]);
                            hieRow["point_id"] = pointid;
                            hieRow["accel_a"] = Convert.ToString(dr1["accel_a"]);
                            hieRow["accel_h"] = Convert.ToString(dr1["accel_h"]);
                            hieRow["accel_v"] = Convert.ToString(dr1["accel_v"]);
                            hieRow["accel_ch1"] = Convert.ToString(dr1["accel_ch1"]);
                            hieRow["vel_a"] = Convert.ToString(dr1["vel_a"]);
                            hieRow["vel_h"] = Convert.ToString(dr1["vel_h"]);
                            hieRow["vel_v"] = Convert.ToString(dr1["vel_v"]);
                            hieRow["vel_ch1"] = Convert.ToString(dr1["vel_ch1"]);
                            hieRow["disp_a"] = Convert.ToString(dr1["displ_a"]);
                            hieRow["disp_h"] = Convert.ToString(dr1["displ_h"]);
                            hieRow["disp_v"] = Convert.ToString(dr1["displ_v"]);
                            hieRow["disp_ch1"] = Convert.ToString(dr1["displ_ch1"]);
                            hieRow["bearing_a"] = Convert.ToString(dr1["bearing_a"]);
                            hieRow["bearing_h"] = Convert.ToString(dr1["bearing_h"]);
                            hieRow["bearing_v"] = Convert.ToString(dr1["bearing_v"]);
                            hieRow["bearing_ch1"] = Convert.ToString(dr1["bearing_ch1"]);

                            hieRow["crest_factor_a"] = Convert.ToString(dr1["crest_factor_a"]);
                            hieRow["crest_factor_h"] = Convert.ToString(dr1["crest_factor_h"]);
                            hieRow["crest_factor_v"] = Convert.ToString(dr1["crest_factor_v"]);
                            hieRow["crest_factor_ch1"] = Convert.ToString(dr1["crest_factor_ch1"]);

                            //PointDataRow["order_a"] =dNewAccel_h.ToString();
                            //PointDataRow["order_h"] = dNewAccel_h.ToString();
                            //PointDataRow["order_v"] = dNewAccel_h.ToString();
                            //PointDataRow["order_ch1"] = dNewAccel_h.ToString();


                            hieRow["temperature"] = Convert.ToString(dr1["temperature"]);
                            hieRow["Time"] = Convert.ToString(dr1["Measure_time"]);
                            objOverAllReport.overallvalues1.PointRecordOverAll.Rows.Add(hieRow);
                            objOverAllReport.overallvalues1.PointRecordOverAll.AcceptChanges();
                        }
                    }
                }
                printControl1.PrintingSystem = objOverAllReport.PrintingSystem;
                objOverAllReport.CreateDocument();
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }

        private void oneoverallonegraph(string rp_name)
        {
            try
            {
                frmreportselection frmselection = new frmreportselection();
                frmselection.ShowDialog();
                
                string graphtypevalue = frmselection.GraphType;
                string overallvalue = frmselection.overalltype;
                GraphType = graphtypevalue;
                OverallType = overallvalue;
                newCreateSingleReportNew(GraphType, OverallType,rp_name);
            }
            catch { }
        }

        private void RouteTimeBasedReport()
        {
            try
            {
                StringBuilder sbDatabase = new StringBuilder();
                string sDataBase = null;
                ArrayList arlFacID = new ArrayList();
                string sFID = null;
                string sRID = null;
                string sEID = null;
                string sSID = null;
                string sPID = null;
                string sFIDR = null;
                string sRIDR = null;
                string sEIDR = null;
                string sSIDR = null;
                string sPIDR = null;
                ArrayList arrFid = null;
                ArrayList arrRid = null;
                ArrayList arrEid = null;
                ArrayList arrSid = null;
                ArrayList arrPid = null;
                ArrayList arlstCheck = new ArrayList();
                string pointName = null;
                string FName = null;
                string RName = null;
                string EName = null;
                string SEname = null;
                string check = null;
                string Direction = null;
                StringBuilder sbDirection = null;
                string sDtime = null;
                rptroute _RouteDerail = null;
                try
                {
                    _RouteDerail = new rptroute();
                    _RouteDerail.lblTitle.Text = PublicClass.ReportName;
                    DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                    try
                    {
                        foreach (DataRow dr in dtcompimage.Rows)
                        {
                            string cname = Convert.ToString(dr["Company_Name"]).Trim();
                            _RouteDerail.xrLabel2.Text = cname;
                            string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                            clogo = clogo.Replace('-', '\\');
                            _RouteDerail.xrPictureBox1.Image = Image.FromFile(clogo);
                        }
                    }
                    catch { }

                    if (PublicClass.ReportName == "Route Time Based Report")
                    {
                        _RouteDerail.GroupHeader2.Visible = false;
                        _RouteDerail.Detail.Visible = false;
                    }

                    RouteDetail objfrmRoutedetail = new RouteDetail();
                    objfrmRoutedetail.ShowDialog();
                    splashScreenManager1.ShowWaitForm();
                    if (objfrmRoutedetail.IsOKClicked)
                    {
                        string sRouteName = objfrmRoutedetail.SelectedRoute;
                        sDtime = objfrmRoutedetail.SelectedTime;
                        DataRow PointDataRow1 = _RouteDerail.overallvalues1.RouteTable1.NewRow();
                        PointDataRow1["RouteName"] = sRouteName;
                        PointDataRow1["DownloadTime"] = sDtime;
                        _RouteDerail.overallvalues1.RouteTable1.Rows.Add(PointDataRow1);
                        _RouteDerail.overallvalues1.RouteTable1.AcceptChanges();
                    }
                }
                catch { }
                printControl1.PrintingSystem = _RouteDerail.PrintingSystem;
                _RouteDerail.CreateDocument();               
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }

        private void ReportasperKribhco2()
        {
            int inctr = 0;
            string Plantname = "";
            string Plantid = "";
            string MachineName = "";
            string AreaName = "";
            string Areaid = "";
            string TrainName = "";
            string Trainid = "";
            double dHz = 0;
            string Machine_ID = null;
            RptVibrationMeasurement rptvib = new RptVibrationMeasurement();
            rptvib.xrLabel2.Text = "VIBRATION MEASUREMENT REPORT";

            DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
            try
            {
                foreach (DataRow dr in dtcompimage.Rows)
                {
                    string cname = Convert.ToString(dr["Company_Name"]).Trim();
                    rptvib.xrLabel1.Text = cname;
                    string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                    clogo = clogo.Replace('-', '\\');
                    rptvib.xrPictureBox1.Image = Image.FromFile(clogo);
                }
            }
            catch { }
            try
            {
                frmHierrarchySelection MyReport = new frmHierrarchySelection();
                MyReport.ShowDialog();
                splashScreenManager1.ShowWaitForm();
                string[] SelectedMachineIDs = MyReport.Machine_id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string mID = Convert.ToString(SelectedMachineIDs[0]);
                GetDetail(mID, ref Plantname, ref Plantid, ref AreaName, ref Areaid, ref TrainName, ref Trainid, ref MachineName);
                DataTable dtmacid = new DataTable();
                dtmacid = DbClass.getdata(CommandType.Text, "select DateCreated,RPM_Driven,PulseRev from machine_info where machine_id='" + mID + "'");
                foreach (DataRow dr in dtmacid.Rows)
                {
                    DataRow Datarownew = rptvib.newKribhco1.DataTable1.NewRow();
                    Datarownew["MachineID"] = Convert.ToString(SelectedMachineIDs[0]);
                    Datarownew["Plant"] = Convert.ToString(Plantname);
                    Datarownew["Machine"] = Convert.ToString(MachineName);
                    Datarownew["DateofTesting"] = Convert.ToString(dr["DateCreated"]);
                    string rpm = Convert.ToString(dr["RPM_Driven"]);
                    if (rpm != "0")
                    {
                        dHz = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["RPM_Driven"]), "0")) / Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["PulseRev"]), "0"));
                    }
                    else
                    { dHz = 0; }
                    Datarownew["RPM1"] = dHz;
                    DataTable dtmac = new DataTable();
                    dtmac = DbClass.getdata(CommandType.Text, "select picture,description from machine_pic where machineid='" + mID + "'");
                    foreach (DataRow dr1 in dtmac.Rows)
                    {
                        try
                        {
                            string Mlogo = Convert.ToString(dr1["picture"]).Trim();
                            Mlogo = Mlogo.Replace('-', '\\');
                            rptvib.xrPictureBox2.Image = Image.FromFile(Mlogo);
                        }
                        catch { }
                    }
                    rptvib.newKribhco1.DataTable1.Rows.Add(Datarownew);
                    rptvib.newKribhco1.DataTable1.AcceptChanges();
                }
                for (int xx = 0; xx < SelectedMachineIDs.Length; xx++)
                {
                    string sselctedPID = null;
                    DataTable dtpointid = new DataTable();
                    dtpointid = DbClass.getdata(CommandType.Text, "Select * from point p left join machine_info m on m.machine_id=p.machine_id where m.machine_id= '" + SelectedMachineIDs[xx] + "' ");

                    foreach (DataRow dr in dtpointid.Rows)
                    {
                        sselctedPID += "'" + Convert.ToString(dr["point_id"]).Trim() + "',";
                    }
                    string newsssid = sselctedPID.Remove(sselctedPID.Length - 1);
                    DataTable dt1 = new DataTable();
                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id  where pa.point_id IN (" + newsssid + ") and pa.Measure_time between '"+PublicClass.StartingDate+"' and '"+PublicClass.EndDate+"'  group by data_id order by point_id");
                    foreach (DataRow dr in dt1.Rows)
                    {
                        string pointid = Convert.ToString(dr["point_id"]).Trim();
                        string data_id = Convert.ToString(dr["Data_ID"]).Trim();
                        DataTable dtpoint_data = new DataTable();
                        dtpoint_data = DbClass.getdata(CommandType.Text, "select point_name,vel_a,vel_h,vel_v,vel_ch1,displ_a,displ_h,displ_v,displ_ch1,ordertrace_Rpm,point_id,pa_x,pa_y,ph_x ,Ph_y,pv_x,pv_y,pch1_x,pch1_y from point_data where point_id='" + pointid + "' and Data_ID ='" + data_id + "'");
                        foreach (DataRow dr1 in dtpoint_data.Rows)
                        {
                            try
                            {
                                string A_X = Convert.ToString(dr1["pa_x"]);
                                string A_Y = Convert.ToString(dr1["pa_y"]);
                                string H_X = Convert.ToString(dr1["ph_x"]);
                                string H_Y = Convert.ToString(dr1["Ph_y"]);
                                string V_X = Convert.ToString(dr1["pv_x"]);
                                string V_Y = Convert.ToString(dr1["pv_y"]);
                                string CH1_X = Convert.ToString(dr1["pch1_x"]);
                                string CH1_Y = Convert.ToString(dr1["pch1_y"]);
                                string vel_a = Convert.ToString(dr1["vel_a"]);
                                string vel_h = Convert.ToString(dr1["vel_h"]);
                                string vel_v = Convert.ToString(dr1["vel_v"]);
                                string vel_ch1 = Convert.ToString(dr1["vel_ch1"]);
                                string displ_a = Convert.ToString(dr1["displ_a"]);
                                string displ_h = Convert.ToString(dr1["displ_h"]);
                                string displ_v = Convert.ToString(dr1["displ_v"]);
                                string displ_ch1 = Convert.ToString(dr1["displ_ch1"]);
                                string X_a = "0";
                                string y_a = "0";
                                string DFX_A = "0";
                                string DFY_A = "0";
                                string X_h = "0";
                                string y_h = "0";
                                string DFX_H = "0";
                                string DFY_H = "0";
                                string X_v = "0";
                                string y_v = "0";
                                string DFX_V = "0";
                                string DFY_V = "0";
                                string X_Ch1 = "0";
                                string y_Ch1 = "0";
                                string DFX_Ch1 = "0";
                                string DFY_Ch1 = "0";
                                int pos_a = 0;
                                int pos_h = 0;
                                int pos_v = 0;
                                int pos_ch1 = 0;

                                string AYRPM1 = null;
                                string HYRPM1 = null;
                                string VYRPM1 = null;
                                string CH1YRPM1 = null;

                                string AYRPM2 = null;
                                string HYRPM2 = null;
                                string VYRPM2 = null;
                                string CH1YRPM2 = null;

                                string AYRPM3 = null;
                                string HYRPM3 = null;
                                string VYRPM3 = null;
                                string CH1YRPM3 = null;

                                string[] strA_X = A_X.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                string[] strH_X = H_X.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                string[] strV_X = V_X.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                string[] strCH1_X = CH1_X.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                                string[] strA_Y = A_Y.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                string[] strH_Y = H_Y.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                string[] strV_Y = V_Y.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                string[] strCH1_Y = CH1_Y.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                                try
                                {
                                    try
                                    {
                                        for (int check = 0; check < strA_X.Length; check++)
                                        {
                                            if (Convert.ToDouble(strA_Y[check]) > Convert.ToDouble(y_a))
                                            {
                                                y_a = strA_Y[check];
                                                X_a = strA_X[check];
                                                pos_a = check;
                                            }
                                        }
                                    }
                                    catch
                                    { }
                                    try
                                    {
                                        for (int check = 0; check < strH_X.Length; check++)
                                        {
                                            if (Convert.ToDouble(strH_Y[check]) > Convert.ToDouble(y_h))
                                            {
                                                y_h = strH_Y[check];
                                                X_h = strH_X[check];
                                                pos_h = check;
                                            }
                                        }
                                    }
                                    catch
                                    { }
                                    try
                                    {
                                        for (int check = 0; check < strV_X.Length; check++)
                                        {
                                            if (Convert.ToDouble(strV_Y[check]) > Convert.ToDouble(y_v))
                                            {
                                                y_v = strV_Y[check];
                                                X_v = strV_X[check];
                                                pos_v = check;
                                            }
                                        }
                                    }
                                    catch { }
                                    try
                                    {
                                        for (int check = 0; check < strCH1_X.Length; check++)
                                        {
                                            if (Convert.ToDouble(strCH1_Y[check]) > Convert.ToDouble(y_a))
                                            {
                                                y_Ch1 = strCH1_Y[check];
                                                X_Ch1 = strCH1_X[check];
                                                pos_ch1 = check;
                                            }
                                        }
                                    }
                                    catch { }
                                }
                                catch { }
                                try
                                {
                                    if (strA_Y != null)
                                    {
                                        AYRPM1 = Math.Round(Convert.ToDouble(strA_Y[pos_a]), 2).ToString();
                                        AYRPM2 = Math.Round(Convert.ToDouble(strA_Y[pos_a * 2]), 2).ToString();
                                        AYRPM3 = Math.Round(Convert.ToDouble(strA_Y[pos_a * 3]), 2).ToString();
                                    }
                                }
                                catch
                                { }
                                try
                                {
                                    if (strH_Y.Length != 0)
                                    {
                                        HYRPM1 = Math.Round(Convert.ToDouble(strH_Y[pos_h]), 2).ToString();
                                        HYRPM2 = Math.Round(Convert.ToDouble(strH_Y[pos_h * 2]), 2).ToString();
                                        HYRPM3 = Math.Round(Convert.ToDouble(strH_Y[pos_h * 3]), 2).ToString();
                                    }
                                }
                                catch
                                { }
                                try
                                {
                                    if (strV_Y.Length != 0)
                                    {
                                        VYRPM1 = Math.Round(Convert.ToDouble(strV_Y[pos_v]), 2).ToString();
                                        VYRPM2 = Math.Round(Convert.ToDouble(strV_Y[pos_v * 2]), 2).ToString();
                                        VYRPM3 = Math.Round(Convert.ToDouble(strV_Y[pos_v * 3]), 2).ToString();
                                    }
                                }
                                catch
                                { }
                                try
                                {
                                    if (strCH1_Y.Length != 0)
                                    {
                                        CH1YRPM1 = Math.Round(Convert.ToDouble(strCH1_Y[pos_ch1]), 2).ToString();
                                        CH1YRPM2 = Math.Round(Convert.ToDouble(strCH1_Y[pos_ch1 * 2]), 2).ToString();
                                        CH1YRPM3 = Math.Round(Convert.ToDouble(strCH1_Y[pos_ch1 * 3]) * 60, 2).ToString();
                                    }
                                }
                                catch
                                { }

                                DataRow DatarowKribhco = rptvib.newKribhco1.KribhcoDatatable.NewRow();
                                DataTable dtPower = DbClass.getdata(CommandType.Text, "select u.power_unit_type from units u left join point p on p.pointtype_id=u.type_id where p.point_id='" + pointid + "'");
                                string EncryptedMeasureValue = dtPower.Rows[0]["power_unit_type"].ToString();
                                string DecryptedMeasureValue = EncryptedMeasureValue;
                                if (EncryptedMeasureValue == "2")
                                {
                                    DatarowKribhco["DFiAcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_a) * 60), 2);
                                    DatarowKribhco["DFiAcpm2"] = Math.Round(Convert.ToDouble((2 * Convert.ToDecimal(X_a) * 60)), 2);
                                    DatarowKribhco["DFiAcpm3"] = Math.Round(Convert.ToDouble((3 * Convert.ToDecimal(X_a) * 60)), 2);
                                    DatarowKribhco["DFiAmic1"] = Math.Round(Convert.ToDouble(AYRPM1), 2);
                                    DatarowKribhco["DFiAmic2"] = Math.Round(Convert.ToDouble(AYRPM2), 2);
                                    DatarowKribhco["DFiAmic3"] = Math.Round(Convert.ToDouble(AYRPM3), 2);

                                    DatarowKribhco["DFiHcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_h) * 60), 2);
                                    DatarowKribhco["DFiHcpm2"] = Math.Round(Convert.ToDouble((2 * Convert.ToDecimal(X_h) * 60)), 2);
                                    DatarowKribhco["DFiHcpm3"] = Math.Round(Convert.ToDouble((3 * Convert.ToDecimal(X_h) * 60)), 2);
                                    DatarowKribhco["DFiHmic1"] = Math.Round(Convert.ToDouble(HYRPM1), 2);
                                    DatarowKribhco["DFiHmic2"] = Math.Round(Convert.ToDouble(HYRPM2), 2);
                                    DatarowKribhco["DFiHmic3"] = Math.Round(Convert.ToDouble(HYRPM3), 2);

                                    DatarowKribhco["DFiVcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_v) * 60), 2);
                                    DatarowKribhco["DFiVcpm2"] = Math.Round(Convert.ToDouble((2 * Convert.ToDecimal(X_v) * 60)), 2);
                                    DatarowKribhco["DFiVcpm3"] = Math.Round(Convert.ToDouble((3 * Convert.ToDecimal(X_v) * 60)), 2);
                                    DatarowKribhco["DFiVmic1"] = Math.Round(Convert.ToDouble(VYRPM1), 2);
                                    DatarowKribhco["DFiVmic2"] = Math.Round(Convert.ToDouble(VYRPM2), 2);
                                    DatarowKribhco["DFiVmic3"] = Math.Round(Convert.ToDouble(VYRPM3), 2);

                                    DatarowKribhco["DFiCH1cpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_Ch1) * 60), 2);
                                    DatarowKribhco["DFiCH1cpm2"] = Math.Round(Convert.ToDouble((2 * Convert.ToDecimal(X_Ch1) * 60)), 2);
                                    DatarowKribhco["DFiCH1cpm3"] = Math.Round(Convert.ToDouble((3 * Convert.ToDecimal(X_Ch1) * 60)), 2);
                                    DatarowKribhco["DFiCH1mic1"] = Math.Round(Convert.ToDouble(CH1YRPM1), 2);
                                    DatarowKribhco["DFiCH1mic2"] = Math.Round(Convert.ToDouble(CH1YRPM2), 2);
                                    DatarowKribhco["DFiCH1mic3"] = Math.Round(Convert.ToDouble(CH1YRPM3), 2);
                                    
                                    DatarowKribhco["DFoAcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_a) * 60), 2);
                                    DatarowKribhco["DFoHcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_h) * 60), 2);
                                    DatarowKribhco["DFoVcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_v) * 60), 2);
                                    DatarowKribhco["DFoCH1cpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_Ch1) * 60), 2);
                                    DatarowKribhco["DFoAmic1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(displ_a)), 2);
                                    DatarowKribhco["DFoHmic1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(displ_h)), 2);
                                    DatarowKribhco["DFoVmic1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(displ_v)), 2);
                                    DatarowKribhco["DFoCH1mic1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(displ_ch1)), 2);

                                    DatarowKribhco["VFoAcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_a) * 60), 2);
                                    DatarowKribhco["VFoHcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_h) * 60), 2);
                                    DatarowKribhco["VFoVcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_v) * 60), 2);
                                    DatarowKribhco["VFoCH1cpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_Ch1) * 60), 2);
                                    DatarowKribhco["VFoAmps1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(vel_a)), 2);
                                    DatarowKribhco["VFoHmps1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(vel_h)), 2);
                                    DatarowKribhco["VFoVmps1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(vel_v)), 2);
                                    DatarowKribhco["VFoCH1mps1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(vel_ch1)), 2);

                                    DatarowKribhco["machine_id"] = Convert.ToString(SelectedMachineIDs[0]);

                                }
                                else if (EncryptedMeasureValue == "1")
                                {
                                    DatarowKribhco["VFiAcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_a) * 60), 2);
                                    DatarowKribhco["VFiAcpm2"] = Math.Round(Convert.ToDouble((2 * Convert.ToDecimal(X_a) * 60)), 2);
                                    DatarowKribhco["VFiAcpm3"] = Math.Round(Convert.ToDouble((3 * Convert.ToDecimal(X_a) * 60)), 2);
                                    DatarowKribhco["VFiAmps1"] = Math.Round(Convert.ToDouble(AYRPM1), 2);
                                    DatarowKribhco["VFiAmps2"] = Math.Round(Convert.ToDouble(AYRPM2), 2);
                                    DatarowKribhco["VFiAmps3"] = Math.Round(Convert.ToDouble(AYRPM3), 2);

                                    DatarowKribhco["VFiHcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_h) * 60), 2);
                                    DatarowKribhco["VFiHcpm2"] = Math.Round(Convert.ToDouble((2 * Convert.ToDecimal(X_h) * 60)), 2);
                                    DatarowKribhco["VFiHcpm3"] = Math.Round(Convert.ToDouble((3 * Convert.ToDecimal(X_h) * 60)), 2);
                                    DatarowKribhco["VFiHmps1"] = Math.Round(Convert.ToDouble(HYRPM1), 2);
                                    DatarowKribhco["VFiHmps2"] = Math.Round(Convert.ToDouble(HYRPM2), 2);
                                    DatarowKribhco["VFiHmps3"] = Math.Round(Convert.ToDouble(HYRPM3), 2);

                                    DatarowKribhco["VFiVcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_v) * 60), 2);
                                    DatarowKribhco["VFiVcpm2"] = Math.Round(Convert.ToDouble((2 * Convert.ToDecimal(X_v) * 60)), 2);
                                    DatarowKribhco["VFiVcpm3"] = Math.Round(Convert.ToDouble((3 * Convert.ToDecimal(X_v) * 60)), 2);
                                    DatarowKribhco["VFiVmps1"] = Math.Round(Convert.ToDouble(VYRPM1), 2);
                                    DatarowKribhco["VFiVmps2"] = Math.Round(Convert.ToDouble(VYRPM2), 2);
                                    DatarowKribhco["VFiVmps3"] = Math.Round(Convert.ToDouble(VYRPM3), 2);

                                    DatarowKribhco["VFiCH1cpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_Ch1) * 60), 2);
                                    DatarowKribhco["VFiCH1cpm2"] = Math.Round(Convert.ToDouble((2 * Convert.ToDecimal(X_Ch1) * 60)), 2);
                                    DatarowKribhco["VFiCH1cpm3"] = Math.Round(Convert.ToDouble((3 * Convert.ToDecimal(X_Ch1) * 60)), 2);
                                    DatarowKribhco["VFiCH1mps1"] = Math.Round(Convert.ToDouble(CH1YRPM1), 2);
                                    DatarowKribhco["VFiCH1mps2"] = Math.Round(Convert.ToDouble(CH1YRPM2), 2);
                                    DatarowKribhco["VFiCH1mps3"] = Math.Round(Convert.ToDouble(CH1YRPM3), 2);

                                    DatarowKribhco["VFoAcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_a) * 60), 2);
                                    DatarowKribhco["VFoHcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_h) * 60), 2);
                                    DatarowKribhco["VFoVcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_v) * 60), 2);
                                    DatarowKribhco["VFoCH1cpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_Ch1) * 60), 2);
                                    DatarowKribhco["VFoAmps1"] = Math.Round(Convert.ToDouble(vel_a), 2);
                                    DatarowKribhco["VFoHmps1"] = Math.Round(Convert.ToDouble(vel_h), 2);
                                    DatarowKribhco["VFoVmps1"] = Math.Round(Convert.ToDouble(vel_v), 2);
                                    DatarowKribhco["VFoCH1mps1"] = Math.Round(Convert.ToDouble(vel_ch1), 2);

                                    DatarowKribhco["DFoAcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_a) * 60), 2);
                                    DatarowKribhco["DFoHcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_h) * 60), 2);
                                    DatarowKribhco["DFoVcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_v) * 60), 2);
                                    DatarowKribhco["DFoCH1cpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_Ch1) * 60), 2);
                                    DatarowKribhco["DFoAmic1"] = Math.Round(Convert.ToDouble(displ_a), 2);
                                    DatarowKribhco["DFoHmic1"] = Math.Round(Convert.ToDouble(displ_h), 2);
                                    DatarowKribhco["DFoVmic1"] = Math.Round(Convert.ToDouble(displ_v), 2);
                                    DatarowKribhco["DFoCH1mic1"] = Math.Round(Convert.ToDouble(displ_ch1), 2);
                                    DatarowKribhco["machine_id"] = Convert.ToString(SelectedMachineIDs[0]);
                                }
                                else
                                {
                                    DatarowKribhco["VFoAcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_a) * 60),2);
                                    DatarowKribhco["VFoHcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_h) * 60),2);
                                    DatarowKribhco["VFoVcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_v) * 60),2);
                                    DatarowKribhco["VFoCH1cpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_Ch1) * 60),2);
                                    DatarowKribhco["VFoAmps1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(vel_a)),2);
                                    DatarowKribhco["VFoHmps1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(vel_h)),2);
                                    DatarowKribhco["VFoVmps1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(vel_v)),2);
                                    DatarowKribhco["VFoCH1mps1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(vel_ch1)), 2);

                                    DatarowKribhco["DFoAcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_a) * 60),2);
                                    DatarowKribhco["DFoHcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_h) * 60),2);
                                    DatarowKribhco["DFoVcpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_v) * 60), 2);
                                    DatarowKribhco["DFoCH1cpm1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(X_Ch1) * 60),2);
                                    DatarowKribhco["DFoAmic1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(displ_a)),2);
                                    DatarowKribhco["DFoHmic1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(displ_h)),2);
                                    DatarowKribhco["DFoVmic1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(displ_v)),2);
                                    DatarowKribhco["DFoCH1mic1"] = Math.Round(Convert.ToDouble(Convert.ToDecimal(displ_ch1)), 2);
                                    DatarowKribhco["machine_id"] = Convert.ToString(SelectedMachineIDs[0]);
                                }
                                DatarowKribhco["pickup_position"] = pointid;
                                DatarowKribhco["PointName"] = dr1["point_name"];
                                rptvib.newKribhco1.KribhcoDatatable.Rows.Add(DatarowKribhco);
                                rptvib.newKribhco1.KribhcoDatatable.AcceptChanges();

                            }
                            catch { }


                        }
                    }

                }

            }
            catch { }
            printControl1.PrintingSystem = rptvib.PrintingSystem;
            rptvib.CreateDocument();
            splashScreenManager1.CloseWaitForm();
        }

        private void Generalnavy()
        {
            try
            {
                string sCommandText = null;
                ArrayList sarrTime = new ArrayList();
                string sTime = null;
                string Machine_ID = null;
                string[] SelectedMachineIDs = null;
                string Overall = null;
                int inctr = 0;
                frmreportselection frmselection = new frmreportselection();
                frmselection.ShowDialog();
                string overallvalue = frmselection.overalltype;
                if (Convert.ToString(overallvalue).Trim() == "")
                {
                    return;
                }
                NavGeneralReport rptGNav = new NavGeneralReport();
                rptGNav.xrLabel2.Text = "Navy General Report";
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        rptGNav.xrLabel1.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        rptGNav.xrPictureBox1.Image = Image.FromFile(clogo);
                    }
                }
                catch { }
                //start// 
                string[] sarrOverall = overallvalue.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                Overall = sarrOverall[0];
                frmHierrarchySelection MyReport = new frmHierrarchySelection();
                MyReport.ShowDialog();
                splashScreenManager1.ShowWaitForm();
                SelectedMachineIDs = MyReport.Machine_id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                for (int xx = 0; xx < SelectedMachineIDs.Length; xx++)
                {
                    string sselctedPID = null;
                    DataTable dtpointid = new DataTable();
                    dtpointid = DbClass.getdata(CommandType.Text, "Select * from point p left join machine_info m on m.machine_id=p.machine_id where m.machine_id= '" + SelectedMachineIDs[xx] + "' ");

                    foreach (DataRow dr in dtpointid.Rows)
                    {
                        sselctedPID += "'" + Convert.ToString(dr["point_id"]).Trim() + "',";
                    }
                    string newsssid = sselctedPID.Remove(sselctedPID.Length - 1);
                    DataTable dt1 = new DataTable();
                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct Max(pa.Data_ID),max(pa.Measure_time) as Measure_time FROM point_data  pa inner join point p on pa.point_id=p.point_id where pa.point_id IN (" + newsssid + ")  and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "' group by pa.point_id");
                    foreach (DataRow dr in dt1.Rows)
                    {
                        sTime = Convert.ToDateTime(dr["Measure_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                        sarrTime.Add(sTime);
                    }
                    int iArrayCount = sarrTime.Count;
                    if (Overall == "Acceleration")
                    {
                        sCommandText = CValues.SCNSTQDT23 + "Measure_Time='" + sarrTime[0];
                        for (int j = 1; j < iArrayCount; j++)
                        {
                            sCommandText += "'|| Measure_Time='" + sarrTime[j];
                        }
                        sCommandText += "'";
                    }
                    if (Overall == "Velocity")
                    {
                        sCommandText = CValues.SCNSTQDT24 + "Measure_Time='" + sarrTime[0];
                        for (int j = 1; j < iArrayCount; j++)
                        {
                            sCommandText += "'|| Measure_Time='" + sarrTime[j];
                        }
                        sCommandText += "'";
                    }
                    if (Overall == "Displacement")
                    {
                        sCommandText = CValues.SCNSTQDT25 + "Measure_Time='" + sarrTime[0];
                        for (int j = 1; j < iArrayCount; j++)
                        {
                            sCommandText += "'|| Measure_Time='" + sarrTime[j];
                        }
                        sCommandText += "'";
                    }
                    if (Overall == "Bearing")
                    {
                        sCommandText = CValues.SCNSTQDT26 + "Measure_Time='" + sarrTime[0];
                        for (int j = 1; j < iArrayCount; j++)
                        {
                            sCommandText += "'|| Measure_Time='" + sarrTime[j];
                        }
                        sCommandText += "'";
                    }
                    DataTable dt = DbClass.getdata(CommandType.Text, sCommandText);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow hieRow = rptGNav.overallvalues1.GenNavyDatatable.NewRow();
                        hieRow["pt_1"] = Math.Round(Convert.ToDecimal(Convert.ToString(dt.Rows[0]["overall"])), 2);                        
                        hieRow["pt_2"] = Math.Round(Convert.ToDecimal(Convert.ToString(dt.Rows[1]["overall"])), 2);
                        try
                        {
                            hieRow["pt_3"] = Math.Round(Convert.ToDecimal(Convert.ToString(dt.Rows[2]["overall"])), 2);
                            hieRow["pt_4"] = Math.Round(Convert.ToDecimal(Convert.ToString(dt.Rows[3]["overall"])), 2);
                            hieRow["pt_5"] = Math.Round(Convert.ToDecimal(Convert.ToString(dt.Rows[4]["overall"])), 2);
                            hieRow["pt_6"] = Math.Round(Convert.ToDecimal(Convert.ToString(dt.Rows[5]["overall"])), 2);
                            hieRow["pt_7"] = Math.Round(Convert.ToDecimal(Convert.ToString(dt.Rows[6]["overall"])), 2);
                            hieRow["pt_8"] = Math.Round(Convert.ToDecimal(Convert.ToString(dt.Rows[7]["overall"])), 2);
                            hieRow["pt_9"] = Math.Round(Convert.ToDecimal(Convert.ToString(dt.Rows[8]["overall"])), 2);
                            hieRow["pt_10"] = Math.Round(Convert.ToDecimal(Convert.ToString(dt.Rows[9]["overall"])), 2);
                        }
                        catch { }
                        hieRow["Fac_name"] = Convert.ToString(dt.Rows[0]["factoryname"]);
                        hieRow["machine_name"] = Convert.ToString(dt.Rows[0]["machinename"]);
                        //hieRow["measure_time"] = Convert.ToString(dr1["vel_v"]);
                        //hieRow["MDBMFE"] = Convert.ToString(dr1["displ_a"]);
                        //hieRow["MDBCFE"] = Convert.ToString(dr1["displ_h"]);
                        //hieRow["MDELTAFE"] = Convert.ToString(dr1["displ_v"]);
                        //hieRow["MCOLORFE"] = Convert.ToString(dr1["bearing_a"]);
                        //hieRow["MDBMDE"] = Convert.ToString(dr1["bearing_h"]);
                        //hieRow["MDBCDE"] = Convert.ToString(dr1["bearing_v"]);
                        //hieRow["MDELTADE"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["MCOLORDE"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["PDBMFE"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["PDBCFE"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["PDELTAFE"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["PCOLORFE"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["PDBMDE"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["PDBCDE"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["PDELTADE"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["PCOLORDE"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["RUN_HRS"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["GOOD"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["SAT"] = Convert.ToString(dr1["temperature"]);
                        //hieRow["BAD"] = Convert.ToString(dr1["temperature"]);
                       
                        rptGNav.overallvalues1.GenNavyDatatable.Rows.Add(hieRow);
                        rptGNav.overallvalues1.GenNavyDatatable.AcceptChanges();
                    }
                }                
                printControl1.PrintingSystem = rptGNav.PrintingSystem;
                rptGNav.CreateDocument();               
            }
            catch
            {
            }
            splashScreenManager1.CloseWaitForm();
        }

        private void PointwithAlarms(string rp_name)
        {
            try
            {
                string Machine_ID = null;
                string[] SelectedMachineIDs = null;
                RptAlarms rptalarm = new RptAlarms();
                rptalarm.lblTitle.Text = rp_name;
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    rptalarm.xrTable2.Visible = true;
                    rptalarm.xrTable1.Visible = true;                   
                }
                else
                {
                    rptalarm.xrTable5.Visible = true;
                    rptalarm.xrTable6.Visible = true;                            
                }


                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        rptalarm.xrLabel2.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        rptalarm.xrPictureBox1.Image = Image.FromFile(clogo);
                    }
                }
                catch { }

                if (PublicClass.ReportName == "Points with Alarms")
                {
                    DataTable dtPoint = DbClass.getdata(CommandType.Text, "SELECT f.Factory_ID as 'FactoryID',a.Area_ID as 'Area_ID' ,t.Train_ID as 'TrainID', m.Machine_ID as 'MachineID'  FROM machine_info m left join train_info t on m.TrainID = t.Train_ID left join area_info a on a.Area_ID=t.Area_ID left join factory_info f on f.Factory_ID=a.FactoryID");
                    foreach (DataRow dr in dtPoint.Rows)
                    {
                        Machine_ID += Convert.ToString(dr["MachineID"]) + ",";
                    }
                    SelectedMachineIDs = Machine_ID.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    frmHierrarchySelection MyReport = new frmHierrarchySelection();
                    MyReport.ShowDialog();
                    splashScreenManager1.ShowWaitForm();
                    SelectedMachineIDs = MyReport.Machine_id.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                }
                for (int xx = 0; xx < SelectedMachineIDs.Length; xx++)
                {
                    string sselctedPID = null;
                    DataTable dtpointid = new DataTable();
                    dtpointid = DbClass.getdata(CommandType.Text, "Select * from point p left join machine_info m on m.machine_id=p.machine_id where m.machine_id= '" + SelectedMachineIDs[xx] + "' ");

                    foreach (DataRow dr in dtpointid.Rows)
                    {
                        sselctedPID += "'" + Convert.ToString(dr["point_id"]).Trim() + "',";
                    }

                    string newsssid = sselctedPID.Remove(sselctedPID.Length - 1);

                    DataTable dt1 = new DataTable();

                    dt1 = DbClass.getdata(CommandType.Text, "SELECT distinct  pa.Data_ID,pa.vel_a,pa.vel_h,pa.vel_v,pa.vel_ch1,pa.displ_a,pa.displ_h,pa.displ_v,pa.displ_ch1,pa.ordertrace_Rpm,pa.point_id,Max(pa.Data_ID),p.pointname  FROM point_data  pa inner join point p on pa.point_id=p.point_id  where pa.point_id IN (" + newsssid + ") and Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'  group by data_id order by point_id");

                    foreach (DataRow dr in dt1.Rows)
                    {
                        string pointid = Convert.ToString(dr["point_id"]).Trim();
                        string data_id = Convert.ToString(dr["Data_ID"]).Trim();
                        DataTable dtpoint_data = new DataTable();
                        dtpoint_data = DbClass.getdata(CommandType.Text, "select alar.alarm_name,alar.Alarm_ID,fac.name as fname,area.name as areaname,tra.name as tname,mac.name as macname,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.displ_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.bearing_ch1,pd.temperature from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + pointid + "' and pd.Data_ID='" + data_id + "'");
                        foreach (DataRow dr1 in dtpoint_data.Rows)
                        {
                            DataRow hieRow = rptalarm.alarmdata1.AlarmData.NewRow();
                            hieRow["Alarm_Name"] = Convert.ToString(dr1["alarm_name"]);
                            hieRow["Factory_Name"] = Convert.ToString(dr1["fname"]);
                            hieRow["Resource_Name"] = Convert.ToString(dr1["areaname"]);
                            hieRow["Element_Name"] = Convert.ToString(dr1["tname"]);
                            hieRow["Sub_Element_Name"] = Convert.ToString(dr1["macname"]);
                            hieRow["pointname"] = Convert.ToString(dr1["pname"]);
                            hieRow["point_id"] = pointid;
                            hieRow["accel_a"] = Convert.ToString(dr1["accel_a"]);
                            hieRow["accel_h"] = Convert.ToString(dr1["accel_h"]);
                            hieRow["accel_v"] = Convert.ToString(dr1["accel_v"]);
                            hieRow["accel_ch1"] = Convert.ToString(dr1["accel_ch1"]);
                            hieRow["vel_a"] = Convert.ToString(dr1["vel_a"]);
                            hieRow["vel_h"] = Convert.ToString(dr1["vel_h"]);
                            hieRow["vel_v"] = Convert.ToString(dr1["vel_v"]);
                            hieRow["vel_ch1"] = Convert.ToString(dr1["vel_ch1"]);
                            hieRow["displ_a"] = Convert.ToString(dr1["displ_a"]);
                            hieRow["displ_h"] = Convert.ToString(dr1["displ_h"]);
                            hieRow["displ_v"] = Convert.ToString(dr1["displ_v"]);
                            hieRow["displ_ch1"] = Convert.ToString(dr1["displ_ch1"]);
                            hieRow["bearing_a"] = Convert.ToString(dr1["bearing_a"]);
                            hieRow["bearing_h"] = Convert.ToString(dr1["bearing_h"]);
                            hieRow["bearing_v"] = Convert.ToString(dr1["bearing_v"]);
                            hieRow["bearing_ch1"] = Convert.ToString(dr1["bearing_ch1"]);
                            hieRow["temp"] = Convert.ToString(dr1["temperature"]);
                            string alarmID = Convert.ToString(dr1["Alarm_ID"]);
                            string alarmName = Convert.ToString(dr1["alarm_name"]);

                            rptalarm.alarmdata1.AlarmData.Rows.Add(hieRow);
                            rptalarm.alarmdata1.AlarmData.AcceptChanges();
                        }
                    }
                }
                printControl1.PrintingSystem = rptalarm.PrintingSystem;
                rptalarm.CreateDocument();
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }
        
        public int[] chkAlarmForAllLevel(string pointID, string axiaValue, string HorValue, string VerValue, string ch1Value, string tempVal, string AlarmID, int ValFor)
        {
            int[] alrmCoun = new int[5];
            try
            {
                double faccel_a1 = 0;
                double faccel_h1 = 0;
                double faccel_v1 = 0;
                double faccel_a2 = 0;
                double faccel_h2 = 0;
                double faccel_v2 = 0;
                double faccel_ch11 = 0;
                double faccel_ch12 = 0;

                DataTable dtAlarm = DbClass.getdata(CommandType.StoredProcedure, "select * from alarms_data where Alarm_ID ='" + AlarmID + "'");
                foreach (DataRow dr in dtAlarm.Rows)
                {
                    try
                    {
                        if (ValFor == 0)
                        {
                            faccel_a1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_a1"]), "0"));
                            faccel_a2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_a2"]), "0"));
                            faccel_v1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_v1"]), "0"));
                            faccel_v2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_v2"]), "0"));
                            faccel_h1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_h1"]), "0"));
                            faccel_h2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_h2"]), "0"));
                            faccel_ch11 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_ch11"]), "0"));
                            faccel_ch12 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["accel_ch12"]), "0"));
                        }
                        else if (ValFor == 1)
                        {
                            faccel_a1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_a1"]), "0"));
                            faccel_a2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_a2"]), "0"));
                            faccel_v1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_v1"]), "0"));
                            faccel_v2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_v2"]), "0"));
                            faccel_h1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_h1"]), "0"));
                            faccel_h2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_h2"]), "0"));
                            faccel_ch11 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_ch11"]), "0"));
                            faccel_ch12 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["vel_ch12"]), "0"));
                        }
                        else if (ValFor == 2)
                        {
                            faccel_a1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_a1"]), "0"));
                            faccel_a2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_a2"]), "0"));
                            faccel_v1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_v1"]), "0"));
                            faccel_v2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_v2"]), "0"));
                            faccel_h1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_h1"]), "0"));
                            faccel_h2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_h2"]), "0"));
                            faccel_ch11 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_ch11"]), "0"));
                            faccel_ch12 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["displ_ch12"]), "0"));
                        }
                        else if (ValFor == 3)
                        {
                            faccel_a1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_a1"]), "0"));
                            faccel_a2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_a2"]), "0"));
                            faccel_v1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_v1"]), "0"));
                            faccel_v2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_v2"]), "0"));
                            faccel_h1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_h1"]), "0"));
                            faccel_h2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_h2"]), "0"));
                            faccel_ch11 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_ch11"]), "0"));
                            faccel_ch12 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["bearing_ch12"]), "0"));
                        }
                        else if (ValFor == 4)
                        {
                            faccel_a1 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["temperature_1"]), "0"));
                            faccel_a2 = Convert.ToDouble(PublicClass.DefVal(Convert.ToString(dr["temperature_2"]), "0"));
                        }
                    }
                    catch
                    {

                    }
                }

                if (faccel_a1 != 0 || faccel_v1 != 0 || faccel_h1 != 0 || faccel_ch11 != 0)
                {

                    //----------------Axial Direction----------------------------------------------------------//

                    if (Convert.ToDouble(axiaValue) > faccel_a1)
                    {
                        alrmCoun[0] = 2;
                    }
                    else if (Convert.ToDouble(axiaValue) > faccel_a2)
                    {
                        alrmCoun[0] = 1;
                    }
                    else if (Convert.ToDouble(axiaValue) < faccel_a2)
                    {
                        alrmCoun[0] = 0;
                    }
                    //----------------Vertical Direction----------------------------------------------------------//

                    if (Convert.ToDouble(VerValue) > faccel_v1)
                    {
                        alrmCoun[1] = 2;
                    }
                    else if (Convert.ToDouble(VerValue) > faccel_v2)
                    {
                        alrmCoun[1] = 1;
                    }
                    else if (Convert.ToDouble(VerValue) < faccel_v2)
                    {
                        alrmCoun[1] = 0;
                    }

                    //----------------Horizontal Direction----------------------------------------------------------//

                    if (Convert.ToDouble(HorValue) > faccel_h1)
                    {
                        alrmCoun[2] = 2;
                    }
                    else if (Convert.ToDouble(HorValue) > faccel_h2)
                    {
                        alrmCoun[2] = 1;
                    }
                    else if (Convert.ToDouble(HorValue) < faccel_h2)
                    {
                        alrmCoun[2] = 0;
                    }

                    //----------------Channel1 Direction----------------------------------------------------------//

                    if (Convert.ToDouble(ch1Value) > faccel_ch11)
                    {
                        alrmCoun[3] = 2;
                    }
                    else if (Convert.ToDouble(ch1Value) > faccel_ch12)
                    {
                        alrmCoun[3] = 1;
                    }
                    else if (Convert.ToDouble(ch1Value) < faccel_ch12)
                    {
                        alrmCoun[3] = 0;
                    }
                    //---------------------------Temprature----------------------------------------------------------//

                    if (Convert.ToDouble(tempVal) > faccel_a1)
                    {
                        alrmCoun[4] = 2;
                    }
                    else if (Convert.ToDouble(tempVal) > faccel_a2)
                    {
                        alrmCoun[4] = 1;
                    }
                    else if (Convert.ToDouble(tempVal) < faccel_a2)
                    {
                        alrmCoun[4] = 0;
                    }


                }
            }
            catch { }
            return alrmCoun;
        }
       
        private void AllRouteReport()
        {
            try
            {
                rptroute _route = new rptroute();
                splashScreenManager1.ShowWaitForm();
                _route.lblTitle.Text = PublicClass.ReportName;
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        _route.xrLabel2.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        _route.xrPictureBox1.Image = Image.FromFile(clogo);
                    }
                }
                catch { }
            }
            catch { }
            splashScreenManager1.CloseWaitForm();
        }

       
        private void pointnotes()
        {
            try
            {
                int inctr = 0;
                RptNotes rptnote = new RptNotes();
                rptnote.xrLabel2.Text = "Point Notes Report";
                splashScreenManager1.ShowWaitForm();
                DataTable dtcompimage = DbClass.getdata(CommandType.Text, "SELECT * FROM comp_image");
                try
                {
                    foreach (DataRow dr in dtcompimage.Rows)
                    {
                        string cname = Convert.ToString(dr["Company_Name"]).Trim();
                        rptnote.xrLabel1.Text = cname;
                        string clogo = Convert.ToString(dr["Company_logoimage"]).Trim();
                        clogo = clogo.Replace('-', '\\');
                        rptnote.xrPictureBox1.Image = Image.FromFile(clogo);
                    }
                }
                catch { }

                DataTable dtpoint_data = new DataTable();
                dtpoint_data = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id and pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "' order by p.point_id");

                foreach (DataRow dr in dtpoint_data.Rows)
                {
                    DataRow hieRow = rptnote.multiData1.PointrecordNotes.NewRow();
                    dataID = Convert.ToString(dr["Data_ID"]);
                    PublicClass.Data_ID = dataID;
                    ptID = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                    string Machine_id = Convert.ToString(Convert.ToString(dr["Machine_ID"]).Trim());
                    string Plantname = "";
                    string Plantid = "";
                    string MachineName = "";
                    string AreaName = "";
                    string Areaid = "";
                    string TrainName = "";
                    string Trainid = "";

                    GetDetail(Machine_id, ref Plantname, ref Plantid, ref AreaName, ref Areaid, ref TrainName, ref Trainid, ref MachineName);
                    hieRow["FactoryName"] = Plantname.Trim();
                    hieRow["ResourceName"] = AreaName.Trim();
                    hieRow["ElementName"] = TrainName.Trim();
                    hieRow["SuElementName"] = MachineName.Trim();
                    hieRow["PointName"] = Convert.ToString(Convert.ToString(dr["pointname"]).Trim());
                    hieRow["PointID"] = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());
                    string sPointID = Convert.ToString(Convert.ToString(dr["point_id"]).Trim());

                    DataTable dt = DbClass.getdata(CommandType.Text, "select note.notes_desc as Notes1, note2.Note as Notes2 from point_data pd inner join notes note on note.notes_id=pd.notes1 left join point_note2 note2 on note2.note_id=pd.notes2 where pd.point_id='" + sPointID + "' and pd.Data_ID='" + PublicClass.Data_ID + "'");
                    hieRow["Note1"] = null;
                    hieRow["Note2"] = null;
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        hieRow["Note1"] = Convert.ToString(dr1["Notes1"]);
                        hieRow["Note2"] = Convert.ToString(dr1["Notes2"]);
                    }
                    if (hieRow["Note1"] == "")
                    { hieRow["Note1"] = "-"; }
                    if (hieRow["Note2"] == "")
                    { hieRow["Note2"] = "-"; }

                    rptnote.multiData1.PointrecordNotes.Rows.Add(hieRow);
                    rptnote.multiData1.PointrecordNotes.AcceptChanges();
                }
                printControl1.PrintingSystem = rptnote.PrintingSystem;
                rptnote.CreateDocument();                
            }
            catch{ }
            splashScreenManager1.CloseWaitForm();
        }

        private void enddate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string strdtt = Convert.ToString(strdate.Text);
                if(strdtt != "")
                {
                    DateTime strdt = Convert.ToDateTime(strdate.Text);
                    DateTime enddt = Convert.ToDateTime(enddate.Text);

                    TimeSpan ts = enddt.Subtract(strdt);
                    double i = ts.TotalHours;
                    double k = ts.TotalMinutes;
                    lbReportingList.Enabled = true;
                    if(k < 0)
                    {
                        MessageBox.Show(this, "End date Not Correct", "VibAnalyst@Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                       
                        return;
                    }
                }
                else
                {
                }
            }
            catch { }
        }

        private void lbReportingList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                DateTime strdt = Convert.ToDateTime(strdate.Text);
                DateTime enddt = Convert.ToDateTime(enddate.Text);
                TimeSpan ts = enddt.Subtract(strdt);
                double i = ts.TotalHours;
                double k = ts.TotalMinutes;
                if (k >= 0)
                {
                    PublicClass.StartingDate = strdt.ToString("yyyy-MM-dd HH:mm:ss");
                    PublicClass.EndDate = enddt.ToString("yyyy-MM-dd 23:59:59");
                    Set_Report_data(Convert.ToString(lbReportingList.SelectedValue).Trim());
                }
                else
                {
                    if (k < 0)
                    {
                        MessageBox.Show(this, "Start date Not Correct", "VibAnalyst@Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (k > 0)
                    {
                        MessageBox.Show(this, "End date Not Correct", "VibAnalyst@Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
       

        private void frmReport_Load(object sender, EventArgs e)
        {
            try
            {
                FillReportList();
                enddate.DateTime = DateTime.Now;
                strdate.DateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day).AddMonths(-1);
            }
            catch { }
        }

        private DataTable CheckForData()
        {
            DataTable dataDT = new DataTable();
            try
            {
                dataDT = DbClass.getdata(CommandType.Text, "SELECT  distinct pa.Data_ID as Data_ID, p.pointname,p.point_id ,P.Machine_ID,pa.Measure_time as Measure_time  FROM  point_data  pa inner join point p on pa.point_id=p.point_id where pa.Measure_time between '" + PublicClass.StartingDate + "' and '" + PublicClass.EndDate + "'order by p.point_id");
            }
            catch
            {
            }
            return dataDT;
        }     
    }
}