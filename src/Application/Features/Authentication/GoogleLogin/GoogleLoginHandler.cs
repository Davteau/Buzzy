using Application.Common.Models;
using Application.Common.Models.Enums;
using Application.Features.Authentication.Common;
using Application.Infrastructure.Persistence;
using Google.Apis.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Features.Authentication.GoogleLogin;

public record GoogleLoginCommand(string Token, string Role) : IRequest<TokenResponseDto>;
internal sealed class GoogleLoginHandler(ApplicationDbContext context, IConfiguration configuration, TokenFactory tokenFactory) : IRequestHandler<GoogleLoginCommand, TokenResponseDto>
{
    public async Task<TokenResponseDto> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(request.Token);
            if (!Enum.TryParse<UserRole>(request.Role, ignoreCase: true, out var userRole))
            {
                userRole = UserRole.Client;
            }
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == payload.Email, cancellationToken: cancellationToken);
            if (user == null)
            {
                user = new User
                {
                    Email = payload.Email,
                    Role = userRole,
                };

                context.Users.Add(user);

                await context.SaveChangesAsync(cancellationToken);
            }

            return await tokenFactory.CreateTokenResponse(user);
        }

        catch (Exception ex)
        {
            throw new ApplicationException("Google login failed", ex);
        }
    }
}