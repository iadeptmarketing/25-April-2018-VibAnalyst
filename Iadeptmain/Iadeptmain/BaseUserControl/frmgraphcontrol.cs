using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using Iadeptmain.GlobalClasses;
using Iadeptmain.Mainforms;
using DevExpress.XtraTreeList.Nodes;
using com.iAM.chart2dnet;

namespace Iadeptmain.BaseUserControl 
{
    public partial class frmgraphcontrol : DevExpress.XtraEditors.XtraForm
    {
        private uc3DGraphControl m_obj3DGraphControl = null;
        GraphView m_objGraphView =null;
        PointGeneral1 m_objpointControl = null;
        private IadeptUserControl m_objMainControl = null;
        frmIAdeptMain m_objMainForm ;
         
        
        public frmgraphcontrol()
        {
            InitializeComponent();
            ActivGrapgobj();
        }

        public void ActivGrapgobj()
        {
            m_objGraphView = new GraphView(this);
            m_objGraphView.ParentForm = this;

        }


        private bool bSetTime = false;
        string xList = null;
        string yList = null;

        

        public IadeptUserControl usercontrol
        {
            get
            {
                return m_objMainControl;
            }
            set
            {
                m_objMainControl = value;
            }
        }

        public uc3DGraphControl uc3D
        {
            get
            {
                return m_obj3DGraphControl;
            }
            set
            {
                m_obj3DGraphControl = value;
            }
        }

        public PointGeneral1 pg1
        {
            get { return m_objpointControl; }
            set { m_objpointControl = value; }

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
        public frmIAdeptMain MainForm
        {
            get
            {
                return m_objMainForm;
            }
            set
            {
                m_objMainForm = value;
            }
        }

        public ChartView testGraph1
        {
            get
            {
                return m_objGraphView.testingGraph1;
            }
            set
            {
                m_objGraphView.testingGraph1 = value;
            }


        }




        public void ClearData()
        {
            try
            {

                dgvGraphData.Rows[0].Cells[1].Value = "";
                dgvGraphData.Rows[1].Cells[1].Value = "";
                dgvGraphData.Rows[2].Cells[1].Value = "";

                dgvGraphData.Rows[0].Cells[1].ReadOnly = true;
                dgvGraphData.Rows[1].Cells[1].ReadOnly = true;
                dgvGraphData.Rows[2].Cells[1].ReadOnly = true;


                dgvGraphData.Rows[0].Cells[2].Value = "";
                dgvGraphData.Rows[1].Cells[2].Value = "";
                dgvGraphData.Rows[2].Cells[2].Value = "";

                dgvGraphData.Rows[0].Cells[2].ReadOnly = true;
                dgvGraphData.Rows[1].Cells[2].ReadOnly = true;
                dgvGraphData.Rows[2].Cells[2].ReadOnly = true;

                dgvGraphData.Rows[0].Cells[3].Value = "";
                dgvGraphData.Rows[1].Cells[3].Value = "";
                dgvGraphData.Rows[2].Cells[3].Value = "";

                dgvGraphData.Rows[0].Cells[3].ReadOnly = true;
                dgvGraphData.Rows[1].Cells[3].ReadOnly = true;
                dgvGraphData.Rows[2].Cells[3].ReadOnly = true;


                dgvGraphData.Rows[0].Cells[4].Value = "";
                dgvGraphData.Rows[1].Cells[4].Value = "";
                dgvGraphData.Rows[2].Cells[4].Value = "";

                dgvGraphData.Rows[0].Cells[4].ReadOnly = true;
                dgvGraphData.Rows[1].Cells[4].ReadOnly = true;
                dgvGraphData.Rows[2].Cells[4].ReadOnly = true;

                if (m_sFocusedNodeChange == "FocusedNodeChange")
                {
                    btnSetBackColor.Enabled = false;
                    btnCursor.Enabled = false;
                    lblPointName.Text = "";
                    btnZoom.Enabled = false;




                    btnUnZoom.Enabled = false;
                    tscbGraphTypes.Enabled = false;
                    lblDate.Text = "";
                }
                else if (m_sFocusedNodeChange == "InitializeChart")
                {
                    btnSetBackColor.Enabled = true;
                    btnCursor.Enabled = true;
                    lblPointName.Text = "";
                    btnZoom.Enabled = true;

                    btnUnZoom.Enabled = true;
                    tscbGraphTypes.Enabled = true;
                    lblDate.Text = "";
                }

                m_objGraphView.ClearItems = true;


            }
            catch (Exception ex)
            {
            }
        }


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
                m_objGraphView.RemovePreviousObjects();
                if (m_objGraphView._Mara)
                {
                    bmara = true;
                }
                else
                {
                    bmara = false;
                }
            }
            catch (Exception ex)
            {
            }
        }
       
