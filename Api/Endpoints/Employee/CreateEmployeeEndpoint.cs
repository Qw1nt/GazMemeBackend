using Application.Common.Interfaces;
using Application.Messages.Employee.Commands;

namespace GazMeme.Endpoints.Employee;

public class CreateEmployeeEndpoint : Endpoint<CreateEmployeeCommand, Domain.Entities.Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public CreateEmployeeEndpoint(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public override void Configure()
    {
        AllowFormData();
        Post("employee/create");
    }
    
    public override async Task HandleAsync(CreateEmployeeCommand req, CancellationToken ct)
    {
        var createdDirection = await _employeeRepository.AddAsync(HttpContext, req, ct);

        if (createdDirection is null)
            await SendErrorsAsync(cancellation: ct);
        
        await SendAsync(createdDirection!, cancellation: ct);
    }
}