using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportLoadXML.XMLParser
{
	[XmlRoot(ElementName = "Cards")]
	public class Cards
	{
		[XmlElement(ElementName = "Card")]
		public List<CardXMLData> Card { get; set; }
	}
}
