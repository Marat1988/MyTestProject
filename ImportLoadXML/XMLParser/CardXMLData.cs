using HtmlParserSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ImportLoadXML.XMLParser
{
	[XmlRoot(ElementName = "Card")]
	public class CardXMLData
	{
		[XmlAttribute(AttributeName = "CARDCODE")]
		public string CARDCODE { get; set; }
		[XmlAttribute(AttributeName = "STARTDATE")]
		public string STARTDATE { get; set; }
		[XmlAttribute(AttributeName = "FINISHDATE")]
		public string FINISHDATE { get; set; }
		[XmlAttribute(AttributeName = "LASTNAME")]
		public string LASTNAME { get; set; }
		[XmlAttribute(AttributeName = "FIRSTNAME")]
		public string FIRSTNAME { get; set; }
		[XmlAttribute(AttributeName = "SURNAME")]
		public string SURNAME { get; set; }
		[XmlAttribute(AttributeName = "FULLNAME")]
		public string FULLNAME { get; set; }
		[XmlAttribute(AttributeName = "GENDERID")]
		public string GENDERID { get; set; }
		[XmlAttribute(AttributeName = "BIRTHDAY")]
		public string BIRTHDAY { get; set; }
		[XmlAttribute(AttributeName = "PHONEHOME")]
		public string PHONEHOME { get; set; }
		[XmlAttribute(AttributeName = "PHONEMOBIL")]
		public string PHONEMOBIL { get; set; }
		[XmlAttribute(AttributeName = "EMAIL")]
		public string EMAIL { get; set; }
		[XmlAttribute(AttributeName = "CITY")]
		public string CITY { get; set; }
		[XmlAttribute(AttributeName = "STREET")]
		public string STREET { get; set; }
		[XmlAttribute(AttributeName = "HOUSE")]
		public string HOUSE { get; set; }
		[XmlAttribute(AttributeName = "APARTMENT")]
		public string APARTMENT { get; set; }
		[XmlAttribute(AttributeName = "ALTADDRESS")]
		public string ALTADDRESS { get; set; }
		[XmlAttribute(AttributeName = "CARDTYPE")]
		public string CARDTYPE { get; set; }
		[XmlAttribute(AttributeName = "OWNERGUID")]
		public string OWNERGUID { get; set; }
		[XmlAttribute(AttributeName = "CARDPER")]
		public string CARDPER { get; set; }
		[XmlAttribute(AttributeName = "TURNOVER")]
		public string TURNOVER { get; set; }

		public Nullable<System.DateTime> IsNULLSTARTDATE()
		{
			if (string.IsNullOrEmpty(STARTDATE))
				return null;
			else
				return DateTime.Parse(STARTDATE);
		}

		public Nullable<System.DateTime> IsNULLFINISHDATE()
        {
			if (string.IsNullOrEmpty(FINISHDATE))
				return null;
            else
				return  DateTime.Parse(FINISHDATE);
		}

		public Nullable<System.DateTime> IsNullOrEmptyBIRTHDAY()
        {
			if (string.IsNullOrEmpty(BIRTHDAY))
				return null;
            else
				return DateTime.Parse(BIRTHDAY);
        }

		public Nullable<byte> IsNullOrEmptyHOUSE()
        {
			if (string.IsNullOrEmpty(HOUSE))
				return null;
			else
				return Byte.Parse(HOUSE);
        }

		public Nullable<byte> IsNullOrEmptyAPARTMENT()
		{
			if (string.IsNullOrEmpty(APARTMENT))
				return null;
			else
				return Byte.Parse(APARTMENT);
		}

	}
}
