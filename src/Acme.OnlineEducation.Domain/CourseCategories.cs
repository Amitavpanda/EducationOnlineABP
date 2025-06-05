using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.OnlineEducation
{
    public class CourseCategory : AuditedAggregateRoot<Guid>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
