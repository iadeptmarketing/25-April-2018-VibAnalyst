using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace Iadeptmain.Classes
{
    public class Class_extractdata
    {
        string ModelIdentification = null;
        string RunIdentification = null;
        string DateTime = null;
        string CaseName = null;
        string ID5 = null;
        string FunctionType = null;
        int FunctionId = 0;
        double Version = 0;
        int LoadCaseID = 0;
        string ResponseEntity = null;
        int ResponseNode = 0;
        string ResponseDirection = null;
        string RefEntity = null;
        int RefNode = 0;
        string Refdirection = null;
        int DataForm = 0;
        int datasize = 0;
        int Spacing = 0;
        double Xincrement = 0.0;
        double min_spacing = 0.0;
        int XDataType = 0;
        string XUnit = null;
        string YUnit = null;
        string[] arrXunit = null;
        string[] arrYunit = null;
        string[] arrCXunit = new string[0];
        string[] arrCYunit = new string[0];
        string[] NewColorCode = new string[0];
        int[] ConvGraphPerData = new int[0];
        //string ParameterType = null;
        
        int YDataType = 0;
        ArrayList arlstYdata = new ArrayList();
        ArrayList arlstXdata = new ArrayList();
        ResizeArray_Interface Resize = new ResizeArray_Control();
        string[] ColorCode = { "7667712", "16751616", "4684277", "7077677", "16777077", "9868951", "2987746", "4343957", "16777216", "23296", "16711681", "8388652", "6972", "16776961", "7722014", "32944", "7667573", "7357301", "12042869", "60269", "14774017", "5103070", "14513374", "5374161", "38476", "3318692", "29696", "6737204", "16728065", "744352" };
        public ArrayList arldata = null;
        public void getUFF58Data(string spath)
        {
            try
            {
                arrXunit = new string[0];
                arrYunit = new string[0];
                arldata = new ArrayList();
                arlstYdata = new ArrayList();
                arlstXdata = new ArrayList();
                StreamReader objReader = new StreamReader(spath);
                string sLine = "";
                ArrayList arrText = new ArrayList();
                ArrayList[] xxd = new ArrayList[4];
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        arrText.Add(sLine);
                }
                objReader.Close();
                int i = 0;
                bool NewData = false;
                bool PreNewData = false;
                DateTime = null;
                double[] XData = null;
                double[] YData = null;
                int yy = 0;
                foreach (string sOutput in arrText)
                {
                    string[] splitedstring = sOutput.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    if (PreNewData)
                    {
                        if (splitedstring[0].ToString() == "58")
                        {
                            NewData = true;
                        }
                        else
                        {
                            PreNewData = false;
                        }
                    }
                    try
                    {
                        if (Convert.ToString(splitedstring[0].ToString()) == "-1")
                        {
                            PreNewData = true;
                        }
                        else
                        {
                            PreNewData = false;
                        }
                    }
                    catch
                    { }


                    if (NewData)
                    {
                        i = 1;
                        Resize.IncreaseArrayString(ref arrXunit, 1);
                        Resize.IncreaseArrayString(ref arrYunit, 1);
                        NewData = false;
                    }
                    switch (i)
                    {
                        case 0:
                        case 1:
                            {
                                break;
                            }
                        case 2:
                            {
                                ModelIdentification = sOutput.ToString();
                                break;
                            }
                        case 3:
                            {
                                RunIdentification = sOutput.ToString();
                                break;
                            }
                        case 4:
                            {
                                DateTime = sOutput.ToString();
                                break;
                            }
                        case 5:
                            {
                                CaseName = sOutput.ToString();
                                break;
                            }
                        case 6:
                            {
                                ID5 = sOutput.ToString();
                                break;
                            }
                        case 7:
                            {
                                FunctionType = splitedstring[0].ToString();                 //1
                                FunctionId = Convert.ToInt32(splitedstring[1].ToString());  //2
                                Version = Convert.ToDouble(splitedstring[2].ToString());    //3
                                LoadCaseID = Convert.ToInt32(splitedstring[3].ToString());  //4
                                ResponseEntity = splitedstring[4].ToString();               //5
                                ResponseNode = Convert.ToInt32(splitedstring[5].ToString());//6
                                ResponseDirection = splitedstring[6].ToString();            //7
                                //valid if field 4 is zero
                                RefEntity = splitedstring[7].ToString();                    //8
                                RefNode = Convert.ToInt32(splitedstring[8].ToString());     //9
                                Refdirection = splitedstring[9].ToString();                 //10
                                break;
                            }
                        case 8:
                            {
                                DataForm = Convert.ToInt32(splitedstring[0].ToString());
                                datasize = Convert.ToInt32(splitedstring[1].ToString());
                                Spacing = Convert.ToInt32(splitedstring[2].ToString());
                                min_spacing = Convert.ToDouble(splitedstring[3].ToString());//0.0 if spacing uneven(0)
                                Xincrement = Convert.ToDouble(splitedstring[4].ToString());
                                arldata.Add(CaseName.Trim() + "(" + ResponseEntity + ")");
                                YData = new double[datasize];
                                XData = new double[datasize];
                                yy = 0;
                                break;
                            }
                        case 9:
                            {

                                XDataType = Convert.ToInt32(splitedstring[0].ToString());
                                XUnit = splitedstring[5].ToString();
                                char[] chartest = XUnit.ToCharArray();
                                string NewChar = null;
                                for (int icount = 0; icount < chartest.Length; icount++)// char val in chartest)
                                {
                                    try
                                    {
                                        char val = (char)chartest[icount];
                                        byte bytetest = Convert.ToByte(val);
                                        NewChar = NewChar + val.ToString();
                                    }
                                    catch (Exception ex)
                                    {
                                        NewChar = NewChar + ("2");
                                    }
                                }
                                XUnit = NewChar.ToString();
                                arrXunit[arrXunit.Length - 1] = (string)XUnit;
                                break;
                            }
                        case 10:
                            {
                                YDataType = Convert.ToInt32(splitedstring[0].ToString());
                                YUnit = splitedstring[5].ToString();
                                char[] chartest = YUnit.ToCharArray();
                                string NewChar = null;
                                for (int icount = 0; icount < chartest.Length; icount++)// char val in chartest)
                                {
                                    try
                                    {
                                        char val = (char)chartest[icount];
                                        byte bytetest = Convert.ToByte(val);
                                        NewChar = NewChar + val.ToString();
                                    }
                                    catch (Exception ex)
                                    {
                                        NewChar = NewChar + ("2");
                                    }
                                }
                                YUnit = NewChar.ToString();
                                arrYunit[arrYunit.Length - 1] = (string)YUnit;
                                break;
                            }
                        case 11:
                        case 12:
                            {
                                break;
                            }
                        default:
                            {
                                switch (Spacing)
                                {
                                    case 0://uneven spacing
                                        {
                                            switch (DataForm)
                                            {
                                                case 2://real, Single Precission
                                                    {   //X1  Y1  X2  Y2  X3  Y3
                                                        //X4  Y4  X5  Y5  X6  Y6

                                                        try
                                                        {
                                                            int xx = 0;
                                                            foreach (string sstring in splitedstring)
                                                            {
                                                                if (xx % 2 == 0)
                                                                {
                                                                    //XData[yy] = Convert.ToDouble((yy) * Xincrement);
                                                                    XData[yy] = Convert.ToDouble(yy);
                                                                }
                                                                else
                                                                {
                                                                    YData[yy] = Convert.ToDouble(sstring);
                                                                    yy++;
                                                                }
                                                                xx++;
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            if (YData != null)
                                                            {
                                                                arlstYdata.Add(YData);
                                                                arlstXdata.Add(XData);
                                                                YData = null;
                                                                XData = null;
                                                            }

                                                        }
                                                        break;
                                                    }
                                                case 4://real, double precission
                                                    {   //X1  Y1  X2  Y2  
                                                        //X3  Y3  X4  Y4 

                                                        try
                                                        {
                                                            int xx = 0;
                                                            foreach (string sstring in splitedstring)
                                                            {
                                                                if (xx % 2 == 0)
                                                                {
                                                                    if (XUnit == "Sec")
                                                                    {
                                                                        XData[yy] = Convert.ToDouble((yy + 1) * Xincrement);
                                                                    }
                                                                    else
                                                                    {
                                                                        XData[yy] = Convert.ToDouble(yy);
                                                                    }

                                                                }
                                                                else
                                                                {
                                                                    YData[yy] = Convert.ToDouble(sstring);
                                                                    yy++;
                                                                }
                                                                xx++;
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            if (YData != null)
                                                            {
                                                                arlstYdata.Add(YData);
                                                                arlstXdata.Add(XData);
                                                                YData = null;
                                                                XData = null;
                                                            }

                                                        }

                                                        break;
                                                    }
                                                case 5://Complex, Single Precission
                                                    {   //X1  RY1  IY1  X2  RY2  IY2
                                                        //X3  RY3  IY3  X4  RY4  IY4
                                                        try
                                                        {
                                                            int xx = 0;
                                                            foreach (string sstring in splitedstring)
                                                            {
                                                                if (xx % 2 == 0)
                                                                {
                                                                    if (XUnit == "Sec")
                                                                    {
                                                                        XData[yy] = Convert.ToDouble((yy + 1) * Xincrement);
                                                                    }
                                                                    else
                                                                    {
                                                                        XData[yy] = Convert.ToDouble(yy);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    YData[yy] = Convert.ToDouble(sstring);
                                                                    yy++;
                                                                }
                                                                xx++;
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            if (YData != null)
                                                            {
                                                                arlstYdata.Add(YData);
                                                                arlstXdata.Add(XData);
                                                                YData = null;
                                                                XData = null;
                                                            }

                                                        }

                                                        break;
                                                    }
                                                case 6://Complex, Double Pression
                                                    {   //X1  RY1  IY1  
                                                        //X2  RY2  IY2  
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case 1://even spacing
                                        {
                                            switch (DataForm)
                                            {
                                                case 2://real, Single Precission
                                                    {   //Y1  Y2  Y3  Y4  Y5  Y6
                                                        //Y7  Y8  Y9  Y10 Y11 Y12

                                                        try
                                                        {
                                                            foreach (string sstring in splitedstring)
                                                            {
                                                                if (XUnit == "Sec")
                                                                {
                                                                    YData[yy] = Convert.ToDouble(sstring);
                                                                    XData[yy] = Convert.ToDouble((yy + 1) * Xincrement);
                                                                }
                                                                else
                                                                {
                                                                    YData[yy] = Convert.ToDouble(sstring);
                                                                    //XData[yy] = Convert.ToDouble((yy) * Xincrement);
                                                                    XData[yy] = Convert.ToDouble(yy);
                                                                }
                                                                yy++;
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            if (YData != null)
                                                            {
                                                                arlstYdata.Add(YData);
                                                                arlstXdata.Add(XData);
                                                                YData = null;
                                                                XData = null;
                                                            }

                                                        }
                                                        break;
                                                    }
                                                case 4://real, double precission
                                                    {   //Y1  Y2  Y3  Y4  
                                                        //Y5  Y6  Y7  Y8 

                                                        try
                                                        {
                                                            foreach (string sstring in splitedstring)
                                                            {
                                                                if (XUnit == "Sec")
                                                                {
                                                                    YData[yy] = Convert.ToDouble(sstring);
                                                                    XData[yy] = Convert.ToDouble((yy + 1) * Xincrement);
                                                                }
                                                                else
                                                                {
                                                                    YData[yy] = Convert.ToDouble(sstring);
                                                                    //XData[yy] = Convert.ToDouble((yy) * Xincrement);
                                                                    XData[yy] = Convert.ToDouble(yy);
                                                                }
                                                                yy++;
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            if (YData != null)
                                                            {
                                                                arlstYdata.Add(YData);
                                                                arlstXdata.Add(XData);
                                                                YData = null;
                                                                XData = null;
                                                            }
                                                        }
                                                        break;
                                                    }
                                                case 5://Complex, Single Precission
                                                    {   //RY1  IY1  RY2  IY2  RY3  IY3
                                                        //RY4  IY4  RY5  IY5  RY6  IY6
                                                        try
                                                        {
                                                            foreach (string sstring in splitedstring)
                                                            {
                                                                if (XUnit == "Sec")
                                                                {
                                                                    YData[yy] = Convert.ToDouble(sstring);
                                                                    XData[yy] = Convert.ToDouble((yy + 1) * Xincrement);
                                                                }
                                                                else
                                                                {
                                                                    YData[yy] = Convert.ToDouble(sstring);
                                                                    //XData[yy] = Convert.ToDouble((yy) * Xincrement);
                                                                    XData[yy] = Convert.ToDouble(yy);
                                                                }
                                                                yy++;
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            if (YData != null)
                                                            {
                                                                arlstYdata.Add(YData);
                                                                arlstXdata.Add(XData);
                                                                YData = null;
                                                                XData = null;
                                                            }
                                                        }

                                                        break;
                                                    }
                                                case 6://Complex, Double Pression
                                                    {   //RY1  IY1  RY2  IY2 
                                                        //RY3  IY3  RY4  IY4  
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
            }
        }
        
        
        private ArrayList ConverttoFFT(ArrayList xdata, ArrayList ydata, string[] xunit, string[] yunit)
        {
            ArrayList XYData = new ArrayList();
            try
            {
                arrCXunit = new string[0];
                arrCYunit = new string[0];
                NewColorCode = new string[0];
                ConvGraphPerData = new int[0];
                for (int i = 0; i < xdata.Count; i++)
                {
                    double[] X = (double[])xdata[i];
                    double[] Y = (double[])ydata[i];
                    XUnit = xunit[i];
                    YUnit = yunit[i];
                    int SamplingFreq = (int)(Math.Round((double)1 / (double)X[0]));
                    double[] testy = new double[SamplingFreq];
                    double[] testX = new double[SamplingFreq];

                    int _i_ = 0;
                    try
                    {
                        while (true)
                        {

                            Array.Copy(X, 0, testX, 0, SamplingFreq);
                            Array.Copy(Y, SamplingFreq * _i_, testy, 0, SamplingFreq);

                            _i_++;
                            double[] mag = null;//Calculate.fftMag(testy);
                            double lastTimevalue = (double)(testX[testX.Length - 1]);
                            lastTimevalue = Math.Round(lastTimevalue, 2);
                            double HzRate = (double)(1 / lastTimevalue);
                            double[] Hz = new double[mag.Length];
                            for (int i1 = 0; i1 < mag.Length; i1++)
                            {
                                Hz[i1] = HzRate * i1;
                            }
                            XYData.Add(Hz);
                            XYData.Add(mag);

                            Resize.IncreaseArrayString(ref arrCXunit, 1);
                            Resize.IncreaseArrayString(ref arrCYunit, 1);
                            Resize.IncreaseArrayString(ref NewColorCode, 1);
                            arrCXunit[arrCXunit.Length - 1] = "Hz";
                            arrCYunit[arrCYunit.Length - 1] = arrYunit[i];
                            NewColorCode[NewColorCode.Length - 1] = ColorCode[i];
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    Resize.IncreaseArrayInt(ref ConvGraphPerData, 1);
                    ConvGraphPerData[ConvGraphPerData.Length - 1] = _i_;
                }
            }

            catch (Exception ex)
            {

            }
            return XYData;
        }
       
        #region Interface_ExtractData Members

        public void GetData(string spath)
        {
            string[] sarrPath = spath.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            if (sarrPath[sarrPath.Length - 1].ToString().ToLower() == "wav")
            {
               // getWaveData(spath);
            }
            else if (sarrPath[sarrPath.Length - 1].ToString().ToLower() == "uff")
            {
                getUFF58Data(spath);
            }
        }



        public ArrayList Arraylist_X
        {
            get
            {
                return arlstXdata;
            }
        }

        public ArrayList Arraylist_Y
        {
            get
            {
                return arlstYdata;
            }
        }



        public string[] arrXUnits
        {
            get { return arrXunit; }
        }

        public string[] arrYUnits
        {
            get { return arrYunit; }
        }

        public string[] arrCXUnits
        {
            get { return arrCXunit; }
        }

        public string[] arrCYUnits
        {
            get { return arrCYunit; }
        }

        public string[] _NewColorCode
        {
            get
            {
                return NewColorCode;
            }
        }
        public int[] CGPD
        {
            get
            {
                return ConvGraphPerData;
            }
        }

        public ArrayList GetFFTData(string spath, ArrayList xdata, ArrayList ydata, string[] xunit, string[] yunit)
        {
            string[] sarrPath = spath.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            ArrayList XYData = null;
            if (sarrPath[sarrPath.Length - 1].ToString().ToLower() == "wav")
            {
                XYData = ConverttoFFT(xdata, ydata, xunit, yunit);
            }
            else if (sarrPath[sarrPath.Length - 1].ToString().ToLower() == "uff")
            {
                XYData = ConverttoFFT(xdata, ydata, xunit, yunit);
            }
            return XYData;
        }

        #endregion
    }
}
