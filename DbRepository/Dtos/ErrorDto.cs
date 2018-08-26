using DbRepository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace DbRepository.Dtos
{
    [DataContract]
    public class ErrorDto : IEntity
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "ID", IsNullable = true)]
        [DataMember]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "createdDate", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "CREATEDDATE", DataType ="DateTime", IsNullable = true)]
        [DataMember]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "exceptionName", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "EXCEPTIONNAME", IsNullable = true)]
        [DataMember]
        public string ExceptionName { get; set; }

        [JsonProperty(PropertyName = "errorMessage", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "ERRORMESSAGE", IsNullable = true)]
        [DataMember]
        public string ErrorMessage { get; set; }

        [JsonProperty(PropertyName = "exceptionMessage", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "EXCEPTIONMESSAGE", IsNullable = true)]
        [DataMember]
        string ExceptionMessage { get; set; }
    }
}
