
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.OnlineEducation
{
    public class Course : AuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CourseType { get; set; }
        public int? SeatsAvailable { get; set; }
        public decimal Duration { get; set; }
        public Guid CategoryId { get; set; }
        public Guid InstructorId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Thumbnail { get; set; }

        // Navigation properties
        public CourseCategory Category { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<SessionDetail> SessionDetails { get; set; } = new List<SessionDetail>();
    }
}
