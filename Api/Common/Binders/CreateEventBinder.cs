using Application.Messages.Event.Commands;

namespace GazMeme.Common.Binders;

public class CreateEventBinder : RequestBinder<CreateEventCommand>
{
    public override async ValueTask<CreateEventCommand> BindAsync(BinderContext ctx, CancellationToken ct)
    {
        var form = await ctx.HttpContext.Request.ReadFormAsync(ct);

        return new CreateEventCommand(
            Title: form["title"].ToString(),
            Description: form["description"].ToString(),
            DirectionId: Convert.ToInt32(form["employeeId"]),
            DateTime: DateTime.Parse(form["dateTime"].ToString()),
            Video: form.Files[0],
            Images: form.Files.Skip(1).ToList(),
            EmployeeIds: form["employeeIds"].ToString().Split(',').Select(strId => Convert.ToInt32(strId)).ToList()
        );
    }
}