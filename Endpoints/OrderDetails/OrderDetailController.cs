using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [HttpGet("Create/{OrderId}")]
    public async Task<IResult> GetNewRow(Guid OrderId)
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
            ViewMode = ViewMode.Create,
            detail = new OrderDetailSimpleView()
            {
                OrderId = OrderId
            }
        });
    }

    [HttpPost("Create")]
    public async Task<IResult> PostNew([FromForm] OrderDetailSimpleView orderDetailNew)
    {
        OrderDetail orderDetail = orderDetailNew.Adapt<OrderDetail>();
        orderDetail.Dump();
        await work.Get<OrderDetail>().AddAsync(orderDetail);
        return new RazorComponentResult(typeof(SS75Row), new
        {
            Model = new OrderDetailModifyModel
            {
                OrderDetails = [],
                Items = await work.Get<ViwItem>().GetAll().ToDictionaryAsync(i => i.ItemId),
                ItemTypes = await work.Get<ViwItemType>().GetAll().ToListAsync(),
                TaxCodes = await work.Get<TaxCode>().GetAll().ToListAsync()
            },
            ViewMode = ViewMode.Detail,
            detail = orderDetail.Adapt<OrderDetailSimpleView>()
        });
    }
    [HttpPost("Edit/{guid}")]
    public async Task<IResult> PostEdit([FromForm] OrderDetailSimpleView orderDetailNew, Guid guid)
    {
        await service.UpdateAsync(orderDetailNew, guid);
        return new RazorComponentResult(typeof(SS75Row), new
        {
            Model = new OrderDetailModifyModel
            {
                OrderDetails = [],
                Items = await work.Get<ViwItem>().GetAll().ToDictionaryAsync(i => i.ItemId),
                ItemTypes = await work.Get<ViwItemType>().GetAll().ToListAsync(),
                TaxCodes = await work.Get<TaxCode>().GetAll().ToListAsync()
            },
            ViewMode = ViewMode.Detail,
            detail = work.Get<OrderDetail>().Get<OrderDetailSimpleView>(guid)
        });
    }
    [HttpGet("Edit/{guid}")]
    public async Task<IResult> GetEdit(Guid guid)
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
            ViewMode = ViewMode.Edit,
            detail = work.Get<OrderDetail>().Get<OrderDetailSimpleView>(guid)
        });
    }
    [HttpGet("Detail/{guid}")]
    public async Task<IResult> GetDetailsAsync(Guid guid)
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
            ViewMode = ViewMode.Detail,
            detail = work.Get<OrderDetail>().Get<OrderDetailSimpleView>(guid)
        });
    }
}
public class OrderDetailModifyModel
{
    public IEnumerable<OrderDetailSimpleView> OrderDetails { get; set; } = [];

    public Dictionary<string, ViwItem> Items { get; set; } = [];

    public IEnumerable<ViwItemType> ItemTypes { get; set; } = [];

    public IEnumerable<TaxCode> TaxCodes { get; set; } = [];
}