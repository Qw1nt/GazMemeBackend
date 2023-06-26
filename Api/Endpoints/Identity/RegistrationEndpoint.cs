using Application.Common.Interfaces;
using Application.Messages.Identity.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace GazMeme.Endpoints.Identity;

[AllowAnonymous]
[HttpPost("api/identity/register")]
public class RegistrationEndpoint : Endpoint<IdentityCommand, User>
{
    private readonly IUserAuthenticationService _userAuthenticationService;
    private readonly IApplicationDataContext _applicationDataContext;
    
    public RegistrationEndpoint(IUserAuthenticationService userAuthenticationService, IApplicationDataContext applicationDataContext)
    {
        _userAuthenticationService = userAuthenticationService;
        _applicationDataContext = applicationDataContext;
    }

    public override async Task HandleAsync(IdentityCommand req, CancellationToken ct)
    {
        var response = _userAuthenticationService.Register(req);
        var entry = await _applicationDataContext.Users.AddAsync(response, ct);
        await _applicationDataContext.SaveChangesAsync(ct);
        await SendAsync(entry.Entity, cancellation: ct);
    }
}