using Application.Common.Interfaces;
using Application.Common.Persistence;
using Application.Messages.Direction.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Services;

public class DirectionRepository : IDirectionRepository
{
    private readonly IApplicationDataContext _applicationDataContext;
    private readonly IFileSaveService _fileSaveService;

    public DirectionRepository(IApplicationDataContext applicationDataContext, IFileSaveService fileSaveService)
    {
        _applicationDataContext = applicationDataContext;
        _fileSaveService = fileSaveService;
    }
    
    public async Task<List<Direction>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _applicationDataContext.Direction
            .Include(direction => direction.Employee)
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Direction?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _applicationDataContext.Direction
            .Include(direction => direction.Employee)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<Direction?> AddAsync(HttpContext httpContext, CreateDirectionCommand model, CancellationToken cancellationToken = default)
    {
        var employee = await _applicationDataContext.Employee
            .FirstOrDefaultAsync(x => x.Id == model.EmployeeId, cancellationToken: cancellationToken);
        
        if (employee is null)
            return null;
        
        var direction = new Direction()
        {
            Title = model.Title,
            Description = model.Description,
            Employee = employee,
            ImageUrl = await _fileSaveService.SaveAsync(httpContext, model.Image, Constants.Paths.Directions),
            VideoUrl = await _fileSaveService.SaveAsync(httpContext, model.Video, Constants.Paths.Directions),
            ImageUrls = model.Images.Select(async x => 
                await _fileSaveService.SaveAsync(httpContext, x, Constants.Paths.Directions))
                .Select(x => x.Result)
                .ToList()
        };

        var entry = await _applicationDataContext.Direction.AddAsync(direction, cancellationToken);
        await _applicationDataContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public Task<Direction?> EditAsync(Direction model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var direction = await _applicationDataContext.Direction
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

        if (direction is null)
            return false;
            
        _applicationDataContext.Direction.Remove(direction);
        await _applicationDataContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}