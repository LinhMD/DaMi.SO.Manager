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
using DaMi.SO.Manager.Endpoints.Share;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Endpoints.OrderDetails;

[Authorize]
[ApiController]
[Route("[controller]")]
public class OrderDetailController(IUnitOfWork work) : ControllerBase
{

    [Authorize(policy: "ViewOrder")]
    [HttpGet("Detail/{guid}")]
    public async Task<IResult> GetDetailsAsync(Guid guid)
    {
        var orderDetail = await work.Get<OrderDetail>().GetAsync<OrderDetailSimpleView>(guid);
        if (orderDetail == null)
        {
            return Results.NotFound();
        }
        var orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(o => o.OrderForm)
            .Where(f => f.RowUniqueId == orderDetail.OrderId).FirstOrDefaultAsync();
        return await ReturnPage(work, orderDetail, orderMaster, null, ViewMode.Detail);
    }

    [Authorize(policy: nameof(Permision.AddNewOrder))]
    [HttpGet("Create")]
    public async Task<IResult> GetNewRow([FromQuery] Guid OrderId, [FromQuery] string? ItemIdSelect)
    {
        var orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Include(o => o.OrderForm)
            .Where(f => f.RowUniqueId == OrderId!).FirstOrDefaultAsync();
        var orderDetailSimpleView = new OrderDetailSimpleView()
        {
            OrderId = OrderId,
            ItemId = ItemIdSelect,
            CurrencyId = orderMaster!.CurrencyId,
            ExchangeRate = orderMaster!.ExchangeRate
        };
        if (ItemIdSelect is null)
        {
            orderDetailSimpleView.ItemId = await work.Get<ViwFullItem>().Find(f => f.OrderFormId == orderMaster!.OrderFormId).Select(f => f.ItemId).FirstOrDefaultAsync();
        }
        return await ReturnPage(work, orderDetailSimpleView, orderMaster, null, ViewMode.Create);
    }

    [Authorize(policy: nameof(Permision.AddNewOrder))]
    [HttpPost("Create")]
    public async Task<IResult> PostNew([FromForm] OrderDetailSimpleView orderDetailNew)
    {
        var orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Include(o => o.OrderForm).Where(f => f.RowUniqueId == orderDetailNew.OrderId!).FirstOrDefaultAsync();
        if (orderDetailNew.DiscountPercent > 0 && (orderDetailNew.OriginalDiscAmount == 0 || orderDetailNew.OriginalDiscAmount is null))
        {
            orderDetailNew.OriginalDiscAmount = orderDetailNew.OriginalAmount * Convert.ToDecimal(orderDetailNew.DiscountPercent) / 100;
        }
        try
        {
            OrderDetail orderDetail = orderDetailNew.Adapt<OrderDetail>();
            orderDetail.Dump();
            await work.Get<OrderDetail>().AddAsync(orderDetail);
            await ReCalculateMasterAmount(work, orderMaster!);
            return await ReturnPage(work, work.Get<OrderDetail>().Get<OrderDetailSimpleView>(orderDetail.RowUniqueId), orderMaster, null, ViewMode.Detail);
        }
        catch (ModelValueInvalidException e)
        {
            return await ReturnPage(work, null, orderMaster, e.MemberErrors, ViewMode.Create);
        }
    }

    [Authorize(policy: nameof(Permision.UpdateOrder))]
    [HttpGet("Edit/{guid}")]
    public async Task<IResult> GetEdit(Guid guid, [FromQuery] string? ItemIdSelect, [FromQuery] string? FormID)
    {
        var orderDetail = await work.Get<OrderDetail>().GetAsync<OrderDetailSimpleView>(guid);
        var item = await work.Get<ViwItem>().Find(x => x.ItemId == ItemIdSelect).FirstOrDefaultAsync();
        if (item is not null && orderDetail is not null)
        {
            orderDetail.ItemId = item.ItemId;
            orderDetail.OriginalPrice = item.OriginalPrice;
            orderDetail.TaxRate = item.TaxRate;
        }
        var orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(o => o.OrderForm).Where(f => f.RowUniqueId == orderDetail!.OrderId).FirstOrDefaultAsync();
        return await ReturnPage(work, orderDetail, orderMaster, null, ViewMode.Edit);
    }

