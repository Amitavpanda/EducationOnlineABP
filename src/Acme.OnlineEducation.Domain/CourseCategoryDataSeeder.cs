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
    internal class CourseCategoryDataSeeder : IDataSeedContributor, ITransientDependency
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
        }

        private readonly IRepository<CourseCategory, int> _courseCategoryRepository;
        public CourseCategoryDataSeeder(IRepository<CourseCategory, int> courseCategoryRepository)
        {
            _courseCategoryRepository = courseCategoryRepository;
        }


    }
}
