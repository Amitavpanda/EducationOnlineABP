using Acme.OnlineEducation.Samples;
using Xunit;

namespace Acme.OnlineEducation.EntityFrameworkCore.Domains;

[Collection(OnlineEducationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<OnlineEducationEntityFrameworkCoreTestModule>
{

}