    [Authorize(policy: nameof(Permision.UpdateOrder))]
    [HttpPost("Edit/{guid}")]
    public async Task<IResult> PostEdit([FromForm] OrderDetailSimpleView orderDetail, Guid guid)
    {
        if (orderDetail.DiscountPercent > 0 && (orderDetail.OriginalDiscAmount == 0 || orderDetail.OriginalDiscAmount is null))
        {
            orderDetail.OriginalDiscAmount = orderDetail.OriginalAmount * Convert.ToDecimal(orderDetail.DiscountPercent) / 100;
        }
        var orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Include(o => o.OrderForm).Where(f => f.RowUniqueId == orderDetail.OrderId!).FirstOrDefaultAsync();
        try
        {
            var item = await work.Get<ViwItem>().Find(f => f.ItemId == orderDetail.ItemId).FirstOrDefaultAsync();
            if (item is not null)
            {
                orderDetail.TaxRate = item.TaxRate;
            }
            OrderDetail? update = await work.Get<OrderDetail>().GetAsync(guid);
            orderDetail.Adapt(update);
            await work.CompleteAsync();
            await ReCalculateMasterAmount(work, orderMaster!);
            return await ReturnPage(work, await work.Get<OrderDetail>().GetAsync<OrderDetailSimpleView>(guid), orderMaster, null, ViewMode.Detail);
        }
        catch (ModelValueInvalidException e)
        {
            OrderDetailSimpleView? orderDetailSimpleView = await work.Get<OrderDetail>().GetAsync<OrderDetailSimpleView>(guid);
            return await ReturnPage(work, orderDetailSimpleView, orderMaster, e.MemberErrors, ViewMode.Edit);
        }
    }

    [Authorize(policy: nameof(Permision.DeleteOrder))]
    [HttpDelete("{guid}")]
    public async Task<IResult> Delete(Guid guid)
    {
        var orderDetail = await work.Get<OrderDetail>().GetAsync(guid);
        if (orderDetail is not null)
        {
            await work.Get<OrderDetail>().RemoveAsync(orderDetail);
            var orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Where(f => f.RowUniqueId == orderDetail.OrderId!).FirstOrDefaultAsync();
            await ReCalculateMasterAmount(work, orderMaster!);
            return new RazorComponentResult(typeof(Empty));
        }
        return Results.NotFound();
    }

    private static async Task ReCalculateMasterAmount(IUnitOfWork work, OrderMaster orderMaster)
    {
        orderMaster.OriginalDiscAmount = orderMaster.OrderDetails.Select(f => f.OriginalDiscAmount).Sum();
        orderMaster.OriginalTaxAmount = orderMaster.OrderDetails.Select(f => f.OriginalTaxAmount).Sum();
        orderMaster.OriginalTotalAmount = orderMaster.OrderDetails.Select(f => f.OriginalTotalAmount).Sum();
        orderMaster.ConvertDiscAmount = orderMaster.OriginalTotalAmount * orderMaster.ExchangeRate;
        orderMaster.ConvertTaxAmount = orderMaster.OriginalTaxAmount * orderMaster.ExchangeRate;
        orderMaster.ConvertTotalAmount = orderMaster.OriginalTotalAmount * orderMaster.ExchangeRate;
        await work.CompleteAsync();
    }

    private static async Task<IResult> ReturnPage(IUnitOfWork work, OrderDetailSimpleView? orderDetail,
        OrderMaster? orderMaster, Dictionary<string, string>? e = null, ViewMode viewMode = ViewMode.Detail)
    {
        Dictionary<string, ViwFullItem> fullItems = await work.Get<ViwFullItem>().Find(f => orderMaster != null && f.OrderFormId == orderMaster.OrderFormId).ToDictionaryAsync(f => f.ItemId);
        return new RazorComponentResult(typeof(OrderDetailRow), new
        {
            Model = new OrderDetailModifyModel
            {
                OrderDetails = [],
                ItemTypes = await work.Get<ViwItemType>().GetAll().ToListAsync(),
                TaxCodes = await work.Get<TaxCode>().Find(t => t.CustomerId == orderMaster!.CustomerId).ToListAsync(),
                FullItemMap = fullItems
            },
            ViewMode = viewMode,
            detail = orderDetail,
            Errors = e,
            FullItem = fullItems.ContainsKey(orderDetail?.ItemId ?? "") ? fullItems[orderDetail?.ItemId ?? ""] : new ViwFullItem(),
            Form = orderMaster?.OrderForm,
            Order = orderMaster
        });
    }

}
public class OrderDetailModifyModel
{
    public IEnumerable<OrderDetailSimpleView> OrderDetails { get; set; } = [];
    public Dictionary<string, string>? Errors { get; set; }
    public IEnumerable<ViwItemType> ItemTypes { get; set; } = [];
    public Dictionary<string, ViwFullItem> FullItemMap { get; set; } = new();
    public IEnumerable<TaxCode> TaxCodes { get; set; } = [];
}