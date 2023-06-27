using Application.Common.Interfaces;

namespace GazMeme.Endpoints.Direction;

[HttpGet("direction/all")]
public class GetAllDirectionEndpoint : EndpointWithoutRequest<List<Domain.Entities.Direction>>
{
    private readonly IDirectionRepository _directionRepository;

    public GetAllDirectionEndpoint(IDirectionRepository directionRepository)
    {
        _directionRepository = directionRepository;
    }
    
    public override async Task HandleAsync(CancellationToken ct)
    {
        var directions = await _directionRepository.GetAllAsync(ct);

        await SendAsync(directions, cancellation: ct);
    }
}