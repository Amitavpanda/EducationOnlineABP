using Volo.Abp.Modularity;

namespace Acme.OnlineEducation;

[DependsOn(
    typeof(OnlineEducationApplicationModule),
    typeof(OnlineEducationDomainTestModule)
)]
public class OnlineEducationApplicationTestModule : AbpModule
{

}
