using BlazorMinimalApis.Lib.Helpers;
using BlazorMinimalApis.Lib.Validation;
using Microsoft.AspNetCore.Mvc;

namespace DaMi.SO.Manager.Endpoints.HomePages;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IResult Get()
    {
        return this.Page<HomePage, HomeModel>(new() { Hello = 2 });
    }
}

public class HomeModel
{
    public int Hello { get; set; }
}
