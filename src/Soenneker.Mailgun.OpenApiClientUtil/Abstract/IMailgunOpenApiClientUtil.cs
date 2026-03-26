using Soenneker.Mailgun.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Mailgun.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IMailgunOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<MailgunOpenApiClient> Get(CancellationToken cancellationToken = default);
}
