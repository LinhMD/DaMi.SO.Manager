using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApiTemplate.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DaMi.Shared;
using DaMi.SO.Manager.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace DaMi.SO.Manager.Endpoints.TaxCodes;

[ApiController]
[Authorize]
[Route("[controller]")]
public class TaxCodeController(IUnitOfWork work) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetTaxCode([FromQuery] string taxcode, [FromQuery] string customer)
    {
        if (Utils.TaxCodeIsValid(taxcode ?? ""))
        {
            var taxCodes = await work.Get<TaxCode>().Find(t => t.TaxCodeId == taxcode).ToListAsync();
            if (taxCodes.Count == 0)
            {
                taxCodes.Add(await work.Get<TaxCode>().AddAsync(new TaxCode { CustomerId = customer, TaxCodeId = taxcode }));
            }
            return Ok(taxCodes);
        }
        return BadRequest();
    }
}