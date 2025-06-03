using Volo.Abp.Modularity;

namespace Acme.OnlineEducation;

public abstract class OnlineEducationApplicationTestBase<TStartupModule> : OnlineEducationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
