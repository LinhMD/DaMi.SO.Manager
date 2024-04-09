using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CrudApiTemplate.CustomException;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Services;
using CrudApiTemplate.Utilities;
using DaMi.SO.Manager.Components;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Endpoints.OrderDetails.DTO;
using DaMi.SO.Manager.Endpoints.OrderDetails.Pages;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Endpoints.OrderDetails;

[ApiController]
[Route("[controller]")]
public class OrderDetailController(IUnitOfWork work, IServiceCrud<OrderDetail> service) : ControllerBase
{

    [HttpGet("Detail/{guid}")]
    public async Task<IResult> GetDetailsAsync(Guid guid)
    {
        return await ReturnPage(work, work.Get<OrderDetail>().Get<OrderDetailSimpleView>(guid), null, ViewMode.Detail);
    }

    [HttpGet("Create")]
    public async Task<IResult> GetNewRow([FromQuery] Guid OrderId, [FromQuery] string? ItemIdSelect)
    {
        return await ReturnPage(work, new OrderDetailSimpleView() { OrderId = OrderId, ItemId = ItemIdSelect }, null, ViewMode.Create);
    }
    [HttpGet("Item")]
    public async Task<IResult> GetItem(Guid? OrderDetailId, string? FormID, string ItemIdSelect)
    {
        ViwItem? item = await work.Get<ViwItem>().Find(x => x.ItemId == ItemIdSelect).FirstOrDefaultAsync();
        Console.WriteLine(JsonSerializer.Serialize(item));
        return new RazorComponentResult(typeof(ItemOOB), new
        {
            DetailID = OrderDetailId,
            Item = item
        });
    }

    [HttpPost("Create")]
    public async Task<IResult> PostNew([FromForm] OrderDetailSimpleView orderDetailNew)
    {
        try
        {
            OrderDetail orderDetail = orderDetailNew.Adapt<OrderDetail>();
            orderDetail.Dump();
            await work.Get<OrderDetail>().AddAsync(orderDetail);
            return await ReturnPage(work, work.Get<OrderDetail>().Get<OrderDetailSimpleView>(orderDetail.RowUniqueId), viewMode: ViewMode.Detail);
        }
        catch (ModelValueInvalidException e)
        {
            return await ReturnPage(work, null, e.MemberErrors, ViewMode.Create);
        }
    }
    [HttpGet("Edit/{guid}")]
    public async Task<IResult> GetEdit(Guid guid, [FromQuery] string? ItemIdSelect)
    {
        OrderDetailSimpleView? orderDetail = await work.Get<OrderDetail>().GetAsync<OrderDetailSimpleView>(guid);
        ViwItem? item = await work.Get<ViwItem>().Find(x => x.ItemId == ItemIdSelect).FirstOrDefaultAsync();
        if (item is not null && orderDetail is not null)
        {
            orderDetail.ItemId = item.ItemId;
            orderDetail.ConvertPrice = item.ConvertPrice;
            orderDetail.TaxRate = item.TaxRate;
        }
        return await ReturnPage(work, orderDetail, null, ViewMode.Edit);
    }

    [HttpPost("Edit/{guid}")]
    public async Task<IResult> PostEdit([FromForm] OrderDetailSimpleView orderDetailNew, Guid guid)
    {
        try
        {
            ViwItem? item = await work.Get<ViwItem>().Find(f => f.ItemId == orderDetailNew.ItemId).FirstOrDefaultAsync();
            if (item is not null)
            {
                orderDetailNew.ConvertPrice = item.ConvertPrice;
                orderDetailNew.TaxRate = item.TaxRate;
            }
            await service.UpdateAsync(orderDetailNew, guid);
            OrderMaster? orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Where(f => f.RowUniqueId == orderDetailNew.OrderId!).FirstOrDefaultAsync();
            if (orderMaster != null)
            {
                orderMaster.ConvertDiscAmount = orderMaster.OrderDetails.Select(f => f.ConvertDiscAmount).Sum();
                orderMaster.ConvertTaxAmount = orderMaster.OrderDetails.Select(f => f.ConvertTaxAmount).Sum();
                orderMaster.ConvertTotalAmount = orderMaster.OrderDetails.Select(f => f.ConvertAmount + f.ConvertTaxAmount - f.ConvertDiscAmount).Sum();
                await work.CompleteAsync();
            }
            return await ReturnPage(work, work.Get<OrderDetail>().Get<OrderDetailSimpleView>(guid), viewMode: ViewMode.Detail);
        }
        catch (ModelValueInvalidException e)
        {
            return await ReturnPage(work, work.Get<OrderDetail>().Get<OrderDetailSimpleView>(guid), e.MemberErrors, ViewMode.Edit);
        }
    }

    private static async Task<IResult> ReturnPage(IUnitOfWork work, OrderDetailSimpleView? orderDetail, Dictionary<string, string>? e = null, ViewMode viewMode = ViewMode.Detail)
    {
        return new RazorComponentResult(typeof(SS75Row), new
        {
            Model = new OrderDetailModifyModel
            {
                OrderDetails = [],
                Items = await work.Get<ViwItem>().GetAll().ToDictionaryAsync(i => i.ItemId),
                ItemTypes = await work.Get<ViwItemType>().GetAll().ToListAsync(),
                TaxCodes = await work.Get<TaxCode>().GetAll().ToListAsync(),
            },
            ViewMode = viewMode,
            detail = orderDetail,
            Errors = e,
            FullItem = await work.Get<ViwFullItem>().Find(i => orderDetail != null && i.ItemId == orderDetail.ItemId).FirstOrDefaultAsync()
        });
    }
}
public class OrderDetailModifyModel
{
    public IEnumerable<OrderDetailSimpleView> OrderDetails { get; set; } = [];

    public Dictionary<string, ViwItem> Items { get; set; } = [];
    public Dictionary<string, string>? Errors { get; set; }
    public IEnumerable<ViwItemType> ItemTypes { get; set; } = [];
    public Dictionary<string, ViwFullItem>? FullItemMap { get; set; }
    public IEnumerable<TaxCode> TaxCodes { get; set; } = [];
}