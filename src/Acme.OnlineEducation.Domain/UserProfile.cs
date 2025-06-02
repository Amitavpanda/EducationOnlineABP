using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.OnlineEducation
{
    public class UserProfile : Entity<int>
    {
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AdObjId { get; set; }
        public string ProfilePictureUrl { get; set; }

        // Navigation properties
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        //public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        //public ICollection<VideoRequest> VideoRequests { get; set; } = new List<VideoRequest>();
    }
}
