using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using RadDiagramSample.Models;

namespace RadDiagramSample.Scripting
{
    [Serializable]
    public class ContentElement
    {
        [XmlArray("components"), XmlArrayItem("component")]
        public List<ComponentElement> Components { get; set; }

        [XmlArray("routing"), XmlArrayItem("route")]
        public List<RouteElement> Routing { get; set; }

        public ContentElement()
        {
            Components = new List<ComponentElement>();
            Routing = new List<RouteElement>();
        }
    }
}