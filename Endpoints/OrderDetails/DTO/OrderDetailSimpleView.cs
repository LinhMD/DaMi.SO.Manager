using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CrudApiTemplate.Model;
using CrudApiTemplate.Request;
using CrudApiTemplate.View;
using DaMi.SO.Manager.Data.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace DaMi.SO.Manager.Endpoints.OrderDetails.DTO;


public class OrderDetailSimpleView : IView<OrderDetail>, IDto, IUpdateRequest<OrderDetail>, ICreateRequest<OrderDetail>
{

    [HiddenInput]
    public Guid? RowUniqueId { get; set; }

    [HiddenInput]
    [DisplayName("Mã đơn đặt hàng")]
    public Guid? OrderId { get; set; }

    [DisplayName("Thứ tự dòng")]
    public int? LineNumber { get; set; }

    [DisplayName("Mã Vật tư sản phẩm hàng hóa")]
    public string? ItemId { get; set; } = null!;

    [DisplayName("Số lượng mã số thuế")]
    public int? NumOfTaxCode { get; set; }

    [DisplayName("Số lượng hệ thống")]
    public int? NumOfData { get; set; }

    [DisplayName("Số lượng hóa đơn")]
    public int? NumOfInv { get; set; }

    [DisplayName("Số lượng User")]
    public int? NumOfUser { get; set; }

    [DisplayName("Số lượng máy tính")]
    public int? NumOfPc { get; set; }

    [DisplayName("Dung lượng lưu trữ iCloud (GB)")]
    public int? ICloudDataSize { get; set; }

    [DisplayName("Số lượng tháng")]
    public int? NumOfMonth { get; set; }

    [DisplayName("Danh sách Mã số thuế sử dụng")]
    public string? TaxCode { get; set; }

    [DisplayName("Số lượng")]
    public double? Quantity { get; set; }

    [DataType(DataType.Currency)]
    [DisplayName("Đơn giá quy đổi (VND)")]
    public double ConvertPrice { get; set; }

    [DataType(DataType.Currency)]
    [DisplayName("Đơn giá nguyên tệ")]
    public double? OriginalPrice { get; set; }

    [DisplayName("Thuế suất")]
    public decimal? TaxRate { get; set; }

    [DisplayName("Tiền thuế")]
    public decimal ConvertTaxAmount => (TaxRate ?? 0) * ConvertAmount / 100;

    [DisplayName("Số tiền VND")]
    public decimal ConvertAmount => Convert.ToDecimal(ConvertPrice * Quantity);

    [DisplayName("Tổng số tiền")]
    public decimal ConvertTotalAmount => ConvertAmount + ConvertTaxAmount - (ConvertDiscAmount ?? 0);

    [DisplayName("Loại tiền")]
    public string? CurrencyId { get; set; } = null!;

    [DisplayName("Tỷ giá")]
    public decimal? ExchangeRate { get; set; }

    [DisplayName("Tiền thuế nguyên tệ")]
    public decimal OriginalTaxAmount => (TaxRate ?? 0) * OriginalAmount / 100;

    [DisplayName("Thành tiền nguyên tệ")]
    public decimal OriginalAmount => Convert.ToDecimal(OriginalPrice * Quantity);

    [DisplayName("Tổng số tiền")]
    public decimal OriginalTotalAmount => OriginalAmount + OriginalTaxAmount - (OriginalDiscAmount ?? 0);

    [DisplayName("Phần trăm chiết khấu")]
    public double? DiscountPercent { get; set; }

    [DisplayName("Chiết khấu VND")]
    public decimal? ConvertDiscAmount { get; set; }

    [DisplayName("Chiết khấu nguyên tệ")]
    public decimal? OriginalDiscAmount { get; set; }

    [DisplayName("Ngày tạo")]
    public DateTime? CreatedDate { get; set; }

    [DisplayName("Mã người tạo")]
    public string? CreatedUserId { get; set; } = null!;

    [DisplayName("Ngày chỉnh sửa cuối cùng")]
    public DateTime? LastModifiedDate { get; set; }

    [DisplayName("Mã người chỉnh sửa cuối cùng")]
    public string? LastModifiedUserId { get; set; } = null!;

    [DisplayName("Ngày sử dụng")]
    public DateTime? StartDate { get; set; }

    public static void InitMapper()
    {
        TypeAdapterConfig<OrderDetail, OrderDetailSimpleView>.NewConfig();

        TypeAdapterConfig<OrderDetailSimpleView, OrderDetail>.NewConfig();
    }
}
