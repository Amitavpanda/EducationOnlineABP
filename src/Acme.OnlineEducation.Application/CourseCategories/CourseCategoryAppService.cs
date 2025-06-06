using Acme.OnlineEducation.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.OnlineEducation.CourseCategories
{
    public class CourseCategoryAppService :
            CrudAppService<
                CourseCategory, // The entity
                CourseCategoryDto, // The DTO for the entity
                Guid, // Primary key type
                PagedAndSortedResultRequestDto, // Used for paging/sorting
                CreateUpdateCourseCategoryDto>, // DTO for creating/updating
            ICourseCategoryAppService
    {
        public CourseCategoryAppService(IRepository<CourseCategory, Guid> repository)
            : base(repository)
        {
            GetPolicyName = OnlineEducationPermissions.Categories.Default;
            GetListPolicyName = OnlineEducationPermissions.Categories.Default;
            CreatePolicyName = OnlineEducationPermissions.Categories.Create;
            UpdatePolicyName = OnlineEducationPermissions.Categories.Edit;
            DeletePolicyName = OnlineEducationPermissions.Categories.Delete;
        }
    }
}
