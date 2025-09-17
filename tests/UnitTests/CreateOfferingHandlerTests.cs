using Application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using ErrorOr;
using Application.Common.Models;
using Application.Features.Offerings;
using Application.Features.Offerings.Handlers;
using FluentAssertions;

namespace UnitTests;

public class CreateOfferingHandlerTests
{
    private ApplicationDbContext GetInMemoryDb()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new ApplicationDbContext(options);
    }

    [Fact]
    public async Task Handle_ShouldCreateOfferingSuccessfully()
    {
        var context = GetInMemoryDb();

        context.Companies.Add(new Company
        {
            Id = Guid.Parse("7ee5bb18-78de-4fc6-b514-bcb3881c8b37"),
            Name = "Test Company",
            OwnerId = Guid.Parse("7ee5bb18-78de-4fc6-b514-bcb3881c8b33")
        });
        context.OfferingCategories.Add(new OfferingCategory
        {
            Id = Guid.Parse("7ee5bb18-78de-4fc6-b514-bcb3881c8b39"),
            Name = "Test Category"
        });

        await context.SaveChangesAsync();

        var handler = new CreateOfferingHandler(context);
        var command = new CreateOfferingCommand(new CreateOfferingDto
        {
            Name = "Test Offering",
            Description = "Test Description",
            Price = 99.99m,
            Duration = 30,
            CategoryId = Guid.Parse("7ee5bb18-78de-4fc6-b514-bcb3881c8b39"),
            CompanyId = Guid.Parse("7ee5bb18-78de-4fc6-b514-bcb3881c8b37"),

        });

        ErrorOr<OfferingDto> result = await handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Name.Should().Be("Test Offering");
        result.Value.Description.Should().Be("Test Description");
        result.Value.Price.Should().Be(99.99m);

        var dbItem = await context.Offerings.FindAsync(result.Value.Id);
        dbItem.Should().NotBeNull();
        dbItem!.Name.Should().Be("Test Offering");
    }

}
