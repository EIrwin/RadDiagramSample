using System;
using System.Xml.Serialization;

namespace RadDiagramSample.Scripting
{
    [Serializable]
    public class OptionElement
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("selected")]
        public bool Selected { get; set; }
    }
}