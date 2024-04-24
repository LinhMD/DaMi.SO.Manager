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
using CrudApiTemplate.CustomBinding;
using System.Security.Claims;
using System.Web;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using DaMi.SO.Manager.Hubs;
using DaMi.SO.Manager.Endpoints.Notifications;

namespace DaMi.SO.Manager.Endpoints.OrderMasters;

[ApiController]
[Authorize]
[Route("[controller]")]
public class OrderMasterController(IUnitOfWork work, IServiceCrud<OrderMaster> service, DaMiSoManagerContext context, NotificationService notificationService) : ControllerBase
{
    [Authorize(policy: "ViewOrder")]
    [HttpGet]
    public async Task<IResult> GetAsync()
    {
        var orderMasters = await work.Get<OrderMaster>().GetAll<OrderMasterSimpleView>().OrderByDescending(f => f.OrderNo).ToListAsync();
        Dictionary<string, ViwCustomer> customer = await work.Get<ViwCustomer>().GetAll().ToDictionaryAsync(f => f.CustomerId);
        orderMasters.ForEach(m => m.CustomerId = customer[m.CustomerId].TradeName);
        return this.Page<IndexPage, OrderMasterTableModel>(new() { OrderMasters = orderMasters });
    }

    [Authorize(policy: "ViewOrder")]
    [HttpGet("Details/{guid}")]
    public async Task<IResult> GetDetailsAsync(Guid guid, [FromClaim(ClaimTypes.NameIdentifier)] string employeeID)
    {
        var orderMaster = await work.Get<OrderMaster>().Find<OrderMasterDetailView>(f => f.RowUniqueId == guid).FirstOrDefaultAsync();
        if (orderMaster is null)
        {
            return new RazorComponentResult(typeof(_404));
        }
        return await ReturnPage<DetailPage>(work, orderMaster, ViewMode.Detail);
    }

    [Authorize(policy: nameof(Permision.UpdateOrder))]
    [HttpGet("Edit/Customer")]
    public async Task<IResult> GetCustomerInfo([FromQuery] string CustomerIdSelect)
    {
        var customer = await work.Get<ViwCustomer>().Find(c => c.CustomerId == CustomerIdSelect).FirstOrDefaultAsync() ?? new ViwCustomer();
        return new RazorComponentResult(typeof(OOBCustomerInfo), new { customer });
    }

    [Authorize(policy: nameof(Permision.AddNewOrder))]
    [HttpGet("New")]
    public async Task<IResult> GetNew([FromClaim(ClaimTypes.NameIdentifier)] string? employeeID)
    {
        var orderMaster = new OrderMasterDetailView
        {
            OrderDate = DateTime.Now,
            OrderStatusId = "OS10", //Mới tạo
            CurrencyId = "VND",
            ExchangeRate = 1,
            SalesManId = employeeID
        };
        return await ReturnPage<CreatePage>(work, orderMaster, ViewMode.Create);
    }

    [Authorize(policy: nameof(Permision.AddNewOrder))]
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

    [Authorize(policy: nameof(Permision.UpdateOrder))]
    [HttpGet("Edit/{guid}")]
    public async Task<IResult> GetEditAsync(Guid guid)
    {
        var orderMaster = await work.Get<OrderMaster>().Find<OrderMasterDetailView>(f => f.RowUniqueId == guid).FirstOrDefaultAsync();
        if (orderMaster is null)
        {
            return new RazorComponentResult(typeof(_404));
        }

        if (orderMaster.OrderStatusId != "OS10")
        {
            return Results.BadRequest("Đơn hàng không được phép sửa");
        }
        return await ReturnPage<EditPage>(work, orderMaster, ViewMode.Edit);
    }

