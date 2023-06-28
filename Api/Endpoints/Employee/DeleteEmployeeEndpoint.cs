using Application.Common.Interfaces;
using Application.Messages.Direction.Commands;
using Application.Messages.Employee.Commands;

namespace GazMeme.Endpoints.Employee;

[HttpDelete("employee/{EmployeeId}")]
public class DeleteEmployeeEndpoint : Endpoint<DeleteEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeEndpoint(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public override async Task HandleAsync(DeleteEmployeeCommand req, CancellationToken ct)
    {
        var operationResult = await _employeeRepository.DeleteAsync(req.EmployeeId, cancellationToken: ct);
        
        if (operationResult)
            await SendAsync(true, cancellation: ct);
        else
            await SendErrorsAsync(cancellation: ct);
    }
}