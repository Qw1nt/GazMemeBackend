namespace Domain.Entities;

public class Organizer : EntityBase
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Surname { get; set; } = null!;
    
    public string ImageUrl { get; set; } = null!;
}