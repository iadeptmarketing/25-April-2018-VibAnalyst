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
using Iadeptmain.Mainforms;
using Iadeptmain.GlobalClasses;

namespace Iadeptmain.Mainforms
{
    public partial class frmNotes : DevExpress.XtraEditors.XtraForm
    {

        frmIAdeptMain _objMain;
        public frmNotes()
        {
            InitializeComponent();
        }

        string notesDesc = null;
        string dNotes = null;
        int dId;
        int nid;

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

        private void frmNotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                 _objMain.fillform();
            }
            catch { }
        }

        private void frmNotes_Load(object sender, EventArgs e)
        {
            try
            {
                filldgvNotes();
            }
            catch { }
        }

        private void DgvNotes_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                DgvNotes.Rows[e.RowIndex].Cells["colLevel"].Value = "--Select--";
            }
            catch { }
        }

        public void  filldgvNotes()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DbClass.getdata(CommandType.Text, "call Get_Notes");
                int i = 0;
                  DgvNotes.Rows.Clear();
                foreach (DataRow dr in dt.Rows )
                {
                     //Notes_Desc , Note_type  , Date,notes_id 
                    DgvNotes.Rows.Add();
                    DgvNotes.Rows[i].Cells["colID"].Value = Convert.ToString(dr["notes_id"]);
                    DgvNotes.Rows[i].Cells["colDate"].Value = Convert.ToString(dr["Date"]);
                    DgvNotes.Rows[i].Cells["colNotes"].Value = Convert.ToString(dr["Notes_Desc"]);
                    DgvNotes.Rows[i].Cells["colLevel"].Value = SETLevel(Convert.ToInt32(PublicClass.DefVal(Convert.ToString(dr["Note_type"]).Trim(), "0")));
                    i = i + 1;
                }
            }
            catch 
            { }
        }


        public string  SETLevel(int i)
        {
            string LevelValue="";
            if (i == 1)
            {
              LevelValue = "Machine";

            }
            else    if (i == 2)
            {
                LevelValue = "Point";
            }
            else
            {
                LevelValue = "--Select--";
            }
            return LevelValue;
        }

        public int SETLevel(string LevelValue)
        {
            int i = 0;
            if (LevelValue == "Machine")
            {
                i = 1;
            }
            else
            {
                i = 2;
            }
            return i;
        }

        private void DgvNotes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 notesDesc = Convert.ToString(DgvNotes.CurrentRow.Cells["colNotes"].Value).Trim();
                 if (DgvNotes.CurrentCell.ColumnIndex == 1 && Convert.ToString(DgvNotes.Rows[e.RowIndex].Cells["colNotes"].Value).Trim() != "")
                 {
                     DgvNotes.Rows[e.RowIndex].Cells["colDate"].Value = Convert.ToString(PublicClass.GetDatetime());
                 }
            }
            catch { }
        }

        private void DgvNotes_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    int ee = DgvNotes.CurrentRow.Index;
                    string bidd = PublicClass.DefVal(Convert.ToString(DgvNotes.CurrentRow.Cells["colID"].Value).Trim(), "0");
                    DbClass.executequery(CommandType.StoredProcedure, "call Delete_Notes('" + bidd + "')");
                    DgvNotes.Rows.RemoveAt(ee);
                }
            }
            catch
            {
            }
        }

      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool addrow = true;
            for (int a = 0; a < DgvNotes.Rows.Count;a++ )
            {
                if (Convert.ToString(DgvNotes.Rows[a].Cells["colNotes"].Value).Trim()=="")
                {
                    addrow = false;
                }

            }
            if (addrow == true)
            {
                _objMain.lblStatus.Caption = "Status: Adding New Notes";
                DgvNotes.Rows.Add();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                int ee = DgvNotes.CurrentRow.Index;
                string bidd = PublicClass.DefVal(Convert.ToString(DgvNotes.CurrentRow.Cells["colID"].Value).Trim(), "0");
                DbClass.executequery(CommandType.StoredProcedure, "call Delete_Notes('" + bidd + "')");
                DgvNotes.Rows.RemoveAt(ee);
                _objMain.lblStatus.Caption = "Status: Deleting Existing Notes";
            }
            catch 
            {
            }
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int a = 0; a < DgvNotes.Rows.Count; a++)
                {
                    notesDesc = Convert.ToString(DgvNotes.Rows[a].Cells["colNotes"].Value).Trim();
                    nid = Convert.ToInt32(PublicClass.DefVal(Convert.ToString(DgvNotes.Rows[a].Cells["colID"].Value).Trim(), "0"));
                    //int nIndex = DgvNotes.CurrentRow.Index;

                    if (notesDesc == "")
                    {
                        return;
                    }

                    DataTable cdt = new DataTable();
                    cdt = DbClass.getdata(CommandType.StoredProcedure, " call Get_cNotes('" + nid + "') ");
                    foreach (DataRow dr in cdt.Rows)
                    {
                        dNotes = Convert.ToString(dr["Notes_Desc"]);
                        dId = Convert.ToInt32(dr["Note_type"]);
                    }

                    if (cdt.Rows.Count - 1 < 0)
                    {
                        DbClass.executequery(CommandType.StoredProcedure, "call Insert_Notes('" + notesDesc + "' , '" + SETLevel(Convert.ToString(DgvNotes.Rows[a].Cells["colLevel"].Value).Trim()) + "' , '" + PublicClass.GetDatetime() + "'  )");                    
                    }
                    else
                    {
                        if (dNotes != notesDesc || dId != nid)
                        {
                            DbClass.executequery(CommandType.StoredProcedure, "call Update_Notes('" + notesDesc + "'  , '" + PublicClass.GetDatetime() + "' , '" + SETLevel(Convert.ToString(DgvNotes.Rows[a].Cells["colLevel"].Value).Trim()) + "' , ' " + nid + "' )");
                         
                        }
                    }
                }
                if (DgvNotes.Rows.Count > 0)
                {
                    MessageBox.Show("Data Saved Successfully");
                    _objMain.lblStatus.Caption = "Status: Notes Saved Successfully";
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void DgvNotes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (DgvNotes.IsCurrentCellDirty)
                {
                    DgvNotes.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch { }
        }

     

    }
}

