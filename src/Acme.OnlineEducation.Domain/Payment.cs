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
    public class Payment : AuditedAggregateRoot<Guid>
    {
        public Guid EnrollmentId { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        public DateTime? PaymentDate { get; set; }

        [MaxLength(50)]
        public string PaymentMethod { get; set; } = null!;

        [MaxLength(20)]
        public string PaymentStatus { get; set; } = null!;

        [ForeignKey("EnrollmentId")]
        [InverseProperty("Payments")]
        public virtual Enrollment Enrollment { get; set; } = null!;
    }
}
