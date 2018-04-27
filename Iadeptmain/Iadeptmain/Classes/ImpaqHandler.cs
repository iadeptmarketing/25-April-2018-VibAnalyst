using ClassesStructs;
using Iadeptmain.GlobalClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iadeptmain.Classes
{
    public partial class ImpaqHandler
    {

        public string TextDec(string Target)
        {
            string FinalEncrypData = null;
            string[] TargetArr = Target.Split(new string[] { "." }, StringSplitOptions.None);
            //byte[] MainByte = Encoding.ASCII.GetBytes(
            StringBuilder Str = null;

            for (int iCtr = 0; iCtr < TargetArr.Length; iCtr++)
            {
                string sText = TargetArr[iCtr].Trim(new char[] { '-', '>' });
            }


            int a = 0;
            if (TargetArr.Length == 1)
                a = TargetArr.Length;
            else
                a = TargetArr.Length - 1;

            Int64[] MainTarget = new Int64[a];
            if (TargetArr.Length == 1)
            {
                for (int i = 0; i < TargetArr.Length; i++)
                {
                    MainTarget[i] = Convert.ToInt64(TargetArr[i]);
                }
            }
            else
            {
                for (int i = 0; i < TargetArr.Length - 1; i++)
                {
                    MainTarget[i] = Convert.ToInt64(TargetArr[i]);
                }
            }
            try
            {
                Str = new StringBuilder();
                for (int i = 0; i < MainTarget.Length; i++)
                {
                    MainTarget[i] = Convert.ToInt64((MainTarget[i] / 63342) - i);
                    string converted = compareVal(MainTarget[i]);
                    Str.Append(converted);

                }
                FinalEncrypData = Convert.ToString(Str);

            }
            catch (Exception ex)
            {
            }
            return FinalEncrypData;
        }

        public string TextEncryption(string Target)
        {
            //Int64 FinalEncrypData = 0;
            if (string.IsNullOrEmpty(Target))
            {
                Target = "0";
            }
            string mm = null;
            char[] TargetMain = Target.ToCharArray();
            byte[] MainByte = Encoding.ASCII.GetBytes(TargetMain);
            Int64[] MainByteInt = new Int64[MainByte.Length];
            StringBuilder Str = null;
            //Target = TextEncryption(Target);
            try
            {
                Str = new StringBuilder();
                for (int i = 0; i < MainByte.Length; i++)
                {
                    MainByteInt[i] = Convert.ToInt64((MainByte[i] + i) * 63342);
                    string converted = Convert.ToString(MainByteInt[i]);
                    Str.Append(converted);
                    Str.Append(".");
                }
                mm = Convert.ToString(Str);
                // FinalEncrypData = 

            }
            catch (Exception ex)
            {
            }
            return mm;
        }
        public string compareVal(Int64 Val)
        {
            string Ans = null;
            try
            {
                switch (Val)
                {
                    case 65: Ans = "A"; break;
                    case 66: Ans = "B"; break;
                    case 67: Ans = "C"; break;
                    case 68: Ans = "D"; break;
                    case 69: Ans = "E"; break;
                    case 70: Ans = "F"; break;
                    case 71: Ans = "G"; break;
                    case 72: Ans = "H"; break;
                    case 73: Ans = "I"; break;
                    case 74: Ans = "J"; break;
                    case 75: Ans = "K"; break;
                    case 76: Ans = "L"; break;
                    case 77: Ans = "M"; break;
                    case 78: Ans = "N"; break;
                    case 79: Ans = "O"; break;
                    case 80: Ans = "P"; break;
                    case 81: Ans = "Q"; break;
                    case 82: Ans = "R"; break;
                    case 83: Ans = "S"; break;
                    case 84: Ans = "T"; break;
                    case 85: Ans = "U"; break;
                    case 86: Ans = "V"; break;
                    case 87: Ans = "W"; break;
                    case 88: Ans = "X"; break;
                    case 89: Ans = "Y"; break;
                    case 90: Ans = "Z"; break;

                    case 97: Ans = "a"; break;
                    case 98: Ans = "b"; break;
                    case 99: Ans = "c"; break;
                    case 100: Ans = "d"; break;
                    case 101: Ans = "e"; break;
                    case 102: Ans = "f"; break;
                    case 103: Ans = "g"; break;
                    case 104: Ans = "h"; break;
                    case 105: Ans = "i"; break;
                    case 106: Ans = "j"; break;
                    case 107: Ans = "k"; break;
                    case 108: Ans = "l"; break;
                    case 109: Ans = "m"; break;
                    case 110: Ans = "n"; break;
                    case 111: Ans = "o"; break;
                    case 112: Ans = "p"; break;
                    case 113: Ans = "q"; break;
                    case 114: Ans = "r"; break;
                    case 115: Ans = "s"; break;
                    case 116: Ans = "t"; break;
                    case 117: Ans = "u"; break;
                    case 118: Ans = "v"; break;
                    case 119: Ans = "w"; break;
                    case 120: Ans = "x"; break;
                    case 121: Ans = "y"; break;
                    case 122: Ans = "z"; break;

                    case 48: Ans = "0"; break;
                    case 49: Ans = "1"; break;
                    case 50: Ans = "2"; break;
                    case 51: Ans = "3"; break;
                    case 52: Ans = "4"; break;
                    case 53: Ans = "5"; break;
                    case 54: Ans = "6"; break;
                    case 55: Ans = "7"; break;
                    case 56: Ans = "8"; break;
                    case 57: Ans = "9"; break;
                    case 32: Ans = " "; break;
                    case 46: Ans = "."; break;
                    case 45: Ans = "-"; break;
                    case 95: Ans = "_"; break;
                    case 44: Ans = ","; break;

                }             


            }
            catch (Exception ex)
            {
            }
            return Ans;
        }
        ArrayList Time = null;
        public ArrayList GetTime
        {
            get
            {
                return Time;
            }

        }
        ArrayList m_arlstSelectedDateTime = new ArrayList();

        public ArrayList SelectedDates
        {
            get
            {
                return m_arlstSelectedDateTime;
            }
        }
        string sCommandText = null;
        private void DataOne(string sPointID, int iArrayCount, ArrayList sSelectedDates, string sDirection,string pnl)
        {           
            try
            {
                DataTable dt = new DataTable();
                string sTimeXFirstData = null;
                string sTimeYFirstData = null;

                //double array Time First
                double[] darrTimeXFirstD = null;
                double[] darrTimeYFirstD = null;

                string sTimeXOverLapH = null;
                string sTimeYOverLapH = null;

                double[] darrTmOlpXH = null;
                double[] darrTmOlpYH = null;


                string sTimeXOverLapV = null;
                string sTimeYOverLapV = null;

                double[] darrTmOlpXV = null;
                double[] darrTmOlpYV = null;

                string sTimeXOverLapCh1 = null;
                string sTimeYOverLapCh1 = null;

                double[] darrTmOlpXCh1 = null;
                double[] darrTmOlpYCh1 = null;


                ArrayList arlstForTimeData = null;
               
                arlstForTimeData = new ArrayList();
                arlstForTimeData.Clear();

                if (PublicClass.ReportStatus)
                {
                    dt = DbClass.getdata(CommandType.Text, "Select * from Point_data where Point_ID='" + PublicClass.SPointID + "'  and Data_ID = '" + PublicClass.Data_ID + "'");
                    PublicClass.ReportStatus = false;
                }
                else
                {
                    sCommandText = CValues.SCNSTQDT + sPointID + "' && (Measure_Time='" + sSelectedDates[0];
                    for (int j = 1; j < iArrayCount; j++)
                    {
                        sCommandText += "'|| Measure_Time='" + sSelectedDates[j];
                    }
                    sCommandText += "' )";

                    dt = DbClass.getdata(CommandType.Text, sCommandText);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    if (pnl == "Time")
                    {
                        switch (sDirection)
                        {
                            case "Axial":

                                sTimeXFirstData = (string)dr["timeA_X"];
                                sTimeYFirstData = (string)dr["timeA_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sAxialDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objExactData.ConvertToDoubleValues();
                                    darrTimeXFirstD = objExactData.darrXValues;
                                    darrTimeYFirstD = objExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sAxialDateTime);

                                }
                                break;
                            case "Horizontal":
                                sTimeXFirstData = (string)dr["timeH_X"];
                                sTimeYFirstData = (string)dr["timeH_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Vertical":
                                sTimeXFirstData = (string)dr["timeV_X"];
                                sTimeYFirstData = (string)dr["timeV_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Channel1":
                                sTimeXFirstData = (string)dr["timeCH1_X"];
                                sTimeYFirstData = (string)dr["timeCH1_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Overlap":
                                if (PublicClass.overlaybool == true)
                                {
                                    if (PublicClass.Axialoverlap == true)
                                    {
                                        sTimeXFirstData = (string)dr["timeA_X"];
                                        sTimeYFirstData = (string)dr["timeA_Y"];
                                    }
                                    if (PublicClass.horoverlap == true)
                                    {
                                        sTimeXOverLapH = (string)dr["timeH_X"];
                                        sTimeYOverLapH = (string)dr["timeH_Y"];
                                    }
                                    if (PublicClass.veroverlap == true)
                                    {
                                        sTimeXOverLapV = (string)dr["timeV_X"];
                                        sTimeYOverLapV = (string)dr["timeV_Y"];
                                    }
                                    if (PublicClass.chanoverlap == true)
                                    {
                                        sTimeXOverLapCh1 = (string)dr["timeCH1_X"];
                                        sTimeYOverLapCh1 = (string)dr["timeCH1_Y"];
                                    }
                                }
                                else
                                {
                                    sTimeXFirstData = (string)dr["timeA_X"];
                                    sTimeYFirstData = (string)dr["timeA_Y"];
                                    sTimeXOverLapH = (string)dr["timeH_X"];
                                    sTimeYOverLapH = (string)dr["timeH_Y"];
                                    sTimeXOverLapV = (string)dr["timeV_X"];
                                    sTimeYOverLapV = (string)dr["timeV_Y"];
                                    sTimeXOverLapCh1 = (string)dr["timeCH1_X"];
                                    sTimeYOverLapCh1 = (string)dr["timeCH1_Y"];
                                    PublicClass.Axialoverlap = true;
                                    PublicClass.horoverlap = true;
                                    PublicClass.veroverlap = true;
                                    PublicClass.chanoverlap = true;
                                }
                                string sOlpDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                GetExactData objOlpDataA = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                objOlpDataA.ConvertToDoubleValues();

                                darrTimeXFirstD = objOlpDataA.darrXValues;
                                darrTimeYFirstD = objOlpDataA.darrYValues;
                                if (PublicClass.Axialoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);
                                }

                              
                                GetExactData objOlpDataH = new GetExactData(sTimeXOverLapH, sTimeYOverLapH, null, null, null, null);
                                objOlpDataH.ConvertToDoubleValues();

                                darrTmOlpXH = objOlpDataH.darrXValues;
                                darrTmOlpYH = objOlpDataH.darrYValues;
                                if (PublicClass.horoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXH);
                                    arlstForTimeData.Add(darrTmOlpYH);
                                }
                                GetExactData objOlpDataV = new GetExactData(sTimeXOverLapV, sTimeYOverLapV, null, null, null, null);
                                objOlpDataV.ConvertToDoubleValues();

                                darrTmOlpXV = objOlpDataV.darrXValues;
                                darrTmOlpYV = objOlpDataV.darrYValues;
                                if (PublicClass.veroverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXV);
                                    arlstForTimeData.Add(darrTmOlpYV);
                                }
                               
                                GetExactData objOlpDataCh1 = new GetExactData(sTimeXOverLapCh1, sTimeYOverLapCh1, null, null, null, null);
                                objOlpDataCh1.ConvertToDoubleValues();

                                darrTmOlpXCh1 = objOlpDataCh1.darrXValues;
                                darrTmOlpYCh1 = objOlpDataCh1.darrYValues;
                                if (PublicClass.chanoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXCh1);
                                    arlstForTimeData.Add(darrTmOlpYCh1);
                                }

                                m_arlstSelectedDateTime.Add(sOlpDateTime);
                                break;
                        }
                    }
                    if (pnl == "Power"||pnl=="Power1"||pnl=="Power2"||pnl=="Power21"||pnl=="Power3"||pnl=="Power31")
                    {
                        switch (sDirection)
                        {
                            case "Axial":
                                if (pnl == "Power")
                                {
                                    sTimeXFirstData = (string)dr["PA_X"];
                                    sTimeYFirstData = (string)dr["PA_Y"];
                                }
                                if (pnl == "Power1")
                                {
                                    sTimeXFirstData = (string)dr["P1A_X"];
                                    sTimeYFirstData = (string)dr["P1A_Y"];
                                }
                                if (pnl == "Power2")
                                {
                                    sTimeXFirstData = (string)dr["P2A_X"];
                                    sTimeYFirstData = (string)dr["P2A_Y"];
                                }
                                if (pnl == "Power21")
                                {
                                    sTimeXFirstData = (string)dr["P21A_X"];
                                    sTimeYFirstData = (string)dr["P21A_Y"];
                                }
                                if (pnl == "Power3")
                                {
                                    sTimeXFirstData = (string)dr["P3A_X"];
                                    sTimeYFirstData = (string)dr["P3A_Y"];
                                }
                                if (pnl == "Power31")
                                {
                                    sTimeXFirstData = (string)dr["P31A_X"];
                                    sTimeYFirstData = (string)dr["P31A_Y"];
                                }
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sAxialDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objExactData.ConvertToDoubleValues();
                                    darrTimeXFirstD = objExactData.darrXValues;
                                    darrTimeYFirstD = objExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sAxialDateTime);

                                }
                                break;
                            case "Horizontal":
                                if (pnl == "Power")
                                {
                                    sTimeXFirstData = (string)dr["PH_X"];
                                    sTimeYFirstData = (string)dr["PH_Y"];
                                }
                                if (pnl == "Power1")
                                {
                                    sTimeXFirstData = (string)dr["P1H_X"];
                                    sTimeYFirstData = (string)dr["P1H_Y"];
                                }
                                if (pnl == "Power2")
                                {
                                    sTimeXFirstData = (string)dr["P2H_X"];
                                    sTimeYFirstData = (string)dr["P2H_Y"];
                                }
                                if (pnl == "Power21")
                                {
                                    sTimeXFirstData = (string)dr["P21H_X"];
                                    sTimeYFirstData = (string)dr["P21H_Y"];
                                }
                                if (pnl == "Power3")
                                {
                                    sTimeXFirstData = (string)dr["P3H_X"];
                                    sTimeYFirstData = (string)dr["P3H_Y"];
                                }
                                if (pnl == "Power31")
                                {
                                    sTimeXFirstData = (string)dr["P31H_X"];
                                    sTimeYFirstData = (string)dr["P31H_Y"];
                                }
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Vertical":
                                if (pnl == "Power")
                                {
                                    sTimeXFirstData = (string)dr["PV_X"];
                                    sTimeYFirstData = (string)dr["PV_Y"];
                                }
                                if (pnl == "Power1")
                                {
                                    sTimeXFirstData = (string)dr["P1V_X"];
                                    sTimeYFirstData = (string)dr["P1V_Y"];
                                }
                                if (pnl == "Power2")
                                {
                                    sTimeXFirstData = (string)dr["P2V_X"];
                                    sTimeYFirstData = (string)dr["P2V_Y"];
                                }
                                if (pnl == "Power21")
                                {
                                    sTimeXFirstData = (string)dr["P21V_X"];
                                    sTimeYFirstData = (string)dr["P21V_Y"];
                                }
                                if (pnl == "Power3")
                                {
                                    sTimeXFirstData = (string)dr["P3V_X"];
                                    sTimeYFirstData = (string)dr["P3V_Y"];
                                }
                                if (pnl == "Power31")
                                {
                                    sTimeXFirstData = (string)dr["P31V_X"];
                                    sTimeYFirstData = (string)dr["P31V_Y"];
                                }
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Channel1":
                                if (pnl == "Power")
                                {
                                    sTimeXFirstData = (string)dr["PCH1_X"];
                                    sTimeYFirstData = (string)dr["PCH1_Y"];
                                }
                                if (pnl == "Power1")
                                {
                                    sTimeXFirstData = (string)dr["P1CH1_X"];
                                    sTimeYFirstData = (string)dr["P1CH1_Y"];
                                }
                                if (pnl == "Power2")
                                {
                                    sTimeXFirstData = (string)dr["P2CH1_X"];
                                    sTimeYFirstData = (string)dr["P2CH1_Y"];
                                }
                                if (pnl == "Power21")
                                {
                                    sTimeXFirstData = (string)dr["P21CH1_X"];
                                    sTimeYFirstData = (string)dr["P21CH1_Y"];
                                }
                                if (pnl == "Power3")
                                {
                                    sTimeXFirstData = (string)dr["P3CH1_X"];
                                    sTimeYFirstData = (string)dr["P3CH1_Y"];
                                }
                                if (pnl == "Power31")
                                {
                                    sTimeXFirstData = (string)dr["P31CH1_X"];
                                    sTimeYFirstData = (string)dr["P31CH1_Y"];
                                }
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;

                            case "Overlap":
                                if (pnl == "Power")
                                {
                                    if (PublicClass.overlaybool == true)
                                    {
                                        if (PublicClass.Axialoverlap == true)
                                        {
                                            sTimeXFirstData = (string)dr["PA_X"];
                                            sTimeYFirstData = (string)dr["PA_Y"];
                                        }
                                        else
                                        {
                                            sTimeXFirstData = "0|";
                                            sTimeYFirstData = "";
                                        }
                                        if (PublicClass.horoverlap == true)
                                        {
                                            sTimeXOverLapH = (string)dr["PH_X"];
                                            sTimeYOverLapH = (string)dr["PH_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapH = "0|";
                                            sTimeYOverLapH = "";
                                        }

                                        if (PublicClass.veroverlap == true)
                                        {
                                            sTimeXOverLapV = (string)dr["PV_X"];
                                            sTimeYOverLapV = (string)dr["PV_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapV = "0|";
                                            sTimeYOverLapV = "";
                                        }
                                        if (PublicClass.chanoverlap == true)
                                        {
                                            sTimeXOverLapCh1 = (string)dr["PCH1_X"];
                                            sTimeYOverLapCh1 = (string)dr["PCH1_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapCh1 = "0|";
                                            sTimeYOverLapCh1 = "";
                                        }
                                    }
                                    else
                                    {
                                        sTimeXFirstData = (string)dr["PA_X"];
                                        sTimeYFirstData = (string)dr["PA_Y"];

                                        sTimeXOverLapH = (string)dr["PH_X"];
                                        sTimeYOverLapH = (string)dr["PH_Y"];

                                        sTimeXOverLapV = (string)dr["PV_X"];
                                        sTimeYOverLapV = (string)dr["PV_Y"];

                                        sTimeXOverLapCh1 = (string)dr["PCH1_X"];
                                        sTimeYOverLapCh1 = (string)dr["PCH1_Y"];
                                        PublicClass.Axialoverlap = true;
                                        PublicClass.horoverlap = true;
                                        PublicClass.veroverlap = true;
                                        PublicClass.chanoverlap = true;
                                    }
                                }

                                if (pnl == "Power1")
                                {
                                    if (PublicClass.overlaybool == true)
                                    {
                                        if (PublicClass.Axialoverlap == true)
                                        {
                                            sTimeXFirstData = (string)dr["P1A_X"];
                                            sTimeYFirstData = (string)dr["P1A_Y"];
                                        }
                                        else
                                        {
                                            sTimeXFirstData = "0|";
                                            sTimeYFirstData = "";
                                        }
                                        if (PublicClass.horoverlap == true)
                                        {
                                            sTimeXOverLapH = (string)dr["P1H_X"];
                                            sTimeYOverLapH = (string)dr["P1H_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapH = "0|";
                                            sTimeYOverLapH = "";
                                        }

                                        if (PublicClass.veroverlap == true)
                                        {
                                            sTimeXOverLapV = (string)dr["P1V_X"];
                                            sTimeYOverLapV = (string)dr["P1V_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapV = "0|";
                                            sTimeYOverLapV = "";
                                        }
                                        if (PublicClass.chanoverlap == true)
                                        {
                                            sTimeXOverLapCh1 = (string)dr["P1CH1_X"];
                                            sTimeYOverLapCh1 = (string)dr["P1CH1_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapCh1 = "0|";
                                            sTimeYOverLapCh1 = "";
                                        }
                                    }
                                    else
                                    {
                                        sTimeXFirstData = (string)dr["P1A_X"];
                                        sTimeYFirstData = (string)dr["P1A_Y"];

                                        sTimeXOverLapH = (string)dr["P1H_X"];
                                        sTimeYOverLapH = (string)dr["P1H_Y"];

                                        sTimeXOverLapV = (string)dr["P1V_X"];
                                        sTimeYOverLapV = (string)dr["P1V_Y"];

                                        sTimeXOverLapCh1 = (string)dr["P1CH1_X"];
                                        sTimeYOverLapCh1 = (string)dr["P1CH1_Y"];
                                        PublicClass.Axialoverlap = true;
                                        PublicClass.horoverlap = true;
                                        PublicClass.veroverlap = true;
                                        PublicClass.chanoverlap = true;
                                    }
                                }
                                if (pnl == "Power2")
                                {
                                    if (PublicClass.overlaybool == true)
                                    {
                                        if (PublicClass.Axialoverlap == true)
                                        {
                                            sTimeXFirstData = (string)dr["P2A_X"];
                                            sTimeYFirstData = (string)dr["P2A_Y"];
                                        }
                                        else
                                        {
                                            sTimeXFirstData = "0|";
                                            sTimeYFirstData = "";
                                        }
                                        if (PublicClass.horoverlap == true)
                                        {
                                            sTimeXOverLapH = (string)dr["P2H_X"];
                                            sTimeYOverLapH = (string)dr["P2H_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapH = "0|";
                                            sTimeYOverLapH = "";
                                        }

                                        if (PublicClass.veroverlap == true)
                                        {
                                            sTimeXOverLapV = (string)dr["P2V_X"];
                                            sTimeYOverLapV = (string)dr["P2V_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapV = "0|";
                                            sTimeYOverLapV = "";
                                        }
                                        if (PublicClass.chanoverlap == true)
                                        {
                                            sTimeXOverLapCh1 = (string)dr["P2CH1_X"];
                                            sTimeYOverLapCh1 = (string)dr["P2CH1_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapCh1 = "0|";
                                            sTimeYOverLapCh1 = "";
                                        }
                                    }
                                    else
                                    {
                                        sTimeXFirstData = (string)dr["P2A_X"];
                                        sTimeYFirstData = (string)dr["P2A_Y"];

                                        sTimeXOverLapH = (string)dr["P2H_X"];
                                        sTimeYOverLapH = (string)dr["P2H_Y"];

                                        sTimeXOverLapV = (string)dr["P2V_X"];
                                        sTimeYOverLapV = (string)dr["P2V_Y"];

                                        sTimeXOverLapCh1 = (string)dr["P2CH1_X"];
                                        sTimeYOverLapCh1 = (string)dr["P2CH1_Y"];
                                        PublicClass.Axialoverlap = true;
                                        PublicClass.horoverlap = true;
                                        PublicClass.veroverlap = true;
                                        PublicClass.chanoverlap = true;
                                    }
                                }
                                if (pnl == "Power21")
                                {
                                    if (PublicClass.overlaybool == true)
                                    {
                                        if (PublicClass.Axialoverlap == true)
                                        {
                                            sTimeXFirstData = (string)dr["P21A_X"];
                                            sTimeYFirstData = (string)dr["P21A_Y"];
                                        }
                                        else
                                        {
                                            sTimeXFirstData = "0|";
                                            sTimeYFirstData = "";
                                        }
                                        if (PublicClass.horoverlap == true)
                                        {
                                            sTimeXOverLapH = (string)dr["P21H_X"];
                                            sTimeYOverLapH = (string)dr["P21H_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapH = "0|";
                                            sTimeYOverLapH = "";
                                        }

                                        if (PublicClass.veroverlap == true)
                                        {
                                            sTimeXOverLapV = (string)dr["P21V_X"];
                                            sTimeYOverLapV = (string)dr["P21V_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapV = "0|";
                                            sTimeYOverLapV = "";
                                        }
                                        if (PublicClass.chanoverlap == true)
                                        {
                                            sTimeXOverLapCh1 = (string)dr["P21CH1_X"];
                                            sTimeYOverLapCh1 = (string)dr["P21CH1_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapCh1 = "0|";
                                            sTimeYOverLapCh1 = "";
                                        }
                                    }
                                    else
                                    {
                                        sTimeXFirstData = (string)dr["P21A_X"];
                                        sTimeYFirstData = (string)dr["P21A_Y"];

                                        sTimeXOverLapH = (string)dr["P21H_X"];
                                        sTimeYOverLapH = (string)dr["P21H_Y"];

                                        sTimeXOverLapV = (string)dr["P21V_X"];
                                        sTimeYOverLapV = (string)dr["P21V_Y"];

                                        sTimeXOverLapCh1 = (string)dr["P21CH1_X"];
                                        sTimeYOverLapCh1 = (string)dr["P21CH1_Y"];
                                        PublicClass.Axialoverlap = true;
                                        PublicClass.horoverlap = true;
                                        PublicClass.veroverlap = true;
                                        PublicClass.chanoverlap = true;
                                    }
                                }
                                if (pnl == "Power3")
                                {
                                    if (PublicClass.overlaybool == true)
                                    {
                                        if (PublicClass.Axialoverlap == true)
                                        {
                                            sTimeXFirstData = (string)dr["P3A_X"];
                                            sTimeYFirstData = (string)dr["P3A_Y"];
                                        }
                                        else
                                        {
                                            sTimeXFirstData = "0|";
                                            sTimeYFirstData = "";
                                        }
                                        if (PublicClass.horoverlap == true)
                                        {
                                            sTimeXOverLapH = (string)dr["P3H_X"];
                                            sTimeYOverLapH = (string)dr["P3H_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapH = "0|";
                                            sTimeYOverLapH = "";
                                        }

                                        if (PublicClass.veroverlap == true)
                                        {
                                            sTimeXOverLapV = (string)dr["P3V_X"];
                                            sTimeYOverLapV = (string)dr["P3V_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapV = "0|";
                                            sTimeYOverLapV = "";
                                        }
                                        if (PublicClass.chanoverlap == true)
                                        {
                                            sTimeXOverLapCh1 = (string)dr["P3CH1_X"];
                                            sTimeYOverLapCh1 = (string)dr["P3CH1_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapCh1 = "0|";
                                            sTimeYOverLapCh1 = "";
                                        }
                                    }
                                    else
                                    {
                                        sTimeXFirstData = (string)dr["P3A_X"];
                                        sTimeYFirstData = (string)dr["P3A_Y"];

                                        sTimeXOverLapH = (string)dr["P3H_X"];
                                        sTimeYOverLapH = (string)dr["P3H_Y"];

                                        sTimeXOverLapV = (string)dr["P3V_X"];
                                        sTimeYOverLapV = (string)dr["P3V_Y"];

                                        sTimeXOverLapCh1 = (string)dr["P3CH1_X"];
                                        sTimeYOverLapCh1 = (string)dr["P3CH1_Y"];
                                        PublicClass.Axialoverlap = true;
                                        PublicClass.horoverlap = true;
                                        PublicClass.veroverlap = true;
                                        PublicClass.chanoverlap = true;
                                    }
                                }
                                if (pnl == "Power31")
                                {
                                    if (PublicClass.overlaybool == true)
                                    {
                                        if (PublicClass.Axialoverlap == true)
                                        {
                                            sTimeXFirstData = (string)dr["P31A_X"];
                                            sTimeYFirstData = (string)dr["P31A_Y"];
                                        }
                                        else
                                        {
                                            sTimeXFirstData = "0|";
                                            sTimeYFirstData = "";
                                        }
                                        if (PublicClass.horoverlap == true)
                                        {
                                            sTimeXOverLapH = (string)dr["P31H_X"];
                                            sTimeYOverLapH = (string)dr["P31H_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapH = "0|";
                                            sTimeYOverLapH = "";
                                        }

                                        if (PublicClass.veroverlap == true)
                                        {
                                            sTimeXOverLapV = (string)dr["P31V_X"];
                                            sTimeYOverLapV = (string)dr["P31V_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapV = "0|";
                                            sTimeYOverLapV = "";
                                        }
                                        if (PublicClass.chanoverlap == true)
                                        {
                                            sTimeXOverLapCh1 = (string)dr["P31CH1_X"];
                                            sTimeYOverLapCh1 = (string)dr["P31CH1_Y"];
                                        }
                                        else
                                        {
                                            sTimeXOverLapCh1 = "0|";
                                            sTimeYOverLapCh1 = "";
                                        }
                                    }
                                    else
                                    {                                      
                                        sTimeXFirstData = (string)dr["P31A_X"];
                                        sTimeYFirstData = (string)dr["P31A_Y"];

                                        sTimeXOverLapH = (string)dr["P31H_X"];
                                        sTimeYOverLapH = (string)dr["P31H_Y"];

                                        sTimeXOverLapV = (string)dr["P31V_X"];
                                        sTimeYOverLapV = (string)dr["P31V_Y"];

                                        sTimeXOverLapCh1 = (string)dr["P31CH1_X"];
                                        sTimeYOverLapCh1 = (string)dr["P31CH1_Y"];
                                        PublicClass.Axialoverlap = true;
                                        PublicClass.horoverlap = true;
                                        PublicClass.veroverlap = true;
                                        PublicClass.chanoverlap = true;
                                    }
                                }


                                string sOlpDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                GetExactData objOlpDataA = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                objOlpDataA.ConvertToDoubleValues();

                                darrTimeXFirstD = objOlpDataA.darrXValues;
                                darrTimeYFirstD = objOlpDataA.darrYValues;

                                if (PublicClass.Axialoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);
                                }
                                

                                GetExactData objOlpDataH = new GetExactData(sTimeXOverLapH, sTimeYOverLapH, null, null, null, null);
                                objOlpDataH.ConvertToDoubleValues();

                                darrTmOlpXH = objOlpDataH.darrXValues;
                                darrTmOlpYH = objOlpDataH.darrYValues;
                                if (PublicClass.horoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXH);
                                    arlstForTimeData.Add(darrTmOlpYH);
                                }
                                


                                GetExactData objOlpDataV = new GetExactData(sTimeXOverLapV, sTimeYOverLapV, null, null, null, null);
                                objOlpDataV.ConvertToDoubleValues();

                                darrTmOlpXV = objOlpDataV.darrXValues;
                                darrTmOlpYV = objOlpDataV.darrYValues;

                                if (PublicClass.veroverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXV);
                                    arlstForTimeData.Add(darrTmOlpYV);
                                }
                              


                                GetExactData objOlpDataCh1 = new GetExactData(sTimeXOverLapCh1, sTimeYOverLapCh1, null, null, null, null);
                                objOlpDataCh1.ConvertToDoubleValues();

                                darrTmOlpXCh1 = objOlpDataCh1.darrXValues;
                                darrTmOlpYCh1 = objOlpDataCh1.darrYValues;

                                if (PublicClass.chanoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXCh1);
                                    arlstForTimeData.Add(darrTmOlpYCh1);
                                }
                               
                                m_arlstSelectedDateTime.Add(sOlpDateTime);

                                break;

                        }
                    }
                    if (pnl == "Demodulate")
                    {
                        switch (sDirection)
                        {
                            case "Axial":

                                sTimeXFirstData = (string)dr["DEMA_X"];
                                sTimeYFirstData = (string)dr["DEMA_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sAxialDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objExactData.ConvertToDoubleValues();
                                    darrTimeXFirstD = objExactData.darrXValues;
                                    darrTimeYFirstD = objExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sAxialDateTime);

                                }
                                break;
                            case "Horizontal":
                                sTimeXFirstData = (string)dr["DEMH_X"];
                                sTimeYFirstData = (string)dr["DEMH_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Vertical":
                                sTimeXFirstData = (string)dr["DEMV_X"];
                                sTimeYFirstData = (string)dr["DEMV_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Channel1":
                                sTimeXFirstData = (string)dr["DEMCH1_X"];
                                sTimeYFirstData = (string)dr["DEMCH1_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Overlap":
                                if (PublicClass.overlaybool == true)
                                {
                                    if (PublicClass.Axialoverlap == true)
                                    {
                                        sTimeXFirstData = (string)dr["DEMA_X"];
                                        sTimeYFirstData = (string)dr["DEMA_Y"];
                                    }
                                    if (PublicClass.horoverlap == true)
                                    {
                                        sTimeXOverLapH = (string)dr["DEMH_X"];
                                        sTimeYOverLapH = (string)dr["DEMH_Y"];
                                    }
                                    if (PublicClass.veroverlap == true)
                                    {
                                        sTimeXOverLapV = (string)dr["DEMV_X"];
                                        sTimeYOverLapV = (string)dr["DEMV_Y"];
                                    }
                                    if (PublicClass.chanoverlap == true)
                                    {
                                        sTimeXOverLapCh1 = (string)dr["DEMCH1_X"];
                                        sTimeYOverLapCh1 = (string)dr["DEMCH1_Y"];
                                    }
                                }
                                else
                                {
                                    sTimeXFirstData = (string)dr["DEMA_X"];
                                    sTimeYFirstData = (string)dr["DEMA_Y"];
                                    sTimeXOverLapH = (string)dr["DEMH_X"];
                                    sTimeYOverLapH = (string)dr["DEMH_Y"];
                                    sTimeXOverLapV = (string)dr["DEMV_X"];
                                    sTimeYOverLapV = (string)dr["DEMV_Y"];
                                    sTimeXOverLapCh1 = (string)dr["DEMCH1_X"];
                                    sTimeYOverLapCh1 = (string)dr["DEMCH1_Y"];
                                    PublicClass.Axialoverlap = true;
                                    PublicClass.horoverlap = true;
                                    PublicClass.veroverlap = true;
                                    PublicClass.chanoverlap = true;
                                }
                                string sOlpDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                GetExactData objOlpDataA = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                objOlpDataA.ConvertToDoubleValues();

                                darrTimeXFirstD = objOlpDataA.darrXValues;
                                darrTimeYFirstD = objOlpDataA.darrYValues;

                                if (PublicClass.Axialoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);
                                }

                             
                                GetExactData objOlpDataH = new GetExactData(sTimeXOverLapH, sTimeYOverLapH, null, null, null, null);
                                objOlpDataH.ConvertToDoubleValues();

                                darrTmOlpXH = objOlpDataH.darrXValues;
                                darrTmOlpYH = objOlpDataH.darrYValues;
                                if (PublicClass.horoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXH);
                                    arlstForTimeData.Add(darrTmOlpYH);
                                }

                              
                                GetExactData objOlpDataV = new GetExactData(sTimeXOverLapV, sTimeYOverLapV, null, null, null, null);
                                objOlpDataV.ConvertToDoubleValues();

                                darrTmOlpXV = objOlpDataV.darrXValues;
                                darrTmOlpYV = objOlpDataV.darrYValues;
                                if (PublicClass.veroverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXV);
                                    arlstForTimeData.Add(darrTmOlpYV);
                                }

                             
                                GetExactData objOlpDataCh1 = new GetExactData(sTimeXOverLapCh1, sTimeYOverLapCh1, null, null, null, null);
                                objOlpDataCh1.ConvertToDoubleValues();

                                darrTmOlpXCh1 = objOlpDataCh1.darrXValues;
                                darrTmOlpYCh1 = objOlpDataCh1.darrYValues;
                                if (PublicClass.chanoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXCh1);
                                    arlstForTimeData.Add(darrTmOlpYCh1);
                                }

                                m_arlstSelectedDateTime.Add(sOlpDateTime);
                                break;
                        }
                    }

                    if (pnl == "Cepstrum")
                    {
                        switch (sDirection)
                        {
                            case "Axial":

                                sTimeXFirstData = (string)dr["CEPA_X"];
                                sTimeYFirstData = (string)dr["CEPA_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sAxialDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objExactData.ConvertToDoubleValues();
                                    darrTimeXFirstD = objExactData.darrXValues;
                                    darrTimeYFirstD = objExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sAxialDateTime);

                                }
                                break;
                            case "Horizontal":
                                sTimeXFirstData = (string)dr["CEPH_X"];
                                sTimeYFirstData = (string)dr["CEPH_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Vertical":
                                sTimeXFirstData = (string)dr["CEPV_X"];
                                sTimeYFirstData = (string)dr["CEPV_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Channel1":
                                sTimeXFirstData = (string)dr["CEPCH1_X"];
                                sTimeYFirstData = (string)dr["CEPCH1_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Overlap":
                                if (PublicClass.overlaybool == true)
                                {
                                    if (PublicClass.Axialoverlap == true)
                                    {
                                        sTimeXFirstData = (string)dr["CEPA_X"];
                                        sTimeYFirstData = (string)dr["CEPA_Y"];
                                    }
                                    if (PublicClass.horoverlap == true)
                                    {
                                        sTimeXOverLapH = (string)dr["CEPH_X"];
                                        sTimeYOverLapH = (string)dr["CEPH_Y"];
                                    }
                                    if (PublicClass.veroverlap == true)
                                    {
                                        sTimeXOverLapV = (string)dr["CEPV_X"];
                                        sTimeYOverLapV = (string)dr["CEPV_Y"];
                                    }
                                    if (PublicClass.chanoverlap == true)
                                    {
                                        sTimeXOverLapCh1 = (string)dr["CEPCH1_X"];
                                        sTimeYOverLapCh1 = (string)dr["CEPCH1_Y"];
                                    }
                                }
                                else
                                {
                                    sTimeXFirstData = (string)dr["CEPA_X"];
                                    sTimeYFirstData = (string)dr["CEPA_Y"];
                                    sTimeXOverLapH = (string)dr["CEPH_X"];
                                    sTimeYOverLapH = (string)dr["CEPH_Y"];
                                    sTimeXOverLapV = (string)dr["CEPV_X"];
                                    sTimeYOverLapV = (string)dr["CEPV_Y"];
                                    sTimeXOverLapCh1 = (string)dr["CEPCH1_X"];
                                    sTimeYOverLapCh1 = (string)dr["CEPCH1_Y"];
                                    PublicClass.Axialoverlap = true;
                                    PublicClass.horoverlap = true;
                                    PublicClass.veroverlap = true;
                                    PublicClass.chanoverlap = true;
                                }
                                string sOlpDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                GetExactData objOlpDataA = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                objOlpDataA.ConvertToDoubleValues();

                                darrTimeXFirstD = objOlpDataA.darrXValues;
                                darrTimeYFirstD = objOlpDataA.darrYValues;
                                if (PublicClass.Axialoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);
                                }

                               
                                GetExactData objOlpDataH = new GetExactData(sTimeXOverLapH, sTimeYOverLapH, null, null, null, null);
                                objOlpDataH.ConvertToDoubleValues();

                                darrTmOlpXH = objOlpDataH.darrXValues;
                                darrTmOlpYH = objOlpDataH.darrYValues;
                                if (PublicClass.horoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXH);
                                    arlstForTimeData.Add(darrTmOlpYH);
                                }

                              
                                GetExactData objOlpDataV = new GetExactData(sTimeXOverLapV, sTimeYOverLapV, null, null, null, null);
                                objOlpDataV.ConvertToDoubleValues();

                                darrTmOlpXV = objOlpDataV.darrXValues;
                                darrTmOlpYV = objOlpDataV.darrYValues;
                                if (PublicClass.veroverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXV);
                                    arlstForTimeData.Add(darrTmOlpYV);
                                }

                                
                                GetExactData objOlpDataCh1 = new GetExactData(sTimeXOverLapCh1, sTimeYOverLapCh1, null, null, null, null);
                                objOlpDataCh1.ConvertToDoubleValues();

                                darrTmOlpXCh1 = objOlpDataCh1.darrXValues;
                                darrTmOlpYCh1 = objOlpDataCh1.darrYValues;
                                if (PublicClass.chanoverlap == true)
                                {
                                    arlstForTimeData.Add(darrTmOlpXCh1);
                                    arlstForTimeData.Add(darrTmOlpYCh1);
                                }

                                m_arlstSelectedDateTime.Add(sOlpDateTime);
                                break;
                        }
                    }
                    if (pnl == "Trend")
                    {
                        switch (sDirection)
                        {
                            case "Axial":

                                sTimeXFirstData = (string)dr["timeA_X"];
                                sTimeYFirstData = (string)dr["timeA_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sAxialDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objExactData.ConvertToDoubleValues();
                                    darrTimeXFirstD = objExactData.darrXValues;
                                    darrTimeYFirstD = objExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sAxialDateTime);

                                }
                                break;
                            case "Horizontal":
                                sTimeXFirstData = (string)dr["timeH_X"];
                                sTimeYFirstData = (string)dr["timeH_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Vertical":
                                sTimeXFirstData = (string)dr["timeV_X"];
                                sTimeYFirstData = (string)dr["timeV_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Channel1":
                                sTimeXFirstData = (string)dr["timeCH1_X"];
                                sTimeYFirstData = (string)dr["timeCH1_Y"];
                                if (!string.IsNullOrEmpty(sTimeXFirstData) && sTimeXFirstData != "0|" && sTimeXFirstData.Length > 100)
                                {
                                    string sHorizontalDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                    GetExactData objHorizontalExactData = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                    objHorizontalExactData.ConvertToDoubleValues();

                                    darrTimeXFirstD = objHorizontalExactData.darrXValues;
                                    darrTimeYFirstD = objHorizontalExactData.darrYValues;

                                    arlstForTimeData.Add(darrTimeXFirstD);
                                    arlstForTimeData.Add(darrTimeYFirstD);

                                    m_arlstSelectedDateTime.Add(sHorizontalDateTime);
                                }
                                break;
                            case "Overlap":
                                sTimeXFirstData = (string)dr["timeA_X"];
                                sTimeYFirstData = (string)dr["timeA_Y"];
                                string sOlpDateTime = Convert.ToDateTime(dr["Measure_Time"]).ToString("yyyy-MM-dd HH:mm:ss");
                                GetExactData objOlpDataA = new GetExactData(sTimeXFirstData, sTimeYFirstData, null, null, null, null);
                                objOlpDataA.ConvertToDoubleValues();

                                darrTimeXFirstD = objOlpDataA.darrXValues;
                                darrTimeYFirstD = objOlpDataA.darrYValues;

                                arlstForTimeData.Add(darrTimeXFirstD);
                                arlstForTimeData.Add(darrTimeYFirstD);


                                sTimeXOverLapH = (string)dr["timeH_X"];
                                sTimeYOverLapH = (string)dr["timeH_Y"];
                                GetExactData objOlpDataH = new GetExactData(sTimeXOverLapH, sTimeYOverLapH, null, null, null, null);
                                objOlpDataH.ConvertToDoubleValues();

                                darrTmOlpXH = objOlpDataH.darrXValues;
                                darrTmOlpYH = objOlpDataH.darrYValues;

                                arlstForTimeData.Add(darrTmOlpXH);
                                arlstForTimeData.Add(darrTmOlpYH);

                                sTimeXOverLapV = (string)dr["timeV_X"];
                                sTimeYOverLapV = (string)dr["timeV_Y"];
                                GetExactData objOlpDataV = new GetExactData(sTimeXOverLapV, sTimeYOverLapV, null, null, null, null);
                                objOlpDataV.ConvertToDoubleValues();

                                darrTmOlpXV = objOlpDataV.darrXValues;
                                darrTmOlpYV = objOlpDataV.darrYValues;

                                arlstForTimeData.Add(darrTmOlpXV);
                                arlstForTimeData.Add(darrTmOlpYV);

                                sTimeXOverLapCh1 = (string)dr["timeCH1_X"];
                                sTimeYOverLapCh1 = (string)dr["timeCH1_Y"];
                                GetExactData objOlpDataCh1 = new GetExactData(sTimeXOverLapCh1, sTimeYOverLapCh1, null, null, null, null);
                                objOlpDataCh1.ConvertToDoubleValues();

                                darrTmOlpXCh1 = objOlpDataCh1.darrXValues;
                                darrTmOlpYCh1 = objOlpDataCh1.darrYValues;

                                arlstForTimeData.Add(darrTmOlpXCh1);
                                arlstForTimeData.Add(darrTmOlpYCh1);

                                m_arlstSelectedDateTime.Add(sOlpDateTime);
                                break;
                        }
                    }                
                }
            
                if (arlstForTimeData.Count > 0)
                    arrXYValues = arlstForTimeData;
            
            }
            catch { }
        }

        ArrayList arrXYValues = null;
        string pnl = null;
        public ArrayList GetAllPlotValues(string sPointID, string sXpath, ArrayList sSelectedDates, string sType, string sDirection)
        {
            int iArrayCount = sSelectedDates.Count;
            try
            {
                arrXYValues = new ArrayList();
                Time = new ArrayList();
                arrXYValues.Clear();

                if (iArrayCount != 0)
                {
                    switch (sType)
                    {
                        case ("Time")://time
                            pnl = "Time";
                            DataOne(sPointID, iArrayCount, sSelectedDates, sDirection, pnl);
                            break;
                        case CValues.SCNSTFPW://power
                            pnl = CValues.SCNSTFPW;
                            DataOne(sPointID, iArrayCount, sSelectedDates, sDirection, pnl);
                            break;
                        case CValues.SCNSTFDML://demodulate
                            pnl = CValues.SCNSTFDML;
                            DataOne(sPointID, iArrayCount, sSelectedDates, sDirection, pnl);
                            break;
                        case "Power1"://power
                            pnl = "Power1";
                            DataOne(sPointID, iArrayCount, sSelectedDates, sDirection, pnl);
                            break;
                        case "Power2"://power
                            pnl = "Power2";
                            DataOne(sPointID, iArrayCount, sSelectedDates, sDirection, pnl);
                            break;
                        case "Power21"://power
                            pnl = "Power21";
                            DataOne(sPointID, iArrayCount, sSelectedDates, sDirection, pnl);
                            break;
                        case "Power3"://power
                            pnl = "Power3";
                            DataOne(sPointID, iArrayCount, sSelectedDates, sDirection, pnl);
                            break;
                        case "Power31"://power
                            pnl = "Power31";
                            DataOne(sPointID, iArrayCount, sSelectedDates, sDirection, pnl);
                            break;
                        case "Cepstrum":
                            pnl = "Cepstrum";
                            DataOne(sPointID, iArrayCount, sSelectedDates, sDirection, pnl);
                            break;
                    }                                                     
                }                
                return arrXYValues;
            }
            catch (Exception ex)
            {                
                return arrXYValues;
            }
        }

        public ArrayList GetDualOverallValuesImpaq(string pointID)
        {
            string Overall_Disp_Axial = null;
            string Overall_Disp_Horizontal = null;
            string Overall_Disp_Vertical = null;

            string XOverall = null;
            string YOverall = null;
            ArrayList arlstToReturn = new ArrayList();

            try
            {
                DataTable dt = DbClass.getdata(CommandType.Text, "select * from Point_data where point_id='" + pointID + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    Overall_Disp_Axial = (string)dr["displ_a"].ToString();
                    Overall_Disp_Horizontal = (string)dr["displ_h"].ToString();
                    Overall_Disp_Vertical = (string)dr["displ_v"].ToString();

                    if (Convert.ToDouble(Overall_Disp_Horizontal) == 0)
                    {
                        if (Convert.ToDouble(Overall_Disp_Axial) == 0)
                        {
                            break;
                        }
                        else if (Convert.ToDouble(Overall_Disp_Vertical) == 0)
                        {
                            break;
                        }
                        XOverall = Overall_Disp_Axial;
                        YOverall = Overall_Disp_Vertical;
                    }
                    else if (Convert.ToDouble(Overall_Disp_Vertical) == 0)
                    {
                        if (Convert.ToDouble(Overall_Disp_Axial) == 0)
                        {
                            break;
                        }
                        XOverall = Overall_Disp_Horizontal;
                        YOverall = Overall_Disp_Axial;
                    }
                    else
                    {
                        XOverall = Overall_Disp_Horizontal;
                        YOverall = Overall_Disp_Vertical;
                    }
                    arlstToReturn.Add(XOverall);
                    arlstToReturn.Add(YOverall);
                }

            }
            catch (Exception ex)
            {
                
            }
            return arlstToReturn;
        }


        public ArrayList ReturnAllDates(string sPointID, string sGraphType, string sCheckRecords, string sAxis)
        {
            string sQueryString = null;
            ArrayList arlstDates = null;
            int iUpperLimit = 0;
            int iLowerLimit = 0;
            int iDifferenceLimit = 0;
            string sTime = null;
            try
            {
                arlstDates = new ArrayList();
                if (sGraphType == "Time")
                {
                    if (sCheckRecords == "Last Ten Records")
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select Max(Counter)as MMax from Point_Data");
                        foreach (DataRow dr in dt.Rows)
                        {
                            iUpperLimit = Convert.ToInt16(dr["MMax"]);
                        }
                        DataTable dt1 = DbClass.getdata(CommandType.Text, "select Min(Counter) as MMIN from Point_Data");
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            iLowerLimit = Convert.ToInt16(dr1["MMIN"]);
                        }

                        iDifferenceLimit = iUpperLimit - iLowerLimit;

                        if (iDifferenceLimit > 9)
                            iLowerLimit = iUpperLimit - 10;

                        sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and timeA_Y != 0 && timeH_Y != 0 && timeV_Y != 0 && timeCH1_Y != 0 order by Counter asc,Counter BETWEEN " + iUpperLimit + " AND " + iLowerLimit;
                    }
                    else
                    {
                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                        {
                            if (sAxis == "Axial")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and timeA_Y not like '0|0|%' order by Counter asc";
                            }
                            else if (sAxis == "Horizontal")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and timeH_Y not like '0|0|%' order by Counter asc";
                            }
                            else if (sAxis == "Vertical")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and timeV_Y not like '0|0|%' order by Counter asc";
                            }
                            else if (sAxis == "Channel1")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and timeCH1_Y not like '0|0|%' order by Counter asc";
                            }
                        }
                        else
                        {
                            if (sAxis == "Axial")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' order by Counter asc";
                            }
                            else if (sAxis == "Horizontal")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' order by Counter asc";
                            }
                            else if (sAxis == "Vertical")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' order by Counter asc";
                            }
                            else if (sAxis == "Channel1")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' order by Counter asc";
                            }
                        }
                    }
                }
                else if (sGraphType == "Power")
                {
                    if (sCheckRecords == "Last Ten Records")
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select Max(Counter)as MMax from Point_Data");
                        foreach (DataRow dr in dt.Rows)
                        {
                            iUpperLimit = Convert.ToInt16(dr["MMax"]);
                        }
                        DataTable dt1 = DbClass.getdata(CommandType.Text, "select Min(Counter) as MMIN from Point_Data");
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            iLowerLimit = Convert.ToInt16(dr1["MMIN"]);
                        }

                        iDifferenceLimit = iUpperLimit - iLowerLimit;

                        if (iDifferenceLimit > 9)
                            iLowerLimit = iUpperLimit - 10;

                        sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and PA_Y != 0 && PH_Y != 0 && PV_Y != 0 && PCH1_Y != 0 order by Counter asc,Counter BETWEEN " + iUpperLimit + " AND " + iLowerLimit;
                    }
                    else
                    {
                        if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                        {
                            if (sAxis == "Axial")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and PA_Y not like '0|0|%' order by Counter asc";
                            }
                            else if (sAxis == "Horizontal")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and PH_Y not like '0|0|%' order by Counter asc";
                            }
                            else if (sAxis == "Vertical")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and PV_Y not like '0|0|%' order by Counter asc";
                            }
                            else if (sAxis == "Channel1")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and PCH1_Y not like '0|0|%' order by Counter asc";
                            }
                        }
                        else
                        {
                            if (sAxis == "Axial")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' order by Counter asc";
                            }
                            else if (sAxis == "Horizontal")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' order by Counter asc";
                            }
                            else if (sAxis == "Vertical")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' order by Counter asc";
                            }
                            else if (sAxis == "Channel1")
                            {
                                sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' order by Counter asc";
                            }
                        }
                    }
                }
                else if (sGraphType == "Power1")
                {
                    if (sCheckRecords == "Last Ten Records")
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select Max(Counter)as MMax from Point_Data");
                        foreach (DataRow dr in dt.Rows)
                        {
                            iUpperLimit = Convert.ToInt16(dr["MMax"]);
                        }
                        DataTable dt1 = DbClass.getdata(CommandType.Text, "select Min(Counter) as MMIN from Point_Data");
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            iLowerLimit = Convert.ToInt16(dr1["MMIN"]);
                        }

                        iDifferenceLimit = iUpperLimit - iLowerLimit;

                        if (iDifferenceLimit > 9)
                            iLowerLimit = iUpperLimit - 10;

                        sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P1A_Y != 0 && P1H_Y != 0 && P1V_Y != 0 && P1CH1_Y != 0 order by Counter asc,Counter BETWEEN " + iUpperLimit + " AND " + iLowerLimit;
                    }
                    else
                    {
                        if (sAxis == "Axial")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P1A_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Horizontal")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P1H_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Vertical")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P1V_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Channel1")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P1CH1_Y not like '0|0|%' order by Counter asc";
                        }
                    }
                }
                else if (sGraphType == "Power2")
                {
                    if (sCheckRecords == "Last Ten Records")
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select Max(Counter)as MMax from Point_Data");
                        foreach (DataRow dr in dt.Rows)
                        {
                            iUpperLimit = Convert.ToInt16(dr["MMax"]);
                        }
                        DataTable dt1 = DbClass.getdata(CommandType.Text, "select Min(Counter) as MMIN from Point_Data");
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            iLowerLimit = Convert.ToInt16(dr1["MMIN"]);
                        }

                        iDifferenceLimit = iUpperLimit - iLowerLimit;

                        if (iDifferenceLimit > 9)
                            iLowerLimit = iUpperLimit - 10;

                        sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P2A_Y != 0 && P2H_Y != 0 && P2V_Y != 0 && P2CH1_Y != 0 order by Counter asc,Counter BETWEEN " + iUpperLimit + " AND " + iLowerLimit;
                    }
                    else
                    {
                        if (sAxis == "Axial")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P2A_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Horizontal")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P2H_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Vertical")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P2V_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Channel1")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P2CH1_Y not like '0|0|%' order by Counter asc";
                        }
                    }
                }
                else if (sGraphType == "Power21")
                {
                    if (sCheckRecords == "Last Ten Records")
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select Max(Counter)as MMax from Point_Data");
                        foreach (DataRow dr in dt.Rows)
                        {
                            iUpperLimit = Convert.ToInt16(dr["MMax"]);
                        }
                        DataTable dt1 = DbClass.getdata(CommandType.Text, "select Min(Counter) as MMIN from Point_Data");
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            iLowerLimit = Convert.ToInt16(dr1["MMIN"]);
                        }

                        iDifferenceLimit = iUpperLimit - iLowerLimit;

                        if (iDifferenceLimit > 9)
                            iLowerLimit = iUpperLimit - 10;

                        sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P21A_Y != 0 && P21H_Y != 0 && P21V_Y != 0 && P21CH1_Y != 0 order by Counter asc,Counter BETWEEN " + iUpperLimit + " AND " + iLowerLimit;
                    }
                    else
                    {
                        if (sAxis == "Axial")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P21A_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Horizontal")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P21H_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Vertical")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P21V_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Channel1")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P21CH1_Y not like '0|0|%' order by Counter asc";
                        }
                    }
                }
                else if (sGraphType == "Power3")
                {
                    if (sCheckRecords == "Last Ten Records")
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select Max(Counter)as MMax from Point_Data");
                        foreach (DataRow dr in dt.Rows)
                        {
                            iUpperLimit = Convert.ToInt16(dr["MMax"]);
                        }
                        DataTable dt1 = DbClass.getdata(CommandType.Text, "select Min(Counter) as MMIN from Point_Data");
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            iLowerLimit = Convert.ToInt16(dr1["MMIN"]);
                        }

                        iDifferenceLimit = iUpperLimit - iLowerLimit;

                        if (iDifferenceLimit > 9)
                            iLowerLimit = iUpperLimit - 10;

                        sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P3A_Y != 0 && P3H_Y != 0 && P3V_Y != 0 && P3CH1_Y != 0 order by Counter asc,Counter BETWEEN " + iUpperLimit + " AND " + iLowerLimit;
                    }
                    else
                    {
                        if (sAxis == "Axial")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P3A_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Horizontal")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P3H_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Vertical")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P3V_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Channel1")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P3CH1_Y not like '0|0|%' order by Counter asc";
                        }
                    }
                }
                else if (sGraphType == "Power31")
                {
                    if (sCheckRecords == "Last Ten Records")
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select Max(Counter)as MMax from Point_Data");
                        foreach (DataRow dr in dt.Rows)
                        {
                            iUpperLimit = Convert.ToInt16(dr["MMax"]);
                        }
                        DataTable dt1 = DbClass.getdata(CommandType.Text, "select Min(Counter) as MMIN from Point_Data");
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            iLowerLimit = Convert.ToInt16(dr1["MMIN"]);
                        }

                        iDifferenceLimit = iUpperLimit - iLowerLimit;

                        if (iDifferenceLimit > 9)
                            iLowerLimit = iUpperLimit - 10;

                        sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P31A_Y != 0 && P31H_Y != 0 && P31V_Y != 0 && P31CH1_Y != 0 order by Counter asc,Counter BETWEEN " + iUpperLimit + " AND " + iLowerLimit;
                    }
                    else
                    {
                        if (sAxis == "Axial")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P31A_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Horizontal")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P31H_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Vertical")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P31V_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Channel1")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and P31CH1_Y not like '0|0|%' order by Counter asc";
                        }
                    }
                }                
                else if (sGraphType == "Demodulate")
                {
                    if (sCheckRecords == "Last Ten Records")
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select Max(Counter)as MMax from Point_Data");
                        foreach (DataRow dr in dt.Rows)
                        {
                            iUpperLimit = Convert.ToInt16(dr["MMax"]);
                        }
                        DataTable dt1 = DbClass.getdata(CommandType.Text, "select Min(Counter) as MMIN from Point_Data");
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            iLowerLimit = Convert.ToInt16(dr1["MMIN"]);
                        }

                        iDifferenceLimit = iUpperLimit - iLowerLimit;

                        if (iDifferenceLimit > 9)
                            iLowerLimit = iUpperLimit - 10;
                        sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and DEMA_Y != 0 && DEMH_Y != 0 && DEMV_Y != 0 && DEMCH1_Y != 0  order by Counter asc,Counter BETWEEN " + iUpperLimit + " AND " + iLowerLimit;
                    }
                    else
                    {
                        if (sAxis == "Axial")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and DEMA_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Horizontal")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and DEMH_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Vertical")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and DEMV_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Channel1")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and DEMCH1_Y not like '0|0|%' order by Counter asc";
                        }
                    }
                }
                else if (sGraphType == "Cepstrum")
                {
                    if (sCheckRecords == "Last Ten Records")
                    {
                        DataTable dt = DbClass.getdata(CommandType.Text, "select Max(Counter)as MMax from Point_Data");
                        foreach (DataRow dr in dt.Rows)
                        {
                            iUpperLimit = Convert.ToInt16(dr["MMax"]);
                        }
                        DataTable dt1 = DbClass.getdata(CommandType.Text, "select Min(Counter) as MMIN from Point_Data");
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            iLowerLimit = Convert.ToInt16(dr1["MMIN"]);
                        }

                        iDifferenceLimit = iUpperLimit - iLowerLimit;

                        if (iDifferenceLimit > 9)
                            iLowerLimit = iUpperLimit - 10;
                        sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and CEPA_Y != 0 && CEPH_Y != 0 && CEPV_Y != 0 && CEPCH1_Y != 0  order by Counter asc,Counter BETWEEN " + iUpperLimit + " AND " + iLowerLimit;
                    }
                    else
                    {
                        if (sAxis == "Axial")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and CEPA_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Horizontal")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and CEPH_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Vertical")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and CEPV_Y not like '0|0|%' order by Counter asc";
                        }
                        else if (sAxis == "Channel1")
                        {
                            sQueryString = "select * from Point_Data where Point_ID='" + sPointID + "' and CEPCH1_Y not like '0|0|%' order by Counter asc";
                        }
                    }
                }

                DataTable dt3 = DbClass.getdata(CommandType.Text, sQueryString);
                foreach (DataRow dr3 in dt3.Rows)
                {                    
                    sTime = Convert.ToDateTime(dr3["Measure_time"]).ToString("yyyy-MM-dd HH:mm:ss");
                    arlstDates.Add(sTime);
                }
                return arlstDates;
            }
            catch (Exception ex)
            {
                return arlstDates;
            }
            finally
            {

            }
        }



    }
}
