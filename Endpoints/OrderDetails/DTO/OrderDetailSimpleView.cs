using System.ComponentModel;
using CrudApiTemplate.Model;
using CrudApiTemplate.View;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace DaMi.SO.Manager.Endpoints.OrderDetails.DTO;


public class OrderDetailSimpleView : IDto
{

    [HiddenInput]
    public Guid RowUniqueId { get; set; }

    /// <summary>
    /// Mã đơn đặt hàng
    /// </summary>
    [HiddenInput]
    [DisplayName("Mã đơn đặt hàng")]
    public Guid OrderId { get; set; }

    /// <summary>
    /// Thứ tự dòng
    /// </summary>
    [DisplayName("Thứ tự dòng")]
    public int LineNumber { get; set; }

    /// <summary>
    /// Mã Vật tư sản phẩm hàng hóa
    /// </summary>
    [DisplayName("Mã Vật tư sản phẩm hàng hóa")]
    public string ItemId { get; set; } = null!;

    /// <summary>
    /// Số lượng mã số thuế
    /// </summary>
    [DisplayName("Số lượng mã số thuế")]
    public int NumOfTaxCode { get; set; }

    /// <summary>
    /// Số lượng hệ thống
    /// </summary>
    [DisplayName("Số lượng hệ thống")]
    public int NumOfData { get; set; }

    /// <summary>
    /// Số lượng hóa đơn
    /// </summary>
    [DisplayName("Số lượng hóa đơn")]
    public int NumOfInv { get; set; }

    /// <summary>
    /// Số lượng User
    /// </summary>
    [DisplayName("Số lượng User")]
    public int NumOfUser { get; set; }

    /// <summary>
    /// Số lượng máy tính
    /// </summary>
    [DisplayName("Số lượng máy tính")]
    public int NumOfPc { get; set; }

    /// <summary>
    /// Dung lượng lưu trữ iCloud (GB)
    /// </summary>
    [DisplayName("Dung lượng lưu trữ iCloud (GB)")]
    public int ICloudDataSize { get; set; }

    /// <summary>
    /// Số lượng tháng
    /// </summary>
    [DisplayName("Số lượng tháng")]
    public int NumOfMonth { get; set; }

    /// <summary>
    /// Danh sách Mã số thuế sử dụng
    /// </summary>
    [DisplayName("Danh sách Mã số thuế sử dụng")]
    public string? TaxCode { get; set; }

    /// <summary>
    /// Số lượng
    /// </summary>
    [DisplayName("Số lượng")]
    public double Quantity { get; set; }

    /// <summary>
    /// Đơn giá quy đổi (VND)
    /// </summary>
    [DisplayName("Đơn giá quy đổi (VND)")]
    public double ConvertPrice { get; set; }

    /// <summary>
    /// Đơn giá nguyên tệ
    /// </summary>
    [DisplayName("Đơn giá nguyên tệ")]
    public double OriginalPrice { get; set; }

    /// <summary>
    /// Thuế suất
    /// </summary>
    [DisplayName("Thuế suất")]
    public decimal TaxRate { get; set; }

    /// <summary>
    /// Tiền thuế
    /// </summary>
    [DisplayName("Tiền thuế")]
    public decimal ConvertTaxAmount { get; set; }

    /// <summary>
    /// Số tiền VND
    /// </summary>
    [DisplayName("Số tiền VND")]
    public decimal ConvertAmount { get; set; }

    /// <summary>
    /// Tổng số tiền
    /// </summary>
    [DisplayName("Tổng số tiền")]
    public decimal ConvertTotalAmount { get; set; }

    /// <summary>
    /// Loại tiền
    /// </summary>
    [DisplayName("Loại tiền")]
    public string CurrencyId { get; set; } = null!;

    /// <summary>
    /// Tỷ giá
    /// </summary>
    [DisplayName("Tỷ giá")]
    public decimal ExchangeRate { get; set; }

    /// <summary>
    /// Tiền thuế nguyên tệ
    /// </summary>
    [DisplayName("Tiền thuế nguyên tệ")]
    public decimal OriginalTaxAmount { get; set; }

    /// <summary>
    /// Thành tiền nguyên tệ
    /// </summary>
    [DisplayName("Thành tiền nguyên tệ")]
    public decimal OriginalAmount { get; set; }

    /// <summary>
    /// Tổng số tiền
    /// </summary>
    [DisplayName("Tổng số tiền")]
    public decimal OriginalTotalAmount { get; set; }

    /// <summary>
    /// Phần trăm chiết khấu
    /// </summary>
    [DisplayName("Phần trăm chiết khấu")]
    public double DiscountPercent { get; set; }

    /// <summary>
    /// Chiết khấu VND
    /// </summary>
    [DisplayName("Chiết khấu VND")]
    public decimal ConvertDiscAmount { get; set; }

    /// <summary>
    /// Chiết khấu nguyên tệ
    /// </summary>
    [DisplayName("Chiết khấu nguyên tệ")]
    public decimal OriginalDiscAmount { get; set; }

    /// <summary>
    /// Ngày tạo
    /// </summary>
    [DisplayName("Ngày tạo")]
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Mã người tạo
    /// </summary>
    [DisplayName("Mã người tạo")]
    public string CreatedUserId { get; set; } = null!;

    /// <summary>
    /// Ngày chỉnh sửa cuối cùng
    /// </summary>
    [DisplayName("Ngày chỉnh sửa cuối cùng")]
    public DateTime LastModifiedDate { get; set; }

    /// <summary>
    /// Mã người chỉnh sửa cuối cùng
    /// </summary>
    [DisplayName("Mã người chỉnh sửa cuối cùng")]
    public string LastModifiedUserId { get; set; } = null!;

    // public byte[]? RowVersionId { get; set; }

    // public virtual WhItemLink Item { get; set; } = null!;

    // public virtual OrderMaster Order { get; set; } = null!;

    // public virtual ICollection<ComputerItemMap> ComputerItemMaps { get; set; } = new List<ComputerItemMap>();

    // public virtual ICollection<CustomerUser> CustomerUsers { get; set; } = new List<CustomerUser>();

    public static void InitMapper()
    {
        //TypeAdapterConfig<OrderDetail, OrderDetailSimpleView>.NewConfig();
    }
}
