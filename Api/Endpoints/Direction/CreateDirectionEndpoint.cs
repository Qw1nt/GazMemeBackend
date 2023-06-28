using Application.Common.Interfaces;
using Application.Messages.Direction.Commands;

namespace GazMeme.Endpoints.Direction;

public class CreateDirectionEndpoint : Endpoint<CreateDirectionCommand, Domain.Entities.Direction>
{
    private readonly IDirectionRepository _directionRepository;

    public CreateDirectionEndpoint(IDirectionRepository directionRepository)
    {
        _directionRepository = directionRepository;
    }

    public override void Configure()
    {
        AllowFormData();
        AllowFileUploads();
        Post("direction/create");
    }
    
    public override async Task HandleAsync(CreateDirectionCommand req, CancellationToken ct)
    {
        var test = Files.Count;
        
        var createdDirection = await _directionRepository.AddAsync(HttpContext, req, ct);

        if (createdDirection is null)
            await SendErrorsAsync(cancellation: ct);
        
        await SendAsync(createdDirection!, cancellation: ct);
    }
}