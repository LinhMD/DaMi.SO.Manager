using BlazorMinimalApis.Lib.Helpers;
using BlazorMinimalApis.Lib.Validation;
using Microsoft.AspNetCore.Mvc;

namespace DaMi.SO.Manager.Endpoints.Homes;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet("index")]
    public IResult Get()
    {
        if (HttpContext.User?.Identity?.IsAuthenticated ?? false)
        {
            return Results.Redirect("/OrderMaster");
        }
        return Results.Redirect("/Login");
    }
    [HttpGet]
    public IResult GetNor()
    {
        if (HttpContext.User?.Identity?.IsAuthenticated ?? false)
        {
            return Results.Redirect("/OrderMaster");
        }
        return Results.Redirect("/Login");
    }
}

public class HomeModel
{
    public int Hello { get; set; }
}
