using System.Reflection;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public sealed class ApplicationDataContext : DbContext, IApplicationDataContext
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(options => options.MigrationsAssembly("Api"));
    }

    public DbSet<User> Users => Set<User>();
    
    public DbSet<Post> Posts => Set<Post>();

    public DbSet<Employee> Employee => Set<Employee>();

    public DbSet<Direction> Direction => Set<Direction>();
    
    public DbSet<Event> Event => Set<Event>();
}