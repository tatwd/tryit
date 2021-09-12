using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace api2.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 2).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("echo_headers")]
    public string EchoHeaders()
    {
        var sb = new StringBuilder();
        sb.AppendFormat("path-base: {0}\n", HttpContext.Request.PathBase);
        sb.AppendFormat("path: {0}\n", HttpContext.Request.Path);
        sb.AppendFormat("query: {0}\n", HttpContext.Request.QueryString);
        sb.AppendLine("headers: ");
        foreach (var (k, v) in HttpContext.Request.Headers.OrderBy(e => e.Key)) {
            sb.AppendFormat("   {0}: {1}\n", k, v);
        }
        return sb.ToString();
    }
}
