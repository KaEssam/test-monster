using Microsoft.AspNetCore.Mvc;

namespace TestMonster.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new HealthResponse(
            Status: "Healthy",
            Timestamp: DateTime.UtcNow,
            Environment: System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown"));
    }
    [HttpGet("test")]
    public IActionResult Get1()
    {
        return Ok("Test");
    }
}

public record HealthResponse(string Status, DateTime Timestamp, string Environment);
