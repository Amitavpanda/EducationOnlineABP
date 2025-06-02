using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.OnlineEducation.Data;

/* This is used if database provider does't define
 * IOnlineEducationDbSchemaMigrator implementation.
 */
public class NullOnlineEducationDbSchemaMigrator : IOnlineEducationDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
