using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.OnlineEducation
{
    public class Instructor : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public UserProfile User { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
