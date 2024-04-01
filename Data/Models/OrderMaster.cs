using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class OrderMaster
{
    public Guid RowUniqueId { get; set; }

    [DisplayName("Số đơn đặt hàng")]
    public string? OrderNo { get; set; }

    [DisplayName("Số thứ tự trong tháng")]
    public long SeqInMonth { get; set; }

    [DisplayName("Số thứ tự trong năm")]
    public long SeqInYear { get; set; }

    [DisplayName("Ngày đặt hàng")]
    public DateTime OrderDate { get; set; }

    [DisplayName("Ngày bắt đầu triển khai")]
    public DateTime? BeginExecDate { get; set; }

    [DisplayName("Ngày kết thúc triển khai")]
    public DateTime? EndExecDate { get; set; }

    [DisplayName("Hạn thanh toán")]
    public DateOnly? OverDate { get; set; }

    [DisplayName("Mã loại đơn hàng")]
    public string OrderTypeId { get; set; } = null!;

    [DisplayName("Mã kiểu đơn hàng")]
    public string OrderFormId { get; set; } = null!;

    [DisplayName("Diễn giải")]
    public string? Description { get; set; }

    [DisplayName("Mã khách hàng")]
    public string CustomerId { get; set; } = null!;

    [DisplayName("Người đại diện")]
    public string? RefPerson { get; set; }

    [DisplayName("Chức vụ")]
    public string? RefPos { get; set; }

    [DisplayName("Số hợp đồng")]
    public string? ContractNo { get; set; }

    [DisplayName("Ngày hợp đồng")]
    public DateOnly? ContractDate { get; set; }

    [DisplayName("Mã nhân viên bán hàng")]
    public string? SalesManId { get; set; }

    [DisplayName("Mã nhân viên triển khai")]
    public string? ExecutorId { get; set; }

    [DisplayName("Thuế suất")]
    public decimal TaxRate { get; set; }

    [DisplayName("Tổng số tiền")]
    public decimal ConvertTotalAmount { get; set; }

    [DisplayName("Tiền thuế quy đổi VND")]
    public decimal ConvertTaxAmount { get; set; }

    [DisplayName("Loại tiền")]
    public string CurrencyId { get; set; } = null!;

    [DisplayName("Tỷ giá")]
    public decimal ExchangeRate { get; set; }

    [DisplayName("Tổng số tiền")]
    public decimal OriginalTotalAmount { get; set; }

    [DisplayName("Tiền thuế nguyên tệ")]
    public decimal OriginalTaxAmount { get; set; }

    [DisplayName("Có xuất đơn GTGT")]
    public bool HasInvoiceVat { get; set; }

    [DisplayName("Giá sau thuế")]
    public bool IsPriceAfterTax { get; set; }

    [DisplayName("Có chiết khấu")]
    public bool HasDiscount { get; set; }

    [DisplayName("Phần trăm chiết khấu (hoặc đơn giá chiết khấu)")]
    public double DiscountPercent { get; set; }

    [DisplayName("Chiết khấu VND")]
    public decimal ConvertDiscAmount { get; set; }

    [DisplayName("Chiết khấu nguyên tệ")]
    public decimal OriginalDiscAmount { get; set; }

    [DisplayName("Mã hình thức thanh toán")]
    public string? PaymentMethodId { get; set; }

    [DisplayName("Điều khoản thanh toán")]
    public string? PaymentTerms { get; set; }

    [DisplayName("Ghi chú")]
    public string? Notes { get; set; }

    [DisplayName("Trạng thái đơn đặt hàng")]
    public string OrderStatusId { get; set; } = null!;

    [DisplayName("Đã xuất Hóa đơn")]
    public bool PublishedInvoice { get; set; }

    [DisplayName("Đã thanh toán")]
    public bool Paymented { get; set; }

    [DisplayName("Đã duyệt")]
    public bool Accepted { get; set; }

    [DisplayName("Người duyệt")]
    public string? AccepterId { get; set; }

    [DisplayName("Ngày duyệt")]
    public DateTime? AcceptedDate { get; set; }

    [DisplayName("Đã bị hủy")]
    public bool IsCancel { get; set; }

    [DisplayName("Ngày hủy đơn hàng")]
    public DateTime? CancelOrderDate { get; set; }

    [DisplayName("Đang triển khai")]
    public bool IsExecuting { get; set; }

    [DisplayName("Đã hoàn thành")]
    public bool FinishOk { get; set; }

    public string SubCompanyId { get; set; } = null!;

    public int? TranYear { get; set; }

    public int? TranMonth { get; set; }

    [DisplayName("Ngày tạo")]
    public DateTime CreatedDate { get; set; }

    [DisplayName("Mã người tạo")]
    public string CreatedUserId { get; set; } = null!;

    [DisplayName("Ngày giờ hiệu chỉnh cuối cùng")]
    public DateTime LastModifiedDate { get; set; }

    [DisplayName("người hiệu chỉnh cuối cùng")]
    public string LastModifiedUserId { get; set; } = null!;

    public byte[]? RowVersionId { get; set; }

    public virtual Employee? Executor { get; set; }

    public virtual OrderForm OrderForm { get; set; } = null!;

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual OrderType OrderType { get; set; } = null!;

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual Employee? SalesMan { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
