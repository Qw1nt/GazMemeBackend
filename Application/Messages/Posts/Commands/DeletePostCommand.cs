using Microsoft.AspNetCore.Mvc;

namespace Application.Messages.Posts.Commands;

public record DeletePostCommand(int PostId);