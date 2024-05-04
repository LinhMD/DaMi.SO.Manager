using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CrudApiTemplate.Attributes.Update;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblOrderMaster")]
[Index("TranYear", "TranMonth", "SubCompanyId", "SeqInMonth", Name = "UK_tblOrderMaster", IsUnique = true)]
public partial class OrderMaster
{
    [Key]
    [Column("RowUniqueID")]
    public Guid RowUniqueId { get; set; } = Guid.NewGuid();

    [DisplayName("Số đơn đặt hàng")]
    [StringLength(20)]
    [Unicode(false)]
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
    [Column("OrderTypeID")]
    [StringLength(20)]
    [Unicode(false)]
    public string OrderTypeId { get; set; } = null!;

    [DisplayName("Mã kiểu đơn hàng")]
    [Column("OrderFormID")]
    [StringLength(20)]
    [Unicode(false)]
    public string OrderFormId { get; set; } = null!;

    [DisplayName("Diễn giải")]
    [StringLength(800)]
    public string? Description { get; set; }

    [DisplayName("Mã khách hàng")]
    [Column("CustomerID")]
    [StringLength(20)]
    [Unicode(false)]
    [Required]
    public string CustomerId { get; set; } = null!;

    [DisplayName("Người đại diện")]
    [StringLength(60)]
    public string? RefPerson { get; set; }

    [DisplayName("Chức vụ")]
    [StringLength(40)]
    public string? RefPos { get; set; }

    [DisplayName("Số hợp đồng")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ContractNo { get; set; }

    [DisplayName("Ngày hợp đồng")]
    public DateOnly? ContractDate { get; set; }

    [DisplayName("Mã nhân viên bán hàng")]
    [Column("SalesManID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? SalesManId { get; set; }

    [DisplayName("Mã nhân viên triển khai")]
    [Column("ExecutorID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ExecutorId { get; set; }

    [DisplayName("Thuế suất")]
    [Column(TypeName = "smallmoney")]
    public decimal TaxRate { get; set; }

    [DisplayName("Tổng số tiền")]
    [Column(TypeName = "money")]
    public decimal ConvertTotalAmount { get; set; }

    [DisplayName("Tiền thuế quy đổi VND")]
    [Column(TypeName = "money")]
    public decimal ConvertTaxAmount { get; set; }

    [DisplayName("Loại tiền")]
    [Column("CurrencyID")]
    [StringLength(3)]
    [Unicode(false)]
    public string CurrencyId { get; set; } = null!;

    [DisplayName("Tỷ giá")]
    [Column(TypeName = "smallmoney")]
    public decimal ExchangeRate { get; set; }

    [DisplayName("Tổng số tiền")]
    [Column(TypeName = "money")]
    public decimal OriginalTotalAmount { get; set; }

    [DisplayName("Tiền thuế nguyên tệ")]
    [Column(TypeName = "money")]
    public decimal OriginalTaxAmount { get; set; }

    [DisplayName("Có xuất đơn GTGT")]
    [Column("HasInvoiceVAT")]
    public bool HasInvoiceVat { get; set; }

    [DisplayName("Giá sau thuế")]
    public bool IsPriceAfterTax { get; set; }

    [DisplayName("Có chiết khấu")]
    public bool HasDiscount { get; set; }

    [DisplayName("Phần trăm chiết khấu (hoặc đơn giá chiết khấu)")]
    public double DiscountPercent { get; set; }

    [DisplayName("Chiết khấu VND")]
    [Column(TypeName = "money")]
    public decimal ConvertDiscAmount { get; set; }

    [DisplayName("Chiết khấu nguyên tệ")]
    [Column(TypeName = "money")]
    public decimal OriginalDiscAmount { get; set; }

    [DisplayName("Mã hình thức thanh toán")]
    [Column("PaymentMethodID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PaymentMethodId { get; set; }

    [DisplayName("Điều khoản thanh toán")]
    [StringLength(150)]
    public string? PaymentTerms { get; set; }

    [DisplayName("Ghi chú")]
    [StringLength(250)]
    public string? Notes { get; set; }

    [DisplayName("Trạng thái đơn đặt hàng")]
    [Column("OrderStatusID")]
    [StringLength(20)]
    [Unicode(false)]
    public string OrderStatusId { get; set; } = null!;

    [DisplayName("Đã xuất Hóa đơn")]
    public bool PublishedInvoice { get; set; }

    [DisplayName("Đã thanh toán")]
    public bool Paymented { get; set; }

    [DisplayName("Đã duyệt")]
    public bool Accepted { get; set; }

    [DisplayName("Người duyệt")]
    [Column("AccepterID")]
    [StringLength(20)]
    [Unicode(false)]
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

    [Column("SubCompanyID")]
    [StringLength(20)]
    [Unicode(false)]
    public string SubCompanyId { get; set; } = null!;

    public int? TranYear { get; set; }

    public int? TranMonth { get; set; }

    [DisplayName("Ngày tạo")]
    public DateTime CreatedDate { get; set; }

    [DisplayName("Mã người tạo")]
    [Column("CreatedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CreatedUserId { get; set; } = null!;

    [DisplayName("Ngày giờ hiệu chỉnh cuối cùng")]
    public DateTime LastModifiedDate { get; set; }

    [DisplayName("người hiệu chỉnh cuối cùng")]
    [Column("LastModifiedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string LastModifiedUserId { get; set; } = null!;

    [Column("RowVersionID")]
    public byte[]? RowVersionId { get; set; }

    [ForeignKey("ExecutorId")]
    [InverseProperty("OrderMasterExecutors")]
    public virtual Employee? Executor { get; set; }

    [ForeignKey("OrderFormId")]
    [InverseProperty("OrderMasters")]
    public virtual OrderForm OrderForm { get; set; } = null!;

    [ForeignKey("OrderStatusId")]
    [InverseProperty("OrderMasters")]
    public virtual OrderStatus OrderStatus { get; set; } = null!;

    [ForeignKey("OrderTypeId")]
    [InverseProperty("OrderMasters")]
    public virtual OrderType OrderType { get; set; } = null!;

    [ForeignKey("PaymentMethodId")]
    [InverseProperty("OrderMasters")]
    public virtual PaymentMethod? PaymentMethod { get; set; }

    [ForeignKey("SalesManId")]
    [InverseProperty("OrderMasterSalesMen")]
    public virtual Employee? SalesMan { get; set; }

    [InverseProperty("Order")]
    [UpdateIgnore]
    public virtual IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
