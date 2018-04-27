using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Iadeptmain.BaseUserControl;
using System.Collections;
using Iadeptmain.GlobalClasses;
using DevExpress.XtraCharts;
using System.IO;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using com.iAM.chart2dnet;
using System.Drawing.Printing;
using System.Drawing.Imaging;


namespace Iadeptmain.Mainforms
{
    public partial class frmDashboardRibbon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmDashboardRibbon()
        {
            InitializeComponent();
        }
        frmAllDashboard objalldash = null;
        frmPointDashboard objPointDash = null;
        public string sSelectedRibbonPage = null;
        frmIAdeptMain _objMain = null;
        IadeptUserControl objUserControl = null;

        public frmIAdeptMain MainForm
        {
            get
            {
                return _objMain;
            }

            set
            {
                _objMain = value;

            }
        }

        public IadeptUserControl UserControl
        {
            get
            {
                return objUserControl;
            }

            set
            {
                objUserControl = value;
            }
        }

        //public IadeptUserControl usercontrol { get; set; }
        public frmAllDashboard allDash
        {
            get
            {
                return objalldash;
            }

            set
            {
                objalldash = value;
            }
        }

        public void showAlPointData(int mID)
        {
            try
            {
                objPointDash = new frmPointDashboard();
                objPointDash.DashMain = this;
                pnlDashboard.Visible = true;
                pnlDashboard.Controls.Clear();
                objPointDash.MdiParent = this;
                pnlDashboard.Controls.Add(objPointDash);
                objPointDash.Dock = DockStyle.Fill;
                objPointDash.Show();
                objPointDash.fillPointyList(PublicClass.CurrentMachineID);
                btnBack.Enabled = true;
                bbback.Enabled = true;
            }
            catch
            {

            }
        }
        private void bbPie_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                objalldash = new frmAllDashboard();
                objalldash.DashMain = this;
                objalldash.UserControl = objUserControl;
                objalldash.MainForm = _objMain;

                pnlDashboard.Controls.Clear();
                pnlDashboard.Visible = true;
                pnlLblDasboard.Visible = true;
                objalldash.MdiParent = this;
                pnlDashboard.Controls.Add(objalldash);
                objalldash.Dock = DockStyle.Fill;
                objalldash.Show();
                btnBack.Visible = false;
                btnBack.Enabled = false;
                bbback.Enabled = false;
            }
            catch { }
        }

        private void frmDashboardRibbon_Load(object sender, EventArgs e)
        {
            try
            {
                bbback.Enabled = false;
                btnBack.Visible = false;
            }
            catch { }
        }
        
        private void frmDashboardRibbon_FormClosed(object sender, FormClosedEventArgs e)
        {
            _objMain.WindowState = FormWindowState.Maximized;
        }

     
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
        //        objalldash.level = PublicClass.CurrentLevel;
        //        objalldash.FunctionForBack(PublicClass.CurrentLevel);
        //        pnlDashboard.Controls.Clear();
        //        pnlDashboard.Visible = true;
        //        pnlLblDasboard.Visible = true;
        //        objalldash.MdiParent = this;
        //        pnlDashboard.Controls.Add(objalldash);
        //        objalldash.Dock = DockStyle.Fill;
        //        objalldash.Show();    
            }
            catch { }
        }

        private void bbcopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                screenCapture();
            }
            catch { }
        }

        void PrintBitmap(Bitmap bm)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawImage(bm, Point.Empty); // adjust this to put the image elsewhere                
                ev.HasMorePages = false;
            };
            doc.DefaultPageSettings.Landscape = true;
            doc.Print();
        }

        public void screenCapture()
        {
            try
            {
                Point curPos = new Point(Cursor.Position.X, Cursor.Position.Y);
                System.Threading.Thread.Sleep(250);
                Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));
                Bitmap bitmap = new Bitmap(bounds.Width, 715);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(Point.Empty, Point.Empty, bitmap.Size);
                Image img = (Image)bitmap;               
                Clipboard.SetImage(img);
                  DialogResult Drslt = MessageBox.Show("Press Yes to Print Graph" + "\n" + "Press NO to Copy Graph", "Copy", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                  if (Drslt == DialogResult.Yes)
                  {
                      try
                      {
                          PrintBitmap(bitmap);
                      }
                      catch { }
                  }
                  else
                  {
                      MessageBox.Show(this, "Copied on Clipboard", "DashBoard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
            }
            catch
            {
                MessageBox.Show(this, "Error in Copy", "DashBoard", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bbback_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                objalldash.level = PublicClass.CurrentLevel;
                objalldash.FunctionForBack(PublicClass.CurrentLevel);
                pnlDashboard.Controls.Clear();
                pnlDashboard.Visible = true;
                pnlLblDasboard.Visible = true;
                objalldash.MdiParent = this;
                pnlDashboard.Controls.Add(objalldash);
                objalldash.Dock = DockStyle.Fill;
                objalldash.Show();
            }
            catch { }
        }

    }
}