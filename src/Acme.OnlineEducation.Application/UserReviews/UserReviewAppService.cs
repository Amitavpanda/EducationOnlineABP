using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.OnlineEducation.UserReviews
{
    public class UserReviewAppService :
        CrudAppService<Review, UserReviewDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateUserReviewDto>,
        IUserReviewAppService
    {
        private readonly IRepository<Review, Guid> _userReviewRepository;

        public UserReviewAppService(IRepository<Review, Guid> userReviewRepository)
            : base(userReviewRepository)
        {
            _userReviewRepository = userReviewRepository;
        }

        // Custom method: Get reviews by course ID
        public async Task<List<UserReviewDto>> GetReviewsByCourseIdAsync(Guid courseId)
        {
            // Fetch reviews for the specified course ID
            var reviews = await _userReviewRepository
                .GetListAsync(r => r.CourseId == courseId);

            // Map reviews to DTOs
            return ObjectMapper.Map<List<Review>, List<UserReviewDto>>(reviews);
        }

        // Custom method: Get reviews by user ID
        public async Task<List<UserReviewDto>> GetUserReviewsAsync(Guid userId)
        {
            // Fetch reviews for the specified user ID
            var reviews = await _userReviewRepository
                .GetListAsync(r => r.UserId == userId);

            // Map reviews to DTOs
            return ObjectMapper.Map<List<Review>, List<UserReviewDto>>(reviews);
        }
    }
}
