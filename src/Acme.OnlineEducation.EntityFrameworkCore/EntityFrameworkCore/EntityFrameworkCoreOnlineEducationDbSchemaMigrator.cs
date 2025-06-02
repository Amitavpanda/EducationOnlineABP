using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.OnlineEducation.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.OnlineEducation.EntityFrameworkCore;

public class EntityFrameworkCoreOnlineEducationDbSchemaMigrator
    : IOnlineEducationDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreOnlineEducationDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the OnlineEducationDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<OnlineEducationDbContext>()
            .Database
            .MigrateAsync();
    }
}
