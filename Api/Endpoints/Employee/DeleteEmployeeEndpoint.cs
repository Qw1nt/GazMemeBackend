using Application.Common.Interfaces;
using Application.Messages.Direction.Commands;

namespace GazMeme.Endpoints.Employee;

[HttpDelete("employee/{DeleteId}")]
public class DeleteEmployeeEndpoint : Endpoint<DeleteDirectionCommand>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeEndpoint(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public override async Task HandleAsync(DeleteDirectionCommand req, CancellationToken ct)
    {
        var operationResult = await _employeeRepository.DeleteAsync(req.DirectionId, cancellationToken: ct);
        
        if (operationResult)
            await SendAsync(true, cancellation: ct);
        else
            await SendErrorsAsync(cancellation: ct);
    }
}