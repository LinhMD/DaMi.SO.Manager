using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DaMi.SO.Manager.Data.Models;

public partial class OrderStatus
{
    [DisplayName("Mã trạng thái đơn hàng")]
    public string OrderStatusId { get; set; } = null!;

    [DisplayName("Tên trạng thái đơn hàng")]
    public string OrderStatusName { get; set; } = null!;

    [DisplayName("Là trạng thái Đã duyệt")]
    public bool IsAcceptStatus { get; set; }

    [DisplayName("Là trạng thái Hủy")]
    public bool IsCancelStatus { get; set; }

    [DisplayName("Là trạng thái treo")]
    public bool IsSuspendStatus { get; set; }

    [DisplayName("Là trạng thái có thể thay đổi bởi NV Sales")]
    public bool CanChangeStatus { get; set; }

    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
