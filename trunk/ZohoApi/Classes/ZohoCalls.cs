using System;
/*
 * User: Ert
 * Date: 5/7/2012
 * Time: 8:28 PM 
 */

namespace ZohoApi
{
	public class ZohoCalls
	{
		public string Subject { get; set; }
		public string CallType { get; set; }
		public string CallPurpose { get; set; }
		public string CallFromTo {get; set;}
		public string RelatedTo { get; set; }
		public string CallDetails { get; set; }
		public DateTime CallStartTime { get; set; }
		public int CallDuration { get; set; }
		public string Description { get; set; }
		public bool Billable { get; set; }
		public string CallResult { get; set; }
	}
}