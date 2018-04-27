using com.iAM.chart2dnet;
using DevExpress.XtraTreeList.Nodes;
using Iadeptmain.BaseUserControl;
using Iadeptmain.GlobalClasses;
using Iadeptmain.Mainforms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iadeptmain.Classes
{
    public partial class MCW
    {
        ImpaqHandler objIHandler = null;        
        frmgraphcontrol m_objGraphControl = null;        
        PointGeneral1 m_PointGeneral1 = null;
        ChartView testingGraph =null;
        private IadeptUserControl m_objMainControl = null;
        public IadeptUserControl usercontrol1
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
       
        public PointGeneral1 Main
        {
            get
            {
                return m_PointGeneral1;
            }
            set
            {
                m_PointGeneral1 = value;
            }
        }


        public ImpaqHandler _ImpaqHandler
        {
            get
            {
                return objIHandler;
            }
            set
            {
                objIHandler = value;
            }
        }
       
        string sTimeVal = null;
        public string TimeVal
        {
            get
            {
                return sTimeVal;
            }
            set
            {
                sTimeVal = value;
            }
        }



        string sPowerVal = null;
        public string PowerVal
        {
            get
            {
                return sPowerVal;
            }
            set
            {
                sPowerVal = value;
            }
        }

        string sPowerVal1 = null;
        public string PowerVal1
        {
            get
            {
                return sPowerVal1;
            }
            set
            {
                sPowerVal1 = value;
            }
        }

        string sPowerVal2 = null;
        public string PowerVal2
        {
            get
            {
                return sPowerVal2;
            }
            set
            {
                sPowerVal2 = value;
            }
        }
        string sPowerVal3 = null;
        public string PowerVal3
        {
            get
            {
                return sPowerVal3;
            }
            set
            {
                sPowerVal3 = value;
            }
        }
        string sPowerVal4 = null;
        public string PowerVal4
        {
            get
            {
                return sPowerVal4;
            }
            set
            {
                sPowerVal4 = value;
            }
        }
        string sPowerVal5 = null;
        public string PowerVal5
        {
            get
            {
                return sPowerVal5;
            }
            set
            {
                sPowerVal5 = value;
            }
        }



        string sDemVal = null;
        public string DemVal
        {
            get
            {
                return sDemVal;
            }
            set
            {
                sDemVal = value;
            }
        }

        string sCepVal = null;
        public string CepVal
        {
            get
            {
                return sCepVal;
            }
            set
            {
                sCepVal = value;
            }
        }


        string sTrendVal = null;
        public string TrendVal
        {
            get
            {
                return sTrendVal;
            }
            set
            {
                sTrendVal = value;
            }
        }
        string sGeneratedAxis = null;
        public string GeneratedAxis
        {
            get
            {
                return sGeneratedAxis;
            }
            set
            {
                sGeneratedAxis = value;
            }
        }


        string sFirstGraph = null; string sFirstPower = null; string sFirstPower1 = null;
        string sFirstPower2 = null; string sFirstPower21 = null; string sFirstPower3 = null;
        string sFirstPower31 = null; string sFirstDemo = null; string sFirstCep = null; string sFirstTrend = null;
        public void FillTrendPanel(string sTime, string sPointID, string pnl)
        {
            int x = 0;
            int iCtr = 0;
            int iCountdata = 0;
            int ActualCount = 0;
            double dvalue = 0;
            int iValue = 0;
            double[] dYData = null;
            double[] dXData = null;
            bool bdataPresent = false;
            string ForUnit = null;
            StringBuilder sbdy = new StringBuilder();
            StringBuilder sbdx = new StringBuilder();

            ArrayList arrTime = new ArrayList();
            ArrayList arrdata = null;
            ArrayList arlstReturnedDoubleValues = null;
            try
            {
                iValue = 4;
                if (sPointID != null)
                {
                    sFirstTrend = PublicClass.Gtrend;
                }
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "Select count(*) from Point_data where point_id='" + sPointID + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    iCountdata = Convert.ToInt32(dr[0]);
                }
                dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                foreach (DataRow dr1 in dt.Rows)
                {
                    dvalue = 0;
                    switch (sFirstTrend)
                    {
                        case "accel_a":
                            {
                                dvalue = Convert.ToDouble(dr1["accel_a"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "accel_h":
                            {
                                dvalue = Convert.ToDouble(dr1["accel_h"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "accel_v":
                            {
                                dvalue = Convert.ToDouble(dr1["accel_v"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "accel_ch1":
                            {
                                dvalue = Convert.ToDouble(dr1["accel_ch1"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "vel_a":
                            {
                                dvalue = Convert.ToDouble(dr1["vel_a"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "vel_h":
                            {
                                dvalue = Convert.ToDouble(dr1["vel_h"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "vel_v":
                            {
                                dvalue = Convert.ToDouble(dr1["vel_v"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "vel_ch1":
                            {
                                dvalue = Convert.ToDouble(dr1["vel_ch1"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "displ_a":
                            {
                                dvalue = Convert.ToDouble(dr1["displ_a"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "displ_h":
                            {
                                dvalue = Convert.ToDouble(dr1["displ_h"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "displ_v":
                            {
                                dvalue = Convert.ToDouble(dr1["displ_v"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "displ_ch1":
                            {
                                dvalue = Convert.ToDouble(dr1["displ_ch1"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "bearing_a":
                            {
                                dvalue = Convert.ToDouble(dr1["bearing_a"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "bearing_h":
                            {
                                dvalue = Convert.ToDouble(dr1["bearing_h"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "bearing_v":
                            {
                                dvalue = Convert.ToDouble(dr1["bearing_v"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "bearing_ch1":
                            {
                                dvalue = Convert.ToDouble(dr1["bearing_ch1"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "temperature":
                            {
                                dvalue = Convert.ToDouble(dr1["temperature"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }

                        case "crest_factor_a":
                            {
                                dvalue = Convert.ToDouble(dr1["crest_factor_a"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "crest_factor_h":
                            {
                                dvalue = Convert.ToDouble(dr1["crest_factor_h"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "crest_factor_v":
                            {
                                dvalue = Convert.ToDouble(dr1["crest_factor_v"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                        case "crest_factor_ch1":
                            {
                                dvalue = Convert.ToDouble(dr1["crest_factor_ch1"]);
                                if (dvalue != 0.0)
                                {
                                    ActualCount += 1;
                                }
                                break;
                            }
                    }
                }
                dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    dvalue = 0;
                    switch (sFirstTrend)
                    {
                        case "accel_a":
                            {
                                dvalue = Convert.ToDouble(dr["accel_a"]);
                                if (dvalue != 0.0)
                                {                                   
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendAcc";
                                }
                                break;
                            }
                        case "accel_h":
                            {
                                dvalue = Convert.ToDouble(dr["accel_h"]);
                                if (dvalue != 0.0)
                                {                                   
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendAcc";
                                }
                                break;
                            }
                        case "accel_v":
                            {
                                dvalue = Convert.ToDouble(dr["accel_v"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendAcc";
                                }
                                break;
                            }
                        case "accel_ch1":
                            {
                                dvalue = Convert.ToDouble(dr["accel_ch1"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendAcc";
                                }
                                break;
                            }
                        case "vel_a":
                            {
                                dvalue = Convert.ToDouble(dr["vel_a"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendVel";
                                }
                                break;
                            }
                        case "vel_h":
                            {
                                dvalue = Convert.ToDouble(dr["vel_h"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendVel";
                                }
                                break;
                            }
                        case "vel_v":
                            {
                                dvalue = Convert.ToDouble(dr["vel_v"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendVel";
                                }
                                break;
                            }
                        case "vel_ch1":
                            {
                                dvalue = Convert.ToDouble(dr["vel_ch1"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendVel";
                                }
                                break;
                            }
                        case "displ_a":
                            {
                                dvalue = Convert.ToDouble(dr["displ_a"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendDisp";
                                }
                                break;
                            }
                        case "displ_h":
                            {
                                dvalue = Convert.ToDouble(dr["displ_h"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendDisp";
                                }
                                break;
                            }
                        case "displ_v":
                            {
                                dvalue = Convert.ToDouble(dr["displ_v"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendDisp";
                                }
                                break;
                            }
                        case "displ_ch1":
                            {
                                dvalue = Convert.ToDouble(dr["displ_ch1"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendDisp";
                                }
                                break;
                            }
                        case "bearing_a":
                            {
                                dvalue = Convert.ToDouble(dr["bearing_a"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendBear";
                                }
                                break;
                            }
                        case "bearing_h":
                            {
                                dvalue = Convert.ToDouble(dr["bearing_h"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendBear";
                                }
                                break;
                            }
                        case "bearing_v":
                            {
                                dvalue = Convert.ToDouble(dr["bearing_v"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendBear";
                                }
                                break;
                            }
                        case "bearing_ch1":
                            {
                                dvalue = Convert.ToDouble(dr["bearing_ch1"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendBear";
                                }
                                break;
                            }
                        case "temperature":
                            {
                                dvalue = Convert.ToDouble(dr["temperature"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "TrendTemp";
                                }
                                break;
                            }

                        case "crest_factor_a":
                            {
                                dvalue = Convert.ToDouble(dr["crest_factor_a"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "Trendcrestfactor";
                                }
                                break;
                            }
                        case "crest_factor_h":
                            {
                                dvalue = Convert.ToDouble(dr["crest_factor_h"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "Trendcrestfactor";
                                }
                                break;
                            }
                        case "crest_factor_v":
                            {
                                dvalue = Convert.ToDouble(dr["crest_factor_v"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "Trendcrestfactor";
                                }
                                break;
                            }
                        case "crest_factor_ch1":
                            {
                                dvalue = Convert.ToDouble(dr["crest_factor_v"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    ForUnit = "Trendcrestfactor";
                                }
                                break;
                            }
                    }

                    if (dvalue != 0.0)
                    {
                        sbdx.Append((x + 1).ToString() + "nn");
                        x += 1;
                    }

                    if (!bdataPresent && dvalue != 0.0)
                    {
                        bdataPresent = true;
                        sTrendVal = "Trend Graph (" + sFirstTrend + ")";
                    }
                    iCtr++;
                }
                //-----------------------//
                if (!bdataPresent)
                {
                    dvalue = 0;
                    x = 0;
                    iCtr = 0;
                    dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                    foreach (DataRow dr in dt.Rows)
                    {
                        dvalue = Convert.ToDouble(dr["accel_a"]);
                        if (dvalue != 0.0)
                        {
                            sbdy.Append(dvalue.ToString() + "nn");
                            sbdx.Append((x + 1).ToString() + "nn");
                            x += 1;
                        }
                        if (!bdataPresent && dvalue != 0.0)
                        {
                            bdataPresent = true;
                            sTrendVal = "Trend Graph (accel_a)";
                            ForUnit = "TrendAcc";
                        }
                        iCtr++;
                    }
                    if (!bdataPresent)
                    {
                        dvalue = 0;
                        x = 0;
                        iCtr = 0;
                        dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                        foreach (DataRow dr in dt.Rows)
                        {
                            dvalue = Convert.ToDouble(dr["accel_h"]);
                            if (dvalue != 0.0)
                            {
                                sbdy.Append(dvalue.ToString() + "nn");
                                sbdx.Append((x + 1).ToString() + "nn");
                                x += 1;
                            }
                            if (!bdataPresent && dvalue != 0.0)
                            {
                                bdataPresent = true;
                                sTrendVal = "Trend Graph (accel_h)";
                                ForUnit = "TrendAcc";
                            }
                            iCtr++;
                        }
                        if (!bdataPresent)
                        {
                            dvalue = 0;
                            x = 0;
                            iCtr = 0;
                            dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                            foreach (DataRow dr in dt.Rows)
                            {
                                dvalue = Convert.ToDouble(dr["accel_v"]);
                                if (dvalue != 0.0)
                                {
                                    sbdy.Append(dvalue.ToString() + "nn");
                                    sbdx.Append((x + 1).ToString() + "nn");
                                    x += 1;
                                }
                                if (!bdataPresent && dvalue != 0.0)
                                {
                                    bdataPresent = true;
                                    sTrendVal = "Trend Graph (accel_v)";
                                    ForUnit = "TrendAcc";
                                }
                                iCtr++;
                            }
                            if (!bdataPresent)
                            {
                                dvalue = 0;
                                x = 0;
                                iCtr = 0;
                                dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                foreach (DataRow dr in dt.Rows)
                                {
                                    dvalue = Convert.ToDouble(dr["vel_a"]);
                                    if (dvalue != 0.0)
                                    {
                                        sbdy.Append(dvalue.ToString() + "nn");
                                        sbdx.Append((x + 1).ToString() + "nn");
                                        x += 1;
                                    }
                                    if (!bdataPresent && dvalue != 0.0)
                                    {
                                        bdataPresent = true;
                                        sTrendVal = "Trend Graph (vel_a)";
                                        ForUnit = "TrendVel";
                                    }
                                    iCtr++;
                                }
                                if (!bdataPresent)
                                {
                                    dvalue = 0;
                                    x = 0;
                                    iCtr = 0;
                                    dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                    foreach (DataRow dr in dt.Rows)
                                    {
                                        dvalue = Convert.ToDouble(dr["vel_h"]);
                                        if (dvalue != 0.0)
                                        {
                                            sbdy.Append(dvalue.ToString() + "nn");
                                            sbdx.Append((x + 1).ToString() + "nn");
                                            x += 1;
                                        }
                                        if (!bdataPresent && dvalue != 0.0)
                                        {
                                            bdataPresent = true;
                                            sTrendVal = "Trend Graph (vel_h)";
                                            ForUnit = "TrendVel";
                                        }
                                        iCtr++;
                                    }
                                    if (!bdataPresent)
                                    {
                                        dvalue = 0;
                                        x = 0;
                                        iCtr = 0;
                                        dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                        foreach (DataRow dr in dt.Rows)
                                        {
                                            dvalue = Convert.ToDouble(dr["vel_v"]);
                                            if (dvalue != 0.0)
                                            {
                                                sbdy.Append(dvalue.ToString() + "nn");
                                                sbdx.Append((x + 1).ToString() + "nn");
                                                x += 1;
                                            }
                                            if (!bdataPresent && dvalue != 0.0)
                                            {
                                                bdataPresent = true;
                                                sTrendVal = "Trend Graph (vel_v)";
                                                ForUnit = "TrendVel";
                                            }
                                            iCtr++;
                                        }
                                        if (!bdataPresent)
                                        {
                                            dvalue = 0;
                                            x = 0;
                                            iCtr = 0;
                                            dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                            foreach (DataRow dr in dt.Rows)
                                            {
                                                dvalue = Convert.ToDouble(dr["displ_a"]);
                                                if (dvalue != 0.0)
                                                {
                                                    sbdy.Append(dvalue.ToString() + "nn");
                                                    sbdx.Append((x + 1).ToString() + "nn");
                                                    x += 1;
                                                }
                                                if (!bdataPresent && dvalue != 0.0)
                                                {
                                                    bdataPresent = true;
                                                    sTrendVal = "Trend Graph (displ_a)";
                                                    ForUnit = "TrendDisp";
                                                }
                                                iCtr++;
                                            }
                                            if (!bdataPresent)
                                            {
                                                dvalue = 0;
                                                x = 0;
                                                iCtr = 0;
                                                dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                                foreach (DataRow dr in dt.Rows)
                                                {
                                                    dvalue = Convert.ToDouble(dr["displ_h"]);
                                                    if (dvalue != 0.0)
                                                    {
                                                        sbdy.Append(dvalue.ToString() + "nn");
                                                        sbdx.Append((x + 1).ToString() + "nn");
                                                        x += 1;
                                                    }
                                                    if (!bdataPresent && dvalue != 0.0)
                                                    {
                                                        bdataPresent = true;
                                                        sTrendVal = "Trend Graph (displ_h)";
                                                        ForUnit = "TrendDisp";
                                                    }
                                                    iCtr++;
                                                }
                                                if (!bdataPresent)
                                                {
                                                    dvalue = 0;
                                                    x = 0;
                                                    iCtr = 0;
                                                    dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                                    foreach (DataRow dr in dt.Rows)
                                                    {
                                                        dvalue = Convert.ToDouble(dr["displ_v"]);
                                                        if (dvalue != 0.0)
                                                        {
                                                            sbdy.Append(dvalue.ToString() + "nn");
                                                            sbdx.Append((x + 1).ToString() + "nn");
                                                            x += 1;
                                                        }
                                                        if (!bdataPresent && dvalue != 0.0)
                                                        {
                                                            bdataPresent = true;
                                                            sTrendVal = "Trend Graph (displ_v)";
                                                            ForUnit = "TrendDisp";
                                                        }
                                                        iCtr++;
                                                    }
                                                    if (!bdataPresent)
                                                    {
                                                        dvalue = 0;
                                                        x = 0;
                                                        iCtr = 0;
                                                        dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                                        foreach (DataRow dr in dt.Rows)
                                                        {
                                                            dvalue = Convert.ToDouble(dr["bearing_a"]);
                                                            if (dvalue != 0.0)
                                                            {
                                                                sbdy.Append(dvalue.ToString() + "nn");
                                                                sbdx.Append((x + 1).ToString() + "nn");
                                                                x += 1;
                                                            }
                                                            if (!bdataPresent && dvalue != 0.0)
                                                            {
                                                                bdataPresent = true;
                                                                sTrendVal = "Trend Graph (bearing_a)";
                                                                ForUnit = "TrendBear";
                                                            }
                                                            iCtr++;
                                                        }
                                                        if (!bdataPresent)
                                                        {
                                                            dvalue = 0;
                                                            x = 0;
                                                            iCtr = 0;
                                                            dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                                            foreach (DataRow dr in dt.Rows)
                                                            {
                                                                dvalue = Convert.ToDouble(dr["bearing_h"]);
                                                                if (dvalue != 0.0)
                                                                {
                                                                    sbdy.Append(dvalue.ToString() + "nn");
                                                                    sbdx.Append((x + 1).ToString() + "nn");
                                                                    x += 1;
                                                                }
                                                                if (!bdataPresent && dvalue != 0.0)
                                                                {
                                                                    bdataPresent = true;
                                                                    sTrendVal = "Trend Graph (bearing_h)";
                                                                    ForUnit = "TrendBear";
                                                                }
                                                                iCtr++;
                                                            }
                                                            if (!bdataPresent)
                                                            {
                                                                dvalue = 0;
                                                                x = 0;
                                                                iCtr = 0;
                                                                dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                                                foreach (DataRow dr in dt.Rows)
                                                                {
                                                                    dvalue = Convert.ToDouble(dr["bearing_v"]);
                                                                    if (dvalue != 0.0)
                                                                    {
                                                                        sbdy.Append(dvalue.ToString() + "nn");
                                                                        sbdx.Append((x + 1).ToString() + "nn");
                                                                        x += 1;
                                                                    }
                                                                    if (!bdataPresent && dvalue != 0.0)
                                                                    {
                                                                        bdataPresent = true;
                                                                        sTrendVal = "Trend Graph (bearing_v)";
                                                                        ForUnit = "TrendBear";
                                                                    }
                                                                    iCtr++;
                                                                }
                                                                if (!bdataPresent)
                                                                {
                                                                    dvalue = 0;
                                                                    x = 0;
                                                                    iCtr = 0;
                                                                    dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                                                    foreach (DataRow dr in dt.Rows)
                                                                    {
                                                                        dvalue = Convert.ToDouble(dr["temperature"]);
                                                                        if (dvalue != 0.0)
                                                                        {
                                                                            sbdy.Append(dvalue.ToString() + "nn");
                                                                            sbdx.Append((x + 1).ToString() + "nn");
                                                                            x += 1;
                                                                        }
                                                                        if (!bdataPresent && dvalue != 0.0)
                                                                        {
                                                                            bdataPresent = true;
                                                                            sTrendVal = "Trend Graph (temperature)";
                                                                            ForUnit = "TrendTemp";
                                                                        }
                                                                        iCtr++;
                                                                    }
                                                                    if (!bdataPresent)
                                                                    {
                                                                        dvalue = 0;
                                                                        x = 0;
                                                                        iCtr = 0;
                                                                        dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                                                        foreach (DataRow dr in dt.Rows)
                                                                        {
                                                                            dvalue = Convert.ToDouble(dr["crest_factor_a"]);
                                                                            if (dvalue != 0.0)
                                                                            {
                                                                                sbdy.Append(dvalue.ToString() + "nn");
                                                                                sbdx.Append((x + 1).ToString() + "nn");
                                                                                x += 1;
                                                                            }
                                                                            if (!bdataPresent && dvalue != 0.0)
                                                                            {
                                                                                bdataPresent = true;
                                                                                sTrendVal = "Trend Graph (crest_factor_a)";
                                                                                ForUnit = "Trendcrestfactor";
                                                                            }
                                                                            iCtr++;
                                                                        }
                                                                        if (!bdataPresent)
                                                                        {
                                                                            dvalue = 0;
                                                                            x = 0;
                                                                            iCtr = 0;
                                                                            dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                                                            foreach (DataRow dr in dt.Rows)
                                                                            {
                                                                                dvalue = Convert.ToDouble(dr["crest_factor_h"]);
                                                                                if (dvalue != 0.0)
                                                                                {
                                                                                    sbdy.Append(dvalue.ToString() + "nn");
                                                                                    sbdx.Append((x + 1).ToString() + "nn");
                                                                                    x += 1;
                                                                                }
                                                                                if (!bdataPresent && dvalue != 0.0)
                                                                                {
                                                                                    bdataPresent = true;
                                                                                    sTrendVal = "Trend Graph (crest_factor_h)";
                                                                                    ForUnit = "Trendcrestfactor";
                                                                                }
                                                                                iCtr++;
                                                                            }
                                                                            if (!bdataPresent)
                                                                            {
                                                                                dvalue = 0;
                                                                                x = 0;
                                                                                iCtr = 0;
                                                                                dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where point_id='" + sPointID + "'");
                                                                                foreach (DataRow dr in dt.Rows)
                                                                                {
                                                                                    dvalue = Convert.ToDouble(dr["crest_factor_v"]);
                                                                                    if (dvalue != 0.0)
                                                                                    {
                                                                                        sbdy.Append(dvalue.ToString() + "nn");
                                                                                        sbdx.Append((x + 1).ToString() + "nn");
                                                                                        x += 1;
                                                                                    }
                                                                                    if (!bdataPresent && dvalue != 0.0)
                                                                                    {
                                                                                        bdataPresent = true;
                                                                                        sTrendVal = "Trend Graph (crest_factor_v)";
                                                                                        ForUnit = "Trendcrestfactor";
                                                                                    }
                                                                                    iCtr++;
                                                                                }                                                                                
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }                                                    
                                                    }
                                                }
                                            }
                                        }                                    
                                    }                                
                                }
                            }                        
                        }
                    }
                }
                if (bdataPresent)
                {
                    string[] sarrayY = sbdy.ToString().Split(new string[] { "nn" }, StringSplitOptions.RemoveEmptyEntries);
                    string[] sarrayX = sbdx.ToString().Split(new string[] { "nn" }, StringSplitOptions.RemoveEmptyEntries);


                    dYData = new double[sarrayY.Length];
                    dXData = new double[sarrayX.Length];
                    for (int i = 0; i < sarrayY.Length; i++)
                    {
                        dXData[i] = Convert.ToDouble(sarrayX[i]);
                        dYData[i] = Convert.ToDouble(sarrayY[i]);
                    }
                    m_PointGeneral1.XData = dXData;
                    m_PointGeneral1.YData = dYData;
                    PublicClass.darrtrendX = dXData;
                    PublicClass.darrtrendY = dYData;
                    m_PointGeneral1.DateTime = sarrTime;
                    if (dYData.Length > 1)
                    {
                        if (PublicClass.trendbool == true)
                        {
                            PublicClass.trendbool = false;
                            return;
                        }
                        if (PublicClass.tym != null)
                        {
                            m_PointGeneral1.RemoveChartObjects();
                            m_PointGeneral1.SetTypeForTime = false;
                            m_PointGeneral1.OverallTrend = true;
                            m_PointGeneral1.Timedata = sarrTime;
                            PublicClass.graphname = pnl;
                            m_PointGeneral1.CreateGraph(dXData, dYData, sTime, iValue, pnl);
                            m_PointGeneral1.OverallTrend = false;
                            PublicClass.checkgraph = true;
                        }
                        else
                        {
                            PublicClass.checkgraph = false;
                        }
                    }
                    else
                    {
                        sTrendVal = "Trend Graph";
                    }
                }
            }
            catch { }
        }



        private void FillTimePanel(string sTime, string sPointID, string pnl)
        {
            int iValue = 0;
            bool bdataPresent = false;
            ArrayList arrTime = new ArrayList();
            ArrayList arrdata = null;
            ArrayList arlstReturnedDoubleValues = null;
            try
            {
                PublicClass.tym = sTime;
                arrTime.Add(sTime);
                switch (pnl)
                {
                    case "Time":
                        iValue = 1;
                        if (sPointID != null)
                        {
                            sFirstGraph = PublicClass.AHVCH1;
                        }

                        arrdata = _ImpaqHandler.GetAllPlotValues(sPointID, "", arrTime, "Time", sFirstGraph);
                        if (arrdata == null || arrdata.Count < 1||arrdata.Count<=0)
                        {
                            sTimeVal = "Time Graph";
                            sGeneratedAxis = sFirstGraph;
                        }

                        else
                        {
                            sTimeVal = "Time Graph (" + sFirstGraph + ")";
                            sGeneratedAxis = sFirstGraph;
                        }
                        break;
                    case "Power":
                        iValue = 2;
                        if (sPointID != null)
                        {
                            sFirstPower = PublicClass.AHVCH1;
                        }
                        arrdata = _ImpaqHandler.GetAllPlotValues(sPointID, "", arrTime, "Power", sFirstPower);

                        if (arrdata == null || arrdata.Count < 1 || arrdata.Count <= 0)
                        {
                            sPowerVal = "Power Graph";
                            sGeneratedAxis = sFirstPower;
                        }
                        else
                        {
                            sPowerVal = "Power Graph (" + sFirstPower + ")";
                            sGeneratedAxis = sFirstPower;
                        }
                        break;
                    case "Power1":
                        iValue = 5;
                        if (sPointID != null)
                        {
                            sFirstPower1 = PublicClass.AHVCH1;
                        }
                        arrdata = _ImpaqHandler.GetAllPlotValues(sPointID, "", arrTime, "Power1", sFirstPower1);


                        if (arrdata == null || arrdata.Count < 1 || arrdata.Count <= 0)
                        {
                            sPowerVal1 = "Power1 Graph";
                            sGeneratedAxis = sFirstPower1;
                        }
                        else
                        {
                            sPowerVal1 = "Power1 Graph (" + sFirstPower1 + ")";
                            sGeneratedAxis = sFirstPower1;
                        }
                        break;
                    case "Power2":
                        iValue = 6;
                        if (sPointID != null)
                        {
                            sFirstPower2 = PublicClass.AHVCH1;
                        }
                        arrdata = _ImpaqHandler.GetAllPlotValues(sPointID, "", arrTime, "Power2", sFirstPower2);

                        if (arrdata == null || arrdata.Count < 1 || arrdata.Count <= 0)
                        {
                            sPowerVal2 = "Power2 Graph";
                            sGeneratedAxis = sFirstPower2;
                        }
                        else
                        {
                            sPowerVal2 = "Power2 Graph (" + sFirstPower2 + ")";
                            sGeneratedAxis = sFirstPower2;
                        }

                        break;


                    case "Power21":
                        iValue = 7;
                        if (sPointID != null)
                        {
                            sFirstPower21 = PublicClass.AHVCH1;
                        }
                        arrdata = _ImpaqHandler.GetAllPlotValues(sPointID, "", arrTime, "Power21", sFirstPower21);


                        if (arrdata == null || arrdata.Count < 1 || arrdata.Count <= 0)
                        {
                            sPowerVal3 = "Power21 Graph";
                            sGeneratedAxis = sFirstPower21;
                        }
                        else
                        {
                            sPowerVal3 = "Power21 Graph (" + sFirstPower21 + ")";
                            sGeneratedAxis = sFirstPower21;
                        }
                        break;

                    case "Power3":
                        iValue = 8;
                        if (sPointID != null)
                        {
                            sFirstPower3 = PublicClass.AHVCH1;
                        }
                        arrdata = _ImpaqHandler.GetAllPlotValues(sPointID, "", arrTime, "Power3", sFirstPower3);


                        if (arrdata == null || arrdata.Count < 1 || arrdata.Count <= 0)
                        {
                            sPowerVal4 = "Power3 Graph";
                            sGeneratedAxis = sFirstPower3;
                        }
                        else
                        {
                            sPowerVal4 = "Power3 Graph (" + sFirstPower3 + ")";
                            sGeneratedAxis = sFirstPower3;
                        }
                        break;

                    case "Power31":
                        iValue = 9;
                        if (sPointID != null)
                        {
                            sFirstPower31 = PublicClass.AHVCH1;
                        }
                        arrdata = _ImpaqHandler.GetAllPlotValues(sPointID, "", arrTime, "Power31", sFirstPower31);


                        if (arrdata == null || arrdata.Count < 1 || arrdata.Count <= 0)
                        {
                            sPowerVal5 = "Power31 Graph";
                            sGeneratedAxis = sFirstPower31;
                        }
                        else
                        {
                            sPowerVal5 = "Power31 Graph (" + sFirstPower31 + ")";
                            sGeneratedAxis = sFirstPower31;
                        }
                        break;

                    case "Demodulate":
                        iValue = 3;
                        if (sPointID != null)
                        {
                            sFirstDemo = PublicClass.AHVCH1;
                        }
                        arrdata = _ImpaqHandler.GetAllPlotValues(sPointID, "", arrTime, "Demodulate", sFirstDemo);


                        if (arrdata == null || arrdata.Count < 1 || arrdata.Count <= 0)
                        {
                            sDemVal = "Demodulate Graph";
                            sGeneratedAxis = sFirstDemo;
                        }
                        else
                        {
                            sDemVal = "Demodulate Graph (" + sFirstDemo + ")";
                            sGeneratedAxis = sFirstDemo;
                        }
                        break;

                    case "Cepstrum":
                        iValue = 10;
                        if (sPointID != null)
                        {
                            sFirstCep = PublicClass.AHVCH1;
                        }
                        arrdata = _ImpaqHandler.GetAllPlotValues(sPointID, "", arrTime, "Cepstrum", sFirstCep);
                        if (arrdata == null || arrdata.Count < 1 || arrdata.Count <= 0)
                        {
                            sCepVal = "Cepstrum Graph";
                            sGeneratedAxis = sFirstCep;
                        }
                        else
                        {
                            sCepVal = "Cepstrum Graph (" + sFirstCep + ")";
                            sGeneratedAxis = sFirstCep;
                        }
                        break;

                }

                if (arrdata != null && arrdata.Count > 1)
                {
                    PublicClass.checkgraph = true;
                    m_PointGeneral1.XData = (double[])arrdata[0];
                    m_PointGeneral1.YData = (double[])arrdata[1];
                    PublicClass.darrXData = (double[])arrdata[0];
                    PublicClass.darrYData = (double[])arrdata[1];

                    m_PointGeneral1.DateTime = arrTime;
                    if (PublicClass.tym != null)
                    {
                        m_PointGeneral1.RemoveChartObjects();
                        m_PointGeneral1.SetTypeForTime = true;

                        PublicClass.graphname = pnl;
                        m_PointGeneral1.CreateGraph((double[])arrdata[0], (double[])arrdata[1], sTime, iValue, pnl);
                    }
                }
                else
                {
                    PublicClass.checkgraph = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        internal ArrayList GetTimefrmOutside(string sPointID, string Graph)
        {
            ArrayList arlstTimeList = null;
            try
            {
                arlstTimeList = GetTime(sPointID, Graph);
                return arlstTimeList;
            }
            catch (Exception ex)
            {
                return arlstTimeList;
            }
        }

        public ArrayList sarrTime = null;
        private ArrayList GetTime(string sPointID, string Graph)
        {
            DataTable dt = new DataTable();
            
            string sTime = null;
            try
            {
                sarrTime = new ArrayList();
                dt = DbClass.getdata(CommandType.Text, "select Measure_time from point_data where point_id='" + PublicClass.SPointID + "'");
                foreach (DataRow dr in dt.Rows)
                {                    
                    sTime = Convert.ToDateTime(dr["Measure_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                    sarrTime.Add(sTime);
                }
            }
            catch (Exception ex)
            {
            }
            return sarrTime;
        }

        ArrayList m_arlstTime = null;
        ArrayList m_arlstTimeValues = null; ArrayList m_arlstTimeValues1 = null;
        internal void FirstClick(String objNode, String Pnl)
        {
            try
            {
                ArrayList arlstTime = null;
                ArrayList arlstTime1 = null;
                string sTime = null;               
                try
                {
                    if (objNode != null)
                    {                       
                            arlstTime = GetTimefrmOutside(PublicClass.SPointID, Pnl);
                            if (arlstTime.Count > 0)
                            {
                                sTime = (string)arlstTime[arlstTime.Count - 1];
                            }
                        
                        if (sTime != null)
                        {
                            if (Pnl == "Time")
                            {
                                FillTimePanel(sTime, PublicClass.SPointID, Pnl);
                            }
                            else if (Pnl == "Power")
                            {
                                FillTimePanel(sTime, PublicClass.SPointID, Pnl);
                            }
                            else if (Pnl == "Power1")
                            {
                                FillTimePanel(sTime, PublicClass.SPointID, Pnl);
                            }
                            else if (Pnl == "Demodulate")
                            {
                                FillTimePanel(sTime, PublicClass.SPointID, Pnl);
                            }
                            else if (Pnl == "Cepstrum")
                            {
                                FillTimePanel(sTime, PublicClass.SPointID, Pnl);
                            }
                            else if (Pnl == "Trend")
                            {
                                FillTrendPanel(sTime, PublicClass.SPointID, Pnl);
                            }                            
                            else if (Pnl == "Power2")
                            {
                                FillTimePanel(sTime, PublicClass.SPointID, Pnl);
                            }
                            else if (Pnl == "Power21")
                            {
                                FillTimePanel(sTime, PublicClass.SPointID, Pnl);
                            }
                            else if (Pnl == "Power3")
                            {
                                FillTimePanel(sTime, PublicClass.SPointID, Pnl);
                            }
                            else if (Pnl == "Power31")
                            {
                                FillTimePanel(sTime, PublicClass.SPointID, Pnl);
                            }
                        }     
                    }       
                }
                catch { }
            }
            catch
            { }


        }

    }
}
