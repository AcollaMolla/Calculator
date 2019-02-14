using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkylator
{
    public partial class Form1 : Form
    {
        double num = 0; //The first number input by the user
        double result = 0; //Result of two numbers
        int operationType = -1; //What kind of arithmethical operation to be used
        bool operationFinished = false; //Is the calculation finished?

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numButton_Click(object sender, EventArgs e) //0-9 buttons
        {
            var source = (Button)sender;
            if (operationFinished)
            {
                textBox1.Text = source.Text;
                operationFinished = false;
            }
            else if (!operationFinished)
                textBox1.AppendText(source.Text);
        }

        private void operationButton_Click(object sender, EventArgs e) //Operational buttons ie add, sub, mul, div
        {
            num = double.Parse(textBox1.Text, System.Globalization.CultureInfo.CurrentCulture);
            button17.Enabled = true;
            //num = Convert.ToDouble(textBox1.Text);
            textBox1.Text = "";
            var source = (Button)sender;
            switch (source.Name)
            {
                case "button11":
                    operationType = 0;
                    break;
                case "button12":
                    operationType = 1;
                    break;
                case "button13":
                    operationType = 2;
                    break;
                case "button14":
                    operationType = 3;
                    break;
                default:
                    operationType = -1;
                    break;
            }
        }

        private void modifierButton_Click(object sender, EventArgs e)//Convert the number to negative or make it decimal
        {
            var source = (Button)sender;
            switch (source.Name)
            {
                case "button16": //Make number negative
                    if (!operationFinished)
                    {
                        if(textBox1.Text != "" && textBox1.Text != null)
                        {
                            num = Convert.ToDouble(textBox1.Text);
                            textBox1.Text = Convert.ToString(num *= -1);
                        }
                    }

                    else if (operationFinished)//result is to be negative
                    {
                        result = Convert.ToDouble(textBox1.Text);
                        textBox1.Text = Convert.ToString(result *= -1);
                    }
                    break;
                case "button17": //Make number decimal
                    if (textBox1.Text != "" && textBox1.Text != null)
                    {
                        textBox1.AppendText(",");
                        button17.Enabled = false;
                    }
                    break;
            }
        }


        private void button10_Click(object sender, EventArgs e) // C button. Clear all variables and screen.
        {
            textBox1.Text = "";
            num = 0;
            result = 0;
            button17.Enabled = true;
        }

        private void button15_Click(object sender, EventArgs e) //Sum button
        {
            if(textBox1.Text != "" && textBox1.Text != null)
            {
                makeCalculation();
                operationFinished = true;
            }
            textBox1.Text = Convert.ToString(result);
        }

        private void makeCalculation()//Do the calculations
        {
            switch (operationType)//What operational button the user pressed
            {
                case 0:
                    result = num + Convert.ToDouble(textBox1.Text);
                    break;
                case 1:
                    result = num - Convert.ToDouble(textBox1.Text);
                    break;
                case 2:
                    result = num * Convert.ToDouble(textBox1.Text);
                    break;
                case 3:
                    result = num / Convert.ToDouble(textBox1.Text);
                    break;
            }
        }
    }
}
