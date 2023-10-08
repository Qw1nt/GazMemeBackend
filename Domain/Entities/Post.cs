namespace Domain.Entities;

public class Post : EntityBase
{
    public string Title { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;
}