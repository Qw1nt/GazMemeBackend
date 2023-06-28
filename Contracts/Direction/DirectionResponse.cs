using Contracts.Employee;
using Contracts.Event;

namespace Contracts.Direction;

public class DirectionResponse
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public EmployeeResponse Employee { get; set; }

    public string PreviewUrl { get; set; } = null!;

    public List<string> ImageUrls { get; set; } = new();

    public List<EventResponse> Events { get; set; } = new();
}