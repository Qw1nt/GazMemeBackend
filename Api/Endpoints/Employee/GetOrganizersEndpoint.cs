using Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace GazMeme.Endpoints.Employee;

[HttpGet("employee/organizers")]
[AllowAnonymous]
public class GetAllOrganizersEndpoint : EndpointWithoutRequest<List<Domain.Entities.Employee>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllOrganizersEndpoint(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var employees = await _employeeRepository.GetAllOrganizersAsync(ct);

        await SendAsync(employees, cancellation: ct);
    }
}