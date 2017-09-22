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
        public double Result { get; set; }
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
        public string[] GetSubTypeName()
        {
            string[] str = new string[2];
                switch (FirstSub)
                {
                    case "":
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
    }
}
