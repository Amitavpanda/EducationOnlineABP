using System;

namespace Acme.OnlineEducation.UserReviews;

public class UserReviewDto
{
    public int CourseId { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public int Rating { get; set; }
    public string Comments { get; set; }
    public DateTime? ReviewDate { get; set; }
}