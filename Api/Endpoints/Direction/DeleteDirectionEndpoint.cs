using Application.Common.Interfaces;
using Application.Messages.Direction.Commands;

namespace GazMeme.Endpoints.Direction;

[HttpDelete("posts/{DeleteId}")]
public class DeleteDirectionEndpoint : Endpoint<DeleteDirectionCommand>
{
    private readonly IDirectionRepository _directionRepository;

    public DeleteDirectionEndpoint(IDirectionRepository directionRepository)
    {
        _directionRepository = directionRepository;
    }
    
    public override async Task HandleAsync(DeleteDirectionCommand req, CancellationToken ct)
    {
        var operationResult = await _directionRepository.DeleteAsync(req.DirectionId, cancellationToken: ct);
        
        if (operationResult)
            await SendAsync(true, cancellation: ct);
        else
            await SendErrorsAsync(cancellation: ct);
    }
}