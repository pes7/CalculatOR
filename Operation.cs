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
        public Operation(string first = null, string second = null, TypeOfOperation type = TypeOfOperation.NULL, SubOperations sub1 = SubOperations.NULL, SubOperations sub2 = SubOperations.NULL)
        {
            Type = type;
            FirstNum = first;
            SecondNum = second;
            FirstSub = sub1;
            SecondSub = sub2;
        }
        public Operation GetResult()
        {
            Result = ORS.GetResult(this).Result;
            return this;
        } 
        /*Доделать*/
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
