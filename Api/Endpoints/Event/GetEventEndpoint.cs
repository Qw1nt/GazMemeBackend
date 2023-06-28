using Application.Common.Interfaces;
using Application.Messages.Event.Request;
using Contracts.Event;
using GazMeme.Endpoints.Event.Mapper;

namespace GazMeme.Endpoints.Event;

[HttpGet("event/{Id}")]
public class GetEventEndpoint : Endpoint<GetByIdEventRequest, EventResponse, EventMapper>
{
    private readonly IEventRepository _eventRepository;

    public GetEventEndpoint(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public override async Task HandleAsync(GetByIdEventRequest req , CancellationToken ct)
    {
        var requestedEvent = await _eventRepository.GetAsync(req.Id, ct);

        if (requestedEvent is null)
            await SendErrorsAsync(cancellation: ct);

        await SendAsync(Map.FromEntity(requestedEvent!)!, cancellation: ct);
    }
}