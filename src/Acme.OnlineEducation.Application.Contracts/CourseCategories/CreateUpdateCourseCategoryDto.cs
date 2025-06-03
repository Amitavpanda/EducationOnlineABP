using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.OnlineEducation.CourseCategories
{
    public class CreateUpdateCourseCategoryDto
    {
        [Required]
        [StringLength(60)]
        public string CategoryName { get; set; } = String.Empty;

        [Required]
        [StringLength(128)]
        public string Description { get; set; } = String.Empty;
    }
}