        public string CopiedX
        {
            get
            {
                return xList;
            }
        }
        string sGraphType = null;
        public string GraphType
        {
            get
            {
                return sGraphType;
            }
            set
            {
                sGraphType = value;
            }
        }
        string sDirection = null;
        public string GraphDirection
        {
            get
            {
                return sDirection;
            }
            set
            {
                sDirection = value;
            }
        }

        public SplitGroupPanel buttonheight
        {
            get
            {
                return m_objMainControl.buttonheight;
            }
        }
        public string CopiedY
        {
            get
            {
                return yList;
            }
        }
        public bool SetTypeTime
        {
            set
            {
                bSetTime = value;
            }
        }
        private string m_sFocusedNodeChange = null;

        public string CheckFocusedNodeChange
        {
            set
            {
                m_sFocusedNodeChange = value;
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

        string m_sDateTime = null;

        public string DateTime
        {
            get
            {
                return m_sDateTime;
            }
            set
            {
                m_sDateTime = value;
            }
        }

        public string SetDateTime
        {
            set
            {
                lblDate.Text = value;
            }
        }

        public Color SetForeColorDateTime
        {
            set
            {
                lblDate.ForeColor = value;
            }
        }

        bool bZoom = false;

        public bool DisableZoomButton
        {
            set
            {
                bZoom = value;
            }
        }
        bool bAxial = false;

        public bool Axial
        {
            set
            {
                bAxial = value;
            }
        }
        string m_sUnits = null;

        public string Units
        {
            get
            {
                return m_sUnits;
            }
            set
            {
                m_sUnits = value;
            }
        }

        public string LabelTime
        {
            get
            {
                return lblDate.Text;
            }
            set
            {
                lblDate.Text = value;


            }
        }

        public Color LabelColor
        {
            get
            {
                return lblDate.ForeColor;
            }
            set
            {
                lblDate.ForeColor = value;
            }
        }

        bool bOverall = false;
        public bool IfOverallTrend
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

        bool bAxisCombobox = false;
        public bool IsAxisComboBox
        {
            get
            {
                return toolStripComboBox1.Enabled;
            }
            set
            {
                toolStripComboBox1.Enabled = value;
            }
        }
        string sYAxis = null;
        public string setYAxisValue
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
        ArrayList sarrTime = null;
        public ArrayList Timedata1
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
        int iDataTaken = 0;
        public int NoOfDataTaken
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

        public IadeptUserControl MainControl
        {
            get
            {
                return m_objMainControl;
            }
            set
            {
                m_objMainControl = value;
            }
        }
        string sCopyTime = null;
        public string CopyTime
        {
            get
            {
                return sCopyTime;
            }
            set
            {
                sCopyTime = value;
            }
        }


        public void FillOverAllValues(string sDateTime)
        {
            string objNode = PublicClass.SPointID;
            string sID = null;

            string sPtAccelA = null;
            string sPtAccelH = null;
            string sPtAccelV = null;
            string sPtVelA = null;
            string sPtVelH = null;
            string sPtVelV = null;
            string sPtDisplA = null;
            string sPtDisplH = null;
            string sPtDisplV = null;
            string sPtBearingA = null;
            string sPtBearingH = null;
            string sPtBearingV = null;

            string sPtcrestfactorA = null;
            string sPtcrestfactorH = null;
            string sPtcrestfactorV = null;

            string InstrumentNAme = PublicClass.currentInstrument;
            string sOverAllValue = null;
            
            string sDIUnit = null;
            
            string sTime = null;
            try
            {
                sID = objNode;

                if (InstrumentNAme == "Impaq-Benstone"||InstrumentNAme=="FieldPaq2")
                {
                    DataTable dt = new DataTable();
                    dt = DbClass.getdata(CommandType.Text, "select * from Point_data where point_id='" + sID + "' && Time='" + sDateTime + "'");

                    foreach (DataRow dr in dt.Rows)
                    {
                        sPtAccelA = Convert.ToString(dr["accel_a"]);
                        sPtAccelH = Convert.ToString(dr["accel_h"]);
                        sPtAccelV = Convert.ToString(dr["accel_v"]);

                        sPtVelA = Convert.ToString(dr["vel_a"]);
                        sPtVelH = Convert.ToString(dr["vel_h"]);
                        sPtVelV = Convert.ToString(dr["vel_v"]);

                        sPtDisplA = Convert.ToString(dr["displ_a"]);
                        sPtDisplH = Convert.ToString(dr["displ_h"]);
                        sPtDisplV = Convert.ToString(dr["displ_v"]);

                        sPtBearingA = Convert.ToString(dr["bearing_a"]);
                        sPtBearingH = Convert.ToString(dr["bearing_h"]);
                        sPtBearingV = Convert.ToString(dr["bearing_v"]);

                        sPtcrestfactorA = Convert.ToString(dr["crest_factor_a"]);
                        sPtcrestfactorH = Convert.ToString(dr["crest_factor_h"]);
                        sPtcrestfactorV = Convert.ToString(dr["crest_factor_v"]);

                        sTime = Convert.ToString(dr["Time"]);
                    }


                    CopyTime = sTime;

                    PickDataToCopy(sTime, sID);
                }
                

                dgvGraphData.Rows[0].Cells[1].Value = sPtAccelA;
                dgvGraphData.Rows[1].Cells[1].Value = sPtAccelH;
                dgvGraphData.Rows[2].Cells[1].Value = sPtAccelV;

                dgvGraphData.Rows[0].Cells[1].ReadOnly = true;
                dgvGraphData.Rows[1].Cells[1].ReadOnly = true;
                dgvGraphData.Rows[2].Cells[1].ReadOnly = true;


                dgvGraphData.Rows[0].Cells[2].Value = sPtVelA;
                dgvGraphData.Rows[1].Cells[2].Value = sPtVelH;
                dgvGraphData.Rows[2].Cells[2].Value = sPtVelV;

                dgvGraphData.Rows[0].Cells[2].ReadOnly = true;
                dgvGraphData.Rows[1].Cells[2].ReadOnly = true;
                dgvGraphData.Rows[2].Cells[2].ReadOnly = true;

                dgvGraphData.Rows[0].Cells[3].Value = sPtDisplA;
                dgvGraphData.Rows[1].Cells[3].Value = sPtDisplH;
                dgvGraphData.Rows[2].Cells[3].Value = sPtDisplV;

                dgvGraphData.Rows[0].Cells[3].ReadOnly = true;
                dgvGraphData.Rows[1].Cells[3].ReadOnly = true;
                dgvGraphData.Rows[2].Cells[3].ReadOnly = true;


                dgvGraphData.Rows[0].Cells[4].Value = sPtBearingA;
                dgvGraphData.Rows[1].Cells[4].Value = sPtBearingH;
                dgvGraphData.Rows[2].Cells[4].Value = sPtBearingV;

                dgvGraphData.Rows[0].Cells[4].ReadOnly = true;
                dgvGraphData.Rows[1].Cells[4].ReadOnly = true;
                dgvGraphData.Rows[2].Cells[4].ReadOnly = true;

                try
                {
                    dgvGraphData.Rows[0].Cells[5].Value = sPtcrestfactorA;
                    dgvGraphData.Rows[1].Cells[5].Value = sPtcrestfactorH;
                    dgvGraphData.Rows[2].Cells[5].Value = sPtcrestfactorV;

                    dgvGraphData.Rows[0].Cells[5].ReadOnly = true;
                    dgvGraphData.Rows[1].Cells[5].ReadOnly = true;
                    dgvGraphData.Rows[2].Cells[5].ReadOnly = true;
                }
                catch
                {
                }

            }
            catch (Exception ex)
            {
            }
        }
        private int iPlotConter = 0;

        public int SetCounter
        {
            set
            {
                iPlotConter = 0;
            }
        }
        private void PickDataToCopy(string sTime, string sID)
        {
            try
            {

            }
            catch { }
        }
        public void getUnitValues(string Report)
        {
            try
            {
                string accel_unit = null;
                string vel_unit = null;
                string displ_unit = null;
                string temprature_unit = null;
                string process_unit = null;
                string accel_detection = null;
                string vel_detection = null;
                string displ_detection = null;
                string time_unit_type = null;
                string power_unit_type = null;
                string demodulate_unit_type = null;
                string pressure_unit = null;
                string current_unit = null;
                string pressure_detection = null;
                string current_detection = null;
                string ordertrace_unit_type = null;
                string cepstrum_unit_type = null;
                string spoint = null;

                if (PublicClass.ssNodeType == "Point")
                {
                    DataTable dt = new DataTable();
                    dt = DbClass.getdata(CommandType.Text, "select PointType_ID from point where point_id='" + PublicClass.SPointID + "'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        spoint = Convert.ToString(dr["PointType_ID"]);
                    }
                    if (spoint != null)
                    {
                        DataTable dt2 = new DataTable();
                        dt2 = DbClass.getdata(CommandType.Text, "select * from units where Type_ID='" + spoint + "'");
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            try
                            {
                                accel_unit = Convert.ToString(dr2["accel_unit"]);
                                vel_unit = Convert.ToString(dr2["vel_unit"]);
                                displ_unit = Convert.ToString(dr2["displ_unit"]);
                                temprature_unit = Convert.ToString(dr2["temperature_unit"]);
                                process_unit = Convert.ToString(dr2["process_unit"]);
                                accel_detection = Convert.ToString(dr2["accel_detection"]);
                                vel_detection = Convert.ToString(dr2["vel_detection"]);
                                displ_detection = Convert.ToString(dr2["displ_detection"]);
                                time_unit_type = Convert.ToString(dr2["time_unit_type"]);
                                power_unit_type = Convert.ToString(dr2["power_unit_type"]);
                                demodulate_unit_type = Convert.ToString(dr2["demodulate_unit_type"]);
                                pressure_unit = Convert.ToString(dr2["pressure_unit"]);
                                current_unit = Convert.ToString(dr2["current_unit"]);
                                pressure_detection = Convert.ToString(dr2["pressure_detection"]);
                                current_detection = Convert.ToString(dr2["current_detection"]);
                                ordertrace_unit_type = Convert.ToString(dr2["ordertrace_unit_type"]);
                                cepstrum_unit_type = Convert.ToString(dr2["cepstrum_unit_type"]);
                            }
                            catch
                            { }
                        }
                        DataTable dt3 = new DataTable();
                        dt3 = DbClass.getdata(CommandType.Text, "select * from measure where Type_ID='" + spoint + "'");
                        foreach (DataRow dr3 in dt3.Rows)
                        {
                            string overall_bearing_filter = Convert.ToString(dr3["overall_bearing_filter"]);
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
                            accel_detection = "True PK";
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
                            vel_detection = "True PK";
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
                            displ_detection = "True PK";
                        }

                        if (sGraphname == "Time")
                        {
                            m_objGraphView = new GraphView(this);
                            if (time_unit_type == "0")
                            {
                                m_obj3DGraphControl.Units = "Hz," + accel_unit + "(" + accel_detection + ")";

                                m_objGraphView.Units = "Hz," + accel_unit + "(" + accel_detection + ")";
                            }
                            else if (time_unit_type == "1")
                            {
                                m_objGraphView.Units = "Hz," + vel_unit + "(" + vel_detection + ")";
                            }
                            else if (time_unit_type == "2")
                            {
                                m_objGraphView.Units = "Hz," + displ_unit + "(" + displ_detection + ")";
                            }
                        }
                        else if (sGraphname == "Power" || sGraphname == "powerGraph1" || sGraphname == "power2Graph" || sGraphname == "power2Graph1" || sGraphname == "power3Graph" || sGraphname == "power3Graph1")
                        {
                            if (power_unit_type == "0")
                            {
                                m_obj3DGraphControl.Units = "Hz," + accel_unit + "(" + accel_detection + ")";


                                m_objGraphView.Units = "Hz," + accel_unit + "(" + accel_detection + ")";
                            }
                            else if (power_unit_type == "1")
                            {
                                m_objGraphView.Units = "Hz," + vel_unit + "(" + vel_detection + ")";
                            }
                            else if (power_unit_type == "2")
                            {
                                m_objGraphView.Units = "Hz," + displ_unit + "(" + displ_detection + ")";
                            }
                        }
                        else if (sGraphname == "Demodulate")
                        {
                            if (demodulate_unit_type == "0")
                            {
                                m_obj3DGraphControl.Units = "Hz," + accel_unit + "(" + accel_detection + ")";

                                m_objGraphView.Units = "Hz," + accel_unit + "(" + accel_detection + ")";
                            }
                            else if (demodulate_unit_type == "1")
                            {
                                m_objGraphView.Units = "Hz," + vel_unit + "(" + vel_detection + ")";
                            }
                            else if (demodulate_unit_type == "2")
                            {
                                m_objGraphView.Units = "Hz," + displ_unit + "(" + displ_detection + ")";
                            }
                        }
                        else if (sGraphname == "Cepstrum")
                        {
                            if (cepstrum_unit_type == "0")
                            {
                                m_obj3DGraphControl.Units = "Hz," + accel_unit + "(" + accel_detection + ")";

                                m_objGraphView.Units = "Hz," + accel_unit + "(" + accel_detection + ")";
                            }
                            else if (cepstrum_unit_type == "1")
                            {
                                m_objGraphView.Units = "Hz," + vel_unit + "(" + vel_detection + ")";
                            }
                            else if (cepstrum_unit_type == "2")
                            {
                                m_objGraphView.Units = "Hz," + displ_unit + "(" + displ_detection + ")";
                            }
                        }
                        else
                        {
                            m_objGraphView.Units = "Date And Time,OverAll";
                        }

                    }
                }
            }
            catch { }
        }

        public string CurrentUnit = null; public string strCurrentUnit = null; public string MType = null;
        public string ExtractCurrentUnit()
        {            
            try
            {
                DataTable dt = DbClass.getdata(CommandType.Text, "select * from di_point di inner join type_point tp on tp.ID=di.Type_ID left join point pt on tp.ID=pt.PointType_ID where pt.Point_ID='"+PublicClass.SPointID+"'");
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

        public string getUnitValuesC911()
        {
            try
            {
                if (PublicClass.checkparent == "Acc")
                {
                    m_objGraphView.Units = "Hz,m/s2";
                }
                else if (PublicClass.checkparent == "Vel")
                {
                    m_objGraphView.Units = "Hz,mm/s";
                }
                else
                { m_objGraphView.Units = "Hz,um"; }
            }
            catch { }
            return m_objGraphView.Units;
        }
       
        public void getUnitValues()
        {
            try
            {
                string accel_unit = null;
                string vel_unit = null;
                string displ_unit = null;
                string temprature_unit = null;
                string process_unit = null;
                string accel_detection = null;
                string vel_detection = null;
                string displ_detection = null;
                string time_unit_type = null;
                string power_unit_type = null;
                string demodulate_unit_type = null;
                string pressure_unit = null;
                string current_unit = null;
                string pressure_detection = null;
                string current_detection = null;
                string ordertrace_unit_type = null;
                string cepstrum_unit_type = null;
                string spoint=null;

                if (PublicClass.ssNodeType == "Point")
                {
                    DataTable dt = new DataTable();
                    dt = DbClass.getdata(CommandType.Text, "select PointType_ID from point where point_id='" + PublicClass.SPointID + "'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        spoint = Convert.ToString(dr["PointType_ID"]);
                    }
                    if (spoint != null)
                    {
                        DataTable dt2 = new DataTable();
                        dt2 = DbClass.getdata(CommandType.Text, "select * from units where Type_ID=(select id from type_point where id='" + spoint + "')");
                        //dt2 = DbClass.getdata(CommandType.Text, "select * from units where unit_id=(select tp.unit_id from units un inner join type_point tp on tp.type_id=un.type_id where  tp.id='"+spoint+"')");
                        foreach (DataRow dr2 in dt2.Rows)
                        {
                            try
                            {
                                accel_unit = Convert.ToString(dr2["accel_unit"]);
                                vel_unit = Convert.ToString(dr2["vel_unit"]);
                                displ_unit = Convert.ToString(dr2["displ_unit"]);
                                temprature_unit = Convert.ToString(dr2["temperature_unit"]);
                                process_unit = Convert.ToString(dr2["process_unit"]);
                                accel_detection = Convert.ToString(dr2["accel_detection"]);
                                vel_detection = Convert.ToString(dr2["vel_detection"]);
                                displ_detection = Convert.ToString(dr2["displ_detection"]);
                                time_unit_type = Convert.ToString(dr2["time_unit_type"]);
                                power_unit_type = Convert.ToString(dr2["power_unit_type"]);
                                demodulate_unit_type = Convert.ToString(dr2["demodulate_unit_type"]);
                                pressure_unit = Convert.ToString(dr2["pressure_unit"]);
                                current_unit = Convert.ToString(dr2["current_unit"]);
                                pressure_detection = Convert.ToString(dr2["pressure_detection"]);
                                current_detection = Convert.ToString(dr2["current_detection"]);
                                ordertrace_unit_type = Convert.ToString(dr2["ordertrace_unit_type"]);
                                cepstrum_unit_type = Convert.ToString(dr2["cepstrum_unit_type"]);
                            }
                            catch
                            { }
                        }
                         DataTable dt3 = new DataTable();
                         dt3 = DbClass.getdata(CommandType.Text, "select * from measure where Type_ID='" + spoint + "'");
                        foreach (DataRow dr3 in dt3.Rows)
                        {
                            string overall_bearing_filter = Convert.ToString(dr3["overall_bearing_filter"]);
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
                            accel_detection = "True PK";
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
                            vel_detection = "True PK";
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
                            displ_detection = "True PK";
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

                        if (sGraphname == "Time")
                        {
                            m_objGraphView = new GraphView(this);
                            if (time_unit_type == "0")
                            {
                                m_obj3DGraphControl.Units = "Hz," + accel_unit + "(" + accel_detection + ")";

                                m_objGraphView.Units = "Hz," + accel_unit + "(" + accel_detection + ")";
                            }
                            else if (time_unit_type == "1")
                            {
                                m_objGraphView.Units = "Hz," + vel_unit + "(" + vel_detection + ")";
                            }
                            else if (time_unit_type == "2")
                            {
                                m_objGraphView.Units = "Hz," + displ_unit + "(" + displ_detection + ")";
                            }
                            else if (time_unit_type == "3")
                            {
                                m_objGraphView.Units = "Hz," + pressure_unit + "(" + pressure_detection + ")";
                            }
                            else if (time_unit_type == "4")
                            {
                                m_objGraphView.Units = "Hz," + current_unit + "(" + current_detection + ")";
                            }
                        }
                        else if (sGraphname == "Power" || sGraphname == "Power1" || sGraphname == "Power2" || sGraphname == "Power21" || sGraphname == "Power3" || sGraphname == "Power31")
                        {
                            if (power_unit_type == "0")
                            {
                                m_obj3DGraphControl.Units = "Hz," + accel_unit + "(" + accel_detection + ")";

                               
                                m_objGraphView.Units = "Hz," + accel_unit + "(" + accel_detection + ")";
                            }
                            else if (power_unit_type == "1")
                            {
                                m_objGraphView.Units = "Hz," + vel_unit + "(" + vel_detection + ")";
                            }
                            else if (power_unit_type == "2")
                            {
                                m_objGraphView.Units = "Hz," + displ_unit + "(" + displ_detection + ")";
                            }
                            else if (power_unit_type == "3")
                            {
                                m_objGraphView.Units = "Hz," + pressure_unit + "(" + pressure_detection + ")";
                            }
                            else if (power_unit_type == "4")
                            {
                                m_objGraphView.Units = "Hz," + current_unit + "(" + current_detection + ")";
                            }
                        }
                        else if (sGraphname == "Demodulate")
                        {
                            if (demodulate_unit_type == "0")
                            {
                                m_obj3DGraphControl.Units = "Hz," + accel_unit + "(" + accel_detection + ")";

                                m_objGraphView.Units = "Hz," + accel_unit + "(" + accel_detection + ")";
                            }
                            else if (demodulate_unit_type == "1")
                            {
                                m_objGraphView.Units = "Hz," + vel_unit + "(" + vel_detection + ")";
                            }
                            else if (demodulate_unit_type == "2")
                            {
                                m_objGraphView.Units = "Hz," + displ_unit + "(" + displ_detection + ")";
                            }
                            else if (demodulate_unit_type == "3")
                            {
                                m_objGraphView.Units = "Hz," + pressure_unit + "(" + pressure_detection + ")";
                            }
                            else if (demodulate_unit_type == "4")
                            {
                                m_objGraphView.Units = "Hz," + current_unit + "(" + current_detection + ")";
                            }
                        }
                        else if (sGraphname == "Cepstrum")
                        {
                            if (cepstrum_unit_type == "0")
                            {
                                m_obj3DGraphControl.Units = "Hz," + accel_unit + "(" + accel_detection + ")";

                                m_objGraphView.Units = "Hz," + accel_unit + "(" + accel_detection + ")";
                            }
                            else if (cepstrum_unit_type == "1")
                            {
                                m_objGraphView.Units = "Hz," + vel_unit + "(" + vel_detection + ")";
                            }
                            else if (cepstrum_unit_type == "2")
                            {
                                m_objGraphView.Units = "Hz," + displ_unit + "(" + displ_detection + ")";
                            }
                            else if (cepstrum_unit_type == "3")
                            {
                                m_objGraphView.Units = "Hz," + pressure_unit + "(" + pressure_detection + ")";
                            }
                            else if (cepstrum_unit_type == "4")
                            {
                                m_objGraphView.Units = "Hz," + current_unit + "(" + current_detection + ")";
                            }
                        }
                        else
                        {
                            m_objGraphView.Units = "Date And Time,OverAll";
                        }
                    }
                }
            }
            catch { }
        
        
        }

        private void CreateGraphWithExactParams(ArrayList arrlstData, ArrayList arlstDateTime, ArrayList arlstCounter, string Report)
        {
            try
            {
                if (m_sFocusedNodeChange == "InitializeChart")
                {
                    btnCursor.Enabled = true;
                    btnSetBackColor.Enabled = true;
                    tscbGraphTypes.Enabled = true;
                }

                if (bZoom == true)
                {
                    btnZoom.Enabled = false;
                    btnUnZoom.Enabled = false;
                    tscbGraphTypes.Enabled = false;

                }
                else
                {
                    btnZoom.Enabled = true;
                    btnUnZoom.Enabled = true;
                    tscbGraphTypes.Enabled = true;

                }
               
                m_objMainForm = m_objMainControl.MainForm;
                m_objGraphView.usercontrol = m_objMainControl;
                string sDirection = m_objpointControl.PointDirection;
                lblPointName.Text = "Point Name: " + PublicClass.pointtext + " \nPointDirection: " + sDirection;
                getUnitValues(Report);


                if (bSetTime)
                {
                    m_objGraphView.TimeAxisValue = "Sec";
                }
                else
                {
                    m_objGraphView.TimeAxisValue = "Others";
                }

                m_objGraphView.ParentForm = this;
                m_objGraphView.OverallTrend1 = IfOverallTrend;
                m_objGraphView.InitializeChart(arrlstData, arlstDateTime, arlstCounter);
               
                bool bReportGraph = false;
                bReportGraph = m_objpointControl.Reporting;

                string sCompletePointName = null;
                sCompletePointName = m_objpointControl.ReportingPoint;
                if (bAxial == true && bReportGraph == true)
                {
                    m_objGraphView.SaveReportingImage(sCompletePointName);
                }

            }
            catch (Exception ex)
            {
                
            }
        }

        internal void InitializeGraph(ArrayList arrlstData, ArrayList arlstDateTime, System.Collections.ArrayList arlstCounter)
        {
            try
            {
                if (bOverall)
                {
                    m_objGraphView.OverallTrend1 = true;
                    m_objGraphView.YAxisValue1 = sYAxis;
                    m_objGraphView.DateTimedata = sarrTime;
                }
                else
                {
                    m_objGraphView.OverallTrend1 = false;
                }
                CreateGraphWithExactParams(arrlstData, arlstDateTime, arlstCounter);
               
            }
            catch (Exception ex)
            {
            }
        }


        private void CreateGraphWithExactParams(ArrayList arrlstData, ArrayList arlstDateTime, ArrayList arlstCounter)
        {
            try
            {
                string inst = PublicClass.currentInstrument;
                if (m_sFocusedNodeChange == "InitializeChart")
                {
                    btnCursor.Enabled = true;
                    btnSetBackColor.Enabled = true;
                    //cmbMarkerTypes.Enabled = true;
                    tscbGraphTypes.Enabled = true;
                }

                if (bZoom == true)
                {
                    btnZoom.Enabled = false;
                    btnUnZoom.Enabled = false;
                    tscbGraphTypes.Enabled = false;

                }
                else
                {
                    btnZoom.Enabled = true;
                    btnUnZoom.Enabled = true;
                    tscbGraphTypes.Enabled = true;

                }
                m_objMainForm = m_objMainControl.MainForm;
                m_objGraphView.usercontrol = m_objMainControl;

                string sDirection = m_objpointControl.PointDirection;
                lblPointName.Text = "Point Name: " + PublicClass.pointtext + " \nPointDirection: " + sDirection;
               
                if (inst != "DI-460")
                {
                    getUnitValues();
                }
                

                if (bSetTime)
                {
                    m_objGraphView.TimeAxisValue = "Sec";
                }
                else
                {
                    m_objGraphView.TimeAxisValue = "Others";
                }

                m_objGraphView.ParentForm = this;
                m_objGraphView.OverallTrend1 = IfOverallTrend;
                
                m_objGraphView.InitializeChart(arrlstData, arlstDateTime, arlstCounter);
                
                bool bReportGraph = false;
                bReportGraph = m_objpointControl.Reporting;

                string sCompletePointName = null;
                sCompletePointName = m_objpointControl.ReportingPoint;
                if (bAxial == true && bReportGraph == true)
                {
                    m_objGraphView.SaveReportingImage(sCompletePointName);
                }
                if (bAxial == true)
                {
                    m_objGraphView.SaveReportingImage(sCompletePointName);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        public void ClearDataGrid()
        {
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
            }
        }


        string InstName =PublicClass.currentInstrument;
        double[] m_objarrXValue = null;
        double[] m_objarrYValue = null;
        int igrphctr = 0;
        public void InitializeGraph(double[] arrXValue, double[] arrYValue, string sdatetime, int ixctr,string pnl)
        {
            try
            {
                if (m_obj3DGraphControl != null)
                {
                    scGraphContainer.Panel1.Controls.Remove(m_obj3DGraphControl);
                    scGraphContainer.Panel1.Controls.Add(m_objGraphView);
                    this.Invalidate();
                }

                if (m_sFocusedNodeChange == "InitializeChart")
                {
                    btnCursor.Enabled = true;
                    btnSetBackColor.Enabled = true;
                    tscbGraphTypes.Enabled = true;
                }
                if (m_objpointControl != null)
                {
                    if (m_objpointControl.CopyValueButton == false)
                    {
                        btnValuetoClipBoard.Visible = false;
                    }
                    else
                    {
                        btnValuetoClipBoard.Visible = true;
                    }
                }
                if (bZoom == true)
                {
                    btnZoom.Enabled = false;
                    btnUnZoom.Enabled = false;
                    tscbGraphTypes.Enabled = false;
                }
                else
                {
                    btnZoom.Enabled = true;
                    btnUnZoom.Enabled = true;
                    tscbGraphTypes.Enabled = true;
                }

                m_objarrXValue = arrXValue;
                m_objarrYValue = arrYValue;
                string sDirection = m_objpointControl.PointDirection;
                lblPointName.Text = "Point Name: " + PublicClass.pointtext + " \nPointDirection: " + sDirection;
                if (InstName == "Impaq-Benstone"||InstName=="FieldPaq2")
                {
                    dgvGraphData.Enabled = true;
                    getUnitValues();
                   // m_objpointControl.ExtractUnits();
                }
                else if (InstName == "Kohtect-C911")
                {
                    dgvGraphData.Enabled = false;
                    getUnitValuesC911();
                }
                else if (InstName == "SKF/DI")
                {
                    dgvGraphData.Enabled = false;
                    ExtractCurrentUnit();
                }
                if (bSetTime)
                {
                    if (pnl == "Time")
                    {
                        m_objGraphView.TimeAxisValue = "Sec";
                    }
                    else { m_objGraphView.TimeAxisValue = "Hz"; }
                }
                else
                {
                    m_objGraphView.TimeAxisValue = "Others";
                }
                if (bOverall)
                {
                    m_objGraphView.OverallTrend1 = true;
                    m_objGraphView.YAxisValue1 = sYAxis;
                    m_objGraphView.DateTimedata = sarrTime;
                }
                else
                {
                    m_objGraphView.OverallTrend1 = false;
                }

                m_objGraphView.InitializeChart(arrXValue, arrYValue, sdatetime, ixctr);
                m_objGraphView.ParentForm = this;
                bool bReportGraph = false;
                bReportGraph = m_objpointControl.Reporting;
                string sCompletePointName = null;
                sCompletePointName = m_objpointControl.ReportingPoint;
                if (bAxial == true && bReportGraph == true)
                {
                    m_objGraphView.SaveReportingImage(sCompletePointName);
                }
                else if (bAxial == false)
                    m_objGraphView.usercontrol1 = pg1;
                     m_objGraphView.SaveImage(pnl);

                if (ixctr == 1)
                {
                    igrphctr = 1;
                }
                else if (ixctr == 2)
                {
                    igrphctr = 2;
                }
                else if (ixctr == 3)
                {
                    igrphctr = 3;
                }

            }
            catch { }
        }

    }
}