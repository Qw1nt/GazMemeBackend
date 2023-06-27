using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces;

public interface IFileSaveService
{
    Task<string> SaveAsync(HttpContext httpContext, IFormFile formFile, string saveFolder);
}