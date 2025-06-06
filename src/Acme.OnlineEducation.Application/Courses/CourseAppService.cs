using Acme.OnlineEducation.UserReviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Acme.OnlineEducation.Permissions;


namespace Acme.OnlineEducation.Courses
{
    public class CourseAppService :
        CrudAppService< 
        Course,
        CourseDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateCourseDto>, 
        ICourseAppService 
    {



        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly IRepository<Instructor, Guid> _instructorRepository;
        private readonly IRepository<SessionDetail, Guid> _sessionDetailRepository;
        private readonly IRepository<Review, Guid> _userReviewRepository;

        public CourseAppService(
          IRepository<Course, Guid> courseRepository,
        IRepository<Instructor, Guid> instructorRepository,
        IRepository<SessionDetail, Guid> sessionDetailRepository,
        IRepository<Review, Guid> userReviewRepository)
            : base(courseRepository)
        {
            _courseRepository = courseRepository;
            _instructorRepository = instructorRepository;
            _sessionDetailRepository = sessionDetailRepository;
            _userReviewRepository = userReviewRepository;


            GetPolicyName = OnlineEducationPermissions.Courses.Default;
            GetListPolicyName = OnlineEducationPermissions.Courses.Default;
            CreatePolicyName = OnlineEducationPermissions.Courses.Create;
            UpdatePolicyName = OnlineEducationPermissions.Courses.Edit;
            DeletePolicyName = OnlineEducationPermissions.Courses.Delete;
        }

        // Get detailed course information (including reviews, session details, and user ratings)
        public async Task<CourseDetailDto> GetCourseDetailAsync(Guid courseId)
        {
            var course = await _courseRepository.GetAsync(courseId);

            var courseDetail = ObjectMapper.Map<Course, CourseDetailDto>(course);

            // Include reviews
            var reviews = await _userReviewRepository.GetListAsync(r => r.CourseId == courseId);
            courseDetail.Reviews = ObjectMapper.Map<List<Review>, List<UserReviewDto>>(reviews);

            // Include session details
            var sessionDetails = await _sessionDetailRepository.GetListAsync(sd => sd.CourseId == courseId);
            courseDetail.SessionDetails = ObjectMapper.Map<List<SessionDetail>, List<SessionDetailDto>>(sessionDetails);

            // Calculate user rating
            courseDetail.UserRating = new UserRatingDto
            {
                CourseId = courseId,
                AverageRating = reviews.Any() ? Convert.ToDecimal(reviews.Average(r => r.Rating)) : 0,
                TotalRating = reviews.Count
            };

            return courseDetail;
        }



        // Additional method: Get all courses (optionally filtered by categoryId)
        public async Task<List<CourseDto>> GetAllCoursesAsync(Guid? categoryId = null)
        {
            var query = await _courseRepository.GetQueryableAsync();

            if (categoryId.HasValue)
            {
                query = query.Where(c => c.CategoryId == categoryId.Value);
            }

            var courses = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<Course>, List<CourseDto>>(courses);
        }

        // Additional method: Update course thumbnail
        public async Task UpdateCourseThumbnailAsync(string courseThumbnailUrl, Guid courseId)
        {
            var course = await _courseRepository.GetAsync(courseId);
            course.Thumbnail = courseThumbnailUrl;
            await _courseRepository.UpdateAsync(course);
        }

        // Additional method: Get all instructors
        public async Task<List<InstructorDto>> GetAllInstructorsAsync()
        {
            var instructors = await _instructorRepository.GetListAsync();
            return ObjectMapper.Map<List<Instructor>, List<InstructorDto>>(instructors);
        }
    }
}
