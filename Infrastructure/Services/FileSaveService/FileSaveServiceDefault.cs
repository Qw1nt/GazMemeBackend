using Application.Common.Interfaces;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services.FileSaveService;

public class FileSaveServiceDefault : FilesSaveServiceBase, IFileSaveService
{
    public FileSaveServiceDefault(IWebHostEnvironment environment) : base(environment)
    {
        
    }
    
    public async Task<string> SaveAsync(HttpContext httpContext, IFormFile formFile, string saveFolder)
    {
        if(formFile is null)
            throw new NullReferenceException("Нет целевого файла на сохранение");
        
        if (string.IsNullOrEmpty(saveFolder) == true)
            throw new NullReferenceException("Название папки для сохранения не указана");
        
        string saveDirectory = GetSaveDirectoryPath(saveFolder);

        string fileName = GenerateFileName(formFile.FileName);
        string savePath = GenerateSavePath(saveDirectory, fileName);
        
        await using Stream stream = new FileStream(savePath, FileMode.Create);
        await formFile.CopyToAsync(stream);

        return Path.Combine(httpContext.Request.BaseUrl()!, saveFolder, fileName);
    }
}