using Application.Messages.Event.Request;

namespace GazMeme.Endpoints.Event;

[HttpGet("event/{Id}")]
public class GetByIdEventEndpoint : EndpointWithoutRequest<GetByIdEventRequest>
{
    public override Task HandleAsync(CancellationToken ct)
    {
        return base.HandleAsync(ct);
    }
}