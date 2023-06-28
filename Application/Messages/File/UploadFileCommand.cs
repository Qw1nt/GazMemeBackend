using Microsoft.AspNetCore.Http;

namespace Application.Messages.File;

public record UploadFileCommand(IFormFile File);