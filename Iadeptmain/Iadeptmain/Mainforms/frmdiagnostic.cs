using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Iadeptmain.GlobalClasses;
using Iadeptmain.BaseUserControl;

namespace Iadeptmain.Mainforms
{
    public partial class frmDiagnostic : DevExpress.XtraEditors.XtraForm
    {
        frmIAdeptMain objMain = null;
        PointGeneral1 objPointGeneral = null;
        IadeptUserControl objUserControl = null;
        public frmDiagnostic()
        {
            InitializeComponent();
        }
        public IadeptUserControl usercontrol
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

        public PointGeneral1 ptMain
        {
            get
            {
                return objPointGeneral;
            }
            set
            {
                objPointGeneral = value;
            }
        }

        private void frmDiagnostic_Load(object sender, EventArgs e)
        {
            try
            {               
                objPointGeneral.MainForm1 = Main;
                PublicClass.flag = true;
                objPointGeneral.usercontrol = objUserControl;               
                objPointGeneral.allGraphdiag(PublicClass.GraphClicked,PublicClass.flag);                
            }
            catch
            {

            }
            
        }

        private void dgvRPM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRPM.ReadOnly = true;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            txtDescription.ReadOnly = true;
        }


    }
}