using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Messages.Employee.Commands;

public record CreateEmployeeCommand(string FirstName, string LastName, string Surname, [FromForm] IFormFile Image, string Phone, string Email);