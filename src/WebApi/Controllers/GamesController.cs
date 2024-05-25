using GamingApi.GamingService;
using Microsoft.AspNetCore.Mvc;

namespace Yld.GamingApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public sealed class GamesController : ControllerBase
{
    private readonly IGamingService gamingService;

    public GamesController(IGamingService gamingService)
    {
        this.gamingService = gamingService;
    }

    [HttpGet]
    public async Task<IActionResult?> Get(int offset = 0, int limit = 2)
    {
        var response = await gamingService.Get(offset, limit);

        try
        {
            var json = new JsonResult(new
            {
                response.summary.Items,
                response.TotalItems
            });
            return json;
        }
        catch (Exception)
        {
            return new JsonResult(new { success = false, message = "An error occured fetching your results" });
        }
    }
}