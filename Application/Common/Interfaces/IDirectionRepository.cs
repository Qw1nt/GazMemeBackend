using Application.Messages.Direction.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces;

public interface IDirectionRepository : IRepository<Direction, CreateDirectionCommand>
{
}