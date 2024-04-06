using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblOrderTypeList")]
public partial class OrderType
{
    [DisplayName("Mã loại đơn hàng")]
    [Key]
    [Column("OrderTypeID")]
    [StringLength(20)]
    [Unicode(false)]
    public string OrderTypeId { get; set; } = null!;

    [DisplayName("Tên loại đơn hàng")]
    [StringLength(100)]
    public string OrderTypeName { get; set; } = null!;

    [InverseProperty("OrderType")]
    public virtual IEnumerable<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
