using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblOrderDetail")]
[Index("OrderId", "ItemId", Name = "UK_tblOrderDetail", IsUnique = true)]
public partial class OrderDetail
{
    [Key]
    [Column("RowUniqueID")]
    public Guid RowUniqueId { get; set; }

    [DisplayName("Mã đơn đặt hàng")]
    [Column("OrderID")]
    public Guid OrderId { get; set; }

    [DisplayName("Thứ tự dòng")]
    public int LineNumber { get; set; }

    [DisplayName("Mã Vật tư sản phẩm hàng hóa")]
    [Column("ItemID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemId { get; set; } = null!;

    [DisplayName("Số lượng mã số thuế")]
    public int NumOfTaxCode { get; set; }

    [DisplayName("Số lượng hệ thống")]
    public int NumOfData { get; set; }

    [DisplayName("Số lượng hóa đơn")]
    public int NumOfInv { get; set; }

    [DisplayName("Số lượng User")]
    public int NumOfUser { get; set; }

    [DisplayName("Số lượng máy tính")]
    [Column("NumOfPC")]
    public int NumOfPc { get; set; }

    [DisplayName("Dung lượng lưu trữ iCloud (GB)")]
    [Column("iCloudDataSize")]
    public int ICloudDataSize { get; set; }

    [DisplayName("Số lượng tháng")]
    public int NumOfMonth { get; set; }

    [DisplayName("Danh sách Mã số thuế sử dụng")]
    [StringLength(500)]
    [Unicode(false)]
    public string? TaxCode { get; set; }

    [DisplayName("Ngày bắt đầu sử dụng")]
    public DateTime? StartDate { get; set; }

    [DisplayName("Số lượng")]
    public double Quantity { get; set; }

    [DisplayName("Đơn giá quy đổi (VND)")]
    public double ConvertPrice { get; set; }

    [DisplayName("Đơn giá nguyên tệ")]
    public double OriginalPrice { get; set; }

    [DisplayName("Thuế suất")]
    [Column(TypeName = "smallmoney")]
    public decimal TaxRate { get; set; }

    [DisplayName("Tiền thuế")]
    [Column(TypeName = "money")]
    public decimal ConvertTaxAmount { get; set; }

    [DisplayName("Số tiền VND")]
    [Column(TypeName = "money")]
    public decimal ConvertAmount { get; set; }

    [DisplayName("Tổng số tiền")]
    [Column(TypeName = "money")]
    public decimal ConvertTotalAmount { get; set; }

    [DisplayName("Số tiền đã thanh toán")]
    [Column(TypeName = "money")]
    public decimal CnvPaymentAmount { get; set; }

    [DisplayName("Loại tiền")]
    [Column("CurrencyID")]
    [StringLength(3)]
    [Unicode(false)]
    public string CurrencyId { get; set; } = null!;

    [DisplayName("Tỷ giá")]
    [Column(TypeName = "smallmoney")]
    public decimal ExchangeRate { get; set; }

    [DisplayName("Tiền thuế nguyên tệ")]
    [Column(TypeName = "money")]
    public decimal OriginalTaxAmount { get; set; }

    [DisplayName("Thành tiền nguyên tệ")]
    [Column(TypeName = "money")]
    public decimal OriginalAmount { get; set; }

    [DisplayName("Tổng số tiền USD")]
    [Column(TypeName = "money")]
    public decimal OriginalTotalAmount { get; set; }

    [DisplayName("Số tiền đã thanh toán USD")]
    [Column(TypeName = "money")]
    public decimal OrgPaymentAmount { get; set; }

    [DisplayName("Phần trăm chiết khấu")]
    public double DiscountPercent { get; set; }

    [DisplayName("Chiết khấu VND")]
    [Column(TypeName = "money")]
    public decimal ConvertDiscAmount { get; set; }

    [DisplayName("Chiết khấu nguyên tệ")]
    [Column(TypeName = "money")]
    public decimal OriginalDiscAmount { get; set; }

    [DisplayName("Ngày tạo")]
    public DateTime CreatedDate { get; set; }

    [DisplayName("Mã người tạo")]
    [Column("CreatedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CreatedUserId { get; set; } = null!;

    [DisplayName("Ngày chỉnh sửa cuối cùng")]
    public DateTime LastModifiedDate { get; set; }

    [DisplayName("Mã người chỉnh sửa cuối cùng")]
    [Column("LastModifiedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string LastModifiedUserId { get; set; } = null!;

    [Column("RowVersionID")]
    public byte[]? RowVersionId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual OrderMaster Order { get; set; } = null!;

    [InverseProperty("OrderDetail")]
    public virtual ICollection<ComputerItemMap> ComputerItemMaps { get; set; } = new List<ComputerItemMap>();

    [InverseProperty("OrderDetail")]
    public virtual ICollection<CustomerUser> CustomerUsers { get; set; } = new List<CustomerUser>();
}
