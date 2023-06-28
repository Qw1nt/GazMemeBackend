using Application.Common.Interfaces;
using Application.Messages.Event.Commands;
using Contracts.Event;
using GazMeme.Common.Binders;
using GazMeme.Endpoints.Event.Mapper;

namespace GazMeme.Endpoints.Event;

public class CreateEventEndpoint : Endpoint<CreateEventCommand, EventResponse, EventMapper>
{
    private readonly IEventRepository _eventRepository;
    
    private readonly CreateEventBinder _createEventBinder;

    public CreateEventEndpoint(CreateEventBinder createEventBinder, IEventRepository eventRepository)
    {
        _createEventBinder = createEventBinder;
        _eventRepository = eventRepository;
    }

    public override void Configure()
    {
        AllowFormData();
        AllowFileUploads();
        RequestBinder(_createEventBinder);
        Post("event/create");
    }

    public override async Task HandleAsync(CreateEventCommand req, CancellationToken ct)
    {
        var createdEvent = await _eventRepository.AddAsync(HttpContext, req, ct);

        if (createdEvent is null)
            await SendErrorsAsync(cancellation: ct);
        
        await SendAsync(Map.FromEntity(createdEvent!), cancellation: ct);
    }
}