using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSuiteApiConsole.Models
{
    public class Clients
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

        public class Client
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string fullName { get; set; }
            public string email { get; set; }
            public string status { get; set; }
            public string customerStatus { get; set; }
            public string profileImg { get; set; }
            public string personalEmail { get; set; }
            public string dateOfBirth { get; set; }
            public string designation { get; set; }
            public object primaryContact { get; set; }
            public object secondaryContact { get; set; }
            public string primaryPhone { get; set; }
            public string secondaryPhone { get; set; }
            public Address address { get; set; }
            public string fax { get; set; }
            public string personalWebsite { get; set; }
            public string keywords { get; set; }
            public string companyId { get; set; }
            public string companyName { get; set; }
            public string companyEmail { get; set; }
            public string companyPhone { get; set; }
            public CompanyAddress companyAddress { get; set; }
            public string foundedDate { get; set; }
            public string companyWebsite { get; set; }
            public object companyServices { get; set; }
            public string companyServiceArea { get; set; }
            public object industry { get; set; }
            public object leadSource { get; set; }
            public object clientSource { get; set; }
            public string priority { get; set; }
            public List<object> tags { get; set; }
            public object opportunityStage { get; set; }
            public string inviteStatus { get; set; }
            public string userToBusinessId { get; set; }
            public string createdAt { get; set; }
            public string updatedAt { get; set; }
        }

        public class CompanyAddress
        {
            public string companyCity { get; set; }
            public string companyState { get; set; }
            public string companyAddress { get; set; }
            public string companyCountry { get; set; }
            public string companyPostalCode { get; set; }
        }

        public class Clientss
        {
            public List<Client> clients { get; set; }
        }


    }
}
