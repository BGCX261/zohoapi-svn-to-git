using System;
/*
 * User: Ert
 * Date: 5/7/2012
 * Time: 8:14 PM 
 */

namespace ZohoApi
{
	public class ZohoPotentials
	{
		public string PotentialOwner { get; set; }
		public string PotentialName { get; set; }
		public string AccountName { get; set; }
		public string PotentialType {get; set;}
		public string LeadSource { get; set; }
		public string CampaignSource { get; set; }
		public string ContactName { get; set; }
		public decimal Amount { get; set; }
		public DateTime ClosingDate { get; set; }
		public string NextStep { get; set; }
		public string PotentialStage { get; set; }
		public int Probability { get; set; }
		public decimal ExpectedRevenue { get; set; }
		public string CreatedBy { get; set; }
		public string ModifiedBy { get; set; }
		public string Description { get; set; }
		
		public ZohoPotentials(string potentialName, string accountName, DateTime closingDate, string potentialStage)
		{
			this.PotentialName = potentialName;
			this.AccountName = accountName;
			this.ClosingDate = closingDate;
			this.PotentialStage = potentialStage;
		}
		
		public bool IsSendable()
		{
			bool HasPotentialName = !string.IsNullOrEmpty(PotentialName);
			bool HasAccountName = !string.IsNullOrEmpty(AccountName);
			bool HasClosingDate = ClosingDate != null;
			bool HasStage = !string.IsNullOrEmpty(PotentialStage);
			
			return HasPotentialName && HasAccountName && HasClosingDate && HasStage;
		}
	}
}