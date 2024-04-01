using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblCustomerUserList")]
[Index("CustomerId", V, "CustomerUserId", Name = "UK_tblCustomerUserList", IsUnique = true)]
public partial class CustomerUser
{
    private const string V = "ItemTypeId";

    [Key]
    [Column("RowUniqueID")]
    public Guid RowUniqueId { get; set; }

    [DisplayName("Mã khách hàng")]
    [Column("CustomerID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CustomerId { get; set; } = null!;

    [DisplayName("Mã loại sản phẩm")]
    [Column("ItemTypeID")]
    [StringLength(20)]
    [Unicode(false)]
    public string ItemTypeId { get; set; } = null!;

    [DisplayName("Mã User KH")]
    [Column("CustomerUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CustomerUserId { get; set; } = null!;

    [DisplayName("Tên User KH")]
    [StringLength(100)]
    public string CustomerUserName { get; set; } = null!;

    [DisplayName("Mật khẩu User KH")]
    [StringLength(50)]
    public string? CustomerUserPassword { get; set; }

    [DisplayName("Mã đơn đặt hàng chi tiết")]
    [Column("OrderDetailID")]
    public Guid? OrderDetailId { get; set; }

    [DisplayName("Có hiệu lực")]
    public bool Actived { get; set; }

    [DisplayName("Ngày cập nhật")]
    public DateTime CreatedDate { get; set; }

    [Column("CreatedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string CreatedUserId { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    [Column("LastModifiedUserID")]
    [StringLength(20)]
    [Unicode(false)]
    public string LastModifiedUserId { get; set; } = null!;

    [ForeignKey("OrderDetailId")]
    [InverseProperty("CustomerUsers")]
    public virtual OrderDetail? OrderDetail { get; set; }
}
