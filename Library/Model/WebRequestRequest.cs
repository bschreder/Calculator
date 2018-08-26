using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;

namespace Library.Model
{
    public class WebRequestRequest<T> where T : class
    {
        [JsonProperty(PropertyName = "ID", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "ID", IsNullable = true)]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "URL", IsNullable = true)]
        public string URL { get; set; }

        [JsonProperty(PropertyName = "header", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "HEADER", IsNullable = true)]
        public IDictionary<string, string> Header { get; set; }

        [JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement(ElementName = "CONTENT", IsNullable = true)]
        public T Content { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public CancellationToken CancellationToken { get; set; }
    }
}
