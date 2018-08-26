using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.Models
{
    public class CalculatorRequest
    {
        [JsonProperty(PropertyName = "input", NullValueHandling = NullValueHandling.Ignore)]
        public string Input { get; set; }
    }
}