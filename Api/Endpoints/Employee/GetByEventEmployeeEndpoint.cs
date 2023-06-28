using Application.Common.Interfaces;
using Application.Messages.Employee.Queries;
using Application.Messages.Event.Request;
using Microsoft.AspNetCore.Authorization;

namespace GazMeme.Endpoints.Employee;

[HttpGet("employee/event/{EventId}")]
[AllowAnonymous]
public class GetByEventEmployeeEndpoint : Endpoint<GetByEventEmployeeQuery, List<Domain.Entities.Employee>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetByEventEmployeeEndpoint(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public override async Task HandleAsync(GetByEventEmployeeQuery req, CancellationToken ct)
    {
        var employees = await _employeeRepository.GetByEventAsync(req.EventId, cancellationToken: ct);
        
        await SendAsync(employees, cancellation: ct);
    }
}