using Application.Messages.Direction.Commands;

namespace GazMeme.Common.Binders;

public class CreateDirectionBinder : RequestBinder<CreateDirectionCommand>
{
    public override async ValueTask<CreateDirectionCommand> BindAsync(BinderContext ctx, CancellationToken ct)
    {
        var form = await ctx.HttpContext.Request.ReadFormAsync(ct);
        
        return new CreateDirectionCommand(
            Title: form["title"].ToString(),
            Subtitle: form["subtitle"].ToString(),
            ShortDescription: form["shortDescription"].ToString(),
            Description: form["description"].ToString(),
            EmployeeId: Convert.ToInt32(form["employeeId"]),
            Preview: form.Files[0],
            Images: form.Files.Skip(1).ToList()
        );
    }
}