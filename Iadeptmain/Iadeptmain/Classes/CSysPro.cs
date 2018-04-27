#region Hasp Key Code

using System;
using System.Collections.Generic;
using System.Text;
using Aladdin.HASP;
using Iadeptmain.Mainforms;

using System.IO;
using System.Diagnostics;
using Aladdin.Hasp;
using Iadeptmain.GlobalClasses;
using System.Windows.Forms;
namespace Iadeptmain.Classes
{
    public sealed class CSysPro
    {
        Hasp m_objHasp = null;
        //Hasp m_objHasp1 = null;
        HaspFile m_objHaspFile = null;
        static int iCounter = 0;
        private string sFormClosed = null;
        private bool m_bAcknowledgement = false;
        public delegate void ExitButtonClickHandler();
        public event ExitButtonClickHandler ExitButtonClicked;
        public event ExitButtonClickHandler DemoButtonClick;
        public event ExitButtonClickHandler TryButtonClicked;
        private int m_iAuth1 = 6830;
        private int m_iAuth2 = 8503;
        private int m_iSC = 0;
        private int m_iPt = 0;
        string m_sFromOtherThread = null;

//        string m_sTest = "6ecUixAlOI/z6h5iycfjoX86wD34pqt7hJYC290/MEeO/sr/GnZJ6/uFF6s4r0me0nSsG9Cm4v9ThprC" +
//"/aWbS5VM9SFQaAOHpXholPu0DT0v+GfE9v3S3yd6yueeQxNR+xivt3t5MEso3iK7dJshOUAHP0HGldzE" +
//"YM0vwAqIE6uSV3VcgLLM2264YwWqYNCIeTCwmAx58XQIalh+1q+UhGhdeSEArmp+u0WwU2N8wim3LeMp" +
//"0Pykh3ahJqiMucR3ukAlVWahLYh6/uncJ6vsWE764n50hznJum6EQlCuH0pmsrszwoKoY7fGsi2i+wY3" +
//"NTK21XqeNVvd5Lucex7MT3/77hLW/CMzCG+2P43GxbEjJcF46ZeL2qN9sviTBIHpl9J3YEfzE3d1dNgx" +
//"1LuTDwX4SlXANVeRIqr7TLuJ2u5+/TdxUE9oETQIzz9cwNmM6eZThB0V9wMPHaWBd5KpW59n02uFqepX" +
//"JGyQTGnVe9xQ6HiE87DmFduDco9aAJyC14jgYPkfvn9yX7Pl7SRgzHjiWPSwI1aAMz3x8klUQTjW9oBO" +
//"UnHdXUxetR7K7S54l41I8wkMY706S7+hqSmr3GaQEeHY3Iczyhl5IZdxJo8sV2RHmDYR/vGx7OudEIL3" +
//"ASc7oC6NGBoenSq52cAmQMY/zOTn/h2l9waADHCnYRVmpOFvflmnpWhUscPNM5d+M8I0Qi/CRJ+AgFtC" +
//"gKIvr+hhB6wr+Xk1IL91HHAcw+XxA0cd66t0lacDwA8wAcv7ROlW5bylH4ZncpblwV2ozaYR34v5egd3" +
//"kIlMsA7PFfpxzNNf7OtRCNlT3L4hHrT2sohck912Y3qc4vBTrWduxS0E9RH8cOT9DJQn16k6wj4BrdCp" +
//"SmVOU3bp2aKBa+3nxwH/9b5mS2QYHAS5eq77duxCdZM1F8ARq9En8EWwYM4aYAZFQbLr3IfIVTr6htzC" +
//"PjdDYTLqZYxO1hsH5z5C7Q==";

