using Application.Common.Interfaces;
using Application.Common.Persistence;
using Application.Messages.File;

namespace GazMeme.Endpoints;

public class FileEndpoint : Endpoint<UploadFileCommand, string>
{
    private readonly IFileSaveService _fileSaveService;

    public FileEndpoint(IFileSaveService fileSaveService)
    {
        _fileSaveService = fileSaveService;
    }

    public override void Configure()
    {
        AllowFileUploads();
        Post("file/upload");
    }

    public override async Task HandleAsync(UploadFileCommand req, CancellationToken ct)
    {
        await SendAsync(await _fileSaveService.SaveAsync(HttpContext, req.File, Constants.Paths.Common), cancellation: ct);
    }
}