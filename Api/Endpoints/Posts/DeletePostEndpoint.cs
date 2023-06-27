using Application.Common.Interfaces;
using Application.Messages.Posts.Commands;

namespace GazMeme.Endpoints.Posts;

[HttpDelete("api/posts{PostId}")]
public class DeletePostEndpoint : Endpoint<DeletePostCommand>
{
    private readonly IPostRepository _postRepository;

    public DeletePostEndpoint(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public override async Task HandleAsync(DeletePostCommand req, CancellationToken ct)
    {
        var operationResult = await _postRepository.DeleteAsync(req.PostId, cancellationToken: ct);
        if (operationResult == true)
            await SendAsync(true, cancellation: ct);
        else
            await SendErrorsAsync(cancellation: ct);
    }
}