using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class CustomerUser
{
    public Guid RowUniqueId { get; set; }

    public string CustomerId { get; set; } = null!;

    public string ItemTypeId { get; set; } = null!;

    public string CustomerUserId { get; set; } = null!;

    public string CustomerUserName { get; set; } = null!;

    public string? CustomerUserPassword { get; set; }

    /// <summary>
    /// Mã đơn đặt hàng chi tiết
    /// </summary>
    [DisplayName("Mã đơn đặt hàng chi tiết")]
    public Guid? OrderDetailId { get; set; }

    public bool Actived { get; set; }

    /// <summary>
    /// Ngày cập nhật
    /// </summary>
    [DisplayName("Ngày cập nhật")]
    public DateTime CreatedDate { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public DateTime LastModifiedDate { get; set; }

    public string LastModifiedUserId { get; set; } = null!;

    public virtual CustomerLink Customer { get; set; } = null!;

    public virtual OrderDetail? OrderDetail { get; set; }
}
