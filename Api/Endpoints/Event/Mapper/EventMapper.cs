using Contracts.Employee;
using Contracts.Event;

namespace GazMeme.Endpoints.Event.Mapper;

public class EventMapper : ResponseMapper<EventResponse, Domain.Entities.Event>
{
    public override EventResponse FromEntity(Domain.Entities.Event e)
    {
        return new EventResponse
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            DateTime = e.DateTime,
            VideoUrl = e.VideoUrl,
            Employees = e.Employees.Select(x => new EmployeeResponse
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Surname = x.Surname,
                PhotoUrl = x.PhotoUrl,
                Phone = x.Phone,
                Email = x.Email
            }).ToList(),
            ImageUrls = e.ImageUrls
        };
    }
}