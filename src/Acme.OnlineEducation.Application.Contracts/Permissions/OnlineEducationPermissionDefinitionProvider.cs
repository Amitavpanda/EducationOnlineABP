using Acme.OnlineEducation.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Acme.OnlineEducation.Permissions;

public class OnlineEducationPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(OnlineEducationPermissions.GroupName);


        var courses = myGroup.AddPermission(OnlineEducationPermissions.Courses.Default, L("Permission:Courses"));
        courses.AddChild(OnlineEducationPermissions.Courses.Create, L("Permission:Courses.Create"));
        courses.AddChild(OnlineEducationPermissions.Courses.Edit, L("Permission:Courses.Edit"));
        courses.AddChild(OnlineEducationPermissions.Courses.Delete, L("Permission:Courses.Delete"));

        var categories = myGroup.AddPermission(OnlineEducationPermissions.Categories.Default, L("Permission:Categories"));
        categories.AddChild(OnlineEducationPermissions.Categories.Create, L("Permission:Categories.Create"));
        categories.AddChild(OnlineEducationPermissions.Categories.Edit, L("Permission:Categories.Edit"));
        categories.AddChild(OnlineEducationPermissions.Categories.Delete, L("Permission:Categories.Delete"));
     
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<OnlineEducationResource>(name);
    }
}
