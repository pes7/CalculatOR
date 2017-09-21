using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    static class ORS
    {
        public static Operation GetResult(Operation op)
        {
            if (Check(op))
            {
                switch (op.Type)
                {
                    case Operation.TypeOfOperation.Plus:
                        op.Result = Plus(op);
                        break;
                    case Operation.TypeOfOperation.Minus:
                        op.Result = Minus(op);
                        break;
                    case Operation.TypeOfOperation.Drob:
                        op.Result = Drob(op);
                        break;
                    case Operation.TypeOfOperation.Multiply:
                        op.Result = Multiply(op);
                        break;
                }
            }
            return op;
        }

        private static bool Check(Operation op)
        {
            return op.FirstNum == null || op.SecondNum == null ? false : true;
        }

        private static double Plus(Operation op)
        {
            return Double.Parse(op.FirstNum) + Double.Parse(op.SecondNum);
        }
        private static double Minus(Operation op)
        {
            return Double.Parse(op.FirstNum) - Double.Parse(op.SecondNum);
        }
        private static double Drob(Operation op)
        {
            return Double.Parse(op.FirstNum) / Double.Parse(op.SecondNum);
        }
        private static double Multiply(Operation op)
        {
            return Double.Parse(op.FirstNum) * Double.Parse(op.SecondNum);
        }
    }
}
