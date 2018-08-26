using Library.Algorithm;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Calculator.Models
{
    public class CalculatePostfixRequest
    {
        public List<string> CalculateStack { get; set; }

        public IDictionary<string, Operator> Operators { get; set; }
    }
}