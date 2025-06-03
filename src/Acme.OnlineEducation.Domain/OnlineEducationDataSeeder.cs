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
            
            // Seed Instructors
            if (await _instructorRepository.GetCountAsync() <= 0)
            {
                await _instructorRepository.InsertAsync(new Instructor
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Bio = "Experienced software developer and instructor.",
                    UserId = 1
                }, autoSave: true);

                await _instructorRepository.InsertAsync(new Instructor
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    Bio = "Data science expert with 10+ years of experience.",
                    UserId = 2
                }, autoSave: true);
            }
            
            // Seed User Profiles
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
            
            
            // Seed Courses
            if (await _courseRepository.GetCountAsync() <= 0)
            {
                await _courseRepository.InsertAsync(new Course
                {
                    Title = "Introduction to C#",
                    Description = "Learn the basics of C# programming.",
                    Price = 49.99m,
                    CourseType = "Online",
                    SeatsAvailable = 50,
                    Duration = 10,
                    CategoryId = 1, // Programming
                    InstructorId = 1, // John Doe
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1),
                    Thumbnail = "https://example.com/csharp.jpg"
                }, autoSave: true);

                await _courseRepository.InsertAsync(new Course
                {
                    Title = "Machine Learning Basics",
                    Description = "An introduction to machine learning concepts.",
                    Price = 99.99m,
                    CourseType = "Online",
                    SeatsAvailable = 30,
                    Duration = 15,
                    CategoryId = 2, // Data Science
                    InstructorId = 2, // Jane Smith
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(2),
                    Thumbnail = "https://example.com/ml.jpg"
                }, autoSave: true);
            }
            
            
            
            // Seed Enrollments
            if (await _enrollmentRepository.GetCountAsync() <= 0)
            {
                await _enrollmentRepository.InsertAsync(new Enrollment
                {
                    CourseId = 1, // Introduction to C#
                    UserId = 1, // Alice Johnson
                    EnrollmentDate = DateTime.Now,
                    PaymentStatus = "Paid"
                }, autoSave: true);

                await _enrollmentRepository.InsertAsync(new Enrollment
                {
                    CourseId = 2, // Machine Learning Basics
                    UserId = 2, // Bob Brown
                    EnrollmentDate = DateTime.Now,
                    PaymentStatus = "Pending"
                }, autoSave: true);
            }

            // Seed Payments
            if (await _paymentRepository.GetCountAsync() <= 0)
            {
                await _paymentRepository.InsertAsync(new Payment
                {
                    EnrollmentId = 1, // Alice's enrollment
                    Amount = 49.99m,
                    PaymentDate = DateTime.Now,
                    PaymentMethod = "Credit Card",
                    PaymentStatus = "Completed"
                }, autoSave: true);
            }
            
            // Seed Reviews
            if (await _reviewRepository.GetCountAsync() <= 0)
            {
                await _reviewRepository.InsertAsync(new Review
                {
                    CourseId = 1, // Introduction to C#
                    UserId = 1, // Alice Johnson
                    Rating = 5,
                    Comments = "Great course! Very informative.",
                    ReviewDate = DateTime.Now
                }, autoSave: true);
            }
            
            // Seed Session Details
            if (await _sessionDetailRepository.GetCountAsync() <= 0)
            {
                await _sessionDetailRepository.InsertAsync(new SessionDetail
                {
                    CourseId = 1, // Introduction to C#
                    Title = "Introduction to C# Basics",
                    Description = "Learn the basics of C# programming.",
                    VideoUrl = "https://example.com/csharp-session1.mp4",
                    VideoOrder = 1
                }, autoSave: true);
            }
        }

        private readonly IRepository<CourseCategory, int> _courseCategoryRepository;
        private readonly IRepository<Instructor, int> _instructorRepository;
        private readonly IRepository<UserProfile, int> _userProfileRepository;
        private readonly IRepository<Course, int> _courseRepository;
        private readonly IRepository<Enrollment, int> _enrollmentRepository;
        private readonly IRepository<Payment, int> _paymentRepository;
        private readonly IRepository<Review, int> _reviewRepository;
        private readonly IRepository<SessionDetail, int> _sessionDetailRepository;
        public OnlineEducationDataSeeder(IRepository<CourseCategory, int> courseCategoryRepository, IRepository<Instructor, int> instructorRepository,
            IRepository<UserProfile, int> userProfileRepository,
            IRepository<Course, int> courseRepository,
            IRepository<Enrollment, int> enrollmentRepository,
            IRepository<Payment, int> paymentRepository,
            IRepository<Review, int> reviewRepository,
            IRepository<SessionDetail, int> sessionDetailRepository)
        {
            _courseCategoryRepository = courseCategoryRepository;
            _instructorRepository = instructorRepository;
            _userProfileRepository = userProfileRepository;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
            _paymentRepository = paymentRepository;
            _reviewRepository = reviewRepository;
            _sessionDetailRepository = sessionDetailRepository;
        }


    }
}
