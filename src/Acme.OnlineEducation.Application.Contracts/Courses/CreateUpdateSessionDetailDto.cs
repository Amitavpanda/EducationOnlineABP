using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.OnlineEducation.Courses
{
    public class CreateUpdateSessionDetailDto
    {
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [Required]
        public int VideoOrder { get; set; }
    }
}
