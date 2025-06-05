using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.OnlineEducation.Courses
{
    public class CreateUpdateCourseDto
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string CourseType { get; set; }

        public int? SeatsAvailable { get; set; }

        [Required]
        public decimal Duration { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Guid InstructorId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Thumbnail { get; set; }
    }
}
