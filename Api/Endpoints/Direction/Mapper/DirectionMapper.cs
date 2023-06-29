using Contracts.Direction;
using Contracts.Employee;
using Contracts.Event;

namespace GazMeme.Endpoints.Direction.Mapper;

public class DirectionMapper : ResponseMapper<DirectionResponse, Domain.Entities.Direction>
{
    public override DirectionResponse FromEntity(Domain.Entities.Direction e)
    {
        return new DirectionResponse
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            Employee = new EmployeeResponse
            {
                FirstName = e.Employee.FirstName,
                LastName = e.Employee.LastName,
                Surname = e.Employee.Surname,
                PhotoUrl = e.Employee.PhotoUrl,
                Phone = e.Employee.Phone,
                Email = e.Employee.Email
            },
            Events = e.Events.Select(x => new EventResponse
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                DateTime = x.DateTime,
                VideoUrl = x.VideoUrl,
                ImageUrls = x.ImageUrls
            }).ToList(),
            ImageUrls = e.ImageUrls,
            PreviewUrl = e.PreviewUrl
        };
    }
}