using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RadDiagramSample.Scripting
{
    [Serializable]
    public class PropertyElement
    {
        public PropertyElement()
        {
            Options = new List<OptionElement>();
        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("option")]
        public List<OptionElement> Options { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}