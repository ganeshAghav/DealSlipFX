namespace FP.Common.Configuration
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serialization
    {
        public static XmlDocument DocumentFromXMLString(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            return document;
        }

        public static object ObjectFromDocument(XmlDocument document, Type type)
        {
            object obj2 = null;
            MemoryStream outStream = new MemoryStream();
            document.Save(outStream);
            outStream.Position = 0L;
            obj2 = new XmlSerializer(type).Deserialize(outStream);
            outStream.Close();
            return obj2;
        }

        public static XmlDocument ObjectToDocument(object toSerialiseObject)
        {
            XmlDocument document = new XmlDocument();
            MemoryStream inStream = new MemoryStream();
            new XmlSerializer(toSerialiseObject.GetType()).Serialize((Stream) inStream, toSerialiseObject);
            inStream.Position = 0L;
            document.PreserveWhitespace = false;
            document.Load(inStream);
            inStream = null;
            return document;
        }
    }
}

