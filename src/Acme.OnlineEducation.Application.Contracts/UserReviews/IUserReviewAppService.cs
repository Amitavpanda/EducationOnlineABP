using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.OnlineEducation.UserReviews
{
    public interface IUserReviewAppService :
        ICrudAppService<UserReviewDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateUserReviewDto>
    {
        Task<List<UserReviewDto>> GetReviewsByCourseIdAsync(Guid courseId);
        Task<List<UserReviewDto>> GetUserReviewsAsync(Guid userId);
    }
}
