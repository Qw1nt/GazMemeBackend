using Contracts.Direction;
using Contracts.Employee;
using Contracts.Event;

namespace GazMeme.Endpoints.Event.Mapper;

public class EventMapper : ResponseMapper<EventResponse, Domain.Entities.Event>
{
    public override EventResponse FromEntity(Domain.Entities.Event e)
    {
        var response = new EventResponse
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            DateTime = e.DateTime,
            VideoUrl = e.VideoUrl,
            ImageUrls = e.ImageUrls
        };

        var employees = new List<EmployeeResponse>();
        
        foreach (var yuy in e.Employees)
        {
            var employee = new EmployeeResponse()
            {
                FirstName = yuy.FirstName,
                LastName = yuy.LastName,
                Surname = yuy.Surname,
                PhotoUrl = yuy.PhotoUrl,
                Phone = yuy.Phone,
                Email = yuy.Email
            };

            if (yuy.Direction is not null)
            {
                employee.Direction = new DirectionResponse()
                {
                    Id = yuy.Direction.Id
                };
            }
            
            employees.Add(employee);
        }

        response.Employees = employees;
        
        return response;
    }
}