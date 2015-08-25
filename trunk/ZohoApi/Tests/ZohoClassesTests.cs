/*
 * User: Ert
 * Date: 5/13/2012
 * Time: 5:44 PM 
 */
using System;
using NUnit.Framework;

namespace ZohoApi.Tests
{
	[TestFixture]
	public class ZohoClassesTests
	{
		ZohoPotentials pot1;
		ZohoPotentials pot2;
		[SetUp]
		public void Init()
		{
			pot1 = new ZohoPotentials("Radiant Systems", "Radiant Systems", DateTime.Parse("05/13/2012"), "Closed Won");
			pot2 = new ZohoPotentials("Honda", "Zotac", DateTime.Parse("05/12/2012"), "Closed Lost");
			
		}
		
		[Test]
		public void TestIsSendable()
		{
			Assert.True(pot1.IsSendable());
		}
		[Test]
		public void TestData()
		{
			var account = typeof(ZohoPotentials).GetProperty("AccountName");
			Assert.AreEqual("AccountName", account.Name);
			Assert.AreEqual("Radiant Systems", account.GetValue(pot1, null));
			Assert.AreEqual("Zotac", account.GetValue(pot2, null));
		}
		
	}
}
