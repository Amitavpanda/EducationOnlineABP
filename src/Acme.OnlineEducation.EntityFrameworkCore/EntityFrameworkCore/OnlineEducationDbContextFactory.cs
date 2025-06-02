using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Acme.OnlineEducation.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class OnlineEducationDbContextFactory : IDesignTimeDbContextFactory<OnlineEducationDbContext>
{
    public OnlineEducationDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        OnlineEducationEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<OnlineEducationDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new OnlineEducationDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Acme.OnlineEducation.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
