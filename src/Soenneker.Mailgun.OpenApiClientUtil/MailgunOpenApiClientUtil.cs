using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Mailgun.HttpClients.Abstract;
using Soenneker.Mailgun.OpenApiClientUtil.Abstract;
using Soenneker.Mailgun.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Mailgun.OpenApiClientUtil;

public sealed class MailgunOpenApiClientUtil : IMailgunOpenApiClientUtil
{
    private readonly AsyncSingleton<MailgunOpenApiClient> _client;

    public MailgunOpenApiClientUtil(IMailgunOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<MailgunOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new MailgunOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<MailgunOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
