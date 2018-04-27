namespace Iadeptmain.Reports
{
    partial class frmHierrarchySelection
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
            this.gcHierarchy = new DevExpress.XtraEditors.GroupControl();
            this.xscHierarchy = new DevExpress.XtraEditors.XtraScrollableControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblHSelect = new DevExpress.XtraEditors.LabelControl();
            this.chklHierarchy = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chklSelectNode = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcHierarchy)).BeginInit();
            this.gcHierarchy.SuspendLayout();
            this.xscHierarchy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklHierarchy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chklSelectNode)).BeginInit();
            this.SuspendLayout();
            // 
            // gcHierarchy
            // 
            this.gcHierarchy.Controls.Add(this.xscHierarchy);
            this.gcHierarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHierarchy.Location = new System.Drawing.Point(0, 0);
            this.gcHierarchy.Name = "gcHierarchy";
            this.gcHierarchy.Size = new System.Drawing.Size(233, 390);
            this.gcHierarchy.TabIndex = 0;
            // 
            // xscHierarchy
            // 
            this.xscHierarchy.Controls.Add(this.btnOK);
            this.xscHierarchy.Controls.Add(this.labelControl2);
            this.xscHierarchy.Controls.Add(this.lblHSelect);
            this.xscHierarchy.Controls.Add(this.chklHierarchy);
            this.xscHierarchy.Controls.Add(this.chklSelectNode);
            this.xscHierarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xscHierarchy.Location = new System.Drawing.Point(2, 21);
            this.xscHierarchy.Name = "xscHierarchy";
            this.xscHierarchy.Size = new System.Drawing.Size(229, 367);
            this.xscHierarchy.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(130, 325);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 136);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(196, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Please Select Node for report generation";
            // 
            // lblHSelect
            // 
            this.lblHSelect.Location = new System.Drawing.Point(19, 14);
            this.lblHSelect.Name = "lblHSelect";
            this.lblHSelect.Size = new System.Drawing.Size(143, 13);
            this.lblHSelect.TabIndex = 2;
            this.lblHSelect.Text = "Please select report hierarchy";
            // 
            // chklHierarchy
            // 
            this.chklHierarchy.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.chklHierarchy.Location = new System.Drawing.Point(19, 41);
            this.chklHierarchy.Name = "chklHierarchy";
            this.chklHierarchy.Size = new System.Drawing.Size(186, 79);
            this.chklHierarchy.TabIndex = 1;
            this.chklHierarchy.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chklHierarchy_ItemCheck);
            this.chklHierarchy.SelectedIndexChanged += new System.EventHandler(this.chklHierarchy_SelectedIndexChanged);
            // 
            // chklSelectNode
            // 
            this.chklSelectNode.Location = new System.Drawing.Point(19, 160);
            this.chklSelectNode.Name = "chklSelectNode";
            this.chklSelectNode.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.chklSelectNode.Size = new System.Drawing.Size(186, 142);
            this.chklSelectNode.TabIndex = 0;
            this.chklSelectNode.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chklSelectNode_ItemCheck);
            // 
            // frmHierrarchySelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 390);
            this.Controls.Add(this.gcHierarchy);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHierrarchySelection";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hierarchy Selection";
            this.Load += new System.EventHandler(this.frmHierrarchySelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcHierarchy)).EndInit();
            this.gcHierarchy.ResumeLayout(false);
            this.xscHierarchy.ResumeLayout(false);
            this.xscHierarchy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklHierarchy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chklSelectNode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcHierarchy;
        private DevExpress.XtraEditors.XtraScrollableControl xscHierarchy;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblHSelect;
        private DevExpress.XtraEditors.CheckedListBoxControl chklHierarchy;
        private DevExpress.XtraEditors.CheckedListBoxControl chklSelectNode;
    }
}