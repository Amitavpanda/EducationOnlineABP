using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Acme.OnlineEducation
{
    public class SessionDetail : Entity<int>
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public int VideoOrder { get; set; }

        // Navigation property
        public Course Course { get; set; }
    }
}
