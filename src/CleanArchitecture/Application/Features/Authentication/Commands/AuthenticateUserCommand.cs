using CleanArchitecture.Application;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.Authentication.Commands;
public record AuthenticateUserCommand(string UserName, string Password) : IRequest<AuthenticateUserResult>;
public record AuthenticateUserResult(bool Success, Guid UserId, string Token, DateTime Expires);

public class AuthenticateUserCommandHandler(UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    ITokenService tokenService,
    IUnitOfWork unitOfWork,
    IMailService emailSender,
    ICurrentUser currentUser,
    AppSettings appSettings,
    ICookieService cookieService) : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResult>
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
    private readonly IMailService _emailSender = emailSender;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICurrentUser _currentUser = currentUser;
    private readonly AppSettings _appSettings = appSettings;
    private readonly ICookieService _cookieService = cookieService;
    
    public async Task<AuthenticateUserResult> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
            .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
            .Include(u => u.Avatar)
            .FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken)
            ?? throw AuthIdentityException.ThrowAccountDoesNotExist();

        // Step 2: Check the password first to avoid unnecessary database queries if invalid.
        var passwordCheckResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);

        if (!passwordCheckResult.Succeeded)
        {
            throw AuthIdentityException.ThrowLoginUnsuccessful();
        }

        // Step 3: Retrieve user's claims in bulk to avoid multiple individual queries.
        var userClaims = await _userManager.GetClaimsAsync(user);
        var scopes = userClaims.FirstOrDefault(c => c.Type == "scope")?.Value.Split(' ') ?? Array.Empty<string>();

        // Step 4: Generate authentication token.
        var token = await _tokenService.GenerateToken(user, scopes, cancellationToken);
        _cookieService.Delete();
        _cookieService.Set(token.Token);

        return new AuthenticateUserResult(
            Success: true,
            UserId: user.Id,
            Token: token.Token,
            Expires: token.Expires
        );
    }
}