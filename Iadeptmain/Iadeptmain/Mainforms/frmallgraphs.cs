using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevComponents.DotNetBar;
using Iadeptmain.Classes;
using Iadeptmain.BaseUserControl;
using Iadeptmain.GlobalClasses;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using com.iAM.chart2dnet;
using ClassesStructs;
using System.IO;

namespace Iadeptmain.Mainforms
{
    public partial class PointGeneral1 : DevExpress.XtraEditors.XtraForm
    {
        frmgraphcontrol m_objGraphControl = null;
        frmIAdeptMain m_main = null;
        MCW m_objMainControlWork = null;
        ImpaqHandler m_objImpaqHandler = null;
        public GraphView m_objGraphView = null;
        IadeptUserControl m_usercontrol = null;

        public PointGeneral1()
        {
            InitializeComponent();
            activateobjects1();

        }

        public void activateobjects1()
        {
            m_objMainControlWork = new MCW();
            m_objMainControlWork.Main = this;
            m_objGraphControl = new frmgraphcontrol();
            m_objGraphControl.pg1 = this;
            m_objGraphControl.uc3D = new uc3DGraphControl();

        }

        public frmgraphcontrol pg3
        {
            get { return m_objGraphControl; }
            set { m_objGraphControl = value; }

        }

        public IadeptUserControl usercontrol
        {
            get
            {
                return m_usercontrol;
            }
            set
            {
                m_usercontrol = value;
            }
        }

        public GraphView grp
        {
            get
            {
                return m_objGraphView;
            }
            set
            {
                m_objGraphView = value;
            }

        }

        public MCW MainForm
        {
            get
            {
                return m_objMainControlWork;
            }

            set
            {
                m_objMainControlWork = value;

            }

        }

        public frmIAdeptMain MainForm1
        {
            get
            {
                return m_main;
            }
            set
            {
                m_main = value;
            }
        }

        string XUnit = null;
        string YUnit = null;
        public string _XUnit
        {
            get
            {
                return XUnit;
            }
            set
            {
                XUnit = value;
            }
        }
        public string _YUnit
        {
            get
            {
                return YUnit;
            }
            set
            {
                YUnit = value;
            }
        }
        bool bReporting = false;
        public bool Reporting
        {
            get
            {
                return bReporting;
            }
            set
            {
                bReporting = value;
            }
        }
        string m_sPointDirection = null;
        public string PointDirection
        {
            get
            {
                return m_sPointDirection;
            }
            set
            {
                m_sPointDirection = value;
            }

        }

        private bool bAxial = false;

        public bool Axial
        {
            set
            {
                bAxial = value;
            }
        }
        private string m_sUnirs = null;
        public string Units
        {
            get
            {
                return m_sUnirs;
            }
            set
            {
                m_sUnirs = value;
            }
        }
        bool bOverall = false;
        public bool OverallTrend
        {
            get
            {
                return bOverall;
            }
            set
            {
                bOverall = value;
            }
        }
        private bool bSetTime = false;
        public bool SetTypeForTime
        {
            get
            {
                return bSetTime;
            }
            set
            {
                bSetTime = value;
            }

        }
        string sYAxis = null;
        public string YAxisValue
        {
            get
            {
                return sYAxis;
            }
            set
            {
                sYAxis = value;
            }
        }
        public ArrayList sarrTime = null;

        public ArrayList Timedata
        {
            get
            {
                return sarrTime;
            }
            set
            {
                sarrTime = value;
            }
        }

        string sGraphname = null;
        public string Graphname
        {
            get
            {
                return sGraphname;
            }
            set
            {
                sGraphname = value;
            }
        }
        int iDataTaken = 0;

        public int NoofDataTaken
        {
            get
            {
                return iDataTaken;
            }
            set
            {
                iDataTaken = value;
            }
        }
        bool bBtnCopyValue = false;
        public bool CopyValueButton
        {
            get
            {
                return bBtnCopyValue;
            }
            set
            {
                bBtnCopyValue = value;
            }
        }
        string ReportPointID = null;
        public string CurrentReportPoint
        {
            get
            {
                return ReportPointID;
            }
            set
            {
                ReportPointID = value;
            }
        }

        public void CreateGraph(ArrayList arrlstData, ArrayList arlstDateTime, ArrayList arlstCounter)
        {
            try
            {

                if (bReporting == false)
                {

                    m_objGraphControl.Dock = DockStyle.Fill;
                }

                if (arrlstData != null)
                {
                    m_objGraphControl.DateTime = m_sDateTime;

                    m_objGraphControl.DisableZoomButton = bZoom;
                    if (bSetTime)
                        m_objGraphControl.SetTypeTime = bSetTime;
                    else
                        m_objGraphControl.SetTypeTime = false; ;

                    if (bAxial == true)
                        m_objGraphControl.Axial = true;
                    else
                        m_objGraphControl.Axial = false;

                    if (bOverall)
                    {
                        m_objGraphControl.IfOverallTrend = true;
                        m_objGraphControl.setYAxisValue = sYAxis;
                        m_objGraphControl.Timedata1 = sarrTime;
                        m_objGraphControl.NoOfDataTaken = iDataTaken;
                    }
                    else
                    {
                        m_objGraphControl.IfOverallTrend = false;
                    }
                    m_objGraphControl.Units = m_sUnirs;
                    m_objGraphControl.CurrentReportPoint = CurrentReportPoint;
                    m_objGraphControl.IfOverallTrend = OverallTrend;
                    m_objGraphControl.IsAxisComboBox = IsAxisCombo;

                    m_objGraphControl.CheckFocusedNodeChange = "InitializeChart";
                    m_objGraphControl.Graphname = Graphname;
                    m_objGraphControl.InitializeGraph(arrlstData, arlstDateTime, arlstCounter);

                }
                bReporting = false;

            }
            catch (Exception ex)
            {
            }
        }

        public void CallClearDataGrid()
        {
            try
            {
                m_objGraphControl.ClearDataGrid();
            }
            catch (Exception ex)
            {
            }
        }

        bool bAxisCombo = false;
        public bool IsAxisCombo
        {
            get
            {
                return bAxisCombo;
            }
            set
            {
                bAxisCombo = value;
            }
        }

        bool bZoom = false;
        string Inss = PublicClass.currentInstrument;
        private string m_sDateTime = null;
        public void CreateGraph(double[] dXValues, double[] dYValues, string DateTime, int ixCtr, string pnl)
        {
            try
            {
                if (bReporting == false)
                {
                    m_objGraphControl.Dock = DockStyle.Fill;
                }
                if (dXValues != null && dYValues != null)
                {
                    m_objGraphControl.DateTime = m_sDateTime;
                    if (Inss == "DI 460")
                    {
                    }
                    else
                        m_objGraphControl.DisableZoomButton = bZoom;
                    if (bSetTime)
                        m_objGraphControl.SetTypeTime = bSetTime;
                    else
                        m_objGraphControl.SetTypeTime = false; ;

                    if (bAxial == true)
                        m_objGraphControl.Axial = true;
                    else
                        m_objGraphControl.Axial = false;
                    m_objGraphControl.Units = m_sUnirs;
                    if (bOverall)
                    {
                        m_objGraphControl.IfOverallTrend = true;
                        m_objGraphControl.setYAxisValue = sYAxis;
                        m_objGraphControl.Timedata1 = sarrTime;
                        m_objGraphControl.NoOfDataTaken = iDataTaken;
                    }
                    else
                    {
                        m_objGraphControl.IfOverallTrend = false;
                    }
                    m_objGraphControl.CheckFocusedNodeChange = "InitializeChart";
                    m_objGraphControl.Graphname = PublicClass.graphname;
                    m_objGraphControl.InitializeGraph(dXValues, dYValues, DateTime, ixCtr, pnl);
                    if (bReporting == false)
                    {
                    }
                    bReporting = false;
                }

            }
            catch { }
        }

        string sReportingPoint = null;

        public string ReportingPoint
        {
            get
            {
                return sReportingPoint;
            }
            set
            {
                sReportingPoint = value;
            }
        }

        public string _DisplacementUnit
        {
            get
            {
                return displ_unit + "(" + displ_detection + ")";
            }
        }

