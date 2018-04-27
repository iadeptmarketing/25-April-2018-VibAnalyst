using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Security.Cryptography;
using Iadeptmain.Classes;

namespace Iadeptmain.Mainforms
{
    public partial class frmtest : DevExpress.XtraEditors.XtraForm
    {
        public frmtest()
        {
            InitializeComponent();
        }

        //private void DecryptFile(string inputFile, string outputFile)
        //{
        //    string password = inputFile; // Your Key Here

        //        UnicodeEncoding UE = new UnicodeEncoding();
        //        byte[] key = UE.GetBytes(password);

        //        FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

        //        RijndaelManaged RMCrypto = new RijndaelManaged();

        //        CryptoStream cs = new CryptoStream(fsCrypt,
        //            RMCrypto.CreateDecryptor(key, key),
        //            CryptoStreamMode.Read);

        //        FileStream fsOut = new FileStream(outputFile, FileMode.Create);

        //        int data;
        //        while ((data = cs.ReadByte()) != -1)
        //            fsOut.WriteByte((byte)data);

        //        fsOut.Close();
        //        cs.Close();
        //        fsCrypt.Close();

        //}
        
        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
           
        }

        public static string ConvertHex(String hexString)
        {
            try
            {
                string ascii = string.Empty;
                for (int i = 0; i < hexString.Length; i += 2)
                {
                    String hs = string.Empty;
                    hs = hexString.Substring(i, 2);
                    uint decval = System.Convert.ToUInt32(hs, 16);
                    char character = System.Convert.ToChar(decval);
                    ascii += character;
                }
                return ascii;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }


        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }


        public void main()
        {
            try
            {
                StringBuilder DataX = new StringBuilder();
                listBox1.Items.Clear();
                // int i = 0;
                string filename = "C:\\Users\\SONY\\Desktop\\dda\\dd.dda";
               // string filename = "C:\\Users\\SONY\\Desktop\\dda\\D0269.dda";
                // string filename = "C:\\VibrationData\\NewVMU\\Acq 1\\2016_07_26.day";
                // string filename = "c:\\Users\\Iadept\\Desktop\\kohtect data\\demo-2\\routes.src";
                using (FileStream objInput = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    byte[] MainArr = new byte[(int)objInput.Length];
                    int contents = objInput.Read(MainArr, 0, (int)objInput.Length);
                    byte[] NameExtracter = new byte[contents];


                    //for (int NmCtr = 0; NmCtr < MainArr.Length; NmCtr++)
                    //{
                    //    DataX.Append(Convert.ToString(MainArr[NmCtr]));
                    //    DataX.Append(",");
                    //}

                    if (!Directory.Exists("c:\\vvvtemp\\"))
                    {
                        Directory.CreateDirectory("c:\\vvvtemp\\");
                    }

                    FileStream aa = new FileStream("c:\\vvvtemp\\" + "DDA" + ".txt", FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(aa);

                    for (int i = 0; i < MainArr.Length; i++)
                    {
                        sw.Write(MainArr[i] + "||");
                    }

                    FileStream aa1 = new FileStream("c:\\vvvtemp\\" + "Decode" + ".txt", FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter sw1 = new StreamWriter(aa1);
                    byte[] fs = new byte[2];

                    string ComponentName = null;
                  

                    for (int i = 1120; i < 5000; i++)
                    {
                        NameExtracter[i] = MainArr[i];

                        //fs[0] = MainArr[i];
                        //fs[1] = MainArr[i + 1];
                        //string byteval = Common.DeciamlToHexadeciaml1(Convert.ToInt32(fs[0].ToString())) + Common.DeciamlToHexadeciaml1(Convert.ToInt32(fs[1].ToString()));
                        //int ival = Common.HexadecimaltoDecimal(byteval);                       
                    }
                    ComponentName = Encoding.ASCII.GetString(NameExtracter);
                    sw1.Write(ComponentName + "||");


                }
            }
            catch { }
        }


        public void main1()
        {
          
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] exampleByteArray = new byte[] { 0x00, 0x52, 0x50, 0x4D, 0x20, 0x3D, 0x20, 0x32, 0x35, 0x35, 0x2C, 0x36, 0x30, 0x0A, 0x00 };
            //exampleByteArray = exampleByteArray.Where(x => x != 0x00).ToArray(); // not sure this is OK with your requirements 
            //string myString = System.Text.Encoding.ASCII.GetString(exampleByteArray);





            main();
            //string output=@"C:\Users\Iadept\Desktop\n\routes.txt";
            //DecryptFile(@"C:\Users\Iadept\Desktop\n\routes.src", output);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}