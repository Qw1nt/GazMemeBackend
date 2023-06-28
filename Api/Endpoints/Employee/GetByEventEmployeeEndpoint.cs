using Application.Common.Interfaces;
using Application.Messages.Event.Request;
using Microsoft.AspNetCore.Authorization;

namespace GazMeme.Endpoints.Employee;

[HttpGet("employee/event/{DeleteId}")]
[AllowAnonymous]
public class GetByEventEmployeeEndpoint : Endpoint<GetByDirectionEventRequest>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetByEventEmployeeEndpoint(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public override async Task HandleAsync(GetByDirectionEventRequest req, CancellationToken ct)
    {
        var employees = await _employeeRepository.GetByEventAsync(req.DirectionId, cancellationToken: ct);
        
        await SendAsync(employees, cancellation: ct);
    }
}