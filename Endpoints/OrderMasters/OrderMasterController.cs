using CrudApiTemplate.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using DaMi.SO.Manager.Endpoints.Share;
using DaMi.SO.Manager.Endpoints.OrderMasters.DTO;
using DaMi.SO.Manager.Data.Models;
using Microsoft.EntityFrameworkCore;
using BlazorMinimalApis.Lib.Helpers;
using DaMi.SO.Manager.Endpoints.OrderMasters.Pages;
using Mapster;
using CrudApiTemplate.Utilities;
using Microsoft.AspNetCore.Authorization;
using DaMi.SO.Manager.Endpoints.OrderDetails;
using CrudApiTemplate.Services;
using CrudApiTemplate.CustomException;
using BlazorMinimalApis.Lib.Validation;
using BlazorMinimalApis.Lib.Views;
using DaMi.SO.Manager.Components;
using DaMi.SO.Manager.Data;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace DaMi.SO.Manager.Endpoints.OrderMasters;

[ApiController]
[Authorize]
[Route("[controller]")]
public class OrderMasterController(IUnitOfWork work, IServiceCrud<OrderMaster> service, DaMiSoManagerContext context) : ControllerBase
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
        var orderMaster = await work.Get<OrderMaster>().Find<OrderMasterDetailView>(f => f.RowUniqueId == guid).FirstOrDefaultAsync();

        if (orderMaster is null)
            return new RazorComponentResult(typeof(_404));


        return await ReturnPage<DetailPage>(work, orderMaster, ViewMode.Detail);
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
        return await ReturnPage<CreatePage>(work, orderMaster, ViewMode.Create);
    }
    [HttpPost("New")]
    public async Task<IResult> PostNew([FromForm] OrderMasterDetailView orderMasterCreate)
    {
        OrderMaster orderMaster = orderMasterCreate.Adapt<OrderMaster>();
        try
        {
            var SubCompanyID = new SqlParameter
            {
                ParameterName = "SubCompanyID",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 20,
                Value = "MAIN",
            };
            var OrderDate = new SqlParameter
            {
                ParameterName = "OrderDate",
                SqlDbType = System.Data.SqlDbType.Date,
                Value = orderMaster.OrderDate,
            };
            var OrderNo = new SqlParameter
            {
                ParameterName = "@OrderNo",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Output,
                Size = 20
            };
            var SeqInMonth = new SqlParameter
            {
                ParameterName = "@SeqInMonth",
                SqlDbType = System.Data.SqlDbType.BigInt,
                Direction = System.Data.ParameterDirection.Output
            };
            context.Database.ExecuteSqlRaw("EXECUTE [dbo].[spGetNewOrderNo] @SubCompanyID, @OrderDate, @OrderNo OUTPUT, @SeqInMonth OUTPUT",
                SubCompanyID,
                OrderDate,
                OrderNo,
                SeqInMonth
            );

            orderMaster.OrderStatusId = "OS10";
            orderMaster.OrderNo = (string)OrderNo.Value;
            orderMaster.SeqInMonth = (long)SeqInMonth.Value;
            Validation.Validate(orderMaster);
            await work.Get<OrderMaster>().AddAsync(orderMaster);
            return Results.Redirect($"/OrderMaster/Edit/{orderMaster.RowUniqueId}");
        }
        catch (ModelValueInvalidException e)
        {
            return await ReturnPage<CreatePage>(work, orderMasterCreate, ViewMode.Create, e.MemberErrors);
        }
        catch (Exception e)
        {
            e.Dump();
            return await ReturnPage<CreatePage>(work, orderMasterCreate, ViewMode.Create, null, $"Create Error: {e.Message}");
        }
    }

    [HttpGet("Edit/{guid}")]
    public async Task<IResult> GetEditAsync(Guid guid)
    {
        var orderMaster = await work.Get<OrderMaster>().Find<OrderMasterDetailView>(f => f.RowUniqueId == guid).FirstOrDefaultAsync();

        if (orderMaster is null)
            return new RazorComponentResult(typeof(_404));

        return await ReturnPage<EditPage>(work, orderMaster, ViewMode.Edit);
    }

    [HttpPost("Edit/{guid}")]
    public async Task<IResult> EditAsync(Guid guid, [FromForm] OrderMasterDetailView orderMaster)
    {
        try
        {
            List<OrderDetail> orderDetails = await work.Get<OrderDetail>().Find(f => f.OrderId == guid).ToListAsync();
            orderMaster.TotalAmount = orderDetails.Select(x => Convert.ToDecimal(x.ConvertPrice * x.Quantity)).Sum();
            orderMaster.ConvertTaxAmount = orderDetails.Select(x => x.ConvertTaxAmount).Sum();
            orderMaster.ConvertDiscAmount = orderDetails.Select(x => x.ConvertDiscAmount).Sum();
            orderMaster.ConvertTotalAmount = orderMaster.ConvertTotalAmount + orderMaster.ConvertTaxAmount - orderMaster.ConvertDiscAmount;
            Console.WriteLine(orderMaster);
            OrderMaster save = await service.UpdateAsync(orderMaster, guid);
            return await Task.FromResult(Results.Redirect($"/OrderMaster/Details/{guid}"));
        }
        catch (ModelValueInvalidException e)
        {
            return await ReturnPage<EditPage>(work, work.Get<OrderMaster>().Find<OrderMasterDetailView>(f => f.RowUniqueId == guid).FirstOrDefault()!, ViewMode.Edit, e.MemberErrors);
        }
        catch (Exception e)
        {
            e.Dump();
            return await ReturnPage<EditPage>(work, work.Get<OrderMaster>().Find<OrderMasterDetailView>(f => f.RowUniqueId == guid).FirstOrDefault()!, ViewMode.Edit, null, $"Edit Error: {e.Message}");
        }

    }

    private async Task<IResult> ReturnPage<TPage>(IUnitOfWork work, OrderMasterDetailView orderMaster, ViewMode viewMode = ViewMode.Detail, Dictionary<string, string>? validateError = null, string? ErrorMessage = null) where TPage : XComponent<OrderMasterEditModel>
    {
        var orderTypes = await work.Get<OrderType>().GetAll().ToListAsync();
        var orderForms = await work.Get<OrderForm>().GetAll().ToListAsync();
        var customers = await work.Get<ViwCustomer>().GetAll().ToListAsync();
        var employees = await work.Get<Employee>().IncludeAll().Include(e => e.Department).ToListAsync();
        var currencies = await work.Get<Currency>().GetAll().ToListAsync();
        var paymentMethods = await work.Get<PaymentMethod>().GetAll().ToListAsync();

        var customer = customers.FirstOrDefault(c => c.CustomerId == orderMaster.CustomerId);
        orderMaster.Phone = customer?.Phone ?? string.Empty;

        var orderStatuses = await work.Get<OrderStatus>().GetAll().ToListAsync();
        return this.Page<TPage, OrderMasterEditModel>(new OrderMasterEditModel()
        {
            OrderMaster = orderMaster,
            OrderForms = orderForms,
            OrderTypes = orderTypes,
            Customers = customers,
            Employees = employees,
            Currencies = currencies,
            OrderStatuses = orderStatuses,
            PaymentMethods = paymentMethods,
            OrderDetailModify = new OrderDetailModifyModel()
            {
                OrderDetails = orderMaster.OrderDetails,
                Items = await work.Get<ViwItem>().GetAll().ToDictionaryAsync(i => i.ItemId),
                ItemTypes = await work.Get<ViwItemType>().GetAll().ToListAsync(),
                TaxCodes = await work.Get<TaxCode>().GetAll().ToListAsync(),

                FullItemMap = await work.Get<ViwFullItem>().GetAll().ToDictionaryAsync(i => i.ItemId),
            },
            ErrorMessage = ErrorMessage,
            ViewMode = viewMode,
            Errors = validateError
        });
    }
}

public class OrderMasterDetailModel
{
    public OrderMasterDetailView OrderMaster { get; set; } = null!;
}

public class OrderMasterEditModel
{
    public OrderDetailModifyModel OrderDetailModify { get; set; } = null!;
    public OrderMasterDetailView OrderMaster { get; set; } = null!;

    public IEnumerable<OrderType> OrderTypes { get; set; } = [];
    public IEnumerable<OrderForm> OrderForms { get; set; } = [];
    public IEnumerable<ViwCustomer> Customers { get; set; } = [];
    public IEnumerable<Employee> Employees { get; set; } = [];
    public IEnumerable<Currency> Currencies { get; set; } = [];
    public IEnumerable<OrderStatus> OrderStatuses { get; set; } = [];
    public IEnumerable<PaymentMethod> PaymentMethods { get; set; } = [];
    public ViewMode ViewMode { get; set; } = ViewMode.Detail;
    public string? ErrorMessage { get; set; }

    public Dictionary<string, string>? Errors { get; set; }
}


public class OrderMasterTableModel
{
    public IEnumerable<OrderMasterSimpleView> OrderMasters { get; set; } = [];
}

