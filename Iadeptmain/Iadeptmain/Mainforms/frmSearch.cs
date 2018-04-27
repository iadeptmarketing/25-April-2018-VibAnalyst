using Iadeptmain.BaseUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace Iadeptmain.Mainforms
{
    public partial class frmSearch : DevComponents.DotNetBar.Office2007Form
    {
       // private ucSearchNav m_objSearchControl = null;
        IadeptUserControl _objBaseControl = null;
        frmIAdeptMain m_objIAdeptControl = null;
        public frmSearch()
        {
            InitializeComponent();
           
        }
        public frmIAdeptMain Iadept
        {
            get
            {
                return m_objIAdeptControl;
            }
            set
            {
                m_objIAdeptControl = value;
            }
        }
        public IadeptUserControl MainControl
        {
            get
            {
                return _objBaseControl;
            }//end(get)
            set
            {
                _objBaseControl = value;
            }//end(set)
        }


      
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFind.Text != "" && cmbField.SelectedItem != null)
                {
                    _objBaseControl.searchClicked = true;
                    _objBaseControl.SearchNodes(txtFind.Text, cmbField.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {                
                System.Diagnostics.Debug.WriteLine(ex.Message, ex.StackTrace);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                _objBaseControl.CloseSearch();
                this.Close();
            }
            catch (Exception ex)
            {
            }
        }

        private void frmFind_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Iadept.IsFindClosed = true;
                Iadept.IsFindReplaceClosed = true;
            }
            catch (Exception ex)
            {
            }
        }//end( public iAdeptBaseUserControl MainControl)

    }
}
