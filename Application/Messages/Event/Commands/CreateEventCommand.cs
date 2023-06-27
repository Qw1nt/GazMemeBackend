using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Messages.Event.Commands;

public record CreateEventCommand(string Title, string Description, DateTime DateTime, int DirectionId,  [FromForm] IFormFile Video,  IFormFileCollection Images, List<int> EmployeeIds);