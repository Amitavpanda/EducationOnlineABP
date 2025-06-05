using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.OnlineEducation.Courses
{
    public interface ISessionDetailAppService :
        ICrudAppService<SessionDetailDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSessionDetailDto>
    {
        Task<List<SessionDetailDto>> GetSessionDetailsByCourseIdAsync(Guid courseId);
    }
}
