/*
 * User: Ert
 * Date: 5/13/2012
 * Time: 8:07 PM 
 */
using System;
using System.Xml;
using NUnit.Framework;

namespace ZohoApi.Tests
{
	[TestFixture]
	public class XmlDataTests
	{
		[Test]
		public void TestMethod()
		{
			XmlDocument doc = new XmlDocument();
			XmlDeclaration declare = doc.CreateXmlDeclaration("1.0", null, null);
			doc.AppendChild(declare);
			doc.AppendChild(doc.CreateElement("Potentials"));
			doc.AppendChild(doc.CreateAttribute("FL", "AccountName", "Robert Snyder"));
			
			doc.Save("C:\\test.xml");
			//doc.WriteContentTo(XmlWriter.Create("C:\\test.xml"));
		}
	}
}
