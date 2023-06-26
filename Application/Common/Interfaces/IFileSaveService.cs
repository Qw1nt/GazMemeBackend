using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces;

public interface IFileSaveService
{
    Task<string> SaveAsync(IFormFile formFile, string saveFolder);
}