using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Acme.OnlineEducation
{
    internal class OnlineEducationDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<CourseCategory, Guid> _courseCategoryRepository;
        private readonly IRepository<UserProfile, Guid> _userProfileRepository;
        private readonly IRepository<Course, Guid> _courseRepository;
        private readonly IRepository<Instructor, Guid> _instructorRepository;
        private readonly IRepository<Enrollment, Guid> _enrollmentRepository;
        private readonly IRepository<Payment, Guid> _paymentRepository;
        private readonly IRepository<Review, Guid> _reviewRepository;
        private readonly IRepository<SessionDetail, Guid> _sessionDetailRepository;

        public OnlineEducationDataSeeder(
            IRepository<CourseCategory, Guid> courseCategoryRepository,
            IRepository<UserProfile, Guid> userProfileRepository,
            IRepository<Course, Guid> courseRepository,
            IRepository<Instructor, Guid> instructorRepository,
            IRepository<Enrollment, Guid> enrollmentRepository,
            IRepository<Payment, Guid> paymentRepository,
            IRepository<Review, Guid> reviewRepository,
            IRepository<SessionDetail, Guid> sessionDetailRepository)
               

            
            
        {
            _courseCategoryRepository = courseCategoryRepository ?? throw new ArgumentNullException(nameof(courseCategoryRepository));
            _userProfileRepository = userProfileRepository ?? throw new ArgumentNullException(nameof(userProfileRepository));
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _instructorRepository = instructorRepository ?? throw new ArgumentNullException(nameof(instructorRepository));
            _enrollmentRepository = enrollmentRepository ?? throw new ArgumentNullException(nameof(enrollmentRepository));
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
            _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
            _sessionDetailRepository = sessionDetailRepository ?? throw new ArgumentNullException(nameof(sessionDetailRepository));
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _courseCategoryRepository.GetCountAsync() <= 0)
            {
                await _courseCategoryRepository.InsertAsync(
                    new CourseCategory { CategoryName = "Programming", Description = "Courses related to programming languages." },
                    autoSave: true
                );
                await _courseCategoryRepository.InsertAsync(
                    new CourseCategory { CategoryName = "Design", Description = "Courses related to graphic and UI/UX design." },
                    autoSave: true
                );
                await _courseCategoryRepository.InsertAsync(
                    new CourseCategory { CategoryName = "Business", Description = "Courses related to business and management." },
                    autoSave: true
                );
            }

            if (await _userProfileRepository.GetCountAsync() <= 0)
            {
                await _userProfileRepository.InsertAsync(new UserProfile
                {
                    DisplayName = "User1",
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@example.com",
                    AdObjId = Guid.NewGuid().ToString(),
                    ProfilePictureUrl = "https://example.com/user1.jpg"
                }, autoSave: true);

                await _userProfileRepository.InsertAsync(new UserProfile
                {
                    DisplayName = "User2",
                    FirstName = "Bob",
                    LastName = "Brown",
                    Email = "bob.brown@example.com",
                    AdObjId = Guid.NewGuid().ToString(),
                    ProfilePictureUrl = "https://example.com/user2.jpg"
                }, autoSave: true);
            }

            // Seed Instructors
            if (await _instructorRepository.GetCountAsync() <= 0)
            {
                var user1 = await _userProfileRepository.FirstOrDefaultAsync(u => u.Email == "alice.johnson@example.com");
                var user2 = await _userProfileRepository.FirstOrDefaultAsync(u => u.Email == "bob.brown@example.com");

                if (user1 != null)
                {
                    await _instructorRepository.InsertAsync(new Instructor
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "john.doe@example.com",
                        Bio = "Experienced software developer and instructor.",
                        UserId = user1.Id,
                    }, autoSave: true);
                }

                if (user2 != null)
                {
                    await _instructorRepository.InsertAsync(new Instructor
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        Email = "jane.smith@example.com",
                        Bio = "Data science expert with 10+ years of experience.",
                        UserId = user2.Id,
                    }, autoSave: true);
                }
            }

            // Seed Courses
            if (await _courseRepository.GetCountAsync() <= 0)
            {
                // Get categories by name
                var programmingCategory = await _courseCategoryRepository.FirstOrDefaultAsync(c => c.CategoryName == "Programming");
                var designCategory = await _courseCategoryRepository.FirstOrDefaultAsync(c => c.CategoryName == "Design");

                // Get instructors by email
                var johnInstructor = await _instructorRepository.FirstOrDefaultAsync(i => i.Email == "john.doe@example.com");
                var janeInstructor = await _instructorRepository.FirstOrDefaultAsync(i => i.Email == "jane.smith@example.com");
                if (programmingCategory != null && johnInstructor != null)
                {
                    await _courseRepository.InsertAsync(new Course
                    {
                        Title = "Introduction to C#",
                        Description = "Learn the basics of C# programming.",
                        Price = 49.99m,
                        CourseType = "Online",
                        SeatsAvailable = 50,
                        Duration = 10,
                        CategoryId = programmingCategory.Id,
                        InstructorId = johnInstructor.Id,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(1),
                        Thumbnail = "https://example.com/csharp.jpg"
                    }, autoSave: true);
                }


                if (designCategory != null && janeInstructor != null)
                {
                    await _courseRepository.InsertAsync(new Course
                    {
                        Title = "Machine Learning Basics",
                        Description = "An introduction to machine learning concepts.",
                        Price = 99.99m,
                        CourseType = "Online",
                        SeatsAvailable = 30,
                        Duration = 15,
                        CategoryId = designCategory.Id,
                        InstructorId = janeInstructor.Id,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(2),
                        Thumbnail = "https://example.com/ml.jpg"
                    }, autoSave: true);
                }
            }

            // Seed Enrollments
            if (await _enrollmentRepository.GetCountAsync() <= 0)
            {
                // Get users by email
                var alice = await _userProfileRepository.FirstOrDefaultAsync(u => u.Email == "alice.johnson@example.com");
                var bob = await _userProfileRepository.FirstOrDefaultAsync(u => u.Email == "bob.brown@example.com");

                // Get courses by title
                var csharpCourse = await _courseRepository.FirstOrDefaultAsync(c => c.Title == "Introduction to C#");
                var mlCourse = await _courseRepository.FirstOrDefaultAsync(c => c.Title == "Machine Learning Basics");

                if (alice != null && csharpCourse != null)
                {
                    await _enrollmentRepository.InsertAsync(new Enrollment
                    {
                        CourseId = csharpCourse.Id,
                        UserId = alice.Id,
                        EnrollmentDate = DateTime.Now,
                        PaymentStatus = "Paid"
                    }, autoSave: true);
                }

                if (bob != null && mlCourse != null)
                {
                    await _enrollmentRepository.InsertAsync(new Enrollment
                    {
                        CourseId = mlCourse.Id,
                        UserId = bob.Id,
                        EnrollmentDate = DateTime.Now,
                        PaymentStatus = "Pending"
                    }, autoSave: true);
                }
            }

            // Seed Payments
            if (await _paymentRepository.GetCountAsync() <= 0)
            {
                // Get Alice's enrollment for "Introduction to C#"
                var alice = await _userProfileRepository.FirstOrDefaultAsync(u => u.Email == "alice.johnson@example.com");
                var csharpCourse = await _courseRepository.FirstOrDefaultAsync(c => c.Title == "Introduction to C#");
                Enrollment aliceEnrollment = null;

                if (alice != null && csharpCourse != null)
                {
                    aliceEnrollment = await _enrollmentRepository.FirstOrDefaultAsync(e =>
                        e.UserId == alice.Id && e.CourseId == csharpCourse.Id);
                }

                if (aliceEnrollment != null)
                {
                    await _paymentRepository.InsertAsync(new Payment
                    {
                        EnrollmentId = aliceEnrollment.Id,
                        Amount = 49.99m,
                        PaymentDate = DateTime.Now,
                        PaymentMethod = "Credit Card",
                        PaymentStatus = "Completed"
                    }, autoSave: true);
                }
            }

            // Seed Reviews
            if (await _reviewRepository.GetCountAsync() <= 0)
            {
                // Get Alice and the C# course
                var alice = await _userProfileRepository.FirstOrDefaultAsync(u => u.Email == "alice.johnson@example.com");
                var csharpCourse = await _courseRepository.FirstOrDefaultAsync(c => c.Title == "Introduction to C#");

                if (alice != null && csharpCourse != null)
                {
                    await _reviewRepository.InsertAsync(new Review
                    {
                        CourseId = csharpCourse.Id,
                        UserId = alice.Id,
                        Rating = 5,
                        Comments = "Great course! Very informative.",
                        ReviewDate = DateTime.Now
                    }, autoSave: true);
                }
            }

            // Seed Session Details
            if (await _sessionDetailRepository.GetCountAsync() <= 0)
            {
                var csharpCourse = await _courseRepository.FirstOrDefaultAsync(c => c.Title == "Introduction to C#");

                if (csharpCourse != null)
                {
                    await _sessionDetailRepository.InsertAsync(new SessionDetail
                    {
                        CourseId = csharpCourse.Id,
                        Title = "Introduction to C# Basics",
                        Description = "Learn the basics of C# programming.",
                        VideoUrl = "https://www.youtube.com/watch?v=s50VT-kn1fE",
                        VideoOrder = 1
                    }, autoSave: true);
                }
            }
        }
    }
}
