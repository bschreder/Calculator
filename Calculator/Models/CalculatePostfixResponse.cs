using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace Calculator.Models
{
    public class CalculatePostfixResponse
    {
        [JsonProperty(PropertyName = "calculatedValue", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "CALCULATEDVALUE", IsNullable = true)]
        [DataMember]
        public int CalculatedValue { get; set; }
    }
}