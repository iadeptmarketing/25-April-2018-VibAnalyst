namespace Iadeptmain.Reports
{
    partial class frmreportselection
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAcc = new DevExpress.XtraEditors.CheckEdit();
            this.chkVel = new DevExpress.XtraEditors.CheckEdit();
            this.chkDisp = new DevExpress.XtraEditors.CheckEdit();
            this.chkBer = new DevExpress.XtraEditors.CheckEdit();
            this.gbGraph = new System.Windows.Forms.GroupBox();
            this.chktime = new DevExpress.XtraEditors.CheckEdit();
            this.chkpower = new DevExpress.XtraEditors.CheckEdit();
            this.chkpower1 = new DevExpress.XtraEditors.CheckEdit();
            this.chkcep = new DevExpress.XtraEditors.CheckEdit();
            this.chkpower2 = new DevExpress.XtraEditors.CheckEdit();
            this.chkdemo = new DevExpress.XtraEditors.CheckEdit();
            this.chkpower21 = new DevExpress.XtraEditors.CheckEdit();
            this.chkpower31 = new DevExpress.XtraEditors.CheckEdit();
            this.chlPower3 = new DevExpress.XtraEditors.CheckEdit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAcc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBer.Properties)).BeginInit();
            this.gbGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chktime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkpower.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkpower1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkcep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkpower2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkdemo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkpower21.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkpower31.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chlPower3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gbGraph);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 366);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.btncancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(188, 321);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 45);
            this.panel2.TabIndex = 12;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(31, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 30);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(140, 5);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(74, 30);
            this.btncancel.TabIndex = 10;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAcc);
            this.groupBox1.Controls.Add(this.chkVel);
            this.groupBox1.Controls.Add(this.chkDisp);
            this.groupBox1.Controls.Add(this.chkBer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(188, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(236, 366);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Overall";
            // 
            // chkAcc
            // 
            this.chkAcc.Location = new System.Drawing.Point(29, 29);
            this.chkAcc.Name = "chkAcc";
            this.chkAcc.Properties.Caption = "Acceleration";
            this.chkAcc.Size = new System.Drawing.Size(91, 19);
            this.chkAcc.TabIndex = 7;
            this.chkAcc.CheckedChanged += new System.EventHandler(this.chkAcc_CheckedChanged);
            // 
            // chkVel
            // 
            this.chkVel.Location = new System.Drawing.Point(30, 58);
            this.chkVel.Name = "chkVel";
            this.chkVel.Properties.Caption = "Velocity";
            this.chkVel.Size = new System.Drawing.Size(75, 19);
            this.chkVel.TabIndex = 6;
            this.chkVel.CheckedChanged += new System.EventHandler(this.chkAcc_CheckedChanged);
            // 
            // chkDisp
            // 
            this.chkDisp.Location = new System.Drawing.Point(30, 88);
            this.chkDisp.Name = "chkDisp";
            this.chkDisp.Properties.Caption = "Displacement";
            this.chkDisp.Size = new System.Drawing.Size(90, 19);
            this.chkDisp.TabIndex = 5;
            this.chkDisp.CheckedChanged += new System.EventHandler(this.chkAcc_CheckedChanged);
            // 
            // chkBer
            // 
            this.chkBer.Location = new System.Drawing.Point(29, 117);
            this.chkBer.Name = "chkBer";
            this.chkBer.Properties.Caption = "Bearing";
            this.chkBer.Size = new System.Drawing.Size(75, 19);
            this.chkBer.TabIndex = 4;
            this.chkBer.CheckedChanged += new System.EventHandler(this.chkAcc_CheckedChanged);
            // 
            // gbGraph
            // 
            this.gbGraph.Controls.Add(this.chktime);
            this.gbGraph.Controls.Add(this.chkpower);
            this.gbGraph.Controls.Add(this.chkpower1);
            this.gbGraph.Controls.Add(this.chkcep);
            this.gbGraph.Controls.Add(this.chkpower2);
            this.gbGraph.Controls.Add(this.chkdemo);
            this.gbGraph.Controls.Add(this.chkpower21);
            this.gbGraph.Controls.Add(this.chkpower31);
            this.gbGraph.Controls.Add(this.chlPower3);
            this.gbGraph.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbGraph.Location = new System.Drawing.Point(0, 0);
            this.gbGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbGraph.Name = "gbGraph";
            this.gbGraph.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbGraph.Size = new System.Drawing.Size(188, 366);
            this.gbGraph.TabIndex = 1;
            this.gbGraph.TabStop = false;
            this.gbGraph.Text = "Graph";
            // 
            // chktime
            // 
            this.chktime.Location = new System.Drawing.Point(21, 29);
            this.chktime.Name = "chktime";
            this.chktime.Properties.Caption = "Time";
            this.chktime.Size = new System.Drawing.Size(75, 19);
            this.chktime.TabIndex = 0;
            this.chktime.CheckedChanged += new System.EventHandler(this.chktime_CheckedChanged);
            // 
            // chkpower
            // 
            this.chkpower.Location = new System.Drawing.Point(21, 58);
            this.chkpower.Name = "chkpower";
            this.chkpower.Properties.Caption = "Power";
            this.chkpower.Size = new System.Drawing.Size(75, 19);
            this.chkpower.TabIndex = 1;
            this.chkpower.CheckedChanged += new System.EventHandler(this.chktime_CheckedChanged);
            // 
            // chkpower1
            // 
            this.chkpower1.Location = new System.Drawing.Point(21, 88);
            this.chkpower1.Name = "chkpower1";
            this.chkpower1.Properties.Caption = "Power1";
            this.chkpower1.Size = new System.Drawing.Size(75, 19);
            this.chkpower1.TabIndex = 2;
            this.chkpower1.CheckedChanged += new System.EventHandler(this.chktime_CheckedChanged);
            // 
            // chkcep
            // 
            this.chkcep.Location = new System.Drawing.Point(21, 263);
            this.chkcep.Name = "chkcep";
            this.chkcep.Properties.Caption = "Cepstrum";
            this.chkcep.Size = new System.Drawing.Size(75, 19);
            this.chkcep.TabIndex = 8;
            this.chkcep.CheckedChanged += new System.EventHandler(this.chktime_CheckedChanged);
            // 
            // chkpower2
            // 
            this.chkpower2.Location = new System.Drawing.Point(21, 117);
            this.chkpower2.Name = "chkpower2";
            this.chkpower2.Properties.Caption = "Power2";
            this.chkpower2.Size = new System.Drawing.Size(75, 19);
            this.chkpower2.TabIndex = 3;
            this.chkpower2.CheckedChanged += new System.EventHandler(this.chktime_CheckedChanged);
            // 
            // chkdemo
            // 
            this.chkdemo.Location = new System.Drawing.Point(21, 234);
            this.chkdemo.Name = "chkdemo";
            this.chkdemo.Properties.Caption = "Demodulate";
            this.chkdemo.Size = new System.Drawing.Size(88, 19);
            this.chkdemo.TabIndex = 7;
            this.chkdemo.CheckedChanged += new System.EventHandler(this.chktime_CheckedChanged);
            // 
            // chkpower21
            // 
            this.chkpower21.Location = new System.Drawing.Point(21, 146);
            this.chkpower21.Name = "chkpower21";
            this.chkpower21.Properties.Caption = "Power21";
            this.chkpower21.Size = new System.Drawing.Size(75, 19);
            this.chkpower21.TabIndex = 4;
            this.chkpower21.CheckedChanged += new System.EventHandler(this.chktime_CheckedChanged);
            // 
            // chkpower31
            // 
            this.chkpower31.Location = new System.Drawing.Point(21, 205);
            this.chkpower31.Name = "chkpower31";
            this.chkpower31.Properties.Caption = "Power31";
            this.chkpower31.Size = new System.Drawing.Size(75, 19);
            this.chkpower31.TabIndex = 6;
            this.chkpower31.CheckedChanged += new System.EventHandler(this.chktime_CheckedChanged);
            // 
            // chlPower3
            // 
            this.chlPower3.Location = new System.Drawing.Point(21, 176);
            this.chlPower3.Name = "chlPower3";
            this.chlPower3.Properties.Caption = "Power3";
            this.chlPower3.Size = new System.Drawing.Size(75, 19);
            this.chlPower3.TabIndex = 5;
            this.chlPower3.CheckedChanged += new System.EventHandler(this.chktime_CheckedChanged);
            // 
            // frmreportselection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 366);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmreportselection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Selection";
            this.Load += new System.EventHandler(this.frmreportselection_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAcc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBer.Properties)).EndInit();
            this.gbGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chktime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkpower.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkpower1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkcep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkpower2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkdemo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkpower21.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkpower31.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chlPower3.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnOK;
        private DevExpress.XtraEditors.CheckEdit chkcep;
        private DevExpress.XtraEditors.CheckEdit chkdemo;
        private DevExpress.XtraEditors.CheckEdit chkpower31;
        private DevExpress.XtraEditors.CheckEdit chlPower3;
        private DevExpress.XtraEditors.CheckEdit chkpower21;
        private DevExpress.XtraEditors.CheckEdit chkpower2;
        private DevExpress.XtraEditors.CheckEdit chkpower1;
        private DevExpress.XtraEditors.CheckEdit chkpower;
        private DevExpress.XtraEditors.CheckEdit chktime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbGraph;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.CheckEdit chkAcc;
        private DevExpress.XtraEditors.CheckEdit chkVel;
        private DevExpress.XtraEditors.CheckEdit chkDisp;
        private DevExpress.XtraEditors.CheckEdit chkBer;
    }
}