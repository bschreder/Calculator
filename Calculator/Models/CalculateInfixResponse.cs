using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Calculator.Models
{
    public class CalculateInfixResponse
    {
        public List<string> CalculateStack { get; set; }
    }
}