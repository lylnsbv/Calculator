using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Calculator
{
    public partial class Form1 : Form
    {
        bool Keyactive = true;

        double firstvalue = 0;
        double secondvalue = 0;

        bool operation_pressed = false;
        bool isRepeatLastOperation = false;
        bool disable = false;
        char operation = new char();

        bool xnum;
        bool exp = false;
        bool prcnt;

        public Form1()
        {
            InitializeComponent();
        }

        #region - Calculator-

        private void Focusbtn_Enter(object sender, EventArgs e)
        {
            Keyactive = true;
            Equartion.Focus();
        }
        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keyactive)
            {
                switch (e.KeyChar)
                {
                    case '0':
                        Nullbtn.PerformClick();
                        break;
                    case '1':
                        Onebtn.PerformClick();
                        break;
                    case '2':
                        Twobtn.PerformClick();
                        break;
                    case '3':
                        Threebtn.PerformClick();
                        break;
                    case '4':
                        Fourbtn.PerformClick();
                        break;
                    case '5':
                        Fivebtn.PerformClick();
                        break;
                    case '6':
                        Sixbtn.PerformClick();
                        break;
                    case '7':
                        Sevenbtn.PerformClick();
                        break;
                    case '8':
                        Eightbtn.PerformClick();
                        break;
                    case '9':
                        Ninebtn.PerformClick();
                        break;
                    case ',':
                        Dotbtn.PerformClick();
                        break;
                    case '.':
                        Dotbtn.PerformClick();
                        break;
                    case '/':
                        Divbtn.PerformClick();
                        break;
                    case '*':
                        Multbtn.PerformClick();
                        break;
                    case '-':
                        Subbtn.PerformClick();
                        break;
                    case '+':
                        Addbtn.PerformClick();
                        break;
                    case '%':
                        Percentbtn.PerformClick();
                        break;
                    case '=':
                        Equalbtn.PerformClick();
                        break;
                    case '\r':
                        Equalbtn.PerformClick();
                        break;
                    case '\b':
                        Backbtn.PerformClick();
                        break;
                    case (char)27:
                        Resetbtn.PerformClick();
                        break;
                }
            }

        }
        private void CalculatorFocus_Click(object sender, EventArgs e)
        {
            Keyactive = true;
            Equartion.Focus();
        }
        private void Clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DisplayResultLbl.Text == "Sıfıra bölünə bilməz")
                {
                    isRepeatLastOperation = false;
                    secondvalue = firstvalue = 0;
                    operation_pressed = true;
                    operation = '\0';
                    Equartion.Text = "";
                }
                DisplayResultLbl.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
                DisplayResultLbl.Text = "0";
                exp = false;
                disable = false;
            }
            catch
            //(Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }
        private void ClearAllbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayResultLbl.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
                disable = isRepeatLastOperation = false;
                secondvalue = firstvalue = 0;
                DisplayResultLbl.Text = "0";
                operation_pressed = true;
                operation = '\0';
                Equartion.Text = "";
                exp = false;
            }
            catch
            //(Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }
        }
        private void Backbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DisplayResultLbl.Text != "" && !operation_pressed)
                {
                    DisplayResultLbl.Text = DisplayResultLbl.Text.Remove(DisplayResultLbl.Text.Length - 1, 1);
                }
                if (DisplayResultLbl.Text == "")
                {
                    DisplayResultLbl.Text = "0";
                }
            }
            catch
            //(Exception ex)
            {
                //  MessageBox.Show(ex.Message);
            }

        }
        private void Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!disable)
                {

                    if (operation_pressed)
                    {
                        DisplayResultLbl.Text = "0";
                        operation_pressed = false;
                    }

                    if (isRepeatLastOperation)
                    {
                        operation = '\0';
                        firstvalue = 0;
                    }

                    Button b = (Button)sender;
                    if (!(DisplayResultLbl.Text == "0" && b == Nullbtn) && !(b == Dotbtn && DisplayResultLbl.Text.Contains(",")))
                        DisplayResultLbl.Text = (DisplayResultLbl.Text == "0" && b == Dotbtn) ? "0," : ((DisplayResultLbl.Text == "0") ? b.Text : DisplayResultLbl.Text + b.Text);
                }
            }
            catch
            //(Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        private void Operationbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                if (!disable)
                {
                    if (operation == '\0')
                    {
                        if (DisplayResultLbl.Text == "Sıfıra bölünə bilməz")
                        {
                            firstvalue = 0;
                        }
                        else
                        {
                            if (b.Text == "√")
                            {
                                Equartion.Text = " √" + DisplayResultLbl.Text + " ";
                                DisplayResultLbl.Text = Operators.sqrt(double.Parse(DisplayResultLbl.Text)).ToString();
                                exp = true;
                            }
                            else if (b.Text == "1/x")
                            {
                                if (DisplayResultLbl.Text == "0")
                                {
                                    DisplayResultLbl.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                                    DisplayResultLbl.Text = "Sıfıra bölünə bilməz";

                                    disable = true;
                                }
                                else
                                {
                                    Equartion.Text = " (1/" + DisplayResultLbl.Text + ") ";
                                    DisplayResultLbl.Text = Convert.ToDouble(1.0 / double.Parse(DisplayResultLbl.Text)).ToString();
                                    exp = true;
                                }
                                if (DisplayResultLbl.Text.Contains("E"))
                                {
                                    DisplayResultLbl.Text = "0";
                                }
                            }
                            if (b.Text == "%")
                            {
                                Equartion.Text = "0";
                                DisplayResultLbl.Text = "0";
                                exp = true;
                            }
                            // else
                            if (b.Text != "√" && b.Text != "1/x" && b.Text != "%")
                            {
                                if (!exp)
                                {
                                    Equartion.Text = Equartion.Text + " " + DisplayResultLbl.Text + " " + b.Text;
                                }
                                else
                                {
                                    Equartion.Text = Equartion.Text + " " + b.Text;
                                }
                            }
                            firstvalue = double.Parse(DisplayResultLbl.Text);
                        }

                    }
                    else if (operation_pressed)
                    {
                        if (b.Text == "√")
                        {
                            Equartion.Text = Equartion.Text + "-> √" + DisplayResultLbl.Text + " ";
                            DisplayResultLbl.Text = Operators.sqrt(double.Parse(DisplayResultLbl.Text)).ToString();
                            // firstvalue = (double.Parse(DisplayResultLbl.Text));
                            xnum = true;
                        }
                        else if (b.Text == "1/x")
                        {
                            Equartion.Text = Equartion.Text + "-> (1/" + DisplayResultLbl.Text + ") ";
                            DisplayResultLbl.Text = Convert.ToDouble(1.0 / double.Parse(DisplayResultLbl.Text)).ToString();
                            xnum = true;
                        }
                        if (b.Text == "%")
                        {
                            double percent = (firstvalue * double.Parse(DisplayResultLbl.Text)) / 100;
                            Equartion.Text = Equartion.Text + " " + percent + " ";
                            DisplayResultLbl.Text = percent.ToString();
                        }

                        if (b.Text != "√" && b.Text != "1/x" && b.Text != "%")
                        //else
                        {
                            if (xnum)
                            {
                                Equartion.Text = Equartion.Text + " " + b.Text[0];
                                Operate(firstvalue, operation, double.Parse(DisplayResultLbl.Text));
                                DisplayResultLbl.Text = firstvalue.ToString();
                                xnum = false;
                            }
                            if (prcnt)
                            {
                                Equartion.Text = Equartion.Text + " " + b.Text[0];
                                Operate(firstvalue, operation, double.Parse(DisplayResultLbl.Text));
                                DisplayResultLbl.Text = firstvalue.ToString();
                                prcnt = false;
                            }

                            if (Equartion.Text != "")
                            {
                                // if (Equartion.Text[Equartion.Text.Length - 1].ToString() != "√")
                                {
                                    Equartion.Text = Equartion.Text.Remove(Equartion.Text.Length - 1, 1);
                                    Equartion.Text = Equartion.Text + b.Text[0];
                                }
                            }
                            else
                            {
                                Equartion.Text = Equartion.Text + " " + DisplayResultLbl.Text + " " + b.Text[0];
                            }
                        }
                    }
                    else
                    {
                        if (b.Text == "√")
                        {
                            Equartion.Text = Equartion.Text + " √" + DisplayResultLbl.Text + " ";
                            DisplayResultLbl.Text = Operators.sqrt(double.Parse(DisplayResultLbl.Text)).ToString();
                            exp = true;
                            // firstvalue = (double.Parse(DisplayResultLbl.Text));
                        }
                        else if (b.Text == "1/x")
                        {
                            Equartion.Text = Equartion.Text + " (1/" + DisplayResultLbl.Text + ") ";
                            DisplayResultLbl.Text = Convert.ToDouble(1.0 / double.Parse(DisplayResultLbl.Text)).ToString();
                            exp = true;
                        }
                        if (b.Text == "%")
                        {
                            double percent = (firstvalue * double.Parse(DisplayResultLbl.Text)) / 100;
                            Equartion.Text = Equartion.Text + " " + percent + " ";
                            DisplayResultLbl.Text = percent.ToString();
                            exp = true;
                            prcnt = true;
                        }
                        // else
                        if (b.Text != "√" && b.Text != "1/x" && b.Text != "%")
                        {
                            Equartion.Text = Equartion.Text + " " + DisplayResultLbl.Text + " " + b.Text[0];
                            Operate(firstvalue, operation, double.Parse(DisplayResultLbl.Text));
                        }
                    }
                    if (b.Text != "1/x" && b.Text != "√" && b.Text != "%")
                    {
                        operation = b.Text[0];
                        if (Equartion.Text != "" && Equartion.Text[Equartion.Text.Length - 3].ToString() == ",")
                        {
                            Equartion.Text = Equartion.Text.Remove(Equartion.Text.Length - 3, 1);
                        }
                    }
                    if (b.Text != "1/x" && b.Text != "%")
                    {
                        if (Equartion.Text != "" && Equartion.Text[Equartion.Text.Length - 2].ToString() == ",")
                        {
                            Equartion.Text = Equartion.Text.Remove(Equartion.Text.Length - 2, 1);
                        }
                    }
                    if (b.Text != "√" && b.Text != "%")
                    {
                        if (Equartion.Text != "" && Equartion.Text[Equartion.Text.Length - 3].ToString() == ",")
                        {
                            Equartion.Text = Equartion.Text.Remove(Equartion.Text.Length - 3, 1);
                        }
                    }

                    operation_pressed = true;
                    isRepeatLastOperation = false;
                }
            }
            catch
            //(Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        void Operate(double dblfirstvalue, char operation, double dblsecondvalue)
        {
            try
            {
                switch (operation)
                {
                    case '+':
                        DisplayResultLbl.Text = (firstvalue = (Operators.Add(dblfirstvalue, dblsecondvalue))).ToString();
                        break;
                    case '-':
                        DisplayResultLbl.Text = (firstvalue = (Operators.Sub(dblfirstvalue, dblsecondvalue))).ToString();
                        break;
                    case '*':
                        DisplayResultLbl.Text = (firstvalue = (Operators.Mult(dblfirstvalue, dblsecondvalue))).ToString();
                        break;
                    case '/':
                        if (dblsecondvalue == 0)
                        {
                            DisplayResultLbl.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                            DisplayResultLbl.Text = "Sıfıra bölünə bilməz";

                            disable = true;
                        }
                        else
                            DisplayResultLbl.Text = (firstvalue = (Operators.Div(dblfirstvalue, dblsecondvalue))).ToString();
                        break;
                }
                if (DisplayResultLbl.Text.Contains("E"))
                {
                    DisplayResultLbl.Text = "0";
                }
            }
            catch
            //(Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }

        }
        private void Equalbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!disable)
                {
                    if (!isRepeatLastOperation)
                    {
                        secondvalue = double.Parse(DisplayResultLbl.Text);
                        isRepeatLastOperation = true;
                    }
                    Operate(firstvalue, operation, secondvalue);
                    operation_pressed = true;
                    Equartion.Text = "";
                }
            }
            catch
            //(Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        private void Signbtn_Click(object sender, EventArgs e)
        {
            if (!disable)
            {
                DisplayResultLbl.Text = (double.Parse(DisplayResultLbl.Text) * -1).ToString();
            }

        }       
        
        #endregion
        
    }
}
