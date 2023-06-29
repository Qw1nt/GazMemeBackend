using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Messages.Employee.Commands;

public record CreateEmployeeCommand(string LastName, string FirstName, string Surname, [FromForm] IFormFile Photo, string Phone, string Email);