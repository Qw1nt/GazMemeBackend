namespace Domain.Entities;

public class Event : EntityBase
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public Direction Direction { get; set; }
    
    public string VideoUrl { get; set; } = null!;

    public List<string> ImageUrls { get; set; } = new();

    public List<Employee> Employees { get; set; } = new();
}