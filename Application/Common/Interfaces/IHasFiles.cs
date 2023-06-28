using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Common.Interfaces;

public interface IHasFiles
{
    [BindNever]
    public List<IFormFile> Images { get; set; }
}