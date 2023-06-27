using Application.Common.Interfaces;
using Application.Messages.Identity.Commands;
using Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GazMeme.Endpoints.Identity;

[AllowAnonymous]
[HttpPost("identity/authentication")]
public class AuthenticationEndpoint : Endpoint<IdentityCommand, TokenPair>
{
    private readonly IUserAuthenticationService _userAuthenticationService;
    private readonly IApplicationDataContext _applicationDataContext;
    
    public AuthenticationEndpoint(IUserAuthenticationService userAuthenticationService, IApplicationDataContext applicationDataContext)
    {
        _userAuthenticationService = userAuthenticationService;
        _applicationDataContext = applicationDataContext;
    }

    public override async Task HandleAsync(IdentityCommand request, CancellationToken ct)
    {
        var user = await _applicationDataContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Login == request.Login, cancellationToken: ct);

        if (user is null)
            await SendNotFoundAsync(ct);

        var response = _userAuthenticationService.Login(user!, request);

        if (response is null)
            await SendNotFoundAsync(ct);
            
        await SendAsync(response!, cancellation: ct);
    }
}