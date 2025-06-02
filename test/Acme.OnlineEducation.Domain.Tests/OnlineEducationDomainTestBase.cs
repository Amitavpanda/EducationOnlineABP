using Volo.Abp.Modularity;

namespace Acme.OnlineEducation;

/* Inherit from this class for your domain layer tests. */
public abstract class OnlineEducationDomainTestBase<TStartupModule> : OnlineEducationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
