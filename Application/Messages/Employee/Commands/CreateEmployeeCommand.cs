using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Messages.Employee.Commands;

public class CreateEmployeeCommand
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Surname { get; set; }
    
    [FromForm]
    public IFormFile Image { get; set; } 
    
    public string Phone { get; set; }
    
    public string Email { get; set; }
}
