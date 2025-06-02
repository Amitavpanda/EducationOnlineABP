using Volo.Abp.Modularity;

namespace Acme.OnlineEducation;

[DependsOn(
    typeof(OnlineEducationDomainModule),
    typeof(OnlineEducationTestBaseModule)
)]
public class OnlineEducationDomainTestModule : AbpModule
{

}
