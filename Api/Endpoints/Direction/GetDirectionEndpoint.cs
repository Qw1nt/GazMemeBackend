using Application.Common.Interfaces;
using Application.Messages.Direction.Queries;
using Application.Messages.Event.Request;
using Contracts.Direction;
using GazMeme.Endpoints.Direction.Mapper;
using Microsoft.AspNetCore.Authorization;

namespace GazMeme.Endpoints.Direction;

[HttpGet("direction/{Id}")]
[AllowAnonymous]
public class GetDirectionEndpoint : Endpoint<GetByIdDirectionQuery, DirectionResponse, DirectionMapper>
{
    private readonly IDirectionRepository _directionRepository;

    public GetDirectionEndpoint(IDirectionRepository directionRepository)
    {
        _directionRepository = directionRepository;
    }

    public override async Task HandleAsync(GetByIdDirectionQuery req , CancellationToken ct)
    {
        var direction = await _directionRepository.GetAsync(req.Id, ct);

        if (direction is null)
            await SendErrorsAsync(cancellation: ct);

        await SendAsync(Map.FromEntity(direction!), cancellation: ct);
    }
}