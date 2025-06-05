using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.OnlineEducation.Courses
{
    public class UserRatingDto : AuditedEntityDto<Guid>
    {
        public Guid CourseId { get; set; }
        public decimal AverageRating { get; set; }
        public int TotalRating { get; set; }
    }
}
