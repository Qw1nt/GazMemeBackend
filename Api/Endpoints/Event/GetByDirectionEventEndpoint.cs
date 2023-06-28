using Application.Common.Interfaces;
using Application.Messages.Event.Request;
using Contracts.Event;
using GazMeme.Endpoints.Event.Mapper;

namespace GazMeme.Endpoints.Event;

[HttpGet("event/direction/{DirectionId}")]
public class GetByDirectionEventEndpoint : Endpoint<GetByDirectionEventRequest, List<EventResponse>, EventMapper>
{
    private readonly IEventRepository _eventRepository;

    public GetByDirectionEventEndpoint(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public override async Task HandleAsync(GetByDirectionEventRequest req, CancellationToken ct)
    {
        var events = await _eventRepository.GetEventByDirectionAsync(req.DirectionId, ct);

        await SendAsync(events.Select(x => Map.FromEntity(x)).ToList(), cancellation: ct);
    }
}