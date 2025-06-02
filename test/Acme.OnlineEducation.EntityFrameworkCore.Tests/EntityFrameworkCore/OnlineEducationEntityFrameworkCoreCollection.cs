using Xunit;

namespace Acme.OnlineEducation.EntityFrameworkCore;

[CollectionDefinition(OnlineEducationTestConsts.CollectionDefinitionName)]
public class OnlineEducationEntityFrameworkCoreCollection : ICollectionFixture<OnlineEducationEntityFrameworkCoreFixture>
{

}
