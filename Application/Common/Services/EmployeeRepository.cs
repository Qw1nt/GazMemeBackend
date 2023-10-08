using Application.Common.Interfaces;
using Application.Common.Persistence;
using Application.Messages.Employee.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Services;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IApplicationDataContext _applicationDataContext;
    private readonly IFileSaveService _fileSaveService;

    public EmployeeRepository(IApplicationDataContext applicationDataContext, IFileSaveService fileSaveService)
    {
        _applicationDataContext = applicationDataContext;
        _fileSaveService = fileSaveService;
    }
    
    public async Task<List<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _applicationDataContext.Employee
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }
    
    public async Task<List<Employee>> GetAllOrganizersAsync(CancellationToken cancellationToken = default)
    {
        return await _applicationDataContext.Employee
            .Where(x => x.Direction != null)
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }
    
    public async Task<List<Employee>> GetByEventAsync(int eventId, CancellationToken cancellationToken = default)
    {
        return await _applicationDataContext.Employee
            .AsNoTracking()
            .Where(x => x.Events.Any(x => x.Id == eventId))
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Employee?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _applicationDataContext.Employee
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<Employee?> AddAsync(HttpContext httpContext, CreateEmployeeCommand model, CancellationToken cancellationToken = default)
    {
        var employee = new Employee()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Surname = model.Surname,
            Phone = model.Phone,
            Email = model.Email,
            PhotoUrl = await _fileSaveService.SaveAsync(httpContext, model.Photo, Constants.Paths.Employees)
        };

        var entry = await _applicationDataContext.Employee.AddAsync(employee, cancellationToken);
        await _applicationDataContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public async Task<Employee?> EditAsync(Employee model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var employee = await _applicationDataContext.Employee
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

        if (employee is null)
            return false;
            
        _applicationDataContext.Employee.Remove(employee);
        await _applicationDataContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}