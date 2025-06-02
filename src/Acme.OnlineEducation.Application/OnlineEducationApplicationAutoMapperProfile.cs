using Acme.OnlineEducation.CourseCategories;
using AutoMapper;

namespace Acme.OnlineEducation;

public class OnlineEducationApplicationAutoMapperProfile : Profile
{
    public OnlineEducationApplicationAutoMapperProfile()
    {
        CreateMap<CourseCategory, CourseCategoryDto>();
        CreateMap<CreateUpdateCourseCategoryDto, CourseCategory>();

    }
}
