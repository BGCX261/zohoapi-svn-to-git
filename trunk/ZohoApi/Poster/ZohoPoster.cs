﻿using System;
using System.IO;
using System.Net;
using System.Xml;

/*
 * User: Ert
 * Date: 5/13/2012
 * Time: 6:59 PM
 */

namespace ZohoApi
{
	public class ZohoPoster
	{
		//this is my authentification token for immeraufdemhund@yahoo.com
		//it is strictly for testing so don't worry if you post junk up here, just keep the numbers down
		
		string myAuthToken = "188b63a6ce655eed8380a45820b35cf0";
		string ZohoUrl = "https://crm.zoho.com/crm/private/xml/";
		
		public static string Post(string field, string call, string xmlData)
		{
			return string.Empty;
		}
		public static XmlDocument PostXMLTransaction(string v_strURL, XmlDocument v_objXMLDoc)
		{
			//Declare XMLResponse document
			XmlDocument XMLResponse = null;

			//Declare an HTTP-specific implementation of the WebRequest class.
			HttpWebRequest objHttpWebRequest;

			//Declare an HTTP-specific implementation of the WebResponse class
			HttpWebResponse objHttpWebResponse = null;

			//Declare a generic view of a sequence of bytes
			Stream objRequestStream = null;
			Stream objResponseStream = null;

			//Declare XMLReader
			XmlTextReader objXMLReader;

			//Creates an HttpWebRequest for the specified URL.
			objHttpWebRequest = (HttpWebRequest)WebRequest.Create(v_strURL);

			try
			{
				//---------- Start HttpRequest

				//Set HttpWebRequest properties
				byte[] bytes;
				bytes = System.Text.Encoding.ASCII.GetBytes(v_objXMLDoc.InnerXml);
				objHttpWebRequest.Method = "POST";
				objHttpWebRequest.ContentLength = bytes.Length;
				objHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";

				//Get Stream object
				objRequestStream = objHttpWebRequest.GetRequestStream();

				//Writes a sequence of bytes to the current stream
				objRequestStream.Write(bytes, 0, bytes.Length);

				//Close stream
				objRequestStream.Close();

				//---------- End HttpRequest

				//Sends the HttpWebRequest, and waits for a response.
				objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();

				//---------- Start HttpResponse
				if (objHttpWebResponse.StatusCode == HttpStatusCode.OK)
				{
					//Get response stream
					objResponseStream = objHttpWebResponse.GetResponseStream();

					//Load response stream into XMLReader
					objXMLReader = new XmlTextReader(objResponseStream);

					//Declare XMLDocument
					XmlDocument xmldoc = new XmlDocument();
					xmldoc.Load(objXMLReader);

					//Set XMLResponse object returned from XMLReader
					XMLResponse = xmldoc;

					//Close XMLReader
					objXMLReader.Close();
				}

				//Close HttpWebResponse
				objHttpWebResponse.Close();
			}
			catch (WebException we)
			{
				//TODO: Add custom exception handling
				throw new Exception(we.Message);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				//Close connections
				objRequestStream.Close();
				objResponseStream.Close();
				objHttpWebResponse.Close();

				//Release objects
				objXMLReader = null;
				objRequestStream = null;
				objResponseStream = null;
				objHttpWebResponse = null;
				objHttpWebRequest = null;
			}

			//Return
			return XMLResponse;
		}
	}
}