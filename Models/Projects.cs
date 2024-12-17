using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneSuiteApiConsole.Models
{
    public class Projects
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Business
        {
            public string businessName { get; set; }
            public string id { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public string businessId { get; set; }
            public DateTime? createdAt { get; set; }
            public DateTime? updatedAt { get; set; }
        }

        public class Collaborator
        {
            public string id { get; set; }
            public string projectId { get; set; }
            public string role { get; set; }
            public UserToBusiness userToBusiness { get; set; }
            public string userToBusinessId { get; set; }
        }

        public class Project
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string businessId { get; set; }
            public string privacy { get; set; }
            public string creatorUserToBusinessId { get; set; }
            public object leadId { get; set; }
            public object clientProfileId { get; set; }
            public string priority { get; set; }
            public string status { get; set; }
            public DateTime? startDate { get; set; }
            public DateTime? dueDate { get; set; }
            public int progress { get; set; }
            public int completedTasks { get; set; }
            public string clientPermission { get; set; }
            public DateTime? createdAt { get; set; }
            public DateTime? updatedAt { get; set; }
            public Business business { get; set; }
            public List<Collaborator> collaborators { get; set; }
            public object lead { get; set; }
            public object clientProfile { get; set; }
            public List<Category> categories { get; set; }
            public List<Tag> tags { get; set; }
            public List<object> sections { get; set; }
            public string projectName { get; set; }
            public string projectStatus { get; set; }
            public int totalTasks { get; set; }
            public int totalSubTasks { get; set; }
            public int completedSubTasks { get; set; }
        }

        public class Projectt
        {
            public string status { get; set; }
            public List<Project> projects { get; set; }
        }

        public class Tag
        {
            public string id { get; set; }
            public string name { get; set; }
            public string businessId { get; set; }
            public DateTime? createdAt { get; set; }
            public DateTime? updatedAt { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string fullName { get; set; }
            public string role { get; set; }
            public string profileImg { get; set; }
        }

        public class UserToBusiness
        {
            public string id { get; set; }
            public string businessId { get; set; }
            public User user { get; set; }
            public string userId { get; set; }
        }

    }
}
