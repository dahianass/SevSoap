using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SSoap
{
    [XmlRoot]
    public class StatusDocumentItem
    {
        [XmlElement]
        public string Ebeln;
        [XmlElement]
        public string Resfact;
        [XmlElement]
        public string Name1;
    }
}