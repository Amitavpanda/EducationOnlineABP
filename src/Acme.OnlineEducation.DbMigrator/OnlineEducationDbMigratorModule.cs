using Acme.OnlineEducation.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.OnlineEducation.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(OnlineEducationEntityFrameworkCoreModule),
    typeof(OnlineEducationApplicationContractsModule)
)]
public class OnlineEducationDbMigratorModule : AbpModule
{
}
