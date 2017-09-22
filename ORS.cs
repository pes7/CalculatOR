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

        private static double SubOperation(double i, Operation.SubOperations sub)
        {
            switch (sub) {
                case Operation.SubOperations.Sin:
                    return Math.Sin(i);
                case Operation.SubOperations.Cos:
                    return Math.Cos(i);
                case Operation.SubOperations.Tg:
                    return Math.Tan(i);
                case Operation.SubOperations.Ctg:
                    return 1f / Math.Tan(i);
                default: return i;
            }
        }

        private static double Plus(Operation op)
        {
            return SubOperation(Double.Parse(op.FirstNum), op.FirstSub) + SubOperation(Double.Parse(op.SecondNum), op.SecondSub);
        }
        private static double Minus(Operation op)
        {
            return SubOperation(Double.Parse(op.FirstNum), op.FirstSub) - SubOperation(Double.Parse(op.SecondNum), op.SecondSub);
        }
        private static double Drob(Operation op)
        {
            return SubOperation(Double.Parse(op.FirstNum), op.FirstSub) / SubOperation(Double.Parse(op.SecondNum), op.SecondSub);
        }
        private static double Multiply(Operation op)
        {
            return SubOperation(Double.Parse(op.FirstNum), op.FirstSub) * SubOperation(Double.Parse(op.SecondNum), op.SecondSub);
        }
    }
}
