using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class CustomerUser
{
    public Guid RowUniqueId { get; set; }

    [DisplayName("Mã khách hàng")]
    public string CustomerId { get; set; } = null!;

    [DisplayName("Mã loại sản phẩm")]
    public string ItemTypeId { get; set; } = null!;

    [DisplayName("Mã User KH")]
    public string CustomerUserId { get; set; } = null!;

    [DisplayName("Tên User KH")]
    public string CustomerUserName { get; set; } = null!;

    [DisplayName("Mật khẩu User KH")]
    public string? CustomerUserPassword { get; set; }

    [DisplayName("Mã đơn đặt hàng chi tiết")]
    public Guid? OrderDetailId { get; set; }

    [DisplayName("Có hiệu lực")]
    public bool Actived { get; set; }

    [DisplayName("Ngày cập nhật")]
    public DateTime CreatedDate { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    public string LastModifiedUserId { get; set; } = null!;

    public virtual OrderDetail? OrderDetail { get; set; }
}
