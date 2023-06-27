using Application.Messages.Event.Commands;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IEventRepository : IRepository<Event, CreateEventCommand>
{
    Task<List<Event>> GetEventByDirectionAsync(CancellationToken cancellationToken = default);
}