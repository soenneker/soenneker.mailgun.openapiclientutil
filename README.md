[![](https://img.shields.io/nuget/v/soenneker.mailgun.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.mailgun.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.mailgun.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.mailgun.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.mailgun.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.mailgun.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.mailgun.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.mailgun.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Mailgun.OpenApiClientUtil

Provides a configured Mailgun API client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.Mailgun.OpenApiClientUtil
```

## Configuration

```json
{
  "Mailgun": {
    "ApiKey": "key-example"
  }
}
```

The underlying HTTP client applies Mailgun's required Basic authentication. `Mailgun:AuthHeaderName` can replace the `Authorization` header name, and `Mailgun:AuthHeaderValueTemplate` can replace its value; `{token}` is replaced with the configured API key.

## Usage

```csharp
using Soenneker.Mailgun.OpenApiClientUtil.Abstract;
using Soenneker.Mailgun.OpenApiClientUtil.Registrars;

services.AddMailgunOpenApiClientUtilAsSingleton();

IMailgunOpenApiClientUtil mailgun = serviceProvider
    .GetRequiredService<IMailgunOpenApiClientUtil>();

var client = await mailgun.Get(cancellationToken);
var routes = await client.V3.Routes.GetAsync(cancellationToken: cancellationToken);
```

Use `AddMailgunOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying HTTP provider remains shared and is disposed by the service container at shutdown.