        string OverallTrendUnit = "AccTrend";
        string displ_unit = null;
        string displ_detection = null;
        public string getUnitValuesforgraph(string sGraphnametodraw)
        {
            string accel_unit = null;
            string vel_unit = null;
            string temprature_unit = null;
            string process_unit = null;
            string accel_detection = null;
            string vel_detection = null;

            string pressure_unit = null;
            string current_unit = null;
            string pressure_detection = null;
            string current_detection = null;
            string ordertrace_unit_type = null;
            string sPointID = PublicClass.SPointID;
            string Units = null;
            string stype = null;

            try
            {
                if (sPointID != null)
                {
                    DataTable dt = new DataTable();
                    dt = DbClass.getdata(CommandType.Text, "Select PointType_ID from Point where Point_ID='" + sPointID + "'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        stype = Convert.ToString(dr["PointType_ID"]);
                    }
                    DataTable dt2 = new DataTable();
                    dt2 = DbClass.getdata(CommandType.Text, "select * from units where Type_ID=(select id from type_point where id='" + stype + "')");
                    // dt2 = DbClass.getdata(CommandType.Text, "select * from units where Type_ID='" + stype + "'");

                    foreach (DataRow dr in dt2.Rows)
                    {
                        accel_unit = Convert.ToString(dr["accel_unit"]);
                        vel_unit = Convert.ToString(dr["vel_unit"]);
                        displ_unit = Convert.ToString(dr["displ_unit"]);
                        pressure_unit = Convert.ToString(dr["pressure_unit"]);
                        current_unit = Convert.ToString(dr["current_unit"]);
                        temprature_unit = Convert.ToString(dr["temperature_unit"]);

                        process_unit = Convert.ToString(dr["process_unit"]);
                        accel_detection = Convert.ToString(dr["accel_detection"]);
                        vel_detection = Convert.ToString(dr["vel_detection"]);
                        displ_detection = Convert.ToString(dr["displ_detection"]);
                        pressure_detection = Convert.ToString(dr["pressure_detection"]);
                        current_detection = Convert.ToString(dr["current_detection"]);

                        time_unit_type = Convert.ToString(dr["time_unit_type"]);
                        power_unit_type = Convert.ToString(dr["power_unit_type"]);
                        demodulate_unit_type = Convert.ToString(dr["demodulate_unit_type"]);
                        ordertrace_unit_type = Convert.ToString(dr["ordertrace_unit_type"]);
                        cepstrum_unit_type = Convert.ToString(dr["cepstrum_unit_type"]);

                    }

                    string overall_bearing_filter = null;
                    DataTable dt3 = DbClass.getdata(CommandType.Text, "Select * from measure where Type_ID='" + stype + "'");

                    foreach (DataRow dr1 in dt3.Rows)
                    {
                        overall_bearing_filter = Convert.ToString(dr1["overall_bearing_filter"]);
                    }

                    if (accel_unit == "0")
                    {
                        accel_unit = "Gs";
                    }
                    else if (accel_unit == "1")
                    {
                        accel_unit = "Gal";
                    }
                    else if (accel_unit == "2")
                    {
                        accel_unit = "m/s2";
                    }


                    if (vel_unit == "0")
                    {
                        vel_unit = "mm/s";
                    }
                    else if (vel_unit == "1")
                    {
                        vel_unit = "in/s";
                    }
                    else if (vel_unit == "2")
                    {
                        vel_unit = "cm/s";
                    }


                    if (displ_unit == "0")
                    {
                        displ_unit = "mil";
                    }
                    else if (displ_unit == "1")
                    {
                        displ_unit = "um";
                    }

                    if (pressure_unit == "0")
                    {
                        pressure_unit = "Pa";
                    }
                    else if (pressure_unit == "1")
                    {
                        pressure_unit = "bar";
                    }



                    if (current_unit == "0")
                    {
                        current_unit = "mA";
                    }



                    if (accel_detection == "0")
                    {
                        accel_detection = "RMS";
                    }
                    else if (accel_detection == "1")
                    {
                        accel_detection = "Peak";
                    }
                    else if (accel_detection == "2")
                    {
                        accel_detection = "P-P";
                    }
                    else if (accel_detection == "3")
                    {
                        accel_detection = "True-PK";
                    }


                    if (vel_detection == "0")
                    {
                        vel_detection = "RMS";
                    }
                    else if (vel_detection == "1")
                    {
                        vel_detection = "Peak";
                    }
                    else if (vel_detection == "2")
                    {
                        vel_detection = "P-P";
                    }
                    else if (vel_detection == "3")
                    {
                        vel_detection = "True-PK";
                    }



                    if (displ_detection == "0")
                    {
                        displ_detection = "RMS";
                    }
                    else if (displ_detection == "1")
                    {
                        displ_detection = "Peak";
                    }
                    else if (displ_detection == "2")
                    {
                        displ_detection = "P-P";
                    }
                    else if (displ_detection == "3")
                    {
                        displ_detection = "True-PK";
                    }

                    if (current_detection == "0")
                    {
                        current_detection = "RMS";
                    }
                    else if (current_detection == "1")
                    {
                        current_detection = "Peak";
                    }
                    else if (current_detection == "2")
                    {
                        current_detection = "P-P";
                    }
                    else if (current_detection == "3")
                    {
                        current_detection = "True PK";
                    }



                    if (pressure_detection == "0")
                    {
                        pressure_detection = "RMS";
                    }
                    else if (pressure_detection == "1")
                    {
                        pressure_detection = "Peak";
                    }
                    else if (pressure_detection == "2")
                    {
                        pressure_detection = "P-P";
                    }
                    else if (pressure_detection == "3")
                    {
                        pressure_detection = "True PK";
                    }




                    if (sGraphnametodraw == "Time")
                    {
                        if (time_unit_type == "0")
                        {
                            Units = accel_unit + "(" + accel_detection + ")";
                        }
                        else if (time_unit_type == "1")
                        {
                            Units = vel_unit + "(" + vel_detection + ")";
                        }
                        else if (time_unit_type == "2")
                        {
                            Units = displ_unit + "(" + displ_detection + ")";
                        }
                        else if (time_unit_type == "3")
                        {
                            Units = pressure_unit + "(" + pressure_detection + ")";
                        }
                        else if (time_unit_type == "4")
                        {
                            Units = current_unit + "(" + current_detection + ")";
                        }
                    }
                    else if (sGraphnametodraw == "Power" || sGraphnametodraw == "Power1" || sGraphnametodraw == "Power2" || sGraphnametodraw == "Power21" || sGraphnametodraw == "Power3" || sGraphnametodraw == "Power31")
                    {
                        if (power_unit_type == "0")
                        {
                            Units = accel_unit + "(" + accel_detection + ")";
                        }
                        else if (power_unit_type == "1")
                        {
                            Units = vel_unit + "(" + vel_detection + ")";
                        }
                        else if (power_unit_type == "2")
                        {
                            Units = displ_unit + "(" + displ_detection + ")";
                        }
                        else if (power_unit_type == "3")
                        {
                            Units = pressure_unit + "(" + pressure_detection + ")";
                        }
                        else if (power_unit_type == "4")
                        {
                            Units = current_unit + "(" + current_detection + ")";
                        }
                    }
                    else if (sGraphnametodraw == "Demodulate")
                    {
                        if (demodulate_unit_type == "0")
                        {
                            Units = accel_unit + "(" + accel_detection + ")";
                        }
                        else if (demodulate_unit_type == "1")
                        {
                            Units = vel_unit + "(" + vel_detection + ")";
                        }
                        else if (demodulate_unit_type == "2")
                        {
                            Units = displ_unit + "(" + displ_detection + ")";
                        }
                        else if (demodulate_unit_type == "3")
                        {
                            Units = pressure_unit + "(" + pressure_detection + ")";
                        }
                        else if (demodulate_unit_type == "4")
                        {
                            Units = current_unit + "(" + current_detection + ")";
                        }
                    }
                    else if (sGraphnametodraw == "Cepstrum")
                    {
                        if (cepstrum_unit_type == "0")
                        {
                            Units = accel_unit + "(" + accel_detection + ")";
                        }
                        else if (cepstrum_unit_type == "1")
                        {
                            Units = vel_unit + "(" + vel_detection + ")";
                        }
                        else if (cepstrum_unit_type == "2")
                        {
                            Units = displ_unit + "(" + displ_detection + ")";
                        }
                        else if (cepstrum_unit_type == "3")
                        {
                            Units = pressure_unit + "(" + pressure_detection + ")";
                        }
                        else if (cepstrum_unit_type == "4")
                        {
                            Units = current_unit + "(" + current_detection + ")";
                        }
                    }


                    else if (sGraphnametodraw.Contains("Trend"))
                    {
                        if (OverallTrendUnit.Contains("Acc"))
                        {
                            Units = accel_unit + "(" + accel_detection + ")";
                        }
                        else if (OverallTrendUnit.Contains("Vel"))
                        {
                            Units = vel_unit + "(" + vel_detection + ")";
                        }
                        else if (OverallTrendUnit.Contains("Disp"))
                        {
                            Units = displ_unit + "(" + displ_detection + ")";
                        }
                        else if (OverallTrendUnit.Contains("Bear"))
                        {
                            if (overall_bearing_filter == "0")
                            {
                                Units = accel_unit + "HP(" + accel_detection + ")";
                            }
                            else if (overall_bearing_filter == "1")
                            {
                                Units = vel_unit + "HP(" + vel_detection + ")";
                            }
                            else if (overall_bearing_filter == "2")
                            {
                                Units = accel_unit + "Env(" + accel_detection + ")";
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
            }
            return Units;
        }
        public string GetImpaqOverall()
        {
            return GetImpaqOverall(PublicClass.GraphClicked);
        }

        public string getUnitValuesC911()
        {
            string Units = null;
            try
            {
                if (PublicClass.checkparent == "Acc")
                {
                    Units = "Hz,m/s2";
                }
                else if (PublicClass.checkparent == "Vel")
                {
                    Units = "Hz,mm/s";
                }
                else
                { Units = "Hz,um"; }
            }
            catch { }
            return Units;
        }

        private string m_sFocusedNodeChange = null;
        bool bmara = false;
        public bool _Mara
        {
            get
            {
                return bmara;
            }

        }

        public void RemoveChartObjects()
        {
            try
            {
                if (m_objGraphControl != null)
                {
                    m_objGraphControl.RemoveChartObjects();
                    if (m_objGraphControl._Mara)
                    {
                        bmara = true;
                    }
                    else
                    {
                        bmara = false;
                    }
                    m_objGraphControl.LabelTime = "Date and Time";
                    if (m_sFocusedNodeChange == "FocusedNodeChange")
                    {
                        m_objGraphControl.CheckFocusedNodeChange = m_sFocusedNodeChange;
                    }
                    if (bmara == false)
                    {
                        m_objGraphControl.ClearData();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        string ChartFooter = null;
        string ChartHeader = null;
        public string _ChartFooter
        {
            get
            {
                return ChartFooter;
            }
            set
            {
                ChartFooter = value;
            }
        }
        public string _ChartHeader
        {
            get
            {
                return ChartHeader;
            }
            set
            {
                ChartHeader = value;
            }
        }
        string time_unit_type = null;
        string power_unit_type = null;
        string demodulate_unit_type = null;
        string cepstrum_unit_type = null;
        private string GetImpaqOverall(string sGraphnametodraw)
        {
            string overallcolumn = null; string overallcolumn1 = null;
            string overalltoshow = null;
            if (PublicClass.currentInstrument == "SKF/DI")
            {
                DataTable dt2 = DbClass.getdata(CommandType.Text, " select di.channeltype,di.Type_Unit from point pt inner join type_point tp on tp.ID=pt.PointType_ID left join di_point di on di.type_id=tp.ID where pt.Point_ID='" + PublicClass.SPointID + "'");
                if (dt2.Rows.Count > 0)
                {
                    string unit_type = Convert.ToString(dt2.Rows[0]["Type_Unit"]);
                    if (unit_type == "0" || unit_type == "23")
                    {
                        time_unit_type = "0"; power_unit_type = "0";
                    }
                    else if (unit_type == "1" || unit_type == "2" || unit_type == "5" || unit_type == "6" || unit_type == "24" || unit_type == "25")
                    {
                        time_unit_type = "1"; power_unit_type = "1";
                    }
                    else
                    {
                        time_unit_type = "2"; power_unit_type = "2";
                    }
                }
            }
            else if (PublicClass.currentInstrument == "Kohtect-C911")
            {
                DataTable dt2 = DbClass.getdata(CommandType.Text, "select distinct di.Channel1,di.Channel2,di.SelectRadio1,di.SelectRadio2,alar.alarm_name,fac.name as fname,area.name as areaname,tra.name as tname,mac.name as macname,pd.Measure_time as Measuredate,pt.pointname as pname,pd.accel_a,pd.accel_h,pd.accel_v,pd.accel_ch1,pd.vel_a,pd.vel_h,pd.vel_v,pd.vel_ch1,pd.displ_ch1,pd.displ_a,pd.displ_h,pd.displ_v,pd.bearing_ch1,pd.bearing_a,pd.bearing_h,pd.bearing_v,pd.temperature,pd.crest_factor_a,pd.crest_factor_h,pd.crest_factor_v,pd.crest_factor_ch1 from point_data pd inner join point pt on pt.point_id=pd.point_id left join type_point tp on tp.id=pt.pointtype_id left join c911_measurement di on di.Type_ID=tp.ID left join alarms_data alar on alar.alarm_id=tp.alarm_id left join machine_info mac on mac.machine_id=pt.machine_id left join train_info tra on tra.train_id=mac.trainid left join area_info area on area.area_id=tra.area_id left join factory_info fac on fac.factory_id=area.factoryid where pd.Point_id='" + PublicClass.SPointID + "'");
                if (dt2.Rows.Count > 0)
                {
                    string chl1 = Convert.ToString(dt2.Rows[0]["Channel1"]);
                    string chl2 = Convert.ToString(dt2.Rows[0]["Channel2"]);
                    string dir1 = Convert.ToString(dt2.Rows[0]["SelectRadio1"]);
                    string dir2 = Convert.ToString(dt2.Rows[0]["SelectRadio2"]);
                    if (chl1 == "0" || chl1 == "1" || chl1 == "2")
                    {
                        if (dir1 == "0")
                        { overallcolumn1 = "accel_h"; }
                        else if (dir1 == "1")
                        { overallcolumn1 = "vel_h"; }
                        else if (dir1 == "2")
                        { overallcolumn1 = "displ_h"; }                       
                    }
                    else
                    {
                        if (dir2 == "0")
                        { overallcolumn1 = "accel_v"; }
                        else if (dir2 == "1")
                        { overallcolumn1 = "vel_v"; }
                        else if (dir2 == "2")
                        { overallcolumn1 = "displ_v"; }                      
                    }
                }
            }           
            switch (sGraphnametodraw)
            {
                case "Time":
                    {
                        switch (time_unit_type)
                        {
                            case "0":
                                {
                                    overallcolumn = "accel_";
                                    break;
                                }
                            case "1":
                                {
                                    overallcolumn = "vel_";
                                    break;
                                }
                            case "2":
                                {
                                    overallcolumn = "displ_";
                                    break;
                                }
                        }
                        break;
                    }
                case "Power":
                    {
                        switch (power_unit_type)
                        {
                            case "0":
                                {
                                    overallcolumn = "accel_";
                                    break;
                                }
                            case "1":
                                {
                                    overallcolumn = "vel_";
                                    break;
                                }
                            case "2":
                                {
                                    overallcolumn = "displ_";
                                    break;
                                }

                        }
                        break;
                    }
                case "Demodulate":
                    {
                        switch (demodulate_unit_type)
                        {
                            case "0":
                                {
                                    overallcolumn = "accel_";
                                    break;
                                }
                            case "1":
                                {
                                    overallcolumn = "vel_";
                                    break;
                                }
                            case "2":
                                {
                                    overallcolumn = "displ_";
                                    break;
                                }
                        }
                        break;
                    }
                case "Cepstrum":
                    {
                        switch (cepstrum_unit_type)
                        {
                            case "0":
                                {
                                    overallcolumn = "accel_";
                                    break;
                                }
                            case "1":
                                {
                                    overallcolumn = "vel_";
                                    break;
                                }
                            case "2":
                                {
                                    overallcolumn = "displ_";
                                    break;
                                }
                        }
                        break;
                    }
                default:
                    {
                        switch (power_unit_type)
                        {
                            case "0":
                                {
                                    overallcolumn = "accel_";
                                    break;
                                }
                            case "1":
                                {
                                    overallcolumn = "vel_";
                                    break;
                                }
                            case "2":
                                {
                                    overallcolumn = "displ_";
                                    break;
                                }
                        }
                        break;
                    }
            }
            switch (m_main.EdittextDirection)
            {
                case "Axial":
                    {
                        overallcolumn += "a";
                        break;
                    }
                case "Horizontal":
                    {
                        overallcolumn += "h";
                        break;
                    }
                case "Vertical":
                    {
                        overallcolumn += "v";
                        break;
                    }
                case "Channel1":
                    {
                        overallcolumn += "ch1";
                        break;
                    }
            }

            string sPointID = PublicClass.SPointID;
            DataTable dt = new DataTable();
            if(PublicClass.currentInstrument=="Kohtect-C911")
            { overallcolumn = overallcolumn1; }
            dt = DbClass.getdata(CommandType.Text, "Select " + overallcolumn + " from point_data where Point_ID='" + sPointID + "' and measure_time='" + PublicClass.tym + "' ");
            foreach (DataRow dr in dt.Rows)
            {
                overalltoshow = Convert.ToString(dr[overallcolumn]);
                break;
            }
            return overalltoshow;
        }

        bool bExTop = true;
        bool bExBottom = true;
        bool bExMiddle = true;
        bool bExTopLeft = true;
        bool bExBottomLeft = true;

        private void powergraphdispose()
        {
            try
            {
                if (pbpower != null)
                {
                    pbpower.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbpower1 != null)
                {
                    pbpower1.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbpower2 != null)
                {
                    pbpower2.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbpower2_1 != null)
                {
                    pbpower2_1.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbpower3 != null)
                {
                    pbpower3.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbpower3_1 != null)
                {
                    pbpower3_1.Image.Dispose();
                }
            }
            catch { }

        }

        private void deleteimage()
        {
            try
            {
                string path = Path.GetTempPath();
                if (File.Exists(path + "\\Trend.jpg"))
                {

                    System.IO.File.Delete(path + "\\Trend.jpg");
                    // File.Delete(path + "\\Trend.jpg");                     
                }
            }
            catch { }
        }

        private void allGraphDispose()
        {
            try
            {
                if (pbtime.Image != null)
                {
                    pbtime.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbpower != null)
                {
                    pbpower.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbpower1 != null)
                {
                    pbpower1.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbpower2 != null)
                {
                    pbpower2.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbpower2_1 != null)
                {
                    pbpower2_1.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbpower3 != null)
                {
                    pbpower3.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbpower3_1 != null)
                {
                    pbpower3_1.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbdemo != null)
                {
                    pbdemo.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbcep != null)
                {
                    pbcep.Image.Dispose();
                }
            }
            catch { }

            try
            {
                if (pbtrend.Image != null)
                {
                    pbtrend.Image.Dispose();
                }
            }
            catch { }
        }

        public ChartView chartVu; string timeval1 = "Time Graph channel2";
        string Powerval1 = "Power Graph channel2";
        string DemVal1 = "TWF To FFT Graph Channel2";
        string timeval = "Time Graph channel1";
        string PowerVal = "Power Graph channel1";
        string DemVal = "TWF To FFT Graph Channel1";
        double[] xarrayNew = new double[0];
        double[] yarrayNew = new double[0];
        string CurrentYLabel = null;
        public void ShowgraphsforDI()
        {
            try
            {
                string aa1 = null;
                CurrentYLabel = null;
                xtcTrend.Visible = false; tpPower1.PageVisible = false; tpPower2.PageVisible = false; tpPower3.PageVisible = false; tpPower4.PageVisible = false;
                tpPower5.PageVisible = false;
                m_objMainControlWork.TrendVal = "Trend Graph";
                m_objImpaqHandler = new ImpaqHandler();
                m_objMainControlWork._ImpaqHandler = m_objImpaqHandler;
                string aa = PublicClass.ssNodeType;

                DataTable dt = DbClass.getdata(CommandType.Text, " select di.channeltype from point pt inner join type_point tp on tp.ID=pt.PointType_ID left join di_point di on di.type_id=tp.ID where pt.Point_ID='" + PublicClass.SPointID + "'");
                if (dt.Rows.Count > 0)
                {
                    aa1 = Convert.ToString(dt.Rows[0]["channeltype"]);
                    if (aa1 == "3" || aa1 == "4")
                    {
                        tpTime1.PageVisible = true;
                    }
                    else { tpTime1.PageVisible = false; }
                }

                //Time//////////////////////////////
                PublicClass.checkgraph = false;
                try
                {
                    if (pbtime.Image != null)
                    {
                        pbtime.Image.Dispose();
                        pbtime.Image = null;
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Time");
                if (PublicClass.checkgraph == true)
                {
                    xarrayNew = PublicClass.darrXData;
                    yarrayNew = PublicClass.darrYData;
                    CurrentYLabel = PublicClass.y_Unit;
                    pbtime.Image = Image.FromFile(PublicClass.timeimage, true);
                    tpTime.Text = timeval + " (" + PublicClass.AHVCH1 + ")";
                    bExTop = true;
                }
                else
                {
                    bExTop = false;
                    tpTime.Text = timeval;
                    tpTime.Visible = false;
                }

                //power/////////////////////////////////////                    

                PublicClass.checkgraph = false;
                try
                {
                    if (pbpower.Image != null)
                    {
                        pbpower.Image.Dispose();
                        pbpower.Image = null;
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Power");
                if (PublicClass.checkgraph == true)
                {
                    pbpower.Image = Image.FromFile(PublicClass.powerimage);
                    tpPower.Text = PowerVal + "(" + PublicClass.AHVCH1 + ")";
                    bExTop = true;
                    tpPower.PageVisible = true;
                }
                else
                {
                    bExTop = false;
                    tpPower.Text = PowerVal;
                    tpPower.PageVisible = false;
                }


                //trend/////////////////////////////////////

                PublicClass.checkgraph = false;
                if (PublicClass.AHVCH1 == "Axial")
                {
                    PublicClass.Gtrend = "accel_a";
                }
                else if (PublicClass.AHVCH1 == "Horizontal")
                {
                    PublicClass.Gtrend = "accel_h";
                }
                else if (PublicClass.AHVCH1 == "Vertical")
                {
                    PublicClass.Gtrend = "accel_v";
                }
                else if (PublicClass.AHVCH1 == "Channel1")
                {
                    PublicClass.Gtrend = "accel_ch1";
                }
                try
                {
                    if (pbcep.Image != null)
                    {
                        pbcep.Image.Dispose();
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Trend");
                if (PublicClass.checkgraph == true)
                {

                    pbcep.Image = Image.FromFile(PublicClass.trendimage);
                    tpCepstrum.Text = m_objMainControlWork.TrendVal.ToString();
                    bExTop = true;
                }
                else
                {
                    bExTop = false;
                    tpCepstrum.Text = m_objMainControlWork.TrendVal.ToString();
                    tpCepstrum.Visible = false;
                }

                //demo/////////////////////////////////////////

                PublicClass.checkgraph = false;
                try
                {
                    if (pbdemo.Image != null)
                    {
                        pbdemo.Image.Dispose();
                    }
                }
                catch { }
                try
                {
                    LineGraphControl _LineGraph = new LineGraphControl();
                    double[] mag = m_main.fftMag(yarrayNew);
                    ConvertToFFT.TWFtoFFT _Convert = new ConvertToFFT.TWFtoFFT();
                    ArrayList NewValues = _Convert.ConvertTWFtoFFT(xarrayNew, yarrayNew, "Sec", CurrentYLabel);
                    if (NewValues != null)
                    {
                        xarrayNew = (double[])NewValues[0];
                        yarrayNew = (double[])NewValues[1];
                        CurrentYLabel = (string)NewValues[3];
                        m_main.DrawLineGraphsforDi(xarrayNew, yarrayNew, "Sec", CurrentYLabel);
                        chartVu = m_main._ChartViewDI;
                        BufferedImage objImage = new BufferedImage(chartVu);
                        string path = Path.GetTempPath();
                        try
                        {
                            if (File.Exists(path + @"TWFToFFT.jpg"))
                            {
                                File.Delete(path + @"TWFToFFT.jpg");
                            }
                            else
                            { }
                            objImage.SaveImage(path + @"TWFToFFT.jpg");
                            PublicClass.demoimage = path + @"TWFToFFT.jpg";
                        }
                        catch
                        { }
                    }
                }
                catch { }
                if (CurrentYLabel != null)
                {
                    pbdemo.Image = Image.FromFile(PublicClass.demoimage);
                    tpDemo.Text = DemVal + " (" + PublicClass.AHVCH1 + ")";
                    bExTop = true;
                }
                else
                {
                    bExTop = false;
                    tpDemo.Text = DemVal;
                    tpDemo.Visible = false;
                }

                if (aa1 == "3" || aa1 == "4")
                {
                    tpPower1.PageVisible = true;
                    //power channel2///////////
                    string firstdir = PublicClass.AHVCH1;
                    PublicClass.AHVCH1 = "Channel1";
                    PublicClass.checkgraph = false;
                    try
                    {
                        if (pbpower1.Image != null)
                        {
                            pbpower1.Image.Dispose();
                        }
                    }
                    catch { }
                    m_objMainControlWork.FirstClick(PublicClass.ssNodeType, "Power");
                    if (PublicClass.checkgraph == true)
                    {
                        //xarrayNew = PublicClass.darrXData;
                        //yarrayNew = PublicClass.darrYData;
                        //CurrentYLabel = PublicClass.y_Unit;
                        //chartVu = m_main._ChartViewDI;
                        pbpower1.Image = Image.FromFile(PublicClass.powerimage, true);
                        tpPower1.Text = Powerval1 + " (" + firstdir + ")";
                        bExTop = true;
                    }
                    else
                    {
                        bExTop = false;
                        tpPower1.Text = Powerval1;
                        tpPower1.Visible = false;
                    }
                    PublicClass.AHVCH1 = firstdir;
                }
            }
            catch { }
        }
        
        public void ShowgraphsC911()
        {
            try
            {
                xtcTrend.Visible = false; tpPower2.PageVisible = false; tpPower3.PageVisible = false; tpPower4.PageVisible = false;
                tpPower5.PageVisible = false; xtcDemodulate.Visible = false; xtcCepstrum.Visible = false;

                m_objImpaqHandler = new ImpaqHandler();
                m_objMainControlWork._ImpaqHandler = m_objImpaqHandler;
                string aa = PublicClass.ssNodeType;

                m_objMainControlWork.FirstClick(aa, "Power");
                if (PublicClass.checkgraph == true)
                {
                    pbpower.Image = Image.FromFile(PublicClass.powerimage);
                   // tpPower.Text = m_objMainControlWork.PowerVal.ToString();
                    tpPower.Text = PowerVal.ToString();
                    bExTop = true;
                    tpPower.PageVisible = true;
                }
                else
                {
                    bExTop = false;
                    tpPower.Text = PowerVal;
                    tpPower.PageVisible = false;
                }

                ///----------trend------------//
                PublicClass.checkgraph = false;
                if (PublicClass.AHVCH1 == "Axial")
                {
                    PublicClass.Gtrend = "accel_a";
                }
                else if (PublicClass.AHVCH1 == "Horizontal")
                {
                    PublicClass.Gtrend = "accel_h";
                }
                else if (PublicClass.AHVCH1 == "Vertical")
                {
                    PublicClass.Gtrend = "accel_v";
                }
                else if (PublicClass.AHVCH1 == "Channel1")
                {
                    PublicClass.Gtrend = "accel_ch1";
                }
                try
                {
                    if (pbtime.Image != null)
                    {
                        pbtime.Image.Dispose();
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Trend");
                if (PublicClass.checkgraph == true)
                {

                    pbtime.Image = Image.FromFile(PublicClass.trendimage);
                    tpTime.Text = m_objMainControlWork.TrendVal.ToString();
                    bExTop = true;
                }
                else
                {
                    bExTop = false;
                    tpTime.Text = m_objMainControlWork.TrendVal.ToString();
                    tpTime.Visible = false;
                }

            }
            catch { }
        }

        public void Showgraphs()
        {
            try
            {
                m_objMainControlWork.TimeVal = "Time Graph";
                m_objMainControlWork.PowerVal = "Power Graph";
                m_objMainControlWork.PowerVal1 = "Power Graph1";
                m_objMainControlWork.PowerVal2 = "Power Graph2";
                m_objMainControlWork.PowerVal3 = "Power2 Graph1";
                m_objMainControlWork.PowerVal4 = "Power Graph3";
                m_objMainControlWork.PowerVal5 = "Power3 Graph1";
                m_objMainControlWork.DemVal = "Demodulate Graph";
                m_objMainControlWork.TrendVal = "Trend Graph";
                m_objMainControlWork.CepVal = "Cepstrum Graph";
                m_objImpaqHandler = new ImpaqHandler();
                m_objMainControlWork._ImpaqHandler = m_objImpaqHandler;

                string aa = PublicClass.ssNodeType;

                //Time//////////////////////////////
                PublicClass.checkgraph = false;
                try
                {
                    if (pbtime.Image != null)
                    {
                        pbtime.Image.Dispose();
                        pbtime.Image = null;
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Time");
                if (PublicClass.checkgraph == true)
                {
                    pbtime.Image = Image.FromFile(PublicClass.timeimage, true);
                    tpTime.Text = m_objMainControlWork.TimeVal.ToString();
                    bExTop = true;
                }
                else
                {
                    bExTop = false;
                    tpTime.Text = m_objMainControlWork.TimeVal.ToString();
                    tpTime.Visible = false;
                }
                //power/////////////////////////////////////                    

                PublicClass.checkgraph = false;
                try
                {
                    if (pbpower.Image != null)
                    {
                        pbpower.Image.Dispose();
                        pbpower.Image = null;
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Power");
                if (PublicClass.checkgraph == true)
                {
                    pbpower.Image = Image.FromFile(PublicClass.powerimage);
                    tpPower.Text = m_objMainControlWork.PowerVal.ToString();
                    bExTop = true;
                    tpPower.PageVisible = true;
                }
                else
                {
                    bExTop = false;
                    tpPower.Text = m_objMainControlWork.PowerVal.ToString();
                    tpPower.PageVisible = false;
                }

                //power1/////////////////////////

                PublicClass.checkgraph = false;
                try
                {
                    if (pbpower1.Image != null)
                    {
                        pbpower1.Image.Dispose();
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Power1");
                if (PublicClass.checkgraph == true)
                {
                    pbpower1.Image = Image.FromFile(PublicClass.power1image);
                    tpPower1.Text = m_objMainControlWork.PowerVal1.ToString();
                    bExTop = true;
                    tpPower1.PageVisible = true;
                }
                else
                {
                    bExTop = false;
                    tpPower1.Text = m_objMainControlWork.PowerVal1.ToString();
                    tpPower1.PageVisible = false;
                }

                //power2/////////////////////////

                PublicClass.checkgraph = false;
                try
                {
                    if (pbpower2.Image != null)
                    {
                        pbpower2.Image.Dispose();
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Power2");
                if (PublicClass.checkgraph == true)
                {
                    pbpower2.Image = Image.FromFile(PublicClass.power2image);
                    tpPower2.Text = m_objMainControlWork.PowerVal2.ToString();
                    bExTop = true;
                    tpPower2.PageVisible = true;
                }
                else
                {
                    bExTop = false;
                    tpPower2.Text = m_objMainControlWork.PowerVal2.ToString();
                    tpPower2.PageVisible = false;
                }

                //power21//////////////////////

                PublicClass.checkgraph = false;
                try
                {
                    if (pbpower2_1.Image != null)
                    {
                        pbpower2_1.Image.Dispose();
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Power21");
                if (PublicClass.checkgraph == true)
                {
                    pbpower2_1.Image = Image.FromFile(PublicClass.power21image);
                    tpPower3.Text = m_objMainControlWork.PowerVal3.ToString();
                    bExTop = true;
                    tpPower3.PageVisible = true;
                }
                else
                {
                    bExTop = false;
                    tpPower3.Text = m_objMainControlWork.PowerVal3.ToString();
                    tpPower3.PageVisible = false;
                }

                //power3///////////////////////////////////////////////

                PublicClass.checkgraph = false;
                try
                {
                    if (pbpower3.Image != null)
                    {
                        pbpower3.Image.Dispose();
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Power3");
                if (PublicClass.checkgraph == true)
                {
                    pbpower3.Image = Image.FromFile(PublicClass.power3image);
                    tpPower4.Text = m_objMainControlWork.PowerVal4.ToString();
                    bExTop = true;
                    tpPower4.PageVisible = true;
                }
                else
                {
                    bExTop = false;
                    tpPower4.Text = m_objMainControlWork.PowerVal4.ToString();
                    tpPower4.PageVisible = false;
                }

                //power31/////////////////////////////////////////////////

                PublicClass.checkgraph = false;
                try
                {
                    if (pbpower3_1.Image != null)
                    {
                        pbpower3_1.Image.Dispose();
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Power31");
                if (PublicClass.checkgraph == true)
                {
                    pbpower3_1.Image = Image.FromFile(PublicClass.power31image);
                    tpPower5.Text = m_objMainControlWork.PowerVal5.ToString();
                    bExTop = true;
                    tpPower5.PageVisible = true;
                }
                else
                {
                    bExTop = false;
                    tpPower5.Text = m_objMainControlWork.PowerVal5.ToString();
                    tpPower5.PageVisible = false;
                }
                //demo/////////////////////////////////////////

                PublicClass.checkgraph = false;
                try
                {
                    if (pbdemo.Image != null)
                    {
                        pbdemo.Image.Dispose();
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Demodulate");
                if (PublicClass.checkgraph == true)
                {
                    pbdemo.Image = Image.FromFile(PublicClass.demoimage);
                    tpDemo.Text = m_objMainControlWork.DemVal.ToString();
                    bExTop = true;
                }
                else
                {
                    bExTop = false;
                    tpDemo.Text = m_objMainControlWork.DemVal.ToString();
                    tpDemo.Visible = false;
                }

                //trend/////////////////////////////////////

                PublicClass.checkgraph = false;
                if (PublicClass.AHVCH1 == "Axial")
                {
                    PublicClass.Gtrend = "accel_a";
                }
                else if (PublicClass.AHVCH1 == "Horizontal")
                {
                    PublicClass.Gtrend = "accel_h";
                }
                else if (PublicClass.AHVCH1 == "Vertical")
                {
                    PublicClass.Gtrend = "accel_v";
                }
                else if (PublicClass.AHVCH1 == "Channel1")
                {
                    PublicClass.Gtrend = "accel_ch1";
                }
                try
                {
                    if (pbtrend.Image != null)
                    {
                        pbtrend.Image.Dispose();
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Trend");
                if (PublicClass.checkgraph == true)
                {

                    pbtrend.Image = Image.FromFile(PublicClass.trendimage);
                    tpTrend.Text = m_objMainControlWork.TrendVal.ToString();
                    bExTop = true;
                }
                else
                {
                    bExTop = false;
                    tpTrend.Text = m_objMainControlWork.TrendVal.ToString();
                    tpTrend.Visible = false;
                }

                //Cepstrum/////////////////////////////////////

                PublicClass.checkgraph = false;
                try
                {
                    if (pbcep.Image != null)
                    {
                        pbcep.Image.Dispose();
                    }
                }
                catch { }
                m_objMainControlWork.FirstClick(aa, "Cepstrum");
                if (PublicClass.checkgraph == true)
                {
                    pbcep.Image = Image.FromFile(PublicClass.cepimage);
                    tpCepstrum.Text = m_objMainControlWork.CepVal.ToString();
                    bExTop = true;
                }
                else
                {
                    bExTop = false;
                    tpCepstrum.Text = m_objMainControlWork.CepVal.ToString();
                    tpCepstrum.Visible = false;
                }
            }
            catch { }
        }

        public string CurrentUnit = null; public string strCurrentUnit = null; public string MType = null;
        public string ExtractCurrentUnit()
        {
            try
            {
                DataTable dt = DbClass.getdata(CommandType.Text, "select * from di_point di inner join type_point tp on tp.ID=di.Type_ID left join point pt on tp.ID=pt.PointType_ID where pt.Point_ID='" + PublicClass.SPointID + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    CurrentUnit = Convert.ToString(dr["Type_Unit"]);
                    MType = Convert.ToString(dr["MeasureType"]);
                }
                if (CurrentUnit == "0")
                    strCurrentUnit = "G";
                else if (CurrentUnit == "1" || CurrentUnit == "5")
                    strCurrentUnit = "IPS";
                else if (CurrentUnit == "2" || CurrentUnit == "6")
                    strCurrentUnit = "mm/s";
                else if (CurrentUnit == "3" || CurrentUnit == "7" || CurrentUnit == "9")
                    strCurrentUnit = "Mils";
                else if (CurrentUnit == "4" || CurrentUnit == "8" || CurrentUnit == "10")
                    strCurrentUnit = "um";

                if (Convert.ToInt16(MType) == 0 || Convert.ToInt16(MType) == 1)
                    m_objGraphView.Units = "Hz," + strCurrentUnit;
                else if (Convert.ToInt16(MType) == 2 || Convert.ToInt16(MType) == 3)
                    m_objGraphView.Units = "Sec," + strCurrentUnit;
            }
            catch { }
            return m_objGraphView.Units;
        }

        public string getExtractCurrentUnit()
        {
            try
            {
                DataTable dt = DbClass.getdata(CommandType.Text, "select * from di_point di inner join type_point tp on tp.ID=di.Type_ID left join point pt on tp.ID=pt.PointType_ID where pt.Point_ID='" + PublicClass.SPointID + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    CurrentUnit = Convert.ToString(dr["Type_Unit"]);
                    MType = Convert.ToString(dr["MeasureType"]);
                }
                if (CurrentUnit == "0")
                    strCurrentUnit = "G";
                else if (CurrentUnit == "1" || CurrentUnit == "5")
                    strCurrentUnit = "IPS";
                else if (CurrentUnit == "2" || CurrentUnit == "6")
                    strCurrentUnit = "mm/s";
                else if (CurrentUnit == "3" || CurrentUnit == "7" || CurrentUnit == "9")
                    strCurrentUnit = "Mils";
                else if (CurrentUnit == "4" || CurrentUnit == "8" || CurrentUnit == "10")
                    strCurrentUnit = "um";

                if (Convert.ToInt16(MType) == 0 || Convert.ToInt16(MType) == 1)
                    Units = "Hz," + strCurrentUnit;
                else if (Convert.ToInt16(MType) == 2 || Convert.ToInt16(MType) == 3)
                    Units = "Sec," + strCurrentUnit;
            }
            catch { }
            return Units;
            //string[] SelectedunitIDs = Units.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            //_XUnit = SelectedunitIDs[0];
            //_YUnit = SelectedunitIDs[1];           
        }

        public string[] ExtractUnits()
        {
            string[] XYLabel = new string[2];
            try
            {
                string instname = PublicClass.currentInstrument;
                switch (instname)
                {
                    case "DI 460":
                        {
                            break;
                        }
                    case "FieldPaq2":
                    case "Impaq-Benstone":
                        {
                            _YUnit = getUnitValuesforgraph(PublicClass.GraphClicked);
                            switch (PublicClass.GraphClicked)
                            {
                                case "Time":
                                    {
                                        _XUnit = "Sec";
                                        break;
                                    }
                                case "Power":
                                    {
                                        _XUnit = "Hz";
                                        break;
                                    }
                                case "Demodulate":
                                    {
                                        _XUnit = "Hz";
                                        break;
                                    }
                                case "Cepstrum":
                                    {
                                        _XUnit = "Sec";
                                        break;
                                    }
                                case "Trend":
                                    {
                                        _XUnit = "Date and Time";
                                        break;
                                    }
                                default:
                                    {
                                        _XUnit = "Hz";
                                        break;
                                    }

                            }
                            break;
                        }
                }
                XYLabel[0] = _XUnit;
                XYLabel[1] = _YUnit;
            }
            catch (Exception ex)
            {
            }
            return XYLabel;
        }

        double[] darrXData = null;
        double[] darrYData = null;
        ArrayList arrXYData = null;

        ArrayList arrlstTime = null;
        public ArrayList DateTime
        {
            get
            {
                return arrlstTime;
            }
            set
            {
                arrlstTime = value;

            }
        }
        public double[] XData
        {
            get
            {
                return darrXData;
            }
            set
            {
                darrXData = value;
            }
        }
        public double[] YData
        {
            get
            {
                return darrYData;
            }
            set
            {
                darrYData = value;

            }
        }

        string sForUnit = null;
        public string ForUnit
        {
            get
            {
                return sForUnit;
            }
            set
            {
                sForUnit = value;
            }
        }
        string sOverallValue = null;
        public string _OverallValue
        {
            get
            {
                return sOverallValue;
            }
            set
            {
                sOverallValue = value;
            }
        }

        private double FindOverallVal(string Target)
        {
            double OverallVal = 0.0;
            int Ctr = 1;
            try
            {
                string[] XYVals = Target.Split(new string[] { "," }, StringSplitOptions.None);
                for (int i = 10; i < XYVals.Length; i++)
                {
                    string[] Val = XYVals[i].Split(new string[] { "|" }, StringSplitOptions.None);
                    double Xval = Convert.ToDouble(Val[0]);
                    double Yval = Convert.ToDouble(Val[1]);
                    if (OverallVal < Yval)
                        OverallVal = Yval;
                    Ctr++;
                }
            }
            catch { }
            return OverallVal;
        }

        string lastgraph; string lastDigraph; string zoom = null; string power_zoom = null;
        public void allGraph(string Gclicked, string tabName)
        {
            PublicClass.zoom = false;
            DataTable dt2 = new DataTable();
            GetDoubleArray strFirstData;
            double[][] darrddFirstData = null;
            arrXYData = new ArrayList();
            int CtrLoop = 0;
            string InstName = PublicClass.currentInstrument;
            string[] XYUnits = null;
            string fac = null;
            string are = null;
            string tra = null;
            string mac = null;
            string pp = null;
            string sensordir = null;
            string sensortype = null;
            PublicClass.chkcurrent = null;
            m_objImpaqHandler = new ImpaqHandler();
            try
            {
                if (InstName == "Impaq-Benstone" || InstName == "FieldPaq2")
                {
                    XYUnits = ExtractUnits();
                    _XUnit = XYUnits[0];
                    _YUnit = XYUnits[1];
                    PublicClass.x_Unit = _XUnit;
                    PublicClass.y_Unit = _YUnit;
                    dt2 = DbClass.getdata(CommandType.Text, "select sen.Sensor_dir,sen.sensor_type,mea.power_zoom,mea.power_zoom_startfeq  from point pt inner join type_point tp on tp.ID=pt.PointType_ID left join measure mea on mea.Type_ID=tp.ID left join sensor_data sen on sen.Sensor_ID=mea.Sensor_ID where pt.Point_ID='" + PublicClass.SPointID + "'");
                    foreach (DataRow rd1 in dt2.Rows)
                    {
                        sensordir = Convert.ToString(rd1["Sensor_dir"]);
                        sensortype = Convert.ToString(rd1["sensor_type"]);
                        zoom = Convert.ToString(rd1["power_zoom"]);
                        power_zoom = Convert.ToString(rd1["power_zoom_startfeq"]);
                        if (sensordir == "0")
                        {
                            PublicClass.sensordirtype = "XYZ";
                        }
                    }
                }
                else if (InstName == "Kohtect-C911")
                {
                    m_main.setgraphCombo();
                    string XY = pg3.getUnitValuesC911();
                    string[] graph = XY.Split(new char[] { ',' });
                    PublicClass.x_Unit = graph[0];
                    PublicClass.y_Unit = graph[1];
                }
                else
                {
                    dt2 = DbClass.getdata(CommandType.Text, " select di.channeltype from point pt inner join type_point tp on tp.ID=pt.PointType_ID left join di_point di on di.type_id=tp.ID where pt.Point_ID='" + PublicClass.SPointID + "'");
                    foreach (DataRow rd1 in dt2.Rows)
                    {
                        sensordir = Convert.ToString(rd1["channeltype"]);
                        if (sensordir == "3")
                        {
                            PublicClass.sensordirtype = "XY";
                        }
                        else if (sensordir == "4")
                        { PublicClass.sensordirtype = "XZ"; }
                    }
                    //m_main.DirectionValue = PublicClass.AHVCH1;
                    //string demOverall = GetImpaqOverall();
                    m_main.setgraphCombo();
                    string XY = pg3.ExtractCurrentUnit();
                    string[] graph = XY.Split(new char[] { ',' });
                    PublicClass.x_Unit = graph[0];
                    PublicClass.y_Unit = graph[1];
                    //m_objfrmMain._EnableOrbit = false;
                    if (Convert.ToInt16(pg3.MType) == 0 || Convert.ToInt16(pg3.MType) == 1)
                    {
                        //m_main.GraphType = "FFT";                       
                    }
                    else if (Convert.ToInt16(pg3.MType) == 2 || Convert.ToInt16(pg3.MType) == 3)
                    {
                        //m_main.GraphType = "Time";                      
                        if (Convert.ToInt16(pg3.MType) == 3)
                        {
                            // m_main._EnableOrbit = true;
                        }
                    }
                }
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select fac.Name,ar.Name,tra.Name,mac.Name,pp.PointName from point pp inner join machine_info mac on mac.Machine_ID=pp.Machine_ID left join train_info tra on tra.Train_ID=mac.TrainID left join area_info ar on ar.Area_ID=tra.Area_ID left join factory_info fac on fac.Factory_ID=ar.FactoryID where Point_ID='" + PublicClass.SPointID + "'");
                foreach (DataRow rd in dt.Rows)
                {
                    fac = Convert.ToString(rd["Name"]);
                    are = Convert.ToString(rd["Name1"]);
                    tra = Convert.ToString(rd["Name2"]);
                    mac = Convert.ToString(rd["Name3"]);
                    pp = Convert.ToString(rd["PointName"]);
                }
                string showhierchy = fac + " --> " + are + " --> " + tra + " --> " + mac + " --> " + pp;
                m_main.DirectionValue = PublicClass.AHVCH1;
                string demOverall = GetImpaqOverall();
                PublicClass.footername = showhierchy + "\n" + "Overall : " + demOverall;
                if (sensortype == "5")
                {
                    PublicClass.chkcurrent = "Current";
                    PublicClass.Chart_Footer = showhierchy + "\n" + "Overall : " + demOverall + "\n" + "Motor Current Signature";
                }
                else
                {
                    PublicClass.Chart_Footer = showhierchy + "\n" + "Overall : " + demOverall;
                }
                _ChartHeader = null;

                if (InstName == "FieldPaq2" || InstName == "Impaq-Benstone" || InstName == "Kohtect-C911")
                { m_main.SetButtons(PublicClass.GraphClicked, "FieldPaq2"); }
                else
                {
                    m_main.SetButtons(PublicClass.GraphClicked, "Impaq-Benstone");
                }
                m_main.setCursorCombo(PublicClass.GraphClicked);
                ArrayList arrXYVals = new ArrayList();
                string sFirstGraph = PublicClass.AHVCH1;
                ArrayList arrTime = new ArrayList();
                arrTime.Add(PublicClass.tym);

                arrXYVals = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrTime, Gclicked, sFirstGraph);
                //----get overall value----//

                ////int GraphCount = arrXYVals.Count / 2; StringBuilder DataXY = new StringBuilder(); string XYFinalData = null;
                ////for (int i = 0; i < GraphCount; i++)
                ////{
                  
                ////    double[] xData = (double[])arrXYVals[2 * i];
                ////    double[] yData = (double[])arrXYVals[(2 * i) + 1];

                ////    for (int a = 0; a < xData.Length; a++)
                ////    {
                ////        DataXY.Append(Convert.ToString(xData[a]));
                ////        DataXY.Append("|");                      
                ////        DataXY.Append(Convert.ToString(yData[a]));
                ////        DataXY.Append(",");                       
                ////    }
                ////    XYFinalData = Convert.ToString(DataXY);
                ////}
                ////FindOverallVal(XYFinalData);

                //----End----//

                if (arrXYVals.Count > 0)
                {
                    m_main.ShowCurrentDate();
                    if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                    {
                        if (PublicClass.GraphClicked == "Time")
                        {
                            m_main.cmbGraphs.EditValue = "Time Waveform";
                        }
                        else if (PublicClass.GraphClicked == "Power")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group1 Power1";
                        }
                        else if (PublicClass.GraphClicked == "Power1")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group1 Power2";
                        }
                        else if (PublicClass.GraphClicked == "Power2")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group2 Power1";
                        }
                        else if (PublicClass.GraphClicked == "Power21")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group2 Power2";
                        }
                        else if (PublicClass.GraphClicked == "Power3")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group3 Power1";
                        }
                        else if (PublicClass.GraphClicked == "Power31")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group3 Power2";
                        }
                        else if (PublicClass.GraphClicked == "Cepstrum")
                        {
                            m_main.cmbGraphs.EditValue = "Cepstrum";
                        }
                        else if (PublicClass.GraphClicked == "Demodulate")
                        {
                            m_main.cmbGraphs.EditValue = "Demodulate Spectrum";
                        }
                    }
                    else
                    {
                        m_main.bcmDirection.Enabled = false;
                        if (PublicClass.GraphClicked == "Time")
                        {
                            if (PublicClass.lastDigraph == "Time Channel1")
                            {
                                m_main.cmbGraphs.EditValue = "Time Channel1";
                            }
                            else if (PublicClass.lastDigraph == "Time Channel2")
                            {
                                m_main.cmbGraphs.EditValue = "Time Channel2";
                            }
                            else if (PublicClass.lastDigraph == "TWF To FFT Channel1")
                            {
                                m_main.cmbGraphs.EditValue = "TWF To FFT Channel1";
                            }
                            else if (PublicClass.lastDigraph == "TWF To FFT Channel2")
                            {
                                m_main.cmbGraphs.EditValue = "TWF To FFT Channel2";
                            }
                        }
                        else if (PublicClass.GraphClicked == "Power")
                        {
                            if (PublicClass.lastDigraph == "Power Spectrum Channel2")
                            { m_main.cmbGraphs.EditValue = "Power Spectrum Channel2"; }
                            else
                            {
                                m_main.cmbGraphs.EditValue = "Power Spectrum Channel1";                                            
                            }
                            if(PublicClass.currentInstrument=="Kohtect-C911")
                            {
                                if (PublicClass.checkparent == "Acc")
                                {
                                    m_main.bboveralltype.EditValue = "A";
                                }
                                else if (PublicClass.checkparent == "Vel")
                                {
                                    m_main.bboveralltype.EditValue = "V";
                                }
                                if (PublicClass.checkparent == "Displ")
                                {
                                    m_main.bboveralltype.EditValue = "S";
                                }
                            }
                        }
                    }
                    lastgraph = PublicClass.GraphClicked;                   
                    m_main.IsBandAreaPlot = false;
                    m_main.DrawLineGraphs(arrXYVals, zoom, power_zoom);
                }
                else
                {                                       
                    PublicClass.GraphClicked = lastgraph;
                    if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                    {
                        MessageBox.Show("Current Selection Have No Data", "No Data");
                        if (PublicClass.GraphClicked == "Time")
                        {
                            m_main.cmbGraphs.EditValue = "Time Waveform";
                        }
                        else if (PublicClass.GraphClicked == "Power")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group1 Power1";
                        }
                        else if (PublicClass.GraphClicked == "Power1")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group1 Power2";
                        }
                        else if (PublicClass.GraphClicked == "Power2")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group2 Power1";
                        }
                        else if (PublicClass.GraphClicked == "Power21")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group2 Power2";
                        }
                        else if (PublicClass.GraphClicked == "Power3")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group3 Power1";
                        }
                        else if (PublicClass.GraphClicked == "Power31")
                        {
                            m_main.cmbGraphs.EditValue = "Power Spectrum Group3 Power2";
                        }
                        else if (PublicClass.GraphClicked == "Cepstrum")
                        {
                            m_main.cmbGraphs.EditValue = "Cepstrum";
                        }
                        else if (PublicClass.GraphClicked == "Demodulate")
                        {
                            m_main.cmbGraphs.EditValue = "Demodulate Spectrum";
                        }
                    }
                    else
                    {
                        m_main.bcmDirection.Enabled = false;
                        m_main.cmbGraphs.EditValue = PublicClass.lastDigraph;
                        if (PublicClass.GraphClicked == "Time")
                        {
                            if (PublicClass.lastDigraph == "Time Channel1")
                            {
                                m_main.cmbGraphs.EditValue = "Time Channel1";
                            }
                            else if (PublicClass.lastDigraph == "Time Channel2")
                            { 
                                m_main.cmbGraphs.EditValue = "Time Channel2";
                            }
                            else if (PublicClass.lastDigraph == "TWF To FFT Channel1")
                            {
                                m_main.cmbGraphs.EditValue = "TWF To FFT Channel1";
                            }
                            else if (PublicClass.lastDigraph == "TWF To FFT Channel2")
                            {
                                m_main.cmbGraphs.EditValue = "TWF To FFT Channel2";
                            }
                        }
                        else if (PublicClass.GraphClicked == "Power")
                        {
                            if (PublicClass.lastDigraph == "Power Spectrum Channel2")
                            {
                                m_main.cmbGraphs.EditValue = "Power Spectrum Channel2"; 
                            }
                            else
                            {
                                m_main.cmbGraphs.EditValue = "Power Spectrum Channel1";
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        ArrayList arrtime = new ArrayList();
        public void trendGraph(string Gclicked, string tabName)
        {
            GetDoubleArray strFirstData;
            double[][] darrddFirstData = null;
            arrXYData = new ArrayList();
            string sTime = null;
            string InstName = PublicClass.currentInstrument;
            string[] XYUnits = null;
            string fac = null;
            string are = null;
            string tra = null;
            string mac = null;
            string pp = null;

            m_objImpaqHandler = new ImpaqHandler();
            try
            {
                if (InstName == "Impaq-Benstone"||InstName=="FieldPaq2")
                {
                    XYUnits = ExtractUnits();
                    _XUnit = XYUnits[0];
                    _YUnit = XYUnits[1];
                    PublicClass.x_Unit = _XUnit;
                    PublicClass.y_Unit = _YUnit;
                    DataTable dt2 = new DataTable();
                    dt2 = DbClass.getdata(CommandType.Text, "select sen.Sensor_dir from point pt inner join type_point tp on tp.ID=pt.PointType_ID left join measure mea on mea.Type_ID=tp.ID left join sensor_data sen on sen.Sensor_ID=mea.Sensor_ID where pt.Point_ID='" + PublicClass.SPointID + "'");
                    foreach (DataRow rd1 in dt2.Rows)
                    {
                        string sensordir = Convert.ToString(rd1["Sensor_dir"]);
                        if (sensordir == "0")
                        {
                            PublicClass.sensordirtype = "XYZ";
                        }
                    }

                    DataTable dt1 = new DataTable();
                    dt1 = DbClass.getdata(CommandType.Text, "select measure_time from point_data where Point_ID='" + PublicClass.SPointID + "'");

                    foreach (DataRow rd1 in dt1.Rows)
                    {
                        sTime = Convert.ToDateTime(rd1["Measure_time"]).ToString();
                        arrtime.Add(sTime);
                    }
                    DataTable dt = new DataTable();
                    dt = DbClass.getdata(CommandType.Text, "select fac.Name,ar.Name,tra.Name,mac.Name,pp.PointName from point pp inner join machine_info mac on mac.Machine_ID=pp.Machine_ID left join train_info tra on tra.Train_ID=mac.TrainID left join area_info ar on ar.Area_ID=tra.Area_ID left join factory_info fac on fac.Factory_ID=ar.FactoryID where Point_ID='" + PublicClass.SPointID + "'");
                    foreach (DataRow rd in dt.Rows)
                    {
                        fac = Convert.ToString(rd["Name"]);
                        are = Convert.ToString(rd["Name1"]);
                        tra = Convert.ToString(rd["Name2"]);
                        mac = Convert.ToString(rd["Name3"]);
                        pp = Convert.ToString(rd["PointName"]);
                    }
                    string showhierchy = fac + " --> " + are + " --> " + tra + " --> " + mac + " --> " + pp;
                    string demOverall = GetImpaqOverall();
                    PublicClass.footername = showhierchy + "\n" + "Overall : " + demOverall;
                    PublicClass.Chart_Footer = showhierchy + "\n" + "Overall : " + demOverall;
                    _ChartHeader = null;
                }
                else
                {

                    DataTable dt1 = new DataTable();
                    dt1 = DbClass.getdata(CommandType.Text, "select measure_time from point_data where Point_ID='" + PublicClass.SPointID + "'");

                    foreach (DataRow rd1 in dt1.Rows)
                    {
                        sTime = Convert.ToDateTime(rd1["Measure_time"]).ToString();
                        arrtime.Add(sTime);
                    }
                    m_main.DirectionValue = PublicClass.AHVCH1;
                    string XY = pg3.ExtractCurrentUnit();
                    string[] graph = XY.Split(new char[] { ',' });
                    PublicClass.x_Unit = graph[0];
                    PublicClass.y_Unit = graph[1];
                    //m_objfrmMain._EnableOrbit = false;
                    if (Convert.ToInt16(pg3.MType) == 0 || Convert.ToInt16(pg3.MType) == 1)
                    {
                        //m_main.GraphType = "FFT";                       
                    }
                    else if (Convert.ToInt16(pg3.MType) == 2 || Convert.ToInt16(pg3.MType) == 3)
                    {
                        //m_main.GraphType = "Time";                      
                        if (Convert.ToInt16(pg3.MType) == 3)
                        {
                            // m_main._EnableOrbit = true;
                        }
                    }
                }
                m_main.SetButtons(PublicClass.GraphClicked, InstName);
                m_main.setCursorCombo(PublicClass.GraphClicked);
                ArrayList arrXYVals = new ArrayList();
                string sFirstGraph = PublicClass.AHVCH1;
                m_main.cmbGraphs.EditValue = null;
                m_main.DirectionValue = PublicClass.AHVCH1;
                arrXYVals.Add(PublicClass.darrtrendX);
                arrXYVals.Add(PublicClass.darrtrendY);
                m_main.ShowRedColor(tabName);
                m_main.DrawOverallTrendGraph(arrXYVals, arrtime);
            }
            catch
            {
            }
        }

        public void allGraphdiag(string Gclicked, Boolean flag1)
        {
            GetDoubleArray strFirstData;
            double[][] darrddFirstData = null;
            arrXYData = new ArrayList();
            int CtrLoop = 0;
            string InstName = PublicClass.currentInstrument;
            string[] XYUnits = null;
            string word1 = null;
            string fac = null;
            string are = null;
            string tra = null;
            string mac = null;
            string pp = null;
            m_objImpaqHandler = new ImpaqHandler();
            try
            {
                if (InstName == "Impaq-Benstone" || InstName == "FieldPaq2")
                {
                    XYUnits = ExtractUnits();
                    _XUnit = XYUnits[0];
                    _YUnit = XYUnits[1];
                    PublicClass.x_Unit = _XUnit;
                    PublicClass.y_Unit = _YUnit;
                    DataTable dt2 = new DataTable();
                    dt2 = DbClass.getdata(CommandType.Text, "select sen.Sensor_dir from point pt inner join type_point tp on tp.ID=pt.PointType_ID left join measure mea on mea.Type_ID=tp.ID left join sensor_data sen on sen.Sensor_ID=mea.Sensor_ID where pt.Point_ID='" + PublicClass.SPointID + "'");
                    foreach (DataRow rd1 in dt2.Rows)
                    {
                        string sensordir = Convert.ToString(rd1["Sensor_dir"]);
                        if (sensordir == "0")
                        {
                            PublicClass.sensordirtype = "XYZ";
                        }
                    }
                    DataTable dt = new DataTable();
                    dt = DbClass.getdata(CommandType.Text, "select fac.Name,ar.Name,tra.Name,mac.Name,pp.PointName from point pp inner join machine_info mac on mac.Machine_ID=pp.Machine_ID left join train_info tra on tra.Train_ID=mac.TrainID left join area_info ar on ar.Area_ID=tra.Area_ID left join factory_info fac on fac.Factory_ID=ar.FactoryID where Point_ID='" + PublicClass.SPointID + "'");
                    foreach (DataRow rd in dt.Rows)
                    {
                        fac = Convert.ToString(rd["Name"]);
                        are = Convert.ToString(rd["Name1"]);
                        tra = Convert.ToString(rd["Name2"]);
                        mac = Convert.ToString(rd["Name3"]);
                        pp = Convert.ToString(rd["PointName"]);
                    }
                    string showhierchy = fac + " --> " + are + " --> " + tra + " --> " + mac + " --> " + pp;
                    m_main.DirectionValue = PublicClass.AHVCH1;
                    string demOverall = GetImpaqOverall();
                    PublicClass.footername = showhierchy + "\n" + "Overall : " + demOverall;
                    PublicClass.Chart_Footer = showhierchy + "\n" + "Overall : " + demOverall;

                    _ChartHeader = null;
                }
                m_main.SetButtons(PublicClass.GraphClicked, InstName);
                m_main.setCursorCombo(PublicClass.GraphClicked);
                ArrayList arrXYVals = new ArrayList();
                string sFirstGraph = PublicClass.AHVCH1;
                ArrayList arrTime = new ArrayList();
                arrTime.Add(PublicClass.tym);
                arrXYVals = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrTime, Gclicked, sFirstGraph);

                m_main.ShowCurrentDate();
                m_main.DirectionValue = PublicClass.AHVCH1;
                m_main.DrawLineGraphsDia(arrXYVals, m_main.allvalue);
            }
            catch
            {
            }
        }

        private void pbpower_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.lastDigraph = "Power Spectrum Channel1";
                PublicClass.GraphClicked = "Power";
                ArrayList arrselectedDate = new ArrayList();
                arrselectedDate.Add(PublicClass.tym);
                arrXYchecks = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, PublicClass.AHVCH1);
                if (arrXYchecks.Count > 0)
                {
                    allGraph(PublicClass.GraphClicked, tpPower.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Data Not Available on Power", "Power", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch { }

        }

        private void pbpower1_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList arrselectedDate = new ArrayList();
                arrselectedDate.Add(PublicClass.tym);
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    PublicClass.GraphClicked = "Power1";
                    arrXYchecks = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, PublicClass.AHVCH1);
                    if (arrXYchecks.Count > 0)
                    {
                        allGraph(PublicClass.GraphClicked, tpPower1.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Data Not Available on Power1", "Power1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    PublicClass.lastDigraph = "Power Spectrum Channel2";
                    PublicClass.GraphClicked = "Power";
                    string firstdir = PublicClass.AHVCH1;
                    PublicClass.AHVCH1 = "Channel1";
                    arrXYchecks = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, PublicClass.AHVCH1);
                    if (arrXYchecks.Count > 0)
                    {
                        allGraph(PublicClass.GraphClicked, tpPower1.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Data Not Available on Power Channel2", "Power", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    PublicClass.AHVCH1 = firstdir;
                }
            }
            catch { }

        }

        private void pbpower2_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.GraphClicked = "Power2";
                ArrayList arrselectedDate = new ArrayList();
                arrselectedDate.Add(PublicClass.tym);
                arrXYchecks = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, PublicClass.AHVCH1);
                if (arrXYchecks.Count > 0)
                {
                    allGraph(PublicClass.GraphClicked, tpPower2.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Data Not Available on Power2", "Power2", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch { }
        }

        private void pbpower2_1_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.GraphClicked = "Power21";
                ArrayList arrselectedDate = new ArrayList();
                arrselectedDate.Add(PublicClass.tym);
                arrXYchecks = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, PublicClass.AHVCH1);
                if (arrXYchecks.Count > 0)
                {
                    allGraph(PublicClass.GraphClicked, tpPower3.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Data Not Available on Power2_1", "Power2_1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch { }
        }

        private void pbpower3_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.GraphClicked = "Power3";
                ArrayList arrselectedDate = new ArrayList();
                arrselectedDate.Add(PublicClass.tym);
                arrXYchecks = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, PublicClass.AHVCH1);
                if (arrXYchecks.Count > 0)
                {
                    allGraph(PublicClass.GraphClicked, tpPower4.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Data Not Available on Power3", "Power3", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch { }
        }

        private void pbpower3_1_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.GraphClicked = "Power31";
                ArrayList arrselectedDate = new ArrayList();
                arrselectedDate.Add(PublicClass.tym);
                arrXYchecks = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, PublicClass.AHVCH1);
                if (arrXYchecks.Count > 0)
                {
                    allGraph(PublicClass.GraphClicked, tpPower5.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Data Not Available on Power3_1", "Power3_1", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch { }
        }

        private void pbdemo_Click(object sender, EventArgs e)
        {
            try
            {
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    PublicClass.GraphClicked = "Demodulate";
                    ArrayList arrselectedDate = new ArrayList();
                    arrselectedDate.Add(PublicClass.tym);
                    arrXYchecks = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, PublicClass.AHVCH1);
                    if (arrXYchecks.Count > 0)
                    {
                        allGraph(PublicClass.GraphClicked, tpDemo.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Data Not Available on Demodulate", "Demodulate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    PublicClass.lastDigraph = "TWF To FFT Channel1";
                    if (CurrentYLabel != null)
                    {
                        PublicClass.GraphClicked = "TWFToFFT";
                        PublicClass.checkgraph = true;
                        m_main.SetButtons("Time", PublicClass.currentInstrument);
                        m_main.setCursorCombo("Time");
                        m_main.DrawLineGraphsforDi(xarrayNew, yarrayNew, "Sec", CurrentYLabel);
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Data Not Available on Time", "Demodulate", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            catch { }
        }

        ArrayList arrXYchecks = new ArrayList();
        private void pbcep_Click(object sender, EventArgs e)
        {
            try
            {
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    PublicClass.GraphClicked = "Cepstrum";
                    ArrayList arrselectedDate = new ArrayList();
                    arrselectedDate.Add(PublicClass.tym);
                    arrXYchecks = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, PublicClass.AHVCH1);
                    if (arrXYchecks.Count > 0)
                    {
                        allGraph(PublicClass.GraphClicked, tpCepstrum.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Data Not Available on Cepstrum", "Cepstrum", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    PublicClass.GraphClicked = "Trend";
                    DataTable dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + PublicClass.SPointID + "'");
                    if (dt.Rows.Count >= 2)
                    {
                        trendGraph(PublicClass.GraphClicked, tpTrend.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Two Date Data Shows the Trend Graph", "Trend", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            catch { }
        }

        private void pbtrend_Click(object sender, EventArgs e)
        {
            try
            {
                PublicClass.GraphClicked = "Trend";
                DataTable dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + PublicClass.SPointID + "'");
                if (dt.Rows.Count >= 2)
                {
                    trendGraph(PublicClass.GraphClicked, tpTrend.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Two Date Data Shows the Trend Graph", "Trend", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch { }
        }

        private void pbtime_Click(object sender, EventArgs e)
        {
            try
            {
                if (PublicClass.currentInstrument == "Kohtect-C911")
                {
                    PublicClass.GraphClicked = "Trend";
                    DataTable dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + PublicClass.SPointID + "'");
                    if (dt.Rows.Count >= 2)
                    {
                        trendGraph(PublicClass.GraphClicked, tpTrend.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Two Date Data Shows the Trend Graph", "Trend", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    PublicClass.lastDigraph = "Time Channel1";
                    PublicClass.GraphClicked = "Time";
                    ArrayList arrselectedDate = new ArrayList();
                    arrselectedDate.Add(PublicClass.tym);
                    arrXYchecks = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, PublicClass.AHVCH1);
                    if (arrXYchecks.Count > 0)
                    {
                        allGraph(PublicClass.GraphClicked, tpTime.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(this, "Data Not Available on Time", "Time", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            catch { }
        }

        private void xtcPower_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                string gType = Convert.ToString(xtcPower.SelectedTabPage.Text.Trim());
                string[] graph = gType.Split(new char[] { ' ' });
                string gt = graph[0];
                m_objMainControlWork.FirstClick(PublicClass.ssNodeType, gt);
                switch (gt)
                {
                    case "Power":
                        {
                            if (PublicClass.checkgraph == true)
                            {
                                pbpower.Image = Image.FromFile(PublicClass.powerimage);
                            }
                            break;
                        }
                    case "Power1":
                        {
                            if (PublicClass.checkgraph == true)
                            {
                                pbpower1.Image = Image.FromFile(PublicClass.power1image);
                            }
                            break;
                        }
                    case "Power2":
                        {
                            if (PublicClass.checkgraph == true)
                            {
                                pbpower2.Image = Image.FromFile(PublicClass.power2image);
                            }
                            break;
                        }
                    case "Power21":
                        {
                            if (PublicClass.checkgraph == true)
                            {
                                pbpower2_1.Image = Image.FromFile(PublicClass.power21image);
                            }
                            break;
                        }
                    case "Power3":
                        {
                            if (PublicClass.checkgraph == true)
                            {
                                pbpower3.Image = Image.FromFile(PublicClass.power3image);
                            }
                            break;
                        }
                    case "Power31":
                        {
                            if (PublicClass.checkgraph == true)
                            {
                                pbpower3_1.Image = Image.FromFile(PublicClass.power31image);
                            }
                            break;
                        }
                }
            }
            catch
            {
            }
        }

        private void xtcTime_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                string firstdir = PublicClass.AHVCH1;
                string gType = Convert.ToString(xtcTime.SelectedTabPage.Text.Trim());
                string[] graph = gType.Split(new char[] { ' ' });
                string gt = graph[2];
                switch (gt)
                {
                    case "channel2":
                        {
                            PublicClass.AHVCH1 = "Channel1";
                            PublicClass.checkgraph = false;
                            try
                            {
                                if (pbtime1.Image != null)
                                {
                                    pbtime1.Image.Dispose();
                                }
                            }
                            catch { }
                            m_objMainControlWork.FirstClick(PublicClass.ssNodeType, "Time");
                            if (PublicClass.checkgraph == true)
                            {
                                xarrayNew = PublicClass.darrXData;
                                yarrayNew = PublicClass.darrYData;
                                CurrentYLabel = PublicClass.y_Unit;
                                chartVu = m_main._ChartViewDI;
                                pbtime1.Image = Image.FromFile(PublicClass.timeimage, true);
                                tpTime1.Text = timeval1 + " (" + firstdir + ")";
                                bExTop = true;
                            }
                            else
                            {
                                bExTop = false;
                                tpTime1.Text = timeval1;
                                tpTime1.Visible = false;
                            }

                            //twftofft//////////////

                            PublicClass.checkgraph = false;
                            try
                            {
                                if (pbdemo.Image != null)
                                {
                                    pbdemo.Image.Dispose();
                                }
                            }
                            catch { }
                            try
                            {
                                LineGraphControl _LineGraph = new LineGraphControl();
                                ConvertToFFT.TWFtoFFT _Convert = new ConvertToFFT.TWFtoFFT();
                                ArrayList NewValues = _Convert.ConvertTWFtoFFT(xarrayNew, yarrayNew, "Sec", CurrentYLabel);
                                if (NewValues != null)
                                {
                                    xarrayNew = (double[])NewValues[0];
                                    yarrayNew = (double[])NewValues[1];
                                    CurrentYLabel = (string)NewValues[3];
                                    m_main.DrawLineGraphsforDi(xarrayNew, yarrayNew, "Sec", CurrentYLabel);
                                    chartVu = m_main._ChartViewDI;
                                    BufferedImage objImage = new BufferedImage(chartVu);
                                    string path = Path.GetTempPath();
                                    try
                                    {
                                        if (File.Exists(path + @"TWFToFFT.jpg"))
                                        {
                                            File.Delete(path + @"TWFToFFT.jpg");
                                        }
                                        else
                                        { }
                                        objImage.SaveImage(path + @"TWFToFFT.jpg");
                                        PublicClass.demoimage = path + @"TWFToFFT.jpg";
                                    }
                                    catch
                                    { }
                                }
                            }
                            catch { }

                            if (CurrentYLabel != null)
                            {
                                pbdemo.Image = Image.FromFile(PublicClass.demoimage);
                                tpDemo.Text = DemVal1 + " (" + firstdir + ")";
                                bExTop = true;
                            }
                            else
                            {
                                bExTop = false;
                                tpDemo.Text = DemVal1;
                                tpDemo.Visible = false;
                            }
                            PublicClass.AHVCH1 = firstdir;
                            break;
                        }
                    case "channel1":
                        {
                            PublicClass.checkgraph = false;
                            try
                            {
                                if (pbtime.Image != null)
                                {
                                    pbtime.Image.Dispose();
                                    pbtime.Image = null;
                                }
                            }
                            catch { }
                            m_objMainControlWork.FirstClick(PublicClass.ssNodeType, "Time");
                            if (PublicClass.checkgraph == true)
                            {
                                xarrayNew = PublicClass.darrXData;
                                yarrayNew = PublicClass.darrYData;
                                CurrentYLabel = PublicClass.y_Unit;
                                pbtime.Image = Image.FromFile(PublicClass.timeimage, true);
                                tpTime.Text = timeval + " (" + PublicClass.AHVCH1 + ")";
                                bExTop = true;
                            }
                            else
                            {
                                bExTop = false;
                                tpTime.Text = timeval;
                                tpTime.Visible = false;
                            }

                            //demo/////////////////////////////////////////

                            PublicClass.checkgraph = false;
                            try
                            {
                                if (pbdemo.Image != null)
                                {
                                    pbdemo.Image.Dispose();
                                }
                            }
                            catch { }
                            try
                            {
                                LineGraphControl _LineGraph = new LineGraphControl();
                                ConvertToFFT.TWFtoFFT _Convert = new ConvertToFFT.TWFtoFFT();
                                ArrayList NewValues = _Convert.ConvertTWFtoFFT(xarrayNew, yarrayNew, "Sec", CurrentYLabel);
                                if (NewValues != null)
                                {
                                    xarrayNew = (double[])NewValues[0];
                                    yarrayNew = (double[])NewValues[1];
                                    CurrentYLabel = (string)NewValues[3];
                                    m_main.DrawLineGraphsforDi(xarrayNew, yarrayNew, "Sec", CurrentYLabel);
                                    chartVu = m_main._ChartViewDI;
                                    BufferedImage objImage = new BufferedImage(chartVu);
                                    string path = Path.GetTempPath();
                                    try
                                    {
                                        if (File.Exists(path + @"TWFToFFT.jpg"))
                                        {
                                            File.Delete(path + @"TWFToFFT.jpg");
                                        }
                                        else
                                        { }
                                        objImage.SaveImage(path + @"TWFToFFT.jpg");
                                        PublicClass.demoimage = path + @"TWFToFFT.jpg";
                                    }
                                    catch
                                    { }
                                }
                            }
                            catch { }

                            if (CurrentYLabel != null)
                            {
                                pbdemo.Image = Image.FromFile(PublicClass.demoimage);
                                tpDemo.Text = DemVal + " (" + PublicClass.AHVCH1 + ")";
                                bExTop = true;
                            }
                            else
                            {
                                bExTop = false;
                                tpDemo.Text = DemVal;
                                tpDemo.Visible = false;
                            }
                            break;
                        }
                }
            }
            catch { }
        }

        private void pbtime1_Click(object sender, EventArgs e)
        {
            PublicClass.lastDigraph = "Time Channel2";
            ArrayList arrselectedDate = new ArrayList();
            arrselectedDate.Add(PublicClass.tym);
            PublicClass.GraphClicked = "Time";
            string firstdir = PublicClass.AHVCH1;
            PublicClass.AHVCH1 = "Channel1";
            arrXYchecks = m_objImpaqHandler.GetAllPlotValues(PublicClass.SPointID, null, arrselectedDate, PublicClass.GraphClicked, PublicClass.AHVCH1);
            if (arrXYchecks.Count > 0)
            {
                allGraph(PublicClass.GraphClicked, tpPower1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Data Not Available on Time Channel2", "Time", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            PublicClass.AHVCH1 = firstdir;
        }


    }
}