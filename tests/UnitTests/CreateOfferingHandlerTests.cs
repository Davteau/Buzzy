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
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // unikalna baza dla testu
            .Options;

        return new ApplicationDbContext(options);
    }

    [Fact]
    public async Task Handle_ShouldCreateOfferingSuccessfully()
    {
        // Arrange
        var context = GetInMemoryDb();
        var handler = new CreateOfferingHandler(context);
        var command = new CreateOfferingCommand("Test Offering", "Test Description", 99.99m, 30, Guid.Parse("7ee5bb18-78de-4fc6-b514-bcb3881c8b39"));

        // Act
        ErrorOr<Offering> result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsError.Should().BeFalse(); // brak błędów
        result.Value.Name.Should().Be("Test Offering");
        result.Value.Description.Should().Be("Test Description");
        result.Value.Price.Should().Be(99.99m);

        // Sprawdzenie, czy zapisano w bazie
        var dbItem = await context.Offerings.FindAsync(result.Value.Id);
        dbItem.Should().NotBeNull();
        dbItem!.Name.Should().Be("Test Offering");
    }
}
