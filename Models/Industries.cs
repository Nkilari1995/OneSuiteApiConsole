using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSuiteApiConsole.Models
{
    public class Industries
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Data
        {
            public string id { get; set; }
            public string name { get; set; }
            public string businessId { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
        }

        public class Indusrties
        {
            public string status { get; set; }
            public List<Data> data { get; set; }
        }


    }
}
