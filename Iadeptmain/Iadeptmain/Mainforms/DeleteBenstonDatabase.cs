using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
 
using System.IO;
using trial6;
using Iadeptmain.GlobalClasses;
using System.IO.Ports;
using System.Threading;
using Iadeptmain.Classes;

namespace Iadeptmain.Mainforms
{
    public partial class DeleteBenstonDatabase : DevExpress.XtraEditors.XtraForm
    {
        RAPI objConnToDvc = new RAPI();
        public DeleteBenstonDatabase()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
        }

       
        string sErrorLogPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
        FileStream aa = null;
        StreamWriter sw = null;

        private void ErrorLogFile(Exception ex)
        {
            try
            {
                if (ex.Message == "Exception of type 'System.OutOfMemoryException' was thrown.")
                {
                    MessageBox.Show("System Memory is low. Please Close Some Applications and Try again", "Low Memory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (!File.Exists(sErrorLogPath + "\\FMErrorLog.txt"))
                {
                    aa = new FileStream(sErrorLogPath + "\\FMErrorLog.txt", FileMode.Create, FileAccess.ReadWrite);
                }
                else
                {
                    aa = new FileStream(sErrorLogPath + "\\FMErrorLog.txt", FileMode.Append, FileAccess.Write);
                }
                sw = new StreamWriter(aa);
                sw.WriteLine(ex.Message + "      " + ex.StackTrace + "          " + System.DateTime.Now.ToString("MM/dd/yyyy HH:m:s"));
                sw.Close();
            }
            catch 
            {
            }
        }

        private string RouteNumbers = null; ClsSdftodb _objgenDi = new ClsSdftodb();
        private void DeleteBenstonDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    if (objConnToDvc.DevicePresent)
                    {
                        GetInfo();
                    }
                    else
                    {
                        MessageBox.Show("Device Not Connected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
                else
                {
                    int sleep = 300;
                    lbPrsntDataBss.SelectionMode = SelectionMode.One; lbPrsntDataBss.Items.Clear();
                    if (m_objSerialPort.IsOpen == true)
                    {
                        m_objSerialPort.Write("\x06");
                        m_objSerialPort.Write("\x04");
                        m_objSerialPort.Close();
                    }
                    Thread.Sleep(sleep);
                    if (m_objSerialPort.IsOpen == false)
                    {
                        _objgenDi.ConnectwithINST();
                        if (_objgenDi.DiStatus == true)
                        {
                            m_objSerialPort = _objgenDi.m_objSerialPort;
                            RouteNumbers = _objgenDi.sblRtNumbers.ToString();
                            for (int a = 0; a < _objgenDi.Routename.Length - 1; a++)
                            {
                                string[] Routename1 = Convert.ToString(_objgenDi.Routename[a]).Split('|');
                                lbPrsntDataBss.Items.Add(Routename1[0]);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Device Not Connected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
            }
        }
               
        private string ExtractNames()
        {
            StringBuilder sblSelected = new StringBuilder();
            string test = null;
            char chrtest = Convert.ToChar(" ");
            try
            {
                foreach (Object aa in lbPrsntDataBss.SelectedItems)
                {
                  
                    test = aa as String;
                    test = test.TrimEnd(new char[] { chrtest });
                    test = test.TrimStart(new char[] { chrtest });
                    sblSelected.Append(test);
                    sblSelected.Append("!!");
                }
            }
            catch 
            {
               
            }
            return Convert.ToString(sblSelected);
        }


        private void GetInfo()
        {
            lbPrsntDataBss.Items.Clear();
            objConnToDvc.Connect();            
            try
            {
                if (objConnToDvc.DevicePresent)
                {
                    FileList objAllFiles =Direct;
                    foreach (FileInformation FileInfoMtn in objAllFiles)
                    {
                        lbPrsntDataBss.Items.Add(FileInfoMtn.FileName.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Device Not Connected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ErrorLogFile(ex);
            }
        }

        private FileList Direct
        {
            get
            {
               FileList instname= objConnToDvc.EnumFiles("Storage Card\\*.*");                
                return objConnToDvc.EnumFiles("Storage Card\\"+instname[0].FileName+"\\DataCollector\\Data\\*.sdf");              
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] AllSelected = ExtractNames().Split(new string[] { "!!" }, StringSplitOptions.None);
            try
            {
                if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "FieldPaq2")
                {
                    if (objConnToDvc.DevicePresent)
                    {
                        if (MessageBox.Show("Do You Want To Delete The Selected Databases", "Database Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            FileList instname = objConnToDvc.EnumFiles("Storage Card\\*.*");
                            for (int i = 0; i < AllSelected.Length - 1; i++)
                            {
                                if (objConnToDvc.DeviceFileExists("Storage Card\\" + instname[0].FileName + "\\DataCollector\\Data\\" + AllSelected[i]))
                                {
                                    objConnToDvc.DeleteDeviceFile("Storage Card\\" + instname[0].FileName + "\\DataCollector\\Data\\" + AllSelected[i]);
                                }

                            }
                            MessageBox.Show("Route Deleted Successully");
                            GetInfo();
                        }
                    }
                    else
                        MessageBox.Show("Device Not Connected", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DIDelete(AllSelected[0],Convert.ToString(lbPrsntDataBss.SelectedIndex),RouteNumbers);
                    MessageBox.Show("Route Deleted Successully");
                }
            }
            catch { }
        }

        int ValForBar = 0;
        private byte[] RouteNoForDeletion(string target,string RouteNM)
        {            
            string[] Routes = RouteNM.Split(new string[] { ",", "|" }, StringSplitOptions.None);            
            string numbertosend = null;
            byte[] Number = null;
            char test = Convert.ToChar(" ");
            string[] targetwithmedia = target.ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);            
            try
            {
                for (int i = 0; i < Routes.Length; i++)
                {
                    Routes[i] = Routes[i].TrimEnd(new char[] { test });
                    if (Routes[i] == targetwithmedia[0].Trim())
                        numbertosend = Routes[i + 1];
                    if (numbertosend != null)
                        break;
                }
                Number = Encoding.ASCII.GetBytes(numbertosend);
            }
            catch{ }
            return Number;
        }

        private int SumOfByteArray(byte[] a)
        {
            int SumOfBytes = 0;
            try
            {
                for (int i = 0; i < a.Length; i++)
                {
                    SumOfBytes = a[i] + SumOfBytes;
                }
            }
            catch { }
            return SumOfBytes;
        }

        public void ConnectwithINST()
        {
            DiStatus = false;
            byte[] arrFiveByte = { 0x05 };
            int BaudRR = 115200;
            try
            {
                string sComPortName = "COM8";
                if (!string.IsNullOrEmpty(sComPortName))
                {
                    m_objSerialPort = new SerialPort(sComPortName, BaudRR, Parity.None, 8, StopBits.One);
                    m_objSerialPort.Open();
                    m_objSerialPort.DtrEnable = true;
                    m_objSerialPort.RtsEnable = true;
                    m_objSerialPort.Write(arrFiveByte, 0, arrFiveByte.Length);
                    DiStatus = true;
                }
            }
            catch
            { DiStatus = false; m_objSerialPort.Close(); }
        }


        public byte DataSyncWrite()
        {
            byte[] arrReceivedSix1 = new byte[1];
            try
            {
                m_objSerialPort.Read(arrReceivedSix1, 0, arrReceivedSix1.Length);
            }
            catch { }
            return (arrReceivedSix1[0]);

        }

        bool DiStatus = false;
        SerialPort m_objSerialPort = new SerialPort(); private const string SHEXFIVE = "\x05";
        public void DIDelete(string Dbname,string ID,string RouteNum)
        {
            try
            {
                byte[] Q1 = { 0x01, 0x30, 0x30, 0x32, 0x38, 0x02 };
                byte[] Q12 = { 0x1F, 0x00, 0x00, 0x03 };
                byte[] Q2 = { 0x01, 0x30, 0x30, 0x32, 0x44, 0x02, 0x03, 0x35, 0x42 };
                byte[] Q3 = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x44, 0x45, 0x4C, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x32, 0x33 };
                byte[] Q4 = { 0x01, 0x30, 0x31, 0x37, 0x46, 0x02, 0x53, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x36, 0x38 };
                byte[] Q5 = { 0x01, 0x30, 0x32, 0x37, 0x46, 0x02, 0x30, 0x30, 0x36, 0x31, 0x00, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x94, 0x2A, 0xE4, 0x8F, 0xCC, 0xF6, 0x43, 0x8C, 0xA8, 0xF8, 0xFF, 0x01, 0x00, 0xC8, 0xFF, 0xFF, 0x20, 0x1B, 0x05 };
                byte[] Q51 = { 0x1B, 0x03, 0x08, 0x00, 0x0B, 0x1B, 0x08, 0x07, 0x00, 0x50, 0x39, 0xF8, 0x03, 0x1B, 0x04, 0x10, 0x1B, 0x04, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x06, 0x1B, 0x03, 0x70, 0xD4, 0x0C, 0x00, 0x98, 0x72, 0x8E, 0x01, 0x24, 0xF5, 0x10, 0x0E, 0x84, 0xF5, 0x10, 0x0E, 0x60, 0x8E, 0x01, 0xCC, 0xF4, 0x10, 0x0E, 0x30, 0xDE, 0x8A, 0x01, 0x0B, 0x00, 0xFF, 0x01, 0xDC, 0xF6, 0x10, 0x0E, 0x00, 0x00, 0x10, 0x0E, 0x1B, 0x17, 0x03 };
                byte[] Q6 = { 0x01, 0x30, 0x30, 0x37, 0x46, 0x02, 0x52, 0x46, 0x43, 0x3A, 0x5C, 0x7E, 0x70, 0x6C, 0x33, 0x30, 0x32, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x5C, 0x63, 0x6F, 0x6E, 0x66, 0x69, 0x67, 0x2E, 0x70, 0x31, 0x31, 0x03, 0x36, 0x36 };
                byte[] Q7 = { 0x01, 0x30, 0x30, 0x31, 0x36, 0x02, 0x03, 0x34, 0x43 };
                byte[] Q5Test = { 0x01, 0x30, 0x32, 0x37, 0x46, 0x02, 0x30, 0x30, 0x36, 0x31, 0x00, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x94, 0x2A, 0xE4, 0x8F, 0xCC, 0xF6, 0x43, 0x8C, 0xA8, 0xF8, 0xFF, 0x01, 0x00, 0xC8, 0xFF, 0xFF, 0x20, 0x1B, 0x05, 0x02, 0x1B, 0x03, 0x08, 0x00, 0x0B, 0x1B, 0x08, 0x07, 0x00, 0x50, 0x39, 0xF8, 0x03, 0x1B, 0x04, 0x10, 0x1B, 0x04, 0xC8, 0xFF, 0xFF, 0x94, 0x2A, 0xE4, 0x8F, 0x06, 0x1B, 0x03, 0x70, 0xD4, 0x0C, 0x00, 0x98, 0x72, 0x8E, 0x01, 0x24, 0xF5, 0x10, 0x0E, 0x84, 0xF5, 0x10, 0x0E, 0x60, 0x8E, 0x01, 0xCC, 0xF4, 0x10, 0x0E, 0x30, 0xDE, 0x8A, 0x01, 0x0B, 0x00, 0xFF, 0x01, 0xDC, 0xF6, 0x10, 0x0E, 0x00, 0x00, 0x10, 0x0E, 0x1B, 0x17, 0x03, 0x33, 0x43 };
                byte Recieve = 0;
                int Count = 0;              
                byte[] testbyte1 = new byte[2];
                byte[] RouteNo = new byte[1];
                StringBuilder Routes = new StringBuilder(); 
                ValForBar++;
                byte[] no = RouteNoForDeletion(Dbname, RouteNum);               
                m_objSerialPort.Write(SHEXFIVE);//Sending 05
                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                ValForBar++;

                m_objSerialPort.Write(SHEXFIVE);//Sending 05
                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                Count = 0;
                ValForBar++;

                Count = Count + SumOfByteArray(Q1) + SumOfByteArray(Q12) + SumOfByteArray(no);
                m_objSerialPort.Write(Q1, 0, Q1.Length);//Sending Question 1
                //RouteNo = Encoding.ASCII.GetBytes(Convert.ToString(iSelectedIndex + 1));
                m_objSerialPort.Write(no, 0, no.Length);//Sending Key Of The Route
                m_objSerialPort.Write(Q12, 0, Q12.Length);//Sending Secong Part Of Question 1
                ValForBar++;


                byte[] test = _objgenDi.SelectValueToBeSended(Convert.ToUInt64(Count));//Extracting Ending Value of Q1
                m_objSerialPort.Write(test, 0, test.Length);//Sending The End value of Q1
                do
                {
                    Recieve = _objgenDi.DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                m_objSerialPort.Write(SHEXFIVE);//Sending 05
                ValForBar++;

                do
                {
                    Recieve = DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                m_objSerialPort.Write(Q2, 0, Q2.Length);// Sending Question 2
                do
                {
                    Recieve = _objgenDi.DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                m_objSerialPort.Write(SHEXFIVE);//Sending 05
                ValForBar++;

                do
                {
                    Recieve = _objgenDi.DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                m_objSerialPort.Write(Q3, 0, Q3.Length);//Sending Question 3
                do
                {
                    Recieve = _objgenDi.DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                m_objSerialPort.Write(Q4, 0, Q4.Length);//Sending Q4
                ValForBar++;

                do
                {
                    Recieve = _objgenDi.DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                Count = 0;
                m_objSerialPort.Write(Q5Test, 0, Q5Test.Length);//Sending Question 5

                do
                {
                    Recieve = _objgenDi.DataSyncWrite();//Recieving 06
                } while (Recieve != 6);
                ValForBar++;               
                _objgenDi.InitializeAgain();
                _objgenDi.checkbool = "true";
                _objgenDi.FillRoutesCombo(_objgenDi.m_sarrData);
                RouteNumbers = _objgenDi.sblRtNumbers.ToString();
                lbPrsntDataBss.Items.Clear();
                //if (_objgenDi.DiStatus == true)
                //{
                    for (int a = 0; a < _objgenDi.Routename.Length - 1; a++)
                    {
                        string[] Routename1 = Convert.ToString(_objgenDi.Routename[a]).Split('|');
                        lbPrsntDataBss.Items.Add(Routename1[0]);
                    }
               // }
            }
            catch { }
        }





        private void lbPrsntDataBss_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int Selected = lbPrsntDataBss.SelectedIndex;
            if (Selected >= 0)
                btnDelete.Enabled = true;
            else if (Selected < 0)
                btnDelete.Enabled = false;
        }

        private void DeleteBenstonDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(PublicClass.currentInstrument=="SKF/DI")
            {
                if (m_objSerialPort.IsOpen == true)
                {
                    m_objSerialPort.Write("\x06");
                    m_objSerialPort.Write("\x04");
                    m_objSerialPort.Close();
                }
            }
        }

       
    }
}