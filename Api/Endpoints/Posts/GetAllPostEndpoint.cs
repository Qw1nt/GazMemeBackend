using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GazMeme.Endpoints.Posts;

[HttpGet("posts/all")]
[AllowAnonymous]
public class GetAllPostEndpoint : EndpointWithoutRequest<List<Post>>
{
    private readonly IApplicationDataContext _applicationDataContext;

    public GetAllPostEndpoint(IApplicationDataContext applicationDataContext)
    {
        _applicationDataContext = applicationDataContext;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var posts = await _applicationDataContext.Posts
            .AsNoTracking()
            .ToListAsync(cancellationToken: ct);

        await SendAsync(posts, cancellation: ct);
    }
}