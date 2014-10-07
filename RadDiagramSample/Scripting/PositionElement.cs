using System.Xml.Serialization;

namespace RadDiagramSample.Scripting
{
    public class PositionElement
    {
        [XmlAttribute("x")]
        public double X { get; set; }

        [XmlAttribute("y")]
        public double Y { get; set; }
    }
}