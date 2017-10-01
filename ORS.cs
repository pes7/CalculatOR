using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    static class ORS
    {
        /// <summary>
        /// Get Result of Math Operation
        /// </summary>
        /// <param name="op">Operation that need's to calculate</param>
        /// <returns>return's Operation with result in it</returns>
        public static Operation GetResult(Operation op)
        {
            if (Check(op))
            {
                switch (op.Type)
                {
                    case Operation.TypeOfOperation.Plus:
                        op.Result = Plus(op).ToString();
                        break;
                    case Operation.TypeOfOperation.Minus:
                        op.Result = Minus(op).ToString();
                        break;
                    case Operation.TypeOfOperation.Drob:
                        op.Result = Drob(op).ToString();
                        break;
                    case Operation.TypeOfOperation.Multiply:
                        op.Result = Multiply(op).ToString();
                        break;
                }
            }
            if (op.FirstSub != Operation.SubOperations.NULL)
            {
                op.Result = SubOperation(Double.Parse(op.FirstNum), op.FirstSub).ToString();
            }
            return op;
        }

        /// <summary>
        /// Checks can we calculate this operation
        /// </summary>
        /// <param name="op">Operation</param>
        /// <returns>bool Can we or need</returns>
        private static bool Check(Operation op)
        {
            return op.FirstNum == null || op.SecondNum == null ? false : true;
        }

        /// <summary>
        /// Gets math calculation of sub operations
        /// </summary>
        /// <param name="i">Number</param>
        /// <param name="sub">Type of sub operation</param>
        /// <returns>Result of calculation</returns>
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
                case Operation.SubOperations.Pow:
                    return Math.Pow(i, 2);
                case Operation.SubOperations.Sqrt:
                    return Math.Sqrt(i);
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
