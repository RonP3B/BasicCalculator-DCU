using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        private double numUno = 0.0, numDos = 0.0;
        private char operador;

        public Form1()
        {
            InitializeComponent();
        }

        private void addNum(object sender, EventArgs e)
        {
            string c = txtResultado.Text;
            if (c == "0" || c.Contains("N") || c.Contains("∞"))
                txtResultado.Text = "";

            txtResultado.Text += ((Guna.UI2.WinForms.Guna2Button)sender).Text;
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
            numUno = 0.0;
            numDos = 0.0;
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "√";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            int chars = txtResultado.Text.Length;

            if (txtResultado.Text.Substring(0, 1) != "√")
            {
                numDos = Convert.ToDouble(txtResultado.Text);

                if (operador == '+')
                    txtResultado.Text = (numUno + numDos).ToString();
                else if (operador == '-')
                    txtResultado.Text = (numUno - numDos).ToString();
                else if (operador == 'X')
                    txtResultado.Text = (numUno * numDos).ToString();
                else
                    txtResultado.Text = (numUno / numDos).ToString();
            }
            else if (chars > 1)
            {
                numUno = Convert.ToDouble(txtResultado.Text.Substring(1, chars - 1));
                txtResultado.Text = Math.Sqrt(numUno).ToString();
            } else
            {
                txtResultado.Text = "0";
            }
        }

        private void btnMasMenos_Click(object sender, EventArgs e)
        {
            string c = txtResultado.Text;
            if (!c.Contains("√"))
            {
                double num = Convert.ToDouble(txtResultado.Text);
                num *= -1;
                txtResultado.Text = num.ToString();
            }
            
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            string c = txtResultado.Text;

            if (!c.Contains(".")) txtResultado.Text += ".";
        }

        private void operadorClick(object sender, EventArgs e)
        {
            numUno = Convert.ToDouble(txtResultado.Text);
            operador = Convert.ToChar(((Guna.UI2.WinForms.Guna2Button)sender).Text);
            txtResultado.Text = "0";
        }
    }
}
