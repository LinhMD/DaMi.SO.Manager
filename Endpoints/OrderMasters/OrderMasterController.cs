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

namespace DaMi.SO.Manager.Endpoints.OrderMasters;

[ApiController]
[Authorize]
[Route("[controller]")]
public class OrderMasterController(IUnitOfWork work, IServiceCrud<OrderMaster> service) : ControllerBase
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

        var customer = await work.Get<ViwCustomer>().Find(c => c.CustomerId == orderMaster.CustomerId).FirstOrDefaultAsync() ?? new ViwCustomer();
        orderMaster.TaxCode = customer.TaxCode;
        orderMaster.Phone = customer.Phone;
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
        return await ReturnPage<CreatePage>(work, orderMaster);
    }
    [HttpPost("New")]
    public async Task<IResult> PostNew([FromForm] OrderMasterDetailView orderMasterCreate)
    {
        OrderMaster orderMaster = orderMasterCreate.Adapt<OrderMaster>();

        var validateError = default(Dictionary<string, string>);
        string? ErrorMessage = null;
        try
        {
            orderMaster.OrderStatusId = "OS10";
            await work.Get<OrderMaster>().AddAsync(orderMaster);
            return Results.Redirect($"/OrderMaster/Edit/{orderMaster.RowUniqueId}");
        }
        catch (ModelValueInvalidException e)
        {
            validateError = e.MemberErrors;
        }
        catch (DbUpdateException ex)
        {
            ErrorMessage = ex.Message;
        }

        return await ReturnPage<CreatePage>(work, orderMasterCreate, ViewMode.Create, validateError, ErrorMessage);
    }

    [HttpGet("Edit/{guid}")]
    public async Task<IResult> GetEditAsync(Guid guid)
    {
        var orderMaster = await work.Get<OrderMaster>().Find<OrderMasterDetailView>(f => f.RowUniqueId == guid).FirstOrDefaultAsync();

        if (orderMaster is null)
            return new RazorComponentResult(typeof(_404));

        return await ReturnPage<EditPage>(work, orderMaster);
    }

    [HttpPost("Edit/{guid}")]
    public async Task<IResult> EditAsync(Guid guid, [FromForm] OrderMasterDetailView orderMaster)
    {
        var validateError = default(Dictionary<string, string>);
        string? ErrorMessage = null;
        try
        {
            await service.UpdateAsync(orderMaster);
            return await Task.FromResult(Results.Redirect($"/OrderMaster/Detail/{guid}"));
        }
        catch (ModelValueInvalidException e)
        {
            validateError = e.MemberErrors;
        }
        catch (DbUpdateException ex)
        {
            ErrorMessage = ex.Message;
        }

        return await ReturnPage<EditPage>(work, orderMaster, ViewMode.Edit, validateError, ErrorMessage);
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
                TaxCodes = await work.Get<TaxCode>().GetAll().ToListAsync()
            },
            ErrorMessage = ErrorMessage,
            ViewMode = viewMode

        }, validation: new ValidationResponse()
        {
            Errors = validateError?.Select(f => f.Adapt<ValidationError>()).ToList() ?? [],
            HasErrors = validateError is not null
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

