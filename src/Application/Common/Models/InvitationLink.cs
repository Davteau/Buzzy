namespace Application.Common.Models;

public class InvitationLink
{
    public Guid Id { get; set; }

    public DateTime ExpirationDate { get; set; }

    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }
}

