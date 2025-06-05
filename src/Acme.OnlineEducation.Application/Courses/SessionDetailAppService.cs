using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.OnlineEducation.Courses
{
    public class SessionDetailAppService :
        CrudAppService<SessionDetail, SessionDetailDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateSessionDetailDto>,
        ISessionDetailAppService
    {
        private readonly IRepository<SessionDetail, Guid> _sessionDetailRepository;

        public SessionDetailAppService(IRepository<SessionDetail, Guid> sessionDetailRepository)
            : base(sessionDetailRepository)
        {
            _sessionDetailRepository = sessionDetailRepository;
        }

        // Custom method: Get session details by course ID
        public async Task<List<SessionDetailDto>> GetSessionDetailsByCourseIdAsync(Guid courseId)
        {
            // Fetch session details for the specified course ID
            var sessionDetails = await _sessionDetailRepository
                .GetListAsync(sd => sd.CourseId == courseId);

            // Map session details to DTOs
            return ObjectMapper.Map<List<SessionDetail>, List<SessionDetailDto>>(sessionDetails);
        }
    }
}
