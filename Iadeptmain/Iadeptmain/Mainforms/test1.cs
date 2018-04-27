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
using System.Collections;
using Iadeptmain.Classes;
using Iadeptmain.GlobalClasses;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace Iadeptmain.Mainforms
{
    public partial class test1 : DevExpress.XtraEditors.XtraForm
    {
        ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        CultureInfo cul;   
        public frmIAdeptMain MainForm = null;
        ImpaqHandler m_objImpaqHandler = new ImpaqHandler();
        ArrayList arrXYVals = new ArrayList();
        PointGeneral1 objpoint = new PointGeneral1();
        
        public frmIAdeptMain MainForm1
        {
            get
            {
                return MainForm;
            }
            set
            {
                MainForm = value;
            }
        }
        public test1()
        {
            InitializeComponent();
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            labelControl1.Text = res_man.GetString("label_text", cul);
            switch_language();
        }

        private void switch_language()
        {
            cul = CultureInfo.CreateSpecificCulture("fr"); 
        }

        private void test1_Load(object sender, EventArgs e)
        {
            res_man = new ResourceManager("MultiLanguageApp.Resource.Res", typeof(test1).Assembly);
        }

    }
}