namespace Domain.Entities;

public class Direction : EntityBase
{
    public string Title { get; set; }
    
    public string Subtitle { get; set; }

    public string ShortDescription { get; set; }

    public string Description { get; set; }

    public Employee Employee { get; set; }

    public string PreviewUrl { get; set; } = null!;

    public List<string> ImageUrls { get; set; } = new();

    public List<Event> Events { get; set; } = new();
}