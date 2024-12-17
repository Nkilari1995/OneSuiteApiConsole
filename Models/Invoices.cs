using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSuiteApiConsole.Models
{
    public class Invoices
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Invoice
        {
            public string id { get; set; }
            public string name { get; set; }
            public DateTime? createdDate { get; set; }
            public string invoiceNo { get; set; }
            public string postBoxNo { get; set; }
            public string company { get; set; }
            public string street { get; set; }
            public string city { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public string description { get; set; }
            public string note { get; set; }
            public int subTotalPrice { get; set; }
            public object discountPrice { get; set; }
            public int salesTax { get; set; }
            public int totalPrice { get; set; }
            public string status { get; set; }
            public object paymentDate { get; set; }
            public string columnOneName { get; set; }
            public string columnTwoName { get; set; }
            public string columnThreeName { get; set; }
            public string columnFourName { get; set; }
            public string columnFiveName { get; set; }
            public string columnSixName { get; set; }
            public string columnSevenName { get; set; }
            public string businessId { get; set; }
            public string clientProfileId { get; set; }
            public string clientName { get; set; }
            public string clientCompany { get; set; }
            public string projectId { get; set; }
            public DateTime dueDate { get; set; }
            public string currency { get; set; }
            public DateTime? createdAt { get; set; }
            public DateTime? updatedAt { get; set; }
            public List<InvoiceItem> invoiceItems { get; set; }
            public int invoiceSerialNo { get; set; }
        }

        public class InvoiceItem
        {
            public string id { get; set; }
            public int serialNo { get; set; }
            public string description { get; set; }
            public int quantity { get; set; }
            public int unitPrice { get; set; }
            public int totalPrice { get; set; }
            public string invoiceId { get; set; }
            public DateTime? createdAt { get; set; }
            public DateTime? updatedAt { get; set; }
        }

        public class Invoicess
        {
            public string status { get; set; }
            public List<Invoice> invoices { get; set; }
        }


    }
}
