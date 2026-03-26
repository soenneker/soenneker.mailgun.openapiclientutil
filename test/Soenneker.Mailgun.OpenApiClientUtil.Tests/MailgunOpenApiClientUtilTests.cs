using Soenneker.Mailgun.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Mailgun.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class MailgunOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IMailgunOpenApiClientUtil _openapiclientutil;

    public MailgunOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IMailgunOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
