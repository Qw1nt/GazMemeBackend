using Application.Messages.Posts.Commands;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IPostRepository : IRepository<Post, CreatePostCommand>
{
}