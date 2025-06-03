using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.OnlineEducation
{
    public class Review : Entity<int>
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime ReviewDate { get; set; }

        // Navigation properties
        public Course Course { get; set; }
        public UserProfile User { get; set; }
    }
}