    [Authorize(policy: nameof(Permision.UpdateOrder))]
    [HttpPost("Edit/{guid}")]
    public async Task<IResult> EditAsync(Guid guid, [FromForm] OrderMasterDetailView editOrderMaster)
    {

        var orderMaster = await work.Get<OrderMaster>().GetAsync(guid);
        if (orderMaster is null)
        {
            return new RazorComponentResult(typeof(_404));
        }
        if (orderMaster.OrderStatusId != "OS10")
        {
            return Results.BadRequest("Đơn hàng không được phép sửa");
        }
        try
        {
            List<OrderDetail> orderDetails = await work.Get<OrderDetail>().Find(f => f.OrderId == guid).ToListAsync();
            await service.UpdateAsync(editOrderMaster, guid);
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
    [Authorize(policy: nameof(Permision.UpdateOrder))]
    [HttpGet("Delete/{guid}")]
    public async Task<IResult> Delete(Guid guid)
    {
        var orderMaster = await work.Get<OrderMaster>().Find(f => f.RowUniqueId == guid).FirstOrDefaultAsync();
        if (orderMaster is null)
        {
            return new RazorComponentResult(typeof(_404));
        }

        if (orderMaster.OrderStatusId != "OS10")
        {
            return Results.BadRequest("Đơn hàng không được phép xóa");
        }
        await work.Get<OrderMaster>().RemoveAsync(orderMaster);
        return Results.Redirect("/OrderMaster");
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
        orderMaster.TaxCode = customer?.TaxCode ?? string.Empty;
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
                ItemTypes = await work.Get<ViwItemType>().GetAll().ToListAsync(),
                TaxCodes = await work.Get<TaxCode>().Find(t => orderMaster.CustomerId == null || t.CustomerId == orderMaster.CustomerId).ToListAsync(),
                FullItemMap = await work.Get<ViwFullItem>().Find(f => orderMaster.OrderFormId == null || f.OrderFormId == orderMaster.OrderFormId).ToDictionaryAsync(i => i.ItemId),
            },
            ErrorMessage = ErrorMessage,
            ViewMode = viewMode,
            Errors = validateError
        });
    }

    [Authorize(policy: nameof(Permision.AcceptOrder))]
    [HttpGet("Accept/{guid}")]
    public async Task<IResult> Accept(Guid guid, [FromClaim(ClaimTypes.NameIdentifier)] string userId)
    {
        var orderMaster = await work.Get<OrderMaster>().Find(f => f.RowUniqueId == guid).FirstOrDefaultAsync();
        if (orderMaster is null)
            return new RazorComponentResult(typeof(_404));
        if (orderMaster.OrderStatusId != "OS10")
        {
            return Results.BadRequest("Đơn hàng không được phép duyệt");
        }

        orderMaster.AccepterId = userId;
        orderMaster.Accepted = true;
        orderMaster.AcceptedDate = DateTime.Now;

        var acceptStatus = await work.Get<OrderStatus>().Find(f => f.IsAcceptStatus).FirstOrDefaultAsync();
        if (acceptStatus is not null)
            orderMaster.OrderStatusId = acceptStatus.OrderStatusId;
        await work.CompleteAsync();
        await notificationService.Notify(orderMaster, $"Đơn Hàng {orderMaster.OrderNo} đã duyệt", "info");
        return Results.Redirect($"/OrderMaster/Details/{guid}");
    }

    [Authorize(policy: nameof(Permision.CancelOrder))]
    [HttpPost("Cancel/{guid}")]
    public async Task<IResult> Cancel(Guid guid, [FromForm] string? hxPrompt)
    {

        var orderMaster = await work.Get<OrderMaster>().Find(f => f.RowUniqueId == guid).FirstOrDefaultAsync();
        if (orderMaster is null)
            return new RazorComponentResult(typeof(_404));
        if (!Permision.AllowCancelStatus.Contains(orderMaster.OrderStatusId))
        {
            return Results.BadRequest("Đơn hàng không được phép hủy");
        }

        $"Lý do hủy: {hxPrompt}".Dump();
        orderMaster.Notes += $"Lý do hủy: {hxPrompt}";
        orderMaster.IsCancel = true;

        var cancelStatus = await work.Get<OrderStatus>().Find(f => f.IsCancelStatus).FirstOrDefaultAsync();
        if (cancelStatus is not null)
            orderMaster.OrderStatusId = cancelStatus.OrderStatusId;
        await work.CompleteAsync();

        await notificationService.Notify(orderMaster, $"Đơn Hàng {orderMaster.OrderNo} vừa hủy", "danger");
        Response.Headers.Append("hx-redirect", $"/OrderMaster/Details/{guid}");
        return Results.Ok();
    }

    [Authorize(policy: nameof(Permision.SuspendOrder))]
    [HttpPost("Suspend/{guid}")]
    public async Task<IResult> Suspend(Guid guid, [FromForm] string? hxPrompt)
    {
        var orderMaster = await work.Get<OrderMaster>().Find(f => f.RowUniqueId == guid).FirstOrDefaultAsync();
        if (orderMaster is null)
            return new RazorComponentResult(typeof(_404));
        if (!Permision.AllowCancelStatus.Contains(orderMaster.OrderStatusId))
        {
            return Results.BadRequest("Đơn hàng không được phép treo");
        }
        $"Lý do treo: {hxPrompt}".Dump();
        orderMaster.Notes += $"Lý do treo: {hxPrompt}";
        var suspendStatus = await work.Get<OrderStatus>().Find(f => f.IsSuspendStatus).FirstOrDefaultAsync();
        if (suspendStatus is not null)
            orderMaster.OrderStatusId = suspendStatus.OrderStatusId;
        await work.CompleteAsync();

        await notificationService.Notify(orderMaster, $"Đơn Hàng {orderMaster.OrderNo} vừa Treo/Tạm ngưng", "danger");
        Response.Headers.Append("hx-redirect", $"/OrderMaster/Details/{guid}");
        return Results.Ok();
    }

    [Authorize(policy: nameof(Permision.ChangeStatusOrder))]
    [HttpGet("Status/{guid}")]
    public async Task<IResult> Status(Guid guid, [FromQuery] string StatusID)
    {

        var orderMaster = await work.Get<OrderMaster>().IncludeAll().Include(f => f.OrderStatus).Where(f => f.RowUniqueId == guid).FirstOrDefaultAsync();
        if (orderMaster is null)
            return new RazorComponentResult(typeof(_404));
        var oldStatus = orderMaster.OrderStatus.OrderStatusName;
        var status = await work.Get<OrderStatus>().Find(f => f.CanChangeStatus || f.IsAcceptStatus).ToListAsync();

        if (!status.Select(f => f.OrderStatusId).Contains(orderMaster.OrderStatusId))
        {
            return Results.BadRequest("Đơn hàng không được phép đổi trạng thái");
        }
        if (!status.Where(f => !f.IsAcceptStatus).Select(f => f.OrderStatusId).Contains(StatusID))
        {
            return Results.BadRequest("Trạng thái không hợp lệ");
        }
        var orderStatus = status.FirstOrDefault(f => f.OrderStatusId == StatusID);
        orderMaster.IsCancel = true;
        orderMaster.CreatedDate = DateTime.Now;

        if (orderStatus is not null)
            orderMaster.OrderStatusId = orderStatus.OrderStatusId;
        await work.CompleteAsync();

        await notificationService.Notify(orderMaster, $"Đơn Hàng {orderMaster.OrderNo} vừa đổi trạng thái từ {oldStatus} sang {orderStatus?.OrderStatusName}", "warning");
        Response.Headers.Append("hx-redirect", $"/OrderMaster/Details/{guid}");
        return Results.Ok();
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

