using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.OnlineEducation
{
    public class Enrollment : AuditedAggregateRoot<Guid>
    {

        public Guid CourseId { get; set; }

        public Guid UserId { get; set; }

        public DateTime? EnrollmentDate { get; set; }

        [MaxLength(20)]
        public string PaymentStatus { get; set; } = null!;

        [ForeignKey("CourseId")]
        [InverseProperty("Enrollments")]
        public virtual Course Course { get; set; } = null!;

        [InverseProperty("Enrollment")]
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

        [ForeignKey("UserId")]
        [InverseProperty("Enrollments")]
        public virtual UserProfile User { get; set; } = null!;
    }
}
