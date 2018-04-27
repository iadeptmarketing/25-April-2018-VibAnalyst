using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using Iadeptmain.GlobalClasses;//using dotnetCHARTING.WinForms.MySql.Data.MySqlClient;

namespace Iadeptmain.Reports
{
    public partial class RouteDetail : DevExpress.XtraEditors.XtraForm
    {
        public RouteDetail()
        {
            InitializeComponent();
        }
        OdbcCommand objCommand = null;
        OdbcDataReader objDataReader = null;
        private void RouteDetail_Load(object sender, EventArgs e)
        {
            Time = null;
            Route = null;
            try
            {
                cmbRouteName.Properties.Items.Clear();

                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "Select Route_Name from route.route_data where databasename='"+PublicClass.User_DataBase+"'");

                foreach (DataRow dr in dt.Rows)
                {
                    cmbRouteName.Properties.Items.Add((dr["Route_Name"].ToString()));
                }              
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbRouteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbDTime.Properties.Items.Clear();
                Route = cmbRouteName.SelectedItem.ToString();
                DataTable dt1 = new DataTable();
                dt1 = DbClass.getdata(CommandType.Text, "Select Date from route.route_data where route_name='" + cmbRouteName.SelectedItem.ToString() + "'");
                foreach (DataRow dr in dt1.Rows)
                {
                    cmbDTime.Properties.Items.Add((dr["Date"].ToString()));
                }
                if (cmbDTime.Properties.Items.Count == 0)
                {
                    cmbDTime.Properties.Items.Add(("No DownLoad Date"));
                }
                if (cmbRouteName.SelectedIndex != -1)
                {
                    cmbDTime.Visible = true;
                    label2.Visible = true;
                }
            }
            catch (Exception ex)
            {
            }
        }
        string Time = null;
        string Route = null;
        public string SelectedTime
        {
            get
            {
                return Time;
            }
        }
        public string SelectedRoute
        {
            get
            {
                return Route;
            }
        }
        private void cmbDTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDTime.SelectedIndex != -1)
                {
                    Time = cmbDTime.SelectedItem.ToString();
                    button1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }
        public bool IsOKClicked
        {
            get
            {
                return OKClicked;
            }
        }
        bool OKClicked = false;
        private void button1_Click(object sender, EventArgs e)
        {
            OKClicked = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OKClicked = false;
            this.Close();
        }

       
    }
}
