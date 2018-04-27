using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace Iadeptmain.Mainforms
{
    public partial class WaitForm2 : WaitForm
    {
        public WaitForm2()
        {
            InitializeComponent();
           // this.pictureBox1.AutoHeight = true;
           
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            //base.SetCaption(caption);
            //this.pictureBox1.Caption = caption;
            //this.pictureBox1.Cursor = caption;
        }
        public override void SetDescription(string description)
        {
            //base.SetDescription(description);
            //this.pictureBox1.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}