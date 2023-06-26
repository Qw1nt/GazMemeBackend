using Application.Common.Interfaces;
using Application.Common.Persistence;
using Application.Messages.Identity.Commands;
using Contracts.Identity;
using Domain.Entities;
using FastEndpoints.Security;

namespace Application.Common.Services;

public class UserAuthenticationService: IUserAuthenticationService
{
    private readonly IHashSaltService _hashSaltService;
    private readonly AuthenticationConfiguration _authenticationConfiguration;
    
    public UserAuthenticationService(IHashSaltService hashSaltService, AuthenticationConfiguration authenticationConfiguration)
    {
        _hashSaltService = hashSaltService;
        _authenticationConfiguration = authenticationConfiguration;
    }
    
    public TokenPair? Login(User user, IdentityCommand command)
    {
        if (Verify(user, command) == false)
            return null;
        
        var accessToken = JWTBearer.CreateToken(
            signingKey: _authenticationConfiguration.BearerKey,
            expireAt: DateTime.UtcNow.AddDays(1),
            priviledges: u =>
            {
                u["UserID"] = user.Id.ToString(); //indexer based claim setting
            });

        return new TokenPair(accessToken, "");
    }

    public User Register(IdentityCommand command)
    {
        var salt = _hashSaltService.ComputeSalt();
        var hash = _hashSaltService.ComputeHash(command.Password, salt);

        var user = new User
        {
            Login = command.Login,
            PasswordSalt = salt,
            PasswordHash = hash
        };

        return user;
    }

    public bool Verify(User user, IdentityCommand command)
    {
        var hash = _hashSaltService.ComputeHash(command.Password, user!.PasswordSalt);
        return user.PasswordHash == hash;
    }
}