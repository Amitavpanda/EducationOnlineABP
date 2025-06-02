using Acme.OnlineEducation.Localization;
using Volo.Abp.Application.Services;

namespace Acme.OnlineEducation;

/* Inherit your application services from this class.
 */
public abstract class OnlineEducationAppService : ApplicationService
{
    protected OnlineEducationAppService()
    {
        LocalizationResource = typeof(OnlineEducationResource);
    }
}
