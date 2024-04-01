using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Data.Models;

[Table("tblOrderFormList")]
public partial class OrderForm
{
    [DisplayName("Mã kiểu đơn hàng")]
    [Key]
    [Column("OrderFormID")]
    [StringLength(20)]
    [Unicode(false)]
    public string OrderFormId { get; set; } = null!;

    [DisplayName("Tên kiểu đơn hàng")]
    [StringLength(150)]
    public string OrderFormName { get; set; } = null!;

    [DisplayName("Có tính theo thời gian")]
    public bool HasByTime { get; set; }

    [DisplayName("Có tính theo MST")]
    public bool HasByTaxCode { get; set; }

    [DisplayName("Có tính theo số Data")]
    public bool HasByNumData { get; set; }

    [DisplayName("Có tính theo số lượng HĐ")]
    public bool HasByQtyInvc { get; set; }

    [DisplayName("Có tính theo dung lượng (GB)")]
    public bool HasByDiskSize { get; set; }

    [DisplayName("Có tính theo máy tính")]
    [Column("HasByPC")]
    public bool HasByPc { get; set; }

    [DisplayName("Có tính theo User")]
    public bool HasByUser { get; set; }

    [DisplayName("Thứ tự sắp xếp")]
    public int SortOrder { get; set; }

    [InverseProperty("OrderForm")]
    public virtual ICollection<OrderMaster> OrderMasters { get; set; } = new List<OrderMaster>();
}
