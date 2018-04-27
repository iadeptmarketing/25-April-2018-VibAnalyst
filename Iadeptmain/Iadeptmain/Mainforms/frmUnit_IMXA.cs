using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using DevComponents.DotNetBar;
using Iadeptmain.GlobalClasses;
using Iadeptmain.BaseUserControl;


namespace Iadeptmain.Mainforms
{
    public partial class frmUnit_IMXA : DevExpress.XtraEditors.XtraForm
    {
        private IadeptUserControl _objUserControl = null;
        public frmUnit_IMXA()
        {
            InitializeComponent();
        }
        string sUnitOld = null;
        string sUnitNew = null;
        public IadeptUserControl usrcontrol
        {
            get
            {
                return _objUserControl;
            }
            set
            {
                _objUserControl = value;
            }
        }
       
        public string RetNewUnit
        {
            get
            {
                return sUnitNew;
            }
        }

        public string GetOldUnit
        {
            get
            {
                return sUnitOld;
            }
            set
            {
                sUnitOld = value;
            }
        }
        string sTransformation = null;
        public string GetTransformation
        {
            get
            {
                return sTransformation;
            }
            set
            {
                sTransformation = value;
            }
        }
        public void SetHeader(string Value)
        {
            try
            {
                this.Text = "Change " + Value + " Unit";
            }
            catch (Exception ex)
            {
                
            }
        }
        private void Unit_IMXA_Shown(object sender, EventArgs e)
        {
            try
            {                 
                cmbUnits.Properties.Items.Clear();
                    switch (sUnitOld)
                    {
                        case "mm/s2":
                            {

                                cmbUnits.Properties.Items.AddRange(new object[] { "mm/s2", "cm/s2", "m/s2", "G", "gal","db" });

                                break;
                            }
                        case "cm/s2":
                            {
                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "cm/s2", "mm/s2", "m/s2", "G", "gal", "db" });

                                break;
                            }
                        case "m/s2":
                            {
                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "m/s2", "mm/s2", "cm/s2", "G", "gal", "db" });