        string m_sTest =
"Csg7ZAiTyHJ7inmrYY36/DRESlCS9GugA4d86MP5Jnzdd0qUVTqB/QEdeCwcAWuIwe/UtTEx6w9qAz3f" +
"zqp4XFneInggquLBncHG/uXXPt2ESTw44cO+qE76Q4vf87DUOC4hwl5osfLahdOMwOoZy3qgv36AzNKR" +
"dTOPRDc8Y2Ak/Qu3M3yxjpDZzWlMMtGjVvCp9H8ZLB9EOl44nNrMTH+iOLHuS6W0Q8UmZpGb+CtyoNBJ" +
"J7Y3BVRvBBPD4xWtcdWLugwIPLarbASAITlQ4dI5tjY2xTEKNNL4FZx9EFqMZ7oBuC9T7LbOQJnvFAhE" +
"lW/hAhmTbGpiFniv2TjuvIPQS53Zl4tdYi3f3fX2slT37SO8MWOn1EiSZFKBg+QPpe86c5YYNuZFIT6x" +
"YzaWysiUQppVpIZRLUqEdCPNuCavbk/BcNUl0/k87sOalQoeIch5EZgGapG/8rxksXSmbEGaXkomZlMx" +
"lUMcE7GeVdaDOpFeJOpGKfnuT+D98iW9AsjUNtoqKQfWWLSskp/h2kgK1+1c/PCjGW41UESdNyNM1ht/" +
"evUZ0R0nPdALgwSQWm3fHdmM6knpngDd+9VWb8tJgcDfdWeG9ST7l5iVHeRKukLXGmiruTQGhwRyzPaO" +
"jK0gT5rGTYBRfaTtuvr6viulL6bJAk78Eja9AW73VrTTvvo6k46jSIDo/KCoV5RQaDnZfUpgtRV4eERG" +
"7kv0GCrtvj0+6acEuYH/21sIE+Fzq+hwpZ5S5q546+q1iwImRaEXe0mVJTSyfSjLn+LUOwcIa4ZD8YD0" +
"47w0DyVtMPW2qOYmTnaKSlxAM/zzo7Zy3n78clzJQjjx4dF1DzjtHc6a/hQOYCOnVA3U1gpCJ8hwVMjh" +
"+Cf0HrfYNzAHiDhG6vJyZfiDfNAwBwdBGfqBCdjFX7xtYEHM6gdcrjM0gek=";
        HaspFeature m_objHaspFeatue = HaspFeature.FromFeature(10);
        //HaspFeature m_objHaspFeatue1 = HaspFeature.FromFeature(1);
        private frmHasp m_objHaspForm = null;
        byte[] m_arrByte = { 0x01, 0x30, 0x30, 0x06, 0x02, 0x46, 0x53, 0x63, 0x37, 0x3a, 0x5c, 0x7e, 0x70, 0x6c, 0x46, 0x33, 0x30, 0x32, 0x5c, 0x74, 0x6f, 0x72, 0x75 };
        public static string VCode = null;
        public string decrypt(string s)
        {
            try
            {
                string r = "";

                for (int c = 0; c < s.Length; c += 6)
                {

                    int no = Convert.ToInt32(s.Substring(c, 3)) - 523;
                    byte curchar = Convert.ToByte(no.ToString());


                    r += (char)curchar;
                }

                VCode = r;
                return r;
            }
            catch (Exception mex)
            {
                return "";
            }

        }
        public CSysPro()
        {
            m_objHasp = new Hasp(m_objHaspFeatue);
            //m_objHasp1 = new Hasp(m_objHaspFeatue1);
            m_objHaspForm = new frmHasp();
            m_objHaspForm.SystemPro = this;
            if (m_objHaspForm != null)
            {

                m_objHaspForm.ExitButtonClicked += new frmHasp.ExitButtonClickedHandler(objHasp_ExitButtonClicked);
                m_objHaspForm.TryButtonClicked += new frmHasp.ExitButtonClickedHandler(objHasp_TryButtonClicked);
                m_objHaspForm.DemoButtonClicked += new frmHasp.ExitButtonClickedHandler(objHasp_DemoButtonClicked);                
            }
        }


        public string FromOtherThread
        {
            set
            {
                m_sFromOtherThread = value;
            }

        }

        public string GetFormClosed
        {
            get
            {
                return sFormClosed;
            }
        }
        bool onceLogged = false;
        public bool IsOnceLogged
        {
            get
            {
                return onceLogged;
            }
            set
            {
                onceLogged = value;
            }
        }

        public string vendorCode = null;
        Hasp hasp;
        HaspStatus status = new HaspStatus();
        public string featureStatus = null;
        public string ExtractInstrumentName()
        {
            string currentName = null;
            try
            {
                PublicClass.InstrumentSerial = "";
                vendorCode = m_sTest;
                hasp = new Hasp(new HaspFeature(10));
                status = hasp.Login(vendorCode);
                featureStatus = status.ToString();
                Int32 offset = 0;
                Int32 size = 48;
                byte[] data = new byte[size];
                HaspFile file = hasp.GetFile(HaspFileId.ReadWrite);
                file.FilePos = offset;
                status = file.Read(data, 0, data.Length);
                currentName = Encoding.ASCII.GetString(data).TrimEnd(new char[] { '\0' });
                string[] insName = currentName.Split(new string[] { "|" }, StringSplitOptions.None);
                currentName = insName[0];
                PublicClass.InstrumentSerial = insName[1];
            }
            catch (Exception ex)
            {
            }
            return currentName;
        }

        //public bool Test()
        //{
        //    try
        //    {
        //        m_objHasp.Logout();
        //        // m_objHasp1.Logout();

        //        HaspStatus status = m_objHasp.Login(m_sTest);
        //        //HaspStatus status1 = m_objHasp1.Login(decrypt(m_sTest));
        //        if (HaspStatus.StatusOk == status)
        //        {
        //            onceLogged = true;
        //            PublicClass.currentInstrument = "Impaq-Benstone";
        //            return true;

        //        }
        //        else
        //        {
        //            onceLogged = false;
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return m_bAcknowledgement;
        //    }
        //    finally
        //    {
        //    }
        //}

