using Contracts.Employee;
using Contracts.Event;

namespace Contracts.Direction;

public class DirectionResponse
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    
    public string Subtitle { get; set; }  = null!;

    public string ShortDescription { get; set; }  = null!;

    public string Description { get; set; }  = null!;

    public EmployeeResponse Employee { get; set; }  = null!;

    public string PreviewUrl { get; set; } = null!;

    public List<string> ImageUrls { get; set; } = new();

    public List<EventResponse> Events { get; set; } = new();
}