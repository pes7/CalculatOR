using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Operation
    {
        public enum TypeOfOperation {Plus,Minus,Drob,Multiply,NULL};
        public enum SubOperations {Sin,Cos,Tg,Ctg,Pow,Sqrt,NULL};
        public TypeOfOperation Type { get; set; }
        public string FirstNum { get; set; }
        public SubOperations FirstSub { get; set; }
        public string SecondNum { get; set; }
        public SubOperations SecondSub { get; set; }
        public string Result { get; set; }
        /// <summary>
        /// Operation Class
        /// </summary>
        /// <param name="first">Firts Number</param>
        /// <param name="second">Second Number</param>
        /// <param name="type">Type of Operation</param>
        /// <param name="sub1">Sub Operation of First number</param>
        /// <param name="sub2">Sub Operation of Second number</param>
        public Operation(string first = null, string second = null, TypeOfOperation type = TypeOfOperation.NULL, SubOperations sub1 = SubOperations.NULL, SubOperations sub2 = SubOperations.NULL)
        {
            Type = type;
            FirstNum = first;
            SecondNum = second;
            FirstSub = sub1;
            SecondSub = sub2;
        }
        /// <summary>
        /// Get's result of Operation
        /// </summary>
        /// <returns>Result of Operation</returns>
        public Operation GetResult()
        {
            Result = ORS.GetResult(this).Result;
            return this;
        } 
        /// <summary>
        /// Get's (string) Name of sub operation
        /// </summary>
        /// <param name="i">0 - first number, 1 - second number</param>
        /// <returns>Type of sub operation</returns>
        public string GetSubTypeName(int i = 0)
        {
            SubOperations op;
            if (i == 0)
                op = FirstSub;
            else
                op = SecondSub;
            switch (op)
            {
                case SubOperations.Sin:
                    return "sin";
                case SubOperations.Cos:
                    return "cos";
                case SubOperations.Tg:
                    return "tg";
                case SubOperations.Ctg:
                    return "ctg";
                case SubOperations.Pow:
                    return "pow";
                case SubOperations.Sqrt:
                    return "sqrt";
                default: return "";
            }
        }
        /// <summary>
        /// Get's (string) Name of operation
        /// </summary>
        /// <returns>Type of operation</returns>
        public string GetTypeName()
        {
            if (Type != TypeOfOperation.NULL) {
                switch (Type)
                {
                    case TypeOfOperation.Plus:
                        return "+";
                    case TypeOfOperation.Minus:
                        return "-";
                    case TypeOfOperation.Multiply:
                        return "*";
                    case TypeOfOperation.Drob:
                        return "/";
                    default:
                        return "";
                }
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// Get (string) result of operation
        /// </summary>
        /// <returns>result string</returns>
        public string GetStrResult()
        {
            if (FirstSub != Operation.SubOperations.NULL && SecondSub == Operation.SubOperations.NULL)
            {
                return $"{GetSubTypeName()}({FirstNum}){GetTypeName()}{SecondNum}";
            }
            else if (FirstSub == Operation.SubOperations.NULL && SecondSub != Operation.SubOperations.NULL)
            {
                return $"{FirstNum}{GetTypeName()}{GetSubTypeName(1)}({SecondNum})";
            }
            else if (FirstSub != Operation.SubOperations.NULL && SecondSub != Operation.SubOperations.NULL)
            {
                return $"{GetSubTypeName()}({FirstNum}){GetTypeName()}{GetSubTypeName(1)}({SecondNum})";
            }
            else
            {
                return $"{FirstNum}{GetTypeName()}{SecondNum}";
            }
        }
        public override string ToString()
        {
            return $"{GetStrResult()}={Result}";
        }
    }
}
