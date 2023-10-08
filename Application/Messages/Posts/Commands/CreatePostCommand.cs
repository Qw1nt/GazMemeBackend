using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Messages.Posts.Commands;

public record CreatePostCommand(string Title, string ShortDescription, string Content, [FromForm] IFormFile Image);