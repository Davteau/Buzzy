using Microsoft.Extensions.Configuration;

namespace Application.Common.Services;

public class InvitationService(IConfiguration configuration)
{
    private readonly ApiPathOptions _apiPathOptions = configuration.GetSection("ApiPathSettings").Get<ApiPathOptions>()
                                                  ?? throw new InvalidOperationException("ApiPathSettings not configured");
    public string GenerateInvitationLink(Guid invitationId)
    {
        var baseUrl = _apiPathOptions.BaseUrl;
        var path = _apiPathOptions.InvitationPath;

        if (string.IsNullOrWhiteSpace(baseUrl))
        {
            throw new ArgumentNullException("ApiPathSettings:BaseUrl",
                "Base URL is missing in the configuration.");
        }

        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentNullException("ApiPathSettings:InvitationPath",
                "Invitation Path is missing in the configuration.");
        }

        return $"{baseUrl.TrimEnd('/')}/{path.Trim('/')}/{invitationId}";
    }
}