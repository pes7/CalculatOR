using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Operation top; // This Operation

        private void ButOperator(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if(top == null)
            {
                top = new Operation();
                DrowOptional();
            }
            if(top.Type == Operation.TypeOfOperation.NULL)
            {
                Result.Text += bt.Text;
                top.FirstNum += bt.Text;
            }
            else
            {
                Result.Text += bt.Text;
                top.SecondNum += bt.Text;
            }
        }

        private void OperationsOperator(object sender, EventArgs e)
        {
            if(top == null)
            {
                MessageBox.Show("Введите число.");
                return;
            }
            else
            {
                Button bt = sender as Button;
                switch (bt.Text)
                {
                    case "+":
                        top.Type = Operation.TypeOfOperation.Plus;
                        break;
                    case "-":
                        top.Type = Operation.TypeOfOperation.Minus;
                        break;
                    case "/":
                        top.Type = Operation.TypeOfOperation.Drob;
                        break;
                    case "*":
                        top.Type = Operation.TypeOfOperation.Multiply;
                        break;
                }
                DrowOptional();
            }
        }

        private void GetResult(object sender, EventArgs e)
        {
            if(top != null)
            {
                Result.Text = $"Result: {top.GetResult().Result}";
                listBox1.Items.Add($"{top.FirstNum}{top.GetTypeName()}{top.SecondNum}={top.Result}");
                AutorPanel.SendToBack();
                top = null;
            }
            else
            {
                MessageBox.Show("Введите число.");
                return;
            }
        }

        private void cls(object sender, EventArgs e)
        {
            top = null;
            Result.Text = "";
        }

        private void del_Click(object sender, EventArgs e)
        {
            if(top != null)
            {
                if(top.Type == Operation.TypeOfOperation.NULL)
                {
                    if (top.FirstNum.Length > 0)
                        top.FirstNum = top.FirstNum.Remove(top.FirstNum.Length - 1);
                }
                else
                {
                    if (top.SecondNum.Length > 0)
                        top.SecondNum = top.SecondNum.Remove(top.SecondNum.Length - 1);
                }
                DrowOptional();
            }
        }

        private void DrowOptional()
        {
            if(top != null)
                Result.Text = $"{top.FirstNum}{top.GetTypeName()}{top.SecondNum}";
        }
    }
}
