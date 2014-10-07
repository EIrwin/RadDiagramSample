using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RadDiagramSample.Scripting
{
    [Serializable]
    public class RouteElement
    {
        public RouteElement()
        {
            Destinations = new List<LinkElement>();
        }

        [XmlAttribute("component")]
        public Guid Component { get; set; }

        [XmlAttribute("port")]
        public string Port { get; set; }

        [XmlElement("to")]
        public List<LinkElement> Destinations { get; set; }
    }
}