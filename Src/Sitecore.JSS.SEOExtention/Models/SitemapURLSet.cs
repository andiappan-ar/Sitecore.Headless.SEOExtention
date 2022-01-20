using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Sitecore.JSS.SEOExtention.Models
{
	// using System.Xml.Serialization;
	// XmlSerializer serializer = new XmlSerializer(typeof(Urlset));
	// using (StringReader reader = new StringReader(xml))
	// {
	//    var test = (Urlset)serializer.Deserialize(reader);
	// }

	[XmlRoot(ElementName = "urlset")]
	public class SitemapURLSet
	{

		[XmlElement(ElementName = "url")]
		public List<Url> Url { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }

		[XmlAttribute(AttributeName = "xmlns")]
		public string Xmlns { get; set; }

		[XmlAttribute(AttributeName = "image")]
		public string Image { get; set; }

		[XmlAttribute(AttributeName = "schemaLocation")]
		public string SchemaLocation { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "url")]
	public class Url
	{

		[XmlElement(ElementName = "image")]
		public List<Image> Image { get; set; }

		[XmlElement(ElementName = "lastmod")]
		public DateTime Lastmod { get; set; }

		[XmlElement(ElementName = "changefreq")]
		public string Changefreq { get; set; }

		[XmlElement(ElementName = "loc")]
		public string Loc { get; set; }

		[XmlElement(ElementName = "priority")]
		public string Priority { get; set; }
	}

	[XmlRoot(ElementName = "image")]
	public class Image
	{

		[XmlElement(ElementName = "loc")]
		public string Loc { get; set; }

		[XmlElement(ElementName = "title")]
		public string Title { get; set; }
	}
}