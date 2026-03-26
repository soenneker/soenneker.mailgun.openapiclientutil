using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Mailgun.HttpClients.Abstract;
using Soenneker.Mailgun.OpenApiClientUtil.Abstract;
using Soenneker.Mailgun.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Mailgun.OpenApiClientUtil;

///<inheritdoc cref="IMailgunOpenApiClientUtil"/>
public sealed class MailgunOpenApiClientUtil : IMailgunOpenApiClientUtil
{
    private readonly AsyncSingleton<MailgunOpenApiClient> _client;

    public MailgunOpenApiClientUtil(IMailgunOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<MailgunOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Mailgun:ApiKey");
            string authHeaderValueTemplate = configuration["Mailgun:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
