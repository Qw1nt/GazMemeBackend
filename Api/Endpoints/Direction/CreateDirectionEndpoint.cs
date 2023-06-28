using Application.Common.Interfaces;
using Application.Messages.Direction.Commands;
using GazMeme.Common.Binders;

namespace GazMeme.Endpoints.Direction;

public class CreateDirectionEndpoint : Endpoint<CreateDirectionCommand, Domain.Entities.Direction>
{
    private readonly IDirectionRepository _directionRepository;

    private readonly CreateDirectionBinder _createDirectionBinder;

    public CreateDirectionEndpoint(IDirectionRepository directionRepository, CreateDirectionBinder createDirectionBinder)
    {
        _directionRepository = directionRepository;
        _createDirectionBinder = createDirectionBinder;
    }

    public override void Configure()
    {
        AllowFormData();
        AllowFileUploads();
        RequestBinder(_createDirectionBinder);
        Post("direction/create");
    }
    
    public override async Task HandleAsync(CreateDirectionCommand req, CancellationToken ct)
    {
        var createdDirection = await _directionRepository.AddAsync(HttpContext, req, ct);

        if (createdDirection is null)
            await SendErrorsAsync(cancellation: ct);
        
        await SendAsync(createdDirection!, cancellation: ct);
    }
}