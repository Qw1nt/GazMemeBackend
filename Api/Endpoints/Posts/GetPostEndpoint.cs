using Application.Common.Interfaces;
using Application.Messages.Posts.Request;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace GazMeme.Endpoints.Posts;

[HttpGet("posts/{Id}")]
[AllowAnonymous]
public class GetPostEndpoint : Endpoint<GetByIdPostRequest, Post>
{
    private readonly IPostRepository _postRepository;

    public GetPostEndpoint(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public override async Task HandleAsync(GetByIdPostRequest req, CancellationToken ct)
    {
        var post = await _postRepository.GetAsync(req.Id, ct);

        if (post is null)
            await SendErrorsAsync(cancellation: ct);
        else
            await SendAsync(post, cancellation: ct);
    }
}