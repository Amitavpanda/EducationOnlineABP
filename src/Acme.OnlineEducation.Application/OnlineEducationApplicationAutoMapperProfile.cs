using Acme.OnlineEducation.CourseCategories;
using Acme.OnlineEducation.Courses;
using Acme.OnlineEducation.Enrollments;
using Acme.OnlineEducation.UserReviews;
using AutoMapper;

namespace Acme.OnlineEducation;

public class OnlineEducationApplicationAutoMapperProfile : Profile
{
    public OnlineEducationApplicationAutoMapperProfile()
    {
        CreateMap<CourseCategory, CourseCategoryDto>();
        CreateMap<CreateUpdateCourseCategoryDto, CourseCategory>();


        CreateMap<Course, CourseDto>();
        CreateMap<CreateUpdateCourseDto, Course>();
        CreateMap<Course, CourseDetailDto>();

        CreateMap<SessionDetail, SessionDetailDto>();
        CreateMap<CreateUpdateSessionDetailDto, SessionDetail>();

        //CreateMap<Enrollment, EnrollmentDto>();
        CreateMap<Instructor, InstructorDto>();

        CreateMap<Review, UserReviewDto>();
        CreateMap<CreateUpdateUserReviewDto, Review>();

        // Map Enrollment entity to CourseEnrollmentDto
        CreateMap<Enrollment, CourseEnrollmentDto>();

        // Map Payment entity to CoursePaymentDto
        CreateMap<Payment, CoursePaymentDto>();
        CreateMap<CreateUpdateEnrollmentDto, Enrollment>();

    }
}
