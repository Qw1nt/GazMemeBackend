using Application.Common.Interfaces;
using Application.Messages.Posts.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GazMeme.Endpoints.Posts;

public class CreatePost : Endpoint<CreatePostCommand, Post>
{
    private readonly IPostRepository _postRepository;

    public CreatePost(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public override void Configure()
    {
        AllowFormData();
        Post("api/posts/create");
    }

    public override async Task HandleAsync(CreatePostCommand req, CancellationToken ct)
    {
        var createdPost = await _postRepository.AddAsync(HttpContext, req, ct);

        if (createdPost is null)
            await SendErrorsAsync(cancellation: ct);
        
        await SendAsync(createdPost!, cancellation: ct);
    }
}