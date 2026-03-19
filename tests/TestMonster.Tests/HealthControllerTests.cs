using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using TestMonster.API.Controllers;

namespace TestMonster.Tests;

public class HealthControllerTests
{
    [Fact]
    public void Should_ReturnOkWithHealthyStatus_When_Called()
    {
        // Arrange
        var controller = new HealthController();

        // Act
        var result = controller.Get() as OkObjectResult;

        // Assert
        result.Should().NotBeNull();
        result!.StatusCode.Should().Be(200);

        var response = result.Value as HealthResponse;
        response.Should().NotBeNull();
        response!.Status.Should().Be("Healthy");
        response.Timestamp.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
    }
}
