using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BlazorMinimalApis.Lib.Helpers;
using BlazorMinimalApis.Lib.Validation;
using CrudApiTemplate.Repository;
using CrudApiTemplate.View;
using DaMi.SO.Manager.Components.Share;
using DaMi.SO.Manager.Data.Models;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Components.OrderMasters;
[ApiController]
[Route("[controller]")]
public class OrderMasterController(IUnitOfWork work) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAsync()
    {
        var orderMasters = await work.Get<OrderMaster>().GetAll<OrderMasterSimpleView>().ToListAsync();
        return this.Page<OrderMasterTablePage>(new ValidationResponse(), new OrderMasterTableModel() { OrderMasters = orderMasters });
    }

    [HttpGet("Details/{guid}")]
    public async Task<IResult> GetDetailsAsync(Guid guid)
    {
        var orderMaster = await work.Get<OrderMaster>().GetAsync<OrderMasterDetailView>(guid);

        if (orderMaster is null)
            return new RazorComponentResult(typeof(_404));

        return this.Page<OrderMasterDetailPage>(new ValidationResponse(), new OrderMasterDetailModel() { OrderMaster = orderMaster });
    }

}

public class OrderMasterDetailModel
{
    public OrderMasterDetailView OrderMaster { get; set; }
}


public class OrderMasterTableModel
{
    public IEnumerable<OrderMasterSimpleView> OrderMasters { get; set; } = [];
}

