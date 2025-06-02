using Acme.OnlineEducation.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.OnlineEducation.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class OnlineEducationController : AbpControllerBase
{
    protected OnlineEducationController()
    {
        LocalizationResource = typeof(OnlineEducationResource);
    }
}
