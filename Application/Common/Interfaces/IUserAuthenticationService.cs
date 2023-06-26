using Application.Messages.Identity.Commands;
using Contracts.Identity;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IUserAuthenticationService
{
    public TokenPair? Login(User user, IdentityCommand command);

    public User Register(IdentityCommand command);

    public bool Verify(User user, IdentityCommand command);
}