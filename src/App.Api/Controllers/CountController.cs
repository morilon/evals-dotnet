using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPS.TechEval.App.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{v:apiVersion}/[controller]")]
public sealed class CountController : ControllerBase
{
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult PostAsync()
    {
        return Ok();
    }
}