using BlazorMinimalApis.Lib.Helpers;
using BlazorMinimalApis.Lib.Validation;
using Microsoft.AspNetCore.Mvc;

namespace DaMi.SO.Manager.Endpoints.Homes;

[ApiController]
[Route("index")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IResult Get()
    {
        if (HttpContext.User?.Identity?.IsAuthenticated ?? false)
        {
            return this.Page<HomePage, HomeModel>(new() { Hello = 2 });
        }
        return Results.Redirect("/Login");
    }
}

public class HomeModel
{
    public int Hello { get; set; }
}
