using MediatR;

namespace Application.Features.Authentication;

public class TokenResponseDto : IRequest
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}