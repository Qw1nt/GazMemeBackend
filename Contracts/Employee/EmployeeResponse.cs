namespace Contracts.Employee;

public record EmployeeResponse
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Surname { get; set; } = null!;

    public string PhotoUrl { get; set; } = null!;

    public string Phone { get; set; } = null!;
    
    public string Email { get; set; } = null!;

    public string FullName => $"{FirstName} {LastName} {Surname}";   
}