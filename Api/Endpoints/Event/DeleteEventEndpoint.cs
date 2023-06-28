using Application.Common.Interfaces;
using Application.Messages.Event.Commands;

namespace GazMeme.Endpoints.Event;

[HttpDelete("event/{DeleteId}")]
public class DeleteEventEndpoint : Endpoint<DeleteEventCommand>
{
    private readonly IEventRepository _eventRepository;

    public DeleteEventEndpoint(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public override async Task HandleAsync(DeleteEventCommand req, CancellationToken ct)
    {
        var operationResult = await _eventRepository.DeleteAsync(req.EventId, ct);

        if (operationResult)
            await SendAsync(true ,cancellation: ct);
        else
            await SendErrorsAsync(cancellation: ct);
    }
}