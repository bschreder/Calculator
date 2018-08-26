using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Library.Utilities
{
    public static class XMLSerializer<T> where T: class
    {
        /// <summary>
        /// XML Serializer - convert generic object to xml string
        /// </summary>
        /// <param name="obj">generic object</param>
        /// <param name="encoding">type of encoding to use (default is UTF8)</param>
        /// <returns>xml string</returns>
        public static string Serialize(T obj, Encoding encoding = null)
        {
            if (obj == null)
                return null;

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Encoding = encoding ?? new UTF8Encoding(false, false),
                Indent = false,
                OmitXmlDeclaration = false,      //  true = remove <?xml version="1.0" encoding="UTF-16"?> from top of XMLdoc string
            };

            using (StringWriter sw = new StringWriter())
            {
                using (XmlWriter xw = XmlWriter.Create(sw, settings))
                    serializer.Serialize(sw, obj);

                return sw.ToString();
            }
        }


        /// <summary>
        /// XML Deserializer - convert xml string to generic object
        /// </summary>
        /// <param name="xml">xml string</param>
        /// <returns>Generic T object</returns>
        public static T Deserialize(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return null;

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            XmlReaderSettings settings = new XmlReaderSettings()
            {
                IgnoreComments = true,
                IgnoreProcessingInstructions = true,
                IgnoreWhitespace = true,
            };

            using (StringReader sr = new StringReader(xml))
                using (XmlReader xr = XmlReader.Create(sr, settings))
                    return (T)serializer.Deserialize(xr);

        }
    }
}
