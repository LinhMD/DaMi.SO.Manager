using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class OrderType
{
    [DisplayName("Mã loại đơn hàng")]
    public string OrderTypeId { get; set; } = null!;

    [DisplayName("Tên loại đơn hàng")]
    public string OrderTypeName { get; set; } = null!;

    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
