using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO ;
using System.Diagnostics;
using System.Configuration;
using System.Net;
namespace Iadeptmain.GlobalClasess
{
    public class Errorlogfile
    {
       
        public static void LogFile(Exception ex, string sEventName, int nErrorLineNo, string sFormName)
        {
           
            StreamWriter log;

            if (!File.Exists("logfile.txt"))
            {
                log = new StreamWriter("logfile.txt");
            }
            else
            {
                log = File.AppendText("logfile.txt");
            }

            log.WriteLine("Data Time:" + DateTime.Now);
            log.WriteLine("Exception Name:" + ex);
            log.WriteLine("Event Name:" + sEventName);
            //log.WriteLine("Control Name:" + sControlName);
            log.WriteLine("Error Line No.:" + nErrorLineNo);
            log.WriteLine("Form Name:" + sFormName);
            log.WriteLine("------------------------------------------------------------------------------------------------------------------------"); 
              // Close the stream:
            log.Close();

        }
       
        public static void LogFile(Exception ex,string sEventName, string sControlName, int nErrorLineNo, string sFormName)
        {
            
            StreamWriter log;

            if (!File.Exists("logfile.txt"))
            {
                log = new StreamWriter("logfile.txt");
            }
            else
            {
                log = File.AppendText("logfile.txt");
            }
            log.WriteLine("Data Time:" + DateTime.Now);
            log.WriteLine("Exception Name:" + ex);
            log.WriteLine("Event Name :" + sEventName);
            log.WriteLine("Control Name :" + sControlName);
            log.WriteLine("Error Line No :" + nErrorLineNo);
            log.WriteLine("Form Name :" + sFormName);
            log.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            // Close the stream:
            log.Close();

        }

    }
    public static class ExceptionHelper
    {

        public static int LineNumber(this Exception e)
        {

            int linenum = 0;

            try
            {

                linenum = Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(":line") + 5));

            }

            catch
            {
            }
            return linenum;

        }

    }
}
