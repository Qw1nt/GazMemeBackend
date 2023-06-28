using Contracts.Employee;

namespace Contracts.Event;

public class EventResponse
{
    public int Id { get; set; }

    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public string VideoUrl { get; set; } = null!;

    public List<string> ImageUrls { get; set; } = new();

    public List<EmployeeResponse> Employees { get; set; } = new();
}