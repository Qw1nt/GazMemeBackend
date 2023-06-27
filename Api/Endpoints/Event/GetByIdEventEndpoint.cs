using Application.Messages.Event.Request;

namespace GazMeme.Endpoints.Event;

[HttpGet("event/direction/{Id}")]
public class GetByIdEventEndpoint : EndpointWithoutRequest<GetByIdEventRequest>
{
    
}