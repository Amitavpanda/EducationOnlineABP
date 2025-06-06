using Acme.OnlineEducation.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Acme.OnlineEducation.EntityFrameworkCore.Applications.Courses
{
    [Collection(OnlineEducationTestConsts.CollectionDefinitionName)]
    public class EfCoreCourseAppService_Tests : CourseAppService_Tests<OnlineEducationEntityFrameworkCoreTestModule>
    {
    }
}
