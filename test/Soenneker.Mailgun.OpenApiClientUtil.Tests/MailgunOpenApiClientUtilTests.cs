using Soenneker.Mailgun.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Mailgun.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class MailgunOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IMailgunOpenApiClientUtil _openapiclientutil;

    public MailgunOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IMailgunOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
