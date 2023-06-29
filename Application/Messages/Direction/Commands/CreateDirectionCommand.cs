using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Messages.Direction.Commands;

public record CreateDirectionCommand(string Title, string Subtitle, string ShortDescription, string Description, int EmployeeId, [FromForm] IFormFile Preview, [FromForm] List<IFormFile> Images);