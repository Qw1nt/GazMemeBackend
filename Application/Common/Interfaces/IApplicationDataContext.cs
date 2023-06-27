using Domain.Entities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDataContext
{
    public DbSet<Employee> Employee { get; }
    
    public DbSet<Direction> Direction { get; }

    public DbSet<Event> Event { get; }
    
    public DbSet<User> Users { get; }
    
    public DbSet<Post> Posts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}