                                break;
                            }
                        case "Hz":
                            {
                                cmbUnits.Properties.Items.AddRange(new object[] { "Hz", "RPM", "Order" });
                                break;
                            }
                        case "RPM":
                            {
                                cmbUnits.Properties.Items.AddRange(new object[] { "RPM", "Hz", "Order" });
                                break;
                            }
                        case "Order":
                            {
                                cmbUnits.Properties.Items.AddRange(new object[] { "Order", "RPM", "Hz" });
                                break;
                            }
                        case "Gs":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "G", "mm/s2", "cm/s2", "m/s2", "gal", "db" });
                                break;
                            }
                        case "g":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "G", "mm/s2", "cm/s2", "m/s2", "gal", "db" });
                                break;
                            }
                        case "G":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "G", "mm/s2", "cm/s2", "m/s2", "gal", "db" });
                                break;
                            }
                        case "gal":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "gal", "mm/s2", "m/s2", "G", "cm/s2", "db" });
                                break;
                            }
                        case "mm/s":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "mm/s", "cm/s", "m/s", "IPS", "ft/s", "db" });
                                break;
                            }
                        case "cm/s":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "cm/s", "mm/s", "m/s", "IPS", "ft/s", "db" });
                                break;
                            }
                        case "m/s":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "m/s", "cm/s", "mm/s", "IPS", "ft/s", "db" });
                                break;
                            }                       
                        case "IPS":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "IPS", "cm/s", "m/s", "mm/s", "ft/s", "db" });
                                break;
                            }
                        case "ft/s":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "ft/s", "cm/s", "m/s", "IPS", "mm/s", "db" });
                                break;
                            }
                        case "mm":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "mm", "Mils", "um", "db" });
                                break;
                            }                      
                        case "Mils":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "Mils", "mm", "um", "db" });
                                break;
                            }
                        case "um":
                            {                                
                                cmbUnits.Properties.Items.AddRange(new object[] { "um", "Mils", "mm", "db" });
                                break;
                            }
                        default:
                            {
                                rbConvertTo.Checked = true;
                                break;
                            }

                    }
                    cmbUnits.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
               
            }
            try
            {
                if (this.Text.ToString() == "Change Y Unit")
                {                   
                    cmbConvertTo.Visible = true;
                    rbConvertTo.Visible = true;                   
                }
            }
            catch (Exception ex)
            {
            }


        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            OkClicked = false;
            this.Close();
        }
        bool OkClicked = false;
        public bool IsOkClicked
        {
            get
            {
                return OkClicked;
            }
            set
            {
                OkClicked = value;
            }
        }
        public bool UnitSelected
        {
            get
            {
                return rbUnit.Checked;
            }
        }
        public bool ConversionSelected
        {
            get
            {
                return rbConvertTo.Checked;
            }
        }
        string FormulaToSend = "0";
        public string _Formula
        {
            get
            {
                return FormulaToSend;
            }           
        }
        string FormulaUnit = null;
        public string _FormulaUnit
        {
            get
            {
                return FormulaUnit;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbUnit.Checked)
                {
                    sUnitNew = cmbUnits.SelectedItem.ToString();
                    OkClicked = true;
                    this.Close();
                }
                else if (rbConvertTo.Checked)
                {
                    sUnitNew = cmbConvertTo.SelectedItem.ToString();
                    OkClicked = true;
                    this.Close();
                }
                else              
                {
                    if (!string.IsNullOrEmpty(tbFormula.Text.ToString()) && !string.IsNullOrEmpty(tbFormulaUnit.Text.ToString()))
                    {
                        double factor = 0;
                        FormulaToSend = "0";
                        FormulaUnit = null;
                        string Formula = tbFormula.Text.ToString();
                        bool bError = false;
                        double[] arrFValues = new double[0];
                        string[] arrFormula = Formula.Split(new string[] { "+", "-", "/", "*" }, StringSplitOptions.RemoveEmptyEntries);

                        {
                            for (int i = 0; i < arrFormula.Length; i++)
                            {
                                try
                                {
                                    factor = Convert.ToDouble(arrFormula[i].ToString());
                                    Array.Resize(ref arrFValues, arrFValues.Length + 1);
                                    arrFValues[arrFValues.Length - 1] = factor;

                                }
                                catch (Exception ex)
                                {
                                    
                                    bError = true;
                                    break;
                                }
                            }

                            if (!bError)
                            {
                                string val = "0";
                                string FinalValue = null;
                                string PrevVal = null;
                                double DFinal = 0;
                                byte[] byteFormula = Encoding.ASCII.GetBytes(Formula);
                                int FValuesCtr = 0;
                                DFinal = arrFValues[0];
                                for (int i = 0; i < byteFormula.Length; i++)
                                {

                                    if (Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "+")//( Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "-" || Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "/" || Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "*")
                                    {
                                        FValuesCtr++;
                                        DFinal += (double)arrFValues[FValuesCtr];
                                    }
                                    if (Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "-")//( Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "-" || Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "/" || Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "*")
                                    {
                                        FValuesCtr++;
                                        DFinal -= (double)arrFValues[FValuesCtr];
                                    }
                                    if (Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "*")//( Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "-" || Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "/" || Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "*")
                                    {
                                        FValuesCtr++;
                                        DFinal *= (double)arrFValues[FValuesCtr];
                                    }
                                    if (Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "/")//( Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "-" || Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "/" || Encoding.ASCII.GetString(byteFormula, i, 1).ToString() == "*")
                                    {
                                        FValuesCtr++;
                                        DFinal /= (double)arrFValues[FValuesCtr];
                                    }
                                }
                                FormulaToSend = cmbFExpression.SelectedItem.ToString() + DFinal.ToString();
                                FormulaUnit = tbFormulaUnit.Text.ToString();

                                OkClicked = true;
                                this.Close();
                            }
                            else
                            {
                                MessageBoxEx.Show("Error in Formula");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void rbUnit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbUnit.Checked)
                {
                    cmbUnits.Enabled = true;
                    tbFormula.Enabled = false;
                    cmbFExpression.Enabled = false;
                    tbFormulaUnit.Enabled = false;
                    cmbConvertTo.Enabled = false;
                    
                }
                
                
            }
            catch(Exception ex)
            {
                //ErrorLog_Class.ErrorLogEntry(ex);
            }
        }

        private void rbConvertTo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbConvertTo.Checked)
                {
                    tbFormula.Enabled = false;
                    cmbUnits.Enabled = false;
                    cmbFExpression.Enabled = false;
                    tbFormulaUnit.Enabled = false;
                    cmbConvertTo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void rbFormula_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(rbFormula.Checked)
                {
                    tbFormula.Enabled = true;
                    cmbUnits.Enabled = false;
                    cmbFExpression.Enabled = true;
                    tbFormulaUnit.Enabled = true;
                    cmbConvertTo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
            }
        }
        

        public double UnitConverter(string ConvertFromUnit, string ConvertToUnit)
        {
            string Convertto = null;
            string Convertfrom = null;
            double NumericValue = 1;
            double NewNumericValue = 1;           
            try
            {
                Convertto = ConvertToUnit;
                Convertfrom = ConvertFromUnit;                
                string[] splittedTo = Convertto.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                switch (Convertto.ToString())
                {
                    case "db":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "mil":
                                    {
                                        NewNumericValue = NumericValue / .0394;//NumericValue * 25.4;

                                        break;
                                    }
                                case "Mils":
                                    {
                                        NewNumericValue = NumericValue / .0394;//NumericValue * 25.4;

                                        break;
                                    }
                                case "mm":
                                    {
                                        NewNumericValue = NumericValue * 1000;
                                        break;
                                    }
                                case "um":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }

                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue * 10;
                                        break;
                                    }
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue * 1000;
                                        break;
                                    }
                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue * 25.4;
                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue * 25.4;
                                        break;
                                    }
                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * 305;
                                        break;
                                    }
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue * .001;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue * .01;
                                        break;
                                    }
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 9.81;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 9.81;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 9.81;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue * .01;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "mil":
                        {

                            switch (Convertfrom.ToString())
                            {

                                case "mm":
                                    {
                                        NewNumericValue = NumericValue * 39.4;
                                        break;
                                    }
                                case "um":
                                    {
                                        NewNumericValue = NumericValue * .0394;

                                        break;
                                    }
                                case "mil":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                case "Mils":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Mils":
                        {

                            switch (Convertfrom.ToString())
                            {

                                case "mm":
                                    {
                                        NewNumericValue = NumericValue * 39.4;
                                        break;
                                    }
                                case "um":
                                    {
                                        NewNumericValue = NumericValue * .0394;

                                        break;
                                    }
                                case "mil":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                case "Mils":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }

                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "mm":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "mil":
                                    {
                                        NewNumericValue = NumericValue / 39.4; //NumericValue * .0254;

                                        break;
                                    }
                                case "Mils":
                                    {
                                        NewNumericValue = NumericValue / 39.4; //NumericValue * .0254;

                                        break;
                                    }
                                case "um":
                                    {
                                        NewNumericValue = NumericValue * .001;

                                        break;
                                    }
                                case "mm":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "um":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "mil":
                                    {
                                        NewNumericValue = NumericValue / .0394;//NumericValue * 25.4;

                                        break;
                                    }
                                case "Mils":
                                    {
                                        NewNumericValue = NumericValue / .0394;//NumericValue * 25.4;

                                        break;
                                    }
                                case "mm":
                                    {
                                        NewNumericValue = NumericValue * 1000;

                                        break;
                                    }
                                case "um":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "*C":
                        {
                            switch (Convertfrom.ToString())
                            {

                                case "*F":
                                    {
                                        double factor = 9.0 / 5.0;
                                        NewNumericValue = (NumericValue * factor) + 32;

                                        break;
                                    }
                                case "*C":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "*F":
                        {
                            switch (Convertfrom.ToString())
                            {

                                case "*C":
                                    {
                                        double factor = 5.0 / 9.0;
                                        NewNumericValue = (NumericValue - 32) * factor;

                                        break;
                                    }
                                case "*F":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "mm/s":
                        {
                            switch (Convertfrom.ToString())
                            {

                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue * 10;

                                        break;
                                    }
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue * 1000;

                                        break;
                                    }
                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue * 25.4;

                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue * 25.4;

                                        break;
                                    }
                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * 305;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "cm/s":
                        {
                            switch (Convertfrom.ToString())
                            {

                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue * .1;

                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue * 100;

                                        break;
                                    }
                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue * 2.54;

                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue * 2.54;

                                        break;
                                    }
                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * 30.5;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "m/s":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue * .001;
                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue * .01;
                                        break;
                                    }

                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue * .0254;
                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue * .0254;
                                        break;
                                    }
                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * .305;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "in/s":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue / 25.4; //NumericValue * .0394;
                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue / 2.54;//NumericValue * .394;
                                        break;
                                    }
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue / .0254;//NumericValue * 39.4;
                                        break;
                                    }

                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * 12;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "IPS":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue / 25.4; //NumericValue * .0394;
                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue / 2.54;//NumericValue * .394;
                                        break;
                                    }
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue / .0254;//NumericValue * 39.4;
                                        break;
                                    }

                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * 12;
                                        break;
                                    }

                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "ft/s":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue / 305;//NumericValue * .00328;
                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue / 30.5;//NumericValue * .0328;
                                        break;
                                    }
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue / .305; //NumericValue * 3.28;
                                        break;
                                    }
                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue / 12;//NumericValue * .0833;
                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue / 12;//NumericValue * .0833;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "mm/s2":
                        {
                            switch (Convertfrom.ToString())
                            {

                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue * 10;
                                        break;
                                    }
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue * 1000;
                                        break;
                                    }
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 9810;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 9810;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 9810;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue * 10;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "cm/s2":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue * .1;
                                        break;
                                    }

                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue * 100;
                                        break;
                                    }
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "m/s2":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue * .001;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue * .01;
                                        break;
                                    }
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 9.81;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 9.81;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 9.81;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue * .01;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Gs":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue / 9810;//NumericValue * .000102;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue / 9.81;//NumericValue * .102;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "G":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue / 9810;//NumericValue * .000102;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue / 9.81;//NumericValue * .102;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "g":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue / 9810;//NumericValue * .000102;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue / 9.81;//NumericValue * .102;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }

                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "gal":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue * .1;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue;
                                        break;
                                    }
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue * 100;
                                        break;
                                    }
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "RPM":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "Hz":
                                    {
                                        NewNumericValue = NumericValue * 60;
                                        break;
                                    }
                                case "RPM":
                                    {
                                        NumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "Order":
                                    {
                                        string[] RPMValues = _objUserControl.GetRPMValues(PublicClass.SMachineID);
                                        int iRPM = Convert.ToInt32(RPMValues[0]);
                                        int iPulse = Convert.ToInt32(RPMValues[1]);
                                        double FinalFreq = (double)((double)iRPM / (double)(iPulse * 60));
                                        NewNumericValue = (FinalFreq * 60);
                                        break;
                                    }



                            }
                            break;
                        }
                    case "Hz":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "RPM":
                                    {
                                        NewNumericValue = NumericValue / 60;
                                        break;
                                    }
                                case "Hz":
                                    {
                                        NewNumericValue = NewNumericValue * 1;
                                        break;
                                    }
                                case "Order":
                                    {
                                        string[] RPMValues = _objUserControl.GetRPMValues(PublicClass.SMachineID);
                                        int iRPM = Convert.ToInt32(RPMValues[0]);
                                        int iPulse = Convert.ToInt32(RPMValues[1]);
                                        double FinalFreq = (double)((double)iRPM / (double)(iPulse * 60));

                                        NewNumericValue = FinalFreq;      

                                        break;
                                    }
                            }
                            break;
                        }
                    case "Order":
                        {
                            string[] RPMValues = _objUserControl.GetRPMValues(PublicClass.SMachineID);
                            int iRPM = Convert.ToInt32(RPMValues[0]);
                            int iPulse = Convert.ToInt32(RPMValues[1]);
                            double FinalFreq = (double)((double)iRPM / (double)(iPulse * 60));
                            
                            switch (Convertfrom.ToString())
                            {
                                case "RPM":
                                    {                                        
                                        NewNumericValue = (FinalFreq * 60);
                                        break;
                                    }
                                case "Hz":
                                    {
                                        NewNumericValue = FinalFreq;                                        
                                        break;
                                    }
                            }
                            break;
                        }
                  
                }
            }
            catch (Exception ex)
            {
                
            }
            return NewNumericValue;
        }

        public double UnitConverter(string ConvertFromUnit, string ConvertToUnit, float CPM)
        {

            string Convertto = null;
            string Convertfrom = null;
            double NumericValue = 1;
            double NewNumericValue = 1;
          
            try
            {

                Convertto = ConvertToUnit;
                Convertfrom = ConvertFromUnit;

                
                string[] splittedTo = Convertto.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                switch (Convertto.ToString())
                {
                    case "mil":
                        {

                            switch (Convertfrom.ToString())
                            {

                                case "mm":
                                    {
                                        NewNumericValue = NumericValue * 39.4;
                                        break;
                                    }
                                case "um":
                                    {
                                        NewNumericValue = NumericValue * .0394;

                                        break;
                                    }
                                case "mil":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                case "Mils":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Mils":
                        {

                            switch (Convertfrom.ToString())
                            {

                                case "mm":
                                    {
                                        NewNumericValue = NumericValue * 39.4;
                                        break;
                                    }
                                case "um":
                                    {
                                        NewNumericValue = NumericValue * .0394;

                                        break;
                                    }
                                case "mil":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                case "Mils":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }

                                case "IPS":
                                    {
                                        NewNumericValue = (19100 * NumericValue);
                                        break;
                                    }
                                case "in/s":
                                    {
                                        NewNumericValue = (19100 * NumericValue);
                                        break;
                                    }
                                case "mm/s":
                                    {


                                        NewNumericValue = NumericValue / 25.4; //NumericValue * .0394;
                                        NewNumericValue *= (19100 * NumericValue);
                                        break;
                                    }
                                case "cm/s":
                                    {

                                        NewNumericValue = NumericValue / 2.54;//NumericValue * .394;
                                        NewNumericValue *= (19100 * NumericValue);
                                        break;
                                    }
                                case "m/s":
                                    {

                                        NewNumericValue = NumericValue / .0254;//NumericValue * 39.4;
                                        NewNumericValue *= (19100 * NumericValue);
                                        break;
                                    }

                                case "ft/s":
                                    {

                                        NewNumericValue = NumericValue * 12;
                                        NewNumericValue *= (19100 * NumericValue);
                                        break;
                                    }


                                case "Gs":
                                    {
                                        
                                        NewNumericValue = NumericValue * 1;
                                        NewNumericValue *= (70400000 * NumericValue);

                                        break;
                                    }
                                case "G":
                                    {

                                        NewNumericValue = NumericValue * 1;
                                        NewNumericValue *= (70400000 * NumericValue);
                                        break;
                                    }
                                case "g":
                                    {

                                        NewNumericValue = NumericValue * 1;
                                        NewNumericValue *= (70400000 * NumericValue);
                                        break;
                                    }
                                case "mm/s2":
                                    {

                                        NewNumericValue = NumericValue / 9810;//NumericValue * .000102;
                                        NewNumericValue *= (70400000 * NumericValue);
                                        break;
                                    }
                                case "cm/s2":
                                    {

                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        NewNumericValue *= (70400000 * NumericValue);
                                        break;
                                    }
                                case "m/s2":
                                    {

                                        NewNumericValue = NumericValue / 9.81;//NumericValue * .102;
                                        NewNumericValue *= (70400000 * NumericValue);
                                        break;
                                    }
                                case "gal":
                                    {

                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        NewNumericValue *= (70400000 * NumericValue);
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "mm":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "mil":
                                    {
                                        NewNumericValue = NumericValue / 39.4; //NumericValue * .0254;

                                        break;
                                    }
                                case "Mils":
                                    {
                                        NewNumericValue = NumericValue / 39.4; //NumericValue * .0254;

                                        break;
                                    }
                                case "um":
                                    {
                                        NewNumericValue = NumericValue * .001;

                                        break;
                                    }
                                case "mm":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "um":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "mil":
                                    {
                                        NewNumericValue = NumericValue / .0394;//NumericValue * 25.4;

                                        break;
                                    }
                                case "Mils":
                                    {
                                        NewNumericValue = NumericValue / .0394;//NumericValue * 25.4;

                                        break;
                                    }
                                case "mm":
                                    {
                                        NewNumericValue = NumericValue * 1000;

                                        break;
                                    }
                                case "um":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "*C":
                        {
                            switch (Convertfrom.ToString())
                            {

                                case "*F":
                                    {
                                        double factor = 9.0 / 5.0;
                                        NewNumericValue = (NumericValue * factor) + 32;

                                        break;
                                    }
                                case "*C":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "*F":
                        {
                            switch (Convertfrom.ToString())
                            {

                                case "*C":
                                    {
                                        double factor = 5.0 / 9.0;
                                        NewNumericValue = (NumericValue - 32) * factor;

                                        break;
                                    }
                                case "*F":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "mm/s":
                        {
                            switch (Convertfrom.ToString())
                            {

                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue * 10;

                                        break;
                                    }
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue * 1000;

                                        break;
                                    }
                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue * 25.4;

                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue * 25.4;

                                        break;
                                    }
                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * 305;

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "cm/s":
                        {
                            switch (Convertfrom.ToString())
                            {

                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue * .1;

                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue * 1;

                                        break;
                                    }
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue * 100;

                                        break;
                                    }
                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue * 2.54;

                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue * 2.54;

                                        break;
                                    }
                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * 30.5;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "m/s":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue * .001;
                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue * .01;
                                        break;
                                    }

                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue * .0254;
                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue * .0254;
                                        break;
                                    }
                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * .305;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "in/s":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue / 25.4; //NumericValue * .0394;
                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue / 2.54;//NumericValue * .394;
                                        break;
                                    }
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue / .0254;//NumericValue * 39.4;
                                        break;
                                    }

                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * 12;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "IPS":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue / 25.4; //NumericValue * .0394;
                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue / 2.54;//NumericValue * .394;
                                        break;
                                    }
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue / .0254;//NumericValue * 39.4;
                                        break;
                                    }

                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * 12;
                                        break;
                                    }


                                case "mm":
                                    {
                                        NewNumericValue = NumericValue * 39.4;
                                        NewNumericValue *= (NumericValue) / 19100;
                                        break;
                                    }
                                case "um":
                                    {

                                        NewNumericValue = NumericValue * .0394;
                                        NewNumericValue *= (NumericValue) / 19100;
                                        break;
                                    }
                                case "mil":
                                    {

                                        NewNumericValue = NumericValue * 1;
                                        NewNumericValue *= (NumericValue) / 19100;
                                        break;
                                    }
                                case "Mils":
                                    {


                                        NewNumericValue = NumericValue * 1;
                                        NewNumericValue *= (NumericValue) / 19100;

                                        break;
                                    }

                                case "Gs":
                                    {
                                        
                                        NewNumericValue = NumericValue * 1;
                                        NewNumericValue *= ((NumericValue * 1000) / (0.271));

                                        break;
                                    }
                                case "G":
                                    {

                                        NewNumericValue = NumericValue * 1;
                                        NewNumericValue *= ((NumericValue * 1000) / (0.271));

                                        break;
                                    }
                                case "g":
                                    {

                                        NewNumericValue = NumericValue * 1;
                                        NewNumericValue *= ((NumericValue * 1000) / (0.271));

                                        break;
                                    }
                                case "mm/s2":
                                    {

                                        NewNumericValue = NumericValue / 9810;//NumericValue * .000102;
                                        NewNumericValue *= ((NumericValue * 1000) / (0.271));

                                        break;
                                    }
                                case "cm/s2":
                                    {

                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        NewNumericValue *= ((NumericValue * 1000) / (0.271));

                                        break;
                                    }
                                case "m/s2":
                                    {

                                        NewNumericValue = NumericValue / 9.81;//NumericValue * .102;
                                        NewNumericValue *= ((NumericValue * 1000) / (0.271));

                                        break;
                                    }
                                case "gal":
                                    {

                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        NewNumericValue *= ((NumericValue * 1000) / (0.271));

                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "ft/s":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "ft/s":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue / 305;//NumericValue * .00328;
                                        break;
                                    }
                                case "cm/s":
                                    {
                                        NewNumericValue = NumericValue / 30.5;//NumericValue * .0328;
                                        break;
                                    }
                                case "m/s":
                                    {
                                        NewNumericValue = NumericValue / .305; //NumericValue * 3.28;
                                        break;
                                    }
                                case "in/s":
                                    {
                                        NewNumericValue = NumericValue / 12;//NumericValue * .0833;
                                        break;
                                    }
                                case "IPS":
                                    {
                                        NewNumericValue = NumericValue / 12;//NumericValue * .0833;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "mm/s2":
                        {
                            switch (Convertfrom.ToString())
                            {

                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue * 10;
                                        break;
                                    }
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue * 1000;
                                        break;
                                    }
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 9810;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 9810;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 9810;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue * 10;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "cm/s2":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue * .1;
                                        break;
                                    }

                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue * 100;
                                        break;
                                    }
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "m/s2":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue * .001;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue * .01;
                                        break;
                                    }
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 9.81;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 9.81;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 9.81;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue * .01;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Gs":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue / 9810;//NumericValue * .000102;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue / 9.81;//NumericValue * .102;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "G":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue / 9810;//NumericValue * .000102;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue / 9.81;//NumericValue * .102;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "g":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue / 9810;//NumericValue * .000102;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue / 9.81;//NumericValue * .102;
                                        break;
                                    }
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue / 981;//NumericValue * .00102;
                                        break;
                                    }

                                case "IPS":
                                    {
                                        NewNumericValue = 0.000271 * NumericValue;
                                        break;
                                    }
                                case "in/s":
                                    {
                                        NewNumericValue = 0.000271 * NumericValue;
                                        break;
                                    }
                                case "mm/s":
                                    {
                                        NewNumericValue = NumericValue / 25.4; //NumericValue * .0394;
                                        NewNumericValue *= 0.000271 * NumericValue;
                                        break;
                                    }
                                case "cm/s":
                                    {

                                        NewNumericValue = NumericValue / 2.54;//NumericValue * .394;
                                        NewNumericValue *= 0.000271 * NumericValue;
                                        break;
                                    }
                                case "m/s":
                                    {

                                        NewNumericValue = NumericValue / .0254;//NumericValue * 39.4;
                                        NewNumericValue *= 0.000271 * NumericValue;
                                        break;
                                    }

                                case "ft/s":
                                    {

                                        NewNumericValue = NumericValue * 12;
                                        NewNumericValue *= 0.000271 * NumericValue;
                                        break;
                                    }

                                case "mm":
                                    {
                                        
                                        NewNumericValue = NumericValue * 39.4;
                                        NewNumericValue *= (NumericValue) / 70400000;

                                        break;
                                    }
                                case "um":
                                    {

                                        NewNumericValue = NumericValue * .0394;
                                        NewNumericValue *= (NumericValue) / 70400000;
                                        break;
                                    }
                                case "mil":
                                    {
                                        
                                        NewNumericValue = NumericValue * 1;
                                        NewNumericValue *= (NumericValue) / 70400000;
                                        break;
                                    }
                                case "Mils":
                                    {
                                        
                                        NewNumericValue = NumericValue * 1;
                                        NewNumericValue *= (NumericValue) / 70400000;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "gal":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "gal":
                                    {
                                        NewNumericValue = NumericValue * 1;
                                        break;
                                    }
                                case "mm/s2":
                                    {
                                        NewNumericValue = NumericValue * .1;
                                        break;
                                    }
                                case "cm/s2":
                                    {
                                        NewNumericValue = NumericValue;
                                        break;
                                    }
                                case "m/s2":
                                    {
                                        NewNumericValue = NumericValue * 100;
                                        break;
                                    }
                                case "Gs":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                case "G":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                case "g":
                                    {
                                        NewNumericValue = NumericValue * 981;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Sorry!!! Conversion Method not implemented");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "RPM":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "Hz":
                                    {
                                        NewNumericValue = NumericValue * 60;
                                        break;
                                    }
                                case "RPM":
                                    {
                                        NumericValue = NumericValue * 1;
                                        break;
                                    }


                            }
                            break;
                        }
                    case "Hz":
                        {
                            switch (Convertfrom.ToString())
                            {
                                case "RPM":
                                    {
                                        NewNumericValue = NumericValue / 60;
                                        break;
                                    }
                                case "Hz":
                                    {
                                        NewNumericValue = NewNumericValue * 1;
                                        break;
                                    }
                            }
                            break;
                        }
                    case "Order":
                        {
                            string[] RPMValues = _objUserControl.GetRPMValues(PublicClass.SMachineID);
                            int iRPM = Convert.ToInt32(RPMValues[0]);
                            int iPulse = Convert.ToInt32(RPMValues[1]);
                            double FinalFreq = (double)((double)iRPM / (double)(iPulse * 60));

                            switch (Convertfrom.ToString())
                            {
                                case "RPM":
                                    {
                                        NewNumericValue = (FinalFreq * 60);
                                        break;
                                    }
                                case "Hz":
                                    {
                                        NewNumericValue = FinalFreq;
                                        break;
                                    }
                            }
                            break;
                        }
                   
                }
            }
            catch (Exception ex)
            {
                
            }
            return NewNumericValue;
        }


    }
}
