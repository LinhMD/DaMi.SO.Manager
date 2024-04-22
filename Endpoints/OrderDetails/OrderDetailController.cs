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
using DaMi.Shared;
using DaMi.SO.Manager.Components;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Endpoints.OrderDetails.DTO;
using DaMi.SO.Manager.Endpoints.OrderDetails.Pages;
using DaMi.SO.Manager.Endpoints.OrderMasters.DTO;
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
        var taxCode = await work.Get<ViwCustomer>().Find(c => c.CustomerId == orderMaster!.CustomerId).Select(c => c.TaxCode).FirstOrDefaultAsync();
        var orderDetailSimpleView = new OrderDetailSimpleView()
        {
            OrderId = OrderId,
            ItemId = ItemIdSelect,
            CurrencyId = orderMaster!.CurrencyId,
            ExchangeRate = orderMaster!.ExchangeRate,
            TaxCode = Utils.TaxCodeIsValid(taxCode) ? taxCode : null,
            Quantity = 1,
        };
        var item = await work.Get<ViwFullItem>().Find(f => f.ItemId == ItemIdSelect).FirstOrDefaultAsync();
        if (item is not null)
        {

            orderDetailSimpleView.ItemId = item.ItemId;
            orderDetailSimpleView.OriginalPrice = item.OriginalPrice;
            orderDetailSimpleView.ConvertPrice = item.ConvertPrice;
            orderDetailSimpleView.TaxRate = item.TaxRate;
            if (item.DefNumOfMonth > 0)
            {
                orderDetailSimpleView.StartDate = DateTime.Now;
            }
        }
        return await ReturnPage(work, orderDetailSimpleView, orderMaster, null, ViewMode.Create);
    }

    [Authorize(policy: nameof(Permision.AddNewOrder))]
    [HttpPost("Create")]
    public async Task<IResult> PostNew([FromForm] OrderDetailSimpleView orderDetailNew)
    {
        try
        {
            var item = await work.Get<ViwItem>().Find(x => x.ItemId == orderDetailNew.ItemId).FirstOrDefaultAsync();
            if (item is not null)
            {
                orderDetailNew.TaxRate = item.TaxRate;
            }

            OrderDetail orderDetail = orderDetailNew.Adapt<OrderDetail>();
            await work.Get<OrderDetail>().AddAsync(orderDetail);
            var orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Include(o => o.OrderForm).Where(f => f.RowUniqueId == orderDetail.OrderId!).FirstOrDefaultAsync();
            await ReCalculateMasterAmount(work, orderMaster!);
            return await ReturnPage(work, work.Get<OrderDetail>().Get<OrderDetailSimpleView>(orderDetail.RowUniqueId), orderMaster, null, ViewMode.Detail);
        }
        catch (ModelValueInvalidException e)
        {
            var orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Include(o => o.OrderForm).Where(f => f.RowUniqueId == orderDetailNew.OrderId!).FirstOrDefaultAsync();

            return await ReturnPage(work, null, orderMaster, e.MemberErrors, ViewMode.Create);
        }
    }

    [Authorize(policy: nameof(Permision.UpdateOrder))]
    [HttpGet("Edit/{guid}")]
    public async Task<IResult> GetEdit(Guid guid, [FromQuery] string? ItemIdSelect)
    {
        var orderDetail = await work.Get<OrderDetail>().GetAsync<OrderDetailSimpleView>(guid);
        var item = await work.Get<ViwItem>().Find(x => x.ItemId == ItemIdSelect).FirstOrDefaultAsync();
        if (item is not null && orderDetail is not null)
        {
            orderDetail.ItemId = item.ItemId;
            orderDetail.OriginalPrice = item.OriginalPrice;
            orderDetail.ConvertPrice = item.ConvertPrice;
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
            var orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Include(o => o.OrderForm).Where(f => f.RowUniqueId == orderDetail.OrderId!).FirstOrDefaultAsync();
            await ReCalculateMasterAmount(work, orderMaster!);
            return await ReturnPage(work, await work.Get<OrderDetail>().GetAsync<OrderDetailSimpleView>(guid), orderMaster, null, ViewMode.Detail);
        }
        catch (ModelValueInvalidException e)
        {
            var orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Include(o => o.OrderForm).Where(f => f.RowUniqueId == orderDetail.OrderId!).FirstOrDefaultAsync();

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
        orderMaster.ConvertDiscAmount = orderMaster.OrderDetails.Select(f => f.ConvertDiscAmount).Sum();
        orderMaster.ConvertTaxAmount = orderMaster.OrderDetails.Select(f => f.ConvertTaxAmount).Sum();
        orderMaster.ConvertTotalAmount = orderMaster.OrderDetails.Select(f => f.ConvertTotalAmount).Sum();
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
            Order = orderMaster.Adapt<OrderMasterDetailView>()
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