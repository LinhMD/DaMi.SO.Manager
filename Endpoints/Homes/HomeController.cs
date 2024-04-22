using BlazorMinimalApis.Lib.Helpers;
using BlazorMinimalApis.Lib.Validation;
using DaMi.SO.Manager.Endpoints.Share;
using Microsoft.AspNetCore.Http.HttpResults;
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
    [HttpGet("Home")]
    public IResult GetHome()
    {
        return this.Page<HomePage, HomeModel>(new HomeModel { Hello = 1 });
    }
    [HttpGet("forbidden")]
    public IResult Get403()
    {
        return new RazorComponentResult(typeof(_403));
    }
}

public class HomeModel
{
    public int Hello { get; set; }
}
