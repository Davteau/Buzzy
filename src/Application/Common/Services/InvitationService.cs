using Microsoft.Extensions.Configuration;

namespace Application.Common.Services;
public class InvitationService(IConfiguration configuration)
{
    public async Task<string> GenerateInvitationLink(Guid invitationId)
    {
        var baseUrl = configuration["AppSettings:BaseUrl"];
        return $"{baseUrl}/api/invitations/{invitationId}";
    }
}

