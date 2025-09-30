namespace Application.Features.Companies;

public class CreateCompanyDto
{
    public required string Name { get; set; }

    public required string Description { get; set; }
}