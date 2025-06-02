using System.Threading.Tasks;

namespace Acme.OnlineEducation.Data;

public interface IOnlineEducationDbSchemaMigrator
{
    Task MigrateAsync();
}
