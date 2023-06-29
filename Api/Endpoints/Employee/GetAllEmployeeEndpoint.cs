using Application.Common.Interfaces;

namespace GazMeme.Endpoints.Employee;

[HttpGet("employee/all")]
public class GetAllEmployeeEndpoint : EndpointWithoutRequest<List<Domain.Entities.Employee>>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeeEndpoint(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var employees = await _employeeRepository.GetAllAsync(ct);

        await SendAsync(employees, cancellation: ct);
    }
}