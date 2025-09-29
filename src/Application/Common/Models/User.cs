using Application.Common.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models;

public class User
{
    public Guid Id { get; set; }

    [EmailAddress(ErrorMessage = "Incorrect format of email.")]
    [MaxLength(50)]
    public required string Email { get; set; }

    [MaxLength(20)]
    public string? Nickname { get; set; }

    public UserRole Role { get; set; } = UserRole.Client;

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}
