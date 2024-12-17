using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSuiteApiConsole.Models
{
    public class Leads
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Address
        {
            public string city { get; set; }
            public string state { get; set; }
            public string address { get; set; }
            public string country { get; set; }
            public string postalCode { get; set; }
        }

        public class Lead
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string fullName { get; set; }
            public string email { get; set; }
            public string profileImg { get; set; }
            public string personalEmail { get; set; }
            public string dateOfBirth { get; set; }
            public string designation { get; set; }
            public string primaryContact { get; set; }
            public string secondaryContact { get; set; }
            public string status { get; set; }
            public string primaryPhone { get; set; }
            public string secondaryPhone { get; set; }
            public Address address { get; set; }
            public string fax { get; set; }
            public string personalWebsite { get; set; }
            public string customerStatus { get; set; }
            public string linkedinUrl { get; set; }
            public string shortNote { get; set; }
            public string keywords { get; set; }
            public object industry { get; set; }
            public List<LeadAssignedTo> leadAssignedTo { get; set; }
            public object leadSource { get; set; }
            public string priority { get; set; }
            public List<object> tags { get; set; }
            public OpportunityStage opportunityStage { get; set; }
            public int leadSortId { get; set; }
            public string createdAt { get; set; }
            public string updatedAt { get; set; }
        }

        public class LeadAssignedTo
        {
            public string id { get; set; }
            public string profileImg { get; set; }
            public string fullName { get; set; }
            public string email { get; set; }
        }

        public class OpportunityStage
        {
            public string id { get; set; }
            public string stageName { get; set; }
            public string stageColor { get; set; }
            public int stageNo { get; set; }
            public bool isFolded { get; set; }
        }

        public class Root
        {
            public List<Lead> leads { get; set; }
        }


    }
}
