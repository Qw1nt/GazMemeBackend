using Contracts.Direction;

namespace Contracts.Employee;

public record EmployeeResponse
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Surname { get; set; } = null!;

    public string PhotoUrl { get; set; } = null!;

    public string Phone { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public DirectionResponse Direction { get; set; }  = null!;

    public string FullName => $"{LastName} {FirstName} {Surname}";   
}