using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.OnlineEducation.Courses
{
    public class SessionDetailDto : AuditedEntityDto<Guid>
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public int VideoOrder { get; set; }
    }
}
