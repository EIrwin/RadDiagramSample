using System;
using System.Xml.Serialization;

namespace RadDiagramSample.Scripting
{
    [Serializable]
    public class LinkElement
    {
        [XmlAttribute("component")]
        public Guid Component { get; set; }

        [XmlAttribute("port")]
        public string Port { get; set; }
    }
}