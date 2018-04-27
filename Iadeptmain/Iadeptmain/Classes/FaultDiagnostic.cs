using Iadeptmain.BaseUserControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iadeptmain.Mainforms;
using System.Collections;

namespace Iadeptmain.Classes
{
    class FaultDiagnostic
    {
        private IadeptUserControl m_objMainControl = null;
        private frmIAdeptMain objMain = null;
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

        public frmIAdeptMain Main
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
        double[] xx = null;
        int[] yy = null;
        int[] ff = null;
        double[] xData = null;
        double[] yData = null;

        private int getRPM(string[] rpmValue, int peakinfo)
        {
            int rpm = 0, rpm1, rpm2;
            try
            {
                if (rpmValue[3] == "True")
                {
                    rpm = Convert.ToInt32(rpmValue[0]);
                    if (Math.Abs(rpm - peakinfo) < Convert.ToInt32(rpmValue[1]))
                    {
                        rpm = peakinfo;
                    }
                }
                else
                {
                    rpm1 = (Convert.ToInt32(rpmValue[0]) - Convert.ToInt32(rpmValue[1]));
                    rpm2 = (Convert.ToInt32(rpmValue[0]) + Convert.ToInt32(rpmValue[1]));
                    if (Enumerable.Range(rpm1, rpm2).Contains(peakinfo))
                    {
                        rpm = peakinfo;
                    }
                    else
                    {
                        rpm = Convert.ToInt32(rpmValue[0]);
                    }
                }
            }
            catch { }
            return rpm;
        }

        private ArrayList GetMotorCurrentFaults(ArrayList XYData1, string[] RPMValues, bool fstatus)
        {
            ArrayList faultData = new ArrayList();
            try 
            {
                xData = (double[])XYData1[0];
                yData = (double[])XYData1[1];

                int peak1 = Convert.ToInt32(xData[yy[0]] * 60);

                int rpmFinal = getRPM(RPMValues, peak1);
            }
            catch  
            {
            }
            return faultData;
                 
        }

        private double GetPPF(double FL,int PoleCount , int RPM)
        {
            double ppf = 0;
            try
            { 
            }
            catch
            {
            }
            return ppf;
        }
    }
}
