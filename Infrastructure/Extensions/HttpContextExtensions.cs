using Microsoft.AspNetCore.Http;

namespace Infrastructure.Extensions;

public static class HttpContextExtensions
{
    public static string? BaseUrl(this HttpRequest req)
    {
        var uriBuilder = new UriBuilder(req.Scheme, req.Host.Host, req.Host.Port ?? -1);

        if (uriBuilder.Uri.IsDefaultPort)
            uriBuilder.Port = -1;

        return uriBuilder.Uri.AbsoluteUri;
    }
}