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
        private List<Operation> Operations;
        private Operation top; // This Operation

        public Form1()
        {
            InitializeComponent();
            Operations = new List<Operation>();
        }

        private void ButOperator(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            if(top == null)
            {
                top = new Operation();
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
            DrowOptional();
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
                    case "sin":
                        AddSubOp(Operation.SubOperations.Sin);
                        break;
                    case "cos":
                        AddSubOp(Operation.SubOperations.Cos);
                        break;
                    case "tg":
                        AddSubOp(Operation.SubOperations.Tg);
                        break;
                    case "ctg":
                        AddSubOp(Operation.SubOperations.Ctg);
                        break;
                    case "x^2":
                        AddSubOp(Operation.SubOperations.Pow);
                        break;
                    case "sqrt":
                        AddSubOp(Operation.SubOperations.Sqrt);
                        break;
                }
                DrowOptional();
            }
        }

        private void AddSubOp(Operation.SubOperations sub)
        {
            if (top.Type == Operation.TypeOfOperation.NULL)
                top.FirstSub = sub;
            else
                top.SecondSub = sub;
        }

        private void GetResult(object sender, EventArgs e)
        {
            if(top != null && top.FirstNum != null && top.SecondNum != null && top.Type != Operation.TypeOfOperation.NULL)
            {
                Result.Text = $"Result: {top.GetResult().Result}";
                Operation oper = new Operation(top.FirstNum, top.SecondNum, top.Type, top.FirstSub, top.SecondSub);
                oper.Result = top.Result;
                Operations.Insert(0, oper);
                ResultList.Items.Insert(0, top);
                AutorPanel.SendToBack();
                top.FirstNum = top.Result.ToString();
                top.FirstSub = Operation.SubOperations.NULL;
                top.SecondSub = Operation.SubOperations.NULL;
                top.SecondNum = "";
                top.Type = Operation.TypeOfOperation.NULL;
            }
            else
            {
                MessageBox.Show("Ошибка.");
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
            {
                Result.Text = top.GetStrResult();
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(Operations[ResultList.SelectedIndex].Result.ToString());
            }catch(Exception ex)
            {

            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (top.Type == Operation.TypeOfOperation.NULL)
                    top = new Operation(Operations[ResultList.SelectedIndex].Result.ToString());
                else
                    top.SecondNum = Operations[ResultList.SelectedIndex].Result.ToString();
                DrowOptional();
            }catch(Exception ex)
            {

            }
        }

        private void CatImage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Да, да, pes7 это я - Назар Уколов.");
        }
    }
}
