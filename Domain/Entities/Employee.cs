namespace Domain.Entities;

public class Employee : EntityBase
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Surname { get; set; } = null!;

    public string PhotoUrl { get; set; } = null!;

    public string Phone { get; set; } = null!;
    
    public string Email { get; set; } = null!;

    public List<Event> Events { get; set; } = new();

    public string FullName => $"{LastName} {FirstName} {Surname}";
}