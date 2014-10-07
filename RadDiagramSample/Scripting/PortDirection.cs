using System;
using System.Xml.Serialization;

namespace RadDiagramSample.Scripting
{
    [Serializable]
    public enum PortDirection
    {
        [XmlEnum("input")]
        Input,
        [XmlEnum("output")]
        Output
    }
}