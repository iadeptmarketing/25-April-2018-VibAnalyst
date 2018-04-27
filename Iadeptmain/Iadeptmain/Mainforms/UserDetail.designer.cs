namespace Iadeptmain.Mainforms
{
    partial class frmUserDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserDetail));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dgvUserDetail = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colSr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDatabase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUSettings = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gpUserDetail = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.tsbtnFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserDetail)).BeginInit();
            this.gpUserDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnFile,
            this.tsbtnEdit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(645, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dgvUserDetail
            // 
            this.dgvUserDetail.AllowUserToAddRows = false;
            this.dgvUserDetail.AllowUserToOrderColumns = true;
            this.dgvUserDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUserDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSr,
            this.colUserName,
            this.colPassword,
            this.colLogin,
            this.colLoginDate,
            this.colID,
            this.colDatabase,
            this.colUSettings,
            this.colDelete});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserDetail.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvUserDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvUserDetail.Name = "dgvUserDetail";
            this.dgvUserDetail.ReadOnly = true;
            this.dgvUserDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUserDetail.Size = new System.Drawing.Size(639, 355);
            this.dgvUserDetail.TabIndex = 2;
            this.dgvUserDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserDetail_CellContentClick);
            this.dgvUserDetail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvUserDetail_MouseClick);
            // 
            // colSr
            // 
            this.colSr.HeaderText = "Sr.No.";
            this.colSr.Name = "colSr";
            this.colSr.ReadOnly = true;
            this.colSr.Width = 63;
            // 
            // colUserName
            // 
            this.colUserName.HeaderText = "User Name";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            this.colUserName.Width = 84;
            // 
            // colPassword
            // 
            this.colPassword.HeaderText = "Password";
            this.colPassword.Name = "colPassword";
            this.colPassword.ReadOnly = true;
            this.colPassword.Width = 78;
            // 
            // colLogin
            // 
            this.colLogin.HeaderText = "Login";
            this.colLogin.Name = "colLogin";
            this.colLogin.ReadOnly = true;
            this.colLogin.Width = 57;
            // 
            // colLoginDate
            // 
            this.colLoginDate.HeaderText = "Login Date";
            this.colLoginDate.Name = "colLoginDate";
            this.colLoginDate.ReadOnly = true;
            this.colLoginDate.Width = 83;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            this.colID.Width = 43;
            // 
            // colDatabase
            // 
            this.colDatabase.HeaderText = "DataBase";
            this.colDatabase.Name = "colDatabase";
            this.colDatabase.ReadOnly = true;
            this.colDatabase.Visible = false;
            this.colDatabase.Width = 79;
            // 
            // colUSettings
            // 
            this.colUSettings.DataPropertyName = "None";
            this.colUSettings.HeaderText = "User Setting";
            this.colUSettings.Name = "colUSettings";
            this.colUSettings.ReadOnly = true;
            this.colUSettings.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colUSettings.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colUSettings.Text = "Change Settings";
            this.colUSettings.UseColumnTextForButtonValue = true;
            this.colUSettings.Width = 91;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDelete.Text = "Delete";
            this.colDelete.UseColumnTextForButtonValue = true;
            this.colDelete.Width = 19;
            // 
            // gpUserDetail
            // 
            this.gpUserDetail.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpUserDetail.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpUserDetail.Controls.Add(this.dgvUserDetail);
            this.gpUserDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpUserDetail.Location = new System.Drawing.Point(0, 25);
            this.gpUserDetail.Name = "gpUserDetail";
            this.gpUserDetail.Size = new System.Drawing.Size(645, 377);
            // 
            // 
            // 
            this.gpUserDetail.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpUserDetail.Style.BackColorGradientAngle = 90;
            this.gpUserDetail.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpUserDetail.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpUserDetail.Style.BorderBottomWidth = 1;
            this.gpUserDetail.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpUserDetail.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpUserDetail.Style.BorderLeftWidth = 1;
            this.gpUserDetail.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpUserDetail.Style.BorderRightWidth = 1;
            this.gpUserDetail.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpUserDetail.Style.BorderTopWidth = 1;
            this.gpUserDetail.Style.CornerDiameter = 4;
            this.gpUserDetail.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpUserDetail.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpUserDetail.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.gpUserDetail.Style.TextShadowColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor;
            this.gpUserDetail.TabIndex = 4;
            this.gpUserDetail.Text = "Users";
            // 
            // tsbtnFile
            // 
            this.tsbtnFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNew});
            this.tsbtnFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFile.Image")));
            this.tsbtnFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFile.Name = "tsbtnFile";
            this.tsbtnFile.Size = new System.Drawing.Size(38, 22);
            this.tsbtnFile.Text = "File";
            // 
            // tsbtnNew
            // 
            this.tsbtnNew.Name = "tsbtnNew";
            this.tsbtnNew.Size = new System.Drawing.Size(152, 22);
            this.tsbtnNew.Text = "New";
            this.tsbtnNew.Click += new System.EventHandler(this.tsbtnNew_Click);
            // 
            // tsbtnEdit
            // 
            this.tsbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEdit.Image")));
            this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEdit.Name = "tsbtnEdit";
            this.tsbtnEdit.Size = new System.Drawing.Size(31, 22);
            this.tsbtnEdit.Text = "Edit";
            this.tsbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
            // 
            // frmUserDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(645, 402);
            this.ControlBox = false;
            this.Controls.Add(this.gpUserDetail);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserDetail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Detail";
            this.Load += new System.EventHandler(this.frmUserDetail_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserDetail)).EndInit();
            this.gpUserDetail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnEdit;
        private DevComponents.DotNetBar.Controls.GroupPanel gpUserDetail;
        private System.Windows.Forms.ToolStripDropDownButton tsbtnFile;
        private System.Windows.Forms.ToolStripMenuItem tsbtnNew;
        public DevComponents.DotNetBar.Controls.DataGridViewX dgvUserDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDatabase;
        private System.Windows.Forms.DataGridViewButtonColumn colUSettings;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;

    }
}