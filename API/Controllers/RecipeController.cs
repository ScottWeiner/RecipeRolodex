using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Hello()
    {
        return Ok("Hello!!!");
    }
}