        public string label = null;
        public bool Test()
        {
            try
            {
                label = "";
                m_objHasp.Logout();
                PublicClass.currentInstrument = ExtractInstrumentName();
                if (PublicClass.currentInstrument == "")
                {
                    onceLogged = false;
                    return false;
                }
                else if (PublicClass.currentInstrument == "Impaq-Benstone" || PublicClass.currentInstrument == "Kohtect-C911")
                {
                    onceLogged = true;
                    return true;
                }
                else if (PublicClass.currentInstrument == "FieldPaq2")
                {
                    onceLogged = true;
                    return true;
                }
                else if (PublicClass.currentInstrument == "DI-460")
                {
                    PublicClass.currentInstrument = "SKF/DI";
                    onceLogged = true;
                    return true;
                }
                else
                {
                    label = "Wrong";
                    onceLogged = false;
                    return false;
                }
            }
            catch (Exception ex)
            {
                return m_bAcknowledgement;
            }
            finally
            {
            }
        }

        public bool Test(string sText)
        {
            bool bTest = false;
            try
            {
                if (sText == "Second")
                {
                    bTest = NewTest();
                }
                return bTest;
            }
            catch (Exception ex)
            {
                return bTest;
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private bool NewTest()
        {
            int iRlt = 0;
            int iSts = 0;
            bool bRetRes = false;

            try
            {
                object oConvRlt = (object)iRlt;
                object oConvSts = (object)iSts;

                HaspKey.Hasp(HaspService.IsHasp4, m_iSC, m_iPt, m_iAuth1, m_iAuth2, oConvRlt, null, oConvSts, null);
                bool bCID = this.GetAndCheck();

                iRlt = (int)oConvRlt;

                if (iRlt == 1 && bCID)
                {
                    bRetRes = true;
                }
                else if (iRlt != 1 && !bCID)
                {
                    bRetRes = false;
                }
                return bRetRes;
            }
            catch (Exception ex)
            {
                return bRetRes;
            }
        }

        public bool Check(byte[] Param1)
        {
            int iFirst = 0;
            int iSecond = 0;
            int iThird = 0;
            bool bEnc = false;

            try
            {
                iSecond = Param1.Length;

                object objSecConv = (object)iSecond;
                object objThirdConv = (object)iThird;

                HaspKey.Hasp(HaspService.EncodeData, m_iSC, m_iPt, m_iAuth1, m_iAuth2, null, objSecConv, objThirdConv, Param1);

                iThird = (int)objThirdConv;
                if (iThird == 0)
                {
                    bEnc = true;
                }
                else
                    bEnc = false;

                return bEnc;
            }
            catch (Exception ex)
            {
                return bEnc;

            }
        }

        public bool UnCheck(byte[] Param2)
        {
            int iFirst = 0;
            int iSecond = 0;
            int iThird = 0;
            bool bEnc = false;

            try
            {
                iSecond = Param2.Length;

                object objSecConv = (object)iSecond;
                object objThirdConv = (object)iThird;

                HaspKey.Hasp(HaspService.DecodeData, m_iSC, m_iPt, m_iAuth1, m_iAuth2, null, objSecConv, objThirdConv, Param2);


                iThird = (int)objThirdConv;
                if (iThird == 0)
                {
                    bEnc = true;
                }
                else
                    bEnc = false;

                return bEnc;
            }
            catch (Exception ex)
            {
                return bEnc;

            }
        }

        void objHasp_ExitButtonClicked()
        {
            try
            {
                if (ExitButtonClicked != null)
                    this.ExitButtonClicked();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }
        
        public void OpenFrm()
        {
            try
            {
                m_objHaspForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                if (m_sFromOtherThread == "FromOtherThread")
                {
                    m_objHaspForm.DisBts();
                    m_objHaspForm.ShowDialog();
                }
                else
                {                    
                    m_objHaspForm.ShowDialog();
                }                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        void objHasp_DemoButtonClicked()
        {
            try
            {
                if (DemoButtonClick != null)
                    DemoButtonClick();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        void objHasp_TryButtonClicked()
        {
            try
            {
                if (TryButtonClicked != null)
                    TryButtonClicked();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.Message);
            }

        }

        public void DDB()
        {
            if (m_objHaspForm != null)
            {
                m_objHaspForm.DisBts();
                m_objHaspForm.Close();
            }
        }

        public void DCB()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }

        }

        public void ECB()
        {
            try
            {
                if (m_objHaspForm != null)
                {                    
                    m_objHaspForm.Visible = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private bool GetAndCheck()
        {
            bool bCheckID = false;
            int idLw = 0;
            int idHgh = 0;
            int iSts = 0;

            try
            {

                object oConvidLw = (object)idLw;
                object oConvidHigh = (object)idHgh;
                object oConvSts = (object)iSts;

                HaspKey.Hasp(HaspService.HaspID, m_iSC, m_iPt, m_iAuth1, m_iAuth2, oConvidLw, oConvidHigh, oConvSts, null);

                idLw = (int)oConvidLw;
                idHgh = (int)oConvidHigh;

                int iNewOne = idHgh + idLw;

                if (iNewOne == 22545 || iNewOne == 25626)
                    bCheckID = true;
                else
                    bCheckID = false;

                return bCheckID;

            }
            catch (Exception ex)
            {
                return bCheckID;

            }
        }

    }
}



#endregion

