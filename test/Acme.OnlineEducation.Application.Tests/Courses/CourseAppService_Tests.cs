using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;

namespace Acme.OnlineEducation.Courses
{
    public abstract class CourseAppService_Tests<TStartupModule> : OnlineEducationApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly ICourseAppService _courseAppService;

        protected CourseAppService_Tests()
        {
            _courseAppService = GetRequiredService<ICourseAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Courses()
        {
            // Act
            var result = await _courseAppService.GetListAsync(new PagedAndSortedResultRequestDto());

            // Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(c => c.Title == "Introduction to C#");


        }


        [Fact]
        public async Task Should_Create_A_Valid_Course()
        {
            var categoryRepository = GetRequiredService<IRepository<CourseCategory, Guid>>();
            var instructorRepository = GetRequiredService<IRepository<Instructor, Guid>>();

            // Query for the seeded category and instructor
            var programmingCategory = await categoryRepository.FirstOrDefaultAsync(c => c.CategoryName == "Programming");
            var johnInstructor = await instructorRepository.FirstOrDefaultAsync(i => i.Email == "john.doe@example.com");

            // Act
            var result = await _courseAppService.CreateAsync(
                new CreateUpdateCourseDto
                {
                    Title = "New test course 42",
                    Description = "Test description",
                    Price = 10,
                    CourseType = "Online",
                    SeatsAvailable = 20,
                    Duration = 5,
                    CategoryId = programmingCategory.Id, 
                    InstructorId = johnInstructor.Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(10),
                    Thumbnail = "https://example.com/test.jpg"
                }
            );

            // Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Title.ShouldBe("New test course 42");
        }


        [Fact]
        public async Task Should_Not_Create_A_Course_Without_Title()
        {
            var categoryRepository = GetRequiredService<IRepository<CourseCategory, Guid>>();
            var instructorRepository = GetRequiredService<IRepository<Instructor, Guid>>();

            // Query for the seeded category and instructor
            var programmingCategory = await categoryRepository.FirstOrDefaultAsync(c => c.CategoryName == "Programming");
            var johnInstructor = await instructorRepository.FirstOrDefaultAsync(i => i.Email == "john.doe@example.com");

            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {

                await _courseAppService.CreateAsync(
                    new CreateUpdateCourseDto
                    {
                        Title = "",
                        Description = "Test description",
                        Price = 10,
                        CourseType = "Online",
                        SeatsAvailable = 20,
                        Duration = 5,
                        CategoryId = programmingCategory.Id,
                        InstructorId = johnInstructor.Id,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(10),
                        Thumbnail = "https://example.com/test.jpg"
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "Title"));
        }
    }

}
