using Acme.OnlineEducation.CourseCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.OnlineEducation.Enrollments
{
    public interface IEnrollmentAppService :
        ICrudAppService<
        CourseEnrollmentDto, // Defines the DTO for the entity
        Guid, // Primary key type
        PagedAndSortedResultRequestDto, // Used for paging/sorting
        CreateUpdateEnrollmentDto>
    {
        Task<List<CourseEnrollmentDto>> GetUserEnrollmentsAsync(Guid userId);
    }
}
