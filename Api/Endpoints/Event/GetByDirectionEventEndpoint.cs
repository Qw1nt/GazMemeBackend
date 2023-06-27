using Application.Messages.Event.Request;

namespace GazMeme.Endpoints.Event;

[HttpGet("event/direction/{DirectionId}")]
public class GetByDirectionEventEndpoint : EndpointWithoutRequest<GetByDirectionEventRequest>
{
    public override Task HandleAsync(CancellationToken ct)
    {
        return base.HandleAsync(ct);
    }
}