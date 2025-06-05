using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.OnlineEducation.Enrollments
{
    public class CourseEnrollmentDto : AuditedEntityDto<Guid>
    {
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string PaymentStatus { get; set; } = null!;
        public CoursePaymentDto CoursePayment { get; set; }
    }
}
