using Application.Common.Interfaces;
using Application.Messages.Direction.Commands;
using Application.Messages.Direction.Request;

namespace GazMeme.Endpoints.Employee;

[HttpDelete("employee/event/{DeleteId}")]
public class GetByEventEmployeeEndpoint : Endpoint<GetByEventDirectionCommand>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetByEventEmployeeEndpoint(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public override async Task HandleAsync(GetByEventDirectionCommand req, CancellationToken ct)
    {
        var employees = await _employeeRepository.GetByEventAsync(req.EventId, cancellationToken: ct);
        
        await SendAsync(employees, cancellation: ct);
    }
}