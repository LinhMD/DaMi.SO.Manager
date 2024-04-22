using CrudApiTemplate.Repository;
using DaMi.SO.Manager.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Endpoints.Items;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ItemController(IUnitOfWork work) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetItem([FromQuery] string? ItemIdSelect)
    {
        var items = await work.Get<ViwItem>().Find(t => ItemIdSelect == null || t.ItemId == ItemIdSelect || t.ItemName.ToLower().Contains(ItemIdSelect.ToLower())).ToListAsync();
        return Ok(items);
    }
}