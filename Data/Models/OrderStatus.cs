using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblOrderStatusList")]
public partial class OrderStatus
{
    [DisplayName("Mã trạng thái đơn hàng")]
    [Key]
    [Column("OrderStatusID")]
    [StringLength(20)]
    [Unicode(false)]
    public string OrderStatusId { get; set; } = null!;

    [DisplayName("Tên trạng thái đơn hàng")]
    [StringLength(100)]
    public string OrderStatusName { get; set; } = null!;

    [DisplayName("Là trạng thái Đã duyệt")]
    public bool IsAcceptStatus { get; set; }

    [DisplayName("Là trạng thái Hủy")]
    public bool IsCancelStatus { get; set; }

    [DisplayName("Là trạng thái treo")]
    public bool IsSuspendStatus { get; set; }

    [DisplayName("Là trạng thái có thể thay đổi bởi NV Sales")]
    public bool CanChangeStatus { get; set; }

    [InverseProperty("OrderStatus")]
    public virtual IEnumerable<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
