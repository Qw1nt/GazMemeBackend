namespace Domain.Entities;

public class Direction : EntityBase
{
    public string Title { get; set; }

    public string Description { get; set; }

    public Employee Employee { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string VideoUrl { get; set; } = null!;
    
    public List<string> ImageUrls { get; set; } = new();

    public List<Event> Events { get; set; } = new();
}