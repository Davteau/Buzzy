using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Authentication;

public class TokenResponseDto : IRequest
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}