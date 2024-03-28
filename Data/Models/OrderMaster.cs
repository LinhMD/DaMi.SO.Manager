using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class OrderMaster
{
    public Guid RowUniqueId { get; set; }

    /// <summary>
    /// Số đơn đặt hàng
    /// </summary>
    [DisplayName("Số đơn đặt hàng")]
    public string? OrderNo { get; set; }

    /// <summary>
    /// Số thứ tự trong tháng
    /// </summary>
    [DisplayName("Số thứ tự trong tháng")]
    public long SeqInMonth { get; set; }

    /// <summary>
    /// Số thứ tự trong năm
    /// </summary>
    [DisplayName("Số thứ tự trong năm")]
    public long SeqInYear { get; set; }

    /// <summary>
    /// Ngày đặt hàng
    /// </summary>
    [DisplayName("Ngày đặt hàng")]
    public DateTime OrderDate { get; set; }

    public DateTime? BeginExecDate { get; set; }

    public DateTime? EndExecDate { get; set; }

    /// <summary>
    /// Hạn thanh toán
    /// </summary>
    [DisplayName("Hạn thanh toán")]
    public DateOnly? OverDate { get; set; }

    /// <summary>
    /// Loại đơn hàng
    /// </summary>
    [DisplayName("Loại đơn hàng")]
    public string OrderTypeId { get; set; } = null!;

    /// <summary>
    /// Mã Form nhập
    /// </summary>
    [DisplayName("Mã Form nhập")]
    public string OrderFormId { get; set; } = null!;

    /// <summary>
    /// Diễn giải
    /// </summary>
    [DisplayName("Diễn giải")]
    public string? Description { get; set; }

    /// <summary>
    /// Mã khách hàng
    /// </summary>
    [DisplayName("Mã khách hàng")]
    public string CustomerId { get; set; } = null!;

    /// <summary>
    /// Người đại diện
    /// </summary>
    [DisplayName("Người đại diện")]
    public string? RefPerson { get; set; }

    /// <summary>
    /// Chức vụ
    /// </summary>
    [DisplayName("Chức vụ")]
    public string? RefPos { get; set; }

    /// <summary>
    /// Số hợp đồng
    /// </summary>
    [DisplayName("Số hợp đồng")]
    public string? ContractNo { get; set; }

    /// <summary>
    /// Ngày hợp đồng
    /// </summary>
    [DisplayName("Ngày hợp đồng")]
    public DateOnly? ContractDate { get; set; }

    /// <summary>
    /// Mã nhân viên bán hàng
    /// </summary>
    [DisplayName("Mã nhân viên bán hàng")]
    public string? SalesManId { get; set; }

    public string? ExecutorId { get; set; }

    /// <summary>
    /// Thuế suất
    /// </summary>
    [DisplayName("Thuế suất")]
    public decimal TaxRate { get; set; }

    /// <summary>
    /// Tổng số tiền
    /// </summary>
    [DisplayName("Tổng số tiền")]
    public decimal ConvertTotalAmount { get; set; }

    /// <summary>
    /// Tiền thuế quy đổi VND
    /// </summary>
    [DisplayName("Tiền thuế quy đổi VND")]
    public decimal ConvertTaxAmount { get; set; }

    /// <summary>
    /// Loại tiền
    /// </summary>
    [DisplayName("Loại tiền")]
    public string CurrencyId { get; set; } = null!;

    /// <summary>
    /// Tỷ giá
    /// </summary>
    [DisplayName("Tỷ giá")]
    public decimal ExchangeRate { get; set; }

    /// <summary>
    /// Tổng số tiền
    /// </summary>
    [DisplayName("Tổng số tiền")]
    public decimal OriginalTotalAmount { get; set; }

    /// <summary>
    /// Tiền thuế nguyên tệ
    /// </summary>
    [DisplayName("Tiền thuế nguyên tệ")]
    public decimal OriginalTaxAmount { get; set; }

    /// <summary>
    /// Có hóa đơn GTGT
    /// </summary>
    [DisplayName("Có hóa đơn GTGT")]
    public bool HasInvoiceVat { get; set; }

    /// <summary>
    /// Giá sau thuế
    /// </summary>
    [DisplayName("Giá sau thuế")]
    public bool IsPriceAfterTax { get; set; }

    /// <summary>
    /// Có chiết khấu
    /// </summary>
    [DisplayName("Có chiết khấu")]
    public bool HasDiscount { get; set; }

    /// <summary>
    /// Phần trăm chiết khấu (hoặc đơn giá chiết khấu)
    /// </summary>
    [DisplayName("Phần trăm chiết khấu (hoặc đơn giá chiết khấu)")]
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
    /// Mã hình thức thanh toán
    /// </summary>
    [DisplayName("Mã hình thức thanh toán")]
    public string? PaymentMethodId { get; set; }

    /// <summary>
    /// Điều khoản thanh toán
    /// </summary>
    [DisplayName("Điều khoản thanh toán")]
    public string? PaymentTerms { get; set; }

    /// <summary>
    /// Ghi chú
    /// </summary>
    [DisplayName("Ghi chú")]
    public string? Notes { get; set; }

    /// <summary>
    /// Trạng thái đơn đặt hàng
    /// </summary>
    [DisplayName("Trạng thái đơn đặt hàng")]
    public string OrderStatusId { get; set; } = null!;

    /// <summary>
    /// Đã duyệt
    /// </summary>
    [DisplayName("Đã duyệt")]
    public bool Accepted { get; set; }

    /// <summary>
    /// Người duyệt
    /// </summary>
    [DisplayName("Người duyệt")]
    public string? AccepterId { get; set; }

    /// <summary>
    /// Ngày duyệt
    /// </summary>
    [DisplayName("Ngày duyệt")]
    public DateTime? AcceptedDate { get; set; }

    /// <summary>
    /// Đã bị hủy
    /// </summary>
    [DisplayName("Đã bị hủy")]
    public bool IsCancel { get; set; }

    /// <summary>
    /// Ngày hủy đơn hàng
    /// </summary>
    [DisplayName("Ngày hủy đơn hàng")]
    public DateTime? CancelOrderDate { get; set; }

    /// <summary>
    /// Đang triển khai
    /// </summary>
    [DisplayName("Đang triển khai")]
    public bool IsExecuting { get; set; }

    /// <summary>
    /// Đã hoàn thành
    /// </summary>
    [DisplayName("Đã hoàn thành")]
    public bool FinishOk { get; set; }

    public string SubCompanyId { get; set; } = null!;

    public int? TranYear { get; set; }

    public int? TranMonth { get; set; }

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
    /// Ngày giờ hiệu chỉnh cuối cùng
    /// </summary>
    [DisplayName("Ngày giờ hiệu chỉnh cuối cùng")]
    public DateTime LastModifiedDate { get; set; }

    /// <summary>
    /// người hiệu chỉnh cuối cùng
    /// </summary>
    [DisplayName("người hiệu chỉnh cuối cùng")]
    public string LastModifiedUserId { get; set; } = null!;

    public byte[]? RowVersionId { get; set; }
    [DisplayName("Đã xuất Hóa đơn")]
    public bool PublishedInvoice { get; set; }

    public virtual CustomerLink Customer { get; set; } = null!;

    public virtual Employee? Executor { get; set; }

    public virtual OrderForm OrderForm { get; set; } = null!;

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual OrderType OrderType { get; set; } = null!;

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual Employee? SalesMan { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
