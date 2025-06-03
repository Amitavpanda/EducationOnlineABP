using Microsoft.Extensions.Localization;
using Acme.OnlineEducation.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.OnlineEducation;

[Dependency(ReplaceServices = true)]
public class OnlineEducationBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<OnlineEducationResource> _localizer;

    public OnlineEducationBrandingProvider(IStringLocalizer<OnlineEducationResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
