using Library.Interfaces;
using DbRepository.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using DbRepository.Interfaces;
using DbRepository.Business;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Library.Model
{
    [DataContract]
    public class HException : Exception, IHError
    {
        [JsonProperty(PropertyName = "error", Required = Required.Always)]
        [XmlElement(ElementName = "ERROR", IsNullable = true)]
        [DataMember]
        public HError Error { get; set; }


        public HException(string exceptionName, string errorMessage, Exception ex)  : base(errorMessage, ex)
        {
            Error = new HError(exceptionName, errorMessage);
        }

        public HException(DataRepository<ErrorDto> dbRepository, string exceptionName, string errorMessage, Exception ex) 
            : this (exceptionName, errorMessage, ex)
        {
            var dto = new ErrorDto
            {
                ExceptionName = exceptionName,
                ErrorMessage = errorMessage
            };
            int x = dbRepository.AddOrUpdateAsync(dto).Result;
        }
    }
}
