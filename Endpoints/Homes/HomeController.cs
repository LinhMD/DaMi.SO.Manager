using System.Security.Claims;
using BlazorMinimalApis.Lib.Helpers;
using BlazorMinimalApis.Lib.Validation;
using CrudApiTemplate.CustomBinding;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Endpoints.Share;
using DaMi.SO.Manager.Hubs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DaMi.SO.Manager.Endpoints.Homes;

[ApiController]
[Route("")]
public class HomeController(IHubContext<NotificationHub> notificationHub) : ControllerBase
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
    [HttpGet("notify")]
    public async Task<IActionResult> notify([FromClaim(ClaimTypes.NameIdentifier)] string employeeID)
    {
        await notificationHub.Clients.User(employeeID).SendAsync("notify", new Notification { Message = "hello" });
        return Ok();
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
