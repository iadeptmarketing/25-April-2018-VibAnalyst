using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Mainforms
{
    public partial class SideBandTrend : DevExpress.XtraEditors.XtraForm
    {
        public SideBandTrend()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        frmIAdeptMain objMainForm = null;

        public frmIAdeptMain MainForm
        {
            get
            {
                return objMainForm;
            }
            set
            {
                objMainForm = value;
            }
        }

        public string FreqVal
        {
            set
            {
                tbFreq.Text = value;
            }
        }

        int ival = 10;
        public int _Value
        {
            get
            {
                return ival;
            }
        }

        double iFreq = 100;
        public double _Freq
        {
            get
            {
                return iFreq;
            }
        }

        private int FillValue()
        {
            int Value = 10;
            int Freq = 0;
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select * from SideBandTrend");
                foreach (DataRow dr in dt.Rows)
                {
                    Value = Convert.ToInt32(dr["Value"]);
                }
            }
            catch { }
            return Value;
        }

        private int FillValueFreq()
        {
            int Freq = 0;
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "select * from SideBandTrend");
                foreach (DataRow dr in dt.Rows)
                {
                    Freq = Convert.ToInt32(dr["Freq"]);
                }
            }
            catch { }
            return Freq;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int ValChk = (Convert.ToInt32(tbBandValue.Text.ToString()));
                if (ValChk <= 100)
                {
                    DbClass.executequery(CommandType.Text, "truncate table SideBandTrend");
                    DbClass.executequery(CommandType.Text, "insert into SideBandTrend(Value,Freq) values('" + tbBandValue.Text.ToString() + "','" + tbFreq.Text.ToString() + "')");

                    ival = ValChk;
                    iFreq = Convert.ToDouble(tbFreq.Text.ToString());
                    this.Close();
                }
            }
            catch { }
        }

        private void SideBandTrend_Shown(object sender, EventArgs e)
        {
            try
            {
                tbBandValue.Text = Convert.ToString(FillValue());
                tbFreq.Text = Convert.ToString(FillValueFreq());
            }
            catch (Exception ex)
            {
            }
        }
    }
}