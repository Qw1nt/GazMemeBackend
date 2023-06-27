using Application.Common.Interfaces;
using Application.Common.Persistence;
using Application.Messages.Posts.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Services;

public class PostRepository : IPostRepository
{
    private readonly IApplicationDataContext _applicationDataContext;
    private readonly IFileSaveService _fileSaveService;

    public PostRepository(IApplicationDataContext applicationDataContext, IFileSaveService fileSaveService)
    {
        _applicationDataContext = applicationDataContext;
        _fileSaveService = fileSaveService;
    }

    public async Task<List<Post>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _applicationDataContext.Posts
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Post?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _applicationDataContext.Posts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<Post?> AddAsync(HttpContext httpContext, CreatePostCommand model, CancellationToken cancellationToken = default)
    {
        var post = new Post()
        {
            Title = model.Title,
            Content = model.Content,
            ImageUrl = await _fileSaveService.SaveAsync(httpContext, model.Image, Constants.Paths.Posts)
        };

        var entry = await _applicationDataContext.Posts.AddAsync(post, cancellationToken);
        await _applicationDataContext.SaveChangesAsync(cancellationToken);

        return entry.Entity;
    }

    public Task<Post?> EditAsync(Post model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var post = await _applicationDataContext.Posts
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

        if (post is null)
            return false;
            
        _applicationDataContext.Posts.Remove(post);
        await _applicationDataContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}