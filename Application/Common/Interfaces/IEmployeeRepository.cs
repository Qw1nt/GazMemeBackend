using Application.Messages.Direction.Commands;
using Application.Messages.Employee.Commands;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IEmployeeRepository : IRepository<Employee, CreateEmployeeCommand>
{
    Task<List<Employee>> GetByEventAsync(int eventId, CancellationToken cancellationToken = default);

    Task<List<Employee>> GetAllOrganizersAsync(CancellationToken cancellationToken = default);
}