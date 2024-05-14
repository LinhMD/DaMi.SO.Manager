using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMinimalApis.Lib.Helpers;
using CrudApiTemplate.Repository;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Endpoints.OrderDetails.DTO;
using DaMi.SO.Manager.Endpoints.OrderMasters.DTO;
using DaMi.SO.Manager.Endpoints.Reports.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Endpoints.Reports;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ReportController(IUnitOfWork work) : ControllerBase
{
    [HttpGet("OrderDetail")]
    public async Task<IResult> GetOrderDetailsReport([FromForm] string? CustomerId, [FromQuery] string? ItemId)
    {
        var items = (await work.Get<OrderDetail>()
            .Find<OrderDetailSimpleView>(t => (CustomerId == null || t.Order.CustomerId == CustomerId) && (ItemId == null || t.ItemId == ItemId))
            .ToListAsync())
            .GroupBy(o => o.OrderNo)
            .ToDictionary(o => o.Key ?? "", o => o.ToList());
        var orderMasters = await work.Get<OrderMaster>().Find<OrderMasterSimpleView>(f => f.OrderNo != null && items.Keys.Contains(f.OrderNo)).ToDictionaryAsync(o => o.OrderNo ?? "");
        return this.Page<OrderDetailReportPage, OrderDetailReportModel>(new OrderDetailReportModel
        {
            OrderDetailMap = items,
            OrderMasterMap = orderMasters
        });
    }
}

public class OrderDetailReportModel
{
    public required Dictionary<string, List<OrderDetailSimpleView>> OrderDetailMap { get; set; }
    public required Dictionary<string, OrderMasterSimpleView> OrderMasterMap { get; set; }

    public OrderForm OrderForm { get; set; } = new OrderForm()
    {
        HasByDiskSize = true,
        HasByNumData = true,
        HasByPc = true,
        HasByQtyInvc = true,
        HasByTaxCode = true,
        HasByTime = true,
        HasByUser = true
    };
}
