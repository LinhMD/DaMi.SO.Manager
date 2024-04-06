using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [HttpGet("Create/{OrderId}")]
    public async Task<IResult> GetNewRow(Guid OrderId)
    {
        return await ReturnPage(work, new OrderDetailSimpleView() { OrderId = OrderId }, null, ViewMode.Create);
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
    public async Task<IResult> GetEdit(Guid guid)
    {
        return await ReturnPage(work, work.Get<OrderDetail>().Get<OrderDetailSimpleView>(guid), null, ViewMode.Edit);
    }

    [HttpPost("Edit/{guid}")]
    public async Task<IResult> PostEdit([FromForm] OrderDetailSimpleView orderDetailNew, Guid guid)
    {
        try
        {
            await service.UpdateAsync(orderDetailNew, guid);
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
                TaxCodes = await work.Get<TaxCode>().GetAll().ToListAsync()
            },
            ViewMode = viewMode,
            detail = orderDetail,
            Errors = e
        });
    }
}
public class OrderDetailModifyModel
{
    public IEnumerable<OrderDetailSimpleView> OrderDetails { get; set; } = [];

    public Dictionary<string, ViwItem> Items { get; set; } = [];
    public Dictionary<string, string>? Errors { get; set; }
    public IEnumerable<ViwItemType> ItemTypes { get; set; } = [];

    public IEnumerable<TaxCode> TaxCodes { get; set; } = [];
}