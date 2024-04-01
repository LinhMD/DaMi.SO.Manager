using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using BlazorMinimalApis.Lib.Helpers;
using BlazorMinimalApis.Lib.Validation;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Utilities;
using CrudApiTemplate.View;
using DaMi.SO.Manager.Components.Share;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Services.OrderMasterDTO;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace DaMi.SO.Manager.Components.OrderMasters;
[ApiController]
[Route("[controller]")]
public class OrderMasterController(IUnitOfWork work) : ControllerBase
{

    [HttpGet]
    public async Task<IResult> GetAsync()
    {
        var orderMasters = await work.Get<OrderMaster>().GetAll<OrderMasterSimpleView>().ToListAsync();
        return this.Page<IndexPage, OrderMasterTableModel>(new() { OrderMasters = orderMasters });
    }

    [HttpGet("Details/{guid}")]
    public async Task<IResult> GetDetailsAsync(Guid guid)
    {
        var orderMaster = await work.Get<OrderMaster>().GetAsync<OrderMasterDetailView>(guid);

        if (orderMaster is null)
            return new RazorComponentResult(typeof(_404));

        return this.Page<DetailPage, OrderMasterDetailModel>(new() { OrderMaster = orderMaster });
    }
    [HttpGet("Edit/Customer")]
    public async Task<IResult> GetCustomerInfo([FromQuery] string CustomerIdSelect)
    {

        var customer = await work.Get<ViwCustomer>().Find(c => c.CustomerId == CustomerIdSelect).FirstOrDefaultAsync() ?? new ViwCustomer();
        return new RazorComponentResult(typeof(OOBCustomerInfo), new { customer.TaxCode, customer.Phone });
    }

    [HttpGet("New")]
    public async Task<IResult> GetNew()
    {
        var orderMaster = new OrderMasterDetailView
        {
            OrderDate = DateTime.Now,
            OrderStatusId = "OS10", //Mới tạo
            CurrencyId = "VND",
            ExchangeRate = 1
            //TODO: mặc định current user
        };


        var orderTypes = await work.Get<OrderType>().GetAll().ToListAsync();
        var orderForms = await work.Get<OrderForm>().GetAll().ToListAsync();
        var customers = await work.Get<ViwCustomer>().GetAll().ToListAsync();
        var employees = await work.Get<Employee>().IncludeAll().Include(e => e.Department).ToListAsync();
        var currencies = await work.Get<Currency>().GetAll().ToListAsync();

        var paymentMethods = await work.Get<PaymentMethod>().GetAll().ToListAsync();
        var orderStatuses = await work.Get<OrderStatus>().GetAll().ToListAsync();
        return this.Page<CreatePage, OrderMasterEditModel>(new()
        {
            OrderMaster = orderMaster,
            OrderForms = orderForms,
            OrderTypes = orderTypes,
            Customers = customers,
            Employees = employees,
            Currencies = currencies,
            OrderStatuses = orderStatuses,
            PaymentMethods = paymentMethods
        });
    }
    [HttpPost("New")]
    public async Task<IResult> PostNew([FromForm] OrderMasterDetailView orderMasterCreate)
    {
        OrderMaster orderMaster = orderMasterCreate.Adapt<OrderMaster>();
        try
        {
            orderMaster.OrderStatusId = "OS10";
            await work.Get<OrderMaster>().AddAsync(orderMaster);
        }
        catch (Exception e)
        {
            var orderTypes = await work.Get<OrderType>().GetAll().ToListAsync();
            var orderForms = await work.Get<OrderForm>().GetAll().ToListAsync();
            var customers = await work.Get<ViwCustomer>().GetAll().ToListAsync();
            var employees = await work.Get<Employee>().IncludeAll().Include(e => e.Department).ToListAsync();
            var currencies = await work.Get<Currency>().GetAll().ToListAsync();
            var orderStatuses = await work.Get<OrderStatus>().GetAll().ToListAsync();

            var paymentMethods = await work.Get<PaymentMethod>().GetAll().ToListAsync();
            return this.Page<CreatePage, OrderMasterEditModel>(new()
            {
                OrderMaster = orderMasterCreate,
                OrderForms = orderForms,
                OrderTypes = orderTypes,
                Customers = customers,
                Employees = employees,
                Currencies = currencies,
                OrderStatuses = orderStatuses,
                PaymentMethods = paymentMethods
            });
        }
        return Results.Redirect("");
    }
    [HttpGet("Edit/{guid}")]
    public async Task<IResult> GetEditAsync(Guid guid)
    {
        var orderMaster = await work.Get<OrderMaster>().GetAsync<OrderMasterDetailView>(guid);

        if (orderMaster is null)
            return new RazorComponentResult(typeof(_404));

        var orderTypes = await work.Get<OrderType>().GetAll().ToListAsync();
        var orderForms = await work.Get<OrderForm>().GetAll().ToListAsync();
        var customers = await work.Get<ViwCustomer>().GetAll().ToListAsync();
        var employees = await work.Get<Employee>().IncludeAll().Include(e => e.Department).ToListAsync();
        var currencies = await work.Get<Currency>().GetAll().ToListAsync();
        var paymentMethods = await work.Get<PaymentMethod>().GetAll().ToListAsync();

        var customer = customers.FirstOrDefault(c => c.CustomerId == orderMaster.CustomerId);
        orderMaster.TaxCode = customer?.TaxCode ?? string.Empty;
        orderMaster.Phone = customer?.Phone ?? string.Empty;

        var orderStatuses = await work.Get<OrderStatus>().GetAll().ToListAsync();
        return this.Page<EditPage, OrderMasterEditModel>(new()
        {
            OrderMaster = orderMaster,
            OrderForms = orderForms,
            OrderTypes = orderTypes,
            Customers = customers,
            Employees = employees,
            Currencies = currencies,
            OrderStatuses = orderStatuses,
            PaymentMethods = paymentMethods
        });
    }

    [HttpPost("Edit/{guid}")]
    public async Task<IResult> EditAsync(Guid guid, [FromForm] OrderMasterDetailView orderMaster)
    {
        return new RazorComponentResult(typeof(_404));
    }
}

public class OrderMasterDetailModel
{
    public OrderMasterDetailView OrderMaster { get; set; }
}

public class OrderMasterEditModel
{
    public OrderMasterDetailView OrderMaster { get; set; }

    public IEnumerable<OrderType> OrderTypes { get; set; }
    public IEnumerable<OrderForm> OrderForms { get; set; }
    public IEnumerable<ViwCustomer> Customers { get; set; }
    public IEnumerable<Employee> Employees { get; set; }
    public IEnumerable<Currency> Currencies { get; set; }
    public IEnumerable<OrderStatus> OrderStatuses { get; set; }

    public IEnumerable<PaymentMethod> PaymentMethods { get; set; }
}


public class OrderMasterTableModel
{
    public IEnumerable<OrderMasterSimpleView> OrderMasters { get; set; } = [];
}

