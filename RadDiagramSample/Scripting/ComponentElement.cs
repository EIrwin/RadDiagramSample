using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using RadDiagramSample.Models;

namespace RadDiagramSample.Scripting
{
    [Serializable]
    [XmlRoot("DesignerComponent")]
    public class ComponentElement
    {
        [XmlAttribute("id")]
        public Guid ID { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("port")]
        public List<PortElement> Ports { get; set; }

        [XmlAttribute("generator")]
        public string Generator { get; set; }

        [XmlElement("property")]
        public List<PropertyElement> Properties { get; set; }

        [XmlElement("content")]
        public ContentElement Content { get; set; }

        [XmlElement("position")]
        public PositionElement Position { get; set; }

        #region [Constructors]

        public ComponentElement()
        {
            Ports = new List<PortElement>();
            Properties = new List<PropertyElement>();
            Content = new ContentElement();
            Position = new PositionElement();
        }

        public ComponentElement(Guid id)
        {
            ID = id;
            Ports = new List<PortElement>();
            Properties = new List<PropertyElement>();
            Content = new ContentElement();
            Position = new PositionElement();
        }

        public ComponentElement(Type generator)
        {
            Generator = generator.FullName;
        }

        #endregion
    }
}