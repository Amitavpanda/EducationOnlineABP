using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.OnlineEducation.CourseCategories
{
    public interface ICourseCategoryAppService : ICrudAppService<
        CourseCategoryDto, // Defines the DTO for the entity
        int, // Primary key type
        PagedAndSortedResultRequestDto, // Used for paging/sorting
        CreateUpdateCourseCategoryDto>
    {
      
    }
}
