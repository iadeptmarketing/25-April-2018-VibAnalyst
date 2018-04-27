using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Iadeptmain.BaseUserControl;
using Iadeptmain.Mainforms;
using System.Data.Odbc;

namespace Iadeptmain.BaseUserControl
{
    
    class CDataDaseWork
    {
        private string m_sDateBaseName = null;
        private string m_sConnectionString = null;
        OdbcDataAdapter m_objDataAdapter = null;
        private frmIAdeptMain m_objBaseMainForm = null;
        private frmgraphcontrol m_objBaseControl = null;

        public CDataDaseWork()
        {
           
        }

        public string DataBaseName
        {
            set
            {
                m_sDateBaseName = value; 
            }
        }

        public frmIAdeptMain BaseMainForm
        {
            set
            {
                m_objBaseMainForm = value;
            }
        }

        public frmgraphcontrol BaseControl
        {
            set
            {
                m_objBaseControl = value;
            }
        }

    }
}
