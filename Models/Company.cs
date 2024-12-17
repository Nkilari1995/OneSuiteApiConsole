using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSuiteApiConsole.Models
{
    public class Company
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Companies
        {
            public string id { get; set; }
            public string companyName { get; set; }
            public string companyEmail { get; set; }
            public string companyPhone { get; set; }
            public CompanyAddress companyAddress { get; set; }
            public string foundedDate { get; set; }
            public string companyWebsite { get; set; }
            public string companyServices { get; set; }
            public string companyServiceArea { get; set; }
            public string businessId { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
        }

        public class CompanyAddress
        {
            public string companyCity { get; set; }
            public string companyState { get; set; }
            public string companyAddress { get; set; }
            public string companyCountry { get; set; }
            public string companyPostalCode { get; set; }
        }

        public class Companys
        {
            public List<Companies> companies { get; set; }
        }

    }
}
