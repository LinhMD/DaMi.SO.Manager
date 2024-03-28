using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class OrderStatus
{
    /// <summary>
    /// Mã trạng thái đơn hàng
    /// </summary>
    [DisplayName("Mã trạng thái đơn hàng")]
    public string OrderStatusId { get; set; } = null!;

    /// <summary>
    /// Tên trạng thái đơn hàng
    /// </summary>
    [DisplayName("Tên trạng thái đơn hàng")]
    public string OrderStatusName { get; set; } = null!;

    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
