using System;
using Volo.Abp.Application.Dtos;

namespace Acme.OnlineEducation.UserReviews;

public class UserReviewDto : AuditedEntityDto<Guid>
{
    public Guid CourseId { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public int Rating { get; set; }
    public string Comments { get; set; }
    public DateTime? ReviewDate { get; set; }
}