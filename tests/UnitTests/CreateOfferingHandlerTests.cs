using Application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Features.Offerings.Commands.CreateOffering;
using ErrorOr;
using Application.Common.Models;
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

        var orgId = Guid.NewGuid();
        context.OfferingCategories.Add(new OfferingCategory
        {
            Id = Guid.Parse("7ee5bb18-78de-4fc6-b514-bcb3881c8b39"),
            Name = "Test Category"
        });

        await context.SaveChangesAsync();

        var handler = new CreateOfferingHandler(context);
        var command = new CreateOfferingCommand("Test Offering", "Test Description", 99.99m, 30, Guid.Parse("7ee5bb18-78de-4fc6-b514-bcb3881c8b39"));

        ErrorOr<Offering> result = await handler.Handle(command, CancellationToken.None);

        result.IsError.Should().BeFalse();
        result.Value.Name.Should().Be("Test Offering");
        result.Value.Description.Should().Be("Test Description");
        result.Value.Price.Should().Be(99.99m);

        var dbItem = await context.Offerings.FindAsync(result.Value.Id);
        dbItem.Should().NotBeNull();
        dbItem!.Name.Should().Be("Test Offering");
    }
    
}
