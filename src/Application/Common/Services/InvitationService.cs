using Microsoft.Extensions.Configuration;

namespace Application.Common.Services;

public class InvitationService(IConfiguration configuration)
{
    public Task<string> GenerateInvitationLink(Guid invitationId)
    {
        var baseUrl = configuration["AppSettings:BaseUrl"];
        var path = configuration["AppSettings:InvitationPath"];

        if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(path))
            throw new InvalidOperationException("Unexpected error occured on the server.");

        return Task.FromResult($"{baseUrl.TrimEnd('/')}/{path.Trim('/')}/{invitationId}");
    }
}