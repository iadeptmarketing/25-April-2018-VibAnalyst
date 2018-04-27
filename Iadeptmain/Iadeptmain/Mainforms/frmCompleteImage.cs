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

namespace Iadeptmain.Mainforms
{
    public partial class frmCompleteImage : DevExpress.XtraEditors.XtraForm
    {
        Image m_imgDisplayImage = null;
        public frmCompleteImage()
        {
            InitializeComponent();
        }

        public Image SetImage
        {
            get
            {
                return m_imgDisplayImage;
            }
            set
            {
                m_imgDisplayImage = value;
                if (m_imgDisplayImage != null)
                {
                    
                    mPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    mPicBox.Image = m_imgDisplayImage;
                }
            }
        }

        public string ImageName
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }


    }
}