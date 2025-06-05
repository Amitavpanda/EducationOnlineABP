using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.OnlineEducation.Courses
{
    public interface ICourseAppService :

        ICrudAppService< //Defines CRUD methods
        CourseDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCourseDto> //Used to create/update a book
    {

        Task<CourseDetailDto> GetCourseDetailAsync(Guid courseId);
        Task<List<CourseDto>> GetAllCoursesAsync(Guid? categoryId = null);
        Task UpdateCourseThumbnailAsync(string courseThumbnailUrl, Guid courseId);
        Task<List<InstructorDto>> GetAllInstructorsAsync();
    }
}
