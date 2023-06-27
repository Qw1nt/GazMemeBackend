using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Messages.Event.Commands;

public record CreateEventCommand([FromForm] IFormFile Video);