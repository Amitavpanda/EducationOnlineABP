using Acme.OnlineEducation.Samples;
using Xunit;

namespace Acme.OnlineEducation.EntityFrameworkCore.Applications;

[Collection(OnlineEducationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<OnlineEducationEntityFrameworkCoreTestModule>
{

}
