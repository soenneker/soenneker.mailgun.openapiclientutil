using Soenneker.Mailgun.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Mailgun.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Mailgun OpenAPI client that uses the configured Mailgun HTTP client.
/// </summary>
public interface IMailgunOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Mailgun client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<MailgunOpenApiClient> Get(CancellationToken cancellationToken = default);
}
