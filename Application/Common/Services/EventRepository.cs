using Application.Common.Interfaces;
using Application.Common.Persistence;
using Application.Messages.Event.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Services;

public class EventRepository : IEventRepository
{
    private readonly IApplicationDataContext _applicationDataContext;
    private readonly IFileSaveService _fileSaveService;

    public EventRepository(IApplicationDataContext applicationDataContext, IFileSaveService fileSaveService)
    {
        _applicationDataContext = applicationDataContext;
        _fileSaveService = fileSaveService;
    }
    
    public async Task<List<Event>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _applicationDataContext.Event
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Event?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _applicationDataContext.Event
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<Event?> AddAsync(HttpContext httpContext, CreateEventCommand model, CancellationToken cancellationToken = default)
    {
        var direction = await _applicationDataContext.Direction
            .FirstOrDefaultAsync(x => x.Id == model.DirectionId, cancellationToken: cancellationToken);
        
        if (direction is null)
            return null;
        
        var newEvent = new Event()
        {
            Title = model.Title,
            Description = model.Description,
            Direction = direction,
            VideoUrl = await _fileSaveService.SaveAsync(httpContext, model.Video, Constants.Paths.Events),
            ImageUrls = model.Images.Select(async x => 
                    await _fileSaveService.SaveAsync(httpContext, x, Constants.Paths.Directions))
                .Select(x => x.Result)
                .ToList()
        };

        var entry = await _applicationDataContext.Event.AddAsync(newEvent, cancellationToken);
        await _applicationDataContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public async Task<Event?> EditAsync(Event model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Event>> GetEventByDirectionAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}