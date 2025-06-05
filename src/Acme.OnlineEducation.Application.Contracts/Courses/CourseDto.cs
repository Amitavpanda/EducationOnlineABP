using Acme.OnlineEducation.CourseCategories;
using System;
using Volo.Abp.Application.Dtos;

namespace Acme.OnlineEducation.Courses;

public class CourseDto : AuditedEntityDto<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string CourseType { get; set; }
    public int? SeatsAvailable { get; set; }
    public decimal Duration { get; set; }
    public Guid CategoryId { get; set; }
    public Guid InstructorId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Thumbnail { get; set; }
    public Guid InstructorUserId { get; set; }
    public CourseCategoryDto Category { get; set; }
    public UserRatingDto UserRating { get; set; }
}