using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.OnlineEducation.CourseCategories
{
    public class CourseCategoryDto : AuditedEntityDto<Guid>
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
