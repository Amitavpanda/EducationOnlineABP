using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.OnlineEducation.UserReviews
{
    public class CreateUpdateUserReviewDto
    {
        [Required]
        public Guid CourseId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }


        public string Comments { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }
    }
}
