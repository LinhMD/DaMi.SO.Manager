using BlazorMinimalApis.Lib.Helpers;
using BlazorMinimalApis.Lib.Validation;
using Microsoft.AspNetCore.Mvc;

namespace DaMi.SO.Manager.Components.HomePages;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetResultAsync()
    {
        return this.Page<HomePage>(new ValidationResponse(), await Task.FromResult(new HomeModel { Hello = 2 }));
    }
}

public class HomeModel
{
    public int Hello { get; set; }
}
