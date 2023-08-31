using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;

[ApiController, Route("[controller]"), Authorize]
[SwaggerTag("Swashbuckle.AspNetCore.Annotations")]
public class TestAuthorizationController : ControllerBase
{
    private readonly ILogger<TestAuthorizationController> _logger;

    public TestAuthorizationController(ILogger<TestAuthorizationController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get()
    {
        await Task.Yield();
        return Ok($"Hello {HttpContext.User.Identity?.Name}!");
    }
}
