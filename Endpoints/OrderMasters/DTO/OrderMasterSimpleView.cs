using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Endpoints.OrderStatuses.DTO;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace DaMi.SO.Manager.Endpoints.OrderMasters.DTO;

public class OrderMasterSimpleView : IView<OrderMaster>
{

    [HiddenInput]
    public Guid RowUniqueId { get; set; }

    [HiddenInput]
    [DisplayName("Số đơn hàng")]
    public string? OrderNo { get; set; }

    [DataType(DataType.Date)]
    [DisplayName("Ngày ĐH")]
    public DateTime OrderDate { get; set; }

    [DisplayName("Khách hàng")]
    public string CustomerId { get; set; } = null!;

    [DisplayName("Trạng thái")]
    public string OrderStatusName { get; set; } = null!;

    [HiddenInput]
    public OrderStatusSView OrderStatus { get; set; } = null!;

    [DisplayName("NV triển khai")]
    public string ExecutorName { get; set; } = null!;

    [DataType(DataType.Date)]
    [DisplayName("Ngày triển khai")]
    public DateTime? BeginExecDate { get; set; }

    [DisplayName("Kiểu đơn hàng")]
    public string OrderForm { get; set; } = string.Empty;
    [HiddenInput]
    [DisplayName("Tên sản phẩm")]
    public string ItemNames { get; set; } = null!;

    [HiddenInput]
    [DisplayName("Số máy")]
    public int NumOfPC { get; set; }

    [HiddenInput]
    [DisplayName("Số hệ thống")]
    public int NumOfData { get; set; }

    [HiddenInput]
    [DisplayName("Số MST")]
    public int NumOfTaxCode { get; set; }

    [HiddenInput]
    [DisplayName("Số hóa đơn")]
    public int NumOfInv { get; set; }

    [HiddenInput]
    [DisplayName("Số User")]
    public int NumOfUser { get; set; }

    [HiddenInput]
    [DisplayName("Số iCloudData")]
    public int NoICloudData { get; set; }

    [DisplayName("Thành tiền thực")]
    [DataType(DataType.Currency)]
    public decimal OriginalTotalAmount { get; set; }

    [DataType(DataType.Currency)]
    [DisplayName("Số tiền đã thu")]
    public decimal CollectAmount { get; set; }

    [DisplayName("Có xuất HĐ")]
    public bool HasInvoiceVat { get; set; }

    [DisplayName("Đã xuất HĐ")]
    public bool PublishedInvoice { get; set; }

    public static void InitMapper()
    {
        TypeAdapterConfig<OrderMaster, OrderMasterSimpleView>.NewConfig()
            .Map(view => view.ExecutorName, order => order.Executor != null ? order.Executor.EmployeeName : "")
            .Map(view => view.OrderStatusName, order => order.OrderStatus.OrderStatusName)
            .Map(view => view.OrderForm, order => order.OrderForm.OrderFormName);
        // .Map(view => view.NumOfPC, order => order.OrderDetails.Sum(d => d.NumOfPc))
        // .Map(view => view.NumOfData, order => order.OrderDetails.Sum(d => d.NumOfData))
        // .Map(view => view.NumOfInv, order => order.OrderDetails.Sum(d => d.NumOfInv))
        // .Map(view => view.NumOfTaxCode, order => order.OrderDetails.Sum(d => d.NumOfTaxCode))
        // .Map(view => view.NumOfUser, order => order.OrderDetails.Sum(d => d.NumOfUser));
    }
}