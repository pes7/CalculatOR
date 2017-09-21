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
        public TypeOfOperation Type { get; set; }
        public string FirstNum { get; set; }
        public string SecondNum { get; set; }
        public double Result { get; set; }
        public Operation(string first = null, string second = null, TypeOfOperation type = TypeOfOperation.NULL)
        {
            Type = type;
            FirstNum = first;
            SecondNum = second;
        }
        public Operation GetResult()
        {
            Result = ORS.GetResult(this).Result;
            return this;
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
