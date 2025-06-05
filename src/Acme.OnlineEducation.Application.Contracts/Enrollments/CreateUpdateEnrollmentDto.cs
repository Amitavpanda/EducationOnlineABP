using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.OnlineEducation.Enrollments
{
    public class CreateUpdateEnrollmentDto : AuditedEntityDto<Guid>
    {
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string PaymentStatus { get; set; } = null!;
    }
}
