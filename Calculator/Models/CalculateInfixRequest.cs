using Library.Algorithm;
using System.Collections.Generic;

namespace Calculator.Models
{
    public class CalculateInfixRequest
    {
        public string Input { get; set; }

        public IDictionary<string, Operator> Operators { get; set; }
    }
}