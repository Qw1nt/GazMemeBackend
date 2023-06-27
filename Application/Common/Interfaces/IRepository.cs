using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces;

public interface IRepository<TSource, in TAddModel>
{
    Task<List<TSource>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<TSource?> GetAsync(int id, CancellationToken cancellationToken = default);

    Task<TSource?> AddAsync(HttpContext httpContext, TAddModel model, CancellationToken cancellationToken = default);

    Task<TSource?> EditAsync(TSource model, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}