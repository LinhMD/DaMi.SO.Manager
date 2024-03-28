using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class OrderType
{
    /// <summary>
    /// Mã loại đơn hàng
    /// </summary>
    [DisplayName("Mã loại đơn hàng")]
    public string OrderTypeId { get; set; } = null!;

    /// <summary>
    /// Tên loại đơn hàng
    /// </summary>
    [DisplayName("Tên loại đơn hàng")]
    public string OrderTypeName { get; set; } = null!;

    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
