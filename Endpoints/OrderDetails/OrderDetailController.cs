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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Endpoints.OrderDetails;

[Authorize]
[ApiController]
[Route("[controller]")]
public class OrderDetailController(IUnitOfWork work, IServiceCrud<OrderDetail> service) : ControllerBase
{

    [Authorize(policy: "ViewOrder")]
    [HttpGet("Detail/{guid}")]
    public async Task<IResult> GetDetailsAsync(Guid guid, [FromQuery] string? FormID)
    {
        OrderForm orderForm = await work.Get<OrderForm>().Find(f => f.OrderFormId == FormID).FirstOrDefaultAsync() ?? new OrderForm();
        return await ReturnPage(work, work.Get<OrderDetail>().Get<OrderDetailSimpleView>(guid), orderForm, null, ViewMode.Detail);
    }

    [Authorize(policy: nameof(Permision.AddNewOrder))]
    [HttpGet("Create")]
    public async Task<IResult> GetNewRow([FromQuery] Guid OrderId, [FromQuery] string? ItemIdSelect, [FromQuery] string? FormID)
    {
        OrderMaster? orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Where(f => f.RowUniqueId == OrderId).FirstOrDefaultAsync();
        OrderForm orderForm = await work.Get<OrderForm>().Find(f => f.OrderFormId == FormID).FirstOrDefaultAsync() ?? new OrderForm();
        return await ReturnPage(work, new OrderDetailSimpleView() { OrderId = OrderId, ItemId = ItemIdSelect }, orderForm, null, ViewMode.Create, orderMaster?.CustomerId);
    }

    [Authorize(policy: nameof(Permision.AddNewOrder))]
    [HttpPost("Create")]
    public async Task<IResult> PostNew([FromForm] OrderDetailSimpleView orderDetailNew)
    {
        OrderMaster? orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Where(f => f.RowUniqueId == orderDetailNew.OrderId!).FirstOrDefaultAsync();
        OrderForm orderForm = await work.Get<OrderForm>().Find(f => orderMaster != null && f.OrderFormId == orderMaster.OrderFormId).FirstOrDefaultAsync() ?? new OrderForm();
        try
        {
            OrderDetail orderDetail = orderDetailNew.Adapt<OrderDetail>();
            orderDetail.Dump();
            await work.Get<OrderDetail>().AddAsync(orderDetail);
            return await ReturnPage(work, work.Get<OrderDetail>().Get<OrderDetailSimpleView>(orderDetail.RowUniqueId), orderForm, null, ViewMode.Detail, orderMaster?.CustomerId);
        }
        catch (ModelValueInvalidException e)
        {
            return await ReturnPage(work, null, orderForm, e.MemberErrors, ViewMode.Create, orderMaster?.CustomerId);
        }
    }

    [Authorize(policy: nameof(Permision.UpdateOrder))]
    [HttpGet("Edit/{guid}")]
    public async Task<IResult> GetEdit(Guid guid, [FromQuery] string? ItemIdSelect, [FromQuery] string? FormID)
    {
        OrderDetailSimpleView? orderDetail = await work.Get<OrderDetail>().GetAsync<OrderDetailSimpleView>(guid);

        OrderMaster? orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Where(f => orderDetail != null && f.RowUniqueId == orderDetail.OrderId).FirstOrDefaultAsync();
        ViwItem? item = await work.Get<ViwItem>().Find(x => x.ItemId == ItemIdSelect).FirstOrDefaultAsync();
        if (item is not null && orderDetail is not null)
        {
            orderDetail.ItemId = item.ItemId;
            orderDetail.ConvertPrice = item.ConvertPrice;
            orderDetail.TaxRate = item.TaxRate;
        }

        OrderForm orderForm = await work.Get<OrderForm>().Find(f => f.OrderFormId == FormID).FirstOrDefaultAsync() ?? new OrderForm();
        return await ReturnPage(work, orderDetail, orderForm, null, ViewMode.Edit, orderMaster?.CustomerId);
    }

    [Authorize(policy: nameof(Permision.UpdateOrder))]
    [HttpPost("Edit/{guid}")]
    public async Task<IResult> PostEdit([FromForm] OrderDetailSimpleView orderDetailNew, Guid guid)
    {

        OrderMaster? orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderDetails).Where(f => f.RowUniqueId == orderDetailNew.OrderId!).FirstOrDefaultAsync();
        OrderForm orderForm = await work.Get<OrderForm>().Find(f => orderMaster != null && f.OrderFormId == orderMaster.OrderFormId).FirstOrDefaultAsync() ?? new OrderForm();
        try
        {
            ViwItem? item = await work.Get<ViwItem>().Find(f => f.ItemId == orderDetailNew.ItemId).FirstOrDefaultAsync();
            if (item is not null)
            {
                orderDetailNew.ConvertPrice = item.ConvertPrice;
                orderDetailNew.TaxRate = item.TaxRate;
            }
            await service.UpdateAsync(orderDetailNew, guid);
            if (orderMaster != null)
            {
                orderMaster.ConvertDiscAmount = orderMaster.OrderDetails.Select(f => f.ConvertDiscAmount).Sum();
                orderMaster.ConvertTaxAmount = orderMaster.OrderDetails.Select(f => f.ConvertTaxAmount).Sum();
                orderMaster.ConvertTotalAmount = orderMaster.OrderDetails.Select(f => f.ConvertAmount + f.ConvertTaxAmount - f.ConvertDiscAmount).Sum();
                await work.CompleteAsync();
            }
            return await ReturnPage(work, work.Get<OrderDetail>().Get<OrderDetailSimpleView>(guid), orderForm, null, ViewMode.Detail, orderMaster?.CustomerId);
        }
        catch (ModelValueInvalidException e)
        {
            OrderDetailSimpleView? orderDetailSimpleView = await work.Get<OrderDetail>().GetAsync<OrderDetailSimpleView>(guid);
            return await ReturnPage(work, orderDetailSimpleView, orderForm, e.MemberErrors, ViewMode.Edit, orderMaster?.CustomerId);
        }
    }

    private static async Task<IResult> ReturnPage(IUnitOfWork work, OrderDetailSimpleView? orderDetail, OrderForm form, Dictionary<string, string>? e = null, ViewMode viewMode = ViewMode.Detail, string? customerId = null)
    {
        Dictionary<string, ViwFullItem> fullItems = await work.Get<ViwFullItem>().Find(f => f.OrderFormId == form.OrderFormId).ToDictionaryAsync(f => f.ItemId);
        return new RazorComponentResult(typeof(OrderDetailRow), new
        {
            Model = new OrderDetailModifyModel
            {
                OrderDetails = [],
                ItemTypes = await work.Get<ViwItemType>().GetAll().ToListAsync(),
                TaxCodes = await work.Get<TaxCode>().Find(t => t.CustomerId == customerId).ToListAsync(),
                FullItemMap = fullItems
            },
            ViewMode = viewMode,
            detail = orderDetail,
            Errors = e,
            FullItem = fullItems.ContainsKey(orderDetail?.ItemId ?? "") ? fullItems[orderDetail?.ItemId ?? ""] : new ViwFullItem(),
            Form = form
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