using Microsoft.AspNetCore.Mvc;

namespace my_app.Controllers;

[ApiController]
[Route("[controller]")]
public class TestClassController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<TestClassController> _logger;

    public TestClassController(ILogger<TestClassController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<TestClass> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new TestClass
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
