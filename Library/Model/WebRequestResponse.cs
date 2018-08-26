using Newtonsoft.Json;
using System.Net;
using System.Xml.Serialization;

namespace Library.Model
{
    public class WebRequestResponse
    {
        [JsonProperty(PropertyName = "ID", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "ID", IsNullable = true)]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "CONTENT", IsNullable = true)]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "statusCode", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "STATUSCODE", IsNullable = true)]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty(PropertyName = "isSuccessful", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "ISSUCCESSFUL", IsNullable = true)]
        public bool IsSuccessful { get; set; }

        [JsonProperty(PropertyName = "reasonPhrase", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "REASONPHRASE", IsNullable = true)]
        public string ReasonPhrase { get; set; }
    }
}
