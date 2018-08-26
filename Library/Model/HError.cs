using Library.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Library.Model
{
    [DataContract]
    public class HError
    {
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "ERROR", IsNullable = true)]
        [DataMember]
        public string Error { get; set; }


        public HError(string exceptionName, string errorMessage)
        {
            Console.WriteLine($"{exceptionName}: {errorMessage}");
            Error = $"{exceptionName}: {errorMessage}";
        }

        public static implicit operator HError(HException exception)
        {
            return exception.Error;
        }
    }
}
