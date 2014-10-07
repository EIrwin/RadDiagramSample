using System;
using System.Xml.Serialization;

namespace RadDiagramSample.Scripting
{
    [Serializable]
    public class PortElement
    {
        [XmlAttribute("type")]
        public PortDirection Type { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlAttribute("id")]
        public Guid ID { get; set; }

        [XmlAttribute("internal")]
        public bool Internal { get; set; }

        [XmlAttribute("external")]
        public bool External { get; set; }

        public PortElement()
        {
            ID = Guid.NewGuid();
        }
    }
}