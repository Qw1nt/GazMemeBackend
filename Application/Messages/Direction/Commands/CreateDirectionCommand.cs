using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Messages.Direction.Commands;

public class CreateDirectionCommand : IHasFiles
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int EmployeeId { get; set; }
    
    [FromForm]
    public IFormFile Preview { get; set; }

    [BindNever]
    public List<IFormFile> Images { get; set; } = new();
}
