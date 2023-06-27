using Application.Messages.Event.Commands;

namespace GazMeme.Endpoints.Event;

public class CreateEventEndpoint : Endpoint<CreateEventCommand, Domain.Entities.Event>
{
    public override void Configure()
    {
        AllowFormData();
        Post("event/create");
    }

    public override Task HandleAsync(CreateEventCommand req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}